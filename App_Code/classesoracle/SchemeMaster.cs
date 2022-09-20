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
/// Summary description for SchemeMaster
/// </summary>
public class SchemeMaster:orclconnection
{
	public SchemeMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet advdata(string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("getadvtyp.getadvtyp_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);
            
            
            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
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


  

    public DataSet colscheme(string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("schemetypsel.schemetypsel_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
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
    public DataSet advdata1(string comb, string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindpkgname.bindpkgname_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("comb", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = comb;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);


           
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

    public DataSet schinsert(string AdvType, string AdvCat, string SchemeCode, string SchemeType, string CombName, string PackName, string Color, string Remarks, string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("schsave.schsave_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("AdvType", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = AdvType;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("SchemeType", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = SchemeType;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("CombName", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = CombName;
            objOraclecommand.Parameters.Add(prm3);



            OracleParameter prm4 = new OracleParameter("PackName", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = PackName;
            objOraclecommand.Parameters.Add(prm4);


            OracleParameter prm5 = new OracleParameter("Color", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = Color;
            objOraclecommand.Parameters.Add(prm5);


            OracleParameter prm6 = new OracleParameter("AdvCat", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = AdvCat;
            objOraclecommand.Parameters.Add(prm6);


            OracleParameter prm7 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("Remarks", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = Remarks;
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = compcode;
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = userid;
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

    public DataSet chkinsert(string SchemeCode, string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("chkschemesave.chkschemesave_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);

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

    public DataSet schmodify(string AdvType, string AdvCat, string SchemeCode, string SchemeType, string CombName, string PackName, string Color, string Remarks, string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("schupdate.schupdate_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm1 = new OracleParameter("AdvType", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = AdvType;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("SchemeType", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = SchemeType;
            objOraclecommand.Parameters.Add(prm2);



            OracleParameter prm3 = new OracleParameter("CombName", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = CombName;
            objOraclecommand.Parameters.Add(prm3);




            OracleParameter prm4 = new OracleParameter("PackName", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = PackName;
            objOraclecommand.Parameters.Add(prm4);



            OracleParameter prm5 = new OracleParameter("Color", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = Color;
            objOraclecommand.Parameters.Add(prm5);





            OracleParameter prm6 = new OracleParameter("AdvCat", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = AdvCat;
            objOraclecommand.Parameters.Add(prm6);





            OracleParameter prm7 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm7);





            OracleParameter prm8 = new OracleParameter("Remarks", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = Remarks;
            objOraclecommand.Parameters.Add(prm8);





            OracleParameter prm9 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = compcode;
            objOraclecommand.Parameters.Add(prm9);




            OracleParameter prm10 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = userid;
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


    public DataSet checkcode(string compcode, string SchemeCode, string userid)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("checkschemecode.checkschemecode_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm2 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm2);



            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);


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




    public DataSet selectpubdaymodify(string compcode, string SchemeCode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();


        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("secdaymodify.secdaymodify_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm2);




            OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = sun;
            objOraclecommand.Parameters.Add(prm3);




            OracleParameter prm4 = new OracleParameter("mon", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = mon;
            objOraclecommand.Parameters.Add(prm4);




            OracleParameter prm5 = new OracleParameter("tue", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = tue;
            objOraclecommand.Parameters.Add(prm5);




            OracleParameter prm6 = new OracleParameter("wed", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = wed;
            objOraclecommand.Parameters.Add(prm6);



            OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = thu;
            objOraclecommand.Parameters.Add(prm7);







            OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = fri;
            objOraclecommand.Parameters.Add(prm8);



            OracleParameter prm9 = new OracleParameter("sat", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = sat;
            objOraclecommand.Parameters.Add(prm9);


            OracleParameter prm10 = new OracleParameter("all", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = all;
            objOraclecommand.Parameters.Add(prm10);



            OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = userid;
            objOraclecommand.Parameters.Add(prm11);



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




    public DataSet selectpubdaysave(string compcode, string SchemeCode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("secdaysave.secdaysave_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);




            OracleParameter prm2 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm2);




            OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = sun;
            objOraclecommand.Parameters.Add(prm3);




            OracleParameter prm4 = new OracleParameter("mon", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = mon;
            objOraclecommand.Parameters.Add(prm4);





            OracleParameter prm5 = new OracleParameter("tue", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = tue;
            objOraclecommand.Parameters.Add(prm5);





            OracleParameter prm6 = new OracleParameter("wed", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = wed;
            objOraclecommand.Parameters.Add(prm6);




            OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = thu;
            objOraclecommand.Parameters.Add(prm7);


           
            OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = fri;
            objOraclecommand.Parameters.Add(prm8);




            OracleParameter prm9 = new OracleParameter("sat", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = sat;
            objOraclecommand.Parameters.Add(prm9);




            OracleParameter prm10 = new OracleParameter("all", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = all;
            objOraclecommand.Parameters.Add(prm10);



            OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = userid;
            objOraclecommand.Parameters.Add(prm11);


          
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


    public DataSet schexe(string AdvType, string AdvCat, string SchemeCode, string SchemeType, string CombName, string PackName, string Color, string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("schexe", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("AdvType", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = AdvType;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm2 = new OracleParameter("SchemeType", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = SchemeType;
            objOraclecommand.Parameters.Add(prm2);



            OracleParameter prm3 = new OracleParameter("CombName", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = CombName;
            objOraclecommand.Parameters.Add(prm3);



            OracleParameter prm4 = new OracleParameter("Color", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = Color;
            objOraclecommand.Parameters.Add(prm4);




            OracleParameter prm5 = new OracleParameter("AdvCat", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = AdvCat;
            objOraclecommand.Parameters.Add(prm5);



            OracleParameter prm6 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm6);


            OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = compcode;
            objOraclecommand.Parameters.Add(prm7);



            OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = userid;
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


    public DataSet checkpubcode(string compcode, string SchemeCode, string userid)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("schdayexe.schdayexe_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm2 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm2);

            

            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);


            
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


    public DataSet secfnpl(string compcode, string SchemeCode, string userid)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("secfnpl.secfnpl_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

           
            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
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


    public DataSet secdel(string compcode, string SchemeCode, string userid)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("schdelete.schdelete_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm2 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm2);

           
            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);


            
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




    public DataSet schbind(string compcode, string userid, string SchemeCode)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("secbind.secbind_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm2 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm2);

            
            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);


           

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



    public DataSet detailinsert(string compcode, string userid, string SchemeCode, string paid, string free, string disno, string distype, string discount, string freins, string fromdate, string todate, string period, string periodtyp)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("secsubmit.secsubmit_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            

            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm3);


            OracleParameter prm4 = new OracleParameter("paid", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = paid;
            //objOraclecommand.Parameters.Add(prm4);


            
            if (paid == "" || paid == null)
            {
                objOraclecommand.Parameters["paid"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["paid"].Value = paid;
            }


            OracleParameter prm5 = new OracleParameter("free", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = free;
            //objOraclecommand.Parameters.Add(prm5);



           
            if (free == "" || free == null)
            {
                objOraclecommand.Parameters["free"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["free"].Value = free;
            }

            OracleParameter prm6 = new OracleParameter("disno", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = disno;
            //objOraclecommand.Parameters.Add(prm6);

           
            if (disno == "" || disno == null)
            {
                objOraclecommand.Parameters["disno"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["disno"].Value = disno;
            }

            OracleParameter prm7 = new OracleParameter("distype", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = distype;
            //objOraclecommand.Parameters.Add(prm7);
           
            if (distype == "0")
            {
                objOraclecommand.Parameters["distype"].Value = "";
            }
            else
            {
                objOraclecommand.Parameters["distype"].Value = distype;
            }

            OracleParameter prm8 = new OracleParameter("discount", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = discount;
            //objOraclecommand.Parameters.Add(prm8);

           
            if (discount == "" || discount == null)
            {
                objOraclecommand.Parameters["discount"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["discount"].Value = discount;
            }

            OracleParameter prm9 = new OracleParameter("freins", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = freins;
            //objOraclecommand.Parameters.Add(prm9);

            
            if (freins == "" || freins == null)
            {
                objOraclecommand.Parameters["freins"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["freins"].Value = freins;
            }

            OracleParameter prm10 = new OracleParameter("fromdate", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = fromdate;
            //objOraclecommand.Parameters.Add(prm9);

           
            if (fromdate == "" || fromdate == null)
            {
                objOraclecommand.Parameters["fromdate"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["fromdate"].Value = fromdate;
            }


            OracleParameter prm11 = new OracleParameter("todate", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = todate;
            //objOraclecommand.Parameters.Add(prm11);
           

            if (todate == "" || todate == null)
            {
                objOraclecommand.Parameters["todate"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["todate"].Value = todate;
            }

            OracleParameter prm12 = new OracleParameter("period", OracleType.VarChar, 50);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = period;
            //objOraclecommand.Parameters.Add(prm12);
           
            if (period == "")
            {
                objOraclecommand.Parameters["period"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["period"].Value = period;
            }

            OracleParameter prm13 = new OracleParameter("periodtyp", OracleType.VarChar, 50);
            prm13.Direction = ParameterDirection.Input;
            prm13.Value = periodtyp;
            //objOraclecommand.Parameters.Add(prm12);

           
            if (periodtyp == "0")
            {
                objOraclecommand.Parameters["periodtyp"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["periodtyp"].Value = periodtyp;
            }

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




    public DataSet detailupdate(string Code, string compcode, string userid, string SchemeCode, string paid, string free, string disno, string distype, string discount, string freins, string fromdate, string todate, string period, string periodtyp)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("secupdate.secupdate_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm1 = new OracleParameter("Code", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = Code;
            objOraclecommand.Parameters.Add(prm1);

           

            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);



            OracleParameter prm4 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm4);




            OracleParameter prm5 = new OracleParameter("paid", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = paid;
            objOraclecommand.Parameters.Add(prm5);



            OracleParameter prm6 = new OracleParameter("free", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = free;
            objOraclecommand.Parameters.Add(prm6);



            OracleParameter prm7 = new OracleParameter("disno", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = disno;
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("distype", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = distype;
            //objOraclecommand.Parameters.Add(prm8);

           
            if (distype == "0")
            {
                objOraclecommand.Parameters["distype"].Value = "";
            }
            else
            {
                objOraclecommand.Parameters["distype"].Value = distype;
            }


            OracleParameter prm9 = new OracleParameter("discount", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = discount;
            objOraclecommand.Parameters.Add(prm9);



            OracleParameter prm10 = new OracleParameter("freins", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = freins;
            objOraclecommand.Parameters.Add(prm10);




            OracleParameter prm11 = new OracleParameter("fromdate", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = fromdate;
           // objOraclecommand.Parameters.Add(prm11);


           
            if (fromdate == "" || fromdate == null)
            {
                objOraclecommand.Parameters["fromdate"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["fromdate"].Value = fromdate;
            }
            OracleParameter prm12 = new OracleParameter("todate", OracleType.VarChar, 50);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = todate;
            // objOraclecommand.Parameters.Add(prm12);

            
            if (todate == "" || todate == null)
            {
                objOraclecommand.Parameters["todate"].Value = System.DBNull.Value;
            }
            else
            {
                objOraclecommand.Parameters["todate"].Value = todate;
            }

            OracleParameter prm13 = new OracleParameter("period", OracleType.VarChar, 50);
            prm13.Direction = ParameterDirection.Input;
            prm13.Value = period;
            // objOraclecommand.Parameters.Add(prm13);
           
            if (period == "0")
            {
                objOraclecommand.Parameters["period"].Value = "";
            }
            else
            {
                objOraclecommand.Parameters["period"].Value = period;
            }

            OracleParameter prm14 = new OracleParameter("periodtyp", OracleType.VarChar, 50);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = periodtyp;
            objOraclecommand.Parameters.Add(prm14);

           

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



    public DataSet clientcontactbind(string SchemeCode, string userid, string compcode, string code10)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("schdetsel.schdetsel_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm1);





            OracleParameter prm2 = new OracleParameter("code10", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = code10;
            objOraclecommand.Parameters.Add(prm2);




            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);




            OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = compcode;
            objOraclecommand.Parameters.Add(prm4);


          


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


    public DataSet detaildelete(string SchemeCode, string compcode, string userid, string code)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("schdeldetail", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("SchemeCode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = SchemeCode;
            objOraclecommand.Parameters.Add(prm1);





            OracleParameter prm2 = new OracleParameter("code", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = code;
            objOraclecommand.Parameters.Add(prm2);





            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);

            

            OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = compcode;
            objOraclecommand.Parameters.Add(prm4);


           


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

		
	}	}