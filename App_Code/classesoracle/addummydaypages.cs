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
    /// Summary description for addummydaypages
    /// </summary>
    public class addummydaypages : orclconnection
    {
        public addummydaypages()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getPubName(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
              objOracleConnection.Open();
              objOraclecommand = GetCommand("Bind_Pubname.Bind_Pubname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;             

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
                
               objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet getPubCName()
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
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                
               objorclDataAdapter.SelectCommand =objOraclecommand;
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
        //**********************************************************************************************************

        //**********This function is used to GET the Edition Name using stored procedure Bind_EdiName***************
        public DataSet getEdiName(string pubcode, string pubcenter)
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
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm4);
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
                
                
               objorclDataAdapter.SelectCommand =objOraclecommand;
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

        //**********************************************************************************************************

        //**********This function is used to GET the Suppliment using stored procedure bindsuppliment***************

        public DataSet getSuppliment(string pubcode, string pubedit)
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
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubedit;
                objOraclecommand.Parameters.Add(prm4);
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

              
               objorclDataAdapter.SelectCommand =objOraclecommand;
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
        //**********************************************************************************************************

        //**********This function is used to Insert the Data using stored procedure adDDPInsert***************

        public DataSet insertData(string day, string pubCode, string centerCode, string ediCode, string supCode, string nPages, string dFrom, string dTo, string compCode, string userId,string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
              objOracleConnection.Open();
              objOraclecommand = GetCommand("adDDPInsert.adDDPInsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




             

                OracleParameter prm5 = new OracleParameter("pub_day", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = day;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pub_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pubCode;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("center_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = centerCode;
                objOraclecommand.Parameters.Add(prm7);
                OracleParameter prm9 = new OracleParameter("edition_code", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = ediCode;
                objOraclecommand.Parameters.Add(prm9);
                OracleParameter prm10 = new OracleParameter("sub_pub", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = supCode;
                objOraclecommand.Parameters.Add(prm10);
                OracleParameter prm11 = new OracleParameter("npages", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (nPages == "")
                {
                    prm11.Value = DBNull.Value;


                }
                else
                {
                    prm11.Value = Convert.ToInt32(nPages);
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("datefrom", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (dFrom == "")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dFrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dFrom = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dFrom.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dFrom = mm + "/" + dd + "/" + yy;
                    }

                    prm12.Value = Convert.ToDateTime(dFrom).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm12);
                OracleParameter prm13 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (dTo == "")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dTo.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dTo = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dTo.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dTo = mm + "/" + dd + "/" + yy;
                    }

                    prm13.Value =Convert.ToDateTime(dTo).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm3 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compCode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userId;
                objOraclecommand.Parameters.Add(prm8);


        
                

               
               objorclDataAdapter.SelectCommand =objOraclecommand;
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

        //**********************************************************************************************************

        //**********This function is used to check the Duplicate Data using stored procedure adDDPDupChk*********************
        public string chkDupRec(string day, string pubCode, string centerCode, string ediCode, string supCode, string recordId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            string dup;

            try
            {
              objOracleConnection.Open();
              objOraclecommand = GetCommand("adDDPDupChk.adDDPDupChk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm5 = new OracleParameter("pub_day", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = day;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pub_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pubCode;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("center_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = centerCode;
                objOraclecommand.Parameters.Add(prm7);
                OracleParameter prm9 = new OracleParameter("edition_code", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = ediCode;
                objOraclecommand.Parameters.Add(prm9);
                OracleParameter prm10 = new OracleParameter("sub_pub", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = supCode;
                objOraclecommand.Parameters.Add(prm10);
                OracleParameter prm11 = new OracleParameter("record_id", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (recordId == "")
                {
                    prm11.Value = DBNull.Value;
                }
                else
                {
                    prm11.Value = recordId;
                }

                objOraclecommand.Parameters.Add(prm11);






                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


            

            

              
               objorclDataAdapter.SelectCommand =objOraclecommand;

               objorclDataAdapter.Fill(objDataSet);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    dup = "y";
                }
                else
                {
                    dup = "n";
                }
                return dup;
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
        //**********************************************************************************************************
        public DataSet getData(string compCode, string day, string pubCode, string centerCode, string ediCode, string supCode,string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
              objOracleConnection.Open();
              objOraclecommand = GetCommand("adDDPExecute.adDDPExecute_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compCode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm5 = new OracleParameter("pub_day", OracleType.VarChar, 50);
                
                
                prm5.Direction = ParameterDirection.Input;
                if(day=="0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else

                {
                     prm5.Value = day;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pub_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (pubCode == "" || pubCode == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pubCode;
                }
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("center_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (centerCode == "" || centerCode == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = centerCode;
                }
               
                objOraclecommand.Parameters.Add(prm7);
                OracleParameter prm9 = new OracleParameter("edition_code", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;

                if (ediCode == "" || ediCode == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {

                    prm9.Value = ediCode;
                }
                objOraclecommand.Parameters.Add(prm9);
                OracleParameter prm10 = new OracleParameter("sub_pub", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (supCode == "" || supCode == "0")
                {

                    prm10.Value = System.DBNull.Value;
 

                }
                else
                {
                    prm10.Value = supCode;

                }
                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                objOraclecommand.Parameters.Add(prm20);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


            

              



                
               objorclDataAdapter.SelectCommand =objOraclecommand;

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

        //**********************************************************************************************************
        public DataSet deleteData(string recordId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
              objOracleConnection.Open();
              objOraclecommand = GetCommand("adDDPDelete.adDDPDelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;               

                OracleParameter prm3 = new OracleParameter("record_id", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = recordId;
                objOraclecommand.Parameters.Add(prm3);

               
               objorclDataAdapter.SelectCommand =objOraclecommand;

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

        //******This is used to Update the data ori stand for original data on the basis update will occur************
        public DataSet updateData(string recordId, string day, string pubCode, string centerCode, string ediCode, string supCode, string nPages, string dFrom, string dTo, string compCode, string userId,string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
              objOracleConnection.Open();
              objOraclecommand = GetCommand("adDDPUpdate.adDDPUpdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm4 = new OracleParameter("record_id", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = recordId;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pub_day", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = day;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pub_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pubCode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("center_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = centerCode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("edition_code", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = ediCode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("sub_pub", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = supCode;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("npages", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (nPages == "")
                {
                    prm11.Value = DBNull.Value;


                }
                else
                {
                    prm11.Value = Convert .ToInt32 (nPages);
                }
                objOraclecommand.Parameters.Add(prm11);
                OracleParameter prm12 = new OracleParameter("datefrom", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (dFrom == "")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dFrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dFrom = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dFrom.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dFrom = mm + "/" + dd + "/" + yy;
                    }
                    prm12.Value = Convert.ToDateTime(dFrom).ToString ("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm12);
                OracleParameter prm13 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (dTo=="")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dTo.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dTo = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dTo.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dTo = mm + "/" + dd + "/" + yy;
                    }

                    prm13.Value = Convert.ToDateTime(dTo).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm13);
              

                OracleParameter prm3 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compCode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userId;
                objOraclecommand.Parameters.Add(prm8); 

               
               objorclDataAdapter.SelectCommand =objOraclecommand;
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


    }
}