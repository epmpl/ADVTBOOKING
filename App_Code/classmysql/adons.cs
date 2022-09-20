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
    /// Summary description for adons
    /// </summary>
    public class adons:connection
    {
        public adons()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindadon(string compcode, string ratecode, string pkgcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindadongrid", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;

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


        public DataSet getpkgname(string compcode, string pkgcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getpkgname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;

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



        public DataSet insertadon(string publication, string edition, string supp, string rate, string compcode, string userid, string pkgcode, string pkgdesc, string pkgname, string ratecode, string rateuniqueid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adoninsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = publication;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;


                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("supp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supp"].Value = supp;

                objmysqlcommand.Parameters.Add("rate", MySqlDbType.Decimal);

                objmysqlcommand.Parameters["rate"].Value = Convert.ToDecimal(rate);

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;

                objmysqlcommand.Parameters.Add("pkgdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgdesc"].Value = pkgdesc;

                objmysqlcommand.Parameters.Add("pkgname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgname"].Value = pkgname;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

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


        public DataSet getdataup(string compcode, string ratecode, string code11)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getadondata", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("code11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code11"].Value = code11;

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




        public DataSet updateadon(string publication, string edition, string supp, string rate, string compcode, string code, string ratecode, string rateid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adonupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = publication;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("rateid", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["rateid"].Value = rateid;


                objmysqlcommand.Parameters.Add("supp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supp"].Value = supp;

                objmysqlcommand.Parameters.Add("rate", MySqlDbType.Decimal);
                objmysqlcommand.Parameters["rate"].Value = Convert.ToDecimal(rate);

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

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





        public DataSet deladon(string compcode, string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adondelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

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


        public DataSet chkdupins(string ratecode, string pub, string edit, string supp, string compcode, string flag)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdupinaddon", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value=pub;

                objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit"].Value = edit;

                objmysqlcommand.Parameters.Add("ratecode",MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;


                objmysqlcommand.Parameters.Add("supp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supp"].Value = supp;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;


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
    }
}