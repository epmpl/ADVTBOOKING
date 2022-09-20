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
    public class getReferenceFile : orclconnection
    {
        public getReferenceFile()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void updateclassified(string cioid, string insertion,string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getReferenceupdate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("insertion_no", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = insertion;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);


                //objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.ExecuteNonQuery();
               
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
        public DataSet getfontsizeleading(string fontname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getfonteditionwise", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fontname_p", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fontname;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
        public DataSet clsReferenceFile(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat, string center, string auditad, string includeuom, string excludeuom, string includecat, string excludecat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getReferencefile", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {

                    if (pubdate.IndexOf('-') < 0)
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    pubdate = mm + "/" + dd + "/" + yy;
                }
                prm2.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centercode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("logincenter", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = center;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("auditad", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = auditad;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("includeuom", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = includeuom;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("excludeuom", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = excludeuom;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("includecat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = includecat;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("excludecat", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = excludecat;
                objOraclecommand.Parameters.Add(prm12); 

                objOraclecommand.Parameters.Add("p_getref", OracleType.Cursor);
                objOraclecommand.Parameters["p_getref"].Direction = ParameterDirection.Output;

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
        public DataSet clsReferenceFileDict(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat, string center)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getReferencefileDict", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {

                    if (pubdate.IndexOf('-') < 0)
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;

                    }

                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    pubdate = mm + "/" + dd + "/" + yy;
                }
                prm2.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centercode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("logincenter", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = center;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_getref", OracleType.Cursor);
                objOraclecommand.Parameters["p_getref"].Direction = ParameterDirection.Output;

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
        //public DataSet bindEdition_ref(string pub)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("bindEdition_ref", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("pub", OracleType.VarChar, 50);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = pub;
        //        objOraclecommand.Parameters.Add(prm1);

              

        //        objOraclecommand.Parameters.Add("p_getref", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_getref"].Direction = ParameterDirection.Output;

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

        public void clsPublishClassifiedAd(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string iidnum, string insnum, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;            
            objOracleConnection = GetConnection();            
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_PublishClassifiedAd", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    if (pubdate.IndexOf('-') < 0)
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    pubdate = mm + "/" + dd + "/" + yy;
                }
                prm2.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centercode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("iidnum", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = iidnum;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("insnum", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = insnum;
                objOraclecommand.Parameters.Add(prm8);

                objOraclecommand.ExecuteNonQuery();

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

        public void clsInsertDetails(string pcompcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat, string p_idnum, string p_keyno, string p_adcat, string p_adsubcat, string p_adcat3, string p_adcat4, string p_uom, string packagecode, string bullet)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_insertDetails", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubdate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centercode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("p_idnum", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = p_idnum;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("p_keyno", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = p_keyno;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("p_adcat", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = p_adcat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("p_adsubcat", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = p_adsubcat;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("p_adcat3", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = p_adcat3;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("p_adcat4", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = p_adcat4;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("p_uom", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = p_uom;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("p_package", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = packagecode;
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("p_bullet", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = bullet;
                objOraclecommand.Parameters.Add(prm16);
                
                objOraclecommand.ExecuteNonQuery();

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



        public DataSet clsGenerateReport(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_GenerateReport", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubdate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centercode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = dateformat;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_getrep", OracleType.Cursor);
                objOraclecommand.Parameters["p_getrep"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_getrep1", OracleType.Cursor);
                objOraclecommand.Parameters["p_getrep1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_getrep2", OracleType.Cursor);
                objOraclecommand.Parameters["p_getrep2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_getrep3", OracleType.Cursor);
                objOraclecommand.Parameters["p_getrep3"].Direction = ParameterDirection.Output;

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
        public void clsDeleteInsertDetails(string pcompcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_deleteInsertDetails", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.ExecuteNonQuery();

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

        public DataSet clsReferenceFilepackage(string compcode, string pubdate, string dateformat, string center, string auditad, string includeuom, string excludeuom, string includecat, string excludecat, string package,string pubcode,string edicode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getReferencefile_pkg", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {

                    if (pubdate.IndexOf('-') < 0)
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    pubdate = mm + "/" + dd + "/" + yy;
                }
                prm2.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("p_package", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = package;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm7 = new OracleParameter("logincenter", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = center;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("auditad", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = auditad;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("includeuom", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = includeuom;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("excludeuom", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = excludeuom;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("includecat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = includecat;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("excludecat", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = excludecat;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm15 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pubcode;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = edicode;
                objOraclecommand.Parameters.Add(prm16);

                objOraclecommand.Parameters.Add("p_getref", OracleType.Cursor);
                objOraclecommand.Parameters["p_getref"].Direction = ParameterDirection.Output;

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

        public DataSet clsGenerateReport_pkg(string compcode, string pubdate, string packagecode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_GenerateReport_pkg", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubdate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("p_package", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = packagecode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm7 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = dateformat;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_getrep", OracleType.Cursor);
                objOraclecommand.Parameters["p_getrep"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_getrep1", OracleType.Cursor);
                objOraclecommand.Parameters["p_getrep1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_getrep2", OracleType.Cursor);
                objOraclecommand.Parameters["p_getrep2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_getrep3", OracleType.Cursor);
                objOraclecommand.Parameters["p_getrep3"].Direction = ParameterDirection.Output;

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

        //get edition filename 
        public DataSet clsEditionFileName(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string iidnum, string insnum, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_geteditionfilename", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    if (pubdate.IndexOf('-') < 0)
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;
                    }
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    pubdate = mm + "/" + dd + "/" + yy;
                }
                prm2.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centercode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("iidnum", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = iidnum;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("iinsnum", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = insnum;
                objOraclecommand.Parameters.Add(prm8);

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

    }
}
