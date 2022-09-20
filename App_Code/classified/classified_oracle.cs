using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

/// <summary>
/// Summary description for classified_oracle
/// </summary>
/// 
namespace NewAdbooking.classified 
{
    public class classified_oracle : NewAdbooking.classesoracle.orclconnection
    {
        public classified_oracle()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindmainchannel()
        {

          OracleConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select * from adv_cat_mast where adv_type='WE0'";
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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

        public DataSet bindmainchannel_sec(string Getid, string typ)
        {

            OracleConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select fld_id,fld_name from cat_field_mst where cat_cd='" + Getid + "' and fld_type='" + typ + "'";
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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
        public int maxid_ID()
        {
            OracleConnection cn = GetConnection();
            int ab = 0;
            try
            {
                string query = "select isnull(max(fld_id)+1,1) from cat_field_mst";
                OracleCommand cmd = new OracleCommand(query, cn);
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
        public int maxid_ID_fld_option()
        {
            OracleConnection cn = GetConnection();
            int ab = 0;
            try
            {
                string query = "select isnull(max(fld_id)+1,1) from fld_option_mst";
                OracleCommand cmd = new OracleCommand(query, cn);
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
        public OracleCommand insertMainclassifiedcat(int maxid, int catid, string Fieldname, string fldtype)
        {
            OracleConnection cn = GetConnection();
            try
            {
                OracleCommand cmd = new OracleCommand("classified_category", cn);
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

        public OracleCommand insertMainclassifiedcat_option(int maxid, int catid, string Fieldname)
        {
            OracleConnection cn = GetConnection();
            try
            {
                OracleCommand cmd = new OracleCommand("classified_category_optional", cn);
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

            OracleConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select * from cat_field_mst where cat_cd='" + Getcd + "'";
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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


        public DataSet get_val_from_table(string id)
        {

            OracleConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select * from cat_field_mst where fld_id=" + id + "";
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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


        public DataSet getFields(String code)
        {
            OracleConnection cn = GetConnection();
            cn.Open();
            DataSet ds = new DataSet();
            string ab = "0";
            try
            {
                string query = "select fld_id,fld_name,fld_len,fld_type from cat_field_mst where cat_cd='" + code + "'";
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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
            OracleConnection cn = GetConnection();
            cn.Open();
            DataSet ds = new DataSet();
            string ab = "0";
            try
            {
                string query = "select auto_id,opt_name from fld_option_mst where fld_id='" + Fid + "'";
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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

        public OracleCommand deletefld(string fld_id)
        {
            OracleConnection cn = GetConnection();
            try
            {
                cn.Open();
                string query = "delete from cat_field_mst where fld_id=@fld_id";
                OracleCommand cmd = new OracleCommand(query, cn);
                cmd.Parameters.Add("@fld_id",OracleType.VarChar).Value = fld_id;
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

        public OracleCommand update_table(string str)
        {
            OracleConnection cn = GetConnection();
            cn.Open();
            OracleCommand cmd = new OracleCommand(str, cn);
            cmd.ExecuteNonQuery();
            CloseConnection(ref cn);
            return cmd;            
        }
        public DataSet bindSubCat(string cd)
        {
            OracleConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select Adv_Subcat_Code,Adv_Subcat_Name from adv_subcat_mast where adv_cat_code='" + cd + "'";
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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
            OracleConnection cn = GetConnection();
            try
            {
                DataSet ds = new DataSet();
                string qry = "select \"Country_Code\",\"Country_Name\" from count_mst where \"Comp_Code\"='" + compcode + "'";
                if (flg == "ctr")
                {
                    qry = "select \"Country_Code\",\"Country_Name\" from count_mst where \"Comp_Code\"='" + compcode + "' and \"Country_Code\"='" + cCode + "'";
                }
                //=========State
                if (flg == "st")
                {
                    qry = "select \"State_Code\",\"State_Name\" from state_mst where \"Comp_Code\"='" + compcode + "' and \"Country_Code\"='" + cCode + "'";
                }
                if (flg == "stt")
                {
                    qry = "select \"State_Code\",\"State_Name\" from state_mst where \"Comp_Code\"='" + compcode + "' and \"State_Code\"='" + cCode + "'";
                }
                //=========City
                if (flg == "ct")
                {
                    qry = "select \"City_Code\",\"City_Name\" from city_mst where \"State_Code\"='" + cCode + "' and \"Comp_Code\"='" + compcode + "'";
                }
                if (flg == "ctt")
                {
                    qry = "select \"City_Code\",\"City_Name\" from city_mst where \"City_Code\"='" + cCode + "' and \"Comp_Code\"='" + compcode + "'";
                }
                OracleCommand cmd = new OracleCommand(qry, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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
            OracleConnection cn = GetConnection();
            try
            {
                cn.Open();
                string query = "update online_admaster set extend_id='" + exId + "' where ad_id=" + adid + "";
                OracleCommand cmd = new OracleCommand(query, cn);
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
            OracleConnection cn = GetConnection();
            cn.Open();
            int ab = 0;
            try
            {
                string query = "select isnull(max(ad_id)+1,1) from online_admaster";
                OracleCommand cmd = new OracleCommand(query, cn);
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
            OracleParameter[] objParam = new OracleParameter[22];
            objParam[0] = new OracleParameter("adv_id", adid);
            objParam[1] = new OracleParameter("adv_loc_id", loc_id);
            objParam[2] = new OracleParameter("adv_cat_code", cat);
            objParam[3] = new OracleParameter("adv_scat_code", scat);
            objParam[4] = new OracleParameter("adv_sscat_code", sscat);
            objParam[5] = new OracleParameter("adv_title", adtitle);
            objParam[6] = new OracleParameter("adv_desc", addesc);
            objParam[7] = new OracleParameter("adv_img", adimg);
            objParam[8] = new OracleParameter("adv_mail", admail);
            objParam[9] = new OracleParameter("adv_phn", adphn);
            objParam[10] = new OracleParameter("adv_feature", adfeature);
            objParam[11] = new OracleParameter("adv_user", ad_uid);
            objParam[12] = new OracleParameter("adv_urg", adurg);
            objParam[13] = new OracleParameter("adv_hot", adhot);
            objParam[14] = new OracleParameter("adv_home", adhome);
            objParam[15] = new OracleParameter("adv_type", adtype);
            objParam[16] = new OracleParameter("adv_prc", adprc);
            objParam[17] = new OracleParameter("adv_url", adurl);

            objParam[18] = new OracleParameter("@pubid", pubid);
            objParam[19] = new OracleParameter("@videopath", videopath);
            objParam[20] = new OracleParameter("@ipadr", ipadr);
            objParam[21] = new OracleParameter("@expiredate", expdate);

            OracleConnection cn = GetConnection();
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            OracleCommand cmd = new OracleCommand("sp_ins_webad", cn);
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
            OracleParameter[] objParam = new OracleParameter[3];
            objParam[0] = new OracleParameter("adv_id", adid);
            objParam[1] = new OracleParameter("child_id", chID);
            objParam[2] = new OracleParameter("child_val", chVal);

            OracleConnection cn = GetConnection();
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            OracleCommand cmd = new OracleCommand("sp_ins_childfield", cn);
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
            OracleConnection cn = GetConnection();
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
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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
            OracleConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = "select ad_id,loc_id,ad_title from online_admaster where extend_id='" + adid + "'";
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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
            OracleConnection cn = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                string query = " select fld_id,fld_value from admaster_child where ad_id='" + adid + "' and fld_id='" + fldId + "'";
                OracleCommand cmd = new OracleCommand(query, cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
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
            OracleConnection cn = GetConnection();
            try
            {
                cn.Open();
                int retVal = 0;
                string query = "select count(ad_id) from online_admaster where extend_id='" + exId + "'";
                OracleCommand cmd = new OracleCommand(query, cn);
                retVal = int.Parse(cmd.ExecuteScalar().ToString());
                if (retVal > 0)
                {
                    query = "update online_admaster set ad_title='" + title + "',cat_code='" + cat + "',scat_code='" + scat + "',ad_type='" + adtype + "',loc_id='" + loc + "' where extend_id='" + exId + "'";
                    cmd = new OracleCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    query = "delete from admaster_child where ad_id='" + mainid + "'";
                    cmd = new OracleCommand(query, cn);
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
            OracleConnection cn = GetConnection();
            try
            {
                cn.Open();
                string query = "select State_Code from city_mst where City_Code='" + lcId + "'";
                OracleCommand cmd = new OracleCommand(query, cn);
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
