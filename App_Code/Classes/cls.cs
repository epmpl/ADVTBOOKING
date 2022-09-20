using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;

/// <summary>
/// Summary description for cls
/// </summary>
/// 

namespace NewAdbooking.Classes
{
    public class cls : connection
    {
        public cls()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet fetchdata()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getsavehtml", ref objSqlConnection);
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

        //public DataSet insertxml(int t_id, string location1, string xml, string name, string fullhtml, string filterhtml)
        //{

        //    //SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["admakingConnectionString1"]);
        //    //cn.Open();
        //    ////string sql = "insert into global_library(temp_location,image_location)values(@temp_location,@image_location)";
        //    ////string sql1 = "insert into html(html)values(@html)";
        //    //string sql = "insert into save_html(templete_path, html_string)values(@templete_path, @html_string)";
        //    //SqlCommand cmd = new SqlCommand(sql, cn);
        //    //return cmd;

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();

        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();

        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("inserthtml", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@temp_location", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@temp_location"].Value = location1;

        //        objSqlCommand.Parameters.Add("@temp_xml", SqlDbType.Text);
        //        objSqlCommand.Parameters["@temp_xml"].Value = xml;

        //        objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@name"].Value = name;

        //        objSqlCommand.Parameters.Add("@template_id", SqlDbType.Int);
        //        objSqlCommand.Parameters["@template_id"].Value = t_id;

        //        objSqlCommand.Parameters.Add("@temp_html", SqlDbType.Text);
        //        objSqlCommand.Parameters["@temp_html"].Value = fullhtml;

        //        objSqlCommand.Parameters.Add("@temp_xhtml", SqlDbType.Text);
        //        objSqlCommand.Parameters["@temp_xhtml"].Value = filterhtml;

        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);

        //        return objDataSet;
        //    }

        //    catch (SqlException objException)
        //    {
        //        throw (objException);


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

