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
/// Summary description for vatmaster
/// </summary>
    public class vatmaster : orclconnection 
{
	public vatmaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     public DataSet vatsave(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype,string orderno,string publicat,string edit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();



                objOraclecommand = GetCommand("vatsave.vatsave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


              







                OracleParameter prm3 = new OracleParameter("comp_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm1 = new OracleParameter("vat_description", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = description;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("vat_rate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = vatrate;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("vat_from_date", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy"); 
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("vat_to_date", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert .ToDateTime(todate).ToString ("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("vat_gross_type", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = grosstype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("vat_order_no", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = orderno;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("publicat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = publicat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("edit1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = edit;
                objOraclecommand.Parameters.Add(prm10);


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet dauto(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("vat_Auto.vat_Auto_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                
                
                OracleParameter prm3 = new OracleParameter("cod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm3.Value = str.Substring(0, 2);
                }
                else
                {
                    prm3.Value = str;
                }
                objOraclecommand.Parameters.Add(prm3);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

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

        public DataSet vatexecute(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype, string orderno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Vat_Exe.Vat_Exe_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm3 = new OracleParameter("comp_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm1 = new OracleParameter("vat_description", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (description == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {

                    prm1.Value = description;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("vat_rate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = vatrate;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("vat_from_date", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = fromdate;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("vat_to_date", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = todate;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("vat_gross_type", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (grosstype == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = grosstype;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("vat_order_no", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = orderno;
                objOraclecommand.Parameters.Add(prm8);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




            

             


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet vatchk(string description)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("vat_Chk.vat_Chk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm4 = new OracleParameter("vat_description", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = description;
                objOraclecommand.Parameters.Add(prm4);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

              
              

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet vatdelete(string compcode, string description, string fromdate, string todate, string publicat, string edit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("vat_delete.vat_delete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("comp_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("vat_description", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = description;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1 = new OracleParameter("p_fromdate", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_todate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value =Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("p_publicat", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = publicat;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("p_edit", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = edit;
                objOraclecommand.Parameters.Add(prm6);

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet vatmodify(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype, string orderno,string publicat,string edit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("vat_modify.vat_modify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm3 = new OracleParameter("comp_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm1 = new OracleParameter("vat_description", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = description;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("vat_rate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = vatrate;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("vat_from_date", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("vat_to_date", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("vat_gross_type", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = grosstype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("vat_order_no", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = orderno;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("publicat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = publicat;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("edit1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = edit;
                objOraclecommand.Parameters.Add(prm10);

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

        public DataSet grosstype(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("vat_GrossType.vat_GrossType_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("comp_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet chkdate(string description, string fromdate, string todate,string publicat,string edit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("vat_chkdate.vat_chkdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("vat_description", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = description;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("vat_from_date", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("vat_to_date", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("publicat", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = publicat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("edit1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = edit;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
             
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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



    }






}
