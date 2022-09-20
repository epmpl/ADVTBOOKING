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
namespace NewAdbooking.Report.classesoracle
{
    /// <summary>
    /// Summary description for Categorreport
    /// </summary>
    public class Categorreport : orclconnection
    {
        public Categorreport()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //agedir(txtfrmdate.Text, txttodate1.Text, dpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, dpexec.SelectedValue, dpregion.SelectedValue, dpplace.SelectedValue, dpgroup.SelectedValue,dppage.SelectedItem, Session["compcode"].ToString(), Session["dateformat"].ToString());
        public DataSet categoryreport(string fromdate, string dateto, string adtype, string pub, string pubcent, string execut, string region, string place, string grp, string page, string compcode, string dateformat,string ascdesc,string descid,string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("categoryreport.categoryreport_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

               

                OracleParameter prm2 = new OracleParameter("Adtype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (pubcent == "0" || pubcent == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pub == "0" || pub == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pub;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm1 = new OracleParameter("Region", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (region == "0" || region == "" || region == "--Select Region--")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = region;
                }
                objOraclecommand.Parameters.Add(prm1);
               

                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("execut", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm115 = new OracleParameter("place", OracleType.VarChar);
                prm115.Direction = ParameterDirection.Input;
                if (place == "0" || place == "")
                {
                    prm115.Value = System.DBNull.Value;
                }
                else
                {
                    prm115.Value = place;
                }

                objOraclecommand.Parameters.Add(prm115);


                OracleParameter prm1115 = new OracleParameter("page", OracleType.VarChar);
                prm1115.Direction = ParameterDirection.Input;
                if (page == "0" || page == "")
                {
                    prm1115.Value = System.DBNull.Value;
                }
                else
                {
                    prm1115.Value = page;
                }

                objOraclecommand.Parameters.Add(prm1115);

                OracleParameter prm111 = new OracleParameter("grp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                if (grp == "0" || grp == "")
                {
                    prm111.Value = System.DBNull.Value;
                }
                else
                {
                    prm111.Value = grp;
                }

                objOraclecommand.Parameters.Add(prm111);

                OracleParameter tmp11 = new OracleParameter("descid", OracleType.VarChar);
                tmp11.Direction = ParameterDirection.Input;
                tmp11.Value = descid;
                objOraclecommand.Parameters.Add(tmp11);

                OracleParameter tmp12 = new OracleParameter("ascdesc", OracleType.VarChar);
                tmp12.Direction = ParameterDirection.Input;
                tmp12.Value = ascdesc;
                objOraclecommand.Parameters.Add(tmp12);

                OracleParameter tmp121 = new OracleParameter("value", OracleType.VarChar);
                tmp121.Direction = ParameterDirection.Input;
                tmp121.Value = value;
                objOraclecommand.Parameters.Add(tmp121);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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


        //===============

        //(txtfrmdate.Text, txttodate1.Text, dpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, dpexec.SelectedValue, dpregion.SelectedValue, dpplace.SelectedValue, dpgroup.SelectedValue,dppage.SelectedItem, Session["compcode"].ToString(), Session["dateformat"].ToString());
        public DataSet agedir(string fromdate, string dateto, string adtype, string pub, string pubcent, string execut, string region, string place, string compcode, string dateformat, string ascdesc, string descid, string value, string agtyp)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Agedir.Agedir_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("Adtype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (pubcent == "0" || pubcent == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pub == "0" || pub == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pub;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm1 = new OracleParameter("Region", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (region == "0" || region == "" || region == "--Select Region--")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = region;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("execut", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm115 = new OracleParameter("place", OracleType.VarChar);
                prm115.Direction = ParameterDirection.Input;
                if (place == "0" || place == "")
                {
                    prm115.Value = System.DBNull.Value;
                }
                else
                {
                    prm115.Value = place;
                }

                objOraclecommand.Parameters.Add(prm115);



                OracleParameter tmp11 = new OracleParameter("descid", OracleType.VarChar);
                tmp11.Direction = ParameterDirection.Input;
                tmp11.Value = descid;
                objOraclecommand.Parameters.Add(tmp11);

                OracleParameter tmp12 = new OracleParameter("ascdesc", OracleType.VarChar);
                tmp12.Direction = ParameterDirection.Input;
                tmp12.Value = ascdesc;
                objOraclecommand.Parameters.Add(tmp12);

                OracleParameter tmp121 = new OracleParameter("value", OracleType.VarChar);
                tmp121.Direction = ParameterDirection.Input;
                tmp121.Value = value;
                objOraclecommand.Parameters.Add(tmp121);

                OracleParameter tmp1211 = new OracleParameter("agtyp", OracleType.VarChar);
                tmp1211.Direction = ParameterDirection.Input;
                tmp1211.Value = agtyp;
                objOraclecommand.Parameters.Add(tmp1211);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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
        //team
        public DataSet advpub(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubName.Bind_PubName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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

        public DataSet advtyp(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpremiumforrate_report.bindpremiumforrate_report_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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

        public DataSet page(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpremiumforrate.bindpremiumforrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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



        public DataSet position(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getPagePosition.websp_getPagePosition_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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

        public DataSet bindrevenuecenter(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindrevenuecenter", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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

        public DataSet pub_cent(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("publication_proc.publication_proc_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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


        public DataSet edition(string pubcode, string centercode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {







                objOracleConnection.Open();
                objOraclecommand = GetCommand("edition_proc.edition_proc_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm2 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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


        public OracleDataReader categoryreportexecl(string fromdate, string dateto, string adtype, string pub, string pubcent, string execut, string region, string place, string grp, string page, string compcode, string dateformat, string ascdesc, string descid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("categoryreport.categoryreport_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("Adtype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (pubcent == "0" || pubcent == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pub == "0" || pub == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pub;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm1 = new OracleParameter("Region", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (region == "0" || region == "")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = region;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("execut", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm115 = new OracleParameter("place", OracleType.VarChar);
                prm115.Direction = ParameterDirection.Input;
                if (place == "0" || place == "")
                {
                    prm115.Value = System.DBNull.Value;
                }
                else
                {
                    prm115.Value = place;
                }

                objOraclecommand.Parameters.Add(prm115);


                OracleParameter prm1115 = new OracleParameter("page", OracleType.VarChar);
                prm1115.Direction = ParameterDirection.Input;
                if (page == "0" || page == "")
                {
                    prm1115.Value = System.DBNull.Value;
                }
                else
                {
                    prm1115.Value = page;
                }

                objOraclecommand.Parameters.Add(prm1115);

                OracleParameter prm111 = new OracleParameter("grp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                if (grp == "0" || grp == "")
                {
                    prm111.Value = System.DBNull.Value;
                }
                else
                {
                    prm111.Value = grp;
                }

                objOraclecommand.Parameters.Add(prm111);

                OracleParameter tmp11 = new OracleParameter("descid", OracleType.VarChar);
                tmp11.Direction = ParameterDirection.Input;
                tmp11.Value = descid;
                objOraclecommand.Parameters.Add(tmp11);

                OracleParameter tmp12 = new OracleParameter("ascdesc", OracleType.VarChar);
                tmp12.Direction = ParameterDirection.Input;
                tmp12.Value = ascdesc;
                objOraclecommand.Parameters.Add(tmp12);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();
                return objdatareadre;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
            }


        }


        //team
        public DataSet team(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_team", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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



        //=============
        public DataSet city(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_City", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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

        //Get_Execexec
        public DataSet bindexecutive(string compcode, string team)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Get_Execexec", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("team", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = team;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("get_executive", OracleType.Cursor);
                objOraclecommand.Parameters["get_executive"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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

        public DataSet adname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindadcatexec", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("adcat", OracleType.Cursor);
                objOraclecommand.Parameters["adcat"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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


        //=============
        public DataSet adtypedaily(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adtypedaily", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("adcat", OracleType.Cursor);
                objOraclecommand.Parameters["adcat"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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

        //*******************rikkee

        public DataSet executive(string fromdate, string dateto, string adtype, string team, string execut, string compcode, string dateformat, string ascdesc, string descid, string adcategory1, string publication1, string edition1, string pubce, string useid, string chk_acc, string currency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Executivereport", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("adcategory", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adcategory1 == "0" || adcategory1 == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adcategory1;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm7 = new OracleParameter("team", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (team == "0" || team == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = team;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm15 = new OracleParameter("execut", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "" || execut == "--Select Executive Name--")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm15);


                OracleParameter tmp11 = new OracleParameter("descid", OracleType.VarChar);
                tmp11.Direction = ParameterDirection.Input;
                tmp11.Value = descid;
                objOraclecommand.Parameters.Add(tmp11);

                OracleParameter tmp12 = new OracleParameter("ascdesc", OracleType.VarChar);
                tmp12.Direction = ParameterDirection.Input;
                tmp12.Value = ascdesc;
                objOraclecommand.Parameters.Add(tmp12);



                OracleParameter prm16 = new OracleParameter("adtype1", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype == "")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = adtype;
                }

                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("publication1", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (publication1 == "0" || publication1 == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = publication1;
                }

                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("edition1", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (edition1 == "0" || edition1 == "")
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = edition1;
                }

                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm1e8 = new OracleParameter("pubcent1", OracleType.VarChar);
                prm1e8.Direction = ParameterDirection.Input;
                if (pubce == "0" || pubce == "")
                {
                    prm1e8.Value = System.DBNull.Value;
                }
                else
                {
                    prm1e8.Value = pubce;
                }

                objOraclecommand.Parameters.Add(prm1e8);

                OracleParameter prm30 = new OracleParameter("puserid", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = useid;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("chk_access", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = chk_acc;
                objOraclecommand.Parameters.Add(prm31);



                OracleParameter prm32 = new OracleParameter("pextra1", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = currency;
                objOraclecommand.Parameters.Add(prm32);
                
                
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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
        //*******************

        //=========

        //public DataSet executive(string fromdate, string dateto, string adtype, string team, string execut, string compcode, string dateformat, string ascdesc, string descid, string adcategory1, string publication1, string edition1, string pubce, string useid, string chk_acc)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        //    try
        //    {

        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("Executivereport", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
        //        top1.Direction = ParameterDirection.Input;
        //        top1.Value = useid;
        //        objOraclecommand.Parameters.Add(top1);

        //        OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
        //        top2.Direction = ParameterDirection.Input;
        //        top2.Value = chk_acc;
        //        objOraclecommand.Parameters.Add(top2);



        //        OracleParameter prm2 = new OracleParameter("adcategory", OracleType.VarChar);
        //        prm2.Direction = ParameterDirection.Input;
        //        if (adcategory1 == "0" || adcategory1 == "")
        //        {
        //            prm2.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            prm2.Value = adcategory1;
        //        }
        //        objOraclecommand.Parameters.Add(prm2);



        //        OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
        //        prm4.Direction = ParameterDirection.Input;
        //        if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
        //        {
        //            string[] arr = fromdate.Split('/');
        //            string dd = arr[0];
        //            string mm = arr[1];
        //            string yy = arr[2];
        //            fromdate = mm + "/" + dd + "/" + yy;
        //        }
        //        prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
        //        objOraclecommand.Parameters.Add(prm4);


        //        OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
        //        prm5.Direction = ParameterDirection.Input;
        //        if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
        //        {
        //            string[] arr = dateto.Split('/');
        //            string dd = arr[0];
        //            string mm = arr[1];
        //            string yy = arr[2];
        //            dateto = mm + "/" + dd + "/" + yy;
        //        }
        //        prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
        //        objOraclecommand.Parameters.Add(prm5);

        //        OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
        //        prm6.Direction = ParameterDirection.Input;
        //        prm6.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm6);

        //        OracleParameter prm7 = new OracleParameter("team", OracleType.VarChar);
        //        prm7.Direction = ParameterDirection.Input;
        //        if (team == "0" || team == "")
        //        {
        //            prm7.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            prm7.Value = team;
        //        }
        //        objOraclecommand.Parameters.Add(prm7);




        //        OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
        //        prm14.Direction = ParameterDirection.Input;
        //        prm14.Value = dateformat;
        //        objOraclecommand.Parameters.Add(prm14);

        //        OracleParameter prm15 = new OracleParameter("execut", OracleType.VarChar);
        //        prm15.Direction = ParameterDirection.Input;
        //        if (execut == "0" || execut == "")
        //        {
        //            prm15.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            prm15.Value = execut;
        //        }

        //        objOraclecommand.Parameters.Add(prm15);




        //        OracleParameter tmp11 = new OracleParameter("descid", OracleType.VarChar);
        //        tmp11.Direction = ParameterDirection.Input;
        //        tmp11.Value = descid;
        //        objOraclecommand.Parameters.Add(tmp11);

        //        OracleParameter tmp12 = new OracleParameter("ascdesc", OracleType.VarChar);
        //        tmp12.Direction = ParameterDirection.Input;
        //        tmp12.Value = ascdesc;
        //        objOraclecommand.Parameters.Add(tmp12);



        //        OracleParameter prm16 = new OracleParameter("adtype1", OracleType.VarChar);
        //        prm16.Direction = ParameterDirection.Input;
        //        if (adtype == "0" || adtype == "")
        //        {
        //            prm16.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            prm16.Value = adtype;
        //        }

        //        objOraclecommand.Parameters.Add(prm16);


        //        OracleParameter prm17 = new OracleParameter("publication1", OracleType.VarChar);
        //        prm17.Direction = ParameterDirection.Input;
        //        if (publication1 == "0" || publication1 == "")
        //        {
        //            prm17.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            prm17.Value = publication1;
        //        }

        //        objOraclecommand.Parameters.Add(prm17);


        //        OracleParameter prm18 = new OracleParameter("edition1", OracleType.VarChar);
        //        prm18.Direction = ParameterDirection.Input;
        //        if (edition1 == "0" || edition1 == "")
        //        {
        //            prm18.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            prm18.Value = edition1;
        //        }

        //        objOraclecommand.Parameters.Add(prm18);

        //        OracleParameter prm1e8 = new OracleParameter("pubcent1", OracleType.VarChar);
        //        prm1e8.Direction = ParameterDirection.Input;
        //        if (pubce == "0" || pubce == "")
        //        {
        //            prm1e8.Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            prm1e8.Value = pubce;
        //        }

        //        objOraclecommand.Parameters.Add(prm1e8);

        //        objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

        //        objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


        //        objorclDataAdapter.SelectCommand = objOraclecommand;
        //        objorclDataAdapter.Fill(objDataSet);
        //        return objDataSet;



        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objOracleConnection);
        //    }


        //}

        //-----------------------------------

        public DataSet Dailyrep(string fromdate, string dateto, string adtype, string pub, string pubcen, string compcode, string dateformat, string ascdesc, string descid, string edition, string useid, string chk_acc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Dailyreport", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm2 = new OracleParameter("adcategory", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else


                   if(dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if(dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pub == "0" || pub == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pub;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm15 = new OracleParameter("pubcen", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (pubcen == "0" || pubcen == ""  ||pubcen == "--Select Publication Center--")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = pubcen;
                }

                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm25 = new OracleParameter("edition", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (edition == "0" || edition == "" || edition == "--Select Edition Name--")
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                {
                    prm25.Value = edition;
                }

                objOraclecommand.Parameters.Add(prm25);







                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

              


                OracleParameter tmp11 = new OracleParameter("descid", OracleType.VarChar);
                tmp11.Direction = ParameterDirection.Input;
                tmp11.Value = descid;
                objOraclecommand.Parameters.Add(tmp11);

                OracleParameter tmp12 = new OracleParameter("ascdesc", OracleType.VarChar);
                tmp12.Direction = ParameterDirection.Input;
                tmp12.Value = ascdesc;
                objOraclecommand.Parameters.Add(tmp12);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
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



        public OracleDataReader executiveexcel(string fromdate, string dateto, string adtype, string team, string execut, string compcode, string dateformat, string ascdesc, string descid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Executivereport", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("adcategory", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("team", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (team == "0" || team == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = team;
                }
                objOraclecommand.Parameters.Add(prm7);




                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("execut", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm15);




                OracleParameter tmp11 = new OracleParameter("descid", OracleType.VarChar);
                tmp11.Direction = ParameterDirection.Input;
                tmp11.Value = descid;
                objOraclecommand.Parameters.Add(tmp11);

                OracleParameter tmp12 = new OracleParameter("ascdesc", OracleType.VarChar);
                tmp12.Direction = ParameterDirection.Input;
                tmp12.Value = ascdesc;
                objOraclecommand.Parameters.Add(tmp12);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();
                return objdatareadre;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
            }


        }


    }
}