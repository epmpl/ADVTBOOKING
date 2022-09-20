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
namespace NewAdbooking.Report.classesoracle
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

    public DataSet bind_currency(string compcode,string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindcurrency.bindcurrency_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);


        

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




    public DataSet netamtreportdatewise(string frmdt, string todate, string compcode, string dateformate, string rowname, string columnname, string conditionchk, string useid, string chk_acc)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("billreportbilled", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("pfromdate", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (frmdt != "")
            {

                prm1.Value = frmdt;
            }
            else
            {
                prm1.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm7 = new OracleParameter("ptodate", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (todate != "")
            {

                prm7.Value = todate;
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pdateformat", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = dateformate;
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);



            OracleParameter prm9 = new OracleParameter("prowname", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = rowname;
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("pcolumnname", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = columnname;
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm1h = new OracleParameter("pconditioncheck", OracleType.VarChar);
            prm1h.Direction = ParameterDirection.Input;
            prm1h.Value = conditionchk;
            objOraclecommand.Parameters.Add(prm1h);



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



    public DataSet get_SubCategory(string compcode, string catcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("adsubcategory.adsubcategory_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("Adcat", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = catcode;
            objOraclecommand.Parameters.Add(prm6);
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

    public DataSet selectreport(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("select_report_prefer.select_report_prefer_p", ref objOracleConnection);
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
    public DataSet aduom(string adtype, string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("Binduom.binduom_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("Adtype", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = adtype;
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
    public DataSet barter_report(string frmdt, string todate, string compcode, string client, string agency, string region, string product, string booktype, string dateformate, string descid, string ascdesc, string pub_center, string useid, string chk_acc, string adtype, string uomtype)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("Barter_Report.bill_report_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter p11 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
            p11.Direction = ParameterDirection.Input;
            if (pub_center != "0")
            {
                p11.Value = pub_center;
            }
            else
            {
                p11.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(p11);
            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);


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

            OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
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
                prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("dateformat", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = dateformate;
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm2 = new OracleParameter("product", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (product != "0")
            {
                prm2.Value = product;
            }
            else
            {
                prm2.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm4 = new OracleParameter("Region", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            if (region != "0")
            {
                prm4.Value = region;
            }
            else
            {
                prm4.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm3 = new OracleParameter("descid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = descid;
            objOraclecommand.Parameters.Add(prm3);


            OracleParameter prm6 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm9 = new OracleParameter("agency", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            if (agency != "0" && agency != "")
            {
                prm9.Value = agency;
            }
            else
            {
                prm9.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("client", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            if (client != "0" && client != "")
            {
                prm10.Value = client;
            }
            else
            {
                prm10.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("booktype", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = booktype;
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter prm12 = new OracleParameter("advtype", OracleType.VarChar, 50);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = adtype;
            objOraclecommand.Parameters.Add(prm12);

            OracleParameter prm13 = new OracleParameter("uomtype", OracleType.VarChar, 50);
            prm13.Direction = ParameterDirection.Input;
            prm13.Value = uomtype;
            objOraclecommand.Parameters.Add(prm13);

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

    public DataSet updatereport(string pub_cent, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("update_report_prefer.update_report_prefer_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top2 = new OracleParameter("pub_cent", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = pub_cent;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            //OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
            //prm2.Direction = ParameterDirection.Input;
            //prm2.Value = useid;
            //objOraclecommand.Parameters.Add(prm2);

            //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
    public DataSet pub_centbind(string compcode, string useid, string chk_acc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("pubcent_proc.pubcent_proc_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = useid;
            objOraclecommand.Parameters.Add(prm2);

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
    public DataSet edition_print(string pubcode,string print_center,string comp_code )
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("BIND_EDITION_PRINT.BIND_EDITION_PRINT_P", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("p_pubcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            if (pubcode=="0")
                prm1.Value =System.DBNull.Value;
            else
            prm1.Value = pubcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("p_printcent", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (print_center=="0")
                prm2.Value =System.DBNull.Value ;
            else
                prm2.Value = print_center;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("p_compcode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = comp_code;
            objOraclecommand.Parameters.Add(prm3);


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
    public DataSet issuereport(string compcode, string fromdate, string todate, string pubcent, string edition, string dateformat, string userid, string chk_acc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();


        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("rpt_issue_pcentre_wise.rpt_issue_pcentre_wise_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("ppubcent", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (pubcent == "0")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = pubcent;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm3.Value = System.DBNull.Value;
            }
            else
            {
                prm3.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = fromdate;
           
            objOraclecommand.Parameters.Add(prm4);


            OracleParameter prm6 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = todate;
          
            objOraclecommand.Parameters.Add(prm6);



            OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = dateformat;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm27 = new OracleParameter("puserid", OracleType.VarChar, 50);
            prm27.Direction = ParameterDirection.Input;
            prm27.Value = userid;
            objOraclecommand.Parameters.Add(prm27);



            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

           // objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
          //  objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;
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
    public DataSet uombind(string comp_code, string adtype, string uomdesc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("getuom", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = comp_code;
            objOraclecommand.Parameters.Add(prm1);
            OracleParameter prm2 = new OracleParameter("adtype", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = adtype;
            objOraclecommand.Parameters.Add(prm2);
            OracleParameter prm3 = new OracleParameter("uomdesc", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = uomdesc;
            objOraclecommand.Parameters.Add(prm3);

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

    public DataSet getQBC(string pubcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_QBC.websp_QBC_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pubcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = pubcode;
            objOraclecommand.Parameters.Add(prm1);
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
    public DataSet package_report(string compcode,string adtype)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindpackagereport.bindpackagereport_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm1 = new OracleParameter("adtype1", OracleType.VarChar, 50);
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

            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
           
            objorclDataAdapter = new OracleDataAdapter();
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

    public DataSet payment(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("an_payment.an_payment_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            //objSqlDataAdapter = new SqlDataAdapter();
            objorclDataAdapter = new OracleDataAdapter();
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

    public DataSet bind_fmgregion(string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("ad_fmg_reason_bind", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
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
    public DataSet bind_bookingtype(string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("ad_bktype_bind", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm2 = new OracleParameter("pextra1", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = "";
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pextra2", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = "";
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
    public DataSet completerep(string compcode, string fromdate, string dateto, string dateformate, string publication, string pub_cent, string edition, string suppliment, string zone, string branch, string district, string region, string city, string revcenter, string adtype, string agencytype, string ratetype, string adcat, string adsubcat, string adsubcat3, string adsubcat4, string adsubcat5, string package, string scheme, string agency, string client, string executive, string retainer, string product, string brand, string varient, string pagetype, string pageprem, string postprem, string rostatus, string booktype, string contractname, string filterby, string adcheck, string state, string taluka, string based, string status, string chkdetail, string insertsts, string useid, string chk_acc, string box, string fmgregion)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("completereport", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top1 = new OracleParameter("p_puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("p_chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm5 = new OracleParameter("p_compcode", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("p_dateformat", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = dateformate;
            objOraclecommand.Parameters.Add(prm6);



            OracleParameter prm9 = new OracleParameter("p_fromdate", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;

            if (fromdate == "" || fromdate == null)
            {
                prm9.Value = System.DBNull.Value;
            }

            else
            {
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;


                }

                prm9.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm4 = new OracleParameter("p_dateto", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;

            if (dateto == "" || dateto == null)
            {
                prm4.Value = System.DBNull.Value;
            }

            else
            {
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;


                }

                prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm4);


            OracleParameter prm2 = new OracleParameter("p_publication", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (publication != "0")
            {
                prm2.Value = publication;
            }
            else
            {
                prm2.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter temp2 = new OracleParameter("p_pub_cent", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;

            if (pub_cent != "0")
            {
                temp2.Value = pub_cent;
            }
            else
            {
                temp2.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(temp2);


            OracleParameter temp3 = new OracleParameter("p_edition", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            // temp3.Value = edition;
            if (edition == "0")
            {
                temp3.Value = System.DBNull.Value;
            }
            else
            {
                temp3.Value = edition;
            }
            objOraclecommand.Parameters.Add(temp3);

            OracleParameter put1 = new OracleParameter("p_suppliment", OracleType.VarChar);
            put1.Direction = ParameterDirection.Input;
            // put1.Value = suppliment;
            if (suppliment == "0")
            {
                put1.Value = System.DBNull.Value;
            }
            else
            {
                put1.Value = suppliment;
            }
            objOraclecommand.Parameters.Add(put1);

            OracleParameter put2 = new OracleParameter("p_zone", OracleType.VarChar);
            put2.Direction = ParameterDirection.Input;
            //put2.Value = zone;
            if (zone == "0")
            {
                put2.Value = System.DBNull.Value;
            }
            else
            {
                put2.Value = zone;
            }
            objOraclecommand.Parameters.Add(put2);

            OracleParameter put3 = new OracleParameter("p_branch", OracleType.VarChar);
            put3.Direction = ParameterDirection.Input;
            //put3.Value = branch;
            if (branch == "0" || branch == "Select Branch")
            {
                put3.Value = System.DBNull.Value;
            }
            else
            {
                put3.Value = branch;
            }
            objOraclecommand.Parameters.Add(put3);

            OracleParameter prm52 = new OracleParameter("p_district", OracleType.VarChar);
            prm52.Direction = ParameterDirection.Input;
            if (district == "0" || district == "Select District")
            {
                prm52.Value = System.DBNull.Value;
            }
            else
            {
                prm52.Value = district;
            }
            objOraclecommand.Parameters.Add(prm52);




            OracleParameter prm1 = new OracleParameter("p_region", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (region != "0")
            {
                prm1.Value = region;
            }
            else
            {
                prm1.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm3 = new OracleParameter("p_city", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (city != "0")
            {
                prm3.Value = city;
            }
            else
            {
                prm3.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm3);




            OracleParameter prm7 = new OracleParameter("p_revcenter", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            //prm7.Value = revcenter;
            if (revcenter == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = revcenter;
            }
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("p_adtype", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            //prm8.Value = adtype;
            if (adtype == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = adtype;
            }
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter temp = new OracleParameter("p_agencytype", OracleType.VarChar);
            temp.Direction = ParameterDirection.Input;
            //temp.Value = agencytype;
            if (agencytype == "0" || agencytype == "Select Agency Type")
            {
                temp.Value = System.DBNull.Value;
            }
            else
            {
                temp.Value = agencytype;
            }
            objOraclecommand.Parameters.Add(temp);

            OracleParameter temp1 = new OracleParameter("p_ratetype", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;

            if (ratetype == "0")
            {
                temp1.Value = System.DBNull.Value;
            }
            else
            {
                temp1.Value = ratetype;
            }
            objOraclecommand.Parameters.Add(temp1);





            OracleParameter temp4 = new OracleParameter("p_adcat", OracleType.VarChar);
            temp4.Direction = ParameterDirection.Input;
            //temp4.Value = adcat;
            if (adcat == "0" || adcat == "Select AdCat")
            {
                temp4.Value = System.DBNull.Value;
            }
            else
            {
                temp4.Value = adcat;
            }
            objOraclecommand.Parameters.Add(temp4);

            OracleParameter temp5 = new OracleParameter("p_adsubcat", OracleType.VarChar);
            temp5.Direction = ParameterDirection.Input;
            //temp5.Value = adsubcat;
            if (adsubcat == "0")
            {
                temp5.Value = System.DBNull.Value;
            }
            else
            {
                temp5.Value = adsubcat;
            }
            objOraclecommand.Parameters.Add(temp5);



            OracleParameter temp15 = new OracleParameter("p_adsubcat3", OracleType.VarChar);
            temp15.Direction = ParameterDirection.Input;
            if (adsubcat3 == "0")
            {
                temp15.Value = System.DBNull.Value;
            }
            else
            {
                temp15.Value = adsubcat3;
            }
            objOraclecommand.Parameters.Add(temp15);

            OracleParameter put30 = new OracleParameter("p_adsubcat4", OracleType.VarChar);
            put30.Direction = ParameterDirection.Input;
            if (adsubcat4 == "0")
            {
                put30.Value = System.DBNull.Value;
            }
            else
            {
                put30.Value = adsubcat4;
            }
            objOraclecommand.Parameters.Add(put30);

            OracleParameter put4 = new OracleParameter("p_adsubcat5", OracleType.VarChar);
            put4.Direction = ParameterDirection.Input;
            if (adsubcat5 == "0")
            {
                put4.Value = System.DBNull.Value;
            }
            else
            {
                put4.Value = adsubcat5;
            }
            objOraclecommand.Parameters.Add(put4);



            OracleParameter prm51 = new OracleParameter("p_package", OracleType.VarChar);
            prm51.Direction = ParameterDirection.Input;
            if (package == "0")
            {
                prm51.Value = System.DBNull.Value;
            }
            else
            {

                prm51.Value = package;
            }
            objOraclecommand.Parameters.Add(prm51);



            OracleParameter prm55 = new OracleParameter("p_scheme", OracleType.VarChar);
            prm55.Direction = ParameterDirection.Input;
            if (scheme == "0")
            {
                prm55.Value = System.DBNull.Value;
            }
            else
            {
                prm55.Value = scheme;
            }
            objOraclecommand.Parameters.Add(prm55);


            OracleParameter put5 = new OracleParameter("p_agency", OracleType.VarChar);
            put5.Direction = ParameterDirection.Input;
            if (agency == "0" || agency == "")
            {
                put5.Value = System.DBNull.Value;
            }
            else
            {
                put5.Value = agency;
            }
            objOraclecommand.Parameters.Add(put5);
            //////////////////////////////////////////////
            ///////////////////////////////////////////
            OracleParameter put6 = new OracleParameter("p_client", OracleType.VarChar);
            put6.Direction = ParameterDirection.Input;
            if (client == "0" || client == "")
            {
                put6.Value = System.DBNull.Value;
            }
            else
            {
                put6.Value = client;
            }
            objOraclecommand.Parameters.Add(put6);

            OracleParameter put7 = new OracleParameter("p_executive", OracleType.VarChar);
            put7.Direction = ParameterDirection.Input;
            if (executive == "0" || executive == "")
            {
                put7.Value = System.DBNull.Value;
            }
            else
            {
                put7.Value = executive;
            }
            objOraclecommand.Parameters.Add(put7);

            OracleParameter put8 = new OracleParameter("p_retainer", OracleType.VarChar);
            put8.Direction = ParameterDirection.Input;
            if (retainer == "0" || retainer == "")
            {
                put8.Value = System.DBNull.Value;
            }
            else
            {
                put8.Value = retainer;
            }
            objOraclecommand.Parameters.Add(put8);
            OracleParameter put9 = new OracleParameter("p_product", OracleType.VarChar);
            put9.Direction = ParameterDirection.Input;
            if (product == "0")
            {
                put9.Value = System.DBNull.Value;
            }
            else
            {
                put9.Value = product;
            }
            objOraclecommand.Parameters.Add(put9);

            OracleParameter put10 = new OracleParameter("p_brand", OracleType.VarChar);
            put10.Direction = ParameterDirection.Input;
            if (brand == "0")
            {
                put10.Value = System.DBNull.Value;
            }
            else
            {
                put10.Value = brand;
            }
            objOraclecommand.Parameters.Add(put10);

            OracleParameter put11 = new OracleParameter("p_varient", OracleType.VarChar);
            put11.Direction = ParameterDirection.Input;
            if (varient == "0")
            {
                put11.Value = System.DBNull.Value;
            }
            else
            {
                put11.Value = varient;
            }
            objOraclecommand.Parameters.Add(put11);

            OracleParameter put12 = new OracleParameter("p_pagetype", OracleType.VarChar);
            put12.Direction = ParameterDirection.Input;
            if (pagetype == "0")
            {
                put12.Value = System.DBNull.Value;
            }
            else
            {
                put12.Value = pagetype;
            }
            objOraclecommand.Parameters.Add(put12);

            OracleParameter put13 = new OracleParameter("p_pageprem", OracleType.VarChar);
            put13.Direction = ParameterDirection.Input;
            if (pageprem == "0")
            {
                put13.Value = System.DBNull.Value;
            }
            else
            {
                put13.Value = pageprem;
            }
            objOraclecommand.Parameters.Add(put13);

            OracleParameter put14 = new OracleParameter("p_postprem", OracleType.VarChar);
            put14.Direction = ParameterDirection.Input;
            if (postprem == "0")
            {
                put14.Value = System.DBNull.Value;
            }
            else
            {
                put14.Value = postprem;
            }
            objOraclecommand.Parameters.Add(put14);

            OracleParameter put15 = new OracleParameter("p_rostatus", OracleType.VarChar);
            put15.Direction = ParameterDirection.Input;
            if (rostatus == "0")
            {
                put15.Value = System.DBNull.Value;
            }
            else
            {
                put15.Value = rostatus;
            }
            objOraclecommand.Parameters.Add(put15);

            OracleParameter put16 = new OracleParameter("p_booktype", OracleType.VarChar);
            put16.Direction = ParameterDirection.Input;
            if (booktype == "0")
            {
                put16.Value = System.DBNull.Value;
            }
            else
            {
                put16.Value = booktype;
            }
            objOraclecommand.Parameters.Add(put16);

            OracleParameter put17 = new OracleParameter("p_contractname", OracleType.VarChar);
            put17.Direction = ParameterDirection.Input;
            if (contractname == "0")
            {
                put17.Value = System.DBNull.Value;
            }
            else
            {
                put17.Value = contractname;
            }
            objOraclecommand.Parameters.Add(put17);
            OracleParameter put18 = new OracleParameter("p_filterby", OracleType.VarChar);
            put18.Direction = ParameterDirection.Input;
            if (filterby == "0")
            {
                put18.Value = System.DBNull.Value;
            }
            else
            {
                put18.Value = filterby;
            }
            objOraclecommand.Parameters.Add(put18);

            OracleParameter put19 = new OracleParameter("p_adcheck", OracleType.VarChar);
            put19.Direction = ParameterDirection.Input;
            if (adcheck == "0")
            {
                put19.Value = System.DBNull.Value;
            }
            else
            {
                put19.Value = adcheck;
            }
            objOraclecommand.Parameters.Add(put19);

            OracleParameter putd9 = new OracleParameter("p_state", OracleType.VarChar);
            putd9.Direction = ParameterDirection.Input;
            if (state == "0" || state == "" || state == "Select State")
            {
                putd9.Value = System.DBNull.Value;
            }
            else
            {
                putd9.Value = state;
            }
            objOraclecommand.Parameters.Add(putd9);


            OracleParameter putn9 = new OracleParameter("p_taluka", OracleType.VarChar);
            putn9.Direction = ParameterDirection.Input;
            if (taluka == "0" || taluka == "")
            {
                putn9.Value = System.DBNull.Value;
            }
            else
            {
                putn9.Value = taluka;
            }
            objOraclecommand.Parameters.Add(putn9);

            OracleParameter putj9 = new OracleParameter("p_base", OracleType.VarChar);
            putj9.Direction = ParameterDirection.Input;
            if (based == "0" || based == "")
            {
                putj9.Value = System.DBNull.Value;
            }
            else
            {
                putj9.Value = based;
            }
            objOraclecommand.Parameters.Add(putj9);

            OracleParameter sq = new OracleParameter("p_drpstatus", OracleType.VarChar);
            sq.Direction = ParameterDirection.Input;
            if (status == "0")
            {
                sq.Value = System.DBNull.Value;
            }
            else
            {
                sq.Value = status;
            }
            objOraclecommand.Parameters.Add(sq);

            OracleParameter srq = new OracleParameter("p_insertstatus", OracleType.VarChar);
            srq.Direction = ParameterDirection.Input;
            if (insertsts == "0")
            {
                srq.Value = System.DBNull.Value;
            }
            else
            {
                srq.Value = insertsts;
            }
            objOraclecommand.Parameters.Add(srq);



            OracleParameter sq3 = new OracleParameter("p_chkdetail", OracleType.VarChar);
            sq3.Direction = ParameterDirection.Input;

            sq3.Value = chkdetail;

            objOraclecommand.Parameters.Add(sq3);

            OracleParameter srq100 = new OracleParameter("p_baxcode", OracleType.VarChar);
            srq100.Direction = ParameterDirection.Input;
            if (box == "0")
            {
                srq100.Value = System.DBNull.Value;
            }
            else
            {
                srq100.Value = box;
            }
            objOraclecommand.Parameters.Add(srq100);

            OracleParameter srq101 = new OracleParameter("p_fmgreason", OracleType.VarChar);
            srq101.Direction = ParameterDirection.Input;
            if (fmgregion == "0")
            {
                srq101.Value = System.DBNull.Value;
            }
            else
            {
                srq101.Value = fmgregion;
            }
            objOraclecommand.Parameters.Add(srq101);

            objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
            objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

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

    public DataSet statebind(string compcode, string userid)
    {
        string zonename = "";
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("statebind.statebind_P", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            //OracleParameter prm01 = new OracleParameter("countrycode", OracleType.VarChar);
            //prm01.Direction = ParameterDirection.Input;
            //if (country == "0" || country == "")
            //    prm01.Value = System.DBNull.Value;
            //else
            //    prm01.Value = country;
            //objOraclecommand.Parameters.Add(prm01);
            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
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
    public DataSet talukabind(string compcode, string dist_code)
    {
        string zonename = "";
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("BINDTALUKA.BINDTALUKA_P", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm3 = new OracleParameter("pdist_code", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (dist_code == "0" || dist_code == "")
                prm3.Value = System.DBNull.Value;
            else
                prm3.Value = dist_code;
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

    
    public DataSet cat345(string adcat, string compcode, string adcat4, string adcat5)
    {
        string zonename = "";
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindadcat345.bindadcat345_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

           

            OracleParameter prm3 = new OracleParameter("adcat", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = adcat;
            objOraclecommand.Parameters.Add(prm3);


            OracleParameter prm31 = new OracleParameter("adsubcat", OracleType.VarChar);
            prm31.Direction = ParameterDirection.Input;
            prm31.Value = adcat4;
            objOraclecommand.Parameters.Add(prm31);

            OracleParameter prm311 = new OracleParameter("adssubcat", OracleType.VarChar);
            prm311.Direction = ParameterDirection.Input;
            prm311.Value = adcat5;
            objOraclecommand.Parameters.Add(prm311);

            
            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;
            objOraclecommand.Parameters.Add("P_Accounts2", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts2"].Direction = ParameterDirection.Output;


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
    public DataSet getSubCategory(string compcode, string catcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("advsubcattyp.advsubcattyp_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;





            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);



            OracleParameter prm6 = new OracleParameter("catcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = catcode;
            objOraclecommand.Parameters.Add(prm6);
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
    public DataSet packagebind(string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindpackage.bindpackage_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);

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
    public DataSet ratecdbind(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("xlsratecode.xlsratecode_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;



            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

           
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
    public DataSet bindratetype(string Compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("ratetype.ratetype_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = Compcode;
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
    
         public DataSet bindscheme(string Compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("schemename.schemename_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = Compcode;
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
    public DataSet bindcontract(string Compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("contractname.contractname_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = Compcode;
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
    public DataSet bindpagetype(string Compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindpagetype.bindpagetype_P", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = Compcode;
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
    public DataSet bindvarient(string brand, string Compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("AN_BRANDVARIENT.AN_BRANDVARIENT_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;
            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = Compcode;
            objOraclecommand.Parameters.Add(prm1);
            OracleParameter prm2 = new OracleParameter("brand", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = brand;
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

    public DataSet bindBrand(string compcode, string procat)
    {

       
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_getBrand.websp_getBrand_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("procat", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = procat;
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

    public DataSet agbnd(string comcode, string ag)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("ag_agtype.ag_agtype_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;




            OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = comcode;
            objOraclecommand.Parameters.Add(prm3);
            OracleParameter prm4 = new OracleParameter("agencytype", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = ag;
            objOraclecommand.Parameters.Add(prm4);
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
            objOracleConnection.Close();
        }
    }
    public DataSet pubsupply(string comcode, string edit)
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
            prm3.Value = comcode;
            objOraclecommand.Parameters.Add(prm3);
            OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = edit;
            objOraclecommand.Parameters.Add(prm4);
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
            objOracleConnection.Close();
        }
    }
    public DataSet distcity(string dist, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("dist_city.dist_city_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("district", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = dist;
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

    public DataSet district(string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("CityMst_District.CityMst_District_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
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
            CloseConnection(ref objOracleConnection);
        }
    }


    public DataSet bind_district2(string compcode, string userid, string extra1)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("getdistrict", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (extra1=="")
                prm3.Value = System.DBNull.Value;
            else
            prm3.Value = extra1;
            objOraclecommand.Parameters.Add(prm3);


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
            CloseConnection(ref objOracleConnection);
        }
    }




    public DataSet state(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("DistrictMst_State.DistrictMst_State_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;



            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

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

    public DataSet addzone(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("zonebind.zonebind_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
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

    public DataSet adbranch(string compcode)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();

            objOraclecommand = GetCommand("branchbind_adv.branchbind_adv_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = compcode;
            objOraclecommand.Parameters.Add(prm11);

            objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
            objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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





    public DataSet spfun1(string adtype, string adcategory, string adsubcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string clientname, string status, string hold, string agentyp, string useid, string chk_acc, string branch, string print_cent, string docket, string searching, string extra1, string extra2, string extra3, string extra4, string extra5,string currencytype)
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


            objOraclecommand = GetCommand("reportnew1", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter temp1 = new OracleParameter("agname", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;
            temp1.Value = agname;
            objOraclecommand.Parameters.Add(temp1);

            OracleParameter temp2 = new OracleParameter("clientname", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;
            temp2.Value = clientname;
            objOraclecommand.Parameters.Add(temp2);

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


            OracleParameter prm255 = new OracleParameter("Adsubcategory", OracleType.VarChar);
            prm255.Direction = ParameterDirection.Input;
            if (adsubcategory == "")
            {
                prm255.Value = System.DBNull.Value;
            }
            else
            {


                prm255.Value = adsubcategory;
            }
            objOraclecommand.Parameters.Add(prm255);


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
            //if (pubcent == "0")
            //{
            //    prm7.Value = System.DBNull.Value;
            //}
            //else
            //{
            //    prm7.Value = pubcent;
            //}
            prm7.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter temp3 = new OracleParameter("status", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            temp3.Value = status;
            objOraclecommand.Parameters.Add(temp3);


            OracleParameter prm8 = new OracleParameter("edition", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (edition == "0" || edition == "'--Select Edition Name--' ")
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

            OracleParameter temp4 = new OracleParameter("hold", OracleType.VarChar);
            temp4.Direction = ParameterDirection.Input;
            temp4.Value = hold;
            objOraclecommand.Parameters.Add(temp4);



            OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = descid;
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter tmp33 = new OracleParameter("agtype", OracleType.VarChar);
            tmp33.Direction = ParameterDirection.Input;
            if (agentyp == "0" || agentyp == "--Select AgencyType--")
            {
                tmp33.Value = System.DBNull.Value;
            }
            else
            {
                tmp33.Value = agentyp;
            }
            objOraclecommand.Parameters.Add(tmp33);

            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

          
            OracleParameter po1 = new OracleParameter("pbranch", OracleType.VarChar);
            po1.Direction = ParameterDirection.Input;
            if (branch == "0" || branch == "Select Branch")
            {
                po1.Value = System.DBNull.Value;
            }
            else
            {
                po1.Value = branch;
            }
            objOraclecommand.Parameters.Add(po1);

            OracleParameter po2 = new OracleParameter("pprint_center", OracleType.VarChar);
            po2.Direction = ParameterDirection.Input;
            if (print_cent == "0")
            {
                po2.Value = System.DBNull.Value;
            }
            else
            {
                po2.Value = print_cent;
            }
            objOraclecommand.Parameters.Add(po2);


            OracleParameter doc1 = new OracleParameter("pwithout_rono", OracleType.VarChar);
            doc1.Direction = ParameterDirection.Input;
            doc1.Value = docket;
            objOraclecommand.Parameters.Add(doc1);



            OracleParameter ser1 = new OracleParameter("pdate_flag", OracleType.VarChar);
            ser1.Direction = ParameterDirection.Input;
            ser1.Value = searching;
            objOraclecommand.Parameters.Add(ser1);

            OracleParameter ser8 = new OracleParameter("pinclude", OracleType.VarChar);
            ser8.Direction = ParameterDirection.Input;
            ser8.Value = searching;
            objOraclecommand.Parameters.Add(ser8);


            OracleParameter ser2 = new OracleParameter("pextra1", OracleType.VarChar);
            ser2.Direction = ParameterDirection.Input;

            if (extra1 == "0" || extra1 == "--Select UOM Name--")
            {
                ser2.Value = System.DBNull.Value;
            }
            else
            {
                ser2.Value = extra1;
            }

            objOraclecommand.Parameters.Add(ser2);

            OracleParameter ser3 = new OracleParameter("pextra2", OracleType.VarChar);
            ser3.Direction = ParameterDirection.Input;   
            if (extra2 == "" || extra2 == "0")
            {
                ser3.Value = System.DBNull.Value; 
            }
            else
            {
                ser3.Value = extra2;
            }          
           objOraclecommand.Parameters.Add(ser3);

            OracleParameter ser4 = new OracleParameter("pextra3", OracleType.VarChar);
            ser4.Direction = ParameterDirection.Input;
            if (extra3 == "" || extra3 == "0")
            {
                ser4.Value = System.DBNull.Value;
            }
            else
            {
                ser4.Value = extra3;
            }  
          
            objOraclecommand.Parameters.Add(ser4);

            OracleParameter ser5 = new OracleParameter("pextra4", OracleType.VarChar);
            ser5.Direction = ParameterDirection.Input;
            if (extra4 == "" || extra4 == "0")
            {
                //ser5.Value = System.DBNull.Value;
                ser5.Value = extra4;
            }
            else
            {
                ser5.Value = extra4;
            } 
         
            objOraclecommand.Parameters.Add(ser5);

            OracleParameter ser6 = new OracleParameter("pextra5", OracleType.VarChar);
            ser6.Direction = ParameterDirection.Input;
            if (extra5 == "" || extra5 == "0")
            {
                //ser6.Value = System.DBNull.Value;
                ser6.Value = extra5;
            }
            else
            {
                ser6.Value = extra5;
            }
         
            objOraclecommand.Parameters.Add(ser6);

            OracleParameter ser9 = new OracleParameter("pextra6", OracleType.VarChar);
            ser9.Direction = ParameterDirection.Input;
            ser9.Value = System.DBNull.Value;
               
           objOraclecommand.Parameters.Add(ser9);





            OracleParameter ser7 = new OracleParameter("pextra7", OracleType.VarChar);
                 ser7.Direction = ParameterDirection.Input;
                 if (currencytype == "" || currencytype == "0")
            {

                ser7.Value = currencytype;
            }
            else
            {
                ser7.Value = currencytype;
            }

                 objOraclecommand.Parameters.Add(ser7);

                 OracleParameter ser10 = new OracleParameter("pextra8", OracleType.VarChar);
                 ser10.Direction = ParameterDirection.Input;
                 ser10.Value = System.DBNull.Value;

                 objOraclecommand.Parameters.Add(ser10);

                 OracleParameter ser11 = new OracleParameter("pextra9", OracleType.VarChar);
                 ser11.Direction = ParameterDirection.Input;
                 ser11.Value = System.DBNull.Value;

                 objOraclecommand.Parameters.Add(ser11);



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
    public DataSet pub_cent_NEW(string compcode,string chk_access,string useid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("Bind_PubCentName_r.Bind_PubCentName_r_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;



            OracleParameter prm1 = new OracleParameter("puserid", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = useid;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("chk_access", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = chk_access;
            objOraclecommand.Parameters.Add(prm2);

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
    public DataSet bind_print(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("bind_printcenter.bind_printcenter_p", ref objOracleConnection);
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

   
    public DataSet premiumbind(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindpremiumforrate_report.bindpremiumforrate_report_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;





            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return (objDataSet);


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


 public DataSet bindPagePosition(string compcode)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_getPagePosition.websp_getPagePosition_p", ref objOracleConnection);
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
    public DataSet displayonscreenreport(string frmdt, string todate, string compcode, string publication, string status, string edition, string pubcenter, string adtype, string adcategory, string dateformate, string descid, string ascdesc, string supplement, string package1, string editiondetail, string useid, string chk_acc, string branch, string ro_statuscod)
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

            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

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

            OracleParameter e4 = new OracleParameter("supplement_name", OracleType.VarChar, 50);
            e4.Direction = ParameterDirection.Input;
            if (supplement != "0" && supplement != "")
            {
                e4.Value = supplement;
            }
            else
            {
                e4.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(e4);



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
            if (frmdt != "0" && frmdt != "")
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
            if (todate != "0" && todate != "")
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
            if (edition == "0" || edition == "")
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
            if (status == "cancel")
            {
                prm12.Value = "includecancel";
            }
            else if (status == "hold")
            {
                prm12.Value = "includehold";
            }
            else
            {
                prm12.Value = "cancel";
            }



            //prm12.Value = status;
            objOraclecommand.Parameters.Add(prm12);



            OracleParameter prm13 = new OracleParameter("packagecode", OracleType.VarChar, 50);
            prm13.Direction = ParameterDirection.Input;
            if (package1 == "0" || package1 == "")
            {
                prm13.Value = System.DBNull.Value;
            }
            else
            {
                prm13.Value = package1;
            }
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter prm14 = new OracleParameter("editiondtl", OracleType.VarChar, 50);
            prm14.Direction = ParameterDirection.Input;
            //if (editiondetail == "0" || editiondetail == "")
            //{
            //    prm14.Value = System.DBNull.Value;
            //}
            //else
            //{
            prm14.Value = editiondetail;
            // }
            objOraclecommand.Parameters.Add(prm14);


            OracleParameter prm15 = new OracleParameter("p_branch", OracleType.VarChar, 50);
            prm15.Direction = ParameterDirection.Input;
            if (branch == "0" || branch == "")
            {
                prm15.Value = System.DBNull.Value;
            }
            else
            {
                prm15.Value = branch;
            }
            objOraclecommand.Parameters.Add(prm15);

            OracleParameter prm16 = new OracleParameter("ro_statusres", OracleType.VarChar, 50);
            prm16.Direction = ParameterDirection.Input;

            prm16.Value = ro_statuscod;

            objOraclecommand.Parameters.Add(prm16);


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


    public DataSet spclient(string cliname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string status, string hold, string agentyp, string useid, string chk_acc,string branch)
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

            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("clientname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (cliname == "0" || cliname == "")
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
            //prm8.Value = System.DBNull.Value;
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

            OracleParameter tmp33 = new OracleParameter("agtype", OracleType.VarChar);
            tmp33.Direction = ParameterDirection.Input;
            if (agentyp == "0" || agentyp == "--Select AgencyType--")
            {
                tmp33.Value = System.DBNull.Value;
            }
            else
            {
                tmp33.Value = agentyp;
            }
            objOraclecommand.Parameters.Add(tmp33);


            OracleParameter prm81 = new OracleParameter("pbranch", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (branch == "0")
            {
                prm81.Value = System.DBNull.Value;
            }
            else
            {
                prm81.Value = branch;
            }
            objOraclecommand.Parameters.Add(prm81);

            objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

            //objOraclecommand.Parameters.Add("p_reportnew1", OracleType.Cursor);
            //objOraclecommand.Parameters["p_reportnew1"].Direction = ParameterDirection.Output;


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

            objOraclecommand.Parameters.Add("p_reportnew1", OracleType.Cursor);
            objOraclecommand.Parameters["p_reportnew1"].Direction = ParameterDirection.Output;


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
    public DataSet clientxls(string compcode,string cli)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindclientforxls.bindclientforxls_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);
            OracleParameter prm1 = new OracleParameter("client", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = cli;
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

    public DataSet spAgency(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string clientname, string extra2, string hold, string agentyp, string useid, string chk_acc, string branch)
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

            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("agname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (agname == "0" || agname=="")
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
            if (fromdate == "0" || fromdate=="")
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
            if (dateto == "0" || dateto=="")
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
            temp2.Value = extra2;
            objOraclecommand.Parameters.Add(temp2);

            OracleParameter temp3 = new OracleParameter("hold", OracleType.VarChar);
            temp3.Direction = ParameterDirection.Input;
            temp3.Value = hold;
            objOraclecommand.Parameters.Add(temp3);

            OracleParameter tmp33 = new OracleParameter("agtype", OracleType.VarChar);
            tmp33.Direction = ParameterDirection.Input;
            if (agentyp == "0" || agentyp == "--Select AgencyType--")
            {
                tmp33.Value = System.DBNull.Value;
            }
            else
            {
                tmp33.Value = agentyp;
            }
            objOraclecommand.Parameters.Add(tmp33);

            OracleParameter prm81 = new OracleParameter("pbranch", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (branch == "0")
            {
                prm81.Value = System.DBNull.Value;
            }
            else
            {
                prm81.Value = branch;
            }
            objOraclecommand.Parameters.Add(prm81);

            objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

            //objOraclecommand.Parameters.Add("p_reportnew1", OracleType.Cursor);
            //objOraclecommand.Parameters["p_reportnew1"].Direction = ParameterDirection.Output;


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

    public DataSet agencyxls(string compcode,string agen)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindagencyforxls.bindagencyforxls_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm1 = new OracleParameter("agency", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = agen;
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
    public DataSet agencyxlsmain(string compcode, string agen)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindagencyforxls.bindagencyforxls_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm1 = new OracleParameter("agency", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = agen;
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

   
    public DataSet bindagencyall(string compcode, string userid, string agency)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindagencyforall_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);
            OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = agency;
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

    public DataSet agencyxlschild(string compcode, string agen)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindagencyforxls_child.bindagencyforxls_child_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm1 = new OracleParameter("agency", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = agen;
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


//--------------------for  barter  report--------------------------------------//
//----------------------------------------------------------------------------//
   /* public DataSet bindregion(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("sp_region.sp_region_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm5 = new OracleParameter("Compcode", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
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
    }*/

    public DataSet product(string region, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("Sp_Publication.Sp_Publication_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm4 = new OracleParameter("Region", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = region;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
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

    public DataSet bindclient(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindclient11.bindclient11_p", ref objOracleConnection);
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

    public DataSet bindagency(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindagency11.bindagency11_p", ref objOracleConnection);
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

    public DataSet barter_report(string frmdt, string todate, string compcode, string client, string agency, string region, string product, string booktype, string dateformate, string descid, string ascdesc, string pub_center, string useid, string chk_acc)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("Barter_Report.bill_report_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter p11 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
            p11.Direction = ParameterDirection.Input;
            if (pub_center != "0")
            {
                p11.Value = pub_center;
            }
            else
            {
                p11.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(p11);
            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);


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

            OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
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
                prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("dateformat", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = dateformate;
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm2 = new OracleParameter("product", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (product != "0")
            {
                prm2.Value = product;
            }
            else
            {
                prm2.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm4 = new OracleParameter("Region", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            if (region != "0")
            {
                prm4.Value = region;
            }
            else
            {
                prm4.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm3 = new OracleParameter("descid", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = descid;
            objOraclecommand.Parameters.Add(prm3);


            OracleParameter prm6 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm9= new OracleParameter("agency", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            if (agency != "0" && agency!="")
            {
                prm9.Value = agency;
            }
            else
            {
                prm9.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("client", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            if (client != "0" && client!="")
            {
                prm10.Value = client;
            }
            else
            {
                prm10.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("booktype", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = booktype;
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



 public DataSet drilloutstatus(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string status, string descid, string ascdesc, string temp1, string temp2, string temp3)
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
                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm8 = new OracleParameter("agname", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (agency == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = agency;
            }
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm7 = new OracleParameter("clientname", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (client == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = client;
            }
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm15 = new OracleParameter("Adtype1", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            if (adtyp == "0")
            {
                prm15.Value = System.DBNull.Value;
            }
            else
            {
                prm15.Value = adtyp;
            }
            objOraclecommand.Parameters.Add(prm15);

            OracleParameter prm16 = new OracleParameter("adcategory", OracleType.VarChar);
            prm16.Direction = ParameterDirection.Input;
            if (adcat == "0")
            {
                prm16.Value = System.DBNull.Value;
            }
            else
            {
                prm16.Value = adcat;
            }
            objOraclecommand.Parameters.Add(prm16);

            OracleParameter prm17 = new OracleParameter("pub_name", OracleType.VarChar);
            prm17.Direction = ParameterDirection.Input;
            if (publ == "0")
            {
                prm17.Value = System.DBNull.Value;
            }
            else
            {
                prm17.Value = publ;
            }
            objOraclecommand.Parameters.Add(prm17);


            OracleParameter prm18 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm18.Direction = ParameterDirection.Input;
            if (pubcen == "0")
            {
                prm18.Value = System.DBNull.Value;
            }
            else
            {
                prm18.Value = pubcen;
            }
            objOraclecommand.Parameters.Add(prm18);

            OracleParameter prm19 = new OracleParameter("edition", OracleType.VarChar);
            prm19.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm19.Value = System.DBNull.Value;
            }
            else
            {
                prm19.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm19);



            OracleParameter prm20 = new OracleParameter("PACKAGE1", OracleType.VarChar);
            prm20.Direction = ParameterDirection.Input;
            if (package == "0")
            {
                prm20.Value = System.DBNull.Value;
            }
            else
            {
                prm20.Value = package;
            }
            objOraclecommand.Parameters.Add(prm20);


            OracleParameter prm21 = new OracleParameter("status", OracleType.VarChar);
            prm21.Direction = ParameterDirection.Input;
            if (status == "0")
            {
                prm21.Value = System.DBNull.Value;
            }
            else
            {
                prm21.Value = status;
            }
            objOraclecommand.Parameters.Add(prm21);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);


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

            OracleParameter tmp1 = new OracleParameter("hold", OracleType.VarChar);
            tmp1.Direction = ParameterDirection.Input;
            tmp1.Value = temp1;
            objOraclecommand.Parameters.Add(tmp1);



            OracleParameter tmp2 = new OracleParameter("page", OracleType.VarChar);
            tmp2.Direction = ParameterDirection.Input;
            tmp2.Value = temp2;
            objOraclecommand.Parameters.Add(tmp2);


            OracleParameter tmp3 = new OracleParameter("position", OracleType.VarChar);
            tmp3.Direction = ParameterDirection.Input;
            tmp3.Value = temp3;
            objOraclecommand.Parameters.Add(tmp3);

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



  public DataSet statusdrilloutpdf(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string status, string descid, string ascdesc, string temp1, string temp2, string temp3)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("Report_drillout.Report_drillout_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("clientname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (client != "0")
            {
                prm1.Value = client;
            }
            else
            {
                prm1.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("agname", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (agency != "0")
            {
                prm2.Value = agency;
            }
            else
            {
                prm2.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm2);



            OracleParameter prm3 = new OracleParameter("Adtype1", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (adtyp != "0")
            {
                prm3.Value = adtyp;
            }
            else
            {
                prm3.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("adcategory", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (adcat != "0")
            {
                prm4.Value = adcat;
            }
            else
            {
                prm4.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("fromdate", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (fromdt != "")
            {
                prm5.Value = Convert.ToDateTime(fromdt).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm5.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm5);


            OracleParameter prm6 = new OracleParameter("dateto", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            if (dateto != "")
            {
                prm6.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm6.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = compcode;
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("pub_name", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (publ != "0")
            {
                prm8.Value = publ;
            }
            else
            {
                prm8.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (pubcen != "0")
            {
                prm9.Value = pubcen;
            }
            else
            {
                prm9.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm9);


            OracleParameter prm10 = new OracleParameter("edition", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            if (edition != "0")
            {
                prm10.Value = edition;
            }
            else
            {
                prm10.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm10);


            OracleParameter prm11 = new OracleParameter("PACKAGE1", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            if (package != "0")
            {
                prm11.Value = package;
            }
            else
            {
                prm11.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm11);


            OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = dateformat;
            objOraclecommand.Parameters.Add(prm12);


            OracleParameter prm13 = new OracleParameter("status", OracleType.VarChar);
            prm13.Direction = ParameterDirection.Input;
            if (status != "0")
            {
                prm13.Value = status;
            }
            else
            {
                prm13.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter prm14 = new OracleParameter("descid", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = descid;
            objOraclecommand.Parameters.Add(prm14);

            OracleParameter prm15 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm15);


            OracleParameter tmp1 = new OracleParameter("page", OracleType.VarChar);
            tmp1.Direction = ParameterDirection.Input;
            tmp1.Value = temp1;
            objOraclecommand.Parameters.Add(tmp1);

            OracleParameter tmp2 = new OracleParameter("position", OracleType.VarChar);
            tmp2.Direction = ParameterDirection.Input;
            tmp2.Value = temp2;
            objOraclecommand.Parameters.Add(tmp2);

            OracleParameter tmp3 = new OracleParameter("hold", OracleType.VarChar);
            tmp3.Direction = ParameterDirection.Input;
            tmp3.Value = temp3;
            objOraclecommand.Parameters.Add(tmp3);

            objOraclecommand.Parameters.Add("P_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_accounts"].Direction = ParameterDirection.Output;



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


//============================================end of Barter Report===============================//

    public DataSet bindrevenuecenter(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindrevenuecenter", ref objOracleConnection);
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




    public DataSet displayonscreenreport1(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("Schedulereport.Schedulereport_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (frmdt == "0")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {
                prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (todate == "0")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {
                prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);


            OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (publication == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = publication;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm18 = new OracleParameter("dateformat", OracleType.VarChar);
            prm18.Direction = ParameterDirection.Input;
            prm18.Value = dateformate;
            objOraclecommand.Parameters.Add(prm18);

            OracleParameter prm17 = new OracleParameter("adtyp", OracleType.VarChar);
            prm17.Direction = ParameterDirection.Input;
            prm17.Value = adtyp;
            objOraclecommand.Parameters.Add(prm17);

            OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = descid;
            objOraclecommand.Parameters.Add(prm15);

            OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm16.Direction = ParameterDirection.Input;
            prm16.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm16);

            OracleParameter prm116 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm116.Direction = ParameterDirection.Input;
            if (pubcent == "0")
            {
                prm116.Value = System.DBNull.Value;
            }
            else
            {
                prm116.Value = pubcent;
            }
            objOraclecommand.Parameters.Add(prm116);


            OracleParameter prm161 = new OracleParameter("value", OracleType.VarChar);
            prm161.Direction = ParameterDirection.Input;
            prm161.Value = value;
            objOraclecommand.Parameters.Add(prm161);




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


    public DataSet schedule_drillout1(string frmdt, string todate, string client, string compcode, string dateformate, string package, string agency, string publication, string descid, string ascdesc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("ScheduleReport_drillout.ScheduleReport_drillout_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (frmdt == "")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {
                prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (todate == "")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {
                prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);


            OracleParameter prm7 = new OracleParameter("publication", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (publication == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = publication;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("agency", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (agency == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = agency;
            }
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm9 = new OracleParameter("client", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (client == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = client;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("package1", OracleType.VarChar);
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
            prm11.Value = dateformate;
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter prm12 = new OracleParameter("descid", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = descid;
            objOraclecommand.Parameters.Add(prm12);

            OracleParameter prm14 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm14);


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



    public OracleDataReader scheduleexcel_drillout1(string frmdt, string todate, string client, string compcode, string dateformate, string package, string agency, string publication)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("ScheduleReport_drillout.ScheduleReport_drillout_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            if (frmdt == "0")
            {
                prm4.Value = System.DBNull.Value;
            }
            else
            {
                prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            if (todate == "0")
            {
                prm5.Value = System.DBNull.Value;
            }
            else
            {
                prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = compcode;
            objOraclecommand.Parameters.Add(prm6);


            OracleParameter prm7 = new OracleParameter("publication", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (publication == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = publication;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("agency", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (agency == "0")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = agency;
            }
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm9 = new OracleParameter("client", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (client == "0")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = client;
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
            prm11.Value = dateformate;
            objOraclecommand.Parameters.Add(prm11);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
    public DataSet bind_user(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bind_username.bind_username_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("roleid", OracleType.VarChar, 50);
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
    public DataSet money_report(string frmdt, string todate, string compcode, string client, string agency, string dateformate, string paymode, string adtype, string branch, string userid, string pubcent, string useid, string chk_acc, string puom,string currency)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("Money_Rep", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm9 = new OracleParameter("agname", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            if (agency != "0" && agency != "")
            {
                prm9.Value = agency;
            }
            else
            {
                prm9.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm9);

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

            OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
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
                prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm8 = new OracleParameter("dateformat", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = dateformate;
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm10 = new OracleParameter("client", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            if (client != "0" && client != "")
            {
                prm10.Value = client;
            }
            else
            {
                prm10.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm1h = new OracleParameter("agencypay", OracleType.VarChar, 50);
            prm1h.Direction = ParameterDirection.Input;
            if (paymode != "0")
            {
                prm1h.Value = paymode;
            }
            else
            {
                prm1h.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm1h);

            OracleParameter prm2h = new OracleParameter("advtype", OracleType.VarChar, 50);
            prm2h.Direction = ParameterDirection.Input;
            if (adtype == "0")
            {
                prm2h.Value = System.DBNull.Value;

            }
            else
            {
                prm2h.Value = adtype;
            }
            objOraclecommand.Parameters.Add(prm2h);

            OracleParameter w1 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
            w1.Direction = ParameterDirection.Input;
            if (pubcent != "0")
            {
                w1.Value = pubcent;
            }
            else
            {
                w1.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(w1);


            OracleParameter top11 = new OracleParameter("puserid", OracleType.VarChar);
            top11.Direction = ParameterDirection.Input;
            top11.Value = useid;
            objOraclecommand.Parameters.Add(top11);

            OracleParameter top22 = new OracleParameter("chk_access", OracleType.VarChar);
            top22.Direction = ParameterDirection.Input;
            top22.Value = chk_acc;
            objOraclecommand.Parameters.Add(top22);

            
            OracleParameter top1 = new OracleParameter("useridcode", OracleType.VarChar, 50);
            top1.Direction = ParameterDirection.Input;
            //top1.Value = userid;
            if (userid == "0")
            {
                top1.Value = System.DBNull.Value;

            }
            else
            {
                top1.Value = userid;
            }
            objOraclecommand.Parameters.Add(top1);



            OracleParameter top2 = new OracleParameter("pbranch", OracleType.VarChar, 50);
            top2.Direction = ParameterDirection.Input;
            if (branch == "0" || branch == "--Select Branch--")
            {
                top2.Value = System.DBNull.Value;
               
            }
            else
            {
                top2.Value = branch;
            }
            objOraclecommand.Parameters.Add(top2);


            OracleParameter prm12 = new OracleParameter("p_uom", OracleType.VarChar, 50);
            prm12.Direction = ParameterDirection.Input;
            if (puom == "0" || puom == "")
                prm12.Value = System.DBNull.Value;
            else
                prm12.Value = puom;
            objOraclecommand.Parameters.Add(prm12);
           
           

            //OracleParameter prm0 = new OracleParameter("pcurency", OracleType.VarChar, 10);
            //prm0.Direction = ParameterDirection.Input;
            //prm0.Value = compcode;
            //objOraclecommand.Parameters.Add(prm0);

            

           

          


           

            objOraclecommand.Parameters.Add("p_recordsetnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_recordsetnew"].Direction = ParameterDirection.Output;

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



    public DataSet packagewise(string frmdt, string todate, string compcode, string client, string agency, string dateformate, string package,string adtype,string publication,string pubcenter,string edition)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("package_Rep", ref objOracleConnection);
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

            OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
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
                prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("dateformat", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = dateformate;
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);



            OracleParameter prm9 = new OracleParameter("agname", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            if (agency != "0")
            {
                prm9.Value = agency;
            }
            else
            {
                prm9.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("client", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            if (client != "0")
            {
                prm10.Value = client;
            }
            else
            {
                prm10.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm1h = new OracleParameter("packagecode", OracleType.VarChar, 50);
            prm1h.Direction = ParameterDirection.Input;
            if (package != "0")
            {
                prm1h.Value = package;
            }
            else
            {
                prm1h.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm1h);

            OracleParameter prm11 = new OracleParameter("publ", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            if (publication != "0")
            {
                prm11.Value = publication;
            }
            else
            {
                prm11.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter prm12 = new OracleParameter("pubcent", OracleType.VarChar, 50);
            prm12.Direction = ParameterDirection.Input;
            if (pubcenter != "0")
            {
                prm12.Value = pubcenter;
            }
            else
            {
                prm12.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm12);

            OracleParameter prm13 = new OracleParameter("edition", OracleType.VarChar, 50);
            prm13.Direction = ParameterDirection.Input;
            if (edition != "0")
            {
                prm13.Value = edition;
            }
            else
            {
                prm13.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter prm14 = new OracleParameter("adtype1", OracleType.VarChar, 50);
            prm14.Direction = ParameterDirection.Input;
            if (adtype != "0")
            {
                prm14.Value = adtype;
            }
            else
            {
                prm14.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm14);

            objOraclecommand.Parameters.Add("p_recordsetnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_recordsetnew"].Direction = ParameterDirection.Output;

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

    public DataSet netamtreportinsert(string frmdt, string todate, string compcode, string dateformate, string rowname, string columnname, string conditionchk, string useid, string chk_acc)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("billreportinsert", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("pfromdate", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (frmdt != "")
            {
                
                prm1.Value = frmdt;
            }
            else
            {
                prm1.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm7 = new OracleParameter("ptodate", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (todate != "")
            {
                
                prm7.Value = todate;
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pdateformat", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = dateformate;
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);



            OracleParameter prm9 = new OracleParameter("prowname", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
                prm9.Value = rowname;
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("pcolumnname", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
                prm10.Value = columnname;
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm1h = new OracleParameter("pconditioncheck", OracleType.VarChar);
            prm1h.Direction = ParameterDirection.Input;
                prm1h.Value = conditionchk;
            objOraclecommand.Parameters.Add(prm1h);



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
    public DataSet netamtreport(string frmdt, string todate, string compcode, string dateformate, string rowname, string columnname, string conditionchk, string useid, string chk_acc)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("billreport", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;
            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("pfromdate", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (frmdt != "")
            {                
                prm1.Value = frmdt;
            }
            else
            {
                prm1.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm7 = new OracleParameter("ptodate", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (todate != "")
            {
                
                prm7.Value = todate;
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("pdateformat", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = dateformate;
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);



            OracleParameter prm9 = new OracleParameter("prowname", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
                prm9.Value = rowname;
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("pcolumnname", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
                prm10.Value = columnname;
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm1h = new OracleParameter("pconditioncheck", OracleType.VarChar);
            prm1h.Direction = ParameterDirection.Input;
                prm1h.Value = conditionchk;
            objOraclecommand.Parameters.Add(prm1h);



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

    public DataSet boxcyclebind(string compcode, string center)
    {
        string zonename = "";
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("Boxbind.Boxbind_P", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;



            OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);



            OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = center;
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
       
//=================================== **** Call Procedure for Receipt Register ****=====================//
    public DataSet rpt_booking_receipt(string frmdt, string todate, string compcode, string client, string agency, string dateformate, string paymode, string adtype, string branch, string userid, string pubcent, string useid, string chk_acc, string puom)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("rpt_booking_collection", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top11 = new OracleParameter("puserid", OracleType.VarChar);
            top11.Direction = ParameterDirection.Input;
            top11.Value = useid;
            objOraclecommand.Parameters.Add(top11);

            OracleParameter top22 = new OracleParameter("chk_access", OracleType.VarChar);
            top22.Direction = ParameterDirection.Input;
            top22.Value = chk_acc;
            objOraclecommand.Parameters.Add(top22);

            OracleParameter w1 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
            w1.Direction = ParameterDirection.Input;
            if (pubcent != "0")
            {
                w1.Value = pubcent;
            }
            else
            {
                w1.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(w1);
            OracleParameter top1 = new OracleParameter("useridcode", OracleType.VarChar, 50);
            top1.Direction = ParameterDirection.Input;
            //top1.Value = userid;
            if (userid == "0")
            {
                top1.Value = System.DBNull.Value;

            }
            else
            {
                top1.Value = userid;
            }
            objOraclecommand.Parameters.Add(top1);



            OracleParameter top2 = new OracleParameter("pbranch", OracleType.VarChar, 50);
            top2.Direction = ParameterDirection.Input;
            if (branch == "0" || branch == "--Select Branch--")
            {
                top2.Value = System.DBNull.Value;

            }
            else
            {
                top2.Value = branch;
            }
            objOraclecommand.Parameters.Add(top2);

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

            OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
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
                prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm8 = new OracleParameter("dateformat", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = dateformate;
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);



            OracleParameter prm9 = new OracleParameter("agname", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            if (agency != "0" && agency != "")
            {
                prm9.Value = agency;
            }
            else
            {
                prm9.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("client", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            if (client != "0" && client != "")
            {
                prm10.Value = client;
            }
            else
            {
                prm10.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm1h = new OracleParameter("agencypay", OracleType.VarChar, 50);
            prm1h.Direction = ParameterDirection.Input;
            if (paymode != "0")
            {
                prm1h.Value = paymode;
            }
            else
            {
                prm1h.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm1h);

            OracleParameter prm2h = new OracleParameter("advtype", OracleType.VarChar, 50);
            prm2h.Direction = ParameterDirection.Input;
            if (adtype == "0")
            {
                prm2h.Value = System.DBNull.Value;

            }
            else
            {
                prm2h.Value = adtype;
            }
            objOraclecommand.Parameters.Add(prm2h);


            OracleParameter prm12 = new OracleParameter("puom_code", OracleType.VarChar, 50);
            prm12.Direction = ParameterDirection.Input;
            if (puom == "0" || puom == "")
                prm12.Value = System.DBNull.Value;
            else
                prm12.Value = puom;
            objOraclecommand.Parameters.Add(prm12);

            objOraclecommand.Parameters.Add("p_recordsetnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_recordsetnew"].Direction = ParameterDirection.Output;

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

    public DataSet spSUMMARYAgency(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string clientname, string status, string hold, string agentyp, string useid, string chk_acc, string branch)
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

            objOraclecommand = GetCommand("Reportnew1_agency_stmt", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("agname", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            if (agname == "0" || agname == "")
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
            if (fromdate == "0" || fromdate == "")
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
            if (dateto == "0" || dateto == "")
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
            //if (pubcent == "0")
            //{
            //    prm8.Value = System.DBNull.Value;
            //}
            //else
            //{
            //    prm8.Value = pubcent;
            //}
            prm8.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm8);


            OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (edition == "0"||edition =="--Select Edition Name--")
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

            OracleParameter tmp33 = new OracleParameter("agtype", OracleType.VarChar);
            tmp33.Direction = ParameterDirection.Input;
            if (agentyp == "0" || agentyp == "--Select AgencyType--")
            {
                tmp33.Value = System.DBNull.Value;
            }
            else
            {
                tmp33.Value = agentyp;
            }
            objOraclecommand.Parameters.Add(tmp33);

            OracleParameter prm81 = new OracleParameter("pbranch", OracleType.VarChar);
            prm81.Direction = ParameterDirection.Input;
            if (branch == "0")
            {
                prm81.Value = System.DBNull.Value;
            }
            else
            {
                prm81.Value = branch;
            }
            objOraclecommand.Parameters.Add(prm81);

            objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
            objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

            //objOraclecommand.Parameters.Add("p_reportnew1", OracleType.Cursor);
            //objOraclecommand.Parameters["p_reportnew1"].Direction = ParameterDirection.Output;


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

    public DataSet gvgv4321Adisplayonscreenreport1(string frmdt, string todate, string compcode, string publication, string status, string edition, string pubcenter, string adtype, string adcategory, string dateformate, string descid, string ascdesc, string supplement, string package1, string editiondetail, string useid, string chk_acc, string branch, string ro_statuscod)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("schedulereportnew", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = useid;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = chk_acc;
            objOraclecommand.Parameters.Add(top2);

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

            OracleParameter e4 = new OracleParameter("supplement_name", OracleType.VarChar, 50);
            e4.Direction = ParameterDirection.Input;
            if (supplement != "0" && supplement != "")
            {
                e4.Value = supplement;
            }
            else
            {
                e4.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(e4);



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
            if (frmdt != "0" && frmdt != "")
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
            if (todate != "0" && todate != "")
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
            if (edition == "0" || edition == "")
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
            if (status == "cancel")
            {
                prm12.Value = "includecancel";
            }
            else if (status == "hold")
            {
                prm12.Value = "includehold";
            }
            else
            {
                prm12.Value = "cancel";
            }



            //prm12.Value = status;
            objOraclecommand.Parameters.Add(prm12);



            OracleParameter prm13 = new OracleParameter("packagecode", OracleType.VarChar, 50);
            prm13.Direction = ParameterDirection.Input;
            if (package1 == "0" || package1 == "")
            {
                prm13.Value = System.DBNull.Value;
            }
            else
            {
                prm13.Value = package1;
            }
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter prm14 = new OracleParameter("editiondtl", OracleType.VarChar, 50);
            prm14.Direction = ParameterDirection.Input;
            //if (editiondetail == "0" || editiondetail == "")
            //{
            //    prm14.Value = System.DBNull.Value;
            //}
            //else
            //{
            prm14.Value = editiondetail;
            // }
            objOraclecommand.Parameters.Add(prm14);


            OracleParameter prm15 = new OracleParameter("p_branch", OracleType.VarChar, 50);
            prm15.Direction = ParameterDirection.Input;
            if (branch == "0" || branch == "")
            {
                prm15.Value = System.DBNull.Value;
            }
            else
            {
                prm15.Value = branch;
            }
            objOraclecommand.Parameters.Add(prm15);

            OracleParameter prm16 = new OracleParameter("ro_statusres", OracleType.VarChar, 50);
            prm16.Direction = ParameterDirection.Input;

            prm16.Value = ro_statuscod;

            objOraclecommand.Parameters.Add(prm16);


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


            objorclDataAdapter.SelectCommand = objOraclecommand;
            //objOraclecommand.CommandTimeout = 0;
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
    public DataSet report_pud_schedule(string agname, string clientname, string adtype, string listadcat, string listadsubcat, string fromdate, string dateto, string compcode, string pubname, string pubcent, string status, string edition, string dateformat, string ascdesc, string hold, string descid, string agencytype, string useridmain, string chk_access, string branch, string printcenter, string docket, string searching, string uom, string userid, string state, string dist, string city, string paymode, string package_code)
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


            objOraclecommand = GetCommand("schedule_register_pud_NEW", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top1 = new OracleParameter("agname", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = agname;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("clientname", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            top2.Value = clientname;
            objOraclecommand.Parameters.Add(top2);

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


            OracleParameter prm2 = new OracleParameter("Adcategory", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (listadcat == "")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {


                prm2.Value = listadcat;
            }
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm255 = new OracleParameter("Adsubcategory", OracleType.VarChar);
            prm255.Direction = ParameterDirection.Input;
            if (listadsubcat == "")
            {
                prm255.Value = System.DBNull.Value;
            }
            else
            {


                prm255.Value = listadsubcat;
            }
            objOraclecommand.Parameters.Add(prm255);

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

            OracleParameter prm327 = new OracleParameter("status", OracleType.VarChar);
            prm327.Direction = ParameterDirection.Input;
            if (status == "" || status == "0")
            {
                prm327.Value = System.DBNull.Value;
            }
            else
            {
                prm327.Value = status;
            }
            objOraclecommand.Parameters.Add(prm327);


            OracleParameter prm8 = new OracleParameter("edition", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            if (edition == "0" || edition == "--Select Edition Name--")
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

            OracleParameter temp4 = new OracleParameter("hold", OracleType.VarChar);
            temp4.Direction = ParameterDirection.Input;
            temp4.Value = hold;
            objOraclecommand.Parameters.Add(temp4);


            OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = descid;
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = ascdesc;
            objOraclecommand.Parameters.Add(prm11);


            OracleParameter tmp33 = new OracleParameter("agtype", OracleType.VarChar);
            tmp33.Direction = ParameterDirection.Input;
            if (agencytype == "0" || agencytype == "--Select AgencyType--")
            {
                tmp33.Value = System.DBNull.Value;
            }
            else
            {
                tmp33.Value = agencytype;
            }
            objOraclecommand.Parameters.Add(tmp33);


            OracleParameter temp1 = new OracleParameter("puserid", OracleType.VarChar);
            temp1.Direction = ParameterDirection.Input;
            temp1.Value = useridmain;
            objOraclecommand.Parameters.Add(temp1);

            OracleParameter temp2 = new OracleParameter("chk_access", OracleType.VarChar);
            temp2.Direction = ParameterDirection.Input;
            temp2.Value = chk_access;
            objOraclecommand.Parameters.Add(temp2);

            OracleParameter po1 = new OracleParameter("pbranch", OracleType.VarChar);
            po1.Direction = ParameterDirection.Input;
            if (branch == "0" || branch == "Select Branch")
            {
                po1.Value = System.DBNull.Value;
            }
            else
            {
                po1.Value = branch;
            }
            objOraclecommand.Parameters.Add(po1);

            OracleParameter po2 = new OracleParameter("pprint_center", OracleType.VarChar);
            po2.Direction = ParameterDirection.Input;
            if (printcenter == "0")
            {
                po2.Value = System.DBNull.Value;
            }
            else
            {
                po2.Value = printcenter;
            }
            objOraclecommand.Parameters.Add(po2);


            OracleParameter doc1 = new OracleParameter("pwithout_rono", OracleType.VarChar);
            doc1.Direction = ParameterDirection.Input;
            doc1.Value = docket;
            objOraclecommand.Parameters.Add(doc1);



            OracleParameter ser1 = new OracleParameter("pdate_flag", OracleType.VarChar);
            ser1.Direction = ParameterDirection.Input;
            ser1.Value = searching;
            objOraclecommand.Parameters.Add(ser1);


            OracleParameter ser2 = new OracleParameter("pextra1", OracleType.VarChar);
            ser2.Direction = ParameterDirection.Input;

            if (uom == "0" || uom == "--Select UOM Name--")
            {
                ser2.Value = System.DBNull.Value;
            }
            else
            {
                ser2.Value = uom;
            }

            objOraclecommand.Parameters.Add(ser2);

            OracleParameter ser3 = new OracleParameter("pextra2", OracleType.VarChar);
            ser3.Direction = ParameterDirection.Input;
            if (userid == "" || userid == "0")
            {
                ser3.Value = System.DBNull.Value;
            }
            else
            {
                ser3.Value = userid;
            }
            objOraclecommand.Parameters.Add(ser3);

            OracleParameter ser4 = new OracleParameter("pextra3", OracleType.VarChar);
            ser4.Direction = ParameterDirection.Input;
            if (state == "" || state == "0")
            {
                ser4.Value = System.DBNull.Value;
            }
            else
            {
                ser4.Value = state;
            }

            objOraclecommand.Parameters.Add(ser4);

            OracleParameter ser5 = new OracleParameter("pextra4", OracleType.VarChar);
            ser5.Direction = ParameterDirection.Input;
            if (dist == "" || dist == "0")
            {
                ser5.Value = System.DBNull.Value; ;
            }
            else
            {
                ser5.Value = dist;
            }

            objOraclecommand.Parameters.Add(ser5);

            OracleParameter ser6 = new OracleParameter("pextra5", OracleType.VarChar);
            ser6.Direction = ParameterDirection.Input;
            if (city == "" || city == "0")
            {
                ser6.Value = System.DBNull.Value;
            }
            else
            {
                ser6.Value = city;
            }

            objOraclecommand.Parameters.Add(ser6);





            OracleParameter ser7 = new OracleParameter("pextra6", OracleType.VarChar);
            ser7.Direction = ParameterDirection.Input;
            if (paymode == "" || paymode == "0")
            {
                ser7.Value = System.DBNull.Value;
            }
            else
            {
                ser7.Value = paymode;
            }

            objOraclecommand.Parameters.Add(ser7);




            OracleParameter ser8 = new OracleParameter("ppackage_code", OracleType.VarChar);
            ser8.Direction = ParameterDirection.Input;
            ser8.Value = package_code;
            objOraclecommand.Parameters.Add(ser8);





            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


            objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;

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
