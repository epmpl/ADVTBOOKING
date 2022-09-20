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
    /// Summary description for productsubcategory
    /// </summary>
    public class productsubcategory : orclconnection
    {
        public productsubcategory()
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
                cmd = GetCommand("drpsubproduct.drpsubproduct_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);


                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



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

        //Check code
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
                cmd = GetCommand("productsubcode.productsubcode_P", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);


                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




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
        public DataSet insertedvalue(string drpprosub, string prosubcode, string prosubname, string proalias, string compcode, string userid)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("productsubinsert.productsubinsert_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;        

                OracleParameter prm6 = new OracleParameter("prosubcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = prosubcode;
                cmd.Parameters.Add(prm6);
            

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("prosubname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = prosubname;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = proalias;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                cmd.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("drppro", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpprosub;
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

        //Auto generated code
        public DataSet autocode(string str,string procode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("productsubautocode.productsubautocode_P", ref con);
                cmd.CommandType = CommandType.StoredProcedure;            

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length >2)
                {
                prm2.Value = str.Substring (0,2);
                }
                else
                {
                    prm2.Value = str;
                }
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("procode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = procode;
                cmd.Parameters.Add(prm3);


                cmd.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNTS1", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNTS1"].Direction = ParameterDirection.Output;


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
        public DataSet prosubexecute(string drpprodes, string prosubcode, string prosubname, string prosubalias, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("productsubexe.productsubexe_P", ref con);
                cmd.CommandType = CommandType.StoredProcedure;            
           
               
             

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("prosubalias", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = prosubalias;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("prosubname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = prosubname;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("prosubcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = prosubcode;
                cmd.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("drpproduct", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (drpprodes=="0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {

                prm5.Value = drpprodes;
                }
                cmd.Parameters.Add(prm5);
                cmd.Parameters.Add("P_Accounts", OracleType.Cursor);
                cmd.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



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
        public DataSet deleteproduct(string prosubcode, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("productsubdel.productsubdel_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("prosubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = prosubcode;
                cmd.Parameters.Add(prm2);

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
        public DataSet updatepro(string drpprodes, string prosubcode, string prosubname, string prosubalias, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("productsubmodify.productsubmodify_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;           

            

            

       
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("prosubalias", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = prosubalias;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("prosubname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = prosubname;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("prosubcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = prosubcode;
                cmd.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("drpproduct", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpprodes;
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