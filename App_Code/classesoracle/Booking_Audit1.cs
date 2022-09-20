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

/// <summary>
/// Summary description for Booking_Audit1
/// </summary>
namespace NewAdbooking.classesoracle
{
public class Booking_Audit1:orclconnection
{
	public Booking_Audit1()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet getsection(string sectionname)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("getSectionCode", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("name_p", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = sectionname;
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



    public DataSet bookingdetailgrid(string cioid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bookingdetailgrid", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = cioid;
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



    public DataSet updateagency(string comcode, string agency, string agencysubcode, string pid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("updatechangeagency", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm3 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = comcode;
            objOraclecommand.Parameters.Add(prm3);
            OracleParameter prm4 = new OracleParameter("pagency", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = agency;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm1 = new OracleParameter("pagencysubcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = agencysubcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = pid;
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
            objOracleConnection.Close();
        }
    }



    public DataSet pubsupply_new(string comcode, string edit, string from_date, string to_date, string dateformat)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindsuppliment_datewise.bindsuppliment_datewise_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm3 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = comcode;
            objOraclecommand.Parameters.Add(prm3);
            OracleParameter prm4 = new OracleParameter("peditioncode", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = edit;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = from_date;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pto_date", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = to_date;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = dateformat;
            objOraclecommand.Parameters.Add(prm5);

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


    public DataSet bindbill_frequency()
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("get_bill_frequency.get_bill_frequency_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;



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
    public DataSet bindgrid(string dateformat, string tilldate, string fromdate, string branch1, string adtype, string audittype, string branch2, string abc_cat, string userid, string comp_code, string package_code, string agency_code, string client_code, string section_code, string booktype, string uom, string datebased,string Booking_Id)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindaudit.bindaudit_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("date1", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = dateformat;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            if (dateformat == "dd/mm/yyyy")
            {
                string[] tilldatearr = tilldate.Split('/');
                string dd1 = tilldatearr[0].ToString();
                string mm1 = tilldatearr[1].ToString();
                string yy1 = tilldatearr[2].ToString();
                tilldate = mm1 + "/" + dd1 + "/" + yy1;
            }
            prm2.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            if (dateformat == "dd/mm/yyyy")
            {
                string[] fromdatearr = fromdate.Split('/');
                string dd1 = fromdatearr[0].ToString();
                string mm1 = fromdatearr[1].ToString();
                string yy1 = fromdatearr[2].ToString();
                fromdate = mm1 + "/" + dd1 + "/" + yy1;
            }
            prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy"); ;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("branch1", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            String BRANCHNAME = branch1;
            if (branch1.IndexOf("(") >= 0)
            {
                BRANCHNAME = branch1.Substring(0, branch1.IndexOf("("));
            }
            prm4.Value = BRANCHNAME;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("adtype", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = adtype;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm7 = new OracleParameter("v_Cat", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            if (abc_cat == "0")
            {
                prm7.Value = System.DBNull.Value;
            }
            else
            {
                prm7.Value = abc_cat;
            }
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm9 = new OracleParameter("branch2", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (branch2 != "0" && branch2 != "--Select Branch--" && branch2 != "")
            {
                prm9.Value = branch2;
            }
            else
            {
                prm9.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm6 = new OracleParameter("audittype", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = audittype;
            objOraclecommand.Parameters.Add(prm6);


            OracleParameter prm16 = new OracleParameter("v_userid", OracleType.VarChar);
            prm16.Direction = ParameterDirection.Input;
            prm16.Value = userid;
            objOraclecommand.Parameters.Add(prm16);

            OracleParameter prm21 = new OracleParameter("comp_code", OracleType.VarChar);
            prm21.Direction = ParameterDirection.Input;
            prm21.Value = comp_code;
            objOraclecommand.Parameters.Add(prm21);


            OracleParameter prm17 = new OracleParameter("v_package_code", OracleType.VarChar);
            prm17.Direction = ParameterDirection.Input;
            if (package_code == "0" || package_code == "")
            {
                prm17.Value = System.DBNull.Value;
            }
            else
            {
                prm17.Value = package_code;
            }
            objOraclecommand.Parameters.Add(prm17);

            OracleParameter prm18 = new OracleParameter("pagency_code", OracleType.VarChar);
            prm18.Direction = ParameterDirection.Input;
            if (agency_code == "0" || agency_code == "")
            {
                prm18.Value = System.DBNull.Value;
            }
            else
            {
                prm18.Value = agency_code;
            }
            objOraclecommand.Parameters.Add(prm18);

            OracleParameter prm19 = new OracleParameter("pclient_code", OracleType.VarChar);
            prm19.Direction = ParameterDirection.Input;
            if (client_code == "0" || client_code == "")
            {
                prm19.Value = System.DBNull.Value;
            }
            else
            {
                prm19.Value = client_code;
            }
            objOraclecommand.Parameters.Add(prm19);

            OracleParameter prm20 = new OracleParameter("psection_code", OracleType.VarChar);
            prm20.Direction = ParameterDirection.Input;
            if (section_code == "0" || section_code == "")
            {
                prm20.Value = System.DBNull.Value;
            }
            else
            {
                prm20.Value = section_code;
            }
            objOraclecommand.Parameters.Add(prm20);

            OracleParameter prm22 = new OracleParameter("p_booktype", OracleType.VarChar);
            prm22.Direction = ParameterDirection.Input;
            prm22.Value = booktype;
            objOraclecommand.Parameters.Add(prm22);

            OracleParameter prm23 = new OracleParameter("extra1", OracleType.VarChar);
            prm23.Direction = ParameterDirection.Input;
            if (uom == "0" || uom == "")
                prm23.Value = System.DBNull.Value;
            else
                prm23.Value = uom;
            objOraclecommand.Parameters.Add(prm23);

            OracleParameter prm24 = new OracleParameter("extra2", OracleType.VarChar);
            prm24.Direction = ParameterDirection.Input;
            prm24.Value = datebased;
            objOraclecommand.Parameters.Add(prm24);

            OracleParameter prm25 = new OracleParameter("extra3", OracleType.VarChar);
            prm25.Direction = ParameterDirection.Input;
            prm25.Value = Booking_Id;
            objOraclecommand.Parameters.Add(prm25);

            OracleParameter prm26 = new OracleParameter("extra4", OracleType.VarChar);
            prm26.Direction = ParameterDirection.Input;
            prm26.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm26);

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
    public void updateaudit(string cioid, string auditname)
    {
         OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("updateauditbooking.updateauditbooking_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = cioid;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("auditname", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = auditname;
            objOraclecommand.Parameters.Add(prm2);
            objOraclecommand.ExecuteNonQuery();

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
    public DataSet getPubCenter(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_QBC_Audit.websp_QBC_Audit_p", ref objOracleConnection);
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
    public DataSet fetchMatter(string cioid,string uomdesc)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_fetchmatter.websp_fetchmatter_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("cioid1", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = cioid;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("uomdesc", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = uomdesc;
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
    public DataSet adtypbind(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("advtypbind.advtypbind_p", ref objOracleConnection);
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
    public DataSet executeauditmast1(string bookingid, string compcode, string adtype, string dateformat, string insertion)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("executebookingdispaudit.executebookingdispaudit_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("ciobookid", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = bookingid;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("booking", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = adtype;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("docno", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = insertion;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("keyno", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("rono", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("agencycode", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("client", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = dateformat;
            objOraclecommand.Parameters.Add(prm9);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_Accounts3", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts3"].Direction = ParameterDirection.Output;

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
    public DataSet updatestatus(string bookingid, string insertion, string edition)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("updatestaus.updatestaus_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm4 = new OracleParameter("ciobookid", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = bookingid;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm7 = new OracleParameter("insertion", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = insertion;
            objOraclecommand.Parameters.Add(prm7);


            OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = edition;
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
            objOracleConnection.Close();
        }

    }

    public DataSet clsPackageName(string compcode, string pkg_code)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_PackageName.websp_PackageName_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pkg_code", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = pkg_code;
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
            objOracleConnection.Close();
        }

    }

    public DataSet websp_bindgrid(string dateformat, string tilldate, string fromdate, string branch, string adtype, string publication, string pub_cent, string edition, string agency, string client, string branchnew, string retainer, string executive, string supplement, string insert_status, string uom, string userid, string Booking_Id)
    {


        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_bindaudit.websp_bindaudit_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;




            OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = dateformat;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("fromdate", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;



            if (dateformat == "dd/mm/yyyy")
            {
                string[] arr = fromdate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];

                fromdate = mm + "/" + dd + "/" + yy;


            }

            prm5.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("todate", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;

            if (dateformat == "dd/mm/yyyy")
            {
                string[] arr = tilldate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                tilldate = mm + "/" + dd + "/" + yy;


            }

            prm6.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
            objOraclecommand.Parameters.Add(prm6);


            OracleParameter prm7 = new OracleParameter("branch", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("adtype", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = adtype;
            objOraclecommand.Parameters.Add(prm8);

            /////

            OracleParameter prm9 = new OracleParameter("publication", OracleType.VarChar);
            prm9.Direction = ParameterDirection.Input;
            if (publication == "0")
            {
                prm9.Value = System.DBNull.Value;

            }
            else
            {
                prm9.Value = publication;
            }
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("pub_cent", OracleType.VarChar);
            prm10.Direction = ParameterDirection.Input;
            if (pub_cent == "0")
            {
                prm10.Value = System.DBNull.Value;

            }
            else
            {
                prm10.Value = pub_cent;
            }
            objOraclecommand.Parameters.Add(prm10);


            OracleParameter prm18 = new OracleParameter("edition", OracleType.VarChar);
            prm18.Direction = ParameterDirection.Input;
            if (edition == "0")
            {
                prm18.Value = System.DBNull.Value;

            }
            else
            {
                prm18.Value = edition;
            }
            objOraclecommand.Parameters.Add(prm18);

            OracleParameter prm28 = new OracleParameter("agency", OracleType.VarChar);
            prm28.Direction = ParameterDirection.Input;
            if (agency == "0")
            {
                prm28.Value = System.DBNull.Value;

            }
            else
            {
                prm28.Value = agency;
            }
            objOraclecommand.Parameters.Add(prm28);

            OracleParameter prm38 = new OracleParameter("client", OracleType.VarChar);
            prm38.Direction = ParameterDirection.Input;
            if (client == "0")
            {
                prm38.Value = System.DBNull.Value;

            }
            else
            {

                prm38.Value = client;
            }
            objOraclecommand.Parameters.Add(prm38);

            OracleParameter prm48 = new OracleParameter("branchnew", OracleType.VarChar);
            prm48.Direction = ParameterDirection.Input;
            if ((branchnew == "") || (branchnew == "0"))
            {
                prm48.Value = System.DBNull.Value;

            }
            else
            {
                prm48.Value = branchnew;
            }
            objOraclecommand.Parameters.Add(prm48);


            ////

            OracleParameter prm51 = new OracleParameter("v_retainer", OracleType.VarChar);
            prm51.Direction = ParameterDirection.Input;
            if (retainer == "0")
            {
                prm51.Value = System.DBNull.Value;

            }
            else
            {
                prm51.Value = retainer;
            }
            objOraclecommand.Parameters.Add(prm51);

            OracleParameter prm49 = new OracleParameter("v_executive", OracleType.VarChar);
            prm49.Direction = ParameterDirection.Input;
            if (executive == "0")
            {
                prm49.Value = System.DBNull.Value;

            }
            else
            {
                prm49.Value = executive;
            }
            objOraclecommand.Parameters.Add(prm49);

            OracleParameter prm50 = new OracleParameter("v_supplement", OracleType.VarChar);
            prm50.Direction = ParameterDirection.Input;
            if (supplement == "")
            {
                prm50.Value = System.DBNull.Value;

            }
            else
            {
                prm50.Value = supplement;
            }
            objOraclecommand.Parameters.Add(prm50);



            OracleParameter prm150 = new OracleParameter("v_insert_status", OracleType.VarChar);
            prm150.Direction = ParameterDirection.Input;
            if (insert_status == "0")
            {
                prm150.Value = System.DBNull.Value;

            }
            else
            {
                prm150.Value = insert_status;
            }
            objOraclecommand.Parameters.Add(prm150);

            OracleParameter prm151 = new OracleParameter("puom_code", OracleType.VarChar);
            prm151.Direction = ParameterDirection.Input;
            if (uom == "0" || uom == "")
                prm151.Value = System.DBNull.Value;
            else
                prm151.Value = uom;
            objOraclecommand.Parameters.Add(prm151);


            OracleParameter prm152 = new OracleParameter("v_userid", OracleType.VarChar);
            prm152.Direction = ParameterDirection.Input;
            //if (uom == "0" || uom == "")
            //    prm152.Value = System.DBNull.Value;
            //else
            prm152.Value = userid;
            objOraclecommand.Parameters.Add(prm152);


            OracleParameter prm153 = new OracleParameter("p_bkid", OracleType.VarChar);
            prm153.Direction = ParameterDirection.Input;
            if (Booking_Id == "")
                prm153.Value = System.DBNull.Value;
            else
                prm153.Value = Booking_Id;
            objOraclecommand.Parameters.Add(prm153);



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
            objOracleConnection.Close();
        }
    }

    //*********************************************************************************************************
    public DataSet executeauditmast2(string bookingid, string compcode, string edition, string insertion)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("executebooking2.executebooking2_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm4 = new OracleParameter("ciobookid", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = bookingid;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = compcode;
            objOraclecommand.Parameters.Add(prm5);


            OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = edition;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("insertion", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = insertion;
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
            objOracleConnection.Close();
        }

    }
    public DataSet bindbranch()
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bind_branch.bind_branch_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;



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

    public DataSet update1(string booking_id, string auditname)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("updateauditbooking.updateauditbooking_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = booking_id;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("auditname", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = auditname;
            objOraclecommand.Parameters.Add(prm2);
            objOraclecommand.ExecuteNonQuery();

            //objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
            //objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;



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




    public DataSet unaudit(string booking_id, string auditname)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("unauditbooking.unauditbooking_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = booking_id;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("auditname", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = auditname;
            objOraclecommand.Parameters.Add(prm2);
            objOraclecommand.ExecuteNonQuery();

            //objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
            //objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;



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



    public DataSet save1(string remarks, string cioid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("saveremark5.saveremark5_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("remarks", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = remarks;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("cioid", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = cioid;
            objOraclecommand.Parameters.Add(prm2);
            objOraclecommand.ExecuteNonQuery();

            //objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
            //objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;



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
    public DataSet bindretainer(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("Sp_Retainerbind.Sp_Retainerbind_p", ref objOracleConnection);
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
    public DataSet adexec(string comcode, string usid, string tname)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("xlsBindexec.xlsBindexec_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = comcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = usid;
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("name1", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = tname;
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
}
}