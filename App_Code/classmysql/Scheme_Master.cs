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
    /// Summary description for Scheme_Master
    /// </summary>


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

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemechk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("scheme_id", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_id"].Value = scheme_id;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;

                objmysqlcommand.Parameters.Add("scheme_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_name"].Value = scheme_name;

                objmysqlcommand.Parameters.Add("sc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sc"].Value = sc;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("validfrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfrom"].Value = validfrom;

                objmysqlcommand.Parameters.Add("validto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validto"].Value = validto;

                objmysqlcommand.Parameters.Add("discount", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["discount"].Value = discount;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcat"].Value = System.DBNull.Value;

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



        public DataSet schemeautocode(string scheme_name)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemeautocode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("scheme_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_name"].Value = scheme_name;

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




        public DataSet modifyscheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount, string compcode, string userid, string scheme_name)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("modifyscheme", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("scheme_id", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_id"].Value = scheme_id;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;


                objmysqlcommand.Parameters.Add("scheme_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_name"].Value = scheme_name;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("validfrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfrom"].Value = validfrom;

                objmysqlcommand.Parameters.Add("validto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validto"].Value = validto;

                objmysqlcommand.Parameters.Add("discount", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["discount"].Value = discount;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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


        public DataSet schememodifychk(string scheme_id, string schemecode, string scheme_name, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemecheckname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("scheme_id", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_id"].Value = scheme_id;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;


                objmysqlcommand.Parameters.Add("scheme_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_name"].Value = scheme_name;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;


                //return objDataSet;

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


        //public DataSet savescheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount_type, string discount, string compcode, string userid, string flag, string scheme_name,string adcat)
        public DataSet savescheme(string scheme_id, string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount_type, string discount, string compcode, string userid, string flag, string scheme_name)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemesave", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["editioncode"].Value =editioncode;

                objmysqlcommand.Parameters.Add("schemeid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemeid"].Value = scheme_id;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;

                objmysqlcommand.Parameters.Add("scheme_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_name"].Value = scheme_name;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.Int24);
                if (frominsert == null || frominsert == "")
                {
                    objmysqlcommand.Parameters["frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["frominsert"].Value = Convert.ToInt32(frominsert);
                }

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.Int24);
                if (toinsert == null || toinsert == "")
                {
                    objmysqlcommand.Parameters["toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["toinsert"].Value = Convert.ToInt32(toinsert);
                }


                objmysqlcommand.Parameters.Add("discount_type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["discount_type"].Value = discount_type;




                objmysqlcommand.Parameters.Add("discount", MySqlDbType.Decimal);
                if (discount == null || discount == "")
                {
                    objmysqlcommand.Parameters["discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["discount"].Value = Convert.ToDecimal(discount);
                }

                objmysqlcommand.Parameters.Add("validfrom", MySqlDbType.Datetime);
                if (validfrom == "" || validfrom == null || validfrom == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["validfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfrom"].Value = Convert.ToDateTime(validfrom).ToString("yyyy-MM-dd");
                }

                objmysqlcommand.Parameters.Add("validto", MySqlDbType.Datetime);
                if (validto == "" || validto == null || validto == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["validto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validto"].Value = Convert.ToDateTime(validto).ToString("yyyy-MM-dd");
                }


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.Decimal);
                //if (toinsert == null || toinsert == "")
                //{
                //    objmysqlcommand.Parameters["toinsert"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["toinsert"].Value = Convert.ToInt32(toinsert);
                //}
                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;

                //objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["adcat"].Value = adcat;



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
        public DataSet ptdelete(string scheme_id, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemedelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("scheme_id", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_id"].Value = scheme_id;

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


        public DataSet ptexecute(string schemecode, string frominsert, string toinsert, string validfrom, string validto, string discount_type, string discount, string compcode, string scheme_name)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemeexe", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("scheme_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_name"].Value = scheme_name;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("validfrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfrom"].Value = validfrom;

                objmysqlcommand.Parameters.Add("validto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validto"].Value = validto;

                objmysqlcommand.Parameters.Add("discount_type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["discount_type"].Value = discount_type;

                objmysqlcommand.Parameters.Add("discount", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["discount"].Value = discount;


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



        public DataSet schemeexecuteMain(string schemecode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemeexecuteMain", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;

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

        public DataSet schemeexecute(string schemecode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemeexecute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;

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

        public DataSet deletegrid(string schemeid, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemedelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("schemeid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemeid"].Value = schemeid;

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

        public DataSet deletescheme(string schemecode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemedeletegrid", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;

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
      /*  public DataSet updatescheme(string schemeid, string frominsert, string toinsert, string discount, string compcode, string flag, string txtdescription)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemesave", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["editioncode"].Value =editioncode;

                objmysqlcommand.Parameters.Add("scheme_id", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_id"].Value = schemeid;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;

                objmysqlcommand.Parameters.Add("scheme_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme_name"].Value = scheme_name;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.Int);
                if (frominsert == null || frominsert == "")
                {
                    objmysqlcommand.Parameters["frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["frominsert"].Value = Convert.ToInt32(frominsert);
                }

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.Int);
                if (toinsert == null || toinsert == "")
                {
                    objmysqlcommand.Parameters["toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["toinsert"].Value = Convert.ToInt32(toinsert);
                }


                objmysqlcommand.Parameters.Add("discount_type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["discount_type"].Value = discount_type;




                objmysqlcommand.Parameters.Add("discount", MySqlDbType.Decimal);
                if (discount == null || discount == "")
                {
                    objmysqlcommand.Parameters["discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["discount"].Value = Convert.ToDecimal(discount);
                }

                objmysqlcommand.Parameters.Add("validfrom", MySqlDbType.Datetime);
                if (validfrom == "" || validfrom == null || validfrom == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["validfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfrom"].Value = Convert.ToDateTime(validfrom).ToString("yyyy-MM-dd");
                }

                objmysqlcommand.Parameters.Add("validto", MySqlDbType.Datetime);
                if (validto == "" || validto == null || validto == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["validto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validto"].Value = Convert.ToDateTime(validto).ToString("yyyy-MM-dd");
                }


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.Decimal);
                //if (toinsert == null || toinsert == "")
                //{
                //    objmysqlcommand.Parameters["toinsert"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["toinsert"].Value = Convert.ToInt32(toinsert);
                //}
                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;

                //objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["adcat"].Value = adcat;



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
        }*/
    }
}