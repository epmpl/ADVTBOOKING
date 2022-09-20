using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data ;
using MySql.Data .MySqlClient ;
namespace NewAdbooking.classmysql
{

    /// <summary>
    /// Summary description for region
    /// </summary>
    public class region:connection 
    {
        public region()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet regionmaster_save(string Comp_Code, string Region_Code, string Region_Name, string Region_alias, string UserId, string zone)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("region_save", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = Comp_Code;


                objmysqlcommand.Parameters.Add("Region_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region_Code"].Value = Region_Code;


                objmysqlcommand.Parameters.Add("Region_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region_Name"].Value = Region_Name;


                objmysqlcommand.Parameters.Add("Region_alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region_alias"].Value = Region_alias;



                objmysqlcommand.Parameters.Add("UserId", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["UserId"].Value = UserId;

                objmysqlcommand.Parameters.Add("zone1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone1"].Value = zone;

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





        public DataSet regionmaster_modify(string Comp_Code, string Region_Code, string Region_Name, string Region_alias, string UserId, string zone)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_modifyregion", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = Comp_Code;


                objmysqlcommand.Parameters.Add("Region_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region_Code"].Value = Region_Code;


                objmysqlcommand.Parameters.Add("Region_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region_Name"].Value = Region_Name;


                objmysqlcommand.Parameters.Add("Region_alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region_alias"].Value = Region_alias;

                objmysqlcommand.Parameters.Add("zone1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone1"].Value = zone;

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



        public DataSet chkregion(string compcode, string regioncode, string regionname, string alias, string username,string zone)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_chkregion", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = compcode;


                objmysqlcommand.Parameters.Add("regioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["regioncode"].Value = regioncode;


                objmysqlcommand.Parameters.Add("regionname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["regionname"].Value = regionname;


                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                objmysqlcommand.Parameters.Add("zone1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone1"].Value = zone;

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


        //********************************************************************************************************	

        //*******************************************************************************************************


        public DataSet btndelete(string compcode, string regioncode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("regiondel", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;


                objmysqlcommand.Parameters.Add("regioncode",MySqlDbType.VarChar);
                objmysqlcommand.Parameters["regioncode"].Value = regioncode;

                objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
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


        public DataSet chkregion123(string compcode, string regionname, string regioncode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkregion", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("regionname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["regionname"].Value = regionname;

                objmysqlcommand.Parameters.Add("regioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["regioncode"].Value = regioncode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


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
        public DataSet countregioncode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkregioncodename", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if(str.Length >2)
                {
                objmysqlcommand.Parameters["cod"].Value = str.Substring (0,2);
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
        //******************************************************************************************************
        public DataSet chknameforduplicate(string regioncode, string regionname, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkduplicateregion", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("regioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["regioncode"].Value = regioncode;

                objmysqlcommand.Parameters.Add("regionname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["regionname"].Value = regionname;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

              
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
//******************************************************************************************************
        public DataSet getzone(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindzone", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


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
