using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{

/// <summary>
/// Summary description for BrandMaster
/// </summary>
public class BrandMaster:connection 
{
	public BrandMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  public DataSet productdes(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("drpbrandproduct_drpbrandproduct_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        //Check code
       public DataSet chkcode(string code, string brandname, string drpprosub, string productcat, string productsubcat, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkbrandcode_chkbrandcode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;


                objmysqlcommand.Parameters.Add("drppro", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drppro"].Value = drpprosub;

                objmysqlcommand.Parameters.Add("brandname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandname"].Value = brandname;

                objmysqlcommand.Parameters.Add("prodcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prodcategory"].Value = productcat;

                objmysqlcommand.Parameters.Add("proobjDataSetubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["proobjDataSetubcategory"].Value = productsubcat;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }
        //Insert the value
        public DataSet insertedvalue(string drpprosub, string brandcode, string brandname, string brandalias, string compcode, string userid,string productcat,string  productsubcat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("brandinsert_brandinsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("brandcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandcode"].Value = brandcode;

                objmysqlcommand.Parameters.Add("brandname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandname"].Value = brandname;

                objmysqlcommand.Parameters.Add("brandalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandalias"].Value = brandalias;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("drppro", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drppro"].Value = drpprosub;

                objmysqlcommand.Parameters.Add("prodcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prodcategory"].Value = productcat;

                objmysqlcommand.Parameters.Add("proobjDataSetubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["proobjDataSetubcategory"].Value = productsubcat;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        //Auto generated code
    public DataSet autocode(string str, string productcategory, string productsubcategory, string product)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("brandautocode_brandautocode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;


                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if(str.Length >2)
                {
                objmysqlcommand.Parameters["cod"].Value = str.Substring (0,2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }

                objmysqlcommand.Parameters.Add("productcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["productcategory"].Value = productcategory;

                objmysqlcommand.Parameters.Add("productsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["productsubcategory"].Value = productsubcategory;

                objmysqlcommand.Parameters.Add("product", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["product"].Value = product;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref objmysqlconnection);

            }
        }

        //Execute Value
        public DataSet prosubexecute(string drpprodes, string brandcode, string brandname, string brandalias, string compcode,string productcat,string productsubcat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("brandexe_brandexe_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("drppro", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drppro"].Value = drpprodes;

                objmysqlcommand.Parameters.Add("brandcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandcode"].Value = brandcode;

                objmysqlcommand.Parameters.Add("brandname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandname"].Value = brandname;

                objmysqlcommand.Parameters.Add("brandalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandalias"].Value = brandalias;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("prodcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prodcategory"].Value = productcat;

                objmysqlcommand.Parameters.Add("prodsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prodsubcategory"].Value = productsubcat;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);

            }
        }

        //Delete The Value
        public DataSet deleteproduct(string brandcode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("branddel_branddel_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("brandcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandcode"].Value = brandcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }

            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        //Modify The Value
        public DataSet updatepro(string drpprodes, string brandcode, string brandname, string brandalias, string compcode,string productcat,string productsubcat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("brandmodify_brandmodify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("drppro", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drppro"].Value = drpprodes;

                objmysqlcommand.Parameters.Add("brandcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandcode"].Value = brandcode;

                objmysqlcommand.Parameters.Add("brandname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandname"].Value = brandname;

                objmysqlcommand.Parameters.Add("brandalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["brandalias"].Value = brandalias;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("prodcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prodcategory"].Value = productcat;

                objmysqlcommand.Parameters.Add("prodsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prodsubcategory"].Value = productsubcat;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);

            }



        }


        public DataSet prodcategory(string compcode,string procode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AN_PRODCATEGORY_AN_PRODCATEGORY_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("prodcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prodcode"].Value = procode;

                //  objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                // objmysqlcommand.Parameters["suppcode"].Value = suppcode;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }


        public DataSet prodsubcategory( string prodcatcode,string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AN_PRODSUBCATEGORY_AN_PRODSUBCATEGORY_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pro_cat_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pro_cat_code"].Value = prodcatcode;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet product(string compcode, string prodcatcode, string prodsubcatcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AN_PRODUCT_AN_PRODUCT_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("p_Compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_Compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("p_pro_cat_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_pro_cat_code"].Value = prodcatcode;

                objmysqlcommand.Parameters.Add("p_pro_subcat_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_pro_subcat_code"].Value = prodsubcatcode;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }


    }
}
