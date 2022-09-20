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
/// Summary description for AdvPagePositionMaster
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class AdvPagePositionMaster : connection
    {
        public AdvPagePositionMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet addadvtype()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("addadvtype", ref con);
                com.CommandType = CommandType.StoredProcedure;

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
        public DataSet addpublication()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpublicationpage", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

          
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


        public DataSet addadvcat(string adtypcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("addadvcat", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@adtypcode", SqlDbType.VarChar);
                com.Parameters["@adtypcode"].Value = adtypcode;

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
        public DataSet addeditquery(string publication)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("addeditionadv", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@publication", SqlDbType.VarChar);
                com.Parameters["@publication"].Value = publication;


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


        public DataSet addsuppquery(string edition,string publication)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("addsuppadv", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@edition", SqlDbType.VarChar);
                com.Parameters["@edition"].Value = edition;

                com.Parameters.Add("@publication", SqlDbType.VarChar);
                com.Parameters["@publication"].Value = publication;



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

        public DataSet addadvsizedesc()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("addadvsizedesc", ref con);
                com.CommandType = CommandType.StoredProcedure;

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
        public DataSet checkmulti(string compcode, string userid, string premcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkmultipremselect", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;




                objSqlCommand.Parameters.Add("@premcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premcode"].Value = premcode;



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

        public DataSet addcolor()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("addcolor", ref con);
                com.CommandType = CommandType.StoredProcedure;

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
        public DataSet addrategrp()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("addrategrp", ref con);
                com.CommandType = CommandType.StoredProcedure;

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
        public DataSet addspecialposition()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("addspecialposition", ref con);
                com.CommandType = CommandType.StoredProcedure;

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

        public DataSet listboxbind(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adadvcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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



        public DataSet listboxmultibind(string compcode, string userid, string premcode, string abc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertmultiadcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;




                objSqlCommand.Parameters.Add("@premcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premcode"].Value = premcode;

                objSqlCommand.Parameters.Add("@abc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@abc"].Value = abc;

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

        public DataSet listboxmultiupdate(string compcode, string userid, string premcode, string abc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatemultiadcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;




                objSqlCommand.Parameters.Add("@premcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premcode"].Value = premcode;

                objSqlCommand.Parameters.Add("@abc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@abc"].Value = abc;

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

        //***************************************************************************************//
        //**********************************Save Function****************************************//
        //***************************************************************************************//
        public DataSet advpagesave1(string companycode, string premiumcode,string  premiumname,string advtype, string advcategory, string publication, string edition,string supplement, string color, string advsizedesc, string pageno, string rategrp, string position, string premium, string txtpremium, string validtill, string validfrm, string UserId,string solus, string pageheading)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("AdvPageposition_Save", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@premiumcode", SqlDbType.VarChar);
                com.Parameters["@premiumcode"].Value = premiumcode;

                com.Parameters.Add("@premiumname", SqlDbType.VarChar);
                com.Parameters["@premiumname"].Value = premiumname;


                

                com.Parameters.Add("@advtype", SqlDbType.VarChar);
                com.Parameters["@advtype"].Value = advtype;

                com.Parameters.Add("@advcategory", SqlDbType.VarChar);
                com.Parameters["@advcategory"].Value = advcategory;

                com.Parameters.Add("@publication", SqlDbType.VarChar);
                com.Parameters["@publication"].Value = publication;

                com.Parameters.Add("@edition", SqlDbType.VarChar);
                com.Parameters["@edition"].Value = edition;

                com.Parameters.Add("@supplement", SqlDbType.VarChar);
                com.Parameters["@supplement"].Value = supplement;


                com.Parameters.Add("@color", SqlDbType.VarChar);
                com.Parameters["@color"].Value = color;

                com.Parameters.Add("@advsizedesc", SqlDbType.VarChar);
                com.Parameters["@advsizedesc"].Value = advsizedesc;

                com.Parameters.Add("@pageno", SqlDbType.VarChar);
                com.Parameters["@pageno"].Value = pageno;

                com.Parameters.Add("@rategrp", SqlDbType.VarChar);
                com.Parameters["@rategrp"].Value = rategrp;

                com.Parameters.Add("@position", SqlDbType.VarChar);
                com.Parameters["@position"].Value = position;

                com.Parameters.Add("@premium", SqlDbType.VarChar);
                com.Parameters["@premium"].Value = premium;

                com.Parameters.Add("@txtpremium", SqlDbType.VarChar);
                com.Parameters["@txtpremium"].Value = txtpremium;


                com.Parameters.Add("@validtill", SqlDbType.DateTime);
                if (validtill == "" || validtill == null || validtill == "undefined/undefined/")
                {
                    com.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@validtill"].Value = Convert.ToDateTime(validtill);
                }

                com.Parameters.Add("@validfrm", SqlDbType.DateTime);
                if (validfrm == "" || validfrm == null || validfrm == "undefined/undefined/")
                {
                    com.Parameters["@validfrm"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@validfrm"].Value = Convert.ToDateTime(validfrm);
                }
             
                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

                com.Parameters.Add("@solus", SqlDbType.VarChar);
                com.Parameters["@solus"].Value = solus;

                com.Parameters.Add("@pageheading", SqlDbType.VarChar);
                com.Parameters["@pageheading"].Value = pageheading;


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

        //*****************************************************************************************//
        //**********************************Modify Function****************************************//
        //*****************************************************************************************//
        public DataSet advpagemodify1(string companycode,string premiumcode,string  premiumname,string advtype, string advcategory, string publication, string edition,string supplement, string color, string advsizedesc, string pageno, string rategrp, string position, string premium,string txtpremium, string validtill, string validfrm, string UserId,string solus, string pageheading)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("AdvPageposition_Modify", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@premiumcode", SqlDbType.VarChar);
                com.Parameters["@premiumcode"].Value = premiumcode;

                com.Parameters.Add("@premiumname", SqlDbType.VarChar);
                com.Parameters["@premiumname"].Value = premiumname;




                com.Parameters.Add("@advtype", SqlDbType.VarChar);
                com.Parameters["@advtype"].Value = advtype;

                com.Parameters.Add("@advcategory", SqlDbType.VarChar);
                com.Parameters["@advcategory"].Value = advcategory;

                com.Parameters.Add("@publication", SqlDbType.VarChar);
                com.Parameters["@publication"].Value = publication;

                com.Parameters.Add("@edition", SqlDbType.VarChar);
                com.Parameters["@edition"].Value = edition;

                com.Parameters.Add("@supplement", SqlDbType.VarChar);
                com.Parameters["@supplement"].Value = supplement;

              

                com.Parameters.Add("@color", SqlDbType.VarChar);
                com.Parameters["@color"].Value = color;

                com.Parameters.Add("@advsizedesc", SqlDbType.VarChar);
                com.Parameters["@advsizedesc"].Value = advsizedesc;

                com.Parameters.Add("@pageno", SqlDbType.Int);
                com.Parameters["@pageno"].Value = pageno;

                com.Parameters.Add("@rategrp", SqlDbType.VarChar);
                com.Parameters["@rategrp"].Value = rategrp;

                com.Parameters.Add("@position", SqlDbType.VarChar);
                com.Parameters["@position"].Value = position;

                com.Parameters.Add("@premium", SqlDbType.VarChar);
                com.Parameters["@premium"].Value = premium;

                com.Parameters.Add("@txtpremium", SqlDbType.VarChar);
                com.Parameters["@txtpremium"].Value = txtpremium;


                com.Parameters.Add("@validtill", SqlDbType.DateTime);

                if (validtill == "" || validtill == null || validtill == "undefined/undefined/")
                {
                    com.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@validtill"].Value = Convert.ToDateTime(validtill);
                }


              


                com.Parameters.Add("@validfrm", SqlDbType.DateTime);

                if (validfrm == "" || validfrm == null || validfrm == "undefined/undefined")
                {
                    com.Parameters["@validfrm"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@validfrm"].Value = Convert.ToDateTime(validfrm);
                }

               // com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = UserId;

                com.Parameters.Add("@solus", SqlDbType.VarChar);
                com.Parameters["@solus"].Value = solus;//pageheading

                com.Parameters.Add("@pageheading", SqlDbType.VarChar);
                com.Parameters["@pageheading"].Value = pageheading;


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
        public DataSet chkadvpagecode(string companycode, string UserId, string premiumcode, string adtype, string premiumname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Advpagecheck", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@premiumcode", SqlDbType.VarChar);
                com.Parameters["@premiumcode"].Value = premiumcode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                com.Parameters["@adtype"].Value = adtype;

                com.Parameters.Add("@premiumname", SqlDbType.VarChar);
                com.Parameters["@premiumname"].Value = premiumname;
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

        //*****************************************************************************************//
        //**********************************Delete Function****************************************//
        //*****************************************************************************************//
        public DataSet advpagedelete1(string companycode, string premiumcode, string UserId)// string advtype, string advcategory, string publication, string edition, string color, string advsizedesc, string pageno, string rategrp, string position, string premium,string txtpremium,string UserId)//,string txtfrom,string  txtto)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("AdvPageposition_Delete", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@premiumcode", SqlDbType.VarChar);
                com.Parameters["@premiumcode"].Value = premiumcode;

               //com.Parameters.Add("@userid", SqlDbType.VarChar);
               // com.Parameters["@userid"].Value = UserId;
                //com.Parameters.Add("@advtype", SqlDbType.VarChar);
                //com.Parameters["@advtype"].Value = advtype;

                //com.Parameters.Add("@advcategory", SqlDbType.VarChar);
                //com.Parameters["@advcategory"].Value = advcategory;

                //com.Parameters.Add("@publication", SqlDbType.VarChar);
                //com.Parameters["@publication"].Value = publication;

                //com.Parameters.Add("@edition", SqlDbType.VarChar);
                //com.Parameters["@edition"].Value = edition;

                //com.Parameters.Add("@color", SqlDbType.VarChar);
                //com.Parameters["@color"].Value = color;

                //com.Parameters.Add("@advsizedesc", SqlDbType.VarChar);
                //com.Parameters["@advsizedesc"].Value = advsizedesc;

                //com.Parameters.Add("@pageno", SqlDbType.Int);
                //com.Parameters["@pageno"].Value = pageno;

                //com.Parameters.Add("@rategrp", SqlDbType.VarChar);
                //com.Parameters["@rategrp"].Value = rategrp;

                //com.Parameters.Add("@position", SqlDbType.VarChar);
                //com.Parameters["@position"].Value = position;

                //com.Parameters.Add("@premium", SqlDbType.VarChar);
                //com.Parameters["@premium"].Value = premium;

                //com.Parameters.Add("@txtpremium", SqlDbType.VarChar);
                //com.Parameters["@txtpremium"].Value = txtpremium;

                //com.Parameters.Add("@txtfrom", SqlDbType.VarChar);
                //com.Parameters["@txtfrom"].Value = txtfrom;

                //com.Parameters.Add("@txtto", SqlDbType.VarChar);
                //com.Parameters["@txtto"].Value = txtto;

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

        //public DataSet advpagemultidelete(string companycode, string premiumcode, string UserId)
        //{
        //    SqlConnection con;
        //    SqlCommand com;
        //    con = GetConnection();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        con.Open();
        //        com = GetCommand("deletemultiadcategory", ref con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        com.Parameters["@compcode"].Value = companycode;
        //        com.Parameters.Add("@premiumcode", SqlDbType.VarChar);
        //        com.Parameters["@premiumcode"].Value = premiumcode;
        //        com.Parameters.Add("@userid", SqlDbType.VarChar);
        //        com.Parameters["@userid"].Value = UserId;
        //        da.SelectCommand = com;
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref con);
        //    }
        //}

        //******************************************************************************************//
        //**********************************Execute Function****************************************//
        //******************************************************************************************//
        public DataSet advpageexecute1(string companycode, string premiumcode,string premiumname, string advtype, string advcategory, string publication, string edition,string supplement, string advsizedesc, string UserId, string color, string pageno, string rategrp, string position, string premium)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("AdvPageposition_Execute", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@premiumcode", SqlDbType.VarChar);
                com.Parameters["@premiumcode"].Value = premiumcode;

                com.Parameters.Add("@premiumname", SqlDbType.VarChar);
                com.Parameters["@premiumname"].Value = premiumname;

               

                com.Parameters.Add("@advtype", SqlDbType.VarChar);
                com.Parameters["@advtype"].Value = advtype;
                
                com.Parameters.Add("@advcategory", SqlDbType.VarChar);
                com.Parameters["@advcategory"].Value = advcategory;

                com.Parameters.Add("@publication", SqlDbType.VarChar);
                com.Parameters["@publication"].Value = publication;

                com.Parameters.Add("@edition", SqlDbType.VarChar);
                com.Parameters["@edition"].Value = edition;

                com.Parameters.Add("@supplement", SqlDbType.VarChar);
                com.Parameters["@supplement"].Value = supplement;
              
               
                com.Parameters.Add("@advsizedesc", SqlDbType.VarChar);
                com.Parameters["@advsizedesc"].Value = advsizedesc;
               
                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = UserId;

                com.Parameters.Add("@color", SqlDbType.VarChar);
                com.Parameters["@color"].Value = color;

                com.Parameters.Add("@pageno", SqlDbType.VarChar);
                //if (pageno == "")
                //{
                //    com.Parameters["@pageno"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    //com.Parameters["@pageno"].Value = Convert.ToInt32(pageno);
                //}

                com.Parameters["@pageno"].Value = pageno;


                com.Parameters.Add("@rategrp", SqlDbType.VarChar);
                com.Parameters["@rategrp"].Value = rategrp;

                com.Parameters.Add("@position", SqlDbType.VarChar);
                com.Parameters["@position"].Value = position;

                com.Parameters.Add("@premium", SqlDbType.VarChar);
                com.Parameters["@premium"].Value = premium;

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

        //**************************************Function For*****************************************//
        //*******************************See The First Record****************************************//
        //*******************************************************************************************//
        public DataSet advpagefirst(string companycode, string UserId)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Advpagepositionfpnl", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

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

        //**************************************Function For****************************************//
        //*******************************See The Last Record****************************************//
        //******************************************************************************************//
        public DataSet advpagelast(string companycode, string UserId)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Advpagepositionfpnl", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

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

        //**************************************Function For********************************************//
        //*******************************See The Previous Record****************************************//
        //**********************************************************************************************//
        public DataSet advpageprevious(string companycode, string UserId)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Advpagepositionfpnl", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

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

        //*************************************Function For*****************************************//
        //*******************************See The Next Record****************************************//
        //******************************************************************************************//
        public DataSet advpagenext(string companycode, string UserId)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Advpagepositionfpnl", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

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

        //**************************************Function For*****************************************//
        //*******************************Save The Premium Day****************************************//
        //*******************************************************************************************//
        public DataSet selectpremiumdaysave(string compcode, string premcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectpremiumdaysave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@premcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premcode"].Value = premcode;

                objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sun"].Value = sun;

                objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mon"].Value = mon;

                objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tue"].Value = tue;

                objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@wed"].Value = wed;

                objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@thu"].Value = thu;

                objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fri"].Value = fri;

                objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sat"].Value = sat;

                objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
                objSqlCommand.Parameters["@all"].Value = all;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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

//********************Select Days for Premium According to Edition Code**********************************
//***********************************************************************************************
        public DataSet checkeditcode(string compcode, string editcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkpremiumeditcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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



        public DataSet checksuppcode(string compcode, string suppcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkpremiumsuppcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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




        //****************************************************************************************************
        //****************************************************************************************************
       // ********************************************************************************************
        public DataSet checkpremcode(string compcode, string premcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkpremiumcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@premcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premcode"].Value = premcode;

              //  objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
               // objSqlCommand.Parameters["@userid"].Value = userid;

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



        //public DataSet selectpremiumdaydelete(string companycode, string premiumcode, string UserId)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("deletepremiumappl", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = companycode;

        //        objSqlCommand.Parameters.Add("@premcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@premcode"].Value = premiumcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = UserId;

        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}




        //****************************************Function For*****************************************//
        //***********************************Modify The Premium Day************************************//
        //*********************************************************************************************//
        public DataSet selectpremiumdaymodify(string compcode, string premcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectpremiumdaymodify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@premcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premcode"].Value = premcode;

                objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sun"].Value = sun;

                objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mon"].Value = mon;


                objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tue"].Value = tue;

                objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@wed"].Value = wed;

                objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@thu"].Value = thu;


                objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fri"].Value = fri;

                objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sat"].Value = sat;

                objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
                objSqlCommand.Parameters["@all"].Value = all;

               // objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
               // objSqlCommand.Parameters["@userid"].Value = userid;

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

       
        //********************************************************************************************//
        //**********************************Auto Generate Code****************************************//
        //********************************************************************************************//
        public DataSet autopagecode(string premname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("autopremiumcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = premname;

              
                objSqlCommand.Parameters.Add("@premname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premname"].Value = premname;

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
