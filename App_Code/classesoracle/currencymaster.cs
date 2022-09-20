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
    /// Summary description for currencymaster
    /// </summary>
    public class currencymaster : orclconnection
    {
        public currencymaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindcount(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindcountry.bindcountry_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;



             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);
             objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
             objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



            



              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet chkcurrcode(string code, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcurrcode.chkcurrcode_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;



             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = code;
             objOraclecommand.Parameters.Add(prm3);
             objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
             objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
             objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
             objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;



             




             



               
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet currsave(string txtcurrcode, string txtcurrname, string txtalias, string drpcountryname, string compcode, string userid, string SYMBOL_P, string cursymbol)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();

            try
            {



                objOracleConnection.Open();


                objOraclecommand = GetCommand("insertcurrencymst.insertcurrencymst_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;



             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("txtcurrcode", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = txtcurrcode;
             objOraclecommand.Parameters.Add(prm3);

             OracleParameter prm13 = new OracleParameter("txtcurrname", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = txtcurrname;
             objOraclecommand.Parameters.Add(prm13);

             OracleParameter prm23 = new OracleParameter("txtalias", OracleType.VarChar, 50);
             prm23.Direction = ParameterDirection.Input;
             prm23.Value = txtalias;
             objOraclecommand.Parameters.Add(prm23);
             OracleParameter prm33 = new OracleParameter("drpcountryname", OracleType.VarChar, 50);
             prm33.Direction = ParameterDirection.Input;
             prm33.Value = drpcountryname;
             objOraclecommand.Parameters.Add(prm33);

             OracleParameter prm4 = new OracleParameter("SYMBOL_P", OracleType.VarChar, 50);
             prm4.Direction = ParameterDirection.Input;
             prm4.Value = SYMBOL_P;
             objOraclecommand.Parameters.Add(prm4);



             OracleParameter prm5 = new OracleParameter("CURR_SYMBOL_NAME", OracleType.VarChar, 50);
             prm5.Direction = ParameterDirection.Input;
             prm5.Value = cursymbol;
             objOraclecommand.Parameters.Add(prm5);

           


         
                


              



             
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet executecurrmst(string txtcurrcode, string txtcurrname, string txtalias, string drpcountryname, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("exeecutecurrencymast.exeecutecurrencymast_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;   




             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("txtcurrcode", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = txtcurrcode;
             objOraclecommand.Parameters.Add(prm3);

             OracleParameter prm13 = new OracleParameter("txtcurrname", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = txtcurrname;
             objOraclecommand.Parameters.Add(prm13);

             OracleParameter prm23 = new OracleParameter("txtalias", OracleType.VarChar, 50);
             prm23.Direction = ParameterDirection.Input;
             prm23.Value = txtalias;
             objOraclecommand.Parameters.Add(prm23);
             OracleParameter prm33 = new OracleParameter("drpcountryname", OracleType.VarChar, 50);
             prm33.Direction = ParameterDirection.Input;
             if (drpcountryname=="0")
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
             prm33.Value = drpcountryname;
                }
             objOraclecommand.Parameters.Add(prm33);






            
             objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
             objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;




               


                
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet firstcurrmst()
       {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("firstcurrenmast.firstcurrenmast_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;




             objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
             objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

              



                
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet currmodify(string txtcurrcode, string txtcurrname, string txtalias, string drpcountryname, string compcode, string userid, string SYMBOL_P, string cursymbol)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("modifycurrmast.modifycurrmast_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;           



             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("txtcurrcode", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = txtcurrcode;
             objOraclecommand.Parameters.Add(prm3);

             OracleParameter prm13 = new OracleParameter("txtcurrname", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = txtcurrname;
             objOraclecommand.Parameters.Add(prm13);

             OracleParameter prm23 = new OracleParameter("txtalias", OracleType.VarChar, 50);
             prm23.Direction = ParameterDirection.Input;
             prm23.Value = txtalias;
             objOraclecommand.Parameters.Add(prm23);
             OracleParameter prm33 = new OracleParameter("drpcountryname", OracleType.VarChar, 50);
             prm33.Direction = ParameterDirection.Input;
             prm33.Value = drpcountryname;
             objOraclecommand.Parameters.Add(prm33);


             OracleParameter prm4 = new OracleParameter("SYMBOL_P", OracleType.VarChar, 50);
             prm4.Direction = ParameterDirection.Input;
             prm4.Value = SYMBOL_P;
             objOraclecommand.Parameters.Add(prm4);


             OracleParameter prm5 = new OracleParameter("CURR_SYMBOL_NAME_p", OracleType.VarChar, 50);
                  prm5.Direction = ParameterDirection.Input;
                  prm5.Value = cursymbol;
                  objOraclecommand.Parameters.Add(prm5);



              



              
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet currdelete(string code, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletecurrmast.deletecurrmast_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

          

            

             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = code;
             objOraclecommand.Parameters.Add(prm3);

                
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet checkratecode(string code, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("converartechk.converartechk_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = code;
             objOraclecommand.Parameters.Add(prm3);

             objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
             objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;






                
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }
        public DataSet ratebind(string code, string compcode, string userid, string date)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindcurrmast.bindcurrmast_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = code;
             objOraclecommand.Parameters.Add(prm3);

             OracleParameter prm13 = new OracleParameter("date1", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = date;
             objOraclecommand.Parameters.Add(prm13);

             objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
             objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



            


              



              
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet insertconverrate(string txtconrate, string txtfromdate, string txtefftill, string compcode, string userid, string currcode, string currency, string txtunit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertconvertrate.insertconvertrate_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;          

          

        

             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("txtconrate", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = txtconrate;
             objOraclecommand.Parameters.Add(prm3);

             OracleParameter prm13 = new OracleParameter("txtfromdate", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = Convert.ToDateTime(txtfromdate).ToString("dd-MMMM-yyyy");
             objOraclecommand.Parameters.Add(prm13);
             OracleParameter prm23 = new OracleParameter("txtefftill", OracleType.VarChar, 50);
             prm23.Direction = ParameterDirection.Input;
             prm23.Value = Convert.ToDateTime(txtefftill).ToString("dd-MMMM-yyyy");
             objOraclecommand.Parameters.Add(prm23);

             OracleParameter prm33 = new OracleParameter("currcode", OracleType.VarChar, 50);
             prm33.Direction = ParameterDirection.Input;
             prm33.Value = currcode;
             objOraclecommand.Parameters.Add(prm33);

             OracleParameter prm34 = new OracleParameter("currency", OracleType.VarChar, 50);
             prm34.Direction = ParameterDirection.Input;
             prm34.Value = currency;
             objOraclecommand.Parameters.Add(prm34);

             OracleParameter prm35 = new OracleParameter("txtunit", OracleType.VarChar, 50);
             prm35.Direction = ParameterDirection.Input;
             prm35.Value = txtunit;
             objOraclecommand.Parameters.Add(prm35);
                
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet selectedfromgrid(string currcode, string compcode, string userid, string code10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selectfromcurrmast.selectfromcurrmast_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

             

            




             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("currcode", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = currcode;
             objOraclecommand.Parameters.Add(prm3);

             OracleParameter prm13 = new OracleParameter("code10", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = code10;
             objOraclecommand.Parameters.Add(prm13);

             objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
             objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;








              
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet gridupdate(string txtconrate, string txtfromdate, string txtefftill, string compcode, string userid, string currcode, string code10, string currency, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateconvertrate.updateconvertrate_P", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("txtconrate", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = txtconrate;
             objOraclecommand.Parameters.Add(prm3);

          

             OracleParameter prm13 = new OracleParameter("txtfromdate", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = Convert.ToDateTime(txtfromdate).ToString("dd-MMMM-yyyy");
             objOraclecommand.Parameters.Add(prm13);

             OracleParameter prm23 = new OracleParameter("txtefftill", OracleType.VarChar, 50);
             prm23.Direction = ParameterDirection.Input;
             prm23.Value = Convert.ToDateTime(txtefftill).ToString("dd-MMMM-yyyy");
             objOraclecommand.Parameters.Add(prm23);
             OracleParameter prm33 = new OracleParameter("currcode", OracleType.VarChar, 50);
             prm33.Direction = ParameterDirection.Input;
             prm33.Value = currcode;
             objOraclecommand.Parameters.Add(prm33);
             OracleParameter prm34 = new OracleParameter("code10", OracleType.VarChar, 50);
             prm34.Direction = ParameterDirection.Input;
             prm34.Value = code10;
             objOraclecommand.Parameters.Add(prm34);


             OracleParameter prm35 = new OracleParameter("currency", OracleType.VarChar, 50);
             prm35.Direction = ParameterDirection.Input;
             prm35.Value = currency;
             objOraclecommand.Parameters.Add(prm35);

             OracleParameter prm36 = new OracleParameter("txtunit", OracleType.VarChar, 50);
            prm36.Direction = ParameterDirection.Input;
            prm36.Value = unit;
            objOraclecommand.Parameters.Add(prm36);
             
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet griddelete(string currcode, string compcode, string userid, string code10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletegridconrate.deletegridconrate_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

          



             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("currcode", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = currcode;
             objOraclecommand.Parameters.Add(prm3);

             OracleParameter prm13 = new OracleParameter("code10", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = code10;
             objOraclecommand.Parameters.Add(prm13);




                



                
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }
        public DataSet chkdaetconv(string txtconrate, string txtfromdate, string txtefftill, string compcode, string userid, string currcode,string currency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdateconrate.chkdateconrate_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

            


          

             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("txtconrate", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = txtconrate;
             objOraclecommand.Parameters.Add(prm3);






       






             OracleParameter prm13 = new OracleParameter("txtfromdate", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             if (txtfromdate=="")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = txtfromdate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    txtfromdate = mm + "/" + dd + "/" + yy;

                    //}


                    prm13.Value = Convert.ToDateTime(txtfromdate).ToString("dd-MMMM-yyyy");
                }
             objOraclecommand.Parameters.Add(prm13);



             OracleParameter prm23 = new OracleParameter("txtefftill", OracleType.VarChar, 50);
             prm23.Direction = ParameterDirection.Input;

             if (txtefftill == "")
             {
                 prm23.Value = System.DBNull.Value;
             }

             else
             {

                 //if (dateformat == "dd/mm/yyyy")
                 //{
                 //    string[] arr = txtefftill.Split('/');
                 //    string dd = arr[0];
                 //    string mm = arr[1];
                 //    string yy = arr[2];
                 //    txtefftill = mm + "/" + dd + "/" + yy;

                 //}

                 prm23.Value = Convert.ToDateTime(txtefftill).ToString("dd-MMMM-yyyy");
                }
            
             objOraclecommand.Parameters.Add(prm23);




             OracleParameter prm33 = new OracleParameter("currcode", OracleType.VarChar, 50);
             prm33.Direction = ParameterDirection.Input;
             prm33.Value = currcode;
             objOraclecommand.Parameters.Add(prm33);

             OracleParameter prm34 = new OracleParameter("pcurrency", OracleType.VarChar, 50);
             prm34.Direction = ParameterDirection.Input;
             prm34.Value = currency;
             objOraclecommand.Parameters.Add(prm34);

             objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
             objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;
               
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException  objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet chkdateupdate(string txtconrate, string txtfromdate, string txtefftill, string compcode, string userid, string currcode, string code10,string currency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdateupdate.chkdateupdate_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

            

            

         


             OracleParameter prm53 = new OracleParameter("txtfromdate", OracleType.VarChar, 50);
             prm53.Direction = ParameterDirection.Input;
             if (txtfromdate == "" || txtfromdate==null)
                {
                    prm53.Value = System.DBNull.Value;
                }
                else
                {
              //if (dateformat == "dd/mm/yyyy")
              //{
              //          string[] arr = txtfromdate.Split('/');
              //          string dd = arr[0];
              //          string mm = arr[1];
              //          string yy = arr[2];
              //          txtfromdate = mm + "/" + dd + "/" + yy;
              //}
             prm53.Value = Convert.ToDateTime(txtfromdate).ToString("dd-MMMM-yyyy");
                }
             objOraclecommand.Parameters.Add(prm53);

             OracleParameter prm23 = new OracleParameter("txtefftill", OracleType.VarChar, 50);
             prm23.Direction = ParameterDirection.Input;
             if (txtefftill == "" || txtefftill==null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = txtefftill.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    txtefftill = mm + "/" + dd + "/" + yy;
                    //}

             prm23.Value = Convert.ToDateTime(txtefftill).ToString("dd-MMMM-yyyy");
                }
             objOraclecommand.Parameters.Add(prm23);
             OracleParameter prm33 = new OracleParameter("currcode", OracleType.VarChar, 50);
             prm33.Direction = ParameterDirection.Input;
             prm33.Value = currcode;
             objOraclecommand.Parameters.Add(prm33);

             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = userid;
             objOraclecommand.Parameters.Add(prm2);



             OracleParameter prm3 = new OracleParameter("txtconrate", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = txtconrate;
             objOraclecommand.Parameters.Add(prm3);

             OracleParameter prm13 = new OracleParameter("code10", OracleType.VarChar, 50);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = code10;
             objOraclecommand.Parameters.Add(prm13);

             OracleParameter prm14 = new OracleParameter("pcurrency", OracleType.VarChar, 50);
             prm14.Direction = ParameterDirection.Input;
             prm14.Value = currency;
             objOraclecommand.Parameters.Add(prm14);



             objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
             objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                
              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException  objException)
            {
                throw (objException);
            }

            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet countcurrencycode(string str, string country)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcurrencycodename.chkcurrencycodename_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

             

             OracleParameter prm3 = new OracleParameter("country", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = country;
             objOraclecommand.Parameters.Add(prm3);




             OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = str;
             objOraclecommand.Parameters.Add(prm1);


             OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             if (str.Length > 2)
             {
                 prm2.Value = str.Substring(0, 2);
             }
             else
             {
                 prm2.Value = str;
             }
             objOraclecommand.Parameters.Add(prm2);
             objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
             objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

             objOraclecommand.Parameters.Add("P_ACCOUNTS1", OracleType.Cursor);
             objOraclecommand.Parameters["P_ACCOUNTS1"].Direction = ParameterDirection.Output;



        


              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);

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


        public DataSet countcurrencycodectry(string country)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcurrencycodenamectry.chkcurrencycodenamectry_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;


             OracleParameter prm1 = new OracleParameter("country", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = country;
             objOraclecommand.Parameters.Add(prm1);

             objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
             objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;




           





              objmysqlDataAdapter.SelectCommand =objOraclecommand;
              objmysqlDataAdapter.Fill(objDataSet);

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
    }
}
