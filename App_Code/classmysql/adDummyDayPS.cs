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
              public DataSet getPubName(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_Pubname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
           
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet getPubCName()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_PubCentName", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        //**********************************************************************************************************

        //**********This function is used to GET the Edition Name using stored procedure Bind_EdiName***************

        public DataSet getEdiName(string pubcode, string pubcenter)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_EdiName", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit"].Value = pubcode;
                objmysqlcommand.Parameters.Add("center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["center"].Value = pubcenter;
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        //**********************************************************************************************************

        //**********This function is used to GET the Suppliment using stored procedure bindsuppliment***************

        public DataSet getSuppliment(string pubcode, string pubedit)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindsuppliment", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = pubcode;
                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = pubedit;
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        //**********************************************************************************************************

        //**********This function is used to GET the Category using stored procedure websp_advcategory***************

        public DataSet getCategory(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_advcategory", ref objmysqlconnection);
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
        //**********************************************************************************************************

        public DataSet getSubCategory(string compcode, string catcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advsubcattyp", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["agencytype"].Value = agencytype;

                objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["catcode"].Value = catcode;

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
        //**********************************************************************************************************
        //**********************************************************************************************************

        //**********This function is used to check the Duplicate Data using stored procedure adDDPDupChk*********************
        public string chkDupRec(string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            string dup;

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adDDPS_DupChk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pub_day", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_day"].Value = day;

                objmysqlcommand.Parameters.Add("pri_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pri_pub"].Value = pubCode;

                objmysqlcommand.Parameters.Add("pub_center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_center"].Value = centerCode;

                objmysqlcommand.Parameters.Add("edition_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition_code"].Value = ediCode;

                objmysqlcommand.Parameters.Add("sub_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sub_pub"].Value = supCode;

                objmysqlcommand.Parameters.Add("page_no", MySqlDbType.Int32);
                objmysqlcommand.Parameters["page_no"].Value = Convert.ToInt32(pageNo);

               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;

                objmysqlDataAdapter.Fill(objDataSet);
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
                objmysqlconnection.Close();

            }
        }
        //**********************************************************************************************************

        //**********This function is used to Insert the Data using stored procedure adDDPInsert***************

        public DataSet insertData(string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo, string pageHead, string nPages, string adCtg, string subAdCtg, string maxRow, string maxCol, string startRow, string startCol, string maxAd, string pagiCode, string dFrom, string dTo, string ladStatus, string pDate, string pColor, string adVolume, string compCode, string userId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adDDPS_Insert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pub_day", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_day"].Value = day;

                objmysqlcommand.Parameters.Add("pri_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pri_pub"].Value = pubCode;

                objmysqlcommand.Parameters.Add("pub_center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_center"].Value = centerCode;

                objmysqlcommand.Parameters.Add("edition_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition_code"].Value = ediCode;

                objmysqlcommand.Parameters.Add("sub_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sub_pub"].Value = supCode;

                objmysqlcommand.Parameters.Add("page_no", MySqlDbType.Int32);
                objmysqlcommand.Parameters["page_no"].Value = Convert.ToInt32(pageNo);

                objmysqlcommand.Parameters.Add("page_heading", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["page_heading"].Value = pageHead;

                objmysqlcommand.Parameters.Add("npages", MySqlDbType.Int32);
                objmysqlcommand.Parameters["npages"].Value = Convert.ToInt32(nPages);

                objmysqlcommand.Parameters.Add("priadctg", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["priadctg"].Value = adCtg;

                objmysqlcommand.Parameters.Add("secadctg", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["secadctg"].Value = subAdCtg;

                objmysqlcommand.Parameters.Add("max_row", MySqlDbType.Int32);
                objmysqlcommand.Parameters["max_row"].Value = Convert.ToInt32(maxRow);

                objmysqlcommand.Parameters.Add("max_col", MySqlDbType.Int32);
                objmysqlcommand.Parameters["max_col"].Value = Convert.ToInt32(maxCol);

                objmysqlcommand.Parameters.Add("starting_row", MySqlDbType.Int32);
                objmysqlcommand.Parameters["starting_row"].Value = Convert.ToInt32(startRow);

                objmysqlcommand.Parameters.Add("starting_col", MySqlDbType.Int32);
                objmysqlcommand.Parameters["starting_col"].Value = Convert.ToInt32(startCol);

                objmysqlcommand.Parameters.Add("max_ad", MySqlDbType.Int32);
                objmysqlcommand.Parameters["max_ad"].Value = Convert.ToInt32(maxAd);

                objmysqlcommand.Parameters.Add("pagination_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pagination_code"].Value = pagiCode;

                objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["datefrom"].Value = Convert.ToDateTime(dFrom);

                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["dateto"].Value = Convert.ToDateTime(dTo);

                objmysqlcommand.Parameters.Add("ladder_status", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ladder_status"].Value = ladStatus;

                objmysqlcommand.Parameters.Add("pdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["pdate"].Value = Convert.ToDateTime(pDate);

                objmysqlcommand.Parameters.Add("page_color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["page_color"].Value = pColor;

                objmysqlcommand.Parameters.Add("ad_volume", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ad_volume"].Value = adVolume;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compCode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userId;

               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                //   objmysqlcommand.ExecuteNonQuery();
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        //**********************************************************************************************************

        //******This is used to Update the data mod stand for modification, on the basis of this data update will occur************
        public DataSet updateData(string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo, string pageHead, string nPages, string adCtg, string subAdCtg, string maxRow, string maxCol, string startRow, string startCol, string maxAd, string pagiCode, string dFrom, string dTo, string ladStatus, string pDate, string pColor, string adVolume, string compCode, string modDay, string modPubCode, string modCenterCode, string modEdiCode, string modSupCode, string modPageNo)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adDDPS_Modify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pub_day", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_day"].Value = day;

                objmysqlcommand.Parameters.Add("pri_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pri_pub"].Value = pubCode;

                objmysqlcommand.Parameters.Add("pub_center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_center"].Value = centerCode;

                objmysqlcommand.Parameters.Add("edition_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition_code"].Value = ediCode;

                objmysqlcommand.Parameters.Add("sub_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sub_pub"].Value = supCode;

                objmysqlcommand.Parameters.Add("page_no", MySqlDbType.Int32);
                objmysqlcommand.Parameters["page_no"].Value = Convert.ToInt32(pageNo);

                objmysqlcommand.Parameters.Add("page_heading", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["page_heading"].Value = pageHead;

                objmysqlcommand.Parameters.Add("npages", MySqlDbType.Int32);
                objmysqlcommand.Parameters["npages"].Value = Convert.ToInt32(nPages);

                objmysqlcommand.Parameters.Add("priadctg", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["priadctg"].Value = adCtg;

                objmysqlcommand.Parameters.Add("secadctg", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["secadctg"].Value = subAdCtg;

                objmysqlcommand.Parameters.Add("max_row", MySqlDbType.Int32);
                objmysqlcommand.Parameters["max_row"].Value = Convert.ToInt32(maxRow);

                objmysqlcommand.Parameters.Add("max_col", MySqlDbType.Int32);
                objmysqlcommand.Parameters["max_col"].Value = Convert.ToInt32(maxCol);

                objmysqlcommand.Parameters.Add("starting_row", MySqlDbType.Int32);
                objmysqlcommand.Parameters["starting_row"].Value = Convert.ToInt32(startRow);

                objmysqlcommand.Parameters.Add("starting_col", MySqlDbType.Int32);
                objmysqlcommand.Parameters["starting_col"].Value = Convert.ToInt32(startCol);

                objmysqlcommand.Parameters.Add("max_ad", MySqlDbType.Int32);
                objmysqlcommand.Parameters["max_ad"].Value = Convert.ToInt32(maxAd);

                objmysqlcommand.Parameters.Add("pagination_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pagination_code"].Value = pagiCode;

                objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["datefrom"].Value = Convert.ToDateTime(dFrom);

                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["dateto"].Value = Convert.ToDateTime(dTo);

                objmysqlcommand.Parameters.Add("ladder_status", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ladder_status"].Value = ladStatus;

                objmysqlcommand.Parameters.Add("pdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["pdate"].Value = Convert.ToDateTime(pDate);

                objmysqlcommand.Parameters.Add("page_color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["page_color"].Value = pColor;

                objmysqlcommand.Parameters.Add("ad_volume", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ad_volume"].Value = adVolume;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compCode;

                objmysqlcommand.Parameters.Add("mod_pub_day", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mod_pub_day"].Value = modDay;

                objmysqlcommand.Parameters.Add("mod_pri_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mod_pri_pub"].Value = modPubCode;

                objmysqlcommand.Parameters.Add("mod_pub_center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mod_pub_center"].Value = modCenterCode;

                objmysqlcommand.Parameters.Add("mod_edition_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mod_edition_code"].Value = modEdiCode;

                objmysqlcommand.Parameters.Add("mod_sub_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mod_sub_pub"].Value = modSupCode;

                objmysqlcommand.Parameters.Add("mod_page_no", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mod_page_no"].Value = Convert.ToInt32(modPageNo);

               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                //   objmysqlcommand.ExecuteNonQuery();
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        //**********************************************************************************************************
        //**********************************************************************************************************
        public DataSet getData(string compCode, string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adDDPS_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compCode;

                objmysqlcommand.Parameters.Add("pub_day", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_day"].Value = day;

                objmysqlcommand.Parameters.Add("pri_pub", MySqlDbType.VarChar);
                if (pubCode == "")
                {
                    objmysqlcommand.Parameters["pri_pub"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["pri_pub"].Value = pubCode;
                }

                objmysqlcommand.Parameters.Add("pub_center", MySqlDbType.VarChar);
                if (centerCode == "")
                {
                    objmysqlcommand.Parameters["pub_center"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["pub_center"].Value = centerCode;
                }

                objmysqlcommand.Parameters.Add("edition_code", MySqlDbType.VarChar);
                if (ediCode == "")
                {
                    objmysqlcommand.Parameters["edition_code"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["edition_code"].Value = ediCode;
                }

                objmysqlcommand.Parameters.Add("sub_pub", MySqlDbType.VarChar);
                if (supCode == "")
                {
                    objmysqlcommand.Parameters["sub_pub"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["sub_pub"].Value = supCode;
                }

                objmysqlcommand.Parameters.Add("page_no", MySqlDbType.Int32);
                if (pageNo == "")
                {
                    objmysqlcommand.Parameters["page_no"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["page_no"].Value = Convert.ToInt32(pageNo);
                }

               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;

                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        //**********************************************************************************************************
        //**********************************************************************************************************
        public DataSet deleteData(string compCode, string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adDDPS_Delete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compCode;

                objmysqlcommand.Parameters.Add("pub_day", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_day"].Value = day;

                objmysqlcommand.Parameters.Add("pri_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pri_pub"].Value = pubCode;

                objmysqlcommand.Parameters.Add("pub_center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_center"].Value = centerCode;

                objmysqlcommand.Parameters.Add("edition_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition_code"].Value = ediCode;

                objmysqlcommand.Parameters.Add("sub_pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sub_pub"].Value = supCode;

                objmysqlcommand.Parameters.Add("page_no", MySqlDbType.Int32);
                objmysqlcommand.Parameters["page_no"].Value = Convert.ToInt32(pageNo);

                
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;

                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        //***********************************************************************************************************
    }
}