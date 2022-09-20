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
    /// Summary description for AgencyCategoryMaster
    /// </summary>
    public class AgencyCategoryMaster:connection
    {
        public AgencyCategoryMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet addagencytype()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
              objmysqlconnection.Open();
              objmysqlcommand = GetCommand("adagencytype_adagencytype_p", ref objmysqlconnection);
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
        public DataSet acmsave(string companycode, string code, string name, string alias, string agencytype, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acm_Save_acm_Save_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc"].Value = code;

                objmysqlcommand.Parameters.Add("acn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acn"].Value = name;

                objmysqlcommand.Parameters.Add("aca", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["aca"].Value = alias;



                objmysqlcommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencytype"].Value = agencytype;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

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

        public DataSet acmmodify(string companycode, string code, string name, string alias, string agencytype, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acm_Modify_acm_Modify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc"].Value = code;

                objmysqlcommand.Parameters.Add("acn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acn"].Value = name;

                objmysqlcommand.Parameters.Add("aca", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["aca"].Value = alias;


                objmysqlcommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencytype"].Value = agencytype;

                //objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value=UserId;

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

        public DataSet acmdelete(string companycode, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acm_Delete_acm_Delete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc"].Value = code;

                objmysqlcommand.Parameters.Add("acn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acn"].Value = name;

                objmysqlcommand.Parameters.Add("aca", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["aca"].Value = alias;

                //objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value=UserId;

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

        public DataSet acmexecute(string companycode, string code, string name, string alias, string agencytype, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acm_Execute_acm_Execute_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
                objmysqlcommand.Parameters["acc"].Value = code;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["acc"].Value="%%";
                //}

                objmysqlcommand.Parameters.Add("acn", MySqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
                objmysqlcommand.Parameters["acn"].Value = name;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["acn"].Value ="%%";
                //}

                objmysqlcommand.Parameters.Add("aca", MySqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
                objmysqlcommand.Parameters["aca"].Value = alias;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["aca"].Value ="%%";
                //}

                objmysqlcommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                //if (agencytype != "0" && agencytype != null )
                //{
                objmysqlcommand.Parameters["agencytype"].Value = agencytype;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["agencytype"].Value = "%%";
                //}
                //objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value=UserId;

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


        public DataSet acmexecute1(string companycode, string code, string name, string alias, string agencytype, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acm_Execute_acm_Execute_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
                objmysqlcommand.Parameters["acc"].Value = code;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["acc"].Value="%%";
                //}

                objmysqlcommand.Parameters.Add("acn", MySqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
                objmysqlcommand.Parameters["acn"].Value = name;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["acn"].Value ="%%";
                //}

                objmysqlcommand.Parameters.Add("aca", MySqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
                objmysqlcommand.Parameters["aca"].Value = alias;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["aca"].Value ="%%";
                //}
                objmysqlcommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                //if (agencytype != "0" && agencytype != null)
                //{
                objmysqlcommand.Parameters["agencytype"].Value = agencytype;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["agencytype"].Value = "%%";
                //}
                //objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value=UserId;

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

     /*   public DataSet acmfirst(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acmfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

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

        public DataSet acmlast(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acmfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

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

        public DataSet acmprevious(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acmfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

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

        public DataSet acmnext(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acmfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

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

        public DataSet chkacmcode(string companycode, string UserId, string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("acmcheck_acmcheck_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc"].Value = code;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

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
        public DataSet countacmcodename(string str, string drpagencytype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkacmcodename_chkacmcodename_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }
                objmysqlcommand.Parameters.Add("drpagencytype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpagencytype"].Value = drpagencytype;


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