        public DataSet insertxml(int t_id, string location1, string xml, string name, string fullhtml, string filterhtml, string uom, string adh, string adw, string catcode)
        {

            //SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["admakingConnectionString1"]);
            //cn.Open();
            ////string sql = "insert into global_library(temp_location,image_location)values(@temp_location,@image_location)";
            ////string sql1 = "insert into html(html)values(@html)";
            //string sql = "insert into save_html(templete_path, html_string)values(@templete_path, @html_string)";
            //SqlCommand cmd = new SqlCommand(sql, cn);
            //return cmd;

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();

            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("inserthtml", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@temp_location", SqlDbType.VarChar);
                objSqlCommand.Parameters["@temp_location"].Value = location1;

                objSqlCommand.Parameters.Add("@temp_xml", SqlDbType.Text);
                objSqlCommand.Parameters["@temp_xml"].Value = xml;

                objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name"].Value = name;

                objSqlCommand.Parameters.Add("@template_id", SqlDbType.Int);
                objSqlCommand.Parameters["@template_id"].Value = t_id;

                objSqlCommand.Parameters.Add("@temp_html", SqlDbType.Text);
                objSqlCommand.Parameters["@temp_html"].Value = fullhtml;

                objSqlCommand.Parameters.Add("@temp_xhtml", SqlDbType.Text);
                objSqlCommand.Parameters["@temp_xhtml"].Value = filterhtml;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adheight", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adheight"].Value = adh;

                objSqlCommand.Parameters.Add("@adwidth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adwidth"].Value = adw;
                objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catcode"].Value = catcode;

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
        public DataSet insertadxml(int a_id, string xml, string name, string fullhtml, string filterhtml, string uom1, string adh, string adw)
        {

            //SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["admakingConnectionString1"]);
            //cn.Open();
            ////string sql = "insert into global_library(temp_location,image_location)values(@temp_location,@image_location)";
            ////string sql1 = "insert into html(html)values(@html)";
            //string sql = "insert into save_html(templete_path, html_string)values(@templete_path, @html_string)";
            //SqlCommand cmd = new SqlCommand(sql, cn);
            //return cmd;

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();

            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertad", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ad_xml", SqlDbType.Text);
                objSqlCommand.Parameters["@ad_xml"].Value = xml;

                objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name"].Value = name;

                objSqlCommand.Parameters.Add("@ad_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_id"].Value = a_id;

                objSqlCommand.Parameters.Add("@ad_html", SqlDbType.Text);
                objSqlCommand.Parameters["@ad_html"].Value = fullhtml;

                objSqlCommand.Parameters.Add("@ad_xhtml", SqlDbType.Text);
                objSqlCommand.Parameters["@ad_xhtml"].Value = filterhtml;

                objSqlCommand.Parameters.Add("@ad_uom", SqlDbType.Text);
                objSqlCommand.Parameters["@ad_uom"].Value = uom1;

                objSqlCommand.Parameters.Add("@ad_height", SqlDbType.Text);
                objSqlCommand.Parameters["@ad_height"].Value = adh;

                objSqlCommand.Parameters.Add("@ad_width", SqlDbType.Text);
                objSqlCommand.Parameters["@ad_width"].Value = adw;

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


        public DataSet updatexml(int id, string xml, string fullhtml, string xhtml)
        {

            //SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["admakingConnectionString1"]);
            //cn.Open();
            ////string sql = "insert into global_library(temp_location,image_location)values(@temp_location,@image_location)";
            ////string sql1 = "insert into html(html)values(@html)";
            //string sql = "insert into save_html(templete_path, html_string)values(@templete_path, @html_string)";
            //SqlCommand cmd = new SqlCommand(sql, cn);
            //return cmd;

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();

            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatehtml", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@temp_location", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@temp_location"].Value = location1;

                objSqlCommand.Parameters.Add("@temp_xml", SqlDbType.Text);
                objSqlCommand.Parameters["@temp_xml"].Value = xml;

                //objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@name"].Value = name;

                objSqlCommand.Parameters.Add("@template_id", SqlDbType.Int);
                objSqlCommand.Parameters["@template_id"].Value = id;

                objSqlCommand.Parameters.Add("@temp_html", SqlDbType.Text);
                objSqlCommand.Parameters["@temp_html"].Value = fullhtml;

                objSqlCommand.Parameters.Add("@temp_xhtml", SqlDbType.Text);
                objSqlCommand.Parameters["@temp_xhtml"].Value = xhtml;


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
        
        public DataSet updatexml1(int id, string xml, string fullhtml, string xhtml)
        {

            //SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["admakingConnectionString1"]);
            //cn.Open();
            ////string sql = "insert into global_library(temp_location,image_location)values(@temp_location,@image_location)";
            ////string sql1 = "insert into html(html)values(@html)";
            //string sql = "insert into save_html(templete_path, html_string)values(@templete_path, @html_string)";
            //SqlCommand cmd = new SqlCommand(sql, cn);
            //return cmd;

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();

            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateadhtml", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@temp_location", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@temp_location"].Value = location1;

                objSqlCommand.Parameters.Add("@ad_xml", SqlDbType.Text);
                objSqlCommand.Parameters["@ad_xml"].Value = xml;

                //objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@name"].Value = name;

                objSqlCommand.Parameters.Add("@ad_id", SqlDbType.Int);
                objSqlCommand.Parameters["@ad_id"].Value = id;

                objSqlCommand.Parameters.Add("@ad_html", SqlDbType.Text);
                objSqlCommand.Parameters["@ad_html"].Value = fullhtml;

                objSqlCommand.Parameters.Add("@ad_xhtml", SqlDbType.Text);
                objSqlCommand.Parameters["@ad_xhtml"].Value = xhtml;


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
        
        public DataSet fetchquerydata(string abc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getselectedVal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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

        public void fetchdata(DataSet ds)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataSet get_id()
        {

            //SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["admakingConnectionString1"]);
            //cn.Open();
            ////string sql = "insert into global_library(temp_location,image_location)values(@temp_location,@image_location)";
            ////string sql1 = "insert into html(html)values(@html)";
            //string sql = "insert into save_html(templete_path, html_string)values(@templete_path, @html_string)";
            //SqlCommand cmd = new SqlCommand(sql, cn);
            //return cmd;

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();

            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet1 = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet1);

                return objDataSet1;
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

        public DataSet fetchadquerydata(string abc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getselectedadVal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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



        public DataSet fetchadhtmdata()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getadhtm", ref objSqlConnection);
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
        
        public DataSet get_adid()
        {

            //SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["admakingConnectionString1"]);
            //cn.Open();
            ////string sql = "insert into global_library(temp_location,image_location)values(@temp_location,@image_location)";
            ////string sql1 = "insert into html(html)values(@html)";
            //string sql = "insert into save_html(templete_path, html_string)values(@templete_path, @html_string)";
            //SqlCommand cmd = new SqlCommand(sql, cn);
            //return cmd;

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();

            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet1 = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getadid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet1);

                return objDataSet1;
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

        //public void LaunchCommandLineApp(string location, string type, string name)
        //{
        //    // Launch a command-line application, with some options set.
        //    // Arguments here are just application-specific and can be
        //    // used to control the output format of the application being started.
        //    string gen_path = Server.MapPath("") + "\\htmlgen\\";
        //    string fname = "";
        //    if (type == "PDF")
        //    {
        //        fname = gen_path + "\\pdf\\" + name + "." + type;
        //    }
        //    else if (type == "PS")
        //    {
        //        fname = gen_path + "\\eps\\" + name + "." + type;
        //    }
        //    else if (type == "GIF")
        //    {
        //        fname = gen_path + "\\gif\\" + name + "." + type;
        //    }
        //    else if (type == "PNG")
        //    {
        //        fname = gen_path + "\\png\\" + name + "." + type;
        //    }
        //    else if (type == "TIF")
        //    {
        //        fname = gen_path + "\\tif\\" + name + "." + type;
        //    }
        //    else if (type == "JPG")
        //    {
        //        fname = gen_path + "\\jpg\\" + name + "." + type;
        //    }

        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    startInfo.CreateNoWindow = false;
        //    startInfo.UseShellExecute = false;
        //    startInfo.FileName = gen_path + "htmltools.exe";
        //    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //    startInfo.Arguments = location + " " + fname;// "-f j -o \"" + _cacheDir + "\" -z 1.0 -s y " + target;

        //    try
        //    {
        //        // Start the process with the info we specified.
        //        // Call WaitForExit and the Close. An exception is thrown
        //        // if something goes wrong.
        //        Process exeProcess = Process.Start(startInfo);
        //        exeProcess.WaitForExit();
        //        exeProcess.Close();
        //    }
        //    catch//(Exception ex)
        //    {
        //        return;
        //    }
        //}

        //public int getuser(string userid, string userpwd)
        //{
        //    int xx = 1;
        //    return xx;


        //}


   



     public DataSet fatchcategory()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getcatname", ref objSqlConnection);
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



        public DataSet fatchcatemplate(string myid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("gettemplate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@myid",SqlDbType.VarChar);
                objSqlCommand.Parameters["@myid"].Value = myid;


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



        public DataSet fetchaduom(string uom)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchaduom", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


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