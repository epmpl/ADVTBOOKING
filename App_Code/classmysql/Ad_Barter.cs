using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data ;
using MySql.Data .MySqlClient ;
namespace NewAdbooking.classmysql
{
    /// <summary>
    /// Summary description for Ad_Barter
    /// </summary>
    public class Ad_Barter : connection
    {
        public Ad_Barter()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet uombind(string compcode, string userid)
            {
         MySqlConnection objmysqlconnection;
         MySqlCommand objmysqlcommand;
         objmysqlconnection=GetConnection();
         MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter();
         DataSet objdataset=new DataSet();

         try
         {
         objmysqlconnection.Open();
         objmysqlcommand=GetCommand("uomadsize",ref objmysqlconnection);
         objmysqlcommand.CommandType=CommandType.StoredProcedure;

         objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
         objmysqlcommand.Parameters["compcode"].Value = compcode;

         objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
         objmysqlcommand.Parameters["advtype"].Value = userid;

         objmysqlDataAdapter.SelectCommand=objmysqlcommand;
         objmysqlDataAdapter.Fill(objdataset);
         return objdataset;
         }
         catch(Exception ex)
         {
             throw (ex);
         }
         finally
         {
             CloseConnection(ref objmysqlconnection);
         }
     }

        public DataSet getPubCenter(string compcode)
            {
                MySqlConnection objmysqlconnection;
                MySqlCommand objmysqlcommand;
                objmysqlconnection = GetConnection();
                MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
                DataSet objdataset = new DataSet();

                try
                {
                    objmysqlconnection.Open();
                    objmysqlcommand = GetCommand("publication_proc_publication_proc_p", ref objmysqlconnection);
                    objmysqlcommand.CommandType = CommandType.StoredProcedure;

                    objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["compcode"].Value = compcode;

                    objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                    objmysqlDataAdapter.Fill(objdataset);
                    return objdataset;

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

        public DataSet getQBC(string pubcode)
            {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection=GetConnection();
        MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter();
        DataSet objdataset=new DataSet();

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand=GetCommand("websp_QBC",ref objmysqlconnection);
            objmysqlcommand.CommandType=CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubcode"].Value = pubcode;

            objmysqlDataAdapter.SelectCommand=objmysqlcommand;
            objmysqlDataAdapter.Fill(objdataset);
            return objdataset;
        }
        catch(Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objmysqlconnection);
        }
    }

