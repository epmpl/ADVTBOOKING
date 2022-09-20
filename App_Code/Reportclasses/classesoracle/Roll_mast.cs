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
/// Summary description for Roll_mast
/// </summary>
namespace NewAdbooking.Report.classesoracle
{
    public class Roll_mast:orclconnection
    {
        public Roll_mast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet chkclnt(string compcode, string rono, string pubdt, string dateformate)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("AN_CLINTNAME.AN_clientcod_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("pubdt", OracleType.VarChar);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = pubdt;
                //objorclcmd.Parameters.Add(prm2);

                OracleParameter prm33 = new OracleParameter("pubdt", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (pubdt == "" || pubdt == null)
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = pubdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdt = mm + "/" + dd + "/" + yy;


                    }
                    prm33.Value = Convert.ToDateTime(pubdt).ToString("dd-MMMM-yyyy");
                }
                objorclcmd.Parameters.Add(prm33);


                OracleParameter prm3 = new OracleParameter("rono", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = rono;
                objorclcmd.Parameters.Add(prm3);

                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }

        public DataSet rolautocode(string str)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pam_rolgencode.pam_rolgencode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("str", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("cod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm3.Value = str.Substring(0, 2);
                    objOraclecommand.Parameters.Add(prm3);
                }
                else
                {
                    prm3.Value = str;
                    objOraclecommand.Parameters.Add(prm3);

                }



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
        public DataSet insert_roll(string compcode, string userid, string rolcode, string rolname)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("insert_roll.insert_roll_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("uid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objorclcmd.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("rolcod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = rolcode;
                objorclcmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("rolname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rolname;
                objorclcmd.Parameters.Add(prm4);


               
                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }
        public DataSet advteambranch(string compcode)//, string branchcode)
        {
            OracleConnection objorclcon = new OracleConnection();
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("AN_BRANCHTEAM.AN_BRANCHTEAM_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("branchcode", OracleType.VarChar);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = branchcode;
                //objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }

        public DataSet advExecutive(string compcode)//, string teamcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("AN_EXECUTIVE.AN_EXECUTIVE_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("gteam_code", OracleType.VarChar);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = teamcode;
                //objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }
        }




        public DataSet findcod(string execod,string tmcod,string branch, string compcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("AN_EXECUTIVE.AN_code_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = execod;
                objorclcmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Tcod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = tmcod;
                objorclcmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("Bcod", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = branch;
                objorclcmd.Parameters.Add(prm4);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclcmd.Parameters.Add("p_accounts1", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclcmd.Parameters.Add("p_accounts2", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }
        }


        public DataSet saveaccess(string rgcd, string rolcod, string newuid, string compcode, string hduid, string value)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_access.pam_accreg_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("rgcd", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = rgcd;
                objorclcmd.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("bcd", OracleType.VarChar, 2000);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = bcd;
                //objorclcmd.Parameters.Add(prm2);

                //OracleParameter prm7 = new OracleParameter("tmcd", OracleType.VarChar, 2000);
                //prm7.Direction = ParameterDirection.Input;
                //prm7.Value = tmcd;
                //objorclcmd.Parameters.Add(prm7);


                //OracleParameter prm43 = new OracleParameter("execd", OracleType.VarChar, 2000);
                //prm43.Direction = ParameterDirection.Input;
                //prm43.Value = execd;
                //objorclcmd.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("rolcod", OracleType.VarChar, 2000);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = rolcod;
                objorclcmd.Parameters.Add(prm44);


                OracleParameter prm445 = new OracleParameter("newuid", OracleType.VarChar, 2000);
                prm445.Direction = ParameterDirection.Input;
                prm445.Value = newuid;
                objorclcmd.Parameters.Add(prm445);


                OracleParameter prm45 = new OracleParameter("compcode", OracleType.VarChar, 2000);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = compcode;
                objorclcmd.Parameters.Add(prm45);


                OracleParameter prm451 = new OracleParameter("hduid", OracleType.VarChar, 2000);
                prm451.Direction = ParameterDirection.Input;
                prm451.Value = hduid;
                objorclcmd.Parameters.Add(prm451);

                OracleParameter prm452 = new OracleParameter("hvalue", OracleType.VarChar, 2000);
                prm452.Direction = ParameterDirection.Input;
                prm452.Value = value;
                objorclcmd.Parameters.Add(prm452);

                objorclcmd.ExecuteNonQuery();
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }

        public DataSet update(string rgcd, string rolcod, string newuid, string compcode, string hduid, string value)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_access.modify_access_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("rgcd", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = rgcd;
                objorclcmd.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("bcd", OracleType.VarChar, 2000);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = bcd;
                //objorclcmd.Parameters.Add(prm2);

                //OracleParameter prm7 = new OracleParameter("tmcd", OracleType.VarChar, 2000);
                //prm7.Direction = ParameterDirection.Input;
                //prm7.Value = tmcd;
                //objorclcmd.Parameters.Add(prm7);


                //OracleParameter prm43 = new OracleParameter("execd", OracleType.VarChar, 2000);
                //prm43.Direction = ParameterDirection.Input;
                //prm43.Value = execd;
                //objorclcmd.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("rolcod", OracleType.VarChar, 2000);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = rolcod;
                objorclcmd.Parameters.Add(prm44);


                OracleParameter prm445 = new OracleParameter("newuid", OracleType.VarChar, 2000);
                prm445.Direction = ParameterDirection.Input;
                prm445.Value = newuid;
                objorclcmd.Parameters.Add(prm445);


                OracleParameter prm45 = new OracleParameter("compcode", OracleType.VarChar, 2000);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = compcode;
                objorclcmd.Parameters.Add(prm45);


                OracleParameter prm451 = new OracleParameter("hduid", OracleType.VarChar, 2000);
                prm451.Direction = ParameterDirection.Input;
                prm451.Value = hduid;
                objorclcmd.Parameters.Add(prm451);

                OracleParameter prm452 = new OracleParameter("hvalue", OracleType.VarChar, 2000);
                prm452.Direction = ParameterDirection.Input;
                prm452.Value = value;
                objorclcmd.Parameters.Add(prm452);

                objorclcmd.ExecuteNonQuery();
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }


        //public DataSet update(string rgcd, string bcd, string tmcd, string execd, string rolcod, string newuid, string compcode, string hduid)
        //{
        //    OracleConnection objorclcon;
        //    OracleCommand objorclcmd;
        //    DataSet objds = new DataSet();
        //    objorclcon = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objorclcon.Open();
        //        objorclcmd = GetCommand("pam_access.modify_access_p", ref objorclcon);
        //        objorclcmd.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("rgcd", OracleType.VarChar, 2000);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = rgcd;
        //        objorclcmd.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("bcd", OracleType.VarChar, 2000);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = bcd;
        //        objorclcmd.Parameters.Add(prm2);

        //        OracleParameter prm7 = new OracleParameter("tmcd", OracleType.VarChar, 2000);
        //        prm7.Direction = ParameterDirection.Input;
        //        prm7.Value = tmcd;
        //        objorclcmd.Parameters.Add(prm7);


        //        OracleParameter prm43 = new OracleParameter("execd", OracleType.VarChar, 2000);
        //        prm43.Direction = ParameterDirection.Input;
        //        prm43.Value = execd;
        //        objorclcmd.Parameters.Add(prm43);

        //        OracleParameter prm44 = new OracleParameter("rolcod", OracleType.VarChar, 2000);
        //        prm44.Direction = ParameterDirection.Input;
        //        prm44.Value = rolcod;
        //        objorclcmd.Parameters.Add(prm44);


        //        OracleParameter prm445 = new OracleParameter("newuid", OracleType.VarChar, 2000);
        //        prm445.Direction = ParameterDirection.Input;
        //        prm445.Value = newuid;
        //        objorclcmd.Parameters.Add(prm445);


        //        OracleParameter prm45 = new OracleParameter("compcode", OracleType.VarChar, 2000);
        //        prm45.Direction = ParameterDirection.Input;
        //        prm45.Value = compcode;
        //        objorclcmd.Parameters.Add(prm45);


        //        OracleParameter prm451 = new OracleParameter("hduid", OracleType.VarChar, 2000);
        //        prm451.Direction = ParameterDirection.Input;
        //        prm451.Value = hduid;
        //        objorclcmd.Parameters.Add(prm451);

        //        objorclcmd.ExecuteNonQuery();
        //        return objds;

        //    }
        //    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        objorclcon.Close();

        //    }

        //}


        public DataSet save_center(string rolcod, string newuid, string compcode, string hduid, string center)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_centeraccess.pam_centeraccess_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("rolecd", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = rolcod;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("newuser", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = newuid;
                objorclcmd.Parameters.Add(prm2);

                OracleParameter prm7 = new OracleParameter("hduser", OracleType.VarChar, 2000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = hduid;
                objorclcmd.Parameters.Add(prm7);


                OracleParameter prm43 = new OracleParameter("compcode", OracleType.VarChar, 2000);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = compcode;
                objorclcmd.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("center", OracleType.VarChar, 2000);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = center;
                objorclcmd.Parameters.Add(prm44);


               
                objorclcmd.ExecuteNonQuery();
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }


        public DataSet update_rol(string compcode, string rolcode, string rolname)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_update_roll.pam_update_roll_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);




                OracleParameter prm3 = new OracleParameter("rolcod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = rolcode;
                objorclcmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("rolname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rolname;
                objorclcmd.Parameters.Add(prm4);



                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }

        public DataSet delete_rol(string compcode, string rolcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("delete_roll.delete_roll_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);




                OracleParameter prm3 = new OracleParameter("rolcod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = rolcode;
                objorclcmd.Parameters.Add(prm3);


             

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }

        public DataSet execute_rol(string compcode, string userid, string rolcode, string rolname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pam_execute_rol.pam_execute_rol_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("uid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("rolcod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = rolcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("rolname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rolname;
                objOraclecommand.Parameters.Add(prm4);

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

        public DataSet bind_roll(string compcode)
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleConnection con;
            con = GetConnection();
            OracleCommand com;
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                com = GetCommand("pam_rollbind.pam_rollbind_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                com.Parameters.Add(prm1);

                com.Parameters.Add("p_accounts", OracleType.Cursor);
                com.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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


        public DataSet bind_username(string compcode)
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleConnection con;
            con = GetConnection();
            OracleCommand com;
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                com = GetCommand("bind_username.bind_username_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                com.Parameters.Add(prm1);

                com.Parameters.Add("p_accounts", OracleType.Cursor);
                com.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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


        public DataSet region(string compcode)//, string regioncode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("AN_REGION.AN_REGION_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = compcode;
                //objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }
        }

        public DataSet center(string compcode)//, string regioncode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("AN_center.AN_center_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = compcode;
                //objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }
        }

        public DataSet advbranch(string compcode)//, string regcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("AN_BRANCH.AN_BRANCH_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("regcode", OracleType.VarChar);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = regcode;
                //objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }


        public DataSet bind_prodcodnew(string brdcod, string compcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_brandpro_link.brand_oack_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("brdcod", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = brdcod;
                objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }

        public DataSet bind_prodsubco(string procod, string compcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("brand_oack.pro_oack_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("procod", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = procod;
                objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }

        public DataSet genrateagname(string agcod, string compcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("Pam_fetcgdata.Pam_fetchaname_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agcod", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agcod;
                objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }

        public DataSet adcat_code(string compcode, string sbsbcatcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_adcatname.pam_adcatname_P", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adsbsbcat", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = sbsbcatcode;
                objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }


        public DataSet ad_code(string compcode, string sbsbcatcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_adcatname.pam_adcat_P", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adscat", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = sbsbcatcode;
                objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }


        public DataSet ad_typ(string compcode, string catcod)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_adcatname.pam_adtyp_P", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adtyp", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = catcod;
                objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }


        public DataSet publication(string compcode, string publishercd)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_publication.pam_publication_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("publisgcd", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = publishercd;
                objorclcmd.Parameters.Add(prm2);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }


        public DataSet search_center(string role, string user, string compcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("Pam_Showcenter.Pam_Showcenter_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("designation", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = role;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("user", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = user;
                objorclcmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objorclcmd.Parameters.Add(prm3);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }
        }


        public DataSet reports(string role, string user, string compcode)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_access.show_permission_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("rolcod", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = role;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("newuid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = user;
                objorclcmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objorclcmd.Parameters.Add(prm3);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclcmd.Parameters.Add("p_accounts1", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclcmd.Parameters.Add("p_accounts2", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objorclcmd.Parameters.Add("p_accounts3", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }
        }


        public DataSet select_center(string role, string user, string compcode, string center)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_accesscenter.Pam_selcenter_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("designation", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = role;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("user", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = user;
                objorclcmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objorclcmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
                objorclcmd.Parameters.Add(prm4);


                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }
        }

        //Sachin verma

        public DataSet select_report(string rgcd, string rolcod, string newuid, string compcode, string value)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("pam_access.report_access_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("rolcod", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = rolcod;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("newuid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = newuid;
                objorclcmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objorclcmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("rgcd", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rgcd;
                objorclcmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("hvalue", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = value;
                objorclcmd.Parameters.Add(prm5);



                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }
        }


        public DataSet update_cen(string role, string user, string compcode, string center)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("Pam_Updatecenter.pam_Updatecenter_p", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("designation", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = role;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("user", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = user;
                objorclcmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objorclcmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
                objorclcmd.Parameters.Add(prm4);


                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }
        }

    }
}
