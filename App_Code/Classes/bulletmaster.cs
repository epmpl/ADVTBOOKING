using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for bulletmaster.
	/// </summary>
	public class bulletmaster:connection
	{
		public bulletmaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}



        public DataSet advpub(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_PubName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


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

        public DataSet bindstyle(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindstyle", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;


              


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
                objSqlCommand = GetCommand("delbullet", ref objSqlConnection);
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


        public DataSet duplicay1(string compcode, string logoprem, string edition,string validfrom,string validto,string publication)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("duplicaybulletbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprem"].Value = logoprem;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;


                string dateformat = "dd/mm/yyyy";

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);

                if (validfrom == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value.ToString(); ;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfrom = mm + "/" + dd + "/" + yy;
                    }




                    objSqlCommand.Parameters["@fromdate"].Value = validfrom;
                }


                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);

                if (validto == "")
                {
                    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value.ToString(); ;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validto = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@todate"].Value = validto;
                }




                objSqlCommand.Parameters.Add("@publication", SqlDbType.VarChar);

                if (publication == "0")
                {
                    objSqlCommand.Parameters["@publication"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@publication"].Value = publication;
                }

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
                objSqlCommand = GetCommand("bulletbind", ref objSqlConnection);
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




        public DataSet bindlogo1(string compcode, string logocode,string seq)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bulletbind1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@logocode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logocode"].Value = logocode;


                objSqlCommand.Parameters.Add("@seqno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seqno"].Value = seq;




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


        public DataSet update1(string COMP_CODE, string USERID, string LOGOPREMIUM_CODE, string EDITION, string AMOUNT, string premimum, string hdnsequenceno,string validfrom,string validto,string publication)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatebulletchild", ref objSqlConnection);
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




                string dateformat = "dd/mm/yyyy";

                objSqlCommand.Parameters.Add("@validfrom", SqlDbType.VarChar);

                if (validfrom == "")
                {
                    objSqlCommand.Parameters["@validfrom"].Value = System.DBNull.Value.ToString(); ;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfrom = mm + "/" + dd + "/" + yy;
                    }




                    objSqlCommand.Parameters["@validfrom"].Value = validfrom;
                }

                objSqlCommand.Parameters.Add("@validto", SqlDbType.VarChar);

                if (validto == "")
                {
                    objSqlCommand.Parameters["@validto"].Value = System.DBNull.Value.ToString();
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validto = mm + "/" + dd + "/" + yy;
                    }




                    objSqlCommand.Parameters["@validto"].Value = validto;
                }


                objSqlCommand.Parameters.Add("@publication", SqlDbType.VarChar);
                objSqlCommand.Parameters["@publication"].Value = publication;





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






        public DataSet save(string compcode, string userid, string logoprem, string edition, string premimum, string amount,string validfrom ,string validto,string publication)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("savebulletchild", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMP_CODE"].Value = compcode;


                objSqlCommand.Parameters.Add("@USERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@USERID"].Value = userid;

                objSqlCommand.Parameters.Add("@LOGOPREMIUM_CODE", SqlDbType.VarChar);

                if (logoprem == "" || logoprem == null)
                {
                    objSqlCommand.Parameters["@LOGOPREMIUM_CODE"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@LOGOPREMIUM_CODE"].Value = logoprem;
                }


                objSqlCommand.Parameters.Add("@EDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EDITION"].Value = edition;


                objSqlCommand.Parameters.Add("@PREMIUM", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PREMIUM"].Value = premimum;

                objSqlCommand.Parameters.Add("@AMOUNT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@AMOUNT"].Value = amount;


                string dateformat = "dd/mm/yyyy";

                objSqlCommand.Parameters.Add("@validfrom", SqlDbType.VarChar);

                if (validfrom == "")
                {
                    objSqlCommand.Parameters["@validfrom"].Value = System.DBNull.Value.ToString(); ;
                }
                else
                {

                   
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfrom = mm + "/" + dd + "/" + yy;
                    }




                    objSqlCommand.Parameters["@validfrom"].Value = validfrom;
                }

                objSqlCommand.Parameters.Add("@validto", SqlDbType.VarChar);

                if (validto == "")
                {
                    objSqlCommand.Parameters["@validto"].Value = System.DBNull.Value.ToString();
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validto = mm + "/" + dd + "/" + yy;
                    }




                    objSqlCommand.Parameters["@validto"].Value = validto;
                }


                objSqlCommand.Parameters.Add("@publication", SqlDbType.VarChar);
                objSqlCommand.Parameters["@publication"].Value = publication;




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





        public DataSet checkrevcode(string comcode, string bulletdesc, string compcode, string userid, string pubcenter)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkbullet", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comcode"].Value =comcode;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


                objSqlCommand.Parameters.Add("@bulletdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletdesc"].Value = bulletdesc;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;
				//objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				//objSqlCommand.Parameters["@userid"].Value=userid;


				
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

        //public DataSet insertintobullet(string bulletcode,string advtype,string edition,string bulletdesc,string bulletcharge,string bullettext,string remarks,string listboxvalue,string validatedate,string validatetill,string compcode,string userid)
        public DataSet insertintobullet(string bulletcode, string bulletdesc, string bulletcharge, string bullettext, string remarks, string validatedate, string validatetill, string compcode, string userid, string sumble, string pubcenter, string font, string adcat, string fontcol, string pubcode, string edit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertbullet", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@advtype"].Value =advtype;

                //objSqlCommand.Parameters.Add("@edition",SqlDbType.VarChar);
                //objSqlCommand.Parameters["@edition"].Value=edition;

                objSqlCommand.Parameters.Add("@bulletdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletdesc"].Value = bulletdesc;

                objSqlCommand.Parameters.Add("@bulletcharge", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcharge"].Value = bulletcharge;

                objSqlCommand.Parameters.Add("@bullettext", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bullettext"].Value = bullettext;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@sumble", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@sumble"].Value = sumble;

                //objSqlCommand.Parameters.Add("@listboxvalue", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@listboxvalue"].Value =listboxvalue;

                objSqlCommand.Parameters.Add("@validatedate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@validatedate"].Value = Convert.ToDateTime(validatedate);


                objSqlCommand.Parameters.Add("@validatetill", SqlDbType.DateTime);
                //objSqlCommand.Parameters["@validatetill"].Value=Convert.ToDateTime(validatetill);

                if (validatetill != "" && validatetill != null)
                {
                    objSqlCommand.Parameters["@validatetill"].Value = Convert.ToDateTime(validatetill);
                }
                else
                {

                    objSqlCommand.Parameters["@validatetill"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@font", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@font"].Value = font;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.NVarChar);
                if (adcat == "" || adcat == "0")
                    objSqlCommand.Parameters["@adcat"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adcat"].Value = adcat;



                objSqlCommand.Parameters.Add("@fontcolor", SqlDbType.NVarChar);
                if (fontcol == "" || fontcol == "0")
                    objSqlCommand.Parameters["@fontcolor"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@fontcolor"].Value = fontcol;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@edition"].Value = edit;


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

        //public DataSet executebulletmast(string advtype,string edition,string bulletcode,string bulletdesc,string bulletcharge,string bullettext,string listboxvalue,string compcode,string userid)
        public DataSet executebulletmast(string bulletcode, string bulletdesc, string bulletcharge, string bullettext, string compcode, string userid, string pubcenter, string dateformat, string adcat)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("executebulletbullet", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@advtype"].Value = advtype;

                //objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@edition"].Value = edition;
 
				objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@bulletcode"].Value =bulletcode;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;

				

				

				objSqlCommand.Parameters.Add("@bulletdesc", SqlDbType.VarChar);
				objSqlCommand.Parameters["@bulletdesc"].Value =bulletdesc;

				objSqlCommand.Parameters.Add("@bulletcharge",SqlDbType.VarChar);
				objSqlCommand.Parameters["@bulletcharge"].Value=bulletcharge;

				objSqlCommand.Parameters.Add("@bullettext", SqlDbType.VarChar);
				objSqlCommand.Parameters["@bullettext"].Value =bullettext;

              
                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;


                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.NVarChar);
                if (adcat == "" || adcat == "0")
                    objSqlCommand.Parameters["@adcat"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adcat"].Value = adcat;

				
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

		public DataSet bulletfirst()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("firstbullet", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
								
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

       // public DataSet updateinbullet(string bulletcode,string advtype,string edition,string bulletdesc,string bulletcharge,string bullettext,string remarks,string listboxvalue,string validatedate,string validatetill,string compcode,string userid)
        public DataSet updateinbullet(string bulletcode, string bulletdesc, string bulletcharge, string bullettext, string remarks, string validatedate, string validatetill, string compcode, string userid, string sumble, string pubcenter, string font, string adcat, string fontcol, string pubcode, string edit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatebullet", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@advtype"].Value =advtype;

                //objSqlCommand.Parameters.Add("@edition",SqlDbType.VarChar);
                //objSqlCommand.Parameters["@edition"].Value=edition;

                objSqlCommand.Parameters.Add("@bulletdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletdesc"].Value = bulletdesc;

                objSqlCommand.Parameters.Add("@bulletcharge", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcharge"].Value = bulletcharge;

                objSqlCommand.Parameters.Add("@bullettext", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bullettext"].Value = bullettext;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@sumble", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@sumble"].Value = sumble;
                //objSqlCommand.Parameters.Add("@listboxvalue", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@listboxvalue"].Value =listboxvalue;

                objSqlCommand.Parameters.Add("@validatedate", SqlDbType.DateTime);
                objSqlCommand.Parameters["@validatedate"].Value = Convert.ToDateTime(validatedate);

                objSqlCommand.Parameters.Add("@validatetill", SqlDbType.DateTime);
                //objSqlCommand.Parameters["@validatetill"].Value=Convert.ToDateTime(validatetill);

                if (validatetill != "" && validatetill != null)
                {
                    objSqlCommand.Parameters["@validatetill"].Value = Convert.ToDateTime(validatetill);
                }
                else
                {

                    objSqlCommand.Parameters["@validatetill"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@font1", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@font1"].Value = font;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.NVarChar);
                if (adcat == "" || adcat == "0")
                    objSqlCommand.Parameters["@adcat"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@fontcolor", SqlDbType.NVarChar);
                if (fontcol == "" || fontcol == "0")
                    objSqlCommand.Parameters["@fontcolor"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@fontcolor"].Value = fontcol;


                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.NVarChar);
                objSqlCommand.Parameters["@edition"].Value = edit;



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


		public DataSet deletevalue(string bulletcode,string compcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deletebullet", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@bulletcode"].Value =bulletcode;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value=userid;

				


				
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

		public DataSet checkmultibull(string compcode,string userid,string adsizecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkmultiselectbullet", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@adsizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@adsizecode"].Value =adsizecode;

				
				
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}
		public DataSet chkinsbull(string compcode,string userid,string adsizecode,string abc)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertmultibullet", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@adsizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@adsizecode"].Value =adsizecode;

				objSqlCommand.Parameters.Add("@abc",SqlDbType.VarChar);
				objSqlCommand.Parameters["@abc"].Value=abc;
				
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}


        /*********************************************/

        public DataSet countbulletcode(string str, string pubcenter, string publication, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkbulletcodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@publication", SqlDbType.VarChar);
                objSqlCommand.Parameters["@publication"].Value = publication;

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
        public DataSet getlistad_cat(string xyz, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_advcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking"].Value = xyz;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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


        /********************************************/


        public DataSet countbulletname(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkbulletname", ref objSqlConnection);
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



		public DataSet listboxbullupdate(string compcode,string userid,string adsizecode,string abc)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updatemultibullet", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@adsizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@adsizecode"].Value =adsizecode;

				objSqlCommand.Parameters.Add("@abc",SqlDbType.VarChar);
				objSqlCommand.Parameters["@abc"].Value=abc;
				
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		}

        public DataSet getSymbol(string bulletcode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getSymbol", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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
        public DataSet pubcenter(string pcompcode, string ppcenter, string puserid, string pdateformat, string pextra1, string pextra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pcenter_wise_detail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = pcompcode;

                objSqlCommand.Parameters.Add("@ppcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppcenter"].Value = ppcenter;


                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = puserid;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = pdateformat;


                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = puserid;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = puserid;



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
