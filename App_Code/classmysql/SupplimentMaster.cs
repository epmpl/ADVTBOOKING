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
    /// Summary description for SupplimentMaster
    /// </summary>
    public class SupplimentMaster:connection 
    {
        public SupplimentMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
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
                objmysqlcommand = GetCommand("bind_pubname_p", ref objmysqlconnection);
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

        public DataSet supptyp(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_supptyp", ref objmysqlconnection);
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




        public DataSet SubPub()
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

                //				objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["edit"].Value =edit;
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

                //				objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["dist"].Value =dist;
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

        public DataSet ModifyValue(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid, string uom, string column, string height, string width, string area, string periodicity, string supptyp, string gut, string col, string hr, string min, string pro)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_Supplementmodify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("PubName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PubName"].Value = PubName;

                objmysqlcommand.Parameters.Add("EditionName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditionName"].Value = EditonName;

                objmysqlcommand.Parameters.Add("SuppName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["SuppName"].Value = SuppName;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlcommand.Parameters.Add("SuppCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["SuppCode"].Value = SuppCode;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("column1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["column1"].Value = column;

                objmysqlcommand.Parameters.Add("height", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["height"].Value = height;

                objmysqlcommand.Parameters.Add("width", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["width"].Value = width;

                objmysqlcommand.Parameters.Add("area1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["area1"].Value = area;

                objmysqlcommand.Parameters.Add("periodicity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["periodicity"].Value = periodicity;

                objmysqlcommand.Parameters.Add("supptypcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supptypcode"].Value = supptyp;

                objmysqlcommand.Parameters.Add("gut", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gut"].Value = gut;

                objmysqlcommand.Parameters.Add("col", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["col"].Value = col;

                objmysqlcommand.Parameters.Add("hr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hr"].Value = hr;

                objmysqlcommand.Parameters.Add("min1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["min1"].Value = min;

                objmysqlcommand.Parameters.Add("pro", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pro"].Value = pro;




                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet InsertValue(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid, string uom, string column, string height, string width, string area, string periodicity, string supptyp, string gut, string col, string hr, string min, string pro)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_Supplementinsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("PubName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PubName"].Value = PubName;

                objmysqlcommand.Parameters.Add("EditonName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["EditonName"].Value = EditonName;

                objmysqlcommand.Parameters.Add("SuppName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["SuppName"].Value = SuppName;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlcommand.Parameters.Add("SuppCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["SuppCode"].Value = SuppCode;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("column1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["column1"].Value = column;

                objmysqlcommand.Parameters.Add("height", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["height"].Value = height;

                objmysqlcommand.Parameters.Add("width", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["width"].Value = width;

                objmysqlcommand.Parameters.Add("area1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["area1"].Value = area;

                objmysqlcommand.Parameters.Add("periodicity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["periodicity"].Value = periodicity;

                objmysqlcommand.Parameters.Add("supptypcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supptypcode"].Value = supptyp;

                objmysqlcommand.Parameters.Add("gut", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gut"].Value = gut;

                objmysqlcommand.Parameters.Add("col", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["col"].Value = col;

                objmysqlcommand.Parameters.Add("hr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hr"].Value = hr;

                objmysqlcommand.Parameters.Add("min1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["min1"].Value = min;

                objmysqlcommand.Parameters.Add("prod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prod"].Value = pro;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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



        public DataSet getRO(string PubName, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("GETRO_getro_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = compcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = PubName;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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







        public DataSet SelectValue(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid, string uom, string column, string height, string width, string area, string periodicity, string supptyp, string gut, string col, string hr, string min, string pro)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_SupplementSelect", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("PubName", MySqlDbType.VarChar);
                //if(PubName=="" ||PubName==null || PubName=="0")
                {
                    //	objmysqlcommand.Parameters["PubName"].Value ="%%";		
                }
                //else
                {
                    objmysqlcommand.Parameters["PubName"].Value = PubName;
                }




                objmysqlcommand.Parameters.Add("EditonName", MySqlDbType.VarChar);
                //if(EditonName=="" ||EditonName==null||EditonName=="0")
                {
                    //		objmysqlcommand.Parameters["EditonName"].Value ="%%";
                }
                //	else
                {
                    objmysqlcommand.Parameters["EditonName"].Value = EditonName;
                }


                objmysqlcommand.Parameters.Add("SuppName", MySqlDbType.VarChar);
                //if(SuppName ==""||SuppName ==null)
                {
                    //	objmysqlcommand.Parameters["SuppName "].Value ="%%";
                }
                //else
                {
                    objmysqlcommand.Parameters["SuppName"].Value = SuppName;
                }


                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                //if(Alias=="" ||Alias==null)
                {
                    //	objmysqlcommand.Parameters["Alias "].Value ="%%";
                }
                //else
                {
                    objmysqlcommand.Parameters["Alias"].Value = Alias;
                }

                objmysqlcommand.Parameters.Add("SuppCode", MySqlDbType.VarChar);
                //if(SuppCode==""||SuppCode==null)
                {
                    //	objmysqlcommand.Parameters["SuppCode"].Value ="%%";
                }
                //else
                {
                    objmysqlcommand.Parameters["SuppCode"].Value = SuppCode;
                }

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);

                // if (uom == "0" || uom == null || uom == "undefined")
                {
                    //     objmysqlcommand.Parameters["uom"].Value = "%%";
                }
                // else
                {

                    objmysqlcommand.Parameters["uom"].Value = uom;
                }

                objmysqlcommand.Parameters.Add("column1", MySqlDbType.VarChar);

                // if (column == "" || column == null || column == "undefined")
                {
                    //     objmysqlcommand.Parameters["column"].Value = "%%";
                }
                //  else
                {

                    objmysqlcommand.Parameters["column1"].Value = column;
                }

                objmysqlcommand.Parameters.Add("height", MySqlDbType.VarChar);

                // if (height == "" || height == null || height == "undefined")
                {
                    //     objmysqlcommand.Parameters["height"].Value = "%%";
                }
                //   else
                {

                    objmysqlcommand.Parameters["height"].Value = height;
                }

                objmysqlcommand.Parameters.Add("width", MySqlDbType.VarChar);

                //  if (width == "" || width == null || width == "undefined")
                {
                    //      objmysqlcommand.Parameters["width"].Value = "%%";
                }
                //  else
                {

                    objmysqlcommand.Parameters["width"].Value = width;
                }

                objmysqlcommand.Parameters.Add("area1", MySqlDbType.VarChar);

                // if (area == "" || area == null || area == "undefined")
                {
                    //       objmysqlcommand.Parameters["area"].Value = "%%";
                }
                //   else
                {

                    objmysqlcommand.Parameters["area1"].Value = area;


                }

                objmysqlcommand.Parameters.Add("periodicity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["periodicity"].Value = periodicity;

                objmysqlcommand.Parameters.Add("supptypcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supptypcode"].Value = supptyp;

                objmysqlcommand.Parameters.Add("gut", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gut"].Value = gut;

                objmysqlcommand.Parameters.Add("col", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["col"].Value = col;

                objmysqlcommand.Parameters.Add("hr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hr"].Value = hr;

                objmysqlcommand.Parameters.Add("min1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["min1"].Value = min;

                objmysqlcommand.Parameters.Add("pro", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pro"].Value = pro;

                
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet Selectfnpl(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_supplementfnpl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                //objmysqlcommand.Parameters.Add("PubName", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["PubName"].Value =PubName;


                //				objmysqlcommand.Parameters.Add("SuppName", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["SuppName"].Value =SuppName;

                //objmysqlcommand.Parameters.Add("CityName ", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["CityName "].Value =CityName ;


                //objmysqlcommand.Parameters.Add("EditionName ", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["EditionName "].Value =EditionName;

                //objmysqlcommand.Parameters.Add("Alias ", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["Alias "].Value =Alias;

                //objmysqlcommand.Parameters.Add("EditonCode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["EditonCode"].Value =EditonCode;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet checksupcode(string compcode, string suppcode, string userid, string pubcode, string editioncode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checksupplementcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                //objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["editioncode"].Value = editioncode;

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

        public DataSet selecteditiondaymodify(string compcode, string suppcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("supplementdaymodify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

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

        public DataSet editiondaysave(string compcode, string suppcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("supplementdaysave", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

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



        public DataSet chksupcode(string SuppCode, string compcode, string userid, string pubname, string editionname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chksupcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("SuppCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["SuppCode"].Value = SuppCode;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = pubname;

                objmysqlcommand.Parameters.Add("editionname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editionname"].Value = editionname;

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

        public DataSet supdel(string SuppCode, string compcode, string userid, string pubcode, string editioncode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("supplimentdel", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("SuppCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["SuppCode"].Value = SuppCode;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = editioncode;

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


        public DataSet chkcsupcode1(string str, string editstr, string pubeditstr)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chksuppcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if(str .Length >2)
                {
                objmysqlcommand.Parameters["cod"].Value = str.Substring (0,2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }

                objmysqlcommand.Parameters.Add("editstr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editstr"].Value = editstr;

                objmysqlcommand.Parameters.Add("pubeditstr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubeditstr"].Value = pubeditstr;



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


        public DataSet countedition(string editioncode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("filledition1", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = editioncode;

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


        public DataSet chkedition(string pubcode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkpublicationcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;
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












        public DataSet countcity(string edition)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillcity1", ref objmysqlconnection);
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


        public DataSet addedition(string pubname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fill_editionalias_fill_editionalias_p", ref objmysqlconnection);
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

        public DataSet findedition(string editname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fill_supplalias", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("editname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editname"].Value = editname;

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

        public DataSet inserteditname(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertsuppdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txteditionname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txteditionname"].Value = txteditionname;

                objmysqlcommand.Parameters.Add("txtdate", MySqlDbType.DateTime);
                if (txtdate == "" || txtdate == null)
                {
                    objmysqlcommand.Parameters["txtdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = txtaddate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        txtdate = mm + "/" + dd + "/" + yy;
                    }
                    objmysqlcommand.Parameters["txtdate"].Value = Convert.ToDateTime(txtdate).ToString("yyyy-MM-dd");
                }
               // objmysqlcommand.Parameters["txtdate"].Value = Convert.ToDateTime(txtdate);

                objmysqlcommand.Parameters.Add("txtaddate", MySqlDbType.DateTime);
                if (txtaddate == "" || txtaddate == null)
                {
                    objmysqlcommand.Parameters["txtaddate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtaddate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtaddate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = txtaddate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        txtaddate = mm + "/" + dd + "/" + yy;
                    }
                    objmysqlcommand.Parameters["txtaddate"].Value = Convert.ToDateTime(txtaddate).ToString("yyyy-MM-dd");
                }
                

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet selectedfromgrid(string suppcode, string compcode, string userid, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("selectfromsuppdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;



                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;




                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



              
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet gridupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatesuppdate", ref objmysqlconnection);
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


                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;




                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet griddelete(string suppcode, string compcode, string userid, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletegridsuppdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;

           
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }
        public DataSet chkdaetedit(string compcode, string suppcode, string fdate, string sdate)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdatesupp", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

                objmysqlcommand.Parameters.Add("fdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fdate"].Value = fdate;

                objmysqlcommand.Parameters.Add("sdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sdate"].Value = sdate;


               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet chkdateupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdatesuppupdate", ref objmysqlconnection);
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
                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;


             
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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
                objmysqlcommand = GetCommand("BINDSUPPDATE_BINDSUPPDATE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date1"].Value = date;





                //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["flag"].Value =z;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet filleditalias(string suppcode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillsuppalias", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;




                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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
                objmysqlcommand = GetCommand("chkperiodictyforsupp_chkperiodictyforsupp_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("periodicty", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["periodicty"].Value = periodicty;







               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        //***********************************************Check periodicity******************************
        public DataSet chkperiodicty_edition(string supplement)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkperiodictysupplement", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("supplement", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supplement"].Value = supplement;





             
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }












    }
}
