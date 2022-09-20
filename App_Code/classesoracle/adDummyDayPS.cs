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
    /// Summary description for adDummyDayPS
    /// </summary>
    public class adDummyDayPS : orclconnection
    {
        public adDummyDayPS()
        {
            //
            // TODO: Add constructor logic here
            //
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

              OracleParameter prm5 = new OracleParameter("edit", OracleType.VarChar);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = pubcode;
              objOraclecommand.Parameters.Add(prm5);



              OracleParameter prm6 = new OracleParameter("center", OracleType.VarChar);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = pubcenter;
              objOraclecommand.Parameters.Add(prm6);
              objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
              objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
              
              
                
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
           

              OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = pubcode;
              objOraclecommand.Parameters.Add(prm5);



              OracleParameter prm6 = new OracleParameter("editioncode", OracleType.VarChar);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = pubedit;
              objOraclecommand.Parameters.Add(prm6);
              objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
              objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


               
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
        //**********************************************************************************************************

        //**********This function is used to GET the Category using stored procedure websp_advcategory***************

        public DataSet getCategory(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_advcategory.websp_advcategory_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

              

              OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = compcode;
              objOraclecommand.Parameters.Add(prm5);
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
        //**********************************************************************************************************

        public DataSet getSubCategory(string compcode, string catcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("advsubcattyp.advsubcattyp_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;  

            



              OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = compcode;
              objOraclecommand.Parameters.Add(prm5);



              OracleParameter prm6 = new OracleParameter("catcode", OracleType.VarChar);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = catcode;
              objOraclecommand.Parameters.Add(prm6);
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
        //**********************************************************************************************************
        //**********************************************************************************************************

        //**********This function is used to check the Duplicate Data using stored procedure adDDPDupChk*********************
        public string chkDupRec(string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo)
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
                objOraclecommand = GetCommand("adDDPS_DupChk.adDDPS_DupChk_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

              OracleParameter prm6 = new OracleParameter("pub_day", OracleType.VarChar);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = day;
              objOraclecommand.Parameters.Add(prm6);

              OracleParameter prm15 = new OracleParameter("pri_pub", OracleType.VarChar);
              prm15.Direction = ParameterDirection.Input;
              prm15.Value = pubCode;
              objOraclecommand.Parameters.Add(prm15);
              OracleParameter prm1 = new OracleParameter("pub_center", OracleType.VarChar);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = centerCode;

              objOraclecommand.Parameters.Add(prm1);
              OracleParameter prm2 = new OracleParameter("edition_code", OracleType.VarChar);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = ediCode;
              objOraclecommand.Parameters.Add(prm2);
              OracleParameter prm3 = new OracleParameter("sub_pub", OracleType.VarChar);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = supCode;
              objOraclecommand.Parameters.Add(prm3);
              OracleParameter prm7 = new OracleParameter("page_no", OracleType.VarChar);
              prm7.Direction = ParameterDirection.Input;
              prm7.Value = Convert.ToInt32(pageNo);
              objOraclecommand.Parameters.Add(prm7);
              objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
              objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;









            


           

            

   


        

             
          

                
                objorclDataAdapter.SelectCommand = objOraclecommand;

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

        //**********This function is used to Insert the Data using stored procedure adDDPInsert***************

        public DataSet insertData(string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo, string pageHead, string nPages, string adCtg, string subAdCtg, string maxRow, string maxCol, string startRow, string startCol, string maxAd, string pagiCode, string dFrom, string dTo, string ladStatus, string pDate, string pColor, string adVolume, string compCode, string userId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adDDPS_Insert.adDDPS_Insert_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;



              OracleParameter prm6 = new OracleParameter("pub_day", OracleType.VarChar);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = day;
              objOraclecommand.Parameters.Add(prm6);

              OracleParameter prm15 = new OracleParameter("pri_pub", OracleType.VarChar);
              prm15.Direction = ParameterDirection.Input;
              prm15.Value = pubCode;
              objOraclecommand.Parameters.Add(prm15);
              OracleParameter prm1 = new OracleParameter("pub_center", OracleType.VarChar);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = centerCode;

              objOraclecommand.Parameters.Add(prm1);
              OracleParameter prm2 = new OracleParameter("edition_code", OracleType.VarChar);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = ediCode;
              objOraclecommand.Parameters.Add(prm2);
              OracleParameter prm3 = new OracleParameter("sub_pub", OracleType.VarChar);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = supCode;
              objOraclecommand.Parameters.Add(prm3);
              OracleParameter prm7 = new OracleParameter("page_no", OracleType.VarChar);
              prm7.Direction = ParameterDirection.Input;
              prm7.Value = Convert.ToInt32(pageNo);
              objOraclecommand.Parameters.Add(prm7);


              

             OracleParameter prm13 = new OracleParameter("page_heading", OracleType.VarChar);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = pageHead;
             objOraclecommand.Parameters.Add(prm13);

              OracleParameter prm17 = new OracleParameter("npages", OracleType.VarChar);
              prm17.Direction = ParameterDirection.Input;
              prm17.Value = Convert.ToInt32(nPages);
              objOraclecommand.Parameters.Add(prm17);
              OracleParameter prm18 = new OracleParameter("priadctg", OracleType.VarChar);
              prm18.Direction = ParameterDirection.Input;
              prm18.Value = adCtg;
              objOraclecommand.Parameters.Add(prm18);

              OracleParameter prm19 = new OracleParameter("secadctg", OracleType.VarChar);
              prm19.Direction = ParameterDirection.Input;
              prm19.Value = subAdCtg;
              objOraclecommand.Parameters.Add(prm19);

           

              OracleParameter prm20 = new OracleParameter("max_row", OracleType.VarChar);
              prm20.Direction = ParameterDirection.Input;
              prm20.Value = Convert.ToInt32(maxRow);
              objOraclecommand.Parameters.Add(prm20);



              OracleParameter prm21 = new OracleParameter("max_col", OracleType.VarChar);
              prm21.Direction = ParameterDirection.Input;
              prm21.Value = Convert.ToInt32(maxCol);
              objOraclecommand.Parameters.Add(prm21);

              OracleParameter prm22 = new OracleParameter("starting_row", OracleType.VarChar);
              prm22.Direction = ParameterDirection.Input;
              prm22.Value = Convert.ToInt32(startRow);
              objOraclecommand.Parameters.Add(prm22);
              OracleParameter prm23 = new OracleParameter("starting_col", OracleType.VarChar);
              prm23.Direction = ParameterDirection.Input;
              prm23.Value = Convert.ToInt32(maxRow);
              objOraclecommand.Parameters.Add(prm23);
              OracleParameter prm24 = new OracleParameter("max_ad", OracleType.VarChar);
              prm24.Direction = ParameterDirection.Input;
              prm24.Value = Convert.ToInt32(maxAd);
              objOraclecommand.Parameters.Add(prm24);
              OracleParameter prm25= new OracleParameter("pagination_code", OracleType.VarChar);
              prm25.Direction = ParameterDirection.Input;
              prm25.Value = pagiCode;
              objOraclecommand.Parameters.Add(prm25);
              OracleParameter prm26 = new OracleParameter("datefrom", OracleType.VarChar);
              prm26.Direction = ParameterDirection.Input;
              prm26.Value = Convert.ToDateTime(dFrom).ToString("dd-MMMM-yyyy");
              objOraclecommand.Parameters.Add(prm26);
              OracleParameter prm27 = new OracleParameter("dateto", OracleType.VarChar);
              prm27.Direction = ParameterDirection.Input;
              prm27.Value = Convert.ToDateTime(dTo).ToString("dd-MMMM-yyyy");
              objOraclecommand.Parameters.Add(prm27);

              OracleParameter prm28 = new OracleParameter("ladder_status", OracleType.VarChar);
              prm28.Direction = ParameterDirection.Input;
              prm28.Value = ladStatus;
              objOraclecommand.Parameters.Add(prm28);
              OracleParameter prm29 = new OracleParameter("pdate", OracleType.VarChar);
              prm29.Direction = ParameterDirection.Input;
              prm29.Value = Convert.ToDateTime(pDate).ToString("dd-MMMM-yyyy");
              objOraclecommand.Parameters.Add(prm29);
              OracleParameter prm30 = new OracleParameter("page_color", OracleType.VarChar);
              prm30.Direction = ParameterDirection.Input;
              prm30.Value = pColor;
              objOraclecommand.Parameters.Add(prm30);

              OracleParameter prm31 = new OracleParameter("ad_volume", OracleType.VarChar);
              prm31.Direction = ParameterDirection.Input;
              prm31.Value = adVolume;
              objOraclecommand.Parameters.Add(prm31);
              OracleParameter prm32 = new OracleParameter("comp_code", OracleType.VarChar);
              prm32.Direction = ParameterDirection.Input;
              prm32.Value = compCode;
              objOraclecommand.Parameters.Add(prm32);
              OracleParameter prm33 = new OracleParameter("userid", OracleType.VarChar);
              prm33.Direction = ParameterDirection.Input;
              prm33.Value = userId;
              objOraclecommand.Parameters.Add(prm33);          




               
                objorclDataAdapter.SelectCommand = objOraclecommand;
                // objOraclecommand.ExecuteNonQuery();
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

        //******This is used to Update the data mod stand for modification, on the basis of this data update will occur************
        public DataSet updateData(string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo, string pageHead, string nPages, string adCtg, string subAdCtg, string maxRow, string maxCol, string startRow, string startCol, string maxAd, string pagiCode, string dFrom, string dTo, string ladStatus, string pDate, string pColor, string adVolume, string compCode, string modDay, string modPubCode, string modCenterCode, string modEdiCode, string modSupCode, string modPageNo)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adDDPS_Modify.adDDPS_Modify_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;




              OracleParameter prm6 = new OracleParameter("pub_day", OracleType.VarChar);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = day;
              objOraclecommand.Parameters.Add(prm6);

              OracleParameter prm15 = new OracleParameter("pri_pub", OracleType.VarChar);
              prm15.Direction = ParameterDirection.Input;
              prm15.Value = pubCode;
              objOraclecommand.Parameters.Add(prm15);
              OracleParameter prm1 = new OracleParameter("pub_center", OracleType.VarChar);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = centerCode;

              objOraclecommand.Parameters.Add(prm1);
              OracleParameter prm2 = new OracleParameter("edition_code", OracleType.VarChar);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = ediCode;
              objOraclecommand.Parameters.Add(prm2);
              OracleParameter prm3 = new OracleParameter("sub_pub", OracleType.VarChar);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = supCode;
              objOraclecommand.Parameters.Add(prm3);
              OracleParameter prm7 = new OracleParameter("page_no", OracleType.VarChar);
              prm7.Direction = ParameterDirection.Input;
              prm7.Value = Convert.ToInt32(pageNo);
              objOraclecommand.Parameters.Add(prm7);




              OracleParameter prm13 = new OracleParameter("page_heading", OracleType.VarChar);
              prm13.Direction = ParameterDirection.Input;
              prm13.Value = pageHead;
              objOraclecommand.Parameters.Add(prm13);

              OracleParameter prm17 = new OracleParameter("npages", OracleType.VarChar);
              prm17.Direction = ParameterDirection.Input;
              prm17.Value = Convert.ToInt32(nPages);
              objOraclecommand.Parameters.Add(prm17);
              OracleParameter prm18 = new OracleParameter("priadctg", OracleType.VarChar);
              prm18.Direction = ParameterDirection.Input;
              prm18.Value = adCtg;
              objOraclecommand.Parameters.Add(prm18);

              OracleParameter prm19 = new OracleParameter("secadctg", OracleType.VarChar);
              prm19.Direction = ParameterDirection.Input;
              prm19.Value = subAdCtg;
              objOraclecommand.Parameters.Add(prm19);



              OracleParameter prm20 = new OracleParameter("max_row", OracleType.VarChar);
              prm20.Direction = ParameterDirection.Input;
              prm20.Value = Convert.ToInt32(maxRow);
              objOraclecommand.Parameters.Add(prm20);



              OracleParameter prm21 = new OracleParameter("max_col", OracleType.VarChar);
              prm21.Direction = ParameterDirection.Input;
              prm21.Value = Convert.ToInt32(maxCol);
              objOraclecommand.Parameters.Add(prm21);

              OracleParameter prm22 = new OracleParameter("starting_row", OracleType.VarChar);
              prm22.Direction = ParameterDirection.Input;
              prm22.Value = Convert.ToInt32(startRow);
              objOraclecommand.Parameters.Add(prm22);

              OracleParameter prm23 = new OracleParameter("starting_col", OracleType.VarChar);
              prm23.Direction = ParameterDirection.Input;
              prm23.Value = Convert.ToInt32(startCol);
              objOraclecommand.Parameters.Add(prm23);

              OracleParameter prm24 = new OracleParameter("max_ad", OracleType.VarChar);
              prm24.Direction = ParameterDirection.Input;
              prm24.Value = Convert.ToInt32(maxAd);
              objOraclecommand.Parameters.Add(prm24);

              OracleParameter prm25 = new OracleParameter("pagination_code", OracleType.VarChar);
              prm25.Direction = ParameterDirection.Input;
              prm25.Value = pagiCode;
              objOraclecommand.Parameters.Add(prm25);

              OracleParameter prm26 = new OracleParameter("datefrom", OracleType.VarChar);
              prm26.Direction = ParameterDirection.Input;
              prm26.Value = Convert.ToDateTime(dFrom).ToString("dd-MMMM-yyyy");
              objOraclecommand.Parameters.Add(prm26);

              OracleParameter prm27 = new OracleParameter("dateto", OracleType.VarChar);
              prm27.Direction = ParameterDirection.Input;
              prm27.Value = Convert.ToDateTime(dTo).ToString("dd-MMMM-yyyy");
              objOraclecommand.Parameters.Add(prm27);

              OracleParameter prm28 = new OracleParameter("ladder_status", OracleType.VarChar);
              prm28.Direction = ParameterDirection.Input;
              prm28.Value = ladStatus;
              objOraclecommand.Parameters.Add(prm28);

              OracleParameter prm29 = new OracleParameter("pdate", OracleType.VarChar);
              prm29.Direction = ParameterDirection.Input;
              prm29.Value = Convert.ToDateTime(pDate).ToString("dd-MMMM-yyyy");
              objOraclecommand.Parameters.Add(prm29);

              OracleParameter prm30 = new OracleParameter("page_color", OracleType.VarChar);
              prm30.Direction = ParameterDirection.Input;
              prm30.Value = pColor;
              objOraclecommand.Parameters.Add(prm30);

              OracleParameter prm31 = new OracleParameter("ad_volume", OracleType.VarChar);
              prm31.Direction = ParameterDirection.Input;
              prm31.Value = adVolume;
              objOraclecommand.Parameters.Add(prm31);

              OracleParameter prm32 = new OracleParameter("comp_code", OracleType.VarChar);
              prm32.Direction = ParameterDirection.Input;
              prm32.Value = compCode;
              objOraclecommand.Parameters.Add(prm32);

              OracleParameter prm33 = new OracleParameter("mod_pub_day", OracleType.VarChar);
              prm33.Direction = ParameterDirection.Input;
              prm33.Value = modDay;
              objOraclecommand.Parameters.Add(prm33);

              OracleParameter prm34 = new OracleParameter("mod_pri_pub", OracleType.VarChar);
              prm34.Direction = ParameterDirection.Input;
              prm34.Value = modPubCode;
              objOraclecommand.Parameters.Add(prm34);

              OracleParameter prm35 = new OracleParameter("mod_pub_center", OracleType.VarChar);
              prm35.Direction = ParameterDirection.Input;
              prm35.Value = modCenterCode;
              objOraclecommand.Parameters.Add(prm35);

              OracleParameter prm36 = new OracleParameter("mod_edition_code", OracleType.VarChar);
              prm36.Direction = ParameterDirection.Input;
              prm36.Value = modEdiCode;
              objOraclecommand.Parameters.Add(prm36);

              OracleParameter prm37 = new OracleParameter("mod_sub_pub", OracleType.VarChar);
              prm37.Direction = ParameterDirection.Input;
              prm37.Value = modSupCode;
              objOraclecommand.Parameters.Add(prm37);

              OracleParameter prm38 = new OracleParameter("mod_page_no", OracleType.VarChar);
              prm38.Direction = ParameterDirection.Input;
              prm38.Value = Convert.ToInt32(modPageNo);
              objOraclecommand.Parameters.Add(prm38);  


         

               
                objorclDataAdapter.SelectCommand = objOraclecommand;
                // objOraclecommand.ExecuteNonQuery();
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
        //**********************************************************************************************************
        public DataSet getData(string compCode, string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adDDPS_Execute.adDDPS_Execute_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

            

              OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = compCode;
              objOraclecommand.Parameters.Add(prm1);


              OracleParameter prm6 = new OracleParameter("pub_day", OracleType.VarChar);
              prm6.Direction = ParameterDirection.Input;
              if (day=="0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
              prm6.Value = day;

                }
              objOraclecommand.Parameters.Add(prm6);

              OracleParameter prm15 = new OracleParameter("pri_pub", OracleType.VarChar);
              prm15.Direction = ParameterDirection.Input;
              if (pubCode == "" || pubCode=="0")
              {
                  prm15.Value = System.DBNull.Value;

              }
              else
              {

                  prm15.Value = pubCode;
              }
              objOraclecommand.Parameters.Add(prm15);
              OracleParameter prm21 = new OracleParameter("pub_center", OracleType.VarChar);
              prm21.Direction = ParameterDirection.Input;
              if (centerCode == "" || centerCode == "0")
              {
                  prm21.Value = System.DBNull.Value;
              }
              else
              {
                  prm21.Value = centerCode;
              }

              objOraclecommand.Parameters.Add(prm21);
              OracleParameter prm2 = new OracleParameter("edition_code", OracleType.VarChar);
              prm2.Direction = ParameterDirection.Input;
              if (ediCode == "" || ediCode == "0")
              {
                  prm2.Value = System.DBNull.Value;
              }
              else
              {
                  prm2.Value = ediCode;
              }
              objOraclecommand.Parameters.Add(prm2);
              OracleParameter prm3 = new OracleParameter("sub_pub", OracleType.VarChar);
              prm3.Direction = ParameterDirection.Input;
              if (supCode == "" || supCode == "0")
              {
                  prm3.Value = System.DBNull.Value;

                  
              }
              else
              {
                  prm3.Value = supCode;
              }
              objOraclecommand.Parameters.Add(prm3);
              OracleParameter prm7 = new OracleParameter("page_no", OracleType.VarChar);
              prm7.Direction = ParameterDirection.Input;
              if (pageNo == "")
              {
                  prm7.Value = System.DBNull.Value;
              }
              else
              {
                  prm7.Value = Convert.ToInt32(pageNo);
              }
              objOraclecommand.Parameters.Add(prm7);

              objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
              objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;








             

         

           

              

            


              

               
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
        //**********************************************************************************************************
        //**********************************************************************************************************
        public DataSet deleteData(string compCode, string day, string pubCode, string centerCode, string ediCode, string supCode, string pageNo)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adDDPS_Delete.adDDPS_Delete_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

              OracleParameter prm15 = new OracleParameter("pri_pub", OracleType.VarChar);
              prm15.Direction = ParameterDirection.Input;
              prm15.Value = pubCode;
              objOraclecommand.Parameters.Add(prm15);
              OracleParameter prm1 = new OracleParameter("pub_center", OracleType.VarChar);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = centerCode;

              objOraclecommand.Parameters.Add(prm1);
              OracleParameter prm2 = new OracleParameter("edition_code", OracleType.VarChar);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = ediCode;
              objOraclecommand.Parameters.Add(prm2);
              OracleParameter prm3 = new OracleParameter("sub_pub", OracleType.VarChar);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = supCode;
              objOraclecommand.Parameters.Add(prm3);
              OracleParameter prm7 = new OracleParameter("page_no", OracleType.VarChar);
              prm7.Direction = ParameterDirection.Input;
              prm7.Value = Convert.ToInt32(pageNo);
              objOraclecommand.Parameters.Add(prm7);   

         


             



              OracleParameter prm5 = new OracleParameter("comp_code", OracleType.VarChar);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = compCode;
              objOraclecommand.Parameters.Add(prm5);



              OracleParameter prm6 = new OracleParameter("pub_day", OracleType.VarChar);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = day;
              objOraclecommand.Parameters.Add(prm6);

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
        //***********************************************************************************************************
    }
}