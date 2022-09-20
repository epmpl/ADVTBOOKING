using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for addummydaypages
    /// </summary>
    public class addummydaypages : connection
    {
        //private string _comCode;

        //public string comCode { get { return _comCode; } set { _comCode = value; } }

        public addummydaypages()
        {
            //
            // TODO: Add constructor logic here
            //
        }

//**********This function is used to GET the Pulication Name using stored procedure Bind_Pubname*************
        public DataSet getPubName(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_Pubname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public DataSet getPubCName()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_PubCentName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;                
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
//**********************************************************************************************************

//**********This function is used to GET the Edition Name using stored procedure Bind_EdiName***************
        public DataSet getEdiName(string pubcode,string pubcenter)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_EdiName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit"].Value = pubcode;
                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = pubcenter;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

//**********************************************************************************************************

//**********This function is used to GET the Suppliment using stored procedure bindsuppliment***************

        public DataSet getSuppliment(string pubcode, string pubedit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindsuppliment", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = pubcode;
                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = pubedit;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
//**********************************************************************************************************

//**********This function is used to Insert the Data using stored procedure adDDPInsert***************

        public DataSet insertData(string day, string pubCode, string centerCode, string ediCode, string supCode, string nPages, string dFrom, string dTo, string compCode, string userId)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;            
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPInsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_day"].Value = day;

                objSqlCommand.Parameters.Add("@pub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_code"].Value = pubCode;

                objSqlCommand.Parameters.Add("@center_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center_code"].Value = centerCode;

                objSqlCommand.Parameters.Add("@edition_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_code"].Value = ediCode;

                objSqlCommand.Parameters.Add("@sub_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sub_pub"].Value = supCode;

                objSqlCommand.Parameters.Add("@npages", SqlDbType.Int);
                if (nPages == "")
                {
                    objSqlCommand.Parameters["@npages"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@npages"].Value = Convert.ToInt32(nPages);
                }
                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.DateTime);
                if (dFrom == "")
                {
                    objSqlCommand.Parameters["@datefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@datefrom"].Value = Convert.ToDateTime(dFrom);
                }
                objSqlCommand.Parameters.Add("@dateto", SqlDbType.DateTime);
                if (dTo == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value =System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = Convert.ToDateTime(dTo);
                }
                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compCode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userId;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
             //   objSqlCommand.ExecuteNonQuery();
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
          }
           catch (Exception objException)
           {
                throw (objException);
            }
            finally
           {
               objSqlConnection.Close();

            }
        }

//**********************************************************************************************************

//**********This function is used to check the Duplicate Data using stored procedure adDDPDupChk*********************
        public string chkDupRec(string day, string pubCode, string centerCode, string ediCode, string supCode,string recordId)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            string dup;

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPDupChk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_day"].Value = day;

                objSqlCommand.Parameters.Add("@pub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_code"].Value = pubCode;

                objSqlCommand.Parameters.Add("@center_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center_code"].Value = centerCode;

                objSqlCommand.Parameters.Add("@edition_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_code"].Value = ediCode;

                objSqlCommand.Parameters.Add("@sub_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sub_pub"].Value = supCode;

                objSqlCommand.Parameters.Add("@record_id", SqlDbType.VarChar);
                if (recordId == "")
                {
                    objSqlCommand.Parameters["@record_id"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@record_id"].Value = recordId;
                }

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                
                objSqlDataAdapter.Fill(objDataSet);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    dup = "y";
                }
                else
                {
                    dup = "n";
                }
                return dup;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
//**********************************************************************************************************
        public DataSet getData(string compCode, string day, string pubCode, string centerCode, string ediCode, string supCode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPExecute", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compCode;

                objSqlCommand.Parameters.Add("@pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_day"].Value = day;

                objSqlCommand.Parameters.Add("@pub_code", SqlDbType.VarChar);
                if (pubCode == "")
                {
                    objSqlCommand.Parameters["@pub_code"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@pub_code"].Value = pubCode;
                }

                objSqlCommand.Parameters.Add("@center_code", SqlDbType.VarChar);
                if (centerCode == "")
                {
                    objSqlCommand.Parameters["@center_code"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@center_code"].Value = centerCode;
                }

                objSqlCommand.Parameters.Add("@edition_code", SqlDbType.VarChar);
                if (ediCode == "")
                {
                    objSqlCommand.Parameters["@edition_code"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@edition_code"].Value = ediCode;
                }

                objSqlCommand.Parameters.Add("@sub_pub", SqlDbType.VarChar);
                if (supCode == "")
                {
                    objSqlCommand.Parameters["@sub_pub"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@sub_pub"].Value = supCode;
                }

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;

                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

//**********************************************************************************************************
        public DataSet deleteData(string recordId)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPDelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@record_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@record_id"].Value = recordId;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;

                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

//******This is used to Update the data ori stand for original data on the basis update will occur************
        public DataSet updateData(string recordId, string day, string pubCode, string centerCode, string ediCode, string supCode, string nPages, string dFrom, string dTo, string compCode, string userId)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adDDPUpdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@record_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@record_id"].Value = recordId;

                objSqlCommand.Parameters.Add("@pub_day", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_day"].Value = day;

                objSqlCommand.Parameters.Add("@pub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub_code"].Value = pubCode;

                objSqlCommand.Parameters.Add("@center_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center_code"].Value = centerCode;

                objSqlCommand.Parameters.Add("@edition_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_code"].Value = ediCode;

                objSqlCommand.Parameters.Add("@sub_pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sub_pub"].Value = supCode;

                objSqlCommand.Parameters.Add("@npages", SqlDbType.Int);
                if (nPages == "")
                {
                    objSqlCommand.Parameters["@npages"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@npages"].Value = Convert.ToInt32(nPages);
                }
                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.DateTime);
                if (dFrom == "")
                {
                    objSqlCommand.Parameters["@datefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@datefrom"].Value = Convert.ToDateTime(dFrom);
                }
                objSqlCommand.Parameters.Add("@dateto", SqlDbType.DateTime);
                if (dTo == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = Convert.ToDateTime(dTo);
                }
                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compCode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userId;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                //   objSqlCommand.ExecuteNonQuery();
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }


//**********************************************************************************************************
    }
}