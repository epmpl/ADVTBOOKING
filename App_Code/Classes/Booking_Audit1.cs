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

namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for Booking_Audit1
    /// </summary>
    public class Booking_Audit1 :connection
    {
        public Booking_Audit1()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet getsection(string sectionname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getSectionCode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@name_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name_p"].Value = sectionname;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }


        public DataSet bindbranch_userwise(string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_branch_branchwise", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }


        public DataSet bookingdetailgrid(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bookingdetailgrid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public DataSet bindgrid(string dateformat, string tilldate, string fromdate, string branch1, string adtype, string audittype, string branch2, string abc_cat, string userid, string comp_code, string package_code, string agency_code, string client_code, string section_code, string booktype, string uom, string datebased,string Booking_Id)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bindaudit", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;



                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@fromdate"].Value = fromdate;
                }


                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = tilldate;
                }





                com.Parameters.Add("@branch1", SqlDbType.VarChar);
                com.Parameters["@branch1"].Value = branch1;

                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                com.Parameters["@adtype"].Value = adtype;

                com.Parameters.Add("@branch2", SqlDbType.VarChar);
                if (branch2 != "0" && branch2 != "--Select Branch--" && branch2 != "")
                {
                    com.Parameters["@branch2"].Value = branch2;
                }
                else
                {
                    com.Parameters["@branch2"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@v_Cat", SqlDbType.VarChar);
                if (abc_cat == "0")
                {
                    com.Parameters["@v_Cat"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_Cat"].Value = abc_cat;
                }


                com.Parameters.Add("@v_userid", SqlDbType.VarChar);
                com.Parameters["@v_userid"].Value = userid;



                com.Parameters.Add("@audittype", SqlDbType.VarChar);
                com.Parameters["@audittype"].Value = audittype;

                com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                com.Parameters["@comp_code"].Value = comp_code;


                com.Parameters.Add("@v_package_code", SqlDbType.VarChar);

                if (package_code == "0" || package_code == "")
                {
                    com.Parameters["@v_package_code"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_package_code"].Value = package_code;

                }   


                com.Parameters.Add("@pagency_code", SqlDbType.VarChar);
                if (agency_code == "0" || agency_code == "")
                {
                    com.Parameters["@pagency_code"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@pagency_code"].Value = agency_code;

                }

                com.Parameters.Add("@pclient_code", SqlDbType.VarChar);
                if (client_code == "0" || client_code == "")
                {
                    com.Parameters["@pclient_code"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@pclient_code"].Value = client_code;

                }

                com.Parameters.Add("@psection_code", SqlDbType.VarChar);
                if (section_code == "0" || section_code == "")
                {
                    com.Parameters["@psection_code"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@psection_code"].Value = section_code;

                }

                com.Parameters.Add("@p_booktype", SqlDbType.VarChar);
                com.Parameters["@p_booktype"].Value = booktype;

                com.Parameters.Add("@extra1", SqlDbType.VarChar);
                if (uom == "0" || uom == "")
                    com.Parameters["@extra1"].Value = System.DBNull.Value;
                else
                    com.Parameters["@extra1"].Value = uom;

                com.Parameters.Add("@extra2", SqlDbType.VarChar);
                com.Parameters["@extra2"].Value = datebased;

                com.Parameters.Add("@extra3", SqlDbType.VarChar);
                com.Parameters["@extra3"].Value = Booking_Id;

                com.Parameters.Add("@extra4", SqlDbType.VarChar);
                com.Parameters["@extra4"].Value = System.DBNull.Value;
                

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        public DataSet executeauditmast1(string bookingid, string compcode, string adtype, string dateformat,string insertion)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("executebooking_new1", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                com.Parameters["@ciobookid"].Value = bookingid;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;


                com.Parameters.Add("@docno", SqlDbType.VarChar);
                com.Parameters["@docno"].Value = insertion;

                com.Parameters.Add("@keyno", SqlDbType.VarChar);
                com.Parameters["@keyno"].Value = System.DBNull.Value;



                  com.Parameters.Add("@rono", SqlDbType.VarChar);
                  com.Parameters["@rono"].Value = System.DBNull.Value;

                com.Parameters.Add("@agencycode", SqlDbType.VarChar);
                com.Parameters["@agencycode"].Value = System.DBNull.Value;


                 com.Parameters.Add("@client", SqlDbType.VarChar);
                 com.Parameters["@client"].Value = System.DBNull.Value;



                  com.Parameters.Add("@booking", SqlDbType.VarChar);
                  com.Parameters["@booking"].Value = adtype;

                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;


                com.Parameters.Add("@revenue", SqlDbType.VarChar);
                com.Parameters["@revenue"].Value = System.DBNull.Value;
            


                

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

        }

        public DataSet adtypbind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("advtypbind", ref objSqlConnection);
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
        public DataSet getPubCenter(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_QBC", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
       public void updateaudit(string cioid,string auditname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            objSqlConnection.Open();
            
            try
            {

                objSqlCommand = GetCommand("updateauditbooking", ref objSqlConnection);  
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;
                objSqlCommand.Parameters.Add("@auditname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auditname"].Value = auditname;
                 SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlCommand.ExecuteNonQuery();
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
        public DataSet getComparison(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("comparebookingaudit", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
        public DataSet websp_bindgrid(string dateformat, string tilldate, string fromdate, string branch, string adtype, string publication, string pub_cent, string edition, string agency, string client, string branchnew, string retainer, string executive, string supplement, string insert_status, string uom, string userid, string Booking_Id)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_bindaudit", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;

                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@fromdate"].Value = fromdate;
                }


                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = tilldate;
                }



                com.Parameters.Add("@branch", SqlDbType.VarChar);
                com.Parameters["@branch"].Value = branch;

                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                com.Parameters["@adtype"].Value = adtype;


                com.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication == "0")
                {
                    com.Parameters["@publication"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@publication"].Value = publication;
                }




                com.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pub_cent == "0")
                {
                    com.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@pub_cent"].Value = pub_cent;
                }






                com.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0")
                {
                    com.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@edition"].Value = edition;
                }


                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency == "0")
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@agency"].Value = agency;
                }





                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client == "0")
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@client"].Value = client;
                }






                com.Parameters.Add("@branchnew", SqlDbType.VarChar);
                if ((branchnew == "") || (branchnew == "0"))
                {
                    com.Parameters["@branchnew"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@branchnew"].Value = branchnew;
                }





                com.Parameters.Add("@v_retainer", SqlDbType.VarChar);
                if (retainer == "0")
                {
                    com.Parameters["@v_retainer"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_retainer"].Value = retainer;
                }





                com.Parameters.Add("@v_executive", SqlDbType.VarChar);
                if (executive == "0")
                {
                    com.Parameters["@v_executive"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_executive"].Value = executive;
                }







                com.Parameters.Add("@v_supplement", SqlDbType.VarChar);
                if (supplement == "")
                {
                    com.Parameters["@v_supplement"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_supplement"].Value = supplement;
                }

                com.Parameters.Add("@v_insert_status", SqlDbType.VarChar);
                if (insert_status == "0")
                {
                    com.Parameters["@v_insert_status"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_insert_status"].Value = insert_status;
                }

                com.Parameters.Add("@puom_code", SqlDbType.VarChar);
                if (uom == "0" || uom == "")
                    com.Parameters["@puom_code"].Value = System.DBNull.Value;
                else
                    com.Parameters["@puom_code"].Value = uom;


                com.Parameters.Add("@v_userid", SqlDbType.VarChar);
                //if (uom == "0" || uom == "")
                //    com.Parameters["@puom_code"].Value = System.DBNull.Value;
                //else
                com.Parameters["@v_userid"].Value = userid;

                com.Parameters.Add("@p_bkid", SqlDbType.VarChar);
                com.Parameters["@p_bkid"].Value = Booking_Id;


                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet executeauditmast2(string bookingid, string compcode, string edition, string insertion)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("executebooking2", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                com.Parameters["@ciobookid"].Value = bookingid;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@edition", SqlDbType.VarChar);
                com.Parameters["@edition"].Value = edition;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;



                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

        }

        public DataSet updatestatus(string bookingid, string insertion, string edition)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("updatestaus", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                com.Parameters["@ciobookid"].Value = bookingid;


                com.Parameters.Add("@edition", SqlDbType.VarChar);
                com.Parameters["@edition"].Value = edition;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;



                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

        }
    }
}