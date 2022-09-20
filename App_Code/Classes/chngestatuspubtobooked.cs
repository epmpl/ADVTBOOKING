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
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.Classes
{

    /// <summary>
    /// Summary description for chngestatuspubtobooked
    /// </summary>
    public class chngestatuspubtobooked : connection
    {
        public chngestatuspubtobooked()
        {
            //
            // TODO: Add constructor logic here
            //
        }






        public DataSet update(string insertid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateholdtobooked", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@insertid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertid"].Value = insertid;



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















        public DataSet bindgridchangestatus(string validfrom, string validto, string agency, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindgrid_changestatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pagencycode", SqlDbType.VarChar);


                if (agency == "")
                {
                    objSqlCommand.Parameters["@pagencycode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pagencycode"].Value = agency;
                }

                objSqlCommand.Parameters.Add("@pcioid", SqlDbType.VarChar);

                if (cioid == "")
                {
                    objSqlCommand.Parameters["@pcioid"].Value = System.DBNull.Value;
                }

                else
                {
                    objSqlCommand.Parameters["@pcioid"].Value = cioid;
                }



                objSqlCommand.Parameters.Add("@validfrom", SqlDbType.VarChar);
                string dateformat = "dd/mm/yyyy";
                if (validfrom == "")
                {
                    objSqlCommand.Parameters["@validfrom"].Value = System.DBNull.Value;
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
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validfrom = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@validfrom"].Value = validfrom;
                }





                objSqlCommand.Parameters.Add("@validto", SqlDbType.VarChar);

                if (validto == "")
                {
                    objSqlCommand.Parameters["@validto"].Value = System.DBNull.Value;
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
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validto = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@validto"].Value = validto;
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




    }
}
