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
    /// Summary description for EditorMaster
    /// </summary>
    public class EditorMaster:connection
    {
        public EditorMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet editiontypecheck(string pub, string type, string city, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("editiontypecheck_editiontypecheck_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("type1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type1"].Value = type;

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

        //*****************
        //circulations
        public DataSet chkcirculations(string pub, string city, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkcirculations_chkcirculations_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("type", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["type"].Value = type;

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
        //**********************//
        //*************This function is used to check whether particular edition code exists already or not*************//

        public DataSet editioncodecheck(string EditonCode, string compcode, string userid, string EDITIONALIAS)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Editioncodecheck", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("EditionCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditionCode"].Value = EditonCode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("EDITIONALIAS", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EDITIONALIAS"].Value = EDITIONALIAS;

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

        // ***********This function is used to insert values in Database*************///

        public DataSet InsertValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string hr, string min, string prod, string type, string printcent)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_editorinsert_websp_editorinsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("PubName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PubName"].Value = PubName;

                objmysqlcommand.Parameters.Add("CityName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityName"].Value = CityName;

                objmysqlcommand.Parameters.Add("EditionName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditionName"].Value = EditionName;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlcommand.Parameters.Add("EditonCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditonCode"].Value = EditonCode;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("circulation", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circulation"].Value = circulation;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("column1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["column1"].Value = column;

                objmysqlcommand.Parameters.Add("height1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["height1"].Value = height;

                objmysqlcommand.Parameters.Add("width1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["width1"].Value = width;

                objmysqlcommand.Parameters.Add("area1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["area1"].Value = area;

                objmysqlcommand.Parameters.Add("periodicity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["periodicity"].Value = periodicity;

                objmysqlcommand.Parameters.Add("gutter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gutter"].Value = gutter;

                objmysqlcommand.Parameters.Add("col_space", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["col_space"].Value = col_space;

                objmysqlcommand.Parameters.Add("hr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hr"].Value = hr;

                objmysqlcommand.Parameters.Add("min1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["min1"].Value = min;

                objmysqlcommand.Parameters.Add("prod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prod"].Value = prod;

                objmysqlcommand.Parameters.Add("type1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type1"].Value = type;

                objmysqlcommand.Parameters.Add("printcent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["printcent"].Value = printcent;

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

        //************* This function is used to modify existing values except edition code******************//

        public DataSet ModifyValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string hr, string min, string prod, string type)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_editormodify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("PubName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PubName"].Value = PubName;

                objmysqlcommand.Parameters.Add("CityName ", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityName "].Value = CityName;

                objmysqlcommand.Parameters.Add("EditionName ", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditionName "].Value = EditionName;

                objmysqlcommand.Parameters.Add("Alias ", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias "].Value = Alias;

                objmysqlcommand.Parameters.Add("EditonCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditonCode"].Value = EditonCode;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("circulation", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circulation"].Value = circulation;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("columns", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["columns"].Value = column;

                objmysqlcommand.Parameters.Add("height", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["height"].Value = height;

                objmysqlcommand.Parameters.Add("width", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["width"].Value = width;

                objmysqlcommand.Parameters.Add("area", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["area"].Value = area;

                objmysqlcommand.Parameters.Add("periodicity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["periodicity"].Value = periodicity;

                objmysqlcommand.Parameters.Add("gutter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gutter"].Value = gutter;

                objmysqlcommand.Parameters.Add("col_space", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["col_space"].Value = col_space;

                objmysqlcommand.Parameters.Add("hr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hr"].Value = hr;

                objmysqlcommand.Parameters.Add("min", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["min"].Value = min;

                objmysqlcommand.Parameters.Add("prod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prod"].Value = prod;

                objmysqlcommand.Parameters.Add("type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type"].Value = type;

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

        //*************** This function is used to delete record from database*************//

        public DataSet deleteedition(string EditonCode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_editordelete_websp_editordelete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("EditonCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditonCode"].Value = EditonCode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

             
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

        //*********** This function is used to select particular record***************//

        public DataSet SelectValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string type, string segmentcode, string grpsave,string SHORTNAME, string  epaper)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_editorSelect_websp_editorSelect_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                //if (centcode == "" || centcode == null || centcode == "undefined")
                //{
                //    objmysqlcommand.Parameters["centcode"].Value = "%%";
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["centcode"].Value = centcode;
                //}

                objmysqlcommand.Parameters.Add("PubName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PubName"].Value = PubName;

                //// if (PubName == "0" || PubName == null || PubName == "undefined")
                //{

                //    //    objmysqlcommand.Parameters["PubName"].Value = "%%";
                //}
                //// else
                //{
                  
                //}

                objmysqlcommand.Parameters.Add("CityName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityName"].Value = CityName;

                // if (CityName == "0" || CityName == null || CityName == "undefined")
                //{
                //    //     objmysqlcommand.Parameters["CityName"].Value = "%%";
                //}
                ////else
                //{
                  
                //}

                objmysqlcommand.Parameters.Add("EditionName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditionName"].Value = EditionName;

                ////if (EditionName == "" || EditionName == null || EditionName == "undefined")
                //{
                //    //     objmysqlcommand.Parameters["EditionName"].Value = "%%";
                //}
                //// else
                //{

                   
                //}


                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                // if (Alias == "" || Alias == null || Alias == "undefined")
                //{
                //    //      objmysqlcommand.Parameters["Alias"].Value = "%%";
                //}
                //// else
                //{

                 
                //}


                objmysqlcommand.Parameters.Add("EditonCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditonCode"].Value = EditonCode;

                //// if (EditonCode == "" || EditonCode == null || EditonCode == "undefined")
                //{
                //    //     objmysqlcommand.Parameters["EditonCode"].Value = "%%";
                //}
                ////  else
                //{

                 
                //}


                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                //// if (country == "0" || country == null || country == "undefined")
                //{
                //    //      objmysqlcommand.Parameters["country"].Value = "%%";
                //}
                ////else
                //{

                //}


                objmysqlcommand.Parameters.Add("circulation", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circulation"].Value = circulation;

                // if (circulation == "" || circulation == null || circulation == "undefined")
                //{
                //    //     objmysqlcommand.Parameters["circulation"].Value = "%%";
                //}
                ////else
                //{

                //}

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                ////if (uom == "0" || uom == null || uom == "undefined")
                //{
                //    //    objmysqlcommand.Parameters["uom"].Value = "%%";
                //}
                ////  else
                //{

                  
                //}

                objmysqlcommand.Parameters.Add("column1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["column1"].Value = column;

                //// if (column == "" || column == null || column == "undefined")
                //{
                //    //     objmysqlcommand.Parameters["column"].Value = "%%";
                //}
                //// else
                //{

                //}

                objmysqlcommand.Parameters.Add("height", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["height"].Value = height;

                //  if (height == "" || height == null || height == "undefined")
                //{
                //    //    objmysqlcommand.Parameters["height"].Value = "%%";
                //}
                //// else
                //{

                  
                //}

                objmysqlcommand.Parameters.Add("width", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["width"].Value = width;

                ////if (width == "" || width == null || width == "undefined")
                //{
                //    //   objmysqlcommand.Parameters["width"].Value = "%%";
                //}
                //// else
                //{

                  
                //}

                objmysqlcommand.Parameters.Add("area", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["area"].Value = area;

                //  if (area == "" || area == null || area == "undefined")
                //{
                //    //     objmysqlcommand.Parameters["area"].Value = "%%";
                //}
                ////else
                //{

                //}

                objmysqlcommand.Parameters.Add("periodicity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["periodicity"].Value = periodicity;

                objmysqlcommand.Parameters.Add("gutter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gutter"].Value = gutter;

                objmysqlcommand.Parameters.Add("col_space", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["col_space"].Value = col_space;

                objmysqlcommand.Parameters.Add("type1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type1"].Value = type;

                objmysqlcommand.Parameters.Add("psegmentcod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["psegmentcod"].Value = segmentcode;

                objmysqlcommand.Parameters.Add("short_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["short_name"].Value = SHORTNAME;

                objmysqlcommand.Parameters.Add("pgrpcod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pgrpcod"].Value = grpsave;

                objmysqlcommand.Parameters.Add("epaper", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["epaper"].Value = epaper;

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
        // ***********This function is used to select first,next,previous,last record *************//

        public DataSet Selectfnpl(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EditiorFNPL_EditiorFNPL_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

         
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
        public DataSet spname(string hiddencomcode)//, string hiddenuserid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BIND_SPNAME", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = hiddencomcode;



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

        // *************This function is used to bind publication name*****************//

        public DataSet Pub(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_PubName_Bind_PubEdName_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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
        //**************Function to bind gutter & column space************************//

        public DataSet space(string pubcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bind_G_C_space_bind_G_C_space_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                //objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["pubname"].Value = pubname;

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

        // *************This function is used to bind periodicity from periodicity master*****************//

        public DataSet periodic(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_Periodicty_Bind_Periodicty_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet uomname(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_uomname_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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


        public DataSet SubPub(string edit)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_SubPubName", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit"].Value = edit;

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

        public DataSet cityName()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_CityEditor", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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


        //****************This function is used to select edition code*******************//

        public DataSet checksupcode(string compcode, string editoncode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkeditioncode_checkeditioncode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("editoncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editoncode"].Value = editoncode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        //*****************This function is used to modify edition days**********************//

        public DataSet selecteditiondaymodify(string compcode, string editioncode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("editiondaymodify_editiondaymodify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = editioncode;

                objmysqlcommand.Parameters.Add("sun1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sun1"].Value = sun;

                objmysqlcommand.Parameters.Add("mon1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mon1"].Value = mon;

                objmysqlcommand.Parameters.Add("tue1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tue1"].Value = tue;

                objmysqlcommand.Parameters.Add("wed1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["wed1"].Value = wed;

                objmysqlcommand.Parameters.Add("thu1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["thu1"].Value = thu;

                objmysqlcommand.Parameters.Add("fri1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fri1"].Value = fri;

                objmysqlcommand.Parameters.Add("sat1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sat1"].Value = sat;

                objmysqlcommand.Parameters.Add("allday", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["allday"].Value = all;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        //********* This function is used to save edition days******************//

        public DataSet editiondaysave(string compcode, string editoncode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid,string pd)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("editiondaysave_editiondaysave_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("editoncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editoncode"].Value = editoncode;

                objmysqlcommand.Parameters.Add("sun", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sun"].Value = sun;

                objmysqlcommand.Parameters.Add("mon", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mon"].Value = mon;

                objmysqlcommand.Parameters.Add("tue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tue"].Value = tue;

                objmysqlcommand.Parameters.Add("wed", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["wed"].Value = wed;

                objmysqlcommand.Parameters.Add("thu", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["thu"].Value = thu;

                objmysqlcommand.Parameters.Add("fri", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fri"].Value = fri;

                objmysqlcommand.Parameters.Add("sat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sat"].Value = sat;

                objmysqlcommand.Parameters.Add("all1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["all1"].Value = all;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("padtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["padtype"].Value = pd;

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

        //***********This function is used to check edition code according to particular publication name************//

        public DataSet autoeditcode(string str, string strpub, string strcity)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("autoeditcode_autoeditcode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("strpub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["strpub"].Value = strpub;

                objmysqlcommand.Parameters.Add("strcity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["strcity"].Value = strcity;


                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length> 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0,2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }


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


        //Pankaj//



        public DataSet editor(string citycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("editorcity", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["citycode"].Value = citycode;

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


        //***********This function is used to find city name and publication name ************//

        public DataSet findcity(string city, string pubname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("findcitypub_findcitypub_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = pubname;


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



        //***********This function is used to check edition code according to particular publication name************//

        public DataSet autoeditcode1(string str, string strpub)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("autoeditcode1_autoeditcode1_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("strpub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["strpub"].Value = strpub;


                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cod"].Value = str;


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

        //Pankaj//



        /*   public DataSet editor(string citycode)
           {
               SqlConnection objmysqlconnection;
               SqlCommand objmysqlcommand;
               objmysqlconnection = GetConnection();
               SqlDataAdapter objmysqlDataAdapter = new SqlDataAdapter();
               DataSet objDataSet = new DataSet();
               try
               {
                   objmysqlconnection.Open();
                   objmysqlcommand = GetCommand("editorcity", ref objmysqlconnection);
                   objmysqlcommand.CommandType = CommandType.StoredProcedure;

                   objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
                   objmysqlcommand.Parameters["citycode"].Value = citycode;

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

           }*/


        //***********This function is used to find city name and publication name ************//

        /* public DataSet findcity(string city, string pubname)
         {
             SqlConnection objmysqlconnection;
             SqlCommand objmysqlcommand;
             objmysqlconnection = GetConnection();
             SqlDataAdapter objmysqlDataAdapter = new SqlDataAdapter();
             DataSet objDataSet = new DataSet();
             try
             {
                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("findcitypub", ref objmysqlconnection);
                 objmysqlcommand.CommandType = CommandType.StoredProcedure;

                 objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["city"].Value = city;

                 objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["pubname"].Value = pubname;


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
         }*/




        public DataSet enablechkbox(string pubname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("enablechkboxpub_enablechkboxpub_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = pubname;


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

        public DataSet countcity(string txtcountry)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillcity_publ_fillcity_publ_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("txtcountry", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcountry"].Value = txtcountry;

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

//*******************************procedures 

        public DataSet inserteditname(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("inserteditdate_inserteditdate_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txteditionname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txteditionname"].Value = txteditionname;

                objmysqlcommand.Parameters.Add("txtdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtdate"].Value = Convert.ToDateTime(txtdate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("txtaddate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtaddate"].Value =Convert.ToDateTime(txtaddate).ToString("yyyy-MM-dd");


                //objmysqlcommand.Parameters.Add("txtaddate", MySqlDbType.DateTime);
                //if (txtaddate == "" || txtaddate == null || txtaddate == "undefined/undefined/")
                //{
                //    objmysqlcommand.Parameters["txtaddate"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["txtaddate"].Value = Convert.ToDateTime(txtaddate);
                //}

                objmysqlcommand.Parameters.Add("editcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editcode"].Value = editcode;

             
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

        public DataSet selectedfromgrid(string editcode, string compcode, string userid, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("selectfromeditdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("editcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editcode"].Value = editcode;



                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;




                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



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

        public DataSet gridupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updateeditdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txteditionname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txteditionname"].Value = txteditionname;

                objmysqlcommand.Parameters.Add("txtdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtdate"].Value = Convert.ToDateTime(txtdate);



                objmysqlcommand.Parameters.Add("txtaddate", MySqlDbType.DateTime);


                if (txtaddate == "" || txtaddate == null || txtaddate == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["txtaddate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["txtaddate"].Value = Convert.ToDateTime(txtaddate);
                }


                objmysqlcommand.Parameters.Add("editcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editcode"].Value = editcode;

                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;




                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



     
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

        public DataSet griddelete(string editcode, string compcode, string userid, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletegrideditdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("editcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editcode"].Value = editcode;

                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;

             
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
        public DataSet chkdaetedit(string compcode, string editcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdateedit", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;



                objmysqlcommand.Parameters.Add("editcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editcode"].Value = editcode;


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

        public DataSet chkdateupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdateeditupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txteditionname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txteditionname"].Value = txteditionname;

                objmysqlcommand.Parameters.Add("txtdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtdate"].Value = Convert.ToDateTime(txtdate);

                objmysqlcommand.Parameters.Add("txtaddate", MySqlDbType.DateTime);


                if (txtaddate == "" || txtaddate == null || txtaddate == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["txtaddate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["txtaddate"].Value = Convert.ToDateTime(txtaddate);
                }
                objmysqlcommand.Parameters.Add("editcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editcode"].Value = editcode;

                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;


          
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

        public DataSet ratebind(string code, string compcode, string userid, string date)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindeditdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("date", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date"].Value = date;





                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



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


        public DataSet filleditalias(string editcode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("filleditalias", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("editcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editcode"].Value = editcode;




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
        //***********************************************Check periodicity******************************
        public DataSet chkperiodicty(string periodicty)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkperiodicty_chkperiodicty_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("periodicty", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["periodicty"].Value = periodicty;


                objmysqlcommand.Parameters.Add("pub1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub1"].Value = "";

                objmysqlcommand.Parameters.Add("edit_period", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit_period"].Value = "";

                objmysqlcommand.Parameters.Add("mod1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mod1"].Value = "";

                objmysqlcommand.Parameters.Add("editcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editcode"].Value = "";



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

        //***********************************************Check periodicity******************************
        public DataSet chkperiodicty_edition(string edition)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkperiodictyedition_chkperiodictyedition_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;





           
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

        public DataSet ModifyValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string hr, string min, string prod, string type, string noofcol, string printcent)
        {

           
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_editormodify_websp_editormodify_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("PubName", MySqlDbType.VarChar);
                objSqlCommand.Parameters["PubName"].Value = PubName;

                objSqlCommand.Parameters.Add("CityName", MySqlDbType.VarChar);
                objSqlCommand.Parameters["CityName"].Value = CityName;

                objSqlCommand.Parameters.Add("EditionName", MySqlDbType.VarChar);
                objSqlCommand.Parameters["EditionName"].Value = EditionName;

                objSqlCommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Alias"].Value = Alias;

                objSqlCommand.Parameters.Add("EditonCode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["EditonCode"].Value = EditonCode;

                objSqlCommand.Parameters.Add("country", MySqlDbType.VarChar);
                objSqlCommand.Parameters["country"].Value = country;

                objSqlCommand.Parameters.Add("circulation", MySqlDbType.VarChar);
                objSqlCommand.Parameters["circulation"].Value = circulation;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("column1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["column1"].Value = column;

                objSqlCommand.Parameters.Add("height", MySqlDbType.VarChar);
                objSqlCommand.Parameters["height"].Value = height;

                objSqlCommand.Parameters.Add("width", MySqlDbType.VarChar);
                objSqlCommand.Parameters["width"].Value = width;

                objSqlCommand.Parameters.Add("area1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["area1"].Value = area;

                objSqlCommand.Parameters.Add("periodicity", MySqlDbType.VarChar);
                objSqlCommand.Parameters["periodicity"].Value = periodicity;

                objSqlCommand.Parameters.Add("gutter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["gutter"].Value = gutter;

                objSqlCommand.Parameters.Add("col_space", MySqlDbType.VarChar);
                objSqlCommand.Parameters["col_space"].Value = col_space;

                objSqlCommand.Parameters.Add("hr", MySqlDbType.VarChar);
                objSqlCommand.Parameters["hr"].Value = hr;

                objSqlCommand.Parameters.Add("min1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["min1"].Value = min;

                objSqlCommand.Parameters.Add("prod", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prod"].Value = prod;

                objSqlCommand.Parameters.Add("type", MySqlDbType.VarChar);
                objSqlCommand.Parameters["type"].Value = type;

                objSqlCommand.Parameters.Add("noofcol", MySqlDbType.VarChar);
                if (noofcol == "NaN" && noofcol == "0")
                {
                    objSqlCommand.Parameters["noofcol"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["noofcol"].Value = noofcol;
                }

                objSqlCommand.Parameters.Add("printcent", MySqlDbType.VarChar);
                objSqlCommand.Parameters["printcent"].Value = printcent;

                objSqlDataAdapter = new MySqlDataAdapter ();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (MySqlException  objException)
            {
                throw (objException);
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
        public DataSet chkperiodicitynumber(string pub, string edit, string period, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkperiodicityforedition_chkperiodicityforedition_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pub"].Value = pub;

                objSqlCommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edit"].Value = edit;

                objSqlCommand.Parameters.Add("period", MySqlDbType.VarChar);
                objSqlCommand.Parameters["period"].Value = period;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("type", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["type"].Value = type;

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







    }
}