        public DataSet bindagency(string compcode, string agency)
            {
                MySqlConnection objmysqlconnection;
                MySqlCommand objmysqlcommand;
                objmysqlconnection = GetConnection();
                MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
                DataSet objdataset = new DataSet();

                try
                {
                    objmysqlconnection.Open();
                    objmysqlcommand = GetCommand("bindagencyforxls_bindagencyforxls_p", ref objmysqlconnection);
                    objmysqlcommand.CommandType = CommandType.StoredProcedure;

                    objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["compcode"].Value = compcode;

                    objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["agency"].Value = agency;


                    objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                    objmysqlDataAdapter.Fill(objdataset);
                    return objdataset;
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

        public DataSet savebarter(string compcode, string userid, string unitcode, string branchcode, string agencycode, string subagencycode, string bartercode, string barterdesc, string barterstdt, string barterendt, string ProdAmt, string barterAmt, string barterArea, string Remarks, string dateformat, string productdesc, string barteruom, string barterkilldate, string strbook, string client)
            {
                MySqlConnection objmysqlconnection;
                MySqlCommand objmysqlcommand;
                objmysqlconnection = GetConnection();
                MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
                DataSet objdataset = new DataSet();

                try
                {
                    objmysqlconnection.Open();
                    objmysqlcommand = GetCommand("Adbarter_save", ref objmysqlconnection);
                    objmysqlcommand.CommandType = CommandType.StoredProcedure;

                    objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["compcode"].Value = compcode;

                    objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["userid"].Value = userid;

                    objmysqlcommand.Parameters.Add("unitcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["unitcode"].Value = unitcode;

                    objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                    objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["agencode"].Value = agencycode;

                    objmysqlcommand.Parameters.Add("subagencode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["subagencode"].Value = subagencycode;

                    objmysqlcommand.Parameters.Add("bartercode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["bartercode"].Value = bartercode;

                    objmysqlcommand.Parameters.Add("barterdesc", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barterdesc"].Value = barterdesc;

                    objmysqlcommand.Parameters.Add("barterstdt", MySqlDbType.VarChar);
                    if (barterstdt == "" || barterstdt == null)
                    {
                        objmysqlcommand.Parameters["barterstdt"].Value = System.DBNull.Value;
                    }
                    else
                    {
                        if (dateformat == "dd/mm/yyyy")
                        {
                            string[] arr = barterstdt.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            barterstdt = mm + "/" + dd + "/" + yy;
                        }
                        else if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = barterstdt.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            barterstdt = mm + "/" + dd + "/" + yy;
                        }
                        objmysqlcommand.Parameters["barterstdt"].Value = Convert.ToDateTime(barterstdt).ToString("yyyy-MM-dd");
                    }



                    objmysqlcommand.Parameters.Add("barterendt", MySqlDbType.VarChar);
                    if (barterendt == "" || barterendt == null)
                    {
                        objmysqlcommand.Parameters["barterendt"].Value = System.DBNull.Value;
                    }
                    else
                    {
                        if (dateformat == "dd/mm/yyyy")
                        {
                            string[] arr = barterendt.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            barterendt = mm + "/" + dd + "/" + yy;
                        }
                        else if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = barterendt.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            barterendt = mm + "/" + dd + "/" + yy;
                        }
                        objmysqlcommand.Parameters["barterendt"].Value = Convert.ToDateTime(barterendt).ToString("yyyy-MM-dd");
                    }


                    objmysqlcommand.Parameters.Add("barterkilldate", MySqlDbType.VarChar);
                    if (barterkilldate == "" || barterkilldate == null)
                    {
                        objmysqlcommand.Parameters["barterkilldate"].Value = System.DBNull.Value;
                    }
                    else
                    {
                        if (dateformat == "dd/mm/yyyy")
                        {
                            string[] arr = barterkilldate.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            barterkilldate = mm + "/" + dd + "/" + yy;
                        }
                        else if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = barterkilldate.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            barterkilldate = mm + "/" + dd + "/" + yy;
                        }
                        objmysqlcommand.Parameters["barterkilldate"].Value = Convert.ToDateTime(barterkilldate).ToString("yyyy-MM-dd");
                    }


                    objmysqlcommand.Parameters.Add("prodamt", MySqlDbType.Double);
                    objmysqlcommand.Parameters["prodamt"].Value = ProdAmt;

                    objmysqlcommand.Parameters.Add("barteramt", MySqlDbType.Double);
                    objmysqlcommand.Parameters["barteramt"].Value = barterAmt;

                    objmysqlcommand.Parameters.Add("barterarea", MySqlDbType.Double);
                    objmysqlcommand.Parameters["barterarea"].Value = barterArea;

                    objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["remarks"].Value = Remarks;

                    objmysqlcommand.Parameters.Add("productdesc", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["productdesc"].Value = productdesc;

                    objmysqlcommand.Parameters.Add("barteruom", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barteruom"].Value = barteruom;

                    objmysqlcommand.Parameters.Add("strbook", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["strbook"].Value = strbook;

                    objmysqlcommand.Parameters.Add("client1", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["client1"].Value = client;


                    objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                    objmysqlDataAdapter.Fill(objdataset);
                    return objdataset;
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

        public DataSet updatebarter(string compcode, string userid, string unitcode, string branchcode, string agencycode, string subagencycode, string bartercode, string barterdesc, string barterstdt, string barterendt, string ProdAmt, string barterAmt, string barterArea, string Remarks, string dateformat, string productdesc, string barteruom, string barterkilldate, string strbook, string client)
            {
                MySqlConnection objmysqlconnection;
                MySqlCommand objmysqlcommand;
                objmysqlconnection = GetConnection();
                MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
                DataSet objdataset = new DataSet();

                try
                {
                    objmysqlconnection.Open();
                    objmysqlcommand = GetCommand("Adbarter_modify", ref objmysqlconnection);
                    objmysqlcommand.CommandType = CommandType.StoredProcedure;

                    objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["compcode"].Value = compcode;

                    objmysqlcommand.Parameters.Add("unitcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["unitcode"].Value = unitcode;

                    objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["branchcode"].Value = branchcode;
                    
                    objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["agencode"].Value = agencycode;

                    objmysqlcommand.Parameters.Add("subagencode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["subagencode"].Value = subagencycode;

                    objmysqlcommand.Parameters.Add("bartercode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["bartercode"].Value = bartercode;

                    objmysqlcommand.Parameters.Add("barterdesc", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barterdesc"].Value = barterdesc;

                    objmysqlcommand.Parameters.Add("barterstdt", MySqlDbType.VarChar);
                    if (barterstdt == "" || barterstdt == null)
                    {
                        objmysqlcommand.Parameters["barterstdt"].Value = System.DBNull.Value;
                    }
                    else
                    {
                        if (dateformat == "dd/mm/yyyy")
                        {
                            string[] arr = barterstdt.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            barterstdt = mm + "/" + dd + "/" + yy;
                        }
                        else if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = barterstdt.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            barterstdt = mm + "/" + dd + "/" + yy;
                        }
                        objmysqlcommand.Parameters["barterstdt"].Value = Convert.ToDateTime(barterstdt).ToString("yyyy-MM-dd");
                    }

                    objmysqlcommand.Parameters.Add("barterendt", MySqlDbType.VarChar);
                    if (barterendt == "" || barterendt == null)
                    {
                        objmysqlcommand.Parameters["barterendt"].Value = System.DBNull.Value;
                    }
                    else
                    {
                        if (dateformat == "dd/mm/yyyy")
                        {
                            string[] arr = barterendt.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            barterendt = mm + "/" + dd + "/" + yy;
                        }
                        else if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = barterendt.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            barterendt = mm + "/" + dd + "/" + yy;
                        }
                        objmysqlcommand.Parameters["barterendt"].Value = Convert.ToDateTime(barterendt).ToString("yyyy-MM-dd");
                    }

                    objmysqlcommand.Parameters.Add("prodamt", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["prodamt"].Value = ProdAmt;

                    objmysqlcommand.Parameters.Add("barteramt", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barteramt"].Value = barterAmt;

                    objmysqlcommand.Parameters.Add("barterarea", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barterarea"].Value = barterArea;


                    objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["userid"].Value = userid;

                    objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["remarks"].Value = Remarks;

                    objmysqlcommand.Parameters.Add("productdesc", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["productdesc"].Value = productdesc;

                    objmysqlcommand.Parameters.Add("barteruom", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barteruom"].Value = barteruom;

                    objmysqlcommand.Parameters.Add("barterkilldate", MySqlDbType.VarChar);
                    if (barterkilldate == "" || barterkilldate == null)
                    {
                        objmysqlcommand.Parameters["barterkilldate"].Value = System.DBNull.Value;
                    }
                    else
                    {
                        if (dateformat == "dd/mm/yyyy")
                        {
                            string[] arr = barterkilldate.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            barterkilldate = mm + "/" + dd + "/" + yy;
                        }
                        else if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = barterkilldate.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            barterkilldate = mm + "/" + dd + "/" + yy;
                        }
                        objmysqlcommand.Parameters["barterkilldate"].Value = Convert.ToDateTime(barterkilldate).ToString("yyyy-MM-dd");
                    }

                    objmysqlcommand.Parameters.Add("strbook", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["strbook"].Value = strbook;

                    objmysqlcommand.Parameters.Add("client1", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["client1"].Value = client;


                    objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                    objmysqlDataAdapter.Fill(objdataset);
                    return objdataset;
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
            
        public DataSet checkdupbarter(string compcode, string unitcode, string branchcode, string bartercode, string barterdesc, string agencycode, string subagencycode)
            {
                MySqlConnection objmysqlconnection;
                MySqlCommand objmysqlcommand;
                objmysqlconnection = GetConnection();
                MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
                DataSet objdataset = new DataSet();

                try
                {
                    objmysqlconnection.Open();
                    objmysqlcommand = GetCommand("Adbarter_checkduplicacy", ref objmysqlconnection);
                    objmysqlcommand.CommandType = CommandType.StoredProcedure;

                    objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["compcode"].Value = compcode;

                    objmysqlcommand.Parameters.Add("bartercode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["bartercode"].Value = bartercode;

                    objmysqlcommand.Parameters.Add("unitcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["unitcode"].Value = unitcode;

                    objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                    objmysqlcommand.Parameters.Add("barterdesc", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barterdesc"].Value = barterdesc;

                    objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                    objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["agencysubcode"].Value = subagencycode;

                    objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                    objmysqlDataAdapter.Fill(objdataset);
                    return objdataset;

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
            
        public DataSet barterexecute(string compcode, string unitcode, string branchcode, string bartercode, string barterdesc, string barterstdt, string barterendt, string barterkilldate, string productdesc, string agencycode, string subagencycode, string strbook, string client)
            {
                MySqlConnection objmysqlconnection;
                MySqlCommand objmysqlcommand;
                objmysqlconnection = GetConnection();
                MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
                DataSet objdataset = new DataSet();

                try
                {
                    objmysqlconnection.Open();
                    objmysqlcommand = GetCommand("AdBarter_Exe", ref objmysqlconnection);
                    objmysqlcommand.CommandType = CommandType.StoredProcedure;

                    objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["compcode"].Value = compcode;

                    objmysqlcommand.Parameters.Add("unitcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["unitcode"].Value = unitcode;

                    objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                    objmysqlcommand.Parameters.Add("bartercode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["bartercode"].Value = bartercode;
                    
                    objmysqlcommand.Parameters.Add("barterdesc", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barterdesc"].Value = barterdesc;

                    objmysqlcommand.Parameters.Add("barterstdt", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barterstdt"].Value = barterstdt;

                    objmysqlcommand.Parameters.Add("barterendt", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barterendt"].Value = barterendt;

                    objmysqlcommand.Parameters.Add("barterkilldate", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["barterkilldate"].Value = barterkilldate;

                    objmysqlcommand.Parameters.Add("productdesc", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["productdesc"].Value = productdesc;

                    objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                    objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;

                    objmysqlcommand.Parameters.Add("strbook", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["strbook"].Value = strbook;

                    objmysqlcommand.Parameters.Add("client1", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["client1"].Value = client;


                    objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                    objmysqlDataAdapter.Fill(objdataset);
                    return objdataset;
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

        public void barterdelete(string bartercode, string compcode)
            {
                MySqlConnection objmysqlconnection;
                MySqlCommand objmysqlcommand;
                objmysqlconnection = GetConnection();
                MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
                DataSet objdataset = new DataSet();

                try
                {
                    objmysqlconnection.Open();
                    objmysqlcommand = GetCommand("Adbarter_delete", ref objmysqlconnection);
                    objmysqlcommand.CommandType = CommandType.StoredProcedure;

                    objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["compcode"].Value = compcode;

                    objmysqlcommand.Parameters.Add("bartercode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["bartercode"].Value = bartercode;


                    objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                    objmysqlDataAdapter.Fill(objdataset);

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
        
        public DataSet barterautocode(string str, string compcode, string unitcode, string branchcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("autoabartercode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("unitcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["unitcode"].Value = unitcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;
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

        public DataSet clientxls(string compcol, string cli)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindclientforxls_bindclientforxls_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcol;

                objmysqlcommand.Parameters.Add("CLIENT", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CLIENT"].Value = cli;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;
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

        public DataSet barter_report(string from_date, string to_date , string compcode, string hdnclient, string hdnagency, string dpregion, string dpproduct, string drpbooktype, string dateformat, string hiddencioid, string hiddenascdesc, string dppubcent, string userid, string access)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("barter_report_bill_report_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agname"].Value = hdnagency;
                
                objmysqlcommand.Parameters.Add("booktype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["booktype"].Value = drpbooktype;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = from_date;

                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = to_date;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pub_cent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_cent"].Value = dppubcent;

                objmysqlcommand.Parameters.Add("client1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["client1"].Value = hdnclient;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = null;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;

                objmysqlcommand.Parameters.Add("Region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region"].Value = dpregion;

                objmysqlcommand.Parameters.Add("product", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["product"].Value = dpproduct;

                objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agency"].Value = hdnagency;

                objmysqlcommand.Parameters.Add("descid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["descid"].Value = hiddencioid;

                objmysqlcommand.Parameters.Add("ascdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascdesc"].Value = hiddenascdesc;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("chk_access", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chk_access"].Value = access;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;
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

        public DataSet pub_centbind(string compcode, string userid, string chkaccess)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("PUBCENT_PROC", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = compcode;

                objmysqlcommand.Parameters.Add("PUSERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PUSERID"].Value = userid;

                objmysqlcommand.Parameters.Add("CHK_ACCESS", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CHK_ACCESS"].Value = chkaccess;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;
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
