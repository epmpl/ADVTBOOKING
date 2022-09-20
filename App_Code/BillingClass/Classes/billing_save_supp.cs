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
/// Summary description for billing_save_supp
/// </summary>
/// 
namespace NewAdbooking.BillingClass.Classes
{
    public class billing_save_supp : NewAdbooking.Classes.connection
    {
        public billing_save_supp()
        {
            //
            // TODO: Add constructor logic here
            //
        }




        public DataSet values_bill_p(string invoiceno, string billcycle, string insertion, string compcode, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectvalues_pra_supp", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@pbillcycle", SqlDbType.VarChar);
                com.Parameters["@pbillcycle"].Value = billcycle;

                com.Parameters.Add("@pinvoiceno", SqlDbType.VarChar);
                com.Parameters["@pinvoiceno"].Value = invoiceno;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = compcode;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = dateformat;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = System.DBNull.Value;

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



        public string saveinlast(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert, string dateto, string dateformat, string chk_billtype)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("Bill_Savelast_G_SUPP", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;



                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;

                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = amountforvat;

                com.Parameters.Add("@amt3", SqlDbType.Float);
                com.Parameters["@amt3"].Value = amt3;

                com.Parameters.Add("@insnum_cou", SqlDbType.Float);
                com.Parameters["@insnum_cou"].Value = insnum_cou;


                com.Parameters.Add("@boxchg1", SqlDbType.VarChar);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@doctyp", SqlDbType.VarChar);
                com.Parameters["@doctyp"].Value = doctyp;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = dateto;
                }


                com.Parameters.Add("@maxinsert", SqlDbType.VarChar);
                com.Parameters["@maxinsert"].Value = maxinsert;

                com.Parameters.Add("@chk_billtype", SqlDbType.VarChar);
                com.Parameters["@chk_billtype"].Value = chk_billtype;








                da.SelectCommand = com;
                da.Fill(ds);
                return "Success";
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



