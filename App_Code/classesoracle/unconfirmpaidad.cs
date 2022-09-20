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
/// Summary description for unconfirmpaidad
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class unconfirmpaidad : orclconnection
    {
        public unconfirmpaidad()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindgrid(string dateformat, string tilldate, string fromdate, string agency, string flag, string rostatus, string center, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindaudit_ht.bindaudit_ht_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("date1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dateformat;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] tilldatearr = tilldate.Split('/');
                    string dd1 = tilldatearr[0].ToString();
                    string mm1 = tilldatearr[1].ToString();
                    string yy1 = tilldatearr[2].ToString();
                    tilldate = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm2.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] fromdatearr = fromdate.Split('/');
                    string dd1 = fromdatearr[0].ToString();
                    string mm1 = fromdatearr[1].ToString();
                    string yy1 = fromdatearr[2].ToString();
                    fromdate = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy"); ;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm5 = new OracleParameter("agency", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (agency == "" || agency == null)
                    prm5.Value = "0";
                else
                    prm5.Value = agency;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("flag", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = flag;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("rostatus", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = rostatus;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("center", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = center;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adtype1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adtype;
                objOraclecommand.Parameters.Add(prm9);

                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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
       
        public DataSet executeauditmast1(string bookingid, string compcode, string adtype,string dateformat,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executebooking.executebooking_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bookingid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("booking", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adtype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("docno", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("keyno", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("rono", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("agencycode", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("client", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("revenue", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = userid;
                objOraclecommand.Parameters.Add(prm10);

               

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts3"].Direction = ParameterDirection.Output;

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


        public DataSet update1(string booking_id,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updaterostatusbillpay.updaterostatusbillpay_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = booking_id;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
               // objOraclecommand.ExecuteNonQuery();

                //objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                //objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;



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

        public DataSet update2(string booking_id)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getmail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = booking_id;
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
        //public DataSet updatestatus(string bookingid, string insertion, string edition)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("updatestaus.updatestaus_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm4 = new OracleParameter("ciobookid", OracleType.VarChar);
        //        prm4.Direction = ParameterDirection.Input;
        //        prm4.Value = bookingid;
        //        objOraclecommand.Parameters.Add(prm4);

        //        OracleParameter prm7 = new OracleParameter("insertion", OracleType.VarChar);
        //        prm7.Direction = ParameterDirection.Input;
        //        prm7.Value = insertion;
        //        objOraclecommand.Parameters.Add(prm7);


        //        OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar);
        //        prm6.Direction = ParameterDirection.Input;
        //        prm6.Value = edition;
        //        objOraclecommand.Parameters.Add(prm6);



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
        //        objOracleConnection.Close();
        //    }

        //}
        public DataSet bindsh( string userid,string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindschhead", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
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
                objOracleConnection.Close();
            }
        }
        //public DataSet websp_bindgrid(string dateformat, string tilldate, string fromdate, string branch, string adtype, string publication, string pub_cent, string edition, string agency, string client, string branchnew)
        //{


        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {

        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("websp_bindaudit.websp_bindaudit_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;




        //        OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar);
        //        prm4.Direction = ParameterDirection.Input;
        //        prm4.Value = dateformat;
        //        objOraclecommand.Parameters.Add(prm4);

        //        OracleParameter prm5 = new OracleParameter("fromdate", OracleType.VarChar);
        //        prm5.Direction = ParameterDirection.Input;



        //        if (dateformat == "dd/mm/yyyy")
        //        {
        //            string[] arr = fromdate.Split('/');
        //            string dd = arr[0];
        //            string mm = arr[1];
        //            string yy = arr[2];

        //            fromdate = mm + "/" + dd + "/" + yy;


        //        }

        //        prm5.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
        //        objOraclecommand.Parameters.Add(prm5);

        //        OracleParameter prm6 = new OracleParameter("todate", OracleType.VarChar);
        //        prm6.Direction = ParameterDirection.Input;

        //        if (dateformat == "dd/mm/yyyy")
        //        {
        //            string[] arr = tilldate.Split('/');
        //            string dd = arr[0];
        //            string mm = arr[1];
        //            string yy = arr[2];
        //            tilldate = mm + "/" + dd + "/" + yy;


        //        }

        //        prm6.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
        //        objOraclecommand.Parameters.Add(prm6);


        //        OracleParameter prm7 = new OracleParameter("branch", OracleType.VarChar);
        //        prm7.Direction = ParameterDirection.Input;
        //        prm7.Value = System.DBNull.Value;
        //        objOraclecommand.Parameters.Add(prm7);

        //        OracleParameter prm8 = new OracleParameter("adtype", OracleType.VarChar);
        //        prm8.Direction = ParameterDirection.Input;
        //        prm8.Value = adtype;
        //        objOraclecommand.Parameters.Add(prm8);

        //        /////

        //        OracleParameter prm9 = new OracleParameter("publication", OracleType.VarChar);
        //        prm9.Direction = ParameterDirection.Input;
        //        if (publication == "0")
        //        {
        //            prm9.Value = System.DBNull.Value;

        //        }
        //        else
        //        {
        //            prm9.Value = publication;
        //        }
        //        objOraclecommand.Parameters.Add(prm9);

        //        OracleParameter prm10 = new OracleParameter("pub_cent", OracleType.VarChar);
        //        prm10.Direction = ParameterDirection.Input;
        //        if (pub_cent == "0")
        //        {
        //            prm10.Value = System.DBNull.Value;

        //        }
        //        else
        //        {
        //            prm10.Value = pub_cent;
        //        }
        //        objOraclecommand.Parameters.Add(prm10);


        //        OracleParameter prm18 = new OracleParameter("edition", OracleType.VarChar);
        //        prm18.Direction = ParameterDirection.Input;
        //        if (edition == "0")
        //        {
        //            prm18.Value = System.DBNull.Value;

        //        }
        //        else
        //        {
        //            prm18.Value = edition;
        //        }
        //        objOraclecommand.Parameters.Add(prm18);

        //        OracleParameter prm28 = new OracleParameter("agency", OracleType.VarChar);
        //        prm28.Direction = ParameterDirection.Input;
        //        if (agency == "0")
        //        {
        //            prm28.Value = System.DBNull.Value;

        //        }
        //        else
        //        {
        //            prm28.Value = agency;
        //        }
        //        objOraclecommand.Parameters.Add(prm28);

        //        OracleParameter prm38 = new OracleParameter("client", OracleType.VarChar);
        //        prm38.Direction = ParameterDirection.Input;
        //        if (client == "0")
        //        {
        //            prm38.Value = System.DBNull.Value;

        //        }
        //        else
        //        {

        //            prm38.Value = client;
        //        }
        //        objOraclecommand.Parameters.Add(prm38);

        //        OracleParameter prm48 = new OracleParameter("branchnew", OracleType.VarChar);
        //        prm48.Direction = ParameterDirection.Input;
        //        if (branchnew == "")
        //        {
        //            prm48.Value = System.DBNull.Value;

        //        }
        //        else
        //        {
        //            prm48.Value = branchnew;
        //        }
        //        objOraclecommand.Parameters.Add(prm48);


        //        ////


        //        objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


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
        //        objOracleConnection.Close();
        //    }
        //}

        ////*********************************************************************************************************
        //public DataSet executeauditmast2(string bookingid, string compcode, string edition, string insertion)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("executebooking2.executebooking2_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm4 = new OracleParameter("ciobookid", OracleType.VarChar);
        //        prm4.Direction = ParameterDirection.Input;
        //        prm4.Value = bookingid;
        //        objOraclecommand.Parameters.Add(prm4);

        //        OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
        //        prm5.Direction = ParameterDirection.Input;
        //        prm5.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm5);


        //        OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar);
        //        prm6.Direction = ParameterDirection.Input;
        //        prm6.Value = edition;
        //        objOraclecommand.Parameters.Add(prm6);

        //        OracleParameter prm7 = new OracleParameter("insertion", OracleType.VarChar);
        //        prm7.Direction = ParameterDirection.Input;
        //        prm7.Value = insertion;
        //        objOraclecommand.Parameters.Add(prm7);

        //        objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


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
        //        objOracleConnection.Close();
        //    }

        //}
        //public DataSet bindbranch()
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("bind_branch.bind_branch_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;



        //        objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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

        




        //public DataSet unaudit(string booking_id, string auditname)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("unauditbooking.unauditbooking_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = booking_id;
        //        objOraclecommand.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("auditname", OracleType.VarChar);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = auditname;
        //        objOraclecommand.Parameters.Add(prm2);
        //        objOraclecommand.ExecuteNonQuery();

        //        //objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
        //        //objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;



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



        //public DataSet save1(string remarks, string cioid)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("saveremark5.saveremark5_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("remarks", OracleType.VarChar);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = remarks;
        //        objOraclecommand.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("cioid", OracleType.VarChar);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = cioid;
        //        objOraclecommand.Parameters.Add(prm2);
        //        objOraclecommand.ExecuteNonQuery();

        //        //objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
        //        //objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;



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

        //public void updateaudit(string cioid, string auditname)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("updateauditbooking.updateauditbooking_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = cioid;
        //        objOraclecommand.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("auditname", OracleType.VarChar);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = auditname;
        //        objOraclecommand.Parameters.Add(prm2);
        //        objOraclecommand.ExecuteNonQuery();

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

        //public DataSet fetchMatter(string cioid, string uomdesc)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("websp_fetchmatter.websp_fetchmatter_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("cioid1", OracleType.VarChar);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = cioid;
        //        objOraclecommand.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("uomdesc", OracleType.VarChar);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = uomdesc;
        //        objOraclecommand.Parameters.Add(prm2);


        //        objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        //public DataSet adtypbind(string compcode)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("advtypbind.advtypbind_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm1);

        //        objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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

    }
}
