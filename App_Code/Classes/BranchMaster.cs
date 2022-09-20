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
/// Summary description for BranchMaster
/// </summary>
namespace NewAdbooking.Classes
{
    public class BranchMaster : connection
    {
        public DataSet chkdel(string compcode, string branchcode, string branchname, string alias)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("CHECKBRANCHEXIST", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@branchname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchname"].Value = branchname;

                objSqlCommand.Parameters.Add("@branchalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchalias"].Value = alias;



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
        public DataSet addcity()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("clientfillcity", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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



        public DataSet addregion(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("regionbind", ref objSqlConnection);
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


        public DataSet addzone(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("zonebind", ref objSqlConnection);
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
        public DataSet addcountry(string compcode)
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






        public DataSet addpickdistname(string citycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillstaedistcountry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@citycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@citycode"].Value = citycode;

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


        public DataSet branchchk(string compcode, string userid, string branchcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchchk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                //objSqlCommand.Parameters.Add("@branchname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@branchname"].Value =branchname;

                //objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@alias"].Value =alias;

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


        public DataSet branchchkcode(string str, string pubcent, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchchkcodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;



                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@pubcent", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcent"].Value = pubcent;
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

        public DataSet pubcodechk(string str, string compcod)//, string city)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkpubcatcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcod;


                //objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@cod"].Value = str;

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
        //public DataSet branchinsert(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter, string boxadd, string Branchnick, string branchaccont)
        public DataSet branchinsert(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter, string boxadd, string Branchnick, string finphone1, string finphone2, string collph1, string collph2, string cirph1, string cirph2, string npph1, string npph2, string stph1, string stph2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchinsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@branchname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchname"].Value = branchname;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                objSqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                objSqlCommand.Parameters["@address"].Value = address;

                objSqlCommand.Parameters.Add("@street", SqlDbType.VarChar);
                objSqlCommand.Parameters["@street"].Value = street;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@pin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pin"].Value = pin;

                objSqlCommand.Parameters.Add("@phone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone1"].Value = phone1;

                objSqlCommand.Parameters.Add("@phone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone2"].Value = phone2;

                objSqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                objSqlCommand.Parameters["@email"].Value = email;

                objSqlCommand.Parameters.Add("@zone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone"].Value = zone;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;



                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@boxadd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxadd"].Value = boxadd;

                objSqlCommand.Parameters.Add("@pbranchnick", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranchnick"].Value = Branchnick;

                objSqlCommand.Parameters.Add("@pbranchaccont", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranchaccont"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@finphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@finphone1"].Value = finphone1;

                objSqlCommand.Parameters.Add("@finphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@finphone2"].Value = finphone2;


                objSqlCommand.Parameters.Add("@collphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@collphone1"].Value = collph1;


                objSqlCommand.Parameters.Add("@collphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@collphone2"].Value = collph2;

                objSqlCommand.Parameters.Add("@cirphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirphone1"].Value = cirph1;

                objSqlCommand.Parameters.Add("@cirphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirphone2"].Value = cirph2;

                objSqlCommand.Parameters.Add("@npphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@npphone1"].Value = npph1;

                objSqlCommand.Parameters.Add("@npphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@npphone2"].Value = npph2;

                objSqlCommand.Parameters.Add("@stphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stphone1"].Value = stph1;

                objSqlCommand.Parameters.Add("@stphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stphone2"].Value = stph2;


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

        //public DataSet branchupdate(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter, string boxadd, string Branchnick, string branchaccount, string finphone1, string finphone2, string collph1, string collph2, string cirph1, string cirph2, string npph1, string npph2, string stph1, string stph2)
        public DataSet branchupdate(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter, string boxadd, string Branchnick, string finphone1, string finphone2, string collph1, string collph2, string cirph1, string cirph2, string npph1, string npph2, string stph1, string stph2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@branchname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchname"].Value = branchname;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                objSqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                objSqlCommand.Parameters["@address"].Value = address;

                objSqlCommand.Parameters.Add("@street", SqlDbType.VarChar);
                objSqlCommand.Parameters["@street"].Value = street;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@pin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pin"].Value = pin;

                objSqlCommand.Parameters.Add("@phone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone1"].Value = phone1;

                objSqlCommand.Parameters.Add("@phone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone2"].Value = phone2;

                objSqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                objSqlCommand.Parameters["@email"].Value = email;

                objSqlCommand.Parameters.Add("@zone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone"].Value = zone;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@boxadd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxadd"].Value = boxadd;


                objSqlCommand.Parameters.Add("@pbranchnick", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranchnick"].Value = Branchnick;

                objSqlCommand.Parameters.Add("@pbranchaccont", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranchaccont"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@finphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@finphone1"].Value = finphone1;

                objSqlCommand.Parameters.Add("@finphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@finphone2"].Value = finphone2;


                objSqlCommand.Parameters.Add("@collphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@collphone1"].Value = collph1;


                objSqlCommand.Parameters.Add("@collphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@collphone2"].Value = collph2;

                objSqlCommand.Parameters.Add("@cirphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirphone1"].Value = cirph1;

                objSqlCommand.Parameters.Add("@cirphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirphone2"].Value = cirph2;

                objSqlCommand.Parameters.Add("@npphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@npphone1"].Value = npph1;

                objSqlCommand.Parameters.Add("@npphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@npphone2"].Value = npph2;

                objSqlCommand.Parameters.Add("@stphone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stphone1"].Value = stph1;

                objSqlCommand.Parameters.Add("@stphone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stphone2"].Value = stph2;


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

        public DataSet branchexe(string compcode, string userid, string branchcode, string branchname, string alias, string country, string city, string pubcenter)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchexe", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@branchname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchname"].Value = branchname;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;


                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;



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

        public DataSet branchfnpl(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchfnpl", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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



        public DataSet branchdel(string compcode, string userid, string branchcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchdel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

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


        public DataSet contactbind(string branchcode, string userid, string compcode, string dateformat)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date"].Value = dateformat;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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


        //**************************To check Contact Person***************************

        public DataSet chksubmitcontact1(string contactperson, string branchcode)
        {
            //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchhckcontper", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;


                objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contactperson"].Value = contactperson;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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
        //*******************************************************************************************

        //**************************To check Contact Person at time of update***************************

        public DataSet chksubmitcontactupdate(string contactperson, string branchcode)
        {
            //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchhckcontperupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;


                objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contactperson"].Value = contactperson;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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

        public DataSet contactupdate(string contactperson, string dob, string designation, string phone, string ext, string fax, string mail, string compcode, string userid, string branchcode, string update)
        {
            //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchcontup", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contactperson"].Value = contactperson;

                objSqlCommand.Parameters.Add("@designation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@designation"].Value = designation;

                objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);
                if (dob != "" && dob != null)
                {
                    objSqlCommand.Parameters["@dob"].Value = Convert.ToDateTime(dob);
                }
                else
                {
                    objSqlCommand.Parameters["@dob"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone"].Value = phone;

                objSqlCommand.Parameters.Add("@ext", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ext"].Value = ext;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mail"].Value = mail;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@update", SqlDbType.VarChar);
                objSqlCommand.Parameters["@update"].Value = update;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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

        public DataSet insertcontact(string contact, string designation, string dob, string phone, string ext, string fax, string mail, string userid, string branchcode, string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchcontin", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@contact", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contact"].Value = contact;

                objSqlCommand.Parameters.Add("@designation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@designation"].Value = designation;

                objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);

                if (dob != null && dob != "")
                {
                    objSqlCommand.Parameters["@dob"].Value = Convert.ToDateTime(dob);
                }
                else
                {
                    objSqlCommand.Parameters["@dob"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone"].Value = phone;

                objSqlCommand.Parameters.Add("@ext", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ext"].Value = ext;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mail"].Value = mail;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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


        public DataSet contactbind12(string branchcode, string compcode, string userid, string hiddencccode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchselect", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@hiddencccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hiddencccode"].Value = hiddencccode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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


        public DataSet contactdelete(string branchcode, string compcode, string userid, string update)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchcontdel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@update", SqlDbType.VarChar);
                objSqlCommand.Parameters["@update"].Value = update;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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


        public DataSet branchnamechk(string str)//, string city)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkbranchname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

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

        public DataSet bindbranchNo(string compcode, string branchaccount, string dateformat)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fa_account_mast_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@pacc_ty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pacc_ty"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = branchaccount;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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



        public DataSet bindempcode_new(string compcode, string empname)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                //  objSqlCommand = GetCommand("regionbind", ref objSqlConnection);
                //  objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand = GetCommand("emp_code_bindall", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@pname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pname"].Value = empname;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

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

        public DataSet bindempcode(string compcode, string empname)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();

                objSqlCommand = GetCommand("emp_code_bindall", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@pname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pname"].Value = empname;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

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
