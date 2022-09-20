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
    /// Summary description for EditorMaster
    /// </summary>
    public class EditorMaster:orclconnection
    {
        public EditorMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet chkyear(string year, string compcode, string txteditionname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkyearcode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("year1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = year;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txteditionname;
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
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet uomname(string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_uomname.Bind_uomname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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


        public DataSet periodic(string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_Periodicty.Bind_Periodicty_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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

        /*=====================================================================================*/

        public DataSet editiontypecheck(string pub, string type, string city, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editiontypecheck.editiontypecheck_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pub", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pub;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("city", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = city;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("type1", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = type;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

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

        //*****************
        //circulations
        public DataSet chkcirculations(string pub, string city, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcirculations.chkcirculations_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pub", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pub;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("city", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = city;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

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
        //**********************//
        //*************This function is used to check whether particular edition code exists already or not*************//

        public DataSet editioncodecheck(string EditonCode, string compcode, string userid, string editionalias)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Editioncodecheck.Editioncodecheck_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("EditionCode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = EditonCode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2= new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editionalias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = editionalias;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

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

        // ***********This function is used to insert values in Database*************///

        public DataSet InsertValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string hr, string min, string prod, string type, string noofcol, string printcent, string segmentcode, string grpsave, string SHORTNAME, string epaper, string spename)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_editorinsert.websp_editorinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction=ParameterDirection.Input;
                prm1.Value=compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PubName", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PubName;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("CityName", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = CityName;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("EditionName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = EditionName;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Alias;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("EditonCode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = EditonCode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8= new OracleParameter("country", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = country;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("circulation", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = circulation;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("uom", OracleType.VarChar, 500);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = uom;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("height1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = height;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("width1", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = width;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("area1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = area;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14= new OracleParameter("periodicity", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = periodicity;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("gutter", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = gutter;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("col_space", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = col_space;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17= new OracleParameter("hr", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = hr;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("min1", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = min;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19= new OracleParameter("prod", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = prod;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("type1", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = type;
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("column1", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = column;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("noofcol", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                if (noofcol == "NaN")
                    noofcol = "1";
                prm22.Value = noofcol;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("printcent", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = printcent;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("psegmentcod", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = segmentcode;
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm26 = new OracleParameter("short_name", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = SHORTNAME;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm25 = new OracleParameter("pgrpcod", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                if (grpsave==""||grpsave==null)
                    prm25.Value = System.DBNull.Value;
                else
                    prm25.Value = grpsave;
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm29 = new OracleParameter("pepaperurl", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = epaper;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm291 = new OracleParameter("spe_name", OracleType.VarChar, 50);
                prm291.Direction = ParameterDirection.Input;
                prm291.Value = spename;
                objOraclecommand.Parameters.Add(prm291);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }


               

             //OracleParameter prm23 = new OracleParameter("printcent", OracleType.VarChar, 50);
             //   prm23.Direction = ParameterDirection.Input;
             //   prm23.Value = printcent;
             //   objOraclecommand.Parameters.Add(prm23);


            




            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        //************* This function is used to modify existing values except edition code******************//

        public DataSet ModifyValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string hr, string min, string prod, string type, string noofcol, string printcent, string segmentcode,string grpsave,string SHORTNAME,string epaper,string spacility)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_editormodify.websp_editormodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("PubName", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PubName;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("CityName", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = CityName;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("EditionName", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = EditionName;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Alias;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("EditonCode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = EditonCode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("country", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = country;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("circulation", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = circulation;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("uom", OracleType.VarChar, 500);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = uom;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("column1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = column;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("height1", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = height;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13= new OracleParameter("width1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = width;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("area1", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = area;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("periodicity", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = periodicity;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("gutter", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = gutter;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("col_space", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = col_space;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("hr", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = hr;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("min1", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = min;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("prod", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = prod;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("type1", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = type;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("noofcol", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                if (noofcol == "NaN")
                    noofcol = "1";
                prm22.Value = noofcol;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("printcent", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = printcent;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("psegmentcod", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = segmentcode;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm26 = new OracleParameter("short_name", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = SHORTNAME;
                objOraclecommand.Parameters.Add(prm26);




                OracleParameter prm25 = new OracleParameter("pgrpcod", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                if (grpsave == "" || grpsave == null)
                    prm25.Value = System.DBNull.Value;
                else
                    prm25.Value = grpsave;
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm29 = new OracleParameter("pepaper", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = epaper;
                objOraclecommand.Parameters.Add(prm29);



                OracleParameter prm291 = new OracleParameter("spe_name", OracleType.VarChar, 50);
                prm291.Direction = ParameterDirection.Input;
                prm291.Value = spacility;
                objOraclecommand.Parameters.Add(prm291);

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

        //*************** This function is used to delete record from database*************//

        public DataSet deleteedition(string EditonCode, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_editordelete.websp_editordelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("EditonCode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = EditonCode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3= new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
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
                CloseConnection(ref objOracleConnection);
            }
        }

        //*********** This function is used to select particular record***************//

        public DataSet SelectValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string type, string segmentcode, string grpsave,string SHORTNAME, string  epaper)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_editorSelect.websp_editorSelect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2= new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (PubName == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = PubName;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("cityname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (CityName == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = CityName;
                }
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("editionname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = EditionName;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Alias;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("editoncode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = EditonCode;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("country", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (country == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {

                    prm8.Value = country;
                }
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9= new OracleParameter("circulation", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = circulation;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (uom == "0")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = uom;
                }
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("column1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = column;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("height", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = height;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("width", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = width;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14= new OracleParameter("area", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = area;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("periodicity", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                if (periodicity == "0")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = periodicity;
                }
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("gutter", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = gutter;
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("col_space", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = col_space;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("type1", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                if (type == "0")
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = type;
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("psegmentcod", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = segmentcode;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm27 = new OracleParameter("short_name", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = SHORTNAME;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm25 = new OracleParameter("pgrpcod", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                if (grpsave == "" || grpsave == null)
                    prm25.Value = System.DBNull.Value;
                else
                    prm25.Value = grpsave;
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm28 = new OracleParameter("epaper", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = epaper;
                objOraclecommand.Parameters.Add(prm28);


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
        // ***********This function is used to select first,next,previous,last record *************//

        public DataSet Selectfnpl(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string SHORTNAME)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("EditiorFNPL.EditiorFNPL_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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

        // *************This function is used to bind publication name*****************//

        public DataSet Pub(string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubName.Bind_PubEdName_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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
        //**************Function to bind gutter & column space************************//

        public DataSet space(string pubcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_G_C_space.bind_G_C_space_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pubcode;
                objOraclecommand.Parameters.Add(prm1);

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

        // *************This function is used to bind periodicity from periodicity master*****************//

        /*public DataSet periodic(string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_Periodicty.Bind_Periodicty_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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
        }*/

    /*    public DataSet uomname(string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_uomname.Bind_uomname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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
        }*/


        public DataSet SubPub(string edit)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_SubPubName.Bind_SubPubName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("edit", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = edit;
                objOraclecommand.Parameters.Add(prm1);

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

        public DataSet cityName()
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_CityEditor.Bind_CityEditor_p", ref objOracleConnection);
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
                CloseConnection(ref objOracleConnection);
            }
        }


        //****************This function is used to select edition code*******************//

        public DataSet checksupcode(string compcode, string editoncode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkeditioncode.checkeditioncode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("editoncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editoncode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
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
                CloseConnection(ref objOracleConnection);
            }
        }

        //*****************This function is used to modify edition days**********************//

        public DataSet selecteditiondaymodify(string compcode, string editioncode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editiondaymodify.editiondaymodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editioncode;
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

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        //********* This function is used to save edition days******************//

        public DataSet editiondaysave(string compcode, string editoncode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid,string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editiondaysave.editiondaysave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("editoncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editoncode;
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

                OracleParameter prm12 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = adtype;
                objOraclecommand.Parameters.Add(prm12);
             

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

        //***********This function is used to check edition code according to particular publication name************//

        public DataSet autoeditcode(string str, string strpub, string strcity)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autoeditcode.autoeditcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("strpub", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = strpub;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("strcity", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = strcity;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm4.Value = str.Substring(0, 2);
                    objOraclecommand.Parameters.Add(prm4);
                }
                else
                {

                    prm4.Value = str;
                    objOraclecommand.Parameters.Add(prm4);
                }

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

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


        //Pankaj//



        public DataSet editor(string citycode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editorcity.editorcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("citycode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = citycode;
                objOraclecommand.Parameters.Add(prm1);


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


        //***********This function is used to find city name and publication name ************//

        public DataSet findcity(string city, string pubname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("findcitypub.findcitypub_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("city", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = city;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubname;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

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



        //***********This function is used to check edition code according to particular publication name************//

        public DataSet autoeditcode1(string str, string strpub)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autoeditcode1.autoeditcode1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("strpub", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = strpub;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm4.Value = str.Substring(0, 2);
                    objOraclecommand.Parameters.Add(prm4);
                }
                else
                {

                    prm4.Value = str;
                    objOraclecommand.Parameters.Add(prm4);
                }


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

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

        //Pankaj//



        /*   public DataSet editor(string citycode)
           {
               SqlConnection objOracleConnection;
               SqlCommand objOraclecommand;
               objOracleConnection = GetConnection();
               SqlDataAdapter objorclDataAdapter = new SqlDataAdapter();
               DataSet objDataSet = new DataSet();
               try
               {
                   objOracleConnection.Open();
                   objOraclecommand = GetCommand("editorcity", ref objOracleConnection);
                   objOraclecommand.CommandType = CommandType.StoredProcedure;

                   objOraclecommand.Parameters.Add("citycode", SqlDbType.VarChar);
                   objOraclecommand.Parameters["citycode"].Value = citycode;

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

           }*/


        //***********This function is used to find city name and publication name ************//

        /* public DataSet findcity(string city, string pubname)
         {
             SqlConnection objOracleConnection;
             SqlCommand objOraclecommand;
             objOracleConnection = GetConnection();
             SqlDataAdapter objorclDataAdapter = new SqlDataAdapter();
             DataSet objDataSet = new DataSet();
             try
             {
                 objOracleConnection.Open();
                 objOraclecommand = GetCommand("findcitypub", ref objOracleConnection);
                 objOraclecommand.CommandType = CommandType.StoredProcedure;

                 objOraclecommand.Parameters.Add("city", SqlDbType.VarChar);
                 objOraclecommand.Parameters["city"].Value = city;

                 objOraclecommand.Parameters.Add("pubname", SqlDbType.VarChar);
                 objOraclecommand.Parameters["pubname"].Value = pubname;


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
         }*/




        public DataSet enablechkbox(string pubname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("enablechkboxpub.enablechkboxpub_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pubname;
                objOraclecommand.Parameters.Add(prm1);

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

        public DataSet countcity(string txtcountry)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillcity_publ.fillcity_publ_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("txtcountry", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = txtcountry;
                objOraclecommand.Parameters.Add(prm1);

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

        //*******************************procedures 

        public DataSet inserteditname(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string year)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("inserteditdate.inserteditdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("txteditionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txteditionname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4= new OracleParameter("txtdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtdate;
                objOraclecommand.Parameters.Add(prm4);
              
                OracleParameter prm5 = new OracleParameter("txtaddate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtaddate;
                objOraclecommand.Parameters.Add(prm5);
            

                OracleParameter prm6 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = editcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("year1", OracleType.VarChar, 50);
                        prm7.Direction = ParameterDirection.Input;
                        prm7.Value = year;
                        objOraclecommand.Parameters.Add(prm7);



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

        public DataSet selectedfromgrid(string editcode, string compcode, string userid, string code10)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selectfromeditdate.selectfromeditdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4= new OracleParameter("code10", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code10;
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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet gridupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string code10, string year)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateeditdate.updateeditdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txteditionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txteditionname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("txtdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtdate;
                objOraclecommand.Parameters.Add(prm4);
              


                OracleParameter prm5 = new OracleParameter("txtaddate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtaddate;
                objOraclecommand.Parameters.Add(prm5);
      


                OracleParameter prm6 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = editcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = code10;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("year1", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = year;
                objOraclecommand.Parameters.Add(prm8);


                


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

        public DataSet griddelete(string editcode, string compcode, string userid, string code10)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletegrideditdate.deletegrideditdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code10;
                objOraclecommand.Parameters.Add(prm4);

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
        public DataSet chkdaetedit(string compcode, string editcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdateedit.chkdateedit_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editcode;
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
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet chkdateupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string code10)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdateeditupdate.chkdateeditupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txteditionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txteditionname;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("txtdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtdate;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("txtaddate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtaddate;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = editcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = code10;
                objOraclecommand.Parameters.Add(prm7);

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

        public DataSet ratebind(string code, string compcode, string userid, string date)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindeditdate.bindeditdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = date;
                objOraclecommand.Parameters.Add(prm4);

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


        public DataSet filleditalias(string editcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("filleditalias.filleditalias_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editcode;
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
                CloseConnection(ref objOracleConnection);
            }
        }
        //***********************************************Check periodicity******************************
        public DataSet chkperiodicty(string periodicty, string pub, string edit_period, string mod, string editcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                if (pub != "foredition")
                {

                    objOraclecommand = GetCommand("chkperiodicty.chkperiodicty_p", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("periodicty", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = periodicty;
                    objOraclecommand.Parameters.Add(prm1);


                    OracleParameter prm2 = new OracleParameter("pub1", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = pub;
                    objOraclecommand.Parameters.Add(prm2);


                    OracleParameter prm3 = new OracleParameter("edit_period", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = edit_period;
                    objOraclecommand.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("mod1", OracleType.VarChar, 50);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = mod;
                    objOraclecommand.Parameters.Add(prm4);


                    OracleParameter prm5 = new OracleParameter("editcode", OracleType.VarChar, 50);
                    prm5.Direction = ParameterDirection.Input;
                    prm5.Value = editcode;
                    objOraclecommand.Parameters.Add(prm5);

                    objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                    objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                    objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                    objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

                }

                else
                {
                    objOraclecommand = GetCommand("chkperiodicty1.chkperiodicty1_p", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("periodicty", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = periodicty;
                    objOraclecommand.Parameters.Add(prm1);


                    OracleParameter prm2 = new OracleParameter("pub1", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = pub;
                    objOraclecommand.Parameters.Add(prm2);


                    OracleParameter prm3 = new OracleParameter("edit_period", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = edit_period;
                    objOraclecommand.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("mod1", OracleType.VarChar, 50);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = mod;
                    objOraclecommand.Parameters.Add(prm4);


                    OracleParameter prm5 = new OracleParameter("editcode", OracleType.VarChar, 50);
                    prm5.Direction = ParameterDirection.Input;
                    prm5.Value = editcode;
                    objOraclecommand.Parameters.Add(prm5);

                    objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                    objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                }

                    
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

        //***********************************************Check periodicity******************************
        public DataSet chkperiodicty_edition(string edition)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkperiodictyedition.chkperiodictyedition_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = edition;
                objOraclecommand.Parameters.Add(prm1);

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
    //==========================================================================================
        public DataSet chkperiodicitynumber(string pub, string edit, string period, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkperiodicityforedition.chkperiodicityforedition_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pub1", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pub;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("edit", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("period", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = period;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

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



        public DataSet editioncodedub(string compcode, string ecode, string extra1)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ADD_CHKEDITCODE", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pedit_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pextra", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
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

//=======================================================================================================

        public DataSet segmentbind(string compcode, string dateformate, string extra1,string extra2)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("FA_VOUCHERS_VIEW.FA_SEGMENT_TYPE_MAST_p",ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm31 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = extra2;
                objOraclecommand.Parameters.Add(prm31);

                objOraclecommand.Parameters.Add("p_fin", OracleType.Cursor);
                objOraclecommand.Parameters["p_fin"].Direction = ParameterDirection.Output;




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

        public DataSet getcostcentname(string compcode, string centcode)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand(); ;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                string query = "";

                query = "select FA_GET_SEGMENT_NAME('" + compcode + "','" + centcode + "') as COST_CENTER_NAME from dual";


                cmd.CommandText = query;
                cmd.Connection = con;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


        public DataSet editiontxtsave(string compcode, string editoncode, string txtsun, string txtmon, string txttue, string txtwed, string txtthu, string txtfri, string txtsat, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editiontxtsave.editiontxtsave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("peditoncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editoncode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ptxtsun", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtsun;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ptxtmon", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtmon;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ptxttue", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = txttue;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ptxtwed", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = txtwed;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("ptxtthu", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = txtthu;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("ptxtfri", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = txtfri;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ptxtsat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = txtsat;
                objOraclecommand.Parameters.Add(prm11);

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


        public DataSet selecteditiontxtmodify(string compcode, string editioncode, string txtsun, string txtmon, string txttue, string txtwed, string txtthu, string txtfri, string txtsat, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editiontxtsave.editiontxtmodify", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("peditoncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editioncode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ptxtsun", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtsun;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ptxtmon", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtmon;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ptxttue", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = txttue;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ptxtwed", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = txtwed;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("ptxtthu", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = txtthu;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("ptxtfri", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = txtfri;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ptxtsat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = txtsat;
                objOraclecommand.Parameters.Add(prm11);

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


        public DataSet checkedtiontxt(string compcode, string editoncode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editiontxtsave.checkedtiontxt", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("peditoncode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editoncode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);


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


        public DataSet filldatatype(string hiddencomcode, string hiddenuserid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindadtypeforedition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = hiddenuserid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = hiddencomcode;
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


        public DataSet spname(string hiddencomcode)//, string hiddenuserid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BIND_SPNAME", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = hiddencomcode;
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

        public DataSet saveinfomain(string seq, string compcode, string crcno, string rdrno, string state, string district, string city, string editioncode)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("SAVE_CICU_MAIN", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pseq", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = seq;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcomcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOrclCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcrcno", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = crcno;
                objOrclCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("prdrno", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rdrno;
                objOrclCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pstate", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = state;
                objOrclCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdist", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = district;
                objOrclCommand.Parameters.Add(prm6);


                OracleParameter prm61 = new OracleParameter("pcity", OracleType.VarChar, 2000);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = city;
                objOrclCommand.Parameters.Add(prm61);


                OracleParameter prm62 = new OracleParameter("peditioncode", OracleType.VarChar, 2000);
                prm62.Direction = ParameterDirection.Input;
                prm62.Value = editioncode;
                objOrclCommand.Parameters.Add(prm62);

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
        public DataSet saveinfo(string seq, string comcode, string crcno, string rdrno, string state, string distct, string city, string editioncode)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("SAVE_CICU_TEMP", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("seq", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = seq;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("comcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comcode;
                objOrclCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("crcno", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = crcno;
                objOrclCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("rdrno", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rdrno;
                objOrclCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("state", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = state;
                objOrclCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dist", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = distct;
                objOrclCommand.Parameters.Add(prm6);


                OracleParameter prm61 = new OracleParameter("city", OracleType.VarChar, 2000);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = city;
                objOrclCommand.Parameters.Add(prm61);


                OracleParameter prm62 = new OracleParameter("editioncode", OracleType.VarChar, 2000);
                prm62.Direction = ParameterDirection.Input;
                prm62.Value = editioncode;
                objOrclCommand.Parameters.Add(prm62);

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
        public DataSet qryinfo(string comcode, string pedcode)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("QUERY_CIRC_MAIN", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pedcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pedcode;
                objOrclCommand.Parameters.Add(prm2);

                objOrclCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOrclCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
        public DataSet updateinfo(string seq, string comcode, string crcno, string rdrno, string state, string distct, string city)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("UPDATE_CIRCU_MAIN", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("seq", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = seq;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comcode;
                objOrclCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcrcno", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = crcno;
                objOrclCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("prdrno", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rdrno;
                objOrclCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pstate", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = state;
                objOrclCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdist", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = distct;
                objOrclCommand.Parameters.Add(prm6);


                OracleParameter prm61 = new OracleParameter("pcity", OracleType.VarChar, 2000);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = city;
                objOrclCommand.Parameters.Add(prm61);


               
                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
        public DataSet updateinfotemp(string seq, string comcode, string crcno, string rdrno, string state, string distct, string city)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("UPDATE_CIRCU_TEMP", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("seq", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = seq;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comcode;
                objOrclCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcrcno", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = crcno;
                objOrclCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("prdrno", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rdrno;
                objOrclCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pstate", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = state;
                objOrclCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdist", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = distct;
                objOrclCommand.Parameters.Add(prm6);


                OracleParameter prm61 = new OracleParameter("pcity", OracleType.VarChar, 2000);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = city;
                objOrclCommand.Parameters.Add(prm61);



                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
        public DataSet deleteinfo(string seq, string comcode)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("DELETE_CIRC_MAIN", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("seq", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = seq;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comcode;
                objOrclCommand.Parameters.Add(prm2);

       
                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
        public DataSet deleteinfotemp(string seq, string comcode)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("DELETE_CIRC_TEMP", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("seq", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = seq;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cmcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comcode;
                objOrclCommand.Parameters.Add(prm2);


                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
        public DataSet cityname(string cmcode, string citycd)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("FILL_CITY_DIST_STATE", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cmcode;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcentcode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = citycd;
                objOrclCommand.Parameters.Add(prm2);

                objOrclCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOrclCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
        public DataSet Dist_State(string cmcode, string citycd)
        {
            OracleConnection objOrclConnection;
            OracleCommand objOrclCommand;
            objOrclConnection = GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOrclConnection.Open();
                objOrclCommand = GetCommand("FILL_DIST", ref objOrclConnection);
                objOrclCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cmcode;
                objOrclCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("citycode", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = citycd;
                objOrclCommand.Parameters.Add(prm2);

                objOrclCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOrclCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOrclDataAdapter.SelectCommand = objOrclCommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOrclConnection);
            }
        }
    }
}