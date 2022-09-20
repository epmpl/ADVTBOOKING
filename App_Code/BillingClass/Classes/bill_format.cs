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
/// Summary description for bill_format
/// </summary>
/// 
namespace NewAdbooking.BillingClass.Classes
{
    public class bill_format : NewAdbooking.Classes.connection
    {
        public bill_format()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet updatevalues(string ciobooking, string editionname, string compcode, string insertion, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("websp_selectvalues", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;

                com.Parameters.Add("@editionname", SqlDbType.VarChar);
                com.Parameters["@editionname"].Value = editionname;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;

                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }




        public DataSet bindedition(string editoncode, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("websp_selectedition", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@editoncode", SqlDbType.VarChar);
                com.Parameters["@editoncode"].Value = editoncode;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

               
                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


    }
}