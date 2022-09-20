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
    /// Summary description for AdvPagePositionMaster
    /// </summary>
    public class AdvPagePositionMaster:orclconnection
    {
        public AdvPagePositionMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet addadvtype()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("addadvtype.addadvtype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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
        public DataSet addpublication()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpublicationpage.bindpublicationpage_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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


        public DataSet addadvcat1(string adtypcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Addadvcatpage.Addadvcatpage_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("adtypecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adtypcode;
                objOraclecommand.Parameters.Add(prm1);



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

        public DataSet addadvcat()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Addadvcat.Addadvcat_P", ref objOracleConnection);
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


        public DataSet addeditquery(string publication)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("addeditionadv.addeditionadv_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = publication;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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


        public DataSet addsuppquery(string edition, string publication)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("addsuppadv.addsuppadv_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = edition;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = publication;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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

        public DataSet addadvsizedesc()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("addadvsizedesc.addadvsizedesc_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        public DataSet checkmulti(string compcode, string userid, string premcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkmultipremselect.checkmultipremselect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = premcode;
                objOraclecommand.Parameters.Add(prm3);

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

        public DataSet addcolor()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("addcolor.addcolor_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        public DataSet addrategrp()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("addrategrp.addrategrp_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        public DataSet addspecialposition()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("addspecialposition.addspecialposition_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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

        public DataSet listboxbind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("adadvcategory.adadvcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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



        public DataSet listboxmultibind(string compcode, string userid, string premcode, string abc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertmultiadcategory.insertmultiadcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = premcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("abc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = abc;
                objOraclecommand.Parameters.Add(prm4);


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

        public DataSet listboxmultiupdate(string compcode, string userid, string premcode, string abc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatemultiadcategory.updatemultiadcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = premcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("abc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = abc;
                objOraclecommand.Parameters.Add(prm4);

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

        //***************************************************************************************//
        //**********************************Save Function****************************************//
        //***************************************************************************************//
        public DataSet advpagesave1(string companycode, string premiumcode, string premiumname, string advtype, string advcategory, string publication, string edition, string supplement, string color, string advsizedesc, string pageno, string rategrp, string position, string premium, string txtpremium, string validtill, string validfrm, string UserId, string solus, string pageheading)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdvPageposition_Save.AdvPageposition_Save_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("premiumcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = premiumcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("premiumname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = premiumname;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = advtype;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("advcategory", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = advcategory;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm6 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = publication;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = edition;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("supplement", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = supplement;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("color", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = color;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("advsizedesc", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = advsizedesc;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pageno", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pageno;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("rategrp", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = rategrp;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("position", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = position;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("premium", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = premium;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("txtpremium", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = txtpremium;
                objOraclecommand.Parameters.Add(prm15);

               /* OracleParameter prm16 = new OracleParameter("validtill", OracleType.DateTime, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm16);*/


               OracleParameter prm16 = new OracleParameter("validtill", OracleType.DateTime, 50);
                prm16.Direction = ParameterDirection.Input;
                if (validtill == "" || validtill == null || validtill == "undefined/undefined/")
                {
                    prm16.Value = System.DBNull.Value;

                }
                else
                {
                    prm16.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm16);


               OracleParameter prm17 = new OracleParameter("validfrm", OracleType.DateTime, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = Convert.ToDateTime(validfrm).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm17);


                /*OracleParameter prm17 = new OracleParameter("validfrm", OracleType.DateTime, 50);
               prm17.Direction = ParameterDirection.Input;
               if (validfrm == "" || validfrm == null || validfrm == "undefined/undefined/")
               {
                   prm17.Value = System.DBNull.Value;

               }
               else
               {
                   prm17.Value = Convert.ToDateTime(validfrm).ToString("dd-MMMM-yyyy"); 
               }
               objOraclecommand.Parameters.Add(prm17);*/


                OracleParameter prm18 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = UserId;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("solus", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = solus;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = companycode;
                objOraclecommand.Parameters.Add(prm20);//

                OracleParameter prmpgheading = new OracleParameter("pageheading", OracleType.VarChar, 50);
                prmpgheading.Direction = ParameterDirection.Input;
                prmpgheading.Value = pageheading;
                objOraclecommand.Parameters.Add(prmpgheading);

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

        //*****************************************************************************************//
        //**********************************Modify Function****************************************//
        //*****************************************************************************************//
        public DataSet advpagemodify1(string companycode, string premiumcode, string premiumname, string advtype, string advcategory, string publication, string edition, string supplement, string color, string advsizedesc, string pageno, string rategrp, string position, string premium, string txtpremium, string validtill, string validfrm, string UserId, string solus, string pageheading)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdvPageposition_Modify.AdvPageposition_Modify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("premiumcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = premiumcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("premiumname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = premiumname;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = advtype;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("advcategory", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = advcategory;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = publication;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = edition;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("supplement", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = supplement;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("color", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = color;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("advsizedesc", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = advsizedesc;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("pageno", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pageno;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("rategrp", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = rategrp;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("position", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = position;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("premium", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = premium;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("txtpremium", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = txtpremium;
                objOraclecommand.Parameters.Add(prm15);

                /*OracleParameter prm16 = new OracleParameter("validtill", OracleType.DateTime, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm16);*/

               OracleParameter prm16 = new OracleParameter("validtill", OracleType.DateTime, 50);
                prm16.Direction = ParameterDirection.Input;
                if (validtill == "" || validtill == null || validtill == "undefined/undefined/")
                {
                    prm16.Value = System.DBNull.Value;

                }
                else
                {
                    prm16.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("validfrm", OracleType.DateTime, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = Convert.ToDateTime(validfrm).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm17);

                /*OracleParameter prm17 = new OracleParameter("validfrm", OracleType.DateTime, 50);
                prm17.Direction = ParameterDirection.Input;
                if (validfrm == "" || validfrm == null || validfrm == "undefined/undefined/")
                {
                    prm17.Value = System.DBNull.Value;

                }
                else
                {
                    prm17.Value = Convert.ToDateTime(validfrm);
                }
                objOraclecommand.Parameters.Add(prm17);*/


                OracleParameter prm18 = new OracleParameter("solus", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = solus;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prmpgheading = new OracleParameter("pageheading1", OracleType.VarChar, 50);
                prmpgheading.Direction = ParameterDirection.Input;
                prmpgheading.Value = pageheading;
                objOraclecommand.Parameters.Add(prmpgheading);

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
        public DataSet chkadvpagecode(string companycode, string UserId, string premiumcode, string adtype, string premiumname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Advpagecheck.Advpagecheck_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("premiumcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = premiumcode;
                objOraclecommand.Parameters.Add(prm2);
         

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = UserId;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adtype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("premiumname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = premiumname;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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

        //*****************************************************************************************//
        //**********************************Delete Function****************************************//
        //*****************************************************************************************//
        public DataSet advpagedelete1(string companycode, string premiumcode, string UserId)// string advtype, string advcategory, string publication, string edition, string color, string advsizedesc, string pageno, string rategrp, string position, string premium,string txtpremium,string UserId)//,string txtfrom,string  txtto)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdvPageposition_Delete.AdvPageposition_Delete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("premiumcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = premiumcode;
                objOraclecommand.Parameters.Add(prm2);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


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


        //******************************************************************************************//
        //**********************************Execute Function****************************************//
        //******************************************************************************************//
        public DataSet advpageexecute1(string companycode, string premiumcode, string premiumname, string advtype, string advcategory, string publication, string edition, string supplement, string advsizedesc, string UserId, string color, string pageno, string rategrp, string position, string premium)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdvPageposition_Execute.AdvPageposition_Execute_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("premiumcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = premiumcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("premiumname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = premiumname;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (advtype == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = advtype;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("advcategory", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (advcategory == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = advcategory;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (publication == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = publication;
                }
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("supplement", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (supplement == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = supplement;
                }
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9= new OracleParameter("advsizedesc", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (advsizedesc == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = advsizedesc;
                }
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("color", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (color == "0")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = color;
                }
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("pageno", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pageno;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("rategrp", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (rategrp == "0")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = rategrp;
                }
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("position", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (position == "0")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = position;
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("premium", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (premium == "0")
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = premium;
                }
                objOraclecommand.Parameters.Add(prm14);

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

        //**************************************Function For*****************************************//
        //*******************************See The First Record****************************************//
        //*******************************************************************************************//
     /*   public DataSet advpagefirst(string companycode, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Advpagepositionfpnl", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                objOraclecommand.Parameters["compcode"].Value = companycode;

                objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                objOraclecommand.Parameters["userid"].Value = UserId;

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
        }*/

        //**************************************Function For****************************************//
        //*******************************See The Last Record****************************************//
        //******************************************************************************************//
     /*   public DataSet advpagelast(string companycode, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Advpagepositionfpnl", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                objOraclecommand.Parameters["compcode"].Value = companycode;

                objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                objOraclecommand.Parameters["userid"].Value = UserId;

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
        }*/

        //**************************************Function For********************************************//
        //*******************************See The Previous Record****************************************//
        //**********************************************************************************************//
    /*    public DataSet advpageprevious(string companycode, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Advpagepositionfpnl", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                objOraclecommand.Parameters["compcode"].Value = companycode;

                objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                objOraclecommand.Parameters["userid"].Value = UserId;

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

        }*/

        //*************************************Function For*****************************************//
        //*******************************See The Next Record****************************************//
        //******************************************************************************************//
     /*   public DataSet advpagenext(string companycode, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Advpagepositionfpnl", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                objOraclecommand.Parameters["compcode"].Value = companycode;

                objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                objOraclecommand.Parameters["userid"].Value = UserId;

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

        }*/

        //**************************************Function For*****************************************//
        //*******************************Save The Premium Day****************************************//
        //*******************************************************************************************//
        public DataSet selectpremiumdaysave(string compcode, string premcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selectpremiumdaysave.selectpremiumdaysave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = premcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sun;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4= new OracleParameter("mon", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = mon;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("tue", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tue;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("wed", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wed;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = thu;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fri;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("sat", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = sat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("all1", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = all;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

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


        //********************Select Days for Premium According to Edition Code**********************************
        //***********************************************************************************************
        public DataSet checkeditcode(string compcode, string editcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkpremiumeditcode.checkpremiumeditcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                
                OracleParameter prm2 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


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



        public DataSet checksuppcode(string compcode, string suppcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkpremiumsuppcode.checkpremiumsuppcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = suppcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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




        //****************************************************************************************************
        //****************************************************************************************************
        // ********************************************************************************************
        public DataSet checkpremcode(string compcode, string premcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkpremiumcode.checkpremiumcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = premcode;
                objOraclecommand.Parameters.Add(prm2);

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






        //****************************************Function For*****************************************//
        //***********************************Modify The Premium Day************************************//
        //*********************************************************************************************//
        public DataSet selectpremiumdaymodify(string compcode, string premcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selectpremiumdaymodify.selectpremiumdaymodify_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = premcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sun;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("mon", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = mon;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("tue", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tue;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("wed", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wed;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = thu;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fri;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("sat", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = sat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("all1", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = all;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

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


        //********************************************************************************************//
        //**********************************Auto Generate Code****************************************//
        //********************************************************************************************//
        public DataSet autopagecode(string premname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autopremiumcode.autopremiumcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("premname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = premname;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (premname.Length > 2)
                {
                    prm2.Value = premname.Substring(0,2);
                    objOraclecommand.Parameters.Add(prm2);
                }
                else
                {
                    prm2.Value = premname;
                    objOraclecommand.Parameters.Add(prm2);
                }

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

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


    }
}