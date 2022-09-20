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
public class QutationApproval: connection
{
	public QutationApproval()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet findrecord(string userid, string compcode, string agency, string executive, string client,string retainer, string fdate, string tdate, string dateformat,string flag, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getquotationapproval", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@vusername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vusername"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive"].Value = executive;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                 objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer"].Value = retainer;


                objSqlCommand.Parameters.Add("@varFromDate", SqlDbType.VarChar);
                if (fdate == "" || fdate == null)
                {
                    objSqlCommand.Parameters["@varFromDate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@varFromDate"].Value = fdate;
                }

                objSqlCommand.Parameters.Add("@varToDate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@varToDate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@varToDate"].Value = tdate;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

               

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

                // objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                 //if (adtype == null || adtype == "" )
                 //{
                 //    objSqlCommand.Parameters["@adtype"].Value = System.DBNull.Value;
                 //}
                 //else
                 //{
                 //    com.Parameters["@adtype"].Value = Convert.ToDateTime(adtype);

                 //}
                 objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                 if (adtype == "0" || adtype == null)
                 {
                     objSqlCommand.Parameters["@adtype"].Value = System.DBNull.Value;
                 }
                 else
                 {
                     objSqlCommand.Parameters["@adtype"].Value =adtype;
                 }


                 //sqlcom.Parameters.Add("@attachment", SqlDbType.VarChar);
                 //if (attachment == "" && attachment == null)
                 //{
                 //    sqlcom.Parameters["@attachment"].Value = System.DBNull.Value;
                 //}
                 //else
                 //{
                 //    sqlcom.Parameters["@attachment"].Value = attachment;
                 //}





              //  objSqlCommand.Parameters["@adtype"].Value = adtype;
                

                


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
    public DataSet executeauditmast1(string bookingid, string compcode, string adtype, string dateformat)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("executebooking_new_quotation", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@ciobookid", SqlDbType.VarChar);
            com.Parameters["@ciobookid"].Value = bookingid;

            com.Parameters.Add("@compcode", SqlDbType.VarChar);
            com.Parameters["@compcode"].Value = compcode;


            com.Parameters.Add("@docno", SqlDbType.VarChar);
            com.Parameters["@docno"].Value = System.DBNull.Value;

            com.Parameters.Add("@keyno", SqlDbType.VarChar);
            com.Parameters["@keyno"].Value = System.DBNull.Value;



            com.Parameters.Add("@rono", SqlDbType.VarChar);
            com.Parameters["@rono"].Value = System.DBNull.Value;

            com.Parameters.Add("@agencycode", SqlDbType.VarChar);
            com.Parameters["@agencycode"].Value = System.DBNull.Value;


            com.Parameters.Add("@client", SqlDbType.VarChar);
            com.Parameters["@client"].Value = System.DBNull.Value;



            com.Parameters.Add("@booking", SqlDbType.VarChar);
            com.Parameters["@booking"].Value = adtype;

            com.Parameters.Add("@dateformat", SqlDbType.VarChar);
            com.Parameters["@dateformat"].Value = dateformat;


            com.Parameters.Add("@revenue", SqlDbType.VarChar);
            com.Parameters["@revenue"].Value = System.DBNull.Value;





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

    public DataSet savedata(string remarks, string userid, string appstatus, string insertid, string bookid1,string compcode,string center,string dateformate)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("savequotationinbookingtable", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@premarks", SqlDbType.VarChar);
            com.Parameters["@premarks"].Value = remarks;

            com.Parameters.Add("@puserid", SqlDbType.VarChar);
            com.Parameters["@puserid"].Value = userid;


            com.Parameters.Add("@pappstatus", SqlDbType.VarChar);
            com.Parameters["@pappstatus"].Value = appstatus;

            com.Parameters.Add("@pinsertid", SqlDbType.VarChar);
            com.Parameters["@pinsertid"].Value = insertid;



            com.Parameters.Add("@pbookid1", SqlDbType.VarChar);
            com.Parameters["@pbookid1"].Value = bookid1;

            com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            com.Parameters["@pcompcode"].Value = compcode;

            com.Parameters.Add("@pcenter", SqlDbType.VarChar);
            com.Parameters["@pcenter"].Value = center.Substring(0, 3);

            com.Parameters.Add("@pdateformate", SqlDbType.VarChar);
            com.Parameters["@pdateformate"].Value = dateformate;

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

    //public string commitT(int count, string cioid, string pcompcode, string pcentname, string puserid, string pbkid_gentype, string pbk_type)
    //{
    //    SqlConnection objSqlConnection;
    //    SqlCommand objSqlCommand;
    //    objSqlConnection = GetConnection();
    //    SqlDataAdapter objSqlDataAdapter;
    //   // string error = "";
    //    DataSet objDataSet = new DataSet();
    //    try
    //    {
    //        objSqlConnection.Open();
    //        objSqlCommand = GetCommand("committransaction", ref objSqlConnection);
    //        objSqlCommand.CommandType = CommandType.StoredProcedure;
    //        objSqlDataAdapter = new SqlDataAdapter();

    //        objSqlCommand.Parameters.Add("@pcioid", SqlDbType.VarChar);
    //        objSqlCommand.Parameters["@pcioid"].Value = cioid;

    //        objSqlCommand.Parameters.Add("@totalcount", SqlDbType.Int);
    //        objSqlCommand.Parameters["@totalcount"].Value = count;

    //        objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
    //        objSqlCommand.Parameters["@pcompcode"].Value = pcompcode;

    //        objSqlCommand.Parameters.Add("@pcentname", SqlDbType.VarChar);
    //        objSqlCommand.Parameters["@pcentname"].Value = pcentname;

    //        objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
    //        objSqlCommand.Parameters["@puserid"].Value = puserid;

    //        objSqlCommand.Parameters.Add("@pbkid_gentype", SqlDbType.VarChar);
    //        objSqlCommand.Parameters["@pbkid_gentype"].Value = pbkid_gentype;

    //        objSqlCommand.Parameters.Add("@pbk_type", SqlDbType.VarChar);
    //        objSqlCommand.Parameters["@pbk_type"].Value = pbk_type;

    //        objSqlDataAdapter.SelectCommand = objSqlCommand;
    //        objSqlDataAdapter.Fill(objDataSet);

    //      //  return error = "AA" + "$~$" + objDataSet.Tables[0].Rows[0][0].ToString();

    //        //objSqlDataAdapter.SelectCommand = objSqlCommand;
    //        //objSqlCommand.ExecuteNonQuery();
    //        // objSqlDataAdapter.Fill(objDataSet);


    //    }
    //    catch (Exception ex)
    //    {
    //     //   error = ex.Message;
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        CloseConnection(ref objSqlConnection);
    //    }
    //  //  return error;
    //}
       
}

}
