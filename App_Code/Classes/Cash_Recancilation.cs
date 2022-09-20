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
    /// Summary description for Booking_Audit1
    /// </summary>
    public class Cash_Recancilation : connection
    {
	    public Cash_Recancilation()
	    {
		//
		// TODO: Add constructor logic here
		//
	    }
       
        public DataSet submitdata(string compcode, string branch_code, string frmdt, string todt, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("FATCH_CASH_RECONCILLATION", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = compcode;

                com.Parameters.Add("@pbran_code", SqlDbType.VarChar);
                com.Parameters["@pbran_code"].Value = branch_code;


                com.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                com.Parameters["@pfromdate"].Value = frmdt;

                com.Parameters.Add("@ptodate", SqlDbType.VarChar);
                com.Parameters["@ptodate"].Value = todt;


                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = extra1;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = extra2;


                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = extra3;


                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = extra4;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = extra5;


                com.Parameters.Add("@pextra6", SqlDbType.VarChar);
                com.Parameters["@pextra6"].Value = extra6;



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

        public DataSet savedata(string compcode, string branch_code, string doctype, string bkidnum, string recptno, string recptdt, string amount, string agmaincode, string agsubcode, string deposittype, string depositnum, string depositdate, string userid, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("SAVE_CASH_RECONCILLATION", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = compcode;

                com.Parameters.Add("@pbran_code", SqlDbType.VarChar);
                com.Parameters["@pbrancode"].Value = branch_code;


                com.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                com.Parameters["@pdoctype"].Value = doctype;

                com.Parameters.Add("@pbkidnum", SqlDbType.VarChar);
                com.Parameters["@pbkidnum"].Value = bkidnum;

                com.Parameters.Add("@precptno", SqlDbType.VarChar);
                com.Parameters["@precptno"].Value = recptno;

                com.Parameters.Add("@precptdt", SqlDbType.VarChar);
                com.Parameters["@precptdt"].Value = recptdt;

                com.Parameters.Add("@pamount", SqlDbType.VarChar);
                com.Parameters["@pamount"].Value = amount;

                com.Parameters.Add("@pagmaincode", SqlDbType.VarChar);
                com.Parameters["@pagmaincode"].Value = agmaincode;

                com.Parameters.Add("@pagsubcode", SqlDbType.VarChar);
                com.Parameters["@pagsubcode"].Value = agsubcode;

                com.Parameters.Add("@pdeposittype", SqlDbType.VarChar);
                com.Parameters["@pdeposittype"].Value = deposittype;

                com.Parameters.Add("@pdepositnum", SqlDbType.VarChar);
                com.Parameters["@pdepositnum"].Value = depositnum;

                com.Parameters.Add("@pdepositdate", SqlDbType.VarChar);
                com.Parameters["@pdepositdate"].Value = depositdate;

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = userid;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = extra1;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = extra2;


                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = extra3;


                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = extra4;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = extra5;


                com.Parameters.Add("@pextra6", SqlDbType.VarChar);
                com.Parameters["@pextra6"].Value = extra6;

                com.Parameters.Add("@pextra7", SqlDbType.VarChar);
                com.Parameters["@pextra7"].Value = extra7;



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