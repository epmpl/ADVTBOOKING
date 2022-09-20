using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
/// <summary>
/// Summary description for All_Module_master


    public class All_Module_master:connection
    {
        public All_Module_master()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adddesignation()
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_designation", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@dist"].Value =dist;
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






        public DataSet addcategoryname()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adcat", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@dist"].Value =dist;
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


        public DataSet getcode(string catname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillcatcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@catname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catname"].Value = catname;


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






        public DataSet all_modsave1(string compcode, string catcode, string code, string name, string level, string mailid, string desc, string userid, string status)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("allmodsave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catcode"].Value = catcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name"].Value = name;

                objSqlCommand.Parameters.Add("@level", SqlDbType.VarChar);
                objSqlCommand.Parameters["@level"].Value = level;

                objSqlCommand.Parameters.Add("@mailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mailid"].Value = mailid;


                objSqlCommand.Parameters.Add("@desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@desc"].Value = desc;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

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





//o

        public DataSet allmodexecute1(string compcode, string catcode, string code, string name, string level, string mailid, string desc, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("allmodexe", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catcode"].Value = catcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name"].Value = name;

                objSqlCommand.Parameters.Add("@level", SqlDbType.VarChar);
                objSqlCommand.Parameters["@level"].Value = level;

                objSqlCommand.Parameters.Add("@mailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mailid"].Value = mailid;


                objSqlCommand.Parameters.Add("@desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@desc"].Value = desc;

                

              















              /*  objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                //if(@catcode == "0")
                //{
                //    objSqlCommand.Parameters["@catcode"].Value ="%%";
                //}
                //else
                //{
                objSqlCommand.Parameters["@catcode"].Value = catcode;

                //}

                objSqlCommand.Parameters.Add("@subcatcode", SqlDbType.VarChar);
                //if(subcatcode!= null && subcatcode!="" && subcatcode!="undefined")
                //{
                objSqlCommand.Parameters["@subcatcode"].Value = subcatcode;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@subcatcode"].Value ="%%";
                //}





                objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
                //if(subcatname!= null && subcatname!="" && subcatname!="undefined")
                //{
                objSqlCommand.Parameters["@subcatname"].Value = subcatname;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@subcatname"].Value ="%%";
                //}





                objSqlCommand.Parameters.Add("@subcatalias", SqlDbType.VarChar);
                //if(subcatalias!= null && subcatalias!="" && subcatalias!="undefined")
                //{
                objSqlCommand.Parameters["@subcatalias"].Value = subcatalias;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@subcatalias"].Value ="%%";
                //}*/



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












        public DataSet allmodupdate1(string compcode, string catcode, string code, string name, string level, string mailid, string desc, string userid, string status)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("allmod_modify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catcode"].Value = catcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name"].Value = name;

                objSqlCommand.Parameters.Add("@level", SqlDbType.VarChar);
                objSqlCommand.Parameters["@level"].Value = level;

                objSqlCommand.Parameters.Add("@mailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mailid"].Value = mailid;


                objSqlCommand.Parameters.Add("@desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@desc"].Value = desc;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = status;

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




        public DataSet allmodfirst1(string compcode, string code, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("allmodfnpl", ref objSqlConnection);
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


          public DataSet codechk1(string compcode, string code, string userid)
           {
               SqlConnection objSqlConnection;
               SqlCommand objSqlCommand; 
               objSqlConnection = GetConnection();
               SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
               DataSet objDataSet = new DataSet();
               try
               {
                   objSqlConnection.Open();
                   objSqlCommand = GetCommand("allchk", ref objSqlConnection);
                   objSqlCommand.CommandType = CommandType.StoredProcedure;


                   objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                   objSqlCommand.Parameters["@compcode"].Value = compcode;

                   objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                   objSqlCommand.Parameters["@code"].Value = code;


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







          public DataSet presubcat(string compcode, string catcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("allmodfnpl", ref objSqlConnection);
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



          public DataSet nextsubcat(string compcode, string catcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("subcatfnpl", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@catcode"].Value =catcode;


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





        public DataSet lastsubcat(string compcode, string catcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("subcatfnpl", ref objSqlConnection);
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



        public DataSet allmoddel1(string compcode, string code, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("allmoddel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;



                
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



        public DataSet chksallmodcode1(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkallname", ref objSqlConnection);
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




    }
}
