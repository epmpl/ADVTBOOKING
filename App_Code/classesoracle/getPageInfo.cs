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
    /// <summary>
    /// Summary description for getPageInfo
    /// </summary>
    public class getPageInfo : orclconnection
    {
        public getPageInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void clsSubmitIssuePages(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            //  OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_SubmitIssuePages", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (pubdate == "" || pubdate == null)
                {
                    prm2.Value = System.DBNull.Value;
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
                    prm2.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                }
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

                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOracleCommand.Parameters.Add(prm6);

                // objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleCommand.ExecuteNonQuery();

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
        public void clsPagination(string pubdate, string centercode, string pubcode, string suppcode, string editioncode, int pageno, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            //  OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            // DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Create_Dummy_Pagebestfit", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                //objOraclecommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@compcode"].Value = compcode;

                ////objOraclecommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objOraclecommand.Parameters["@userid"].Value = userid;

                OracleParameter prm1 = new OracleParameter("P_DATE", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (pubdate == "" || pubdate == null)
                {
                    prm1.Value = System.DBNull.Value;
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

                    prm1.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                }
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("P_CNT", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centercode;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("P_PPUB", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("P_SECPUB", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = suppcode;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("P_ED", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("P_PAGE", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pageno;
                objOracleCommand.Parameters.Add(prm6);

                //  objorclDataAdapter.SelectCommand = objOraclecommand;
                objOracleCommand.ExecuteNonQuery();

                //objorclDataAdapter.Fill(objDataSet);
                //return objDataSet;

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
        //ShowAllPage : Update Ad's Position and Page
        public void clsUpdateAd(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string pageno, double xstcol, double ystrow, string iidnum, string pgid, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            //OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            //DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_UpdateAd.websp_UpdateAd_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                //objOraclecommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@compcode"].Value = compcode;

                ////objOraclecommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objOraclecommand.Parameters["@userid"].Value = userid;

                OracleParameter prm1 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (pubdate == "" || pubdate == null)
                {
                    prm1.Value = System.DBNull.Value;
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

                    prm1.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                }
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
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pageno;
                objOracleCommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("xstcol", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = xstcol;
                objOracleCommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ystrow", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ystrow;
                objOracleCommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("iidnum", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = iidnum;
                objOracleCommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pgid", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pgid;
                objOracleCommand.Parameters.Add(prm10);

                // objorclDataAdapter.SelectCommand = objOraclecommand;
                objOracleCommand.ExecuteNonQuery();

                //objorclDataAdapter.Fill(objDataSet);
                //return objDataSet;

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



        public DataSet clsGetIssuePages(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_Issue_number_of_Pages.websp_Issue_number_of_Pages_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objOraclecommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@compcode"].Value = compcode;

                ////objOraclecommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objOraclecommand.Parameters["@userid"].Value = userid;

                OracleParameter prm1 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (pubdate == "" || pubdate == null)
                {
                    prm1.Value = System.DBNull.Value;
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

                    prm1.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centercode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = editioncode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = suppcode;
                objOraclecommand.Parameters.Add(prm5);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet clspageHeading(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_Pageheading_P.Websp_Pageheading", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objOraclecommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@compcode"].Value = compcode;

                ////objOraclecommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objOraclecommand.Parameters["@userid"].Value = userid;

                OracleParameter prm1 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (pubdate == "" || pubdate == null)
                {
                    prm1.Value = System.DBNull.Value;
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

                    prm1.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centercode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = editioncode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = suppcode;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

       



        }
}
