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
/// Summary description for SupplimentMaster
/// </summary>
namespace NewAdbooking.Classes
{
public class SupplimentMaster:connection
{
	public SupplimentMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
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

    public DataSet supptyp(string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("Bind_supptyp", ref objSqlConnection);
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




		public DataSet SubPub()
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
 
//				objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
//				objSqlCommand.Parameters["@edit"].Value =edit;
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
 
				//				objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
				//				objSqlCommand.Parameters["@dist"].Value =dist;
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

    public DataSet ModifyValue(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid, string uom, string column, string height, string width, string area, string periodicity,string supptyp, string gut, string col,string hr, string min, string pro,string epaper,string shortname)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("websp_Supplementmodify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@PubName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PubName"].Value =PubName;
			
				objSqlCommand.Parameters.Add("@EditionName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@EditionName"].Value =EditonName;

		    	objSqlCommand.Parameters.Add("@SuppName ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SuppName "].Value =SuppName;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias "].Value =Alias;

				objSqlCommand.Parameters.Add("@SuppCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SuppCode"].Value =SuppCode;

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

                objSqlCommand.Parameters.Add("@supptypcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@supptypcode"].Value = supptyp;

                objSqlCommand.Parameters.Add("@gut", SqlDbType.VarChar);
                objSqlCommand.Parameters["@gut"].Value = gut;

                objSqlCommand.Parameters.Add("@col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@col"].Value = col;

                objSqlCommand.Parameters.Add("@hr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hr"].Value = hr;

                objSqlCommand.Parameters.Add("@min", SqlDbType.VarChar);
                objSqlCommand.Parameters["@min"].Value = min;

                objSqlCommand.Parameters.Add("@pro", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pro"].Value = pro;


                objSqlCommand.Parameters.Add("@eapaper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@eapaper"].Value = epaper;


                objSqlCommand.Parameters.Add("@SHORTNAME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SHORTNAME"].Value = shortname;

								
							
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

		public DataSet InsertValue(string PubName,string EditonName,string SuppName,string Alias,string SuppCode,string compcode,string userid,string uom,string column,string height,string width,string area,string periodicity,string supptyp, string gut, string col, string hr, string min, string pro,string epaper,string shortname)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("websp_Supplementinsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@PubName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PubName"].Value =PubName;
			
				objSqlCommand.Parameters.Add("@EditonName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@EditonName"].Value =EditonName;
            
                objSqlCommand.Parameters.Add("@SuppName ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SuppName "].Value =SuppName;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias "].Value =Alias;

				objSqlCommand.Parameters.Add("@SuppCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SuppCode"].Value =SuppCode;

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

                objSqlCommand.Parameters.Add("@supptypcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@supptypcode"].Value = supptyp;

                objSqlCommand.Parameters.Add("@gut", SqlDbType.VarChar);
                objSqlCommand.Parameters["@gut"].Value = gut;

                objSqlCommand.Parameters.Add("@col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@col"].Value = col;

                objSqlCommand.Parameters.Add("@hr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hr"].Value = hr;

                objSqlCommand.Parameters.Add("@min", SqlDbType.VarChar);
                objSqlCommand.Parameters["@min"].Value = min;

                objSqlCommand.Parameters.Add("@prod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prod"].Value = pro;

                objSqlCommand.Parameters.Add("@eapaper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@eapaper"].Value = epaper;


                objSqlCommand.Parameters.Add("@shortname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@shortname"].Value = shortname;
							
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



    public DataSet getRO(string PubName, string compcode)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("getRO", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@PubName", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PubName"].Value = PubName;

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







    public DataSet SelectValue(string PubName, string EditonName, string SuppName, string Alias, string SuppCode, string compcode, string userid, string uom, string column, string height, string width, string area, string periodicity,string supptyp, string gut, string col, string hr, string min, string pro)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("websp_SupplementSelect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@PubName", SqlDbType.VarChar);
				//if(@PubName=="" ||@PubName==null || @PubName=="0")
				{
				//	objSqlCommand.Parameters["@PubName"].Value ="%%";		
				}
				//else
				{
					objSqlCommand.Parameters["@PubName"].Value =PubName;
				}
				
				
				
			
				objSqlCommand.Parameters.Add("@EditonName", SqlDbType.VarChar);
				//if(@EditonName=="" ||@EditonName==null||@EditonName=="0")
				{
			//		objSqlCommand.Parameters["@EditonName"].Value ="%%";
				}
			//	else
				{
					objSqlCommand.Parameters["@EditonName"].Value =EditonName;
				}

			
				objSqlCommand.Parameters.Add("@SuppName ", SqlDbType.VarChar);
				//if(@SuppName ==""||@SuppName ==null)
				{
				//	objSqlCommand.Parameters["@SuppName "].Value ="%%";
				}
				//else
				{
					objSqlCommand.Parameters["@SuppName "].Value =SuppName;
				}


				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				//if(@Alias=="" ||@Alias==null)
				{
				//	objSqlCommand.Parameters["@Alias "].Value ="%%";
				}
				//else
				{
					objSqlCommand.Parameters["@Alias "].Value =Alias;
				}

				objSqlCommand.Parameters.Add("@SuppCode", SqlDbType.VarChar);
				//if(@SuppCode==""||@SuppCode==null)
				{
				//	objSqlCommand.Parameters["@SuppCode"].Value ="%%";
				}
				//else
				{
					objSqlCommand.Parameters["@SuppCode"].Value =SuppCode;
				}

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);

               // if (uom == "0" || uom == null || uom == "undefined")
                {
               //     objSqlCommand.Parameters["@uom"].Value = "%%";
                }
               // else
                {

                    objSqlCommand.Parameters["@uom"].Value = uom;
                }

                objSqlCommand.Parameters.Add("@column", SqlDbType.VarChar);

               // if (column == "" || column == null || column == "undefined")
                {
               //     objSqlCommand.Parameters["@column"].Value = "%%";
                }
              //  else
                {

                    objSqlCommand.Parameters["@column"].Value = column;
                }

                objSqlCommand.Parameters.Add("@height", SqlDbType.VarChar);

               // if (height == "" || height == null || height == "undefined")
                {
               //     objSqlCommand.Parameters["@height"].Value = "%%";
                }
             //   else
                {

                    objSqlCommand.Parameters["@height"].Value = height;
                }

                objSqlCommand.Parameters.Add("@width", SqlDbType.VarChar);

              //  if (width == "" || width == null || width == "undefined")
                {
              //      objSqlCommand.Parameters["@width"].Value = "%%";
                }
              //  else
                {

                    objSqlCommand.Parameters["@width"].Value = width;
                }

                objSqlCommand.Parameters.Add("@area", SqlDbType.VarChar);

               // if (area == "" || area == null || area == "undefined")
                {
             //       objSqlCommand.Parameters["@area"].Value = "%%";
                }
             //   else
                {

                    objSqlCommand.Parameters["@area"].Value = area;


                }

                objSqlCommand.Parameters.Add("@periodicity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@periodicity"].Value = periodicity;

                objSqlCommand.Parameters.Add("@supptypcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@supptypcode"].Value = supptyp;

                objSqlCommand.Parameters.Add("@gut", SqlDbType.VarChar);
                objSqlCommand.Parameters["@gut"].Value = gut;

                objSqlCommand.Parameters.Add("@col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@col"].Value = col;

                objSqlCommand.Parameters.Add("@hr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hr"].Value = hr;

                objSqlCommand.Parameters.Add("@min", SqlDbType.VarChar);
                objSqlCommand.Parameters["@min"].Value = min;

                objSqlCommand.Parameters.Add("@pro", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pro"].Value = pro;

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

		public DataSet Selectfnpl(string PubName,string EditonName,string SuppName,string Alias,string SuppCode,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("websp_supplementfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				//objSqlCommand.Parameters.Add("@PubName", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@PubName"].Value =PubName;

				
				//				objSqlCommand.Parameters.Add("@SuppName", SqlDbType.VarChar);
				//				objSqlCommand.Parameters["@SuppName"].Value =SuppName;

				//objSqlCommand.Parameters.Add("@CityName ", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@CityName "].Value =CityName ;


				//objSqlCommand.Parameters.Add("@EditionName ", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@EditionName "].Value =EditionName;

				//objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@Alias "].Value =Alias;

				//objSqlCommand.Parameters.Add("@EditonCode", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@EditonCode"].Value =EditonCode;

								
							
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

		public DataSet checksupcode(string compcode,string suppcode,string userid, string pubcode, string editioncode)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checksupplementcode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@suppcode"].Value =suppcode;

												
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                //objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                //objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@editioncode"].Value = editioncode;

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

		public DataSet 	selecteditiondaymodify(string compcode,string suppcode,string sun,string mon,string tue,string wed,string thu,string fri,string sat,string all,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("supplementdaymodify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@suppcode"].Value =suppcode;

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

		public DataSet 	editiondaysave(string compcode,string suppcode,string sun,string mon,string tue,string wed,string thu,string fri,string sat,string all,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("supplementdaysave", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@suppcode"].Value =suppcode;

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



		public DataSet 	chksupcode(string SuppName,string SuppCode,string Alias,string compcode,string userid,string pubname,string editionname)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chksupcode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@SuppCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SuppCode"].Value =SuppCode;

												
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;

                objSqlCommand.Parameters.Add("@editionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editionname"].Value = editionname;

                objSqlCommand.Parameters.Add("@SuppName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SuppName"].Value = SuppName;

                objSqlCommand.Parameters.Add("@Alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Alias"].Value = Alias;

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

		public DataSet 	supdel(string SuppCode,string compcode,string userid,string pubcode,string editioncode)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("supplimentdel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@SuppCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SuppCode"].Value =SuppCode;

												
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

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


    public DataSet chkcsupcode1(string str,string editstr,string pubeditstr)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chksuppcode", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = str;

            objSqlCommand.Parameters.Add("@editstr", SqlDbType.VarChar);
            objSqlCommand.Parameters["@editstr"].Value = editstr;

            objSqlCommand.Parameters.Add("@pubeditstr", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pubeditstr"].Value = pubeditstr;



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


    public DataSet countedition(string editioncode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("filledition1", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@editioncode"].Value = editioncode;

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


    public DataSet chkedition(string pubcode, string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("checkpublicationcode", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pubcode"].Value = pubcode;
            objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
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












    public DataSet countcity(string edition)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("fillcity1", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

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


    public DataSet addedition(string pubname)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("fill_editionalias", ref objSqlConnection);
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

    public DataSet findedition(string editname)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("fill_supplalias", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@editname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@editname"].Value = editname;

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

    public DataSet inserteditname(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string dateformat)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("insertsuppdate", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@txteditionname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@txteditionname"].Value = txteditionname;

            objSqlCommand.Parameters.Add("@txtdate", SqlDbType.VarChar);
            if (txtdate == "" || txtdate == null)
            {
                objSqlCommand.Parameters["@txtdate"].Value = System.DBNull.Value;
            }
            else
            {
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = txtdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    txtdate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = txtdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    txtdate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@txtdate"].Value = txtdate;
            }
           // objSqlCommand.Parameters["@txtdate"].Value = txtdate;//Convert.ToDateTime(txtdate);

            objSqlCommand.Parameters.Add("@txtaddate", SqlDbType.VarChar);
            if (txtaddate == "" || txtaddate == null)
            {
                objSqlCommand.Parameters["@txtaddate"].Value = System.DBNull.Value;
            }
            else
            {
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = txtaddate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    txtaddate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = txtaddate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    txtaddate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@txtaddate"].Value = txtaddate;
            }
            //objSqlCommand.Parameters["@txtaddate"].Value = txtaddate;
          

            objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@suppcode"].Value = suppcode;

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

    public DataSet selectedfromgrid(string suppcode, string compcode, string userid, string code10)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("selectfromsuppdate", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@suppcode"].Value = suppcode;



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

    public DataSet gridupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string code10)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("updatesuppdate", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@txteditionname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@txteditionname"].Value = txteditionname;

            objSqlCommand.Parameters.Add("@txtdate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@txtdate"].Value =txtdate;



            objSqlCommand.Parameters.Add("@txtaddate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@txtaddate"].Value = txtaddate;
           

            objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@suppcode"].Value = suppcode;

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

    public DataSet griddelete(string suppcode, string compcode, string userid, string code10)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("deletegridsuppdate", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@suppcode"].Value = suppcode;

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
    public DataSet chkdaetedit(string compcode, string suppcode, string fdate, string sdate)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkdatesupp", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@suppcode"].Value = suppcode;

            objSqlCommand.Parameters.Add("@fdate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@fdate"].Value = fdate;

            objSqlCommand.Parameters.Add("@sdate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@sdate"].Value = sdate;


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

    public DataSet chkdateupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string suppcode, string code10)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkdatesuppupdate", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@txteditionname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@txteditionname"].Value = txteditionname;

            objSqlCommand.Parameters.Add("@txtdate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@txtdate"].Value =txtdate;

            objSqlCommand.Parameters.Add("@txtaddate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@txtaddate"].Value = txtaddate;
           

            objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@suppcode"].Value = suppcode;

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
            objSqlCommand = GetCommand("bindsuppdate", ref objSqlConnection);
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


    public DataSet filleditalias(string suppcode, string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("fillsuppalias", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@suppcode"].Value = suppcode;




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
    public DataSet chkperiodicty(string periodicty)
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
    public DataSet chkperiodicty_edition(string supplement)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkperiodictysupplement", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@supplement", SqlDbType.VarChar);
            objSqlCommand.Parameters["@supplement"].Value = supplement;





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












	}
}
