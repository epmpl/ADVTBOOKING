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
    /// Summary description for bookingmaterialdata
    /// </summary>
    public class bookingmaterialdata : connection
    {
        public bookingmaterialdata()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        // FOR BOOKINGMATERIALDATA 

        public DataSet bookingmaterialdatabind(string compcode, string drppubcenterc, string drpadtypec, string drppublicationc, string fromdate, string todate, string extra1, string extra2, string extra3, string extra4)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("booking_material_det", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.CommandTimeout = 200;

                objmysqlcommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcompcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ppubcent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppubcent"].Value = drppubcenterc;

                objmysqlcommand.Parameters.Add("ppadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppadtype"].Value = drpadtypec;

                objmysqlcommand.Parameters.Add("ppublication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppublication"].Value = drppublicationc;

                objmysqlcommand.Parameters.Add("pfromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pfromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("ptodate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ptodate"].Value = todate;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = extra2;

                objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra3"].Value = extra3;

                objmysqlcommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra4"].Value = extra4;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        public DataSet booking_import_data_bind(string compcode, string drppubcenterc, string drpadtypec, string drppublicationc, string fromdate, string todate, string extra1, string extra2, string extra3, string extra4)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();

            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ad_bill_data_tnie", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.CommandTimeout = 200;

                objmysqlcommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcompcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ppubcent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppubcent"].Value = drppubcenterc;

                objmysqlcommand.Parameters.Add("ppadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppadtype"].Value = drpadtypec;

                objmysqlcommand.Parameters.Add("ppublication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppublication"].Value = drppublicationc;

                objmysqlcommand.Parameters.Add("pfromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pfromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("ptodate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ptodate"].Value = todate;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = extra2;

                objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra3"].Value = extra3;

                objmysqlcommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra4"].Value = extra4;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        public DataSet booking_import_data_dpsbind(string compcode, string drppubcenterc, string drpadtypec, string drppublicationc, string fromdate, string todate, string extra1, string extra2, string extra3, string extra4)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("booking_data_upload_det", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.CommandTimeout = 200;

                objmysqlcommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcompcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ppubcent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppubcent"].Value = drppubcenterc;

                objmysqlcommand.Parameters.Add("ppadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppadtype"].Value = drpadtypec;

                objmysqlcommand.Parameters.Add("ppublication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppublication"].Value = drppublicationc;

                objmysqlcommand.Parameters.Add("pfromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pfromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("ptodate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ptodate"].Value = todate;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = extra2;

                objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra3"].Value = extra3;

                objmysqlcommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra4"].Value = extra4;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        // FOR BOOKINGMATERIALDATA 

        public DataSet bookingmasterdatabind(string compcode, string drppubcenterc, string drpadtypec, string drppublicationc, string fromdate, string todate, string extra1, string extra2, string extra3, string extra4)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("booking_master_report_new", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.CommandTimeout = 200;

                objmysqlcommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcompcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ppubcent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppubcent"].Value = drppubcenterc;

                objmysqlcommand.Parameters.Add("ppadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppadtype"].Value = drpadtypec;

                objmysqlcommand.Parameters.Add("ppublication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppublication"].Value = drppublicationc;

                objmysqlcommand.Parameters.Add("pfromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pfromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("ptodate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ptodate"].Value = todate;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = extra2;

                objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra3"].Value = extra3;

                objmysqlcommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra4"].Value = extra4;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return (objDataSet);
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