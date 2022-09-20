using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for BoxMaster
    /// </summary>
    public class BoxMaster : orclconnection
    {
        public BoxMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet getedition()
        {
            OracleConnection objOracleConnection;
                OracleCommand objOraclecommand;
                DataSet objDataSet = new DataSet();
                objOracleConnection = GetConnection();

                OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getedition.getedition_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet savebox(string boxcode, string boxname, string alias, string dispatch, string boxcharge, string native1, string inter, string fromdate, string todate, string remarks, string compcode, string userid, string pubcenter, string dateformat, string inc_matter)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("boxsave.boxsave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("boxcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = boxcode;
                objOraclecommand.Parameters.Add(prm1);
                

                OracleParameter prm2 = new OracleParameter("boxname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value =boxname ;
                objOraclecommand.Parameters.Add(prm2);
               
                 OracleParameter prm3 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value =alias ;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("dispatch", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value =dispatch ;
                objOraclecommand.Parameters.Add(prm4);
                
                OracleParameter prm5 = new OracleParameter("boxcharge", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value =boxcharge ;
                objOraclecommand.Parameters.Add(prm5);
               
                OracleParameter prm9 = new OracleParameter("native1", OracleType.VarChar, 50);
                 prm9.Direction = ParameterDirection.Input;
                 if (native1 == null || native1 == "")
                 {

                     prm9.Value = System.DBNull.Value;
                 }
                 else
                 {
                     prm9.Value = Convert.ToDecimal(native1);
                 }

                 objOraclecommand.Parameters.Add(prm9);

                 OracleParameter prm10 = new OracleParameter("inter", OracleType.VarChar, 50);
                 prm10.Direction = ParameterDirection.Input;
                 if (inter == null || inter == "" || inter == "NaN")
                 {

                     prm10.Value = System.DBNull.Value;
                 }
                 else
                 {
                     prm10.Value = Convert.ToDecimal(inter);
                 }

                 objOraclecommand.Parameters.Add(prm10);

                 OracleParameter prm6 = new OracleParameter("fromdate", OracleType.DateTime , 50);
                 prm6.Direction = ParameterDirection.Input;
                 if (fromdate == "" || fromdate == null || fromdate == "undefined/undefined/")
                 {
                     prm6.Value = System.DBNull.Value;

                 }
                else
                 {
                     //if (dateformat == "dd/mm/yyyy")
                     //{
                     //    string[] arr = fromdate.Split('/');
                     //    string dd = arr[0];
                     //    string mm = arr[1];
                     //    string yy = arr[2];
                     //    fromdate = mm + "/" + dd + "/" + yy;


                     //}

                     prm6.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                 }
                
                 objOraclecommand.Parameters.Add(prm6);

                 OracleParameter prm11 = new OracleParameter("todate", OracleType.DateTime, 50);
                 prm11.Direction = ParameterDirection.Input;

                 if (todate == "" || todate == null || todate == "undefined/undefined/")
                 {
                     prm11.Value = System.DBNull.Value;

                 }
                
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = todate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    todate = mm + "/" + dd + "/" + yy;


                    //}

                  prm11.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                   
                 objOraclecommand.Parameters.Add(prm11);

             

               
                OracleParameter prm16 = new OracleParameter("remarks", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = remarks;

                objOraclecommand.Parameters.Add(prm16);
                
                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);
                

                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm_pub_cent = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm_pub_cent.Direction = ParameterDirection.Input;
                prm_pub_cent.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm_pub_cent);


                OracleParameter inc_matter1 = new OracleParameter("pincwordmatter", OracleType.VarChar, 50);
                inc_matter1.Direction = ParameterDirection.Input;
                inc_matter1.Value = inc_matter;
                objOraclecommand.Parameters.Add(inc_matter1);
              


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
        public DataSet autocode(string str, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();


            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("boxautocode.boxautocode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm7 = new OracleParameter("str", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = str;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm = new OracleParameter("cod", OracleType.VarChar, 50);
                prm.Direction = ParameterDirection.Input;

                if (str.Length > 2)
                {
                    prm.Value = str.Substring(0, 2);
                }
                else
                {
                   prm.Value = str;
                }
                objOraclecommand.Parameters.Add(prm);

                OracleParameter prm2 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                //objmysqlDataAdapter = new objmysqlDataAdapter();
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }


        public DataSet updatebox(string boxcode, string boxname, string alias, string dispatch, string boxcharge, string native1, string inter, string fromdate, string todate, string remarks, string compcode, string userid, string pubcenter,string inc_matter)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("boxupdate.boxupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("boxcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = boxcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("boxname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = boxname;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = alias;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("dispatch", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dispatch;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("boxcharge", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = boxcharge;
                objOraclecommand.Parameters.Add(prm5);

                
           


                OracleParameter prm9 = new OracleParameter("native1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (native1 == null || native1 == "" )
                {

                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = Convert.ToDecimal(native1);
                }

                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("inter", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (inter == null || inter == "" || inter=="NaN")
                {

                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = Convert.ToDecimal(inter);
                }

                objOraclecommand.Parameters.Add(prm10);
                //OracleParameter prm7 = new OracleParameter("str", OracleType.VarChar, 50);
                //prm7.Direction = ParameterDirection.Input;
                //prm7.Value = str;
                //objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.DateTime, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert.ToDateTime(fromdate);
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm11 = new OracleParameter("todate", OracleType.DateTime, 50);
                prm11.Direction = ParameterDirection.Input;

                if (todate == "" || todate == null || todate == "undefined/undefined/")
                {
                    prm11.Value = System.DBNull.Value;

                }
                else
                {
                    prm11.Value = Convert.ToDateTime(todate);
                }

                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm16 = new OracleParameter("remarks", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = remarks;

                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);
                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                OracleParameter prm_pub_cent = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm_pub_cent.Direction = ParameterDirection.Input;
                prm_pub_cent.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm_pub_cent);

                OracleParameter ins_matter1 = new OracleParameter("pincwordmatter", OracleType.VarChar, 50);
                ins_matter1.Direction = ParameterDirection.Input;
                ins_matter1.Value = inc_matter;
                objOraclecommand.Parameters.Add(ins_matter1);


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


        public DataSet boxexe(string boxcode, string boxname, string alias, string boxcharge, string compcode, string userid, string pubcenter)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("boxexe.boxexe_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("boxcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = boxcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("boxname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = boxname;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = alias;
                objOraclecommand.Parameters.Add(prm3);







            

                OracleParameter prm5 = new OracleParameter("boxcharge", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = boxcharge;
                objOraclecommand.Parameters.Add(prm5);





                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (pubcenter == "0")
                    prm9.Value = System.DBNull.Value;
                else
                    prm9.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm9);

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



        public DataSet boxdel(string boxcode, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("boxdelete.boxdelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

               


                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm1 = new OracleParameter("boxcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = boxcode;
                objOraclecommand.Parameters.Add(prm1);

            






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

        public DataSet boxfnpl(string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("boxfnpl.boxfnpl_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);




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


        public DataSet boxchk(string boxcode, string boxname, string compcode, string userid, string pubcenter)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("boxchk.boxchk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm7 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm1 = new OracleParameter("Boxcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = boxcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("boxname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = boxname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("Userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm9);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

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


        public DataSet modifychk(string boxcode, string boxname, string compcode, string userid, string pubcenter)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("modifychk.modifychk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm1 = new OracleParameter("boxcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = boxcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm18 = new OracleParameter("boxname", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = boxname;
                objOraclecommand.Parameters.Add(prm18);



                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm9);

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
                objOracleConnection.Close();
            }


        }



        // public DataSet chklogin(string username, string password)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();

        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("Websp_LoginEmployee.Websp_LoginEmployee_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;
        //        OracleParameter prm1 = new OracleParameter("vusername", OracleType.VarChar, 50);
        //        prm1.Direction = ParameterDirection.Input ;
        //        prm1.Value = username;
        //        objOraclecommand.Parameters.Add(prm1);
        //        OracleParameter prm2 = new OracleParameter("vpassword", OracleType.VarChar, 50);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = password;
        //        objOraclecommand.Parameters.Add(prm2);
        //        OracleParameter prm3 = new OracleParameter("vqbc", OracleType.VarChar, 50);
        //        prm3.Direction = ParameterDirection.Input;
        //        prm3.Value = System.DBNull.Value;
        //        objOraclecommand.Parameters.Add(prm3);
        //        objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
        //        objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


        //        objorclDataAdapter.SelectCommand = objOraclecommand;
        //        objorclDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }
        //    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        objOracleConnection.Close();
        //    }


    }
}