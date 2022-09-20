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
    /// Summary description for vtsclass
    /// </summary>
    public class vtsrpt : orclconnection
    {
        public vtsrpt()
        {
            //
            // TODO: Add constructor logic here
            //

        }


        public DataSet booking1(string agnecycode, string clientcode, string fromdate, string dateto, string pubname, string pubcent, string branch_c, string edition, string dateformat, string userid, string compcode, string chk_acc, string agencytype, string extra1, string extra2,string currency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_booking_report", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pagency_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (agnecycode == "0" || agnecycode == "")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = agnecycode;
                }

                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pclient_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (clientcode == "0" || clientcode == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = clientcode;
                }

                objOraclecommand.Parameters.Add(prm2);



                //OracleParameter prm3 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //prm3.Value = fromdate;
                //objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("pto_date", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = dateto;
                //objOraclecommand.Parameters.Add(prm4);

               
                OracleParameter prm3 = new OracleParameter("pfrom_date", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "0" || fromdate == "")
                {
                    prm3.Value = System.DBNull.Value;
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


                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pto_date", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateto == "0" || dateto == "")
                {
                    prm4.Value = System.DBNull.Value;
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



                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);









                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("ppublication", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (pubname == "0" || pubname == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pubname;
                }

                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pedition", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (edition == "0" || edition == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = edition;
                }

                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ppub_center", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (pubcent == "0" || pubcent == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = pubcent;
                }

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (branch_c == "0" || branch_c == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = branch_c;
                }

                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = compcode;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("chk_access", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = "0";
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pagency_type", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (agencytype == "0" || agencytype == "")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = agencytype;
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (extra1 == "0" || extra1 == "")
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = extra1;
                }

                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                if (extra2 == "0" || extra2 == "")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = extra2;
                }

                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
              
                    prm16.Value = currency;
                

                objOraclecommand.Parameters.Add(prm16);

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


        public DataSet vtsreport(string edition, string agency_code, string from_date, string to_date, string client_code, string publication, string pub_center, string branch, string dateformat, string userid, string compcode, string chk_access, string clienttype, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("Rpt_vts_Report", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pedition", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                if (edition == "0" || edition == "")
                {
                     prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = edition;

                }
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pagency_code", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                if (agency_code == "0" || agency_code == "")
                {
                     prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = agency_code;

                }
                
                cmd.Parameters.Add(prm2);

                //OracleParameter prm3 = new OracleParameter("pfrom_date", OracleType.VarChar, 2000);
                //prm3.Direction = ParameterDirection.Input;
                //prm3.Value = from_date;
                //cmd.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("pto_date", OracleType.VarChar, 2000);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = to_date;
                //cmd.Parameters.Add(prm4);



                OracleParameter prm3 = new OracleParameter("pfrom_date", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (from_date == "0" || from_date == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = Convert.ToDateTime(from_date).ToString("dd-MMMM-yyyy");
                }
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pto_date", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (to_date == "0" || to_date == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(to_date).ToString("dd-MMMM-yyyy");
                }
                cmd.Parameters.Add(prm4);


                OracleParameter prm224 = new OracleParameter("pclient_code", OracleType.VarChar, 2000);
                prm224.Direction = ParameterDirection.Input;
                if (client_code == "0" || client_code == "")
                {
                    prm224.Value = System.DBNull.Value;
                }
                else
                {
                    prm224.Value = client_code;

                }
               
                cmd.Parameters.Add(prm224);

                OracleParameter prm2214 = new OracleParameter("ppublication", OracleType.VarChar, 2000);
                prm2214.Direction = ParameterDirection.Input;
                if (publication == "0" || publication == "")
                {
                    prm2214.Value = System.DBNull.Value;
                }
                else
                {
                    prm2214.Value = publication;

                }
                cmd.Parameters.Add(prm2214);

                OracleParameter prm22 = new OracleParameter("ppub_center", OracleType.VarChar, 2000);
                prm22.Direction = ParameterDirection.Input;
                if (pub_center == "0" || pub_center == "")
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    prm22.Value = pub_center;

                }
                
                cmd.Parameters.Add(prm22);

                OracleParameter prm221 = new OracleParameter("pbranch", OracleType.VarChar, 2000);
                prm221.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "")
                {
                    prm221.Value = System.DBNull.Value;
                }
                else
                {
                    prm221.Value = branch;
                }
                
                cmd.Parameters.Add(prm221);

                OracleParameter prm21 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                cmd.Parameters.Add(prm21);

                OracleParameter prm31 = new OracleParameter("puserid", OracleType.VarChar, 2000);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = userid;
                cmd.Parameters.Add(prm31);

                OracleParameter prm41 = new OracleParameter("pcompcode", OracleType.VarChar, 2000);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = compcode;
                cmd.Parameters.Add(prm41);

                OracleParameter prm222 = new OracleParameter("chk_access", OracleType.VarChar, 2000);
                prm222.Direction = ParameterDirection.Input;
                prm222.Value = chk_access;
                cmd.Parameters.Add(prm222);

                OracleParameter prm250 = new OracleParameter("clienttype", OracleType.VarChar, 2000);
                prm250.Direction = ParameterDirection.Input;
                if (clienttype == "0" || clienttype == "")
                {
                    prm250.Value = "R";
                }
                else
                {
                    prm250.Value = clienttype;
                }

                cmd.Parameters.Add(prm250);


                //OracleParameter prm226 = new OracleParameter("pad_type", OracleType.VarChar, 2000);
                //prm221.Direction = ParameterDirection.Input;
                //if (adtype == "0" || adtype == "")
                //{
                //    prm221.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm221.Value = adtype;
                //}

                OracleParameter prm225 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm225.Direction = ParameterDirection.Input;
                if (extra1 == "0" || extra1 == "")
                {
                    prm225.Value = System.DBNull.Value;
                }
                else
                {
                    prm225.Value = extra1;
                }
                cmd.Parameters.Add(prm225);

                OracleParameter prm223 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm223.Direction = ParameterDirection.Input;
                if (extra2 == "0" || extra2 == "")
                {
                    prm223.Value = System.DBNull.Value;
                }
                else
                {
                    prm223.Value = extra2;
                }
                cmd.Parameters.Add(prm223);


                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
    }


}