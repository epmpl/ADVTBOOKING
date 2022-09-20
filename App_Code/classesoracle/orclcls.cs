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

/// <summary>
/// Summary description for orclcls
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class orclcls:orclconnection
    {
        public orclcls()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet fetchdata()
        {
                     
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("getsavehtml.getsavehtml_p", ref objOracleConnection);
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

        public DataSet insertxml(int t_id, string location1, string xml, string name, string fullhtml, string filterhtml, string uom, string adh, string adw, string catcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("inserthtml.inserthtml_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("temp_location", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = location1;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("temp_xml", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = xml;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("name", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("template_id", OracleType.Number);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = t_id;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("temp_html", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = fullhtml;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("temp_xhtml", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = filterhtml;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("uom", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = uom;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("adheight", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adh;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adwidth", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adw;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("catcode", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = catcode;
                objOraclecommand.Parameters.Add(prm10);


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




        public DataSet insertadxml(int a_id, string xml, string name, string fullhtml, string filterhtml, string uom1, string adh, string adw)
        {
              OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertad.insertad_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                
                OracleParameter prm1 = new OracleParameter("ad_xml", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = xml;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ad_id", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = a_id;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("name", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ad_html", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = fullhtml;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ad_xhtml", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = filterhtml;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ad_uom", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = uom1;
                objOraclecommand.Parameters.Add(prm6);

                //OracleParameter prm7 = new OracleParameter("img_name", OracleType.VarChar);
                //prm7.Direction = ParameterDirection.Input;
                //prm7.Value = img_name;
                //objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ad_height", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adh;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("ad_width", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adw;
                objOraclecommand.Parameters.Add(prm9);


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


        public DataSet updatexml(int id, string xml, string fullhtml, string xhtml)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatehtml.updatehtml_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("temp_xml", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = xml;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("template_id", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = id;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("temp_html", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fullhtml;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("temp_xhtml", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = xhtml;
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

        public DataSet updatexml1(int id, string xml, string fullhtml, string xhtml)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateadhtml.updateadhtml_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ad_xml", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = xml;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ad_id", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = id;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ad_html", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fullhtml;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ad_xhtml", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = xhtml;
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

        public DataSet fetchquerydata(string abc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getselectedVal.getselectedVal_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("abc", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = abc;
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

        public void fetchdata(DataSet ds)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataSet get_id()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("gettempid.gettempid_P", ref objOracleConnection);
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

        public DataSet getad_id()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getadid.getadid_P", ref objOracleConnection);
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

        public DataSet fetchadquerydata(string abc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getselectedadVal.getselectedadVal_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("abc", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = abc;
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

        public DataSet fetchadpreview(string addname, string adcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fatchadpreview.fatchadpreview_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("addname", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = addname;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcode;
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

        public DataSet fetchadhtmdata()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getadhtm.getadhtm_P", ref objOracleConnection);
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

        public DataSet get_adid()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getadid.getadid_P", ref objOracleConnection);
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

        public DataSet fatchcategory()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getcatname.getcatname_P", ref objOracleConnection);
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

        public DataSet fatchcatemplate(string myid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("gettemplate.gettemplate_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("myid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = myid;
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
        public DataSet fatchquerycode()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getcatname.getcatname_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accountslo"].Direction = ParameterDirection.Output;


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

        public DataSet fetchaduom(string uom)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fetchaduom.fetchaduom_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("uom", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = uom;
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

    }
}
