using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
public partial class updateRoRate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnok_ServerClick(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        string strConnectionString = ConfigurationSettings.AppSettings["orclconnectionstring"].ToString();
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        objOracleConnection = new OracleConnection(strConnectionString);
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        objOracleConnection.Open();

        string query = "select cioid from dummyro";
        objOraclecommand = new OracleCommand(query, objOracleConnection);
        objOraclecommand.CommandType = CommandType.Text;
        objorclDataAdapter.SelectCommand = objOraclecommand;
        objorclDataAdapter.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                query = "select \"Bill_amount\",\"Special_charges\",nvl(\"Trade_disc\",0),nvl(ADD_AGENCY_COMM,0),\"Booking_type\" from tbl_booking_mast where \"cio_booking_id\"='" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "'";
                DataSet ds1 = new DataSet();
                objOraclecommand = new OracleCommand(query, objOracleConnection);
                objOraclecommand.CommandType = CommandType.Text;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(ds1);

                query = "select sum(\"Bill_Amt\") from tbl_booking_insert where \"Cio_Booking_Id\"='" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "'";
                DataSet ds2 = new DataSet();
                objOraclecommand = new OracleCommand(query, objOracleConnection);
                objOraclecommand.CommandType = CommandType.Text;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(ds2);
                if (ds1.Tables[0].Rows.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0].ItemArray[0].ToString() != ds2.Tables[0].Rows[0].ItemArray[0].ToString())
                    {
                      //  if (ds1.Tables[0].Rows[0].ItemArray[1].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[1].ToString() != "null" && ds1.Tables[0].Rows[0].ItemArray[1].ToString() != null)
                       // {
                        if (ds1.Tables[0].Rows[0].ItemArray[4].ToString() == "2")
                        {
                            query = "update tbl_booking_mast set \"Bill_amount\"='0' where \"cio_booking_id\"='" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "'";
                            objOraclecommand = new OracleCommand(query, objOracleConnection);
                            objOraclecommand.CommandType = CommandType.Text;
                            objOraclecommand.ExecuteNonQuery();
                        }
                            double agencydisc = Convert.ToDouble(ds1.Tables[0].Rows[0].ItemArray[2]) + Convert.ToDouble(ds1.Tables[0].Rows[0].ItemArray[3]);
                            query = "select \"Insert_Id\",\"Gross_Rate\" from tbl_booking_insert where \"Cio_Booking_Id\"='" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "'";
                            DataSet ds3 = new DataSet();
                            objOraclecommand = new OracleCommand(query, objOracleConnection);
                            objOraclecommand.CommandType = CommandType.Text;
                            objorclDataAdapter.SelectCommand = objOraclecommand;
                            objorclDataAdapter.Fill(ds3);
                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                double total = 0;
                                double diff = 0;
                                for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                                {
                                    double amt = Convert.ToDouble(ds3.Tables[0].Rows[j].ItemArray[1]) - (Convert.ToDouble(ds3.Tables[0].Rows[j].ItemArray[1]) * agencydisc / 100);
                                    amt = Math.Round(amt, 2);
                                    total = total + amt;
                                    if (j == ds3.Tables[0].Rows.Count - 1)
                                    {
                                        diff = Convert.ToDouble(ds1.Tables[0].Rows[0].ItemArray[0]) - total;
                                        diff = Math.Round(diff, 2);
                                        // amt = amt + diff;
                                    }
                                    if (ds1.Tables[0].Rows[0].ItemArray[4].ToString() == "2")
                                        amt = 0;
                                    query = "update tbl_booking_insert set \"Bill_Amt\"='" + amt.ToString() + "' where \"Insert_Id\"='" + ds3.Tables[0].Rows[j].ItemArray[0].ToString() + "'";
                                    objOraclecommand = new OracleCommand(query, objOracleConnection);
                                    objOraclecommand.CommandType = CommandType.Text;
                                    objOraclecommand.ExecuteNonQuery();
                                   
                                }
                                if (diff > 0)
                                {
                                    query = "select max(\"Insert_Id\") from tbl_booking_insert where \"Cio_Booking_Id\"='" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "' and \"Bill_Amt\" is not null and \"Bill_Amt\">0";
                                    DataSet ds4 = new DataSet();
                                    objOraclecommand = new OracleCommand(query, objOracleConnection);
                                    objOraclecommand.CommandType = CommandType.Text;
                                    objorclDataAdapter.SelectCommand = objOraclecommand;
                                    objorclDataAdapter.Fill(ds4);
                                    if (ds4.Tables[0].Rows.Count > 0)
                                    {
                                        // float amt = Convert.ToDouble(ds3.Tables[0].Rows[0].ItemArray[1]) + diff;

                                        query = "select \"Bill_Amt\" from tbl_booking_insert where \"Insert_Id\"='" + ds4.Tables[0].Rows[0].ItemArray[0] + "'";
                                        DataSet ds5 = new DataSet();
                                        objOraclecommand = new OracleCommand(query, objOracleConnection);
                                        objOraclecommand.CommandType = CommandType.Text;
                                        objorclDataAdapter.SelectCommand = objOraclecommand;
                                        objorclDataAdapter.Fill(ds5);

                                        if (ds5.Tables[0].Rows.Count > 0)
                                        {
                                            double amount=Convert.ToDouble(ds5.Tables[0].Rows[0].ItemArray[0]);
                                            amount = amount + diff;
                                            amount = Math.Round(amount, 2);
                                            if (ds1.Tables[0].Rows[0].ItemArray[4].ToString() == "2")
                                                amount = 0;
                                            query = "update tbl_booking_insert set \"Bill_Amt\"=" + amount.ToString() + " where \"Insert_Id\"='" + ds4.Tables[0].Rows[0].ItemArray[0] + "'";
                                            objOraclecommand = new OracleCommand(query, objOracleConnection);
                                            objOraclecommand.CommandType = CommandType.Text;
                                            objOraclecommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                      //  }
                        //else
                        //{
                        //    double diff = Convert.ToDouble(ds1.Tables[0].Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(ds2.Tables[0].Rows[0].ItemArray[0].ToString());
                        //    diff = Math.Round(diff, 2);
                        //    if (diff > 0)
                        //    {
                        //        query = "select max(\"Insert_Id\") from tbl_booking_insert where \"Cio_Booking_Id\"='" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "' and \"Bill_Amt\" is not null and \"Bill_Amt\"!=0";
                        //            DataSet ds3 = new DataSet();
                        //            objOraclecommand = new OracleCommand(query, objOracleConnection);
                        //            objOraclecommand.CommandType = CommandType.Text;
                        //            objorclDataAdapter.SelectCommand = objOraclecommand;
                        //            objorclDataAdapter.Fill(ds3);
                        //            if (ds3.Tables[0].Rows.Count > 0)
                        //            {
                        //               // float amt = Convert.ToDouble(ds3.Tables[0].Rows[0].ItemArray[1]) + diff;
                        //                query = "update tbl_booking_insert set \"Bill_Amt\"=\"Bill_Amt\" + " + diff.ToString() + " where \"Insert_Id\"='" + ds3.Tables[0].Rows[0].ItemArray[0] + "'";
                        //                objOraclecommand = new OracleCommand(query, objOracleConnection);
                        //                objOraclecommand.CommandType = CommandType.Text;
                        //                objOraclecommand.ExecuteNonQuery();
                        //            }
                                
                        //    }
                        //}
                    }
                }
            }
        }
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        string strConnectionString = ConfigurationSettings.AppSettings["orclconnectionstring"].ToString();
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        objOracleConnection = new OracleConnection(strConnectionString);
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        objOracleConnection.Open();

        string query = "select cioid,adtype,insertid from dummyro";
        objOraclecommand = new OracleCommand(query, objOracleConnection);
        objOraclecommand.CommandType = CommandType.Text;
        objorclDataAdapter.SelectCommand = objOraclecommand;
        objorclDataAdapter.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                query = "select max(\"Insert_Id\") from tbl_booking_insert where \"Cio_Booking_Id\"='" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "' and \"Bill_Amt\" is not null and \"Bill_Amt\">0";
                DataSet ds4 = new DataSet();
                objOraclecommand = new OracleCommand(query, objOracleConnection);
                objOraclecommand.CommandType = CommandType.Text;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(ds4);
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    // float amt = Convert.ToDouble(ds3.Tables[0].Rows[0].ItemArray[1]) + diff;

                    query = "select \"Bill_Amt\",\"Gross_Rate\" from tbl_booking_insert where \"Insert_Id\"='" + ds4.Tables[0].Rows[0].ItemArray[0] + "'";
                    DataSet ds5 = new DataSet();
                    objOraclecommand = new OracleCommand(query, objOracleConnection);
                    objOraclecommand.CommandType = CommandType.Text;
                    objorclDataAdapter.SelectCommand = objOraclecommand;
                    objorclDataAdapter.Fill(ds5);

                    if (ds5.Tables[0].Rows.Count > 0)
                    {
                        double amount = Convert.ToDouble(ds5.Tables[0].Rows[0].ItemArray[0]);
                        amount = amount + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1]); ;
                        amount = Math.Round(amount, 2);

                        double gross = Convert.ToDouble(ds5.Tables[0].Rows[0].ItemArray[1]);
                        gross = gross + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1]); ;
                        gross = Math.Round(gross, 2);

                       
                        query = "update tbl_booking_insert set \"Bill_Amt\"=" + amount.ToString() + " , \"Gross_Rate\"="+gross.ToString()+" where \"Insert_Id\"='" + ds4.Tables[0].Rows[0].ItemArray[0] + "'";
                        objOraclecommand = new OracleCommand(query, objOracleConnection);
                        objOraclecommand.CommandType = CommandType.Text;
                        objOraclecommand.ExecuteNonQuery();

                        query = "update tbl_booking_insert set \"Bill_Amt\"=0, \"Gross_Rate\"=0 where \"Insert_Id\"='" + ds.Tables[0].Rows[i].ItemArray[2] + "'";
                        objOraclecommand = new OracleCommand(query, objOracleConnection);
                        objOraclecommand.CommandType = CommandType.Text;
                        objOraclecommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
