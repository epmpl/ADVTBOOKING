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
    /// Summary description for ColorRateGroupMast
    /// </summary>
    public class ColorRateGroupMast:connection
    {
        public ColorRateGroupMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet pubmast(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_BindPublication_CR_BindPublication_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["pubcode"].Value = pubcode;

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
        //Bind Edition
        public DataSet seledition(string compcode, string pub)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_BindEdition_CR_BindEdition_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pub;

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

        //Bind Supplement
        public DataSet suppliment(string compcode, string edition)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_BindSupplement", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = edition;

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
        //Bind Color
        public DataSet fillcolor(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_BindColor_CR_BindColor_P", ref objmysqlconnection);
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
        //AutoGenerated Code
        public DataSet autocode()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_autocode_CR_autocode_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["str"].Value = str;

                //objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["code"].Value = str;

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

        //Select Package
        public DataSet selpackage(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_BindPackage_CR_BindPackage_P", ref objmysqlconnection);
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

        //Display On Selected
        public DataSet packdes(string compcode, string pack_des)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_BindPackdescr_CR_BindPackdescr_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packdes", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packdes"].Value = pack_des;

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
        //Insert
        public DataSet insertedvalue(string crgcode, string crgname, string drppub, string drpedi, string drpsupp, string drpcolrate, string drpcolname, string crgover, string compcode, string userid, string fromdate, string tilldate, string colorcode, string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("cr_insert_cr_insert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("crgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["crgcode"].Value = crgcode;

                objmysqlcommand.Parameters.Add("crgname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["crgname"].Value = crgname;

                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = drppub;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = drpedi;

                objmysqlcommand.Parameters.Add("suppliment", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppliment"].Value = drpsupp;

                objmysqlcommand.Parameters.Add("colorrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorrate"].Value = drpcolrate;

                objmysqlcommand.Parameters.Add("colname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colname"].Value = drpcolname;

                objmysqlcommand.Parameters.Add("pecent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pecent"].Value = crgover;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.Datetime);
                if (fromdate == null || fromdate == "")
                {
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");
                }

                objmysqlcommand.Parameters.Add("tilldate", MySqlDbType.Datetime);
                if (tilldate == null || tilldate == "")
                {
                    objmysqlcommand.Parameters["tilldate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["tilldate"].Value = Convert.ToDateTime(tilldate).ToString("yyyy-MM-dd");
                }

                objmysqlcommand.Parameters.Add("colorcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorcode"].Value = colorcode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;


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

        //Chechk Code Before Insert
        public DataSet chkcode(string colorcode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_checkcode_CR_checkcode_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["code"].Value = crgcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("colorcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorcode"].Value = colorcode;

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

        //Check Color Before Insert
        public DataSet chkcolor(string drpcolname, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_checkcolor", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["code"].Value = crgcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("colorname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorname"].Value = drpcolname;

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

        //Check Color Before Modify
        public DataSet checkcolor(string drpcolname, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_checkcolormodify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["code"].Value = crgcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("colorname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorname"].Value = drpcolname;

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


        //Modify The Value
        public DataSet updatecrg(string crgcode, string crgname, string drppub, string drpedi, string drpsupp, string drpcolrate, string drpcolname, string crgover, string compcode, string fromdate, string tilldate, string colorcode, string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_Modify_CR_Modify_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("crgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["crgcode"].Value = crgcode;

                objmysqlcommand.Parameters.Add("crgname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["crgname"].Value = crgname;

                //objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["publication"].Value = drppub;

                //objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["edition"].Value = drpedi;

                //objmysqlcommand.Parameters.Add("suppliment", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["suppliment"].Value = drpsupp;

                objmysqlcommand.Parameters.Add("colorrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorrate"].Value = drpcolrate;

                objmysqlcommand.Parameters.Add("colname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colname"].Value = drpcolname;

                objmysqlcommand.Parameters.Add("pecent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pecent"].Value = crgover;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
                if (fromdate == null || fromdate == "")
                {
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");
                }

                objmysqlcommand.Parameters.Add("tilldate", MySqlDbType.Datetime);
                if (tilldate == null || tilldate == "")
                {
                    objmysqlcommand.Parameters["tilldate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["tilldate"].Value = Convert.ToDateTime(tilldate).ToString("yyyy-MM-dd");
                }


                objmysqlcommand.Parameters.Add("colorcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorcode"].Value = colorcode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

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

        //Execute Value
        public DataSet CR_Execute(string crgcode, string crgname, string drppub, string drpedi, string drpsupp, string drpcolrate, string drpcolname, string crgover, string compcode, string fromdate, string tilldate, string colorcode,string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_Execute_CR_Execute_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("crgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["crgcode"].Value = crgcode;

                objmysqlcommand.Parameters.Add("crgname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["crgname"].Value = crgname;

                //objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["publication"].Value = drppub;

                //objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["edition"].Value = drpedi;

                //objmysqlcommand.Parameters.Add("suppliment", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["suppliment"].Value = drpsupp;

                objmysqlcommand.Parameters.Add("colorrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorrate"].Value = drpcolrate;

                objmysqlcommand.Parameters.Add("colname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colname"].Value = drpcolname;

                objmysqlcommand.Parameters.Add("pecent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pecent"].Value = crgover;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.Datetime);
                if (fromdate == null || fromdate == "")
                {
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");
                }


                objmysqlcommand.Parameters.Add("tilldate", MySqlDbType.Datetime);
                if (tilldate == null || tilldate == "")
                {
                    objmysqlcommand.Parameters["tilldate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["tilldate"].Value = Convert.ToDateTime(tilldate).ToString("yyyy-MM-dd");
                }

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("colorcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorcode"].Value = colorcode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

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
        //Delete The Value
        public DataSet CRDelete(string colorcode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CR_Delete_CR_Delete_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("colorcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorcode"].Value = colorcode;

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




    }
}
