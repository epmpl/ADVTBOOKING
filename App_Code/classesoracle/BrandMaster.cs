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
    /// Summary description for BrandMaster
    /// </summary>
    public class BrandMaster : orclconnection
    {
        public BrandMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet productdes(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("drpbrandproduct.drpbrandproduct_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

        
               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);
               objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
               objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        //Check code
        //public DataSet chkcode(string code, string brandname, string drpprosub, string productcat, string productsubcat, string compcode)
        public DataSet chkcode(string code,string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkbrandcode.chkbrandcode_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

            
           
               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("code", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = code;
               objOraclecommand.Parameters.Add(prm2) ;


               //OracleParameter prm3 = new OracleParameter("drppro", OracleType.VarChar, 50);
               //prm3.Direction = ParameterDirection.Input;
               //prm3.Value = drpprosub;
               //objOraclecommand.Parameters.Add(prm3);


               //OracleParameter prm4 = new OracleParameter("brandname", OracleType.VarChar, 50);
               //prm4.Direction = ParameterDirection.Input;
               //prm4.Value = brandname;
               //objOraclecommand.Parameters.Add(prm4);

               //OracleParameter prm5 = new OracleParameter("prodcategory", OracleType.VarChar, 50);
               //prm5.Direction = ParameterDirection.Input;
               //prm5.Value = productcat;
               //objOraclecommand.Parameters.Add(prm5);


               //OracleParameter prm7 = new OracleParameter("proobjDataSetubcategory", OracleType.VarChar, 50);
               //prm7.Direction = ParameterDirection.Input;
               //prm7.Value = productsubcat;
               //objOraclecommand.Parameters.Add(prm7);



               objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
               objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand =objOraclecommand;
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
        //Insert the value
        public DataSet insertedvalue(string drpprosub, string brandcode, string brandname, string brandalias, string compcode, string userid, string productcat, string productsubcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("brandinsert.brandinsert_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm1 = new OracleParameter("drppro", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = drpprosub;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("brandcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = brandcode;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("brandname", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = brandname;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("brandalias", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = brandalias;
               objOraclecommand.Parameters.Add(prm4);



               OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = compcode;
               objOraclecommand.Parameters.Add(prm6);
               OracleParameter prm5 = new OracleParameter("prodcategory", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = productcat;
               objOraclecommand.Parameters.Add(prm5);
               OracleParameter prm7 = new OracleParameter("proobjDataSetubcategory", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = productsubcat;
               objOraclecommand.Parameters.Add(prm7);
               OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = userid;
               objOraclecommand.Parameters.Add(prm8);


                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        //Auto generated code
        public DataSet autocode(string str, string productcategory, string productsubcategory, string product ,string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("brandautocode.brandautocode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("str", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm6 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm6.Value = str.Substring(0, 2);
                }
                else
                {
                    prm6.Value = str;
                }

                OracleParameter prm1 = new OracleParameter("productcategory", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = productcategory;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("productsubcategory", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = productsubcategory;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("product", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = product;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pcomp", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add(prm6);
                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

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

        //Execute Value
        public DataSet prosubexecute(string drpprodes, string brandcode, string brandname, string brandalias, string compcode, string productcat, string productsubcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("brandexe.brandexe_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm1 = new OracleParameter("drppro", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               if (drpprodes=="0")
                {
                     prm1.Value = System .DBNull .Value;

                }
                else
                {
               prm1.Value = drpprodes;
                }
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("brandcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = brandcode;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("brandname", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = brandname;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("brandalias", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = brandalias;
               objOraclecommand.Parameters.Add(prm4);



               OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = compcode;
               objOraclecommand.Parameters.Add(prm6);
               OracleParameter prm5 = new OracleParameter("prodcategory", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               if (productcat=="0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
               prm5.Value = productcat;
                }
               objOraclecommand.Parameters.Add(prm5);
               OracleParameter prm7 = new OracleParameter("prodsubcategory", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               if (productsubcat=="0")
                {
                    prm7.Value = System .DBNull .Value;
                }
                else
                {
                    prm7.Value = productsubcat;
                }
               
               objOraclecommand.Parameters.Add(prm7);
               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


              
                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        //Delete The Value
        public DataSet deleteproduct(string brandcode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("branddel.branddel_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm2 = new OracleParameter("brandcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = brandcode;
               objOraclecommand.Parameters.Add(prm2);
               OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = compcode;
               objOraclecommand.Parameters.Add(prm6);


                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        //Modify The Value
        public DataSet updatepro(string drpprodes, string brandcode, string brandname, string brandalias, string compcode, string productcat, string productsubcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("brandmodify.brandmodify_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               OracleParameter prm1 = new OracleParameter("drppro", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = drpprodes;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("brandcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = brandcode;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("brandname", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = brandname;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("brandalias", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = brandalias;
               objOraclecommand.Parameters.Add(prm4);



               OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = compcode;
               objOraclecommand.Parameters.Add(prm6);
               OracleParameter prm5 = new OracleParameter("prodcategory", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = productcat;
               objOraclecommand.Parameters.Add(prm5);
               OracleParameter prm7 = new OracleParameter("proobjDataSetubcategory", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = productsubcat;
               objOraclecommand.Parameters.Add(prm7);

            


                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet prodcategory(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AN_PRODCATEGORY.AN_PRODCATEGORY_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

           

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

              



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


        public DataSet prodsubcategory(string prodcatcode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AN_PRODSUBCATEGORY.AN_PRODSUBCATEGORY_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pro_cat_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = prodcatcode;
                objOraclecommand.Parameters.Add(prm2);
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

        public DataSet product(string compcode, string prodcatcode, string proobjDataSetubcatcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AN_PRODUCT_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pro_cat_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = prodcatcode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("pro_subcat_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;

                if (proobjDataSetubcatcode == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = proobjDataSetubcatcode;
                }

               // prm3.Value = proobjDataSetubcatcode;
                objOraclecommand.Parameters.Add(prm3);
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

        //public DataSet prodsubcategory(string prodcatcode, string compcode)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("AN_PRODSUBCATEGORY.AN_PRODSUBCATEGORY_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

               


        //        OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("pro_cat_code", OracleType.VarChar, 50);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = prodcatcode;
        //        objOraclecommand.Parameters.Add(prm2);

        //        objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



        //        objorclDataAdapter.SelectCommand = objOraclecommand;
        //        objorclDataAdapter.Fill(objDataSet);

        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objOracleConnection);
        //    }

        //}


    }
}
