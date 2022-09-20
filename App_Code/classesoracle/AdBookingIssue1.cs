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
/// Summary description for AdBookingIssue1
/// </summary>
public class AdBookingIssue1:orclconnection
{
	public AdBookingIssue1()
	{
		//
		// TODO: Add constructor logic here
		//
	}

        public DataSet Adpub(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubName.Bind_PubName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);
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
//********************************************************************************************************
  
        public DataSet pubcenter()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubCentName.Bind_PubCentName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
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
 //**********************************************************************************************************


        public DataSet pubedition(string pubname,string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_EdiName.Bind_EdiName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

              
                OracleParameter prm3 = new OracleParameter("edit", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubname;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubcenter;
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

//**********************************************************************************************************       

        public DataSet pubsupply(string pubname, string pubedit)
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
                prm3.Value = pubname;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubedit;
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
//***********************************************************************************************************
   


//**********************************************************************************************************
        //This code is used for insert data into database

        public DataSet insertad(string adpub, string adcenter, string adedition, string adsuplement, int adbook, int adpages, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertadbookissue.insertadbookissue_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm4 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adpub;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adcenter;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adedition;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("suplement", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adsuplement;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("bookvolume", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adbook;
                objOraclecommand.Parameters.Add(prm8);
                OracleParameter prm9 = new OracleParameter("noofpages", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adpages;
                objOraclecommand.Parameters.Add(prm9);







                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);
                

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
//*********************************************************************************************************

        public DataSet executead(string adpub, string adcenter, string adedition, string adsup,string compcode,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executeadbookissue.executeadbookissue_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm4 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (adpub=="0")
                {
                    prm4.Value =System .DBNull .Value;
                }
                else
                {

                prm4.Value = adpub;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (adcenter=="0")
                {
                    prm5.Value = System.DBNull.Value; 
                }
                else
                {
                prm5.Value = adcenter;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (adedition=="0")
                {
                    prm6.Value = System.DBNull.Value; 
                }
                else
                {
                prm6.Value = adedition;
                }
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("supplement", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (adsup=="0")
                {
                    prm7.Value = System.DBNull.Value; 
                }
                else
                {

                prm7.Value = adsup;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

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
//**********************************************************************************************************
     //this code is used for check duplicate case;

        public DataSet duplicate(string adpub, string adcenter, string adedition, string adsuplement, string compcode,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adduplicate.adduplicate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;





                OracleParameter prm4 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adpub;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("center", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adcenter;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adedition;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("supplement", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adsuplement;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if(userid =="")
                {
                    prm8.Value = DBNull.Value;
                }
                else
                {


                prm8.Value = userid;
                }

                objOraclecommand.Parameters.Add(prm8);
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
//*******************************************************************************************************

 //*******************************************************************************************************

        public DataSet deletead(string adpub, string adcenter, string adedition, string adsup, string compcode,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deleteadbooking.deleteadbooking_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;        

              



                OracleParameter prm4 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adpub;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adcenter;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pubedition", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adedition;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("pubsup", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adsup;
                objOraclecommand.Parameters.Add(prm7);

              







                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8); 


                 objorclDataAdapter.SelectCommand = objOraclecommand;
                 objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException  objException)
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
//*********************************************************************************************************
        public DataSet updatead(string adpub, string adcenter, string adedition, string adsup,string adbook,string adpages, string compcode,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateadbooking.updateadbooking_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adpub;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcenter;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubedition", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adedition;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("pubsup", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adsup;
                objOraclecommand.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("pubbook", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adbook;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = userid;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pubpages", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adpages;
                objOraclecommand.Parameters.Add(prm8);             

            
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
//********************************************************************************************************
  }
}

