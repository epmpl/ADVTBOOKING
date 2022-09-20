using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for CompanyMaster
    /// </summary>
    public class CompanyMaster:orclconnection
    {
        public CompanyMaster()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        public DataSet adcountryname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adcountryname.adcountryname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
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

        public DataSet countcity(string drpcountry)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillcity.fillcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("txtcountry", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = drpcountry;
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

        public DataSet chkcomp(string CompanyCode, string CompanyName, string Companyalias, string Companyadd, string Street, string City, string Zip, string District, string State, string Country, string Phone1, string Phone2, string Fax, string EmailId, string StAcNo, string Pan, string Tan, string Regno, string Regdate, string Remarks, string BoxAdd, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcompanycode.chkcompanycode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = CompanyCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = CompanyName;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm21487 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm21487.Direction = ParameterDirection.Input;
                prm21487.Value = userid;
                objOraclecommand.Parameters.Add(prm21487);

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


        public DataSet save(string CompanyCode, string CompanyName, string Companyalias, string Companyadd, string Street, string City, string Zip, string District, string State, string Country, string Phone1, string Phone2, string Fax, string EmailId, string StAcNo, string Pan, string Tan, string Regno, string Regdate, string Remarks, string BoxAdd, string userid, string dateformat, string vatinno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("companyinsert.companyinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = CompanyCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = CompanyName;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("Companyalias", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = Companyalias;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm214 = new OracleParameter("Companyadd", OracleType.VarChar, 50);
                prm214.Direction = ParameterDirection.Input;
                prm214.Value = Companyadd;
                objOraclecommand.Parameters.Add(prm214);

                OracleParameter prm211 = new OracleParameter("Street", OracleType.VarChar, 50);
                prm211.Direction = ParameterDirection.Input;
                prm211.Value = Street;
                objOraclecommand.Parameters.Add(prm211);

                OracleParameter prm212 = new OracleParameter("City", OracleType.VarChar, 50);
                prm212.Direction = ParameterDirection.Input;
                prm212.Value = City;
                objOraclecommand.Parameters.Add(prm212);

                OracleParameter prm221 = new OracleParameter("Zip", OracleType.VarChar, 50);
                prm221.Direction = ParameterDirection.Input;
                prm221.Value = Zip;
                objOraclecommand.Parameters.Add(prm221);

                OracleParameter prm2142 = new OracleParameter("District", OracleType.VarChar, 50);
                prm2142.Direction = ParameterDirection.Input;
                prm2142.Value = District;
                objOraclecommand.Parameters.Add(prm2142);

                OracleParameter prm223 = new OracleParameter("State", OracleType.VarChar, 50);
                prm223.Direction = ParameterDirection.Input;
                prm223.Value = State;
                objOraclecommand.Parameters.Add(prm223);

                OracleParameter prm228 = new OracleParameter("Country", OracleType.VarChar, 50);
                prm228.Direction = ParameterDirection.Input;
                prm228.Value = Country;
                objOraclecommand.Parameters.Add(prm228);

                OracleParameter prm2147 = new OracleParameter("Phone1", OracleType.VarChar, 50);
                prm2147.Direction = ParameterDirection.Input;
                prm2147.Value = Phone1;
                objOraclecommand.Parameters.Add(prm2147);

                OracleParameter prm265 = new OracleParameter("Phone2", OracleType.VarChar, 50);
                prm265.Direction = ParameterDirection.Input;
                prm265.Value = Phone2;
                objOraclecommand.Parameters.Add(prm265);

                OracleParameter prm215 = new OracleParameter("fax", OracleType.VarChar, 50);
                prm215.Direction = ParameterDirection.Input;
                prm215.Value = Fax;
                objOraclecommand.Parameters.Add(prm215);

                OracleParameter prm2244 = new OracleParameter("Emailid", OracleType.VarChar, 50);
                prm2244.Direction = ParameterDirection.Input;
                prm2244.Value = EmailId;
                objOraclecommand.Parameters.Add(prm2244);

                OracleParameter prm2145 = new OracleParameter("StAcNo", OracleType.VarChar, 50);
                prm2145.Direction = ParameterDirection.Input;
                prm2145.Value = StAcNo;
                objOraclecommand.Parameters.Add(prm2145);

                OracleParameter prm266 = new OracleParameter("Pan", OracleType.VarChar, 50);
                prm266.Direction = ParameterDirection.Input;
                prm266.Value = Pan;
                objOraclecommand.Parameters.Add(prm266);

                OracleParameter prm2166 = new OracleParameter("Tan", OracleType.VarChar, 50);
                prm2166.Direction = ParameterDirection.Input;
                prm2166.Value = Tan;
                objOraclecommand.Parameters.Add(prm2166);

                OracleParameter prm2266 = new OracleParameter("Regno", OracleType.VarChar, 50);
                prm2266.Direction = ParameterDirection.Input;
                prm2266.Value = Regno;
                objOraclecommand.Parameters.Add(prm2266);

                OracleParameter prm21466 = new OracleParameter("Regdate", OracleType.VarChar, 50);
                prm21466.Direction = ParameterDirection.Input;
               
                if (Regdate == "" || Regdate == null)
                {
                    prm21466.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = Regdate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    Regdate = mm + "/" + dd + "/" + yy;


                    //}

                    prm21466.Value = Convert.ToDateTime(Regdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm21466);

                OracleParameter prm2177 = new OracleParameter("Remarks", OracleType.VarChar);
                prm2177.Direction = ParameterDirection.Input;
                prm2177.Value = Remarks;
                objOraclecommand.Parameters.Add(prm2177);

                OracleParameter prm2288 = new OracleParameter("BoxAdd", OracleType.VarChar);
                prm2288.Direction = ParameterDirection.Input;
                prm2288.Value = BoxAdd;
                objOraclecommand.Parameters.Add(prm2288);

                OracleParameter prm21487 = new OracleParameter("Userid", OracleType.VarChar, 50);
                prm21487.Direction = ParameterDirection.Input;
                prm21487.Value = userid;
                objOraclecommand.Parameters.Add(prm21487);

                OracleParameter prm2000 = new OracleParameter("txtvatinno", OracleType.VarChar, 50);
                prm2000.Direction = ParameterDirection.Input;
                prm2000.Value = vatinno;
                objOraclecommand.Parameters.Add(prm2000);
                //objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                //objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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

        public DataSet selectcompany(string CompanyCode, string CompanyName, string Companyalias, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CompanyMastSelect.CompanyMastSelect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = CompanyCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = CompanyName;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm212 = new OracleParameter("Companyalias", OracleType.VarChar, 50);
                prm212.Direction = ParameterDirection.Input;
                prm212.Value = Companyalias;
                objOraclecommand.Parameters.Add(prm212);

                OracleParameter prm21487 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm21487.Direction = ParameterDirection.Input;
                prm21487.Value = userid;
                objOraclecommand.Parameters.Add(prm21487);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;


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

        public DataSet modifysave(string CompanyCode, string CompanyName, string Companyalias, string Companyadd, string Street, string City, string Zip, string District, string State, string Country, string Phone1, string Phone2, string Fax, string EmailId, string StAcNo, string Pan, string Tan, string Regno, string Regdate, string Remarks, string BoxAdd, string userid, string dateformat,string vatinno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CompanyMastModify.CompanyMastModify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = CompanyCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = CompanyName;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("Companyalias", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = Companyalias;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm214 = new OracleParameter("Companyadd", OracleType.VarChar, 50);
                prm214.Direction = ParameterDirection.Input;
                prm214.Value = Companyadd;
                objOraclecommand.Parameters.Add(prm214);

                OracleParameter prm211 = new OracleParameter("Street11", OracleType.VarChar, 50);
                prm211.Direction = ParameterDirection.Input;
                prm211.Value = Street;
                objOraclecommand.Parameters.Add(prm211);

                OracleParameter prm212 = new OracleParameter("City11", OracleType.VarChar, 50);
                prm212.Direction = ParameterDirection.Input;
                prm212.Value = City;
                objOraclecommand.Parameters.Add(prm212);

                OracleParameter prm221 = new OracleParameter("Zip11", OracleType.VarChar, 50);
                prm221.Direction = ParameterDirection.Input;
                prm221.Value = Zip;
                objOraclecommand.Parameters.Add(prm221);

                OracleParameter prm2142 = new OracleParameter("District11", OracleType.VarChar, 50);
                prm2142.Direction = ParameterDirection.Input;
                prm2142.Value = District;
                objOraclecommand.Parameters.Add(prm2142);

                OracleParameter prm223 = new OracleParameter("State11", OracleType.VarChar, 50);
                prm223.Direction = ParameterDirection.Input;
                prm223.Value = State;
                objOraclecommand.Parameters.Add(prm223);

                OracleParameter prm228 = new OracleParameter("Country", OracleType.VarChar, 50);
                prm228.Direction = ParameterDirection.Input;
                prm228.Value = Country;
                objOraclecommand.Parameters.Add(prm228);

                OracleParameter prm2147 = new OracleParameter("Phone111", OracleType.VarChar, 50);
                prm2147.Direction = ParameterDirection.Input;
                prm2147.Value = Phone1;
                objOraclecommand.Parameters.Add(prm2147);

                OracleParameter prm265 = new OracleParameter("Phone211", OracleType.VarChar, 50);
                prm265.Direction = ParameterDirection.Input;
                prm265.Value = Phone2;
                objOraclecommand.Parameters.Add(prm265);

                OracleParameter prm215 = new OracleParameter("fax11", OracleType.VarChar, 50);
                prm215.Direction = ParameterDirection.Input;
                prm215.Value = Fax;
                objOraclecommand.Parameters.Add(prm215);

                OracleParameter prm2244 = new OracleParameter("Emailid11", OracleType.VarChar, 50);
                prm2244.Direction = ParameterDirection.Input;
                prm2244.Value = EmailId;
                objOraclecommand.Parameters.Add(prm2244);

                OracleParameter prm2145 = new OracleParameter("StAcNo11", OracleType.VarChar, 50);
                prm2145.Direction = ParameterDirection.Input;
                prm2145.Value = StAcNo;
                objOraclecommand.Parameters.Add(prm2145);

                OracleParameter prm266 = new OracleParameter("Pan11", OracleType.VarChar, 50);
                prm266.Direction = ParameterDirection.Input;
                prm266.Value = Pan;
                objOraclecommand.Parameters.Add(prm266);

                OracleParameter prm2166 = new OracleParameter("Tan11", OracleType.VarChar, 50);
                prm2166.Direction = ParameterDirection.Input;
                prm2166.Value = Tan;
                objOraclecommand.Parameters.Add(prm2166);

                OracleParameter prm2266 = new OracleParameter("Regno11", OracleType.VarChar, 50);
                prm2266.Direction = ParameterDirection.Input;
                prm2266.Value = Regno;
                objOraclecommand.Parameters.Add(prm2266);

                OracleParameter prm21466 = new OracleParameter("Regdate", OracleType.VarChar, 50);
                prm21466.Direction = ParameterDirection.Input;

                if (Regdate == "" || Regdate == null)
                {
                    prm21466.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = Regdate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    Regdate = mm + "/" + dd + "/" + yy;


                    //}

                    prm21466.Value = Convert.ToDateTime(Regdate).ToString("dd-MMMM-yyyy");
                    //prm21466.Value = Regdate;
                }
                objOraclecommand.Parameters.Add(prm21466);

                OracleParameter prm2177 = new OracleParameter("Remarks11", OracleType.VarChar);
                prm2177.Direction = ParameterDirection.Input;
                prm2177.Value = Remarks;
                objOraclecommand.Parameters.Add(prm2177);

                OracleParameter prm2288 = new OracleParameter("BoxAdd", OracleType.VarChar);
                prm2288.Direction = ParameterDirection.Input;
                prm2288.Value = BoxAdd;
                objOraclecommand.Parameters.Add(prm2288);

                OracleParameter prm21487 = new OracleParameter("Userid", OracleType.VarChar, 50);
                prm21487.Direction = ParameterDirection.Input;
                prm21487.Value = userid;
                objOraclecommand.Parameters.Add(prm21487);

                OracleParameter prm2000 = new OracleParameter("txtvatinno", OracleType.VarChar, 50);
                prm2000.Direction = ParameterDirection.Input;
                prm2000.Value = vatinno;
                objOraclecommand.Parameters.Add(prm2000);
                //objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                //objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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

        public DataSet selectcompany(string CompanyName)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcompanyname.chkcompanyname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = CompanyName;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (CompanyName.Length > 2)
                {
                    prm2.Value = CompanyName.Substring(0, 2);
                }
                else
                {
                    prm2.Value = CompanyName;
                }
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;







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
                objOracleConnection.Close();
            }
        }

        public DataSet next(string CompanyCode, string CompanyName, string Companyalias, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CompanySelectfnpl.CompanySelectfnpl_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = CompanyCode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

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
                objOracleConnection.Close();
            }
        }



        public string Save_misccode(string code, string unitcode, string tblname, string action, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("Cir_Dynamic_DML.variable_insert_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pcolname", OracleType.VarChar, 1000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcolvalue", OracleType.VarChar, 1000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                cmd.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 1000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);

                OracleParameter prm7 = new OracleParameter("pdelimiter", OracleType.VarChar, 1000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = "$~$";
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = date;
                cmd.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = "";
                cmd.Parameters.Add(prm9);

                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = "";
                cmd.Parameters.Add(prm5);



                cmd.ExecuteNonQuery();
                return "true";


            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                CloseConnection(ref con);
            }


        }


        public DataSet execute_zone(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_execute_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = colname;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pcond_colval", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colvalue;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);


                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);

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



        public DataSet delete_misc(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_delete_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = colname;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pcond_colval", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colvalue;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);

                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = "dd/mm/yyyy";
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);


                //da.SelectCommand = cmd;
                //da.Fill(ds);
                cmd.ExecuteNonQuery();
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




        public DataSet execute_detail1(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_execute_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = colname;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pcond_colval", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colvalue;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);


                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);

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
        
        public DataSet DeleteValue(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CompanyMastDelete.CompanyMastDelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

               
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet; ;
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


    }





}
