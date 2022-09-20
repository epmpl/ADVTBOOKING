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

/// <summary>
/// Summary description for pop
/// </summary>
namespace NewAdbooking.classmysql
{
    /// <summary>
    /// Summary description for pop.
    /// </summary>
    public class pop : connection
    {
        public pop()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet filldatapay(string hiddencomcode, string hiddenuserid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("retainer_payfill", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = hiddenuserid;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = hiddencomcode;



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

        public DataSet showchk(string compcode, string userid, string retcode, string agencysubcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("showagencypay", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retcode"].Value = retcode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

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

        public DataSet addstatusname(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bind_status_bind_status_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet CheckClientPopup(string compcode, string custcode,string custname, string userid, int flag)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CheckClientpopup_CheckClientpopup_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;
               objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["custcode"].Value = custcode;
               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;
               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;
               objmysqlcommand.Parameters.Add("flag1", MySqlDbType.Int32);
               objmysqlcommand.Parameters["flag1"].Value = flag;
               objmysqlcommand.Parameters.Add("custname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["custname"].Value = custname;
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

        //------------------------------------------------Pankaj Change----------------------
        public DataSet insertcontact(string contact, string designation, string role, string dob, string phone, string ext, string fax, string mail, string userid, string agencycode, string agencysubcode, string compcode, string id, string dateformat,string mobile)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_contactdetails", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agentcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("contact", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contact"].Value = contact;

                objmysqlcommand.Parameters.Add("designation", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["designation"].Value = designation;
                //----------------------------
                objmysqlcommand.Parameters.Add("role1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["role1"].Value = role;
                //-------------------------------
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
                //if (Comment =="" || Comment==null)
                objmysqlcommand.Parameters["phone"].Value = phone;
                //else

                objmysqlcommand.Parameters.Add("ext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ext"].Value = ext;

                objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax"].Value = fax;

                objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mail"].Value = mail;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("product", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["product"].Value = id;

                objmysqlcommand.Parameters.Add("mobile", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mobile"].Value = mobile;
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
        //		**********************************Code**************************************

        public DataSet rolename(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("rolename_rolename_p", ref objmysqlconnection);
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

        //		*********************************End****************************************

        //

        public DataSet contactbind(string agentcode, string userid, string compcode, string dateformat,string nagencycode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_contactbind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("gentcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gentcode"].Value = agentcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("dateformat1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat1"].Value = dateformat;

                objmysqlcommand.Parameters.Add("nagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["nagencycode"].Value = nagencycode;

            
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


        public DataSet contactbind12(string agentcode, string userid, string compcode, string hiddencccode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_contactbind12", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agentcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcode"].Value = agentcode;

                objmysqlcommand.Parameters.Add("hiddencccode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hiddencccode"].Value = hiddencccode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["compcode"].Value =compcode;

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


        public DataSet getpro(string code)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getpro", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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



        public DataSet getproinsert(string newboxvalue, string comp, string userid, string clientcode, string newprodname, string contactperson,string agencycode,string agencysubcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getproinsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("newboxvalue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["newboxvalue"].Value = newboxvalue;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("comp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp"].Value = comp;

                objmysqlcommand.Parameters.Add("newprodname", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["newprodname"].Value = newprodname;

                objmysqlcommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcode"].Value = clientcode;
                
                objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contactperson"].Value = contactperson;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                
              
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


        public DataSet bindes(string contactperson,string comp,string userid,string agencycode,string agencysubcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindproclicont", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                
                
                objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contactperson"].Value = contactperson;

                objmysqlcommand.Parameters.Add("comp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp"].Value = comp;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;


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



        public DataSet getproname(string aftersplit)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getproname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("aftersplit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["aftersplit"].Value = aftersplit;


                
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


       

        //--------------------------*********************************************


        public DataSet contactupdate(string contactperson, string dob, string designation, string phone, string ext, string fax, string mail, string compcode, string userid, string agencode, string agencysubcode, string update, string role,string id,string mobile)
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
                objmysqlcommand = GetCommand("websp_contactupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contactperson"].Value = contactperson;

                objmysqlcommand.Parameters.Add("designation1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["designation1"].Value = designation;
                //--------------------------------------
                objmysqlcommand.Parameters.Add("role1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["role1"].Value = role;
                //-----------------------------------------
                objmysqlcommand.Parameters.Add("dob1", MySqlDbType.DateTime);
                if (dob != "" && dob != null)
                {
                    objmysqlcommand.Parameters["dob1"].Value = Convert.ToDateTime(dob);
                }
                else
                {
                    objmysqlcommand.Parameters["dob1"].Value = System.DBNull.Value;
                }

                objmysqlcommand.Parameters.Add("phone1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone1"].Value = phone;

                objmysqlcommand.Parameters.Add("ext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ext"].Value = ext;

                objmysqlcommand.Parameters.Add("fax1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax1"].Value = fax;

                objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mail"].Value = mail;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //				objmysqlcommand.Parameters.Add("contcode", MySqlDbType.Int);
                //				objmysqlcommand.Parameters["contcode"].Value =code;


                objmysqlcommand.Parameters.Add("contcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contcode"].Value = update;

                objmysqlcommand.Parameters.Add("product1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["product1"].Value = id;

                objmysqlcommand.Parameters.Add("mobile", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mobile"].Value = phone;


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

        //		public DataSet contactdelete(string contactperson,string dob,string designation,string phone,string ext,string fax,string mail,string code,string compcode,string userid,string agencode,string agencysubcode)
        //			//contactperson,designation,dob,phone,,fax,mail,Session["userid"].ToString(),hidden
        //		{
        //			
        //			SqlConnection objmysqlconnection;
        //			SqlCommand objmysqlcommand;
        //			objmysqlconnection = GetConnection();
        //			SqlDataAdapter objmysqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objmysqlconnection.Open();
        //				objmysqlcommand = GetCommand("websp_contactdelete", ref objmysqlconnection);
        //				objmysqlcommand.CommandType = CommandType.StoredProcedure;
        // 
        //				objmysqlcommand.Parameters.Add("agentcode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["agentcode"].Value =agencode;
        //
        //				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["userid"].Value =userid;
        //
        //				objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["contactperson"].Value =contactperson;
        //
        //				objmysqlcommand.Parameters.Add("designation", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["designation"].Value =designation;
        //
        //				objmysqlcommand.Parameters.Add("dob", MySqlDbType.DateTime);
        //				objmysqlcommand.Parameters["dob"].Value =Convert.ToDateTime(dob);
        //
        //				objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["phone"].Value =phone;
        //
        //				objmysqlcommand.Parameters.Add("ext", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["ext"].Value =ext;
        //
        //				objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["fax"].Value =fax;
        //
        //				objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["mail"].Value =mail;
        //
        //				objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["code"].Value =code;
        //
        //				//				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //				//				objmysqlcommand.Parameters["compcode"].Value =compcode;
        //

        //				objmysqlDataAdapter =new SqlDataAdapter();
        //				objmysqlDataAdapter.SelectCommand =objmysqlcommand;
        //				objmysqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //
        //
        //			}
        //			catch(MySqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objmysqlconnection);
        //			}
        //		
        //		}


        public DataSet contactdelete(string compcode, string userid, string agencode, string agencysubcode, string update)
        //contactperson,designation,dob,phone,,fax,mail,Session["userid"].ToString(),hidden
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_contactdelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("agentcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcode"].Value = agencode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("contcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contcode"].Value = update;

                //				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["compcode"].Value =compcode;


             
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

        public DataSet commission()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_comm_detail", ref objmysqlconnection);
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

        public DataSet insertcomm(string effectivedate, string efeectivetill, string commrate, string commapply, string compcode, string userid, string agencode, string agencysubcode, string dateformat, string adtype, string adcomm, string uom1, string agen, string cash_disc, string cash_amt, string adcat)
        //effectivedate,efeectivetill,commrate,commapply,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_insertcomm", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("effectivedate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["effectivedate"].Value = Convert.ToDateTime(effectivedate);

                objmysqlcommand.Parameters.Add("efeectivetill", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["efeectivetill"].Value = Convert.ToDateTime(efeectivetill);

                objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commrate"].Value = commrate;

                //				objmysqlcommand.Parameters.Add("dob", MySqlDbType.DateTime);
                //				objmysqlcommand.Parameters["dob"].Value =Convert.ToDateTime(dob);

                objmysqlcommand.Parameters.Add("commapply", MySqlDbType.VarChar);
                //if (Comment =="" || Comment==null)
                objmysqlcommand.Parameters["commapply"].Value = commapply;
                //else

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

              

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = adtype;

                objmysqlcommand.Parameters.Add("addcomm", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["addcomm"].Value = adcomm;

                objmysqlcommand.Parameters.Add("uom1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom1"].Value = uom1;

                objmysqlcommand.Parameters.Add("agen", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agen"].Value = agen; 

                
                objmysqlcommand.Parameters.Add("cash_disc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cash_disc"].Value = cash_disc;


                objmysqlcommand.Parameters.Add("cash_amt", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cash_amt"].Value = cash_amt;

                objmysqlcommand.Parameters.Add("adcat11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcat11"].Value = adcat;
                //
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

        //       ***************************My Code*******************************

        public DataSet selectname(string compcode, string userid)//,string agencode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_selectname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //				objmysqlcommand.Parameters.Add("effectivedate", MySqlDbType.DateTime);
                //				objmysqlcommand.Parameters["effectivedate"].Value =Convert.ToDateTime(effectivedate);
                //
                //				objmysqlcommand.Parameters.Add("efeectivetill", MySqlDbType.DateTime);
                //				objmysqlcommand.Parameters["efeectivetill"].Value =Convert.ToDateTime(efeectivetill);
                //
                //				objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["commrate"].Value =commrate;
                //
                //				objmysqlcommand.Parameters.Add("commapply",MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["commapply"].Value=commapply;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //				objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["agencode"].Value =agencode;


               
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




        //       ******************************************************************






        public DataSet commbind(string agencode, string compcode, string userid, string dateformat,string newagecode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("commbind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;



                 objmysqlcommand.Parameters.Add("newagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["newagecode"].Value = newagecode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;


              
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

        public DataSet commcheckdate(string agencode, string compcode, string userid, string fromdatecomm, string tilldate, string agencysubcode,string adtype,string uom11)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkdatecomm", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("fromdatecomm", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["fromdatecomm"].Value = fromdatecomm;// Convert.ToDateTime(fromdatecomm);

                objmysqlcommand.Parameters.Add("tilldate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["tilldate"].Value = tilldate;// Convert.ToDateTime(tilldate);


                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("uom11", MySqlDbType.VarChar);
                if (uom11 == "" || uom11 == "0")
                    objmysqlcommand.Parameters["uom11"].Value = System.DBNull.Value;
                else
                    objmysqlcommand.Parameters["uom11"].Value = uom11;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = adtype;

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

        public DataSet commcheckdate12(string agencode, string compcode, string userid, string fromdatecomm, string tilldate, string hiddenccode, string subagencycode, string drpcommdetail, string adtype,string uom)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkdatecomm12", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("drpcommdetail", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["drpcommdetail"].Value = drpcommdetail;

                 objmysqlcommand.Parameters.Add("hiddenccode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hiddenccode"].Value = hiddenccode;



                objmysqlcommand.Parameters.Add("fromdatecomm", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["fromdatecomm"].Value = Convert.ToDateTime(fromdatecomm);

                objmysqlcommand.Parameters.Add("tilldate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["tilldate"].Value = Convert.ToDateTime(tilldate);

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = adtype;

                objmysqlcommand.Parameters.Add("uom1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom1"].Value = uom;

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

        public DataSet commbind123(string agencode, string compcode, string userid, string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("commbind12", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = code;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                
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


        public DataSet insertbank(string bgno, string bgdate, string amount, string bank, string validitydate, string compcode, string userid, string agencode, string agencysubcode, string dateformat, string attach)
        //bgno,bgdate,amount,bank,validitydate,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_insertbank", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("bgno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgno"].Value = bgno;

                objmysqlcommand.Parameters.Add("bgdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["bgdate"].Value = Convert.ToDateTime(bgdate);

                objmysqlcommand.Parameters.Add("amount", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["amount"].Value = amount;

                objmysqlcommand.Parameters.Add("bank", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bank"].Value = bank;

                objmysqlcommand.Parameters.Add("validitydate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["validitydate"].Value = Convert.ToDateTime(validitydate);

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

             
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


        public DataSet bankbind(string agencode, string compcode, string userid, string date,string nagencycode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_bankbind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("nagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["nagencycode"].Value = nagencycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date1"].Value = date;

                
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


        public DataSet bankbind12(string agencode, string compcode, string userid, string code)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_bankbind12", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

               
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



        public DataSet updatebank(string bgno, string bankdate, string amount, string bank, string validitydate, string compcode, string userid, string agencode, string agencysubcode, string code)
        //bgno,bankdate,amount,bank,validitydate,Session[""].ToString(),Session[""].ToString(),agencode,agencysubcode
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_updatebank", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("bgno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgno"].Value = bgno;

                objmysqlcommand.Parameters.Add("bankdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["bankdate"].Value = Convert.ToDateTime(bankdate);

                objmysqlcommand.Parameters.Add("amount", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["amount"].Value = amount;

                objmysqlcommand.Parameters.Add("bank", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bank"].Value = bank;

                objmysqlcommand.Parameters.Add("validitydate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["validitydate"].Value = Convert.ToDateTime(validitydate);

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

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

        //		public DataSet deletebank(string bgno,string bankdate, string amount,string bank,string validitydate,string compcode,string userid,string agencode,string agencysubcode,string code)
        //			//bgno,bankdate,amount,bank,validitydate,Session[""].ToString(),Session[""].ToString(),agencode,agencysubcode
        //			
        //		{
        //			
        //			SqlConnection objmysqlconnection;
        //			SqlCommand objmysqlcommand;
        //			objmysqlconnection = GetConnection();
        //			SqlDataAdapter objmysqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objmysqlconnection.Open();
        //				objmysqlcommand = GetCommand("websp_deletebank", ref objmysqlconnection);
        //				objmysqlcommand.CommandType = CommandType.StoredProcedure;
        // 
        //				objmysqlcommand.Parameters.Add("bgno", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["bgno"].Value =bgno;
        //
        //				objmysqlcommand.Parameters.Add("bankdate", MySqlDbType.DateTime);
        //				objmysqlcommand.Parameters["bankdate"].Value =Convert.ToDateTime(bankdate);
        //
        //				objmysqlcommand.Parameters.Add("amount", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["amount"].Value =amount;
        //
        //				objmysqlcommand.Parameters.Add("bank", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["bank"].Value =bank;
        //
        //				objmysqlcommand.Parameters.Add("validitydate", MySqlDbType.DateTime);
        //				objmysqlcommand.Parameters["validitydate"].Value =Convert.ToDateTime(validitydate);
        //
        //				objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["agencysubcode"].Value =agencysubcode;

        //				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["compcode"].Value =compcode;
        //
        //				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["userid"].Value =userid;
        //
        //				objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["agencode"].Value =agencode;
        //
        //				objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["code"].Value =code;
        //
        //				objmysqlDataAdapter =new SqlDataAdapter();
        //				objmysqlDataAdapter.SelectCommand =objmysqlcommand;
        //				objmysqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //
        //
        //			}
        //			catch(MySqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objmysqlconnection);
        //			}
        //		
        //		}


        public DataSet deletebank(string compcode, string userid, string agencode, string agencysubcode, string code)
        //bgno,bankdate,amount,bank,validitydate,Session[""].ToString(),Session[""].ToString(),agencode,agencysubcode
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_deletebank", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

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





        public DataSet commupdate(string effectivefrm, string efftill, string commrate, string commapplied, string code, string compcode, string userid, string agencode, string adtype, string addcommrate, string uom, string agen,string cash_disc,string cash_amt)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_commupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("effectivefrm", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["effectivefrm"].Value = Convert.ToDateTime(effectivefrm).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("efftill", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["efftill"].Value = Convert.ToDateTime(efftill).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commrate"].Value = commrate;

                objmysqlcommand.Parameters.Add("commapplied", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commapplied"].Value = commapplied;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                //				objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["agencysubcode"].Value =agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = adtype;

                objmysqlcommand.Parameters.Add("addcommrate", MySqlDbType.VarChar);
                if (addcommrate == "")
                    objmysqlcommand.Parameters["addcommrate"].Value = "0";
                else
                    objmysqlcommand.Parameters["addcommrate"].Value = addcommrate;

                objmysqlcommand.Parameters.Add("uom1", MySqlDbType.VarChar);
                if (uom == "" || uom == "0")
                    objmysqlcommand.Parameters["uom1"].Value = System.DBNull.Value;
                else
                    objmysqlcommand.Parameters["uom1"].Value = uom;

                objmysqlcommand.Parameters.Add("agen", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agen"].Value = agen; 

                objmysqlcommand.Parameters.Add("cash_disc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cash_disc"].Value = cash_disc;

                objmysqlcommand.Parameters.Add("cash_amt", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cash_amt"].Value = cash_amt;

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

        //		public DataSet commdelete(string effectivefrm,string efftill, string commrate,string commapplied,string code,string compcode,string userid,string agencode,string agencysubcode)
        //			//effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        //			
        //		{
        //			
        //			SqlConnection objmysqlconnection;
        //			SqlCommand objmysqlcommand;
        //			objmysqlconnection = GetConnection();
        //			SqlDataAdapter objmysqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objmysqlconnection.Open();
        //				objmysqlcommand = GetCommand("websp_commdelete", ref objmysqlconnection);
        //				objmysqlcommand.CommandType = CommandType.StoredProcedure;
        // 
        //				
        //
        //				objmysqlcommand.Parameters.Add("effectivefrm", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["effectivefrm"].Value =Convert.ToDateTime(effectivefrm);
        //
        //				objmysqlcommand.Parameters.Add("efftill", MySqlDbType.DateTime);
        //				objmysqlcommand.Parameters["efftill"].Value =Convert.ToDateTime(efftill);
        //
        //				objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["commrate"].Value =commrate;
        //
        //
        //				objmysqlcommand.Parameters.Add("commapplied", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["commapplied"].Value =commapplied;
        //
        //				objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["code"].Value =code;
        //
        //				objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["agencysubcode"].Value =agencysubcode;

        //				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["compcode"].Value =compcode;
        //
        //				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["userid"].Value =userid;
        //
        //				objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["agencode"].Value =agencode;

        //				objmysqlDataAdapter =new SqlDataAdapter();
        //				objmysqlDataAdapter.SelectCommand =objmysqlcommand;
        //				objmysqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //
        //
        //			}
        //			catch(MySqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objmysqlconnection);
        //			}
        //		
        //		}


        public DataSet commdelete(string code, string compcode, string userid, string agencode, string agencysubcode)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_commdelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

               
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

        //public DataSet statusbind12(string agencode, string compcode, string userid, string date,string nagencycode)
        //{

        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("websp_statusbind12", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["compcode"].Value = compcode;

        //        objmysqlcommand.Parameters.Add("nagencycode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["nagencycode"].Value = nagencycode;


        //        objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["userid"].Value = userid;

        //        objmysqlcommand.Parameters.Add("date", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["date"].Value = date;


        //        objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["agencode"].Value = agencode;

        //        objmysqlDataAdapter = new SqlDataAdapter();
        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }

        //    catch (MySqlException objException)
        //    {
        //        throw (objException);
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


        public DataSet statusbind12(string agencode, string compcode, string userid, string date, string nagencycode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_statusbind12_websp_statusbind12_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("nagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["nagencycode"].Value = nagencycode;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date1"].Value = date;


                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                
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

        public DataSet statusbind(string agencode, string compcode, string userid, string hiddenccode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_statusbind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("hiddenccode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hiddenccode"].Value = hiddenccode;

               
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


        public DataSet insertstatus(string status, string fromdate, string todate, string circular, string compcode, string userid, string agencode, string agencysubcode, string remarks, string dateformat, string attachment)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_insertstatus", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate);

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate);

                objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circular"].Value = circular;


                objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status"].Value = status;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;

                objmysqlcommand.Parameters.Add("attach", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["attach"].Value = attachment;

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

        //		public DataSet statusupdate(string todate,string frmdate, string status,string code,string compcode,string userid,string agencode,string agencysubcode)
        //			//status,frmdate,todate,code, compcode,userid,agencode,agencysubcode
        //			
        //		{
        //			
        //			SqlConnection objmysqlconnection;
        //			SqlCommand objmysqlcommand;
        //			objmysqlconnection = GetConnection();
        //			SqlDataAdapter objmysqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objmysqlconnection.Open();
        //				objmysqlcommand = GetCommand("websp_statusupdate", ref objmysqlconnection);
        //				objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //				objmysqlcommand.Parameters.Add("frmdate", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["frmdate"].Value =Convert.ToDateTime(frmdate);
        //
        //				objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
        //				objmysqlcommand.Parameters["todate"].Value =Convert.ToDateTime(todate);
        //
        //				objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["status"].Value =status;
        //
        //				objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["code"].Value =code;
        //
        //				objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["agencysubcode"].Value =agencysubcode;
        //
        //				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["compcode"].Value =compcode;
        //
        //				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["userid"].Value =userid;
        //
        //				objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["agencode"].Value =agencode;
        //
        //				objmysqlDataAdapter =new SqlDataAdapter();
        //				objmysqlDataAdapter.SelectCommand =objmysqlcommand;
        //				objmysqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //
        //
        //			}
        //			catch(MySqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objmysqlconnection);
        //			}
        //		
        //		}

        public DataSet statusupdate(string status, string frmdate, string todate, string circular, string agencode, string compcode, string userid, string agencysubcode, string code, string remarks)

            //status,frmdate,todate,code, compcode,userid,agencode,agencysubcode
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_statusupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("frmdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frmdate"].Value = Convert.ToDateTime(frmdate);

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate);

                objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status"].Value = status;

                objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circular"].Value = circular;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;


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

        public DataSet statusdelete(string compcode, string userid, string agencode, string agencysubcode, string hiddenccode)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_statusdelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("hiddenccode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hiddenccode"].Value = hiddenccode;

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
        public DataSet paybind()
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_paybind", ref objmysqlconnection);
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

        /*public DataSet insertpay(string cash, string credit, string bank, string compcode, string userid, string agencode, string agencysubcode)
        //CheckBox1.Text.ToString(),CheckBox2.Text.ToString(),CheckBox2.Text.ToString(),Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {

            SqlConnection objmysqlconnection;
            SqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            SqlDataAdapter objmysqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_insertpay", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("cash", MySqlDbType.VarChar);

                if (cash == null || cash == "")
                {
                    objmysqlcommand.Parameters["cash"].Value = System.DBNull.Value;

                }
                else
                {
                    objmysqlcommand.Parameters["cash"].Value = cash;
                }

                objmysqlcommand.Parameters.Add("credit", MySqlDbType.VarChar);

                if (credit == null || credit == "")
                {
                    objmysqlcommand.Parameters["credit"].Value = System.DBNull.Value;
                }
                else
                {

                    objmysqlcommand.Parameters["credit"].Value = credit;
                }

                objmysqlcommand.Parameters.Add("bank", MySqlDbType.VarChar);

                if (bank == null || bank == "")
                {
                    objmysqlcommand.Parameters["bank"].Value = System.DBNull.Value;

                }
                else
                {

                    objmysqlcommand.Parameters["bank"].Value = bank;
                }

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlDataAdapter = new SqlDataAdapter();
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

        }*/

        public DataSet payselect(string agencode, string userid, string compcode,string subagencycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("payselect", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;


               
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

        /* public DataSet payinsert(string cash, string credit, string bank, string compcode, string userid, string agencode, string agencysubcode)
         {
             SqlConnection objmysqlconnection;
             SqlCommand objmysqlcommand;
             objmysqlconnection = GetConnection();
             SqlDataAdapter objmysqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                 objmysqlconnection.Open();

                 //string query="update pay_mode_mst set cash='"+cash+"',credit='"+credit+"',bank='"+bank+"' where agency_code='"+agencode+"' and userid='"+userid+"' and comp_code='"+compcode+"' and  agency_subcat_code='"+agencysubcode+"' ";
                 string query = "update pay_mode_mst set cash='" + cash + "',credit='" + credit + "',bank='" + bank + "' where agency_code='" + agencode + "' and userid='" + userid + "' and comp_code='" + compcode + "'";
                 objmysqlcommand = new SqlCommand(query, objmysqlconnection);
                 objmysqlcommand.ExecuteNonQuery();


                 //objmysqlcommand = GetCommand("websp_payinsert", ref objmysqlconnection);
                 //				objmysqlcommand.CommandType = CommandType.StoredProcedure;

                 //				objmysqlcommand.Parameters.Add("cash", MySqlDbType.VarChar);
                 //				objmysqlcommand.Parameters["cash"].Value =cash;
                 //
                 ////				objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                 ////				objmysqlcommand.Parameters["code"].Value =code;
                 //
                 //				objmysqlcommand.Parameters.Add("credit", MySqlDbType.VarChar);
                 //				objmysqlcommand.Parameters["credit"].Value =credit;
                 //
                 //				objmysqlcommand.Parameters.Add("bank", MySqlDbType.VarChar);
                 //				objmysqlcommand.Parameters["bank"].Value =bank;

                 ////				if(cash == null || cash == "")
                 ////				{
                 ////					objmysqlcommand.Parameters["cash"].Value =System.DBNull.Value;
                 ////
                 ////				}
                 ////				else
                 ////				{
                 ////					objmysqlcommand.Parameters["cash"].Value =cash;
                 ////				}
                 ////
                 ////				objmysqlcommand.Parameters.Add("credit", MySqlDbType.VarChar);
                 ////
                 ////				if(credit == null || credit == "")
                 ////				{
                 ////					objmysqlcommand.Parameters["credit"].Value =System.DBNull.Value;
                 ////				}
                 ////				else
                 ////				{
                 ////
                 ////					objmysqlcommand.Parameters["credit"].Value =credit;
                 ////				}
                 //			
                 ////				objmysqlcommand.Parameters.Add("bank", MySqlDbType.VarChar);
                 ////
                 ////				if(bank == null || bank == "")
                 ////				{
                 ////					objmysqlcommand.Parameters["bank"].Value =System.DBNull.Value;
                 ////
                 ////				}
                 ////				else
                 ////				{
                 ////
                 ////					objmysqlcommand.Parameters["bank"].Value =bank;
                 ////				}

                 //				objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                 //				objmysqlcommand.Parameters["agencysubcode"].Value =agencysubcode;
                 //
                 //	     		objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                 //				objmysqlcommand.Parameters["compcode"].Value =compcode;
                 //
                 //				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                 //				objmysqlcommand.Parameters["userid"].Value =userid;
                 //
                 //				objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                 //				objmysqlcommand.Parameters["agencode"].Value =agencode;

                 objmysqlDataAdapter = new SqlDataAdapter();
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

         }*/

        public DataSet paydelete(string cash, string credit, string bank, string code, string compcode, string userid, string agencode, string agencysubcode)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_paydelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //				objmysqlcommand.Parameters.Add("cash", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["cash"].Value =cash;
                //
                //				objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["code"].Value =code;
                //
                //				objmysqlcommand.Parameters.Add("credit", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["credit"].Value =credit;
                //
                //				objmysqlcommand.Parameters.Add("bank", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["bank"].Value =bank;


                if (cash == null || cash == "")
                {
                    objmysqlcommand.Parameters["cash"].Value = System.DBNull.Value;

                }
                else
                {
                    objmysqlcommand.Parameters["cash"].Value = cash;
                }

                objmysqlcommand.Parameters.Add("credit", MySqlDbType.VarChar);

                if (credit == null || credit == "")
                {
                    objmysqlcommand.Parameters["credit"].Value = System.DBNull.Value;
                }
                else
                {

                    objmysqlcommand.Parameters["credit"].Value = credit;
                }

                objmysqlcommand.Parameters.Add("bank", MySqlDbType.VarChar);

                if (bank == null || bank == "")
                {
                    objmysqlcommand.Parameters["bank"].Value = System.DBNull.Value;

                }
                else
                {

                    objmysqlcommand.Parameters["bank"].Value = bank;
                }

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                
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

        public DataSet paycheck(string code, string compcode, string userid, string agencycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_paycheck", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

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

        public DataSet status(string code, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_statuscheck", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

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


        public DataSet contactcheck(string code, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_contactcheck", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

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

        public DataSet commcheck(string code, string compcode, string userid,string subagency)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_commcheck", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("subagency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagency"].Value = subagency;

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

        //		public DataSet statuscheck(string agencode,string compcode, string userid)
        //			
        //		{
        //			SqlConnection objmysqlconnection;
        //			SqlCommand objmysqlcommand;
        //			objmysqlconnection = GetConnection();
        //			SqlDataAdapter objmysqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objmysqlconnection.Open();
        //				objmysqlcommand = GetCommand("websp_statuscheck123", ref objmysqlconnection);
        //				objmysqlcommand.CommandType = CommandType.StoredProcedure;
        // 
        //				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["compcode"].Value =compcode;
        //
        //				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["userid"].Value =userid;
        //
        //				objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
        //				objmysqlcommand.Parameters["agencode"].Value =agencode;
        //					
        //				objmysqlDataAdapter =new SqlDataAdapter();
        //				objmysqlDataAdapter.SelectCommand =objmysqlcommand;
        //				objmysqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //		}
        //
        //			catch(MySqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objmysqlconnection);
        //			}
        //		}


        public DataSet statuscheck(string drpstatus, string txtfrom, string txtto, string circular, string compcode, string userid, string agencode, string agencysubcode, string remark)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_statuscheck123", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

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

        public DataSet statuscheckdate(string agencode, string compcode, string userid, string txtfrom, string txtto, string circular, string date, string remarks, string subagencycode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("statuscheckdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;

                objmysqlcommand.Parameters.Add("date", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date"].Value = date;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("txtfrom", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtfrom"].Value = Convert.ToDateTime(txtfrom);

                objmysqlcommand.Parameters.Add("txtto", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtto"].Value = Convert.ToDateTime(txtto);

                objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circular"].Value = circular;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;



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

        public DataSet statusdateupdate12(string agencode, string compcode, string userid, string txtfrom, string txtto, string code, string circular, string date, string remarks, string subagencycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("statuscheckdateupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("date", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date"].Value = date;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;
                
                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("txtfrom", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtfrom"].Value = Convert.ToDateTime(txtfrom);

                objmysqlcommand.Parameters.Add("txtto", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtto"].Value = Convert.ToDateTime(txtto);

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circular"].Value = circular;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;

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


        public DataSet bindpub(string compcode, string userid, string agencycode, string agencysubcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_pub_mast", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

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

        public DataSet insertintopub(string compcode, string userid, string agencycode, string subagency, string pub, string commrate)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_pubinsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;


                objmysqlcommand.Parameters.Add("subagency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagency"].Value = subagency;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;


                objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commrate"].Value = commrate;


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

        public DataSet bindpub(string agencycode, string subagency, string compcode, string userid, string codepub)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_checkpub", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;


                objmysqlcommand.Parameters.Add("subagency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagency"].Value = subagency;

                objmysqlcommand.Parameters.Add("codepub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["codepub"].Value = codepub;

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



        public DataSet updatepub1(string compcode, string userid, string agencycode, string subagency, string pub, string commrate, string code)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_updatepub", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;


                objmysqlcommand.Parameters.Add("subagency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagency"].Value = subagency;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;

                objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commrate"].Value = commrate;


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


        public DataSet deletpub(string compcode, string userid, string agencycode, string subagency, string pub, string commrate, string code)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_deletepub", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;


                objmysqlcommand.Parameters.Add("subagency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagency"].Value = subagency;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;

                objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commrate"].Value = commrate;


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


        //public DataSet MasterPrev(string prev, string formname, string compcode, string userid)
        //{

        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("Wesp_insertModuleDetail", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlcommand.Parameters.Add("prev", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["prev"].Value = prev;

        //        objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["formname"].Value = formname;

        //        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["compcode"].Value = compcode;

        //        objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["userid"].Value = userid;

        //        objmysqlDataAdapter = new SqlDataAdapter();
        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }

        //    catch (MySqlException objException)
        //    {
        //        throw (objException);
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


        public DataSet MasterPrev(string prev, string formname, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_insertModuleDetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("prev", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prev"].Value = prev;

                objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname"].Value = formname;

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



        public DataSet MasterPrevSel(string userid, string modulename)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_ModuleDetailSel", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("modulename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["modulename"].Value = modulename;


               
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

        //public DataSet MasterPrevSel1()
        //{

        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("Wesp_ModuleDetailSel1", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;


        //        ////				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["compcode"].Value =compcode;

        //        objmysqlDataAdapter = new SqlDataAdapter();
        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (MySqlException objException)
        //    {
        //        throw (objException);
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

        //public DataSet MasterPrevSel1()
        //{

        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("Wesp_ModuleDetailSel1", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;


        //        ////				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["compcode"].Value =compcode;

        //        objmysqlDataAdapter = new SqlDataAdapter();
        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (MySqlException objException)
        //    {
        //        throw (objException);
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


        //public DataSet MasterPrevSel(string userid, string modulename)
        //{

        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("Wesp_ModuleDetailSel", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;


        //        objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["userid"].Value = userid;

        //        objmysqlcommand.Parameters.Add("modulename", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["modulename"].Value = modulename;


        //        objmysqlDataAdapter = new SqlDataAdapter();
        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (MySqlException objException)
        //    {
        //        throw (objException);
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

        //public DataSet MasterPrevSel2(string user)
        //{

        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("Wesp_ModuleDetailSel2", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlcommand.Parameters.Add("user", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["user"].Value = user;


        //        objmysqlDataAdapter = new SqlDataAdapter();
        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (MySqlException objException)
        //    {
        //        throw (objException);
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

        public DataSet MasterPrevSel2(string user)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_ModuleDetailSel2", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("user", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["user"].Value = user;


            
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



        //public DataSet MasterPrevbut(string priv, string formname, string compcode, string userid)
        //{

        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("Wesp_ModuleDetailBut", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        ////				objmysqlcommand.Parameters.Add("priv1", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["priv1"].Value =priv1;
        //        ////
        //        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["compcode"].Value = compcode;

        //        objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["userid"].Value = userid;

        //        objmysqlcommand.Parameters.Add("priv", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["priv"].Value = priv;

        //        objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["formname"].Value = formname;


        //        objmysqlDataAdapter = new SqlDataAdapter();
        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (MySqlException objException)
        //    {
        //        throw (objException);
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


        public DataSet MasterPrevbut(string priv, string formname, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_ModuleDetailBut", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("prev", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prev"].Value = priv;

                objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname"].Value = formname;


               
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

        public DataSet checkPrevuser(string userid, string formname)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_Modulechekboxuser_Wesp_Modulechekboxuser_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("formname1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname1"].Value = formname;
               
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

        //public DataSet checkPrev()
        //{

        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("Wesp_Modulechekbox", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        ////				objmysqlcommand.Parameters.Add("priv1", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["priv1"].Value =priv1;
        //        ////
        //        ////				objmysqlcommand.Parameters.Add("priv2", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["priv2"].Value =priv2;
        //        ////
        //        ////				objmysqlcommand.Parameters.Add("priv3", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["priv3"].Value =priv3;

        //        ////				objmysqlcommand.Parameters.Add("priv", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["priv"].Value =priv;
        //        ////										
        //        ////				objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["formname"].Value =formname;


        //        objmysqlDataAdapter = new SqlDataAdapter();
        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (MySqlException objException)
        //    {
        //        throw (objException);
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

        public DataSet checkPrev()
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_Modulechekbox", ref objmysqlconnection);
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


        //public DataSet checkForm()
        //{

        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("Wesp_ModulechekForm", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        ////				objmysqlcommand.Parameters.Add("priv1", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["priv1"].Value =priv1;
        //        ////
        //        ////				objmysqlcommand.Parameters.Add("priv2", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["priv2"].Value =priv2;
        //        ////
        //        ////				objmysqlcommand.Parameters.Add("priv3", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["priv3"].Value =priv3;

        //        ////				objmysqlcommand.Parameters.Add("priv", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["priv"].Value =priv;
        //        ////										
        //        ////				objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
        //        ////				objmysqlcommand.Parameters["formname"].Value =formname;


        //        objmysqlDataAdapter = new SqlDataAdapter();
        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (MySqlException objException)
        //    {
        //        throw (objException);
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

        public DataSet checkForm()
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_ModulechekForm", ref objmysqlconnection);
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

        public DataSet checkFormuser(string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_ModulechekForm", ref objmysqlconnection);
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



        //public DataSet MastPrevDisp(string compcode)
        //{
        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("wesp_ModultPrevDisp", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["compcode"].Value = compcode;

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

        public DataSet MastPrevDisp(string compcode, string userid, string userhome, string admin,string revenue)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("wesp_ModultPrevDisp", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = compcode;

                objmysqlcommand.Parameters.Add("USERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USERID"].Value = userid;

                objmysqlcommand.Parameters.Add("USERHOME", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USERHOME"].Value = userhome;

                objmysqlcommand.Parameters.Add("ADMIN1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ADMIN1"].Value = admin;

                objmysqlcommand.Parameters.Add("RETAINER", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["RETAINER"].Value = revenue;

                objmysqlcommand.Parameters.Add("PEXTRA1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PEXTRA1"].Value = System.DBNull.Value;


                objmysqlcommand.Parameters.Add("PEXTRA2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PEXTRA2"].Value = System.DBNull.Value;


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


        public DataSet filluser_permission(string userid, string compcode, string login_userid, string per_desc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fill_userpermission", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("COMP_CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMP_CODE"].Value = compcode;

                objmysqlcommand.Parameters.Add("USER_ID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USER_ID"].Value = userid;

                objmysqlcommand.Parameters.Add("LOGINUSERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["LOGINUSERID"].Value = login_userid;

                objmysqlcommand.Parameters.Add("PER_DESC", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PER_DESC"].Value = per_desc;

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

        //public DataSet Mastdetail(string compcode, string userid)
        //{
        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("wesp_Modultdetail", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["compcode"].Value = compcode;

        //        objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["userid"].Value = userid;

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

        public DataSet Mastdetail(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("wesp_Modultdetail", ref objmysqlconnection);
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


        //public DataSet MastDivison(string compcode, string userid)
        //{
        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("wesp_Modultdivision", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["compcode"].Value = compcode;

        //        objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["userid"].Value = userid;

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


        public DataSet MastDivison(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("wesp_Modultdivision", ref objmysqlconnection);
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

        public DataSet MasterPrevSelect(string userid, string moduleno)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_ModuleDetailSelect", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("moduleno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["moduleno"].Value = moduleno;

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

        public DataSet MasterPrevSelchk(string userid, string modulename)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_ModuleDetailSel", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("modulename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["modulename"].Value = modulename;


              
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

        public DataSet buttonenablechk(string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("wesp_moduledetailbutton_wesp_moduledetailbutton_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;



               
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

        public DataSet inscheckForm(string moduleno)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_ModuleFormins", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("moduleno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["moduleno"].Value = moduleno;


                
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




        



        //public DataSet dateupdation(string compcode, string userid, string dateformat, string code, string curr, string ratecode)
        //{
        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("wesp_updatedate", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["compcode"].Value = compcode;

        //        objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["userid"].Value = userid;

        //        objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["ratecode"].Value = ratecode;

        //        objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["dateformat"].Value = dateformat;

        //        objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["code"].Value = code;

        //        objmysqlcommand.Parameters.Add("curr", MySqlDbType.VarChar);
        //        objmysqlcommand.Parameters["curr"].Value = curr;

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

        public DataSet dateupdation(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agencyretcomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtype, string approval, string pckstatus, string cash_disc, string cash_amt, string repeatday, string premiumedit,string BILL_GENERATION, string PUBLICATION_CENTER)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("wesp_updatedate1", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("copybooking", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["copybooking"].Value = copybooking;

                objmysqlcommand.Parameters.Add("ratecompany", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecompany"].Value = ratecomp;

                objmysqlcommand.Parameters.Add("addagenycomm", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["addagenycomm"].Value = addagencycomm;

                objmysqlcommand.Parameters.Add("agencycommlinkretainer", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycommlinkretainer"].Value = agencyretcomm;

                objmysqlcommand.Parameters.Add("subeditionr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subeditionr"].Value = subrate;

                objmysqlcommand.Parameters.Add("displaybilltype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["displaybilltype"].Value = displaybilltype;

                objmysqlcommand.Parameters.Add("classifiedbilltype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["classifiedbilltype"].Value = classifiedbilltype;



                /////////////////////////////////////////////////////////////////////////////


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;

                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = code;

                objmysqlcommand.Parameters.Add("curr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["curr"].Value = curr;

                objmysqlcommand.Parameters.Add("solo1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["solo1"].Value = solo;

                objmysqlcommand.Parameters.Add("breakup1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["breakup1"].Value = breakup;

                objmysqlcommand.Parameters.Add("bwcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bwcode"].Value = bwcode;

                objmysqlcommand.Parameters.Add("rostatus1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rostatus1"].Value = rostatus;

                objmysqlcommand.Parameters.Add("filename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["filename"].Value = filename;

                objmysqlcommand.Parameters.Add("tfn1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tfn1"].Value = tfn;


                objmysqlcommand.Parameters.Add("insertbreak", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insertbreak"].Value = insertbreak;

                objmysqlcommand.Parameters.Add("prem", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prem"].Value = prem;

                objmysqlcommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealtype"].Value = dealtype;

                objmysqlcommand.Parameters.Add("pre", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pre"].Value = pre;


                objmysqlcommand.Parameters.Add("suff", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suff"].Value = suff;


                objmysqlcommand.Parameters.Add("financestatus11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["financestatus11"].Value = chkfinancestatus;


                objmysqlcommand.Parameters.Add("voucherst1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["voucherst1"].Value = voucherst;

                objmysqlcommand.Parameters.Add("adcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcode"].Value = adcode;

                objmysqlcommand.Parameters.Add("rodatetime", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rodatetime"].Value = rodatetime;

                objmysqlcommand.Parameters.Add("spacearea", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["spacearea"].Value = spacearea;

                objmysqlcommand.Parameters.Add("vat1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat1"].Value = vat;



                objmysqlcommand.Parameters.Add("bookstat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bookstat"].Value = bookstat;

                objmysqlcommand.Parameters.Add("cio_id1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cio_id1"].Value = cio_id;


                objmysqlcommand.Parameters.Add("receipt_no1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["receipt_no1"].Value = receipt_no;


                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("bgcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgcolor"].Value = bgcolor;


                objmysqlcommand.Parameters.Add("validdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validdate"].Value = validdate;



                objmysqlcommand.Parameters.Add("agencyratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencyratecode"].Value = agencyratecode;

                objmysqlcommand.Parameters.Add("audit1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["audit1"].Value = audit;

                objmysqlcommand.Parameters.Add("book_insert_date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["book_insert_date1"].Value = insert_date;

                objmysqlcommand.Parameters.Add("agencycomm1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycomm1"].Value = agencycomm;

                objmysqlcommand.Parameters.Add("rateaudit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateaudit"].Value = rateaudit;

                objmysqlcommand.Parameters.Add("billaudit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billaudit"].Value = billaudit;

                objmysqlcommand.Parameters.Add("billtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billtype"].Value = billtype;

                objmysqlcommand.Parameters.Add("invoice_no1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["invoice_no1"].Value = invoice_no;


                ///////change bhanu

                objmysqlcommand.Parameters.Add("billformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billformat"].Value = billformat;

                objmysqlcommand.Parameters.Add("ratechk", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratechk"].Value = ratechk;

                objmysqlcommand.Parameters.Add("allpkg", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["allpkg"].Value = allpkg;

                objmysqlcommand.Parameters.Add("dayrate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dayrate1"].Value = dayrate;

                objmysqlcommand.Parameters.Add("schemetype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemetype"].Value = schemetype;

                objmysqlcommand.Parameters.Add("PIncludeclassi", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PIncludeclassi"].Value = Includeclassi;

                objmysqlcommand.Parameters.Add("receiptformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["receiptformat"].Value = receiptformat;

                objmysqlcommand.Parameters.Add("cash_receipt", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cash_receipt"].Value = cash_receipt;

                objmysqlcommand.Parameters.Add("bill_orderwiselast1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bill_orderwiselast1"].Value = bill_orderwiselast;


                objmysqlcommand.Parameters.Add("floor_chk1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["floor_chk1"].Value = floor_chk;

                //for circulation
                objmysqlcommand.Parameters.Add("Unsoldflag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Unsoldflag"].Value = Unsoldflag;


                objmysqlcommand.Parameters.Add("Supplystopper", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Supplystopper"].Value = Supplystopper;

                objmysqlcommand.Parameters.Add("drpRokeychk", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpRokeychk"].Value = drpRokeychk;


                objmysqlcommand.Parameters.Add("Agencycomm_seq", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Agencycomm_seq"].Value = Agencycomm_seq;


                objmysqlcommand.Parameters.Add("creditreciept", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["creditreciept"].Value = creditreciept;

                objmysqlcommand.Parameters.Add("cashindisplay", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cashindisplay"].Value = cashindisplay;


                objmysqlcommand.Parameters.Add("cashinclassified", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cashinclassified"].Value = cashinclassified;


                objmysqlcommand.Parameters.Add("v_rate_audit_pref", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_rate_audit_pref"].Value = rate_audit_pref;

                objmysqlcommand.Parameters.Add("v_barcoding_allow", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_barcoding_allow"].Value = barcoding_allow;


                objmysqlcommand.Parameters.Add("v_fmgbills", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_fmgbills"].Value = fmgbills;



                objmysqlcommand.Parameters.Add("v_billed_cashdis", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_billed_cashdis"].Value = billed_cashdis;



                objmysqlcommand.Parameters.Add("v_billed_cashcls", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_billed_cashcls"].Value = billed_cashcls;



                objmysqlcommand.Parameters.Add("v_drpbackdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_drpbackdate"].Value = v_drpbackdate;

                objmysqlcommand.Parameters.Add("dockitbooking", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dockitbooking"].Value = dockitbooking;

                objmysqlcommand.Parameters.Add("allowprevbooking", MySqlDbType.VarChar); 
                objmysqlcommand.Parameters["allowprevbooking"].Value = allowprevbooking;

                objmysqlcommand.Parameters.Add("ro_wisecashbill", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ro_wisecashbill"].Value = cash_billtype;

                objmysqlcommand.Parameters.Add("chkval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chkval"].Value = chkval;

                objmysqlcommand.Parameters.Add("approval1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["approval1"].Value = approval;

                objmysqlcommand.Parameters.Add("pckstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pckstatus"].Value = pckstatus;

                objmysqlcommand.Parameters.Add("cash_disc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cash_disc"].Value = cash_disc;

                objmysqlcommand.Parameters.Add("cash_amt", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cash_amt"].Value = cash_amt;

                objmysqlcommand.Parameters.Add("repeatday", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["repeatday"].Value = repeatday;

                objmysqlcommand.Parameters.Add("premiumedit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumedit"].Value = premiumedit;

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

        public DataSet datesubmit(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agencyretcomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtype, string approval, string pckstatus, string cash_disc, string cash_amt, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("wesp_submitdate1", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("copybooking", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["copybooking"].Value = copybooking;

                objmysqlcommand.Parameters.Add("ratecompany", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecompany"].Value = ratecomp;

                objmysqlcommand.Parameters.Add("addagenycomm", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["addagenycomm"].Value = addagencycomm;

                objmysqlcommand.Parameters.Add("agencycommlinkretainer", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycommlinkretainer"].Value = agencyretcomm;

                objmysqlcommand.Parameters.Add("subeditionr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subeditionr"].Value = subrate;

                objmysqlcommand.Parameters.Add("displaybilltype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["displaybilltype"].Value = displaybilltype;

                objmysqlcommand.Parameters.Add("classifiedbilltype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["classifiedbilltype"].Value = classifiedbilltype;



                /////////////////////////////////////////////////////////////////////////////
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;

                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = code;

                objmysqlcommand.Parameters.Add("curr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["curr"].Value = curr;

                objmysqlcommand.Parameters.Add("solo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["solo"].Value = solo;

                objmysqlcommand.Parameters.Add("breakup", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["breakup"].Value = breakup;

                objmysqlcommand.Parameters.Add("bwcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bwcode"].Value = bwcode;

                objmysqlcommand.Parameters.Add("rostatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rostatus"].Value = rostatus;

                objmysqlcommand.Parameters.Add("filename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["filename"].Value = filename;

                objmysqlcommand.Parameters.Add("tfn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tfn"].Value = tfn;

                objmysqlcommand.Parameters.Add("insertbreak", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insertbreak"].Value = insertbreak;

                objmysqlcommand.Parameters.Add("prem", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prem"].Value = prem;

                objmysqlcommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealtype"].Value = dealtype;


                objmysqlcommand.Parameters.Add("pre", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pre"].Value = pre;




                objmysqlcommand.Parameters.Add("suff", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suff"].Value = suff;


                objmysqlcommand.Parameters.Add("financestatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["financestatus"].Value = chkfinancestatus;


                objmysqlcommand.Parameters.Add("voucherst", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["voucherst"].Value = voucherst;

                objmysqlcommand.Parameters.Add("adcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcode"].Value = adcode;


                objmysqlcommand.Parameters.Add("rodatetime", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rodatetime"].Value = rodatetime;

                objmysqlcommand.Parameters.Add("spacearea", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["spacearea"].Value = spacearea;

                objmysqlcommand.Parameters.Add("vat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat"].Value = vat;


                objmysqlcommand.Parameters.Add("bookstat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bookstat"].Value = bookstat;

                objmysqlcommand.Parameters.Add("cio_id", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cio_id"].Value = cio_id;


                objmysqlcommand.Parameters.Add("receipt_no", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["receipt_no"].Value = receipt_no;

                /////////////bhanu


                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("bgcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgcolor"].Value = bgcolor;


                objmysqlcommand.Parameters.Add("validdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validdate"].Value = validdate;

                objmysqlcommand.Parameters.Add("agencyratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencyratecode"].Value = agencyratecode;


                objmysqlcommand.Parameters.Add("audit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["audit"].Value = audit;

                objmysqlcommand.Parameters.Add("book_insert_date", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["book_insert_date"].Value = insert_date;

                objmysqlcommand.Parameters.Add("agencycomm", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycomm"].Value = agencycomm;

                objmysqlcommand.Parameters.Add("rateaudit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateaudit"].Value = rateaudit;

                objmysqlcommand.Parameters.Add("billaudit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billaudit"].Value = billaudit;

                objmysqlcommand.Parameters.Add("billtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billtype"].Value = billtype;
                objmysqlcommand.Parameters.Add("invoice_no", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["invoice_no"].Value = invoice_no;


                ///////change bhanu

                objmysqlcommand.Parameters.Add("billformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billformat"].Value = billformat;

                objmysqlcommand.Parameters.Add("ratechk", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratechk"].Value = ratechk;

                objmysqlcommand.Parameters.Add("allpkg", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["allpkg"].Value = allpkg;

                objmysqlcommand.Parameters.Add("dayrate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dayrate1"].Value = dayrate;

                objmysqlcommand.Parameters.Add("schemetype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemetype"].Value = schemetype;


                objmysqlcommand.Parameters.Add("PIncludeclassi", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PIncludeclassi"].Value = Includeclassi;

                objmysqlcommand.Parameters.Add("receiptformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["receiptformat"].Value = receiptformat;

                objmysqlcommand.Parameters.Add("cash_receipt", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bill_orderwiselast"].Value = cash_receipt;

                objmysqlcommand.Parameters.Add("bill_orderwiselast", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bill_orderwiselast"].Value = bill_orderwiselast;


                objmysqlcommand.Parameters.Add("floor_chk", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["floor_chk"].Value = floor_chk;

                //for circulation
                objmysqlcommand.Parameters.Add("Unsoldflag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Unsoldflag"].Value = Unsoldflag;

                objmysqlcommand.Parameters.Add("Supplystopper", MySqlDbType.VarChar);
                if (Supplystopper == "")
                    objmysqlcommand.Parameters["Supplystopper"].Value = System.DBNull.Value;
                else
                    objmysqlcommand.Parameters["Supplystopper"].Value = Supplystopper;

                objmysqlcommand.Parameters.Add("drpRokeychk", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpRokeychk"].Value = drpRokeychk;

                objmysqlcommand.Parameters.Add("Agencycomm_seq", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Agencycomm_seq"].Value = Agencycomm_seq;


                objmysqlcommand.Parameters.Add("creditreciept", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["creditreciept"].Value = creditreciept;


                objmysqlcommand.Parameters.Add("cashindisplay", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cashindisplay"].Value = cashindisplay;


                objmysqlcommand.Parameters.Add("cashinclassified", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cashinclassified"].Value = cashinclassified;


                objmysqlcommand.Parameters.Add("rate_audit_pref", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_audit_pref"].Value = rate_audit_pref;

                objmysqlcommand.Parameters.Add("v_barcoding_allow", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_barcoding_allow"].Value = barcoding_allow;



                objmysqlcommand.Parameters.Add("v_fmgbills", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_fmgbills"].Value = fmgbills;






                objmysqlcommand.Parameters.Add("v_billed_cashdis", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_billed_cashdis"].Value = billed_cashdis;



                objmysqlcommand.Parameters.Add("v_billed_cashcls", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_billed_cashcls"].Value = billed_cashcls;


                objmysqlcommand.Parameters.Add("v_drpbackdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["v_drpbackdate"].Value = v_drpbackdate;

                objmysqlcommand.Parameters.Add("dockitbooking", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dockitbooking"].Value = dockitbooking;

                objmysqlcommand.Parameters.Add("allowprevbooking", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["allowprevbooking"].Value = allowprevbooking;

                objmysqlcommand.Parameters.Add("ro_wisecashbill", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ro_wisecashbill"].Value = cash_billtype;

                objmysqlcommand.Parameters.Add("chkval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chkval"].Value = chkval;

                objmysqlcommand.Parameters.Add("approval1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["approval1"].Value = approval;

                objmysqlcommand.Parameters.Add("pckstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pckstatus"].Value = pckstatus;

                objmysqlcommand.Parameters.Add("cash_disc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cash_disc"].Value = cash_disc;

                objmysqlcommand.Parameters.Add("cash_amt", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cash_amt"].Value = cash_amt;

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

        //********************************To check whether entry for company code exist*****************

        public DataSet datechkprefer(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("wesp_chkdateprefer", ref objmysqlconnection);
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



        public DataSet currbind(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("currbindprefer", ref objmysqlconnection);
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
        public DataSet ratebindprefer(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BINDRATEFORPREFERRENCE", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;


               objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["COMPCODE"].Value = compcode;




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


        public DataSet currbindpgld(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("currbindpreferpgld", ref objmysqlconnection);
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

        //GetData is used to retrieve the custcode from customer master
        public DataSet getData(string clientcode, string userid, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Clientpayselect", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;



               objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["custcode"].Value = clientcode;
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

        public DataSet chkData(string clientcode, string userid, string compcode, int flag)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Clientchkpaymode", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;
               objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["flag"].Value = flag;
               objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["custcode"].Value = clientcode;
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

        //insert Data is used to insert/update values into payment table

        public void insertData(string compcode, string custcode, string userid, int i, params string[] strMode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updateClientPay_updateClientPay_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("Cash", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Cash"].Value = strMode[0];
               objmysqlcommand.Parameters.Add("Credit", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Credit"].Value = strMode[1];
               objmysqlcommand.Parameters.Add("Bank", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Bank"].Value = strMode[2];
               objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Comp_Code"].Value = compcode;
               objmysqlcommand.Parameters.Add("Client_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Client_Code"].Value = custcode;
               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;
               objmysqlcommand.Parameters.Add("Flag", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Flag"].Value = i;


               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);

              
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objmysqlconnection); }
        }

        public DataSet collectadvtype(string compcode, string userid, string date)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindadtypeforstatus", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;


               objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Comp_Code"].Value = compcode;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["date1"].Value = date;


               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objmysqlconnection); }

        }




        //public DataSet insertpay(string agencycode, string compcode, string userid, string agencysubcode, params string[] strMode)
        public DataSet insertpay(string agencycode, string compcode, string userid, string agencysubcode, string cash)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlcommand = GetCommand("websp_insertpay", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("Cash", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Cash"].Value = cash;
                //sqlcomm.Parameters.Add("Credit", MySqlDbType.VarChar);
                //sqlcomm.Parameters["Credit"].Value = strMode[1];
                //sqlcomm.Parameters.Add("Bank", MySqlDbType.VarChar);
                //sqlcomm.Parameters["Bank"].Value = strMode[2];
               objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Comp_Code"].Value = compcode;
               objmysqlcommand.Parameters.Add("Agency_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Agency_Code"].Value = agencycode;
               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;
               objmysqlcommand.Parameters.Add("Agency_subcat_code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Agency_subcat_code"].Value = agencysubcode;

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

        //************to update agent paymode****************************8
        public DataSet payinsert(string agencycode, string compcode, string userid, string agencysubcode, string code)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();

                objmysqlcommand = GetCommand("websp_updatepay", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pCash", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pCash"].Value = code;
                //objmysqlcommand.Parameters.Add("Credit", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["Credit"].Value = strMode[1];
                //objmysqlcommand.Parameters.Add("Bank", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["Bank"].Value = strMode[2];


                objmysqlcommand.Parameters.Add("pComp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pComp_Code"].Value = compcode;

                objmysqlcommand.Parameters.Add("pAgency_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pAgency_Code"].Value = agencycode;
                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;
                objmysqlcommand.Parameters.Add("pAgency_subcat_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pAgency_subcat_code"].Value = agencysubcode;


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


        public DataSet getpay(string agencycode, string compcode, string userid, string agencysubcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("agentpayselect", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;
               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;
               objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["agencycode"].Value = agencycode;



               objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;
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

        public DataSet productbind12(string compcode, string userid,string clientcode,string agencycode,string agencysubcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("contactproduct", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["clientcode"].Value = clientcode;

                //sqlcomm.Parameters.Add("agencycode", MySqlDbType.VarChar);
                //sqlcomm.Parameters["agencycode"].Value = agencycode;

                //sqlcomm.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                //sqlcomm.Parameters["agencysubcode"].Value = agencysubcode;
                
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


        public DataSet productbind(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("contactproductcontact", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

                //sqlcomm.Parameters.Add("clientcode", MySqlDbType.VarChar);
                //sqlcomm.Parameters["clientcode"].Value = clientcode;

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



        public DataSet clientbind(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("listbindclient", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;
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


        public DataSet buttonbind(string compcode, string userid,string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("contactdetailbind", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;
               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["code"].Value = code;
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





        public DataSet getthevalue(string contactperson, string agencycode, string subagencycode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatevalueintable", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;
               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["contactperson"].Value = contactperson;

               objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["agencycode"].Value = agencycode;

               objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;

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

        public DataSet detailofcontact(string compcode, string userid, string contactcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getcontactvalue", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("contactcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["contactcode"].Value = contactcode;




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

        public DataSet contactname(string conname, string agencycode, string subagency, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getcontactname_getcontactname_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("conname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["conname"].Value = conname;

               objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["agencycode"].Value = agencycode;

               objmysqlcommand.Parameters.Add("subagency", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["subagency"].Value = subagency;





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

        public DataSet clientvalue(string conname,string compcode, string userid, string agencycode, string subagency)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getclientfromcontact", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("conname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["conname"].Value = conname;

               objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["agencycode"].Value = agencycode;

               objmysqlcommand.Parameters.Add("subagency", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["subagency"].Value = subagency;





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

        public DataSet ratebind(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindrateforpreferrence", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;


               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;




               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objmysqlconnection); }

        }

        public DataSet insMasterPrev(string name, string prev, string formname, string modulename, string userid, string compcode, string division, string moduleno, string formid, string rostatusval, string modelcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_insertModuleDetailchk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                              

                objmysqlcommand.Parameters.Add("modulename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["modulename"].Value = modulename;

                objmysqlcommand.Parameters.Add("division", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["division"].Value = division;

                objmysqlcommand.Parameters.Add("prev", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prev"].Value = prev;

                objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname"].Value = formname;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("moduleno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["moduleno"].Value = moduleno;

                objmysqlcommand.Parameters.Add("pback_days", MySqlDbType.VarChar);
                if (rostatusval != "")
                    objmysqlcommand.Parameters["pback_days"].Value = rostatusval;
                else
                    objmysqlcommand.Parameters["pback_days"].Value = System.DBNull.Value;

                objmysqlcommand.Parameters.Add("pmodulecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pmodulecode"].Value = modelcode;

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

        public DataSet getuserinfo(string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WESP_GETUSERINFO", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



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

        public DataSet checkBgno(string bgno, string bgname)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Wesp_chkBgNo", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("bgno1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgno1"].Value = bgno;

                objmysqlcommand.Parameters.Add("bgname1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgname1"].Value = bgname;

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

        public DataSet statusdatecheck(string drpstatus, string txtfrom, string txtto, string compcode, string userid, string agencycode, string agencysubcode, string dateformat)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("statusdatecheck", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("drpstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpstatus"].Value = drpstatus;

                objmysqlcommand.Parameters.Add("txtfrom", MySqlDbType.VarChar);
                if (txtfrom == "")
                {
                    objmysqlcommand.Parameters["txtfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtfrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtfrom = yy + "/" + mm + "/" + dd;
                    }
                    else if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = txtfrom.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        txtfrom = yy + "/" + mm + "/" + dd;
                    }
                    else
                    {
                        string[] arr = txtfrom.Split('/');
                        string yy = arr[2];
                        string dd = arr[1];
                        string mm = arr[0];
                        txtfrom = yy + "/" + mm + "/" + dd;
                    }
                    objmysqlcommand.Parameters["txtfrom"].Value = txtfrom;
                }

               

                objmysqlcommand.Parameters.Add("txtto", MySqlDbType.VarChar);
                if (txtfrom == "")
                {
                    objmysqlcommand.Parameters["txtto"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtto = yy + "/" + mm + "/" + dd;
                    }
                    else if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = txtto.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        txtto = yy + "/" + mm + "/" + dd;
                    }
                    else
                    {
                        string[] arr = txtto.Split('/');
                        string yy = arr[2];
                        string dd = arr[1];
                        string mm = arr[0];
                        txtto = yy + "/" + mm + "/" + dd;
                    }

                    objmysqlcommand.Parameters["txtto"].Value = txtto;
                }

                


                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;

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

        public DataSet binduom1(string compcode, string adtype)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("uomad_bind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode1"].Value = compcode;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = adtype;

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

        public DataSet rolebind(string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Rolebind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = compcode;

                

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

        public DataSet Pripubcode(string comp_code, string user_id, string chk_value)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_ADDPUBCODE_B", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = comp_code;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = user_id;

                objmysqlcommand.Parameters.Add("chk_value", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chk_value"].Value = comp_code;

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

        public DataSet publication_center(string comp_code)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("PUBCENTNAME1", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = comp_code;

               

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

        public DataSet adtypbind(string comp_code)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADVTYPBIND", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = comp_code;



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

        public DataSet binduserid(string logincode, string dateformat, string extra1, string extra2)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CIR_LOGIN_BIND", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("plogin_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["plogin_code"].Value = logincode;

                objmysqlcommand.Parameters.Add("pdateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pdateformat"].Value = dateformat;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = extra2;



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
        public DataSet bindunit(string comp_code)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_PUBCENTER", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("PCOMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PCOMPCODE"].Value = comp_code;



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


        public DataSet MastPrevDisp_user(string comp_code, string user_id, string extra1, string extra2, string extra3, string username, string retainer,string extra,string extra4)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("wesp_wesp_Modultuser_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = comp_code;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = user_id;

                objmysqlcommand.Parameters.Add("userhome", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userhome"].Value = extra;

                objmysqlcommand.Parameters.Add("admin1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["admin1"].Value = extra4;

                objmysqlcommand.Parameters.Add("retainer", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retainer"].Value = retainer;

                objmysqlcommand.Parameters.Add("username1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username1"].Value = username;

                objmysqlcommand.Parameters.Add("extra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["extra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("extra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["extra2"].Value = extra2;



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

        public DataSet getCsupply_type(string comp_code, string datefr, string extra1, string extra2)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CIR_SUPPLY_TYPE_BIND", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("PCOMP_CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PCOMP_CODE"].Value = comp_code;

                objmysqlcommand.Parameters.Add("PDATEFORMAT", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PDATEFORMAT"].Value = datefr;


                objmysqlcommand.Parameters.Add("PEXTRA1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PEXTRA1"].Value = extra1;

                objmysqlcommand.Parameters.Add("PEXTRA2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PEXTRA2"].Value = extra2;




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

        public DataSet currbindpgld12(string comp_code)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CIR_SUPPLY_TYPE_BIND", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = comp_code;

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

