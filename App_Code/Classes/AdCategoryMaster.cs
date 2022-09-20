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
/// Summary description for AdCategoryMaster
/// </summary>
namespace NewAdbooking.Classes
{
    public class AdCategoryMaster : connection
    {
        public AdCategoryMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Code for the insert the data into the data base//
        public DataSet advcatinsert1(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype, string regclient, string filemane, string status, string productivity, string hrs, string min, string preodicity, string discount, string discamt, string ffdiscount, string ffdiscamt, string cashdisc, string cashamt, string ldgenday, string ldgenflag, string eddiscflag)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advinsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                objSqlCommand.Parameters.Add("@catalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catalias"].Value = catalias;

                objSqlCommand.Parameters.Add("@catname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catname"].Value = catname;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@rclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rclient"].Value = regclient;


                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filemane;

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = status;

                objSqlCommand.Parameters.Add("@productivity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productivity"].Value = productivity;

                objSqlCommand.Parameters.Add("@hrs", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hrs"].Value = hrs;

                objSqlCommand.Parameters.Add("@min", SqlDbType.VarChar);
                objSqlCommand.Parameters["@min"].Value = min;

                objSqlCommand.Parameters.Add("@preodicity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@preodicity"].Value = preodicity;

                objSqlCommand.Parameters.Add("@pdiscount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdiscount"].Value = discount;

                objSqlCommand.Parameters.Add("@pdiscamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdiscamt"].Value = discamt;

                objSqlCommand.Parameters.Add("@pffdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pffdisctype"].Value = ffdiscount;

                objSqlCommand.Parameters.Add("@pffdiscamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pffdiscamt"].Value = ffdiscamt;

                objSqlCommand.Parameters.Add("@pcashdisc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcashdisc"].Value = cashdisc;

                objSqlCommand.Parameters.Add("@pcashamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcashamt"].Value = cashamt;

                objSqlCommand.Parameters.Add("@lead_days", SqlDbType.VarChar);
                if (ldgenday == "")
                {
                    objSqlCommand.Parameters["@lead_days"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@lead_days"].Value = ldgenday;
                }

                objSqlCommand.Parameters.Add("@lead_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lead_flag"].Value = ldgenflag;

                objSqlCommand.Parameters.Add("@edition_dis_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_dis_flag"].Value = eddiscflag;

               



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

        public DataSet advcatchk(string compcode, string userid, string adcatcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advchk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;


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



        //Code for the Modify the data into the data base//
        public DataSet advcatupdate1(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype, string regclient, string filename, string status, string productivity, string hrs, string min, string preodicity, string discount, string discamt, string ffdiscount, string ffdiscamt, string cashdisc, string cashamt, string ldgenday, string ldgenflag, string eddiscflag)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                objSqlCommand.Parameters.Add("@catalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catalias"].Value = catalias;

                objSqlCommand.Parameters.Add("@catname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catname"].Value = catname;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@rclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rclient"].Value = regclient;


                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;


                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = status;

                objSqlCommand.Parameters.Add("@productivity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productivity"].Value = productivity;


                objSqlCommand.Parameters.Add("@hrs", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hrs"].Value = hrs;


                objSqlCommand.Parameters.Add("@min", SqlDbType.VarChar);
                objSqlCommand.Parameters["@min"].Value = min;

                objSqlCommand.Parameters.Add("@preodicity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@preodicity"].Value = preodicity;

                objSqlCommand.Parameters.Add("@pdiscount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdiscount"].Value = discount;

                objSqlCommand.Parameters.Add("@pdiscamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdiscamt"].Value = discamt;

                objSqlCommand.Parameters.Add("@pffdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pffdisctype"].Value = ffdiscount;

                objSqlCommand.Parameters.Add("@pffdiscamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pffdiscamt"].Value = ffdiscamt;

                objSqlCommand.Parameters.Add("@pcashdisc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcashdisc"].Value = cashdisc;

                objSqlCommand.Parameters.Add("@pcashamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcashamt"].Value = cashamt;

                objSqlCommand.Parameters.Add("@lead_days", SqlDbType.VarChar);
                if (ldgenday == "")
                {
                    objSqlCommand.Parameters["@lead_days"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@lead_days"].Value = ldgenday;
                }

                objSqlCommand.Parameters.Add("@lead_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lead_flag"].Value = ldgenflag;

                objSqlCommand.Parameters.Add("@edition_dis_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_dis_flag"].Value = eddiscflag;

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

        //Code for the Execute the commande for fetch the data from the data base//
        public DataSet advcatexecute(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype)//, string catediname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advcatexec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                //if (adcatcode != "" && adcatcode != null)
                //{
                    objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@adcatcode"].Value = "%%";
                //}



                objSqlCommand.Parameters.Add("@catalias", SqlDbType.VarChar);
                //if (catalias != "" && catalias != null)
                //{
                    objSqlCommand.Parameters["@catalias"].Value = catalias;

                //}
                //else
                //{
                //    objSqlCommand.Parameters["@catalias"].Value = "%%";
                //}

                    objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@catname", SqlDbType.VarChar);
                //if (catname != "" && catname != null)
                //{
                    objSqlCommand.Parameters["@catname"].Value = catname;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@catname"].Value = "%%";
                //}


                //objSqlCommand.Parameters.Add("@catediname", SqlDbType.VarChar);
                //if (catediname != "0" && catediname != null)
                //{

                //    objSqlCommand.Parameters["@catediname"].Value = catediname;

                //}
                //else
                //{
                //    objSqlCommand.Parameters["@catediname"].Value = "%%";
                //}


                //objSqlCommand.Parameters.Add("@focusday", SqlDbType.VarChar);
                //if(focusday=="0" )
                //{
                //objSqlCommand.Parameters["@focusday"].Value ="%%";

                //}
                //else
                //{
                //    objSqlCommand.Parameters["@focusday"].Value =focusday;

                //}


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



        //public DataSet advcatexecute12(string compcode,string userid,string adcatcode,string catalias,string catname,string catediname,string focusday)
        public DataSet advcatexecute12(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype)//, string catediname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advcatexec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                //if (adcatcode != "" && adcatcode != null)
                //{
                    objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@adcatcode"].Value = "%%";
                //}

                    objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@catalias", SqlDbType.VarChar);
                //if (catalias != "" && catalias != null)
                //{
                    objSqlCommand.Parameters["@catalias"].Value = catalias;

                //}
                //else
                //{
                //    objSqlCommand.Parameters["@catalias"].Value = "%%";
                //}



                objSqlCommand.Parameters.Add("@catname", SqlDbType.VarChar);
                //if (catname != "" && catname != null)
                //{
                    objSqlCommand.Parameters["@catname"].Value = catname;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@catname"].Value = "%%";
                //}


                //objSqlCommand.Parameters.Add("@catediname", SqlDbType.VarChar);
                //if (catediname != "0" && catediname != null)
                //{

                //    objSqlCommand.Parameters["@catediname"].Value = catediname;

                //}
                //else
                //{
                //    objSqlCommand.Parameters["@catediname"].Value = "%%";
                //}


                //objSqlCommand.Parameters.Add("@focusday", SqlDbType.VarChar);
                //if(focusday!="0"  )
                //{

                //    objSqlCommand.Parameters["@focusday"].Value =focusday;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@focusday"].Value ="%%";
                //}


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





        //Code for the See the first data//
        public DataSet advcatfirst(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advcatfnpl", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                //	objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@flag"].Value =z;



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


        //Code for the See the Last data//
        public DataSet advcatlast(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advcatfnpl", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@flag"].Value =z;



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


        //Code for the See the Previous data//
        public DataSet advcatpre(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advcatfnpl", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@flag"].Value =z;



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

        //Code for the See the Next data//
        public DataSet advcatnext(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advcatfnpl", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@flag"].Value =z;



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

        //Code for the Delete the data from the data base//
        public DataSet advcatdel(string compcode, string adcatcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advcatdel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                //objSqlCommand.Parameters.Add("@hiddenccode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@hiddenccode"].Value = hiddenccode;


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

        //Code for Auto Genereate-Code for the CategoryName// 
        public DataSet countadcatcode( string str,string adtype,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkadcatcodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

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



        public DataSet ckkusercode(string adcatcode, string catname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkadcatuser", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                objSqlCommand.Parameters.Add("@catname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catname"].Value = catname;

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


     
        //Code for the save the select day in the data base//
        public DataSet selectaddaysave(string compcode, string adcatcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("slelectadcatdaysave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sun"].Value = sun;

                objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mon"].Value = mon;

                objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tue"].Value = tue;

                objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@wed"].Value = wed;

                objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@thu"].Value = thu;

                objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fri"].Value = fri;

                objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sat"].Value = sat;

                objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
                objSqlCommand.Parameters["@all"].Value = all;

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

        public DataSet checkadcode(string compcode, string adcatcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkadcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

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

        //Code for the modify the select day in the data base//
        public DataSet selectaddaymodify(string compcode, string adcatcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("slelectaddaymodify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sun"].Value = sun;

                objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mon"].Value = mon;


                objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tue"].Value = tue;

                objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@wed"].Value = wed;

                objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@thu"].Value = thu;


                objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fri"].Value = fri;

                objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sat"].Value = sat;

                objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
                objSqlCommand.Parameters["@all"].Value = all;

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

       //Enable check boxes on select The Edition Day//
        public DataSet editionday(string drpednname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("enableadcatday", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@editionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editionname"].Value = drpednname;


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

        //*********************************************************************************//
        //**************************Coding For PoP Up Window*******************************//
        //*********************************************************************************//

        //Bind The Drop Down For Select Edition//
        public DataSet selectedition(string compcode,string userid)//,string edition)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("selecteditionname", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                cmd.Parameters["@userid"].Value = userid;

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
        //Proceduer  For Submit//
        public DataSet editionsubmit(string compcode, string userid, string adcatcode, string edition, string chk1, string chk2, string chk3, string chk4, string chk5, string chk6, string chk7, string chk8)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet  ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("editionsubmit",ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                    cmd.Parameters["@adcatcode"].Value = adcatcode;

                    cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                    cmd.Parameters["@compcode"].Value=compcode;

                    cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                    cmd.Parameters["@userid"].Value=userid;

                    cmd.Parameters.Add("@editioncode", SqlDbType.VarChar);
                    cmd.Parameters["@editioncode"].Value = edition;
    
                     cmd.Parameters.Add("@sun", SqlDbType.VarChar);
                     cmd.Parameters["@sun"].Value=chk1;

                     cmd.Parameters.Add("@mon", SqlDbType.VarChar);
                     cmd.Parameters["@mon"].Value=chk2;

                     cmd.Parameters.Add("@tue", SqlDbType.VarChar);
                     cmd.Parameters["@tue"].Value=chk3;

                    cmd.Parameters.Add("@wed", SqlDbType.VarChar);
                    cmd.Parameters["@wed"].Value=chk4;

                    cmd.Parameters.Add("@thu", SqlDbType.VarChar);
                    cmd.Parameters["@thu"].Value=chk5;

                    cmd.Parameters.Add("@fri", SqlDbType.VarChar);
                    cmd.Parameters["@fri"].Value=chk6;

                    cmd.Parameters.Add("@sat", SqlDbType.VarChar);
                    cmd.Parameters["@sat"].Value=chk7;

                    cmd.Parameters.Add("@all", SqlDbType.VarChar);
                    cmd.Parameters["@all"].Value = chk8;

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

        //Bind The Data Grid //
        public DataSet editionbindgrid(string compcode, string userid)//, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editiondatabind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@edition"].Value = edition;

                ////objSqlCommand.Parameters.Add("@values", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@values"].Value = values;

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



        //Procedure For check The Edition code //
        public DataSet editionchk(string compcode, string userid, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionchk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = edition;


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

        //Procedure For Modify//
        public DataSet editionmodify(string compcode, string userid, string adcatcode, string edition, string chk1, string chk2, string chk3, string chk4, string chk5, string chk6, string chk7, string chk8, string hiddenccode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("editionmodify", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                cmd.Parameters["@adcatcode"].Value = adcatcode;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                cmd.Parameters["@userid"].Value = userid;

                cmd.Parameters.Add("@editioncode", SqlDbType.VarChar);
                cmd.Parameters["@editioncode"].Value = edition;

                cmd.Parameters.Add("@sun", SqlDbType.VarChar);
                cmd.Parameters["@sun"].Value = chk1;

                cmd.Parameters.Add("@mon", SqlDbType.VarChar);
                cmd.Parameters["@mon"].Value = chk2;

                cmd.Parameters.Add("@tue", SqlDbType.VarChar);
                cmd.Parameters["@tue"].Value = chk3;

                cmd.Parameters.Add("@wed", SqlDbType.VarChar);
                cmd.Parameters["@wed"].Value = chk4;

                cmd.Parameters.Add("@thu", SqlDbType.VarChar);
                cmd.Parameters["@thu"].Value = chk5;

                cmd.Parameters.Add("@fri", SqlDbType.VarChar);
                cmd.Parameters["@fri"].Value = chk6;

                cmd.Parameters.Add("@sat", SqlDbType.VarChar);
                cmd.Parameters["@sat"].Value = chk7;

                cmd.Parameters.Add("@all", SqlDbType.VarChar);
                cmd.Parameters["@all"].Value = chk8;

                cmd.Parameters.Add("@hiddenccode", SqlDbType.VarChar);
                cmd.Parameters["@hiddenccode"].Value = hiddenccode;

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

      //  Procedure For Delete//

        public DataSet editiondelete(string compcode, string userid, string edition, string hiddenccode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editiondel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@hiddenccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hiddenccode"].Value = hiddenccode;


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
        //My//
        ////Procedure for the select the Row From the Data Grid//
        public DataSet seledition(string adcatcode, string userid, string compcode, string code10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editiondaysel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = code10;

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


        //public DataSet selectpublication()
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("selectadcategory", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}

        public DataSet adname(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adv_bindcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;


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


        public DataSet catwiesedition(string adcatcode, string userid, string compcode)//, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("catwiesedition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centcode"].Value = adcatcode;

                //objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@date"].Value = dateformat;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



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



        public DataSet chkedit(string edition, string adcatcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcategoryedition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;





                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet editionchk_b(string compcode, string adcatcode, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionchk_b", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = edition;


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

        public DataSet selectadtxtsave(string compcode, string adcatcode, string txtsun, string txtmon, string txttue, string txtwed, string txtthu, string txtfri, string txtsat,  string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("slelectadcattxtsave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                objSqlCommand.Parameters.Add("@txtsun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtsun"].Value = txtsun;

                objSqlCommand.Parameters.Add("@txtmon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtmon"].Value = txtmon;

                objSqlCommand.Parameters.Add("@txttue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txttue"].Value = txttue;

                objSqlCommand.Parameters.Add("@txtwed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtwed"].Value = txtwed;

                objSqlCommand.Parameters.Add("@txtthu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtthu"].Value = txtthu;

                objSqlCommand.Parameters.Add("@txtfri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtfri"].Value = txtfri;

                objSqlCommand.Parameters.Add("@txtsat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtsat"].Value = txtsat;

      
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

        public DataSet slelectadtxtmodify(string compcode, string adcatcode, string txtsun, string txtmon, string txttue, string txtwed, string txtthu, string txtfri, string txtsat, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("slelectadtxtmodify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

                objSqlCommand.Parameters.Add("@txtsun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtsun"].Value = txtsun;

                objSqlCommand.Parameters.Add("@txtmon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtmon"].Value = txtmon;


                objSqlCommand.Parameters.Add("@txttue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txttue"].Value = txttue;

                objSqlCommand.Parameters.Add("@txtwed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtwed"].Value = txtwed;

                objSqlCommand.Parameters.Add("@txtthu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtthu"].Value = txtthu;


                objSqlCommand.Parameters.Add("@txtfri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtfri"].Value = txtfri;

                objSqlCommand.Parameters.Add("@txtsat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtsat"].Value = txtsat;


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



        public DataSet checkadtxt(string compcode, string adcatcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkadtxt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;

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

    }
}
