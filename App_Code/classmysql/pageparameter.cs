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
    /// Summary description for pageparameter
    /// </summary>
    public class pageparameter:connection 
    {
        public pageparameter()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet uombind(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adduom", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;





              
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

        public DataSet checkpage(string pagecode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkpagecode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pagecode"].Value = pagecode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;





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

        public DataSet savepageparam(string drpadvtype, string txtpagecode, string drpedition, string drocolor, string txtpageno, string txtadvsize, string txtcolno, string drpuom, string txtremarks, string compcode, string userid, string drpadvcategory, string pub)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertpageparam", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("txtpagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtpagecode"].Value = txtpagecode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;

                objmysqlcommand.Parameters.Add("drpadvtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadvtype"].Value = drpadvtype;


                objmysqlcommand.Parameters.Add("drpedition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpedition"].Value = drpedition;


                objmysqlcommand.Parameters.Add("drocolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drocolor"].Value = drocolor;


                objmysqlcommand.Parameters.Add("txtpageno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtpageno"].Value = txtpageno;


                objmysqlcommand.Parameters.Add("txtadvsize", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtadvsize"].Value = txtadvsize;


                objmysqlcommand.Parameters.Add("txtcolno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcolno"].Value = txtcolno;


                objmysqlcommand.Parameters.Add("drpuom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpuom"].Value = drpuom;


                objmysqlcommand.Parameters.Add("txtremarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtremarks"].Value = txtremarks;

                objmysqlcommand.Parameters.Add("drpadvcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadvcategory"].Value = drpadvcategory;







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

        public DataSet executepagepara(string drpadvtype, string txtpagecode, string drpedition, string drpadvcategory, string drocolor, string txtpageno, string txtadvsize, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executepagepara", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("txtpagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtpagecode"].Value = txtpagecode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("drpadvtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadvtype"].Value = drpadvtype;


                objmysqlcommand.Parameters.Add("drpedition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpedition"].Value = drpedition;


                objmysqlcommand.Parameters.Add("drocolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drocolor"].Value = drocolor;


                objmysqlcommand.Parameters.Add("txtpageno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtpageno"].Value = txtpageno;


                objmysqlcommand.Parameters.Add("txtadvsize", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtadvsize"].Value = txtadvsize;








              objmysqlcommand.Parameters.Add("drpadvcategory", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["drpadvcategory"].Value = drpadvcategory;








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
        public DataSet pagefirst()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("firstpageparam", ref objmysqlconnection);
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

        public DataSet updatepageparam(string drpadvtype, string txtpagecode, string drpedition, string drocolor, string txtpageno, string txtadvsize, string txtcolno, string drpuom, string txtremarks, string compcode, string userid, string drpadvcategory, string pub)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatepageparam", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("txtpagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtpagecode"].Value = txtpagecode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("drpadvtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadvtype"].Value = drpadvtype;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;


                objmysqlcommand.Parameters.Add("drpedition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpedition"].Value = drpedition;


                objmysqlcommand.Parameters.Add("drocolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drocolor"].Value = drocolor;


                objmysqlcommand.Parameters.Add("txtpageno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtpageno"].Value = txtpageno;


                objmysqlcommand.Parameters.Add("txtadvsize", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtadvsize"].Value = txtadvsize;


                objmysqlcommand.Parameters.Add("txtcolno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcolno"].Value = txtcolno;


                objmysqlcommand.Parameters.Add("drpuom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpuom"].Value = drpuom;


                objmysqlcommand.Parameters.Add("txtremarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtremarks"].Value = txtremarks;

                objmysqlcommand.Parameters.Add("drpadvcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadvcategory"].Value = drpadvcategory;




                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



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

        public DataSet deletepageparam(string pagecode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletepageparam", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pagecode"].Value = pagecode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;





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

        public DataSet chkpagecode()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkpagecodename", ref objmysqlconnection);
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

        public DataSet addedition(string pubname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fill_editionalias", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = pubname;

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
