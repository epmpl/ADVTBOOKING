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
    /// Summary description for bulletmaster
    /// </summary>
    public class bulletmaster:connection
    {
        public bulletmaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet checkrevcode(string comcode, string bulletdesc, string compcode, string userid, string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkbullet_checkbullet_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comcode"].Value = comcode;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("bulletdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletdesc"].Value = bulletdesc;


                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;



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

        //public DataSet insertintobullet(string bulletcode,string advtype,string edition,string bulletdesc,string bulletcharge,string bullettext,string remarks,string listboxvalue,string validatedate,string validatetill,string compcode,string userid)
        public DataSet insertintobullet(string bulletcode, string bulletdesc, string bulletcharge, string bullettext, string remarks, string validatedate, string validatetill, string compcode, string userid, string sumble, string pubcenter, string font)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertbullet_insertbullet_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("bulletcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletcode"].Value = bulletcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objSqlCommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["advtype"].Value =advtype;

                //objSqlCommand.Parameters.Add("edition",MySqlDbType.VarChar);
                //objSqlCommand.Parameters["edition"].Value=edition;

                objmysqlcommand.Parameters.Add("bulletdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletdesc"].Value = bulletdesc;

                objmysqlcommand.Parameters.Add("bulletcharge", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletcharge"].Value = bulletcharge;

                objmysqlcommand.Parameters.Add("bullettext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bullettext"].Value = bullettext;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;

                objmysqlcommand.Parameters.Add("sumble", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sumble"].Value = sumble;

                //objSqlCommand.Parameters.Add("listboxvalue", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["listboxvalue"].Value =listboxvalue;

                objmysqlcommand.Parameters.Add("validatedate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["validatedate"].Value = Convert.ToDateTime(validatedate);


                objmysqlcommand.Parameters.Add("validatetill", MySqlDbType.DateTime);
                //objSqlCommand.Parameters["validatetill"].Value=Convert.ToDateTime(validatetill);

                if (validatetill != "" && validatetill != null)
                {
                    objmysqlcommand.Parameters["validatetill"].Value = Convert.ToDateTime(validatetill);
                }
                else
                {

                    objmysqlcommand.Parameters["validatetill"].Value = System.DBNull.Value;
                }


                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;

                objmysqlcommand.Parameters.Add("font", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["font"].Value = font;


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

        //public DataSet executebulletmast(string advtype,string edition,string bulletcode,string bulletdesc,string bulletcharge,string bullettext,string listboxvalue,string compcode,string userid)
        public DataSet executebulletmast(string bulletcode, string bulletdesc, string bulletcharge, string bullettext, string compcode, string userid, string pubcenter, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executebulletbullet_executebulletbullet_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["advtype"].Value = advtype;

                //objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("bulletcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletcode"].Value = bulletcode;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("bulletdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletdesc"].Value = bulletdesc;

                objmysqlcommand.Parameters.Add("bulletcharge", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletcharge"].Value = bulletcharge;

                objmysqlcommand.Parameters.Add("bullettext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bullettext"].Value = bullettext;


                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;


                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;


                //objmysqlcommand.Parameters.Add("listboxvalue", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["listboxvalue"].Value =listboxvalue;

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

        public DataSet bulletfirst()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("firstbullet_firstbullet_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


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

        // public DataSet updateinbullet(string bulletcode,string advtype,string edition,string bulletdesc,string bulletcharge,string bullettext,string remarks,string listboxvalue,string validatedate,string validatetill,string compcode,string userid)
        public DataSet updateinbullet(string bulletcode, string bulletdesc, string bulletcharge, string bullettext, string remarks, string validatedate, string validatetill, string compcode, string userid, string sumble, string pubcenter, string font)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatebullet_updatebullet_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("bulletcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletcode"].Value = bulletcode;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["advtype"].Value =advtype;

                //objmysqlcommand.Parameters.Add("edition",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["edition"].Value=edition;

                objmysqlcommand.Parameters.Add("bulletdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletdesc"].Value = bulletdesc;

                objmysqlcommand.Parameters.Add("bulletcharge", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletcharge"].Value = bulletcharge;

                objmysqlcommand.Parameters.Add("bullettext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bullettext"].Value = bullettext;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;

                objmysqlcommand.Parameters.Add("sumble", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sumble"].Value = sumble;
                //objmysqlcommand.Parameters.Add("listboxvalue", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["listboxvalue"].Value =listboxvalue;

                objmysqlcommand.Parameters.Add("validatedate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["validatedate"].Value = Convert.ToDateTime(validatedate);

                objmysqlcommand.Parameters.Add("validatetill", MySqlDbType.DateTime);
                //objmysqlcommand.Parameters["validatetill"].Value=Convert.ToDateTime(validatetill);

                if (validatetill != "" && validatetill != null)
                {
                    objmysqlcommand.Parameters["validatetill"].Value = Convert.ToDateTime(validatetill);
                }
                else
                {

                    objmysqlcommand.Parameters["validatetill"].Value = System.DBNull.Value;
                }

                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;

                objmysqlcommand.Parameters.Add("font1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["font1"].Value = font;

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


        public DataSet deletevalue(string bulletcode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletebullet_deletebullet_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("bulletcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletcode"].Value = bulletcode;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value=userid;





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

        public DataSet checkmultibull(string compcode, string userid, string adsizecode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkmultiselectbullet", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;




                objmysqlcommand.Parameters.Add("adsizecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsizecode"].Value = adsizecode;



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
        public DataSet chkinsbull(string compcode, string userid, string adsizecode, string abc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertmultibullet", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;




                objmysqlcommand.Parameters.Add("adsizecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsizecode"].Value = adsizecode;

                objmysqlcommand.Parameters.Add("abc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["abc"].Value = abc;

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


        /*********************************************/

        public DataSet countbulletcode(string str, string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkbulletcodename_chkbulletcodename_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cod"].Value = str;

                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;


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

        public DataSet getlistad_cat(string xyz, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("book_advcategory_book_advcategory_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("booking", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["booking"].Value = xyz;

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


        /********************************************/


        public DataSet countbulletname(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkbulletname_chkbulletname_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cod"].Value = str;


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



        public DataSet listboxbullupdate(string compcode, string userid, string adsizecode, string abc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatemultibullet", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;




                objmysqlcommand.Parameters.Add("adsizecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsizecode"].Value = adsizecode;

                objmysqlcommand.Parameters.Add("abc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["abc"].Value = abc;

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

        public DataSet getSymbol(string bulletcode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getSymbol", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("bulletcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bulletcode"].Value = bulletcode;

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
