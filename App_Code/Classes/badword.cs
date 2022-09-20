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




    /// <summary>
    /// Summary description for badword
    /// </summary>
    namespace NewAdbooking.Classes
    {
        public class badwordnew : connection
        {
            public badwordnew()
            {
                //
                // TODO: Add constructor logic here
                //
            }

            public DataSet chkbadword1(string badword)
            {
                SqlConnection objSqlConnection;
                SqlCommand objSqlCommand;
                objSqlConnection = GetConnection();
                SqlDataAdapter objSqlDataAdapter;
                DataSet objDataSet = new DataSet();

                //objSqlConnection = GetConnection();
                //SqlDataAdapter objSqlDataAdapter;
                //DataSet objDataSet = new DataSet();

                try
                {
                    objSqlConnection.Open();
                    objSqlCommand = GetCommand("chkbadword", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("@badword", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@badword"].Value = badword;

                    objSqlDataAdapter = new SqlDataAdapter();
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

