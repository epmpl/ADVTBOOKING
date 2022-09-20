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
/// Summary description for classified_mysql
/// </summary>
/// 

namespace NewAdbooking.classified 
{
    public class classified_mysql : NewAdbooking.classmysql.connection 
    {
        public classified_mysql()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindmainchannel()
        {
            MySqlConnection objSqlConnection;
           objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select * from adv_cat_mast where adv_type='WE0'";
                MySqlCommand cmd = new MySqlCommand(query, objSqlConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }



        }
        public DataSet bindmainchannel_sec(string Getval, string typ)
        {
            MySqlConnection objSqlConnection;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select fld_id,fld_name from cat_field_mst where cat_cd='" + Getval + "' and fld_type='" + typ + "'";
                MySqlCommand cmd = new MySqlCommand(query, objSqlConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }



        }
        public int maxid_ID()
        {
            MySqlConnection cn = GetConnection();
            int ab = 0;
            try
            {
                string query = "select isnull(max(fld_id)+1,1) from cat_field_mst";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                ab = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
            return ab;
        }
        public int maxid_ID_fld_opt_mst()
        {
            MySqlConnection cn = GetConnection();
            int ab = 0;
            try
            {
                string query = "select isnull(max(fld_id)+1,1) from fld_option_mst";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                ab = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
            return ab;
        }

        public MySqlCommand insertMainclassifiedcat(int maxid, int catid, string Fieldname, string fldtype)
        {
            MySqlConnection cn = GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand("sp_ins_classified_category", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fld_id", maxid);
                cmd.Parameters.AddWithValue("@cat_id", catid);
                cmd.Parameters.AddWithValue("@fld_name", Fieldname);
                cmd.Parameters.AddWithValue("@fld_type", fldtype);
                if (fldtype == "R" || fldtype == "C" || fldtype == "S")
                {
                    cmd.Parameters.AddWithValue("@fld_len", 50);
                }
                if (fldtype == "D")
                {
                    cmd.Parameters.AddWithValue("@fld_len", 10);
                }
                if (fldtype == "L")
                {
                    cmd.Parameters.AddWithValue("@fld_len", 1);
                }
                if (fldtype == "N")
                {
                    cmd.Parameters.AddWithValue("@fld_len", 20);
                }
                if (fldtype == "T")
                {
                    cmd.Parameters.AddWithValue("@fld_len", 200);
                }

                cmd.ExecuteNonQuery();
                return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }

        }

        public MySqlCommand insertMainclassifiedcat_option(int maxid, int catid, string Fieldname)
        {
            MySqlConnection cn = GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand("sp_ins_classified_category_optional", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@auto_id", maxid);
                cmd.Parameters.AddWithValue("@fld_id", catid);
                cmd.Parameters.AddWithValue("@opt_name", Fieldname);



                cmd.ExecuteNonQuery();
                return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }

        }

        public DataSet Bind_calssified_grid(string Getcd)
        {
            MySqlConnection objSqlConnection;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select * from cat_field_mst where cat_cd='" + Getcd + "'";
                MySqlCommand cmd = new MySqlCommand(query, objSqlConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet get_val_from_table(string Getcd)
        {
            MySqlConnection objSqlConnection;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select * from cat_field_mst where fld_id=" + Getcd + "";
                MySqlCommand cmd = new MySqlCommand(query, objSqlConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }



        }


        public DataSet getFields(String code)
        {
            MySqlConnection cn = GetConnection();
            cn.Open();
            DataSet ds = new DataSet();
            string ab = "0";
            try
            {
                string query = "select fld_id,fld_name,fld_len,fld_type from cat_field_mst where cat_cd='" + code + "'";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }
        public DataSet getFieldOption(string Fid)
        {
            MySqlConnection cn = GetConnection();
            cn.Open();
            DataSet ds = new DataSet();
            string ab = "0";
            try
            {
                string query = "select auto_id,opt_name from fld_option_mst where fld_id='" + Fid + "'";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }

        public MySqlCommand deletefld(string fld_id)
        {
            MySqlConnection cn = GetConnection();
            try
            {
                cn.Open();
                string query = "delete from cat_field_mst where fld_id=@fld_id";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@fld_id", MySqlDbType.VarChar).Value = fld_id;
                cmd.ExecuteNonQuery();
                return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }

        public MySqlCommand update_table(string str)
        {
            MySqlConnection cn = GetConnection();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            CloseConnection(ref cn);
            return cmd;
        }
        public DataSet bindSubCat(string cd)
        {
            MySqlConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select Adv_Subcat_Code,Adv_Subcat_Name from adv_subcat_mast where adv_cat_code='" + cd + "'";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }
        public DataSet getLocation(string compcode, string flg, string cCode)
        {
            MySqlConnection cn = GetConnection();
            try
            {
                DataSet ds = new DataSet();
                string qry = "select Country_Code,Country_Name from count_mst where Comp_Code='" + compcode + "'";
                if (flg == "ctr")
                {
                    qry = "select Country_Code,Country_Name from count_mst where Comp_Code='" + compcode + "' and Country_Code='" + cCode + "'";
                }
                //=========State
                if (flg == "st")
                {
                    qry = "select State_Code,State_Name from state_mst where Comp_Code='" + compcode + "' and Country_Code='" + cCode + "'";
                }
                if (flg == "stt")
                {
                    qry = "select State_Code,State_Name from state_mst where Comp_Code='" + compcode + "' and State_Code='" + cCode + "'";
                }
                //=========City
                if (flg == "ct")
                {
                    qry = "select City_Code,City_Name from city_mst where State_Code='" + cCode + "' and Comp_Code='" + compcode + "'";
                }
                if (flg == "ctt")
                {
                    qry = "select City_Code,City_Name from city_mst where City_Code='" + cCode + "' and Comp_Code='" + compcode + "'";
                }
                MySqlCommand cmd = new MySqlCommand(qry, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }
        public void extend_online(string adid, string exId)
        {
            MySqlConnection cn = GetConnection();
            try
            {
                cn.Open();
                string query = "update online_admaster set extend_id='" + exId + "' where ad_id=" + adid + "";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }
        public int maxid_online()
        {
            MySqlConnection cn = GetConnection();
            cn.Open();
            int ab = 0;
            try
            {
                string query = "select isnull(max(ad_id)+1,1) from online_admaster";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                ab = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
            return ab;
        }
        public void insertOnlineAdv(int adid, string loc_id, string cat, string scat, string sscat,
           string adtitle, string addesc, string adimg, string admail, string adphn, string adfeature,
           int ad_uid, string adurg, string adhot, string adhome, string adtype, string adprc, string adurl,
            string pubid, string videopath, string ipadr, string expdate)
        {
            MySqlParameter[] objParam = new MySqlParameter[22];
            objParam[0] = new MySqlParameter("@adv_id", adid);
            objParam[1] = new MySqlParameter("@adv_loc_id", loc_id);
            objParam[2] = new MySqlParameter("@adv_cat_code", cat);
            objParam[3] = new MySqlParameter("@adv_scat_code", scat);
            objParam[4] = new MySqlParameter("@adv_sscat_code", sscat);
            objParam[5] = new MySqlParameter("@adv_title", adtitle);
            objParam[6] = new MySqlParameter("@adv_desc", addesc);
            objParam[7] = new MySqlParameter("@adv_img", adimg);
            objParam[8] = new MySqlParameter("@adv_mail", admail);
            objParam[9] = new MySqlParameter("@adv_phn", adphn);
            objParam[10] = new MySqlParameter("@adv_feature", adfeature);
            objParam[11] = new MySqlParameter("@adv_user", ad_uid);
            objParam[12] = new MySqlParameter("@adv_urg", adurg);
            objParam[13] = new MySqlParameter("@adv_hot", adhot);
            objParam[14] = new MySqlParameter("@adv_home", adhome);
            objParam[15] = new MySqlParameter("@adv_type", adtype);
            objParam[16] = new MySqlParameter("@adv_prc", adprc);
            objParam[17] = new MySqlParameter("@adv_url", adurl);

            objParam[18] = new MySqlParameter("@pubid", pubid);
            objParam[19] = new MySqlParameter("@videopath", videopath);
            objParam[20] = new MySqlParameter("@ipadr", ipadr);
            objParam[21] = new MySqlParameter("@expiredate", expdate);

            MySqlConnection cn = GetConnection();
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            MySqlCommand cmd = new MySqlCommand("sp_ins_webad", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(objParam);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
        }
        public void insertChildField(int adid, string chVal, string chID)
        {
            MySqlParameter[] objParam = new MySqlParameter[3];
            objParam[0] = new MySqlParameter("@adv_id", adid);
            objParam[1] = new MySqlParameter("@child_id", chID);
            objParam[2] = new MySqlParameter("@child_val", chVal);

            MySqlConnection cn = GetConnection();
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            MySqlCommand cmd = new MySqlCommand("sp_ins_childfield", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(objParam);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
        }
        public DataSet getMappingCatCode(string catCd, string scatCd)
        {
            MySqlConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select cat_code_o from online_mapping where cat_code_p='" + catCd + "'";
                if (scatCd != "")
                {
                    query += " and subcat_p='" + scatCd + "'";
                }
                else
                {
                    query += " and subcat_p is null";
                }
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }
        public DataSet getAdbasicDetail(string adid)
        {
            MySqlConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select ad_id,loc_id,ad_title from online_admaster where extend_id='" + adid + "';";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }
        public DataSet getFieldDetail(string adid, string fldId)
        {
            MySqlConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = " select fld_id,fld_value from admaster_child where ad_id='" + adid + "' and fld_id='" + fldId + "'";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }
        public int update_extended(string exId, string loc, string cat, string scat, string adtype, string title, string mainid)
        {
            MySqlConnection cn = GetConnection();
            try
            {
                cn.Open();
                int retVal = 0;
                string query = "select count(ad_id) from online_admaster where extend_id='" + exId + "'";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                retVal = int.Parse(cmd.ExecuteScalar().ToString());
                if (retVal > 0)
                {
                    query = "update online_admaster set ad_title='" + title + "',cat_code='" + cat + "',scat_code='" + scat + "',ad_type='" + adtype + "',loc_id='" + loc + "' where extend_id='" + exId + "'";
                    cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    query = "delete from admaster_child where ad_id='" + mainid + "'";
                    cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                }
                cmd.Dispose();
                cn.Close();
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }
        public string getParentLoc(string lcId)
        {
            MySqlConnection cn = GetConnection();
            try
            {
                cn.Open();
                string query = "select State_Code from city_mst where City_Code='" + lcId + "'";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                string retVal = cmd.ExecuteScalar().ToString();
                cmd.Dispose();
                cn.Close();
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref cn);
            }
        }
    }
}
