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
    /// Summary description for AdCategoryMaster
    /// </summary>
    public class AdCategoryMaster:connection
    {
        public AdCategoryMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet advcatinsert1(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype, string rclient)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advinsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                objmysqlcommand.Parameters.Add("catalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["catalias"].Value = catalias;

                objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["catname"].Value = catname;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("rclient", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rclient"].Value = rclient;


                //objmysqlcommand.Parameters.Add("focusday", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["focusday"].Value =focusday;

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

        public DataSet advcatchk(string compcode, string userid, string adcatcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADVCHK_ADVCHK_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;


              
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



        //Code for the Modify the data into the data base//
        public DataSet advcatupdate1(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype, string regclient)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADVUPDATE_ADVUPDATE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                objmysqlcommand.Parameters.Add("catalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["catalias"].Value = catalias;

                objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["catname"].Value = catname;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("rclient", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rclient"].Value = regclient;


                //objmysqlcommand.Parameters.Add("focusday", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["focusday"].Value =focusday;


        
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

        //Code for the Execute the commande for fetch the data from the data base//
        public DataSet advcatexecute(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype)//, string catediname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADVCATEXEC_ADVCATEXEC_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

             //  objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
             // objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                //if (adcatcode != "" && adcatcode != null)
                //{
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["adcatcode"].Value = "%%";
                //}



                objmysqlcommand.Parameters.Add("catalias", MySqlDbType.VarChar);
                //if (catalias != "" && catalias != null)
                //{
                objmysqlcommand.Parameters["catalias"].Value = catalias;

                //}
                //else
                //{
                //    objmysqlcommand.Parameters["catalias"].Value = "%%";
                //}

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
                //if (catname != "" && catname != null)
                //{
                objmysqlcommand.Parameters["catname"].Value = catname;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["catname"].Value = "%%";
                //}


                //objmysqlcommand.Parameters.Add("catediname", MySqlDbType.VarChar);
                //if (catediname != "0" && catediname != null)
                //{

                //    objmysqlcommand.Parameters["catediname"].Value = catediname;

                //}
                //else
                //{
                //    objmysqlcommand.Parameters["catediname"].Value = "%%";
                //}


                //objmysqlcommand.Parameters.Add("focusday", MySqlDbType.VarChar);
                //if(focusday=="0" )
                //{
                //objmysqlcommand.Parameters["focusday"].Value ="%%";

                //}
                //else
                //{
                //    objmysqlcommand.Parameters["focusday"].Value =focusday;

                //}


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



        //public DataSet advcatexecute12(string compcode,string userid,string adcatcode,string catalias,string catname,string catediname,string focusday)
        public DataSet advcatexecute12(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype)//, string catediname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADVCATEXEC_ADVCATEXEC_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                //if (adcatcode != "" && adcatcode != null)
                //{
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["adcatcode"].Value = "%%";
                //}

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("catalias", MySqlDbType.VarChar);
                //if (catalias != "" && catalias != null)
                //{
                objmysqlcommand.Parameters["catalias"].Value = catalias;

                //}
                //else
                //{
                //    objmysqlcommand.Parameters["catalias"].Value = "%%";
                //}



                objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
                //if (catname != "" && catname != null)
                //{
                objmysqlcommand.Parameters["catname"].Value = catname;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["catname"].Value = "%%";
                //}


                //objmysqlcommand.Parameters.Add("catediname", MySqlDbType.VarChar);
                //if (catediname != "0" && catediname != null)
                //{

                //    objmysqlcommand.Parameters["catediname"].Value = catediname;

                //}
                //else
                //{
                //    objmysqlcommand.Parameters["catediname"].Value = "%%";
                //}


                //objmysqlcommand.Parameters.Add("focusday", MySqlDbType.VarChar);
                //if(focusday!="0"  )
                //{

                //    objmysqlcommand.Parameters["focusday"].Value =focusday;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["focusday"].Value ="%%";
                //}


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





        //Code for the See the first data//
        public DataSet advcatfirst(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advcatfnpl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                //	objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



           
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


        //Code for the See the Last data//
        public DataSet advcatlast(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advcatfnpl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



    
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


        //Code for the See the Previous data//
        public DataSet advcatpre(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advcatfnpl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



          
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

        //Code for the See the Next data//
        public DataSet advcatnext(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advcatfnpl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



        
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

        //Code for the Delete the data from the data base//
        public DataSet advcatdel(string compcode, string adcatcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADVCATDEL_ADVCATDEL_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                //objmysqlcommand.Parameters.Add("hiddenccode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["hiddenccode"].Value = hiddenccode;


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

        //Code for Auto Genereate-Code for the CategoryName// 
        public DataSet countadcatcode(string str, string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHKADCATCODENAME_CHKADCATCODENAME_P", ref objmysqlconnection);
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

                objmysqlcommand.Parameters.Add("COMPANY_CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPANY_CODE"].Value = adtype;

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



        public DataSet ckkusercode(string adcatcode, string catname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHKADCATUSER_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["catname"].Value = catname;

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



        //Code for the save the select day in the data base//
        public DataSet selectaddaysave(string compcode, string adcatcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string allday, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("slelectadcatdaysave_slelectadcatdaysave_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                objmysqlcommand.Parameters.Add("sun", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sun"].Value = sun;

                objmysqlcommand.Parameters.Add("mon", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mon"].Value = mon;

                objmysqlcommand.Parameters.Add("tue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tue"].Value = tue;

                objmysqlcommand.Parameters.Add("wed", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["wed"].Value = wed;

                objmysqlcommand.Parameters.Add("thu", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["thu"].Value = thu;

                objmysqlcommand.Parameters.Add("fri", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fri"].Value = fri;

                objmysqlcommand.Parameters.Add("sat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sat"].Value = sat;

                objmysqlcommand.Parameters.Add("allday", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["allday"].Value = allday;

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

        public DataSet checkadcode(string compcode, string adcatcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHECKADCODE_CHECKADCODE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

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

        //Code for the modify the select day in the data base//
        public DataSet selectaddaymodify(string compcode, string adcatcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("slelectaddaymodify_slelectaddaymodify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                objmysqlcommand.Parameters.Add("sun", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sun"].Value = sun;

                objmysqlcommand.Parameters.Add("mon", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mon"].Value = mon;


                objmysqlcommand.Parameters.Add("tue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tue"].Value = tue;

                objmysqlcommand.Parameters.Add("wed", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["wed"].Value = wed;

                objmysqlcommand.Parameters.Add("thu", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["thu"].Value = thu;


                objmysqlcommand.Parameters.Add("fri", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fri"].Value = fri;

                objmysqlcommand.Parameters.Add("sat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sat"].Value = sat;

                objmysqlcommand.Parameters.Add("all", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["all"].Value = all;

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

        //Enable check boxes on select The Edition Day//
        public DataSet editionday(string drpednname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ENABLEADCATDAY_ENABLEADCATDAY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("editionname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editionname"].Value = drpednname;


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

        //*********************************************************************************//
        //**************************Coding For PoP Up Window*******************************//
        //*********************************************************************************//

        //Bind The Drop Down For Select Edition//
        public DataSet selectedition(string compcode, string userid)//,string edition)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("SELECTEDITIONNAME_SELECTEDITIONNAME_P", ref objmysqlconnection);
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
        //Proceduer  For Submit//
        public DataSet editionsubmit(string compcode, string userid, string adcatcode, string edition, string chk1, string chk2, string chk3, string chk4, string chk5, string chk6, string chk7, string chk8)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EDITIONSUBMIT_EDITIONSUBMIT_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = edition;

                objmysqlcommand.Parameters.Add("sun", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sun"].Value = chk1;

                objmysqlcommand.Parameters.Add("mon", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mon"].Value = chk2;

                objmysqlcommand.Parameters.Add("tue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tue"].Value = chk3;

                objmysqlcommand.Parameters.Add("wed", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["wed"].Value = chk4;

                objmysqlcommand.Parameters.Add("thu", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["thu"].Value = chk5;

                objmysqlcommand.Parameters.Add("fri", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fri"].Value = chk6;

                objmysqlcommand.Parameters.Add("sat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sat"].Value = chk7;

                objmysqlcommand.Parameters.Add("allday", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["allday"].Value = chk8;

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

        //Bind The Data Grid //
        public DataSet editionbindgrid(string compcode, string userid)//, string edition)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EDITIONDATABIND_EDITIONDATABIND_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["edition"].Value = edition;

                ////objmysqlcommand.Parameters.Add("values", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["values"].Value = values;

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



        //Procedure For check The Edition code //
        public DataSet editionchk(string compcode, string userid, string edition)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EDITIONCHK_EDITIONCHK_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        //Procedure For Modify//
        public DataSet editionmodify(string compcode, string userid, string adcatcode, string edition, string chk1, string chk2, string chk3, string chk4, string chk5, string chk6, string chk7, string chk8, string hiddenccode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EDITIONMODIFY_EDITIONMODIFY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = edition;

                objmysqlcommand.Parameters.Add("sun1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sun1"].Value = chk1;

                objmysqlcommand.Parameters.Add("mon1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mon1"].Value = chk2;

                objmysqlcommand.Parameters.Add("tue1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tue1"].Value = chk3;

                objmysqlcommand.Parameters.Add("wed1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["wed1"].Value = chk4;

                objmysqlcommand.Parameters.Add("thu1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["thu1"].Value = chk5;

                objmysqlcommand.Parameters.Add("fri1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fri1"].Value = chk6;

                objmysqlcommand.Parameters.Add("sat1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sat1"].Value = chk7;

                objmysqlcommand.Parameters.Add("allday1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["allday1"].Value = chk8;

                objmysqlcommand.Parameters.Add("hiddenccode", MySqlDbType.Int24);
                if (hiddenccode == "" || hiddenccode == null)
                    objmysqlcommand.Parameters["hiddenccode"].Value = System.DBNull.Value;
                else
                    objmysqlcommand.Parameters["hiddenccode"].Value = hiddenccode;

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

        //  Procedure For Delete//

        public DataSet editiondelete(string compcode, string userid, string edition, string hiddenccode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EDITIONDEL_EDITIONDEL_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("hiddenccode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hiddenccode"].Value = hiddenccode;


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
        //My//
        ////Procedure for the select the Row From the Data Grid//
        public DataSet seledition(string adcatcode, string userid, string compcode, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EDITIONDAYSEL_EDITIONDAYSEL_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;

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


        //public DataSet selectpublication()
        //{
        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("selectadcategory", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objmysqlconnection);
        //    }
        //}

        public DataSet adname(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADV_BINDCATEGORY_ADV_BINDCATEGORY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;


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


        public DataSet catwiesedition(string adcatcode, string userid, string compcode)//, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CATWIESEDITION_CATWIESEDITION_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = adcatcode;

                //objmysqlcommand.Parameters.Add("date", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["date"].Value = dateformat;


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



        public DataSet chkedit(string edition, string adcatcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHKCATEGORYEDITION_CHKCATEGORYEDITION_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;
              
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


        public DataSet editionchk_b(string compcode, string adcatcode, string edition)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EDITIONCHK_B_EDITIONCHK_B_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adcatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcatcode"].Value = adcatcode;

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



    }
}