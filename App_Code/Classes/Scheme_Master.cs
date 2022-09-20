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
/// Summary description for Scheme_Master
/// </summary>

namespace NewAdbooking.Classes
{
    public class Scheme_Master:connection
    {
        public Scheme_Master()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet schemechk(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount, string compcode, string userid, string scheme_name, string sc)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("schemechk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@scheme_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme_id"].Value = scheme_id;

                objSqlCommand.Parameters.Add("@schemecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemecode"].Value = schemecode;

                objSqlCommand.Parameters.Add("@scheme_name",SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme_name"].Value = scheme_name;

                objSqlCommand.Parameters.Add("@sc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sc"].Value = sc;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@validfrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validfrom"].Value = validfrom;

                objSqlCommand.Parameters.Add("@validto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validto"].Value = validto;

                objSqlCommand.Parameters.Add("@discount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discount"].Value = discount;

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



        public DataSet schemeautocode(string scheme_name)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("schemeautocode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@scheme_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme_name"].Value = scheme_name;

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




        public DataSet modifyscheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount, string compcode, string userid, string scheme_name)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("modifyscheme", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@scheme_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme_id"].Value = scheme_id;

                objSqlCommand.Parameters.Add("@schemecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemecode"].Value = schemecode;


                objSqlCommand.Parameters.Add("@scheme_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme_name"].Value = scheme_name;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@validfrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validfrom"].Value = validfrom;

                objSqlCommand.Parameters.Add("@validto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validto"].Value = validto;

                objSqlCommand.Parameters.Add("@discount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discount"].Value = discount;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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


        public DataSet schememodifychk(string scheme_id, string schemecode, string scheme_name, string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("schememodifychk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@scheme_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme_id"].Value = scheme_id;

                objSqlCommand.Parameters.Add("@schemecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemecode"].Value = schemecode;


                objSqlCommand.Parameters.Add("@scheme_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme_name"].Value = scheme_name;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;


                //return objDataSet;

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


        //public DataSet updatescheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount, string compcode, string userid, string flagsave)
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("schemeupdate", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;


        //        objSqlCommand.Parameters.Add("@scheme_id", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@scheme_id"].Value = scheme_id;

        //        objSqlCommand.Parameters.Add("@schemecode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@schemecode"].Value = schemecode;


        //        objSqlCommand.Parameters.Add("@frominsert", SqlDbType.Decimal);
        //        if (frominsert == null || frominsert == "")
        //        {
        //            objSqlCommand.Parameters["@frominsert"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@frominsert"].Value = Convert.ToInt32(frominsert);
        //        }

        //        objSqlCommand.Parameters.Add("@toinsert", SqlDbType.Decimal);
        //        if (toinsert == null || toinsert == "")
        //        {
        //            objSqlCommand.Parameters["@toinsert"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@toinsert"].Value = Convert.ToInt32(toinsert);
        //        }

        //        objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
        //        if (discount == null || discount == "")
        //        {
        //            objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
        //        }

        //        objSqlCommand.Parameters.Add("@validfrom", SqlDbType.DateTime);
        //        if (validfrom == "" || validfrom == null || validfrom == "undefined/undefined/")
        //        {
        //            objSqlCommand.Parameters["@validfrom"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@validfrom"].Value = Convert.ToDateTime(validfrom);
        //        }

        //        objSqlCommand.Parameters.Add("@validto", SqlDbType.DateTime);
        //        if (validto == "" || validto == null || validto == "undefined/undefined/")
        //        {
        //            objSqlCommand.Parameters["@validto"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@validto"].Value = Convert.ToDateTime(validto);
        //        }

                
        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlCommand.Parameters.Add("@flagsave", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@flagsave"].Value = flagsave;


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

        //public DataSet savescheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount_type, string discount, string compcode, string userid, string flag, string scheme_name,string adcat)
        public DataSet savescheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount_type, string discount, string compcode, string userid, string flag, string scheme_name, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string contidate,string alternatedate)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("schemesave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@editioncode"].Value =editioncode;

                objSqlCommand.Parameters.Add("@scheme_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme_id"].Value = scheme_id;

                objSqlCommand.Parameters.Add("@schemecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemecode"].Value = schemecode;

                objSqlCommand.Parameters.Add("@scheme_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme_name"].Value = scheme_name;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.Int);
                if (frominsert == null || frominsert == "")
                {
                    objSqlCommand.Parameters["@frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@frominsert"].Value = Convert.ToInt32(frominsert);
                }

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.Int);
                if (toinsert == null || toinsert == "")
                {
                    objSqlCommand.Parameters["@toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@toinsert"].Value = Convert.ToInt32(toinsert);
                }


                objSqlCommand.Parameters.Add("@discount_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discount_type"].Value = discount_type;




                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == null || discount == "")
                {
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
                }

                objSqlCommand.Parameters.Add("@validfrom", SqlDbType.VarChar);
                if (validfrom == "" || validfrom == null || validfrom == "undefined/undefined/")
                {
                    objSqlCommand.Parameters["@validfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validfrom"].Value = validfrom;//Convert.ToDateTime(validfrom);
                }

                objSqlCommand.Parameters.Add("@validto", SqlDbType.VarChar);
                if (validto == "" || validto == null || validto == "undefined/undefined/")
                {
                    objSqlCommand.Parameters["@validto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validto"].Value = validto;// Convert.ToDateTime(validto);
                }


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@toinsert", SqlDbType.Decimal);
                //if (toinsert == null || toinsert == "")
                //{
                //    objSqlCommand.Parameters["@toinsert"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@toinsert"].Value = Convert.ToInt32(toinsert);


                //}


                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

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

                objSqlCommand.Parameters.Add("@pcontidate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcontidate"].Value = contidate;


                //objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@consumtion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@consumtion"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@alternatedate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alternatedate"].Value = alternatedate;
                
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
        public DataSet ptdelete(string scheme_id, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();
            try
            {
                con.Open();
                cmd = GetCommand("schemedelete", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@scheme_id", SqlDbType.VarChar);
                cmd.Parameters["@scheme_id"].Value = scheme_id;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

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


        public DataSet ptexecute(string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount_type, string discount, string compcode, string scheme_name, string contidate)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("schemeexe", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@scheme_name", SqlDbType.VarChar);
                cmd.Parameters["@scheme_name"].Value = scheme_name;

                cmd.Parameters.Add("@schemecode", SqlDbType.VarChar);
                cmd.Parameters["@schemecode"].Value = schemecode;

                cmd.Parameters.Add("@frominsert", SqlDbType.VarChar);
                cmd.Parameters["@frominsert"].Value = frominsert;

                cmd.Parameters.Add("@toinsert", SqlDbType.VarChar);
                cmd.Parameters["@toinsert"].Value = toinsert;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@validfrom", SqlDbType.VarChar);
                cmd.Parameters["@validfrom"].Value = validfrom;

                cmd.Parameters.Add("@validto", SqlDbType.VarChar);
                cmd.Parameters["@validto"].Value = validto;

                cmd.Parameters.Add("@discount_type", SqlDbType.VarChar);
                cmd.Parameters["@discount_type"].Value = discount_type;

                cmd.Parameters.Add("@discount", SqlDbType.VarChar);
                cmd.Parameters["@discount"].Value = discount;

                cmd.Parameters.Add("@pcontidate", SqlDbType.VarChar);
                cmd.Parameters["@pcontidate"].Value = contidate;


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




    }
}
