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
    /// Summary description for AgencySubCategoryMaster
    /// </summary>
    public class AgencySubCategoryMaster:connection
    {
        public AgencySubCategoryMaster()
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


        /*  public DataSet agencycategory(string agencytype)
          {
              SqlConnection objmysqlconnection;
              SqlCommand objmysqlcommand;
              objmysqlconnection = GetConnection();
              SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
              DataSet objDataSet = new DataSet();
              try
              {
                  objmysqlconnection.Open();
                  objmysqlcommand = GetCommand("fillcategory", ref objmysqlconnection);
                  objmysqlcommand.CommandType = CommandType.StoredProcedure;

                  objmysqlcommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                  objmysqlcommand.Parameters["agencytype"].Value = agencytype;

                  objSqlDataAdapter.SelectCommand = objmysqlcommand;
                  objSqlDataAdapter.Fill(objDataSet);

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



        public DataSet ascmsave(string companycode, string agency, string category, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascm_Save_Ascm_Save_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atc"].Value = agency;

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc"].Value = category;

                objmysqlcommand.Parameters.Add("ascc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascc"].Value = code;

                objmysqlcommand.Parameters.Add("ascn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascn"].Value = name;

                objmysqlcommand.Parameters.Add("asca", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["asca"].Value = alias;

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


        public DataSet ascmmodify(string companycode, string agency, string category, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascm_Modify_Ascm_Modify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atc"].Value = agency;

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc"].Value = category;

                objmysqlcommand.Parameters.Add("ascc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascc"].Value = code;

                objmysqlcommand.Parameters.Add("ascn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascn"].Value = name;

                objmysqlcommand.Parameters.Add("asca", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["asca"].Value = alias;

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

        public DataSet ascmdelete(string companycode, string agency, string category, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascm_Delete_Ascm_Delete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atc"].Value = agency;

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acc"].Value = category;

                objmysqlcommand.Parameters.Add("ascc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascc"].Value = code;

                objmysqlcommand.Parameters.Add("ascn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascn"].Value = name;

                objmysqlcommand.Parameters.Add("asca", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["asca"].Value = alias;

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

        public DataSet ascmexecute(string companycode, string agency, string category, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascm_Execute_Ascm_Execute_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                //if(agency == "0")
                //{
                //    objmysqlcommand.Parameters["atc"].Value="%%";
                //}
                //else
                //{
                objmysqlcommand.Parameters["atc"].Value = agency;
                //}

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                //if(category == "0")
                //{	
                //    objmysqlcommand.Parameters["acc"].Value="%%";
                //}
                //else
                //{
                objmysqlcommand.Parameters["acc"].Value = category;
                //}

                objmysqlcommand.Parameters.Add("ascc", MySqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
                objmysqlcommand.Parameters["ascc"].Value = code;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["ascc"].Value="%%";
                //}

                objmysqlcommand.Parameters.Add("ascn", MySqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
                objmysqlcommand.Parameters["ascn"].Value = name;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["ascn"].Value ="%%";
                //}

                objmysqlcommand.Parameters.Add("asca", MySqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
                objmysqlcommand.Parameters["asca"].Value = alias;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["asca"].Value ="%%";
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


        public DataSet ascmexecute1(string companycode, string agency, string category, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascm_Execute_Ascm_Execute_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                //if(agency == "0")
                //{
                //    objmysqlcommand.Parameters["atc"].Value="%%";
                //}
                //else
                //{
                objmysqlcommand.Parameters["atc"].Value = agency;
                //}

                objmysqlcommand.Parameters.Add("acc", MySqlDbType.VarChar);
                //if(category == "0")
                //{	
                //    objmysqlcommand.Parameters["acc"].Value="%%";
                //}
                //else
                //{
                objmysqlcommand.Parameters["acc"].Value = category;
                //}

                objmysqlcommand.Parameters.Add("ascc", MySqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
                objmysqlcommand.Parameters["ascc"].Value = code;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["ascc"].Value="%%";
                //}

                objmysqlcommand.Parameters.Add("ascn", MySqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
                objmysqlcommand.Parameters["ascn"].Value = name;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["ascn"].Value ="%%";
                //}

                objmysqlcommand.Parameters.Add("asca", MySqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
                objmysqlcommand.Parameters["asca"].Value = alias;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["asca"].Value ="%%";
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

  /*      public DataSet ascmfirst(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascmfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                //com.Parameters.Add("userid", MySqlDbType.VarChar);
                //com.Parameters["userid"].Value =UserId;

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

        public DataSet ascmlast(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascmfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =UserId;

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

        public DataSet ascmprevious(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascmfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =UserId;

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

        public DataSet ascmnext(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascmfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =UserId;

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

        public DataSet chkascmcode(string companycode, string UserId, string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ascmcheck_Ascmcheck_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("ascc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascc"].Value = code;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
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
        public DataSet addagencycat(string agencytype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindagencytype_bindagencytype_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencytype"].Value = agencytype;

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

        public DataSet countascmcode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkascmodename_chkascmodename_p", ref objmysqlconnection);
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