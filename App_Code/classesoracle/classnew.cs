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
/// Summary description for classnew
/// </summary>
public class classnew:orclconnection
{
	public classnew()
	{
		//
		// TODO: Add constructor logic here
		//
	}

      public DataSet spfun(string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string clientname, string status, string hold)
     {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
         

            objOraclecommand = GetCommand("reportnew", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("adtype1", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (adtype == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = adtype;
            }
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("adcategory", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (adcategory == "")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = adcategory;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (fromdate == "")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (dateto == "")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy"); ;
            }
            objOraclecommand.Parameters.Add(prm4);



            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);


            OracleParameter prm6 = new OracleParameter("pub_name", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            if (pubname == "0")
            {
                prm6.Value = System.DBNull.Value;
            }
            else
            {
                prm6.Value = pubname;
            }
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (pubcent == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = pubcent;
            }
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("edition", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = dateformat;
            objOraclecommand.Parameters.Add(prm9);


            OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = descid;
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter temp1 = new OracleParameter("agname", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;
            temp1.Value = agname;
            objOraclecommand.Parameters.Add(temp1);

            OracleParameter temp2 = new OracleParameter("clientname", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;
            temp2.Value = clientname;
            objOraclecommand.Parameters.Add(temp2);

            OracleParameter temp3 = new OracleParameter("status", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            temp3.Value = status;
            objOraclecommand.Parameters.Add(temp3);

            OracleParameter temp4 = new OracleParameter("hold", OracleType.VarChar);
            temp4.Direction = ParameterDirection.Input;
            temp4.Value = hold;
            objOraclecommand.Parameters.Add(temp4);

            objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

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
    /////////////////

    public DataSet spAgency(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string clientname, string status, string hold)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            //objOraclecommand = GetCommand("Report1.Report1_p", ref objOracleConnection);
            //objOraclecommand.CommandType = CommandType.StoredProcedure;

            objOraclecommand = GetCommand("reportnew", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("agname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (agname == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = agname;
            }
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (adtype == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = adtype;
            }
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (adcategory == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = adcategory;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (fromdate == "0")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {
                if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (dateto == "0")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (pubname == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = pubname;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (pubcent == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = pubcent;
            }
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = dateformat;
            objOraclecommand.Parameters.Add(prm12);


            OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = descid;
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter temp1 = new OracleParameter("clientname", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;
            temp1.Value = clientname;
            objOraclecommand.Parameters.Add(temp1);

            OracleParameter temp2 = new OracleParameter("status", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;
            temp2.Value = status;
            objOraclecommand.Parameters.Add(temp2);

            OracleParameter temp3 = new OracleParameter("hold", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            temp3.Value = hold;
            objOraclecommand.Parameters.Add(temp3);

            objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

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


    public DataSet spclient(string cliname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string status, string hold)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("reportnew", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("clientname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (cliname == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = cliname;
            }
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (adtype == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = adtype;
            }
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (adcategory == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = adcategory;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (fromdate == "")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;


                }





                prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (dateto == "")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;


                }

                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (pubname == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = pubname;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (pubcent == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = pubcent;
            }
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if ((edition == "--Select Edition Name--") || (edition == "0"))
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = dateformat;
            objOraclecommand.Parameters.Add(prm12);

            OracleParameter prm13 = new OracleParameter("descid", OracleType.VarChar);
            prm13.Direction = ParameterDirection.Input;
            prm13.Value = descid;
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter prm14 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm14);


            OracleParameter temp1 = new OracleParameter("agname", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;
            temp1.Value = agname;
            objOraclecommand.Parameters.Add(temp1);


            OracleParameter temp2 = new OracleParameter("status", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;
            temp2.Value = status;
            objOraclecommand.Parameters.Add(temp2);


            OracleParameter temp3 = new OracleParameter("hold", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            temp3.Value = hold;
            objOraclecommand.Parameters.Add(temp3);

            objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

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

    public DataSet spStatus(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformat, string hold, string descid, string ascdesc, string temp1)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("Reportnew", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("agname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (agname == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = agname;
            }
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (adtype == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = adtype;
            }
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (adcategory == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = adcategory;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (fromdate == "")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (dateto == "")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {
                if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (pubname == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = pubname;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (pubcent == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = pubcent;
            }
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = dateformat;
            objOraclecommand.Parameters.Add(prm12);


            OracleParameter prm13 = new OracleParameter("status", OracleType.VarChar);
            prm13.Direction = ParameterDirection.Input;
            if (status == "0")
            {
                prm13.Value = System.DBNull.Value;
            }
            else
            {
                prm13.Value = status;
            }
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter prm16 = new OracleParameter("hold", OracleType.VarChar);
            prm16.Direction = ParameterDirection.Input;
            if (hold == "0")
            {
                prm16.Value = System.DBNull.Value;
            }
            else
            {
                prm16.Value = hold;
            }
            objOraclecommand.Parameters.Add(prm16);


            OracleParameter prm14 = new OracleParameter("descid", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = descid;
            objOraclecommand.Parameters.Add(prm14);



            OracleParameter prm15 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm15);


            OracleParameter tmp1 = new OracleParameter("clientname", OracleType.VarChar);
            tmp1.Direction = ParameterDirection.Input;
            tmp1.Value = temp1;
            objOraclecommand.Parameters.Add(tmp1);

            objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

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

    public DataSet spDeviation(string cliname, string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformat, string hold, string descid, string ascdesc, string temp1, string temp2)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("Deviationreportnew", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("clientname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (cliname == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = cliname;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm01 = new OracleParameter("agname", OracleType.VarChar);
            prm01.Direction = ParameterDirection.Input;
            if (agname == "0")
            {
                prm01.Value = System.DBNull.Value;
            }
            else
            {
                prm01.Value = agname;
            }
            objOraclecommand.Parameters.Add(prm01);


            OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (adtype == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = adtype;
            }
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (adcategory == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = adcategory;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (fromdate == "")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;


                }




                prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (dateto == "")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {


                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;


                }
                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (pubname == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = pubname;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (pubcent == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = pubcent;
            }
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = dateformat;
            objOraclecommand.Parameters.Add(prm12);


            OracleParameter prm13 = new OracleParameter("status", OracleType.VarChar);
            prm13.Direction = ParameterDirection.Input;
            if (status == "0")
            {
                prm13.Value = System.DBNull.Value;
            }
            else
            {
                prm13.Value = status;
            }
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter prm16 = new OracleParameter("hold", OracleType.VarChar);
            prm16.Direction = ParameterDirection.Input;
            if (hold == "0")
            {
                prm16.Value = System.DBNull.Value;
            }
            else
            {
                prm16.Value = hold;
            }
            objOraclecommand.Parameters.Add(prm16);


            OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = descid;
            objOraclecommand.Parameters.Add(prm15);

            OracleParameter prm14 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm14);

            //==============
            OracleParameter tmp1 = new OracleParameter("page", OracleType.VarChar);
            tmp1.Direction = ParameterDirection.Input;
            tmp1.Value = temp1;
            objOraclecommand.Parameters.Add(tmp1);

            OracleParameter tmp2 = new OracleParameter("position", OracleType.VarChar);
            tmp2.Direction = ParameterDirection.Input;
            tmp2.Value = temp2;
            objOraclecommand.Parameters.Add(tmp2);

            objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
            objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

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

    public DataSet spPagepremium(string page, string position, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string hold, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            //objOraclecommand = GetCommand("deviationreport.deviationreport_p", ref objOracleConnection);
            //objOraclecommand.CommandType = CommandType.StoredProcedure;



            objOraclecommand = GetCommand("Deviationreportnew", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("page", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (page == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = page;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("position", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (page == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = position;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (fromdate == "")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {
                prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (dateto == "")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {
                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (pubname == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = pubname;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (pubcent == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = pubcent;
            }
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = dateformat;
            objOraclecommand.Parameters.Add(prm12);

            OracleParameter prm10 = new OracleParameter("hold", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            if (hold == "0")
            {
                prm10.Value = System.DBNull.Value;
            }
            else
            {
                prm10.Value = hold;
            }
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("descid", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = descid;
            objOraclecommand.Parameters.Add(prm11);



            OracleParameter prm122 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm122.Direction = ParameterDirection.Input;
            prm122.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm122);

            //====================
            OracleParameter tmp2 = new OracleParameter("adtype1", OracleType.VarChar);
            tmp2.Direction = ParameterDirection.Input;
            tmp2.Value = temp2;
            objOraclecommand.Parameters.Add(tmp2);



            OracleParameter tmp3 = new OracleParameter("adcategory", OracleType.VarChar);
            tmp3.Direction = ParameterDirection.Input;
            tmp3.Value = temp3;
            objOraclecommand.Parameters.Add(tmp3);

            OracleParameter tmp4 = new OracleParameter("status", OracleType.VarChar);
            tmp4.Direction = ParameterDirection.Input;
            tmp4.Value = temp4;
            objOraclecommand.Parameters.Add(tmp4);



            OracleParameter tmp5 = new OracleParameter("clientname", OracleType.VarChar);
            tmp5.Direction = ParameterDirection.Input;
            tmp5.Value = temp5;
            objOraclecommand.Parameters.Add(tmp5);

            OracleParameter tmp1 = new OracleParameter("agname", OracleType.VarChar);
            tmp1.Direction = ParameterDirection.Input;
            tmp1.Value = temp1;
            objOraclecommand.Parameters.Add(tmp1);

            objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
            objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

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




    public DataSet displayonscreenreport(string frmdt, string todate, string compcode, string publication, string edition,string publicationcenter,string adtype,string adcategory, string dateformat, string descid, string ascdesc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("ScheduleReport1", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm11 = new OracleParameter("fromdate", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            if (dateformat == "dd/mm/yyyy" && frmdt != "" && frmdt != null)
            {
                string[] arr = frmdt.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                frmdt = mm + "/" + dd + "/" + yy;
            }

            if (frmdt == "" || frmdt == null)
            {
                prm11.Value = System.DBNull.Value;

            }
            else
            {

                prm11.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm11);

            //

            OracleParameter prm12 = new OracleParameter("dateto", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            if (dateformat == "dd/mm/yyyy" && todate != "" && todate != null)
            {
                string[] arr = todate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                todate = mm + "/" + dd + "/" + yy;
            }

            if (todate == "" || todate == null)
            {
                prm12.Value = System.DBNull.Value;

            }
            else
            {

                prm12.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm12);







            OracleParameter prm121 = new OracleParameter("pub_name", OracleType.VarChar);
            prm121.Direction = ParameterDirection.Input;
            if (publication != "0")
            {
                prm121.Value = publication;
            }
            else
            {
                prm121.Value = System.DBNull.Value;

            }
            objOraclecommand.Parameters.Add(prm121);



            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm15 = new OracleParameter("dateformat", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = dateformat;
            objOraclecommand.Parameters.Add(prm15);


            OracleParameter prm14 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            if (publicationcenter != "0")
            {
                prm14.Value = publicationcenter;
            }
            else
            {
                prm14.Value = System.DBNull.Value;

            }
            objOraclecommand.Parameters.Add(prm14);





            OracleParameter prm142 = new OracleParameter("adtyp", OracleType.VarChar);
            prm142.Direction = ParameterDirection.Input;
            if (adtype != "0")
            {
                prm142.Value = adtype;
            }
            else
            {
                prm142.Value = System.DBNull.Value;

            }
            objOraclecommand.Parameters.Add(prm142);




            OracleParameter prm17 = new OracleParameter("edition_name", OracleType.VarChar);
            prm17.Direction = ParameterDirection.Input;
            if (edition != "0")
            {
                prm17.Value = edition;
            }
            else
            {
                prm17.Value = System.DBNull.Value;

            }
            objOraclecommand.Parameters.Add(prm17);




            OracleParameter prm171 = new OracleParameter("adcatg", OracleType.VarChar);
            prm171.Direction = ParameterDirection.Input;
            if (adcategory != "0")
            {
                prm171.Value = adcategory;
            }
            else
            {
                prm171.Value = System.DBNull.Value;

            }
            objOraclecommand.Parameters.Add(prm171);


            OracleParameter prm151 = new OracleParameter("descid", OracleType.VarChar);
            prm151.Direction = ParameterDirection.Input;
            prm151.Value = descid;
            objOraclecommand.Parameters.Add(prm151);


            OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm16.Direction = ParameterDirection.Input;
            prm16.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm16);


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

}
}