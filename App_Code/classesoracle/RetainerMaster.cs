using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for RetainerMaster
/// </summary>
    public class RetainerMaster : orclconnection
{
	public RetainerMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	public DataSet checkpopupdata(string compcode,string retcode,string userid2)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            
			try
			{
                objOracleConnection.Open();

                objOraclecommand = GetCommand("checkpopup.checkpopup_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Retain_Code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid2;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("P_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts2"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("P_Accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts3"].Direction = ParameterDirection.Output;

		
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
			}
			catch(OracleException  e)
			{
				throw(e);
			}
			finally
			{
                CloseConnection(ref objOracleConnection);
			}
			
		}


    public DataSet addstatusname(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bind_status.bind_status_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



           
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

    public DataSet filldatapay(string hiddencomcode, string hiddenuserid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("retainer_payfill.retainer_payfill_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = hiddenuserid;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = hiddencomcode;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




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


    public DataSet bindmaincdp(string compcode, string unit, string cdp, string name, string userid, string extra1, string extra2)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("ad_fa_retainer_ledger_bind", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("pcomp_code", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = compcode;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm1 = new OracleParameter("punit", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = unit;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pcdp", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = cdp;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm4 = new OracleParameter("pname", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = name;
            objOraclecommand.Parameters.Add(prm4);


            OracleParameter prm5 = new OracleParameter("puserid", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = userid;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("pextra1", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = extra1;
            objOraclecommand.Parameters.Add(prm6);


            OracleParameter prm7 = new OracleParameter("pextra2", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = extra2;
            objOraclecommand.Parameters.Add(prm7);



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


    public DataSet cashback_cds(string compcode, string unit, string cdp, string name, string extra1, string extra2)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("ad_fa_subledger_bind", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = unit;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pcdp", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = cdp;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("pname", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = name;
            objOraclecommand.Parameters.Add(prm4);


            OracleParameter prm5 = new OracleParameter("pextra1", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = extra1;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("pextra2", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = extra2;
            objOraclecommand.Parameters.Add(prm6);



            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            objOracleConnection.Close();

        }
    }

    public DataSet agcode(string compcode, string name, string unit, string cdp, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("ad_agency_bind_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pag_name", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = name;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = cdp;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = unit;
            objOraclecommand.Parameters.Add(prm4);


            OracleParameter prm5 = new OracleParameter("pextra1", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("pextra2", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pextra3", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("pextra4", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm9 = new OracleParameter("pextra5", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm9);



            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            objOracleConnection.Close();

        }
    }

				
		//check if the user is already present or not 
		public DataSet checkRetaineruser(string retcode,string userid,string compcode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkretainerdata.checkretainerdata_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Retain_Code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


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



		//Save the data to the retainer master
        public DataSet RetainerStore(string compcode, string retcode, string retname, string retalias, string add1, string street, string citycode, string pubcent, string zip, string dist, string state, string zone, string region, string country, string phone1, string phone2, string fax, string email, string pan, string creditdays, string remarks, string userid, int flag, string Box, string publication, string edition, string supplement, string taluka, string repname, string branchcode, string creditlimit, string mobile, string signature, string empcode, string attachment, string maincdp, string name, string contactnam, string oldcode, string accode, string gstus, string gstdt, string gstin, string gstatus, string gstcltype, string pextra1)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RetainerInsertDetail.RetainerInsertDetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Comp_Code1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Retain_Code1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Retain_Name1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = retname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("Retain_Alias1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = retalias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Add11", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = add1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("Street1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = street;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("City_Code1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = citycode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pubcent", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pubcent;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("Zip1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = zip;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("Dist_Code1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = dist;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("State_Code1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = state;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("zone_code1", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = zone;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("region_code1", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = region;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("Country_Code1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = country;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("phone11", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = phone1;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("Phone21", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = phone2;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("Fax1", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = fax;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("EmailID1", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = email;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("PAN_No1", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = pan;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("Credit_Days1", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = creditdays;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("Remarks1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = remarks;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("userid1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = userid;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("flag", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = flag;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("Box", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = Box;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm41 = new OracleParameter("Publication1", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = publication;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("Edition1", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = edition;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("Supplement1", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = supplement;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("taluka1", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = taluka;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("repname", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = repname;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("branchcode", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = branchcode;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("creditlimit", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                if (creditlimit == "")
                    prm47.Value = System.DBNull.Value;
                else
                    prm47.Value = creditlimit;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm48 = new OracleParameter("mobile1", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                prm48.Value = mobile;
                objOraclecommand.Parameters.Add(prm48);


                OracleParameter prm49 = new OracleParameter("signature", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                prm49.Value = signature;
                objOraclecommand.Parameters.Add(prm49);


                OracleParameter prm50 = new OracleParameter("p_empcode", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = empcode;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm56 = new OracleParameter("pattachment", OracleType.VarChar);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = attachment;
                objOraclecommand.Parameters.Add(prm56);


                OracleParameter prm51 = new OracleParameter("p_maincdp", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = maincdp;
                objOraclecommand.Parameters.Add(prm51);

                //OracleParameter prm500 = new OracleParameter("p_maincds", OracleType.VarChar);
                //prm500.Direction = ParameterDirection.Input;
                //prm500.Value = maincds;
                //objOraclecommand.Parameters.Add(prm500);

                OracleParameter prm52 = new OracleParameter("p_retname", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = name;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("p_contacname", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = contactnam;
                objOraclecommand.Parameters.Add(prm53);


                OracleParameter prm54 = new OracleParameter("poldcode", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = oldcode;
                objOraclecommand.Parameters.Add(prm54);


                OracleParameter prm55 = new OracleParameter("paccode", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = accode;
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm61 = new OracleParameter("gst_registration", OracleType.VarChar);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = gstus;
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm57 = new OracleParameter("gst_registration_date", OracleType.VarChar);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = gstdt;
                objOraclecommand.Parameters.Add(prm57);
            

                OracleParameter prm58 = new OracleParameter("gstin", OracleType.VarChar);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = gstin;
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59 = new OracleParameter("gstapp", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                prm59.Value = gstatus;
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("gst_client_type_cd", OracleType.VarChar);
                prm60.Direction = ParameterDirection.Input;
                prm60.Value = gstcltype;
                objOraclecommand.Parameters.Add(prm60);


                OracleParameter prm641 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm641.Direction = ParameterDirection.Input;
                prm641.Value = pextra1;
                objOraclecommand.Parameters.Add(prm641);



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

    public DataSet retstatuscheck(string compcode, string userid, string retcode, string status, string circular, string todate, string fromdate, string dateformat, string codepass)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("retstatuschk.retstatuschk_P", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = retcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm4 = new OracleParameter("status", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = status;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5= new OracleParameter("circular", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = circular;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value =Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("todate", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("date1", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = dateformat;
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm9 = new OracleParameter("codepass", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = codepass;
            objOraclecommand.Parameters.Add(prm9);

            objOraclecommand.Parameters.Add("P_ACCOUNTs", OracleType.Cursor);
            objOraclecommand.Parameters["P_ACCOUNTs"].Direction = ParameterDirection.Output;

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



    public DataSet retstatuscheck1(string compcode, string retcode, string todate, string fromdate, string dateformat, string codepass, string txtframt, string txttoamt)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("retcomchk.retcomchk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

               

                OracleParameter prm1 = new OracleParameter("v_compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

              

                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("todate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("date_format", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dateformat;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("codepass", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = codepass;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("txtframt", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = txtframt;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("txttoamt", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = txttoamt;
                objOraclecommand.Parameters.Add(prm11);

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

    public void insertData(string compcode, string retcode, string userid, int i, string strMode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("updateRetPay.updateRetPay_p", ref objOracleConnection);
           objOraclecommand.CommandType = CommandType.StoredProcedure;

           OracleParameter prm1 = new OracleParameter("Cash", OracleType.VarChar);
           prm1.Direction = ParameterDirection.Input;
           prm1.Value = strMode;
           objOraclecommand.Parameters.Add(prm1);

           OracleParameter prm2 = new OracleParameter("Comp_Code", OracleType.VarChar);
           prm2.Direction = ParameterDirection.Input;
           prm2.Value = compcode;
           objOraclecommand.Parameters.Add(prm2);

           OracleParameter prm3 = new OracleParameter("retcode", OracleType.VarChar);
           prm3.Direction = ParameterDirection.Input;
           prm3.Value = retcode;
           objOraclecommand.Parameters.Add(prm3);

           OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar);
           prm4.Direction = ParameterDirection.Input;
           prm4.Value = userid;
           objOraclecommand.Parameters.Add(prm4);

           OracleParameter prm5 = new OracleParameter("Flag", OracleType.VarChar);
           prm5.Direction = ParameterDirection.Input;
           prm5.Value = i;
           objOraclecommand.Parameters.Add(prm5);

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            
        }
        catch (Exception ex) { throw (ex); }
        finally
        { CloseConnection(ref objOracleConnection); }
    }

    public DataSet selectretstatus(string retcode, string compcode, string userid, string code11, string dateformat)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("retselect.retselect_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = retcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm4 = new OracleParameter("code11", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = code11;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = dateformat;
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

    public DataSet selectretcomm(string retcode, string compcode, string userid, string code11, string dateformat)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("retcommselect.retcommselect_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = retcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm4 = new OracleParameter("code11", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = code11;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = dateformat;
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


    public DataSet retainerstatusbind(string retcode, string userid, string compcode, string dateformat)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("sp_retstatusbind.sp_retstatusbind_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = retcode;
            objOraclecommand.Parameters.Add(prm2);



            OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = dateformat;
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

		public DataSet RetDelete(string compcode,string Retcode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			
			try
			{
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RetainerDelete.RetainerDelete_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Retain_Code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Retcode;
                objOraclecommand.Parameters.Add(prm2);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
			}
			catch(Exception e)
			{
				throw(e);
			}
			finally
			{
                CloseConnection(ref objOracleConnection);
			}
			
		}

        public DataSet RetainerExecute(string compcode, string Retcode, string Retname, string alias, string city, string pubcent, string country, string Box, string repname, string branchname, string gstus, string gstdt, string gstin, string gstatus, string gstcltype)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RetainerExec.RetainerExec_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Retain_Code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("retname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Retname;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("retalias", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("citycode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (city == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = city;
                }
                    objOraclecommand.Parameters.Add(prm5);




                    OracleParameter prm6 = new OracleParameter("pubcent", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("country", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (country == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = country;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("box_matter", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = Box;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("repname", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = repname;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("branchname", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (branchname == "0")
                {
                     prm10.Value= System.DBNull.Value;
                }
                else
                {
                    prm10.Value = branchname;
                }
              
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("GST_REGISTRATION", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (gstus == "0")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = gstus;
                }

                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("GST_REGISTRATION_DATE", OracleType.DateTime);
                prm12.Direction = ParameterDirection.Input;
                if (gstdt == "0")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = gstdt;
                }

                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("GSTIN", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (gstin == "0")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = gstin;
                }

                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("GSTAPP", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (gstatus == "0")
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = gstatus;
                }

                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("GST_CLIENT_TYPE_CD", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (gstcltype == "0")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = gstcltype;
                }

                objOraclecommand.Parameters.Add(prm15);

                
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
			}
			catch(OracleException  e)
			{
				throw(e);
			}
			finally
			{
                CloseConnection(ref objOracleConnection);
			}
			
		}

		
		public DataSet RetainerNavigate(string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RetNavigate.RetNavigate_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
			}
			catch(OracleException  e)
			{
				throw(e);
			}
			finally
			{
                CloseConnection(ref objOracleConnection);
			}
			
		}
		
		//first,next,last previous 

		public DataSet getRecords(string compcode,string Retcode,string userid2)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("Retpayselect.Retpayselect_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Retcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Retcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid2;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                CloseConnection(ref objOracleConnection);
			}
		
		}



		/*Retainer Master Coding Ends*/

		/*===================================================================*/

		/*Pop up coding Starts*/

		/*Pop Up Paymode*/
		//GetData is used to retrieve the custcode from customer master
		public DataSet getData(string retcode,string userid,string compcode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("Retpayselect.Retpayselect_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Retcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                CloseConnection(ref objOracleConnection);
			}
			
		}



		//insert Data is used to insert/update values into temporary retainer payment table
//		public DataSet insertRetData(string  compcode,string retcode,string  userid,int i, params string[] strMode)
    public void insertRetData(string compcode, string retcode, string userid, int i, string strMode)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("updateRetPayment.updateRetPayment_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Cash", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = strMode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2= new OracleParameter("Comp_Code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Retain_Code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = retcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Flag", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = i;
                objOraclecommand.Parameters.Add(prm5);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

               
					
			}
			catch(Exception ex)
            {
                throw(ex);
            }
			finally
			{
                CloseConnection(ref objOracleConnection);
            }
		 }


		/*Paymode coding ends*/
		

		/*Commmission coding starts*/

		//DropDown Binding

		public DataSet commission()
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_comm_detail.websp_comm_detail_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

				
				objorclDataAdapter.SelectCommand = objOraclecommand;
				objorclDataAdapter.Fill(objDataSet);
				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objOracleConnection);
			}

		}
		
		//Datagrid Binding

		public DataSet RetainerCommBind(string retcode,string compcode, string userid,string dateformat)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("RetainerCommBind.RetainerCommBind_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("Comp_Code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Retain_Code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = retcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


				
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
			}
		
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref objOracleConnection);
			}
		
		}


		//Commission date Check 
		public DataSet checkdate(string retcode,string userid,string compcode,string txtefffrom,string txtefftill)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcommdate.chkcommdate_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("retcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2= new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4= new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtefffrom;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("tilldate", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtefftill;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
            { CloseConnection(ref objOracleConnection); }
		}

//comm date update
		public DataSet checkdateupdate(string retcode,string userid,string compcode,string txtefffrom,string txtefftill,string code)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcommdateupdate.chkcommdateupdate_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("retcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtefffrom;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("tilldate", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtefftill;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("code", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = code;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
            { CloseConnection(ref objOracleConnection); }
		}

		//Commission Data insert/Update
		public DataSet RetainerCommission(string retcode,string userid,string compcode,string txtefffrom,string txtefftill,string txtcommrate,string discount,string updatecommission,int flag,string frmamt,string toamt,string addcommrate)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("RetainerCommission.RetainerCommission_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Retain_Code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("effectivefrm", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Convert.ToDateTime(txtefffrom).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("efftill", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value =  Convert.ToDateTime(txtefftill).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("commrate", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtcommrate;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("discount", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = discount;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("codeid", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = updatecommission;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("flag", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = flag;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm71 = new OracleParameter("frmamt", OracleType.VarChar);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = frmamt;
                objOraclecommand.Parameters.Add(prm71);

                OracleParameter prm82 = new OracleParameter("toamt", OracleType.VarChar);
                prm82.Direction = ParameterDirection.Input;
                prm82.Value = toamt;
                objOraclecommand.Parameters.Add(prm82);

                OracleParameter prm83 = new OracleParameter("addcommrate", OracleType.VarChar);
                prm83.Direction = ParameterDirection.Input;
                prm83.Value = addcommrate;
                objOraclecommand.Parameters.Add(prm83);


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
            { CloseConnection(ref objOracleConnection); }
		
		}

		//Get the values with respect to dates 
		public DataSet getCommData(string compcode,string userid,string retcode,string codeid,int flag)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("GetRetComm.GetRetComm_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("retcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("codeid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = codeid;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("flag", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = flag;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
            { CloseConnection(ref objOracleConnection); }
		}

		/*Commmission coding ends*/


		/*Retainer Status Detail coding starts  */

		/*Bind the data to the datagrid during page load 
		 * & also to check the date whether the date is present or not*/
		public DataSet Ret_GetStatus(string retcode,string compcode, string userid,string date,string fromdate,string todate,string codestatusid,int flag)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("Ret_GetStatus.Ret_GetStatus_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Retain_Code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("date", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = date;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("txtfrom", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(fromdate);
                objOraclecommand.Parameters.Add(prm5);
                /*
				objOraclecommand.Parameters.Add("@txtfrom",SqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
					objOraclecommand.Parameters["@txtfrom"].Value = fromdate;
				}
				else
				{
					objOraclecommand.Parameters["@txtfrom"].Value = Convert.ToDateTime(fromdate);
				}*/

                OracleParameter prm6 = new OracleParameter("txtto", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert.ToDateTime(todate);
                objOraclecommand.Parameters.Add(prm6);
                /*
				objOraclecommand.Parameters.Add("@txtto",SqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
					objOraclecommand.Parameters["@txtto"].Value = todate;
				}
				else
				{
					objOraclecommand.Parameters["@txtto"].Value = Convert.ToDateTime(todate);
				}*/


                OracleParameter prm7= new OracleParameter("codestatusid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = codestatusid;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("flag", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = flag;
                objOraclecommand.Parameters.Add(prm8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;      
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
            { CloseConnection(ref objOracleConnection); }
		}

		public DataSet Ret_GetStatusupdate(string retcode,string compcode, string userid,string status, string circular, string todate,string fromdate,string code)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("Ret_GetStatusupdate.Ret_GetStatusupdate_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("retcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("status", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = status;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("circular", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = circular;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);
                /*
                objOraclecommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
                    objOraclecommand.Parameters["@fromdate"].Value = fromdate;
				}
				else
				{
                    objOraclecommand.Parameters["@fromdate"].Value = Convert.ToDateTime(fromdate);
				}*/

                OracleParameter prm7 = new OracleParameter("todate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm7);

                /*objOraclecommand.Parameters.Add("@todate", SqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
                    objOraclecommand.Parameters["@todate"].Value = todate;
				}
				else
				{
                    objOraclecommand.Parameters["@todate"].Value = Convert.ToDateTime(todate);
				}*/

                OracleParameter prm8 = new OracleParameter("code", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = code;
                objOraclecommand.Parameters.Add(prm8);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
            { CloseConnection(ref objOracleConnection); }
		}

		/*Insert ,Update & Delete operation */
		public DataSet Ret_StatusOperation(string userid,string compcode,string retcode,string statusname ,string fromdate,string todate,string circular,string codeid,int flag)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("RetStatusUpdate.RetStatusUpdate_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Retain_Code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("circular", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (circular == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = circular;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("statusname", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (statusname == "")
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = statusname;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (fromdate == "")
                    prm6.Value = System.DBNull.Value;
                else
                    prm6.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("todate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (todate == "")
                    prm7.Value = System.DBNull.Value;
                else
                    prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("codeid", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (codeid == "")
                    prm8.Value = System.DBNull.Value;
                else
                    prm8.Value = codeid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9= new OracleParameter("flag", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = flag;
                objOraclecommand.Parameters.Add(prm9);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
            { CloseConnection(ref objOracleConnection); }
		}


    public DataSet insertretstatus(string compcode, string userid, string retcode, string status, string fromdate, string todate, string circular)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("insertretstatus.insertretstatus_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("retcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = retcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = compcode;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("status", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = status;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("circular", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = circular;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm7 = new OracleParameter("todate", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            objOraclecommand.Parameters.Add(prm7);

       
            OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            objOraclecommand.Parameters.Add(prm6);

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





    public DataSet showchk(string compcode, string userid, string retcode)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("showchk.showchk_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = compcode;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm1 = new OracleParameter("retcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = retcode;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex) { throw (ex); }
        finally
        { CloseConnection(ref objOracleConnection); }
    }

    public DataSet chkretainercode(string str)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("chkretainername.chkretainername_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("str", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = str;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("cod", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (str.Length > 2)
            {
                prm4.Value = str.Substring(0, 2);
                objOraclecommand.Parameters.Add(prm4);
            }
            else
            {
                prm4.Value = str;
                objOraclecommand.Parameters.Add(prm4);
            }

            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


            objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;


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


    public DataSet chkretainercodemod(string strcode, string strname)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("chkretainernamemod.chkretainernamemod_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("strname", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            
             
           
                prm3.Value = strname;
               objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("strcode", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (strcode.Length > 2)
            {
                prm4.Value = strcode.Substring(0, 2);
            }
            else
            {
                prm4.Value = strcode;
            }
            objOraclecommand.Parameters.Add(prm4);

            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


            objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;



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

    public DataSet chkretainerusercode(string strcode, string strname)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("chkretaineruser.chkretaineruser_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("strname", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = strname;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("strcode", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = strcode;
            objOraclecommand.Parameters.Add(prm4);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
            objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;





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

    public DataSet addcitydist(string cityname)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("retaineraddregion.retaineraddregion_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm3 = new OracleParameter("regioncode", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = cityname;
            objOraclecommand.Parameters.Add(prm3);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts7", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts7"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts8", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts8"].Direction = ParameterDirection.Output;

            
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



        public DataSet addpubcent(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubCentName.Bind_PubCentName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


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


        public DataSet getPubName(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_Pubname.Bind_Pubname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }


        public DataSet getPubCName()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubCentName.Bind_PubCentName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }



        //**********This function is used to GET the Edition Name using stored procedure Bind_EdiName***************
        public DataSet getEdiName(string pubcode, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_EdiName.Bind_EdiName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3 = new OracleParameter("edit", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm4);
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }

        //**********************************************************************************************************

        //**********This function is used to GET the Suppliment using stored procedure bindsuppliment***************

        public DataSet getSuppliment(string pubcode, string pubedit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindsuppliment.bindsuppliment_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubedit;
                objOraclecommand.Parameters.Add(prm4);
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }
        //**********************************************************************************************************

        //public DataSet chkedition(string pubcode, string compcode, string userid)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("checkpublicationcode.checkpublicationcode_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;


        //        OracleParameter prm4 = new OracleParameter("pubcode", OracleType.VarChar, 50);
        //        prm4.Direction = ParameterDirection.Input;
        //        prm4.Value = pubcode;
        //        objOraclecommand.Parameters.Add(prm4);

        //        OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm1);


        //        OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
        //        prm3.Direction = ParameterDirection.Input;
        //        prm3.Value = userid;
        //        objOraclecommand.Parameters.Add(prm3);

        //        objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

        //        objorclDataAdapter.SelectCommand = objOraclecommand;
        //        objorclDataAdapter.Fill(objDataSet);

        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objOracleConnection);
        //    }

        //}

        public DataSet addedition(string pubname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fill_editionalias.fill_editionalias_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pubname;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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

        public DataSet countedition(string editioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getsupplement.getsupplement_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = editioncode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

		/*Retainer Status Detail coding ends*/

        public DataSet addrepname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getrepname", ref objOracleConnection);
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
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet retainerstatusbind_b(string retcode, string userid, string compcode, string dateformat,string commid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_retstatusbind_b.sp_retstatusbind_b_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm4 = new OracleParameter("commid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = commid;
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


        //======================= for Retainer Slab=====================================//


        public DataSet insertretstatus_slab(string compcode, string userid, string retcode, string fromdays, string todays, string drpcommon, string commrate, string commid,string agency_type)
      {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("insertretstatus_slab", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("retcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = retcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = compcode;
            objOraclecommand.Parameters.Add(prm3);

            //OracleParameter prm4 = new OracleParameter("enln", OracleType.Number);
            //prm4.Direction = ParameterDirection.Input;
            //prm4.Value = enln;
            //objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("fromdays", OracleType.Number);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = fromdays;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm7 = new OracleParameter("todays", OracleType.Number);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = todays;
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm6 = new OracleParameter("drpcommon", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = drpcommon;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm8 = new OracleParameter("commrate", OracleType.Number);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = commrate;
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm9 = new OracleParameter("P_COMM_TARGET_ID", OracleType.Number);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = commid;
            objOraclecommand.Parameters.Add(prm9);



            OracleParameter prm10 = new OracleParameter("pagency_type", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = agency_type;
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

        public DataSet selectretslab(string retcode, string compcode, string userid, string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("retselectslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("code11", OracleType.Number);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code11;
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


        public DataSet Ret_GetSlabupdate(string retcode, string compcode, string userid, string common, string commrate, string todays, string fromdays, string code,string agency_type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateretstatus_slab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("retcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("common", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = common;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("commrate", OracleType.Number);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = commrate;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("fromdays", OracleType.Number);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = fromdays;
                objOraclecommand.Parameters.Add(prm6);
               

                OracleParameter prm7 = new OracleParameter("todays", OracleType.Number);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = todays;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("code", OracleType.Number);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = code;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pagency_type", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agency_type;
                objOraclecommand.Parameters.Add(prm9);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex) { throw (ex); }
            finally
            {
                CloseConnection(ref objOracleConnection); 
            
            }
        }


        public DataSet retslabcheck(string compcode, string userid, string retcode,string todays,string fromdays , string codepass,string agency_type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("retcheckslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("fromdays", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = fromdays;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("todays", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = todays;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm8 = new OracleParameter("pagency_type", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = agency_type;
                objOraclecommand.Parameters.Add(prm8);
               
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

        public DataSet Ret_StatusDeleteSlab(string userid, string compcode, string retcode, string enlncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("retdeleteslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("retcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = retcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("enlncode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (enlncode == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = enlncode;
                objOraclecommand.Parameters.Add(prm5);

            

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objOracleConnection); }
        }
        //=================================Retainer chk name to booking==============================//
        public DataSet Retainerchkname(string compcode, string Retname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Retchknameforbook", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Retname", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Retname;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
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

        //=========************************ To save Retainer Comm Structure *****************************================//
        public DataSet insertretcommstructure(string compcode, string userid, string retcode, string PTEAM_CODE, string PADCTG_CODE, string PFROM_TGT, string PTO_TGT, string PCUST_TYPE, string PAD_TYPE, string PPUB_TYPE, string PPUBL_CODE, string PCOMM_TARGET_ID)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_RETAIN_COMM_TARGET_INS", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PRETAIN_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PTEAM_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PTEAM_CODE;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PADCTG_CODE", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = PADCTG_CODE;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PFROM_TGT", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = PFROM_TGT;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PTO_TGT", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = PTO_TGT;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("PCUST_TYPE", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = PCUST_TYPE;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("PAD_TYPE", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = PAD_TYPE;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("PPUB_TYPE", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = PPUB_TYPE;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = PPUBL_CODE;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = PCOMM_TARGET_ID;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "I";
                objOraclecommand.Parameters.Add(prm16);


                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        //================================================Ad for Retainer structure Slab Pop Up================================================//
        public DataSet retainerstructuresbind_b(string retcode, string userid, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_RETAIN_COMM_TARGET_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);



                //OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = dateformat;
                //objOraclecommand.Parameters.Add(prm4);

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
        public DataSet selectretstruct(string retcode, string compcode, string userid, string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("retselectstructslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("code11", OracleType.Number);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code11;
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
        //=========************************ To Update Retainer Comm Structure *****************************================//
        public DataSet Ret_GetStructSlabupdate(string compcode, string userid, string retcode, string PTEAM_CODE, string PADCTG_CODE, string PFROM_TGT, string PTO_TGT, string PCUST_TYPE, string PAD_TYPE, string PPUB_TYPE, string PPUBL_CODE, string PCOMM_TARGET_ID)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_RETAIN_COMM_TARGET_INS", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PRETAIN_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PTEAM_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PTEAM_CODE;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PADCTG_CODE", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = PADCTG_CODE;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PFROM_TGT", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = PFROM_TGT;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PTO_TGT", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = PTO_TGT;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("PCUST_TYPE", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = PCUST_TYPE;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("PAD_TYPE", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = PAD_TYPE;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("PPUB_TYPE", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = PPUB_TYPE;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = PPUBL_CODE;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = PCOMM_TARGET_ID;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = userid;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "U";
                objOraclecommand.Parameters.Add(prm16);


                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        //==============================================*****Insert Retainer additional Slab **********======================//
        public DataSet insertretaddcomm(string compcode, string userid, string retcode, string lstpub, string minpub, string publication,string commid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_RETAIN_ADD_COMM_TARGET_INS", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PRETAIN_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = lstpub;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PNO_OF_PUBL", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = minpub;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PADCOMM_PER", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = publication;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PCOMM_TYPE", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = commid;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "I";
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("PADD_COMM_ID", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = "1";
                objOraclecommand.Parameters.Add(prm17);



                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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

        //==============================================***** Update Retainer additional Slab **********======================//
        public DataSet AddSlabupdate(string compcode, string userid, string retcode, string lstpub, string minpub, string publication, string targetid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_RETAIN_ADD_COMM_TARGET_INS", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PRETAIN_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = lstpub;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PNO_OF_PUBL", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = minpub;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PADCOMM_PER", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = publication;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PCOMM_TYPE", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = "1";
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = userid;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "U";
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("PADD_COMM_ID", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = targetid;
                objOraclecommand.Parameters.Add(prm17);

                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        //==============================================***** DELETE Retainer additional Slab **********======================//
        public DataSet Ret_AddDelete(string compcode, string userid, string retcode, string targetid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_RETAIN_ADD_COMM_TARGET_INS", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PRETAIN_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PNO_OF_PUBL", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PADCOMM_PER", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PCOMM_TYPE", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = "1";
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "D";
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("PADD_COMM_ID", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = targetid;
                objOraclecommand.Parameters.Add(prm17);


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
        public DataSet retaineraddbind_b(string retcode, string userid, string compcode, string dateformat,string commid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("retaddstatusbind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("commid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = commid;
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
        public DataSet selectretaddslab(string retcode, string compcode, string userid, string code11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("retaddselectslab", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("retcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("code11", OracleType.Number);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code11;
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

        //=========************************ To Delete Retainer Comm Structure *****************************================//
        public DataSet delretcommstructure(string compcode, string userid, string retcode, string PCOMM_TARGET_ID)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_RETAIN_COMM_TARGET_INS", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("PCOMP_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PRETAIN_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = retcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("PCREATED_BY", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PTEAM_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PADCTG_CODE", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PFROM_TGT", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("PTO_TGT", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("PCUST_TYPE", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("PAD_TYPE", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("PPUB_TYPE", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("PPUBL_CODE", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("PCOMM_TARGET_ID", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = PCOMM_TARGET_ID;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("PCREATED_DT", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PUPDATED_BY", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("PUPDATED_DT", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("PDML_TYPE", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "D";
                objOraclecommand.Parameters.Add(prm16);


                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        //=========************************ To Generate code for Retainer Comm Structure *****************************================//
        public DataSet gencodeforslab(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("gencodeforcommstruct", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
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

        public DataSet advpub(string compcode, string ptype, string publcode, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_publ_name", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppubtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ptype;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = publcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pexrta1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pexrta2", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                objOraclecommand.Parameters.Add(prm5);


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

        public DataSet bind_agname(string pcomp_code, string pcity_code, string pagcode, string pagsubcode, string pextra1, string pextra2)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                string query = "select get_adagency_name_new('" + pcomp_code + "','" + pcity_code + "','" + pagcode + "','" + pagsubcode + "','" + pextra1 + "','" + pextra2 + "') as Agency_Name from dual";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
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
    
    
    }

   
  

}

