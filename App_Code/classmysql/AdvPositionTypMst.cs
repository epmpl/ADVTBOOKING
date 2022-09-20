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
    /// Summary description for AdvPositionTypMst
    /// </summary>
    public class AdvPositionTypMst : connection
    {
        public AdvPositionTypMst()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet ModifyValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("PositionTypeMstModify_PositionTypeMstModify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("PosTypCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PosTypCode"].Value = PosTypCode;

                objmysqlcommand.Parameters.Add("PosType", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PosType"].Value = PosType;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("amount1", MySqlDbType.Decimal);
                if (amount == "" || amount == null)
                {
                    objmysqlcommand.Parameters["amount1"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["amount1"].Value = Convert.ToDecimal(amount);
                }

                
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


        public DataSet chksave(string PosTypCode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("positiontypechk_positiontypechk_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("PosTypCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PosTypCode"].Value = PosTypCode;

               
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



        public DataSet delete1(string PosTypCode, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("positiontypedel_positiontypedel_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;


                objmysqlcommand.Parameters.Add("PosTypCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PosTypCode"].Value = PosTypCode;
                
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


        // ds = insert.InsertValue(Session["compcode"].ToString(), PosTypCode, PosType, Alias, amount, premium, userid, fdate, tdate, , description, adcat);
        public DataSet InsertValue(string compcode, string PosTypCode, string PosType, string Alias, string amount, string premium, string fdate, string tdate, string description, string adcat)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("LogTypeMstInsert_LogTypeMstInsert_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                


                objmysqlcommand.Parameters.Add("PosTypCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PosTypCode"].Value = PosTypCode;

                objmysqlcommand.Parameters.Add("PosType", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PosType"].Value = PosType;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;


                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                //objmysqlcommand.Parameters.Add("amount", MySqlDbType.Decimal);
                //objmysqlcommand.Parameters["amount"].Value = amount;

                objmysqlcommand.Parameters.Add("amount1", MySqlDbType.Decimal);
                if (amount == "" || amount == null)
                {
                    objmysqlcommand.Parameters["amount1"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["amount1"].Value = Convert.ToDecimal(amount);
                }

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;
               
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

    
        public DataSet SelectValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string dateformat)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
               objmysqlconnection.Open();
               objmysqlcommand = GetCommand("advdistypeselect_advdistypeselect_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("PosTypCode", MySqlDbType.VarChar);
                /*	if(PosTypCode=="" ||PosTypCode==null || PosTypCode=="0")
                    {
                        objmysqlcommand.Parameters["PosTypCode"].Value ="%%";		
                    }
                    else*/
                //	{
                objmysqlcommand.Parameters["PosTypCode"].Value = PosTypCode;
                //	}




                objmysqlcommand.Parameters.Add("PosType", MySqlDbType.VarChar);
                /*	if(PosType=="" ||PosType==null||PosType=="0")
                    {
                        objmysqlcommand.Parameters["PosType"].Value ="%%";
                    }
                    else*/
                //{
                objmysqlcommand.Parameters["PosType"].Value = PosType;
                //}

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                /*if(Alias=="" ||Alias==null)
                {
                    objmysqlcommand.Parameters["Alias "].Value ="%%";
                }
                else*/
                //{
                objmysqlcommand.Parameters["Alias"].Value = Alias;
                //}


                /*        objmysqlcommand.Parameters.Add("pageno",MySqlDbType.VarChar);

               
                        objmysqlcommand.Parameters["pageno "].Value = pageno;*/

                objmysqlcommand.Parameters.Add("amount", MySqlDbType.Decimal);
                if (amount == "" || amount == null)
                {
                    objmysqlcommand.Parameters["amount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["amount"].Value = Convert.ToDecimal(amount);
                }
                objmysqlcommand.Parameters.Add("p_dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_dateformat"].Value = dateformat;

                
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

        public DataSet Selectfnpl(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AdvPosTypefnpl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;



               
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


        public DataSet pagenobind1(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pagenobind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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


        public DataSet chkadvposition1(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkadvlogtyp_chkadvlogtyp_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0,2);
                }
                else {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }


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











    }
}
