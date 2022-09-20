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
    /// Summary description for product_subsub_category
    /// </summary>
    public class product_subsub_category : orclconnection 
    {
        public product_subsub_category()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet productdes(string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            

            try
            {
                con.Open();
                cmd = GetCommand("drpproductselect.drpproductselect_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

             
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add("p_account", OracleType.Cursor);
                cmd.Parameters["p_account"].Direction = ParameterDirection.Output;


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

        public DataSet productsubdes(string compcode, string prosubsubcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpsubproductselect.drpsubproductselect_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("prosubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = prosubsubcode;
                cmd.Parameters.Add(prm2);
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
        //     Check code
        public DataSet chkcode(string code, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("productsubcatcode.productsubcatcode_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

              

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

                cmd.Parameters.Add("p_account", OracleType.Cursor);
                cmd.Parameters["p_account"].Direction = ParameterDirection.Output;



                da.SelectCommand = cmd;
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

        //Insert the value

        public DataSet insertedvalue(string drpprosub, string drpprosubsub, string prosubsubcode, string prosubsubname, string proalias, string compcode, string userid)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("productsubsubinsert.productsubsubinsert_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

               
                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                cmd.Parameters.Add(prm8);
                OracleParameter prm1 = new OracleParameter("procatcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = drpprosub;
                cmd.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("prosubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = drpprosubsub;
                cmd.Parameters.Add(prm2);
              
                OracleParameter prm4 = new OracleParameter("prosubsubname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = prosubsubname;
                cmd.Parameters.Add(prm4);


                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                cmd.Parameters.Add(prm6);
                OracleParameter prm5 = new OracleParameter("prosubsubcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = prosubsubcode;
                cmd.Parameters.Add(prm5);
                OracleParameter prm7 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = proalias;
                cmd.Parameters.Add(prm7);
               



                da.SelectCommand = cmd;
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

        //Auto generated code
        public DataSet autocode(string str, string procode, string prosubcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("productsubsubautocode.productsubsubautocode_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                OracleParameter prm2 = new OracleParameter("str", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                cmd.Parameters.Add(prm2);

                OracleParameter prm6 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (str.Length >2)
                {
                    prm6.Value = str.Substring (0,2);
                    cmd.Parameters.Add(prm6);
                }
                else
                {
                prm6.Value = str;
                cmd.Parameters.Add(prm6);
                }

                OracleParameter prm3 = new OracleParameter("procode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = procode;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("prosubcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = prosubcode;
                cmd.Parameters.Add(prm4);
               
                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_accounts1", OracleType.Cursor);
                cmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
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

        //Execute Value

        public DataSet prosubexecute(string drpprosub, string drpsubprodu, string prosubsubcode, string prosubsubname, string proalias, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {


                con.Open();
                cmd = GetCommand("productsubsubexe.productsubsubexe_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

               

                OracleParameter prm1 = new OracleParameter("procatcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (drpprosub=="0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = drpprosub;
                }
                cmd.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("prosubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (drpsubprodu=="0")
                {
                prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = drpsubprodu;
                }
                cmd.Parameters.Add(prm2);
              
                OracleParameter prm4 = new OracleParameter("prosubsubname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = prosubsubname;
                cmd.Parameters.Add(prm4);
                OracleParameter prm7 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = proalias;
                cmd.Parameters.Add(prm7);


                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                cmd.Parameters.Add(prm6);
                OracleParameter prm5 = new OracleParameter("prosubsubcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = prosubsubcode;
                cmd.Parameters.Add(prm5);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

               
               

                da.SelectCommand = cmd;
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


        //Delete The Value
        public DataSet deleteproduct(string prosubsubcode, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {


                con.Open();
                cmd = GetCommand("productsubsubdel.productsubsubdel_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                cmd.Parameters.Add(prm6);
                OracleParameter prm5 = new OracleParameter("prosubsubcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = prosubsubcode;
                cmd.Parameters.Add(prm5);

                da.SelectCommand = cmd;
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

        //Modify The Value
        public DataSet updatepro(string drpprosub, string drpprosubsub, string prosubsubcode, string prosubsubname, string proalias, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("productsubsubmodify.productsubsubmodify_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                OracleParameter prm1 = new OracleParameter("procatcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = drpprosub;
                cmd.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("prosubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = drpprosubsub;
                cmd.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("prosubsubname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = prosubsubname;
                cmd.Parameters.Add(prm4);
                OracleParameter prm7 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = proalias;
                cmd.Parameters.Add(prm7);


                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                cmd.Parameters.Add(prm6);
                OracleParameter prm5 = new OracleParameter("prosubsubcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = prosubsubcode;
                cmd.Parameters.Add(prm5);


                da.SelectCommand = cmd;
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