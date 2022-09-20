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
    /// Summary description for adDummyDayPS
    /// </summary>
    public class adDummyDayPS:connection
    {
        public adDummyDayPS()
        {
            //
            // TODO: Add constructor logic here
            //
        }

//**********This function is used to GET the Pulication Center Name using stored procedure Bind_Pubname*************
        public DataSet getPubCName()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_PubCentName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
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
//**********************************************************************************************************

//**********This function is used to GET the Edition Name using stored procedure Bind_EdiName***************

        public DataSet getEdiName(string pubcode, string pubcenter)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_EdiName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit"].Value = pubcode;
                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = pubcenter;
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
//**********************************************************************************************************

//**********This function is used to GET the Suppliment using stored procedure bindsuppliment***************

        public DataSet getSuppliment(string pubcode, string pubedit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindsuppliment", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = pubcode;
                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = pubedit;
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
//**********************************************************************************************************

//**********This function is used to GET the Category using stored procedure websp_advcategory***************

        public DataSet getCategory(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_advcategory", ref objSqlConnection);
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
//**********************************************************************************************************

        public DataSet getSubCategory(string compcode, string catcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("advsubcattyp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@agencytype"].Value = agencytype;

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
//**********************************************************************************************************
//**********************************************************************************************************

//**********This function is used to check the Duplicate Data using stored procedure adDDPDupChk*********************
        public string chkDupRec(string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            string dup;

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPS_DupChk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_day"].Value = day;

                objSqlCommand.Parameters.Add("@pri_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pri_pub"].Value = pubCode;

                objSqlCommand.Parameters.Add("@pub_center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_center"].Value = centerCode;

                objSqlCommand.Parameters.Add("@edition_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_code"].Value = ediCode;

                objSqlCommand.Parameters.Add("@sub_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sub_pub"].Value = supCode;

                objSqlCommand.Parameters.Add("@page_no", SqlDbType.Int);
                objSqlCommand.Parameters["@page_no"].Value = Convert.ToInt32(pageNo);

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;

                objSqlDataAdapter.Fill(objDataSet);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    dup = "y";
                }
                else
                {
                    dup = "n";
                }
                return dup;
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
//**********************************************************************************************************

//**********This function is used to Insert the Data using stored procedure adDDPInsert***************

        public DataSet insertData(string day, string pubCode, string centerCode, string ediCode, string supCode,string pageNo,string pageHead, string nPages,string adCtg,string subAdCtg,string maxRow,string maxCol,string startRow,string startCol,string maxAd,string pagiCode, string dFrom, string dTo,string ladStatus,string pDate,string pColor,string adVolume, string compCode, string userId)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPS_Insert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_day"].Value = day;

                objSqlCommand.Parameters.Add("@pri_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pri_pub"].Value = pubCode;

                objSqlCommand.Parameters.Add("@pub_center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_center"].Value = centerCode;

                objSqlCommand.Parameters.Add("@edition_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_code"].Value = ediCode;

                objSqlCommand.Parameters.Add("@sub_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sub_pub"].Value = supCode;

                objSqlCommand.Parameters.Add("@page_no", SqlDbType.Int);
                objSqlCommand.Parameters["@page_no"].Value = Convert.ToInt32(pageNo);

                objSqlCommand.Parameters.Add("@page_heading", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_heading"].Value = pageHead;                

                objSqlCommand.Parameters.Add("@npages", SqlDbType.Int);
                objSqlCommand.Parameters["@npages"].Value = Convert.ToInt32(nPages);

                objSqlCommand.Parameters.Add("@priadctg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@priadctg"].Value = adCtg;

                objSqlCommand.Parameters.Add("@secadctg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@secadctg"].Value = subAdCtg;

                objSqlCommand.Parameters.Add("@max_row", SqlDbType.Int);
                objSqlCommand.Parameters["@max_row"].Value = Convert.ToInt32(maxRow);

                objSqlCommand.Parameters.Add("@max_col", SqlDbType.Int);
                objSqlCommand.Parameters["@max_col"].Value = Convert.ToInt32(maxCol);

                objSqlCommand.Parameters.Add("@starting_row", SqlDbType.Int);
                objSqlCommand.Parameters["@starting_row"].Value = Convert.ToInt32(startRow);

                objSqlCommand.Parameters.Add("@starting_col", SqlDbType.Int);
                objSqlCommand.Parameters["@starting_col"].Value = Convert.ToInt32(startCol);

                objSqlCommand.Parameters.Add("@max_ad", SqlDbType.Int);
                objSqlCommand.Parameters["@max_ad"].Value = Convert.ToInt32(maxAd);

                objSqlCommand.Parameters.Add("@pagination_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagination_code"].Value = pagiCode;
                
                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.DateTime);
                objSqlCommand.Parameters["@datefrom"].Value = Convert.ToDateTime(dFrom);
                
                objSqlCommand.Parameters.Add("@dateto", SqlDbType.DateTime);                
                objSqlCommand.Parameters["@dateto"].Value = Convert.ToDateTime(dTo);

                objSqlCommand.Parameters.Add("@ladder_status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ladder_status"].Value = ladStatus;

                objSqlCommand.Parameters.Add("@pdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@pdate"].Value = Convert.ToDateTime(pDate);

                objSqlCommand.Parameters.Add("@page_color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_color"].Value = pColor;

                objSqlCommand.Parameters.Add("@ad_volume", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_volume"].Value = adVolume;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compCode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userId;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                //   objSqlCommand.ExecuteNonQuery();
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

//**********************************************************************************************************

//******This is used to Update the data mod stand for modification, on the basis of this data update will occur************
        public DataSet updateData(string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo, string pageHead, string nPages, string adCtg, string subAdCtg, string maxRow, string maxCol, string startRow, string startCol, string maxAd, string pagiCode, string dFrom, string dTo, string ladStatus, string pDate, string pColor, string adVolume, string compCode, string modDay, string modPubCode,string modCenterCode,string modEdiCode,string modSupCode,string modPageNo)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPS_Modify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_day"].Value = day;

                objSqlCommand.Parameters.Add("@pri_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pri_pub"].Value = pubCode;

                objSqlCommand.Parameters.Add("@pub_center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_center"].Value = centerCode;

                objSqlCommand.Parameters.Add("@edition_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_code"].Value = ediCode;

                objSqlCommand.Parameters.Add("@sub_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sub_pub"].Value = supCode;

                objSqlCommand.Parameters.Add("@page_no", SqlDbType.Int);
                objSqlCommand.Parameters["@page_no"].Value = Convert.ToInt32(pageNo);

                objSqlCommand.Parameters.Add("@page_heading", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_heading"].Value = pageHead;

                objSqlCommand.Parameters.Add("@npages", SqlDbType.Int);
                objSqlCommand.Parameters["@npages"].Value = Convert.ToInt32(nPages);

                objSqlCommand.Parameters.Add("@priadctg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@priadctg"].Value = adCtg;

                objSqlCommand.Parameters.Add("@secadctg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@secadctg"].Value = subAdCtg;

                objSqlCommand.Parameters.Add("@max_row", SqlDbType.Int);
                objSqlCommand.Parameters["@max_row"].Value = Convert.ToInt32(maxRow);

                objSqlCommand.Parameters.Add("@max_col", SqlDbType.Int);
                objSqlCommand.Parameters["@max_col"].Value = Convert.ToInt32(maxCol);

                objSqlCommand.Parameters.Add("@starting_row", SqlDbType.Int);
                objSqlCommand.Parameters["@starting_row"].Value = Convert.ToInt32(startRow);

                objSqlCommand.Parameters.Add("@starting_col", SqlDbType.Int);
                objSqlCommand.Parameters["@starting_col"].Value = Convert.ToInt32(startCol);

                objSqlCommand.Parameters.Add("@max_ad", SqlDbType.Int);
                objSqlCommand.Parameters["@max_ad"].Value = Convert.ToInt32(maxAd);

                objSqlCommand.Parameters.Add("@pagination_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagination_code"].Value = pagiCode;

                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.DateTime);
                objSqlCommand.Parameters["@datefrom"].Value = Convert.ToDateTime(dFrom);

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.DateTime);
                objSqlCommand.Parameters["@dateto"].Value = Convert.ToDateTime(dTo);

                objSqlCommand.Parameters.Add("@ladder_status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ladder_status"].Value = ladStatus;

                objSqlCommand.Parameters.Add("@pdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@pdate"].Value = Convert.ToDateTime(pDate);

                objSqlCommand.Parameters.Add("@page_color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_color"].Value = pColor;

                objSqlCommand.Parameters.Add("@ad_volume", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_volume"].Value = adVolume;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compCode;

                objSqlCommand.Parameters.Add("@mod_pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mod_pub_day"].Value = modDay;

                objSqlCommand.Parameters.Add("@mod_pri_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mod_pri_pub"].Value = modPubCode;

                objSqlCommand.Parameters.Add("@mod_pub_center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mod_pub_center"].Value = modCenterCode;

                objSqlCommand.Parameters.Add("@mod_edition_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mod_edition_code"].Value = modEdiCode;

                objSqlCommand.Parameters.Add("@mod_sub_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mod_sub_pub"].Value = modSupCode;

                objSqlCommand.Parameters.Add("@mod_page_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mod_page_no"].Value = Convert.ToInt32(modPageNo);

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                //   objSqlCommand.ExecuteNonQuery();
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
//**********************************************************************************************************
//**********************************************************************************************************
        public DataSet getData(string compCode, string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPS_Execute", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compCode;

                objSqlCommand.Parameters.Add("@pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_day"].Value = day;

                objSqlCommand.Parameters.Add("@pri_pub", SqlDbType.VarChar);
                if (pubCode == "")
                {
                    objSqlCommand.Parameters["@pri_pub"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@pri_pub"].Value = pubCode;
                }

                objSqlCommand.Parameters.Add("@pub_center", SqlDbType.VarChar);
                if (centerCode == "")
                {
                    objSqlCommand.Parameters["@pub_center"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@pub_center"].Value = centerCode;
                }

                objSqlCommand.Parameters.Add("@edition_code", SqlDbType.VarChar);
                if (ediCode == "")
                {
                    objSqlCommand.Parameters["@edition_code"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@edition_code"].Value = ediCode;
                }

                objSqlCommand.Parameters.Add("@sub_pub", SqlDbType.VarChar);
                if (supCode == "")
                {
                    objSqlCommand.Parameters["@sub_pub"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@sub_pub"].Value = supCode;
                }

                objSqlCommand.Parameters.Add("@page_no", SqlDbType.Int);
                if (pageNo == "")
                {
                    objSqlCommand.Parameters["@page_no"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@page_no"].Value = Convert.ToInt32(pageNo);
                }

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
//**********************************************************************************************************
        //**********************************************************************************************************
        public DataSet deleteData(string compCode, string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPS_Delete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compCode;

                objSqlCommand.Parameters.Add("@pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_day"].Value = day;

                objSqlCommand.Parameters.Add("@pri_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pri_pub"].Value = pubCode;                

                objSqlCommand.Parameters.Add("@pub_center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_center"].Value = centerCode;                

                objSqlCommand.Parameters.Add("@edition_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_code"].Value = ediCode;                

                objSqlCommand.Parameters.Add("@sub_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sub_pub"].Value = supCode;                

                objSqlCommand.Parameters.Add("@page_no", SqlDbType.Int);
                objSqlCommand.Parameters["@page_no"].Value = Convert.ToInt32(pageNo);                

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
//***********************************************************************************************************
    }
}