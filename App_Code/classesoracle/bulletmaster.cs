using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for bulletmaster
/// </summary>
    public class bulletmaster : orclconnection 
{
	public bulletmaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet advpub(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("Bind_PubName.Bind_PubName_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (OracleException objException)
        {
            throw (objException);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }



    public DataSet bindedition11(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindedition1", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);




            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }



    public DataSet duplicay1(string pcompcode, string pdesigntypecode, string validfrom ,string validto)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("duplicaybulletbind", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = pcompcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("pdesigntypecode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = pdesigntypecode;
            objOraclecommand.Parameters.Add(prm2);



            OracleParameter prm3 = new OracleParameter("pvalidfrom", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;

            string dateformat = "dd/mm/yyyy";
            if (dateformat == "dd/mm/yyyy")
            {
                string[] arr = validfrom.Split('/');
                string dd = arr[2];
                string mm = arr[1];
                string yy = arr[0];
                validfrom = mm + "/" + dd + "/" + yy;
            }


            prm3.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy"); 
            objOraclecommand.Parameters.Add(prm3);



            OracleParameter prm4 = new OracleParameter("pvalidto", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;

        
            if (dateformat == "dd/mm/yyyy")
            {
                string[] arr = validto.Split('/');
                string dd = arr[2];
                string mm = arr[1];
                string yy = arr[0];
                validto = mm + "/" + dd + "/" + yy;
            }


            prm4.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy");
            objOraclecommand.Parameters.Add(prm4);










           

          

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;












            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }






    public DataSet Delete(string compcode, string amount)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("delbullet", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcoed", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("pamount", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = amount;
            objOraclecommand.Parameters.Add(prm2);



            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {

            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }




    public DataSet logobind(string compcode, string logocode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bulletbind", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("plogoprcode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = logocode;
            objOraclecommand.Parameters.Add(prm2);




            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }





    public DataSet update1(string COMP_CODE, string USERID, string LOGOPREMIUM_CODE, string EDITION, string AMOUNT, string PREMIUM, string hdnsequenceno,string validfrom,string validto,string publication)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bulletchild", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pCOMP_CODE", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = COMP_CODE;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("pUSERID", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = USERID;
            objOraclecommand.Parameters.Add(prm2);



            OracleParameter prm3 = new OracleParameter("pLOGOPREMIUM_CODE", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = LOGOPREMIUM_CODE;
            objOraclecommand.Parameters.Add(prm3);



            OracleParameter prm4 = new OracleParameter("pEDITION", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = EDITION;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("pPREMIUM", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = PREMIUM;
            objOraclecommand.Parameters.Add(prm5);


            OracleParameter prm6 = new OracleParameter("pAMOUNT", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = AMOUNT;
            objOraclecommand.Parameters.Add(prm6);



            OracleParameter prm7 = new OracleParameter("pseq", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = hdnsequenceno;
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pvalidfrom", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = validfrom;


            string dateformat = "dd/mm/yyyy";
            if (dateformat == "dd/mm/yyyy")
            {
                string[] arr = validfrom.Split('/');
                string dd = arr[2];
                string mm = arr[1];
                string yy = arr[0];
                validfrom = mm + "/" + dd + "/" + yy;
            }




            prm8.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy"); 




            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("pvalidto", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = validto;


            if (dateformat == "dd/mm/yyyy")
            {
                string[] arr = validto.Split('/');
                string dd = arr[2];
                string mm = arr[1];
                string yy = arr[0];
                validto = mm + "/" + dd + "/" + yy;
            }




            prm9.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy"); 
            objOraclecommand.Parameters.Add(prm9);



            OracleParameter prm10 = new OracleParameter("p_publication", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = publication;
            objOraclecommand.Parameters.Add(prm10);





            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }





    public DataSet save1(string compcode, string userid, string logoprem, string edition, string premimum, string amount,string validfrom ,string validto,string publication)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("savebulletchild", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pCOMP_CODE", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("pUSERID", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);



            OracleParameter prm3 = new OracleParameter("pbulletPREMIUM_CODE", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = logoprem;
            objOraclecommand.Parameters.Add(prm3);



            OracleParameter prm4 = new OracleParameter("pEDITION", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = edition;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("pPREMIUM", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = premimum;
            objOraclecommand.Parameters.Add(prm5);


            OracleParameter prm6 = new OracleParameter("pAMOUNT", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = amount;
            objOraclecommand.Parameters.Add(prm6);



            OracleParameter prm7 = new OracleParameter("pvalidfrom", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;


            if (validfrom == "")
            {
                prm7.Value = System.DBNull.Value; 
            }

            else
            {
                string dateformat = "dd/mm/yyyy";
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validfrom.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validfrom = mm + "/" + dd + "/" + yy;
                }




                prm7.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy"); 
            }
            objOraclecommand.Parameters.Add(prm7);




            OracleParameter prm8 = new OracleParameter("pvalidto", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            if (validto == "")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {

                string dateformat = "dd/mm/yyyy";
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validto.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validto = mm + "/" + dd + "/" + yy;
                }





                prm8.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy"); 
            }



            OracleParameter prm9 = new OracleParameter("ppublication", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = publication;
            objOraclecommand.Parameters.Add(prm9);

          
            objOraclecommand.Parameters.Add(prm8);













            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }




    public DataSet logobind1(string compcode, string logocode, string bulletcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bulletbind1", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pamount", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = logocode;
            objOraclecommand.Parameters.Add(prm2);





            OracleParameter prm3 = new OracleParameter("pbulletcode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = bulletcode;
            objOraclecommand.Parameters.Add(prm3);

         




            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }










	public DataSet checkrevcode(string comcode,string bulletdesc,string compcode,string userid, string pubcenter)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("checkbullet.checkbullet_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3 = new OracleParameter("comcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = comcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm1 = new OracleParameter("bulletdesc", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bulletdesc;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


				
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
		}

        //public DataSet insertintobullet(string bulletcode,string advtype,string edition,string bulletdesc,string bulletcharge,string bullettext,string remarks,string listboxvalue,string validatedate,string validatetill,string compcode,string userid)
    public DataSet insertintobullet(string bulletcode, string bulletdesc, string bulletcharge, string bullettext, string remarks, string validatedate, string validatetill, string compcode, string userid, string sumble, string pubcenter, string font, string adcat, string fontcol,string pubcode,string editioncode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("insertbullet.insertbullet_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;





                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("bulletcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bulletcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm4 = new OracleParameter("bulletdesc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bulletdesc;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("bulletcharge", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = bulletcharge;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("bullettext", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = bullettext;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("remarks", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = remarks;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("sumble", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = sumble;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("validatedate", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = Convert.ToDateTime(validatedate).ToString("dd-MMMM-yyyy"); 
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm19 = new OracleParameter("validatetill", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                if (validatetill != "" && validatetill != null)
                {
                    prm19.Value = Convert.ToDateTime(validatetill).ToString("dd-MMMM-yyyy"); 
                }
                else
                {
                    prm19.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm81 = new OracleParameter("font", OracleType.VarChar, 50);
                prm81.Direction = ParameterDirection.Input;
                prm81.Value = font;
                objOraclecommand.Parameters.Add(prm81);

                OracleParameter prm22 = new OracleParameter("adcat", OracleType.VarChar, 2000);
                prm22.Direction = ParameterDirection.Input;
                if (adcat == "" || adcat == "0")
                    prm22.Value = System.DBNull.Value;
                else
                    prm22.Value = adcat;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm811 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm811.Direction = ParameterDirection.Input;
                prm811.Value = editioncode;
                objOraclecommand.Parameters.Add(prm811);

                OracleParameter prm821 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm821.Direction = ParameterDirection.Input;
                prm821.Value = pubcode;
                objOraclecommand.Parameters.Add(prm821);

                OracleParameter prm812 = new OracleParameter("fontcolor", OracleType.VarChar, 50);
                prm812.Direction = ParameterDirection.Input;
                prm812.Value = fontcol;
                objOraclecommand.Parameters.Add(prm812);

                OracleParameter prm8121 = new OracleParameter("ppackagecode", OracleType.VarChar, 50);
                prm8121.Direction = ParameterDirection.Input;
                prm8121.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8121);

				
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
		}

    public DataSet executebulletmast(string bulletcode, string bulletdesc, string bulletcharge, string bullettext, string compcode, string userid, string pubcenter, string dateformat, string adcat)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();	
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("executebulletbullet.executebulletbullet_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("bulletcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bulletcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm4 = new OracleParameter("bulletdesc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bulletdesc;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("bulletcharge", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (bulletcharge=="0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                prm5.Value = bulletcharge;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("bullettext", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = bullettext;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if(pubcenter=="0")
                    prm7.Value = System.DBNull.Value;
                else
                    prm7.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm622 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm622.Direction = ParameterDirection.Input;
                prm622.Value = dateformat;
                objOraclecommand.Parameters.Add(prm622);

                OracleParameter prm22 = new OracleParameter("adcat", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                if (adcat == "" || adcat == "0")
                    prm22.Value = System.DBNull.Value;
                else
                    prm22.Value = adcat;
                objOraclecommand.Parameters.Add(prm22);

                //OracleParameter prm61 = new OracleParameter("font", OracleType.VarChar, 50);
                //prm61.Direction = ParameterDirection.Input;
                //prm61.Value = font;
                //objOraclecommand.Parameters.Add(prm61);


                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;
				
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
		}

		public DataSet bulletfirst()
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("firstbullet.firstbullet_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
 
								
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
		}

        public DataSet updateinbullet(string bulletcode, string bulletdesc, string bulletcharge, string bullettext, string remarks, string validatedate, string validatetill, string compcode, string userid, string sumble, string pubcenter, string font, string adcat, string fontcol,string pubcode,string edi)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("updatebullet.updatebullet_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("bulletcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bulletcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm4 = new OracleParameter("bulletdesc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bulletdesc;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("bulletcharge", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = bulletcharge;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("bullettext", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = bullettext;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("remarks", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = remarks;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("sumble", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = sumble;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("validatedate", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = Convert.ToDateTime(validatedate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm19 = new OracleParameter("validatetill", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                if (validatetill != "" && validatetill != null)
                {
                    prm19.Value = Convert.ToDateTime(validatetill).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm19.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm201 = new OracleParameter("font1", OracleType.VarChar, 50);
                prm201.Direction = ParameterDirection.Input;
                prm201.Value = font;
                objOraclecommand.Parameters.Add(prm201);

                OracleParameter prm22 = new OracleParameter("adcat", OracleType.VarChar,2000 );
                prm22.Direction = ParameterDirection.Input;
                if(adcat=="" || adcat=="0")
                    prm22.Value = System.DBNull.Value;
                else
                    prm22.Value = adcat;
                objOraclecommand.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("fontcolor", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = fontcol;
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm213 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm213.Direction = ParameterDirection.Input;
                prm213.Value = pubcode;
                objOraclecommand.Parameters.Add(prm213);


                OracleParameter prm231 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm231.Direction = ParameterDirection.Input;
                prm231.Value = edi;
                objOraclecommand.Parameters.Add(prm231);

                OracleParameter prm230 = new OracleParameter("ppackagecode", OracleType.VarChar, 50);
                prm230.Direction = ParameterDirection.Input;
                prm230.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm230);


				
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
		}


		public void deletevalue(string bulletcode,string compcode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();	
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("deletebullet.deletebullet_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 
				


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("bulletcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bulletcode;
                objOraclecommand.Parameters.Add(prm2);





                objOraclecommand.ExecuteNonQuery();
                //objmysqlDataAdapter.SelectCommand = objOraclecommand;
                //objmysqlDataAdapter.Fill(objDataSet);

                //return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
		}

		public DataSet checkmultibull(string compcode,string userid,string adsizecode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("checkmultiselectbullet.checkmultiselectbullet_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("adsizecode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adsizecode;
                objOraclecommand.Parameters.Add(prm4);
				
				
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
		}
		public DataSet chkinsbull(string compcode,string userid,string adsizecode,string abc)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("insertmultibullet.insertmultibullet_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("adsizecode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adsizecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("abc", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = abc;
                objOraclecommand.Parameters.Add(prm5);

				

			

				

				

				
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
		}


        
        
        public DataSet countbulletcode(string str, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkbulletcodename.chkbulletcodename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm3 = new OracleParameter("str", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = str;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0, 2);
                }
                else
                {
                    prm2.Value = str;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm41 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm42);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet getlistad_cat(string xyz, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("book_advcategory.book_advcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("booking", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = xyz;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

               

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }


        /********************************************/


        public DataSet countbulletname(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkbulletname.chkbulletname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

             

                OracleParameter prm3 = new OracleParameter("str", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = str;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length >2)
                {
                prm2.Value = str.Substring (0,2);
                }
                else
                {
                    prm2.Value = str;

                }
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }



		public DataSet listboxbullupdate(string compcode,string userid,string adsizecode,string abc)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();	
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("updatemultibullet.updatemultibullet_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("adsizecode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adsizecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("abc", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = abc;
                objOraclecommand.Parameters.Add(prm5);

				
 

				

				
				
				objmysqlDataAdapter.SelectCommand = objOraclecommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                objOracleConnection.Close();
			}
        }


        public DataSet duplicay1(string pcompcode, string pdesigntypecode, string validfrom, string validto, String publication)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("duplicaybulletbind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pdesigntypecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pdesigntypecode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("pvalidfrom", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;

                string dateformat = "dd/mm/yyyy";
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validfrom.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validfrom = mm + "/" + dd + "/" + yy;
                }


                prm3.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pvalidto", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;


                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validto.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validto = mm + "/" + dd + "/" + yy;
                }


                prm4.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);




                OracleParameter prm5 = new OracleParameter("p_publication", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;

                if (publication == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = publication;
                }

                objOraclecommand.Parameters.Add(prm5);









                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;












                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }



        public DataSet getSymbol(string bulletcode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getSymbol.getSymbol_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;                


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("bulletcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bulletcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet pubcenter(string pcompcode, string ppcenter, string puserid, string pdateformat, string pextra1, string pextra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcenter_wise_detail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppcenter", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ppcenter;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = puserid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pdateformat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pextra1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pextra2;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }
	}
}

