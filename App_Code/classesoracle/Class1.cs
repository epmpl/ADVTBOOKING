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
/// Summary description for Class1
/// </summary>
public class Class1:orclconnection
{
	public Class1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet pub_cent_NEW(string compcode)
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





            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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
        catch (OracleException  objException)
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


    public DataSet pub_cent(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            

            objOracleConnection.Open();
            objOraclecommand = GetCommand("publication_proc.publication_proc_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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

    public DataSet edition(string pubcode, string centercode, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {







            objOracleConnection.Open();
            objOraclecommand = GetCommand("edition_proc.edition_proc_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = pubcode;
            objOraclecommand.Parameters.Add(prm3);
            OracleParameter prm2 = new OracleParameter("centercode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = centercode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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


    // BIND EDITION ---BY RINKI

    public DataSet edition1(string pubcode, String pubcent,string compcode)   //, string centercode, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("edition_proc.edition_proc_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = pubcode;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm2 = new OracleParameter("centercode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = pubcent;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            //objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
            //objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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


    public DataSet displayonscreenreport(string frmdt, string todate, string compcode, string publication, string status, string edition, string pubcenter, string adtype, string adcategory, string dateformate, string descid, string ascdesc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("Schedulereport1", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = dateformate;
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("pub_name", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            if (publication != "0")
            {
                prm3.Value = publication;
            }
            else
            {
                prm3.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm3);



            OracleParameter prm4 = new OracleParameter("descid", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = descid;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            if (frmdt != "0")
            {
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = frmdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    frmdt = mm + "/" + dd + "/" + yy;
                }
                prm6.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm6.Value = System.DBNull.Value;
            }

            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            if (todate != "0")
            {
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
                prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }

            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("edition_name", OracleType.VarChar, 50);
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

            OracleParameter prm9 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            if (pubcenter == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = pubcenter;
            }

            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("adcatg", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            if (adcategory == "")
            {
                prm10.Value = System.DBNull.Value;
            }
            else
            {
                prm10.Value = adcategory;
            }
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("adtyp", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = adtype;
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter prm12 = new OracleParameter("drpstatus", OracleType.VarChar, 50);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = status;
            objOraclecommand.Parameters.Add(prm12);


            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

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
          
          
          







    public DataSet bindgrid(string publication, string publicationcenter, string edition, string fromdate, string dateto, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
             objOraclecommand = GetCommand("websp_ciobooking.websp_ciobooking_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm3 = new OracleParameter("publication", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            if(publication=="0")
            {
                prm3.Value =System .DBNull .Value;
            }
            else
            {
            prm3.Value = publication;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm2 = new OracleParameter("publicationcenter", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if(publicationcenter=="0")
            {
            prm2.Value = System .DBNull .Value;
            }
            else
            {
                prm2.Value = publicationcenter;
            }
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm4 = new OracleParameter("edition", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            if(edition=="0")           
            {
                 prm4.Value =System .DBNull .Value;
            }
            else
            {
            prm4.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm4);


            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;            
            prm1.Value = compcode;          
            objOraclecommand.Parameters.Add(prm1);


              OracleParameter prm5 = new OracleParameter("fromdate", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;            
            prm5.Value =Convert.ToDateTime(fromdate).ToString ("dd-MMMM-yyy");          
            objOraclecommand.Parameters.Add(prm5);

              OracleParameter prm6 = new OracleParameter("dateto", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyy");          
            objOraclecommand.Parameters.Add(prm6);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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

    public DataSet billing(string cioid, string compcode)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


         
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_invoice.websp_invoice_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("ciobooking", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = cioid;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
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


    public DataSet billinginsertion(string cioid, string compcode,int no_of_insertion)
        
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_insertion.websp_insertion_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("ciobooking", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = cioid;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);
            OracleParameter prm3 = new OracleParameter("insertion", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = Convert .ToString (no_of_insertion);
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

    //public DataSet billing_insertins(string cioid, string compcode)
    //{

    //    OracleConnection objOracleConnection;
    //    OracleCommand objOraclecommand;
    //    DataSet objDataSet = new DataSet();
    //    objOracleConnection = GetConnection();
    //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
    //    try
    //    {



    //        objOracleConnection.Open();
    //        objOraclecommand = GetCommand("websp_insertionwise.websp_insertionwise_p", ref objOracleConnection);
    //        objOraclecommand.CommandType = CommandType.StoredProcedure;

    //        OracleParameter prm1 = new OracleParameter("ciobooking", OracleType.VarChar, 50);
    //        prm1.Direction = ParameterDirection.Input;
    //        prm1.Value = cioid;
    //        objOraclecommand.Parameters.Add(prm1);

    //        OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
    //        prm2.Direction = ParameterDirection.Input;
    //        prm2.Value = compcode;
    //        objOraclecommand.Parameters.Add(prm2);



    //        objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
    //        objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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


    public DataSet adagencycli1(string compcode, string adtype)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("packagereport.packagereport_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm5 = new OracleParameter("Adtype1", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = adtype;
            objOraclecommand.Parameters.Add(prm5);

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

    public DataSet addaydrilloutexcel(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string status, string hold, string descid, string ascdesc, string page, string position)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("Report_Drillout.Report_Drillout_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("clientname", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            if (client == "0")
            {
                prm6.Value = System.DBNull.Value;
            }
            else
            {
                prm6.Value = client;
            }
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm5 = new OracleParameter("agname", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (agency == "0")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {
                prm5.Value = agency;
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm7 = new OracleParameter("Adtype1", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (adtyp == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = adtyp;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("adcategory", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (adcat == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = adcat;
            }
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (fromdt == "")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = Convert.ToDateTime(fromdt).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (dateto == "")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pub_name", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (publ == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = publ;
            }
            objOraclecommand.Parameters.Add(prm3);


            OracleParameter prm9 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (pubcen == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = pubcen;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("edition", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm10.Value = System.DBNull.Value;
            }
            else
            {
                prm10.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm10);



            OracleParameter prm11 = new OracleParameter("PACKAGE1", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            if (package == "0")
            {
                prm11.Value = System.DBNull.Value;
            }
            else
            {
                prm11.Value = package;
            }
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter prm14 = new OracleParameter("compcode", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = compcode;
            objOraclecommand.Parameters.Add(prm14);


            OracleParameter prm15 = new OracleParameter("dateformat", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = dateformat;
            objOraclecommand.Parameters.Add(prm15);

            OracleParameter temp1 = new OracleParameter("status", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;
            temp1.Value = status;
            objOraclecommand.Parameters.Add(temp1);

            OracleParameter temp2 = new OracleParameter("hold", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;
            temp2.Value = hold;
            objOraclecommand.Parameters.Add(temp2);

            OracleParameter temp6 = new OracleParameter("descid", OracleType.VarChar);
            temp6.Direction = ParameterDirection.Input;
            temp6.Value = descid;
            objOraclecommand.Parameters.Add(temp6);

            OracleParameter temp3 = new OracleParameter("ascdesc", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            temp3.Value = ascdesc;
            objOraclecommand.Parameters.Add(temp3);

            OracleParameter temp4 = new OracleParameter("page", OracleType.VarChar);
            temp4.Direction = ParameterDirection.Input;
            temp4.Value = page;
            objOraclecommand.Parameters.Add(temp4);

            OracleParameter temp5 = new OracleParameter("position", OracleType.VarChar);
            temp5.Direction = ParameterDirection.Input;
            temp5.Value = position;
            objOraclecommand.Parameters.Add(temp5);


            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
            OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

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

    public DataSet drillout(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string descid, string ascdesc, string status, string hold, string page, string position)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("Report_Drillout.Report_Drillout_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("clientname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (client == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = client;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("agname", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (agency == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = agency;
            }
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("Adtype1", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (adtyp == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = adtyp;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm04 = new OracleParameter("adcategory", OracleType.VarChar);
            prm04.Direction = ParameterDirection.Input;
            if (adcat == "0")
            {
                prm04.Value = System.DBNull.Value;
            }
            else
            {
                prm04.Value = adcat;
            }
            objOraclecommand.Parameters.Add(prm04);


            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (fromdt == "")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {
                prm4.Value = Convert.ToDateTime(fromdt).ToString("dd-MMMM-yyyy");
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
                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy"); ;
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);


            OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (publ == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = publ;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (pubcen == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = pubcen;
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

            OracleParameter prm10 = new OracleParameter("PACKAGE1", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            if (package == "0")
            {
                prm10.Value = System.DBNull.Value;
            }
            else
            {
                prm10.Value = package;
            }
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("dateformat", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = dateformat;
            objOraclecommand.Parameters.Add(prm11);


            OracleParameter prm12 = new OracleParameter("descid", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = descid;
            objOraclecommand.Parameters.Add(prm12);


            OracleParameter prm13 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm13.Direction = ParameterDirection.Input;
            prm13.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter temp1 = new OracleParameter("status", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;
            temp1.Value = status;
            objOraclecommand.Parameters.Add(temp1);


            OracleParameter temp2 = new OracleParameter("hold", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;
            temp2.Value = hold;
            objOraclecommand.Parameters.Add(temp2);


            OracleParameter temp3 = new OracleParameter("page", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            temp3.Value = page;
            objOraclecommand.Parameters.Add(temp3);


            OracleParameter temp4 = new OracleParameter("position", OracleType.VarChar);
            temp4.Direction = ParameterDirection.Input;
            temp4.Value = position;
            objOraclecommand.Parameters.Add(temp4);

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

    public DataSet drilloutclient(string client, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string descid, string ascdesc, string agname, string status, string hold, string page, string position)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("report_drillout.report_drillout_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("clientname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (client == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = client;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("Adtype1", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (adtyp == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = adtyp;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (adcat == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = adcat;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (fromdt == "0")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {
                prm4.Value = Convert.ToDateTime(fromdt).ToString("dd-MMMM-yyyy");
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
                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);


            OracleParameter prm8 = new OracleParameter("pub_name", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (publ == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = publ;
            }
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (pubcen == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = pubcen;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("edition", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm10.Value = System.DBNull.Value;
            }
            else
            {
                prm10.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm10);



            OracleParameter prm11 = new OracleParameter("PACKAGE1", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            if (package == "0")
            {
                prm11.Value = System.DBNull.Value;
            }
            else
            {
                prm11.Value = package;
            }
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter prm12 = new OracleParameter("compcode", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = compcode;
            objOraclecommand.Parameters.Add(prm12);


            OracleParameter prm13 = new OracleParameter("dateformat", OracleType.VarChar);
            prm13.Direction = ParameterDirection.Input;
            prm13.Value = dateformat;
            objOraclecommand.Parameters.Add(prm13);



            OracleParameter prm14 = new OracleParameter("descid", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = descid;
            objOraclecommand.Parameters.Add(prm14);


            OracleParameter prm15 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm15);

            OracleParameter temp1 = new OracleParameter("agname", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;
            if (agname == "")
            {
                temp1.Value = System.DBNull.Value;
            }
            else
            {
                temp1.Value = agname;
            }
            objOraclecommand.Parameters.Add(temp1);

            OracleParameter temp2 = new OracleParameter("status", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;
            if (status == "")
            {
                temp2.Value = System.DBNull.Value;
            }
            else
            {
                temp2.Value = status;
            }
            objOraclecommand.Parameters.Add(temp2);

            OracleParameter temp3 = new OracleParameter("hold", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            if (hold == "")
            {
                temp3.Value = System.DBNull.Value;
            }
            else
            {
                temp3.Value = hold;
            }
            objOraclecommand.Parameters.Add(temp3);

            OracleParameter temp4 = new OracleParameter("page", OracleType.VarChar);
            temp4.Direction = ParameterDirection.Input;
            if (page == "")
            {
                temp4.Value = System.DBNull.Value;
            }
            else
            {
                temp4.Value = page;
            }
            objOraclecommand.Parameters.Add(temp4);

            OracleParameter temp5 = new OracleParameter("position", OracleType.VarChar);
            temp5.Direction = ParameterDirection.Input;
            if (position == "")
            {
                temp5.Value = System.DBNull.Value;
            }
            else
            {
                temp5.Value = position;
            }
            objOraclecommand.Parameters.Add(temp5);

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

    public OracleDataReader spAgencyexcel(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string clientname, string status, string hold, string descid, string ascdesc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("Report1.Report1_p", ref objOracleConnection);
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


            OracleParameter temp1 = new OracleParameter("clientname", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;
            if (clientname == "")
            {
                temp1.Value = System.DBNull.Value;
            }
            else
            {
                temp1.Value = clientname;
            }
            objOraclecommand.Parameters.Add(temp1);

            OracleParameter temp2 = new OracleParameter("status", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;
            if (status == "")
            {
                temp2.Value = System.DBNull.Value;
            }
            else
            {
                temp2.Value = status;
            }
            objOraclecommand.Parameters.Add(temp2);

            OracleParameter temp3 = new OracleParameter("hold", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            if (hold == "")
            {
                temp3.Value = System.DBNull.Value;
            }
            else
            {
                temp3.Value = hold;
            }
            objOraclecommand.Parameters.Add(temp3);

            OracleParameter temp4 = new OracleParameter("descid", OracleType.VarChar);
            temp4.Direction = ParameterDirection.Input;
            if (descid == "")
            {
                temp4.Value = System.DBNull.Value;
            }
            else
            {
                temp4.Value = descid;
            }
            objOraclecommand.Parameters.Add(temp4);

            OracleParameter temp5 = new OracleParameter("ascdesc", OracleType.VarChar);
            temp5.Direction = ParameterDirection.Input;
            if (ascdesc == "")
            {
                temp5.Value = System.DBNull.Value;
            }
            else
            {
                temp5.Value = ascdesc;
            }
            objOraclecommand.Parameters.Add(temp5);

            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



            objorclDataAdapter.SelectCommand = objOraclecommand;
            OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();
            return objdatareadre;



        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            //CloseConnection(ref objOracleConnection);
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
            if ((edition == "--Select Edition Name--")||(edition=="0"))
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
            //objOraclecommand = GetCommand("Report1.Report1_p", ref objOracleConnection);
            //objOraclecommand.CommandType = CommandType.StoredProcedure;


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
                if (dateformat == "dd/mm/yyyy")
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

                if (dateformat == "dd/mm/yyyy")
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


    public OracleDataReader spfunexcel(string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string agname, string clientname, string status, string hold, string descid, string ascdesc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("Report1.Report1_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

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

            OracleParameter temp5 = new OracleParameter("descid", OracleType.VarChar);
            temp5.Direction = ParameterDirection.Input;
            temp5.Value = descid;
            objOraclecommand.Parameters.Add(temp5);

            OracleParameter temp6 = new OracleParameter("ascdesc", OracleType.VarChar);
            temp6.Direction = ParameterDirection.Input;
            temp6.Value = ascdesc;
            objOraclecommand.Parameters.Add(temp6);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();
            return objdatareadre;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            //CloseConnection(ref objOracleConnection);
        }


    }

    public DataSet adname(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("RA_adbindcategory.RA_adbindcategory_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

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

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }

    public DataSet addaydrilloutpdf(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string descid, string ascdesc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("report_drillout", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("clientname", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            if (client == "0")
            {
                prm6.Value = System.DBNull.Value;
            }
            else
            {
                prm6.Value = client;
            }
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm5 = new OracleParameter("agname", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (agency == "0")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {
                prm5.Value = agency;
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm7 = new OracleParameter("adtype", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (adtyp == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = adtyp;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("adcategory", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (adcat == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = adcat;
            }
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (fromdt == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = fromdt;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (dateto == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = dateto;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pub_name", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (publ == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = publ;
            }
            objOraclecommand.Parameters.Add(prm3);


            OracleParameter prm9 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (pubcen == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = pubcen;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("edition", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm10.Value = System.DBNull.Value;
            }
            else
            {
                prm10.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm10);



            OracleParameter prm11 = new OracleParameter("package1", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            if (package == "0")
            {
                prm11.Value = System.DBNull.Value;
            }
            else
            {
                prm11.Value = package;
            }
            objOraclecommand.Parameters.Add(prm11);




            OracleParameter prm14 = new OracleParameter("compcode", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = compcode;
            objOraclecommand.Parameters.Add(prm14);


            OracleParameter prm15 = new OracleParameter("dateformat", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = dateformat;
            objOraclecommand.Parameters.Add(prm15);

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

    public DataSet advtype(string adtype, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("RA_bindadcategory.RA_bindadcategory_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("advtype", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = adtype;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

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

    public DataSet adagencycli(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindclientforcontract.bindclientforcontract_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

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

    //public OracleDataReader spAgencyexcel(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string clientname, string status, string hold, string descid, string ascdesc)
    //{
    //    OracleConnection objOracleConnection;
    //    OracleCommand objOraclecommand;
    //    DataSet objDataSet = new DataSet();
    //    objOracleConnection = GetConnection();
    //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

    //    try
    //    {

    //        objOracleConnection.Open();
    //        objOraclecommand = GetCommand("Report1.Report1_p", ref objOracleConnection);
    //        objOraclecommand.CommandType = CommandType.StoredProcedure;


    //        OracleParameter prm1 = new OracleParameter("agname", OracleType.VarChar);
    //        prm1.Direction = ParameterDirection.Input;
    //        if (agname == "0")
    //        {
    //            prm1.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            prm1.Value = agname;
    //        }
    //        objOraclecommand.Parameters.Add(prm1);


    //        OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
    //        prm2.Direction = ParameterDirection.Input;
    //        if (adtype == "0")
    //        {
    //            prm2.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            prm2.Value = adtype;
    //        }
    //        objOraclecommand.Parameters.Add(prm2);


    //        OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
    //        prm3.Direction = ParameterDirection.Input;
    //        if (adcategory == "0")
    //        {
    //            prm3.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            prm3.Value = adcategory;
    //        }
    //        objOraclecommand.Parameters.Add(prm3);

    //        OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
    //        prm4.Direction = ParameterDirection.Input;
    //        if (fromdate == "0")
    //        {
    //            prm4.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
    //        }
    //        objOraclecommand.Parameters.Add(prm4);

    //        OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
    //        prm5.Direction = ParameterDirection.Input;
    //        if (dateto == "0")
    //        {
    //            prm5.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
    //        }
    //        objOraclecommand.Parameters.Add(prm5);

    //        OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
    //        prm6.Direction = ParameterDirection.Input;
    //        prm6.Value = compcode;
    //        objOraclecommand.Parameters.Add(prm6);

    //        OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
    //        prm7.Direction = ParameterDirection.Input;
    //        if (pubname == "0")
    //        {
    //            prm7.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            prm7.Value = pubname;
    //        }
    //        objOraclecommand.Parameters.Add(prm7);


    //        OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
    //        prm1.Direction = ParameterDirection.Input;
    //        if (pubcent == "0")
    //        {
    //            prm8.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            prm8.Value = pubcent;
    //        }
    //        objOraclecommand.Parameters.Add(prm8);


    //        OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
    //        prm9.Direction = ParameterDirection.Input;
    //        if (edition == "0")
    //        {
    //            prm9.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            prm9.Value = edition;
    //        }
    //        objOraclecommand.Parameters.Add(prm9);

    //        OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
    //        prm12.Direction = ParameterDirection.Input;
    //        prm12.Value = dateformat;
    //        objOraclecommand.Parameters.Add(prm12);


    //        OracleParameter temp1 = new OracleParameter("clientname", OracleType.VarChar);
    //        temp1.Direction = ParameterDirection.Input;
    //        if (clientname == "")
    //        {
    //            temp1.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            temp1.Value = clientname;
    //        }
    //        objOraclecommand.Parameters.Add(temp1);

    //        OracleParameter temp2 = new OracleParameter("status", OracleType.VarChar);
    //        temp2.Direction = ParameterDirection.Input;
    //        if (status == "")
    //        {
    //            temp2.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            temp2.Value = status;
    //        }
    //        objOraclecommand.Parameters.Add(temp2);

    //        OracleParameter temp3 = new OracleParameter("hold", OracleType.VarChar);
    //        temp3.Direction = ParameterDirection.Input;
    //        if (hold == "")
    //        {
    //            temp3.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            temp3.Value = hold;
    //        }
    //        objOraclecommand.Parameters.Add(temp3);

    //        OracleParameter temp4 = new OracleParameter("descid", OracleType.VarChar);
    //        temp4.Direction = ParameterDirection.Input;
    //        if (descid == "")
    //        {
    //            temp4.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            temp4.Value = descid;
    //        }
    //        objOraclecommand.Parameters.Add(temp4);

    //        OracleParameter temp5 = new OracleParameter("ascdesc", OracleType.VarChar);
    //        temp5.Direction = ParameterDirection.Input;
    //        if (ascdesc == "")
    //        {
    //            temp5.Value = System.DBNull.Value;
    //        }
    //        else
    //        {
    //            temp5.Value = ascdesc;
    //        }
    //        objOraclecommand.Parameters.Add(temp5);

    //        objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
    //        objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



    //        objorclDataAdapter.SelectCommand = objOraclecommand;
    //        OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();
    //        return objdatareadre;



    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        //CloseConnection(ref objOracleConnection);
    //    }


    //}

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
            if (dateto == "0")
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

    public DataSet agency(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindagencyforcontract.bindagencyforcontract_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

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

    //

    public OracleDataReader spclientexcel(string clientname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string temp1, string temp2, string temp3, string temp4, string temp5)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("report1.report1_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("clientname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (clientname == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = clientname;
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


            OracleParameter tmp2 = new OracleParameter("descid", OracleType.VarChar);
            tmp2.Direction = ParameterDirection.Input;
            tmp2.Value = temp2;
            objOraclecommand.Parameters.Add(tmp2);



            OracleParameter tmp3 = new OracleParameter("ascdesc", OracleType.VarChar);
            tmp3.Direction = ParameterDirection.Input;
            tmp3.Value = temp3;
            objOraclecommand.Parameters.Add(tmp3);


            OracleParameter tmp1 = new OracleParameter("agname", OracleType.VarChar);
            tmp1.Direction = ParameterDirection.Input;
            tmp1.Value = temp1;
            objOraclecommand.Parameters.Add(tmp1);

            OracleParameter tmp4 = new OracleParameter("hold", OracleType.VarChar);
            tmp4.Direction = ParameterDirection.Input;
            tmp4.Value = temp4;
            objOraclecommand.Parameters.Add(tmp4);


            OracleParameter tmp5 = new OracleParameter("status", OracleType.VarChar);
            tmp5.Direction = ParameterDirection.Input;
            tmp5.Value = temp5;
            objOraclecommand.Parameters.Add(tmp5);

            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



            objorclDataAdapter.SelectCommand = objOraclecommand;
            OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();
            return objdatareadre;



        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            //CloseConnection(ref objOracleConnection);
        }


    }

    public OracleDataReader drillout_clientexcel(string client, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("report_drillout", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("clientname", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            if (client == "0")
            {
                prm6.Value = System.DBNull.Value;
            }
            else
            {
                prm6.Value = client;
            }
            objOraclecommand.Parameters.Add(prm6);



            OracleParameter prm7 = new OracleParameter("adtype", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (adtyp == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = adtyp;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("adcategory", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (adcat == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = adcat;
            }
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (fromdt == "0")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = fromdt;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (dateto == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = dateto;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pub_name", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (publ == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = publ;
            }
            objOraclecommand.Parameters.Add(prm3);


            OracleParameter prm9 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (pubcen == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = pubcen;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("edition", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm10.Value = System.DBNull.Value;
            }
            else
            {
                prm10.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm10);



            OracleParameter prm11 = new OracleParameter("package1", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            if (package == "0")
            {
                prm11.Value = System.DBNull.Value;
            }
            else
            {
                prm11.Value = package;
            }
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter prm14 = new OracleParameter("compcode", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = compcode;
            objOraclecommand.Parameters.Add(prm14);


            OracleParameter prm15 = new OracleParameter("dateformat", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = dateformat;
            objOraclecommand.Parameters.Add(prm15);

            objorclDataAdapter.SelectCommand = objOraclecommand;
            OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

            return objdatareadre;
            //objorclDataAdapter.Fill(objDataSet);

            //return objDataSet;



        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            //CloseConnection(ref objOracleConnection);

        }
    }

    public OracleDataReader displayexcelfile(string frmdt, string todate, string compcode, string publication, string edition, string dateformate, string descid, string ascdesc)  //, string value)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("ScheduleReport.ScheduleReport_P", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = dateformate;
            objOraclecommand.Parameters.Add(prm2);
           

            OracleParameter prm3 = new OracleParameter("pub_name", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            if (publication!="0")
            {
                prm3.Value = publication;
            }
            else
            {
                prm3.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm3);

          

            OracleParameter prm4 = new OracleParameter("descid", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = descid;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            if (frmdt != "0")
            {
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = frmdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    frmdt = mm + "/" + dd + "/" + yy;
                }
                prm6.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm6.Value = System.DBNull.Value;
            }
          
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            if (todate != "0")
            {
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
             prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy"); 
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }
           
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("edition_name", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = edition;
            objOraclecommand.Parameters.Add(prm8);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

            return objdatareadre;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            //CloseConnection(ref objOracleConnection);
        }

    }


    public DataSet value_pub(string frmdt, string todate, string compcode, string product, string dateformate, string descid, string ascdesc, string temp_agname, string temp_adtype, string temp_pubcent, string temp_category, string temp_edition, string temp_agency, string temp_region)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("pub_Reportnew", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            if (frmdt != "")
            {
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = frmdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    frmdt = mm + "/" + dd + "/" + yy;
                }
                prm1.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm1.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (todate != "")
            {
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
                prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm2.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("product", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            if (product != "0")
            {
                prm3.Value = product;
            }
            else
            {
                prm3.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm3);


            OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = compcode;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = dateformate;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("descid", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = descid;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter tmp1 = new OracleParameter("agname", OracleType.VarChar, 50);
            tmp1.Direction = ParameterDirection.Input;
            tmp1.Value = temp_agname;
            objOraclecommand.Parameters.Add(tmp1);

            OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
            tmp2.Direction = ParameterDirection.Input;
            tmp2.Value = temp_adtype;
            objOraclecommand.Parameters.Add(tmp2);

            OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
            tmp3.Direction = ParameterDirection.Input;
            tmp3.Value = temp_pubcent;
            objOraclecommand.Parameters.Add(tmp3);
            //string temp_agname, string temp_adtype, string temp_pubcent,string temp_category, string temp_edition, string temp_agency
            OracleParameter tmp4 = new OracleParameter("category", OracleType.VarChar, 50);
            tmp4.Direction = ParameterDirection.Input;
            tmp4.Value = temp_category;
            objOraclecommand.Parameters.Add(tmp4);

            OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
            tmp5.Direction = ParameterDirection.Input;
            tmp5.Value = temp_edition;
            objOraclecommand.Parameters.Add(tmp5);

            OracleParameter tmp6 = new OracleParameter("Region", OracleType.VarChar, 50);
            tmp6.Direction = ParameterDirection.Input;
            tmp6.Value = temp_region;
            objOraclecommand.Parameters.Add(tmp6);

            OracleParameter tmp7 = new OracleParameter("agency", OracleType.VarChar, 50);
            tmp7.Direction = ParameterDirection.Input;
            tmp7.Value = temp_agency;
            objOraclecommand.Parameters.Add(tmp7);

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


    public DataSet bindregion(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("Sp_Region.sp_region_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
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






    

       



}
}
