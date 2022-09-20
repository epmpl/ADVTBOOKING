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
/// Summary description for BookingMaster
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class BookingMaster : connection
    {
        public BookingMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getResourceNo(string name_p)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getResourceNo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@name_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name_p"].Value = name_p;

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
        public DataSet getSectionCode(string name_p)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getSectionCode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@name_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name_p"].Value = name_p;

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
        public DataSet bindreferenceID(string compcode, string agency, string client)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindreferenceID_TV", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@agency_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_p"].Value = agency;

                objSqlCommand.Parameters.Add("@client_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client_p"].Value = client;


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
        public DataSet fetchPassword(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchPassword", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid_p"].Value = userid;




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
        public DataSet bindAdOnPackage(string compcode, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpackage_Adon", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;




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
        public DataSet CONVERTTOLOCAL_CURRENCY(string p_Comp_code, string p_Curr_Code, string p_amount, string p_amount1, string p_date, string dateformat, string convertcurrency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_convert_to_local", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@p_Comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Comp_code"].Value = p_Comp_code;

                objSqlCommand.Parameters.Add("@p_Curr_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Curr_Code"].Value = p_Curr_Code;

                objSqlCommand.Parameters.Add("@p_amount", SqlDbType.VarChar);
                if (p_amount == "")
                    objSqlCommand.Parameters["@p_amount"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@p_amount"].Value = p_amount;

                objSqlCommand.Parameters.Add("@p_amount1", SqlDbType.VarChar);
                if (p_amount1 == "")
                    objSqlCommand.Parameters["@p_amount1"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@p_amount1"].Value = p_amount1;

                objSqlCommand.Parameters.Add("@p_date", SqlDbType.VarChar);
                if (p_date == "")
                {
                    objSqlCommand.Parameters["@p_date"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = p_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        p_date = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = p_date.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        p_date = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_date"].Value = p_date;
                }

                objSqlCommand.Parameters.Add("@convertcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@convertcurrency"].Value = convertcurrency;

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
        public DataSet GETCASH_PAY(string compcode, string paymode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETCASH_PAY", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@paymode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode_p"].Value = paymode;




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
        public DataSet bindAdTypeAgencyWise(string agencycode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getAgencyBookingType", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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
        public DataSet getVTSRate(string pubcode, string edition, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getVTSRate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode_p"].Value = pubcode;

                objSqlCommand.Parameters.Add("@edition_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_p"].Value = edition;



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
        public DataSet getPackageConsumption(string pkgcode, string pfdate, string pldate, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPackageConsumption", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@pfdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = pfdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pfdate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = pfdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    pfdate = mm + "/" + dd + "/" + yy;
                }

                objSqlCommand.Parameters["@pfdate"].Value = pfdate;

                objSqlCommand.Parameters.Add("@pldate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = pldate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pldate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = pldate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    pldate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pldate"].Value = pldate;


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
        public DataSet getDealAmt(string conttype, string dealagency, string dealclient, string compcode, string contcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getDealAmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@conttype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@conttype"].Value = conttype;

                objSqlCommand.Parameters.Add("@contagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contagency"].Value = dealagency;

                objSqlCommand.Parameters.Add("@contclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contclient"].Value = dealclient;

                objSqlCommand.Parameters.Add("@contcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contcode"].Value = contcode;

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
        public DataSet getDealP(string compcode, string contcode, string type, int counter)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("booking_getdealag", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = @compcode;

                objSqlCommand.Parameters.Add("@contcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contcode"].Value = contcode;

                objSqlCommand.Parameters.Add("@type_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type_p"].Value = type;

                objSqlCommand.Parameters.Add("@counter_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@counter_p"].Value = counter;

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
        public DataSet getpubcount(string compcode, string noofinsert, string packagecode, string cioid_v)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpubcount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

                objSqlCommand.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsert"].Value = noofinsert;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@cioid_v", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid_v"].Value = cioid_v;

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
        public DataSet fetchFMGrefID(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchFMGrefID", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@cioid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid_p"].Value = cioid;


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
        public DataSet getPubSharing(string packagecode, string compcode, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPubBooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

                objSqlCommand.Parameters.Add("@cioid_v", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid_v"].Value = cioid;

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
        public DataSet bindpackage_category(string compcode, string adtype, string category)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpackageCategoryWise", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@category", SqlDbType.VarChar);
                objSqlCommand.Parameters["@category"].Value = category;

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
        public DataSet getDiscPremVal(string compcode, string drpdiscprem)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getDiscPremVal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@drpdiscprem_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpdiscprem_p"].Value = drpdiscprem;



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
        public DataSet bindDiscPrem(string compcode, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindDiscPrem", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype_p"].Value = adtype;



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
        public void updateMatterDetail(string plainmatter, string rtfformat, string xtgmatter, string filename, string cioid, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            // DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateMatterDetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@plainmatter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@plainmatter"].Value = plainmatter;

                objSqlCommand.Parameters.Add("@rtfformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rtfformat"].Value = rtfformat;

                objSqlCommand.Parameters.Add("@xtgmatter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@xtgmatter"].Value = xtgmatter;

                objSqlCommand.Parameters.Add("@filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filename"].Value = filename;
                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlCommand.ExecuteNonQuery();
                // objSqlDataAdapter.Fill(objDataSet);


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
        public DataSet getDetailforProof(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getDetailforProofPreview", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;




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
        public string commitT(int count, string cioid, string pcompcode, string pcentname, string puserid, string pbkid_gentype, string pbk_type, string quotation)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            string error = "";
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("committransaction", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@pcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@totalcount", SqlDbType.Int);
                objSqlCommand.Parameters["@totalcount"].Value = count;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = pcompcode;

                objSqlCommand.Parameters.Add("@pcentname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcentname"].Value = pcentname;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = puserid;

                objSqlCommand.Parameters.Add("@pbkid_gentype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbkid_gentype"].Value = pbkid_gentype;

                objSqlCommand.Parameters.Add("@pbk_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbk_type"].Value = pbk_type;

                objSqlCommand.Parameters.Add("@pquotation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pquotation"].Value = quotation;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return error = "AA" + "$~$" + objDataSet.Tables[0].Rows[0][0].ToString();

                //objSqlDataAdapter.SelectCommand = objSqlCommand;
                //objSqlCommand.ExecuteNonQuery();
                // objSqlDataAdapter.Fill(objDataSet);


            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
            return error;
        }
        public void rollbackT(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            // DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rollbacktransaction", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlCommand.ExecuteNonQuery();
                // objSqlDataAdapter.Fill(objDataSet);


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
        public void deleteRecord(string srno, string insertid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deleteSplitSizeRecord", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@srno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@srno_p"].Value = srno;

                objSqlCommand.Parameters.Add("@insertid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertid_p"].Value = insertid;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);


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
        public DataSet getInsertSplitData(string mainid, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getInsertSplitData", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@idmain", SqlDbType.VarChar);
                objSqlCommand.Parameters["@idmain"].Value = mainid;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


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
        public DataSet getpaymentdetail(string receipt)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpaymentdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@receipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receipt"].Value = receipt;
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
        public DataSet insertpaymentdetail(string receiptno, string chqno, string chqdate, string amount, string chqmode, string bankname, string bankbranch, string filename, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertpaymentdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@chqno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chqno"].Value = chqno;

                objSqlCommand.Parameters.Add("@chqdate", SqlDbType.VarChar);
                if (chqdate == "")
                    objSqlCommand.Parameters["@chqdate"].Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chqdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chqdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = chqdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        chqdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@chqdate"].Value = chqdate;
                }

                objSqlCommand.Parameters.Add("@amount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@amount"].Value = amount;

                objSqlCommand.Parameters.Add("@bankname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bankname"].Value = bankname;

                objSqlCommand.Parameters.Add("@chqmode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chqmode"].Value = chqmode;

                objSqlCommand.Parameters.Add("@bankbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bankbranch"].Value = bankbranch;
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
        public DataSet getPaymentFlag(string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPaymentFlag", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


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
        public DataSet clsCioId(string s_agencycode, string filename)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_cioid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@s_agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@s_agencycode"].Value = s_agencycode;

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
        public DataSet clsOldMatter(string rcpt_no)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_oldMatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@rcpt_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcpt_no"].Value = rcpt_no;


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
        public DataSet fetchqbcdetail(string compcode, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchqbcdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;
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
        public DataSet get_paystatus(string receipt_no)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETPAYSTATUS", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receipt_no;


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
        public DataSet getAgencyCode(string compcode, string codesubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getAgencyCode1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@codesubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@codesubcode"].Value = codesubcode;


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
        public DataSet getciredition(string compcode, string editioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getciragency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.Text;
                string query = " select dbo.cir_get_name_cir_edtn('" + compcode + "','','" + editioncode + "','1','','','') as EDITIONNAME";
                objSqlCommand.CommandText = query;
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
        public DataSet getciragency(string compcode, string branch, string ciragency, string ciragencysubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getciragency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.Text;
                string query = " select dbo.cir_get_name_cir_agname_branch('" + compcode + "','','" + ciragency + "','" + ciragencysubcode + "','1','','','','" + branch + "') as AGENCYNAME";
                objSqlCommand.CommandText = query;
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
        public DataSet bindcirRate(string compcode, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_get_rates_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit_code"].Value = center;


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
        public DataSet getBarterBookingAmt(string bartertype, string cioid, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getBarterBookingAmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@bartertype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bartertype"].Value = bartertype;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

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
        public DataSet getBarter(string compcode, string center, string branch, string agency, string client)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getBarter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;
                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;
                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

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
        public DataSet checkPrevId(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkID_matter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;


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
        public DataSet bindciragency(string compcode, string branch, string ciragency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_agency_bind_cir_agency_bind_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = branch;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = ciragency;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

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
        public DataSet getBAlias(string branch, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("[getbalias]", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

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
        public DataSet getAmount(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("[getcioamount]", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;



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
        public DataSet getmaincode(string name, string code, string compname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("[getmaincodechk]", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@NAME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@NAME"].Value = name;

                objSqlCommand.Parameters.Add("@code1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code1"].Value = code;

                objSqlCommand.Parameters.Add("@company", SqlDbType.VarChar);
                objSqlCommand.Parameters["@company"].Value = compname;


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
        public DataSet getIP(string compcode, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getIP", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;



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
        public DataSet getRegisterClientCheck(string compcode, string ADCAT)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getRegisterClientCheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = ADCAT;



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
        public DataSet getRepressentative(string compcode, string executive, string retainer)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getRepresenttaive", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive"].Value = executive;

                objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer"].Value = retainer;


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
        public DataSet getOurBank(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getOurBank", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet getTemplate(string category)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getTemplateCategoryWise", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = category;

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
        public DataSet getbgcolcode(string bgcolname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getbgcolorcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@bgcolorname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolorname"].Value = bgcolname;

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
        public DataSet autogenratedbox(string compcode, string auto, string no, string center1, string agncodesubcode, string branch, string autono)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Getautocodebox", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@auto1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auto1"].Value = auto;

                objSqlCommand.Parameters.Add("@no1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@no1"].Value = no;

                objSqlCommand.Parameters.Add("@center1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center1"].Value = center1;

                objSqlCommand.Parameters.Add("@agency_codescode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_codescode"].Value = agncodesubcode;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@save_val", SqlDbType.VarChar);
                objSqlCommand.Parameters["@save_val"].Value = autono;

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
        public void clsInsertintoTemp(string ciobookid, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_InsertintoTemp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

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
        public DataSet clsMaxReceipt()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Maxreceipt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
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
        public DataSet getRetainerComm(string retainercode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Getretainercomm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMPCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@RETAINERCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RETAINERCODE"].Value = retainercode;

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
        public DataSet getretainer(string compcode, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETRETAINER", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMPCODE1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE1"].Value = compcode;

                objSqlCommand.Parameters.Add("@PUBCENTER", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUBCENTER"].Value = center;

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
        public DataSet getCurrdate()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getCurrDate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
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
        public void clsInsert_rcpthdr(string compcode, string userid, string punit, string doctype, string rcptno, string rcptdate, string ptype, string preceivedreg, string pvouno, string chqamt, string ag_codesubcode, string pothercd, string chqno, string chqdate, string bankname, string premarks, string prep, string pvdate, string ag_code, string ag_subcode, string dateformat, string ourbank)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Receiptsave_booking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@unit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unit"].Value = punit;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = doctype;

                objSqlCommand.Parameters.Add("@recpt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@recpt"].Value = rcptno;

                objSqlCommand.Parameters.Add("@rdate", SqlDbType.VarChar);
                if (rcptdate == "" || rcptdate == null)
                {
                    objSqlCommand.Parameters["@rdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rcptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rcptdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rcptdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rcptdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@rdate"].Value = rcptdate;
                }


                objSqlCommand.Parameters.Add("@paymodres", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymodres"].Value = ptype;

                objSqlCommand.Parameters.Add("@receivedreg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receivedreg"].Value = preceivedreg;

                objSqlCommand.Parameters.Add("@vouno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vouno"].Value = pvouno;




                objSqlCommand.Parameters.Add("@amount", SqlDbType.VarChar);
                if (chqamt == "")
                    objSqlCommand.Parameters["@amount"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@amount"].Value = chqamt;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = ag_code;

                objSqlCommand.Parameters.Add("@chno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chno"].Value = chqno;

                objSqlCommand.Parameters.Add("@othercd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@othercd"].Value = pothercd;


                objSqlCommand.Parameters.Add("@chedate", SqlDbType.VarChar);
                if (chqdate == "" || chqdate == null)
                {
                    objSqlCommand.Parameters["@chedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chqdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chqdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = chqdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        chqdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@chedate"].Value = chqdate;
                }


                objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bank"].Value = bankname;

                objSqlCommand.Parameters.Add("@vdate", SqlDbType.VarChar);
                if (pvdate == "" || pvdate == null)
                {
                    objSqlCommand.Parameters["@vdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pvdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pvdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pvdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        pvdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@vdate"].Value = pvdate;
                }


                objSqlCommand.Parameters.Add("@narration", SqlDbType.VarChar);
                objSqlCommand.Parameters["@narration"].Value = premarks;

                objSqlCommand.Parameters.Add("@rep", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rep"].Value = prep;

                objSqlCommand.Parameters.Add("@pag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_main_code"].Value = ag_code;

                objSqlCommand.Parameters.Add("@pag_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_sub_code"].Value = ag_subcode;

                objSqlCommand.Parameters.Add("@ourbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ourbank"].Value = ourbank;

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
        public void clsInsert_rcptdet(string compcode, string userid, string punit, string doctype, string rcptno, string rcptdate, string ptype, string preceivedreg, string pvouno, string chqamt, string ag_codesubcode, string chqno, string chqdate, string bankname, string pvdate, string ag_code, string ag_subcode, string dateformat, string remarks)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Receiptsave1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@unit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unit"].Value = punit;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = doctype;

                objSqlCommand.Parameters.Add("@recpt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@recpt"].Value = rcptno;

                objSqlCommand.Parameters.Add("@rdate", SqlDbType.VarChar);
                if (rcptdate == "" || rcptdate == null)
                {
                    objSqlCommand.Parameters["@rdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rcptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rcptdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rcptdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rcptdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@rdate"].Value = rcptdate;
                }


                objSqlCommand.Parameters.Add("@paymodres", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymodres"].Value = ptype;

                objSqlCommand.Parameters.Add("@receivedreg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receivedreg"].Value = preceivedreg;

                objSqlCommand.Parameters.Add("@vouno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vouno"].Value = pvouno;





                objSqlCommand.Parameters.Add("@amount", SqlDbType.VarChar);
                if (chqamt == "")
                    objSqlCommand.Parameters["@amount"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@amount"].Value = chqamt;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = ag_code;

                objSqlCommand.Parameters.Add("@chno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chno"].Value = chqno;

                objSqlCommand.Parameters.Add("@chedate", SqlDbType.VarChar);
                if (chqdate == "" || chqdate == null)
                {
                    objSqlCommand.Parameters["@chedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chqdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chqdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = chqdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        chqdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@chedate"].Value = chqdate;
                }


                objSqlCommand.Parameters.Add("@bank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bank"].Value = bankname;

                objSqlCommand.Parameters.Add("@vdate", SqlDbType.VarChar);
                if (pvdate == "" || pvdate == null)
                {
                    objSqlCommand.Parameters["@vdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pvdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pvdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pvdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        pvdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@vdate"].Value = pvdate;
                }


                objSqlCommand.Parameters.Add("@pag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_main_code"].Value = ag_code;

                objSqlCommand.Parameters.Add("@pag_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_sub_code"].Value = ag_subcode;


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
        public void clsupdate_chqinfo(string compcode, string rcptno, string chqno, string chqdate, string chqamt, string bankname, string ag_codesubcode, string ag_code, string ag_subcode, string ppaymodres, string ptype, string rcptdate, string dateformat, string remarks, string ourbank, string repcode, string unit, string userid, string cioid, string execname, string retainer, string prevcioid, string grossamt)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Update_Chqinfo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@precpt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@precpt"].Value = rcptno;

                objSqlCommand.Parameters.Add("@pchno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchno"].Value = chqno;

                objSqlCommand.Parameters.Add("@pchedate", SqlDbType.VarChar);
                if (chqdate == "" || chqdate == null)
                {
                    objSqlCommand.Parameters["@pchedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chqdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chqdate = mm + "/" + dd + "/" + yy;
                    }
                    if (dateformat == "yyy/mm/dd")
                    {
                        string[] arr = chqdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        chqdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@pchedate"].Value = chqdate;
                }


                objSqlCommand.Parameters.Add("@pamount", SqlDbType.VarChar);
                if (chqamt == "")
                    objSqlCommand.Parameters["@pamount"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pamount"].Value = chqamt;

                objSqlCommand.Parameters.Add("@pbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbank"].Value = bankname;

                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = ag_codesubcode;

                objSqlCommand.Parameters.Add("@pag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_main_code"].Value = ag_code;
                objSqlCommand.Parameters.Add("@pag_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_sub_code"].Value = ag_subcode;
                objSqlCommand.Parameters.Add("@ppaymodres", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppaymodres"].Value = ppaymodres;
                objSqlCommand.Parameters.Add("@ptype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptype"].Value = ptype;
                objSqlCommand.Parameters.Add("@prdate", SqlDbType.VarChar);
                if (rcptdate == "" || rcptdate == null)
                {
                    objSqlCommand.Parameters["@prdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rcptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rcptdate = mm + "/" + dd + "/" + yy;
                    }
                    if (dateformat == "yyy/mm/dd")
                    {
                        string[] arr = rcptdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rcptdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@prdate"].Value = rcptdate;
                }

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@puser", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puser"].Value = userid;
                objSqlCommand.Parameters.Add("@ourbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ourbank"].Value = ourbank;

                objSqlCommand.Parameters.Add("@rep_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rep_code"].Value = repcode;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer"].Value = retainer;

                objSqlCommand.Parameters.Add("@prevcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevcioid"].Value = prevcioid;

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@grossamt"].Value = grossamt;

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
        public void clsInsert_outstand(string compcode, string userid, string punit, string doctype, string rcptno, string rcptdate, string ptype, string preceivedreg, string pvouno, string chqamt, string ag_codesubcode, string pvdate, string ag_code, string ag_subcode, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Receiptsave2", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@unit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unit"].Value = punit;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = doctype;

                objSqlCommand.Parameters.Add("@recpt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@recpt"].Value = rcptno;

                objSqlCommand.Parameters.Add("@rdate", SqlDbType.VarChar);
                if (rcptdate == "" || rcptdate == null)
                {
                    objSqlCommand.Parameters["@rdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rcptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rcptdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rcptdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rcptdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@rdate"].Value = rcptdate;
                }


                objSqlCommand.Parameters.Add("@paymodres", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymodres"].Value = ptype;

                objSqlCommand.Parameters.Add("@receivedreg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receivedreg"].Value = preceivedreg;

                objSqlCommand.Parameters.Add("@vouno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vouno"].Value = pvouno;



                objSqlCommand.Parameters.Add("@amount", SqlDbType.VarChar);
                if (chqamt == "")
                    objSqlCommand.Parameters["@amount"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@amount"].Value = chqamt;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = ag_code;

                objSqlCommand.Parameters.Add("@vdate", SqlDbType.VarChar);
                if (pvdate == "" || pvdate == null)
                {
                    objSqlCommand.Parameters["@vdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pvdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pvdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pvdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        pvdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@vdate"].Value = pvdate;
                }


                objSqlCommand.Parameters.Add("@pag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_main_code"].Value = ag_code;

                objSqlCommand.Parameters.Add("@pag_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_sub_code"].Value = ag_subcode;


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
        public void clsdeletefromtemp(string ciobookid, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Deletefromtemp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

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
        public void deleteBooking(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deleteBooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;


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
        public DataSet clsChequeInfo(string compcode, string receipt)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Chequeinfo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@receipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receipt"].Value = receipt;

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
        public DataSet getPkgEdition_P(string compcode, string combincode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPkgEdition_P", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@combincode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@combincode"].Value = combincode;

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
        public DataSet checkCIOIDReference(string compcode, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkCioidRef", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

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
        public DataSet getPackageInsert(string pckcode, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Getpackageinsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = pckcode;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

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
        public DataSet getPremPage(string premcode, string id)
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
                objSqlCommand = GetCommand("getPremium_PageNo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@premcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premcode"].Value = premcode;

                objSqlCommand.Parameters.Add("@id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@id"].Value = id;

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
        public DataSet getStatus()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getStatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
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
        public DataSet getBillStatus()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getBillStatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
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
        public DataSet getExecZoneName(string execcode, string compcode)
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
                objSqlCommand = GetCommand("websp_getExecZoneName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@exexcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@exexcode"].Value = execcode;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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
        public DataSet getClientName_b(string compcode, string client, string agencycode)
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
                objSqlCommand = GetCommand("websp_getclientName_b", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;
                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;
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
        public DataSet bindBrand(string compcode, string procat)
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
                objSqlCommand = GetCommand("websp_getBrand", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@procat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@procat"].Value = procat;
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
        public DataSet getInsertion(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string @pck, string uom, string dealrate, string checkforor, string premium, string clientname)
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
                objSqlCommand = GetCommand("bindBookingInsertion", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@noofinsertion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("@insertiondate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@clickdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.Int);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["@flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@pck", SqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["@pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@checkforor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

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
        public DataSet bindProduct(string compcode, string product, string value)
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
                objSqlCommand = GetCommand("websp_getProduct", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;
                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;
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
        public DataSet bindPagePosition(string compcode, string bookingdate, string dateformat, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("WEBSP_GETPAGEPOSITION_DATEWISE", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@bookingdate", SqlDbType.VarChar);
                if (bookingdate == "")
                {
                    objSqlCommand.Parameters["@bookingdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = bookingdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        bookingdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = bookingdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        bookingdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@bookingdate"].Value = bookingdate;
                }

                objSqlCommand.Parameters.Add("@adtype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype_p"].Value = adtype;

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
        public DataSet bindAdSizeType(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getadsize", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
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
        public DataSet getCustomer(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getCustomerName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
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
        public DataSet getExec(string compcode, string execname, string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getExec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;


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

        public DataSet autogenrated(string compcode, string auto, string no)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getautocodebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@auto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auto"].Value = auto;

                objSqlCommand.Parameters.Add("@no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@no"].Value = no;

                //objSqlCommand.Parameters.Add("@center1", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@center1"].Value = "0";

                //objSqlCommand.Parameters.Add("@agncodesubcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@agncodesubcode"].Value = "0";


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



        public DataSet bookidchk(string compcode, string ciobookid, string agency, string agencycode, string rono, string saveormod, string keyno, string rodate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkciobookid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@saveormod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@saveormod"].Value = saveormod;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.VarChar);
                char[] a = { '/' };
                if (rodate != "")
                {
                    string[] b = rodate.Split(a);

                    rodate = b[1] + "/" + b[0] + "/" + b[2];
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }
                else
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;


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

        public DataSet insertbooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string receiptdate, string prevcioid, string prevreceipt, Decimal prev_ga, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string attach1, string attach2, string cashdiscount, string cashdiscountper, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multiselect, string agreedrate_active, string agreedamt_active, string grossamtlocal_p, string billamtlocal_p, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string transdisc, string pospremdisc, string billhold, string designbox, string logoprem)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@date_time"].Value = date_time;
                }

                objSqlCommand.Parameters.Add("@adsizetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@booked_by", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("@prevbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("@approvedby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.DateTime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }

                objSqlCommand.Parameters.Add("@caption", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption"].Value = caption;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agencyaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("@clientaddresses", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@execzone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@billremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("@printremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@insertion", SqlDbType.Int);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["@insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["@startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@startdate"].Value = startdate;
                }

                objSqlCommand.Parameters.Add("@repeatdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@subcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@pageposition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("@pagetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.Int);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["@pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("@adsizheight", SqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("@adsizwidth", SqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@agreedrate", SqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("@agreedamt", SqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("@spedisc", SqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["@spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@spacedisx", SqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("@specialcharges", SqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@agencystatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@agencredit", SqlDbType.Int);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["@agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@cardamount", SqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["@cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("@discountper", SqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["@discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("@billaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("@totarea", SqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["@totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("@billcycle", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("@billpay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("@billheight", SqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["@billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("@billwidth", SqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["@billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@invoices", SqlDbType.Int);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["@invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("@vts", SqlDbType.Int);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["@vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("@tradedisc", SqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("@agencyout", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("@boxno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("@boxaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("@boxagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("@boxclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("@bookingtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@coupan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("@campaign", SqlDbType.VarChar);
                objSqlCommand.Parameters["@campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("@bill_amt", SqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("@pageprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("@pageamt", SqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["@pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("@premper", SqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["@premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["@grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("@adsizcolumn", SqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("@billcolumn", SqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("@billarea", SqlDbType.Decimal);

                objSqlCommand.Parameters["@billarea"].Value = Convert.ToDecimal(billarea);

                objSqlCommand.Parameters.Add("@specdiscper", SqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("@spacediscper", SqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("@paidins", SqlDbType.Int);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["@paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient"].Value = varient;

                objSqlCommand.Parameters.Add("@contractname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contractname"].Value = contractname;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;


                ////////////////
                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@cardmonth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("@cardyear", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("@cardno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@adscat3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("@bulletprm", SqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    bulletprm = bulletprm.Replace("%", "");
                    objSqlCommand.Parameters["@bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;


                objSqlCommand.Parameters.Add("@receiptdate", SqlDbType.DateTime);
                if (receiptdate == "" || receiptdate == null)
                {
                    objSqlCommand.Parameters["@receiptdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = receiptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        receiptdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = receiptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        receiptdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@receiptdate"].Value = receiptdate;
                }


                objSqlCommand.Parameters.Add("@prevcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevcioid"].Value = prevcioid;

                objSqlCommand.Parameters.Add("@prevreceipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevreceipt"].Value = prevreceipt;

                objSqlCommand.Parameters.Add("@prev_ga", SqlDbType.Decimal);

                objSqlCommand.Parameters["@prev_ga"].Value = prev_ga;


                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@varient_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient_name"].Value = varient_name;

                ////changes
                objSqlCommand.Parameters.Add("@coltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coltype"].Value = coltype;

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_col"].Value = logo_col;

                objSqlCommand.Parameters.Add("@logo_uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_uom"].Value = logo_uom;


                objSqlCommand.Parameters.Add("@retainer1", SqlDbType.VarChar);
                if (retainer.IndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.LastIndexOf("(") + 1, retainer.Length - retainer.LastIndexOf("(") - 2);
                }
                if (retainer == "0")
                    retainer = "";
                objSqlCommand.Parameters["@retainer1"].Value = retainer;

                objSqlCommand.Parameters.Add("@addagencyrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagencyrate"].Value = addagencyrate;

                objSqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobileno"].Value = mobileno;

                objSqlCommand.Parameters.Add("@addlamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addlamt"].Value = addlamt;

                objSqlCommand.Parameters.Add("@retamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retamt"].Value = retamt;

                objSqlCommand.Parameters.Add("@retper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retper"].Value = retper;


                objSqlCommand.Parameters.Add("@cashrecieved", SqlDbType.VarChar);
                if (cashrecieved == "" || cashrecieved == null)
                {
                    objSqlCommand.Parameters["@cashrecieved"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@cashrecieved"].Value = Convert.ToDecimal(cashrecieved);
                }

                objSqlCommand.Parameters.Add("@CIRAGENCY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCY"].Value = ciragency;

                objSqlCommand.Parameters.Add("@CIRRATE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRRATE"].Value = cirrate;

                objSqlCommand.Parameters.Add("@CIREDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIREDITION"].Value = ciredition;

                objSqlCommand.Parameters.Add("@CIRPUBLICATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRPUBLICATION"].Value = cirpublication;


                objSqlCommand.Parameters.Add("@CIRAGENCYSUBCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCYSUBCODE"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@BARTERTYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BARTERTYPE"].Value = bartertype;

                objSqlCommand.Parameters.Add("@CASHDISCOUNT_V", SqlDbType.VarChar);
                if (cashdiscount == "" || cashdiscount == "null" || cashdiscount == null)
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = cashdiscount;

                objSqlCommand.Parameters.Add("@CASHDISCOUNTPER_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CASHDISCOUNTPER_V"].Value = cashdiscountper;

                objSqlCommand.Parameters.Add("@attach1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach1"].Value = attach1;

                objSqlCommand.Parameters.Add("@attach2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach2"].Value = attach2;

                objSqlCommand.Parameters.Add("@drpdiscprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpdiscprem"].Value = drpdiscprem;
                objSqlCommand.Parameters.Add("@doctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@doctype"].Value = doctype;

                objSqlCommand.Parameters.Add("@CHKTRADE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHKTRADE"].Value = chktradeval;

                objSqlCommand.Parameters.Add("@sharepub_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sharepub_p"].Value = sharepub;
                objSqlCommand.Parameters.Add("@fmginsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmginsert"].Value = fmginsert;

                objSqlCommand.Parameters.Add("@chkno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkno"].Value = chkno;

                objSqlCommand.Parameters.Add("@chkdate", SqlDbType.DateTime);
                if (chkdate == "" || chkdate == null)
                {
                    objSqlCommand.Parameters["@chkdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@chkdate"].Value = chkdate;
                }


                objSqlCommand.Parameters.Add("@chkamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkamt"].Value = chkamt;

                objSqlCommand.Parameters.Add("@chkbankname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkbankname"].Value = chkbankname;
                objSqlCommand.Parameters.Add("@ourbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ourbank"].Value = ourbank;
                objSqlCommand.Parameters.Add("@DEALERPANEL_P", SqlDbType.VarChar);
                if (dealerpanel == "")
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = dealerpanel;

                objSqlCommand.Parameters.Add("@DEALERH_P", SqlDbType.VarChar);
                if (dealerh == "")
                    objSqlCommand.Parameters["@DEALERH_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERH_P"].Value = dealerh;

                objSqlCommand.Parameters.Add("@DEALERW_P", SqlDbType.VarChar);
                if (dealerw == "")
                    objSqlCommand.Parameters["@DEALERW_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERW_P"].Value = dealerw;

                objSqlCommand.Parameters.Add("@DEALERTYPE_P", SqlDbType.VarChar);
                if (dealertype == "")
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = dealertype;

                objSqlCommand.Parameters.Add("@multiselect", SqlDbType.VarChar);
                objSqlCommand.Parameters["@multiselect"].Value = multiselect;

                objSqlCommand.Parameters.Add("@AGREEDRATE_ACTIVE", SqlDbType.VarChar);
                if (agreedrate_active == "")
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = agreedrate_active;

                objSqlCommand.Parameters.Add("@AGREEDAMT_ACTIVE", SqlDbType.VarChar);
                if (agreedamt_active == "")
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = agreedamt_active;


                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.Float);
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.Float);
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;

                objSqlCommand.Parameters.Add("@chkadon_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkadon_p"].Value = chkadon;

                objSqlCommand.Parameters.Add("@refid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refid_p"].Value = refid;

                objSqlCommand.Parameters.Add("@rcpt_currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcpt_currency"].Value = rcpt_currency;

                objSqlCommand.Parameters.Add("@cur_convrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cur_convrate"].Value = cur_convrate;

                objSqlCommand.Parameters.Add("@p_revisedate", SqlDbType.VarChar);
                if (revisedate == "" || revisedate == null)
                {
                    objSqlCommand.Parameters["@p_revisedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@p_revisedate"].Value = revisedate;
                }

                objSqlCommand.Parameters.Add("@clienttype", SqlDbType.VarChar);
                if (clienttype == "0")
                    objSqlCommand.Parameters["@clienttype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@clienttype"].Value = clienttype;

                objSqlCommand.Parameters.Add("@translation", SqlDbType.VarChar);
                if (translation == "0")
                    objSqlCommand.Parameters["@translation"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@translation"].Value = translation;


                objSqlCommand.Parameters.Add("@translationcharge", SqlDbType.Decimal);
                if (translationcharge == "" || translationcharge == null)
                {
                    objSqlCommand.Parameters["@translationcharge"].Value = System.DBNull.Value;
                }
                else
                {
                    translationcharge = translationcharge.Replace("%", "");
                    objSqlCommand.Parameters["@translationcharge"].Value = Convert.ToDecimal(translationcharge);
                }
                objSqlCommand.Parameters.Add("@fmgreasons", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmgreasons"].Value = fmgreasons;
                objSqlCommand.Parameters.Add("@canclecharge", SqlDbType.VarChar);
                objSqlCommand.Parameters["@canclecharge"].Value = canclecharge;

                objSqlCommand.Parameters.Add("@transdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@transdisc_p"].Value = transdisc;

                objSqlCommand.Parameters.Add("@pospremdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pospremdisc_p"].Value = pospremdisc;

                objSqlCommand.Parameters.Add("@billhold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billhold"].Value = billhold;

                objSqlCommand.Parameters.Add("@designbox", SqlDbType.VarChar);
                objSqlCommand.Parameters["@designbox"].Value = designbox;

                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprem"].Value = logoprem;

                objSqlCommand.Parameters.Add("@online_ad_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@online_ad_p"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@style", SqlDbType.VarChar);
                objSqlCommand.Parameters["@style"].Value = System.DBNull.Value;


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

        public DataSet insertCashReceived(string ciobookid, string receiptno, string drpcashrecieved)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintocashreceiveddetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@drpcashrecieved", SqlDbType.VarChar);
                if (drpcashrecieved == "" || drpcashrecieved == null)
                {
                    objSqlCommand.Parameters["@drpcashrecieved"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@drpcashrecieved"].Value = Convert.ToDecimal(drpcashrecieved);
                }



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

        public DataSet updatebooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string status, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string cashdiscount, string cashdiscper, string attach1, string attach2, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string agreedrate_active, string agreedamt_active, string grossamtlocal_p, string billamtlocal_p, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string modifyrateaudit, string ip, string transdisc, string pospremdisc, string billhold, string designbox, string logoprem)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@date_time"].Value = date_time;
                }

                objSqlCommand.Parameters.Add("@adsizetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@booked_by", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("@prevbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("@approvedby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.DateTime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }

                objSqlCommand.Parameters.Add("@caption", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption"].Value = caption;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agencyaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("@clientaddresses", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@execzone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@billremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("@printremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@insertion", SqlDbType.Int);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["@insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["@startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        startdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        startdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@startdate"].Value = startdate;
                }

                objSqlCommand.Parameters.Add("@repeatdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@subcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@pageposition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("@pagetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.Int);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["@pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("@adsizheight", SqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("@adsizwidth", SqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@agreedrate", SqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("@agreedamt", SqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("@spedisc", SqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["@spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@spacedisx", SqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("@specialcharges", SqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@agencystatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@agencredit", SqlDbType.Int);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["@agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@cardamount", SqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["@cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("@discountper", SqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["@discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("@billaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("@totarea", SqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["@totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("@billcycle", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("@billpay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("@billheight", SqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["@billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("@billwidth", SqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["@billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@invoices", SqlDbType.Int);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["@invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("@vts", SqlDbType.Int);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["@vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("@tradedisc", SqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("@agencyout", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("@boxno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("@boxaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("@boxagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("@boxclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("@bookingtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@coupan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("@campaign", SqlDbType.VarChar);
                objSqlCommand.Parameters["@campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("@bill_amt", SqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("@pageprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("@pageamt", SqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["@pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("@premper", SqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["@premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["@grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("@adsizcolumn", SqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("@billcolumn", SqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("@billarea", SqlDbType.Decimal);

                objSqlCommand.Parameters["@billarea"].Value = Convert.ToDecimal(billarea);


                objSqlCommand.Parameters.Add("@specdiscper", SqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("@spacediscper", SqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("@paidins", SqlDbType.Int);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["@paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient"].Value = varient;

                objSqlCommand.Parameters.Add("@contractname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contractname"].Value = contractname;


                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@cardmonth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("@cardyear", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("@cardno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@adscat3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("@bulletprm", SqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    bulletprm = bulletprm.Replace("%", "");
                    objSqlCommand.Parameters["@bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@varient_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient_name"].Value = varient_name;
                /*new change ankur 9 feb*/
                objSqlCommand.Parameters.Add("@coltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coltype"].Value = coltype;
                //////////////////////////////

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_col"].Value = logo_col;

                objSqlCommand.Parameters.Add("@logo_uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_uom"].Value = logo_uom;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@retainer1", SqlDbType.VarChar);
                if (retainer.IndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.IndexOf("(") + 1, retainer.Length - retainer.IndexOf("(") - 2);
                }
                objSqlCommand.Parameters["@retainer1"].Value = retainer;

                objSqlCommand.Parameters.Add("@addagencyrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagencyrate"].Value = addagencyrate;

                objSqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobileno"].Value = mobileno;

                objSqlCommand.Parameters.Add("@addlamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addlamt"].Value = addlamt;

                objSqlCommand.Parameters.Add("@retamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retamt"].Value = retamt;

                objSqlCommand.Parameters.Add("@retper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retper"].Value = retper;

                objSqlCommand.Parameters.Add("@cashrecieved", SqlDbType.VarChar);
                if (cashrecieved == "" || cashrecieved == null)
                {
                    objSqlCommand.Parameters["@cashrecieved"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@cashrecieved"].Value = Convert.ToDecimal(cashrecieved);
                }
                objSqlCommand.Parameters.Add("@CIRAGENCY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCY"].Value = ciragency;

                objSqlCommand.Parameters.Add("@CIRRATE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRRATE"].Value = cirrate;

                objSqlCommand.Parameters.Add("@CIREDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIREDITION"].Value = ciredition;

                objSqlCommand.Parameters.Add("@CIRPUBLICATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRPUBLICATION"].Value = cirpublication;

                objSqlCommand.Parameters.Add("@CIRAGENCYSUBCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCYSUBCODE"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@BARTERTYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BARTERTYPE"].Value = bartertype;

                objSqlCommand.Parameters.Add("@CASHDISCOUNT_V", SqlDbType.VarChar);
                if (cashdiscount == "")
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = cashdiscount;

                objSqlCommand.Parameters.Add("@CASHDISCOUNTPER_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CASHDISCOUNTPER_V"].Value = cashdiscper;

                objSqlCommand.Parameters.Add("@attach1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach1"].Value = attach1;

                objSqlCommand.Parameters.Add("@attach2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach2"].Value = attach2;

                objSqlCommand.Parameters.Add("@drpdiscprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpdiscprem"].Value = drpdiscprem;
                objSqlCommand.Parameters.Add("@doctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@doctype"].Value = doctype;

                objSqlCommand.Parameters.Add("@CHKTRADE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHKTRADE"].Value = chktradeval;
                objSqlCommand.Parameters.Add("@sharepub_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sharepub_p"].Value = sharepub;

                objSqlCommand.Parameters.Add("@fmginsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmginsert"].Value = fmginsert;

                objSqlCommand.Parameters.Add("@chkno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkno"].Value = chkno;

                objSqlCommand.Parameters.Add("@chkdate", SqlDbType.DateTime);
                if (chkdate == "" || chkdate == null)
                {
                    objSqlCommand.Parameters["@chkdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@chkdate"].Value = chkdate;
                }


                objSqlCommand.Parameters.Add("@chkamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkamt"].Value = chkamt;

                objSqlCommand.Parameters.Add("@chkbankname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkbankname"].Value = chkbankname;
                objSqlCommand.Parameters.Add("@ourbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ourbank"].Value = ourbank;

                objSqlCommand.Parameters.Add("@DEALERPANEL_P", SqlDbType.VarChar);
                if (dealerpanel == "")
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = dealerpanel;

                objSqlCommand.Parameters.Add("@DEALERH_P", SqlDbType.VarChar);
                if (dealerh == "")
                    objSqlCommand.Parameters["@DEALERH_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERH_P"].Value = dealerh;

                objSqlCommand.Parameters.Add("@DEALERW_P", SqlDbType.VarChar);
                if (dealerw == "")
                    objSqlCommand.Parameters["@DEALERW_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERW_P"].Value = dealerw;

                objSqlCommand.Parameters.Add("@DEALERTYPE_P", SqlDbType.VarChar);
                if (dealertype == "")
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = dealertype;

                objSqlCommand.Parameters.Add("@multiselect", SqlDbType.VarChar);
                objSqlCommand.Parameters["@multiselect"].Value = multicode;

                objSqlCommand.Parameters.Add("@AGREEDRATE_ACTIVE", SqlDbType.VarChar);
                if (agreedrate_active == "")
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = agreedrate_active;

                objSqlCommand.Parameters.Add("@AGREEDAMT_ACTIVE", SqlDbType.VarChar);
                if (agreedamt_active == "")
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = agreedamt_active;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.VarChar);
                if (grossamtlocal_p == "")
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.VarChar);
                if (billamtlocal_p == "")
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;



                objSqlCommand.Parameters.Add("@chkadon_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkadon_p"].Value = chkadon;

                objSqlCommand.Parameters.Add("@refid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refid_p"].Value = refid;


                objSqlCommand.Parameters.Add("@rcpt_currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcpt_currency"].Value = rcpt_currency;

                objSqlCommand.Parameters.Add("@cur_convrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cur_convrate"].Value = cur_convrate;

                objSqlCommand.Parameters.Add("@p_revisedate", SqlDbType.VarChar);
                if (revisedate == "" || revisedate == null)
                {
                    objSqlCommand.Parameters["@p_revisedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@p_revisedate"].Value = revisedate;
                }

                objSqlCommand.Parameters.Add("@clienttype", SqlDbType.VarChar);
                if (clienttype == "0")
                    objSqlCommand.Parameters["@clienttype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@clienttype"].Value = clienttype;

                objSqlCommand.Parameters.Add("@translation", SqlDbType.VarChar);
                if (translation == "0")
                    objSqlCommand.Parameters["@translation"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@translation"].Value = translation;

                objSqlCommand.Parameters.Add("@translationcharge", SqlDbType.Decimal);
                if (translationcharge == "" || translationcharge == null)
                {
                    objSqlCommand.Parameters["@translationcharge"].Value = System.DBNull.Value;
                }
                else
                {
                    translationcharge = translationcharge.Replace("%", "");
                    objSqlCommand.Parameters["@translationcharge"].Value = Convert.ToDecimal(translationcharge);
                }
                objSqlCommand.Parameters.Add("@fmgreasons", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmgreasons"].Value = fmgreasons;

                objSqlCommand.Parameters.Add("@canclecharge", SqlDbType.VarChar);
                objSqlCommand.Parameters["@canclecharge"].Value = canclecharge;

                objSqlCommand.Parameters.Add("@P_ip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ip"].Value = ip;

                objSqlCommand.Parameters.Add("@P_RATE_AUDIT_FLAG", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_RATE_AUDIT_FLAG"].Value = modifyrateaudit;

                objSqlCommand.Parameters.Add("@transdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@transdisc_p"].Value = transdisc;

                objSqlCommand.Parameters.Add("@pospremdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pospremdisc_p"].Value = pospremdisc;

                objSqlCommand.Parameters.Add("@billhold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billhold"].Value = billhold;

                objSqlCommand.Parameters.Add("@designbox", SqlDbType.VarChar);
                objSqlCommand.Parameters["@designbox"].Value = designbox;


                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprem"].Value = logoprem;


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

        public DataSet executebooking(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking, string dateformat, string revenue, string quotation_no)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@docno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@docno"].Value = docno;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking"].Value = booking;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@revenue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenue"].Value = revenue;

                objSqlCommand.Parameters.Add("@pquotationno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pquotationno"].Value = quotation_no;
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



        public DataSet executebookingqbc(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking, string dateformat, string revenue)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@docno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@docno"].Value = docno;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking"].Value = booking;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@revenue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenue"].Value = revenue;


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



        public DataSet executebookingqbc(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@docno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@docno"].Value = docno;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking"].Value = booking;



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

        public DataSet bindpaymode(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpaymode", ref objSqlConnection);
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

        public DataSet bindrevenue(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindrevenue", ref objSqlConnection);
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
        public DataSet getstatuspaymodeAgency(string agency, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();

                objSqlCommand = GetCommand("getstatuspaymodeAgency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agency;
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
        public DataSet getstatuspaymode(string agency, string agencysubcode, string compcode, string datecheck, string dateformat, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();

                objSqlCommand = GetCommand("getstatuspaymode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@datecheck", SqlDbType.VarChar);
                if (datecheck == "" || datecheck == null)
                    objSqlCommand.Parameters["@datecheck"].Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {

                        if (datecheck.IndexOf('-') < 0)
                        {
                            string[] arr = datecheck.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            datecheck = mm + "/" + dd + "/" + yy;

                        }

                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = datecheck.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        datecheck = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@datecheck"].Value = datecheck;
                }

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

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

        public DataSet getthedatabook(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getuomforbook", ref objSqlConnection);
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

        public DataSet getpercentage(string premium, string compcode)
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
                objSqlCommand = GetCommand("getpremiumforbook", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

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

        public DataSet ratebind(string adcat, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;


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

        public DataSet getrate(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string premium, string clientcode, string noof_ins)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@adsucat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@selecdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("@noof_ins", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noof_ins"].Value = noof_ins;



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

        public DataSet class_getrate(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string noof_ins)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("class_getratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@adsucat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@selecdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@insert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert"].Value = insert;

                objSqlCommand.Parameters.Add("@lines", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lines"].Value = lines;


                objSqlCommand.Parameters.Add("@prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prem"].Value = prem;

                objSqlCommand.Parameters.Add("@adcat3", SqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["@adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat3"].Value = adcat3;
                }

                objSqlCommand.Parameters.Add("@adcat4", SqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["@adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("@adcat5", SqlDbType.VarChar);
                if (adcat5 == "")
                {
                    objSqlCommand.Parameters["@adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@noof_ins", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noof_ins"].Value = noof_ins;






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

        public DataSet class_getrate_qbc(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string noof_ins, string uomdesc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpackgaerate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@adsucat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@selecdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@insert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert"].Value = insert;

                objSqlCommand.Parameters.Add("@lines", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lines"].Value = lines;


                objSqlCommand.Parameters.Add("@prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prem"].Value = prem;

                objSqlCommand.Parameters.Add("@adcat3", SqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["@adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat3"].Value = adcat3;
                }

                objSqlCommand.Parameters.Add("@adcat4", SqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["@adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("@adcat5", SqlDbType.VarChar);
                if (adcat5 == "")
                {
                    objSqlCommand.Parameters["@adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@noof_ins", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noof_ins"].Value = noof_ins;


                /*new change ankur 17 feb*/
                objSqlCommand.Parameters.Add("@uomdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomdesc"].Value = uomdesc;



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

        public DataSet boxbind(string compcode, string center)
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
                objSqlCommand = GetCommand("boxbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;
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

        public DataSet bindagency(string compcode, string userid, string agency, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforbooking", ref objSqlConnection);
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

        public DataSet bindagencyextra(string compcode, string userid, string agency, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforbookingextralevel", ref objSqlConnection);
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


        public DataSet getClientNameadd(string client, string compcode, string value, string datecheck)
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
                objSqlCommand = GetCommand("getclientnameadd", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlCommand.Parameters.Add("@datecheck", SqlDbType.VarChar);
                objSqlCommand.Parameters["@datecheck"].Value = datecheck;


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


        public DataSet chkrategroup(string color, string adcat, string adsucat, string package, string ratecode, string selecdate, string currency, string adtype, string compcode, string agency, string client, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkrategroupcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@adsucat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@selecdate", SqlDbType.VarChar);
                if (selecdate == "" || selecdate == null)
                {
                    objSqlCommand.Parameters["@selecdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = selecdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        selecdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = selecdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        selecdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@selecdate"].Value = selecdate;
                }

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;






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

        public DataSet insertbook_ins(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splitdata, string subedidata, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string disc_)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobookchild", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@insertdate", SqlDbType.DateTime);
                if (insertdate == "" || insertdate == null || insertdate == "null")
                {
                    objSqlCommand.Parameters["@insertdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        insertdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        insertdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@insertdate"].Value = Convert.ToDateTime(insertdate);
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@premium1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium1"].Value = premium1;

                objSqlCommand.Parameters.Add("@premium2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium2"].Value = premium2;

                objSqlCommand.Parameters.Add("@premallow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premallow"].Value = premallow;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@latestdate", SqlDbType.DateTime);
                if (latestdate == "" || latestdate == null || latestdate == "null")
                {
                    objSqlCommand.Parameters["@latestdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        latestdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        latestdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@latestdate"].Value = Convert.ToDateTime(latestdate);
                }
                //,,,,,,,,,,,,,

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null || cardrate == "null")
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@matfilename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matfilename"].Value = matfilename;

                objSqlCommand.Parameters.Add("@discrate", SqlDbType.Decimal);
                if (discrate == "" || discrate == null || discrate == "null")
                {
                    objSqlCommand.Parameters["@discrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discrate"].Value = Convert.ToDecimal(discrate);
                }

                objSqlCommand.Parameters.Add("@insertstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;





                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                //

                objSqlCommand.Parameters.Add("@height", SqlDbType.Decimal);
                if (height == "" || height == null || height == "null")
                {
                    objSqlCommand.Parameters["@height"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@height"].Value = Convert.ToDecimal(height);
                }

                objSqlCommand.Parameters.Add("@width", SqlDbType.Decimal);
                if (width == "" || width == null || width == "null")
                {
                    objSqlCommand.Parameters["@width"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@width"].Value = Convert.ToDecimal(width);
                }

                objSqlCommand.Parameters.Add("@totalsize", SqlDbType.Decimal);
                if (totalsize == "" || totalsize == null || totalsize == "null")
                {
                    objSqlCommand.Parameters["@totalsize"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalsize"].Value = Convert.ToDecimal(totalsize);
                }

                objSqlCommand.Parameters.Add("@pagepost", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagepost"].Value = pagepost;

                objSqlCommand.Parameters.Add("@premper1", SqlDbType.Decimal);
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    objSqlCommand.Parameters["@premper1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper1"].Value = Convert.ToDecimal(premper1);
                }

                objSqlCommand.Parameters.Add("@premper2", SqlDbType.Decimal);
                if (premper2 == "" || premper2 == null || premper2 == "null")
                {
                    objSqlCommand.Parameters["@premper2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper2"].Value = Convert.ToDecimal(premper2);
                }

                objSqlCommand.Parameters.Add("@colid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colid"].Value = colid;

                objSqlCommand.Parameters.Add("@repeat", SqlDbType.DateTime);
                if (repeat == "" || repeat == null || repeat == "null")
                {
                    objSqlCommand.Parameters["@repeat"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        repeat = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        repeat = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@repeat"].Value = Convert.ToDateTime(repeat);
                }




                objSqlCommand.Parameters.Add("@insertno", SqlDbType.Int);
                if (insertno == "" || insertno == null || insertno == "null")
                {
                    objSqlCommand.Parameters["@insertno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertno"].Value = Convert.ToInt32(insertno);
                }

                objSqlCommand.Parameters.Add("@paid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paid"].Value = paid;

                objSqlCommand.Parameters.Add("@agrrate", SqlDbType.Decimal);
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    objSqlCommand.Parameters["@agrrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agrrate"].Value = Convert.ToDecimal(agrrate);
                }

                objSqlCommand.Parameters.Add("@solorate", SqlDbType.Decimal);
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    objSqlCommand.Parameters["@solorate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@solorate"].Value = Convert.ToDecimal(solorate);
                }

                objSqlCommand.Parameters.Add("@grossrate", SqlDbType.Decimal);
                if (grossrate == "" || grossrate == null || grossrate == "null")
                {
                    objSqlCommand.Parameters["@grossrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossrate"].Value = Convert.ToDecimal(grossrate);
                }

                objSqlCommand.Parameters.Add("@insert_remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert_remarks"].Value = insert_remarks;

                objSqlCommand.Parameters.Add("@insert_pageno", SqlDbType.Int);
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32("0");
                }
                else
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32(insert_pageno);
                }

                objSqlCommand.Parameters.Add("@page_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_code"].Value = page_code;

                objSqlCommand.Parameters.Add("@page_per", SqlDbType.Decimal);
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal(page_per);
                }

                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.Decimal);
                if (noofcol == "" || noofcol == null || noofcol == "null")
                {
                    objSqlCommand.Parameters["@noofcol"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofcol"].Value = Convert.ToDecimal(noofcol);
                }

                objSqlCommand.Parameters.Add("@billamt", SqlDbType.Decimal);
                if (billamt == "" || billamt == null || billamt == "null")
                {
                    objSqlCommand.Parameters["@billamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billamt"].Value = Convert.ToDecimal(billamt);
                }


                objSqlCommand.Parameters.Add("@billrate", SqlDbType.Decimal);
                if (billrate == "" || billrate == null || billrate == "null")
                {
                    objSqlCommand.Parameters["@billrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billrate"].Value = Convert.ToDecimal(billrate);
                }

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_name"].Value = logo_name;

                objSqlCommand.Parameters.Add("@ad_cat_3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_3"].Value = adcat3;

                objSqlCommand.Parameters.Add("@ad_cat_4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_4"].Value = adcat4;

                objSqlCommand.Parameters.Add("@ad_cat_5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_5"].Value = adcat5;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@gridins", SqlDbType.Int);
                if (gridins == "" || gridins == null || gridins == "null")
                {
                    objSqlCommand.Parameters["@gridins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@gridins"].Value = gridins;
                }

                objSqlCommand.Parameters.Add("@pkgalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgalias"].Value = pkgalias;

                objSqlCommand.Parameters.Add("@cirvts", SqlDbType.VarChar);
                if (cirvts == "null" || cirvts == null)
                    objSqlCommand.Parameters["@cirvts"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cirvts"].Value = cirvts;


                objSqlCommand.Parameters.Add("@cirpub", SqlDbType.VarChar);
                if (cirpub == "null" || cirpub == null)
                    objSqlCommand.Parameters["@cirpub"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cirpub"].Value = cirpub;


                objSqlCommand.Parameters.Add("@ciredi", SqlDbType.VarChar);
                if (ciredi == "null" || ciredi == null)
                    objSqlCommand.Parameters["@ciredi"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ciredi"].Value = ciredi;


                objSqlCommand.Parameters.Add("@cirrate", SqlDbType.VarChar);
                if (cirrate == "null" && cirrate == null)
                    objSqlCommand.Parameters["@cirrate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cirrate"].Value = cirrate;

                objSqlCommand.Parameters.Add("@cirdate", SqlDbType.VarChar);
                if (cirdate == "" || cirdate == null || cirdate == "null")
                {
                    objSqlCommand.Parameters["@cirdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@cirdate"].Value = Convert.ToDateTime(cirdate);
                }



                objSqlCommand.Parameters.Add("@ciragency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragency"].Value = ciragency;

                objSqlCommand.Parameters.Add("@ciragencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragencysubcode"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@splitdata_v", SqlDbType.VarChar);
                objSqlCommand.Parameters["@splitdata_v"].Value = splitdata;

                objSqlCommand.Parameters.Add("@subedidata", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subedidata"].Value = subedidata;

                objSqlCommand.Parameters.Add("@splboldsizevalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@splboldsizevalue"].Value = splboldsizevalue;

                objSqlCommand.Parameters.Add("@vatrate_p", SqlDbType.Float);
                if (vatrate == "" || vatrate == "null" || vatrate == null)
                    objSqlCommand.Parameters["@vatrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vatrate_p"].Value = Convert.ToDecimal(vatrate);

                objSqlCommand.Parameters.Add("@boxcharge_p", SqlDbType.Float);
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null || boxcharge == "0")
                    objSqlCommand.Parameters["@boxcharge_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@boxcharge_p"].Value = Convert.ToDecimal(boxcharge);

                objSqlCommand.Parameters.Add("@vat_inc_p", SqlDbType.Float);
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null)
                    objSqlCommand.Parameters["@vat_inc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vat_inc_p"].Value = vat_inc_p;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.Float);
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.Float);
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;

                objSqlCommand.Parameters.Add("@sectioncode_p", SqlDbType.VarChar);
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    objSqlCommand.Parameters["@sectioncode_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@sectioncode_p"].Value = sectioncode_p;


                objSqlCommand.Parameters.Add("@resourceno_p", SqlDbType.VarChar);
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    objSqlCommand.Parameters["@resourceno_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = resourceno_p;

                objSqlCommand.Parameters.Add("@caption_inserts_p", SqlDbType.VarChar);
                if (caption_inserts == "" || caption_inserts == "null" || caption_inserts == null)
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = caption_inserts;

                objSqlCommand.Parameters.Add("@dealerheight", SqlDbType.Decimal);
                if (dealerheight == "" || dealerheight == "null" || dealerheight == null)
                    objSqlCommand.Parameters["@dealerheight"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = dealerheight;

                objSqlCommand.Parameters.Add("@dealerwidth", SqlDbType.Decimal);
                if (dealerwidth == "" || dealerwidth == "null" || dealerwidth == null)
                    objSqlCommand.Parameters["@dealerwidth"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dealerwidth"].Value = dealerwidth;

                objSqlCommand.Parameters.Add("@disc_p", SqlDbType.Float);
                if (disc_ == "" || disc_ == "null" || disc_ == null)
                    objSqlCommand.Parameters["@disc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@disc_p"].Value = disc_;

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
        public DataSet insertbook_ins_display(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string insert_id, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string subedidata, string disc_, string modifyrateaudit, string ip)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobookchild_display", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@insertdate", SqlDbType.DateTime);
                if (insertdate == "" || insertdate == null || insertdate == "null")
                {
                    objSqlCommand.Parameters["@insertdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        insertdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        insertdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@insertdate"].Value = Convert.ToDateTime(insertdate);
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@premium1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium1"].Value = premium1;

                objSqlCommand.Parameters.Add("@premium2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium2"].Value = premium2;

                objSqlCommand.Parameters.Add("@premallow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premallow"].Value = premallow;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@latestdate", SqlDbType.DateTime);
                if (latestdate == "" || latestdate == null || latestdate == "null")
                {
                    objSqlCommand.Parameters["@latestdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        latestdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        latestdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@latestdate"].Value = Convert.ToDateTime(latestdate);
                }
                //,,,,,,,,,,,,,

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null || cardrate == "null")
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@matfilename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matfilename"].Value = matfilename;

                objSqlCommand.Parameters.Add("@discrate", SqlDbType.Decimal);
                if (discrate == "" || discrate == null || discrate == "null")
                {
                    objSqlCommand.Parameters["@discrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discrate"].Value = Convert.ToDecimal(discrate);
                }

                objSqlCommand.Parameters.Add("@insertstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;





                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                //

                objSqlCommand.Parameters.Add("@height", SqlDbType.Decimal);
                if (height == "" || height == null || height == "null")
                {
                    objSqlCommand.Parameters["@height"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@height"].Value = Convert.ToDecimal(height);
                }

                objSqlCommand.Parameters.Add("@width", SqlDbType.Decimal);
                if (width == "" || width == null || width == "null")
                {
                    objSqlCommand.Parameters["@width"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@width"].Value = Convert.ToDecimal(width);
                }

                objSqlCommand.Parameters.Add("@totalsize", SqlDbType.Decimal);
                if (totalsize == "" || totalsize == null || totalsize == "null")
                {
                    objSqlCommand.Parameters["@totalsize"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalsize"].Value = Convert.ToDecimal(totalsize);
                }

                objSqlCommand.Parameters.Add("@pagepost", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagepost"].Value = pagepost;

                objSqlCommand.Parameters.Add("@premper1", SqlDbType.Decimal);
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    objSqlCommand.Parameters["@premper1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper1"].Value = Convert.ToDecimal(premper1);
                }

                objSqlCommand.Parameters.Add("@premper2", SqlDbType.Decimal);
                if (premper2 == "" || premper2 == null || premper2 == "null")
                {
                    objSqlCommand.Parameters["@premper2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper2"].Value = Convert.ToDecimal(premper2);
                }

                objSqlCommand.Parameters.Add("@colid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colid"].Value = colid;

                objSqlCommand.Parameters.Add("@repeat", SqlDbType.DateTime);
                if (repeat == "" || repeat == null || repeat == "null")
                {
                    objSqlCommand.Parameters["@repeat"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        repeat = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        repeat = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@repeat"].Value = Convert.ToDateTime(repeat);
                }




                objSqlCommand.Parameters.Add("@insertno", SqlDbType.Int);
                if (insertno == "" || insertno == null || insertno == "null")
                {
                    objSqlCommand.Parameters["@insertno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertno"].Value = Convert.ToInt32(insertno);
                }

                objSqlCommand.Parameters.Add("@paid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paid"].Value = paid;

                objSqlCommand.Parameters.Add("@agrrate", SqlDbType.Decimal);
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    objSqlCommand.Parameters["@agrrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agrrate"].Value = Convert.ToDecimal(agrrate);
                }

                objSqlCommand.Parameters.Add("@solorate", SqlDbType.Decimal);
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    objSqlCommand.Parameters["@solorate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@solorate"].Value = Convert.ToDecimal(solorate);
                }

                objSqlCommand.Parameters.Add("@grossrate", SqlDbType.Decimal);
                if (grossrate == "" || grossrate == null || grossrate == "null")
                {
                    objSqlCommand.Parameters["@grossrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossrate"].Value = Convert.ToDecimal(grossrate);
                }

                objSqlCommand.Parameters.Add("@insert_remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert_remarks"].Value = insert_remarks;

                objSqlCommand.Parameters.Add("@insert_pageno", SqlDbType.Int);
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32("0");
                }
                else
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32(insert_pageno);
                }

                objSqlCommand.Parameters.Add("@page_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_code"].Value = page_code;

                objSqlCommand.Parameters.Add("@page_per", SqlDbType.Decimal);
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal(page_per);
                }

                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.Decimal);
                if (noofcol == "" || noofcol == null || noofcol == "null")
                {
                    objSqlCommand.Parameters["@noofcol"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofcol"].Value = Convert.ToDecimal(noofcol);
                }

                objSqlCommand.Parameters.Add("@billamt", SqlDbType.Decimal);
                if (billamt == "" || billamt == null || billamt == "null")
                {
                    objSqlCommand.Parameters["@billamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billamt"].Value = Convert.ToDecimal(billamt);
                }


                objSqlCommand.Parameters.Add("@billrate", SqlDbType.Decimal);
                if (billrate == "" || billrate == null || billrate == "null")
                {
                    objSqlCommand.Parameters["@billrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billrate"].Value = Convert.ToDecimal(billrate);
                }

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_name"].Value = logo_name;

                objSqlCommand.Parameters.Add("@insertid", SqlDbType.Int);
                if (insert_id == "")
                    insert_id = "0";
                objSqlCommand.Parameters["@insertid"].Value = insert_id;

                objSqlCommand.Parameters.Add("@ad_cat_3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_3"].Value = adcat3;

                objSqlCommand.Parameters.Add("@ad_cat_4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_4"].Value = adcat4;

                objSqlCommand.Parameters.Add("@ad_cat_5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_5"].Value = adcat5;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@gridins", SqlDbType.Int);
                objSqlCommand.Parameters["@gridins"].Value = gridins;

                objSqlCommand.Parameters.Add("@pkgalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgalias"].Value = pkgalias;

                objSqlCommand.Parameters.Add("@cirvts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirvts"].Value = cirvts;

                objSqlCommand.Parameters.Add("@cirpub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirpub"].Value = cirpub;

                objSqlCommand.Parameters.Add("@ciredi", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciredi"].Value = ciredi;

                objSqlCommand.Parameters.Add("@cirrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirrate"].Value = cirrate;

                objSqlCommand.Parameters.Add("@cirdate", SqlDbType.VarChar);
                if (cirdate == "" || cirdate == null || cirdate == "null")
                {
                    objSqlCommand.Parameters["@cirdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@cirdate"].Value = Convert.ToDateTime(cirdate);
                }



                objSqlCommand.Parameters.Add("@ciragency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragency"].Value = ciragency;

                objSqlCommand.Parameters.Add("@ciragencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragencysubcode"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;
                objSqlCommand.Parameters.Add("@splboldsizevalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@splboldsizevalue"].Value = splboldsizevalue;

                objSqlCommand.Parameters.Add("@vatrate_p", SqlDbType.Float);
                if (vatrate == "" || vatrate == "null" || vatrate == null)
                    objSqlCommand.Parameters["@vatrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vatrate_p"].Value = Convert.ToDecimal(vatrate);
                objSqlCommand.Parameters.Add("@boxcharge_p", SqlDbType.Float);
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null || boxcharge == "0")
                    objSqlCommand.Parameters["@boxcharge_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@boxcharge_p"].Value = Convert.ToDecimal(boxcharge);

                objSqlCommand.Parameters.Add("@vat_inc_p", SqlDbType.Float);
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null)
                    objSqlCommand.Parameters["@vat_inc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vat_inc_p"].Value = vat_inc_p;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.Float);
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.Float);
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;

                objSqlCommand.Parameters.Add("@sectioncode_p", SqlDbType.VarChar);
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    objSqlCommand.Parameters["@sectioncode_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@sectioncode_p"].Value = sectioncode_p;

                objSqlCommand.Parameters.Add("@resourceno_p", SqlDbType.VarChar);
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    objSqlCommand.Parameters["@resourceno_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = resourceno_p;

                objSqlCommand.Parameters.Add("@caption_inserts_p", SqlDbType.VarChar);
                if (caption_inserts == "" || caption_inserts == "null" || caption_inserts == null)
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = caption_inserts;



                objSqlCommand.Parameters.Add("@subedidata", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subedidata"].Value = subedidata;

                objSqlCommand.Parameters.Add("@disc_p", SqlDbType.Float);
                if (disc_ == "" || disc_ == "null" || disc_ == null)
                    objSqlCommand.Parameters["@disc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@disc_p"].Value = disc_;

                objSqlCommand.Parameters.Add("@P_ip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ip"].Value = ip;


                objSqlCommand.Parameters.Add("@P_RATE_AUDIT_FLAG", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_RATE_AUDIT_FLAG"].Value = modifyrateaudit;


                objSqlCommand.Parameters.Add("@dealerheight_p", SqlDbType.Decimal);
                if (dealerheight == "" || dealerheight == "null" || dealerheight == null || dealerheight == "default")
                    objSqlCommand.Parameters["@dealerheight_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dealerheight_p"].Value = dealerheight;

                objSqlCommand.Parameters.Add("@dealerwidth_inserts_p", SqlDbType.Decimal);
                if (dealerwidth == "" || dealerwidth == "null" || dealerwidth == null || dealerwidth == "default")
                    objSqlCommand.Parameters["@dealerwidth_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dealerwidth_inserts_p"].Value = dealerwidth;

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

        public DataSet forwalkclient(string client, string compcode)
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
                objSqlCommand = GetCommand("chkforwalkinnclient", ref objSqlConnection);
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

        public DataSet prevbooking(string compcode, string userid, string formname)
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
                objSqlCommand = GetCommand("gettheprevbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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

        public DataSet chkdiscountpremedit_per(string userid, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("chkdiscountpremedit_per", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@userid1", SqlDbType.VarChar);
                cmd.Parameters["@userid1"].Value = userid;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;


                da.SelectCommand = cmd;
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
        public DataSet fetchdataforexe(string ciobid, string compcode)
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
                objSqlCommand = GetCommand("getdataforexecute", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobid"].Value = ciobid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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

        public DataSet getagencyname(string agency, string compcode, string product, string execname, string retainer)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkagen_prod_exec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer"].Value = retainer;

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

        public DataSet getpageamt(string pagecode, string compcode)//, string bookingdate, string dateformat)
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
                objSqlCommand = GetCommand("getpageamount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagecode"].Value = pagecode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                /* objSqlCommand.Parameters.Add("@bookingdate", SqlDbType.VarChar);
                 if (bookingdate == "")
                 {
                     objSqlCommand.Parameters["@bookingdate"].Value = System.DBNull.Value;
                 }
                 else
                 {
                     if (dateformat == "dd/mm/yyyy")
                     {
                         string[] arr = bookingdate.Split('/');
                         string dd = arr[0];
                         string mm = arr[1];
                         string yy = arr[2];
                         bookingdate = mm + "/" + dd + "/" + yy;
                     }
                     else if (dateformat == "yyyy/mm/dd")
                     {
                         string[] arr = bookingdate.Split('/');
                         string dd = arr[2];
                         string mm = arr[1];
                         string yy = arr[0];
                         bookingdate = mm + "/" + dd + "/" + yy;
                     }
                     objSqlCommand.Parameters["@bookingdate"].Value = bookingdate;
                 }
                 */
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

        public DataSet packagebindforexebook(string compcode, string pckcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpckexebook", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pckcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pckcode"].Value = pckcode;


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


        public DataSet getdealvalue(string compcode, string agencysplit, string subagencycode, string bookingdate, string color, string curr, string adcat, string clientsplit, string prod, string col, string code, string rate_cod, string adtype, string dateformat, string totalarea, string dealtype)
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
                objSqlCommand = GetCommand("booking_getdeal_dummy", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agencysplit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysplit"].Value = agencysplit;

                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;

                objSqlCommand.Parameters.Add("@bookingdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingdate"].Value = bookingdate;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@curr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@curr"].Value = curr;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@clientsplit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientsplit"].Value = clientsplit;


                objSqlCommand.Parameters.Add("@prod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prod"].Value = prod;


                objSqlCommand.Parameters.Add("@col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@col"].Value = col;


                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;


                objSqlCommand.Parameters.Add("@rate_cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_cod"].Value = rate_cod;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@totalarea", SqlDbType.VarChar);
                if (totalarea == "")
                    objSqlCommand.Parameters["@totalarea"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@totalarea"].Value = totalarea;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                if (dealtype == "")
                    objSqlCommand.Parameters["@dealtype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dealtype"].Value = dealtype;

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

        public DataSet booking_getdealdisc(string dealcode, string compcode, string agencysplit, string subagency, string clientsplit)
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
                objSqlCommand = GetCommand("booking_getdeealdisc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agencysplit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysplit"].Value = agencysplit;

                objSqlCommand.Parameters.Add("@subagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagency"].Value = subagency;

                objSqlCommand.Parameters.Add("@dealcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealcode"].Value = dealcode;

                objSqlCommand.Parameters.Add("@clientsplit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientsplit"].Value = clientsplit;




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

        public DataSet schemebind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindscheme", ref objSqlConnection);
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

        public DataSet getschemedisc(string schemcode, string compcode, string noofinsert)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("booking_getschdisc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@schemcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemcode"].Value = schemcode;

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

        public DataSet deleteid(string ciobookid, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletecioid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;


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

        public DataSet bindvarient(string brand, string Compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AN_BRANDVARIENT", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = Compcode;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;



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

        public DataSet bindsubagency(string agency, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_bindsubagency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;




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

        public DataSet getbillval(string agency, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_bindbillto", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;




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

        public DataSet chkclient(string client, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_chkcasualclient", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;




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

        public DataSet getinsertsche(string schemecode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getinsertscheme", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@schemecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemecode"].Value = schemecode;




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
        public DataSet book_packagename(string value, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_packagename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;









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

        public DataSet book_chkpublishday(string value, string compcode, string pkgname, string dateday, string dateformat, string adcat, string adtype1, string center, string pkgid, string pkgalias)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_chkpublishday", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;


                objSqlCommand.Parameters.Add("@pkgname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgname"].Value = pkgname;


                objSqlCommand.Parameters.Add("@dateday", SqlDbType.VarChar);
                if (dateday == "" || dateday == null || dateday == "null")
                {
                    objSqlCommand.Parameters["@dateday"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateday.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateday = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateday.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateday = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@dateday"].Value = dateday;
                }

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@pkgalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgalias"].Value = pkgalias;

                objSqlCommand.Parameters.Add("@pkgid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgid"].Value = pkgid;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype1;

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

        public DataSet getname(string curr, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getcurrname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@curr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@curr"].Value = curr;



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

        ///////////////these are the class file used in classified booking form]

        public DataSet getvalfromadcat3(string adcat, string compcode, string value)
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
                objSqlCommand = GetCommand("class_bindadcat3", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

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

        public DataSet bgcolorbind(string compcode, string value)
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
                objSqlCommand = GetCommand("class_bindbgcolor", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;




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
        public DataSet advdatacategoryRate(string compcode, string booking, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_advcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking"].Value = booking;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;


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
        public DataSet advdatacategory(string compcode, string booking)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                if (booking == "adtype")
                {

                    objSqlCommand = GetCommand("book_advcategory1", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@booking"].Value = booking;

                }
                else
                {
                    objSqlCommand = GetCommand("book_advcategory", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@booking"].Value = booking;

                }


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

        public DataSet chkfilename(string cioid, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getfilename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;




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

        public DataSet getPkgDetail(string pkgname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPackageName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgname;




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

        public DataSet getrotime(string Rohours, string Romin, string compcode, string publishdate, string packagename)
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
                objSqlCommand = GetCommand("book_chkrotime", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@Rohours", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Rohours"].Value = Rohours;

                objSqlCommand.Parameters.Add("@Romin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Romin"].Value = Romin;

                objSqlCommand.Parameters.Add("@publishdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@publishdate"].Value = publishdate;

                objSqlCommand.Parameters.Add("@packagename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagename"].Value = packagename;

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

        public DataSet book_bindpagetyp(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_bindpagetyp", ref objSqlConnection);
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

        public DataSet chkforspace(string page_no, string edit_name, string edit_date, string compcode, string nopag)
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
                objSqlCommand = GetCommand("book_chkspace", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@page_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_no"].Value = page_no;

                objSqlCommand.Parameters.Add("@edit_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit_name"].Value = edit_name;

                objSqlCommand.Parameters.Add("@edit_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit_date"].Value = edit_date;

                objSqlCommand.Parameters.Add("@nopag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@nopag"].Value = nopag;



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
        public DataSet advdatasubcatcat(string compcode, string catcode, string agencytype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_advsubcattyp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catcode"].Value = catcode;

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

        public DataSet getInsertion_classified(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string @pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode)
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
                objSqlCommand = GetCommand("bindClassifiedInsertion", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@noofinsertion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("@insertiondate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@clickdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.Int);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["@flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@pck", SqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["@pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@checkforor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("@classinserts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("@lines", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lines"].Value = lines;

                objSqlCommand.Parameters.Add("@adcat3", SqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["@adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("@adcat4", SqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["@adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("@adcat5", SqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["@adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;

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
        public DataSet getInsertion_qbc(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string @pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc)
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
                objSqlCommand = GetCommand("qbc_insertsrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@noofinsertion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("@insertiondate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@clickdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.Int);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["@flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@pck", SqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["@pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@checkforor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("@classinserts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("@lines", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lines"].Value = lines;

                objSqlCommand.Parameters.Add("@adcat3", SqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["@adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("@adcat4", SqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["@adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("@adcat5", SqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["@adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;
                objSqlCommand.Parameters.Add("@uomdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomdesc"].Value = uomdesc;


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


        public DataSet qbc_getInsertion(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string userid, string center)
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
                objSqlCommand = GetCommand("qbc_getInsertion", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@noofinsertion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("@insertiondate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.VarChar);
                if (startdate != "" && startdate != null)
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@startdate"].Value = startdate;
                }
                else
                {
                    objSqlCommand.Parameters["@startdate"].Value = System.DBNull.Value;
                }


                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@clickdate", SqlDbType.VarChar);
                if (clickdate != "" && clickdate != null)
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = clickdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        clickdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = clickdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        clickdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@clickdate"].Value = clickdate;
                }
                else
                {
                    objSqlCommand.Parameters["@clickdate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@flag", SqlDbType.Int);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["@flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@pck", SqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["@pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@checkforor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("@classinserts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("@lines", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lines"].Value = lines;

                objSqlCommand.Parameters.Add("@adcat3", SqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["@adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("@adcat4", SqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["@adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("@adcat5", SqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["@adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("@user_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@user_id"].Value = userid;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;


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


        public DataSet getInsertion_classified_fillgrid(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string @pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode)
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
                objSqlCommand = GetCommand("bindClassifiedInsertion_temp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@noofinsertion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("@insertiondate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@clickdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.Int);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["@flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@pck", SqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["@pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@checkforor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("@classinserts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("@lines", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lines"].Value = lines;

                objSqlCommand.Parameters.Add("@adcat3", SqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["@adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("@adcat4", SqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["@adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("@adcat5", SqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["@adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;

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





        public DataSet getrateforprmpkg(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string compcode, string uom, string premium)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getrate_forprempkg", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@adsucat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;


                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;






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



        public DataSet getvatamt(string grossamt, string compcode)
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
                objSqlCommand = GetCommand("getthevatrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@grossamt"].Value = grossamt;

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

        public DataSet class_chklinerate(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string editionsolo)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("class_chklinerate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@adsucat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@selecdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@insert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert"].Value = insert;

                objSqlCommand.Parameters.Add("@lines", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lines"].Value = lines;


                objSqlCommand.Parameters.Add("@prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prem"].Value = prem;

                objSqlCommand.Parameters.Add("@adcat3", SqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["@adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat3"].Value = adcat3;
                }

                objSqlCommand.Parameters.Add("@adcat4", SqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["@adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("@adcat5", SqlDbType.VarChar);
                if (adcat5 == "")
                {
                    objSqlCommand.Parameters["@adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@editionsolo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editionsolo"].Value = editionsolo;






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

        public DataSet updatebookstatus(string cioid, string compcode)
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
                objSqlCommand = GetCommand("updatebookstatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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

        public DataSet book_getcyoppkg(string code, string compcode, string adtype)
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
                objSqlCommand = GetCommand("book_getcyoppkg", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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
        /*change*/
        public DataSet getwidthforcollumn_qbc(string desc, string collumn, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getwidthforcollumn_qbc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@desc"].Value = desc;

                objSqlCommand.Parameters.Add("@collumn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@collumn"].Value = collumn;




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


        /*change*/
        public DataSet getwidth_qbc(string edition, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getwidth_qbc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

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


        public DataSet getwidthforcollumn(string desc, string collumn, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getwidthforcollumn", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@desc"].Value = desc;

                objSqlCommand.Parameters.Add("@collumn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@collumn"].Value = collumn;




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

        //*****************************By Manish Verma*************************************
        public DataSet fetchStyleSheetName(string uom)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getStyleSheet", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;



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


        public DataSet saveMatter(string cioid, string matterFName, string RTFformat, string XTGformat, string matter, string receipt, string lang, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_insertMatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@matter_filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matter_filename"].Value = matterFName;

                objSqlCommand.Parameters.Add("@RTFformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RTFformat"].Value = RTFformat;

                objSqlCommand.Parameters.Add("@XTGformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@XTGformat"].Value = XTGformat;

                objSqlCommand.Parameters.Add("@matter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matter"].Value = matter;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receipt;

                objSqlCommand.Parameters.Add("@p_lang", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_lang"].Value = lang;

                objSqlCommand.Parameters.Add("@p_userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_userid"].Value = userid;


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

        public DataSet getMatter(string cioid, string matterFName)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getMatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@matter_filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matter_filename"].Value = matterFName;

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

        public DataSet modifyMatter(string cioid, string matterFName, string RTFformat, string XTGformat, string matter, string flag, string receiptnumber, string lang, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_modifyMatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@matter_filename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matter_filename"].Value = matterFName;

                objSqlCommand.Parameters.Add("@RTFformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RTFformat"].Value = RTFformat;

                objSqlCommand.Parameters.Add("@XTGformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@XTGformat"].Value = XTGformat;

                objSqlCommand.Parameters.Add("@matter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matter"].Value = matter;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;
                objSqlCommand.Parameters.Add("@receiptnumber", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptnumber"].Value = receiptnumber;

                objSqlCommand.Parameters.Add("@p_lang", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_lang"].Value = lang;


                objSqlCommand.Parameters.Add("@p_userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_userid"].Value = userid;

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


        public DataSet insertbooking1(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string receiptdate, string prevcioid, string prevreceipt, Decimal prev_ga, string region, string varient_name, string status, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        date_time = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        date_time = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@date_time"].Value = date_time;
                }

                objSqlCommand.Parameters.Add("@adsizetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@booked_by", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("@prevbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("@approvedby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.DateTime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rodate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rodate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }

                objSqlCommand.Parameters.Add("@caption", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption"].Value = caption;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agencyaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("@clientaddresses", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@execzone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@billremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("@printremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@insertion", SqlDbType.Int);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["@insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["@startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@startdate"].Value = startdate;
                }

                objSqlCommand.Parameters.Add("@repeatdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@subcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@pageposition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("@pagetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.Int);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["@pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("@adsizheight", SqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("@adsizwidth", SqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@agreedrate", SqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("@agreedamt", SqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("@spedisc", SqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["@spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@spacedisx", SqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("@specialcharges", SqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@agencystatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@agencredit", SqlDbType.Int);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["@agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@cardamount", SqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["@cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("@discountper", SqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["@discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("@billaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("@totarea", SqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["@totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("@billcycle", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("@billpay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("@billheight", SqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["@billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("@billwidth", SqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["@billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@invoices", SqlDbType.Int);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["@invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("@vts", SqlDbType.Int);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["@vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("@tradedisc", SqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("@agencyout", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("@boxno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("@boxaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("@boxagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("@boxclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("@bookingtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@coupan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("@campaign", SqlDbType.VarChar);
                objSqlCommand.Parameters["@campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("@bill_amt", SqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("@pageprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("@pageamt", SqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["@pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("@premper", SqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["@premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["@grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("@adsizcolumn", SqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("@billcolumn", SqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("@billarea", SqlDbType.Decimal);

                objSqlCommand.Parameters["@billarea"].Value = Convert.ToDecimal(billarea);

                objSqlCommand.Parameters.Add("@specdiscper", SqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("@spacediscper", SqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("@paidins", SqlDbType.Int);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["@paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient"].Value = varient;

                objSqlCommand.Parameters.Add("@contractname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contractname"].Value = contractname;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;


                ////////////////
                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@cardmonth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("@cardyear", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("@cardno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@adscat3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("@bulletprm", SqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;


                objSqlCommand.Parameters.Add("@receiptdate", SqlDbType.DateTime);
                if (receiptdate == "" || receiptdate == null)
                {
                    objSqlCommand.Parameters["@receiptdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = receiptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        receiptdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = receiptdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        receiptdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@receiptdate"].Value = receiptdate;
                }


                objSqlCommand.Parameters.Add("@prevcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevcioid"].Value = prevcioid;

                objSqlCommand.Parameters.Add("@prevreceipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevreceipt"].Value = prevreceipt;

                objSqlCommand.Parameters.Add("@prev_ga", SqlDbType.Decimal);

                objSqlCommand.Parameters["@prev_ga"].Value = prev_ga;


                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@varient_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient_name"].Value = varient_name;




                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;


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

        public DataSet cancelbooking(string prevbookingid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cancelbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@prevbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevbook"].Value = prevbookingid;


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

        public DataSet fetchbookingdata(string edition, string date)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getbookingdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;




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

        /*new change ankur 24 feb*/
        public DataSet getvaliddate_qbc_New(string dateformat, string datetoadd, string pkgname, string adcat, string center, string adtype, string pkgid, string pkgalias)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("get_validdate_qbc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@DATEFORMAT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DATEFORMAT"].Value = dateformat;

                objSqlCommand.Parameters.Add("@datetoadd", SqlDbType.VarChar);
                if (datetoadd == "" || datetoadd == null)
                {
                    objSqlCommand.Parameters["@datetoadd"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = datetoadd.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datetoadd = mm + "/" + dd + "/" + yy;

                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = datetoadd.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        datetoadd = mm + "/" + dd + "/" + yy;

                    }
                    objSqlCommand.Parameters["@datetoadd"].Value = datetoadd;
                }

                objSqlCommand.Parameters.Add("@pkgname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgname"].Value = pkgname;

                objSqlCommand.Parameters.Add("@adcat1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat1"].Value = adcat;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;

                objSqlCommand.Parameters.Add("@pkgid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgid"].Value = pkgid;

                objSqlCommand.Parameters.Add("@pkgalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgalias"].Value = pkgalias;


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
        public DataSet getvaliddate_qbc(string dateformat, string datetoadd, string pkgname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("get_validdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;




                objSqlCommand.Parameters.Add("@datetoadd", SqlDbType.DateTime);
                if (datetoadd == "" || datetoadd == null)
                {
                    objSqlCommand.Parameters["@datetoadd"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = datetoadd.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datetoadd = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = datetoadd.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        datetoadd = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@datetoadd"].Value = Convert.ToDateTime(datetoadd);
                }


                objSqlCommand.Parameters.Add("@pkgname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgname"].Value = pkgname;


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
        public DataSet bingbgcolor_drp(string category, string coltype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_bingbgcolor", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@category", SqlDbType.VarChar);
                objSqlCommand.Parameters["@category"].Value = category;

                objSqlCommand.Parameters.Add("@coltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coltype"].Value = coltype;




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

        public DataSet bindbgandfont(string cat, string desc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_bindbgandfont", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cat"].Value = cat;

                objSqlCommand.Parameters.Add("@desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@desc"].Value = desc;




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
        public DataSet binduomforedit(string adtype, string desc, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("qbc_binduomedition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@desc"].Value = desc;

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

        public DataSet variable_name(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindvariable", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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

        public DataSet getinserts_combin(string compcode, string code, string desc, string agencytype)
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
                objSqlCommand = GetCommand("gettheinserts_combin", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;


                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

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


        /*new change ankur agency*/
        public DataSet class_getrate_qbcagency(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string noof_ins, string uomdesc, string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpackgaerate_agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@adsucat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@selecdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@insert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert"].Value = insert;

                objSqlCommand.Parameters.Add("@lines", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lines"].Value = lines;


                objSqlCommand.Parameters.Add("@prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prem"].Value = prem;

                objSqlCommand.Parameters.Add("@adcat3", SqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["@adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat3"].Value = adcat3;
                }

                objSqlCommand.Parameters.Add("@adcat4", SqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["@adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("@adcat5", SqlDbType.VarChar);
                if (adcat5 == "")
                {
                    objSqlCommand.Parameters["@adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@noof_ins", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noof_ins"].Value = noof_ins;


                /*new change ankur 17 feb*/
                objSqlCommand.Parameters.Add("@uomdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomdesc"].Value = uomdesc;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;



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

        public DataSet getInsertion_qbc_agency(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string @pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc, string agencycode)
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
                objSqlCommand = GetCommand("qbc_insertsrate_agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@noofinsertion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("@insertiondate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@clickdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.Int);
                /*new change ankur 11 feb*/
                if (flag == "" || flag == null || flag == "null")
                {
                    objSqlCommand.Parameters["@flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@pck", SqlDbType.Decimal);
                /*new change ankur 11 feb*/
                if (pck == "" || pck == null || pck == "null")
                {
                    objSqlCommand.Parameters["@pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                /*new change ankur 11 feb*/
                if (dealrate == "" || dealrate == null || dealrate == "null")
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@checkforor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("@classinserts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("@lines", SqlDbType.VarChar);
                objSqlCommand.Parameters["@lines"].Value = lines;

                objSqlCommand.Parameters.Add("@adcat3", SqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["@adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("@adcat4", SqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["@adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("@adcat5", SqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["@adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("@uomdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomdesc"].Value = uomdesc;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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



        public DataSet insertbookingqbc(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string receiptdate, string prevcioid, string prevreceipt, Decimal prev_ga, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string status, string dateformat, string chktradeval, string sharepub, string fmginsert)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        date_time = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        date_time = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@date_time"].Value = date_time;
                }

                objSqlCommand.Parameters.Add("@adsizetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@booked_by", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("@prevbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("@approvedby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.DateTime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rodate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rodate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }

                objSqlCommand.Parameters.Add("@caption", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption"].Value = caption;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agencyaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("@clientaddresses", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@execzone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@billremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("@printremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@insertion", SqlDbType.Int);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["@insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["@startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@startdate"].Value = startdate;
                }

                objSqlCommand.Parameters.Add("@repeatdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@subcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@pageposition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("@pagetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.Int);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["@pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("@adsizheight", SqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("@adsizwidth", SqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@agreedrate", SqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("@agreedamt", SqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("@spedisc", SqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["@spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@spacedisx", SqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("@specialcharges", SqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@agencystatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@agencredit", SqlDbType.Int);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["@agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@cardamount", SqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["@cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("@discountper", SqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["@discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("@billaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("@totarea", SqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["@totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("@billcycle", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("@billpay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("@billheight", SqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["@billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("@billwidth", SqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["@billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@invoices", SqlDbType.Int);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["@invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("@vts", SqlDbType.Int);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["@vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("@tradedisc", SqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("@agencyout", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("@boxno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("@boxaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("@boxagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("@boxclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("@bookingtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@coupan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("@campaign", SqlDbType.VarChar);
                objSqlCommand.Parameters["@campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("@bill_amt", SqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("@pageprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("@pageamt", SqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["@pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("@premper", SqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["@premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["@grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("@adsizcolumn", SqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("@billcolumn", SqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("@billarea", SqlDbType.Decimal);

                objSqlCommand.Parameters["@billarea"].Value = Convert.ToDecimal(billarea);

                objSqlCommand.Parameters.Add("@specdiscper", SqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("@spacediscper", SqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("@paidins", SqlDbType.Int);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["@paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient"].Value = varient;

                objSqlCommand.Parameters.Add("@contractname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contractname"].Value = contractname;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;


                ////////////////
                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@cardmonth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("@cardyear", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("@cardno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@adscat3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("@bulletprm", SqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;


                objSqlCommand.Parameters.Add("@receiptdate", SqlDbType.DateTime);
                if (receiptdate == "" || receiptdate == null)
                {
                    objSqlCommand.Parameters["@receiptdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = receiptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        receiptdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = receiptdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        receiptdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@receiptdate"].Value = receiptdate;
                }


                objSqlCommand.Parameters.Add("@prevcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevcioid"].Value = prevcioid;

                objSqlCommand.Parameters.Add("@prevreceipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevreceipt"].Value = prevreceipt;

                objSqlCommand.Parameters.Add("@prev_ga", SqlDbType.Decimal);

                objSqlCommand.Parameters["@prev_ga"].Value = prev_ga;


                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@varient_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient_name"].Value = varient_name;

                ////changes
                objSqlCommand.Parameters.Add("@coltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coltype"].Value = coltype;

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_col"].Value = logo_col;

                objSqlCommand.Parameters.Add("@logo_uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_uom"].Value = logo_uom;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;





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

        public DataSet clsGetEditionName(string compcode, string buttonText)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_GetEditionName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@buttonText", SqlDbType.VarChar);
                objSqlCommand.Parameters["@buttonText"].Value = buttonText;

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


        public DataSet clsShow_NoAd()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_tempdata", ref objSqlConnection);
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



        public DataSet clsEdiRights(string compcode, string pkgName, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_ediRights", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                ////objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pubdate"].Value = pubdate;

                objSqlCommand.Parameters.Add("@pkgName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgName"].Value = pkgName;

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
        public DataSet clsSpaceAvailability(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_spaceAvailability", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                ////objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy" && pubdate != "" && pubdate != null)
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pubdate = mm + "/" + dd + "/" + yy;

                }
                objSqlCommand.Parameters["@pubdate"].Value = pubdate;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;


                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

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
        public DataSet clsPagesBookedVol(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, int pgno, string spl_page, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getPagesBookedVol", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                ////objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy" && pubdate != "" && pubdate != null)
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pubdate = mm + "/" + dd + "/" + yy;

                }
                objSqlCommand.Parameters["@pubdate"].Value = pubdate;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;


                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@pgno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgno"].Value = pgno;

                //objSqlCommand.Parameters.Add("@spl_page", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@spl_page"].Value = spl_page;

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



        public DataSet clsgetCurrentBooking(string ciobookid, string iRowid, string ins_id)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getCurrentBooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@iRowid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@iRowid"].Value = iRowid;

                objSqlCommand.Parameters.Add("@ins_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ins_id"].Value = ins_id;

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
        public void clsUpdateBooking_AdDummy(string ciobookid, string iRowid, string ins_id, string pdate, string

      ppub, string pbkfor, string pedition, string psecpub, string pcolour, string psplpage, string padtype, string

      ppageno, string adstatus)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_UpdateBooking_AdDummy", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@iRowid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@iRowid"].Value = iRowid;

                objSqlCommand.Parameters.Add("@ins_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ins_id"].Value = ins_id;

                objSqlCommand.Parameters.Add("@pdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate"].Value = pdate;

                objSqlCommand.Parameters.Add("@ppub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppub"].Value = ppub;

                objSqlCommand.Parameters.Add("@pbkfor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbkfor"].Value = pbkfor;

                objSqlCommand.Parameters.Add("@pedition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pedition"].Value = pedition;

                objSqlCommand.Parameters.Add("@psecpub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psecpub"].Value = psecpub;

                objSqlCommand.Parameters.Add("@pcolour", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolour"].Value = pcolour;

                objSqlCommand.Parameters.Add("@psplpage", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psplpage"].Value = psplpage;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = padtype;

                objSqlCommand.Parameters.Add("@ppageno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppageno"].Value = ppageno;

                objSqlCommand.Parameters.Add("@adstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adstatus"].Value = adstatus;

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
        public void clsUpdatePage_Booking(string ciobookid, string iRowid, string ppageno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_UpdatePage_Booking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@iRowid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@iRowid"].Value = iRowid;

                objSqlCommand.Parameters.Add("@ppageno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppageno"].Value = ppageno;

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
        public DataSet clsIssuePageDetails(string pdate, string pubcode, string centercode, string editioncode, string suppcode, string ppageno, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_IssuePageDetails", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy" && pdate != "" && pdate != null)
                {
                    string[] arr = pdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pdate = mm + "/" + dd + "/" + yy;

                }
                objSqlCommand.Parameters["@pdate"].Value = pdate;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@ppageno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppageno"].Value = ppageno;

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
        public DataSet clsExistingBookingSize(string compcode, string currdate, string pubcode, string centercode, string editioncode, string suppcode, string premium, string adpage)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_ExistingBookingSize", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@currdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currdate"].Value = currdate;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@adpage", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adpage"].Value = adpage;

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
        public DataSet clsExistingBookingVolume(string compcode, string currdate, string edition_Text, string premium, string adpage)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_ExistingBookingVolume", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@currdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currdate"].Value = currdate;

                objSqlCommand.Parameters.Add("@edition_Text", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_Text"].Value = edition_Text;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@adpage", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adpage"].Value = adpage;

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
        public DataSet clsPremiumCode(string compcode, string pubcode, string editioncode, string adPremium)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_PremiumCode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@adPremium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adPremium"].Value = adPremium;

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
        public DataSet clsBookingEditionCode(string compcode, string editionText)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_BookingEditionCode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@editionText", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editionText"].Value = editionText;

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
        public DataSet clsgetSupplementName(string compcode, string buttonText)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_GetSupplementName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@buttonText", SqlDbType.VarChar);
                objSqlCommand.Parameters["@buttonText"].Value = buttonText;

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
        public DataSet clsGetCityCode(string compcode, string editioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_GetCityCode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

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
        public void clsUpdateBooking_AdDummy(string ciobookid, string iRowid, string ins_id, string pdate, string ppub, string pbkfor, string pedition, string psecpub, string pcolour, string psplpage, string padtype, string ppageno, string adstatus, string adfilename, double adheight, double adwidth)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            // DataSet objDataSet = new DataSet();
            objSqlConnection = GetConnection();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_UpdateBooking_AdDummy", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@iRowid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@iRowid"].Value = iRowid;

                objSqlCommand.Parameters.Add("@ins_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ins_id"].Value = ins_id;

                objSqlCommand.Parameters.Add("@pdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate"].Value = pdate;

                objSqlCommand.Parameters.Add("@ppub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppub"].Value = ppub;

                objSqlCommand.Parameters.Add("@pbkfor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbkfor"].Value = pbkfor;

                objSqlCommand.Parameters.Add("@pedition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pedition"].Value = pedition;

                objSqlCommand.Parameters.Add("@psecpub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psecpub"].Value = psecpub;

                objSqlCommand.Parameters.Add("@pcolour", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolour"].Value = pcolour;

                objSqlCommand.Parameters.Add("@psplpage", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psplpage"].Value = psplpage;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = padtype;

                objSqlCommand.Parameters.Add("@ppageno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppageno"].Value = ppageno;

                objSqlCommand.Parameters.Add("@adstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adstatus"].Value = adstatus;

                objSqlCommand.Parameters.Add("@adfilename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adfilename"].Value = adfilename;

                objSqlCommand.Parameters.Add("@adheight", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adheight"].Value = adheight;

                objSqlCommand.Parameters.Add("@adwidth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adwidth"].Value = adwidth;

                //objSqlDataAdapter.SelectCommand = objSqlCommand;
                //objSqlDataAdapter.Fill(objDataSet);
                //return objDataSet;
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

        public DataSet getboxmatter(string retcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getboxmatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retcode"].Value = retcode;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet clsBranchAlias(string compcode, string revenue)
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
                objSqlCommand = GetCommand("Websp_Branchalias", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = revenue;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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
        public DataSet get_rate_qbc(string noofinsertion, string dateformat, string compcode, string uom, string adtype, string currency, string ratecode, string clientcode, string uomdesc, string agencycode, string newcode, string center, string ratepremtype, string premium, string schemetype, int currentcounter, string fdate, string ldate, string chkadon_var, string discprem, string spediscper, string pospremdisc, string designbox, string logoprem)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                string openreferExtra = ConfigurationSettings.AppSettings["openreferExtra"];
                objSqlConnection.Open();
                objSqlCommand = GetCommand("RATE_QBC", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@noofinsertion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@Adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@RATECODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RATECODE"].Value = ratecode;

                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("@uomdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomdesc"].Value = uomdesc;

                objSqlCommand.Parameters.Add("@openreferExtra", SqlDbType.VarChar);
                objSqlCommand.Parameters["@openreferExtra"].Value = openreferExtra;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@newcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@newcode"].Value = newcode;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;

                objSqlCommand.Parameters.Add("@ratepremtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratepremtype"].Value = ratepremtype;

                objSqlCommand.Parameters.Add("@premiumval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premiumval"].Value = premium;

                objSqlCommand.Parameters.Add("@schemetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schemetype"].Value = schemetype;

                objSqlCommand.Parameters.Add("@counter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@counter"].Value = currentcounter;

                objSqlCommand.Parameters.Add("@rateflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateflag"].Value = ConfigurationManager.AppSettings["FETCHMINSIZEPACKAGERATE"].ToString();

                objSqlCommand.Parameters.Add("@fDate", SqlDbType.VarChar);
                if (fdate == "")
                    objSqlCommand.Parameters["@fDate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@fDate"].Value = fdate;

                objSqlCommand.Parameters.Add("@lDate", SqlDbType.VarChar);
                if (ldate == "")
                    objSqlCommand.Parameters["@lDate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@lDate"].Value = ldate;

                objSqlCommand.Parameters.Add("@chkadon_p", SqlDbType.VarChar);
                if (chkadon_var == "")
                    objSqlCommand.Parameters["@chkadon_p"].Value = "";//System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@chkadon_p"].Value = chkadon_var;

                objSqlCommand.Parameters.Add("@discprem_p", SqlDbType.VarChar);
                if (discprem == "" || discprem == "0")
                    objSqlCommand.Parameters["@discprem_p"].Value = "";//System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@discprem_p"].Value = discprem;

                objSqlCommand.Parameters.Add("@spediscper_p", SqlDbType.VarChar);
                if (spediscper == "" || spediscper == "0")
                    objSqlCommand.Parameters["@spediscper_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@spediscper_p"].Value = spediscper;

                objSqlCommand.Parameters.Add("@pospremdisc_p", SqlDbType.VarChar);
                if (pospremdisc == "" || pospremdisc == "0")
                    objSqlCommand.Parameters["@pospremdisc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pospremdisc_p"].Value = pospremdisc;

                objSqlCommand.Parameters.Add("@designbox", SqlDbType.VarChar);
                if (designbox == "" || designbox == "0")
                    objSqlCommand.Parameters["@designbox"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@designbox"].Value = designbox;

                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                if (logoprem == "" || logoprem == "0")
                    objSqlCommand.Parameters["@logoprem"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@logoprem"].Value = logoprem;



                objSqlCommand.Parameters.Add("@style_p", SqlDbType.VarChar);


                objSqlCommand.Parameters["@style_p"].Value = System.DBNull.Value;



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


        public DataSet getAdSizeHeightWidth(string adtype, string adcategory, string col, string edi, string compcode, string code, string uom)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                string openreferExtra = ConfigurationSettings.AppSettings["openreferExtra"];
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getAdSizeHeightWidth", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@col"].Value = col;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@edi", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edi"].Value = edi;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@uomcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomcode"].Value = uom;

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
        public DataSet getCurTime(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETCURTIME", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
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

        ///////////////////bhanu

        public DataSet backdate_validate(string pcompcode, string pformname, string puserid, string pentrydate, string pdateformat, string pextra1, string pextra2)
        {
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                string query = "select dbo.ad_get_backdays_validate('" + pcompcode + "','" + pformname + "','" + puserid + "','" + pentrydate + "','" + pdateformat + "','" + pextra1 + "','" + pextra2 + "')";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
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


        //////////////////////////////

        public DataSet clsFillGrid(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getPageVolume", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (pubdate == "" || pubdate == null)
                {
                    objSqlCommand.Parameters["@pubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pubdate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@pubdate"].Value = pubdate;
                }

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

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


        public DataSet clsFillGridAdVolume(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, int i, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getPlacedAdsVolume", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (pubdate == "" || pubdate == null)
                {
                    objSqlCommand.Parameters["@pubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pubdate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@pubdate"].Value = pubdate;
                }

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@i", SqlDbType.VarChar);
                objSqlCommand.Parameters["@i"].Value = i;

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


        public DataSet clsPlacedAds_Page(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string pageno, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getAdsPlacedonPage", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (pubdate == "" || pubdate == null)
                {
                    objSqlCommand.Parameters["@pubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pubdate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@pubdate"].Value = pubdate;
                }

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageno"].Value = pageno;

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

        public DataSet clsGetBookingID(string recptno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GetBookingID", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@receipt_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receipt_no"].Value = recptno;

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

        public DataSet clsBranchAlias1(string compcode, string branchcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_BranchAlias", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

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

        public DataSet getbengali()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getbengalichar", ref objSqlConnection);
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


        public DataSet bind10agency(string compcode, string userid, string agency, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind10agencyforbooking", ref objSqlConnection);
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

        ///////////////////////////////bhanu6june
        public DataSet fetchmultiexe(string cioid, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchmultiexe", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@cioid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid_p"].Value = cioid;
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

        public void deleteexe(string compcode, string cioid, string code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deleteexe", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;


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

        public DataSet book_chkpublishday_n(string compcode, string pkgname, string dateday, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getperiodDate_Edition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@Compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@pkgname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgname"].Value = pkgname;


                objSqlCommand.Parameters.Add("@dateday", SqlDbType.VarChar);
                if (dateday == "" || dateday == null || dateday == "null")
                {
                    objSqlCommand.Parameters["@dateday"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateday.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateday = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateday.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateday = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@dateday"].Value = dateday;
                }



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

        public DataSet getQBC_n(string pubcode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_QBC_n", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;
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
        public DataSet autogenratedbox1(string compcode, string auto, string no, string center1, string agncodesubcode, string branch)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Getautocodebox", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@auto1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auto1"].Value = auto;

                objSqlCommand.Parameters.Add("@no1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@no1"].Value = no;

                objSqlCommand.Parameters.Add("@center1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center1"].Value = center1;

                objSqlCommand.Parameters.Add("@agency_codescode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_codescode"].Value = agncodesubcode;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@save_val", SqlDbType.VarChar);
                objSqlCommand.Parameters["@save_val"].Value = "A";

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
        public DataSet chkuomfval(string compcode, string uomcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_getuomfvalue", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@p_uomcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_uomcode"].Value = uomcode;


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
        ///////this code is to show the user's Branch Name
        public DataSet getbranchname(string compcode, string p_branchcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AD_GET_BRANCH_NAME", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@branch_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch_code"].Value = p_branchcode;

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
        //================================= To Get Data From  permission Master===========================//
        public DataSet fetchpermisiondata(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ADB_FETCHPERMISSION", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_userid"].Value = userid;

                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra2"].Value = System.DBNull.Value;


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
        public DataSet chkagencyforrevise(string compcode, string agcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ADB_CHKAG_RATEREVISE", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_agcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_agcode"].Value = agcode;

                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra2"].Value = System.DBNull.Value;


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
        //================================Generate temp Booking Id at time of New=========================================//
        public DataSet autogenratedtempid(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETAUTOCODEBOOKING_PRE_SAVE", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@auto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auto"].Value = "0";
                objSqlCommand.Parameters.Add("@no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@no"].Value = "0";

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
        public DataSet ratebindforreviserate(string adcat, string compcode, string revisedate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindratecodeforrevisedate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@previsedate", SqlDbType.VarChar);
                if (revisedate == "" || revisedate == null || revisedate == "null")
                {
                    objSqlCommand.Parameters["@previsedate"].Value = System.DBNull.Value;
                }
                else
                    objSqlCommand.Parameters["@previsedate"].Value = revisedate;


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
        public DataSet bindagencyfromadd(string compcode, string userid, string agency, string center, string agencyaddress)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyfromadd", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = center;

                objSqlCommand.Parameters.Add("@p_agencyaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_agencyaddress"].Value = agencyaddress;

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
        public DataSet bindgencyRemark(string compcode, string bookingid, string agency, string client, string type1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ADB_GETAGENCY_ADD", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@p_agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_agency"].Value = agency;

                objSqlCommand.Parameters.Add("@p_client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_client"].Value = client;

                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = type1;

                objSqlCommand.Parameters.Add("@extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra2"].Value = System.DBNull.Value;

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

        public DataSet getbillnobilldate1(string bookingid, string insertno, string compcode, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ADB_GETBILLNOBILLDAET", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_cioid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@p_insertno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_insertno"].Value = insertno;

                objSqlCommand.Parameters.Add("@p_dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@extra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra3"].Value = System.DBNull.Value;

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
        //===============******** This is to Bind Caption Master **********=============//
        public DataSet bindcaptionname(string compcode, string userid, string caption)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AD_BINDCAPTION", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMPCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@PUSERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUSERID"].Value = userid;

                objSqlCommand.Parameters.Add("@PCAPTION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCAPTION"].Value = caption;

                objSqlCommand.Parameters.Add("@PEXTRA", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA"].Value = System.DBNull.Value;

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
        public DataSet getExecbooking(string compcode, string execname, string value, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getExecbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = adtype;
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
        public DataSet getwords12(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("get_words", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@pcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcioid"].Value = cioid;


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
        public DataSet getagreedamtchk(string compcode, string client, string pack_age, string adtype, string adcategory, string color, string page_prem, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Agrredratechk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@pack_age", SqlDbType.VarChar);
                objSqlCommand.Parameters["@@pack_age"].Value = pack_age;

                objSqlCommand.Parameters.Add("@ad_cat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_code"].Value = adcategory;

                objSqlCommand.Parameters.Add("@ad_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_type"].Value = adtype;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@Page_prem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Page_prem"].Value = page_prem;

                objSqlCommand.Parameters.Add("@Vuserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Vuserid"].Value = userid;



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

        public DataSet getpublication(string compcode, string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fn_pub_combin_code", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcombincode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcombincode"].Value = pubcode;


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
        public DataSet getpublicationlanguage(string compcode, string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pubnamelanguage", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ppubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppubcode"].Value = pubcode;


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
        public DataSet getpubcodeedit(string compcode, string editocode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("QBC_GETPUBFOREDITION", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pedition_alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pedition_alias"].Value = editocode;


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
        public DataSet getstatuspaymodeAgency_e(string agency, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();

                objSqlCommand = GetCommand("getstatuspaymodeAgency_e", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agency;
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
        public string updatepayment(string compcode, string booking)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            string error = "";
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("inuppaymentgateway", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking"].Value = booking;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);



            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
            return error;

        }

        ////anuja///////////
        public DataSet bindindus(string compcode, string indscode, string indusname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ADPRODUCTMAINCAT_P", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ppro_cat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppro_cat_code"].Value = indscode;

                objSqlCommand.Parameters.Add("@pexename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexename"].Value = indusname;


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
        public DataSet bindprocat(string comcode, string insduscode, string producaname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ADPRODUCTSUBCAT_P", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@ppro_cat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppro_cat_code"].Value = insduscode;

                objSqlCommand.Parameters.Add("@pexename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexename"].Value = producaname;


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
        public DataSet procatsub(string compcode, string indscode, string procatcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_product_third_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pindustry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pindustry"].Value = indscode;

                objSqlCommand.Parameters.Add("@prodcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prodcatcode"].Value = procatcode;


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
        public DataSet bindprodyc(string brand, string comcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AN_bindproductcat_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@indus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@indus"].Value = brand;

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
        public DataSet getpubcountdiscount(string compcode, string packagecode, string adcategory, string adsubcategory)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpubcountwithdiscount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

                objSqlCommand.Parameters.Add("@padcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@padsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padsubcat"].Value = adsubcategory;

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
        //****************rikkee, id genrate for namibia

        public DataSet autogenratedtempidnam(string compcode, string auto, string nam, string quotation, string adtype, string systemdate, string savedata, string dateformate, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETAUTOCODEBOOKING_PRE_SAVE_nb", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@auto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auto"].Value = auto;

                objSqlCommand.Parameters.Add("@no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@no"].Value = nam;

                objSqlCommand.Parameters.Add("@pbook_quo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbook_quo"].Value = quotation;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@pdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate"].Value = systemdate;

                objSqlCommand.Parameters["@pdate"].Value = systemdate;

                objSqlCommand.Parameters.Add("@psave_y_s", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psave_y_s"].Value = savedata;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = extra3;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = extra4;


                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = extra5;

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
        public DataSet getExecbooking_agency(string compcode, string adtype, string agmaincode, string agsubcode, string code_subcode, string execname, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7, string extra8, string extra9, string extra10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adv_get_executive", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = adtype;


                objSqlCommand.Parameters.Add("@pagency_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency_main_code"].Value = agmaincode;


                objSqlCommand.Parameters.Add("@pagency_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency_sub_code"].Value = agsubcode;


                objSqlCommand.Parameters.Add("@pagency_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency_code"].Value = code_subcode;

                objSqlCommand.Parameters.Add("@pexecname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecname"].Value = execname;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;


                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = extra3;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = extra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = extra5;


                objSqlCommand.Parameters.Add("@pextra6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra6"].Value = extra6;


                objSqlCommand.Parameters.Add("@pextra7", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra7"].Value = extra7;

                objSqlCommand.Parameters.Add("@pextra8", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra8"].Value = extra8;

                objSqlCommand.Parameters.Add("@pextra9", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra9"].Value = extra9;


                objSqlCommand.Parameters.Add("@pextra10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra10"].Value = extra10;

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

