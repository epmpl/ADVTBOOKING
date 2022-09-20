using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OracleClient;

/// <summary>
/// Summary description for section_code_master
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{

    public class section_code_master : orclconnection
    {
        public section_code_master()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet sectionsave(string code, string name)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("insertinto_sectioncode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pSection_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pSection_name", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = name;
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





        public DataSet sectioncodemodify(string code, string name)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("sectioncode_modify_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = Compcode;
                //cmd.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pSection_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pSection_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                cmd.Parameters.Add(prm3);
                
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


        public DataSet sectionautogenerate(string Compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("sectioncodegenerate", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Compcode;
                cmd.Parameters.Add(prm1);



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




        public DataSet sectioncodedelete(string Compcode, string code, string name)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("sectioncode_Delete_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                


                OracleParameter prm2 = new OracleParameter("pSection_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pSection_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                cmd.Parameters.Add(prm3);

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




        public DataSet sectioncodeexcute(string code, string name)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("Section_code_execute.Section_code_execute_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = Compcode;
                //cmd.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pSection_code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pSection_name", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                cmd.Parameters.Add(prm3);




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


        public DataSet sectioncodeexcute1(string code, string name)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("Section_code_execute.Section_code_execute_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = Compcode;
                //cmd.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pSection_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pSection_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                cmd.Parameters.Add(prm3);

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




        public DataSet atmdelete(string code, string name)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand(" Section_code_Delete_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pSection_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pSection_name", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = name;
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


        public DataSet chkatmcode(string code, string name)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("sectioncheck_p1", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pSection_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pSection_name", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = name;
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



    }
}