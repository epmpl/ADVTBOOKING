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
    /// Summary description for BoxMaster
    /// </summary>
    public class BoxMaster:connection 
    {
        public BoxMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet savebox(string boxcode, string boxname, string alias, string dispatch, string boxcharge, string native1, string inter, string fromdate, string todate, string remarks, string compcode, string userid ,string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("boxsave_boxsave_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("boxcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxcode"].Value = boxcode;
                objmysqlcommand.Parameters.Add("boxname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxname"].Value = boxname;
                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;
                objmysqlcommand.Parameters.Add("dispatch", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dispatch"].Value = dispatch;
                objmysqlcommand.Parameters.Add("boxcharge", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxcharge"].Value = boxcharge;
                objmysqlcommand.Parameters.Add("native1", MySqlDbType.Decimal);
                if (native1 == null || native1 == "" || native1 == "NaN")
                {
                    objmysqlcommand.Parameters["native1"].Value = System.DBNull.Value;
                   
                }
                else
                {
                    objmysqlcommand.Parameters["native1"].Value = Convert.ToDecimal(native1);
                }

                objmysqlcommand.Parameters.Add("inter", MySqlDbType.Decimal);
                if (inter == null || inter == "" || inter == "NaN")
                {
                    objmysqlcommand.Parameters["inter"].Value = System.DBNull.Value;

                }
                else
                {
                    objmysqlcommand.Parameters["inter"].Value = Convert.ToDecimal(inter);
                }

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
                if (todate == "" || todate == null || todate == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate);
                }


                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                if (todate == "" || todate == null || todate == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["todate"].Value = System.DBNull.Value;
                
                }
                else
                {
                    objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate);
                }



                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;


                
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


        public DataSet autocode(string str, string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("boxautocode_boxautocode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if(str.Length>2)
                {
                objmysqlcommand.Parameters["cod"].Value = str.Substring (0,2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }

                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;

                //objmysqlDataAdapter = new objmysqlDataAdapter();
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
        public DataSet updatebox(string boxcode, string boxname, string alias, string dispatch, string boxcharge, string native1, string inter, string fromdate, string todate, string remarks, string compcode, string userid,string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("boxupdate_boxupdate_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("boxcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxcode"].Value = boxcode;
                objmysqlcommand.Parameters.Add("boxname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxname"].Value = boxname;
                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;
                objmysqlcommand.Parameters.Add("dispatch", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dispatch"].Value = dispatch;
                objmysqlcommand.Parameters.Add("boxcharge", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxcharge"].Value = boxcharge;
                objmysqlcommand.Parameters.Add("native1", MySqlDbType.Decimal);
                if (native1 == null || native1 == "" || native1 == "NaN")
                {
                    objmysqlcommand.Parameters["native1"].Value = System.DBNull.Value;

                }
                else
                {
                    objmysqlcommand.Parameters["native1"].Value = Convert.ToDecimal(native1);
                }

                objmysqlcommand.Parameters.Add("inter", MySqlDbType.Decimal);
                if (inter == null || inter == "" || inter == "NaN")
                {
                    objmysqlcommand.Parameters["inter"].Value = System.DBNull.Value;

                }
                else
                {
                    objmysqlcommand.Parameters["inter"].Value = Convert.ToDecimal(inter);
                }
                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
                if (todate == "" || todate == null || todate == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate);
                }

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                if (todate == "" || todate == null || todate == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["todate"].Value = System.DBNull.Value;

                }
                else
                {
                    objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate);
                }



                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;



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
        public DataSet boxexe(string boxcode, string boxname, string alias, string boxcharge, string compcode, string userid,string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("boxexe_boxexe_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("boxcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxcode"].Value = boxcode;
                objmysqlcommand.Parameters.Add("boxname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxname"].Value = boxname;
                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;
                objmysqlcommand.Parameters.Add("boxcharge", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxcharge"].Value = boxcharge;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;
                //objmysqlDataAdapter = new objmysqlDataAdapter();
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
        public DataSet boxfnpl(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("boxfnpl_boxfnpl_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                //objmysqlDataAdapter = new objmysqlDataAdapter();
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
        public DataSet boxchk(string boxcode, string boxname, string compcode, string userid, string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("boxchk_boxchk_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("boxcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxcode"].Value = boxcode;
                objmysqlcommand.Parameters.Add("boxname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxname"].Value = boxname;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;
                //objmysqlDataAdapter = new objmysqlDataAdapter();
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
        public DataSet modifychk(string boxcode, string boxname, string compcode, string userid,string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("modifychk_modifychk_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("boxcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxcode"].Value = boxcode;
                objmysqlcommand.Parameters.Add("boxname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxname"].Value = boxname;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;
                //objmysqlDataAdapter = new objmysqlDataAdapter();
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
        public DataSet boxdel(string boxcode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("boxdelete_boxdelete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;              
              
               
                objmysqlcommand.Parameters.Add("boxcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxcode"].Value = boxcode;
                //objmysqlDataAdapter = new objmysqlDataAdapter();
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