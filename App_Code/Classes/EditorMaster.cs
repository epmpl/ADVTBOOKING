using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for EditorMaster.
	/// </summary>
	public class EditorMaster:connection
	{
		public EditorMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        //function to check edition type
        public DataSet editiontypecheck(string pub, string type, string city, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editiontypecheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

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

        //*****************
		//circulations
        public DataSet chkcirculations(string pub, string city, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcirculations", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@type"].Value = type;

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
        //**********************//
		//*************This function is used to check whether particular edition code exists already or not*************//

        public DataSet editioncodecheck(string EditonCode, string compcode, string userid, string editionalias)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("Editioncodecheck", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@EditionCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@EditionCode"].Value =EditonCode;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@editionalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editionalias"].Value = editionalias;

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

        // ***********This function is used to insert values in Database*************///

        public DataSet InsertValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string hr, string min, string prod, string type, string noofcol, string printcent, string segmentcode, string grpsave, string SHORTNAME, string epaper, string spename)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("websp_editorinsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@PubName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PubName"].Value =PubName;
	
				objSqlCommand.Parameters.Add("@CityName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityName"].Value =CityName ;

				objSqlCommand.Parameters.Add("@EditionName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@EditionName"].Value =EditionName;

				objSqlCommand.Parameters.Add("@Alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias"].Value =Alias;

				objSqlCommand.Parameters.Add("@EditonCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@EditonCode"].Value =EditonCode;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@circulation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@circulation"].Value = circulation;

                 objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                 objSqlCommand.Parameters.Add("@column", SqlDbType.VarChar);
                objSqlCommand.Parameters["@column"].Value = column;

                 objSqlCommand.Parameters.Add("@height", SqlDbType.VarChar);
                objSqlCommand.Parameters["@height"].Value = height;

                 objSqlCommand.Parameters.Add("@width", SqlDbType.VarChar);
                objSqlCommand.Parameters["@width"].Value = width;

                 objSqlCommand.Parameters.Add("@area", SqlDbType.VarChar);
                objSqlCommand.Parameters["@area"].Value = area;

                objSqlCommand.Parameters.Add("@periodicity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@periodicity"].Value = periodicity;

                objSqlCommand.Parameters.Add("@gutter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@gutter"].Value = gutter;

                objSqlCommand.Parameters.Add("@col_space", SqlDbType.VarChar);
                objSqlCommand.Parameters["@col_space"].Value = col_space;

                objSqlCommand.Parameters.Add("@hr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hr"].Value = hr;

                objSqlCommand.Parameters.Add("@min", SqlDbType.VarChar);
                objSqlCommand.Parameters["@min"].Value = min;

                objSqlCommand.Parameters.Add("@prod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prod"].Value = prod;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.VarChar);
                if (noofcol == "NaN")
                    noofcol = "1";
                objSqlCommand.Parameters["@noofcol"].Value = noofcol;

                objSqlCommand.Parameters.Add("@printcent", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printcent"].Value = printcent;

                objSqlCommand.Parameters.Add("@psegmentcod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psegmentcod"].Value = segmentcode;

                objSqlCommand.Parameters.Add("@pgrpcod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgrpcod"].Value = grpsave;


                objSqlCommand.Parameters.Add("@pshort_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pshort_name"].Value = SHORTNAME;



                objSqlCommand.Parameters.Add("@epaper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@epaper"].Value = epaper;

                objSqlCommand.Parameters.Add("@spename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spename"].Value = spename;
                
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}

			catch(SqlException objException)    
			{
				throw(objException);
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

        //************* This function is used to modify existing values except edition code******************//

        public DataSet ModifyValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string hr, string min, string prod, string type, string noofcol, string printcent, string segmentcode, string grpsave, string SHORTNAME, string epaper, string specialityname)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("websp_editormodify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				
				objSqlCommand.Parameters.Add("@PubName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PubName"].Value =PubName;

				objSqlCommand.Parameters.Add("@CityName ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityName "].Value =CityName ;

				objSqlCommand.Parameters.Add("@EditionName ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@EditionName "].Value =EditionName;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias "].Value =Alias;

				objSqlCommand.Parameters.Add("@EditonCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@EditonCode"].Value =EditonCode;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@circulation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@circulation"].Value = circulation;

                 objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                 objSqlCommand.Parameters.Add("@column", SqlDbType.VarChar);
                objSqlCommand.Parameters["@column"].Value = column;

                 objSqlCommand.Parameters.Add("@height", SqlDbType.VarChar);
                objSqlCommand.Parameters["@height"].Value = height;

                 objSqlCommand.Parameters.Add("@width", SqlDbType.VarChar);
                objSqlCommand.Parameters["@width"].Value = width;

                 objSqlCommand.Parameters.Add("@area", SqlDbType.VarChar);
                objSqlCommand.Parameters["@area"].Value = area;

                objSqlCommand.Parameters.Add("@periodicity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@periodicity"].Value = periodicity;

                objSqlCommand.Parameters.Add("@gutter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@gutter"].Value = gutter;

                objSqlCommand.Parameters.Add("@col_space", SqlDbType.VarChar);
                objSqlCommand.Parameters["@col_space"].Value = col_space;

                objSqlCommand.Parameters.Add("@hr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hr"].Value = hr;

                objSqlCommand.Parameters.Add("@min", SqlDbType.VarChar);
                objSqlCommand.Parameters["@min"].Value = min;

                objSqlCommand.Parameters.Add("@prod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prod"].Value = prod;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.VarChar);
                if (noofcol == "NaN")
                    noofcol = "1";
                objSqlCommand.Parameters["@noofcol"].Value = noofcol;

                objSqlCommand.Parameters.Add("@printcent", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printcent"].Value = printcent;

                objSqlCommand.Parameters.Add("@psegmentcod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psegmentcod"].Value = segmentcode;

                objSqlCommand.Parameters.Add("@pgrpcod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgrpcod"].Value = grpsave;


                objSqlCommand.Parameters.Add("@pshort_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pshort_name"].Value = SHORTNAME;


                objSqlCommand.Parameters.Add("@epaper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@epaper"].Value = epaper;

                objSqlCommand.Parameters.Add("@spename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@spename"].Value = specialityname;


				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}

			catch(SqlException objException)
			{
				throw(objException);
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

        //*************** This function is used to delete record from database*************//

		public DataSet deleteedition(string EditonCode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("websp_editordelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@EditonCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@EditonCode"].Value =EditonCode;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
							
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}

			catch(SqlException objException)
			{
				throw(objException);
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

    //*********** This function is used to select particular record***************//

        public DataSet SelectValue(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string uom, string column, string height, string width, string area, string periodicity, string gutter, string col_space, string type, string segmentcode, string grpsave, string SHORTNAME, string epaper)
	{
		SqlConnection objSqlConnection;
		SqlCommand objSqlCommand;
		objSqlConnection = GetConnection();
		SqlDataAdapter objSqlDataAdapter;
		DataSet objDataSet = new DataSet();	
		try
		{
			objSqlConnection.Open();
			objSqlCommand = GetCommand("websp_editorSelect", ref objSqlConnection);
			objSqlCommand.CommandType = CommandType.StoredProcedure;
 
			objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
			objSqlCommand.Parameters["@compcode"].Value =compcode;

			objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
			objSqlCommand.Parameters["@userid"].Value =userid;

            //objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
            //if (centcode == "" || centcode == null || centcode == "undefined")
            //{
            //    objSqlCommand.Parameters["@centcode"].Value = "%%";
            //}
            //else
            //{
            //    objSqlCommand.Parameters["@centcode"].Value = centcode;
            //}

			objSqlCommand.Parameters.Add("@PubName", SqlDbType.VarChar);
           // if (PubName == "0" || PubName == null || PubName == "undefined")
            {

            //    objSqlCommand.Parameters["@PubName"].Value = "%%";
            }
           // else
            {
                objSqlCommand.Parameters["@PubName"].Value = PubName;
            }

            objSqlCommand.Parameters.Add("@CityName", SqlDbType.VarChar);
           // if (CityName == "0" || CityName == null || CityName == "undefined")
            {
           //     objSqlCommand.Parameters["@CityName"].Value = "%%";
            }
            //else
            {
                objSqlCommand.Parameters["@CityName"].Value = CityName;
            }

			objSqlCommand.Parameters.Add("@EditionName", SqlDbType.VarChar);

            //if (EditionName == "" || EditionName == null || EditionName == "undefined")
            {
           //     objSqlCommand.Parameters["@EditionName"].Value = "%%";
            }
           // else
            {

                objSqlCommand.Parameters["@EditionName"].Value = EditionName;
            }


			objSqlCommand.Parameters.Add("@Alias", SqlDbType.VarChar);
           // if (Alias == "" || Alias == null || Alias == "undefined")
            {
          //      objSqlCommand.Parameters["@Alias"].Value = "%%";
            }
           // else
            {

              objSqlCommand.Parameters["@Alias"].Value = Alias;
            }


			objSqlCommand.Parameters.Add("@EditonCode", SqlDbType.VarChar);
           // if (EditonCode == "" || EditonCode == null || EditonCode == "undefined")
            {
           //     objSqlCommand.Parameters["@EditonCode"].Value = "%%";
            }
          //  else
            {

                objSqlCommand.Parameters["@EditonCode"].Value = EditonCode;
            }


          objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
            
           // if (country == "0" || country == null || country == "undefined")
            {
          //      objSqlCommand.Parameters["@country"].Value = "%%";
            }
            //else
            {

              objSqlCommand.Parameters["@country"].Value = country;
            }


            objSqlCommand.Parameters.Add("@circulation", SqlDbType.VarChar);

           // if (circulation == "" || circulation == null || circulation == "undefined")
            {
           //     objSqlCommand.Parameters["@circulation"].Value = "%%";
            }
            //else
            {

                objSqlCommand.Parameters["@circulation"].Value = circulation;
            }

            objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);

            //if (uom == "0" || uom == null || uom == "undefined")
            {
            //    objSqlCommand.Parameters["@uom"].Value = "%%";
            }
          //  else
            {

                objSqlCommand.Parameters["@uom"].Value = uom;
            }

            objSqlCommand.Parameters.Add("@column", SqlDbType.VarChar);

           // if (column == "" || column == null || column == "undefined")
            {
           //     objSqlCommand.Parameters["@column"].Value = "%%";
            }
           // else
            {

                objSqlCommand.Parameters["@column"].Value = column;
            }

            objSqlCommand.Parameters.Add("@height", SqlDbType.VarChar);

          //  if (height == "" || height == null || height == "undefined")
            {
            //    objSqlCommand.Parameters["@height"].Value = "%%";
            }
           // else
            {

                objSqlCommand.Parameters["@height"].Value = height;
            }

            objSqlCommand.Parameters.Add("@width", SqlDbType.VarChar);

            //if (width == "" || width == null || width == "undefined")
            {
             //   objSqlCommand.Parameters["@width"].Value = "%%";
            }
           // else
            {

                objSqlCommand.Parameters["@width"].Value = width;
            }

            objSqlCommand.Parameters.Add("@area", SqlDbType.VarChar);

          //  if (area == "" || area == null || area == "undefined")
            {
           //     objSqlCommand.Parameters["@area"].Value = "%%";
            }
            //else
            {

                objSqlCommand.Parameters["@area"].Value = area;
            }
            objSqlCommand.Parameters.Add("@periodicity", SqlDbType.VarChar);
            objSqlCommand.Parameters["@periodicity"].Value = periodicity;

            objSqlCommand.Parameters.Add("@gutter", SqlDbType.VarChar);
            objSqlCommand.Parameters["@gutter"].Value = gutter;

            objSqlCommand.Parameters.Add("@col_space", SqlDbType.VarChar);
            objSqlCommand.Parameters["@col_space"].Value = col_space;

            objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
            objSqlCommand.Parameters["@type"].Value = type;

            objSqlCommand.Parameters.Add("@psegmentcod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@psegmentcod"].Value = segmentcode;

            objSqlCommand.Parameters.Add("@pgrpcod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pgrpcod"].Value = grpsave;


            objSqlCommand.Parameters.Add("@pshort_name", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pshort_name"].Value = SHORTNAME;


              objSqlCommand.Parameters.Add("@epaper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@epaper"].Value = epaper;

			objSqlDataAdapter =new SqlDataAdapter();
			objSqlDataAdapter.SelectCommand =objSqlCommand;
			objSqlDataAdapter.Fill(objDataSet);
			return objDataSet;
		}

		catch(SqlException objException)
		{
			throw(objException);
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
// ***********This function is used to select first,next,previous,last record *************//

        public DataSet Selectfnpl(string PubName, string CityName, string EditionName, string Alias, string EditonCode, string compcode, string userid, string country, string circulation, string SHORTNAME)
	{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("EditiorFNPL", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlDataAdapter = new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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

// *************This function is used to bind publication name*****************//

		public DataSet Pub(string compcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_PubEdName", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
 
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
        //**************Function to bind gutter & column space************************//

        public DataSet space(string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_G_C_space", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                //objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pubname"].Value = pubname;

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

        // *************This function is used to bind periodicity from periodicity master*****************//

        public DataSet periodic(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_Periodicty", ref objSqlConnection);
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

        public DataSet uomname(string compcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("Bind_uomname", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
 
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


		public DataSet SubPub(string edit)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("Bind_SubPubName", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
				objSqlCommand.Parameters["@edit"].Value =edit;

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

		public DataSet cityName()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("Bind_CityEditor", ref objSqlConnection);
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


        //****************This function is used to select edition code*******************//
   
		public DataSet 	checksupcode(string compcode,string editoncode,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkeditioncode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@editoncode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@editoncode"].Value =editoncode;
												
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

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

        //*****************This function is used to modify edition days**********************//
   
		public DataSet 	selecteditiondaymodify(string compcode,string editioncode,string sun,string mon,string tue,string wed,string thu,string fri,string sat,string all,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("editiondaymodify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@editioncode"].Value =editioncode;

				objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sun"].Value =sun;
				
				objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mon"].Value =mon;

				objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
				objSqlCommand.Parameters["@tue"].Value =tue;

				objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
				objSqlCommand.Parameters["@wed"].Value =wed;
				
				objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
				objSqlCommand.Parameters["@thu"].Value =thu;

				objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fri"].Value =fri;

				objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sat"].Value =sat;
				
				objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
				objSqlCommand.Parameters["@all"].Value =all;
								
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

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

        //********* This function is used to save edition days******************//

        public DataSet editiondaysave(string compcode, string editoncode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid, string adtype)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("editiondaysave", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@editoncode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@editoncode"].Value =editoncode;

				objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sun"].Value =sun;
				
				objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mon"].Value =mon;

				objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
				objSqlCommand.Parameters["@tue"].Value =tue;

				objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
				objSqlCommand.Parameters["@wed"].Value =wed;
				
				objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
				objSqlCommand.Parameters["@thu"].Value =thu;

				objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fri"].Value =fri;

				objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sat"].Value =sat;
				
				objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
				objSqlCommand.Parameters["@all"].Value =all;
								
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;


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

        //***********This function is used to check edition code according to particular publication name************//
   
        public DataSet autoeditcode(string str,string strpub,string strcity)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("autoeditcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@strpub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@strpub"].Value = strpub;

                objSqlCommand.Parameters.Add("@strcity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@strcity"].Value = strcity;


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


//Pankaj//



        public DataSet editor(string citycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editorcity", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@citycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@citycode"].Value = citycode;

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


        //***********This function is used to find city name and publication name ************//
   
        public DataSet findcity(string city, string pubname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("findcitypub", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;


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

       

        //***********This function is used to check edition code according to particular publication name************//

        public DataSet autoeditcode1(string str, string strpub)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("autoeditcode1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@strpub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@strpub"].Value = strpub;

            
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

//Pankaj//



     /*   public DataSet editor(string citycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editorcity", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@citycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@citycode"].Value = citycode;

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

        }*/


        //***********This function is used to find city name and publication name ************//
   
       /* public DataSet findcity(string city, string pubname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("findcitypub", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;


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
        }*/




        public DataSet enablechkbox(string pubname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("enablechkboxpub", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;


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

        public DataSet countcity(string txtcountry)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillcity_publ", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@txtcountry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtcountry"].Value = txtcountry;

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



        public DataSet inserteditname(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string year)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("inserteditdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@txteditionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txteditionname"].Value = txteditionname;

                objSqlCommand.Parameters.Add("@txtdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtdate"].Value = txtdate;

                objSqlCommand.Parameters.Add("@txtaddate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtaddate"].Value = txtaddate;


                //objSqlCommand.Parameters.Add("@txtaddate", SqlDbType.DateTime);
                //if (txtaddate == "" || txtaddate == null || txtaddate == "undefined/undefined/")
                //{
                //    objSqlCommand.Parameters["@txtaddate"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@txtaddate"].Value = Convert.ToDateTime(txtaddate);
                //}

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;

                objSqlCommand.Parameters.Add("@year1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@year1"].Value = year;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet selectedfromgrid(string editcode, string compcode, string userid, string code10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectfromeditdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;



                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = code10;




                //objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@flag"].Value =z;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet gridupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string code10, string year)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateeditdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@txteditionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txteditionname"].Value = txteditionname;

                objSqlCommand.Parameters.Add("@txtdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtdate"].Value = txtdate;



                objSqlCommand.Parameters.Add("@txtaddate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtaddate"].Value = txtaddate;
               

             
                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;

                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = code10;



                objSqlCommand.Parameters.Add("@year1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@year1"].Value = year;

                //objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@flag"].Value =z;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet griddelete(string editcode, string compcode, string userid, string code10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletegrideditdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;

                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = code10;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet chkdaetedit( string compcode,  string editcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdateedit", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                
                
                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet chkdateupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string code10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdateeditupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@txteditionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txteditionname"].Value = txteditionname;

                objSqlCommand.Parameters.Add("@txtdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtdate"].Value = txtdate;

                objSqlCommand.Parameters.Add("@txtaddate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtaddate"].Value =txtaddate;
                
                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;

                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = code10;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet ratebind(string code, string compcode, string userid, string date)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindeditdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date"].Value = date;





                //objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@flag"].Value =z;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet filleditalias(string editcode, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("filleditalias", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;




                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        //***********************************************Check periodicity******************************
        public DataSet chkperiodicty(string periodicty, string pub, string edit_period, string mod, string editcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkperiodicty", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@periodicty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@periodicty"].Value = periodicty;


            objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pub"].Value = pub;


            objSqlCommand.Parameters.Add("@edit_period", SqlDbType.VarChar);
            objSqlCommand.Parameters["@edit_period"].Value = edit_period;


            objSqlCommand.Parameters.Add("@mod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@mod"].Value = mod;



            objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@editcode"].Value = editcode;




                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        //***********************************************Check periodicity******************************
        public DataSet chkperiodicty_edition(string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkperiodictyedition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;





                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

//=================================New Change ===========================================
        public DataSet chkperiodicitynumber(string pub, string edit, string period, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkperiodicityforedition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;

                objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit"].Value = edit;

                objSqlCommand.Parameters.Add("@period", SqlDbType.VarChar);
                objSqlCommand.Parameters["@period"].Value = period;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@type"].Value = type;

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




        public DataSet editioncodedub(string compcode, string ecode,string extra1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ADD_CHKEDITCODE", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pedit_code ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pedit_code "].Value = ecode;

                objSqlCommand.Parameters.Add("@pextra ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra "].Value = extra1;

        

                //objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@type"].Value = type;

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
//=========================================================================================================

        public DataSet segmentbind(string compcode, string dateformate, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("FA_VOUCHERS_VIEW_FA_SEGMENT_TYPE_MAST_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

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

        
        public DataSet getcostcentname(string compcode, string centcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            //   OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                objSqlConnection.Open();

                string query = "select dbo.FA_GET_SEGMENT_NAME('" + compcode + "','" + centcode + "')as COST_CENTER_NAME ";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                objSqlCommand.ExecuteNonQuery();

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }


        public DataSet editiontxtsave(string compcode, string editoncode, string txtsun, string txtmon, string txttue, string txtwed, string txtthu, string txtfri, string txtsat,  string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editiontxtsave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@editoncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editoncode"].Value = editoncode;

                objSqlCommand.Parameters.Add("@txtsun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtsun"].Value = txtsun;

                objSqlCommand.Parameters.Add("@txtmon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtmon"].Value = txtmon;

                objSqlCommand.Parameters.Add("@txttue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txttue"].Value = txttue;

                objSqlCommand.Parameters.Add("@txtwed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtwed"].Value = txtwed;

                objSqlCommand.Parameters.Add("@txtthu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtthu"].Value = txtthu;

                objSqlCommand.Parameters.Add("@txtfri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtfri"].Value = txtfri;

                objSqlCommand.Parameters.Add("@txtsat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtsat"].Value = txtsat;
                                
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


        public DataSet selecteditiontxtmodify(string compcode, string editioncode, string txtsun, string txtmon, string txttue, string txtwed, string txtthu, string txtfri, string txtsat, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editiontxtmodify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@txtsun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtsun"].Value = txtsun;

                objSqlCommand.Parameters.Add("@txtmon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtmon"].Value = txtmon;

                objSqlCommand.Parameters.Add("@txttue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txttue"].Value = txttue;

                objSqlCommand.Parameters.Add("@txtwed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtwed"].Value = txtwed;

                objSqlCommand.Parameters.Add("@txtthu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtthu"].Value = txtthu;

                objSqlCommand.Parameters.Add("@txtfri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtfri"].Value = txtfri;

                objSqlCommand.Parameters.Add("@txtsat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtsat"].Value = txtsat;

        

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


        public DataSet checkedtiontxt(string compcode, string editoncode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkedtiontxt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@editoncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editoncode"].Value = editoncode;

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






        public DataSet chkyear(string year, string compcode, string txteditionname)
 
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkyearcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@year1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@year1"].Value = year;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = txteditionname;

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

        public DataSet spname(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_SpName", ref objSqlConnection);
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
        public DataSet filldatatype(string hiddencomcode, string hiddenuserid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindadtypeforedition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = hiddenuserid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = hiddencomcode;



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
