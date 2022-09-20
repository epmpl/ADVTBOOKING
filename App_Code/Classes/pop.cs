using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for pop
/// </summary>
namespace NewAdbooking.Classes
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
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("retainer_payfill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = hiddenuserid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = hiddencomcode;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet showchk(string compcode, string userid, string retcode, string agencysubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("showagencypay", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retcode"].Value = retcode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet addstatusname(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_status", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet CheckClientPopup(string compcode, string custcode,string custname, string userid, int flag)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("CheckClientpopup", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Add("@custcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@custcode"].Value = custcode;
                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;
                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;
                sqlcomm.Parameters.Add("@flag", SqlDbType.Int);
                sqlcomm.Parameters["@flag"].Value = flag;
                sqlcomm.Parameters.Add("@custname", SqlDbType.VarChar);
                sqlcomm.Parameters["@custname"].Value = custname;
                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
        }

        //------------------------------------------------Pankaj Change----------------------
        public DataSet insertcontact(string contact, string designation, string role, string dob, string phone, string ext, string fax, string mail, string userid, string agencycode, string agencysubcode, string compcode,string id,string mobile)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_contactdetails", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@contact", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contact"].Value = contact;

                objSqlCommand.Parameters.Add("@designation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@designation"].Value = designation;
                //----------------------------
                objSqlCommand.Parameters.Add("@role", SqlDbType.VarChar);
                objSqlCommand.Parameters["@role"].Value = role;
                //-------------------------------
                objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);

                if (dob != null && dob != "")
                {
                    objSqlCommand.Parameters["@dob"].Value = Convert.ToDateTime(dob);
                }
                else
                {
                    objSqlCommand.Parameters["@dob"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                //if (Comment =="" || Comment==null)
                objSqlCommand.Parameters["@phone"].Value = phone;
                //else

                objSqlCommand.Parameters.Add("@ext", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ext"].Value = ext;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mail"].Value = mail;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = id;

                objSqlCommand.Parameters.Add("@mobile", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobile"].Value = mobile ;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        //		**********************************Code**************************************

        public DataSet rolename(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rolename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        //		*********************************End****************************************

        //

        public DataSet contactbind(string agentcode, string userid, string compcode, string dateformat,string nagencycode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_contactbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcode"].Value = agentcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@nagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@nagencycode"].Value = nagencycode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet contactbind12(string agentcode, string userid, string compcode, string hiddencccode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_contactbind12", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcode"].Value = agentcode;

                objSqlCommand.Parameters.Add("@hiddencccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hiddencccode"].Value = hiddencccode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@compcode"].Value =compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet getpro(string code)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpro", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }



        public DataSet getproinsert(string newboxvalue, string comp, string userid, string clientcode, string newprodname, string contactperson,string agencycode,string agencysubcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getproinsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@newboxvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@newboxvalue"].Value = newboxvalue;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@comp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp"].Value = comp;

                objSqlCommand.Parameters.Add("@newprodname", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@newprodname"].Value = newprodname;

                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;
                
                objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contactperson"].Value = contactperson;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet bindes(string contactperson,string comp,string userid,string agencycode,string agencysubcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindproclicont", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                
                
                objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contactperson"].Value = contactperson;

                objSqlCommand.Parameters.Add("@comp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp"].Value = comp;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }



        public DataSet getproname(string aftersplit)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getproname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@aftersplit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@aftersplit"].Value = aftersplit;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


       

        //--------------------------*********************************************


        public DataSet contactupdate(string contactperson, string dob, string designation, string phone, string ext, string fax, string mail, string compcode, string userid, string agencode, string agencysubcode, string update, string role, string id, string mobile)
        {
            //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_contactupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contactperson"].Value = contactperson;

                objSqlCommand.Parameters.Add("@designation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@designation"].Value = designation;
                //--------------------------------------
                objSqlCommand.Parameters.Add("@role", SqlDbType.VarChar);
                objSqlCommand.Parameters["@role"].Value = role;
                //-----------------------------------------
                objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);
                if (dob != "" && dob != null)
                {
                    objSqlCommand.Parameters["@dob"].Value = Convert.ToDateTime(dob);
                }
                else
                {
                    objSqlCommand.Parameters["@dob"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone"].Value = phone;

                objSqlCommand.Parameters.Add("@ext", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ext"].Value = ext;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mail"].Value = mail;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //				objSqlCommand.Parameters.Add("@contcode", SqlDbType.Int);
                //				objSqlCommand.Parameters["@contcode"].Value =code;


                objSqlCommand.Parameters.Add("@update", SqlDbType.VarChar);
                objSqlCommand.Parameters["@update"].Value = update;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = id;

                objSqlCommand.Parameters.Add("@mobile", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobile"].Value = mobile;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        //		public DataSet contactdelete(string contactperson,string dob,string designation,string phone,string ext,string fax,string mail,string code,string compcode,string userid,string agencode,string agencysubcode)
        //			//contactperson,designation,dob,phone,,fax,mail,Session["userid"].ToString(),hidden
        //		{
        //			
        //			SqlConnection objSqlConnection;
        //			SqlCommand objSqlCommand;
        //			objSqlConnection = GetConnection();
        //			SqlDataAdapter objSqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objSqlConnection.Open();
        //				objSqlCommand = GetCommand("websp_contactdelete", ref objSqlConnection);
        //				objSqlCommand.CommandType = CommandType.StoredProcedure;
        // 
        //				objSqlCommand.Parameters.Add("@agentcode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@agentcode"].Value =agencode;
        //
        //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@userid"].Value =userid;
        //
        //				objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@contactperson"].Value =contactperson;
        //
        //				objSqlCommand.Parameters.Add("@designation", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@designation"].Value =designation;
        //
        //				objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);
        //				objSqlCommand.Parameters["@dob"].Value =Convert.ToDateTime(dob);
        //
        //				objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@phone"].Value =phone;
        //
        //				objSqlCommand.Parameters.Add("@ext", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@ext"].Value =ext;
        //
        //				objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@fax"].Value =fax;
        //
        //				objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@mail"].Value =mail;
        //
        //				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@code"].Value =code;
        //
        //				//				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //				//				objSqlCommand.Parameters["@compcode"].Value =compcode;
        //

        //				objSqlDataAdapter =new SqlDataAdapter();
        //				objSqlDataAdapter.SelectCommand =objSqlCommand;
        //				objSqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //
        //
        //			}
        //			catch(SqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objSqlConnection);
        //			}
        //		
        //		}


        public DataSet contactdelete(string compcode, string userid, string agencode, string agencysubcode, string update)
        //contactperson,designation,dob,phone,,fax,mail,Session["userid"].ToString(),hidden
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_contactdelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@agentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcode"].Value = agencode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@update", SqlDbType.VarChar);
                objSqlCommand.Parameters["@update"].Value = update;

                //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@compcode"].Value =compcode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet commission()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_comm_detail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet insertcomm(string effectivedate, string efeectivetill, string commrate, string commapply, string compcode, string userid, string agencode, string agencysubcode, string dateformat, string adtype, string addcomm, string uom1, string agen, string cash_disc, string cash_amt, string adcat)
        //effectivedate,efeectivetill,commrate,commapply,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_insertcomm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@effectivedate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@effectivedate"].Value = Convert.ToDateTime(effectivedate);

                objSqlCommand.Parameters.Add("@efeectivetill", SqlDbType.DateTime);
                objSqlCommand.Parameters["@efeectivetill"].Value = Convert.ToDateTime(efeectivetill);

                objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@commrate"].Value = commrate;

                //				objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);
                //				objSqlCommand.Parameters["@dob"].Value =Convert.ToDateTime(dob);

                objSqlCommand.Parameters.Add("@commapply", SqlDbType.VarChar);
                //if (Comment =="" || Comment==null)
                objSqlCommand.Parameters["@commapply"].Value = commapply;
                //else

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("@addcomm", SqlDbType.VarChar);
                if (addcomm == "")
                    objSqlCommand.Parameters["@addcomm"].Value = "0";
                else
                    objSqlCommand.Parameters["@addcomm"].Value = addcomm;

                objSqlCommand.Parameters.Add("@uom1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom1"].Value = uom1;

                objSqlCommand.Parameters.Add("@agen", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agen"].Value = agen;  

                objSqlCommand.Parameters.Add("@cash_disc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_disc"].Value = cash_disc;

                objSqlCommand.Parameters.Add("@cash_amt", SqlDbType.VarChar);
                if (cash_amt == "")
                    objSqlCommand.Parameters["@cash_amt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cash_amt"].Value = cash_amt;


                objSqlCommand.Parameters.Add("@adcat11", SqlDbType.VarChar);
                if (adcat == "")
                    objSqlCommand.Parameters["@adcat11"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adcat11"].Value = adcat;







                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        //       ***************************My Code*******************************

        public DataSet selectname(string compcode, string userid)//,string agencode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_selectname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@effectivedate", SqlDbType.DateTime);
                //				objSqlCommand.Parameters["@effectivedate"].Value =Convert.ToDateTime(effectivedate);
                //
                //				objSqlCommand.Parameters.Add("@efeectivetill", SqlDbType.DateTime);
                //				objSqlCommand.Parameters["@efeectivetill"].Value =Convert.ToDateTime(efeectivetill);
                //
                //				objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@commrate"].Value =commrate;
                //
                //				objSqlCommand.Parameters.Add("@commapply",SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@commapply"].Value=commapply;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@agencode"].Value =agencode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }




        //       ******************************************************************






        public DataSet commbind(string agencode, string compcode, string userid, string dateformat,string newagecode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("commbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                 objSqlCommand.Parameters.Add("@newagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@newagecode"].Value = newagecode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet commcheckdate(string agencode, string compcode, string userid, string fromdatecomm, string tilldate, string agencysubcode, string adtype, string uom11)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkdatecomm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@fromdatecomm", SqlDbType.DateTime);
                objSqlCommand.Parameters["@fromdatecomm"].Value = Convert.ToDateTime(fromdatecomm);

                objSqlCommand.Parameters.Add("@tilldate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@tilldate"].Value = Convert.ToDateTime(tilldate);


                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@uom11", SqlDbType.VarChar);
                if (uom11 == "" || uom11 == "0")
                    objSqlCommand.Parameters["@uom11"].Value = System.DBNull.Value;
                else
                 objSqlCommand.Parameters["@uom11"].Value = uom11;

                 objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet commcheckdate12(string agencode, string compcode, string userid, string fromdatecomm, string tilldate, string hiddenccode, string subagencycode, string drpcommdetail,string adtype,string uom)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkdatecomm12", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@drpcommdetail", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@drpcommdetail"].Value = drpcommdetail;

                 objSqlCommand.Parameters.Add("@hiddenccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hiddenccode"].Value = hiddenccode;



                objSqlCommand.Parameters.Add("@fromdatecomm", SqlDbType.DateTime);
                objSqlCommand.Parameters["@fromdatecomm"].Value = Convert.ToDateTime(fromdatecomm);

                objSqlCommand.Parameters.Add("@tilldate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@tilldate"].Value = Convert.ToDateTime(tilldate);

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("@uom1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom1"].Value = uom;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet commbind123(string agencode, string compcode, string userid, string code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("commbind12", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet insertbank(string bgno, string bgdate, string amount, string bank, string validitydate, string compcode, string userid, string agencode, string agencysubcode, string attach)
        //bgno,bgdate,amount,bank,validitydate,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_insertbank", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@bgno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgno"].Value = bgno;

                objSqlCommand.Parameters.Add("@bgdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@bgdate"].Value = Convert.ToDateTime(bgdate);

                objSqlCommand.Parameters.Add("@amount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@amount"].Value = amount;

                objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bank"].Value = bank;

                objSqlCommand.Parameters.Add("@validitydate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@validitydate"].Value = Convert.ToDateTime(validitydate);

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;
                objSqlCommand.Parameters.Add("@pattach", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pattach"].Value = attach;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet bankbind(string agencode, string compcode, string userid, string date,string nagencycode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_bankbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@nagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@nagencycode"].Value = nagencycode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date"].Value = date;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet bankbind12(string agencode, string compcode, string userid, string code)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_bankbind12", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }



        public DataSet updatebank(string bgno, string bankdate, string amount, string bank, string validitydate, string compcode, string userid, string agencode, string agencysubcode, string code, string attach)
        //bgno,bankdate,amount,bank,validitydate,Session[""].ToString(),Session[""].ToString(),agencode,agencysubcode
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_updatebank", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@bgno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgno"].Value = bgno;

                objSqlCommand.Parameters.Add("@bankdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@bankdate"].Value = Convert.ToDateTime(bankdate);

                objSqlCommand.Parameters.Add("@amount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@amount"].Value = amount;

                objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bank"].Value = bank;

                objSqlCommand.Parameters.Add("@validitydate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@validitydate"].Value = Convert.ToDateTime(validitydate);

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;


                objSqlCommand.Parameters.Add("@pattach", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pattach"].Value = attach;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        //		public DataSet deletebank(string bgno,string bankdate, string amount,string bank,string validitydate,string compcode,string userid,string agencode,string agencysubcode,string code)
        //			//bgno,bankdate,amount,bank,validitydate,Session[""].ToString(),Session[""].ToString(),agencode,agencysubcode
        //			
        //		{
        //			
        //			SqlConnection objSqlConnection;
        //			SqlCommand objSqlCommand;
        //			objSqlConnection = GetConnection();
        //			SqlDataAdapter objSqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objSqlConnection.Open();
        //				objSqlCommand = GetCommand("websp_deletebank", ref objSqlConnection);
        //				objSqlCommand.CommandType = CommandType.StoredProcedure;
        // 
        //				objSqlCommand.Parameters.Add("@bgno", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@bgno"].Value =bgno;
        //
        //				objSqlCommand.Parameters.Add("@bankdate", SqlDbType.DateTime);
        //				objSqlCommand.Parameters["@bankdate"].Value =Convert.ToDateTime(bankdate);
        //
        //				objSqlCommand.Parameters.Add("@amount", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@amount"].Value =amount;
        //
        //				objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@bank"].Value =bank;
        //
        //				objSqlCommand.Parameters.Add("@validitydate", SqlDbType.DateTime);
        //				objSqlCommand.Parameters["@validitydate"].Value =Convert.ToDateTime(validitydate);
        //
        //				objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@agencysubcode"].Value =agencysubcode;

        //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@compcode"].Value =compcode;
        //
        //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@userid"].Value =userid;
        //
        //				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@agencode"].Value =agencode;
        //
        //				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@code"].Value =code;
        //
        //				objSqlDataAdapter =new SqlDataAdapter();
        //				objSqlDataAdapter.SelectCommand =objSqlCommand;
        //				objSqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //
        //
        //			}
        //			catch(SqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objSqlConnection);
        //			}
        //		
        //		}


        public DataSet deletebank(string compcode, string userid, string agencode, string agencysubcode, string code)
        //bgno,bankdate,amount,bank,validitydate,Session[""].ToString(),Session[""].ToString(),agencode,agencysubcode
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_deletebank", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }





        public DataSet commupdate(string effectivefrm, string efftill, string commrate, string commapplied, string code, string compcode, string userid, string agencode, string adtype, string addcomm, string uom, string agen, string cash_disc, string cash_amt, string adcat)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_commupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@effectivefrm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@effectivefrm"].Value = Convert.ToDateTime(effectivefrm);

                objSqlCommand.Parameters.Add("@efftill", SqlDbType.DateTime);
                objSqlCommand.Parameters["@efftill"].Value = Convert.ToDateTime(efftill);

                objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@commrate"].Value = commrate;

                objSqlCommand.Parameters.Add("@commapplied", SqlDbType.VarChar);
                objSqlCommand.Parameters["@commapplied"].Value = commapplied;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                //				objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@agencysubcode"].Value =agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("@addcomm", SqlDbType.VarChar);
                if(addcomm=="")
                    objSqlCommand.Parameters["@addcomm"].Value = "0";
                else
                objSqlCommand.Parameters["@addcomm"].Value = addcomm;

                objSqlCommand.Parameters.Add("@uom1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom1"].Value = uom;

                objSqlCommand.Parameters.Add("@agen", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agen"].Value = agen;  

                objSqlCommand.Parameters.Add("@cash_disc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_disc"].Value = cash_disc;

                objSqlCommand.Parameters.Add("@cash_amt", SqlDbType.VarChar);
                if (cash_amt == "null" || cash_amt == "" || cash_amt == null)
                    objSqlCommand.Parameters["@cash_amt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cash_amt"].Value = cash_amt;

              
                objSqlCommand.Parameters.Add("@adcat11", SqlDbType.VarChar);
                if (adcat == "")
                    objSqlCommand.Parameters["@adcat11"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adcat11"].Value = adcat;






                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        //		public DataSet commdelete(string effectivefrm,string efftill, string commrate,string commapplied,string code,string compcode,string userid,string agencode,string agencysubcode)
        //			//effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        //			
        //		{
        //			
        //			SqlConnection objSqlConnection;
        //			SqlCommand objSqlCommand;
        //			objSqlConnection = GetConnection();
        //			SqlDataAdapter objSqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objSqlConnection.Open();
        //				objSqlCommand = GetCommand("websp_commdelete", ref objSqlConnection);
        //				objSqlCommand.CommandType = CommandType.StoredProcedure;
        // 
        //				
        //
        //				objSqlCommand.Parameters.Add("@effectivefrm", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@effectivefrm"].Value =Convert.ToDateTime(effectivefrm);
        //
        //				objSqlCommand.Parameters.Add("@efftill", SqlDbType.DateTime);
        //				objSqlCommand.Parameters["@efftill"].Value =Convert.ToDateTime(efftill);
        //
        //				objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@commrate"].Value =commrate;
        //
        //
        //				objSqlCommand.Parameters.Add("@commapplied", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@commapplied"].Value =commapplied;
        //
        //				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@code"].Value =code;
        //
        //				objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@agencysubcode"].Value =agencysubcode;

        //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@compcode"].Value =compcode;
        //
        //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@userid"].Value =userid;
        //
        //				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@agencode"].Value =agencode;

        //				objSqlDataAdapter =new SqlDataAdapter();
        //				objSqlDataAdapter.SelectCommand =objSqlCommand;
        //				objSqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //
        //
        //			}
        //			catch(SqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objSqlConnection);
        //			}
        //		
        //		}


        public DataSet commdelete(string code, string compcode, string userid, string agencode, string agencysubcode)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_commdelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        //public DataSet statusbind12(string agencode, string compcode, string userid, string date,string nagencycode)
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("websp_statusbind12", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@nagencycode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@nagencycode"].Value = nagencycode;


        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@date"].Value = date;


        //        objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@agencode"].Value = agencode;

        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}


        public DataSet statusbind12(string agencode, string compcode, string userid, string date, string nagencycode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_statusbind12", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@nagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@nagencycode"].Value = nagencycode;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date"].Value = date;


                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet statusbind(string agencode, string compcode, string userid, string hiddenccode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_statusbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@hiddenccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hiddenccode"].Value = hiddenccode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet insertstatus(string status, string fromdate, string todate, string circular, string compcode, string userid, string agencode, string agencysubcode, string remarks,string attachment)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_insertstatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromdate"].Value = Convert.ToDateTime(fromdate);

                objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@todate"].Value = Convert.ToDateTime(todate);

                objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
                objSqlCommand.Parameters["@circular"].Value = circular;


                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@attach", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach"].Value = attachment;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        //		public DataSet statusupdate(string todate,string frmdate, string status,string code,string compcode,string userid,string agencode,string agencysubcode)
        //			//status,frmdate,todate,code, compcode,userid,agencode,agencysubcode
        //			
        //		{
        //			
        //			SqlConnection objSqlConnection;
        //			SqlCommand objSqlCommand;
        //			objSqlConnection = GetConnection();
        //			SqlDataAdapter objSqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objSqlConnection.Open();
        //				objSqlCommand = GetCommand("websp_statusupdate", ref objSqlConnection);
        //				objSqlCommand.CommandType = CommandType.StoredProcedure;

        //				objSqlCommand.Parameters.Add("@frmdate", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@frmdate"].Value =Convert.ToDateTime(frmdate);
        //
        //				objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
        //				objSqlCommand.Parameters["@todate"].Value =Convert.ToDateTime(todate);
        //
        //				objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@status"].Value =status;
        //
        //				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@code"].Value =code;
        //
        //				objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@agencysubcode"].Value =agencysubcode;
        //
        //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@compcode"].Value =compcode;
        //
        //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@userid"].Value =userid;
        //
        //				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@agencode"].Value =agencode;
        //
        //				objSqlDataAdapter =new SqlDataAdapter();
        //				objSqlDataAdapter.SelectCommand =objSqlCommand;
        //				objSqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //
        //
        //			}
        //			catch(SqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objSqlConnection);
        //			}
        //		
        //		}

        public DataSet statusupdate(string status, string frmdate, string todate, string circular, string agencode, string compcode, string userid, string agencysubcode, string code, string remarks,string attach)

            //status,frmdate,todate,code, compcode,userid,agencode,agencysubcode
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_statusupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@frmdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frmdate"].Value = Convert.ToDateTime(frmdate);

                objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@todate"].Value = Convert.ToDateTime(todate);

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
                objSqlCommand.Parameters["@circular"].Value = circular;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@attach", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach"].Value = attach;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet statusdelete(string compcode, string userid, string agencode, string agencysubcode, string hiddenccode)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_statusdelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@hiddenccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hiddenccode"].Value = hiddenccode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet paybind()
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_paybind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        /*public DataSet insertpay(string cash, string credit, string bank, string compcode, string userid, string agencode, string agencysubcode)
        //CheckBox1.Text.ToString(),CheckBox2.Text.ToString(),CheckBox2.Text.ToString(),Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_insertpay", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cash", SqlDbType.VarChar);

                if (cash == null || cash == "")
                {
                    objSqlCommand.Parameters["@cash"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@cash"].Value = cash;
                }

                objSqlCommand.Parameters.Add("@credit", SqlDbType.VarChar);

                if (credit == null || credit == "")
                {
                    objSqlCommand.Parameters["@credit"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@credit"].Value = credit;
                }

                objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);

                if (bank == null || bank == "")
                {
                    objSqlCommand.Parameters["@bank"].Value = System.DBNull.Value;

                }
                else
                {

                    objSqlCommand.Parameters["@bank"].Value = bank;
                }

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }*/

        public DataSet payselect(string agencode, string userid, string compcode,string subagencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("payselect", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        /* public DataSet payinsert(string cash, string credit, string bank, string compcode, string userid, string agencode, string agencysubcode)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                 objSqlConnection.Open();

                 //string query="update pay_mode_mst set cash='"+cash+"',credit='"+credit+"',bank='"+bank+"' where agency_code='"+agencode+"' and userid='"+userid+"' and comp_code='"+compcode+"' and  agency_subcat_code='"+agencysubcode+"' ";
                 string query = "update pay_mode_mst set cash='" + cash + "',credit='" + credit + "',bank='" + bank + "' where agency_code='" + agencode + "' and userid='" + userid + "' and comp_code='" + compcode + "'";
                 objSqlCommand = new SqlCommand(query, objSqlConnection);
                 objSqlCommand.ExecuteNonQuery();


                 //objSqlCommand = GetCommand("websp_payinsert", ref objSqlConnection);
                 //				objSqlCommand.CommandType = CommandType.StoredProcedure;

                 //				objSqlCommand.Parameters.Add("@cash", SqlDbType.VarChar);
                 //				objSqlCommand.Parameters["@cash"].Value =cash;
                 //
                 ////				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                 ////				objSqlCommand.Parameters["@code"].Value =code;
                 //
                 //				objSqlCommand.Parameters.Add("@credit", SqlDbType.VarChar);
                 //				objSqlCommand.Parameters["@credit"].Value =credit;
                 //
                 //				objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);
                 //				objSqlCommand.Parameters["@bank"].Value =bank;

                 ////				if(cash == null || cash == "")
                 ////				{
                 ////					objSqlCommand.Parameters["@cash"].Value =System.DBNull.Value;
                 ////
                 ////				}
                 ////				else
                 ////				{
                 ////					objSqlCommand.Parameters["@cash"].Value =cash;
                 ////				}
                 ////
                 ////				objSqlCommand.Parameters.Add("@credit", SqlDbType.VarChar);
                 ////
                 ////				if(credit == null || credit == "")
                 ////				{
                 ////					objSqlCommand.Parameters["@credit"].Value =System.DBNull.Value;
                 ////				}
                 ////				else
                 ////				{
                 ////
                 ////					objSqlCommand.Parameters["@credit"].Value =credit;
                 ////				}
                 //			
                 ////				objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);
                 ////
                 ////				if(bank == null || bank == "")
                 ////				{
                 ////					objSqlCommand.Parameters["@bank"].Value =System.DBNull.Value;
                 ////
                 ////				}
                 ////				else
                 ////				{
                 ////
                 ////					objSqlCommand.Parameters["@bank"].Value =bank;
                 ////				}

                 //				objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                 //				objSqlCommand.Parameters["@agencysubcode"].Value =agencysubcode;
                 //
                 //	     		objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                 //				objSqlCommand.Parameters["@compcode"].Value =compcode;
                 //
                 //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                 //				objSqlCommand.Parameters["@userid"].Value =userid;
                 //
                 //				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                 //				objSqlCommand.Parameters["@agencode"].Value =agencode;

                 objSqlDataAdapter = new SqlDataAdapter();
                 objSqlDataAdapter.SelectCommand = objSqlCommand;
                 objSqlDataAdapter.Fill(objDataSet);
                 return objDataSet;


             }
             catch (SqlException objException)
             {
                 throw (objException);
             }
             catch (Exception ex)
             {
                 throw (ex);
             }
             finally
             {
                 CloseConnection(ref objSqlConnection);
             }

         }*/

        public DataSet paydelete(string cash, string credit, string bank, string code, string compcode, string userid, string agencode, string agencysubcode)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_paydelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@cash", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@cash"].Value =cash;
                //
                //				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@code"].Value =code;
                //
                //				objSqlCommand.Parameters.Add("@credit", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@credit"].Value =credit;
                //
                //				objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@bank"].Value =bank;


                if (cash == null || cash == "")
                {
                    objSqlCommand.Parameters["@cash"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@cash"].Value = cash;
                }

                objSqlCommand.Parameters.Add("@credit", SqlDbType.VarChar);

                if (credit == null || credit == "")
                {
                    objSqlCommand.Parameters["@credit"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@credit"].Value = credit;
                }

                objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);

                if (bank == null || bank == "")
                {
                    objSqlCommand.Parameters["@bank"].Value = System.DBNull.Value;

                }
                else
                {

                    objSqlCommand.Parameters["@bank"].Value = bank;
                }

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet paycheck(string code, string compcode, string userid, string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_paycheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet status(string code, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_statuscheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet contactcheck(string code, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_contactcheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet commcheck(string code, string compcode, string userid,string subagency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_commcheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@subagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagency"].Value = subagency;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        //		public DataSet statuscheck(string agencode,string compcode, string userid)
        //			
        //		{
        //			SqlConnection objSqlConnection;
        //			SqlCommand objSqlCommand;
        //			objSqlConnection = GetConnection();
        //			SqlDataAdapter objSqlDataAdapter;
        //			DataSet objDataSet = new DataSet();	
        //			try
        //			{
        //				objSqlConnection.Open();
        //				objSqlCommand = GetCommand("websp_statuscheck123", ref objSqlConnection);
        //				objSqlCommand.CommandType = CommandType.StoredProcedure;
        // 
        //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@compcode"].Value =compcode;
        //
        //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@userid"].Value =userid;
        //
        //				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
        //				objSqlCommand.Parameters["@agencode"].Value =agencode;
        //					
        //				objSqlDataAdapter =new SqlDataAdapter();
        //				objSqlDataAdapter.SelectCommand =objSqlCommand;
        //				objSqlDataAdapter.Fill(objDataSet);
        //				return objDataSet;
        //		}
        //
        //			catch(SqlException objException)
        //			{
        //				throw(objException);
        //			}
        //			catch(Exception ex)
        //			{
        //				throw(ex);	
        //			}
        //			finally
        //			{
        //				CloseConnection(ref objSqlConnection);
        //			}
        //		}


        public DataSet statuscheck(string drpstatus, string txtfrom, string txtto, string circular, string compcode, string userid, string agencode, string agencysubcode, string remark)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_statuscheck123", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet statuscheckdate(string agencode, string compcode, string userid, string txtfrom, string txtto, string circular, string date, string remarks, string subagencycode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("statuscheckdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;

                objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date"].Value = date;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@txtfrom", SqlDbType.DateTime);
                objSqlCommand.Parameters["@txtfrom"].Value = Convert.ToDateTime(txtfrom);

                objSqlCommand.Parameters.Add("@txtto", SqlDbType.DateTime);
                objSqlCommand.Parameters["@txtto"].Value = Convert.ToDateTime(txtto);

                objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
                objSqlCommand.Parameters["@circular"].Value = circular;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet statusdateupdate12(string agencode, string compcode, string userid, string txtfrom, string txtto, string code, string circular, string date, string remarks, string subagencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("statuscheckdateupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date"].Value = date;

                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;
                
                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@txtfrom", SqlDbType.DateTime);
                objSqlCommand.Parameters["@txtfrom"].Value = Convert.ToDateTime(txtfrom);

                objSqlCommand.Parameters.Add("@txtto", SqlDbType.DateTime);
                objSqlCommand.Parameters["@txtto"].Value = Convert.ToDateTime(txtto);

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
                objSqlCommand.Parameters["@circular"].Value = circular;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet bindpub(string compcode, string userid, string agencycode, string agencysubcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pub_mast", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet insertintopub(string compcode, string userid, string agencycode, string subagency, string pub, string commrate)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pubinsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


                objSqlCommand.Parameters.Add("@subagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagency"].Value = subagency;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;


                objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@commrate"].Value = commrate;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet bindpub(string agencycode, string subagency, string compcode, string userid, string codepub)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_checkpub", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


                objSqlCommand.Parameters.Add("@subagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagency"].Value = subagency;

                objSqlCommand.Parameters.Add("@codepub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@codepub"].Value = codepub;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }



        public DataSet updatepub1(string compcode, string userid, string agencycode, string subagency, string pub, string commrate, string code)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_updatepub", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


                objSqlCommand.Parameters.Add("@subagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagency"].Value = subagency;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;

                objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@commrate"].Value = commrate;


                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet deletpub(string compcode, string userid, string agencycode, string subagency, string pub, string commrate, string code)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_deletepub", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


                objSqlCommand.Parameters.Add("@subagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagency"].Value = subagency;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;

                objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@commrate"].Value = commrate;


                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        //public DataSet MasterPrev(string prev, string formname, string compcode, string userid)
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Wesp_insertModuleDetail", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@prev", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@prev"].Value = prev;

        //        objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@formname"].Value = formname;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}


        public DataSet MasterPrev(string prev, string formname, string compcode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_insertModuleDetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@prev", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prev"].Value = prev;

                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }



        public DataSet MasterPrevSel(string userid, string modulename)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_ModuleDetailSel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@modulename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@modulename"].Value = modulename;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        //public DataSet MasterPrevSel1()
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Wesp_ModuleDetailSel1", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;


        //        ////				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@compcode"].Value =compcode;

        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}

        //public DataSet MasterPrevSel1()
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Wesp_ModuleDetailSel1", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;


        //        ////				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@compcode"].Value =compcode;

        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}


        //public DataSet MasterPrevSel(string userid, string modulename)
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Wesp_ModuleDetailSel", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;


        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlCommand.Parameters.Add("@modulename", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@modulename"].Value = modulename;


        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}

        //public DataSet MasterPrevSel2(string user)
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Wesp_ModuleDetailSel2", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@user", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@user"].Value = user;


        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}

        public DataSet MasterPrevSel2(string user)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_ModuleDetailSel2", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@user", SqlDbType.VarChar);
                objSqlCommand.Parameters["@user"].Value = user;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }



        //public DataSet MasterPrevbut(string priv, string formname, string compcode, string userid)
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Wesp_ModuleDetailBut", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        ////				objSqlCommand.Parameters.Add("@priv1", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@priv1"].Value =priv1;
        //        ////
        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlCommand.Parameters.Add("@priv", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@priv"].Value = priv;

        //        objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@formname"].Value = formname;


        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}


        public DataSet MasterPrevbut(string priv, string formname, string compcode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_ModuleDetailBut", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@prev", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prev"].Value = priv;

                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet checkPrevuser(string userid,string formname)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_Modulechekboxuser", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        //public DataSet checkPrev()
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Wesp_Modulechekbox", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        ////				objSqlCommand.Parameters.Add("@priv1", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@priv1"].Value =priv1;
        //        ////
        //        ////				objSqlCommand.Parameters.Add("@priv2", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@priv2"].Value =priv2;
        //        ////
        //        ////				objSqlCommand.Parameters.Add("@priv3", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@priv3"].Value =priv3;

        //        ////				objSqlCommand.Parameters.Add("@priv", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@priv"].Value =priv;
        //        ////										
        //        ////				objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@formname"].Value =formname;


        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}

        public DataSet checkPrev()
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_Modulechekbox", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        //public DataSet checkForm()
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Wesp_ModulechekForm", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        ////				objSqlCommand.Parameters.Add("@priv1", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@priv1"].Value =priv1;
        //        ////
        //        ////				objSqlCommand.Parameters.Add("@priv2", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@priv2"].Value =priv2;
        //        ////
        //        ////				objSqlCommand.Parameters.Add("@priv3", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@priv3"].Value =priv3;

        //        ////				objSqlCommand.Parameters.Add("@priv", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@priv"].Value =priv;
        //        ////										
        //        ////				objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
        //        ////				objSqlCommand.Parameters["@formname"].Value =formname;


        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}

        public DataSet checkForm()
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_ModulechekForm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet checkFormuser(string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_ModulechekForm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }



        //public DataSet MastPrevDisp(string compcode)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("wesp_ModultPrevDisp", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }

        //}

        public DataSet MastPrevDisp(string compcode,string userid,string userhome,string admin, string retainer)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_ModultPrevDisp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@userhome", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userhome"].Value = userhome;

                objSqlCommand.Parameters.Add("@admin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@admin"].Value = admin;

                objSqlCommand.Parameters.Add("@retainer_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer_code"].Value = retainer;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        //public DataSet Mastdetail(string compcode, string userid)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("wesp_Modultdetail", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }

        //}

        public DataSet Mastdetail(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_Modultdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        //public DataSet MastDivison(string compcode, string userid)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("wesp_Modultdivision", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }

        //}


        public DataSet MastDivison(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_Modultdivision", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet MasterPrevSelect(string userid, string moduleno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_ModuleDetailSelect", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@moduleno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@moduleno"].Value = moduleno;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet MasterPrevSelchk(string userid, string modulename)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_ModuleDetailSel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@modulename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@modulename"].Value = modulename;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet buttonenablechk(string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_ModuleDetailbutton", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet inscheckForm(string moduleno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_ModuleFormins", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@moduleno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@moduleno"].Value = moduleno;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }




        



        //public DataSet dateupdation(string compcode, string userid, string dateformat, string code, string curr, string ratecode)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("wesp_updatedate", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@ratecode"].Value = ratecode;

        //        objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@dateformat"].Value = dateformat;

        //        objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@code"].Value = code;

        //        objSqlCommand.Parameters.Add("@curr", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@curr"].Value = curr;

        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }

        //}

    

        /*new change ankur*/
        public DataSet datesubmit(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agencyretcomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtype, string approval, string pckstatus, string cash_disc, string cash_amt, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER, string allow_discount_prem, string scheme_billing, string ALLOW_PDC, string ad_type_for_manul_bill, string RO_OUTSTAND_P, string genrate_agency_code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_submitdate1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@copybooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@copybooking"].Value = copybooking;

                objSqlCommand.Parameters.Add("@ratecompany", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecompany"].Value = ratecomp;

                objSqlCommand.Parameters.Add("@addagenycomm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagenycomm"].Value = addagencycomm;

                objSqlCommand.Parameters.Add("@agencycommlinkretainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycommlinkretainer"].Value = agencyretcomm;

                objSqlCommand.Parameters.Add("@subeditionr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subeditionr"].Value = subrate;

                objSqlCommand.Parameters.Add("@displaybilltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@displaybilltype"].Value = displaybilltype;

                objSqlCommand.Parameters.Add("@classifiedbilltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@classifiedbilltype"].Value = classifiedbilltype;



                /////////////////////////////////////////////////////////////////////////////
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@curr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@curr"].Value = curr;

                objSqlCommand.Parameters.Add("@solo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@solo"].Value = solo;

                objSqlCommand.Parameters.Add("@breakup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@breakup"].Value = breakup;

                objSqlCommand.Parameters.Add("@bwcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bwcode"].Value = bwcode;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@insertbreak", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertbreak"].Value = insertbreak;

                objSqlCommand.Parameters.Add("@prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prem"].Value = prem;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;


                objSqlCommand.Parameters.Add("@pre", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pre"].Value = pre;




                objSqlCommand.Parameters.Add("@suff", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suff"].Value = suff;


                objSqlCommand.Parameters.Add("@financestatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@financestatus"].Value = chkfinancestatus;


                objSqlCommand.Parameters.Add("@voucherst", SqlDbType.VarChar);
                objSqlCommand.Parameters["@voucherst"].Value = voucherst;

                objSqlCommand.Parameters.Add("@adcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcode"].Value = adcode;


                objSqlCommand.Parameters.Add("@rodatetime", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rodatetime"].Value = rodatetime;

                objSqlCommand.Parameters.Add("@spacearea", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spacearea"].Value = spacearea;

                objSqlCommand.Parameters.Add("@vat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat"].Value = vat;


                objSqlCommand.Parameters.Add("@bookstat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookstat"].Value = bookstat;

                objSqlCommand.Parameters.Add("@cio_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_id"].Value = cio_id;


                objSqlCommand.Parameters.Add("@receipt_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receipt_no"].Value = receipt_no;

                /*new change ankur*/


                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;


                objSqlCommand.Parameters.Add("@validdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validdate"].Value = validdate;

                objSqlCommand.Parameters.Add("@agencyratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyratecode"].Value = agencyratecode;


                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@book_insert_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@book_insert_date"].Value = insert_date;

                objSqlCommand.Parameters.Add("@agencycomm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycomm"].Value = agencycomm;

                objSqlCommand.Parameters.Add("@rateaudit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateaudit"].Value = rateaudit;

                objSqlCommand.Parameters.Add("@billaudit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaudit"].Value = billaudit;

                objSqlCommand.Parameters.Add("@billtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billtype"].Value = billtype;
                objSqlCommand.Parameters.Add("@invoice_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@invoice_no"].Value = invoice_no;


                ///////change bhanu

                objSqlCommand.Parameters.Add("@billformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billformat"].Value = billformat;

                objSqlCommand.Parameters.Add("@ratechk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratechk"].Value = ratechk;

                objSqlCommand.Parameters.Add("@allpkg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allpkg"].Value = allpkg;

                objSqlCommand.Parameters.Add("@dayrate1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dayrate1"].Value = dayrate;

                objSqlCommand.Parameters.Add("@schemetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemetype"].Value = schemetype;


                objSqlCommand.Parameters.Add("@PIncludeclassi", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PIncludeclassi"].Value = Includeclassi;

                objSqlCommand.Parameters.Add("@receiptformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptformat"].Value = receiptformat;

                objSqlCommand.Parameters.Add("@cash_receipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bill_orderwiselast"].Value = cash_receipt;

                objSqlCommand.Parameters.Add("@bill_orderwiselast", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bill_orderwiselast"].Value = bill_orderwiselast;


                objSqlCommand.Parameters.Add("@floor_chk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@floor_chk"].Value = floor_chk;

                //for circulation
                objSqlCommand.Parameters.Add("@Unsoldflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Unsoldflag"].Value = Unsoldflag;

                objSqlCommand.Parameters.Add("@Supplystopper", SqlDbType.VarChar);
                if (Supplystopper == "")
                    objSqlCommand.Parameters["@Supplystopper"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@Supplystopper"].Value = Supplystopper;

                objSqlCommand.Parameters.Add("@drpRokeychk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpRokeychk"].Value = drpRokeychk;

                objSqlCommand.Parameters.Add("@Agencycomm_seq", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Agencycomm_seq"].Value = Agencycomm_seq;


                objSqlCommand.Parameters.Add("@creditreciept", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditreciept"].Value = creditreciept;


                objSqlCommand.Parameters.Add("@cashindisplay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cashindisplay"].Value = cashindisplay;


                objSqlCommand.Parameters.Add("@cashinclassified", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cashinclassified"].Value = cashinclassified;


                objSqlCommand.Parameters.Add("@rate_audit_pref", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_audit_pref"].Value = rate_audit_pref;

                objSqlCommand.Parameters.Add("@v_barcoding_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_barcoding_allow"].Value = barcoding_allow;



                objSqlCommand.Parameters.Add("@v_fmgbills", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_fmgbills"].Value = fmgbills;






                objSqlCommand.Parameters.Add("@v_billed_cashdis", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_billed_cashdis"].Value = billed_cashdis;



                objSqlCommand.Parameters.Add("@v_billed_cashcls", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_billed_cashcls"].Value = billed_cashcls;


                objSqlCommand.Parameters.Add("@v_drpbackdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_drpbackdate"].Value = v_drpbackdate;

                objSqlCommand.Parameters.Add("@dockitbooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitbooking"].Value = dockitbooking;

                objSqlCommand.Parameters.Add("@allowprevbooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allowprevbooking"].Value = allowprevbooking;


                objSqlCommand.Parameters.Add("@chkval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkval"].Value = chkval;

                objSqlCommand.Parameters.Add("@ro_wisecashbill", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ro_wisecashbill"].Value = cash_billtype;

                objSqlCommand.Parameters.Add("@approval1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approval1"].Value = approval;

                objSqlCommand.Parameters.Add("@pckstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pckstatus"].Value = pckstatus;

                objSqlCommand.Parameters.Add("@cash_disc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_disc"].Value = cash_disc;

                objSqlCommand.Parameters.Add("@cash_amt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_amt"].Value = cash_amt;


                objSqlCommand.Parameters.Add("@p_repeatday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_repeatday"].Value = repeatday;

                objSqlCommand.Parameters.Add("@p_premiumedit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_premiumedit"].Value = premiumedit;


                 objSqlCommand.Parameters.Add("@P_BILL_GENERATION", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@P_BILL_GENERATION"].Value = BILL_GENERATION;

                objSqlCommand.Parameters.Add("@P_PUBLICATION_CENTER", SqlDbType.VarChar);
                if (PUBLICATION_CENTER == "0")
                {
                    objSqlCommand.Parameters["@P_PUBLICATION_CENTER"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@P_PUBLICATION_CENTER"].Value = PUBLICATION_CENTER;
                }


                objSqlCommand.Parameters.Add("@P_allow_discount_prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_allow_discount_prem"].Value = allow_discount_prem;


                objSqlCommand.Parameters.Add("@P_SCHEME_BILLING", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_SCHEME_BILLING"].Value = scheme_billing;


                objSqlCommand.Parameters.Add("@P_ALLOW_PDC", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ALLOW_PDC"].Value = ALLOW_PDC;


                objSqlCommand.Parameters.Add("@PAD_TYPE_FOR_MANUL_BILL", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PAD_TYPE_FOR_MANUL_BILL"].Value = ad_type_for_manul_bill;


                objSqlCommand.Parameters.Add("@RO_OUTSTAND_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RO_OUTSTAND_P"].Value = RO_OUTSTAND_P;

                objSqlCommand.Parameters.Add("@genrate_agency_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@genrate_agency_code"].Value = genrate_agency_code;

                
                

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }



        ///////////////////////



        public DataSet dateupdation(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agencyretcomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtype, string approval, string pckstatus, string cash_disc, string cash_amt, string seperate_cashier, string disp_bill, string clas_bill, string mantimepost, string bkdaypost, string maxterutn, string cir_return, string noofchkbounc, string noofdaychkrec, string retday, string chngsuppord, string max_publishday, string billno_period, string spl_trans_edit, string spl_dis_trans_editable, string mul_pac_sel_trans, string shmon_minword, string tradon_spcrg, string rateauth, string f2day, string rateauditmodify, string bindrevenuecenter, string led_allow, string clear_allow, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER, string allow_discount_prem, string scheme_billing, string ALLOW_PDC, string ad_type_for_manul_bill, string RO_OUTSTAND_P, string genrate_agency_code, string dispauditbk)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_updatedate1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                ////////////////////////////////////////////////////////////////////

                objSqlCommand.Parameters.Add("@copybooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@copybooking"].Value = copybooking;

                objSqlCommand.Parameters.Add("@ratecompany", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecompany"].Value = ratecomp;

                objSqlCommand.Parameters.Add("@addagenycomm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagenycomm"].Value = addagencycomm;

                objSqlCommand.Parameters.Add("@agencycommlinkretainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycommlinkretainer"].Value = agencyretcomm;

                objSqlCommand.Parameters.Add("@subeditionr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subeditionr"].Value = subrate;

                objSqlCommand.Parameters.Add("@displaybilltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@displaybilltype"].Value = displaybilltype;

                objSqlCommand.Parameters.Add("@classifiedbilltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@classifiedbilltype"].Value = classifiedbilltype;



                /////////////////////////////////////////////////////////////////////////////


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@curr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@curr"].Value = curr;

                objSqlCommand.Parameters.Add("@solo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@solo"].Value = solo;

                objSqlCommand.Parameters.Add("@breakup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@breakup"].Value = breakup;

                objSqlCommand.Parameters.Add("@bwcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bwcode"].Value = bwcode;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;


                objSqlCommand.Parameters.Add("@insertbreak", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertbreak"].Value = insertbreak;

                objSqlCommand.Parameters.Add("@prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prem"].Value = prem;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@pre", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pre"].Value = pre;


                objSqlCommand.Parameters.Add("@suff", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suff"].Value = suff;


                objSqlCommand.Parameters.Add("@financestatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@financestatus"].Value = chkfinancestatus;


                objSqlCommand.Parameters.Add("@voucherst", SqlDbType.VarChar);
                objSqlCommand.Parameters["@voucherst"].Value = voucherst;

                objSqlCommand.Parameters.Add("@adcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcode"].Value = adcode;

                objSqlCommand.Parameters.Add("@rodatetime", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rodatetime"].Value = rodatetime;

                objSqlCommand.Parameters.Add("@spacearea", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spacearea"].Value = spacearea;

                objSqlCommand.Parameters.Add("@vat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat"].Value = vat;



                objSqlCommand.Parameters.Add("@bookstat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookstat"].Value = bookstat;

                objSqlCommand.Parameters.Add("@cio_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_id"].Value = cio_id;


                objSqlCommand.Parameters.Add("@receipt_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receipt_no"].Value = receipt_no;

                /*new change ankur*/
                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;


                objSqlCommand.Parameters.Add("@validdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validdate"].Value = validdate;



                objSqlCommand.Parameters.Add("@agencyratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyratecode"].Value = agencyratecode;

                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@book_insert_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@book_insert_date"].Value = insert_date;

                objSqlCommand.Parameters.Add("@agencycomm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycomm"].Value = agencycomm;

                objSqlCommand.Parameters.Add("@rateaudit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateaudit"].Value = rateaudit;

                objSqlCommand.Parameters.Add("@billaudit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaudit"].Value = billaudit;

                objSqlCommand.Parameters.Add("@billtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billtype"].Value = billtype;

                objSqlCommand.Parameters.Add("@invoice_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@invoice_no"].Value = invoice_no;


                ///////change bhanu

                objSqlCommand.Parameters.Add("@billformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billformat"].Value = billformat;

                objSqlCommand.Parameters.Add("@ratechk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratechk"].Value = ratechk;

                objSqlCommand.Parameters.Add("@allpkg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allpkg"].Value = allpkg;

                objSqlCommand.Parameters.Add("@dayrate1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dayrate1"].Value = dayrate;

                objSqlCommand.Parameters.Add("@schemetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemetype"].Value = schemetype;

                objSqlCommand.Parameters.Add("@PIncludeclassi", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PIncludeclassi"].Value = Includeclassi;

                objSqlCommand.Parameters.Add("@receiptformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptformat"].Value = receiptformat;

                objSqlCommand.Parameters.Add("@cash_receipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_receipt"].Value = cash_receipt;

                objSqlCommand.Parameters.Add("@bill_orderwiselast", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bill_orderwiselast"].Value = bill_orderwiselast;


                objSqlCommand.Parameters.Add("@floor_chk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@floor_chk"].Value = floor_chk;

                //for circulation
                objSqlCommand.Parameters.Add("@Unsoldflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Unsoldflag"].Value = Unsoldflag;


                objSqlCommand.Parameters.Add("@Supplystopper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Supplystopper"].Value = Supplystopper;

                objSqlCommand.Parameters.Add("@drpRokeychk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpRokeychk"].Value = drpRokeychk;


                objSqlCommand.Parameters.Add("@Agencycomm_seq", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Agencycomm_seq"].Value = Agencycomm_seq;


                objSqlCommand.Parameters.Add("@creditreciept", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditreciept"].Value = creditreciept;

                objSqlCommand.Parameters.Add("@cashindisplay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cashindisplay"].Value = cashindisplay;


                objSqlCommand.Parameters.Add("@cashinclassified", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cashinclassified"].Value = cashinclassified;


                objSqlCommand.Parameters.Add("@rate_audit_pref", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_audit_pref"].Value = rate_audit_pref;

                objSqlCommand.Parameters.Add("@v_barcoding_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_barcoding_allow"].Value = barcoding_allow;


                objSqlCommand.Parameters.Add("@v_fmgbills", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_fmgbills"].Value = fmgbills;



                objSqlCommand.Parameters.Add("@v_billed_cashdis", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_billed_cashdis"].Value = billed_cashdis;



                objSqlCommand.Parameters.Add("@v_billed_cashcls", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_billed_cashcls"].Value = billed_cashcls;



                objSqlCommand.Parameters.Add("@v_drpbackdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_drpbackdate"].Value = v_drpbackdate;

                objSqlCommand.Parameters.Add("@dockitbooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitbooking"].Value = dockitbooking;

                objSqlCommand.Parameters.Add("@allowprevbooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allowprevbooking"].Value = allowprevbooking;

                objSqlCommand.Parameters.Add("@chkval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkval"].Value = chkval;

                objSqlCommand.Parameters.Add("@ro_wisecashbill", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ro_wisecashbill"].Value = cash_billtype;

                objSqlCommand.Parameters.Add("@approval1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approval1"].Value = approval;

                objSqlCommand.Parameters.Add("@pckstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pckstatus"].Value = pckstatus;

                objSqlCommand.Parameters.Add("@cash_disc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_disc"].Value = cash_disc;

                objSqlCommand.Parameters.Add("@cash_amt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cash_amt"].Value = cash_amt;

                objSqlCommand.Parameters.Add("@seperate_cashier1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seperate_cashier1"].Value = seperate_cashier;

                objSqlCommand.Parameters.Add("@disp_bill", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disp_bill"].Value = disp_bill;

                objSqlCommand.Parameters.Add("@clas_bill", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clas_bill"].Value = clas_bill;

                objSqlCommand.Parameters.Add("@mantimepost", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mantimepost"].Value = mantimepost;

                objSqlCommand.Parameters.Add("@bkdaypost", SqlDbType.Int);
                if (bkdaypost == "" || bkdaypost == null)
                {
                    objSqlCommand.Parameters["@bkdaypost"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bkdaypost"].Value =Convert.ToInt32(bkdaypost);
                }

                objSqlCommand.Parameters.Add("@maxterutn", SqlDbType.VarChar);
                if (maxterutn == "" || maxterutn == null)
                {
                    objSqlCommand.Parameters["@maxterutn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@maxterutn"].Value = Convert.ToInt32(maxterutn);
                }

                objSqlCommand.Parameters.Add("@cir_return", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cir_return"].Value = cir_return;

                objSqlCommand.Parameters.Add("@noofchkbounc", SqlDbType.VarChar);
                if (noofchkbounc == "" || noofchkbounc == null)
                {
                    objSqlCommand.Parameters["@noofchkbounc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofchkbounc"].Value = Convert.ToInt32(noofchkbounc);
                }

                objSqlCommand.Parameters.Add("@noofdaychkrec", SqlDbType.VarChar);
                if (noofdaychkrec == "" || noofdaychkrec == null)
                {
                    objSqlCommand.Parameters["@noofdaychkrec"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofdaychkrec"].Value = Convert.ToInt32(noofdaychkrec);
                }

                objSqlCommand.Parameters.Add("@retday", SqlDbType.VarChar);
                if (retday == "" || retday == null)
                {
                    objSqlCommand.Parameters["@retday"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@retday"].Value = Convert.ToInt32(retday);
                }

                objSqlCommand.Parameters.Add("@chngsuppord", SqlDbType.VarChar);
                if (chngsuppord == "" || chngsuppord == null)
                {
                    objSqlCommand.Parameters["@chngsuppord"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@chngsuppord"].Value = Convert.ToInt32(chngsuppord);
                }

                objSqlCommand.Parameters.Add("@max_publishday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@max_publishday"].Value = max_publishday;


                objSqlCommand.Parameters.Add("@p_billno_period", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_billno_period"].Value = billno_period;

                objSqlCommand.Parameters.Add("@spl_trans_edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spl_trans_edit"].Value = spl_trans_edit;

                objSqlCommand.Parameters.Add("@spl_dis_trans_editable", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spl_dis_trans_editable"].Value = spl_dis_trans_editable;

                objSqlCommand.Parameters.Add("@mul_pac_sel_trans", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mul_pac_sel_trans"].Value = mul_pac_sel_trans; 

                objSqlCommand.Parameters.Add("@shmon_minword", SqlDbType.VarChar);
                objSqlCommand.Parameters["@shmon_minword"].Value = shmon_minword;

                objSqlCommand.Parameters.Add("@tradon_spcrg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tradon_spcrg"].Value = tradon_spcrg;

                objSqlCommand.Parameters.Add("@rateauth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateauth"].Value = rateauth;

                objSqlCommand.Parameters.Add("@f2day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@f2day"].Value = f2day;

                objSqlCommand.Parameters.Add("@rateauditmodify", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateauditmodify"].Value = rateauditmodify;

                objSqlCommand.Parameters.Add("@bindrevenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bindrevenuecenter"].Value = bindrevenuecenter;


                objSqlCommand.Parameters.Add("@p_led_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_led_allow"].Value = led_allow;

                objSqlCommand.Parameters.Add("@p_clear_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_clear_allow"].Value = clear_allow;

                objSqlCommand.Parameters.Add("@repeatday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatday"].Value = repeatday;

                objSqlCommand.Parameters.Add("@premiumedit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premiumedit"].Value = premiumedit;

                objSqlCommand.Parameters.Add("@P_BILL_GENERATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_BILL_GENERATION"].Value = BILL_GENERATION;

                objSqlCommand.Parameters.Add("@P_PUBLICATION_CENTER", SqlDbType.VarChar);
                if (PUBLICATION_CENTER == "0")
                {
                    objSqlCommand.Parameters["@P_PUBLICATION_CENTER"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@P_PUBLICATION_CENTER"].Value = PUBLICATION_CENTER;
                }


                objSqlCommand.Parameters.Add("@P_allow_discount_prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_allow_discount_prem"].Value = allow_discount_prem;


               objSqlCommand.Parameters.Add("@P_SCHEME_BILLING", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_SCHEME_BILLING"].Value = scheme_billing;


                objSqlCommand.Parameters.Add("@P_ALLOW_PDC", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ALLOW_PDC"].Value = ALLOW_PDC;



                objSqlCommand.Parameters.Add("@PAD_TYPE_FOR_MANUL_BILL", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PAD_TYPE_FOR_MANUL_BILL"].Value = ad_type_for_manul_bill;



                objSqlCommand.Parameters.Add("@RO_OUTSTAND_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RO_OUTSTAND_P"].Value = RO_OUTSTAND_P;

                objSqlCommand.Parameters.Add("@genrate_agency_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@genrate_agency_code"].Value = genrate_agency_code;

                objSqlCommand.Parameters.Add("@p_dispauditbk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_dispauditbk"].Value = dispauditbk;
                

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }



            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        //********************************To check whether entry for company code exist*****************

        public DataSet datechkprefer(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_chkdateprefer", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }



        public DataSet currbind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("currbindprefer", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;





                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }


        }
        public DataSet ratebindprefer(string compcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("bindrateforprefer", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;


                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;



                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }

        }


        public DataSet currbindpgld(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("currbindpreferpgld", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }


        }

        //GetData is used to retrieve the custcode from customer master
        public DataSet getData(string clientcode, string userid, string compcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("Clientpayselect", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;



                sqlcomm.Parameters.Add("@custcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@custcode"].Value = clientcode;
                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;
                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;
                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
        }

        public DataSet chkData(string clientcode, string userid, string compcode, int flag)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("Clientchkpaymode", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Add("@flag", SqlDbType.VarChar);
                sqlcomm.Parameters["@flag"].Value = flag;
                sqlcomm.Parameters.Add("@custcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@custcode"].Value = clientcode;
                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;
                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;
                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
        }

        //insert Data is used to insert/update values into payment table

        public void insertData(string compcode, string custcode, string userid, int i, params string[] strMode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("updateClientPay", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@Cash", SqlDbType.VarChar);
                sqlcomm.Parameters["@Cash"].Value = strMode[0];
                sqlcomm.Parameters.Add("@Credit", SqlDbType.VarChar);
                sqlcomm.Parameters["@Credit"].Value = strMode[1];
                sqlcomm.Parameters.Add("@Bank", SqlDbType.VarChar);
                sqlcomm.Parameters["@Bank"].Value = strMode[2];
                sqlcomm.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                sqlcomm.Parameters["@Comp_Code"].Value = compcode;
                sqlcomm.Parameters.Add("@Client_Code", SqlDbType.VarChar);
                sqlcomm.Parameters["@Client_Code"].Value = custcode;
                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;
                sqlcomm.Parameters.Add("@Flag", SqlDbType.VarChar);
                sqlcomm.Parameters["@Flag"].Value = i;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref sqlcon); }
        }

        public DataSet collectadvtype(string compcode, string userid, string date)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("bindadtypeforstatus", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;


                sqlcomm.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                sqlcomm.Parameters["@Comp_Code"].Value = compcode;

                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;

                sqlcomm.Parameters.Add("@date", SqlDbType.VarChar);
                sqlcomm.Parameters["@date"].Value = date;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref sqlcon); }

        }




        //public DataSet insertpay(string agencycode, string compcode, string userid, string agencysubcode, params string[] strMode)
        public DataSet insertpay(string agencycode, string compcode, string userid, string agencysubcode, string cash)
        {
            SqlConnection objSqlConnection;
            SqlCommand sqlcomm;
            objSqlConnection = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();

            DataSet objDataSet = new DataSet();
            try
            {
                sqlcomm = GetCommand("websp_insertpay", ref objSqlConnection);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@Cash", SqlDbType.VarChar);
                sqlcomm.Parameters["@Cash"].Value = cash;
                //sqlcomm.Parameters.Add("@Credit", SqlDbType.VarChar);
                //sqlcomm.Parameters["@Credit"].Value = strMode[1];
                //sqlcomm.Parameters.Add("@Bank", SqlDbType.VarChar);
                //sqlcomm.Parameters["@Bank"].Value = strMode[2];
                sqlcomm.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                sqlcomm.Parameters["@Comp_Code"].Value = compcode;
                sqlcomm.Parameters.Add("@Agency_Code", SqlDbType.VarChar);
                sqlcomm.Parameters["@Agency_Code"].Value = agencycode;
                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;
                sqlcomm.Parameters.Add("@Agency_subcat_code", SqlDbType.VarChar);
                sqlcomm.Parameters["@Agency_subcat_code"].Value = agencysubcode;

                da.SelectCommand = sqlcomm;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return (ds);

            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        //************to update agent paymode****************************8
        public DataSet payinsert(string agencycode, string compcode, string userid, string agencysubcode, string code)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            ;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();

                objSqlCommand = GetCommand("websp_updatepay", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@Cash", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Cash"].Value = code;
                //objSqlCommand.Parameters.Add("@Credit", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@Credit"].Value = strMode[1];
                //objSqlCommand.Parameters.Add("@Bank", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@Bank"].Value = strMode[2];


                objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_Code"].Value = compcode;

                objSqlCommand.Parameters.Add("@Agency_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Agency_Code"].Value = agencycode;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;
                objSqlCommand.Parameters.Add("@Agency_subcat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Agency_subcat_code"].Value = agencysubcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet getpay(string agencycode, string compcode, string userid, string agencysubcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("agentpayselect", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;
                sqlcomm.Parameters.Add("@agencycode", SqlDbType.VarChar);
                sqlcomm.Parameters["@agencycode"].Value = agencycode;



                sqlcomm.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@agencysubcode"].Value = agencysubcode;
                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;
                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
        }

        public DataSet productbind12(string compcode, string userid,string clientcode,string agencycode,string agencysubcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("contactproduct", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;

                sqlcomm.Parameters.Add("@clientcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@clientcode"].Value = clientcode;

                //sqlcomm.Parameters.Add("@agencycode", SqlDbType.VarChar);
                //sqlcomm.Parameters["@agencycode"].Value = agencycode;

                //sqlcomm.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                //sqlcomm.Parameters["@agencysubcode"].Value = agencysubcode;
                
                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;
                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
        }


        public DataSet productbind(string compcode, string userid)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("contactproductcontact", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;

                //sqlcomm.Parameters.Add("@clientcode", SqlDbType.VarChar);
                //sqlcomm.Parameters["@clientcode"].Value = clientcode;

                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;
                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
        }



        public DataSet clientbind(string compcode, string userid)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("listbindclient", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;

                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;
                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
        }


        public DataSet buttonbind(string compcode, string userid,string code)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("contactdetailbind", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;

                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;

                sqlcomm.Parameters.Add("@code", SqlDbType.VarChar);
                sqlcomm.Parameters["@code"].Value = code;
                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
        }





        public DataSet getthevalue(string contactperson, string agencycode, string subagencycode, string compcode, string userid)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("updatevalueintable", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;

                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;

                sqlcomm.Parameters.Add("@contactperson", SqlDbType.VarChar);
                sqlcomm.Parameters["@contactperson"].Value = contactperson;

                sqlcomm.Parameters.Add("@agencycode", SqlDbType.VarChar);
                sqlcomm.Parameters["@agencycode"].Value = agencycode;

                sqlcomm.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                sqlcomm.Parameters["@subagencycode"].Value = subagencycode;

                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
            
        }

        public DataSet detailofcontact(string compcode, string userid, string contactcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("getcontactvalue", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;

                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;

                sqlcomm.Parameters.Add("@contactcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@contactcode"].Value = contactcode;

                
                

                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
        }

        public DataSet contactname(string conname, string agencycode, string subagency, string compcode, string userid)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("getcontactname", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;

                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;

                sqlcomm.Parameters.Add("@conname", SqlDbType.VarChar);
                sqlcomm.Parameters["@conname"].Value = conname;

                sqlcomm.Parameters.Add("@agencycode", SqlDbType.VarChar);
                sqlcomm.Parameters["@agencycode"].Value = agencycode;

                sqlcomm.Parameters.Add("@subagency", SqlDbType.VarChar);
                sqlcomm.Parameters["@subagency"].Value = subagency;





                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;
            
        }

        public DataSet clientvalue(string conname,string compcode, string userid, string agencycode, string subagency)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("getclientfromcontact", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;

                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;

                sqlcomm.Parameters.Add("@conname", SqlDbType.VarChar);
                sqlcomm.Parameters["@conname"].Value = conname;

                sqlcomm.Parameters.Add("@agencycode", SqlDbType.VarChar);
                sqlcomm.Parameters["@agencycode"].Value = agencycode;

                sqlcomm.Parameters.Add("@subagency", SqlDbType.VarChar);
                sqlcomm.Parameters["@subagency"].Value = subagency;





                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
            return ds;

        }

        public DataSet ratebind(string compcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("bindrateforpreferrence", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;


                sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcomm.Parameters["@compcode"].Value = compcode;



                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref sqlcon); }

        }

        public DataSet insMasterPrev(string name, string prev, string formname, string modulename, string userid, string compcode, string division, string moduleno, string formid, string rostatusval)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_insertModuleDetailchk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                //objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@name"].Value = name;

                objSqlCommand.Parameters.Add("@modulename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@modulename"].Value = modulename;

                objSqlCommand.Parameters.Add("@division", SqlDbType.VarChar);
                objSqlCommand.Parameters["@division"].Value = division;

                objSqlCommand.Parameters.Add("@prev", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prev"].Value = prev;

                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@moduleno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@moduleno"].Value = moduleno;

                objSqlCommand.Parameters.Add("@pback_days", SqlDbType.VarChar);
                if (rostatusval == "")
                    objSqlCommand.Parameters["@pback_days"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@pback_days"].Value = rostatusval;




                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet getuserinfo(string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_getuserinfo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet checkBgno(string bgno,string bgname)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_chkBgNo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@bgno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgno"].Value = bgno;

                objSqlCommand.Parameters.Add("@bgname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgname"].Value = bgname;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet statusdatecheck(string drpstatus, string txtfrom, string txtto, string compcode, string userid, string agencycode, string agencysubcode, string dateformat)
         {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("statusdatecheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@drpstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpstatus"].Value = drpstatus;

                objSqlCommand.Parameters.Add("@txtfrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtfrom"].Value = txtfrom;

                objSqlCommand.Parameters.Add("@txtto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtto"].Value = txtto;

          
                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;
                
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet MastPrevDisp_user(string compcode, string userid, string userhome, string admin, string retainer, string username)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_ModultPrevDisp_user", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@userhome", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userhome"].Value = userhome;

                objSqlCommand.Parameters.Add("@admin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@admin"].Value = admin;

                objSqlCommand.Parameters.Add("@retainer_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer_code"].Value = retainer;

                objSqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                objSqlCommand.Parameters["@username"].Value = username;

                objSqlCommand.Parameters.Add("@p_extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@p_extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra2"].Value = System.DBNull.Value;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        /////////bhanu date chk

        public DataSet datechk(string sf, string st, string txtfrom, string txtto, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("datechk_b", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@sf", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = sf.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    sf = yy + "/" + mm + "/" + dd;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = sf.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        sf = yy + "/" + mm + "/" + dd;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = sf.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            sf = yy + "/" + mm + "/" + dd;
                        }
                objSqlCommand.Parameters["@sf"].Value = sf;

                objSqlCommand.Parameters.Add("@st", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = st.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    st = yy + "/" + mm + "/" + dd;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = st.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        st = yy + "/" + mm + "/" + dd;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = st.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            st = yy + "/" + mm + "/" + dd;
                        }
                objSqlCommand.Parameters["@st"].Value = st;

                objSqlCommand.Parameters.Add("@txtfrom", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = txtfrom.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    txtfrom = yy + "/" + mm + "/" + dd;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = txtfrom.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        txtfrom = yy + "/" + mm + "/" + dd;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = txtfrom.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            txtfrom = yy + "/" + mm + "/" + dd;
                        }
                objSqlCommand.Parameters["@txtfrom"].Value = txtfrom;

                objSqlCommand.Parameters.Add("@txtto", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = txtto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    txtto = yy + "/" + mm + "/" + dd;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = txtto.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        txtto = yy + "/" + mm + "/" + dd;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = txtto.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            txtto = yy + "/" + mm + "/" + dd ;
                        }
                objSqlCommand.Parameters["@txtto"].Value = txtto;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        /////end bhanu


        
    }














    

    }