        public string save_det_monthly(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string maxdate, string dateformat, string insert_id, string chk_billtype)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("bill_save_det_monthly_supp", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;



                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;

                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = Convert.ToDecimal(grossamt);

                com.Parameters.Add("@edition_name", SqlDbType.VarChar);
                if (edition_name == "0")
                {
                    com.Parameters["@edition_name"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@edition_name"].Value = edition_name;
                }



                com.Parameters.Add("@boxchg1", SqlDbType.VarChar);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                com.Parameters["@noofinsert"].Value = Convert.ToDecimal(ins_num);



                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (maxdate == "" || maxdate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = maxdate;
                }



                com.Parameters.Add("@v_insert_id", SqlDbType.VarChar);
                com.Parameters["@v_insert_id"].Value = insert_id;


                com.Parameters.Add("@chk_billtype", SqlDbType.VarChar);
                com.Parameters["@chk_billtype"].Value = chk_billtype;






                da.SelectCommand = com;
                da.Fill(ds);
                return "Success";
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

        public DataSet receiptinsert(string compcode, string unit, string type, string recpt, string rdate, string paymodres, string receivedreg, string vouno, string amount/*,string damount*/, string agency, string inhand, string othercd, string chno, string chedate, string bank, string narration, string rep, string vdate, string userid, string ag_main_code, string ag_sub_code, string dateformat, string prorec, string bankcashtype, string prodate, string conrecp, string refrecdate, string refrecnum, string refdoctype, string clearence_type, string credit_code, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("receiptsave_supp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@ptype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptype"].Value = type;

                objSqlCommand.Parameters.Add("@precpt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@precpt"].Value = recpt;

                objSqlCommand.Parameters.Add("@prdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@prdate"].Value = Convert.ToDateTime(rdate);

                objSqlCommand.Parameters.Add("@ppaymodres", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppaymodres"].Value = paymodres;

                objSqlCommand.Parameters.Add("@preceivedreg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@preceivedreg"].Value = receivedreg;

                objSqlCommand.Parameters.Add("@pvouno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pvouno"].Value = vouno;


                objSqlCommand.Parameters.Add("@pvdate", SqlDbType.DateTime);
                if (vdate == "")
                {
                    objSqlCommand.Parameters["@pvdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pvdate"].Value = Convert.ToDateTime(vdate);
                }

                objSqlCommand.Parameters.Add("@pamount", SqlDbType.Decimal);
                if (amount == "")
                {
                    objSqlCommand.Parameters["@pamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pamount"].Value = Convert.ToDecimal(amount);
                }
                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agency;

                objSqlCommand.Parameters.Add("@pothercd", SqlDbType.VarChar);
                if (othercd == "")
                {
                    objSqlCommand.Parameters["@pothercd"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pothercd"].Value = othercd;
                }

                objSqlCommand.Parameters.Add("@pchno", SqlDbType.VarChar);
                if (chno == "" || chno == null)
                {
                    objSqlCommand.Parameters["@pchno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pchno"].Value = chno;
                }

                objSqlCommand.Parameters.Add("@pchedate", SqlDbType.DateTime);
                if (chedate == "")
                {
                    objSqlCommand.Parameters["@pchedate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pchedate"].Value = Convert.ToDateTime(chedate);
                }

                objSqlCommand.Parameters.Add("@pbank", SqlDbType.VarChar);
                if (bank == "0")
                {
                    objSqlCommand.Parameters["@pbank"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbank"].Value = bank;
                }

                objSqlCommand.Parameters.Add("@pnarration", SqlDbType.VarChar);
                if (narration == "")
                {
                    objSqlCommand.Parameters["@pnarration"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pnarration"].Value = narration;
                }

                objSqlCommand.Parameters.Add("@prep", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prep"].Value = rep;

                objSqlCommand.Parameters.Add("@pag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_main_code"].Value = ag_main_code;

                objSqlCommand.Parameters.Add("@pag_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_sub_code"].Value = ag_sub_code;

                objSqlCommand.Parameters.Add("@prov_receipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prov_receipt"].Value = prorec;

                //objSqlCommand.Parameters.Add("@bankcashtype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@bankcashtype"].Value = bankcashtype;

                //objSqlCommand.Parameters.Add("@provreceiptdate", SqlDbType.DateTime);
                //if (prodate == "")
                //{
                //    objSqlCommand.Parameters["@provreceiptdate"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@provreceiptdate"].Value = Convert.ToDateTime(prodate);
                //}

                //objSqlCommand.Parameters.Add("@conrecept", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@conrecept"].Value = conrecp;

                //objSqlCommand.Parameters.Add("@prefrecptdt", SqlDbType.DateTime);
                //if (refrecdate == "")
                //{
                //    objSqlCommand.Parameters["@prefrecptdt"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@prefrecptdt"].Value = Convert.ToDateTime(refrecdate);
                //}

                //objSqlCommand.Parameters.Add("@prefrecnum", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@prefrecnum"].Value = refrecnum;

                //objSqlCommand.Parameters.Add("@prefdoctype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@prefdoctype"].Value = refdoctype;



                //objSqlCommand.Parameters.Add("@pcredit_cdp", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pcredit_cdp"].Value = credit_code;

                //objSqlCommand.Parameters.Add("@pclr_type", SqlDbType.VarChar);
                //if (clearence_type == "0")
                //{
                //    objSqlCommand.Parameters["@pclr_type"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@pclr_type"].Value = clearence_type;
                //}




                //objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pextra1"].Value = extra1;

                //objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pextra2"].Value = extra2;



                //objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pextra3"].Value = extra3;

                //objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pextra4"].Value = extra4;



                //objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pextra5"].Value = extra5;

                //objSqlCommand.Parameters.Add("@pextra6", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pextra6"].Value = extra6;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);

                return ds;

            }
            catch (Exception e)
            {

                throw (e);
            }

            finally
            {

                CloseConnection(ref objSqlConnection);
            }









        }

        //for inserting into ad_rcptdet

        public DataSet receiptinsert1(string compcode, string unit, string type, string recpt, string rdate, string paymodres, string receivedreg, string vouno, string amount/*,string damount*/, string agency, string inhand, string othercd, string chno, string chedate, string bank, string narration, string rep, string vdate, string userid, string ag_main_code, string ag_sub_code, string dateformat, string refrecdate, string refrecnum, string refdoctype)
        {


            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("receiptsave1_supp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@ptype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptype"].Value = type;

                objSqlCommand.Parameters.Add("@precpt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@precpt"].Value = recpt;

                objSqlCommand.Parameters.Add("@prdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@prdate"].Value = Convert.ToDateTime(rdate);

                objSqlCommand.Parameters.Add("@ppaymodres", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppaymodres"].Value = paymodres;

                objSqlCommand.Parameters.Add("@preceivedreg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@preceivedreg"].Value = receivedreg;

                objSqlCommand.Parameters.Add("@pvouno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pvouno"].Value = vouno;


                objSqlCommand.Parameters.Add("@pvdate", SqlDbType.DateTime);
                if (vdate == "")
                {
                    objSqlCommand.Parameters["@pvdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pvdate"].Value = Convert.ToDateTime(vdate);
                }

                objSqlCommand.Parameters.Add("@pamount", SqlDbType.Decimal);
                if (amount == "")
                {
                    objSqlCommand.Parameters["@pamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pamount"].Value = Convert.ToDecimal(amount);
                }
                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agency;

                objSqlCommand.Parameters.Add("@pchno", SqlDbType.VarChar);
                if (chno == "" || chno == null)
                {
                    objSqlCommand.Parameters["@pchno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pchno"].Value = chno;
                }

                objSqlCommand.Parameters.Add("@pchedate", SqlDbType.DateTime);
                if (chedate == "")
                {
                    objSqlCommand.Parameters["@pchedate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pchedate"].Value = Convert.ToDateTime(chedate);
                }

                objSqlCommand.Parameters.Add("@pbank", SqlDbType.VarChar);
                if (bank == "0")
                {
                    objSqlCommand.Parameters["@pbank"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbank"].Value = bank;
                }

                objSqlCommand.Parameters.Add("@pag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_main_code"].Value = ag_main_code;

                objSqlCommand.Parameters.Add("@pag_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_sub_code"].Value = ag_sub_code;

                //objSqlCommand.Parameters.Add("@prefrecptdt", SqlDbType.DateTime);
                //if (refrecdate == "")
                //{
                //    objSqlCommand.Parameters["@prefrecptdt"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@prefrecptdt"].Value = Convert.ToDateTime(refrecdate);
                //}

                //objSqlCommand.Parameters.Add("@prefrecnum", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@prefrecnum"].Value = refrecnum;

                //objSqlCommand.Parameters.Add("@prefdoctype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@prefdoctype"].Value = refdoctype;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);

                return ds;

            }
            catch (Exception e)
            {
                throw (e);
            }

            finally
            {

                CloseConnection(ref objSqlConnection);
            }



        }











        public DataSet receiptinsert2(string compcode, string unit, string type, string recpt, string rdate, string paymodres, string receivedreg, string vouno, string amount/*,string damount*/, string agency, string inhand, string othercd, string chno, string chedate, string bank, string narration, string rep, string vdate, string userid, string ag_main_code, string ag_sub_code, string dateformat, string refrecdate, string refrecnum, string refdoctype)
        {


            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("receiptsave2_supp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@ptype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptype"].Value = type;

                objSqlCommand.Parameters.Add("@precpt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@precpt"].Value = recpt;

                objSqlCommand.Parameters.Add("@prdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@prdate"].Value = Convert.ToDateTime(rdate);

                objSqlCommand.Parameters.Add("@ppaymodres", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppaymodres"].Value = paymodres;

                objSqlCommand.Parameters.Add("@preceivedreg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@preceivedreg"].Value = receivedreg;

                objSqlCommand.Parameters.Add("@pvouno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pvouno"].Value = vouno;


                objSqlCommand.Parameters.Add("@pvdate", SqlDbType.DateTime);
                if (vdate == "")
                {
                    objSqlCommand.Parameters["@pvdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pvdate"].Value = Convert.ToDateTime(vdate);
                }

                objSqlCommand.Parameters.Add("@pamount", SqlDbType.Decimal);
                if (amount == "")
                {
                    objSqlCommand.Parameters["@pamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pamount"].Value = Convert.ToDecimal(amount);
                }
                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agency;

                objSqlCommand.Parameters.Add("@pag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_main_code"].Value = ag_main_code;

                objSqlCommand.Parameters.Add("@pag_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_sub_code"].Value = ag_sub_code;

                //objSqlCommand.Parameters.Add("@prefrecptdt", SqlDbType.DateTime);
                //if (refrecdate == "")
                //{
                //    objSqlCommand.Parameters["@prefrecptdt"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@prefrecptdt"].Value = Convert.ToDateTime(refrecdate);
                //}

                //objSqlCommand.Parameters.Add("@prefrecnum", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@prefrecnum"].Value = refrecnum;

                //objSqlCommand.Parameters.Add("@prefdoctype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@prefdoctype"].Value = refdoctype;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);

                return ds;

            }
            catch (Exception e)
            {
                throw (e);
            }

            finally
            {

                CloseConnection(ref objSqlConnection);
            }



        }



        public DataSet checkReceiptno(string compcode, string prefix, string suffix, string cond_chk, string vdoctype, string rcptdt, string dateformat)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkreceiptno", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_prefix_recpt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_prefix_recpt"].Value = prefix;

                objSqlCommand.Parameters.Add("@p_sufix_recpt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_sufix_recpt"].Value = suffix;

                objSqlCommand.Parameters.Add("@pdoctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdoctype"].Value = vdoctype;

                objSqlCommand.Parameters.Add("@precptdt", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = rcptdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    rcptdt = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = rcptdt.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    rcptdt = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@precptdt"].Value = rcptdt;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pcond_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_flag"].Value = cond_chk;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet selectbranchalias(string branchname)
        {
             SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("selectbranchalias", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@pbranch_code", SqlDbType.VarChar);
                com.Parameters["@pbranch_code"].Value = branchname;
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


        public DataSet values_bill_supp(string ciobooking, string editionname, string insertion, string compcode, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectvalues_bill", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;

                com.Parameters.Add("@editionname", SqlDbType.VarChar);
                com.Parameters["@editionname"].Value = editionname;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;

                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;



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



        public DataSet packagecode(string ciobookingid, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_packagecode_supp", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobookingid;


                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

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

        public DataSet edition(string editioncode, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectedition_supp", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@editoncode", SqlDbType.VarChar);
                com.Parameters["@editoncode"].Value = editioncode;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

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



        public DataSet values_bill(string ciobooking, string editionname, string insertion, string compcode, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectvalues_bill", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;

                com.Parameters.Add("@editionname", SqlDbType.VarChar);
                com.Parameters["@editionname"].Value = editionname;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;

                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;



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



        
        public DataSet websp_bindciobookingid(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string retainer_name, string executive_name, string branch_name, string ad_category, string district, string taluka, string comcode, string BILL_GEN_PRIOR, string PUB_CENT_HO, string billno, string centerlogin, string fmg_bills)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_bindcioidlatest12_supp", ref con);
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






                com.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication != "0")
                {


                    com.Parameters["@publication"].Value = publication;
                }
                else
                {
                    com.Parameters["@publication"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@bookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@bookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@bookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@revenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@revenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@agencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@agencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@package"].Value = package;
                }
                else
                {
                    com.Parameters["@package"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@client"].Value = client;
                }
                else
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;
                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;
                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                //if ((billcycle == "0") || (billcycle == "1"))
                //{
                //    com.Parameters["@billcycle"].Value = "0" + "','" + "1";
                //}
                //else
                //{
                com.Parameters["@billcycle"].Value = billcycle;
                //}




                com.Parameters.Add("@v_retainer_name", SqlDbType.VarChar);
                if (retainer_name != "")
                {
                    com.Parameters["@v_retainer_name"].Value = retainer_name;
                }
                else
                {
                    com.Parameters["@v_retainer_name"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@v_executive_name", SqlDbType.VarChar);
                if (executive_name != "")
                {
                    com.Parameters["@v_executive_name"].Value = executive_name;
                }
                else
                {
                    com.Parameters["@v_executive_name"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@v_branch_name", SqlDbType.VarChar);
                if (branch_name != "-Select Branch-")
                {
                    com.Parameters["@v_branch_name"].Value = branch_name;
                }
                else
                {
                    com.Parameters["@v_branch_name"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@v_ad_category", SqlDbType.VarChar);
                if (ad_category != "0")
                {
                    com.Parameters["@v_ad_category"].Value = ad_category;
                }
                else
                {
                    com.Parameters["@v_ad_category"].Value = System.DBNull.Value;
                }



                com.Parameters.Add("@v_district", SqlDbType.VarChar);
                if (district != "0")
                {
                    com.Parameters["@v_district"].Value = district;
                }
                else
                {
                    com.Parameters["@v_district"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@v_taluka", SqlDbType.VarChar);
                if (taluka != "0")
                {
                    com.Parameters["@v_taluka"].Value = taluka;
                }
                else
                {
                    com.Parameters["@v_taluka"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = comcode;


                com.Parameters.Add("@billno", SqlDbType.VarChar);
                if (billno != "")
                {
                    com.Parameters["@billno"].Value = billno;
                }
                else
                {
                    com.Parameters["@billno"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@BILL_GEN_PRIOR", SqlDbType.VarChar);
                if (BILL_GEN_PRIOR == "")
                {
                    com.Parameters["@BILL_GEN_PRIOR"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@BILL_GEN_PRIOR"].Value = BILL_GEN_PRIOR;
                }


                com.Parameters.Add("@PUB_CENT_HO", SqlDbType.VarChar);
                if (PUB_CENT_HO == "")
                {
                    com.Parameters["@PUB_CENT_HO"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@PUB_CENT_HO"].Value = PUB_CENT_HO;
                }


                com.Parameters.Add("@centerlogin", SqlDbType.VarChar);
                com.Parameters["@centerlogin"].Value = centerlogin;



                com.Parameters.Add("@fmg_bills", SqlDbType.VarChar);
                com.Parameters["@fmg_bills"].Value = fmg_bills;








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



        public DataSet settemprec(string comcode, string bookid, string insert, string bill_cycle, string fromdate, string tilldate, string pubdate, string bill_process_id, string userid, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("ad_for_bill_process_supp", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = comcode;

                com.Parameters.Add("@pbookingid", SqlDbType.VarChar);
                if (bookid == "" || bookid == null)
                {
                    com.Parameters["@pbookingid"].Value = System.DBNull.Value;
                }
                else
                {
                    //com.Parameters["@pbookingid"].Value =Convert.ToInt32(bookid);
                    com.Parameters["@pbookingid"].Value = bookid;
                }

                com.Parameters.Add("@pbkid_no_insert", SqlDbType.VarChar);
                com.Parameters["@pbkid_no_insert"].Value = insert;

                com.Parameters.Add("@pbill_cycle", SqlDbType.VarChar);
                com.Parameters["@pbill_cycle"].Value = bill_cycle;


                com.Parameters.Add("@pdatefrom", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@pdatefrom"].Value = System.DBNull.Value;
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

                    com.Parameters["@pdatefrom"].Value = fromdate;
                }


                com.Parameters.Add("@pdateto", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@pdateto"].Value = System.DBNull.Value;
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

                    com.Parameters["@pdateto"].Value = tilldate;
                }

                com.Parameters.Add("@ppubdate", SqlDbType.VarChar);
                com.Parameters["@ppubdate"].Value = pubdate;

                com.Parameters.Add("@pbill_process_id", SqlDbType.VarChar);
                if (bill_process_id == "" || bill_process_id == null)
                {
                    com.Parameters["@pbill_process_id"].Value = System.DBNull.Value;
                }
                else
                {
                    //com.Parameters["@pbill_process_id"].Value =Convert.ToInt32(bill_process_id);
                    com.Parameters["@pbill_process_id"].Value = bill_process_id;
                }

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = userid;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = dateformat;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = System.DBNull.Value;

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
        public DataSet billproces(string comcode, string bill_cycle, string fromdate, string tilldate, string bill_process_id, string userid, string dateformat, string adtype)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("adbill_monthly_insert_process_supp", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = comcode;

                com.Parameters.Add("@pbill_cycle", SqlDbType.VarChar);
                com.Parameters["@pbill_cycle"].Value = bill_cycle;


                com.Parameters.Add("@pdatefrom", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@pdatefrom"].Value = System.DBNull.Value;
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

                    com.Parameters["@pdatefrom"].Value = fromdate;
                }


                com.Parameters.Add("@pdateto", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@pdateto"].Value = System.DBNull.Value;
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

                    com.Parameters["@pdateto"].Value = tilldate;
                }

                com.Parameters.Add("@pbill_process_id", SqlDbType.VarChar);
                if (bill_process_id == "" || bill_process_id == null)
                {
                    com.Parameters["@pbill_process_id"].Value = System.DBNull.Value;
                }
                else
                {
                    //com.Parameters["@pbill_process_id"].Value =Convert.ToInt32(bill_process_id);
                    com.Parameters["@pbill_process_id"].Value = bill_process_id;
                }

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = userid;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = dateformat;

                com.Parameters.Add("@padtype", SqlDbType.VarChar);
                com.Parameters["@padtype"].Value = adtype;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = System.DBNull.Value;

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