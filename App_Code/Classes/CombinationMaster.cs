using System;
using System.Data;
using System.Data.SqlClient;


namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for CombinationMaster.
	/// </summary>
	public class CombinationMaster:connection
	{
		public CombinationMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public void savecombindays(string compcode, string combincode, string edicombincode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string focusday, string allday, int cnt)
        {
            SqlConnection  objSQLConnection;
            SqlCommand objSqlCommand;
            //DataSet objDataSet = new DataSet();
            objSQLConnection = GetConnection();
            //OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objSQLConnection.Open();
                objSqlCommand = GetCommand("SAVE_COMBIN_DAYS", ref objSQLConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMPCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@COMBINCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMBINCODE"].Value = combincode;

                objSqlCommand.Parameters.Add("@EDICOMBINCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EDICOMBINCODE"].Value = edicombincode;

                objSqlCommand.Parameters.Add("@SUN1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SUN1"].Value = sun;

                objSqlCommand.Parameters.Add("@MON1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@MON1"].Value = mon;

                objSqlCommand.Parameters.Add("@TUE1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@TUE1"].Value = tue;

                objSqlCommand.Parameters.Add("@WED1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@WED1"].Value = wed;

                objSqlCommand.Parameters.Add("@THU1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@THU1"].Value = thu;

                objSqlCommand.Parameters.Add("@FRI1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@FRI1"].Value = fri;

                objSqlCommand.Parameters.Add("@SAT1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SAT1"].Value = sat;

                objSqlCommand.Parameters.Add("@FOCUSDAY1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@FOCUSDAY1"].Value = focusday;

                objSqlCommand.Parameters.Add("@ALLDAY1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ALLDAY1"].Value = allday;

                objSqlCommand.Parameters.Add("@CNT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CNT"].Value = cnt;

                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSQLConnection);
            }
        }
        public DataSet bindgrid(string compcode, string userid, string values, string adcat,string pubcenter,string adtype1)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();

                if (adcat == "0")
                {
                    objSqlCommand = GetCommand("bindcombination", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@userid"].Value = userid;
                    if (values == null)
                    {
                        values = "";
                    }
                    objSqlCommand.Parameters.Add("@values", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@values"].Value = values;

                    objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                    objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@adtype1"].Value = adtype1;
                }


                else {

                    objSqlCommand = GetCommand("getedibyvat", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@adcat"].Value = adcat;

                    objSqlCommand.Parameters.Add("@checkboxname", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@checkboxname"].Value = values;

                    objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                    objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@adtype1"].Value = adtype1;
                
                     }
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


		public DataSet checkboxbind()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("combinationcheckbox", ref objSqlConnection);
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

        public DataSet checkcommcode(string comcode, string compcode, string userid, string combination, string adtype, string adcat, string adscat, string pubcenter, string combindesc, string values1)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkcodecommbination", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;	
		
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comcode"].Value =comcode;

                objSqlCommand.Parameters.Add("@combination", SqlDbType.VarChar);
                objSqlCommand.Parameters["@combination"].Value = combination;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@adscat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat"].Value = adscat;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@values1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@values1"].Value = values1;

                objSqlCommand.Parameters.Add("@combindesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@combindesc"].Value = combindesc;
				
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

        public DataSet insertcombination(string comcode, string alias, string packagename, string combinationname, string compcode, string userid, string codepub, string cat, string subcat, string adtype, string noedition, string editiontype, string valofchkbox, string noofinserts, string pubcenter, string split, string consumption,string validfrom ,string vallidto )
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                string dateformat = "dd/mm/yyyy";
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintocombination", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@editiontype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editiontype"].Value = editiontype;

                //objSqlCommand.Parameters.Add("@share", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@share"].Value = share;

                objSqlCommand.Parameters.Add("@valofchkbox", SqlDbType.VarChar);
                objSqlCommand.Parameters["@valofchkbox"].Value = valofchkbox;


                objSqlCommand.Parameters.Add("@cat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cat"].Value = cat;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@noedition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noedition"].Value = noedition;

                objSqlCommand.Parameters.Add("@subcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcat"].Value = subcat;



                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                objSqlCommand.Parameters.Add("@packagename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagename"].Value = packagename;

                objSqlCommand.Parameters.Add("@combinationname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@combinationname"].Value = combinationname;

                objSqlCommand.Parameters.Add("@codepub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@codepub"].Value = codepub;

                /*change ankur*/
                objSqlCommand.Parameters.Add("@noofinserts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinserts"].Value = noofinserts;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@split", SqlDbType.VarChar);
                objSqlCommand.Parameters["@split"].Value = split;

                objSqlCommand.Parameters.Add("@consumption", SqlDbType.Int);
                if (consumption == "" || consumption == null)
                {
                    objSqlCommand.Parameters["@consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@consumption"].Value = Convert.ToInt32(consumption);
                }
                ///////////////////////////////////////////////////////////


                objSqlCommand.Parameters.Add("@pvalid_from", SqlDbType.VarChar);
                if (validfrom == "")
                {
                    objSqlCommand.Parameters["@pvalid_from"].Value = System.DBNull.Value;
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
                    objSqlCommand.Parameters["@pvalid_from"].Value = Convert.ToString(validfrom);
                }



                objSqlCommand.Parameters.Add("@pvaliad_to", SqlDbType.VarChar);

                if (vallidto == "")
                {
                    objSqlCommand.Parameters["@pvaliad_to"].Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = vallidto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        vallidto = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@pvaliad_to"].Value = Convert.ToString(vallidto);
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

        public DataSet executecommmdetail(string comcode, string alias, string packagename, string compcode, string userid, string editiontype, string adtype, string pubcenter, string split,string oldpkgcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("executecommdetail", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;	
		
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comcode"].Value =comcode;

                objSqlCommand.Parameters.Add("@editiontype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editiontype"].Value = editiontype;
				


				objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@alias"].Value =alias;

				objSqlCommand.Parameters.Add("@packagename", SqlDbType.VarChar);
				objSqlCommand.Parameters["@packagename"].Value =packagename;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@split", SqlDbType.VarChar);
                objSqlCommand.Parameters["@split"].Value = split;
				


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


		public DataSet firstcommdetail()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("firstsearchcomm", ref objSqlConnection);
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


		public DataSet deletecommdetail(string comcode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deletecombination", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;	
		
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comcode"].Value =comcode;
				
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



        public DataSet getedition(string edition, string radioval)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionlike", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                
                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;
                

                objSqlCommand.Parameters.Add("@radioval", SqlDbType.VarChar);
                if (radioval == null)
                {
                    objSqlCommand.Parameters["@radioval"].Value = "";
                }
                else
                {
                    objSqlCommand.Parameters["@radioval"].Value = radioval;
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


        public DataSet geteditionforcontract(string edition, string radioval)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionlikeforcontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;


                objSqlCommand.Parameters.Add("@radioval", SqlDbType.VarChar);
                if (radioval == null)
                {
                    objSqlCommand.Parameters["@radioval"].Value = "";
                }
                else
                {
                    objSqlCommand.Parameters["@radioval"].Value = radioval;
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



        public DataSet geteditionbycat(string edition,string  adcat,string  compcode,string radioval)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionlikecatmaster", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;


                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@radioval", SqlDbType.VarChar);
                if (radioval == null)
                {
                    objSqlCommand.Parameters["@radioval"].Value = "";
                }
                else
                {
                    objSqlCommand.Parameters["@radioval"].Value = radioval;
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

//public DataSet updatedetail(string comcode,string alias,string packagename,string combinationname,string compcode,string userid,string codepub)

        public DataSet updatedetail(string comcode, string alias, string packagename, string combinationname, string compcode, string userid, string codepub, string cat, string subcat, string adtype, string noedition, string valofchkbox, string noofinserts, string split, string consumption, string validfrom, string vallidto, string oldpkg)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{

                string dateformat = "dd/mm/yyyy";
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updatecombination", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;	
		
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comcode"].Value =comcode;

                objSqlCommand.Parameters.Add("@cat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cat"].Value = cat;

                objSqlCommand.Parameters.Add("@subcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcat"].Value = subcat;

                objSqlCommand.Parameters.Add("@valofchkbox", SqlDbType.VarChar);
                objSqlCommand.Parameters["@valofchkbox"].Value = valofchkbox;


                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@noedition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noedition"].Value = noedition;
				


				objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@alias"].Value =alias;

				objSqlCommand.Parameters.Add("@packagename", SqlDbType.VarChar);
				objSqlCommand.Parameters["@packagename"].Value =packagename;

				objSqlCommand.Parameters.Add("@combinationname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@combinationname"].Value =combinationname;

				objSqlCommand.Parameters.Add("@codepub", SqlDbType.VarChar);
				objSqlCommand.Parameters["@codepub"].Value =codepub;
                objSqlCommand.Parameters.Add("@noofinserts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofinserts"].Value = noofinserts;

                objSqlCommand.Parameters.Add("@split", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@split"].Value = split;

                 objSqlCommand.Parameters.Add("@consumption", SqlDbType.Int);
                 if (consumption == "" || consumption == null)
                 {
                     objSqlCommand.Parameters["@consumption"].Value = System.DBNull.Value;
                 }
                 else
                 {
                     objSqlCommand.Parameters["@consumption"].Value = Convert.ToInt32(consumption);
                 }

                 objSqlCommand.Parameters.Add("@pvalid_from", SqlDbType.VarChar);
                 if (validfrom == "")
                 {
                     objSqlCommand.Parameters["@pvalid_from"].Value = System.DBNull.Value;
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
                     objSqlCommand.Parameters["@pvalid_from"].Value = validfrom;
                 }



                 objSqlCommand.Parameters.Add("@pvaliad_to", SqlDbType.VarChar);

                 if (vallidto == "")
                 {
                     objSqlCommand.Parameters["@pvaliad_to"].Value = System.DBNull.Value;
                 }
                 else
                 {

                     if (dateformat == "dd/mm/yyyy")
                     {
                         string[] arr = vallidto.Split('/');
                         string dd = arr[0];
                         string mm = arr[1];
                         string yy = arr[2];
                         vallidto = mm + "/" + dd + "/" + yy;
                     }

                     objSqlCommand.Parameters["@pvaliad_to"].Value = vallidto;
                 }




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


        public DataSet advdatacat(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("advcattyp", ref objSqlConnection);
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


        public DataSet advdatacategory(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_advcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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


        public DataSet advdatasubcatcat(string compcode, string catcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("advsubcattyp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catcode"].Value = catcode;

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


        public DataSet adtypbind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("advtypbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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



        public DataSet sharebind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindshare", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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






        public DataSet getedivalbycat(string adcat,string compcode,string checkboxname,string pubcenter,string adtype1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getedibyvat", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@checkboxname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@checkboxname"].Value = checkboxname;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype1;

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



        public DataSet countstatecode(string str,string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcombincodemax", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

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


        public DataSet checkpackage(string package,string compcode,string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkpackagename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;
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

        public DataSet packcode(string package, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpackagecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

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

        public DataSet INSUPDDELADON(string compcode, string combincode, string PADON_CODE, string PPACKAGE_CODE, string PPUBLICATION, string PNO_OF_INSERT, string PUSERID, string PTRN_TYPE, string PPACKAGE_NAME)
        {
            SqlConnection objSQLConnection;
            SqlCommand objSqlCommand;
            DataSet objDataSet = new DataSet();
            objSQLConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSQLConnection.Open();
                objSqlCommand = GetCommand("COMBINADON_INS_UPD_DEL", ref objSQLConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@PCOMBIN_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMBIN_CODE"].Value = combincode;

                objSqlCommand.Parameters.Add("@PADON_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PADON_CODE"].Value = PADON_CODE;

                objSqlCommand.Parameters.Add("@PPACKAGE_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PPACKAGE_CODE"].Value = PPACKAGE_CODE;

                objSqlCommand.Parameters.Add("@PPUBLICATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PPUBLICATION"].Value = PPUBLICATION;

                objSqlCommand.Parameters.Add("@PNO_OF_INSERT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PNO_OF_INSERT"].Value = PNO_OF_INSERT;

                objSqlCommand.Parameters.Add("@PUSERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUSERID"].Value = PUSERID;

                objSqlCommand.Parameters.Add("@PTRN_TYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PTRN_TYPE"].Value = PTRN_TYPE;

                objSqlCommand.Parameters.Add("@PEXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA1"].Value = PPACKAGE_NAME;

                objSqlCommand.Parameters.Add("@PEXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEXTRA3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEXTRA4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEXTRA5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA5"].Value = System.DBNull.Value;

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
                CloseConnection(ref objSQLConnection);
            }
        }
//===============================//
        public DataSet bindadon(string compcode, string combincode)
        {
            SqlConnection objSQLConnection;
            SqlCommand objSqlCommand;
            DataSet objDataSet = new DataSet();
            objSQLConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSQLConnection.Open();
                objSqlCommand = GetCommand("bindadongrid4combin", ref objSQLConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMPCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@PCOMBINCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMBINCODE"].Value = combincode;

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
                CloseConnection(ref objSQLConnection);
            }
        }
        public DataSet soloeditionbind(string compcode, string pubcode, string adtype)
        {
            SqlConnection objSQLConnection;
            SqlCommand objSqlCommand;
            DataSet objDataSet = new DataSet();
            objSQLConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSQLConnection.Open();
                objSqlCommand = GetCommand("bindsolopackage4combin", ref objSQLConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = adtype;

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
                CloseConnection(ref objSQLConnection);
            }
        }
        public DataSet getdata1(string compcode, string code11)
        {
            SqlConnection objSQLConnection;
            SqlCommand objSqlCommand;
            DataSet objDataSet = new DataSet();
            objSQLConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSQLConnection.Open();
                objSqlCommand = GetCommand("filladongrid4combin", ref objSQLConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMPCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@PADONCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PADONCODE"].Value = code11;

                //objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@padtype"].Value = adtype;

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
                CloseConnection(ref objSQLConnection);
            }
        }


        public DataSet chk(string edition1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("combinemastcheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@combindesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@combindesc"].Value = edition1;


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
