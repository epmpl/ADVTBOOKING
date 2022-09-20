using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.OracleClient;

/// <summary>
/// Summary description for pending_for_dummy
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class pending_for_dummy : orclconnection
    {
        public pending_for_dummy()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        //public DataSet packagebind_NEW(string compcode, string userid)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("Bindpackage_NEW.Bindpackage_NEW_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm1);



        //        OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = userid;
        //        objOraclecommand.Parameters.Add(prm2);

        //        objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


        //        objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
        //        objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;





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


        public DataSet adtypbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advtypbind.advtypbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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



        public DataSet pubsupply(string comcode, string edit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindsuppliment.bindsuppliment_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = comcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edit;
                objOraclecommand.Parameters.Add(prm4);
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
                objOracleConnection.Close();
            }
        }





        public DataSet bindgrid(string compcode, string pubcenter, string adtype, string pubfrdate, string pubtodate, string publcode, string edtncode, string suplcode, string reason, string dateformat, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pending_for_dummy", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppubcenter", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (pubcenter == "All")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = pubcenter;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("padtype", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (adtype == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("ppubfrdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] tilldatearr = pubfrdate.Split('/');
                    string dd1 = tilldatearr[0].ToString();
                    string mm1 = tilldatearr[1].ToString();
                    string yy1 = tilldatearr[2].ToString();
                    pubfrdate = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm4.Value = Convert.ToDateTime(pubfrdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm41 = new OracleParameter("ppubtodate", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] tilldatearr = pubtodate.Split('/');
                    string dd1 = tilldatearr[0].ToString();
                    string mm1 = tilldatearr[1].ToString();
                    string yy1 = tilldatearr[2].ToString();
                    pubtodate = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm41.Value = Convert.ToDateTime(pubtodate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm41);
                
                ////if (pubdate == "")
                ////{
                ////    prm4.Value = System.DBNull.Value;
                ////}
                ////else
                ////{
                ////    prm4.Value = pubdate;
                ////}
                //objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ppublcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (publcode == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = publcode;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pedtncode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (edtncode == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = edtncode;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("psuplcode", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (suplcode == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = suplcode;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("preason", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (reason == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = reason;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (dateformat == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = dateformat;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("puserid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (userid == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = userid;
                }
                objOraclecommand.Parameters.Add(prm10);

              
                OracleParameter prm11 = new OracleParameter("pextra1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

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



    }
}
