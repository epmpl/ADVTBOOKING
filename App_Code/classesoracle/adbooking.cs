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
/// Summary description for adbooking
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class adbooking : orclconnection
    {
        public adbooking()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet chkSpaceEdiPageDateWise(string editionname, string compcode, string pageno, string date_p, string edition_area, string inserthei_p, string insertwid_p, string dateformat, string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkSpaceEdiPageDateWise", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editionname_p", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editionname;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1a = new OracleParameter("compcode_p", OracleType.VarChar);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = compcode;
                objOraclecommand.Parameters.Add(prm1a);

                OracleParameter prm1b = new OracleParameter("pageno_p", OracleType.VarChar);
                prm1b.Direction = ParameterDirection.Input;
                prm1b.Value = pageno;
                objOraclecommand.Parameters.Add(prm1b);

                OracleParameter prm1c = new OracleParameter("date_p", OracleType.VarChar);
                prm1c.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = date_p.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    date_p = mm + "/" + dd + "/" + yy;


                }

                prm1c.Value = Convert.ToDateTime(date_p).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm1c);

                OracleParameter prm1d = new OracleParameter("edition_area", OracleType.VarChar);
                prm1d.Direction = ParameterDirection.Input;
                prm1d.Value = edition_area;
                objOraclecommand.Parameters.Add(prm1d);

                OracleParameter prm1e = new OracleParameter("inserthei_p", OracleType.VarChar);
                prm1e.Direction = ParameterDirection.Input;
                prm1e.Value = inserthei_p;
                objOraclecommand.Parameters.Add(prm1e);

                OracleParameter prm1f = new OracleParameter("insertwid_p", OracleType.VarChar);
                prm1f.Direction = ParameterDirection.Input;
                prm1f.Value = insertwid_p;
                objOraclecommand.Parameters.Add(prm1f);

                OracleParameter prm1g = new OracleParameter("extra1", OracleType.VarChar);
                prm1g.Direction = ParameterDirection.Input;
                prm1g.Value = cioid;
                objOraclecommand.Parameters.Add(prm1g);

                OracleParameter prm1h = new OracleParameter("extra2", OracleType.VarChar);
                prm1h.Direction = ParameterDirection.Input;
                prm1h.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm1h);

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
        public DataSet getCouAmount(string compcode, string center, string coutype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("getCouAmount", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE_P", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("CENTER_P", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = center;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm111 = new OracleParameter("COU_TYPE_P", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = coutype;
                objOraclecommand.Parameters.Add(prm111);


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
        public DataSet chkCoupan(string compcode, string center, string cpnno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkCoupan", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE_P", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("CENTER_P", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = center;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm111 = new OracleParameter("CPNNO_P", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = cpnno;
                objOraclecommand.Parameters.Add(prm111);

                OracleParameter prm1111 = new OracleParameter("EXTRA2", OracleType.VarChar);
                prm1111.Direction = ParameterDirection.Input;
                prm1111.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm1111);
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
        public DataSet bindcoupan(string compcode, string center)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("GETCOUPAN", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE_P", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("CENTER_P", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = center;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm111 = new OracleParameter("EXTRA1", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm111);

                OracleParameter prm1111 = new OracleParameter("EXTRA2", OracleType.VarChar);
                prm1111.Direction = ParameterDirection.Input;
                prm1111.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm1111);
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
        public DataSet bindDesignBox_Classified(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindDesignBox_Classified", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
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
        public DataSet bindLogoPrem_Classified(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindLogoPrem_Classified", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
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
        public DataSet getCenterCode(string editioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("getCenterCode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editioncode_p", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editioncode;
                objOraclecommand.Parameters.Add(prm1);
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
        public DataSet ratebind(string adcat, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adb_bindratecode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcat;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm3a = new OracleParameter("pextra2", OracleType.VarChar);
                prm3a.Direction = ParameterDirection.Input;
                prm3a.Value = "QBC";
                objOraclecommand.Parameters.Add(prm3a);


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
        public DataSet fa_getbkoffice1(string compcode, string branchcode, string agencycode, string agencytype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("fa_getbkoffice1", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pbkoffice", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = branchcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pAgency_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencycode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pAgency_type", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencytype;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_secpub", OracleType.Cursor);
                objOraclecommand.Parameters["p_secpub"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_secpub1", OracleType.Cursor);
                objOraclecommand.Parameters["p_secpub1"].Direction = ParameterDirection.Output;

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
        public DataSet autogenratedbox(string compcode, string auto, string no, string center1, string agncodesubcode, string branch)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Getautocodeboxforprev.Getautocodeboxforprev_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("auto1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = auto;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("no1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = no;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("center1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (center1 == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = center1;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("agency_codescode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agncodesubcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("branch", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = branch;
                objOraclecommand.Parameters.Add(prm6);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;



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
        public DataSet bindtranslation(string compcode, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindtranslation", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adtype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adtype;
                objOraclecommand.Parameters.Add(prm2);

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

        public DataSet gettraprem(string compcode, string translation)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("gettranslationper", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("translation", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = translation;
                objOraclecommand.Parameters.Add(prm2);

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
        public DataSet fetchdataforexe1(string ciobid, string compcode)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("getdataforexecute1.getdataforexecute1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("ciobid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobid;
                objOraclecommand.Parameters.Add(prm2);
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


                objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts7", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts7"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts8", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts8"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts9", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts9"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts10", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts10"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts11", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts11"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts12", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts12"].Direction = ParameterDirection.Output;


                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}

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

        public DataSet rono1(string compcode, string userid, string agencycode, string rono)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkrono", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencycode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_rono", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rono;
                objOraclecommand.Parameters.Add(prm4);

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

        public DataSet getmailheader(string compcode, string userid, string dealno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("mailrateheaderforbooking", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbookingid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dealno;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);


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
        public DataSet getmaildetail(string compcode, string userid, string dealno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("mailbooking", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbookingid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dealno;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);


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



        public DataSet fetbindtootipsubcat1(string code, string compcode)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("tooltipsubCategory", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("catid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_accounts"].Direction = ParameterDirection.Output;


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
        public DataSet executivecraditlimit(string compcode, string userid, string execname, string ciobookid, string grossamt, string billamt, string paymode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkexecutivecreditlimit", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pexecname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = execname;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pciobookid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ciobookid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pgrossamt", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = grossamt;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pbillamt", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = billamt;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("ppaymode", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = paymode;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("P_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_accounts"].Direction = ParameterDirection.Output;


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
        public DataSet logopremimage(string logoprem)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("logopremimage", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("logoprem", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = logoprem;
                objOraclecommand.Parameters.Add(prm1);


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
        public DataSet billupdatedata(string compcode, string ciobookid, string supplementbilldate, string supplementbillno, string userid, string dateformat, string flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                if (flag == "1")
                    objOraclecommand = GetCommand("billdet_for_bill_update_data", ref objOracleConnection);
                else
                    objOraclecommand = GetCommand("bill_update_data", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("porderno", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobookid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbill_date", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Convert.ToDateTime(supplementbilldate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pbill_no", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = supplementbillno;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("puserid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra2", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra3", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra4", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra5", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

                if (flag == "1")
                {
                    objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                    objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                }

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
        public DataSet adbillsmodificationvalidate(string compcode, string ciobookid, string supplementbilldate, string supplementbillno, string userid, string dateformat, string branch)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_bills_modification_validate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcentcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm12 = new OracleParameter("pbrancode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = branch;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm3 = new OracleParameter("pbilldt", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Convert.ToDateTime(supplementbilldate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pbillno", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = supplementbillno;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("puserid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra2", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra3", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra4", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra5", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

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
        public DataSet CHECKBOOKINGCREDITLIMIT(string compcode, string agcodeforcreadit, string outstand, string billamt, string datecheck, string dateformat, string cioid, string modflag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("CHECKBOOKINGCREDITLIMIT", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("agcodeforcreadit", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agcodeforcreadit;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("outstand", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = outstand;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("billamt", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = billamt;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("datecheck", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (datecheck == "" || datecheck == null)
                {
                    prm3.Value = System.DBNull.Value;
                }

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
                    if (datecheck.IndexOf('-') < 0)
                    {
                        prm5.Value = Convert.ToDateTime(datecheck).ToString("dd-MMMM-yyyy");
                    }
                    else
                    {
                        prm5.Value = datecheck;
                    }
                }
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6a = new OracleParameter("cioid", OracleType.VarChar);
                prm6a.Direction = ParameterDirection.Input;
                prm6a.Value = cioid;
                objOraclecommand.Parameters.Add(prm6a);

                OracleParameter prm6s = new OracleParameter("modflag", OracleType.VarChar);
                prm6s.Direction = ParameterDirection.Input;
                prm6s.Value = modflag;
                objOraclecommand.Parameters.Add(prm6s);


                OracleParameter prm6 = new OracleParameter("extra2", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = modflag;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("extra3", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("extra4", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("extra5", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);

                objOraclecommand.Parameters.Add("P_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_accounts"].Direction = ParameterDirection.Output;

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
        public DataSet getExecZoneName(string execcode, string compcode, string agencycodesubcode)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getExecZoneNameforprintbooking", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("exexcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = execcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pagency", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencycodesubcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
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
                CloseConnection(ref objOracleConnection);
            }

        }
        public DataSet validationCoupan(string compcode, string center, string cpnno, string cpntype, string agcode, string execcode, string dtime, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("validationCoupan", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE_P", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("CENTER_P", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = center;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm111 = new OracleParameter("CPNNO_P", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = cpnno;
                objOraclecommand.Parameters.Add(prm111);

                OracleParameter prm2 = new OracleParameter("CPNTYPE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cpntype;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("AGCODE_P", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("EXECCODE_P", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = execcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7c = new OracleParameter("DATE_P", OracleType.VarChar, 50);
                prm7c.Direction = ParameterDirection.Input;
                if (dtime == "")
                {
                    prm7c.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dtime.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dtime = mm + "/" + dd + "/" + yy;
                    }

                    prm7c.Value = Convert.ToDateTime(dtime).ToString("dd-MMMM-yyyy");
                }
                // prm7c.Value = validfrom_p;
                objOraclecommand.Parameters.Add(prm7c);

                OracleParameter prm1111 = new OracleParameter("EXTRA2", OracleType.VarChar);
                prm1111.Direction = ParameterDirection.Input;
                prm1111.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm1111);
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
        public DataSet getpageadinfo(string compcode, string pageprem, string editionname, string pageno, string date_p, string userid, string cioid, string extera1, string extera2, string extera3, string extera4, string extera5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getpageadinfo", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode_p", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("pageprem_p", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pageprem;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm111 = new OracleParameter("editionname_p", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = editionname;
                objOraclecommand.Parameters.Add(prm111);

                OracleParameter prm2 = new OracleParameter("pageno_p", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pageno;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm7c = new OracleParameter("date_p", OracleType.VarChar, 50);
                prm7c.Direction = ParameterDirection.Input;
                prm7c.Value = date_p;
                objOraclecommand.Parameters.Add(prm7c);

                OracleParameter prm3 = new OracleParameter("userid_p", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("cioid_p", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = cioid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("extera1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extera1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("extera2", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extera2;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm6a = new OracleParameter("extera3", OracleType.VarChar);
                prm6a.Direction = ParameterDirection.Input;
                prm6a.Value = extera3;
                objOraclecommand.Parameters.Add(prm6a);

                OracleParameter prm6s = new OracleParameter("extera4", OracleType.VarChar);
                prm6s.Direction = ParameterDirection.Input;
                prm6s.Value = extera4;
                objOraclecommand.Parameters.Add(prm6s);

                OracleParameter prm6d = new OracleParameter("extera5", OracleType.VarChar);
                prm6d.Direction = ParameterDirection.Input;
                prm6d.Value = extera5;
                objOraclecommand.Parameters.Add(prm6d);


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
        public DataSet getmailagency(string compcode, string userid, string cioid, string agencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("get_agency_mailid", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbookingid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cioid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pagencycode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencycode;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);


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
        public DataSet adretain_billbase_outstanding(string compcode, string agencycodesubcode, string retain_code, string datetime, string dateformat, string agencytype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("adretain_billbase_outstanding", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("punit", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm111 = new OracleParameter("ppubcode", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm111);

                OracleParameter prm2 = new OracleParameter("pagency", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agencycodesubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pretcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = retain_code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm7c = new OracleParameter("pason_dt", OracleType.VarChar, 50);
                prm7c.Direction = ParameterDirection.Input;
                if (datetime == "")
                {
                    prm7c.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = datetime.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datetime = mm + "/" + dd + "/" + yy;
                    }

                    prm7c.Value = Convert.ToDateTime(datetime).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm7c);

                OracleParameter prm4 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1111 = new OracleParameter("pagtype", OracleType.VarChar);
                prm1111.Direction = ParameterDirection.Input;
                prm1111.Value = agencytype;
                objOraclecommand.Parameters.Add(prm1111);

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
        public DataSet adexec_billbase_outstanding(string compcode, string agencycodesubcode, string pexecode, string datetime, string dateformat, string agencytype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("adexec_billbase_outstanding", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("punit", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm111 = new OracleParameter("ppubcode", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm111);

                OracleParameter prm2 = new OracleParameter("pagency", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agencycodesubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pexecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pexecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm7c = new OracleParameter("pason_dt", OracleType.VarChar, 50);
                prm7c.Direction = ParameterDirection.Input;
                if (datetime == "")
                {
                    prm7c.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = datetime.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datetime = mm + "/" + dd + "/" + yy;
                    }

                    prm7c.Value = Convert.ToDateTime(datetime).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm7c);

                OracleParameter prm4 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1111 = new OracleParameter("pagtype", OracleType.VarChar);
                prm1111.Direction = ParameterDirection.Input;
                prm1111.Value = agencytype;
                objOraclecommand.Parameters.Add(prm1111);

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



        public DataSet discount_count(string compcode, string adtype, string edition_count)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getautodiscountrate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcomcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pedition", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edition_count;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("padtype", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adtype;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra3", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pextra4", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra5", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);


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



        //multibilling
        public DataSet multi_billing(string compcode, string client_code, string client_name, string client_address, string width, string height, string gross_amt, string comm, string bill_amt, string bill_no, string bill_dt, string userid, string flag, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("MULTIBILLING_RO", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PCLIENT_NAME", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client_name;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCLIENT_CODE", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = client_code;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("PCLEINT_ADDRESS", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_address;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("PWIDTH", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = width;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PHEIGHT", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = height;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PGROSS_AMT", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = gross_amt;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("PCOMM", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (comm == "null" || comm == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = comm;
                }
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("PBILL_AMT", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (bill_amt == "null" || bill_amt == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = bill_amt;
                }
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("PBILL_NO", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (bill_no == "null" || bill_no == null)
                {

                    prm10.Value = bill_no;
                }
                else
                {
                    prm10.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("PBILL_DATE", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (bill_dt == "null" || bill_dt == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = bill_dt;
                }
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("PUSER_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PFLAG", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = flag;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("PEXTRA1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = extra1;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("PEXTRA2", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (extra2 == "")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {

                    prm15.Value = extra2;
                }
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PEXTRA3", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = extra3;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("PEXTRA4", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = extra4;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("PEXTRA5", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = extra5;
                objOraclecommand.Parameters.Add(prm18);


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
        public DataSet executebooking_bill(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking, string dateformat, string revenue)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("executebookingdisp_bill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobookid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("docno", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = docno;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm6 = new OracleParameter("keyno", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = keyno;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm5 = new OracleParameter("rono", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = rono;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("agencycode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencycode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("client", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = client;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("booking", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = booking;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("revenue", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = revenue;
                objOraclecommand.Parameters.Add(prm10);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("P_Accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts3"].Direction = ParameterDirection.Output;


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
        public DataSet fetchdataforexe_bill(string ciobid, string compcode)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("getdataforexecute_bill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("ciobid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobid;
                objOraclecommand.Parameters.Add(prm2);
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


                objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts7", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts7"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts8", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts8"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts9", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts9"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts10", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts10"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts11", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts11"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts12", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts12"].Direction = ParameterDirection.Output;


                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}

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
        public DataSet getPackageInsert_bill(string pckcode, string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("getPackageInsert_suppbill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pckcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("cioid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cioid;
                objOraclecommand.Parameters.Add(prm3);

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
        public DataSet updatebookingdisp_bill(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string status, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string attach1, string attach2, string cashdiscount, string cashdiscountper, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string agreedrate_active, string agreedamt_active, string grossamtlocal_p, string billamtlocal_p, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string modifyrateaudit, string ip, string transdisc, string pospremdisc, string billhold, string online_ad, string fixed_booking, string vat_code, string cou_code, string cou_name, string state, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatebooking_suppbill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm6 = new OracleParameter("approvedby", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = approvedby;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("audit1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = audit;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("rono", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = rono;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("rodate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;

                if (rodate == "" || rodate == null)
                {
                    prm10.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = rodate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        rodate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = rodate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            rodate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm10.Value = Convert.ToDateTime(rodate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("caption", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = caption;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("billstatus", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = billstatus;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("rostatus", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = rostatus;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("agency", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = agency;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("client", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = client;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("agencyaddress", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = agencyaddress;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("clientaddresses", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = clientaddresses;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("agencycode", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = agencycode;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("dockitno", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = dockitno;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("execname", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = execname;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("execzone", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = execzone;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("product", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = product;
                objOraclecommand.Parameters.Add(prm22);



                OracleParameter prm23 = new OracleParameter("brand", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = brand;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("keyno", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = keyno;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("billremark", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = billremark;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("printremark", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = printremark;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("package1", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = package;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("insertion", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (insertion == "")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDecimal(insertion);
                }
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("startdate", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;

                if (startdate == "" || startdate == null)
                {
                    prm29.Value = System.DBNull.Value;
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

                    prm29.Value = Convert.ToDateTime(startdate).ToString("dd-MMMM-yyyy");
                }
                //if (dateformat == "dd/mm/yyyy")
                //{
                //    string[] arr = startdate.Split('/');
                //    string dd = arr[0];
                //    string mm = arr[1];
                //    string yy = arr[2];
                //    startdate = mm + "/" + dd + "/" + yy;


                //}
                //else
                //    if (dateformat == "mm/dd/yyyy")
                //    {
                //        string[] arr = startdate.Split('/');
                //        string dd = arr[1];
                //        string mm = arr[0];
                //        string yy = arr[2];
                //        startdate = mm + "/" + dd + "/" + yy;

                //    }

                //    else
                //        if (dateformat == "yyyy/mm/dd")
                //        {
                //            string[] arr = startdate.Split('/');
                //            string dd = arr[2];
                //            string mm = arr[1];
                //            string yy = arr[0];
                //            startdate = mm + "/" + dd + "/" + yy;
                //        }

                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("repeatdate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = repeatdate;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("adtype1", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = adtype;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("adcategory", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = adcategory;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("subcategory", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = subcategory;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("color", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = color;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("uom", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = uom;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("pageposition", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = pageposition;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("pagetype1", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = pagetype;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("pageno", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                if (pageno == "" || pageno == null)
                {
                    prm38.Value = System.DBNull.Value;

                }
                else
                {
                    prm38.Value = Convert.ToDecimal(pageno);
                }
                objOraclecommand.Parameters.Add(prm38);



                OracleParameter prm39 = new OracleParameter("adsizheight", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                if (adsizheight == "" || adsizheight == null)
                {
                    prm39.Value = System.DBNull.Value;
                }
                else
                {
                    prm39.Value = Convert.ToDecimal(adsizheight);
                }
                objOraclecommand.Parameters.Add(prm39);


                OracleParameter prm40 = new OracleParameter("adsizwidth", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                if (adsizwidth == "" || adsizwidth == null)
                {
                    prm40.Value = System.DBNull.Value;
                }
                else
                {
                    prm40.Value = Convert.ToDecimal(adsizwidth);
                }
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm43 = new OracleParameter("ratecode11", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = ratecode;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm41 = new OracleParameter("scheme1", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = scheme;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("currency", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = currency;
                objOraclecommand.Parameters.Add(prm42);



                OracleParameter prm44 = new OracleParameter("agreedrate", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                if (agreedrate == "" || agreedrate == null)
                {
                    prm44.Value = System.DBNull.Value;
                }
                else
                {
                    prm44.Value = Convert.ToDecimal(agreedrate);
                }
                objOraclecommand.Parameters.Add(prm44);


                OracleParameter prm45 = new OracleParameter("agreedamt", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                if (agreedamt == "" || agreedamt == null)
                {
                    prm45.Value = System.DBNull.Value;
                }
                else
                {
                    prm45.Value = Convert.ToDecimal(agreedamt);
                }
                objOraclecommand.Parameters.Add(prm45);


                OracleParameter prm46 = new OracleParameter("spedisc", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                if (spedisc == "" || spedisc == null)
                {
                    prm46.Value = System.DBNull.Value;
                }
                else
                {
                    prm46.Value = Convert.ToDecimal(spedisc);
                }
                objOraclecommand.Parameters.Add(prm46);
                OracleParameter prm48 = new OracleParameter("spacedisx", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                if (spacedisx == "" || spacedisx == null)
                {
                    prm48.Value = System.DBNull.Value;
                }
                else
                {
                    prm48.Value = Convert.ToDecimal(spacedisx);
                }
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm47 = new OracleParameter("compcode", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = compcode;
                objOraclecommand.Parameters.Add(prm47);
                OracleParameter prm50 = new OracleParameter("userid", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = userid;
                objOraclecommand.Parameters.Add(prm50);


                OracleParameter prm7 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ciobookid;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm1 = new OracleParameter("date_time", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (date_time == "" || date_time == null)
                {
                    prm1.Value = System.DBNull.Value;


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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = date_time.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        date_time = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = date_time.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            date_time = mm + "/" + dd + "/" + yy;
                    //        }


                    prm1.Value = Convert.ToDateTime(date_time).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm3 = new OracleParameter("branch", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branch;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("booked_by", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = booked_by;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("prevbook", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = prevbook;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm2 = new OracleParameter("adsizetype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adsizetype;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm49 = new OracleParameter("specialcharges", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                if (specialcharges == "" || specialcharges == null)
                {
                    prm49.Value = System.DBNull.Value;
                }
                else
                {
                    prm49.Value = Convert.ToDecimal(specialcharges);
                }
                objOraclecommand.Parameters.Add(prm49);




                OracleParameter prm51 = new OracleParameter("agencytype", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = agencytype;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm52 = new OracleParameter("agencystatus", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = agencystatus;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("paymode", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = paymode;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("agencredit", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                if (agencredit == "" || agencredit == null)
                {
                    prm54.Value = System.DBNull.Value;
                }
                else
                {
                    prm54.Value = Convert.ToInt32(agencredit);
                }
                objOraclecommand.Parameters.Add(prm54);


                OracleParameter prm55 = new OracleParameter("cardrate", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                if (cardrate == "" || cardrate == null)
                {
                    prm55.Value = System.DBNull.Value;
                }
                else
                {
                    prm55.Value = Convert.ToDecimal(cardrate);
                }
                objOraclecommand.Parameters.Add(prm55);


                OracleParameter prm56 = new OracleParameter("cardamount", OracleType.VarChar);
                prm56.Direction = ParameterDirection.Input;
                if (cardamount == "" || cardamount == null)
                {
                    prm56.Value = System.DBNull.Value;
                }
                else
                {
                    prm56.Value = Convert.ToDecimal(cardamount);
                }
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("discount", OracleType.VarChar);
                prm57.Direction = ParameterDirection.Input;
                if (discount == "" || discount == null)
                {
                    prm57.Value = System.DBNull.Value;
                }
                else
                {
                    prm57.Value = Convert.ToDecimal(discount);
                }
                objOraclecommand.Parameters.Add(prm57);


                OracleParameter prm58 = new OracleParameter("discountper", OracleType.VarChar);
                prm58.Direction = ParameterDirection.Input;
                if (discountper == "" || discountper == null)
                {
                    prm58.Value = System.DBNull.Value;
                }
                else
                {
                    prm58.Value = Convert.ToDecimal(discountper);
                }
                objOraclecommand.Parameters.Add(prm58);


                OracleParameter prm59 = new OracleParameter("billaddress", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                prm59.Value = billaddress;
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("totarea", OracleType.VarChar);
                prm60.Direction = ParameterDirection.Input;
                if (totarea == "" || totarea == null)
                {
                    prm60.Value = System.DBNull.Value;
                }
                else
                {
                    prm60.Value = Convert.ToDecimal(totarea);
                }
                objOraclecommand.Parameters.Add(prm60);


                OracleParameter prm61 = new OracleParameter("billcycle", OracleType.VarChar);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = billcycle;
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm63 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = revenuecenter;
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm62 = new OracleParameter("billpay", OracleType.VarChar);
                prm62.Direction = ParameterDirection.Input;
                prm62.Value = billpay;
                objOraclecommand.Parameters.Add(prm62);



                OracleParameter prm64 = new OracleParameter("billheight", OracleType.VarChar);
                prm64.Direction = ParameterDirection.Input;
                if (billheight == "" || billheight == null)
                {
                    prm64.Value = System.DBNull.Value;
                }
                else
                {
                    prm64.Value = Convert.ToDecimal(billheight);
                }
                objOraclecommand.Parameters.Add(prm64);


                OracleParameter prm65 = new OracleParameter("billwidth", OracleType.VarChar);
                prm65.Direction = ParameterDirection.Input;
                if (billwidth == "" || billwidth == null)
                {
                    prm65.Value = System.DBNull.Value;
                }
                else
                {
                    prm65.Value = Convert.ToDecimal(billwidth);
                }
                objOraclecommand.Parameters.Add(prm65);


                OracleParameter prm66 = new OracleParameter("billto", OracleType.VarChar);
                prm66.Direction = ParameterDirection.Input;
                prm66.Value = billto;
                objOraclecommand.Parameters.Add(prm66);

                OracleParameter prm67 = new OracleParameter("invoices", OracleType.VarChar);
                prm67.Direction = ParameterDirection.Input;
                if (invoices == "" || invoices == null)
                {
                    prm67.Value = System.DBNull.Value;
                }
                else
                {
                    prm67.Value = Convert.ToDecimal(invoices);
                }
                objOraclecommand.Parameters.Add(prm67);


                OracleParameter prm68 = new OracleParameter("vts", OracleType.VarChar);
                prm68.Direction = ParameterDirection.Input;
                if (vts == "" || vts == null || vts == "null")
                {
                    prm68.Value = System.DBNull.Value;
                }
                else
                {
                    prm68.Value = Convert.ToDecimal(vts);
                }
                objOraclecommand.Parameters.Add(prm68);



                OracleParameter prm69 = new OracleParameter("tradedisc", OracleType.VarChar);
                prm69.Direction = ParameterDirection.Input;
                if (tradedisc == "" || tradedisc == null || tradedisc == "undefined" || tradedisc == "0")
                    prm69.Value = System.DBNull.Value;
                else
                    prm69.Value = Convert.ToDecimal(tradedisc);
                objOraclecommand.Parameters.Add(prm69);

                OracleParameter prm70 = new OracleParameter("agencyout", OracleType.VarChar);
                prm70.Direction = ParameterDirection.Input;
                prm70.Value = agencyout;
                objOraclecommand.Parameters.Add(prm70);

                OracleParameter prm71 = new OracleParameter("boxcode", OracleType.VarChar);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = boxcode;
                objOraclecommand.Parameters.Add(prm71);

                OracleParameter prm72 = new OracleParameter("boxno", OracleType.VarChar);
                prm72.Direction = ParameterDirection.Input;
                prm72.Value = boxno;
                objOraclecommand.Parameters.Add(prm72);


                OracleParameter prm74 = new OracleParameter("boxaddress", OracleType.VarChar);
                prm74.Direction = ParameterDirection.Input;
                prm74.Value = boxaddress;
                objOraclecommand.Parameters.Add(prm74);

                OracleParameter prm73 = new OracleParameter("boxagency", OracleType.VarChar);
                prm73.Direction = ParameterDirection.Input;
                prm73.Value = boxagency;
                objOraclecommand.Parameters.Add(prm73);


                OracleParameter prm75 = new OracleParameter("boxclient", OracleType.VarChar);
                prm75.Direction = ParameterDirection.Input;
                prm75.Value = boxclient;
                objOraclecommand.Parameters.Add(prm75);

                OracleParameter prm77 = new OracleParameter("bookingtype", OracleType.VarChar);
                prm77.Direction = ParameterDirection.Input;
                prm77.Value = bookingtype;
                objOraclecommand.Parameters.Add(prm77);

                OracleParameter prm78 = new OracleParameter("tfn", OracleType.VarChar);
                prm78.Direction = ParameterDirection.Input;
                prm78.Value = tfn;
                objOraclecommand.Parameters.Add(prm78);


                OracleParameter prm76 = new OracleParameter("coupan", OracleType.VarChar);
                prm76.Direction = ParameterDirection.Input;
                prm76.Value = coupan;
                objOraclecommand.Parameters.Add(prm76);




                OracleParameter prm79 = new OracleParameter("campaign", OracleType.VarChar);
                prm79.Direction = ParameterDirection.Input;
                prm79.Value = campaign;
                objOraclecommand.Parameters.Add(prm79);


                OracleParameter prm80 = new OracleParameter("bill_amt", OracleType.VarChar);
                prm80.Direction = ParameterDirection.Input;
                if (bill_amt == "" || bill_amt == null)
                {
                    prm80.Value = System.DBNull.Value;
                }
                else
                {
                    prm80.Value = Convert.ToDecimal(bill_amt);
                }
                objOraclecommand.Parameters.Add(prm80);


                OracleParameter prm81 = new OracleParameter("pageprem", OracleType.VarChar);
                prm81.Direction = ParameterDirection.Input;
                prm81.Value = pageprem;
                objOraclecommand.Parameters.Add(prm81);

                OracleParameter prm82 = new OracleParameter("pageamt", OracleType.VarChar);
                prm82.Direction = ParameterDirection.Input;
                if (pageamt == "" || pageamt == null)
                {
                    prm82.Value = System.DBNull.Value;
                }
                else
                {
                    prm82.Value = Convert.ToDecimal(pageamt);
                }
                objOraclecommand.Parameters.Add(prm82);


                OracleParameter prm83 = new OracleParameter("premper", OracleType.VarChar);
                prm83.Direction = ParameterDirection.Input;
                if (premper == "" || premper == null)
                {
                    prm83.Value = System.DBNull.Value;
                }
                else
                {
                    prm83.Value = Convert.ToDecimal(premper);
                }
                objOraclecommand.Parameters.Add(prm83);


                OracleParameter prm84 = new OracleParameter("grossamt", OracleType.VarChar);
                prm84.Direction = ParameterDirection.Input;
                if (grossamt == "" || grossamt == null)
                {
                    prm84.Value = System.DBNull.Value;
                }
                else
                {
                    prm84.Value = Convert.ToDecimal(grossamt);
                }
                objOraclecommand.Parameters.Add(prm84);



                OracleParameter prm85 = new OracleParameter("adsizcolumn", OracleType.VarChar);
                prm85.Direction = ParameterDirection.Input;
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    prm85.Value = System.DBNull.Value;
                }
                else
                {
                    prm85.Value = Convert.ToDecimal(adsizcolumn);
                }
                objOraclecommand.Parameters.Add(prm85);

                OracleParameter prm89 = new OracleParameter("billarea", OracleType.VarChar);
                prm89.Direction = ParameterDirection.Input;
                if (billarea == 0)
                {
                    prm89.Value = System.DBNull.Value;
                }
                else
                {
                    prm89.Value = Convert.ToDecimal(billarea);
                }
                objOraclecommand.Parameters.Add(prm89);


                OracleParameter prm86 = new OracleParameter("billcolumn", OracleType.VarChar);
                prm86.Direction = ParameterDirection.Input;
                if (billcolumn == "" || billcolumn == null)
                {
                    prm86.Value = System.DBNull.Value;
                }
                else
                {
                    prm86.Value = Convert.ToDecimal(billcolumn);
                }
                objOraclecommand.Parameters.Add(prm86);


                OracleParameter prm88 = new OracleParameter("spacediscper", OracleType.VarChar);
                prm88.Direction = ParameterDirection.Input;
                if (spacediscper == "" || spacediscper == null)
                {
                    prm88.Value = System.DBNull.Value;
                }
                else
                {
                    prm88.Value = Convert.ToDecimal(spacediscper);
                }
                objOraclecommand.Parameters.Add(prm88);

                OracleParameter prm87 = new OracleParameter("specdiscper", OracleType.VarChar);
                prm87.Direction = ParameterDirection.Input;
                if (specdiscper == "" || specdiscper == null)
                {
                    prm87.Value = System.DBNull.Value;
                }
                else
                {
                    prm87.Value = Convert.ToDecimal(specdiscper);
                }
                objOraclecommand.Parameters.Add(prm87);






                OracleParameter prm90 = new OracleParameter("paidins", OracleType.VarChar);
                prm90.Direction = ParameterDirection.Input;
                if (paidins == "" || paidins == null)
                {
                    prm90.Value = System.DBNull.Value;
                }
                else
                {
                    prm90.Value = Convert.ToDecimal(paidins);
                }
                objOraclecommand.Parameters.Add(prm90);
                OracleParameter prm91 = new OracleParameter("dealrate", OracleType.VarChar);
                prm91.Direction = ParameterDirection.Input;
                if (dealrate == "" || dealrate == null)
                {
                    prm91.Value = System.DBNull.Value;
                }
                else
                {
                    prm91.Value = Convert.ToDecimal(dealrate);
                }

                objOraclecommand.Parameters.Add(prm91);


                OracleParameter prm92 = new OracleParameter("deviation", OracleType.VarChar);
                prm92.Direction = ParameterDirection.Input;
                if (deviation == "" || deviation == null)
                {
                    prm92.Value = System.DBNull.Value;
                }
                else
                {
                    prm92.Value = Convert.ToDecimal(deviation);
                }
                objOraclecommand.Parameters.Add(prm92);




                OracleParameter prm93 = new OracleParameter("varient", OracleType.VarChar);
                prm93.Direction = ParameterDirection.Input;
                prm93.Value = varient;
                objOraclecommand.Parameters.Add(prm93);



                OracleParameter prm95 = new OracleParameter("dealtype", OracleType.VarChar);
                prm95.Direction = ParameterDirection.Input;
                prm95.Value = dealtype;
                objOraclecommand.Parameters.Add(prm95);

                OracleParameter prm94 = new OracleParameter("contractname", OracleType.VarChar);
                prm94.Direction = ParameterDirection.Input;
                prm94.Value = contractname;
                objOraclecommand.Parameters.Add(prm94);

                OracleParameter prm96 = new OracleParameter("cardname", OracleType.VarChar);
                prm96.Direction = ParameterDirection.Input;
                prm96.Value = cardname;
                objOraclecommand.Parameters.Add(prm96);

                OracleParameter prm97 = new OracleParameter("cardtype", OracleType.VarChar);
                prm97.Direction = ParameterDirection.Input;
                prm97.Value = cardtype;
                objOraclecommand.Parameters.Add(prm97);

                OracleParameter prm98 = new OracleParameter("cardmonth", OracleType.VarChar);
                prm98.Direction = ParameterDirection.Input;
                prm98.Value = cardmonth;
                objOraclecommand.Parameters.Add(prm98);

                OracleParameter prm99 = new OracleParameter("cardyear", OracleType.VarChar);
                prm99.Direction = ParameterDirection.Input;
                prm99.Value = cardyear;
                objOraclecommand.Parameters.Add(prm99);

                OracleParameter prm100 = new OracleParameter("cardno", OracleType.VarChar);
                prm100.Direction = ParameterDirection.Input;
                prm100.Value = cardno;
                objOraclecommand.Parameters.Add(prm100);






                OracleParameter prm101 = new OracleParameter("receiptno", OracleType.VarChar);
                prm101.Direction = ParameterDirection.Input;
                prm101.Value = receiptno;
                objOraclecommand.Parameters.Add(prm101);


                OracleParameter prm102 = new OracleParameter("adscat3", OracleType.VarChar);
                prm102.Direction = ParameterDirection.Input;
                prm102.Value = adscat3;
                objOraclecommand.Parameters.Add(prm102);


                OracleParameter prm103 = new OracleParameter("adscat4", OracleType.VarChar);
                prm103.Direction = ParameterDirection.Input;
                prm103.Value = adscat4;
                objOraclecommand.Parameters.Add(prm103);


                OracleParameter prm104 = new OracleParameter("adscat5", OracleType.VarChar);
                prm104.Direction = ParameterDirection.Input;
                prm104.Value = adscat5;
                objOraclecommand.Parameters.Add(prm104);


                OracleParameter prm105 = new OracleParameter("bgcolor", OracleType.VarChar);
                prm105.Direction = ParameterDirection.Input;
                prm105.Value = bgcolor;
                objOraclecommand.Parameters.Add(prm105);


                OracleParameter prm106 = new OracleParameter("bulletcode", OracleType.VarChar);
                prm106.Direction = ParameterDirection.Input;
                prm106.Value = bulletcode;
                objOraclecommand.Parameters.Add(prm106);


                OracleParameter prm107 = new OracleParameter("bulletprm", OracleType.VarChar);
                prm107.Direction = ParameterDirection.Input;
                if (bulletprm == "" || bulletprm == null)
                {
                    prm107.Value = System.DBNull.Value;
                }
                else
                {
                    bulletprm = bulletprm.Replace("%", "");
                    prm107.Value = Convert.ToDecimal(bulletprm);
                }
                objOraclecommand.Parameters.Add(prm107);


                OracleParameter prm108 = new OracleParameter("material", OracleType.VarChar);
                prm108.Direction = ParameterDirection.Input;
                prm108.Value = material;
                objOraclecommand.Parameters.Add(prm108);








                OracleParameter prm114 = new OracleParameter("region1", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = region;
                objOraclecommand.Parameters.Add(prm114);



                OracleParameter prm113 = new OracleParameter("varient_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = varient_name;
                objOraclecommand.Parameters.Add(prm113);



                /*new change ankur 9 feb*/

                OracleParameter prm115 = new OracleParameter("coltype", OracleType.VarChar);
                prm115.Direction = ParameterDirection.Input;
                prm115.Value = coltype;
                objOraclecommand.Parameters.Add(prm115);

                OracleParameter prm116 = new OracleParameter("logo_h", OracleType.VarChar);
                prm116.Direction = ParameterDirection.Input;
                prm116.Value = logo_h;
                objOraclecommand.Parameters.Add(prm116);

                OracleParameter prm117 = new OracleParameter("logo_w", OracleType.VarChar);
                prm117.Direction = ParameterDirection.Input;
                prm117.Value = logo_w;
                objOraclecommand.Parameters.Add(prm117);

                OracleParameter prm118 = new OracleParameter("logo_col", OracleType.VarChar);
                prm118.Direction = ParameterDirection.Input;
                prm118.Value = logo_col;
                objOraclecommand.Parameters.Add(prm118);

                OracleParameter prm119 = new OracleParameter("logo_uom", OracleType.VarChar);
                prm119.Direction = ParameterDirection.Input;
                prm119.Value = logo_uom;
                objOraclecommand.Parameters.Add(prm119);


                OracleParameter prm120 = new OracleParameter("retainer1", OracleType.VarChar);
                prm120.Direction = ParameterDirection.Input;
                if (retainer.LastIndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.LastIndexOf("(") + 1, retainer.Length - retainer.LastIndexOf("(") - 2);
                }
                prm120.Value = retainer;
                objOraclecommand.Parameters.Add(prm120);

                OracleParameter prm121 = new OracleParameter("addagencyrate", OracleType.VarChar);
                prm121.Direction = ParameterDirection.Input;
                prm121.Value = addagencyrate;
                objOraclecommand.Parameters.Add(prm121);

                OracleParameter prm122 = new OracleParameter("mobileno", OracleType.VarChar);
                prm122.Direction = ParameterDirection.Input;
                prm122.Value = mobileno;
                objOraclecommand.Parameters.Add(prm122);

                OracleParameter prm123 = new OracleParameter("addlamt", OracleType.VarChar);
                prm123.Direction = ParameterDirection.Input;
                prm123.Value = addlamt;
                objOraclecommand.Parameters.Add(prm123);

                OracleParameter prm124 = new OracleParameter("retamt", OracleType.VarChar);
                prm124.Direction = ParameterDirection.Input;
                prm124.Value = retamt;
                objOraclecommand.Parameters.Add(prm124);

                OracleParameter prm125 = new OracleParameter("retper", OracleType.VarChar);
                prm125.Direction = ParameterDirection.Input;
                prm125.Value = retper;
                objOraclecommand.Parameters.Add(prm125);


                OracleParameter prm126 = new OracleParameter("cashrecieved", OracleType.VarChar);
                prm126.Direction = ParameterDirection.Input;
                if (cashrecieved == "" || cashrecieved == null)
                {
                    prm126.Value = System.DBNull.Value;
                }
                else
                {
                    prm126.Value = Convert.ToDecimal(cashrecieved);
                }
                objOraclecommand.Parameters.Add(prm126);

                OracleParameter prm127 = new OracleParameter("CIRAGENCY_V", OracleType.VarChar);
                prm127.Direction = ParameterDirection.Input;
                prm127.Value = ciragency;
                objOraclecommand.Parameters.Add(prm127);

                OracleParameter prm128 = new OracleParameter("CIRRATE_V", OracleType.VarChar);
                prm128.Direction = ParameterDirection.Input;
                prm128.Value = cirrate;
                objOraclecommand.Parameters.Add(prm128);

                OracleParameter prm129 = new OracleParameter("CIREDITION_V", OracleType.VarChar);
                prm129.Direction = ParameterDirection.Input;
                prm129.Value = ciredition;
                objOraclecommand.Parameters.Add(prm129);

                OracleParameter prm130 = new OracleParameter("CIRPUBLICATION_V", OracleType.VarChar);
                prm130.Direction = ParameterDirection.Input;
                prm130.Value = cirpublication;
                objOraclecommand.Parameters.Add(prm130);

                OracleParameter prm131 = new OracleParameter("CIRAGENCYSUBCODE_V", OracleType.VarChar);
                prm131.Direction = ParameterDirection.Input;
                prm131.Value = ciragencysubcode;
                objOraclecommand.Parameters.Add(prm131);

                OracleParameter prm132 = new OracleParameter("BARTERTYPE", OracleType.VarChar);
                prm132.Direction = ParameterDirection.Input;
                prm132.Value = bartertype;
                objOraclecommand.Parameters.Add(prm132);

                OracleParameter prm133 = new OracleParameter("CASHDISCOUNT_V", OracleType.VarChar);
                prm133.Direction = ParameterDirection.Input;
                if (cashdiscount == "")
                    prm133.Value = System.DBNull.Value;
                else
                    prm133.Value = cashdiscount;
                objOraclecommand.Parameters.Add(prm133);

                OracleParameter prm134 = new OracleParameter("CASHDISCOUNTPER_V", OracleType.VarChar);
                prm134.Direction = ParameterDirection.Input;
                prm134.Value = cashdiscountper;
                objOraclecommand.Parameters.Add(prm134);

                OracleParameter prm135 = new OracleParameter("attach1", OracleType.VarChar);
                prm135.Direction = ParameterDirection.Input;
                prm135.Value = attach1;
                objOraclecommand.Parameters.Add(prm135);

                OracleParameter prm136 = new OracleParameter("attach2", OracleType.VarChar);
                prm136.Direction = ParameterDirection.Input;
                prm136.Value = attach2;
                objOraclecommand.Parameters.Add(prm136);

                OracleParameter prm137 = new OracleParameter("drpdiscprem", OracleType.VarChar);
                prm137.Direction = ParameterDirection.Input;
                prm137.Value = drpdiscprem;
                objOraclecommand.Parameters.Add(prm137);

                OracleParameter prm138 = new OracleParameter("doctype_v", OracleType.VarChar);
                prm138.Direction = ParameterDirection.Input;
                prm138.Value = doctype;
                objOraclecommand.Parameters.Add(prm138);

                OracleParameter prm139 = new OracleParameter("CHKTRADE", OracleType.VarChar);
                prm139.Direction = ParameterDirection.Input;
                prm139.Value = chktradeval;
                objOraclecommand.Parameters.Add(prm139);

                OracleParameter prm140 = new OracleParameter("sharepub_p", OracleType.VarChar);
                prm140.Direction = ParameterDirection.Input;
                prm140.Value = sharepub;
                objOraclecommand.Parameters.Add(prm140);
                OracleParameter prm141 = new OracleParameter("fmginsert", OracleType.VarChar);
                prm141.Direction = ParameterDirection.Input;
                prm141.Value = fmginsert;
                objOraclecommand.Parameters.Add(prm141);


                OracleParameter prm142 = new OracleParameter("chkno", OracleType.VarChar);
                prm142.Direction = ParameterDirection.Input;
                prm142.Value = chkno;
                objOraclecommand.Parameters.Add(prm142);

                OracleParameter prm143 = new OracleParameter("chkdate", OracleType.DateTime);
                prm143.Direction = ParameterDirection.Input;
                if (chkdate == "" || chkdate == null)
                {
                    prm143.Value = System.DBNull.Value;

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
                    prm143.Value = Convert.ToDateTime(chkdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm143);

                OracleParameter prm144 = new OracleParameter("chkamt", OracleType.VarChar);
                prm144.Direction = ParameterDirection.Input;
                prm144.Value = chkamt;
                objOraclecommand.Parameters.Add(prm144);
                OracleParameter prm145 = new OracleParameter("chkbankname", OracleType.VarChar);
                prm145.Direction = ParameterDirection.Input;
                prm145.Value = chkbankname;
                objOraclecommand.Parameters.Add(prm145);

                OracleParameter prm146 = new OracleParameter("ourbank", OracleType.VarChar);
                prm146.Direction = ParameterDirection.Input;
                prm146.Value = ourbank;
                objOraclecommand.Parameters.Add(prm146);

                OracleParameter prm147 = new OracleParameter("DEALERPANEL_P", OracleType.VarChar);
                prm147.Direction = ParameterDirection.Input;
                if (dealerpanel == "")
                    prm147.Value = System.DBNull.Value;
                else
                    prm147.Value = dealerpanel;
                objOraclecommand.Parameters.Add(prm147);

                OracleParameter prm148 = new OracleParameter("DEALERH_P", OracleType.VarChar);
                prm148.Direction = ParameterDirection.Input;
                if (dealerh == "")
                    prm148.Value = System.DBNull.Value;
                else
                    prm148.Value = dealerh;
                objOraclecommand.Parameters.Add(prm148);

                OracleParameter prm149 = new OracleParameter("DEALERW_P", OracleType.VarChar);
                prm149.Direction = ParameterDirection.Input;
                if (dealerw == "")
                    prm149.Value = System.DBNull.Value;
                else
                    prm149.Value = dealerw;
                objOraclecommand.Parameters.Add(prm149);

                OracleParameter prm150 = new OracleParameter("DEALERTYPE_P", OracleType.VarChar);
                prm150.Direction = ParameterDirection.Input;
                if (dealertype == "")
                    prm150.Value = System.DBNull.Value;
                else
                    prm150.Value = dealertype;
                objOraclecommand.Parameters.Add(prm150);

                OracleParameter prm151 = new OracleParameter("multiselect", OracleType.VarChar);
                prm151.Direction = ParameterDirection.Input;
                if (multicode == "")
                    prm151.Value = System.DBNull.Value;
                else
                    prm151.Value = multicode;
                objOraclecommand.Parameters.Add(prm151);

                OracleParameter prm152 = new OracleParameter("AGREEDRATE_ACTIVE", OracleType.VarChar);
                prm152.Direction = ParameterDirection.Input;
                if (agreedrate_active == "")
                    prm152.Value = System.DBNull.Value;
                else
                    prm152.Value = agreedrate_active;

                objOraclecommand.Parameters.Add(prm152);

                OracleParameter prm153 = new OracleParameter("AGREEDAMT_ACTIVE", OracleType.VarChar);
                prm153.Direction = ParameterDirection.Input;
                if (agreedamt_active == "")
                    prm153.Value = System.DBNull.Value;
                else
                    prm153.Value = agreedamt_active;

                objOraclecommand.Parameters.Add(prm153);

                OracleParameter prm154 = new OracleParameter("grossamtlocal_p", OracleType.VarChar);
                prm154.Direction = ParameterDirection.Input;
                if (grossamtlocal_p == "")
                    prm154.Value = System.DBNull.Value;
                else
                    prm154.Value = grossamtlocal_p;

                objOraclecommand.Parameters.Add(prm154);

                OracleParameter prm155 = new OracleParameter("billamtlocal_p", OracleType.VarChar);
                prm155.Direction = ParameterDirection.Input;
                if (billamtlocal_p == "")
                    prm155.Value = System.DBNull.Value;
                else
                    prm155.Value = billamtlocal_p;

                objOraclecommand.Parameters.Add(prm155);


                OracleParameter prm145a = new OracleParameter("chkadon_p", OracleType.VarChar);
                prm145a.Direction = ParameterDirection.Input;
                prm145a.Value = chkadon;
                objOraclecommand.Parameters.Add(prm145a);

                OracleParameter prm145b = new OracleParameter("refid_p", OracleType.VarChar);
                prm145b.Direction = ParameterDirection.Input;
                prm145b.Value = refid;
                objOraclecommand.Parameters.Add(prm145b);


                OracleParameter prm145c = new OracleParameter("rcpt_currency", OracleType.VarChar);
                prm145c.Direction = ParameterDirection.Input;
                prm145c.Value = rcpt_currency;
                objOraclecommand.Parameters.Add(prm145c);

                OracleParameter prm145d = new OracleParameter("cur_convrate", OracleType.VarChar);
                prm145d.Direction = ParameterDirection.Input;
                prm145d.Value = cur_convrate;
                objOraclecommand.Parameters.Add(prm145d);

                OracleParameter prm145e = new OracleParameter("p_revisedate", OracleType.VarChar);
                prm145e.Direction = ParameterDirection.Input;
                if (revisedate == "" || revisedate == null)
                {
                    prm145e.Value = System.DBNull.Value;

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
                    prm145e.Value = Convert.ToDateTime(revisedate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm145e);

                OracleParameter prm155a = new OracleParameter("clienttype", OracleType.VarChar);
                prm155a.Direction = ParameterDirection.Input;
                if (clienttype == "0")
                    prm155a.Value = System.DBNull.Value;
                else
                    prm155a.Value = clienttype;
                objOraclecommand.Parameters.Add(prm155a);

                OracleParameter prm153e = new OracleParameter("translation", OracleType.VarChar);
                prm153e.Direction = ParameterDirection.Input;
                if (translation == "0")
                    prm153e.Value = System.DBNull.Value;
                else
                    prm153e.Value = translation;
                objOraclecommand.Parameters.Add(prm153e);

                OracleParameter prm107a = new OracleParameter("translationcharge", OracleType.Number);
                prm107a.Direction = ParameterDirection.Input;
                if (translationcharge == "" || translationcharge == null)
                {
                    prm107a.Value = System.DBNull.Value;
                }
                else
                {
                    translationcharge = translationcharge.Replace("%", "");
                    prm107a.Value = Convert.ToDecimal(translationcharge);
                }
                objOraclecommand.Parameters.Add(prm107a);

                OracleParameter prm141a = new OracleParameter("fmgreasons", OracleType.VarChar);
                prm141a.Direction = ParameterDirection.Input;
                prm141a.Value = fmgreasons;
                objOraclecommand.Parameters.Add(prm141a);

                OracleParameter prm141b = new OracleParameter("canclecharge", OracleType.VarChar);
                prm141b.Direction = ParameterDirection.Input;
                prm141b.Value = canclecharge;
                objOraclecommand.Parameters.Add(prm141b);

                OracleParameter prm151b = new OracleParameter("P_ip", OracleType.VarChar);
                prm151b.Direction = ParameterDirection.Input;
                prm151b.Value = ip;
                objOraclecommand.Parameters.Add(prm151b);

                OracleParameter prm161b = new OracleParameter("P_RATE_AUDIT_FLAG", OracleType.VarChar);
                prm161b.Direction = ParameterDirection.Input;
                prm161b.Value = modifyrateaudit;
                objOraclecommand.Parameters.Add(prm161b);

                OracleParameter prm161bt = new OracleParameter("transdisc_p", OracleType.VarChar);
                prm161bt.Direction = ParameterDirection.Input;
                prm161bt.Value = transdisc;
                objOraclecommand.Parameters.Add(prm161bt);

                OracleParameter prm161bs = new OracleParameter("pospremdisc_p", OracleType.VarChar);
                prm161bs.Direction = ParameterDirection.Input;
                prm161bs.Value = pospremdisc;
                objOraclecommand.Parameters.Add(prm161bs);

                OracleParameter prm161b1 = new OracleParameter("billhold", OracleType.VarChar);
                prm161b1.Direction = ParameterDirection.Input;
                prm161b1.Value = billhold;
                objOraclecommand.Parameters.Add(prm161b1);

                OracleParameter prm161b1x = new OracleParameter("designbox", OracleType.VarChar);
                prm161b1x.Direction = ParameterDirection.Input;
                prm161b1x.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm161b1x);

                OracleParameter prm161b1z = new OracleParameter("logoprem", OracleType.VarChar);
                prm161b1z.Direction = ParameterDirection.Input;
                prm161b1z.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm161b1z);

                OracleParameter prm161b1az = new OracleParameter("online_ad_p", OracleType.VarChar);
                prm161b1az.Direction = ParameterDirection.Input;
                prm161b1az.Value = online_ad;
                objOraclecommand.Parameters.Add(prm161b1az);


                OracleParameter prm161b1az1 = new OracleParameter("pfixed_booking", OracleType.VarChar);
                prm161b1az1.Direction = ParameterDirection.Input;
                prm161b1az1.Value = fixed_booking;
                objOraclecommand.Parameters.Add(prm161b1az1);


                OracleParameter prm161b1az12 = new OracleParameter("pvat_code", OracleType.VarChar);
                prm161b1az12.Direction = ParameterDirection.Input;
                prm161b1az12.Value = vat_code;
                objOraclecommand.Parameters.Add(prm161b1az12);

                OracleParameter prm161b1az13 = new OracleParameter("CPN_CODE_P", OracleType.VarChar);
                prm161b1az13.Direction = ParameterDirection.Input;
                prm161b1az13.Value = cou_code;
                objOraclecommand.Parameters.Add(prm161b1az13);

                OracleParameter prm161b1az14 = new OracleParameter("CPN_NAME_P", OracleType.VarChar);
                prm161b1az14.Direction = ParameterDirection.Input;
                prm161b1az14.Value = cou_name;
                objOraclecommand.Parameters.Add(prm161b1az14);

                OracleParameter prm161b1az14A = new OracleParameter("STATE_P", OracleType.VarChar);
                prm161b1az14A.Direction = ParameterDirection.Input;
                prm161b1az14A.Value = state;
                objOraclecommand.Parameters.Add(prm161b1az14A);

                OracleParameter prm161z = new OracleParameter("clientcatdisc", OracleType.Number);
                prm161z.Direction = ParameterDirection.Input;
                if (clientcatdisc == "" || clientcatdisc == "0" || clientcatdisc == "null")
                {
                    prm161z.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z.Value = clientcatdisc;
                }
                objOraclecommand.Parameters.Add(prm161z);

                OracleParameter prm161z1 = new OracleParameter("clientcatamt", OracleType.Number);
                prm161z1.Direction = ParameterDirection.Input;
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    prm161z1.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z1.Value = clientcatamt;
                }
                objOraclecommand.Parameters.Add(prm161z1);

                OracleParameter prm161z2 = new OracleParameter("clientcatdistype", OracleType.VarChar);
                prm161z2.Direction = ParameterDirection.Input;
                prm161z2.Value = clientcatdistype;
                objOraclecommand.Parameters.Add(prm161z2);


                OracleParameter prm161z3 = new OracleParameter("flatfreqdisc", OracleType.Number);
                prm161z3.Direction = ParameterDirection.Input;
                if (flatfreqdisc == "" || flatfreqdisc == "0" || flatfreqdisc == "null")
                {
                    prm161z3.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z3.Value = flatfreqdisc;
                }
                objOraclecommand.Parameters.Add(prm161z3);



                OracleParameter prm161z4 = new OracleParameter("flatfreqamt", OracleType.Number);
                prm161z4.Direction = ParameterDirection.Input;
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    prm161z4.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z4.Value = flatfreqamt;
                }
                objOraclecommand.Parameters.Add(prm161z4);




                OracleParameter prm161z5 = new OracleParameter("flatfreqdisctype", OracleType.VarChar);
                prm161z5.Direction = ParameterDirection.Input;
                prm161z5.Value = flatfreqdisctype;
                objOraclecommand.Parameters.Add(prm161z5);

                OracleParameter prm161z6 = new OracleParameter("catdisc", OracleType.Number);
                prm161z6.Direction = ParameterDirection.Input;
                if (catdisc == "" || catdisc == "0" || catdisc == "null")
                {
                    prm161z6.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z6.Value = catdisc;
                }
                objOraclecommand.Parameters.Add(prm161z6);

                OracleParameter prm161z7 = new OracleParameter("catamt", OracleType.Number);
                prm161z7.Direction = ParameterDirection.Input;
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    prm161z7.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z7.Value = catamt;
                }
                objOraclecommand.Parameters.Add(prm161z7);

                OracleParameter prm161z8 = new OracleParameter("catdisctype", OracleType.VarChar);
                prm161z8.Direction = ParameterDirection.Input;
                prm161z8.Value = catdisctype;
                objOraclecommand.Parameters.Add(prm161z8);

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
        public DataSet insertbook_ins_update_bill(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string insertid, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string insert_caption, string subedidata, string disc_, string modifyrateaudit, string ip, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clientcatamt, string flatfreqamt, string catamt)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertintobookchildupdatebill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("insertdate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;

                if (insertdate == "" || insertdate == null)
                {
                    prm2.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = insertdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        insertdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = insertdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            insertdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm2.Value = Convert.ToDateTime(insertdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("edition", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);






                OracleParameter prm4 = new OracleParameter("premium1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = premium1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("premium2", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = premium2;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("premallow", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premallow;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcategory;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("latestdate", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;


                if (latestdate == "" || latestdate == null)
                {
                    prm8.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = latestdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        latestdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = latestdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            latestdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm8.Value = Convert.ToDateTime(latestdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("material", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = material;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("cardrate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;


                if (cardrate == "" || cardrate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = Convert.ToDecimal(cardrate);
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("matfilename", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = matfilename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("discrate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;


                if (discrate == "" || discrate == null || discrate == "null")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = Convert.ToDecimal(discrate);
                }
                objOraclecommand.Parameters.Add(prm12);
                /*==========================================================================================*/

                OracleParameter prm13 = new OracleParameter("insertstatus", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = insertstatus;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("billstatus", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = billstatus;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("adsubcat1", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = adsubcat;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm16 = new OracleParameter("userid", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("cioid", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = cioid;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("height", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;


                if (height == "" || height == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = Convert.ToDecimal(height);
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("width", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (width == "" || width == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = Convert.ToDecimal(width);
                }
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("totalsize", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                if (totalsize == "" || totalsize == null)
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    prm20.Value = Convert.ToDecimal(totalsize);
                }
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("pagepost", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = pagepost;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("premper1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    prm22.Value = Convert.ToDecimal(premper1);
                }
                objOraclecommand.Parameters.Add(prm22);




                OracleParameter prm23 = new OracleParameter("premper2", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (premper2 == "" || premper2 == null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDecimal(premper2);
                }
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("colid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = colid;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("repeat", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (repeat == "" || repeat == null)
                {
                    prm25.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = repeat.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        repeat = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = repeat.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            repeat = mm + "/" + dd + "/" + yy;
                    //        }
                    prm25.Value = Convert.ToDateTime(repeat).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("insertno", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (insertno == "" || insertno == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToInt32(insertno);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("paid", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = paid;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("agrrate", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDecimal(agrrate);
                }

                objOraclecommand.Parameters.Add(prm28);






                OracleParameter prm29 = new OracleParameter("solorate", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = Convert.ToDecimal(solorate);
                }

                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("grossrate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (grossrate == "" || grossrate == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = Convert.ToDecimal(grossrate);
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("insert_pageno", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    prm31.Value = Convert.ToInt32("0");
                }
                else
                {
                    prm31.Value = Convert.ToInt32(insert_pageno);
                }
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("insert_remarks", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = insert_remarks;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm34 = new OracleParameter("page_code", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = page_code;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm33 = new OracleParameter("page_per", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToDecimal(page_per);
                }
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm35 = new OracleParameter("noofcol", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                if (noofcol == "" || noofcol == null)
                {
                    prm35.Value = System.DBNull.Value;
                }
                else
                {
                    prm35.Value = Convert.ToDecimal(noofcol);
                }
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("billamt", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                if (billamt == "" || billamt == null)
                {
                    prm36.Value = System.DBNull.Value;
                }
                else
                {
                    prm36.Value = Convert.ToDecimal(billamt);
                }
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("billrate", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                if (billrate == "" || billrate == null)
                {
                    prm37.Value = System.DBNull.Value;
                }
                else
                {
                    prm37.Value = Convert.ToDecimal(billrate);
                }
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm40 = new OracleParameter("logo_h", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = logo_h;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm38 = new OracleParameter("logo_w", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = logo_w;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("logo_name", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = logo_name;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm43 = new OracleParameter("ad_cat_3", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = adcat3;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm41 = new OracleParameter("ad_cat_4", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = adcat4;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("ad_cat_5", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = adcat5;
                objOraclecommand.Parameters.Add(prm42);
                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                OracleParameter prm44 = new OracleParameter("pkgcode", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("gridins", OracleType.Number);
                prm45.Direction = ParameterDirection.Input;
                if (gridins == "")
                {
                    gridins = "1";
                }
                prm45.Value = gridins;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("pkgalias", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = pkgalias;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("insertid1", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = insertid;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm51 = new OracleParameter("cirvts", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                if (cirvts == "null" || cirvts == null)
                    prm51.Value = System.DBNull.Value;
                else
                    prm51.Value = cirvts;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm48 = new OracleParameter("cirpub", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                if (cirpub == "null" || cirpub == null)
                    prm48.Value = System.DBNull.Value;
                else
                    prm48.Value = cirpub;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm49 = new OracleParameter("ciredi", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                if (cirpub == "null" || cirpub == null)
                    prm49.Value = System.DBNull.Value;
                else
                    prm49.Value = ciredi;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("cirrate", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                if (cirrate == "null" && cirrate == null)
                    prm50.Value = System.DBNull.Value;
                else
                    prm50.Value = cirrate;
                objOraclecommand.Parameters.Add(prm50);


                OracleParameter prm59 = new OracleParameter("cirdate_v", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                if (cirdate == "" || cirdate == null)
                {
                    prm59.Value = System.DBNull.Value;
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
                    prm59.Value = Convert.ToDateTime(cirdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm52 = new OracleParameter("ciragency_v", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = ciragency;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("ciragencysubcode_v", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = ciragencysubcode;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("center_v", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = center;
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("branch_v", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = branch;
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm58 = new OracleParameter("splboldsizevalue", OracleType.VarChar);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = splboldsizevalue;
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59a = new OracleParameter("vatrate_p", OracleType.Float);
                prm59a.Direction = ParameterDirection.Input;
                if (vatrate == "" || vatrate == "null" || vatrate == null || vatrate == "undefined")
                    prm59a.Value = System.DBNull.Value;
                else
                    prm59a.Value = Convert.ToDecimal(vatrate);
                objOraclecommand.Parameters.Add(prm59a);

                OracleParameter prm60 = new OracleParameter("boxcharge_p", OracleType.Float);
                prm60.Direction = ParameterDirection.Input;
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null)
                    prm60.Value = System.DBNull.Value;
                else
                    prm60.Value = Convert.ToDecimal(boxcharge);
                objOraclecommand.Parameters.Add(prm60);

                OracleParameter prm61 = new OracleParameter("vat_inc_p", OracleType.Float);
                prm61.Direction = ParameterDirection.Input;
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null || vat_inc_p == "undefined")
                    prm61.Value = System.DBNull.Value;
                else
                    prm61.Value = vat_inc_p;
                objOraclecommand.Parameters.Add(prm61);


                OracleParameter prm61a = new OracleParameter("grossamtlocal_p", OracleType.VarChar);
                prm61a.Direction = ParameterDirection.Input;
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    prm61a.Value = System.DBNull.Value;
                else
                    prm61a.Value = grossamtlocal_p;
                objOraclecommand.Parameters.Add(prm61a);


                OracleParameter prm61b = new OracleParameter("billamtlocal_p", OracleType.VarChar);
                prm61b.Direction = ParameterDirection.Input;
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    prm61b.Value = System.DBNull.Value;
                else
                    prm61b.Value = billamtlocal_p;
                objOraclecommand.Parameters.Add(prm61b);

                OracleParameter prm61b1 = new OracleParameter("sectioncode_p", OracleType.VarChar);
                prm61b1.Direction = ParameterDirection.Input;
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    prm61b1.Value = System.DBNull.Value;
                else
                    prm61b1.Value = sectioncode_p;
                objOraclecommand.Parameters.Add(prm61b1);

                OracleParameter prm61b11 = new OracleParameter("resourceno_p", OracleType.VarChar);
                prm61b11.Direction = ParameterDirection.Input;
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    prm61b11.Value = System.DBNull.Value;
                else
                    prm61b11.Value = resourceno_p;
                objOraclecommand.Parameters.Add(prm61b11);

                OracleParameter prm61b112 = new OracleParameter("caption_inserts_p", OracleType.VarChar);
                prm61b112.Direction = ParameterDirection.Input;
                if (insert_caption == "" || insert_caption == "null" || insert_caption == null)
                    prm61b112.Value = System.DBNull.Value;
                else
                    prm61b112.Value = insert_caption;
                objOraclecommand.Parameters.Add(prm61b112);

                OracleParameter prm63 = new OracleParameter("subedidata", OracleType.VarChar);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = subedidata;
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm61bx = new OracleParameter("disc_p", OracleType.VarChar);
                prm61bx.Direction = ParameterDirection.Input;
                if (disc_ == "" || disc_ == "null" || disc_ == null)
                    prm61bx.Value = System.DBNull.Value;
                else
                    prm61bx.Value = disc_;
                objOraclecommand.Parameters.Add(prm61bx);

                OracleParameter prm151b = new OracleParameter("P_ip", OracleType.VarChar);
                prm151b.Direction = ParameterDirection.Input;
                prm151b.Value = ip;
                objOraclecommand.Parameters.Add(prm151b);


                OracleParameter prm62bx = new OracleParameter("agncyamnt", OracleType.VarChar);
                prm62bx.Direction = ParameterDirection.Input;
                if (agncyamnt == "" || agncyamnt == "null" || agncyamnt == null)
                    prm62bx.Value = System.DBNull.Value;
                else
                    prm62bx.Value = agncyamnt;
                objOraclecommand.Parameters.Add(prm62bx);

                OracleParameter prm63bx = new OracleParameter("adlgncyamnt", OracleType.VarChar);
                prm63bx.Direction = ParameterDirection.Input;
                if (adlgncyamnt == "" || adlgncyamnt == "null" || adlgncyamnt == null)
                    prm63bx.Value = System.DBNull.Value;
                else
                    prm63bx.Value = adlgncyamnt;
                objOraclecommand.Parameters.Add(prm63bx);

                OracleParameter prm64bx = new OracleParameter("spldiscamt", OracleType.VarChar);
                prm64bx.Direction = ParameterDirection.Input;
                if (spldisc == "" || spldisc == "null" || spldisc == null)
                    prm64bx.Value = System.DBNull.Value;
                else
                    prm64bx.Value = spldisc;
                objOraclecommand.Parameters.Add(prm64bx);


                OracleParameter prm65bx = new OracleParameter("cashdamnt", OracleType.VarChar);
                prm65bx.Direction = ParameterDirection.Input;
                if (cashdisc == "" || cashdisc == "null" || cashdisc == null)
                    prm65bx.Value = System.DBNull.Value;
                else
                    prm65bx.Value = cashdisc;
                objOraclecommand.Parameters.Add(prm65bx);


                OracleParameter prm161b = new OracleParameter("P_RATE_AUDIT_FLAG", OracleType.VarChar);
                prm161b.Direction = ParameterDirection.Input;
                prm161b.Value = modifyrateaudit;
                objOraclecommand.Parameters.Add(prm161b);

                OracleParameter prm65bt = new OracleParameter("ROUNDOFF", OracleType.VarChar);
                prm65bt.Direction = ParameterDirection.Input;
                if (roundoffamt == "" || roundoffamt == "null" || roundoffamt == null)
                    prm65bt.Value = System.DBNull.Value;
                else
                    prm65bt.Value = roundoffamt;
                objOraclecommand.Parameters.Add(prm65bt);

                OracleParameter prm65ct = new OracleParameter("PDFHEIGHT", OracleType.VarChar);
                prm65ct.Direction = ParameterDirection.Input;
                if (pdfheight == "" || pdfheight == "null" || pdfheight == null)
                    prm65ct.Value = System.DBNull.Value;
                else
                    prm65ct.Value = pdfheight;
                objOraclecommand.Parameters.Add(prm65ct);

                OracleParameter prm65cb = new OracleParameter("CPNAMT", OracleType.VarChar);
                prm65cb.Direction = ParameterDirection.Input;
                if (cpnamt == "" || cpnamt == "null" || cpnamt == null)
                    prm65cb.Value = System.DBNull.Value;
                else
                    prm65cb.Value = cpnamt;
                objOraclecommand.Parameters.Add(prm65cb);

                OracleParameter prm161z1 = new OracleParameter("clientcatamt", OracleType.Number);
                prm161z1.Direction = ParameterDirection.Input;
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    prm161z1.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z1.Value = clientcatamt;
                }
                objOraclecommand.Parameters.Add(prm161z1);



                OracleParameter prm161z4 = new OracleParameter("flatfreqamt", OracleType.Number);
                prm161z4.Direction = ParameterDirection.Input;
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    prm161z4.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z4.Value = flatfreqamt;
                }
                objOraclecommand.Parameters.Add(prm161z4);


                OracleParameter prm161z7 = new OracleParameter("catamt", OracleType.Number);
                prm161z7.Direction = ParameterDirection.Input;
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    prm161z7.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z7.Value = catamt;
                }
                objOraclecommand.Parameters.Add(prm161z7);




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
        public DataSet insertbook_ins_display_bill(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string insertid, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string subedidata, string disc_, string modifyrateaudit, string ip, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clientcatamt, string flatfreqamt, string catamt)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertintobookchilddisplaybill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("insertdate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;

                if (insertdate == "" || insertdate == null)
                {
                    prm2.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = insertdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        insertdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = insertdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            insertdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm2.Value = Convert.ToDateTime(insertdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("edition", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);






                OracleParameter prm4 = new OracleParameter("premium1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = premium1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("premium2", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = premium2;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("premallow", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premallow;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcategory;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("latestdate", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;


                if (latestdate == "" || latestdate == null)
                {
                    prm8.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = latestdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        latestdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = latestdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            latestdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm8.Value = Convert.ToDateTime(latestdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("material", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = material;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("cardrate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;


                if (cardrate == "" || cardrate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = Convert.ToDecimal(cardrate);
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("matfilename", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = matfilename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("discrate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;


                if (discrate == "" || discrate == null || discrate == "null")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = Convert.ToDecimal(discrate);
                }
                objOraclecommand.Parameters.Add(prm12);
                /*==========================================================================================*/

                OracleParameter prm13 = new OracleParameter("insertstatus", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = insertstatus;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("billstatus", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = billstatus;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("adsubcat1", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = adsubcat;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm16 = new OracleParameter("userid", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("cioid", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = cioid;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("height", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;


                if (height == "" || height == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = Convert.ToDecimal(height);
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("width", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (width == "" || width == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = Convert.ToDecimal(width);
                }
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("totalsize", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                if (totalsize == "" || totalsize == null)
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    prm20.Value = Convert.ToDecimal(totalsize);
                }
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("pagepost", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = pagepost;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("premper1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    prm22.Value = Convert.ToDecimal(premper1);
                }
                objOraclecommand.Parameters.Add(prm22);




                OracleParameter prm23 = new OracleParameter("premper2", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (premper2 == "" || premper2 == null || premper2 == "null")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDecimal(premper2);
                }
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("colid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = colid;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("repeat", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (repeat == "" || repeat == null)
                {
                    prm25.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = repeat.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        repeat = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = repeat.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            repeat = mm + "/" + dd + "/" + yy;
                    //        }
                    prm25.Value = Convert.ToDateTime(repeat).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("insertno", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (insertno == "" || insertno == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToInt32(insertno);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("paid", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = paid;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("agrrate", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDecimal(agrrate);
                }

                objOraclecommand.Parameters.Add(prm28);






                OracleParameter prm29 = new OracleParameter("solorate", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = Convert.ToDecimal(solorate);
                }

                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("grossrate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (grossrate == "" || grossrate == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = Convert.ToDecimal(grossrate);
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("insert_pageno", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    prm31.Value = Convert.ToInt32("0");
                }
                else
                {
                    prm31.Value = Convert.ToInt32(insert_pageno);
                }
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("insert_remarks", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = insert_remarks;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm34 = new OracleParameter("page_code", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = page_code;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm33 = new OracleParameter("page_per", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToDecimal(page_per);
                }
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm35 = new OracleParameter("noofcol", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                if (noofcol == "" || noofcol == null)
                {
                    prm35.Value = System.DBNull.Value;
                }
                else
                {
                    prm35.Value = Convert.ToDecimal(noofcol);
                }
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("billamt", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                if (billamt == "" || billamt == null)
                {
                    prm36.Value = System.DBNull.Value;
                }
                else
                {
                    prm36.Value = Convert.ToDecimal(billamt);
                }
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("billrate", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                if (billrate == "" || billrate == null)
                {
                    prm37.Value = System.DBNull.Value;
                }
                else
                {
                    prm37.Value = Convert.ToDecimal(billrate);
                }
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm40 = new OracleParameter("logo_h", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = logo_h;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm38 = new OracleParameter("logo_w", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = logo_w;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("logo_name", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = logo_name;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm43 = new OracleParameter("ad_cat_3", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = adcat3;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm41 = new OracleParameter("ad_cat_4", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = adcat4;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("ad_cat_5", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = adcat5;
                objOraclecommand.Parameters.Add(prm42);
                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                OracleParameter prm44 = new OracleParameter("pkgcode", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("gridins", OracleType.Number);
                prm45.Direction = ParameterDirection.Input;
                if (gridins == "")
                {
                    gridins = "1";
                }
                prm45.Value = gridins;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("pkgalias", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = pkgalias;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("insertid1", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                if (insertid == "")
                    insertid = "0";
                prm47.Value = insertid;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm51 = new OracleParameter("cirvts", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                if (cirvts == "null" || cirvts == null)
                    prm51.Value = System.DBNull.Value;
                else
                    prm51.Value = cirvts;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm48 = new OracleParameter("cirpub", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                if (cirpub == "null" || cirpub == null)
                    prm48.Value = System.DBNull.Value;
                else
                    prm48.Value = cirpub;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm49 = new OracleParameter("ciredi", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                if (cirpub == "null" || cirpub == null)
                    prm49.Value = System.DBNull.Value;
                else
                    prm49.Value = ciredi;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("cirrate", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                if (cirrate == "null" && cirrate == null)
                    prm50.Value = System.DBNull.Value;
                else
                    prm50.Value = cirrate;
                objOraclecommand.Parameters.Add(prm50);


                OracleParameter prm59 = new OracleParameter("cirdate_v", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                if (cirdate == "" || cirdate == null)
                {
                    prm59.Value = System.DBNull.Value;
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
                    prm59.Value = Convert.ToDateTime(cirdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm52 = new OracleParameter("ciragency_v", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = ciragency;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("ciragencysubcode_v", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = ciragencysubcode;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("center_v", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = center;
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("branch_v", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = branch;
                objOraclecommand.Parameters.Add(prm55);


                OracleParameter prm60 = new OracleParameter("boxcharge_p", OracleType.Float);
                prm60.Direction = ParameterDirection.Input;
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null || boxcharge == "0")
                    prm60.Value = System.DBNull.Value;
                else
                    prm60.Value = Convert.ToDecimal(boxcharge);
                objOraclecommand.Parameters.Add(prm60);

                OracleParameter prm61 = new OracleParameter("vat_inc_p", OracleType.Float);
                prm61.Direction = ParameterDirection.Input;
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null || vat_inc_p == "undefined")
                    prm61.Value = System.DBNull.Value;
                else
                    prm61.Value = vat_inc_p;
                objOraclecommand.Parameters.Add(prm61);
                //OracleParameter prm58 = new OracleParameter("splboldsizevalue", OracleType.VarChar);
                //prm58.Direction = ParameterDirection.Input;
                //prm58.Value = System.DBNull.Value;
                //objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59a = new OracleParameter("vatrate_p", OracleType.Float);
                prm59a.Direction = ParameterDirection.Input;
                if (vatrate == "" || vatrate == "null" || vatrate == null || vatrate == "undefined")
                    prm59a.Value = System.DBNull.Value;
                else
                    prm59a.Value = Convert.ToDecimal(vatrate);
                objOraclecommand.Parameters.Add(prm59a);

                OracleParameter prm61a = new OracleParameter("grossamtlocal_p", OracleType.VarChar);
                prm61a.Direction = ParameterDirection.Input;
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    prm61a.Value = System.DBNull.Value;
                else
                    prm61a.Value = grossamtlocal_p;
                objOraclecommand.Parameters.Add(prm61a);

                OracleParameter prm61b = new OracleParameter("billamtlocal_p", OracleType.VarChar);
                prm61b.Direction = ParameterDirection.Input;
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    prm61b.Value = System.DBNull.Value;
                else
                    prm61b.Value = billamtlocal_p;
                objOraclecommand.Parameters.Add(prm61b);

                OracleParameter prm61b1 = new OracleParameter("sectioncode_p", OracleType.VarChar);
                prm61b1.Direction = ParameterDirection.Input;
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    prm61b1.Value = System.DBNull.Value;
                else
                    prm61b1.Value = sectioncode_p;
                objOraclecommand.Parameters.Add(prm61b1);


                OracleParameter prm61b11 = new OracleParameter("resourceno_p", OracleType.VarChar);
                prm61b11.Direction = ParameterDirection.Input;
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    prm61b11.Value = System.DBNull.Value;
                else
                    prm61b11.Value = resourceno_p;
                objOraclecommand.Parameters.Add(prm61b11);

                OracleParameter prm61b112 = new OracleParameter("caption_inserts_p", OracleType.VarChar);
                prm61b112.Direction = ParameterDirection.Input;
                if (caption_inserts == "" || caption_inserts == "null" || caption_inserts == null || caption_inserts == "0")
                    prm61b112.Value = System.DBNull.Value;
                else
                    prm61b112.Value = caption_inserts;
                objOraclecommand.Parameters.Add(prm61b112);

                OracleParameter prm61b13 = new OracleParameter("dealerheight", OracleType.VarChar);
                prm61b13.Direction = ParameterDirection.Input;
                if (dealerheight == "" || dealerheight == "null" || dealerheight == null || dealerheight == "0")
                    prm61b13.Value = System.DBNull.Value;
                else
                    prm61b13.Value = dealerheight;
                objOraclecommand.Parameters.Add(prm61b13);

                OracleParameter prm61b14 = new OracleParameter("dealerwidth", OracleType.VarChar);
                prm61b14.Direction = ParameterDirection.Input;
                if (dealerwidth == "" || dealerwidth == "null" || dealerwidth == null || dealerwidth == "0")
                    prm61b14.Value = System.DBNull.Value;
                else
                    prm61b14.Value = dealerwidth;
                objOraclecommand.Parameters.Add(prm61b14);

                OracleParameter prm63 = new OracleParameter("subedidata", OracleType.VarChar);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = subedidata;
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm61bx = new OracleParameter("disc_p", OracleType.VarChar);
                prm61bx.Direction = ParameterDirection.Input;
                if (disc_ == "" || disc_ == "null" || disc_ == null || disc_ == "0")
                    prm61bx.Value = System.DBNull.Value;
                else
                    prm61bx.Value = disc_;
                objOraclecommand.Parameters.Add(prm61bx);

                OracleParameter prm151b = new OracleParameter("P_ip", OracleType.VarChar);
                prm151b.Direction = ParameterDirection.Input;
                prm151b.Value = ip;
                objOraclecommand.Parameters.Add(prm151b);

                OracleParameter prm161b = new OracleParameter("P_RATE_AUDIT_FLAG", OracleType.VarChar);
                prm161b.Direction = ParameterDirection.Input;
                prm161b.Value = modifyrateaudit;
                objOraclecommand.Parameters.Add(prm161b);


                OracleParameter prm62bx = new OracleParameter("agnamnt", OracleType.VarChar);
                prm62bx.Direction = ParameterDirection.Input;
                if (agncyamnt == "" || agncyamnt == "null" || agncyamnt == null || agncyamnt == "0")
                    prm62bx.Value = System.DBNull.Value;
                else
                    prm62bx.Value = agncyamnt;
                objOraclecommand.Parameters.Add(prm62bx);

                OracleParameter prm63bx = new OracleParameter("adlgncyamnt", OracleType.VarChar);
                prm63bx.Direction = ParameterDirection.Input;
                if (adlgncyamnt == "" || adlgncyamnt == "null" || adlgncyamnt == null || adlgncyamnt == "0")
                    prm63bx.Value = System.DBNull.Value;
                else
                    prm63bx.Value = adlgncyamnt;
                objOraclecommand.Parameters.Add(prm63bx);

                OracleParameter prm64bx = new OracleParameter("spldiscamt", OracleType.VarChar);
                prm64bx.Direction = ParameterDirection.Input;
                if (spldisc == "" || spldisc == "null" || spldisc == null || spldisc == "0")
                    prm64bx.Value = System.DBNull.Value;
                else
                    prm64bx.Value = spldisc;
                objOraclecommand.Parameters.Add(prm64bx);


                OracleParameter prm65bx = new OracleParameter("cashdamnt", OracleType.VarChar);
                prm65bx.Direction = ParameterDirection.Input;
                if (cashdisc == "" || cashdisc == "null" || cashdisc == null || cashdisc == "0")
                    prm65bx.Value = System.DBNull.Value;
                else
                    prm65bx.Value = cashdisc;
                objOraclecommand.Parameters.Add(prm65bx);

                OracleParameter prm65bt = new OracleParameter("ROUNDOFF", OracleType.VarChar);
                prm65bt.Direction = ParameterDirection.Input;
                if (roundoffamt == "" || roundoffamt == "null" || roundoffamt == null || roundoffamt == "0")
                    prm65bt.Value = System.DBNull.Value;
                else
                    prm65bt.Value = roundoffamt;
                objOraclecommand.Parameters.Add(prm65bt);

                OracleParameter prm65ct = new OracleParameter("PDFHEIGHT", OracleType.VarChar);
                prm65ct.Direction = ParameterDirection.Input;
                if (pdfheight == "" || pdfheight == "null" || pdfheight == null || pdfheight == "0")
                    prm65ct.Value = System.DBNull.Value;
                else
                    prm65ct.Value = pdfheight;
                objOraclecommand.Parameters.Add(prm65ct);

                OracleParameter prm65cb = new OracleParameter("CPNAMT", OracleType.VarChar);
                prm65cb.Direction = ParameterDirection.Input;
                if (cpnamt == "" || cpnamt == "null" || cpnamt == null || cpnamt == "0")
                    prm65cb.Value = System.DBNull.Value;
                else
                    prm65cb.Value = cpnamt;
                objOraclecommand.Parameters.Add(prm65cb);

                OracleParameter prm161z1 = new OracleParameter("clientcatamt", OracleType.Number);
                prm161z1.Direction = ParameterDirection.Input;
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    prm161z1.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z1.Value = clientcatamt;
                }
                objOraclecommand.Parameters.Add(prm161z1);



                OracleParameter prm161z4 = new OracleParameter("flatfreqamt", OracleType.Number);
                prm161z4.Direction = ParameterDirection.Input;
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    prm161z4.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z4.Value = flatfreqamt;
                }
                objOraclecommand.Parameters.Add(prm161z4);


                OracleParameter prm161z7 = new OracleParameter("catamt", OracleType.Number);
                prm161z7.Direction = ParameterDirection.Input;
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    prm161z7.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z7.Value = catamt;
                }
                objOraclecommand.Parameters.Add(prm161z7);

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
        public DataSet billupdatedatatemptable(string compcode, string ciobookid, string supplementbilldate, string supplementbillno, string userid, string dateformat, string supcioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("receiptsave_booking_bill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcioid1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ciobookid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("poldbill_no", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = supplementbillno;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pcioid2", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = supcioid;
                objOraclecommand.Parameters.Add(prm5);


                objOraclecommand.Parameters.Add("prcptno", OracleType.VarChar, 200);
                objOraclecommand.Parameters["prcptno"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_error", OracleType.VarChar, 200);
                objOraclecommand.Parameters["p_error"].Direction = ParameterDirection.Output;

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
        public DataSet colexec_bind(string compcode, string colexec)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("repbind.repbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("pextra1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = colexec;
                objOraclecommand.Parameters.Add(prm11);

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
        public string insertbook_ins(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splitdata, string subedidata, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string disc_, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clientcatamt, string flatfreqamt, string catamt, string premamtval, string gstamount, string gstgrid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            string output = "";
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertintobookchild.insertintobookchild_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("insertdate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;

                if (insertdate == "" || insertdate == null)
                {
                    prm2.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = insertdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        insertdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = insertdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            insertdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm2.Value = Convert.ToDateTime(insertdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("edition", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);






                OracleParameter prm4 = new OracleParameter("premium1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = premium1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("premium2", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = premium2;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("premallow", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premallow;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcategory;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("latestdate", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;


                if (latestdate == "" || latestdate == null)
                {
                    prm8.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = latestdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        latestdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = latestdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            latestdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm8.Value = Convert.ToDateTime(latestdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("material", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = material;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("cardrate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;


                if (cardrate == "" || cardrate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = Convert.ToDecimal(cardrate);
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("matfilename", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = matfilename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("discrate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;


                if (discrate == "" || discrate == null || discrate == "null")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = Convert.ToDecimal(discrate);
                }
                objOraclecommand.Parameters.Add(prm12);
                /*==========================================================================================*/

                OracleParameter prm13 = new OracleParameter("insertstatus", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = insertstatus;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("billstatus", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = billstatus;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("adsubcat1", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = adsubcat;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm16 = new OracleParameter("userid", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("cioid", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = cioid;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("height", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;


                if (height == "" || height == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = Convert.ToDecimal(height);
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("width", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (width == "" || width == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = Convert.ToDecimal(width);
                }
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("totalsize", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                if (totalsize == "" || totalsize == null)
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    prm20.Value = Convert.ToDecimal(totalsize);
                }
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("pagepost", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = pagepost;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("premper1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    prm22.Value = Convert.ToDecimal(premper1);
                }
                objOraclecommand.Parameters.Add(prm22);




                OracleParameter prm23 = new OracleParameter("premper2", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (premper2 == "" || premper2 == null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDecimal(premper2);
                }
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("colid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = colid;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("repeat", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (repeat == "" || repeat == null)
                {
                    prm25.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = repeat.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        repeat = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = repeat.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            repeat = mm + "/" + dd + "/" + yy;
                    //        }
                    prm25.Value = Convert.ToDateTime(repeat).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("insertno", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (insertno == "" || insertno == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToInt32(insertno);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("paid", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = paid;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("agrrate", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDecimal(agrrate);
                }

                objOraclecommand.Parameters.Add(prm28);






                OracleParameter prm29 = new OracleParameter("solorate", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = Convert.ToDecimal(solorate);
                }

                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("grossrate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (grossrate == "" || grossrate == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = Convert.ToDecimal(grossrate);
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("insert_pageno", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    prm31.Value = Convert.ToInt32("0");
                }
                else
                {
                    prm31.Value = Convert.ToInt32(insert_pageno);
                }
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("insert_remarks", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = insert_remarks;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm34 = new OracleParameter("page_code", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = page_code;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm33 = new OracleParameter("page_per", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToDecimal(page_per);
                }
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm35 = new OracleParameter("noofcol", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                if (noofcol == "" || noofcol == null)
                {
                    prm35.Value = System.DBNull.Value;
                }
                else
                {
                    prm35.Value = Convert.ToDecimal(noofcol);
                }
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("billamt", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                if (billamt == "" || billamt == null)
                {
                    prm36.Value = System.DBNull.Value;
                }
                else
                {
                    prm36.Value = Convert.ToDecimal(billamt);
                }
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("billrate", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                if (billrate == "" || billrate == null)
                {
                    prm37.Value = System.DBNull.Value;
                }
                else
                {
                    prm37.Value = Convert.ToDecimal(billrate);
                }
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm40 = new OracleParameter("logo_h", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = logo_h;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm38 = new OracleParameter("logo_w", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = logo_w;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("logo_name", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = logo_name;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm43 = new OracleParameter("ad_cat_3", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = adcat3;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm41 = new OracleParameter("ad_cat_4", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = adcat4;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("ad_cat_5", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = adcat5;
                objOraclecommand.Parameters.Add(prm42);
                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                OracleParameter prm44 = new OracleParameter("pkgcode", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("gridins", OracleType.Number);
                prm45.Direction = ParameterDirection.Input;
                if (gridins == "")
                {
                    gridins = "1";
                }
                prm45.Value = gridins;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("pkgalias", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = pkgalias;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("cirvts", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = cirvts;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm48 = new OracleParameter("cirpub", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                prm48.Value = cirpub;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm49 = new OracleParameter("ciredi", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                prm49.Value = ciredi;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("cirrate", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = cirrate;
                objOraclecommand.Parameters.Add(prm50);


                OracleParameter prm51 = new OracleParameter("cirdate_v", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                if (cirdate == "" || cirdate == null)
                {
                    prm51.Value = System.DBNull.Value;
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
                    prm51.Value = Convert.ToDateTime(cirdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm52 = new OracleParameter("ciragency_v", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = ciragency;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("ciragencysubcode_v", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = ciragencysubcode;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("center_v", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = center;
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("branch_v", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = branch;
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm56 = new OracleParameter("splitdata_v", OracleType.VarChar);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = splitdata;
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("subedidata", OracleType.VarChar);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = subedidata;
                objOraclecommand.Parameters.Add(prm57);

                OracleParameter prm58 = new OracleParameter("splboldsizevalue", OracleType.VarChar);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = splboldsizevalue;
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59 = new OracleParameter("vatrate_p", OracleType.Float);
                prm59.Direction = ParameterDirection.Input;
                if (vatrate == "" || vatrate == "null" || vatrate == null || vatrate == "undefined")
                    prm59.Value = System.DBNull.Value;
                else
                    prm59.Value = Convert.ToDecimal(vatrate);
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("boxcharge_p", OracleType.Float);
                prm60.Direction = ParameterDirection.Input;
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null || boxcharge == "0")
                    prm60.Value = System.DBNull.Value;
                else
                    prm60.Value = Convert.ToDecimal(boxcharge);
                objOraclecommand.Parameters.Add(prm60);

                OracleParameter prm61 = new OracleParameter("vat_inc_p", OracleType.Float);
                prm61.Direction = ParameterDirection.Input;
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null || vat_inc_p == "undefined")
                    prm61.Value = System.DBNull.Value;
                else
                    prm61.Value = vat_inc_p;
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm61a = new OracleParameter("grossamtlocal_p", OracleType.VarChar);
                prm61a.Direction = ParameterDirection.Input;
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    prm61a.Value = System.DBNull.Value;
                else
                    prm61a.Value = grossamtlocal_p;
                objOraclecommand.Parameters.Add(prm61a);

                OracleParameter prm61b = new OracleParameter("billamtlocal_p", OracleType.VarChar);
                prm61b.Direction = ParameterDirection.Input;
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    prm61b.Value = System.DBNull.Value;
                else
                    prm61b.Value = billamtlocal_p;
                objOraclecommand.Parameters.Add(prm61b);

                OracleParameter prm61b1 = new OracleParameter("sectioncode_p", OracleType.VarChar);
                prm61b1.Direction = ParameterDirection.Input;
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    prm61b1.Value = System.DBNull.Value;
                else
                    prm61b1.Value = sectioncode_p;
                objOraclecommand.Parameters.Add(prm61b1);

                OracleParameter prm61b11 = new OracleParameter("resourceno_p", OracleType.VarChar);
                prm61b11.Direction = ParameterDirection.Input;
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    prm61b11.Value = System.DBNull.Value;
                else
                    prm61b11.Value = resourceno_p;
                objOraclecommand.Parameters.Add(prm61b11);

                OracleParameter prm61b12 = new OracleParameter("caption_inserts_p", OracleType.VarChar);
                prm61b12.Direction = ParameterDirection.Input;
                if (caption_inserts == "" || caption_inserts == "null" || caption_inserts == null)
                    prm61b12.Value = System.DBNull.Value;
                else
                    prm61b12.Value = caption_inserts;
                objOraclecommand.Parameters.Add(prm61b12);

                OracleParameter prm61b13 = new OracleParameter("dealerheight", OracleType.VarChar);
                prm61b13.Direction = ParameterDirection.Input;
                if (dealerheight == "" || dealerheight == "null" || dealerheight == null)
                    prm61b13.Value = System.DBNull.Value;
                else
                    prm61b13.Value = dealerheight;
                objOraclecommand.Parameters.Add(prm61b13);

                OracleParameter prm61b14 = new OracleParameter("dealerwidth", OracleType.VarChar);
                prm61b14.Direction = ParameterDirection.Input;
                if (dealerwidth == "" || dealerwidth == "null" || dealerwidth == null)
                    prm61b14.Value = System.DBNull.Value;
                else
                    prm61b14.Value = dealerwidth;
                objOraclecommand.Parameters.Add(prm61b14);


                OracleParameter prm61bx = new OracleParameter("disc_p", OracleType.VarChar);
                prm61bx.Direction = ParameterDirection.Input;
                if (disc_ == "" || disc_ == "null" || disc_ == null)
                    prm61bx.Value = System.DBNull.Value;
                else
                    prm61bx.Value = disc_;
                objOraclecommand.Parameters.Add(prm61bx);


                OracleParameter prm62bx = new OracleParameter("agncyamnt", OracleType.VarChar);
                prm62bx.Direction = ParameterDirection.Input;
                if (agncyamnt == "" || agncyamnt == "null" || agncyamnt == null)
                    prm62bx.Value = System.DBNull.Value;
                else
                    prm62bx.Value = agncyamnt;
                objOraclecommand.Parameters.Add(prm62bx);

                OracleParameter prm63bx = new OracleParameter("adlgncyamnt", OracleType.VarChar);
                prm63bx.Direction = ParameterDirection.Input;
                if (adlgncyamnt == "" || adlgncyamnt == "null" || adlgncyamnt == null)
                    prm63bx.Value = System.DBNull.Value;
                else
                    prm63bx.Value = adlgncyamnt;
                objOraclecommand.Parameters.Add(prm63bx);

                OracleParameter prm64bx = new OracleParameter("spldiscamt", OracleType.VarChar);
                prm64bx.Direction = ParameterDirection.Input;
                if (spldisc == "" || spldisc == "null" || spldisc == null)
                    prm64bx.Value = System.DBNull.Value;
                else
                    prm64bx.Value = spldisc;
                objOraclecommand.Parameters.Add(prm64bx);


                OracleParameter prm65bx = new OracleParameter("cashdamnt", OracleType.VarChar);
                prm65bx.Direction = ParameterDirection.Input;
                if (cashdisc == "" || cashdisc == "null" || cashdisc == null)
                    prm65bx.Value = System.DBNull.Value;
                else
                    prm65bx.Value = cashdisc;
                objOraclecommand.Parameters.Add(prm65bx);

                OracleParameter prm65bt = new OracleParameter("ROUNDOFF", OracleType.VarChar);
                prm65bt.Direction = ParameterDirection.Input;
                if (roundoffamt == "" || roundoffamt == "null" || roundoffamt == null)
                    prm65bt.Value = System.DBNull.Value;
                else
                    prm65bt.Value = roundoffamt;
                objOraclecommand.Parameters.Add(prm65bt);

                OracleParameter prm65ct = new OracleParameter("PDFHEIGHT", OracleType.VarChar);
                prm65ct.Direction = ParameterDirection.Input;
                if (pdfheight == "" || pdfheight == "null" || pdfheight == null)
                    prm65ct.Value = System.DBNull.Value;
                else
                    prm65ct.Value = pdfheight;
                objOraclecommand.Parameters.Add(prm65ct);

                OracleParameter prm65cb = new OracleParameter("CPNAMT", OracleType.VarChar);
                prm65cb.Direction = ParameterDirection.Input;
                if (cpnamt == "" || cpnamt == "null" || cpnamt == null)
                    prm65cb.Value = System.DBNull.Value;
                else
                    prm65cb.Value = cpnamt;
                objOraclecommand.Parameters.Add(prm65cb);

                OracleParameter prm161z1 = new OracleParameter("clientcatamt", OracleType.Number);
                prm161z1.Direction = ParameterDirection.Input;
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    prm161z1.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z1.Value = clientcatamt;
                }
                objOraclecommand.Parameters.Add(prm161z1);



                OracleParameter prm161z4 = new OracleParameter("flatfreqamt", OracleType.Number);
                prm161z4.Direction = ParameterDirection.Input;
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    prm161z4.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z4.Value = flatfreqamt;
                }
                objOraclecommand.Parameters.Add(prm161z4);


                OracleParameter prm161z7 = new OracleParameter("catamt", OracleType.Number);
                prm161z7.Direction = ParameterDirection.Input;
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    prm161z7.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z7.Value = catamt;
                }
                objOraclecommand.Parameters.Add(prm161z7);

                OracleParameter prm161z71 = new OracleParameter("extrarate", OracleType.Number);
                prm161z71.Direction = ParameterDirection.Input;

                prm161z71.Value = System.DBNull.Value;

                objOraclecommand.Parameters.Add(prm161z71);

                OracleParameter prm161z711 = new OracleParameter("premamtval", OracleType.Number);
                prm161z711.Direction = ParameterDirection.Input;
                if (premamtval == "" || premamtval == "0" || premamtval == "null")
                {
                    prm161z711.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z711.Value = premamtval;
                }
                objOraclecommand.Parameters.Add(prm161z711);

                OracleParameter prmt = new OracleParameter("pgstamt", OracleType.Number);
                prmt.Direction = ParameterDirection.Input;
                if (gstamount == "" || gstamount == "0" || gstamount == "null")
                {
                    prmt.Value = System.DBNull.Value;
                }
                else
                {
                    prmt.Value = gstamount;
                }
                objOraclecommand.Parameters.Add(prmt);

                OracleParameter prmd = new OracleParameter("pgstgd", OracleType.VarChar);
                prmd.Direction = ParameterDirection.Input;
                if (gstgrid == "" || gstgrid == "0" || gstgrid == "null")
                {
                    prmd.Value = System.DBNull.Value;
                }
                else
                {
                    prmd.Value = gstgrid;
                }
                objOraclecommand.Parameters.Add(prmd);


                objOraclecommand.Parameters.Add("p_error", OracleType.VarChar, 200);
                objOraclecommand.Parameters["p_error"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                //  objOraclecommand.ExecuteNonQuery();
                output = objOraclecommand.Parameters["p_error"].Value.ToString();



            }
            catch (Exception ex)
            {
                //output = ex.Message;
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
            return output;
        }
        public DataSet insertbook_ins_display(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string insertid, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string subedidata, string disc_, string modifyrateaudit, string ip, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clientcatamt, string flatfreqamt, string catamt, string premamtval, string gstamount, string gstgrid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertintobookchild_display.insertintobookchild_display_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("insertdate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;

                if (insertdate == "" || insertdate == null)
                {
                    prm2.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = insertdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        insertdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = insertdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            insertdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm2.Value = Convert.ToDateTime(insertdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("edition", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);






                OracleParameter prm4 = new OracleParameter("premium1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = premium1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("premium2", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = premium2;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("premallow", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premallow;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcategory;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("latestdate", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;


                if (latestdate == "" || latestdate == null)
                {
                    prm8.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = latestdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        latestdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = latestdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            latestdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm8.Value = Convert.ToDateTime(latestdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("material", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = material;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("cardrate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;


                if (cardrate == "" || cardrate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = Convert.ToDecimal(cardrate);
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("matfilename", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = matfilename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("discrate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;


                if (discrate == "" || discrate == null || discrate == "null")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = Convert.ToDecimal(discrate);
                }
                objOraclecommand.Parameters.Add(prm12);
                /*==========================================================================================*/

                OracleParameter prm13 = new OracleParameter("insertstatus", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = insertstatus;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("billstatus", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = billstatus;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("adsubcat1", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = adsubcat;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm16 = new OracleParameter("userid", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("cioid", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = cioid;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("height", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;


                if (height == "" || height == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = Convert.ToDecimal(height);
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("width", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (width == "" || width == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = Convert.ToDecimal(width);
                }
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("totalsize", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                if (totalsize == "" || totalsize == null)
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    prm20.Value = Convert.ToDecimal(totalsize);
                }
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("pagepost", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = pagepost;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("premper1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    prm22.Value = Convert.ToDecimal(premper1);
                }
                objOraclecommand.Parameters.Add(prm22);




                OracleParameter prm23 = new OracleParameter("premper2", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (premper2 == "" || premper2 == null || premper2 == "null")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDecimal(premper2);
                }
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("colid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = colid;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("repeat", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (repeat == "" || repeat == null)
                {
                    prm25.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = repeat.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        repeat = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = repeat.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            repeat = mm + "/" + dd + "/" + yy;
                    //        }
                    prm25.Value = Convert.ToDateTime(repeat).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("insertno", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (insertno == "" || insertno == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToInt32(insertno);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("paid", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = paid;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("agrrate", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDecimal(agrrate);
                }

                objOraclecommand.Parameters.Add(prm28);






                OracleParameter prm29 = new OracleParameter("solorate", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = Convert.ToDecimal(solorate);
                }

                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("grossrate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (grossrate == "" || grossrate == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = Convert.ToDecimal(grossrate);
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("insert_pageno", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    prm31.Value = Convert.ToInt32("0");
                }
                else
                {
                    prm31.Value = Convert.ToInt32(insert_pageno);
                }
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("insert_remarks", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = insert_remarks;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm34 = new OracleParameter("page_code", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = page_code;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm33 = new OracleParameter("page_per", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToDecimal(page_per);
                }
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm35 = new OracleParameter("noofcol", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                if (noofcol == "" || noofcol == null)
                {
                    prm35.Value = System.DBNull.Value;
                }
                else
                {
                    prm35.Value = Convert.ToDecimal(noofcol);
                }
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("billamt", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                if (billamt == "" || billamt == null)
                {
                    prm36.Value = System.DBNull.Value;
                }
                else
                {
                    prm36.Value = Convert.ToDecimal(billamt);
                }
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("billrate", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                if (billrate == "" || billrate == null)
                {
                    prm37.Value = System.DBNull.Value;
                }
                else
                {
                    prm37.Value = Convert.ToDecimal(billrate);
                }
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm40 = new OracleParameter("logo_h", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = logo_h;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm38 = new OracleParameter("logo_w", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = logo_w;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("logo_name", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = logo_name;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm43 = new OracleParameter("ad_cat_3", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = adcat3;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm41 = new OracleParameter("ad_cat_4", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = adcat4;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("ad_cat_5", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = adcat5;
                objOraclecommand.Parameters.Add(prm42);
                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                OracleParameter prm44 = new OracleParameter("pkgcode", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("gridins", OracleType.Number);
                prm45.Direction = ParameterDirection.Input;
                if (gridins == "")
                {
                    gridins = "1";
                }
                prm45.Value = gridins;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("pkgalias", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = pkgalias;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("insertid1", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                if (insertid == "")
                    insertid = "0";
                prm47.Value = insertid;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm51 = new OracleParameter("cirvts", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                if (cirvts == "null" || cirvts == null)
                    prm51.Value = System.DBNull.Value;
                else
                    prm51.Value = cirvts;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm48 = new OracleParameter("cirpub", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                if (cirpub == "null" || cirpub == null)
                    prm48.Value = System.DBNull.Value;
                else
                    prm48.Value = cirpub;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm49 = new OracleParameter("ciredi", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                if (cirpub == "null" || cirpub == null)
                    prm49.Value = System.DBNull.Value;
                else
                    prm49.Value = ciredi;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("cirrate", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                if (cirrate == "null" && cirrate == null)
                    prm50.Value = System.DBNull.Value;
                else
                    prm50.Value = cirrate;
                objOraclecommand.Parameters.Add(prm50);


                OracleParameter prm59 = new OracleParameter("cirdate_v", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                if (cirdate == "" || cirdate == null)
                {
                    prm59.Value = System.DBNull.Value;
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
                    prm59.Value = Convert.ToDateTime(cirdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm52 = new OracleParameter("ciragency_v", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = ciragency;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("ciragencysubcode_v", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = ciragencysubcode;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("center_v", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = center;
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("branch_v", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = branch;
                objOraclecommand.Parameters.Add(prm55);


                OracleParameter prm60 = new OracleParameter("boxcharge_p", OracleType.Float);
                prm60.Direction = ParameterDirection.Input;
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null || boxcharge == "0")
                    prm60.Value = System.DBNull.Value;
                else
                    prm60.Value = Convert.ToDecimal(boxcharge);
                objOraclecommand.Parameters.Add(prm60);

                OracleParameter prm61 = new OracleParameter("vat_inc_p", OracleType.Float);
                prm61.Direction = ParameterDirection.Input;
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null || vat_inc_p == "undefined")
                    prm61.Value = System.DBNull.Value;
                else
                    prm61.Value = vat_inc_p;
                objOraclecommand.Parameters.Add(prm61);
                //OracleParameter prm58 = new OracleParameter("splboldsizevalue", OracleType.VarChar);
                //prm58.Direction = ParameterDirection.Input;
                //prm58.Value = System.DBNull.Value;
                //objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59a = new OracleParameter("vatrate_p", OracleType.Float);
                prm59a.Direction = ParameterDirection.Input;
                if (vatrate == "" || vatrate == "null" || vatrate == null || vatrate == "undefined")
                    prm59a.Value = System.DBNull.Value;
                else
                    prm59a.Value = Convert.ToDecimal(vatrate);
                objOraclecommand.Parameters.Add(prm59a);

                OracleParameter prm61a = new OracleParameter("grossamtlocal_p", OracleType.VarChar);
                prm61a.Direction = ParameterDirection.Input;
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    prm61a.Value = System.DBNull.Value;
                else
                    prm61a.Value = grossamtlocal_p;
                objOraclecommand.Parameters.Add(prm61a);

                OracleParameter prm61b = new OracleParameter("billamtlocal_p", OracleType.VarChar);
                prm61b.Direction = ParameterDirection.Input;
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    prm61b.Value = System.DBNull.Value;
                else
                    prm61b.Value = billamtlocal_p;
                objOraclecommand.Parameters.Add(prm61b);

                OracleParameter prm61b1 = new OracleParameter("sectioncode_p", OracleType.VarChar);
                prm61b1.Direction = ParameterDirection.Input;
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    prm61b1.Value = System.DBNull.Value;
                else
                    prm61b1.Value = sectioncode_p;
                objOraclecommand.Parameters.Add(prm61b1);


                OracleParameter prm61b11 = new OracleParameter("resourceno_p", OracleType.VarChar);
                prm61b11.Direction = ParameterDirection.Input;
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    prm61b11.Value = System.DBNull.Value;
                else
                    prm61b11.Value = resourceno_p;
                objOraclecommand.Parameters.Add(prm61b11);

                OracleParameter prm61b112 = new OracleParameter("caption_inserts_p", OracleType.VarChar);
                prm61b112.Direction = ParameterDirection.Input;
                if (caption_inserts == "" || caption_inserts == "null" || caption_inserts == null || caption_inserts == "0")
                    prm61b112.Value = System.DBNull.Value;
                else
                    prm61b112.Value = caption_inserts;
                objOraclecommand.Parameters.Add(prm61b112);

                OracleParameter prm61b13 = new OracleParameter("dealerheight", OracleType.VarChar);
                prm61b13.Direction = ParameterDirection.Input;
                if (dealerheight == "" || dealerheight == "null" || dealerheight == null || dealerheight == "0")
                    prm61b13.Value = System.DBNull.Value;
                else
                    prm61b13.Value = dealerheight;
                objOraclecommand.Parameters.Add(prm61b13);

                OracleParameter prm61b14 = new OracleParameter("dealerwidth", OracleType.VarChar);
                prm61b14.Direction = ParameterDirection.Input;
                if (dealerwidth == "" || dealerwidth == "null" || dealerwidth == null || dealerwidth == "0")
                    prm61b14.Value = System.DBNull.Value;
                else
                    prm61b14.Value = dealerwidth;
                objOraclecommand.Parameters.Add(prm61b14);

                OracleParameter prm63 = new OracleParameter("subedidata", OracleType.VarChar);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = subedidata;
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm61bx = new OracleParameter("disc_p", OracleType.VarChar);
                prm61bx.Direction = ParameterDirection.Input;
                if (disc_ == "" || disc_ == "null" || disc_ == null || disc_ == "0")
                    prm61bx.Value = System.DBNull.Value;
                else
                    prm61bx.Value = disc_;
                objOraclecommand.Parameters.Add(prm61bx);

                OracleParameter prm151b = new OracleParameter("P_ip", OracleType.VarChar);
                prm151b.Direction = ParameterDirection.Input;
                prm151b.Value = ip;
                objOraclecommand.Parameters.Add(prm151b);

                OracleParameter prm161b = new OracleParameter("P_RATE_AUDIT_FLAG", OracleType.VarChar);
                prm161b.Direction = ParameterDirection.Input;
                prm161b.Value = modifyrateaudit;
                objOraclecommand.Parameters.Add(prm161b);


                OracleParameter prm62bx = new OracleParameter("agnamnt", OracleType.VarChar);
                prm62bx.Direction = ParameterDirection.Input;
                if (agncyamnt == "" || agncyamnt == "null" || agncyamnt == null || agncyamnt == "0")
                    prm62bx.Value = System.DBNull.Value;
                else
                    prm62bx.Value = agncyamnt;
                objOraclecommand.Parameters.Add(prm62bx);

                OracleParameter prm63bx = new OracleParameter("adlgncyamnt", OracleType.VarChar);
                prm63bx.Direction = ParameterDirection.Input;
                if (adlgncyamnt == "" || adlgncyamnt == "null" || adlgncyamnt == null || adlgncyamnt == "0")
                    prm63bx.Value = System.DBNull.Value;
                else
                    prm63bx.Value = adlgncyamnt;
                objOraclecommand.Parameters.Add(prm63bx);

                OracleParameter prm64bx = new OracleParameter("spldiscamt", OracleType.VarChar);
                prm64bx.Direction = ParameterDirection.Input;
                if (spldisc == "" || spldisc == "null" || spldisc == null || spldisc == "0")
                    prm64bx.Value = System.DBNull.Value;
                else
                    prm64bx.Value = spldisc;
                objOraclecommand.Parameters.Add(prm64bx);


                OracleParameter prm65bx = new OracleParameter("cashdamnt", OracleType.VarChar);
                prm65bx.Direction = ParameterDirection.Input;
                if (cashdisc == "" || cashdisc == "null" || cashdisc == null || cashdisc == "0")
                    prm65bx.Value = System.DBNull.Value;
                else
                    prm65bx.Value = cashdisc;
                objOraclecommand.Parameters.Add(prm65bx);

                OracleParameter prm65bt = new OracleParameter("ROUNDOFF", OracleType.VarChar);
                prm65bt.Direction = ParameterDirection.Input;
                if (roundoffamt == "" || roundoffamt == "null" || roundoffamt == null || roundoffamt == "0")
                    prm65bt.Value = System.DBNull.Value;
                else
                    prm65bt.Value = roundoffamt;
                objOraclecommand.Parameters.Add(prm65bt);

                OracleParameter prm65ct = new OracleParameter("PDFHEIGHT", OracleType.VarChar);
                prm65ct.Direction = ParameterDirection.Input;
                if (pdfheight == "" || pdfheight == "null" || pdfheight == null || pdfheight == "0")
                    prm65ct.Value = System.DBNull.Value;
                else
                    prm65ct.Value = pdfheight;
                objOraclecommand.Parameters.Add(prm65ct);

                OracleParameter prm65cb = new OracleParameter("CPNAMT", OracleType.VarChar);
                prm65cb.Direction = ParameterDirection.Input;
                if (cpnamt == "" || cpnamt == "null" || cpnamt == null || cpnamt == "0")
                    prm65cb.Value = System.DBNull.Value;
                else
                    prm65cb.Value = cpnamt;
                objOraclecommand.Parameters.Add(prm65cb);

                OracleParameter prm161z1 = new OracleParameter("clientcatamt", OracleType.Number);
                prm161z1.Direction = ParameterDirection.Input;
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    prm161z1.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z1.Value = clientcatamt;
                }
                objOraclecommand.Parameters.Add(prm161z1);



                OracleParameter prm161z4 = new OracleParameter("flatfreqamt", OracleType.Number);
                prm161z4.Direction = ParameterDirection.Input;
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    prm161z4.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z4.Value = flatfreqamt;
                }
                objOraclecommand.Parameters.Add(prm161z4);


                OracleParameter prm161z7 = new OracleParameter("catamt", OracleType.Number);
                prm161z7.Direction = ParameterDirection.Input;
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    prm161z7.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z7.Value = catamt;
                }
                objOraclecommand.Parameters.Add(prm161z7);

                OracleParameter prm161z711 = new OracleParameter("premamtval", OracleType.Number);
                prm161z711.Direction = ParameterDirection.Input;
                if (premamtval == "" || premamtval == "0" || premamtval == "null")
                {
                    prm161z711.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z711.Value = premamtval;
                }
                objOraclecommand.Parameters.Add(prm161z711);

                OracleParameter prmt = new OracleParameter("pgstamt", OracleType.Number);
                prmt.Direction = ParameterDirection.Input;
                if (gstamount == "" || gstamount == "0" || gstamount == "null")
                {
                    prmt.Value = System.DBNull.Value;
                }
                else
                {
                    prmt.Value = gstamount;
                }
                objOraclecommand.Parameters.Add(prmt);

                OracleParameter prmd = new OracleParameter("pgstgd", OracleType.VarChar);
                prmd.Direction = ParameterDirection.Input;
                if (gstgrid == "" || gstgrid == "0" || gstgrid == "null")
                {
                    prmd.Value = System.DBNull.Value;
                }
                else
                {
                    prmd.Value = gstgrid;
                }
                objOraclecommand.Parameters.Add(prmd);

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
        public DataSet insertbook_ins_update(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string insertid, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string insert_caption, string subedidata, string disc_, string modifyrateaudit, string ip, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clientcatamt, string flatfreqamt, string catamt, string premamtval, string gstamount, string gstgrid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertintobookchild_update.insertintobookchild_update_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("insertdate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;

                if (insertdate == "" || insertdate == null)
                {
                    prm2.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = insertdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        insertdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = insertdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            insertdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm2.Value = Convert.ToDateTime(insertdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("edition", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);






                OracleParameter prm4 = new OracleParameter("premium1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = premium1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("premium2", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = premium2;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("premallow", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premallow;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcategory;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("latestdate", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;


                if (latestdate == "" || latestdate == null)
                {
                    prm8.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = latestdate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        latestdate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = latestdate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            latestdate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm8.Value = Convert.ToDateTime(latestdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("material", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = material;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("cardrate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;


                if (cardrate == "" || cardrate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = Convert.ToDecimal(cardrate);
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("matfilename", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = matfilename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("discrate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;


                if (discrate == "" || discrate == null || discrate == "null")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = Convert.ToDecimal(discrate);
                }
                objOraclecommand.Parameters.Add(prm12);
                /*==========================================================================================*/

                OracleParameter prm13 = new OracleParameter("insertstatus", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = insertstatus;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("billstatus", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = billstatus;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("adsubcat1", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = adsubcat;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm16 = new OracleParameter("userid", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("cioid", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = cioid;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("height", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;


                if (height == "" || height == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = Convert.ToDecimal(height);
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("width", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (width == "" || width == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = Convert.ToDecimal(width);
                }
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("totalsize", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                if (totalsize == "" || totalsize == null)
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    prm20.Value = Convert.ToDecimal(totalsize);
                }
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("pagepost", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = pagepost;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("premper1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    prm22.Value = Convert.ToDecimal(premper1);
                }
                objOraclecommand.Parameters.Add(prm22);




                OracleParameter prm23 = new OracleParameter("premper2", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (premper2 == "" || premper2 == null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDecimal(premper2);
                }
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("colid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = colid;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("repeat", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (repeat == "" || repeat == null)
                {
                    prm25.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = repeat.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        repeat = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = repeat.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            repeat = mm + "/" + dd + "/" + yy;
                    //        }
                    prm25.Value = Convert.ToDateTime(repeat).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("insertno", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (insertno == "" || insertno == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToInt32(insertno);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("paid", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = paid;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("agrrate", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDecimal(agrrate);
                }

                objOraclecommand.Parameters.Add(prm28);






                OracleParameter prm29 = new OracleParameter("solorate", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = Convert.ToDecimal(solorate);
                }

                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("grossrate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (grossrate == "" || grossrate == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = Convert.ToDecimal(grossrate);
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("insert_pageno", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    prm31.Value = Convert.ToInt32("0");
                }
                else
                {
                    prm31.Value = Convert.ToInt32(insert_pageno);
                }
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("insert_remarks", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = insert_remarks;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm34 = new OracleParameter("page_code", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = page_code;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm33 = new OracleParameter("page_per", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToDecimal(page_per);
                }
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm35 = new OracleParameter("noofcol", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                if (noofcol == "" || noofcol == null)
                {
                    prm35.Value = System.DBNull.Value;
                }
                else
                {
                    prm35.Value = Convert.ToDecimal(noofcol);
                }
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("billamt", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                if (billamt == "" || billamt == null)
                {
                    prm36.Value = System.DBNull.Value;
                }
                else
                {
                    prm36.Value = Convert.ToDecimal(billamt);
                }
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("billrate", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                if (billrate == "" || billrate == null)
                {
                    prm37.Value = System.DBNull.Value;
                }
                else
                {
                    prm37.Value = Convert.ToDecimal(billrate);
                }
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm40 = new OracleParameter("logo_h", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = logo_h;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm38 = new OracleParameter("logo_w", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = logo_w;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("logo_name", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = logo_name;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm43 = new OracleParameter("ad_cat_3", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = adcat3;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm41 = new OracleParameter("ad_cat_4", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = adcat4;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("ad_cat_5", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = adcat5;
                objOraclecommand.Parameters.Add(prm42);
                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                OracleParameter prm44 = new OracleParameter("pkgcode", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("gridins", OracleType.Number);
                prm45.Direction = ParameterDirection.Input;
                if (gridins == "")
                {
                    gridins = "1";
                }
                prm45.Value = gridins;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("pkgalias", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = pkgalias;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("insertid1", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = insertid;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm51 = new OracleParameter("cirvts", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                if (cirvts == "null" || cirvts == null)
                    prm51.Value = System.DBNull.Value;
                else
                    prm51.Value = cirvts;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm48 = new OracleParameter("cirpub", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                if (cirpub == "null" || cirpub == null)
                    prm48.Value = System.DBNull.Value;
                else
                    prm48.Value = cirpub;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm49 = new OracleParameter("ciredi", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                if (cirpub == "null" || cirpub == null)
                    prm49.Value = System.DBNull.Value;
                else
                    prm49.Value = ciredi;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("cirrate", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                if (cirrate == "null" && cirrate == null)
                    prm50.Value = System.DBNull.Value;
                else
                    prm50.Value = cirrate;
                objOraclecommand.Parameters.Add(prm50);


                OracleParameter prm59 = new OracleParameter("cirdate_v", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                if (cirdate == "" || cirdate == null)
                {
                    prm59.Value = System.DBNull.Value;
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
                    prm59.Value = Convert.ToDateTime(cirdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm52 = new OracleParameter("ciragency_v", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = ciragency;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("ciragencysubcode_v", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = ciragencysubcode;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("center_v", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = center;
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("branch_v", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = branch;
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm58 = new OracleParameter("splboldsizevalue", OracleType.VarChar);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = splboldsizevalue;
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59a = new OracleParameter("vatrate_p", OracleType.Float);
                prm59a.Direction = ParameterDirection.Input;
                if (vatrate == "" || vatrate == "null" || vatrate == null || vatrate == "undefined")
                    prm59a.Value = System.DBNull.Value;
                else
                    prm59a.Value = Convert.ToDecimal(vatrate);
                objOraclecommand.Parameters.Add(prm59a);

                OracleParameter prm60 = new OracleParameter("boxcharge_p", OracleType.Float);
                prm60.Direction = ParameterDirection.Input;
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null)
                    prm60.Value = System.DBNull.Value;
                else
                    prm60.Value = Convert.ToDecimal(boxcharge);
                objOraclecommand.Parameters.Add(prm60);

                OracleParameter prm61 = new OracleParameter("vat_inc_p", OracleType.Float);
                prm61.Direction = ParameterDirection.Input;
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null || vat_inc_p == "undefined")
                    prm61.Value = System.DBNull.Value;
                else
                    prm61.Value = vat_inc_p;
                objOraclecommand.Parameters.Add(prm61);


                OracleParameter prm61a = new OracleParameter("grossamtlocal_p", OracleType.VarChar);
                prm61a.Direction = ParameterDirection.Input;
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    prm61a.Value = System.DBNull.Value;
                else
                    prm61a.Value = grossamtlocal_p;
                objOraclecommand.Parameters.Add(prm61a);


                OracleParameter prm61b = new OracleParameter("billamtlocal_p", OracleType.VarChar);
                prm61b.Direction = ParameterDirection.Input;
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    prm61b.Value = System.DBNull.Value;
                else
                    prm61b.Value = billamtlocal_p;
                objOraclecommand.Parameters.Add(prm61b);

                OracleParameter prm61b1 = new OracleParameter("sectioncode_p", OracleType.VarChar);
                prm61b1.Direction = ParameterDirection.Input;
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    prm61b1.Value = System.DBNull.Value;
                else
                    prm61b1.Value = sectioncode_p;
                objOraclecommand.Parameters.Add(prm61b1);

                OracleParameter prm61b11 = new OracleParameter("resourceno_p", OracleType.VarChar);
                prm61b11.Direction = ParameterDirection.Input;
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    prm61b11.Value = System.DBNull.Value;
                else
                    prm61b11.Value = resourceno_p;
                objOraclecommand.Parameters.Add(prm61b11);

                OracleParameter prm61b112 = new OracleParameter("caption_inserts_p", OracleType.VarChar);
                prm61b112.Direction = ParameterDirection.Input;
                if (insert_caption == "" || insert_caption == "null" || insert_caption == null)
                    prm61b112.Value = System.DBNull.Value;
                else
                    prm61b112.Value = insert_caption;
                objOraclecommand.Parameters.Add(prm61b112);

                OracleParameter prm63 = new OracleParameter("subedidata", OracleType.VarChar);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = subedidata;
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm61bx = new OracleParameter("disc_p", OracleType.VarChar);
                prm61bx.Direction = ParameterDirection.Input;
                if (disc_ == "" || disc_ == "null" || disc_ == null)
                    prm61bx.Value = System.DBNull.Value;
                else
                    prm61bx.Value = disc_;
                objOraclecommand.Parameters.Add(prm61bx);

                OracleParameter prm151b = new OracleParameter("P_ip", OracleType.VarChar);
                prm151b.Direction = ParameterDirection.Input;
                prm151b.Value = ip;
                objOraclecommand.Parameters.Add(prm151b);


                OracleParameter prm62bx = new OracleParameter("agncyamnt", OracleType.VarChar);
                prm62bx.Direction = ParameterDirection.Input;
                if (agncyamnt == "" || agncyamnt == "null" || agncyamnt == null)
                    prm62bx.Value = System.DBNull.Value;
                else
                    prm62bx.Value = agncyamnt;
                objOraclecommand.Parameters.Add(prm62bx);

                OracleParameter prm63bx = new OracleParameter("adlgncyamnt", OracleType.VarChar);
                prm63bx.Direction = ParameterDirection.Input;
                if (adlgncyamnt == "" || adlgncyamnt == "null" || adlgncyamnt == null)
                    prm63bx.Value = System.DBNull.Value;
                else
                    prm63bx.Value = adlgncyamnt;
                objOraclecommand.Parameters.Add(prm63bx);

                OracleParameter prm64bx = new OracleParameter("spldiscamt", OracleType.VarChar);
                prm64bx.Direction = ParameterDirection.Input;
                if (spldisc == "" || spldisc == "null" || spldisc == null)
                    prm64bx.Value = System.DBNull.Value;
                else
                    prm64bx.Value = spldisc;
                objOraclecommand.Parameters.Add(prm64bx);


                OracleParameter prm65bx = new OracleParameter("cashdamnt", OracleType.VarChar);
                prm65bx.Direction = ParameterDirection.Input;
                if (cashdisc == "" || cashdisc == "null" || cashdisc == null)
                    prm65bx.Value = System.DBNull.Value;
                else
                    prm65bx.Value = cashdisc;
                objOraclecommand.Parameters.Add(prm65bx);


                OracleParameter prm161b = new OracleParameter("P_RATE_AUDIT_FLAG", OracleType.VarChar);
                prm161b.Direction = ParameterDirection.Input;
                prm161b.Value = modifyrateaudit;
                objOraclecommand.Parameters.Add(prm161b);

                OracleParameter prm65bt = new OracleParameter("ROUNDOFF", OracleType.VarChar);
                prm65bt.Direction = ParameterDirection.Input;
                if (roundoffamt == "" || roundoffamt == "null" || roundoffamt == null)
                    prm65bt.Value = System.DBNull.Value;
                else
                    prm65bt.Value = roundoffamt;
                objOraclecommand.Parameters.Add(prm65bt);

                OracleParameter prm65ct = new OracleParameter("PDFHEIGHT", OracleType.VarChar);
                prm65ct.Direction = ParameterDirection.Input;
                if (pdfheight == "" || pdfheight == "null" || pdfheight == null)
                    prm65ct.Value = System.DBNull.Value;
                else
                    prm65ct.Value = pdfheight;
                objOraclecommand.Parameters.Add(prm65ct);

                OracleParameter prm65cb = new OracleParameter("CPNAMT", OracleType.VarChar);
                prm65cb.Direction = ParameterDirection.Input;
                if (cpnamt == "" || cpnamt == "null" || cpnamt == null)
                    prm65cb.Value = System.DBNull.Value;
                else
                    prm65cb.Value = cpnamt;
                objOraclecommand.Parameters.Add(prm65cb);

                OracleParameter prm161z1 = new OracleParameter("clientcatamt", OracleType.Number);
                prm161z1.Direction = ParameterDirection.Input;
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    prm161z1.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z1.Value = clientcatamt;
                }
                objOraclecommand.Parameters.Add(prm161z1);



                OracleParameter prm161z4 = new OracleParameter("flatfreqamt", OracleType.Number);
                prm161z4.Direction = ParameterDirection.Input;
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    prm161z4.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z4.Value = flatfreqamt;
                }
                objOraclecommand.Parameters.Add(prm161z4);


                OracleParameter prm161z7 = new OracleParameter("catamt", OracleType.Number);
                prm161z7.Direction = ParameterDirection.Input;
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    prm161z7.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z7.Value = catamt;
                }
                objOraclecommand.Parameters.Add(prm161z7);


                OracleParameter prm161z71 = new OracleParameter("extrarate", OracleType.Number);
                prm161z71.Direction = ParameterDirection.Input;

                prm161z71.Value = System.DBNull.Value;

                objOraclecommand.Parameters.Add(prm161z71);

                OracleParameter prm161z711 = new OracleParameter("premamtval", OracleType.Number);
                prm161z711.Direction = ParameterDirection.Input;
                if (premamtval == "" || premamtval == "0" || premamtval == "null")
                {
                    prm161z711.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z711.Value = premamtval;
                }
                objOraclecommand.Parameters.Add(prm161z711);

                OracleParameter prmt = new OracleParameter("pgstamt", OracleType.Number);
                prmt.Direction = ParameterDirection.Input;
                if (gstamount == "" || gstamount == "0" || gstamount == "null")
                {
                    prmt.Value = System.DBNull.Value;
                }
                else
                {
                    prmt.Value = gstamount;
                }
                objOraclecommand.Parameters.Add(prmt);

                OracleParameter prmd = new OracleParameter("pgstgd", OracleType.VarChar);
                prmd.Direction = ParameterDirection.Input;
                if (gstgrid == "" || gstgrid == "0" || gstgrid == "null")
                {
                    prmd.Value = System.DBNull.Value;
                }
                else
                {
                    prmd.Value = gstgrid;
                }
                objOraclecommand.Parameters.Add(prmd);

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
        public DataSet alert1(string compcode, string agcode, string uom, string cat)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CHECKUOMCAT_QBC.UOM_CAT_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("comcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("category1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cat;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm31 = new OracleParameter("uom", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = uom;
                objOraclecommand.Parameters.Add(prm31);

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
        public DataSet bindbrand(string compcode, string BRAND, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BINDBRAND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("BRAND", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = BRAND;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("EXTRA1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("EXTRA2", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra2;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("EXTRA3", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra3;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("EXTRA4", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra4;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("EXTRA5", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra5;
                objOraclecommand.Parameters.Add(prm7);


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
        public DataSet bindbrandproduct(string compcode, string BRAND, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BINDBRANDPRODUCT", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("BRAND", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = BRAND;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("EXTRA1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("EXTRA2", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra2;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("EXTRA3", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra3;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("EXTRA4", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra4;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("EXTRA5", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra5;
                objOraclecommand.Parameters.Add(prm7);


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
        public DataSet ratebindcenterwise(string adcat, string compcode, string branch, string bookingdate, string dateformat, string uom)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindratecodecenterwise_disp", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("padcat", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcat;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm31 = new OracleParameter("pbranch", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = branch;
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (bookingdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = bookingdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        bookingdate = mm + "/" + dd + "/" + yy;


                    }

                    prm4.Value = Convert.ToDateTime(bookingdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm4);

                //OracleParameter prm31a = new OracleParameter("pextra1", OracleType.VarChar);
                //prm31a.Direction = ParameterDirection.Input;
                //prm31a.Value = System.DBNull.Value;
                //objOraclecommand.Parameters.Add(prm31a);

                OracleParameter prm31c = new OracleParameter("pextra2", OracleType.VarChar);
                prm31c.Direction = ParameterDirection.Input;
                if (uom == "0")
                    prm31c.Value = System.DBNull.Value;
                else
                    prm31c.Value = uom;
                objOraclecommand.Parameters.Add(prm31c);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;

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
        //anuja//////
        public string insertbooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string receiptdate, string prevcioid, string prevreceipt, Decimal prev_ga, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string attach1, string attach2, string cashdiscount, string cashdiscountper, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multiselect, string agreedrate_active, string agreedamt_active, string grossamtlocal_p, string billamtlocal_p, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string transdisc, string pospremdisc, string billhold, string online_ad, string pstyle, string fixed_booking, string vat_code, string cou_code, string cou_name, string state, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype, string representative, string teamcode, string industry, string productcat, string chkgstinc, string publ_rev_cent, string contractperson, string emailid, string quotationno)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();

            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                // IDbTransaction trans = objOracleConnection.BeginTransaction(); // Turn off AUTOCOMMIT
                objOraclecommand = GetCommand("insertintobooking.insertintobooking_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("date_time", OracleType.DateTime);
                prm1.Direction = ParameterDirection.Input;
                if (date_time == "" || date_time == null)
                {
                    prm1.Value = System.DBNull.Value;

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
                    prm1.Value = Convert.ToDateTime(date_time).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adsizetype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adsizetype;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("branch", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branch;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("booked_by", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = booked_by;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("prevbook", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = prevbook;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("approvedby", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = approvedby;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ciobookid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("audit1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = audit;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("rono", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = rono;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("rodate", OracleType.DateTime);
                prm10.Direction = ParameterDirection.Input;

                if (rodate == "" || rodate == null)
                {
                    prm10.Value = System.DBNull.Value;
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
                    prm10.Value = Convert.ToDateTime(rodate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm10);




                OracleParameter prm11 = new OracleParameter("caption", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = caption;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("billstatus", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = billstatus;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("rostatus", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = rostatus;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("agency", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = agency;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("client", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = client;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("agencyaddress", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = agencyaddress;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("clientaddresses", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = clientaddresses;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("agencycode", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = agencycode;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("dockitno", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = dockitno;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("execname", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = execname;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("execzone", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = execzone;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("product", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = product;
                objOraclecommand.Parameters.Add(prm22);



                OracleParameter prm23 = new OracleParameter("brand", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = brand;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("keyno", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = keyno;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("billremark", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = billremark;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("printremark", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = printremark;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("package1", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = package;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("insertion", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = insertion;
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("startdate", OracleType.DateTime);
                prm29.Direction = ParameterDirection.Input;

                if (startdate == "" || startdate == null)
                {
                    prm29.Value = System.DBNull.Value;
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
                    prm29.Value = Convert.ToDateTime(startdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("repeatdate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = repeatdate;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("adtype1", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = adtype;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("adcategory", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = adcategory;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("subcategory", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = subcategory;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("color", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = color;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("uom", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = uom;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("pageposition", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = pageposition;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("pagetype1", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = pagetype;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("pageno", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = pageno;
                objOraclecommand.Parameters.Add(prm38);



                OracleParameter prm39 = new OracleParameter("adsizheight", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                if (adsizheight == "" || adsizheight == null)
                {
                    prm39.Value = System.DBNull.Value;
                }
                else
                {
                    prm39.Value = Convert.ToDecimal(adsizheight);
                }
                objOraclecommand.Parameters.Add(prm39);


                OracleParameter prm40 = new OracleParameter("adsizwidth", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                if (adsizwidth == "" || adsizwidth == null)
                {
                    prm40.Value = System.DBNull.Value;
                }
                else
                {
                    prm40.Value = Convert.ToDecimal(adsizwidth);
                }
                objOraclecommand.Parameters.Add(prm40);


                OracleParameter prm41 = new OracleParameter("scheme1", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = scheme;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("currency", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = currency;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("ratecode11", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = ratecode;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("agreedrate", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                if (agreedrate == "" || agreedrate == null)
                {
                    prm44.Value = System.DBNull.Value;
                }
                else
                {
                    prm44.Value = Convert.ToDecimal(agreedrate);
                }
                objOraclecommand.Parameters.Add(prm44);


                OracleParameter prm45 = new OracleParameter("agreedamt", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                if (agreedamt == "" || agreedamt == null)
                {
                    prm45.Value = System.DBNull.Value;
                }
                else
                {
                    prm45.Value = Convert.ToDecimal(agreedamt);
                }
                objOraclecommand.Parameters.Add(prm45);


                OracleParameter prm46 = new OracleParameter("spedisc", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                if (spedisc == "" || spedisc == null)
                {
                    prm46.Value = System.DBNull.Value;
                }
                else
                {
                    prm46.Value = Convert.ToDecimal(spedisc);
                }
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("compcode", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = compcode;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm48 = new OracleParameter("spacedisx", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                if (spacedisx == "" || spacedisx == null)
                {
                    prm48.Value = System.DBNull.Value;
                }
                else
                {
                    prm48.Value = Convert.ToDecimal(spacedisx);
                }
                objOraclecommand.Parameters.Add(prm48);


                OracleParameter prm49 = new OracleParameter("specialcharges", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                if (specialcharges == "" || specialcharges == null)
                {
                    prm49.Value = System.DBNull.Value;
                }
                else
                {
                    prm49.Value = Convert.ToDecimal(specialcharges);
                }
                objOraclecommand.Parameters.Add(prm49);


                OracleParameter prm50 = new OracleParameter("userid", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = userid;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm51 = new OracleParameter("agencytype", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = agencytype;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm52 = new OracleParameter("agencystatus", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = agencystatus;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("paymode", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = paymode;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("agenccredit", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                if (agencredit == "" || agencredit == null)
                {
                    prm54.Value = System.DBNull.Value;
                }
                else
                {
                    prm54.Value = Convert.ToInt32(agencredit);
                }
                objOraclecommand.Parameters.Add(prm54);


                OracleParameter prm55 = new OracleParameter("cardrate", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                if (cardrate == "" || cardrate == null)
                {
                    prm55.Value = System.DBNull.Value;
                }
                else
                {
                    prm55.Value = Convert.ToDecimal(cardrate);
                }
                objOraclecommand.Parameters.Add(prm55);


                OracleParameter prm56 = new OracleParameter("cardamount", OracleType.VarChar);
                prm56.Direction = ParameterDirection.Input;
                if (cardamount == "" || cardamount == null)
                {
                    prm56.Value = System.DBNull.Value;
                }
                else
                {
                    prm56.Value = Convert.ToDecimal(cardamount);
                }
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("discount", OracleType.VarChar);
                prm57.Direction = ParameterDirection.Input;
                if (discount == "" || discount == null)
                {
                    prm57.Value = System.DBNull.Value;
                }
                else
                {
                    prm57.Value = Convert.ToDecimal(discount);
                }
                objOraclecommand.Parameters.Add(prm57);


                OracleParameter prm58 = new OracleParameter("discountper", OracleType.VarChar);
                prm58.Direction = ParameterDirection.Input;
                if (discountper == "" || discountper == null)
                {
                    prm58.Value = System.DBNull.Value;
                }
                else
                {
                    prm58.Value = Convert.ToDecimal(discountper);
                }
                objOraclecommand.Parameters.Add(prm58);


                OracleParameter prm59 = new OracleParameter("billaddress", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                prm59.Value = billaddress;
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("totarea", OracleType.VarChar);
                prm60.Direction = ParameterDirection.Input;
                if (totarea == "" || totarea == null)
                {
                    prm60.Value = System.DBNull.Value;
                }
                else
                {
                    prm60.Value = Convert.ToDecimal(totarea);
                }
                objOraclecommand.Parameters.Add(prm60);


                OracleParameter prm61 = new OracleParameter("billcycle", OracleType.VarChar);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = billcycle;
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm62 = new OracleParameter("billpay", OracleType.VarChar);
                prm62.Direction = ParameterDirection.Input;
                prm62.Value = billpay;
                objOraclecommand.Parameters.Add(prm62);

                OracleParameter prm63 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = revenuecenter;
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm64 = new OracleParameter("billheight", OracleType.VarChar);
                prm64.Direction = ParameterDirection.Input;
                if (billheight == "" || billheight == null)
                {
                    prm64.Value = System.DBNull.Value;
                }
                else
                {
                    prm64.Value = Convert.ToDecimal(billheight);
                }
                objOraclecommand.Parameters.Add(prm64);


                OracleParameter prm65 = new OracleParameter("billwidth", OracleType.VarChar);
                prm65.Direction = ParameterDirection.Input;
                if (billwidth == "" || billwidth == null)
                {
                    prm65.Value = System.DBNull.Value;
                }
                else
                {
                    prm65.Value = Convert.ToDecimal(billwidth);
                }
                objOraclecommand.Parameters.Add(prm65);


                OracleParameter prm66 = new OracleParameter("billto", OracleType.VarChar);
                prm66.Direction = ParameterDirection.Input;
                prm66.Value = billto;
                objOraclecommand.Parameters.Add(prm66);

                OracleParameter prm67 = new OracleParameter("invoices", OracleType.VarChar);
                prm67.Direction = ParameterDirection.Input;
                if (invoices == "" || invoices == null)
                {
                    prm67.Value = System.DBNull.Value;
                }
                else
                {
                    prm67.Value = Convert.ToDecimal(invoices);
                }
                objOraclecommand.Parameters.Add(prm67);


                OracleParameter prm68 = new OracleParameter("vts", OracleType.VarChar);
                prm68.Direction = ParameterDirection.Input;
                if (vts == "" || vts == null || vts == "null")
                {
                    prm68.Value = System.DBNull.Value;
                }
                else
                {
                    prm68.Value = Convert.ToDecimal(vts);
                }
                objOraclecommand.Parameters.Add(prm68);



                OracleParameter prm69 = new OracleParameter("tradedisc", OracleType.VarChar);
                prm69.Direction = ParameterDirection.Input;
                if (tradedisc == "" || tradedisc == null)
                {
                    prm69.Value = System.DBNull.Value;
                }

                else
                {
                    prm69.Value = Convert.ToDecimal(tradedisc);
                }
                objOraclecommand.Parameters.Add(prm69);

                OracleParameter prm70 = new OracleParameter("agencyout", OracleType.VarChar);
                prm70.Direction = ParameterDirection.Input;
                prm70.Value = agencyout;
                objOraclecommand.Parameters.Add(prm70);

                OracleParameter prm71 = new OracleParameter("boxcode", OracleType.VarChar);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = boxcode;
                objOraclecommand.Parameters.Add(prm71);

                OracleParameter prm72 = new OracleParameter("boxno", OracleType.VarChar);
                prm72.Direction = ParameterDirection.Input;
                prm72.Value = boxno;
                objOraclecommand.Parameters.Add(prm72);

                OracleParameter prm73 = new OracleParameter("boxagency", OracleType.VarChar);
                prm73.Direction = ParameterDirection.Input;
                prm73.Value = boxagency;
                objOraclecommand.Parameters.Add(prm73);

                OracleParameter prm74 = new OracleParameter("boxaddress", OracleType.VarChar);
                prm74.Direction = ParameterDirection.Input;
                prm74.Value = boxaddress;
                objOraclecommand.Parameters.Add(prm74);

                OracleParameter prm75 = new OracleParameter("boxclient", OracleType.VarChar);
                prm75.Direction = ParameterDirection.Input;
                prm75.Value = boxclient;
                objOraclecommand.Parameters.Add(prm75);

                OracleParameter prm76 = new OracleParameter("coupan", OracleType.VarChar);
                prm76.Direction = ParameterDirection.Input;
                prm76.Value = coupan;
                objOraclecommand.Parameters.Add(prm76);

                OracleParameter prm77 = new OracleParameter("bookingtype", OracleType.VarChar);
                prm77.Direction = ParameterDirection.Input;
                prm77.Value = bookingtype;
                objOraclecommand.Parameters.Add(prm77);

                OracleParameter prm78 = new OracleParameter("tfn", OracleType.VarChar);
                prm78.Direction = ParameterDirection.Input;
                prm78.Value = tfn;
                objOraclecommand.Parameters.Add(prm78);

                OracleParameter prm79 = new OracleParameter("campaign", OracleType.VarChar);
                prm79.Direction = ParameterDirection.Input;
                prm79.Value = campaign;
                objOraclecommand.Parameters.Add(prm79);


                OracleParameter prm80 = new OracleParameter("bill_amt", OracleType.VarChar);
                prm80.Direction = ParameterDirection.Input;
                if (bill_amt == "" || bill_amt == null)
                {
                    prm80.Value = System.DBNull.Value;
                }
                else
                {
                    prm80.Value = Convert.ToDecimal(bill_amt);
                }
                objOraclecommand.Parameters.Add(prm80);


                OracleParameter prm81 = new OracleParameter("pageprem", OracleType.VarChar);
                prm81.Direction = ParameterDirection.Input;
                prm81.Value = pageprem;
                objOraclecommand.Parameters.Add(prm81);

                OracleParameter prm82 = new OracleParameter("pageamt", OracleType.VarChar);
                prm82.Direction = ParameterDirection.Input;
                if (pageamt == "" || pageamt == null)
                {
                    prm82.Value = System.DBNull.Value;
                }
                else
                {
                    prm82.Value = Convert.ToDecimal(pageamt);
                }
                objOraclecommand.Parameters.Add(prm82);


                OracleParameter prm83 = new OracleParameter("premper", OracleType.VarChar);
                prm83.Direction = ParameterDirection.Input;
                if (premper == "" || premper == null)
                {
                    prm83.Value = System.DBNull.Value;
                }
                else
                {
                    prm83.Value = Convert.ToDecimal(premper);
                }
                objOraclecommand.Parameters.Add(prm83);


                OracleParameter prm84 = new OracleParameter("grossamt", OracleType.VarChar);
                prm84.Direction = ParameterDirection.Input;
                if (grossamt == "" || grossamt == null)
                {
                    prm84.Value = System.DBNull.Value;
                }
                else
                {
                    prm84.Value = Convert.ToDecimal(grossamt);
                }
                objOraclecommand.Parameters.Add(prm84);



                OracleParameter prm85 = new OracleParameter("adsizcolumn", OracleType.VarChar);
                prm85.Direction = ParameterDirection.Input;
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    prm85.Value = System.DBNull.Value;
                }
                else
                {
                    prm85.Value = Convert.ToDecimal(adsizcolumn);
                }
                objOraclecommand.Parameters.Add(prm85);

                OracleParameter prm86 = new OracleParameter("billcolumn", OracleType.VarChar);
                prm86.Direction = ParameterDirection.Input;
                if (billcolumn == "" || billcolumn == null)
                {
                    prm86.Value = System.DBNull.Value;
                }
                else
                {
                    prm86.Value = Convert.ToDecimal(billcolumn);
                }
                objOraclecommand.Parameters.Add(prm86);




                OracleParameter prm87 = new OracleParameter("specdiscper", OracleType.VarChar);
                prm87.Direction = ParameterDirection.Input;
                if (specdiscper == "" || specdiscper == null)
                {
                    prm87.Value = System.DBNull.Value;
                }
                else
                {
                    prm87.Value = Convert.ToDecimal(specdiscper);
                }
                objOraclecommand.Parameters.Add(prm87);


                OracleParameter prm88 = new OracleParameter("spacediscper", OracleType.VarChar);
                prm88.Direction = ParameterDirection.Input;
                if (spacediscper == "" || spacediscper == null)
                {
                    prm88.Value = System.DBNull.Value;
                }
                else
                {
                    prm88.Value = Convert.ToDecimal(spacediscper);
                }
                objOraclecommand.Parameters.Add(prm88);

                OracleParameter prm89 = new OracleParameter("billarea", OracleType.VarChar);
                prm89.Direction = ParameterDirection.Input;
                prm89.Value = Convert.ToDecimal(billarea);
                objOraclecommand.Parameters.Add(prm89);


                OracleParameter prm90 = new OracleParameter("paidins", OracleType.VarChar);
                prm90.Direction = ParameterDirection.Input;
                if (paidins == "" || paidins == null)
                {
                    prm90.Value = System.DBNull.Value;
                }
                else
                {
                    prm90.Value = Convert.ToDecimal(paidins);
                }
                objOraclecommand.Parameters.Add(prm90);

                OracleParameter prm91 = new OracleParameter("dealrate", OracleType.VarChar);
                prm91.Direction = ParameterDirection.Input;
                if (dealrate == "" || dealrate == null)
                {
                    prm91.Value = System.DBNull.Value;
                }
                else
                {
                    prm91.Value = Convert.ToDecimal(dealrate);
                }
                prm91.Value = dealrate;
                objOraclecommand.Parameters.Add(prm91);

                OracleParameter prm92 = new OracleParameter("deviation", OracleType.VarChar);
                prm92.Direction = ParameterDirection.Input;
                if (deviation == "" || deviation == null)
                {
                    prm92.Value = System.DBNull.Value;
                }
                else
                {
                    prm92.Value = Convert.ToDecimal(deviation);
                }
                objOraclecommand.Parameters.Add(prm92);

                OracleParameter prm93 = new OracleParameter("varient", OracleType.VarChar);
                prm93.Direction = ParameterDirection.Input;
                prm93.Value = varient;
                objOraclecommand.Parameters.Add(prm93);

                OracleParameter prm94 = new OracleParameter("contractname", OracleType.VarChar);
                prm94.Direction = ParameterDirection.Input;
                prm94.Value = contractname;
                objOraclecommand.Parameters.Add(prm94);

                OracleParameter prm95 = new OracleParameter("dealtype", OracleType.VarChar);
                prm95.Direction = ParameterDirection.Input;
                prm95.Value = dealtype;
                objOraclecommand.Parameters.Add(prm95);

                OracleParameter prm96 = new OracleParameter("cardname", OracleType.VarChar);
                prm96.Direction = ParameterDirection.Input;
                prm96.Value = cardname;
                objOraclecommand.Parameters.Add(prm96);

                OracleParameter prm97 = new OracleParameter("cardtype", OracleType.VarChar);
                prm97.Direction = ParameterDirection.Input;
                prm97.Value = cardtype;
                objOraclecommand.Parameters.Add(prm97);

                OracleParameter prm98 = new OracleParameter("cardmonth", OracleType.VarChar);
                prm98.Direction = ParameterDirection.Input;
                prm98.Value = cardmonth;
                objOraclecommand.Parameters.Add(prm98);

                OracleParameter prm99 = new OracleParameter("cardyear", OracleType.VarChar);
                prm99.Direction = ParameterDirection.Input;
                prm99.Value = cardyear;
                objOraclecommand.Parameters.Add(prm99);

                OracleParameter prm100 = new OracleParameter("cardno", OracleType.VarChar);
                prm100.Direction = ParameterDirection.Input;
                prm100.Value = cardno;
                objOraclecommand.Parameters.Add(prm100);



                OracleParameter prm101 = new OracleParameter("receiptno", OracleType.VarChar);
                prm101.Direction = ParameterDirection.Input;
                prm101.Value = receiptno;
                objOraclecommand.Parameters.Add(prm101);


                OracleParameter prm102 = new OracleParameter("adscat3", OracleType.VarChar);
                prm102.Direction = ParameterDirection.Input;
                prm102.Value = adscat3;
                objOraclecommand.Parameters.Add(prm102);


                OracleParameter prm103 = new OracleParameter("adscat4", OracleType.VarChar);
                prm103.Direction = ParameterDirection.Input;
                prm103.Value = adscat4;
                objOraclecommand.Parameters.Add(prm103);


                OracleParameter prm104 = new OracleParameter("adscat5", OracleType.VarChar);
                prm104.Direction = ParameterDirection.Input;
                prm104.Value = adscat5;
                objOraclecommand.Parameters.Add(prm104);


                OracleParameter prm105 = new OracleParameter("bgcolor", OracleType.VarChar);
                prm105.Direction = ParameterDirection.Input;
                prm105.Value = bgcolor;
                objOraclecommand.Parameters.Add(prm105);


                OracleParameter prm106 = new OracleParameter("bulletcode", OracleType.VarChar);
                prm106.Direction = ParameterDirection.Input;
                prm106.Value = bulletcode;
                objOraclecommand.Parameters.Add(prm106);


                OracleParameter prm107 = new OracleParameter("bulletprm", OracleType.Number);
                prm107.Direction = ParameterDirection.Input;
                if (bulletprm == "" || bulletprm == null)
                {
                    prm107.Value = System.DBNull.Value;
                }
                else
                {
                    bulletprm = bulletprm.Replace("%", "");
                    prm107.Value = Convert.ToDecimal(bulletprm);
                }
                objOraclecommand.Parameters.Add(prm107);


                OracleParameter prm108 = new OracleParameter("material", OracleType.VarChar);
                prm108.Direction = ParameterDirection.Input;
                prm108.Value = material;
                objOraclecommand.Parameters.Add(prm108);


                OracleParameter prm109 = new OracleParameter("receiptdate", OracleType.DateTime);
                prm109.Direction = ParameterDirection.Input;
                if (receiptdate == "" || receiptdate == null)
                {
                    //prm109.Value = System.DBNull.Value;
                    if (date_time == "" || date_time == null)
                    {
                        prm109.Value = System.DBNull.Value;
                    }
                    else
                    {
                        prm109.Value = Convert.ToDateTime(date_time).ToString("dd-MMMM-yyyy");
                    }
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        receiptdate = mm + "/" + dd + "/" + yy;


                    }
                    prm109.Value = Convert.ToDateTime(receiptdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm109);


                OracleParameter prm110 = new OracleParameter("prevcioid", OracleType.VarChar);
                prm110.Direction = ParameterDirection.Input;
                prm110.Value = prevcioid;
                objOraclecommand.Parameters.Add(prm110);


                OracleParameter prm111 = new OracleParameter("prevreceipt", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = prevreceipt;
                objOraclecommand.Parameters.Add(prm111);


                OracleParameter prm112 = new OracleParameter("prev_ga", OracleType.Number);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = Convert.ToDecimal(prev_ga);
                objOraclecommand.Parameters.Add(prm112);


                OracleParameter prm113 = new OracleParameter("varient_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = varient_name;
                objOraclecommand.Parameters.Add(prm113);


                OracleParameter prm114 = new OracleParameter("region1", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = region;
                objOraclecommand.Parameters.Add(prm114);
                /*new change ankur 9 feb*/

                OracleParameter prm115 = new OracleParameter("coltype", OracleType.VarChar);
                prm115.Direction = ParameterDirection.Input;
                prm115.Value = coltype;
                objOraclecommand.Parameters.Add(prm115);

                OracleParameter prm116 = new OracleParameter("logo_h", OracleType.VarChar);
                prm116.Direction = ParameterDirection.Input;
                prm116.Value = logo_h;
                objOraclecommand.Parameters.Add(prm116);

                OracleParameter prm117 = new OracleParameter("logo_w", OracleType.VarChar);
                prm117.Direction = ParameterDirection.Input;
                prm117.Value = logo_w;
                objOraclecommand.Parameters.Add(prm117);

                OracleParameter prm118 = new OracleParameter("logo_col", OracleType.VarChar);
                prm118.Direction = ParameterDirection.Input;
                prm118.Value = logo_col;
                objOraclecommand.Parameters.Add(prm118);

                OracleParameter prm119 = new OracleParameter("logo_uom", OracleType.VarChar);
                prm119.Direction = ParameterDirection.Input;
                prm119.Value = logo_uom;
                objOraclecommand.Parameters.Add(prm119);

                OracleParameter prm120 = new OracleParameter("retainer1", OracleType.VarChar);
                prm120.Direction = ParameterDirection.Input;
                if (retainer.LastIndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.LastIndexOf("(") + 1, retainer.Length - retainer.LastIndexOf("(") - 2);
                }
                prm120.Value = retainer;
                objOraclecommand.Parameters.Add(prm120);

                OracleParameter prm121 = new OracleParameter("addagencyrate", OracleType.VarChar);
                prm121.Direction = ParameterDirection.Input;
                prm121.Value = addagencyrate;
                objOraclecommand.Parameters.Add(prm121);

                OracleParameter prm122 = new OracleParameter("mobileno", OracleType.VarChar);
                prm122.Direction = ParameterDirection.Input;
                prm122.Value = mobileno;
                objOraclecommand.Parameters.Add(prm122);

                OracleParameter prm123 = new OracleParameter("addlamt", OracleType.VarChar);
                prm123.Direction = ParameterDirection.Input;
                prm123.Value = addlamt;
                objOraclecommand.Parameters.Add(prm123);

                OracleParameter prm124 = new OracleParameter("retamt", OracleType.VarChar);
                prm124.Direction = ParameterDirection.Input;
                prm124.Value = retamt;
                objOraclecommand.Parameters.Add(prm124);

                OracleParameter prm125 = new OracleParameter("retper", OracleType.VarChar);
                prm125.Direction = ParameterDirection.Input;
                prm125.Value = retper;
                objOraclecommand.Parameters.Add(prm125);


                OracleParameter prm126 = new OracleParameter("cashrecieved", OracleType.VarChar);
                prm126.Direction = ParameterDirection.Input;
                if (cashrecieved == "" || cashrecieved == null)
                {
                    prm126.Value = System.DBNull.Value;
                }
                else
                {
                    prm126.Value = Convert.ToDecimal(cashrecieved);
                }
                objOraclecommand.Parameters.Add(prm126);

                OracleParameter prm127 = new OracleParameter("CIRAGENCY_V", OracleType.VarChar);
                prm127.Direction = ParameterDirection.Input;
                prm127.Value = ciragency;
                objOraclecommand.Parameters.Add(prm127);

                OracleParameter prm128 = new OracleParameter("CIRRATE_V", OracleType.VarChar);
                prm128.Direction = ParameterDirection.Input;
                prm128.Value = cirrate;
                objOraclecommand.Parameters.Add(prm128);

                OracleParameter prm129 = new OracleParameter("CIREDITION_V", OracleType.VarChar);
                prm129.Direction = ParameterDirection.Input;
                prm129.Value = ciredition;
                objOraclecommand.Parameters.Add(prm129);

                OracleParameter prm130 = new OracleParameter("CIRPUBLICATION_V", OracleType.VarChar);
                prm130.Direction = ParameterDirection.Input;
                prm130.Value = cirpublication;
                objOraclecommand.Parameters.Add(prm130);

                OracleParameter prm131 = new OracleParameter("CIRAGENCYSUBCODE_V", OracleType.VarChar);
                prm131.Direction = ParameterDirection.Input;
                prm131.Value = ciragencysubcode;
                objOraclecommand.Parameters.Add(prm131);

                OracleParameter prm132 = new OracleParameter("BARTERTYPE", OracleType.VarChar);
                prm132.Direction = ParameterDirection.Input;
                prm132.Value = bartertype;
                objOraclecommand.Parameters.Add(prm132);

                OracleParameter prm133 = new OracleParameter("CASHDISCOUNT_V", OracleType.VarChar);
                prm133.Direction = ParameterDirection.Input;
                if (cashdiscount == "")
                    prm133.Value = System.DBNull.Value;
                else
                    prm133.Value = cashdiscount;
                objOraclecommand.Parameters.Add(prm133);

                OracleParameter prm134 = new OracleParameter("CASHDISCOUNTPER_V", OracleType.VarChar);
                prm134.Direction = ParameterDirection.Input;
                prm134.Value = cashdiscountper;
                objOraclecommand.Parameters.Add(prm134);

                OracleParameter prm135 = new OracleParameter("attach1", OracleType.VarChar);
                prm135.Direction = ParameterDirection.Input;
                prm135.Value = attach1;
                objOraclecommand.Parameters.Add(prm135);

                OracleParameter prm136 = new OracleParameter("attach2", OracleType.VarChar);
                prm136.Direction = ParameterDirection.Input;
                prm136.Value = attach2;
                objOraclecommand.Parameters.Add(prm136);

                OracleParameter prm137 = new OracleParameter("drpdiscprem", OracleType.VarChar);
                prm137.Direction = ParameterDirection.Input;
                prm137.Value = drpdiscprem;
                objOraclecommand.Parameters.Add(prm137);

                OracleParameter prm138 = new OracleParameter("doctype_v", OracleType.VarChar);
                prm138.Direction = ParameterDirection.Input;
                prm138.Value = doctype;
                objOraclecommand.Parameters.Add(prm138);

                OracleParameter prm139 = new OracleParameter("CHKTRADE", OracleType.VarChar);
                prm139.Direction = ParameterDirection.Input;
                prm139.Value = chktradeval;
                objOraclecommand.Parameters.Add(prm139);
                OracleParameter prm140 = new OracleParameter("sharepub_p", OracleType.VarChar);
                prm140.Direction = ParameterDirection.Input;
                prm140.Value = sharepub;
                objOraclecommand.Parameters.Add(prm140);

                OracleParameter prm141 = new OracleParameter("fmginsert", OracleType.VarChar);
                prm141.Direction = ParameterDirection.Input;
                prm141.Value = fmginsert;
                objOraclecommand.Parameters.Add(prm141);

                OracleParameter prm142 = new OracleParameter("chkno", OracleType.VarChar);
                prm142.Direction = ParameterDirection.Input;
                prm142.Value = chkno;
                objOraclecommand.Parameters.Add(prm142);

                OracleParameter prm143 = new OracleParameter("chkdate", OracleType.DateTime);
                prm143.Direction = ParameterDirection.Input;
                if (chkdate == "" || chkdate == null)
                {
                    prm143.Value = System.DBNull.Value;

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
                    prm143.Value = Convert.ToDateTime(chkdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm143);

                OracleParameter prm144 = new OracleParameter("chkamt", OracleType.VarChar);
                prm144.Direction = ParameterDirection.Input;
                prm144.Value = chkamt;
                objOraclecommand.Parameters.Add(prm144);
                OracleParameter prm145 = new OracleParameter("chkbankname", OracleType.VarChar);
                prm145.Direction = ParameterDirection.Input;
                prm145.Value = chkbankname;
                objOraclecommand.Parameters.Add(prm145);

                OracleParameter prm146 = new OracleParameter("ourbank", OracleType.VarChar);
                prm146.Direction = ParameterDirection.Input;
                prm146.Value = ourbank;
                objOraclecommand.Parameters.Add(prm146);

                OracleParameter prm147 = new OracleParameter("DEALERPANEL_P", OracleType.VarChar);
                prm147.Direction = ParameterDirection.Input;
                if (dealerpanel == "")
                    prm147.Value = System.DBNull.Value;
                else
                    prm147.Value = dealerpanel;
                objOraclecommand.Parameters.Add(prm147);

                OracleParameter prm148 = new OracleParameter("DEALERH_P", OracleType.VarChar);
                prm148.Direction = ParameterDirection.Input;
                if (dealerh == "")
                    prm148.Value = System.DBNull.Value;
                else
                    prm148.Value = dealerh;
                objOraclecommand.Parameters.Add(prm148);

                OracleParameter prm149 = new OracleParameter("DEALERW_P", OracleType.VarChar);
                prm149.Direction = ParameterDirection.Input;
                if (dealerw == "")
                    prm149.Value = System.DBNull.Value;
                else
                    prm149.Value = dealerw;
                objOraclecommand.Parameters.Add(prm149);

                OracleParameter prm150 = new OracleParameter("DEALERTYPE_P", OracleType.VarChar);
                prm150.Direction = ParameterDirection.Input;
                if (dealertype == "")
                    prm150.Value = System.DBNull.Value;
                else
                    prm150.Value = dealertype;
                objOraclecommand.Parameters.Add(prm150);

                OracleParameter prm151 = new OracleParameter("multiselect", OracleType.VarChar);
                prm151.Direction = ParameterDirection.Input;
                if (multiselect == "")
                    prm151.Value = System.DBNull.Value;
                else
                    prm151.Value = multiselect;

                objOraclecommand.Parameters.Add(prm151);

                OracleParameter prm152 = new OracleParameter("AGREEDRATE_ACTIVE", OracleType.VarChar);
                prm152.Direction = ParameterDirection.Input;
                if (agreedrate_active == "")
                    prm152.Value = System.DBNull.Value;
                else
                    prm152.Value = agreedrate_active;

                objOraclecommand.Parameters.Add(prm152);

                OracleParameter prm153 = new OracleParameter("AGREEDAMT_ACTIVE", OracleType.VarChar);
                prm153.Direction = ParameterDirection.Input;
                if (agreedamt_active == "")
                    prm153.Value = System.DBNull.Value;
                else
                    prm153.Value = agreedamt_active;

                objOraclecommand.Parameters.Add(prm153);

                OracleParameter prm154 = new OracleParameter("grossamtlocal_p", OracleType.VarChar);
                prm154.Direction = ParameterDirection.Input;
                if (grossamtlocal_p == "")
                    prm154.Value = System.DBNull.Value;
                else
                    prm154.Value = grossamtlocal_p;

                objOraclecommand.Parameters.Add(prm154);

                OracleParameter prm153a = new OracleParameter("billamtlocal_p", OracleType.VarChar);
                prm153a.Direction = ParameterDirection.Input;
                if (billamtlocal_p == "")
                    prm153a.Value = System.DBNull.Value;
                else
                    prm153a.Value = billamtlocal_p;

                objOraclecommand.Parameters.Add(prm153a);



                OracleParameter prm145a = new OracleParameter("chkadon_p", OracleType.VarChar);
                prm145a.Direction = ParameterDirection.Input;
                prm145a.Value = chkadon;
                objOraclecommand.Parameters.Add(prm145a);

                OracleParameter prm145b = new OracleParameter("refid_p", OracleType.VarChar);
                prm145b.Direction = ParameterDirection.Input;
                prm145b.Value = refid;
                objOraclecommand.Parameters.Add(prm145b);

                OracleParameter prm145c = new OracleParameter("rcpt_currency", OracleType.VarChar);
                prm145c.Direction = ParameterDirection.Input;
                prm145c.Value = rcpt_currency;
                objOraclecommand.Parameters.Add(prm145c);

                OracleParameter prm145d = new OracleParameter("cur_convrate", OracleType.VarChar);
                prm145d.Direction = ParameterDirection.Input;
                prm145d.Value = cur_convrate;
                objOraclecommand.Parameters.Add(prm145d);

                OracleParameter prm145e = new OracleParameter("p_revisedate", OracleType.VarChar);
                prm145e.Direction = ParameterDirection.Input;
                if (revisedate == "" || revisedate == null)
                {
                    prm145e.Value = System.DBNull.Value;

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
                    prm145e.Value = Convert.ToDateTime(revisedate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm145e);

                OracleParameter prm153d = new OracleParameter("clienttype", OracleType.VarChar);
                prm153d.Direction = ParameterDirection.Input;
                if (clienttype == "0")
                    prm153d.Value = System.DBNull.Value;
                else
                    prm153d.Value = clienttype;
                objOraclecommand.Parameters.Add(prm153d);

                OracleParameter prm153e = new OracleParameter("translation", OracleType.VarChar);
                prm153e.Direction = ParameterDirection.Input;
                if (translation == "0")
                    prm153e.Value = System.DBNull.Value;
                else
                    prm153e.Value = translation;
                objOraclecommand.Parameters.Add(prm153e);


                OracleParameter prm107a = new OracleParameter("translationcharge", OracleType.Number);
                prm107a.Direction = ParameterDirection.Input;
                if (translationcharge == "" || translationcharge == null)
                {
                    prm107a.Value = System.DBNull.Value;
                }
                else
                {
                    translationcharge = translationcharge.Replace("%", "");
                    prm107a.Value = Convert.ToDecimal(translationcharge);
                }
                objOraclecommand.Parameters.Add(prm107a);

                OracleParameter prm141a = new OracleParameter("fmgreasons", OracleType.VarChar);
                prm141a.Direction = ParameterDirection.Input;
                prm141a.Value = fmgreasons;
                objOraclecommand.Parameters.Add(prm141a);

                OracleParameter prm141b = new OracleParameter("canclecharge", OracleType.VarChar);
                prm141b.Direction = ParameterDirection.Input;
                prm141b.Value = canclecharge;
                objOraclecommand.Parameters.Add(prm141b);

                OracleParameter prm161bt = new OracleParameter("transdisc_p", OracleType.VarChar);
                prm161bt.Direction = ParameterDirection.Input;
                prm161bt.Value = transdisc;
                objOraclecommand.Parameters.Add(prm161bt);

                OracleParameter prm161bs = new OracleParameter("pospremdisc_p", OracleType.VarChar);
                prm161bs.Direction = ParameterDirection.Input;
                prm161bs.Value = pospremdisc;
                objOraclecommand.Parameters.Add(prm161bs);

                OracleParameter prm161b1 = new OracleParameter("billhold", OracleType.VarChar);
                prm161b1.Direction = ParameterDirection.Input;
                prm161b1.Value = billhold;
                objOraclecommand.Parameters.Add(prm161b1);

                OracleParameter prm161b1x = new OracleParameter("designbox", OracleType.VarChar);
                prm161b1x.Direction = ParameterDirection.Input;
                prm161b1x.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm161b1x);

                OracleParameter prm161b1z = new OracleParameter("logoprem", OracleType.VarChar);
                prm161b1z.Direction = ParameterDirection.Input;
                prm161b1z.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm161b1z);

                OracleParameter prm161b1az = new OracleParameter("online_ad_p", OracleType.VarChar);
                prm161b1az.Direction = ParameterDirection.Input;
                prm161b1az.Value = online_ad;
                objOraclecommand.Parameters.Add(prm161b1az);


                OracleParameter prm161b1azx = new OracleParameter("pstyle", OracleType.VarChar);
                prm161b1azx.Direction = ParameterDirection.Input;
                prm161b1azx.Value = pstyle;
                objOraclecommand.Parameters.Add(prm161b1azx);



                OracleParameter prm161b1azy = new OracleParameter("pfixed_booking", OracleType.VarChar);
                prm161b1azy.Direction = ParameterDirection.Input;
                prm161b1azy.Value = fixed_booking;
                objOraclecommand.Parameters.Add(prm161b1azy);




                OracleParameter prm161b1azy1 = new OracleParameter("pvat_code", OracleType.VarChar);
                prm161b1azy1.Direction = ParameterDirection.Input;
                prm161b1azy1.Value = vat_code;
                objOraclecommand.Parameters.Add(prm161b1azy1);

                OracleParameter prm161b1azy1q = new OracleParameter("CPN_CODE_P", OracleType.VarChar);
                prm161b1azy1q.Direction = ParameterDirection.Input;
                prm161b1azy1q.Value = cou_code;
                objOraclecommand.Parameters.Add(prm161b1azy1q);

                OracleParameter prm161b1azy1n = new OracleParameter("CPN_NAME_P", OracleType.VarChar);
                prm161b1azy1n.Direction = ParameterDirection.Input;
                prm161b1azy1n.Value = cou_name;
                objOraclecommand.Parameters.Add(prm161b1azy1n);

                OracleParameter prm161b1az14A = new OracleParameter("STATE_P", OracleType.VarChar);
                prm161b1az14A.Direction = ParameterDirection.Input;
                prm161b1az14A.Value = state;
                objOraclecommand.Parameters.Add(prm161b1az14A);

                //////////////

                OracleParameter prm161z = new OracleParameter("clientcatdisc", OracleType.Number);
                prm161z.Direction = ParameterDirection.Input;
                if (clientcatdisc == "" || clientcatdisc == "0" || clientcatdisc == "null")
                {
                    prm161z.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z.Value = clientcatdisc;
                }
                objOraclecommand.Parameters.Add(prm161z);

                OracleParameter prm161z1 = new OracleParameter("clientcatamt", OracleType.Number);
                prm161z1.Direction = ParameterDirection.Input;
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    prm161z1.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z1.Value = clientcatamt;
                }
                objOraclecommand.Parameters.Add(prm161z1);

                OracleParameter prm161z2 = new OracleParameter("clientcatdistype", OracleType.VarChar);
                prm161z2.Direction = ParameterDirection.Input;
                prm161z2.Value = clientcatdistype;
                objOraclecommand.Parameters.Add(prm161z2);


                OracleParameter prm161z3 = new OracleParameter("flatfreqdisc", OracleType.Number);
                prm161z3.Direction = ParameterDirection.Input;
                if (flatfreqdisc == "" || flatfreqdisc == "0" || flatfreqdisc == "null")
                {
                    prm161z3.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z3.Value = flatfreqdisc;
                }
                objOraclecommand.Parameters.Add(prm161z3);



                OracleParameter prm161z4 = new OracleParameter("flatfreqamt", OracleType.Number);
                prm161z4.Direction = ParameterDirection.Input;
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    prm161z4.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z4.Value = flatfreqamt;
                }
                objOraclecommand.Parameters.Add(prm161z4);




                OracleParameter prm161z5 = new OracleParameter("flatfreqdisctype", OracleType.VarChar);
                prm161z5.Direction = ParameterDirection.Input;
                prm161z5.Value = flatfreqdisctype;
                objOraclecommand.Parameters.Add(prm161z5);

                OracleParameter prm161z6 = new OracleParameter("catdisc", OracleType.Number);
                prm161z6.Direction = ParameterDirection.Input;
                if (catdisc == "" || catdisc == "0" || catdisc == "null")
                {
                    prm161z6.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z6.Value = catdisc;
                }
                objOraclecommand.Parameters.Add(prm161z6);

                OracleParameter prm161z7 = new OracleParameter("catamt", OracleType.Number);
                prm161z7.Direction = ParameterDirection.Input;
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    prm161z7.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z7.Value = catamt;
                }
                objOraclecommand.Parameters.Add(prm161z7);

                OracleParameter prm161z8 = new OracleParameter("catdisctype", OracleType.VarChar);
                prm161z8.Direction = ParameterDirection.Input;
                prm161z8.Value = catdisctype;
                objOraclecommand.Parameters.Add(prm161z8);

                OracleParameter prm161z9 = new OracleParameter("representative_p", OracleType.VarChar);
                prm161z9.Direction = ParameterDirection.Input;
                if (representative == "" || representative == "0" || representative == "null")
                {
                    prm161z9.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z9.Value = representative;
                }
                objOraclecommand.Parameters.Add(prm161z9);

                OracleParameter prm161w = new OracleParameter("teamcode", OracleType.VarChar);
                prm161w.Direction = ParameterDirection.Input;
                prm161w.Value = teamcode;
                objOraclecommand.Parameters.Add(prm161w);

                OracleParameter prm161w1 = new OracleParameter("pindustry", OracleType.VarChar);
                prm161w1.Direction = ParameterDirection.Input;
                prm161w1.Value = industry;
                objOraclecommand.Parameters.Add(prm161w1);

                OracleParameter prm161w3 = new OracleParameter("pproductcat", OracleType.VarChar);
                prm161w3.Direction = ParameterDirection.Input;
                prm161w3.Value = productcat;
                objOraclecommand.Parameters.Add(prm161w3);

                OracleParameter prm161w4 = new OracleParameter("chkgstinc", OracleType.VarChar);
                prm161w4.Direction = ParameterDirection.Input;
                prm161w4.Value = chkgstinc;
                objOraclecommand.Parameters.Add(prm161w4);

                OracleParameter prm161w41 = new OracleParameter("ppubl_rev_cent", OracleType.VarChar);
                prm161w41.Direction = ParameterDirection.Input;
                prm161w41.Value = publ_rev_cent;
                objOraclecommand.Parameters.Add(prm161w41);
                OracleParameter prm161bb = new OracleParameter("pcontractperson", OracleType.VarChar);
                prm161bb.Direction = ParameterDirection.Input;
                prm161bb.Value = contractperson;
                objOraclecommand.Parameters.Add(prm161bb);

                OracleParameter prm161bb1 = new OracleParameter("pemailid", OracleType.VarChar);
                prm161bb1.Direction = ParameterDirection.Input;
                prm161bb1.Value = emailid;
                objOraclecommand.Parameters.Add(prm161bb1);
                OracleParameter prm161bb17 = new OracleParameter("pquotation_id", OracleType.VarChar);
                prm161bb17.Direction = ParameterDirection.Input;
                prm161bb17.Value = quotationno;
                objOraclecommand.Parameters.Add(prm161bb17);

                objOraclecommand.Parameters.Add("p_error", OracleType.VarChar, 200);
                objOraclecommand.Parameters["p_error"].Direction = ParameterDirection.Output;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                //objOraclecommand.ExecuteNonQuery();
                string output = objOraclecommand.Parameters["p_error"].Value.ToString();

                return output;

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
        public DataSet updatebookingdisp(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string status, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string attach1, string attach2, string cashdiscount, string cashdiscountper, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string agreedrate_active, string agreedamt_active, string grossamtlocal_p, string billamtlocal_p, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string modifyrateaudit, string ip, string transdisc, string pospremdisc, string billhold, string online_ad, string fixed_booking, string vat_code, string cou_code, string cou_name, string state, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype, string representative, string teamcode, string industry, string productcat, string chkgstinc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatebooking.updatebooking_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm6 = new OracleParameter("approvedby", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = approvedby;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("audit1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = audit;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("rono", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = rono;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("rodate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;

                if (rodate == "" || rodate == null)
                {
                    prm10.Value = System.DBNull.Value;
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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = rodate.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        rodate = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = rodate.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            rodate = mm + "/" + dd + "/" + yy;
                    //        }
                    prm10.Value = Convert.ToDateTime(rodate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("caption", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = caption;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("billstatus", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = billstatus;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("rostatus", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = rostatus;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("agency", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = agency;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("client", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = client;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("agencyaddress", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = agencyaddress;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("clientaddresses", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = clientaddresses;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("agencycode", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = agencycode;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("dockitno", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = dockitno;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("execname", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = execname;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("execzone", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = execzone;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("product", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = product;
                objOraclecommand.Parameters.Add(prm22);



                OracleParameter prm23 = new OracleParameter("brand", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = brand;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("keyno", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = keyno;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("billremark", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = billremark;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("printremark", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = printremark;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("package1", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = package;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("insertion", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (insertion == "")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDecimal(insertion);
                }
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("startdate", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;

                if (startdate == "" || startdate == null)
                {
                    prm29.Value = System.DBNull.Value;
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

                    prm29.Value = Convert.ToDateTime(startdate).ToString("dd-MMMM-yyyy");
                }
                //if (dateformat == "dd/mm/yyyy")
                //{
                //    string[] arr = startdate.Split('/');
                //    string dd = arr[0];
                //    string mm = arr[1];
                //    string yy = arr[2];
                //    startdate = mm + "/" + dd + "/" + yy;


                //}
                //else
                //    if (dateformat == "mm/dd/yyyy")
                //    {
                //        string[] arr = startdate.Split('/');
                //        string dd = arr[1];
                //        string mm = arr[0];
                //        string yy = arr[2];
                //        startdate = mm + "/" + dd + "/" + yy;

                //    }

                //    else
                //        if (dateformat == "yyyy/mm/dd")
                //        {
                //            string[] arr = startdate.Split('/');
                //            string dd = arr[2];
                //            string mm = arr[1];
                //            string yy = arr[0];
                //            startdate = mm + "/" + dd + "/" + yy;
                //        }

                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("repeatdate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = repeatdate;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("adtype1", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = adtype;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("adcategory", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = adcategory;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("subcategory", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = subcategory;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("color", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = color;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("uom", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = uom;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("pageposition", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = pageposition;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("pagetype1", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = pagetype;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("pageno", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                if (pageno == "" || pageno == null)
                {
                    prm38.Value = System.DBNull.Value;

                }
                else
                {
                    prm38.Value = Convert.ToDecimal(pageno);
                }
                objOraclecommand.Parameters.Add(prm38);



                OracleParameter prm39 = new OracleParameter("adsizheight", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                if (adsizheight == "" || adsizheight == null)
                {
                    prm39.Value = System.DBNull.Value;
                }
                else
                {
                    prm39.Value = Convert.ToDecimal(adsizheight);
                }
                objOraclecommand.Parameters.Add(prm39);


                OracleParameter prm40 = new OracleParameter("adsizwidth", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                if (adsizwidth == "" || adsizwidth == null)
                {
                    prm40.Value = System.DBNull.Value;
                }
                else
                {
                    prm40.Value = Convert.ToDecimal(adsizwidth);
                }
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm43 = new OracleParameter("ratecode11", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = ratecode;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm41 = new OracleParameter("scheme1", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = scheme;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("currency", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = currency;
                objOraclecommand.Parameters.Add(prm42);



                OracleParameter prm44 = new OracleParameter("agreedrate", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                if (agreedrate == "" || agreedrate == null)
                {
                    prm44.Value = System.DBNull.Value;
                }
                else
                {
                    prm44.Value = Convert.ToDecimal(agreedrate);
                }
                objOraclecommand.Parameters.Add(prm44);


                OracleParameter prm45 = new OracleParameter("agreedamt", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                if (agreedamt == "" || agreedamt == null)
                {
                    prm45.Value = System.DBNull.Value;
                }
                else
                {
                    prm45.Value = Convert.ToDecimal(agreedamt);
                }
                objOraclecommand.Parameters.Add(prm45);


                OracleParameter prm46 = new OracleParameter("spedisc", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                if (spedisc == "" || spedisc == null)
                {
                    prm46.Value = System.DBNull.Value;
                }
                else
                {
                    prm46.Value = Convert.ToDecimal(spedisc);
                }
                objOraclecommand.Parameters.Add(prm46);
                OracleParameter prm48 = new OracleParameter("spacedisx", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                if (spacedisx == "" || spacedisx == null)
                {
                    prm48.Value = System.DBNull.Value;
                }
                else
                {
                    prm48.Value = Convert.ToDecimal(spacedisx);
                }
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm47 = new OracleParameter("compcode", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = compcode;
                objOraclecommand.Parameters.Add(prm47);
                OracleParameter prm50 = new OracleParameter("userid", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = userid;
                objOraclecommand.Parameters.Add(prm50);


                OracleParameter prm7 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ciobookid;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm1 = new OracleParameter("date_time", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (date_time == "" || date_time == null)
                {
                    prm1.Value = System.DBNull.Value;


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
                    //else
                    //    if (dateformat == "mm/dd/yyyy")
                    //    {
                    //        string[] arr = date_time.Split('/');
                    //        string dd = arr[1];
                    //        string mm = arr[0];
                    //        string yy = arr[2];
                    //        date_time = mm + "/" + dd + "/" + yy;

                    //    }

                    //    else
                    //        if (dateformat == "yyyy/mm/dd")
                    //        {
                    //            string[] arr = date_time.Split('/');
                    //            string dd = arr[2];
                    //            string mm = arr[1];
                    //            string yy = arr[0];
                    //            date_time = mm + "/" + dd + "/" + yy;
                    //        }


                    prm1.Value = Convert.ToDateTime(date_time).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm3 = new OracleParameter("branch", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branch;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("booked_by", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = booked_by;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("prevbook", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = prevbook;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm2 = new OracleParameter("adsizetype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adsizetype;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm49 = new OracleParameter("specialcharges", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                if (specialcharges == "" || specialcharges == null)
                {
                    prm49.Value = System.DBNull.Value;
                }
                else
                {
                    prm49.Value = Convert.ToDecimal(specialcharges);
                }
                objOraclecommand.Parameters.Add(prm49);




                OracleParameter prm51 = new OracleParameter("agencytype", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = agencytype;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm52 = new OracleParameter("agencystatus", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = agencystatus;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("paymode", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = paymode;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("agencredit", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                if (agencredit == "" || agencredit == null)
                {
                    prm54.Value = System.DBNull.Value;
                }
                else
                {
                    prm54.Value = Convert.ToInt32(agencredit);
                }
                objOraclecommand.Parameters.Add(prm54);


                OracleParameter prm55 = new OracleParameter("cardrate", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                if (cardrate == "" || cardrate == null)
                {
                    prm55.Value = System.DBNull.Value;
                }
                else
                {
                    prm55.Value = Convert.ToDecimal(cardrate);
                }
                objOraclecommand.Parameters.Add(prm55);


                OracleParameter prm56 = new OracleParameter("cardamount", OracleType.VarChar);
                prm56.Direction = ParameterDirection.Input;
                if (cardamount == "" || cardamount == null)
                {
                    prm56.Value = System.DBNull.Value;
                }
                else
                {
                    prm56.Value = Convert.ToDecimal(cardamount);
                }
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("discount", OracleType.VarChar);
                prm57.Direction = ParameterDirection.Input;
                if (discount == "" || discount == null)
                {
                    prm57.Value = System.DBNull.Value;
                }
                else
                {
                    prm57.Value = Convert.ToDecimal(discount);
                }
                objOraclecommand.Parameters.Add(prm57);


                OracleParameter prm58 = new OracleParameter("discountper", OracleType.VarChar);
                prm58.Direction = ParameterDirection.Input;
                if (discountper == "" || discountper == null)
                {
                    prm58.Value = System.DBNull.Value;
                }
                else
                {
                    prm58.Value = Convert.ToDecimal(discountper);
                }
                objOraclecommand.Parameters.Add(prm58);


                OracleParameter prm59 = new OracleParameter("billaddress", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                prm59.Value = billaddress;
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("totarea", OracleType.VarChar);
                prm60.Direction = ParameterDirection.Input;
                if (totarea == "" || totarea == null)
                {
                    prm60.Value = System.DBNull.Value;
                }
                else
                {
                    prm60.Value = Convert.ToDecimal(totarea);
                }
                objOraclecommand.Parameters.Add(prm60);


                OracleParameter prm61 = new OracleParameter("billcycle", OracleType.VarChar);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = billcycle;
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm63 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = revenuecenter;
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm62 = new OracleParameter("billpay", OracleType.VarChar);
                prm62.Direction = ParameterDirection.Input;
                prm62.Value = billpay;
                objOraclecommand.Parameters.Add(prm62);



                OracleParameter prm64 = new OracleParameter("billheight", OracleType.VarChar);
                prm64.Direction = ParameterDirection.Input;
                if (billheight == "" || billheight == null)
                {
                    prm64.Value = System.DBNull.Value;
                }
                else
                {
                    prm64.Value = Convert.ToDecimal(billheight);
                }
                objOraclecommand.Parameters.Add(prm64);


                OracleParameter prm65 = new OracleParameter("billwidth", OracleType.VarChar);
                prm65.Direction = ParameterDirection.Input;
                if (billwidth == "" || billwidth == null)
                {
                    prm65.Value = System.DBNull.Value;
                }
                else
                {
                    prm65.Value = Convert.ToDecimal(billwidth);
                }
                objOraclecommand.Parameters.Add(prm65);


                OracleParameter prm66 = new OracleParameter("billto", OracleType.VarChar);
                prm66.Direction = ParameterDirection.Input;
                prm66.Value = billto;
                objOraclecommand.Parameters.Add(prm66);

                OracleParameter prm67 = new OracleParameter("invoices", OracleType.VarChar);
                prm67.Direction = ParameterDirection.Input;
                if (invoices == "" || invoices == null)
                {
                    prm67.Value = System.DBNull.Value;
                }
                else
                {
                    prm67.Value = Convert.ToDecimal(invoices);
                }
                objOraclecommand.Parameters.Add(prm67);


                OracleParameter prm68 = new OracleParameter("vts", OracleType.VarChar);
                prm68.Direction = ParameterDirection.Input;
                if (vts == "" || vts == null || vts == "null")
                {
                    prm68.Value = System.DBNull.Value;
                }
                else
                {
                    prm68.Value = Convert.ToDecimal(vts);
                }
                objOraclecommand.Parameters.Add(prm68);



                OracleParameter prm69 = new OracleParameter("tradedisc", OracleType.VarChar);
                prm69.Direction = ParameterDirection.Input;
                if (tradedisc == "" || tradedisc == null || tradedisc == "undefined" || tradedisc == "0")
                    prm69.Value = System.DBNull.Value;
                else
                    prm69.Value = Convert.ToDecimal(tradedisc);
                objOraclecommand.Parameters.Add(prm69);

                OracleParameter prm70 = new OracleParameter("agencyout", OracleType.VarChar);
                prm70.Direction = ParameterDirection.Input;
                prm70.Value = agencyout;
                objOraclecommand.Parameters.Add(prm70);

                OracleParameter prm71 = new OracleParameter("boxcode", OracleType.VarChar);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = boxcode;
                objOraclecommand.Parameters.Add(prm71);

                OracleParameter prm72 = new OracleParameter("boxno", OracleType.VarChar);
                prm72.Direction = ParameterDirection.Input;
                prm72.Value = boxno;
                objOraclecommand.Parameters.Add(prm72);


                OracleParameter prm74 = new OracleParameter("boxaddress", OracleType.VarChar);
                prm74.Direction = ParameterDirection.Input;
                prm74.Value = boxaddress;
                objOraclecommand.Parameters.Add(prm74);

                OracleParameter prm73 = new OracleParameter("boxagency", OracleType.VarChar);
                prm73.Direction = ParameterDirection.Input;
                prm73.Value = boxagency;
                objOraclecommand.Parameters.Add(prm73);


                OracleParameter prm75 = new OracleParameter("boxclient", OracleType.VarChar);
                prm75.Direction = ParameterDirection.Input;
                prm75.Value = boxclient;
                objOraclecommand.Parameters.Add(prm75);

                OracleParameter prm77 = new OracleParameter("bookingtype", OracleType.VarChar);
                prm77.Direction = ParameterDirection.Input;
                prm77.Value = bookingtype;
                objOraclecommand.Parameters.Add(prm77);

                OracleParameter prm78 = new OracleParameter("tfn", OracleType.VarChar);
                prm78.Direction = ParameterDirection.Input;
                prm78.Value = tfn;
                objOraclecommand.Parameters.Add(prm78);


                OracleParameter prm76 = new OracleParameter("coupan", OracleType.VarChar);
                prm76.Direction = ParameterDirection.Input;
                prm76.Value = coupan;
                objOraclecommand.Parameters.Add(prm76);




                OracleParameter prm79 = new OracleParameter("campaign", OracleType.VarChar);
                prm79.Direction = ParameterDirection.Input;
                prm79.Value = campaign;
                objOraclecommand.Parameters.Add(prm79);


                OracleParameter prm80 = new OracleParameter("bill_amt", OracleType.VarChar);
                prm80.Direction = ParameterDirection.Input;
                if (bill_amt == "" || bill_amt == null)
                {
                    prm80.Value = System.DBNull.Value;
                }
                else
                {
                    prm80.Value = Convert.ToDecimal(bill_amt);
                }
                objOraclecommand.Parameters.Add(prm80);


                OracleParameter prm81 = new OracleParameter("pageprem", OracleType.VarChar);
                prm81.Direction = ParameterDirection.Input;
                prm81.Value = pageprem;
                objOraclecommand.Parameters.Add(prm81);

                OracleParameter prm82 = new OracleParameter("pageamt", OracleType.VarChar);
                prm82.Direction = ParameterDirection.Input;
                if (pageamt == "" || pageamt == null)
                {
                    prm82.Value = System.DBNull.Value;
                }
                else
                {
                    prm82.Value = Convert.ToDecimal(pageamt);
                }
                objOraclecommand.Parameters.Add(prm82);


                OracleParameter prm83 = new OracleParameter("premper", OracleType.VarChar);
                prm83.Direction = ParameterDirection.Input;
                if (premper == "" || premper == null)
                {
                    prm83.Value = System.DBNull.Value;
                }
                else
                {
                    prm83.Value = Convert.ToDecimal(premper);
                }
                objOraclecommand.Parameters.Add(prm83);


                OracleParameter prm84 = new OracleParameter("grossamt", OracleType.VarChar);
                prm84.Direction = ParameterDirection.Input;
                if (grossamt == "" || grossamt == null)
                {
                    prm84.Value = System.DBNull.Value;
                }
                else
                {
                    prm84.Value = Convert.ToDecimal(grossamt);
                }
                objOraclecommand.Parameters.Add(prm84);



                OracleParameter prm85 = new OracleParameter("adsizcolumn", OracleType.VarChar);
                prm85.Direction = ParameterDirection.Input;
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    prm85.Value = System.DBNull.Value;
                }
                else
                {
                    prm85.Value = Convert.ToDecimal(adsizcolumn);
                }
                objOraclecommand.Parameters.Add(prm85);

                OracleParameter prm89 = new OracleParameter("billarea", OracleType.VarChar);
                prm89.Direction = ParameterDirection.Input;
                if (billarea == 0)
                {
                    prm89.Value = System.DBNull.Value;
                }
                else
                {
                    prm89.Value = Convert.ToDecimal(billarea);
                }
                objOraclecommand.Parameters.Add(prm89);


                OracleParameter prm86 = new OracleParameter("billcolumn", OracleType.VarChar);
                prm86.Direction = ParameterDirection.Input;
                if (billcolumn == "" || billcolumn == null)
                {
                    prm86.Value = System.DBNull.Value;
                }
                else
                {
                    prm86.Value = Convert.ToDecimal(billcolumn);
                }
                objOraclecommand.Parameters.Add(prm86);


                OracleParameter prm88 = new OracleParameter("spacediscper", OracleType.VarChar);
                prm88.Direction = ParameterDirection.Input;
                if (spacediscper == "" || spacediscper == null)
                {
                    prm88.Value = System.DBNull.Value;
                }
                else
                {
                    prm88.Value = Convert.ToDecimal(spacediscper);
                }
                objOraclecommand.Parameters.Add(prm88);

                OracleParameter prm87 = new OracleParameter("specdiscper", OracleType.VarChar);
                prm87.Direction = ParameterDirection.Input;
                if (specdiscper == "" || specdiscper == null)
                {
                    prm87.Value = System.DBNull.Value;
                }
                else
                {
                    prm87.Value = Convert.ToDecimal(specdiscper);
                }
                objOraclecommand.Parameters.Add(prm87);






                OracleParameter prm90 = new OracleParameter("paidins", OracleType.VarChar);
                prm90.Direction = ParameterDirection.Input;
                if (paidins == "" || paidins == null)
                {
                    prm90.Value = System.DBNull.Value;
                }
                else
                {
                    prm90.Value = Convert.ToDecimal(paidins);
                }
                objOraclecommand.Parameters.Add(prm90);
                OracleParameter prm91 = new OracleParameter("dealrate", OracleType.VarChar);
                prm91.Direction = ParameterDirection.Input;
                if (dealrate == "" || dealrate == null)
                {
                    prm91.Value = System.DBNull.Value;
                }
                else
                {
                    prm91.Value = Convert.ToDecimal(dealrate);
                }

                objOraclecommand.Parameters.Add(prm91);


                OracleParameter prm92 = new OracleParameter("deviation", OracleType.VarChar);
                prm92.Direction = ParameterDirection.Input;
                if (deviation == "" || deviation == null)
                {
                    prm92.Value = System.DBNull.Value;
                }
                else
                {
                    prm92.Value = Convert.ToDecimal(deviation);
                }
                objOraclecommand.Parameters.Add(prm92);




                OracleParameter prm93 = new OracleParameter("varient", OracleType.VarChar);
                prm93.Direction = ParameterDirection.Input;
                prm93.Value = varient;
                objOraclecommand.Parameters.Add(prm93);



                OracleParameter prm95 = new OracleParameter("dealtype", OracleType.VarChar);
                prm95.Direction = ParameterDirection.Input;
                prm95.Value = dealtype;
                objOraclecommand.Parameters.Add(prm95);

                OracleParameter prm94 = new OracleParameter("contractname", OracleType.VarChar);
                prm94.Direction = ParameterDirection.Input;
                prm94.Value = contractname;
                objOraclecommand.Parameters.Add(prm94);

                OracleParameter prm96 = new OracleParameter("cardname", OracleType.VarChar);
                prm96.Direction = ParameterDirection.Input;
                prm96.Value = cardname;
                objOraclecommand.Parameters.Add(prm96);

                OracleParameter prm97 = new OracleParameter("cardtype", OracleType.VarChar);
                prm97.Direction = ParameterDirection.Input;
                prm97.Value = cardtype;
                objOraclecommand.Parameters.Add(prm97);

                OracleParameter prm98 = new OracleParameter("cardmonth", OracleType.VarChar);
                prm98.Direction = ParameterDirection.Input;
                prm98.Value = cardmonth;
                objOraclecommand.Parameters.Add(prm98);

                OracleParameter prm99 = new OracleParameter("cardyear", OracleType.VarChar);
                prm99.Direction = ParameterDirection.Input;
                prm99.Value = cardyear;
                objOraclecommand.Parameters.Add(prm99);

                OracleParameter prm100 = new OracleParameter("cardno", OracleType.VarChar);
                prm100.Direction = ParameterDirection.Input;
                prm100.Value = cardno;
                objOraclecommand.Parameters.Add(prm100);






                OracleParameter prm101 = new OracleParameter("receiptno", OracleType.VarChar);
                prm101.Direction = ParameterDirection.Input;
                prm101.Value = receiptno;
                objOraclecommand.Parameters.Add(prm101);


                OracleParameter prm102 = new OracleParameter("adscat3", OracleType.VarChar);
                prm102.Direction = ParameterDirection.Input;
                prm102.Value = adscat3;
                objOraclecommand.Parameters.Add(prm102);


                OracleParameter prm103 = new OracleParameter("adscat4", OracleType.VarChar);
                prm103.Direction = ParameterDirection.Input;
                prm103.Value = adscat4;
                objOraclecommand.Parameters.Add(prm103);


                OracleParameter prm104 = new OracleParameter("adscat5", OracleType.VarChar);
                prm104.Direction = ParameterDirection.Input;
                prm104.Value = adscat5;
                objOraclecommand.Parameters.Add(prm104);


                OracleParameter prm105 = new OracleParameter("bgcolor", OracleType.VarChar);
                prm105.Direction = ParameterDirection.Input;
                prm105.Value = bgcolor;
                objOraclecommand.Parameters.Add(prm105);


                OracleParameter prm106 = new OracleParameter("bulletcode", OracleType.VarChar);
                prm106.Direction = ParameterDirection.Input;
                prm106.Value = bulletcode;
                objOraclecommand.Parameters.Add(prm106);


                OracleParameter prm107 = new OracleParameter("bulletprm", OracleType.VarChar);
                prm107.Direction = ParameterDirection.Input;
                if (bulletprm == "" || bulletprm == null)
                {
                    prm107.Value = System.DBNull.Value;
                }
                else
                {
                    bulletprm = bulletprm.Replace("%", "");
                    prm107.Value = Convert.ToDecimal(bulletprm);
                }
                objOraclecommand.Parameters.Add(prm107);


                OracleParameter prm108 = new OracleParameter("material", OracleType.VarChar);
                prm108.Direction = ParameterDirection.Input;
                prm108.Value = material;
                objOraclecommand.Parameters.Add(prm108);








                OracleParameter prm114 = new OracleParameter("region1", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = region;
                objOraclecommand.Parameters.Add(prm114);



                OracleParameter prm113 = new OracleParameter("varient_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = varient_name;
                objOraclecommand.Parameters.Add(prm113);



                /*new change ankur 9 feb*/

                OracleParameter prm115 = new OracleParameter("coltype", OracleType.VarChar);
                prm115.Direction = ParameterDirection.Input;
                prm115.Value = coltype;
                objOraclecommand.Parameters.Add(prm115);

                OracleParameter prm116 = new OracleParameter("logo_h", OracleType.VarChar);
                prm116.Direction = ParameterDirection.Input;
                prm116.Value = logo_h;
                objOraclecommand.Parameters.Add(prm116);

                OracleParameter prm117 = new OracleParameter("logo_w", OracleType.VarChar);
                prm117.Direction = ParameterDirection.Input;
                prm117.Value = logo_w;
                objOraclecommand.Parameters.Add(prm117);

                OracleParameter prm118 = new OracleParameter("logo_col", OracleType.VarChar);
                prm118.Direction = ParameterDirection.Input;
                prm118.Value = logo_col;
                objOraclecommand.Parameters.Add(prm118);

                OracleParameter prm119 = new OracleParameter("logo_uom", OracleType.VarChar);
                prm119.Direction = ParameterDirection.Input;
                prm119.Value = logo_uom;
                objOraclecommand.Parameters.Add(prm119);


                OracleParameter prm120 = new OracleParameter("retainer1", OracleType.VarChar);
                prm120.Direction = ParameterDirection.Input;
                if (retainer.LastIndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.LastIndexOf("(") + 1, retainer.Length - retainer.LastIndexOf("(") - 2);
                }
                prm120.Value = retainer;
                objOraclecommand.Parameters.Add(prm120);

                OracleParameter prm121 = new OracleParameter("addagencyrate", OracleType.VarChar);
                prm121.Direction = ParameterDirection.Input;
                prm121.Value = addagencyrate;
                objOraclecommand.Parameters.Add(prm121);

                OracleParameter prm122 = new OracleParameter("mobileno", OracleType.VarChar);
                prm122.Direction = ParameterDirection.Input;
                prm122.Value = mobileno;
                objOraclecommand.Parameters.Add(prm122);

                OracleParameter prm123 = new OracleParameter("addlamt", OracleType.VarChar);
                prm123.Direction = ParameterDirection.Input;
                prm123.Value = addlamt;
                objOraclecommand.Parameters.Add(prm123);

                OracleParameter prm124 = new OracleParameter("retamt", OracleType.VarChar);
                prm124.Direction = ParameterDirection.Input;
                prm124.Value = retamt;
                objOraclecommand.Parameters.Add(prm124);

                OracleParameter prm125 = new OracleParameter("retper", OracleType.VarChar);
                prm125.Direction = ParameterDirection.Input;
                prm125.Value = retper;
                objOraclecommand.Parameters.Add(prm125);


                OracleParameter prm126 = new OracleParameter("cashrecieved", OracleType.VarChar);
                prm126.Direction = ParameterDirection.Input;
                if (cashrecieved == "" || cashrecieved == null)
                {
                    prm126.Value = System.DBNull.Value;
                }
                else
                {
                    prm126.Value = Convert.ToDecimal(cashrecieved);
                }
                objOraclecommand.Parameters.Add(prm126);

                OracleParameter prm127 = new OracleParameter("CIRAGENCY_V", OracleType.VarChar);
                prm127.Direction = ParameterDirection.Input;
                prm127.Value = ciragency;
                objOraclecommand.Parameters.Add(prm127);

                OracleParameter prm128 = new OracleParameter("CIRRATE_V", OracleType.VarChar);
                prm128.Direction = ParameterDirection.Input;
                prm128.Value = cirrate;
                objOraclecommand.Parameters.Add(prm128);

                OracleParameter prm129 = new OracleParameter("CIREDITION_V", OracleType.VarChar);
                prm129.Direction = ParameterDirection.Input;
                prm129.Value = ciredition;
                objOraclecommand.Parameters.Add(prm129);

                OracleParameter prm130 = new OracleParameter("CIRPUBLICATION_V", OracleType.VarChar);
                prm130.Direction = ParameterDirection.Input;
                prm130.Value = cirpublication;
                objOraclecommand.Parameters.Add(prm130);

                OracleParameter prm131 = new OracleParameter("CIRAGENCYSUBCODE_V", OracleType.VarChar);
                prm131.Direction = ParameterDirection.Input;
                prm131.Value = ciragencysubcode;
                objOraclecommand.Parameters.Add(prm131);

                OracleParameter prm132 = new OracleParameter("BARTERTYPE", OracleType.VarChar);
                prm132.Direction = ParameterDirection.Input;
                prm132.Value = bartertype;
                objOraclecommand.Parameters.Add(prm132);

                OracleParameter prm133 = new OracleParameter("CASHDISCOUNT_V", OracleType.VarChar);
                prm133.Direction = ParameterDirection.Input;
                if (cashdiscount == "")
                    prm133.Value = System.DBNull.Value;
                else
                    prm133.Value = cashdiscount;
                objOraclecommand.Parameters.Add(prm133);

                OracleParameter prm134 = new OracleParameter("CASHDISCOUNTPER_V", OracleType.VarChar);
                prm134.Direction = ParameterDirection.Input;
                prm134.Value = cashdiscountper;
                objOraclecommand.Parameters.Add(prm134);

                OracleParameter prm135 = new OracleParameter("attach1", OracleType.VarChar);
                prm135.Direction = ParameterDirection.Input;
                prm135.Value = attach1;
                objOraclecommand.Parameters.Add(prm135);

                OracleParameter prm136 = new OracleParameter("attach2", OracleType.VarChar);
                prm136.Direction = ParameterDirection.Input;
                prm136.Value = attach2;
                objOraclecommand.Parameters.Add(prm136);

                OracleParameter prm137 = new OracleParameter("drpdiscprem", OracleType.VarChar);
                prm137.Direction = ParameterDirection.Input;
                prm137.Value = drpdiscprem;
                objOraclecommand.Parameters.Add(prm137);

                OracleParameter prm138 = new OracleParameter("doctype_v", OracleType.VarChar);
                prm138.Direction = ParameterDirection.Input;
                prm138.Value = doctype;
                objOraclecommand.Parameters.Add(prm138);

                OracleParameter prm139 = new OracleParameter("CHKTRADE", OracleType.VarChar);
                prm139.Direction = ParameterDirection.Input;
                prm139.Value = chktradeval;
                objOraclecommand.Parameters.Add(prm139);

                OracleParameter prm140 = new OracleParameter("sharepub_p", OracleType.VarChar);
                prm140.Direction = ParameterDirection.Input;
                prm140.Value = sharepub;
                objOraclecommand.Parameters.Add(prm140);
                OracleParameter prm141 = new OracleParameter("fmginsert", OracleType.VarChar);
                prm141.Direction = ParameterDirection.Input;
                prm141.Value = fmginsert;
                objOraclecommand.Parameters.Add(prm141);


                OracleParameter prm142 = new OracleParameter("chkno", OracleType.VarChar);
                prm142.Direction = ParameterDirection.Input;
                prm142.Value = chkno;
                objOraclecommand.Parameters.Add(prm142);

                OracleParameter prm143 = new OracleParameter("chkdate", OracleType.DateTime);
                prm143.Direction = ParameterDirection.Input;
                if (chkdate == "" || chkdate == null)
                {
                    prm143.Value = System.DBNull.Value;

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
                    prm143.Value = Convert.ToDateTime(chkdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm143);

                OracleParameter prm144 = new OracleParameter("chkamt", OracleType.VarChar);
                prm144.Direction = ParameterDirection.Input;
                prm144.Value = chkamt;
                objOraclecommand.Parameters.Add(prm144);
                OracleParameter prm145 = new OracleParameter("chkbankname", OracleType.VarChar);
                prm145.Direction = ParameterDirection.Input;
                prm145.Value = chkbankname;
                objOraclecommand.Parameters.Add(prm145);

                OracleParameter prm146 = new OracleParameter("ourbank", OracleType.VarChar);
                prm146.Direction = ParameterDirection.Input;
                prm146.Value = ourbank;
                objOraclecommand.Parameters.Add(prm146);

                OracleParameter prm147 = new OracleParameter("DEALERPANEL_P", OracleType.VarChar);
                prm147.Direction = ParameterDirection.Input;
                if (dealerpanel == "")
                    prm147.Value = System.DBNull.Value;
                else
                    prm147.Value = dealerpanel;
                objOraclecommand.Parameters.Add(prm147);

                OracleParameter prm148 = new OracleParameter("DEALERH_P", OracleType.VarChar);
                prm148.Direction = ParameterDirection.Input;
                if (dealerh == "")
                    prm148.Value = System.DBNull.Value;
                else
                    prm148.Value = dealerh;
                objOraclecommand.Parameters.Add(prm148);

                OracleParameter prm149 = new OracleParameter("DEALERW_P", OracleType.VarChar);
                prm149.Direction = ParameterDirection.Input;
                if (dealerw == "")
                    prm149.Value = System.DBNull.Value;
                else
                    prm149.Value = dealerw;
                objOraclecommand.Parameters.Add(prm149);

                OracleParameter prm150 = new OracleParameter("DEALERTYPE_P", OracleType.VarChar);
                prm150.Direction = ParameterDirection.Input;
                if (dealertype == "")
                    prm150.Value = System.DBNull.Value;
                else
                    prm150.Value = dealertype;
                objOraclecommand.Parameters.Add(prm150);

                OracleParameter prm151 = new OracleParameter("multiselect", OracleType.VarChar);
                prm151.Direction = ParameterDirection.Input;
                if (multicode == "")
                    prm151.Value = System.DBNull.Value;
                else
                    prm151.Value = multicode;
                objOraclecommand.Parameters.Add(prm151);

                OracleParameter prm152 = new OracleParameter("AGREEDRATE_ACTIVE", OracleType.VarChar);
                prm152.Direction = ParameterDirection.Input;
                if (agreedrate_active == "")
                    prm152.Value = System.DBNull.Value;
                else
                    prm152.Value = agreedrate_active;

                objOraclecommand.Parameters.Add(prm152);

                OracleParameter prm153 = new OracleParameter("AGREEDAMT_ACTIVE", OracleType.VarChar);
                prm153.Direction = ParameterDirection.Input;
                if (agreedamt_active == "")
                    prm153.Value = System.DBNull.Value;
                else
                    prm153.Value = agreedamt_active;

                objOraclecommand.Parameters.Add(prm153);

                OracleParameter prm154 = new OracleParameter("grossamtlocal_p", OracleType.VarChar);
                prm154.Direction = ParameterDirection.Input;
                if (grossamtlocal_p == "")
                    prm154.Value = System.DBNull.Value;
                else
                    prm154.Value = grossamtlocal_p;

                objOraclecommand.Parameters.Add(prm154);

                OracleParameter prm155 = new OracleParameter("billamtlocal_p", OracleType.VarChar);
                prm155.Direction = ParameterDirection.Input;
                if (billamtlocal_p == "")
                    prm155.Value = System.DBNull.Value;
                else
                    prm155.Value = billamtlocal_p;

                objOraclecommand.Parameters.Add(prm155);


                OracleParameter prm145a = new OracleParameter("chkadon_p", OracleType.VarChar);
                prm145a.Direction = ParameterDirection.Input;
                prm145a.Value = chkadon;
                objOraclecommand.Parameters.Add(prm145a);

                OracleParameter prm145b = new OracleParameter("refid_p", OracleType.VarChar);
                prm145b.Direction = ParameterDirection.Input;
                prm145b.Value = refid;
                objOraclecommand.Parameters.Add(prm145b);


                OracleParameter prm145c = new OracleParameter("rcpt_currency", OracleType.VarChar);
                prm145c.Direction = ParameterDirection.Input;
                prm145c.Value = rcpt_currency;
                objOraclecommand.Parameters.Add(prm145c);

                OracleParameter prm145d = new OracleParameter("cur_convrate", OracleType.VarChar);
                prm145d.Direction = ParameterDirection.Input;
                prm145d.Value = cur_convrate;
                objOraclecommand.Parameters.Add(prm145d);

                OracleParameter prm145e = new OracleParameter("p_revisedate", OracleType.VarChar);
                prm145e.Direction = ParameterDirection.Input;
                if (revisedate == "" || revisedate == null)
                {
                    prm145e.Value = System.DBNull.Value;

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
                    prm145e.Value = Convert.ToDateTime(revisedate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm145e);

                OracleParameter prm155a = new OracleParameter("clienttype", OracleType.VarChar);
                prm155a.Direction = ParameterDirection.Input;
                if (clienttype == "0")
                    prm155a.Value = System.DBNull.Value;
                else
                    prm155a.Value = clienttype;
                objOraclecommand.Parameters.Add(prm155a);

                OracleParameter prm153e = new OracleParameter("translation", OracleType.VarChar);
                prm153e.Direction = ParameterDirection.Input;
                if (translation == "0")
                    prm153e.Value = System.DBNull.Value;
                else
                    prm153e.Value = translation;
                objOraclecommand.Parameters.Add(prm153e);

                OracleParameter prm107a = new OracleParameter("translationcharge", OracleType.Number);
                prm107a.Direction = ParameterDirection.Input;
                if (translationcharge == "" || translationcharge == null)
                {
                    prm107a.Value = System.DBNull.Value;
                }
                else
                {
                    translationcharge = translationcharge.Replace("%", "");
                    prm107a.Value = Convert.ToDecimal(translationcharge);
                }
                objOraclecommand.Parameters.Add(prm107a);

                OracleParameter prm141a = new OracleParameter("fmgreasons", OracleType.VarChar);
                prm141a.Direction = ParameterDirection.Input;
                prm141a.Value = fmgreasons;
                objOraclecommand.Parameters.Add(prm141a);

                OracleParameter prm141b = new OracleParameter("canclecharge", OracleType.VarChar);
                prm141b.Direction = ParameterDirection.Input;
                prm141b.Value = canclecharge;
                objOraclecommand.Parameters.Add(prm141b);

                OracleParameter prm151b = new OracleParameter("P_ip", OracleType.VarChar);
                prm151b.Direction = ParameterDirection.Input;
                prm151b.Value = ip;
                objOraclecommand.Parameters.Add(prm151b);

                OracleParameter prm161b = new OracleParameter("P_RATE_AUDIT_FLAG", OracleType.VarChar);
                prm161b.Direction = ParameterDirection.Input;
                prm161b.Value = modifyrateaudit;
                objOraclecommand.Parameters.Add(prm161b);

                OracleParameter prm161bt = new OracleParameter("transdisc_p", OracleType.VarChar);
                prm161bt.Direction = ParameterDirection.Input;
                prm161bt.Value = transdisc;
                objOraclecommand.Parameters.Add(prm161bt);

                OracleParameter prm161bs = new OracleParameter("pospremdisc_p", OracleType.VarChar);
                prm161bs.Direction = ParameterDirection.Input;
                prm161bs.Value = pospremdisc;
                objOraclecommand.Parameters.Add(prm161bs);

                OracleParameter prm161b1 = new OracleParameter("billhold", OracleType.VarChar);
                prm161b1.Direction = ParameterDirection.Input;
                prm161b1.Value = billhold;
                objOraclecommand.Parameters.Add(prm161b1);

                OracleParameter prm161b1x = new OracleParameter("designbox", OracleType.VarChar);
                prm161b1x.Direction = ParameterDirection.Input;
                prm161b1x.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm161b1x);

                OracleParameter prm161b1z = new OracleParameter("logoprem", OracleType.VarChar);
                prm161b1z.Direction = ParameterDirection.Input;
                prm161b1z.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm161b1z);

                OracleParameter prm161b1az = new OracleParameter("online_ad_p", OracleType.VarChar);
                prm161b1az.Direction = ParameterDirection.Input;
                prm161b1az.Value = online_ad;
                objOraclecommand.Parameters.Add(prm161b1az);


                OracleParameter prm161b1az1 = new OracleParameter("pfixed_booking", OracleType.VarChar);
                prm161b1az1.Direction = ParameterDirection.Input;
                prm161b1az1.Value = fixed_booking;
                objOraclecommand.Parameters.Add(prm161b1az1);


                OracleParameter prm161b1az12 = new OracleParameter("pvat_code", OracleType.VarChar);
                prm161b1az12.Direction = ParameterDirection.Input;
                prm161b1az12.Value = vat_code;
                objOraclecommand.Parameters.Add(prm161b1az12);

                OracleParameter prm161b1az13 = new OracleParameter("CPN_CODE_P", OracleType.VarChar);
                prm161b1az13.Direction = ParameterDirection.Input;
                prm161b1az13.Value = cou_code;
                objOraclecommand.Parameters.Add(prm161b1az13);

                OracleParameter prm161b1az14 = new OracleParameter("CPN_NAME_P", OracleType.VarChar);
                prm161b1az14.Direction = ParameterDirection.Input;
                prm161b1az14.Value = cou_name;
                objOraclecommand.Parameters.Add(prm161b1az14);

                OracleParameter prm161b1az14A = new OracleParameter("STATE_P", OracleType.VarChar);
                prm161b1az14A.Direction = ParameterDirection.Input;
                prm161b1az14A.Value = state;
                objOraclecommand.Parameters.Add(prm161b1az14A);

                OracleParameter prm161z = new OracleParameter("clientcatdisc", OracleType.Number);
                prm161z.Direction = ParameterDirection.Input;
                if (clientcatdisc == "" || clientcatdisc == "0" || clientcatdisc == "null")
                {
                    prm161z.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z.Value = clientcatdisc;
                }
                objOraclecommand.Parameters.Add(prm161z);

                OracleParameter prm161z1 = new OracleParameter("clientcatamt", OracleType.Number);
                prm161z1.Direction = ParameterDirection.Input;
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    prm161z1.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z1.Value = clientcatamt;
                }
                objOraclecommand.Parameters.Add(prm161z1);

                OracleParameter prm161z2 = new OracleParameter("clientcatdistype", OracleType.VarChar);
                prm161z2.Direction = ParameterDirection.Input;
                prm161z2.Value = clientcatdistype;
                objOraclecommand.Parameters.Add(prm161z2);


                OracleParameter prm161z3 = new OracleParameter("flatfreqdisc", OracleType.Number);
                prm161z3.Direction = ParameterDirection.Input;
                if (flatfreqdisc == "" || flatfreqdisc == "0" || flatfreqdisc == "null")
                {
                    prm161z3.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z3.Value = flatfreqdisc;
                }
                objOraclecommand.Parameters.Add(prm161z3);



                OracleParameter prm161z4 = new OracleParameter("flatfreqamt", OracleType.Number);
                prm161z4.Direction = ParameterDirection.Input;
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    prm161z4.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z4.Value = flatfreqamt;
                }
                objOraclecommand.Parameters.Add(prm161z4);




                OracleParameter prm161z5 = new OracleParameter("flatfreqdisctype", OracleType.VarChar);
                prm161z5.Direction = ParameterDirection.Input;
                prm161z5.Value = flatfreqdisctype;
                objOraclecommand.Parameters.Add(prm161z5);

                OracleParameter prm161z6 = new OracleParameter("catdisc", OracleType.Number);
                prm161z6.Direction = ParameterDirection.Input;
                if (catdisc == "" || catdisc == "0" || catdisc == "null")
                {
                    prm161z6.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z6.Value = catdisc;
                }
                objOraclecommand.Parameters.Add(prm161z6);

                OracleParameter prm161z7 = new OracleParameter("catamt", OracleType.Number);
                prm161z7.Direction = ParameterDirection.Input;
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    prm161z7.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z7.Value = catamt;
                }
                objOraclecommand.Parameters.Add(prm161z7);

                OracleParameter prm161z8 = new OracleParameter("catdisctype", OracleType.VarChar);
                prm161z8.Direction = ParameterDirection.Input;
                prm161z8.Value = catdisctype;
                objOraclecommand.Parameters.Add(prm161z8);

                OracleParameter prm161z9 = new OracleParameter("representative_p", OracleType.VarChar);
                prm161z9.Direction = ParameterDirection.Input;
                if (representative == "" || representative == "0" || representative == "null")
                {
                    prm161z9.Value = System.DBNull.Value;
                }
                else
                {
                    prm161z9.Value = representative;
                }
                objOraclecommand.Parameters.Add(prm161z9);

                OracleParameter prm161w = new OracleParameter("teamcode", OracleType.VarChar);
                prm161w.Direction = ParameterDirection.Input;
                prm161w.Value = teamcode;
                objOraclecommand.Parameters.Add(prm161w);

                OracleParameter prm161w1 = new OracleParameter("pindustry", OracleType.VarChar);
                prm161w1.Direction = ParameterDirection.Input;
                prm161w1.Value = industry;
                objOraclecommand.Parameters.Add(prm161w1);

                OracleParameter prm161w2 = new OracleParameter("pproductcat", OracleType.VarChar);
                prm161w2.Direction = ParameterDirection.Input;
                prm161w2.Value = productcat;
                objOraclecommand.Parameters.Add(prm161w2);

                OracleParameter prm161w4 = new OracleParameter("chkgstinc", OracleType.VarChar);
                prm161w4.Direction = ParameterDirection.Input;
                prm161w4.Value = chkgstinc;
                objOraclecommand.Parameters.Add(prm161w4);

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
        public DataSet cancelbooking(string prevbookingid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("cancelbooking.cancelbooking_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm6 = new OracleParameter("prevbook", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = prevbookingid;
                objOraclecommand.Parameters.Add(prm6);

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
        public DataSet bindprodyc(string brand, string Compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("AN_PRODUCT.AN_bindproductcat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Compcode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("indus", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = brand;
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
        public DataSet branchbind(string compcode, string useid, string centercd, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_branchwithemail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top2 = new OracleParameter("p_comp_code", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = compcode;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("p_userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = useid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_centercd", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centercd;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("p_extra1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_extra2", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra2;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("p_extra3", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra3;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("p_extra4", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra4;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("p_extra5", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra5;
                objOraclecommand.Parameters.Add(prm7);

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
        public DataSet mailsave(string cioid, string compcode, string mailcenter, string mailbranch, string mailid, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("savebookingmaildetails", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcioid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm21 = new OracleParameter("pmailcenter", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = mailcenter;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pmailbranch", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = mailbranch;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pmailid", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = mailid;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("puserid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = userid;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra2;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra3", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra3;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra4", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra4;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra5", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra5;
                objOraclecommand.Parameters.Add(prm7);


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

        public DataSet executebooking(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking, string dateformat, string revenue)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("executebookingdisp_q.executebookingdisp_q_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobookid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("docno", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = docno;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm6 = new OracleParameter("keyno", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = keyno;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm5 = new OracleParameter("rono", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = rono;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("agencycode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencycode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("client", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = client;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("booking", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = booking;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("revenue", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = revenue;
                objOraclecommand.Parameters.Add(prm10);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("P_Accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts3"].Direction = ParameterDirection.Output;


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
        public DataSet getPackageInsert(string pckcode, string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("getPackageInsert_q.getPackageInsert_q_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pckcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("cioid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cioid;
                objOraclecommand.Parameters.Add(prm3);

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
        public DataSet fetchdataforexe1_q(string ciobid, string compcode)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("getdataforexecute1_q.getdataforexecute1_q_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("ciobid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobid;
                objOraclecommand.Parameters.Add(prm2);
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


                objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts7", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts7"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts8", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts8"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts9", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts9"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts10", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts10"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts11", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts11"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts12", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts12"].Direction = ParameterDirection.Output;


                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}

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
        public DataSet fetchdataforexe(string ciobid, string compcode)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("getdataforexecute_q.getdataforexecute_q_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("ciobid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobid;
                objOraclecommand.Parameters.Add(prm2);
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


                objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts7", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts7"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts8", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts8"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts9", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts9"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts10", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts10"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts11", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts11"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts12", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts12"].Direction = ParameterDirection.Output;


                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}

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
        public string commitT(int count, string cioid, string pcompcode, string pcentname, string puserid, string pbkid_gentype, string pbk_type, string quotation, string clientcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("committransaction", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("totalcount", OracleType.Int32);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = count;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcioid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cioid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pcentname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pcentname;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("puserid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = puserid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pbkid_gentype", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pbkid_gentype;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pbk_type", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pbk_type;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pquotation", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = quotation;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm81 = new OracleParameter("pclientcode", OracleType.VarChar);
                prm81.Direction = ParameterDirection.Input;
                prm81.Value = clientcode;
                objOraclecommand.Parameters.Add(prm81);

                objOraclecommand.Parameters.Add("p_error", OracleType.VarChar, 200);
                objOraclecommand.Parameters["p_error"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_new_cioid", OracleType.VarChar, 200);
                objOraclecommand.Parameters["p_new_cioid"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                //objOraclecommand.ExecuteNonQuery();
                string output = objOraclecommand.Parameters["p_error"].Value.ToString() + "$~$" + objOraclecommand.Parameters["p_new_cioid"].Value.ToString();


                return output;

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
