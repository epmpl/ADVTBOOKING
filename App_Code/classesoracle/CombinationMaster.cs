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
    /// Summary description for CombinationMaster
    /// </summary>
    public class CombinationMaster : orclconnection
    {
        public CombinationMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet advdatasubcatcatstate(string compcode, string catcode, string agencycode, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advdatasubcatcatstate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                //objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                OracleParameter prm3 = new OracleParameter("catcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = catcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm3a = new OracleParameter("agencycode", OracleType.VarChar);
                prm3a.Direction = ParameterDirection.Input;
                prm3a.Value = agencycode;
                objOraclecommand.Parameters.Add(prm3a);

                OracleParameter prm3aa = new OracleParameter("type", OracleType.VarChar);
                prm3aa.Direction = ParameterDirection.Input;
                prm3aa.Value = type;
                objOraclecommand.Parameters.Add(prm3aa);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref  objOracleConnection);
            }

        }
        public DataSet adtypbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("advtypbind.advtypbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
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

        public DataSet bindgrid(string compcode, string userid, string values, string adcat, string pubcenter, string adtype1)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                if (adcat == "0")
                {
                    objOraclecommand = GetCommand("bindcombination.bindcombination_p", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = compcode;
                    objOraclecommand.Parameters.Add(prm2);

                    OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = userid;
                    objOraclecommand.Parameters.Add(prm3);

                   
                    OracleParameter prm4 = new OracleParameter("values1", OracleType.VarChar);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = values;
                    objOraclecommand.Parameters.Add(prm4);

                    OracleParameter prm5 = new OracleParameter("pubcenter", OracleType.VarChar);
                    prm5.Direction = ParameterDirection.Input;
                    prm5.Value = pubcenter;
                    objOraclecommand.Parameters.Add(prm5);

                    OracleParameter prm6 = new OracleParameter("adtype1", OracleType.VarChar);
                    prm6.Direction = ParameterDirection.Input;
                    prm6.Value = adtype1;
                    objOraclecommand.Parameters.Add(prm6);
                }


                else
                {

                    objOraclecommand = GetCommand("getedibyvat.getedibyvat_p", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = compcode;
                    objOraclecommand.Parameters.Add(prm2);


                    OracleParameter prm5 = new OracleParameter("adcat1", OracleType.VarChar);
                    prm5.Direction = ParameterDirection.Input;
                    prm5.Value = adcat;
                    objOraclecommand.Parameters.Add(prm5);

                    OracleParameter prm6= new OracleParameter("checkboxname", OracleType.VarChar);
                    prm6.Direction = ParameterDirection.Input;
                    prm6.Value = values;
                    objOraclecommand.Parameters.Add(prm6);

                    OracleParameter prm7 = new OracleParameter("pubcenter", OracleType.VarChar);
                    prm7.Direction = ParameterDirection.Input;
                    prm7.Value = pubcenter;
                    objOraclecommand.Parameters.Add(prm7);

                    OracleParameter prm8 = new OracleParameter("adtype1", OracleType.VarChar);
                    prm8.Direction = ParameterDirection.Input;
                    prm8.Value = adtype1;
                    objOraclecommand.Parameters.Add(prm8);
                }
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

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



        public DataSet checkboxbind()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("combinationcheckbox.combinationcheckbox_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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


        public DataSet checkcommcode(string comcode, string compcode, string userid, string combination, string adtype, string adcat, string adscat, string pubcenter, string combindesc, string values1)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkcodecommbination.checkcodecommbination_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("comcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = comcode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5= new OracleParameter("combination", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = combination;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adtype1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adtype;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adcat1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcat;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("adscat", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value =adscat;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("values1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = values1;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("combindesc", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = combindesc;
                objOraclecommand.Parameters.Add(prm11);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNTS1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNTS2", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS2"].Direction = ParameterDirection.Output;


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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


        public DataSet insertcombination(string comcode, string alias, string packagename, string combinationname, string compcode, string userid, string codepub, string cat, string subcat, string adtype, string noedition, string editiontype, string valofchkbox, string noofinserts, string pubcenter, string split, string consumption,string validfrom,string validto )
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                string dateformat = "dd/mm/yyyy";

                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertintocombination.insertintocombination_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("comcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = comcode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("editiontyp", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editiontype;
                objOraclecommand.Parameters.Add(prm5);

                //objSqlCommand.Parameters.Add("@share", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@share"].Value = share;

                OracleParameter prm6 = new OracleParameter("packagename", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = packagename;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("cat1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = cat;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("adtype1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adtype;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("noedition", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = noedition;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("subcat", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = subcat;
                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("alias", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value =alias;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("valofchkbox", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = valofchkbox;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("combinationname", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = combinationname;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("codepub", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = codepub;
                objOraclecommand.Parameters.Add(prm14);
               
                OracleParameter prm15 = new OracleParameter("noofinserts", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = noofinserts;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("split1", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = split;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("consumption", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = consumption;
                objOraclecommand.Parameters.Add(prm18);

                
                OracleParameter prm19 = new OracleParameter("p_validfrom", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;

                if (validfrom == "")
                {
                    prm19.Value = System.DBNull.Value.ToString();

                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfrom = mm + "/" + dd + "/" + yy;
                    }
                    prm19.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy");
                }
                  
                objOraclecommand.Parameters.Add(prm19);




                OracleParameter prm20 = new OracleParameter("p_validto", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;

                if (validto == "")
                {
                    prm20.Value = System.DBNull.Value.ToString();

                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validto = mm + "/" + dd + "/" + yy;
                    }
                    prm20.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy");
                }
                  
                   objOraclecommand.Parameters.Add(prm20);

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet executecommmdetail(string comcode, string alias, string packagename, string compcode, string userid, string editiontype, string adtype, string pubcenter,string split,string oldpkg)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executecommdetail.executecommdetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

             

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm25 = new OracleParameter("comcode", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = comcode;
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm5 = new OracleParameter("editiontyp", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editiontype;
                objOraclecommand.Parameters.Add(prm5);


               
                OracleParameter prm6 = new OracleParameter("packagename", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = packagename;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("alias", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = alias;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("adtype1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (adtype=="0")

                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {

                prm8.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm_pcenter = new OracleParameter("pubcenter", OracleType.VarChar);
                prm_pcenter.Direction = ParameterDirection.Input;
                if (pubcenter == "0")
                {
                    prm_pcenter.Value = System.DBNull.Value;
                }
                else
                {
                    prm_pcenter.Value = pubcenter;
                }
                objOraclecommand.Parameters.Add(prm_pcenter);

                OracleParameter prm9 = new OracleParameter("split1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (split == "0")

                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {

                    prm9.Value = split;
                }
                objOraclecommand.Parameters.Add(prm9);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

        public DataSet firstcommdetail()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("firstsearchcomm.firstdearchcomm_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet deletecommdetail(string comcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletecombination.deletecombination_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("comcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = comcode;
                objOraclecommand.Parameters.Add(prm4);

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

        public DataSet getedition(string edition, string radioval)
        {
            
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionlike.editionlike_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("edition", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edition;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("radioval", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (radioval == null)
                {
                    prm3.Value = "";
                }
                else
                {
                    prm3.Value = radioval;
                }
               
              
               
               objOraclecommand.Parameters.Add(prm3);


               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

               //objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
               //objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

               //objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
               //objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

               //objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
               //objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;



               

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet geteditionforcontract(string edition, string radioval)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionlikeforcontract.editionlikeforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("edition", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edition;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("radioval", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (radioval == null)
                {
                prm3.Value = "";
                }
                else
                {
                    prm3.Value = radioval;
                }
                objOraclecommand.Parameters.Add(prm3);
                
               



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

        public DataSet geteditionbycat(string edition, string adcat, string compcode, string radioval)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionlikecatmaster.editionlikecatmaster_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm2 = new OracleParameter("edition", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edition;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("adcat1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcat;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("radioval", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (radioval==null)
                {
                    prm5.Value = "";

                }
                else
                {
                    prm5.Value = radioval;
                }
                
               objOraclecommand.Parameters.Add(prm5);



               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //if (radioval == null)
                //{
                //    objOraclecommand.Parameters["@radioval"].Value = "";
                //}
                //else
                //{
                //    objOraclecommand.Parameters["@radioval"].Value = radioval;
                //}

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        public DataSet updatedetail(string comcode, string alias, string packagename, string combinationname, string compcode, string userid, string codepub, string cat, string subcat, string adtype, string noedition, string valofchkbox, string noofinserts, string split, string consumption, string valid_from, string valid_to, string CENTER, string oldpkg)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {

                string dateformat = "dd/mm/yyyy";

                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatecombination.updatecombination_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;





                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("comcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = comcode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("CAT1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cat;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("subcat", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = subcat;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm61 = new OracleParameter("valofchkbox", OracleType.VarChar);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = valofchkbox;
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm7 = new OracleParameter("Adtype1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("noedition", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = noedition;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("alias", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = alias;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("packagename", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = packagename;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("combinationname", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = combinationname;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("codepub", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = codepub;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("noofinserts", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = noofinserts;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("split1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = split;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("consumption", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = consumption;
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("p_validfrom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                

                if (valid_from == "")
                {
                    prm16.Value = System.DBNull.Value.ToString();
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = valid_from.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        valid_from = mm + "/" + dd + "/" + yy;
                    }
                    prm16.Value = Convert.ToDateTime(valid_from).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm16);



                OracleParameter prm17 = new OracleParameter("p_validto", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (valid_to == "")
                {
                    prm17.Value = System.DBNull.Value.ToString();
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = valid_to.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        valid_to = mm + "/" + dd + "/" + yy;
                    }
                    prm17.Value = Convert.ToDateTime(valid_to).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("p_center", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = CENTER;
                objOraclecommand.Parameters.Add(prm13);

                //
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref  objOracleConnection);
            }
        }


        public DataSet advdatacat(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advcattyp.advcattyp_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref  objOracleConnection);
            }


        }
        public DataSet advdatacategory(string compcode)
        {
           OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_advcategory.websp_advcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


               
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref  objOracleConnection);
            }


        }


        public DataSet advdatasubcatcat(string compcode, string catcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advsubcattyp.advsubcattyp_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                //objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                OracleParameter prm3 = new OracleParameter("catcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = catcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref  objOracleConnection);
            }

        }



        public DataSet sharebind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindshare.bindshare_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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






        public DataSet getedivalbycat(string adcat,string compcode,string checkboxname,string pubcenter,string adtype1)
        {
           OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getedibyvat.getedibyvat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("adcat1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcat;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("checkboxname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value =checkboxname;
                objOraclecommand.Parameters.Add(prm4);
               
                OracleParameter prm7 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("adtype1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adtype1;
                objOraclecommand.Parameters.Add(prm8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;




                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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



        public DataSet countstatecode(string str,string adtype, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcombincodemax.chkcombincodemax_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("str", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("adtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adtype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("cod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if(str.Length >2)
                {
                prm3.Value = str.Substring (0,2);
                }
                else
                {
                    prm3.Value = str;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm41 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm41);
                  
                
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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


        public DataSet checkpackage(string package,string compcode,string adtype)
        {
           OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkpackagename.chkpackagename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("package1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = package;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("adtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adtype;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

        public DataSet packcode(string package, string compcode)
        {
           OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getpackagecode.getpackagecode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("package", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = package;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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



        public void savecombindays(string compcode, string combincode, string edicombincode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string focusday, string allday, int cnt)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            //DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            //OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("SAVE_COMBIN_DAYS.SAVE_COMBIN_DAYS_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("COMBINCODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = combincode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("EDICOMBINCODE", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edicombincode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("SUN1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = sun;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("MON1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = mon;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("TUE1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = tue;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("WED1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = wed;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("THU1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = thu;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("FRI1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = fri;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("SAT1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = sat;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("FOCUSDAY1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = focusday;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("ALLDAY1", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = allday;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("CNT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = cnt;
                objOraclecommand.Parameters.Add(prm13);

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


//==========Changes for Adons in combination master //
     public DataSet bindadon(string compcode, string combincode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindadongrid4combin", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMPCODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PCOMBINCODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = combincode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

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


     public DataSet INSUPDDELADON(string compcode, string combincode, string PADON_CODE, string PPACKAGE_CODE, string PPUBLICATION, string PNO_OF_INSERT, string PUSERID, string PTRN_TYPE, string PPACKAGE_NAME)
     {
         OracleConnection objOracleConnection;
         OracleCommand objOraclecommand;
         DataSet objDataSet = new DataSet();
         objOracleConnection = GetConnection();
         OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
         try
         {
             objOracleConnection.Open();
             objOraclecommand = GetCommand("COMBINADON_INS_UPD_DEL", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

             OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);

             OracleParameter prm2 = new OracleParameter("PCOMBIN_CODE", OracleType.VarChar);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = combincode;
             objOraclecommand.Parameters.Add(prm2);


             OracleParameter prm3 = new OracleParameter("PADON_CODE", OracleType.VarChar);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = PADON_CODE;
             objOraclecommand.Parameters.Add(prm3);

             OracleParameter prm4 = new OracleParameter("PPACKAGE_CODE", OracleType.VarChar);
             prm4.Direction = ParameterDirection.Input;
             prm4.Value = PPACKAGE_CODE;
             objOraclecommand.Parameters.Add(prm4);

             OracleParameter prm5 = new OracleParameter("PPUBLICATION", OracleType.VarChar);
             prm5.Direction = ParameterDirection.Input;
             prm5.Value = PPUBLICATION;
             objOraclecommand.Parameters.Add(prm5);

             OracleParameter prm6 = new OracleParameter("PNO_OF_INSERT", OracleType.VarChar);
             prm6.Direction = ParameterDirection.Input;
             prm6.Value = PNO_OF_INSERT;
             objOraclecommand.Parameters.Add(prm6);

             OracleParameter prm7 = new OracleParameter("PUSERID", OracleType.VarChar);
             prm7.Direction = ParameterDirection.Input;
             prm7.Value = PUSERID;
             objOraclecommand.Parameters.Add(prm7);

             OracleParameter prm8 = new OracleParameter("PTRN_TYPE", OracleType.VarChar);
             prm8.Direction = ParameterDirection.Input;
             prm8.Value = PTRN_TYPE;
             objOraclecommand.Parameters.Add(prm8);

             OracleParameter prm9 = new OracleParameter("PEXTRA1", OracleType.VarChar);
             prm9.Direction = ParameterDirection.Input;
             prm9.Value = PPACKAGE_NAME;
             objOraclecommand.Parameters.Add(prm9);

             OracleParameter prm10 = new OracleParameter("PEXTRA2", OracleType.VarChar);
             prm10.Direction = ParameterDirection.Input;
             prm10.Value = System.DBNull.Value;
             objOraclecommand.Parameters.Add(prm10);

             OracleParameter prm11 = new OracleParameter("PEXTRA3", OracleType.VarChar);
             prm11.Direction = ParameterDirection.Input;
             prm11.Value = System.DBNull.Value;
             objOraclecommand.Parameters.Add(prm11);

             OracleParameter prm12 = new OracleParameter("PEXTRA4", OracleType.VarChar);
             prm12.Direction = ParameterDirection.Input;
             prm12.Value = System.DBNull.Value;
             objOraclecommand.Parameters.Add(prm12);

             OracleParameter prm13 = new OracleParameter("PEXTRA5", OracleType.VarChar);
             prm13.Direction = ParameterDirection.Input;
             prm13.Value = System.DBNull.Value;
             objOraclecommand.Parameters.Add(prm13);

             objmysqlDataAdapter.SelectCommand = objOraclecommand;
             objmysqlDataAdapter.Fill(objDataSet);

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
     public DataSet getdata1(string compcode, string code11)
     {
         OracleConnection objOracleConnection;
         OracleCommand objOraclecommand;
         DataSet objDataSet = new DataSet();
         objOracleConnection = GetConnection();
         OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
         try
         {
             objOracleConnection.Open();
             objOraclecommand = GetCommand("filladongrid4combin", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

             OracleParameter prm1 = new OracleParameter("PCOMPCODE", OracleType.VarChar);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);

             OracleParameter prm2 = new OracleParameter("PADONCODE", OracleType.VarChar);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = code11;
             objOraclecommand.Parameters.Add(prm2);

             objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
             objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

             objmysqlDataAdapter.SelectCommand = objOraclecommand;
             objmysqlDataAdapter.Fill(objDataSet);

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
     public DataSet soloeditionbind(string compcode, string pubcode, string adtype)
     {
         OracleConnection objOracleConnection;
         OracleCommand objOraclecommand;
         DataSet objDataSet = new DataSet();
         objOracleConnection = GetConnection();
         OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
         try
         {
             objOracleConnection.Open();
             objOraclecommand = GetCommand("bindsolopackage4combin", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

             OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = compcode;
             objOraclecommand.Parameters.Add(prm1);

             OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
             prm2.Direction = ParameterDirection.Input;
             prm2.Value = pubcode;
             objOraclecommand.Parameters.Add(prm2);

             OracleParameter prm3 = new OracleParameter("padtype", OracleType.VarChar, 50);
             prm3.Direction = ParameterDirection.Input;
             prm3.Value = adtype;
             objOraclecommand.Parameters.Add(prm3);

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
             CloseConnection(ref objOracleConnection);
         }

     }

     public DataSet chk(string edition1)
     {
         OracleConnection objOracleConnection;
         OracleCommand objOraclecommand;
         DataSet objDataSet = new DataSet();
         objOracleConnection = GetConnection();
         OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
         try
         {
             objOracleConnection.Open();
             objOraclecommand = GetCommand("websp_combinemastcheck.websp_combinemastcheck_p", ref objOracleConnection);
             objOraclecommand.CommandType = CommandType.StoredProcedure;

             OracleParameter prm7 = new OracleParameter("combindesc", OracleType.VarChar, 50);
             prm7.Direction = ParameterDirection.Input;
             prm7.Value = edition1;
             objOraclecommand.Parameters.Add(prm7);

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

	}

}

    



