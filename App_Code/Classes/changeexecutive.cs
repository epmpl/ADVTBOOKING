using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;


/// <summary>
/// Summary description for changeexecutive
/// </summary>
namespace NewAdbooking.Classes
{

    public class changeexecutive : connection
    {
        public changeexecutive()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindgridexecutive(string client, string agcode, string agsubcode, string id, string validfrom, string validto, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindexecutivegrid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pclientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pclientcode"].Value = client;

                objSqlCommand.Parameters.Add("@pagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagencycode"].Value = agcode;

                objSqlCommand.Parameters.Add("@pagencysubcode", SqlDbType.VarChar);
                if (agsubcode == "0")
                {
                    objSqlCommand.Parameters["@pagencysubcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pagencysubcode"].Value = agsubcode;
                }

                objSqlCommand.Parameters.Add("@pcioid", SqlDbType.VarChar);
                if (id == "0")
                {
                    objSqlCommand.Parameters["@pcioid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pcioid"].Value = id;
                }


                objSqlCommand.Parameters.Add("@validfrom", SqlDbType.DateTime);

                if (validfrom == "dd/mm/yyyy")
                {

                    string[] arr = validfrom.Split('/');
                    string mm = arr[1];
                    string dd = arr[0];
                    string yy = arr[2];
                    validfrom = mm + "/" + dd + "/" + yy;
                    objSqlCommand.Parameters["@validfrom"].Value = validfrom;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfrom = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@validfrom"].Value = validfrom;

                }








                //objSqlCommand.Parameters.Add("@validfrom", SqlDbType.VarChar);
                //if (validfrom == "")
                //{
                //    objSqlCommand.Parameters["@validfrom"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@validfrom"].Value = validfrom;
                //}

                objSqlCommand.Parameters.Add("@validto", SqlDbType.DateTime);

                if (validto == "dd/mm/yyyy")
                {

                    string[] arr = validfrom.Split('/');
                    string mm = arr[1];
                    string dd = arr[0];
                    string yy = arr[2];
                    validto = mm + "/" + dd + "/" + yy;
                    objSqlCommand.Parameters["@validto"].Value = validto;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validto = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@validto"].Value = validto;

                }






                //objSqlCommand.Parameters.Add("@validto", SqlDbType.VarChar);
                //if (validto == "0")
                //{
                //    objSqlCommand.Parameters["@validto"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@validto"].Value = validto;
                //}



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


        public DataSet bindagencys(string compcode, string userid, string agency, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforbooking_ex", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = center;

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



        public DataSet getClientName(string compcode, string client)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getclientName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;
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

        public DataSet bindexecutive(string compcode, string usid, string tname, string ext)
        {
          //  string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("xlsBindexecnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = usid;

                objSqlCommand.Parameters.Add("@name1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name1"].Value = tname;

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive"].Value = ext;

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


        public DataSet bindclientname_2(string compcode, string usid, string tname, string ext)
        {
            //  string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("xlsBindexecnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = usid;

                objSqlCommand.Parameters.Add("@name1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name1"].Value = tname;

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive"].Value = ext;

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

        public DataSet adbillsmodificationvalidate(string compcode, string centcode, string branch, string supplementbillno, string supplementbilldate, string dateformat, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_bills_modification_validate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcentcode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pbrancode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbrancode"].Value = branch;

                 objSqlCommand.Parameters.Add("@pbillno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbillno"].Value = supplementbillno;



                objSqlCommand.Parameters.Add("@pbilldt", SqlDbType.VarChar);
                if (supplementbilldate == "NULL" || supplementbilldate == "null" || supplementbilldate == null || supplementbilldate == "")
                {
                    objSqlCommand.Parameters["@pbilldt"].Value = System.DBNull.Value;

                }
                else
                objSqlCommand.Parameters["@pbilldt"].Value = supplementbilldate;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

               

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;

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
        public DataSet billupdatedata(string compcode, string ciobookid, string userid, string dateformat, string extra1, string extra2, string extra3, string extra4, string extra5, string flag)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                if (flag == "1")
                    objSqlCommand = GetCommand("billdet_for_bill_update_data_N", ref objSqlConnection);
                else
                    objSqlCommand = GetCommand("bill_update_data", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //objSqlConnection.Open();
                //objSqlCommand = GetCommand("billdet_for_bill_update_data", ref objSqlConnection);
                //objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@porderno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@porderno"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;            

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;

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





        public DataSet updateexe(string compcol, string cioid, string executive, string clientname, string clientadd, string retainername)
        {
          //  string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateexecutive", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcol;
                objSqlCommand.Parameters.Add("@pcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@pexecutivecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecutivecode"].Value = executive;

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@clientadd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientadd"].Value = clientadd;

                objSqlCommand.Parameters.Add("@retainername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainername"].Value = retainername;

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


        public DataSet update(string compcode, string langcode, string fontleading, string fontsize, string editioncode, string fontname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("update_fontleading", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;
                

                objSqlCommand.Parameters.Add("@pLANGCODE",SqlDbType.VarChar);
                objSqlCommand.Parameters["@pLANGCODE"].Value = langcode;



                objSqlCommand.Parameters.Add("@pFONTLEADING", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pFONTLEADING"].Value = fontleading;

                objSqlCommand.Parameters.Add("@pFONTSIZE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pFONTSIZE"].Value = fontsize;


                objSqlCommand.Parameters.Add("@pEITIONCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pEITIONCODE"].Value = editioncode;




                objSqlCommand.Parameters.Add("@PFONTNAME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PFONTNAME"].Value = fontname;





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




        public DataSet save(string compcode, string langcode, string fontleading, string fontsize, string editioncode, string fontname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("savefontleading", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

               
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@plangcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@plangcode"].Value = langcode;



                objSqlCommand.Parameters.Add("@fontleading", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fontleading"].Value = fontleading;

                objSqlCommand.Parameters.Add("@fontsize", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fontsize"].Value = fontsize;


                objSqlCommand.Parameters.Add("@eitioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@eitioncode"].Value = editioncode;




                objSqlCommand.Parameters.Add("@pfontname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfontname"].Value = fontname;







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


        public DataSet bindfontleading(string compcode, string edtioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_fontgrid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcompcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcompcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@peditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@peditioncode"].Value = edtioncode;
                

               

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

    }
}
