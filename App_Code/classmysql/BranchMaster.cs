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
    /// Summary description for BranchMaster
    /// </summary>
    public class BranchMaster:connection
    {
        public BranchMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet chkdel(string compcode, string branchcode, string branchname, string alias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHECKBRANCHEXIST", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("branchname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchname"].Value = branchname;

                objmysqlcommand.Parameters.Add("branchalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchalias"].Value = alias;

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
        public DataSet branchnamechk(string str)//, string city)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkbranchname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;


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
        public DataSet pubcodechk(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkpubcatcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;


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
        public DataSet addcity()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("clientfillcity", ref objmysqlconnection);
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



        public DataSet addregion(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("regionbind", ref objmysqlconnection);
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


        public DataSet addzone(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("zonebind", ref objmysqlconnection);
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
        public DataSet addcountry(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adcountryname", ref objmysqlconnection);
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






        public DataSet addpickdistname(string citycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillstaedistcountry", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["citycode"].Value = citycode;

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


        public DataSet branchchk(string compcode, string userid, string branchcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHCHK_branchchk_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                //objmysqlcommand.Parameters.Add("branchname", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["branchname"].Value =branchname;

                //objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["alias"].Value =alias;

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


        public DataSet branchchkcode(string str, string pubcent)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHCHKCODENAME_branchchkcodename_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

               
                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0,2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }
                objmysqlcommand.Parameters.Add("pubcent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcent"].Value = pubcent;

                

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


        public DataSet branchinsert(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHINSERT_branchinsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("branchname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchname"].Value = branchname;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                objmysqlcommand.Parameters.Add("address", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address"].Value = address;

                objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["street"].Value = street;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dist"].Value = dist;

                objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["state"].Value = state;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax"].Value = fax;

                objmysqlcommand.Parameters.Add("pin", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pin"].Value = pin;

                objmysqlcommand.Parameters.Add("phone1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone1"].Value = phone1;

                objmysqlcommand.Parameters.Add("phone2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone2"].Value = phone2;

                objmysqlcommand.Parameters.Add("email", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["email"].Value = email;

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone"].Value = zone;

                objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region"].Value = region;

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

        public DataSet branchupdate(string compcode, string userid, string branchcode, string branchname, string alias, string address, string street, string city, string dist, string state, string country, string fax, string pin, string phone1, string phone2, string email, string zone, string region, string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHUPDATE_branchupdate_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("branchname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchname"].Value = branchname;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                objmysqlcommand.Parameters.Add("address", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address"].Value = address;

                objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["street"].Value = street;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dist"].Value = dist;

                objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["state"].Value = state;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax"].Value = fax;

                objmysqlcommand.Parameters.Add("pin", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pin"].Value = pin;

                objmysqlcommand.Parameters.Add("phone1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone1"].Value = phone1;

                objmysqlcommand.Parameters.Add("phone2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone2"].Value = phone2;

                objmysqlcommand.Parameters.Add("email", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["email"].Value = email;

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone"].Value = zone;

                objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region"].Value = region;

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

        public DataSet branchexe(string compcode, string userid, string branchcode, string branchname, string alias, string country, string city, string pubcenter, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHEXE_branchexe_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("branchname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchname"].Value = branchname;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;


                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;

                
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

        public DataSet branchfnpl(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHFNPL_branchfnpl_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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



        public DataSet branchdel(string compcode, string userid, string branchcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHDEL_branchdel_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

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


        public DataSet contactbind(string branchcode, string userid, string compcode, string dateformat)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHBIND_branchbind_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date1"].Value = dateformat;

               
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


        //**************************To check Contact Person***************************

        public DataSet chksubmitcontact1(string contactperson, string branchcode)
        {
            //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHHCKCONTPER_branchhckcontper_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;


                objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contactperson"].Value = contactperson;



               
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
        //*******************************************************************************************

        //**************************To check Contact Person at time of update***************************

        public DataSet chksubmitcontactupdate(string contactperson, string branchcode)
        {
            //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHHCKCONTPERUPDATE_branchhckcontperupdate_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;


                objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contactperson"].Value = contactperson;



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

        public DataSet contactupdate(string contactperson, string dob, string designation, string phone, string ext, string fax, string mail, string compcode, string userid, string branchcode, string update)
        {
            //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHCONTUP_branchcontup_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contactperson"].Value = contactperson;

                objmysqlcommand.Parameters.Add("designation", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["designation"].Value = designation;

                objmysqlcommand.Parameters.Add("dob", MySqlDbType.DateTime);
                if (dob != "" && dob != null)
                {
                    objmysqlcommand.Parameters["dob"].Value = Convert.ToDateTime(dob);
                }
                else
                {
                    objmysqlcommand.Parameters["dob"].Value = System.DBNull.Value;
                }

                objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone"].Value = phone;

                objmysqlcommand.Parameters.Add("ext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ext"].Value = ext;

                objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax"].Value = fax;

                objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mail"].Value = mail;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("update1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["update1"].Value = update;

             
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

        public DataSet insertcontact(string contact, string designation, string dob, string phone, string ext, string fax, string mail, string userid, string branchcode, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHCONTIN_branchcontin_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("contact", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contact"].Value = contact;

                objmysqlcommand.Parameters.Add("designation", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["designation"].Value = designation;

                objmysqlcommand.Parameters.Add("dob", MySqlDbType.DateTime);

                if (dob != null && dob != "")
                {
                    objmysqlcommand.Parameters["dob"].Value = Convert.ToDateTime(dob);
                }
                else
                {
                    objmysqlcommand.Parameters["dob"].Value = System.DBNull.Value;
                }

                objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone"].Value = phone;

                objmysqlcommand.Parameters.Add("ext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ext"].Value = ext;

                objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax"].Value = fax;

                objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mail"].Value = mail;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


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


        public DataSet contactbind12(string branchcode, string compcode, string userid, string hiddencccode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHSELECT_branchselect_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("hiddencccode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hiddencccode"].Value = hiddencccode;

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


        public DataSet contactdelete(string branchcode, string compcode, string userid, string update)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BRANCHCONTDEL_branchcontdel_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("update1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["update1"].Value = update;

            
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