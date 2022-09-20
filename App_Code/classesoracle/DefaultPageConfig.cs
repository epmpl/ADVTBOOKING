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

namespace NewAdbooking.classesoracle
{
    public class DefaultPageConfig :orclconnection
    {
        public DefaultPageConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get Category code
        public DataSet clsCategory(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_Category.Websp_Category_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        //Get center Code from preference
        public DataSet centercode(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("pubcent_proc.pubcent_proc_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("chk_access", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = "0";
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet editioncodes(string centercode, string compcode, string pubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("edition_proc.edition_proc_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = centercode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                //prm3.Direction = ParameterDirection.Output;
                //objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet secpubcodes(string compcode, string userid, string editioncode, string flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_DefAddsecpubs", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editioncode;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = flag;
                objOracleCommand.Parameters.Add(prm4);

                objOracleCommand.Parameters.Add("p_secpub", OracleType.Cursor);
                objOracleCommand.Parameters["p_secpub"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        // new func ---rinki
        public DataSet clsSavenewRecord(string compcode, string userid, string ddlpubcode, string ddlcentercode, string ddleditioncode, string ddlsuppcode, string ddlpgno, string ddlladder, string ddlIssuePage, string txtadctg, string txtadsubctg, string ddlpgheading, string ddlpgcolor, string txtpgheight, string txtpgwidth, string txtstrow, string txtstcol, string txtpgvolume, string txtsharepgstatus, string txtsharepgno, string txtmaxadallow, string txtvalidfromdate, string txtvalidtodate, string dateformat, string ddlPremiumRequired, string ddlHouseAdRequired)  //,string ddlpubname,string ddlcentername,string ddleditionname,string ddlsuppname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_SaveDefPageconfig.websp_SaveDefPageconfig_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ddlpubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ddlpubcode;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ddlcentercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ddlcentercode;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ddleditioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = ddleditioncode;
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ddlsuppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ddlsuppcode;
                objOracleCommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ddlpgno", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ddlpgno;
                objOracleCommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("txtadctg", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = txtadctg;
                objOracleCommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("txtadsubctg", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (txtadsubctg == "" || txtadsubctg == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = txtadsubctg;
                }
                objOracleCommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("ddlpgheading", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = ddlpgheading;
                objOracleCommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ddlpgcolor", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ddlpgcolor;
                objOracleCommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("txtpgheight", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = txtpgheight;
                objOracleCommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("txtpgwidth", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = txtpgwidth;
                objOracleCommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("txtstrow", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = txtstrow;
                objOracleCommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("txtstcol", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = txtstcol;
                objOracleCommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("txtpgvolume", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                if (txtpgvolume == "" || txtpgvolume == null)
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = txtpgvolume;
                }

                objOracleCommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("txtsharepgstatus", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                if (txtsharepgstatus == "" || txtsharepgstatus == null)
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = txtsharepgstatus;
                }

                objOracleCommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("txtsharepgno", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                if (txtsharepgno == "" || txtsharepgno == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = txtsharepgno;
                }

                objOracleCommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("txtmaxadallow", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                if (txtmaxadallow == "" || txtmaxadallow == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = txtmaxadallow;
                }


                objOracleCommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("txtvalidtodate", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                if (txtvalidtodate == "" || txtvalidtodate == null)
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtvalidtodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtvalidtodate = mm + "/" + dd + "/" + yy;
                    }
                    prm20.Value = Convert.ToDateTime(txtvalidtodate).ToString("dd-MMMM-yyyy");
                }

                objOracleCommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("txtvalidfromdate", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                if (txtvalidfromdate == "" || txtvalidfromdate == null)
                {
                    prm21.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtvalidfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtvalidfromdate = mm + "/" + dd + "/" + yy;
                    }
                    prm21.Value = Convert.ToDateTime(txtvalidfromdate).ToString("dd-MMMM-yyyy");
                }

                objOracleCommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("ddlladder", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ddlladder;
                objOracleCommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("ddlIssuePage", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = ddlIssuePage;
                objOracleCommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("ddlPremiumRequired", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = ddlPremiumRequired;
                objOracleCommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("ddlHouseAdRequired", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = ddlHouseAdRequired;
                objOracleCommand.Parameters.Add(prm25);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet clsExecuteRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno, string noofpages, string ddlpgcolor, string ddlPremiumRequired, string flag )
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_defExecuteRecord.Websp_defExecuteRecord_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (suppcode == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = suppcode;
                }
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (pubcode == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = pubcode;
                }
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (centercode == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = centercode;
                }
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (editioncode == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = editioncode;
                }
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pageno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (pageno == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pageno;
                }
                objOracleCommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("noofpages", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (noofpages == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = noofpages;
                }

                objOracleCommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ddlpgcolor", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (ddlpgcolor == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = ddlpgcolor;
                }

                objOracleCommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("ddlPremiumRequired", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (ddlPremiumRequired == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = ddlPremiumRequired;
                }
                objOracleCommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = flag;
                objOracleCommand.Parameters.Add(prm10);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }


        // Modify Page configuration's record
        public DataSet clsModifyRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string ladder, string pageno, string category, string noofpages, string ddlpgcolor, string pageheading, string pageheight, string pagewidth, string maxad, string strow, string stcol, string dt_from, string dt_to, string pagevolume, string dateformat, string ddlPremiumRequired)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_ModifyDefPageconfig.websp_ModifyDefPageconfig_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ddlladder", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ladder;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ddlpubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ddlcentercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centercode;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ddleditioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ddlsuppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOracleCommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ddlpgno", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pageno;
                objOracleCommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("txtadctg", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = category;
                objOracleCommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("txtadsubctg", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = "0";
                objOracleCommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("ddlpgheading", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pageheading;
                objOracleCommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ddlpgcolor", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ddlpgcolor;
                objOracleCommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("txtpgheight", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pageheight;
                objOracleCommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("txtpgwidth", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pagewidth;
                objOracleCommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("txtstrow", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = strow;
                objOracleCommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("txtstcol", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = stcol;
                objOracleCommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("txtpgvolume", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pagevolume;
                objOracleCommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("ddlIssuePage", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = noofpages;
                objOracleCommand.Parameters.Add(prm17);


                OracleParameter prm19 = new OracleParameter("txtmaxadallow", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = maxad;
                objOracleCommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("txtvalidtodate", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                if (dt_to == "" || dt_to == null)
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dt_to.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dt_to = mm + "/" + dd + "/" + yy;
                    }

                    prm20.Value = Convert.ToDateTime(dt_to).ToString("dd-MMMM-yyyy");
                }
                objOracleCommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("txtvalidfromdate", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                if (dt_from == "" || dt_from == null)
                {
                    prm21.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dt_from.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dt_from = mm + "/" + dd + "/" + yy;
                    }

                    prm21.Value = Convert.ToDateTime(dt_from).ToString("dd-MMMM-yyyy");
                }
                objOracleCommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("ddlPremiumRequired", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ddlPremiumRequired;
                objOracleCommand.Parameters.Add(prm22);




                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        // Delete Page configuration's record
        public DataSet clsDeleteRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_DefDeleteRecord", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = suppcode;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centercode;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pageno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pageno;
                objOracleCommand.Parameters.Add(prm6);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet clscheckentry(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno, string noofpages)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_Defchkpagecode.websp_Defchkpagecode_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centercode;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = editioncode;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = suppcode;
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pageno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.InputOutput;
                prm6.Value = pageno;
                objOracleCommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("noofpages", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = noofpages;
                objOracleCommand.Parameters.Add(prm7);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                // objOracleCommand.ExecuteNonQuery();
                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                //DataTable dt1 = new DataTable();
                //DataRow dr = dt1.NewRow();
                //DataColumn d1 = new DataColumn("a1", System.Type.GetType("System.String"));

                //dt1.Columns.Add(d1);
                //dr[0] = prm6.Value;
                //dt1.Rows.Add(dr);
                //objDataSet.Tables.Add(dt1);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


    }
}
