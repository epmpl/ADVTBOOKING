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
    /// Summary description for AdvertisementMaster
    /// </summary>
    public class AdvertisementMaster:orclconnection
    {
        public AdvertisementMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet AdvTeamDetailSave(string Comp_Code, string Team_Code, string Team_Name, string zone, string userid, string signature, string attachment)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdvTeamDetailSave.AdvTeamDetailSave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Comp_Code;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Team_Code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Team_Code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("Team_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Team_Name;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5= new OracleParameter("zone", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = zone;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("signature", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = signature;
                objOraclecommand.Parameters.Add(prm6);

                //OracleParameter prm7 = new OracleParameter("attachment", OracleType.VarChar, 50);
                //prm7.Direction = ParameterDirection.Input;
                //prm7.Value = attachment;
                //objOraclecommand.Parameters.Add(prm7);




                OracleParameter prm8 = new OracleParameter("attachment", OracleType.VarChar, 70);
                prm8.Direction = ParameterDirection.Input;
                if (attachment == "" && attachment == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = attachment;
                }
                objOraclecommand.Parameters.Add(prm8);
            


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




        public DataSet AdvExecDetail(string Comp_Code, string Team_Code, string Team_Name, string zone, int Flag, string userid, string signature, string attachment)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdvTeamDetail.AdvTeamDetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Comp_Code;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Team_Code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Team_Code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("Team_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Team_Name;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("zone", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (zone == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = zone;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("Flag", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
               
                prm6.Value = Flag;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7= new OracleParameter("signature", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = signature;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("attachment", OracleType.VarChar, 70);
                prm8.Direction = ParameterDirection.Input;
                if (attachment == "" && attachment == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = attachment;
                }
                objOraclecommand.Parameters.Add(prm8);

              




                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;


                //objOraclecommand.Parameters.Add("P_ACCOUNT2", OracleType.Cursor);
                //objOraclecommand.Parameters["P_ACCOUNT2"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("P_ACCOUNT3", OracleType.Cursor);
                //objOraclecommand.Parameters["P_ACCOUNT3"].Direction = ParameterDirection.Output;


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


        public DataSet chkAdv(string Comp_Code, string Team_Code, string userid,string tname,string bname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkAdv.chkAdv_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Comp_Code;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Team_Code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Team_Code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("tname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = tname;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("bname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = bname;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNT2", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT2"].Direction = ParameterDirection.Output;

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


        public DataSet detailinserted(string exename, string designation, string address, string street, string city, string district, string state, string country, string pin, string phone, string status, string compcode, string userid, string teamcode, string report, string taluka, string repname, string adtype, string branchcode, string craditlimit, string email, string mobile, string empcode, string mailto, string ATTACHMENT)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execcontactinsert.execcontactinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("exename", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = exename;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm01 = new OracleParameter("designation", OracleType.VarChar, 50);
                prm01.Direction = ParameterDirection.Input;
                prm01.Value = designation;
                objOraclecommand.Parameters.Add(prm01);

                OracleParameter prm2 = new OracleParameter("address", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = address;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("street", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = street;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("city", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = city;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("district", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = district;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("state", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = state;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("country", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = country;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pin", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pin;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("phone", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = phone;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("status", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = status;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("teamcode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = teamcode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("report", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = report;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm141 = new OracleParameter("taluka1", OracleType.VarChar, 50);
                prm141.Direction = ParameterDirection.Input;
                prm141.Value = taluka;
                objOraclecommand.Parameters.Add(prm141);

                OracleParameter prm15 = new OracleParameter("repname", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = repname;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = adtype;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("branchcode", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = branchcode;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("craditlimit", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                if (craditlimit == "")
                    prm18.Value = System.DBNull.Value;
                else
                    prm18.Value = craditlimit;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("email", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = email;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("mobile", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = mobile;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm23 = new OracleParameter("p_empcode", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = empcode;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("mailto", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = mailto;
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("attachment", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = ATTACHMENT;
                objOraclecommand.Parameters.Add(prm25);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                //OracleParameter prm16 = new OracleParameter("adcategory", OracleType.VarChar, 50);
                //prm16.Direction = ParameterDirection.Input;
                //prm16.Value = adcategory;
                //objOraclecommand.Parameters.Add(prm16);

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


        public DataSet exebind(string compcode, string userid, string teamcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execcontactbind_grid.execcontactbind_grid_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("teamcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = teamcode;
                objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("P_Accounts", OracleType.Cursor);
                //prm4.Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add(prm4);

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

        public DataSet detailinsertedexec(string compcode, string userid, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execselectbind.execselectbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = code;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts2"].Direction = ParameterDirection.Output;

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

        public DataSet detailupdate(string exename, string designation, string address, string street, string city, string district, string state, string country, string pin, string phone, string status, string compcode, string userid, string teamcode, string code, string report, string taluka, string repname, string adtype, string brancgname1, string craditlimit, string email, string mobile, string empcode, string mailto, string attachment)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execcontactupdate.execcontactupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("exename", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = exename;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm01 = new OracleParameter("designation", OracleType.VarChar, 50);
                prm01.Direction = ParameterDirection.Input;
                prm01.Value = designation;
                objOraclecommand.Parameters.Add(prm01);

                OracleParameter prm2 = new OracleParameter("address", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = address;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("street", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = street;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("city", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = city;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("district", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = district;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm16 = new OracleParameter("state", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = state;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm7 = new OracleParameter("country", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = country;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pin", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pin;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("phone", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = phone;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("status", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = status;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("teamcode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = teamcode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("report", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = report;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("code", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = code;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm161 = new OracleParameter("TALUKA1", OracleType.VarChar, 50);
                prm161.Direction = ParameterDirection.Input;
                prm161.Value = taluka;
                objOraclecommand.Parameters.Add(prm161);

                OracleParameter prm17 = new OracleParameter("repname", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = repname;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = adtype;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("branchcode", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = brancgname1;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("craditlimit", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                if (craditlimit == "")
                    prm20.Value = System.DBNull.Value;
                else
                    prm20.Value = Convert.ToDecimal(craditlimit);
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("email", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = email;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("mobile", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = mobile;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("p_empcode", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = empcode;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("mailto", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = mailto;
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("pattachment", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = attachment;
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



        public DataSet deleteexecdetail(string compcode, string userid, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execdelete.execdelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm15 = new OracleParameter("code", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = code;
                objOraclecommand.Parameters.Add(prm15);
                objOraclecommand.ExecuteNonQuery();

               // objorclDataAdapter.Fill(objDataSet);
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



        public DataSet chkpopup(string teamcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkpopteam.chkpopteam_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("teamcode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = teamcode;
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

                OracleParameter prm1 = new OracleParameter("citycode", OracleType.VarChar, 50);
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

                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;

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

        public DataSet report(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindreportto.bindreportto_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);

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

        public DataSet valueofcount(string countcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getcountryname.getcountryname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("countcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = countcode;
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



        public DataSet chkexeccode1(string str,string region)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkadvexename.chkadvexename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2= new OracleParameter("cod", OracleType.VarChar, 50);
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

                OracleParameter prm3 = new OracleParameter("region1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = region;
                objOraclecommand.Parameters.Add(prm3);

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


        public DataSet chkexecname1(string Comp_Code, string exename, string userid, string teamcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkexecname.chkexecname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = Comp_Code;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("execname", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = exename;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("teamcode1", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = teamcode;
                objOraclecommand.Parameters.Add(prm14);

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





        public DataSet bindteam1()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("addpubname.addpubname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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











        public DataSet adcategory1()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adcat.adcat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet addesignation(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("addesignation.addesignation_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
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

        public DataSet adzone(string userid, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("branchbind_adv.branchbind_adv_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

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





        public DataSet countczone(string pub)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillzone.fillzone_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("pub", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pub;
                objOraclecommand.Parameters.Add(prm11);

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

        public DataSet addrepname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getrepname", ref objOracleConnection);
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

        //================== ad by rinki========================//
        public DataSet typebind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adtype.adtype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
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


        public DataSet addadvcat1(string adtypcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Addadvcatpage.Addadvcatpage_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("adtypecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adtypcode;
                objOraclecommand.Parameters.Add(prm1);



                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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
       
        // ad for adcategory
        public void deleteExecAdetail(string compcode, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;

            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execcontactdeleteadcat", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm17 = new OracleParameter("execode", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = code;
                objOraclecommand.Parameters.Add(prm17);


                objOraclecommand.ExecuteNonQuery();


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
        public void insertedExecAdetail(string compcode, string userid, string teamcode, string adcategory, string flag,string execode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
           
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execcontactinsertadcat", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13= new OracleParameter("flag", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = flag;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm16 = new OracleParameter("adcategory", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = adcategory;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("execode", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = execode;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm14 = new OracleParameter("teamcode", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = teamcode;
                objOraclecommand.Parameters.Add(prm14);

                objOraclecommand.ExecuteNonQuery();
              

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


        public DataSet bindempcode(string compcode,string empname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("emp_code_bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm11 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pname", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = empname;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm16);

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

        public DataSet retaineraddbind_b(string retcode, string userid, string compcode, string dateformat, string commid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("exeaddstatusbind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("commid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = commid;
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


        public DataSet insertretaddcomm(string compcode, string userid, string retcode, string lstpub, string minpub, string publication, string commid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_execu_add_comm_target_ins", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pexecu_code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = lstpub;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PNO_OF_PUBL", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = minpub;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PADCOMM_PER", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = publication;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PCOMM_TYPE", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = commid;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "I";
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("PADD_COMM_ID", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = "1";
                objOraclecommand.Parameters.Add(prm17);



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



        public DataSet AddSlabupdate(string compcode, string userid, string retcode, string lstpub, string minpub, string publication, string targetid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_execu_add_comm_target_ins", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pexecu_code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = lstpub;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PNO_OF_PUBL", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = minpub;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PADCOMM_PER", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = publication;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PCOMM_TYPE", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = "1";
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = userid;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "U";
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("PADD_COMM_ID", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = targetid;
                objOraclecommand.Parameters.Add(prm17);

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



        public DataSet Ret_AddDelete(string compcode, string userid, string retcode, string targetid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_execu_add_comm_target_ins", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pexecu_code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PNO_OF_PUBL", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PADCOMM_PER", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PCOMM_TYPE", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = "1";
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "D";
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("PADD_COMM_ID", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = targetid;
                objOraclecommand.Parameters.Add(prm17);


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


        public DataSet selectretaddslab(string retcode, string compcode, string userid, string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("exeaddselectslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("code11", OracleType.Number);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code11;
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


        public DataSet retainerstructuresbind_b(string retcode, string userid, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_execut_comm_target_bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);



                //OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = dateformat;
                //objOraclecommand.Parameters.Add(prm4);

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




        public DataSet selectretstruct(string retcode, string compcode, string userid, string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("exeselectstructslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("code11", OracleType.Number);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code11;
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



        public DataSet Ret_GetStructSlabupdate(string compcode, string userid, string retcode, string PTEAM_CODE, string PADCTG_CODE, string PFROM_TGT, string PTO_TGT, string PCUST_TYPE, string PAD_TYPE, string PPUB_TYPE, string PPUBL_CODE, string PCOMM_TARGET_ID)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_execu_COMM_TARGET_INS", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Pexe_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PTEAM_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PTEAM_CODE;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PADCTG_CODE", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = PADCTG_CODE;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PFROM_TGT", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = PFROM_TGT;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PTO_TGT", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = PTO_TGT;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("PCUST_TYPE", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = PCUST_TYPE;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("PAD_TYPE", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = PAD_TYPE;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("PPUB_TYPE", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = PPUB_TYPE;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = PPUBL_CODE;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = PCOMM_TARGET_ID;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = userid;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "U";
                objOraclecommand.Parameters.Add(prm16);


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




        public DataSet insertretcommstructure(string compcode, string userid, string retcode, string PTEAM_CODE, string PADCTG_CODE, string PFROM_TGT, string PTO_TGT, string PCUST_TYPE, string PAD_TYPE, string PPUB_TYPE, string PPUBL_CODE, string PCOMM_TARGET_ID)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_execu_COMM_TARGET_INS", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Pexe_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PTEAM_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PTEAM_CODE;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PADCTG_CODE", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = PADCTG_CODE;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PFROM_TGT", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = PFROM_TGT;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PTO_TGT", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = PTO_TGT;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("PCUST_TYPE", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = PCUST_TYPE;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("PAD_TYPE", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = PAD_TYPE;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("PPUB_TYPE", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = PPUB_TYPE;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = PPUBL_CODE;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = PCOMM_TARGET_ID;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "I";
                objOraclecommand.Parameters.Add(prm16);


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


        public DataSet insertretstatus_slab(string compcode, string userid, string retcode, string fromdays, string todays, string drpcommon, string commrate, string commid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertexestatus_slab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("execode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("enln", OracleType.Number);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = enln;
                //objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("fromdays", OracleType.Number);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = fromdays;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("todays", OracleType.Number);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = todays;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm6 = new OracleParameter("drpcommon", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpcommon;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("commrate", OracleType.Number);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = commrate;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("P_COMM_TARGET_ID", OracleType.Number);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = commid;
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


        public DataSet delretcommstructure(string compcode, string userid, string retcode, string PCOMM_TARGET_ID)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_execu_COMM_TARGET_INS", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Pexe_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PTEAM_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PADCTG_CODE", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PFROM_TGT", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PTO_TGT", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("PCUST_TYPE", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("PAD_TYPE", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("PPUB_TYPE", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = PCOMM_TARGET_ID;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "D";
                objOraclecommand.Parameters.Add(prm16);


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



        public DataSet gencodeforslab(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("exegencodeforcommstruct", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
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








        public DataSet retainerstatusbind_b(string retcode, string userid, string compcode, string dateformat, string commid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_exestatusbind_b.sp_exestatusbind_b_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm4 = new OracleParameter("commid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = commid;
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


        public DataSet selectretslab(string retcode, string compcode, string userid, string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("exeselectslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("code11", OracleType.Number);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code11;
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


        public DataSet Ret_GetSlabupdate(string retcode, string compcode, string userid, string common, string commrate, string todays, string fromdays, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateexestatus_slab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("execode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("common", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = common;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("commrate", OracleType.Number);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = commrate;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("fromdays", OracleType.Number);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = fromdays;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("todays", OracleType.Number);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = todays;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("code", OracleType.Number);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = code;
                objOraclecommand.Parameters.Add(prm8);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex) { throw (ex); }
            finally
            {
                CloseConnection(ref objOracleConnection);

            }
        }


        public DataSet retslabcheck(string compcode, string userid, string retcode, string todays, string fromdays, string codepass)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execheckslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("fromdays", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = fromdays;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("todays", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = todays;
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


        //public DataSet insertretstatus_slab(string compcode, string userid, string retcode, string fromdays, string todays, string drpcommon, string commrate, string commid)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("insertexestatus_slab", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("execode", OracleType.VarChar);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = retcode;
        //        objOraclecommand.Parameters.Add(prm1);


        //        OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = userid;
        //        objOraclecommand.Parameters.Add(prm2);

        //        OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
        //        prm3.Direction = ParameterDirection.Input;
        //        prm3.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm3);

        //        //OracleParameter prm4 = new OracleParameter("enln", OracleType.Number);
        //        //prm4.Direction = ParameterDirection.Input;
        //        //prm4.Value = enln;
        //        //objOraclecommand.Parameters.Add(prm4);

        //        OracleParameter prm5 = new OracleParameter("fromdays", OracleType.Number);
        //        prm5.Direction = ParameterDirection.Input;
        //        prm5.Value = fromdays;
        //        objOraclecommand.Parameters.Add(prm5);

        //        OracleParameter prm7 = new OracleParameter("todays", OracleType.Number);
        //        prm7.Direction = ParameterDirection.Input;
        //        prm7.Value = todays;
        //        objOraclecommand.Parameters.Add(prm7);


        //        OracleParameter prm6 = new OracleParameter("drpcommon", OracleType.VarChar);
        //        prm6.Direction = ParameterDirection.Input;
        //        prm6.Value = drpcommon;
        //        objOraclecommand.Parameters.Add(prm6);

        //        OracleParameter prm8 = new OracleParameter("commrate", OracleType.Number);
        //        prm8.Direction = ParameterDirection.Input;
        //        prm8.Value = commrate;
        //        objOraclecommand.Parameters.Add(prm8);

        //        OracleParameter prm9 = new OracleParameter("P_COMM_TARGET_ID", OracleType.Number);
        //        prm9.Direction = ParameterDirection.Input;
        //        prm9.Value = commid;
        //        objOraclecommand.Parameters.Add(prm9);

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


        public DataSet Ret_StatusDeleteSlab(string userid, string compcode, string retcode, string enlncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("exedeleteslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("execode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("enlncode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (enlncode == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = enlncode;
                objOraclecommand.Parameters.Add(prm5);



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objOracleConnection); }
        }


    
    }
}