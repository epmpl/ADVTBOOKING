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
    /// Summary description for UOM
    /// </summary>
    public class UOM:connection 
    {
        public UOM()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet checkuomcode(string code, string txtuomdesc, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkuom_checkuom_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("uomname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uomname"].Value = txtuomdesc;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;





                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet countuomcode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkuomcodename_chkuomcodename_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                
                //objmysqlcommand.Parameters["cod"].Value = str;
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;

                }

                objmysqlcommand.Parameters.Add("company_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["company_code"].Value = "";
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet; ;

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

        public DataSet insertinuom(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string txtuomtype, string adtype, string sampleimg, string stylesheet, string uom_desc, string logo, string logouom, string column, string gutwidth, string colwidth, string acc_cd, string sacc_cd)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertuom_insertuom_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("txtuomcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtuomcode"].Value = txtuomcode;

                objmysqlcommand.Parameters.Add("txtuomdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtuomdesc"].Value = txtuomdesc;


                objmysqlcommand.Parameters.Add("txtalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtalias"].Value = txtalias;


                objmysqlcommand.Parameters.Add("txtuomtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtuomtype"].Value = txtuomtype;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("sample_img_hm", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sample_img_hm"].Value = sampleimg;

                objmysqlcommand.Parameters.Add("stylesheetname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["stylesheetname"].Value = stylesheet;

                objmysqlcommand.Parameters.Add("uom_desc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom_desc"].Value = uom_desc;

                objmysqlcommand.Parameters.Add("logo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["logo"].Value = logo;

                objmysqlcommand.Parameters.Add("logouom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["logouom"].Value = logouom;

                objmysqlcommand.Parameters.Add("pcolumn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcolumn"].Value = column;
           

                objmysqlcommand.Parameters.Add("gutwidth", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gutwidth"].Value = gutwidth;

                objmysqlcommand.Parameters.Add("colwidth", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colwidth"].Value = gutwidth;

                objmysqlcommand.Parameters.Add("acc_cd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc_cd"].Value = acc_cd;


                objmysqlcommand.Parameters.Add("sacc_cd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sacc_cd"].Value = sacc_cd;
               

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet executeuom(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string adtype, string uomtype, string acc_cd, string sacc_cd)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executeuom_executeuom_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("txtuomcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtuomcode"].Value = txtuomcode;

                objmysqlcommand.Parameters.Add("txtuomdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtuomdesc"].Value = txtuomdesc;


                objmysqlcommand.Parameters.Add("txtalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtalias"].Value = txtalias;


                if (uomtype == "0")
                {
                    uomtype = "";
                }

                objmysqlcommand.Parameters.Add("uomtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uomtype"].Value = uomtype;


                if (adtype == "0")
                {
                    adtype = "";
                }

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("acc_cd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc_cd"].Value = acc_cd;

                objmysqlcommand.Parameters.Add("sacc_cd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sacc_cd"].Value = sacc_cd;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet firstquery()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("firstuom_firstuom_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;








                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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
        public DataSet updaetcode(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string txtuomtype, string adtype, string sampleimg, string stylesheet,string uom_desc,string logo,string logouom ,string  column,string gutwidth,string colwidth, string acc_cd, string sacc_cd)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updateuom_updateuom_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("txtuomcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtuomcode"].Value = txtuomcode;

                objmysqlcommand.Parameters.Add("txtuomdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtuomdesc"].Value = txtuomdesc;


                objmysqlcommand.Parameters.Add("txtalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtalias"].Value = txtalias;


                objmysqlcommand.Parameters.Add("txtuomtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtuomtype"].Value = txtuomtype;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("sample_img_hm", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sample_img_hm"].Value = sampleimg;

                objmysqlcommand.Parameters.Add("stylesheetname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["stylesheetname"].Value = stylesheet;

                objmysqlcommand.Parameters.Add("uom_desc1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom_desc1"].Value = uom_desc;

                objmysqlcommand.Parameters.Add("logo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["logo"].Value = logo;

                objmysqlcommand.Parameters.Add("logouom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["logouom"].Value = logouom;
                //column, gutwidth,colwidth,
                objmysqlcommand.Parameters.Add("pcolumn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcolumn"].Value = column;

                objmysqlcommand.Parameters.Add("gutwidth", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gutwidth"].Value = gutwidth;

                objmysqlcommand.Parameters.Add("colwidth", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colwidth"].Value = colwidth;

                objmysqlcommand.Parameters.Add("acc_cd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc_cd"].Value = acc_cd;

                objmysqlcommand.Parameters.Add("sacc_cd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sacc_cd"].Value = sacc_cd;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet deleteuom(string code, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deleteuom_deleteuom_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = code;





                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (MySqlException objException)
            {
                throw (objException);
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
        public DataSet bindes()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fromuom", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;






                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (MySqlException objException)
            {
                throw (objException);
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
