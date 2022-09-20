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
    /// Summary description for CombinationMaster
    /// </summary>
    public class CombinationMaster : connection
    {
        public CombinationMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet adtypbind(string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advtypbind_advtypbind_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }

        }

        public DataSet advdatasubcatcat(string compcode, string catcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advsubcattyp_advsubcattyp_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

              

                objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["catcode"].Value = catcode;

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

        public DataSet checkboxbind()
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("combinationcheckbox_combinationcheckbox_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet advdatacategory(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_advcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }


        }

        public DataSet sharebind(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindshare_bindshare_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }


        }

        public DataSet bindgrid(string compcode, string userid, string values, string adcat)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();

                if (adcat == "0")
                {
                    objSqlCommand = GetCommand("bindcombination_bindcombination_p", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["userid"].Value = userid;
                    if (values == null)
                    {
                        values = "";
                    }
                    objSqlCommand.Parameters.Add("values1", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["values1"].Value = values;
                }


                else
                {

                    objSqlCommand = GetCommand("getedibyvat", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["adcat"].Value = adcat;

                    objSqlCommand.Parameters.Add("checkboxname", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["checkboxname"].Value = values;

                }
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet checkcommcode(string compcode, string userid, string comcode, string combination, string adtype, string adcat, string adscat,string  pubcenter,string values1,string combindesc)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkcodecommbination_checkcodecommbination_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("comcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["comcode"].Value = comcode;

                objSqlCommand.Parameters.Add("combination", MySqlDbType.VarChar);
                objSqlCommand.Parameters["combination"].Value = combination;

                objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("adcat1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat1"].Value = adcat;

                objSqlCommand.Parameters.Add("adscat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat"].Value = adscat;

                objSqlCommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("values1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["values1"].Value = values1;

                objSqlCommand.Parameters.Add("combindesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["combindesc"].Value = combindesc;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

                                                                                    
        public DataSet insertcombination(string compcode, string userid, string comcode, string alias, string packagename, string combinationname, string codepub, string cat, string subcat, string adtype, string noedition, string editiontype, string valofchkbox, string noofinserts, string pubcenter, string split, string consumption, string validfrom, string validto, string oldpkgcd)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintocombination_insertintocombination_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("comcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["comcode"].Value = comcode;

                objSqlCommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objSqlCommand.Parameters["alias"].Value = alias;

                //objSqlCommand.Parameters.Add("share", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["share"].Value = share;
                
                objSqlCommand.Parameters.Add("packagename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["packagename"].Value = packagename;

                objSqlCommand.Parameters.Add("combinationname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["combinationname"].Value = combinationname;

                objSqlCommand.Parameters.Add("codepub", MySqlDbType.VarChar);
                objSqlCommand.Parameters["codepub"].Value = codepub;

                objSqlCommand.Parameters.Add("cat1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cat1"].Value = cat;

                objSqlCommand.Parameters.Add("subcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["subcat"].Value = subcat;

                objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("noedition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noedition"].Value = noedition;

                objSqlCommand.Parameters.Add("editiontyp", MySqlDbType.VarChar);
                objSqlCommand.Parameters["editiontyp"].Value = editiontype;

                objSqlCommand.Parameters.Add("valofchkbox", MySqlDbType.VarChar);
                objSqlCommand.Parameters["valofchkbox"].Value = valofchkbox;
                 
                objSqlCommand.Parameters.Add("noofinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinserts"].Value = noofinserts;

                objSqlCommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("split1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["split1"].Value = split;

                //objSqlCommand.Parameters.Add("consumption", MySqlDbType.Double);
                //objSqlCommand.Parameters["consumption"].Value = combinationname;

                objSqlCommand.Parameters.Add("consumption", MySqlDbType.Double);
                if (consumption == "" || consumption == null)
                {
                    objSqlCommand.Parameters["consumption"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["consumption"].Value = Convert.ToDouble(consumption);
                }

                objSqlCommand.Parameters.Add("p_validfrom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_validfrom"].Value = validfrom;
                
                objSqlCommand.Parameters.Add("p_validto", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_validto"].Value = validto;

                objSqlCommand.Parameters.Add("p_pkgcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_pkgcode"].Value = oldpkgcd;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet updatedetail(string comcode, string alias, string packagename, string combinationname, string compcode, string userid, string codepub, string cat, string subcat, string adtype, string noedition, string valofchkbox,string   noofinserts)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatecombination_updatecombination_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("comcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["comcode"].Value = comcode;

                objSqlCommand.Parameters.Add("cat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cat"].Value = cat;

                objSqlCommand.Parameters.Add("subcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["subcat"].Value = subcat;

                objSqlCommand.Parameters.Add("valofchkbox", MySqlDbType.VarChar);
                objSqlCommand.Parameters["valofchkbox"].Value = valofchkbox;


                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("noedition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noedition"].Value = noedition;



                objSqlCommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objSqlCommand.Parameters["alias"].Value = alias;

                objSqlCommand.Parameters.Add("packagename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["packagename"].Value = packagename;

                objSqlCommand.Parameters.Add("combinationname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["combinationname"].Value = combinationname;

                objSqlCommand.Parameters.Add("codepub", MySqlDbType.VarChar);
                objSqlCommand.Parameters["codepub"].Value = codepub;
                objSqlCommand.Parameters.Add("noofinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinserts"].Value = noofinserts;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet executecommmdetail(string comcode, string alias, string packagename, string compcode, string userid, string editiontype, string adtype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executecommdetail_executecommdetail_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("comcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["comcode"].Value = comcode;

                objSqlCommand.Parameters.Add("editiontype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["editiontype"].Value = editiontype;



                objSqlCommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objSqlCommand.Parameters["alias"].Value = alias;

                objSqlCommand.Parameters.Add("packagename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["packagename"].Value = packagename;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;







                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet firstcommdetail()
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("firstsearchcomm_firstdearchcomm_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;









                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet deletecommdetail(string comcode, string compcode, string userid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletecombination_deletecombination_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("comcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["comcode"].Value = comcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet checkpackage(string package, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkpackagename_chkpackagename_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet countstatecode(string str, string padtype, string ppubcenter)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcombincodemax_chkcombincodemax_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("str", MySqlDbType.VarChar);
                objSqlCommand.Parameters["str"].Value = str;

                objSqlCommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objSqlCommand.Parameters["cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objSqlCommand.Parameters["cod"].Value = str;
                }
                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = padtype;

                objSqlCommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubcenter"].Value = ppubcenter;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet getedivalbycat(string adcat, string compcode, string checkboxname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getedibyvat_getedibyvat_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcat1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat1"].Value = adcat;

                objSqlCommand.Parameters.Add("checkboxname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkboxname"].Value = checkboxname;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet geteditionbycat(string edition, string adcat, string compcode, string radioval)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionlikecatmaster_editionlikecatmaster_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edition"].Value = edition;


                objSqlCommand.Parameters.Add("adcat1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat1"].Value = adcat;


                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("radioval", MySqlDbType.VarChar);
                if (radioval == null)
                {
                    objSqlCommand.Parameters["radioval"].Value = "";
                }
                else
                {
                    objSqlCommand.Parameters["radioval"].Value = radioval;
                }

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet getedition(string edition, string radioval)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionlike_editionlike_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edition"].Value = edition;


                objSqlCommand.Parameters.Add("radioval", MySqlDbType.VarChar);
                if (radioval == null)
                {
                    objSqlCommand.Parameters["radioval"].Value = "";
                }
                else
                {
                    objSqlCommand.Parameters["radioval"].Value = radioval;
                }

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet geteditionforcontract(string edition, string radioval)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionlikeforcontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edition"].Value = edition;


                objSqlCommand.Parameters.Add("radioval", MySqlDbType.VarChar);
                if (radioval == null)
                {
                    objSqlCommand.Parameters["radioval"].Value = "";
                }
                else
                {
                    objSqlCommand.Parameters["radioval"].Value = radioval;
                }

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

      

        public DataSet bindgridpackage(string compcode, string adcat, string valuee, string pcenters,string drpadtype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();

                if (adcat == "0")
                {
                    objSqlCommand = GetCommand("bindcombination_bindcombination_p", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["compcode"].Value = compcode;
                    if (adcat == "0")
                    {
                        adcat = "";
                    }

                    objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["userid"].Value = adcat;

                    objSqlCommand.Parameters.Add("values1", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["values1"].Value = valuee;

                    objSqlCommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["pubcenter"].Value = pcenters;

                    objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["adtype1"].Value = drpadtype;

                }
                else
                {

                    objSqlCommand = GetCommand("getedibyvat_getedibyvat_p", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("adcat1", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["adcat1"].Value = adcat;

                    objSqlCommand.Parameters.Add("checkboxname", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["checkboxname"].Value = valuee;

                    objSqlCommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["pubcenter"].Value = pcenters;

                    objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                    objSqlCommand.Parameters["adtype1"].Value = drpadtype;

                }
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        // save combination days 



        public void savecomdays(string compcode, string combincode, string edicombincode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string focusday, string allday, string cnt)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("SAVE_COMBIN_DAYS_SAVE_COMBIN_DAYS_P", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("p_COMPCODE", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_COMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("p_COMBINCODE", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_COMBINCODE"].Value = combincode;

                objSqlCommand.Parameters.Add("p_EDICOMBINCODE", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_EDICOMBINCODE"].Value = edicombincode;

                objSqlCommand.Parameters.Add("p_SUN1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_SUN1"].Value = sun;

                objSqlCommand.Parameters.Add("p_MON1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_MON1"].Value = mon;

                objSqlCommand.Parameters.Add("p_TUE1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_TUE1"].Value = tue;

                objSqlCommand.Parameters.Add("p_WED1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_WED1"].Value = wed;

                objSqlCommand.Parameters.Add("p_THU1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_THU1"].Value = thu;

                objSqlCommand.Parameters.Add("p_FRI1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_FRI1"].Value = fri;

                objSqlCommand.Parameters.Add("p_SAT1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_SAT1"].Value = sat;

                objSqlCommand.Parameters.Add("p_FOCUSDAY1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_FOCUSDAY1"].Value = focusday;

                objSqlCommand.Parameters.Add("p_ALLDAY1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_ALLDAY1"].Value = allday;

                objSqlCommand.Parameters.Add("p_CNT", MySqlDbType.Int64);
                if (cnt == "" || cnt == null)
                {
                    objSqlCommand.Parameters["p_CNT"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["p_CNT"].Value = Convert.ToInt32(cnt);
                }

                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }



    }
}
