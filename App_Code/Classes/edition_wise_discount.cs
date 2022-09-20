using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for edition_wise_discount
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class edition_wise_discount : connection
    {
        public edition_wise_discount()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet filleditalias(string editcode, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("filleditalias", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;




                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet discbind(string code, string compcode, string userid, string date)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindeditdisc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date"].Value = date;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet chkduplicate(string compcode, string disccode,string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editdiscchk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@disccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disccode"].Value = disccode;

                objSqlCommand.Parameters.Add("@discdes", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discdes"].Value = unit;

                //objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@padtype"].Value = adtype;

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
        public DataSet inserteditname(string compcode, string unit, string txtaddate, string year, string txteditionname, string txtdate, string createddate, string userid, string updateddate, string updatedby, string editcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editdiscsave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
               
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pUNIT_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUNIT_CODE"].Value = unit;

                objSqlCommand.Parameters.Add("@pFROM_EDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pFROM_EDITION"].Value = txtaddate;

                objSqlCommand.Parameters.Add("@pTO_EDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pTO_EDITION"].Value = year;

                objSqlCommand.Parameters.Add("@pDISC_TYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pDISC_TYPE"].Value = txteditionname;


                objSqlCommand.Parameters.Add("@pDISCOUNT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pDISCOUNT"].Value = txtdate;


                objSqlCommand.Parameters.Add("@pCREATION_DATETIME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pCREATION_DATETIME"].Value = createddate;


                objSqlCommand.Parameters.Add("@pUSERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUSERID"].Value = userid;


                objSqlCommand.Parameters.Add("@pUPDATED_DATETIME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUPDATED_DATETIME"].Value = updateddate;


                objSqlCommand.Parameters.Add("@pUPDATEDBY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUPDATEDBY"].Value = updatedby;


                objSqlCommand.Parameters.Add("@pDISC_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pDISC_CODE"].Value = editcode;


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

        public DataSet selectedfromgrid(string compcode, string userid, string unitcode, string disccode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("selecteditiondiscount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = unitcode;



                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = disccode;




                //objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@flag"].Value =z;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet chkdateupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkeditdiscountupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@txteditionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txteditionname"].Value = txteditionname;

                objSqlCommand.Parameters.Add("@txtdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtdate"].Value = txtdate;

                objSqlCommand.Parameters.Add("@txtaddate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtaddate"].Value = txtaddate;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;

                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = unit;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet gridupdate(string compcode, string unit, string txtaddate, string year, string txteditionname, string txtdate, string createddate, string userid, string updateddate, string updatedby, string editcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateeditdiscount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pUNIT_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUNIT_CODE"].Value = unit;

                objSqlCommand.Parameters.Add("@pFROM_EDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pFROM_EDITION"].Value = txtaddate;

                objSqlCommand.Parameters.Add("@pTO_EDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pTO_EDITION"].Value = year;

                objSqlCommand.Parameters.Add("@pDISC_TYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pDISC_TYPE"].Value = txteditionname;


                objSqlCommand.Parameters.Add("@pDISCOUNT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pDISCOUNT"].Value = txtdate;


                objSqlCommand.Parameters.Add("@pCREATION_DATETIME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pCREATION_DATETIME"].Value = createddate;


                objSqlCommand.Parameters.Add("@pUSERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUSERID"].Value = userid;


                objSqlCommand.Parameters.Add("@pUPDATED_DATETIME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUPDATED_DATETIME"].Value = updateddate;


                objSqlCommand.Parameters.Add("@pUPDATEDBY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pUPDATEDBY"].Value = updatedby;


                objSqlCommand.Parameters.Add("@pDISC_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pDISC_CODE"].Value = editcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet griddelete(string editcode, string compcode, string userid, string Unit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletegrideditdiscount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;

                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = Unit;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

    }


}