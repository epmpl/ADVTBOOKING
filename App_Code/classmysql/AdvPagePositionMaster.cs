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
    /// Summary description for AdvPagePositionMaster
    /// </summary>
    public class AdvPagePositionMaster:connection 
    {
        public AdvPagePositionMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet addadvtype()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {

                
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADDADVTYPE_ADDADVTYPE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
              
            }
           catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        public DataSet addpublication()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BINDPUBLICATIONPAGE_BINDPUBLICATIONPAGE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

                
               
            }
         catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        public DataSet addadvcat(string adtypcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADDADVCAT", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("adtypcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtypcode"].Value = adtypcode;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
              
            }
           catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        public DataSet addeditquery(string publication)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {

                
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("addeditionadv", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = publication;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
              
            }
         catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        public DataSet addsuppquery(string edition, string publication)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {


                  objmysqlconnection.Open();
                objmysqlcommand = GetCommand("addsuppadv", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;
                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = publication;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
          
            }
        catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet addadvsizedesc()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {

                   objmysqlconnection.Open();
                   objmysqlcommand = GetCommand("ADDADVSIZEDESC_ADDADVSIZEDESC_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
              
            }
         catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        public DataSet checkmulti(string compcode, string userid, string premcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {                
                  objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkmultipremselect", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
               

            }
          catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet addcolor()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {

                   objmysqlconnection.Open();
                   objmysqlcommand = GetCommand("ADDCOLOR_ADDCOLOR_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
              
            }
          catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        public DataSet addrategrp()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {                

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADDRATEGRP_ADDRATEGRP_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
              
            }
             catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        public DataSet addspecialposition()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {

               
                  objmysqlconnection.Open();
                  objmysqlcommand = GetCommand("ADDSPECIALPOSITION_ADDSPECIALPOSITION_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            
            }
           catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet listboxbind(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {


                  objmysqlconnection.Open();
                  objmysqlcommand = GetCommand("ADADVCATEGORY_ADADVCATEGORY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
             
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
           

            }
         catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }



        public DataSet listboxmultibind(string compcode, string userid, string premcode, string abc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertmultiadcategory", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;




                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;

                objmysqlcommand.Parameters.Add("abc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["abc"].Value = abc;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet listboxmultiupdate(string compcode, string userid, string premcode, string abc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatemultiadcategory", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;




                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;

                objmysqlcommand.Parameters.Add("abc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["abc"].Value = abc;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        //***************************************************************************************//
        //**********************************Save Function****************************************//
        //***************************************************************************************//
        public DataSet advpagesave1(string companycode, string premiumcode, string premiumname, string advtype, string advcategory, string publication, string edition, string supplement, string color, string advsizedesc, string pageno, string rategrp, string position, string premium, string txtpremium, string validtill, string validfrm, string UserId, string solus, string pageheadinging)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AdvPageposition_Save", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("premiumcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumcode"].Value = premiumcode;

                objmysqlcommand.Parameters.Add("premiumname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumname"].Value = premiumname;




                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                objmysqlcommand.Parameters.Add("advcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advcategory"].Value = advcategory;

                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = publication;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("supplement", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supplement"].Value = supplement;


                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("advsizedesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advsizedesc"].Value = advsizedesc;

                objmysqlcommand.Parameters.Add("pageno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pageno"].Value = pageno;

                objmysqlcommand.Parameters.Add("rategrp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategrp"].Value = rategrp;

                objmysqlcommand.Parameters.Add("position1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["position1"].Value = position;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("txtpremium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtpremium"].Value = txtpremium;


                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);
                if (validtill == "" || validtill == null || validtill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = Convert.ToDateTime(validtill);
                }

                objmysqlcommand.Parameters.Add("validfrm", MySqlDbType.DateTime);
                if (validfrm == "" || validfrm == null || validfrm == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["validfrm"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfrm"].Value = Convert.ToDateTime(validfrm);
                }

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlcommand.Parameters.Add("solus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["solus"].Value = solus;

                objmysqlcommand.Parameters.Add("pageheading1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pageheading1"].Value = pageheadinging;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
          catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        //*****************************************************************************************//
        //**********************************Modify Function****************************************//
        //*****************************************************************************************//
        public DataSet advpagemodify1(string companycode, string premiumcode, string premiumname, string advtype, string advcategory, string publication, string edition, string supplement, string color, string advsizedesc, string pageno, string rategrp, string position, string premium, string txtpremium, string validtill, string validfrm, string UserId, string solus, string pageheadinging)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AdvPageposition_Modify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("premiumcode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumcode1"].Value = premiumcode;

                objmysqlcommand.Parameters.Add("premiumname1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumname1"].Value = premiumname;




                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                objmysqlcommand.Parameters.Add("advcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advcategory"].Value = advcategory;

                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = publication;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("supplement", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supplement"].Value = supplement;



                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("advsizedesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advsizedesc"].Value = advsizedesc;

                objmysqlcommand.Parameters.Add("pageno", MySqlDbType.Int32);
                objmysqlcommand.Parameters["pageno"].Value = pageno;

                objmysqlcommand.Parameters.Add("rategrp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategrp"].Value = rategrp;

                objmysqlcommand.Parameters.Add("position1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["position1"].Value = position;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("txtpremium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtpremium"].Value = txtpremium;


                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);

                if (validtill == "" || validtill == null || validtill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = Convert.ToDateTime(validtill);
                }





                objmysqlcommand.Parameters.Add("validfrm", MySqlDbType.DateTime);

                if (validfrm == "" || validfrm == null || validfrm == "undefined/undefined")
                {
                    objmysqlcommand.Parameters["validfrm"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfrm"].Value = Convert.ToDateTime(validfrm);
                }

                // objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlcommand.Parameters.Add("solus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["solus"].Value = solus;

                objmysqlcommand.Parameters.Add("pageheading1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pageheading1"].Value = pageheadinging;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
        catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        public DataSet chkadvpagecode(string companycode, string UserId, string premiumcode, string adtype, string premiumname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Advpagecheck", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("premiumcode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumcode1"].Value = premiumcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("premiumname1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumname1"].Value = premiumname;




                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

         catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }

        }

        //*****************************************************************************************//
        //**********************************Delete Function****************************************//
        //*****************************************************************************************//
        public DataSet advpagedelete1(string companycode, string premiumcode, string UserId)// string advtype, string advcategory, string publication, string edition, string color, string advsizedesc, string pageno, string rategrp, string position, string premium,string txtpremium,string UserId)//,string txtfrom,string  txtto)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AdvPageposition_Delete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("premiumcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumcode"].Value = premiumcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                // objmysqlcommand.Parameters["userid"].Value = UserId;
                //objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["advtype"].Value = advtype;

                //objmysqlcommand.Parameters.Add("advcategory", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["advcategory"].Value = advcategory;

                //objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["publication"].Value = publication;

                //objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["edition"].Value = edition;

                //objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["color"].Value = color;

                //objmysqlcommand.Parameters.Add("advsizedesc", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["advsizedesc"].Value = advsizedesc;

                //objmysqlcommand.Parameters.Add("pageno", MySqlDbType.Int);
                //objmysqlcommand.Parameters["pageno"].Value = pageno;

                //objmysqlcommand.Parameters.Add("rategrp", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["rategrp"].Value = rategrp;

                //objmysqlcommand.Parameters.Add("position", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["position"].Value = position;

                //objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["premium"].Value = premium;

                //objmysqlcommand.Parameters.Add("txtpremium", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["txtpremium"].Value = txtpremium;

                //objmysqlcommand.Parameters.Add("txtfrom", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["txtfrom"].Value = txtfrom;

                //objmysqlcommand.Parameters.Add("txtto", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["txtto"].Value = txtto;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
           catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

       
        //******************************************************************************************//
        //**********************************Execute Function****************************************//
        //******************************************************************************************//
        public DataSet advpageexecute1(string companycode, string premiumcode, string premiumname, string advtype, string advcategory, string publication, string edition, string supplement, string advsizedesc, string UserId, string color, string pageno, string rategrp, string position, string premium)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AdvPageposition_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("premiumcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumcode"].Value = premiumcode;

                objmysqlcommand.Parameters.Add("premiumname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumname"].Value = premiumname;



                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                objmysqlcommand.Parameters.Add("advcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advcategory"].Value = advcategory;

                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = publication;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("supplement", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["supplement"].Value = supplement;


                objmysqlcommand.Parameters.Add("advsizedesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advsizedesc"].Value = advsizedesc;

             

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("pageno", MySqlDbType.VarChar);
               

                objmysqlcommand.Parameters["pageno"].Value = pageno;


                objmysqlcommand.Parameters.Add("rategrp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategrp"].Value = rategrp;

                objmysqlcommand.Parameters.Add("position1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["position1"].Value = position;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
           catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        //**************************************Function For*****************************************//
        //*******************************See The First Record****************************************//
        //*******************************************************************************************//
        public DataSet advpagefirst(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Advpagepositionfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        //**************************************Function For****************************************//
        //*******************************See The Last Record****************************************//
        //******************************************************************************************//
        public DataSet advpagelast(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Advpagepositionfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        //**************************************Function For********************************************//
        //*******************************See The Previous Record****************************************//
        //**********************************************************************************************//
        public DataSet advpageprevious(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Advpagepositionfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
           catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }

        }

        //*************************************Function For*****************************************//
        //*******************************See The Next Record****************************************//
        //******************************************************************************************//
        public DataSet advpagenext(string companycode, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Advpagepositionfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
           catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }

        }

        //**************************************Function For*****************************************//
        //*******************************Save The Premium Day****************************************//
        //*******************************************************************************************//
        public DataSet selectpremiumdaysave(string compcode, string premcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("selectpremiumdaysave", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;

                objmysqlcommand.Parameters.Add("sun", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sun"].Value = sun;

                objmysqlcommand.Parameters.Add("mon", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mon"].Value = mon;

                objmysqlcommand.Parameters.Add("tue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tue"].Value = tue;

                objmysqlcommand.Parameters.Add("wed", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["wed"].Value = wed;

                objmysqlcommand.Parameters.Add("thu", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["thu"].Value = thu;

                objmysqlcommand.Parameters.Add("fri", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fri"].Value = fri;

                objmysqlcommand.Parameters.Add("sat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sat"].Value = sat;

                objmysqlcommand.Parameters.Add("all1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["all1"].Value = all;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

         catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
            }
       

        //********************Select Days for Premium According to Edition Code**********************************
        //***********************************************************************************************
        public DataSet checkeditcode(string compcode, string editcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkpremiumeditcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("editcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editcode"].Value = editcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }



        public DataSet checksuppcode(string compcode, string suppcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkpremiumsuppcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }




        //****************************************************************************************************
        //****************************************************************************************************
        // ********************************************************************************************
        public DataSet checkpremcode(string compcode, string premcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkpremiumcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;

               

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }



      


        //****************************************Function For*****************************************//
        //***********************************Modify The Premium Day************************************//
        //*********************************************************************************************//
        public DataSet selectpremiumdaymodify(string compcode, string premcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("selectpremiumdaymodify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;

                objmysqlcommand.Parameters.Add("sun", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sun"].Value = sun;

                objmysqlcommand.Parameters.Add("mon", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mon"].Value = mon;


                objmysqlcommand.Parameters.Add("tue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tue"].Value = tue;

                objmysqlcommand.Parameters.Add("wed", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["wed"].Value = wed;

                objmysqlcommand.Parameters.Add("thu", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["thu"].Value = thu;


                objmysqlcommand.Parameters.Add("fri", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fri"].Value = fri;

                objmysqlcommand.Parameters.Add("sat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sat"].Value = sat;

                objmysqlcommand.Parameters.Add("all1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["all1"].Value = all;

              

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);


                return objDataSet;
            }

            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        //********************************************************************************************//
        //**********************************Auto Generate Code****************************************//
        //********************************************************************************************//
        public DataSet autopagecode(string premname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("autopremiumcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("premname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premname"].Value = premname;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (premname.Length >2)
                {
                objmysqlcommand.Parameters["cod"].Value = premname.Substring (0,2);
                 }
                 else
                 {
                     objmysqlcommand.Parameters["cod"].Value = premname;
                 }



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


    }
}
