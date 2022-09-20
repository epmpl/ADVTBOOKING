using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Company_Master
/// </summary>

namespace NewAdbooking.Classes
{
    public class CompanyMaster : connection
    {
        public DataSet adcountryname(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {


                objSqlConnection.Open();
                objSqlCommand = GetCommand("adcountryname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet countcity(string drpcountry)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("fillcity.fillcity_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillcity", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@txtcountry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtcountry"].Value = drpcountry;



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


        public DataSet chkcomp(string CompanyCode, string CompanyName, string Companyalias, string Companyadd, string Street, string City, string Zip, string District, string State, string Country, string Phone1, string Phone2, string Fax, string EmailId, string StAcNo, string Pan, string Tan, string Regno, string Regdate, string Remarks, string BoxAdd, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("chkcompanycode.chkcompanycode_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcompanycode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = CompanyCode;
                //objOraclecommand.Parameters.Add(prm2);

                objSqlCommand.Parameters.Add("@CompanyCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CompanyCode"].Value = CompanyCode;


                //OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                //prm21.Direction = ParameterDirection.Input;
                //prm21.Value = CompanyName;
                //objOraclecommand.Parameters.Add(prm21);

                objSqlCommand.Parameters.Add("@CompanyName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CompanyName"].Value = CompanyName;

                //OracleParameter prm21487 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm21487.Direction = ParameterDirection.Input;
                //prm21487.Value = userid;
                //objOraclecommand.Parameters.Add(prm21487);

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



                //objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;


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


        public DataSet save(string CompanyCode, string CompanyName, string Companyalias, string Companyadd, string Street, string City, string Zip, string District, string State, string Country, string Phone1, string Phone2, string Fax, string EmailId, string StAcNo, string Pan, string Tan, string Regno, string Regdate, string Remarks, string BoxAdd, string userid, string dateformat, string vatinno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("companyinsert.companyinsert_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objSqlConnection.Open();
                objSqlCommand = GetCommand("companyinsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = CompanyCode;
                //objOraclecommand.Parameters.Add(prm2);

                objSqlCommand.Parameters.Add("@CompanyCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CompanyCode"].Value = CompanyCode;

                //OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                //prm21.Direction = ParameterDirection.Input;
                //prm21.Value = CompanyName;
                //objOraclecommand.Parameters.Add(prm21);

                objSqlCommand.Parameters.Add("@CompanyName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CompanyName"].Value = CompanyName;

                //OracleParameter prm22 = new OracleParameter("Companyalias", OracleType.VarChar, 50);
                //prm22.Direction = ParameterDirection.Input;
                //prm22.Value = Companyalias;
                //objOraclecommand.Parameters.Add(prm22);

                objSqlCommand.Parameters.Add("@Companyalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Companyalias"].Value = Companyalias;

                //OracleParameter prm214 = new OracleParameter("Companyadd", OracleType.VarChar, 50);
                //prm214.Direction = ParameterDirection.Input;
                //prm214.Value = Companyadd;
                //objOraclecommand.Parameters.Add(prm214);

                objSqlCommand.Parameters.Add("@Companyadd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Companyadd"].Value = Companyadd;

                //OracleParameter prm211 = new OracleParameter("Street", OracleType.VarChar, 50);
                //prm211.Direction = ParameterDirection.Input;
                //prm211.Value = Street;
                //objOraclecommand.Parameters.Add(prm211);

                objSqlCommand.Parameters.Add("@Street", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Street"].Value = Street;

                //OracleParameter prm212 = new OracleParameter("City", OracleType.VarChar, 50);
                //prm212.Direction = ParameterDirection.Input;
                //prm212.Value = City;
                //objOraclecommand.Parameters.Add(prm212);

                objSqlCommand.Parameters.Add("@City", SqlDbType.VarChar);
                objSqlCommand.Parameters["@City"].Value = City;

                //OracleParameter prm221 = new OracleParameter("Zip", OracleType.VarChar, 50);
                //prm221.Direction = ParameterDirection.Input;
                //prm221.Value = Zip;
                //objOraclecommand.Parameters.Add(prm221);

                objSqlCommand.Parameters.Add("@Zip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Zip"].Value = Zip;

                //OracleParameter prm2142 = new OracleParameter("District", OracleType.VarChar, 50);
                //prm2142.Direction = ParameterDirection.Input;
                //prm2142.Value = District;
                //objOraclecommand.Parameters.Add(prm2142);

                objSqlCommand.Parameters.Add("@District", SqlDbType.VarChar);
                objSqlCommand.Parameters["@District"].Value = District;

                //OracleParameter prm223 = new OracleParameter("State", OracleType.VarChar, 50);
                //prm223.Direction = ParameterDirection.Input;
                //prm223.Value = State;
                //objOraclecommand.Parameters.Add(prm223);

                objSqlCommand.Parameters.Add("@State", SqlDbType.VarChar);
                objSqlCommand.Parameters["@State"].Value = State;

                //OracleParameter prm228 = new OracleParameter("Country", OracleType.VarChar, 50);
                //prm228.Direction = ParameterDirection.Input;
                //prm228.Value = Country;
                //objOraclecommand.Parameters.Add(prm228);

                objSqlCommand.Parameters.Add("@Country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Country"].Value = Country;

                //OracleParameter prm2147 = new OracleParameter("Phone1", OracleType.VarChar, 50);
                //prm2147.Direction = ParameterDirection.Input;
                //prm2147.Value = Phone1;
                //objOraclecommand.Parameters.Add(prm2147);

                objSqlCommand.Parameters.Add("@Phone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Phone1"].Value = Phone1;

                //OracleParameter prm265 = new OracleParameter("Phone2", OracleType.VarChar, 50);
                //prm265.Direction = ParameterDirection.Input;
                //prm265.Value = Phone2;
                //objOraclecommand.Parameters.Add(prm265);

                objSqlCommand.Parameters.Add("@Phone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Phone2"].Value = Phone2;

                //OracleParameter prm215 = new OracleParameter("fax", OracleType.VarChar, 50);
                //prm215.Direction = ParameterDirection.Input;
                //prm215.Value = Fax;
                //objOraclecommand.Parameters.Add(prm215);

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = Fax;

                //OracleParameter prm2244 = new OracleParameter("Emailid", OracleType.VarChar, 50);
                //prm2244.Direction = ParameterDirection.Input;
                //prm2244.Value = EmailId;
                //objOraclecommand.Parameters.Add(prm2244);

                objSqlCommand.Parameters.Add("@Emailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Emailid"].Value = EmailId;

                //OracleParameter prm2145 = new OracleParameter("StAcNo", OracleType.VarChar, 50);
                //prm2145.Direction = ParameterDirection.Input;
                //prm2145.Value = StAcNo;
                //objOraclecommand.Parameters.Add(prm2145);

                objSqlCommand.Parameters.Add("@StAcNo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@StAcNo"].Value = StAcNo;

                //OracleParameter prm266 = new OracleParameter("Pan", OracleType.VarChar, 50);
                //prm266.Direction = ParameterDirection.Input;
                //prm266.Value = Pan;
                //objOraclecommand.Parameters.Add(prm266);

                objSqlCommand.Parameters.Add("@Pan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Pan"].Value = Pan;

                //OracleParameter prm2166 = new OracleParameter("Tan", OracleType.VarChar, 50);
                //prm2166.Direction = ParameterDirection.Input;
                //prm2166.Value = Tan;
                //objOraclecommand.Parameters.Add(prm2166);

                objSqlCommand.Parameters.Add("@Tan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Tan"].Value = Tan;

                //OracleParameter prm2266 = new OracleParameter("Regno", OracleType.VarChar, 50);
                //prm2266.Direction = ParameterDirection.Input;
                //prm2266.Value = Regno;
                //objOraclecommand.Parameters.Add(prm2266);

                objSqlCommand.Parameters.Add("@Regno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Regno"].Value = Regno;

                objSqlCommand.Parameters.Add("@Regdate", SqlDbType.VarChar);
                if (Regdate == "" || Regdate == null)
                {
                    objSqlCommand.Parameters["@Regdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@Regdate"].Value = Convert.ToDateTime(Regdate);
                }


                //objOraclecommand.Parameters.Add(prm21466);

                //OracleParameter prm2177 = new OracleParameter("Remarks", OracleType.VarChar);
                //prm2177.Direction = ParameterDirection.Input;
                //prm2177.Value = Remarks;
                //objOraclecommand.Parameters.Add(prm2177);

                objSqlCommand.Parameters.Add("@Remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Remarks"].Value = Remarks;

                //OracleParameter prm2288 = new OracleParameter("BoxAdd", OracleType.VarChar);
                //prm2288.Direction = ParameterDirection.Input;
                //prm2288.Value = BoxAdd;
                //objOraclecommand.Parameters.Add(prm2288);

                objSqlCommand.Parameters.Add("@BoxAdd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BoxAdd"].Value = BoxAdd;

                //OracleParameter prm21487 = new OracleParameter("Userid", OracleType.VarChar, 50);
                //prm21487.Direction = ParameterDirection.Input;
                //prm21487.Value = userid;
                //objOraclecommand.Parameters.Add(prm21487);

                objSqlCommand.Parameters.Add("@Userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Userid"].Value = userid;

                objSqlCommand.Parameters.Add("@txtvatinno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtvatinno"].Value = vatinno;
                //objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                //objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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


        public DataSet selectcompany(string CompanyCode, string CompanyName, string Companyalias, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("CompanyMastSelect.CompanyMastSelect_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objSqlConnection.Open();
                objSqlCommand = GetCommand("CompanyMastSelect", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = CompanyCode;
                //objOraclecommand.Parameters.Add(prm2);

                objSqlCommand.Parameters.Add("@CompanyCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CompanyCode"].Value = CompanyCode;


                //OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                //prm21.Direction = ParameterDirection.Input;
                //prm21.Value = CompanyName;
                //objOraclecommand.Parameters.Add(prm21);

                objSqlCommand.Parameters.Add("@CompanyName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CompanyName"].Value = CompanyName;


                //OracleParameter prm212 = new OracleParameter("Companyalias", OracleType.VarChar, 50);
                //prm212.Direction = ParameterDirection.Input;
                //prm212.Value = Companyalias;
                //objOraclecommand.Parameters.Add(prm212);

                objSqlCommand.Parameters.Add("@Companyalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Companyalias"].Value = Companyalias;


                //OracleParameter prm21487 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm21487.Direction = ParameterDirection.Input;
                //prm21487.Value = userid;
                //objOraclecommand.Parameters.Add(prm21487);

                objSqlCommand.Parameters.Add("@Userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Userid"].Value = userid;

                //objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;


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


        public DataSet modifysave(string CompanyCode, string CompanyName, string Companyalias, string Companyadd, string Street, string City, string Zip, string District, string State, string Country, string Phone1, string Phone2, string Fax, string EmailId, string StAcNo, string Pan, string Tan, string Regno, string Regdate, string Remarks, string BoxAdd, string userid, string dateformat, string vatinno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("CompanyMastModify.CompanyMastModify_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objSqlConnection.Open();
                objSqlCommand = GetCommand("CompanyMastModify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = CompanyCode;
                //objOraclecommand.Parameters.Add(prm2);

                objSqlCommand.Parameters.Add("@CompanyCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CompanyCode"].Value = CompanyCode;

                //OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                //prm21.Direction = ParameterDirection.Input;
                //prm21.Value = CompanyName;
                //objOraclecommand.Parameters.Add(prm21);

                objSqlCommand.Parameters.Add("@CompanyName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CompanyName"].Value = CompanyName;

                //OracleParameter prm22 = new OracleParameter("Companyalias", OracleType.VarChar, 50);
                //prm22.Direction = ParameterDirection.Input;
                //prm22.Value = Companyalias;
                //objOraclecommand.Parameters.Add(prm22);

                objSqlCommand.Parameters.Add("@Companyalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Companyalias"].Value = Companyalias;

                //OracleParameter prm214 = new OracleParameter("Companyadd", OracleType.VarChar, 50);
                //prm214.Direction = ParameterDirection.Input;
                //prm214.Value = Companyadd;
                //objOraclecommand.Parameters.Add(prm214);

                objSqlCommand.Parameters.Add("@Companyadd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Companyadd"].Value = Companyadd;

                //OracleParameter prm211 = new OracleParameter("Street11", OracleType.VarChar, 50);
                //prm211.Direction = ParameterDirection.Input;
                //prm211.Value = Street;
                //objOraclecommand.Parameters.Add(prm211);

                objSqlCommand.Parameters.Add("@Street11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Street11"].Value = Street;

                //OracleParameter prm212 = new OracleParameter("City11", OracleType.VarChar, 50);
                //prm212.Direction = ParameterDirection.Input;
                //prm212.Value = City;
                //objOraclecommand.Parameters.Add(prm212);

                objSqlCommand.Parameters.Add("@City11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@City11"].Value = City;

                //OracleParameter prm221 = new OracleParameter("Zip11", OracleType.VarChar, 50);
                //prm221.Direction = ParameterDirection.Input;
                //prm221.Value = Zip;
                //objOraclecommand.Parameters.Add(prm221);

                objSqlCommand.Parameters.Add("@Zip11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Zip11"].Value = Zip;

                //OracleParameter prm2142 = new OracleParameter("District11", OracleType.VarChar, 50);
                //prm2142.Direction = ParameterDirection.Input;
                //prm2142.Value = District;
                //objOraclecommand.Parameters.Add(prm2142);

                objSqlCommand.Parameters.Add("@District11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@District11"].Value = District;

                //OracleParameter prm223 = new OracleParameter("State11", OracleType.VarChar, 50);
                //prm223.Direction = ParameterDirection.Input;
                //prm223.Value = State;
                //objOraclecommand.Parameters.Add(prm223);

                objSqlCommand.Parameters.Add("@State11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@State11"].Value = State;

                //OracleParameter prm228 = new OracleParameter("Country", OracleType.VarChar, 50);
                //prm228.Direction = ParameterDirection.Input;
                //prm228.Value = Country;
                //objOraclecommand.Parameters.Add(prm228);

                objSqlCommand.Parameters.Add("@Country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Country"].Value = Country;

                //OracleParameter prm2147 = new OracleParameter("Phone111", OracleType.VarChar, 50);
                //prm2147.Direction = ParameterDirection.Input;
                //prm2147.Value = Phone1;
                //objOraclecommand.Parameters.Add(prm2147);

                objSqlCommand.Parameters.Add("@Phone111", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Phone111"].Value = Phone1;

                //OracleParameter prm265 = new OracleParameter("Phone211", OracleType.VarChar, 50);
                //prm265.Direction = ParameterDirection.Input;
                //prm265.Value = Phone2;
                //objOraclecommand.Parameters.Add(prm265);

                objSqlCommand.Parameters.Add("@Phone211", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Phone211"].Value = Phone2;

                //OracleParameter prm215 = new OracleParameter("fax11", OracleType.VarChar, 50);
                //prm215.Direction = ParameterDirection.Input;
                //prm215.Value = Fax;
                //objOraclecommand.Parameters.Add(prm215);

                objSqlCommand.Parameters.Add("@fax11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax11"].Value = Fax;

                //OracleParameter prm2244 = new OracleParameter("Emailid11", OracleType.VarChar, 50);
                //prm2244.Direction = ParameterDirection.Input;
                //prm2244.Value = EmailId;
                //objOraclecommand.Parameters.Add(prm2244);

                objSqlCommand.Parameters.Add("@Emailid11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Emailid11"].Value = EmailId;

                //OracleParameter prm2145 = new OracleParameter("StAcNo11", OracleType.VarChar, 50);
                //prm2145.Direction = ParameterDirection.Input;
                //prm2145.Value = StAcNo;
                //objOraclecommand.Parameters.Add(prm2145);

                objSqlCommand.Parameters.Add("@StAcNo11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@StAcNo11"].Value = StAcNo;

                //OracleParameter prm266 = new OracleParameter("Pan11", OracleType.VarChar, 50);
                //prm266.Direction = ParameterDirection.Input;
                //prm266.Value = Pan;
                //objOraclecommand.Parameters.Add(prm266);

                objSqlCommand.Parameters.Add("@Pan11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Pan11"].Value = Pan;

                //OracleParameter prm2166 = new OracleParameter("Tan11", OracleType.VarChar, 50);
                //prm2166.Direction = ParameterDirection.Input;
                //prm2166.Value = Tan;
                //objOraclecommand.Parameters.Add(prm2166);

                objSqlCommand.Parameters.Add("@Tan11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Tan11"].Value = Tan;

                //OracleParameter prm2266 = new OracleParameter("Regno11", OracleType.VarChar, 50);
                //prm2266.Direction = ParameterDirection.Input;
                //prm2266.Value = Regno;
                //objOraclecommand.Parameters.Add(prm2266);

                objSqlCommand.Parameters.Add("@Regno11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Regno11"].Value = Regno;

                objSqlCommand.Parameters.Add("@Regdate", SqlDbType.VarChar);
                if (Regdate == "" || Regdate == null)
                {
                    objSqlCommand.Parameters["@Regdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@Regdate"].Value = Convert.ToDateTime(Regdate);
                }

                //OracleParameter prm2177 = new OracleParameter("Remarks11", OracleType.VarChar);
                //prm2177.Direction = ParameterDirection.Input;
                //prm2177.Value = Remarks;
                //objOraclecommand.Parameters.Add(prm2177);

                objSqlCommand.Parameters.Add("@Remarks11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Remarks11"].Value = Remarks;

                //OracleParameter prm2288 = new OracleParameter("BoxAdd", OracleType.VarChar);
                //prm2288.Direction = ParameterDirection.Input;
                //prm2288.Value = BoxAdd;
                //objOraclecommand.Parameters.Add(prm2288);

                objSqlCommand.Parameters.Add("@BoxAdd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BoxAdd"].Value = BoxAdd;

                //OracleParameter prm21487 = new OracleParameter("Userid", OracleType.VarChar, 50);
                //prm21487.Direction = ParameterDirection.Input;
                //prm21487.Value = userid;
                //objOraclecommand.Parameters.Add(prm21487);

                objSqlCommand.Parameters.Add("@Userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Userid"].Value = userid;

                objSqlCommand.Parameters.Add("@txtvatinno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtvatinno"].Value = vatinno;
                //objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                //objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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



        public DataSet selectcompany(string CompanyName)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("chkcompanyname.chkcompanyname_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;


                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcompanyname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                //OracleParameter prm1 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = CompanyName;
                //objOraclecommand.Parameters.Add(prm1);

                objSqlCommand.Parameters.Add("@CompanyName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CompanyName"].Value = CompanyName;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                if (CompanyName.Length > 2)
                {
                    objSqlCommand.Parameters["@cod"].Value = CompanyName.Substring(0, 2);
                }
                else
                {
                    objSqlCommand.Parameters["@cod"].Value= CompanyName;
                }

                //OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //if (CompanyName.Length > 2)
                //{
                //    prm2.Value = CompanyName.Substring(0, 2);
                //}
                //else
                //{
                //    prm2.Value = CompanyName;
                //}
                //objOraclecommand.Parameters.Add(prm2);

                //objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                //objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;







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


        public DataSet next(string CompanyCode, string CompanyName, string Companyalias, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("CompanySelectfnpl.CompanySelectfnpl_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;


                objSqlConnection.Open();
                objSqlCommand = GetCommand("CompanySelectfnpl", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = CompanyCode;
                //objOraclecommand.Parameters.Add(prm1);

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = CompanyName;

                //objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




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



        public string Save_misccode(string code, string unitcode, string tblname, string action, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Cir_Dynamic_DML_variable_insert_stmt", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolname"].Value = code;

                objSqlCommand.Parameters.Add("@pcolvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolvalue"].Value = unitcode;

                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return "true";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                objSqlConnection.Close();
            }


        }





       




        public DataSet delete_misc(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_dml_variable_delete_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colname"].Value = colname;

                objSqlCommand.Parameters.Add("@pcond_colval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colval"].Value = colvalue;


                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";


                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;


                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

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




        public DataSet execute_zone(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_execute_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colname"].Value = colname;

                objSqlCommand.Parameters.Add("@pcond_colval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colval"].Value = colvalue;


                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";


                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;


                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

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





        public DataSet DeleteValue(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("CompanyMastDelete.CompanyMastDelete_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;


                objSqlConnection.Open();
                objSqlCommand = GetCommand("CompanyMastDelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                //OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = compcode;
                //objOraclecommand.Parameters.Add(prm1);

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



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


    }



}