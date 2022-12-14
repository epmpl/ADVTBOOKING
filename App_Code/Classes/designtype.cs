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

using System.Data.SqlClient;
namespace NewAdbooking.Classes
{

    /// <summary>
    /// Summary description for logopremium_type
    /// </summary>
    public class designtype : connection
    {
        public designtype()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet Delete(string compcode, string amount)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deldesign", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@amount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@amount"].Value = amount;



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


        public DataSet update1(string COMP_CODE, string USERID, string LOGOPREMIUM_CODE, string EDITION, string AMOUNT, string premimum, string hdnsequenceno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Hupdatelogochild", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = COMP_CODE;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = USERID;

                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprem"].Value = LOGOPREMIUM_CODE;


                objSqlCommand.Parameters.Add("@EDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EDITION"].Value = EDITION;


                objSqlCommand.Parameters.Add("@AMOUNT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@AMOUNT"].Value = AMOUNT;

                objSqlCommand.Parameters.Add("@premimum", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premimum"].Value = premimum;


                objSqlCommand.Parameters.Add("@hdnsequenceno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hdnsequenceno"].Value = hdnsequenceno;









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


        public DataSet duplicay1(string compcode, string logoprem, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("duplicaydesingbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprem"].Value = logoprem;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;



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





        public DataSet save(string compcode, string userid, string logoprem, string edition, string premimum, string amount)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("savedesignchild", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMP_CODE"].Value = compcode;


                objSqlCommand.Parameters.Add("@USERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@USERID"].Value = userid;

                objSqlCommand.Parameters.Add("@LOGOPREMIUM_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@LOGOPREMIUM_CODE"].Value = logoprem;


                objSqlCommand.Parameters.Add("@EDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EDITION"].Value = edition;


                objSqlCommand.Parameters.Add("@PREMIUM", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PREMIUM"].Value = premimum;

                objSqlCommand.Parameters.Add("@AMOUNT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@AMOUNT"].Value = amount;







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

        public DataSet logobind(string compcode, string logocode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("designbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@logoprcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprcode"].Value = logocode;



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



        public DataSet logobind1(string compcode, string logocode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("designbind1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@amount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@amount"].Value = logocode;






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











        public DataSet chkpastypename1(string PosTypCode, string PosTypName, string compcode, string userid, string fdate, string tdate, string flag)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                string dateformat = "dd/mm/yyyy";


                objSqlConnection.Open();
                objSqlCommand = GetCommand("designTypechknameindate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@p_PosTypCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_PosTypCode"].Value = PosTypCode;

                objSqlCommand.Parameters.Add("@p_PosTypName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_PosTypName"].Value = PosTypName;

                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_userid"].Value = userid;

                objSqlCommand.Parameters.Add("@p_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_flag"].Value = flag;

                objSqlCommand.Parameters.Add("@p_fdate", SqlDbType.VarChar);
                if (fdate == "" || fdate == null)
                {
                    objSqlCommand.Parameters["@p_fdate"].Value = System.DBNull.Value;
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
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_fdate"].Value = fdate;
                }

                objSqlCommand.Parameters.Add("@p_tdate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@p_tdate"].Value = System.DBNull.Value;
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
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_tdate"].Value = tdate;
                }

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
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

        public DataSet chkadvposition1(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkadvdestyp ", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;


                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;




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

        public DataSet SelectValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string dateformat)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("designTypeSelect", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
                /*	if(PosTypCode=="" ||PosTypCode==null || PosTypCode=="0")
                    {
                        objSqlCommand.Parameters["@PosTypCode"].Value ="%%";		
                    }
                    else*/
                //	{
                objSqlCommand.Parameters["@PosTypCode"].Value = PosTypCode;
                //	}




                objSqlCommand.Parameters.Add("@PosType", SqlDbType.VarChar);
                /*	if(PosType=="" ||PosType==null||PosType=="0")
                    {
                        objSqlCommand.Parameters["@PosType"].Value ="%%";
                    }
                    else*/
                //{
                objSqlCommand.Parameters["@PosType"].Value = PosType;
                //}

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
                /*if(@Alias=="" ||@Alias==null)
                {
                    objSqlCommand.Parameters["@Alias "].Value ="%%";
                }
                else*/
                //{
                objSqlCommand.Parameters["@Alias "].Value = Alias;
                //}


                /*        objSqlCommand.Parameters.Add("@pageno",SqlDbType.VarChar);

               
                        objSqlCommand.Parameters["@pageno "].Value = pageno;*/

                objSqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
                if (amount == "" || amount == null)
                {
                    objSqlCommand.Parameters["@amount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@amount"].Value = Convert.ToDecimal(amount);
                }

                objSqlCommand.Parameters.Add("@p_dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_dateformat"].Value = dateformat;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
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


        public DataSet ModifyValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("designeMstModify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PosTypCode"].Value = PosTypCode;

                objSqlCommand.Parameters.Add("@PosType", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PosType"].Value = PosType;

                objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Alias "].Value = Alias;



                objSqlCommand.Parameters.Add("@Amount", SqlDbType.Decimal);
                if (amount == "" || amount == null)
                {
                    objSqlCommand.Parameters["@Amount"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Amount"].Value = Convert.ToDecimal(amount);
                }


                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@p_fdate", SqlDbType.VarChar);
                if (fdate == "" || fdate == null)
                {
                    objSqlCommand.Parameters["@p_fdate"].Value = System.DBNull.Value;
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
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_fdate"].Value = fdate;
                }

                objSqlCommand.Parameters.Add("@p_tdate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@p_tdate"].Value = System.DBNull.Value;
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
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_tdate"].Value = tdate;
                }

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (SqlException objException)
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


        public DataSet delete1(string PosTypCode, string compcode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("destypedel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PosTypCode"].Value = PosTypCode;





                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
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

        public DataSet chksave(string PosTypCode, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("DESTypechk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PosTypCode"].Value = PosTypCode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
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

        public DataSet InsertValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string dateformat)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("DESTypeMstInser", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@PosTypCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PosTypCode"].Value = PosTypCode;

                objSqlCommand.Parameters.Add("@PosType", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PosType"].Value = PosType;

                objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Alias "].Value = Alias;


                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                //objSqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
                //objSqlCommand.Parameters["@amount"].Value = amount;

                /*change ankur*/
                objSqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
                if (amount == "" || amount == null)
                {
                    objSqlCommand.Parameters["@amount"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@amount"].Value = Convert.ToDecimal(amount);
                }

                objSqlCommand.Parameters.Add("@p_fdate", SqlDbType.VarChar);
                if (fdate == "" || fdate == null)
                {
                    objSqlCommand.Parameters["@p_fdate"].Value = System.DBNull.Value;
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
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_fdate"].Value = fdate;
                }

                objSqlCommand.Parameters.Add("@p_tdate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@p_tdate"].Value = System.DBNull.Value;
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
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@p_tdate"].Value = tdate;
                }


                objSqlCommand.Parameters.Add("@des_desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@des_desc"].Value = premium;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (SqlException objException)
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









    }
}