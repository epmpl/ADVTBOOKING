using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace NewAdbooking.classmysql
{
    /// <summary>
    /// Summary description for CompanyMaster
    /// </summary>
    public class CompanyMaster : connection
    {
        public CompanyMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adcountryname(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adcountryname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet countcity(string txtcountry)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillcity", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("txtcountry", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcountry"].Value = txtcountry;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet chkcomp(string CompanyCode, string CompanyName, string Companyalias, string Companyadd, string Street, string City, string Zip, string District, string State, string Country, string Phone1, string Phone2, string Fax, string EmailId, string StAcNo, string Pan, string Tan, string Regno, string Regdate, string Remarks, string BoxAdd, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkcompanycode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("CompanyCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CompanyCode"].Value = CompanyCode;

                objmysqlcommand.Parameters.Add("CompanyName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CompanyName"].Value = CompanyName;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        public DataSet save(string CompanyCode, string CompanyName, string Companyalias, string Companyadd, string Street, string City, string Zip, string District, string State, string Country, string Phone1, string Phone2, string Fax, string EmailId, string StAcNo, string Pan, string Tan, string Regno, string Regdate, string Remarks, string BoxAdd, string userid, string dateformat, string vatinno)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("companyinsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("companyinsert.companyinsert_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = CompanyCode;
                //objOraclecommand.Parameters.Add(prm2);

                objmysqlcommand.Parameters.Add("CompanyCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CompanyCode"].Value = CompanyCode;

                //OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                //prm21.Direction = ParameterDirection.Input;
                //prm21.Value = CompanyName;
                //objOraclecommand.Parameters.Add(prm21);

                objmysqlcommand.Parameters.Add("CompanyName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CompanyName"].Value = CompanyName;

                //OracleParameter prm22 = new OracleParameter("Companyalias", OracleType.VarChar, 50);
                //prm22.Direction = ParameterDirection.Input;
                //prm22.Value = Companyalias;
                //objOraclecommand.Parameters.Add(prm22);

                objmysqlcommand.Parameters.Add("Companyalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Companyalias"].Value = Companyalias;

                //OracleParameter prm214 = new OracleParameter("Companyadd", OracleType.VarChar, 50);
                //prm214.Direction = ParameterDirection.Input;
                //prm214.Value = Companyadd;
                //objOraclecommand.Parameters.Add(prm214);

                objmysqlcommand.Parameters.Add("Companyadd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Companyadd"].Value = Companyadd;

                //OracleParameter prm211 = new OracleParameter("Street", OracleType.VarChar, 50);
                //prm211.Direction = ParameterDirection.Input;
                //prm211.Value = Street;
                //objOraclecommand.Parameters.Add(prm211);

                objmysqlcommand.Parameters.Add("Street", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Street"].Value = Street;

                //OracleParameter prm212 = new OracleParameter("City", OracleType.VarChar, 50);
                //prm212.Direction = ParameterDirection.Input;
                //prm212.Value = City;
                //objOraclecommand.Parameters.Add(prm212);

                objmysqlcommand.Parameters.Add("City", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["City"].Value = City;

                //OracleParameter prm221 = new OracleParameter("Zip", OracleType.VarChar, 50);
                //prm221.Direction = ParameterDirection.Input;
                //prm221.Value = Zip;
                //objOraclecommand.Parameters.Add(prm221);

                objmysqlcommand.Parameters.Add("Zip", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Zip"].Value = Zip;

                //OracleParameter prm2142 = new OracleParameter("District", OracleType.VarChar, 50);
                //prm2142.Direction = ParameterDirection.Input;
                //prm2142.Value = District;
                //objOraclecommand.Parameters.Add(prm2142);

                objmysqlcommand.Parameters.Add("District", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["District"].Value = District;

                //OracleParameter prm223 = new OracleParameter("State", OracleType.VarChar, 50);
                //prm223.Direction = ParameterDirection.Input;
                //prm223.Value = State;
                //objOraclecommand.Parameters.Add(prm223);

                objmysqlcommand.Parameters.Add("State", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State"].Value = State;

                //OracleParameter prm228 = new OracleParameter("Country", OracleType.VarChar, 50);
                //prm228.Direction = ParameterDirection.Input;
                //prm228.Value = Country;
                //objOraclecommand.Parameters.Add(prm228);

                objmysqlcommand.Parameters.Add("Country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country"].Value = Country;

                //OracleParameter prm2147 = new OracleParameter("Phone1", OracleType.VarChar, 50);
                //prm2147.Direction = ParameterDirection.Input;
                //prm2147.Value = Phone1;
                //objOraclecommand.Parameters.Add(prm2147);

                objmysqlcommand.Parameters.Add("Phone1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Phone1"].Value = Phone1;

                //OracleParameter prm265 = new OracleParameter("Phone2", OracleType.VarChar, 50);
                //prm265.Direction = ParameterDirection.Input;
                //prm265.Value = Phone2;
                //objOraclecommand.Parameters.Add(prm265);

                objmysqlcommand.Parameters.Add("Phone2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Phone2"].Value = Phone2;

                //OracleParameter prm215 = new OracleParameter("fax", OracleType.VarChar, 50);
                //prm215.Direction = ParameterDirection.Input;
                //prm215.Value = Fax;
                //objOraclecommand.Parameters.Add(prm215);

                objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax"].Value = Fax;

                //OracleParameter prm2244 = new OracleParameter("Emailid", OracleType.VarChar, 50);
                //prm2244.Direction = ParameterDirection.Input;
                //prm2244.Value = EmailId;
                //objOraclecommand.Parameters.Add(prm2244);

                objmysqlcommand.Parameters.Add("Emailid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Emailid"].Value = EmailId;

                //OracleParameter prm2145 = new OracleParameter("StAcNo", OracleType.VarChar, 50);
                //prm2145.Direction = ParameterDirection.Input;
                //prm2145.Value = StAcNo;
                //objOraclecommand.Parameters.Add(prm2145);

                objmysqlcommand.Parameters.Add("StAcNo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["StAcNo"].Value = StAcNo;

                //OracleParameter prm266 = new OracleParameter("Pan", OracleType.VarChar, 50);
                //prm266.Direction = ParameterDirection.Input;
                //prm266.Value = Pan;
                //objOraclecommand.Parameters.Add(prm266);

                objmysqlcommand.Parameters.Add("Pan", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Pan"].Value = Pan;

                //OracleParameter prm2166 = new OracleParameter("Tan", OracleType.VarChar, 50);
                //prm2166.Direction = ParameterDirection.Input;
                //prm2166.Value = Tan;
                //objOraclecommand.Parameters.Add(prm2166);

                objmysqlcommand.Parameters.Add("Tan", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Tan"].Value = Tan;

                //OracleParameter prm2266 = new OracleParameter("Regno", OracleType.VarChar, 50);
                //prm2266.Direction = ParameterDirection.Input;
                //prm2266.Value = Regno;
                //objOraclecommand.Parameters.Add(prm2266);

                objmysqlcommand.Parameters.Add("Regno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Regno"].Value = Regno;

                objmysqlcommand.Parameters.Add("Regdate", MySqlDbType.VarChar);
                if (Regdate == "" || Regdate == null)
                {
                    objmysqlcommand.Parameters["Regdate"].Value = System.DBNull.Value;
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

                    objmysqlcommand.Parameters["Regdate"].Value = Convert.ToDateTime(Regdate).ToString("yyyy-MM-dd");
                }

                //OracleParameter prm21466 = new OracleParameter("Regdate", OracleType.VarChar, 50);
                //prm21466.Direction = ParameterDirection.Input;

                //if (Regdate == "" || Regdate == null)
                //{
                //    prm21466.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    if (dateformat == "dd/mm/yyyy")
                //    {
                //        string[] arr = Regdate.Split('/');
                //        string dd = arr[0];
                //        string mm = arr[1];
                //        string yy = arr[2];
                //        Regdate = mm + "/" + dd + "/" + yy;


                //    }

                //    prm21466.Value = Convert.ToDateTime(Regdate).ToString("dd-MMMM-yyyy");
                //}
                //objOraclecommand.Parameters.Add(prm21466);

                //OracleParameter prm2177 = new OracleParameter("Remarks", OracleType.VarChar);
                //prm2177.Direction = ParameterDirection.Input;
                //prm2177.Value = Remarks;
                //objOraclecommand.Parameters.Add(prm2177);

                objmysqlcommand.Parameters.Add("Remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Remarks"].Value = Remarks;

                //OracleParameter prm2288 = new OracleParameter("BoxAdd", OracleType.VarChar);
                //prm2288.Direction = ParameterDirection.Input;
                //prm2288.Value = BoxAdd;
                //objOraclecommand.Parameters.Add(prm2288);

                objmysqlcommand.Parameters.Add("BoxAdd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["BoxAdd"].Value = BoxAdd;

                //OracleParameter prm21487 = new OracleParameter("Userid", OracleType.VarChar, 50);
                //prm21487.Direction = ParameterDirection.Input;
                //prm21487.Value = userid;
                //objOraclecommand.Parameters.Add(prm21487);

                objmysqlcommand.Parameters.Add("Userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txtvatinno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtvatinno"].Value = vatinno;

                //objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                //objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        public DataSet selectcompany(string CompanyCode, string CompanyName, string Companyalias, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("COMPANYMASTSELECT_companymastselect_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("CompanyCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CompanyCode"].Value = CompanyCode;

                //OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                //prm21.Direction = ParameterDirection.Input;
                //prm21.Value = CompanyName;
                //objOraclecommand.Parameters.Add(prm21);

                objmysqlcommand.Parameters.Add("CompanyName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CompanyName"].Value = CompanyName;

                //OracleParameter prm22 = new OracleParameter("Companyalias", OracleType.VarChar, 50);
                //prm22.Direction = ParameterDirection.Input;
                //prm22.Value = Companyalias;
                //objOraclecommand.Parameters.Add(prm22);

                objmysqlcommand.Parameters.Add("Companyalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Companyalias"].Value = Companyalias;

                objmysqlcommand.Parameters.Add("Userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Userid"].Value = userid;
            
                

                //OracleParameter prm21487 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm21487.Direction = ParameterDirection.Input;
                //prm21487.Value = userid;
                //objOraclecommand.Parameters.Add(prm21487);

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet modifysave(string CompanyCode, string CompanyName, string Companyalias, string Companyadd, string Street, string City, string Zip, string District, string State, string Country, string Phone1, string Phone2, string Fax, string EmailId, string StAcNo, string Pan, string Tan, string Regno, string Regdate, string Remarks, string BoxAdd, string userid, string dateformat, string vatinno)
        {


            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("COMPANYMASTMODIFY_companymastmodify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objOracleConnection.Open();
                //objOraclecommand = GetCommand("companyinsert.companyinsert_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm2 = new OracleParameter("CompanyCode", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = CompanyCode;
                //objOraclecommand.Parameters.Add(prm2);

                objmysqlcommand.Parameters.Add("CompanyCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CompanyCode"].Value = CompanyCode;

                //OracleParameter prm21 = new OracleParameter("CompanyName", OracleType.VarChar, 50);
                //prm21.Direction = ParameterDirection.Input;
                //prm21.Value = CompanyName;
                //objOraclecommand.Parameters.Add(prm21);

                objmysqlcommand.Parameters.Add("CompanyName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CompanyName"].Value = CompanyName;

                //OracleParameter prm22 = new OracleParameter("Companyalias", OracleType.VarChar, 50);
                //prm22.Direction = ParameterDirection.Input;
                //prm22.Value = Companyalias;
                //objOraclecommand.Parameters.Add(prm22);

                objmysqlcommand.Parameters.Add("Companyalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Companyalias"].Value = Companyalias;

                //OracleParameter prm214 = new OracleParameter("Companyadd", OracleType.VarChar, 50);
                //prm214.Direction = ParameterDirection.Input;
                //prm214.Value = Companyadd;
                //objOraclecommand.Parameters.Add(prm214);

                objmysqlcommand.Parameters.Add("Companyadd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Companyadd"].Value = Companyadd;

                //OracleParameter prm211 = new OracleParameter("Street", OracleType.VarChar, 50);
                //prm211.Direction = ParameterDirection.Input;
                //prm211.Value = Street;
                //objOraclecommand.Parameters.Add(prm211);

                objmysqlcommand.Parameters.Add("Street11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Street11"].Value = Street;

                //OracleParameter prm212 = new OracleParameter("City", OracleType.VarChar, 50);
                //prm212.Direction = ParameterDirection.Input;
                //prm212.Value = City;
                //objOraclecommand.Parameters.Add(prm212);

                objmysqlcommand.Parameters.Add("City11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["City11"].Value = City;

                //OracleParameter prm221 = new OracleParameter("Zip", OracleType.VarChar, 50);
                //prm221.Direction = ParameterDirection.Input;
                //prm221.Value = Zip;
                //objOraclecommand.Parameters.Add(prm221);

                objmysqlcommand.Parameters.Add("Zip11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Zip11"].Value = Zip;

                //OracleParameter prm2142 = new OracleParameter("District", OracleType.VarChar, 50);
                //prm2142.Direction = ParameterDirection.Input;
                //prm2142.Value = District;
                //objOraclecommand.Parameters.Add(prm2142);

                objmysqlcommand.Parameters.Add("District11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["District11"].Value = District;

                //OracleParameter prm223 = new OracleParameter("State", OracleType.VarChar, 50);
                //prm223.Direction = ParameterDirection.Input;
                //prm223.Value = State;
                //objOraclecommand.Parameters.Add(prm223);

                objmysqlcommand.Parameters.Add("State11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State11"].Value = State;

                //OracleParameter prm228 = new OracleParameter("Country", OracleType.VarChar, 50);
                //prm228.Direction = ParameterDirection.Input;
                //prm228.Value = Country;
                //objOraclecommand.Parameters.Add(prm228);

                objmysqlcommand.Parameters.Add("Country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country"].Value = Country;

                //OracleParameter prm2147 = new OracleParameter("Phone1", OracleType.VarChar, 50);
                //prm2147.Direction = ParameterDirection.Input;
                //prm2147.Value = Phone1;
                //objOraclecommand.Parameters.Add(prm2147);

                objmysqlcommand.Parameters.Add("Phone111", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Phone111"].Value = Phone1;

                //OracleParameter prm265 = new OracleParameter("Phone2", OracleType.VarChar, 50);
                //prm265.Direction = ParameterDirection.Input;
                //prm265.Value = Phone2;
                //objOraclecommand.Parameters.Add(prm265);

                objmysqlcommand.Parameters.Add("Phone211", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Phone211"].Value = Phone2;

                //OracleParameter prm215 = new OracleParameter("fax", OracleType.VarChar, 50);
                //prm215.Direction = ParameterDirection.Input;
                //prm215.Value = Fax;
                //objOraclecommand.Parameters.Add(prm215);

                objmysqlcommand.Parameters.Add("fax11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax11"].Value = Fax;

                //OracleParameter prm2244 = new OracleParameter("Emailid", OracleType.VarChar, 50);
                //prm2244.Direction = ParameterDirection.Input;
                //prm2244.Value = EmailId;
                //objOraclecommand.Parameters.Add(prm2244);

                objmysqlcommand.Parameters.Add("Emailid11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Emailid11"].Value = EmailId;

                //OracleParameter prm2145 = new OracleParameter("StAcNo", OracleType.VarChar, 50);
                //prm2145.Direction = ParameterDirection.Input;
                //prm2145.Value = StAcNo;
                //objOraclecommand.Parameters.Add(prm2145);

                objmysqlcommand.Parameters.Add("StAcNo11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["StAcNo11"].Value = StAcNo;

                //OracleParameter prm266 = new OracleParameter("Pan", OracleType.VarChar, 50);
                //prm266.Direction = ParameterDirection.Input;
                //prm266.Value = Pan;
                //objOraclecommand.Parameters.Add(prm266);

                objmysqlcommand.Parameters.Add("Pan11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Pan11"].Value = Pan;

                //OracleParameter prm2166 = new OracleParameter("Tan", OracleType.VarChar, 50);
                //prm2166.Direction = ParameterDirection.Input;
                //prm2166.Value = Tan;
                //objOraclecommand.Parameters.Add(prm2166);

                objmysqlcommand.Parameters.Add("Tan11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Tan11"].Value = Tan;

                //OracleParameter prm2266 = new OracleParameter("Regno", OracleType.VarChar, 50);
                //prm2266.Direction = ParameterDirection.Input;
                //prm2266.Value = Regno;
                //objOraclecommand.Parameters.Add(prm2266);

                objmysqlcommand.Parameters.Add("Regno11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Regno11"].Value = Regno;

                objmysqlcommand.Parameters.Add("Regdate", MySqlDbType.VarChar);
                if (Regdate == "" || Regdate == null)
                {
                    objmysqlcommand.Parameters["Regdate"].Value = System.DBNull.Value;
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

                    objmysqlcommand.Parameters["Regdate"].Value = Convert.ToDateTime(Regdate).ToString("yyyy-MM-dd");
                }

                //OracleParameter prm21466 = new OracleParameter("Regdate", OracleType.VarChar, 50);
                //prm21466.Direction = ParameterDirection.Input;

                //if (Regdate == "" || Regdate == null)
                //{
                //    prm21466.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    if (dateformat == "dd/mm/yyyy")
                //    {
                //        string[] arr = Regdate.Split('/');
                //        string dd = arr[0];
                //        string mm = arr[1];
                //        string yy = arr[2];
                //        Regdate = mm + "/" + dd + "/" + yy;


                //    }

                //    prm21466.Value = Convert.ToDateTime(Regdate).ToString("dd-MMMM-yyyy");
                //}
                //objOraclecommand.Parameters.Add(prm21466);

                //OracleParameter prm2177 = new OracleParameter("Remarks", OracleType.VarChar);
                //prm2177.Direction = ParameterDirection.Input;
                //prm2177.Value = Remarks;
                //objOraclecommand.Parameters.Add(prm2177);

                objmysqlcommand.Parameters.Add("Remarks11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Remarks11"].Value = Remarks;

                //OracleParameter prm2288 = new OracleParameter("BoxAdd", OracleType.VarChar);
                //prm2288.Direction = ParameterDirection.Input;
                //prm2288.Value = BoxAdd;
                //objOraclecommand.Parameters.Add(prm2288);

                objmysqlcommand.Parameters.Add("BoxAdd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["BoxAdd"].Value = BoxAdd;

                //OracleParameter prm21487 = new OracleParameter("Userid", OracleType.VarChar, 50);
                //prm21487.Direction = ParameterDirection.Input;
                //prm21487.Value = userid;
                //objOraclecommand.Parameters.Add(prm21487);

                objmysqlcommand.Parameters.Add("Userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txtvatinno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtvatinno"].Value = vatinno;

                //objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                //objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        public DataSet selectcompany(string CompanyName)
        {
            
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkcompanyname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;





                objmysqlcommand.Parameters.Add("CompanyName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CompanyName"].Value = CompanyName;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);

                if (CompanyName.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = CompanyName.Substring(0, 2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = CompanyName;
                }

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet next(string CompanyCode, string CompanyName, string Companyalias, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("COMPANYSELECTFNPL_companyselectfnpl_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = CompanyCode;
            
                




                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet DeleteValue(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("COMPANYMASTDELETE_companymastdelete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;





                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        
        public DataSet execute_zone(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("cir_dynamic_execute_stmt", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("@ptable_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@ptable_name"].Value = tblname;

                objmysqlcommand.Parameters.Add("@pcond_colname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pcond_colname"].Value = colname;

                objmysqlcommand.Parameters.Add("@pcond_colval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pcond_colval"].Value = colvalue;


                objmysqlcommand.Parameters.Add("@pdelimiter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pdelimiter"].Value = "$~$";


                objmysqlcommand.Parameters.Add("@pdateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pdateformat"].Value = date;

                objmysqlcommand.Parameters.Add("@pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pextra1"].Value = extra1;


                objmysqlcommand.Parameters.Add("@pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pextra2"].Value = extra2;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet Save_misccode(string tablefields, string tablevalue, string tablename, string action, string date, string extra1, string extra2)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("cir_dynamic_execute_stmt", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("@ptable_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@ptable_name"].Value = tablename;

                objmysqlcommand.Parameters.Add("@pcond_colname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pcond_colname"].Value = tablefields;

                objmysqlcommand.Parameters.Add("@pcond_colval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pcond_colval"].Value = tablevalue;


                objmysqlcommand.Parameters.Add("@pdelimiter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pdelimiter"].Value = "$~$";


                objmysqlcommand.Parameters.Add("@pdateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pdateformat"].Value = date;

                objmysqlcommand.Parameters.Add("@pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pextra1"].Value = extra1;


                objmysqlcommand.Parameters.Add("@pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["@pextra2"].Value = extra2;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
    }
}