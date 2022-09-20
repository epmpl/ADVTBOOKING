using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for webbooking
/// </summary>
/// 

namespace NewAdbooking.Classes
{
    public class webbooking:connection
    {
        public webbooking()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet savegeo(string country,string state,string city,string edition,string cio_book_id,string noinsert,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("geographical", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;


                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;


                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;


                objSqlCommand.Parameters.Add("@cio_booking_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_booking_id"].Value = cio_book_id;


                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noinsert;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compcode;



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




        public DataSet savedays(string Rotation, string Priority, string Sunday, string Sunday_From, string Sunday_To, string Monday, string Monday_From, string Monday_To, string Tuesday, string Tuesday_From, string Tuesday_To, string Wedneday, string Wedneday_From, string Wednesday_To, string Thursday, string Thursday_From, string Thursday_To, string Friday, string Friday_From, string Friday_To, string Saturday, string Saturday_From, string Saturday_To, string Demog_sex, string Demog_agegroup, string Demog_Occup, string Demog_inter, string ciobookingid, string noofinsert, string compcode, string edition,string uom,string premium,string adcatcode,string date_time,string interest)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertbookingdays", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@Rotation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Rotation"].Value = Rotation;


                objSqlCommand.Parameters.Add("@Priority", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Priority"].Value = Priority;


                objSqlCommand.Parameters.Add("@Sunday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Sunday"].Value = Sunday;


                objSqlCommand.Parameters.Add("@Sunday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Sunday_From"].Value = Sunday_From;


                objSqlCommand.Parameters.Add("@Sunday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Sunday_To"].Value = Sunday_To;


                objSqlCommand.Parameters.Add("@Monday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Monday"].Value = Monday;

                objSqlCommand.Parameters.Add("@Monday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Monday_From"].Value = Monday_From;



                objSqlCommand.Parameters.Add("@Monday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Monday_To"].Value = Monday_To;



                objSqlCommand.Parameters.Add("@Tuesday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Tuesday"].Value = Tuesday;

                objSqlCommand.Parameters.Add("@Tuesday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Tuesday_From"].Value = Tuesday_From;



                objSqlCommand.Parameters.Add("@Tuesday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Tuesday_To"].Value = Tuesday_To;





                objSqlCommand.Parameters.Add("@Wednesday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Wednesday"].Value = Wedneday;

                objSqlCommand.Parameters.Add("@Wednesday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Wednesday_From"].Value = Wedneday_From;



                objSqlCommand.Parameters.Add("@Wednesday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Wednesday_To"].Value = Wednesday_To;






                objSqlCommand.Parameters.Add("@Thursday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Thursday"].Value = Thursday;

                objSqlCommand.Parameters.Add("@Thursday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Thursday_From"].Value = Thursday_From;



                objSqlCommand.Parameters.Add("@Thursday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Thursday_To"].Value = Thursday_To;





                objSqlCommand.Parameters.Add("@Friday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Friday"].Value = Friday;

                objSqlCommand.Parameters.Add("@Friday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Friday_From"].Value = Friday_From;



                objSqlCommand.Parameters.Add("@Friday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Friday_To"].Value = Friday_To;




                objSqlCommand.Parameters.Add("@Saturday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Saturday"].Value = Saturday;

                objSqlCommand.Parameters.Add("@Saturday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Saturday_From"].Value = Saturday_From;



                objSqlCommand.Parameters.Add("@Saturday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Saturday_To"].Value = Saturday_To;



                objSqlCommand.Parameters.Add("@Demog_sex", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Demog_sex"].Value = Demog_sex;


                objSqlCommand.Parameters.Add("@Demog_agegroup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Demog_agegroup"].Value = Demog_agegroup;


                objSqlCommand.Parameters.Add("@Demog_Occup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Demog_Occup"].Value = Demog_Occup;

                objSqlCommand.Parameters.Add("@Demog_inter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Demog_inter"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@Comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_code"].Value = compcode; 



                objSqlCommand.Parameters.Add("@cioBookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioBookingid"].Value = ciobookingid;



                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noofinsert;



                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;



                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;



                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;



                objSqlCommand.Parameters.Add("@ad_cat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_code"].Value = adcatcode;



                objSqlCommand.Parameters.Add("@date_time", SqlDbType.VarChar);


                string dateformat = "dd/mm/yyyy";
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = date_time.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    date_time = mm + "/" + dd + "/" + yy;
                }





                objSqlCommand.Parameters["@date_time"].Value = date_time;


                objSqlCommand.Parameters.Add("@interest", SqlDbType.VarChar);
                objSqlCommand.Parameters["@interest"].Value = interest;




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





        public DataSet savedays123(string Rotation, string Priority, string Sunday, string Sunday_From, string Sunday_To, string Monday, string Monday_From, string Monday_To, string Tuesday, string Tuesday_From, string Tuesday_To, string Wedneday, string Wedneday_From, string Wednesday_To, string Thursday, string Thursday_From, string Thursday_To, string Friday, string Friday_From, string Friday_To, string Saturday, string Saturday_From, string Saturday_To, string Demog_sex, string Demog_agegroup, string Demog_Occup, string Demog_inter, string ciobookingid, string noofinsert, string compcode, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("modifyinsertbookingdays", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@Rotation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Rotation"].Value = Rotation;


                objSqlCommand.Parameters.Add("@Priority", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Priority"].Value = Priority;


                objSqlCommand.Parameters.Add("@Sunday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Sunday"].Value = Sunday;


                objSqlCommand.Parameters.Add("@Sunday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Sunday_From"].Value = Sunday_From;


                objSqlCommand.Parameters.Add("@Sunday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Sunday_To"].Value = Sunday_To;


                objSqlCommand.Parameters.Add("@Monday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Monday"].Value = Monday;

                objSqlCommand.Parameters.Add("@Monday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Monday_From"].Value = Monday_From;



                objSqlCommand.Parameters.Add("@Monday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Monday_To"].Value = Monday_To;



                objSqlCommand.Parameters.Add("@Tuesday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Tuesday"].Value = Tuesday;

                objSqlCommand.Parameters.Add("@Tuesday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Tuesday_From"].Value = Tuesday_From;



                objSqlCommand.Parameters.Add("@Tuesday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Tuesday_To"].Value = Tuesday_To;





                objSqlCommand.Parameters.Add("@Wednesday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Wednesday"].Value = Wedneday;

                objSqlCommand.Parameters.Add("@Wednesday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Wednesday_From"].Value = Wedneday_From;



                objSqlCommand.Parameters.Add("@Wednesday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Wednesday_To"].Value = Wednesday_To;






                objSqlCommand.Parameters.Add("@Thursday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Thursday"].Value = Thursday;

                objSqlCommand.Parameters.Add("@Thursday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Thursday_From"].Value = Thursday_From;



                objSqlCommand.Parameters.Add("@Thursday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Thursday_To"].Value = Thursday_To;





                objSqlCommand.Parameters.Add("@Friday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Friday"].Value = Friday;

                objSqlCommand.Parameters.Add("@Friday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Friday_From"].Value = Friday_From;



                objSqlCommand.Parameters.Add("@Friday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Friday_To"].Value = Friday_To;




                objSqlCommand.Parameters.Add("@Saturday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Saturday"].Value = Saturday;

                objSqlCommand.Parameters.Add("@Saturday_From", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Saturday_From"].Value = Saturday_From;



                objSqlCommand.Parameters.Add("@Saturday_To", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Saturday_To"].Value = Saturday_To;



                objSqlCommand.Parameters.Add("@Demog_sex", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Demog_sex"].Value = Demog_sex;


                objSqlCommand.Parameters.Add("@Demog_agegroup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Demog_agegroup"].Value = Demog_agegroup;


                objSqlCommand.Parameters.Add("@Demog_Occup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Demog_Occup"].Value = Demog_Occup;

                objSqlCommand.Parameters.Add("@Demog_inter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Demog_inter"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@Comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_code"].Value = compcode;



                objSqlCommand.Parameters.Add("@cioBookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioBookingid"].Value = ciobookingid;



                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noofinsert;



                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;










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









        public DataSet savegeo12(string country, string state, string city, string edition, string cio_book_id, string noinsert, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("modifygeographical", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;


                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;


                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;


                objSqlCommand.Parameters.Add("@cio_booking_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_booking_id"].Value = cio_book_id;


                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noinsert;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compcode;



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







        public string webmaterial(string cioid, string imagefile, string imagename, string url, string filename, string Comp_code, string NO_INSERT, string EDITION)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            //  SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("webbookingmaterial", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                if (cioid == null)
                {
                    objSqlCommand.Parameters["@cioid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cioid"].Value = cioid;
                }


                objSqlCommand.Parameters.Add("@imagefile", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imagefile"].Value = imagefile;

                objSqlCommand.Parameters.Add("@imagename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imagename"].Value = imagename;

                objSqlCommand.Parameters.Add("@url", SqlDbType.VarChar);
                objSqlCommand.Parameters["@url"].Value = url;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;



                objSqlCommand.Parameters.Add("@Comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_code"].Value = Comp_code;

                objSqlCommand.Parameters.Add("@NO_INSERT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@NO_INSERT"].Value = NO_INSERT;

                objSqlCommand.Parameters.Add("@EDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EDITION"].Value = EDITION;


                objSqlCommand.ExecuteNonQuery();
                return "True";
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




        public string updatewebmaterial(string cioid, string imagefile, string imagename, string url, string filename, string Comp_code, string NO_INSERT, string EDITION)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            //  SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatewebbookingmaterial", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                if (cioid == null)
                {
                    objSqlCommand.Parameters["@cioid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cioid"].Value = cioid;
                }


                objSqlCommand.Parameters.Add("@imagefile", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imagefile"].Value = imagefile;

                objSqlCommand.Parameters.Add("@imagename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imagename"].Value = imagename;

                objSqlCommand.Parameters.Add("@url", SqlDbType.VarChar);
                objSqlCommand.Parameters["@url"].Value = url;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;



                objSqlCommand.Parameters.Add("@Comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_code"].Value = Comp_code;

                objSqlCommand.Parameters.Add("@NO_INSERT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@NO_INSERT"].Value = NO_INSERT;

                objSqlCommand.Parameters.Add("@EDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EDITION"].Value = EDITION;


                objSqlCommand.ExecuteNonQuery();
                return "True";
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





        public DataSet tempexecutewebmaterial(string cioid, string Comp_code, string NO_INSERT, string filename)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tempexecutewebbookingmateria", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                if (cioid == null)
                {
                    objSqlCommand.Parameters["@cioid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cioid"].Value = cioid;
                }


            



                objSqlCommand.Parameters.Add("@Comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_code"].Value = Comp_code;

                objSqlCommand.Parameters.Add("@NO_INSERT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@NO_INSERT"].Value = NO_INSERT;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;


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


        public DataSet executewebmaterial(string cioid, string Comp_code, string NO_INSERT, string filename)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executewebbookingmateria", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                if (cioid == null)
                {
                    objSqlCommand.Parameters["@cioid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cioid"].Value = cioid;
                }






                objSqlCommand.Parameters.Add("@Comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_code"].Value = Comp_code;

                objSqlCommand.Parameters.Add("@NO_INSERT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@NO_INSERT"].Value = NO_INSERT;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;


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







        public DataSet deletewebmaterial(string cioid, string Comp_code, string imagename)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletewebmaterial", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                if (cioid == null)
                {
                    objSqlCommand.Parameters["@cioid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cioid"].Value = cioid;
                }

                objSqlCommand.Parameters.Add("@Comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_code"].Value = Comp_code;

                objSqlCommand.Parameters.Add("@imagename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imagename"].Value = imagename;

              

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




        public DataSet deletetempwebmaterial(string cioid, string Comp_code, string imagename)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tempdeletewebmaterial", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                if (cioid == null)
                {
                    objSqlCommand.Parameters["@cioid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cioid"].Value = cioid;
                }

                objSqlCommand.Parameters.Add("@Comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_code"].Value = Comp_code;

                objSqlCommand.Parameters.Add("@imagename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imagename"].Value = imagename;



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






        public DataSet deletegeography(string compcode, string edition, string noofinsert, string ciobokid, string country, string statecode, string City)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("webgeographdelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;



                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noofinsert;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobokid;


                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@statecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statecode"].Value = statecode;

                objSqlCommand.Parameters.Add("@City", SqlDbType.VarChar);
                objSqlCommand.Parameters["@City"].Value = City;


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



        public DataSet tempdeletegeography(string compcode, string edition, string noofinsert, string ciobokid, string country, string statecode, string City)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tempwebgeographdelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;



                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noofinsert;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobokid;



                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@statecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statecode"].Value = statecode;

                objSqlCommand.Parameters.Add("@City", SqlDbType.VarChar);
                objSqlCommand.Parameters["@City"].Value = City;



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






        public DataSet executegeo(string cio_book_id, string compcode,string noofinsert)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executegeography", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                
                objSqlCommand.Parameters.Add("@cio_booking_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_booking_id"].Value = cio_book_id;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noofinsert;


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


        public DataSet bindtree(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adcountryname", ref objSqlConnection);
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


        public DataSet bindchild(string country, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindstate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@countrycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@countrycode"].Value = country;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlDataAdapter = new SqlDataAdapter();
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



        public DataSet bindsubchild(string state, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binddistrict", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@statecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statecode"].Value = state;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlDataAdapter = new SqlDataAdapter();
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








        public DataSet executegeotemp(string cio_book_id, string compcode, string noofinsert)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executegeographytemp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cio_booking_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_booking_id"].Value = cio_book_id;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noofinsert;


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




        public DataSet executedays(string adcategory, string uom, string premium, string date123, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkrotationpremium", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;



                objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);

                string dateformat = "dd/mm/yyyy";
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = date123.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    date123 = mm + "/" + dd + "/" + yy;
                }

                objSqlCommand.Parameters["@date"].Value = date123;


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

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










        public DataSet executedays(string cio_book_id, string compcode, string noofinsert)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executedays", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cio_booking_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_booking_id"].Value = cio_book_id;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noofinsert;


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



        public DataSet tempexecutedays(string cio_book_id, string compcode, string noofinsert)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tempexecutedays", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cio_booking_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_booking_id"].Value = cio_book_id;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noofinsert;


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









    }
}
