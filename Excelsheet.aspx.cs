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
using System.Data.SqlClient;

public partial class Excelsheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string adtyp = Request.QueryString["adtype"].ToString();
        string adcat = Request.QueryString["adcategory"].ToString();
        string fromdt = Request.QueryString["fromdate"].ToString();
        string dateto = Request.QueryString["dateto"].ToString();
        string publ = Request.QueryString["publication"].ToString();
        string pubcen = Request.QueryString["pubcenter"].ToString();
        string pub2 = Request.QueryString["publication1"].ToString();
        string pubcname = Request.QueryString["pubcname"].ToString();
        string edition = Request.QueryString["edition"].ToString();
       
        //lblfrom.Text = fromdt.ToString();
        //lblto.Text = dateto.ToString();
        //lbldate.Text = System.DateTime.Now.Day;
        //pcenter.Text = pubcname.ToString();
        //lblpub.Text = pub2.ToString();
         string strCurrentDir = Server.MapPath(".") + "\\";
        //RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        // ClsReport report = new ClsReport();

        try
        {
            GC.Collect();// clean up any other excel guys hangin' around...
            oXL = new Excel.Application();
            oXL.Visible = true;

            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
            //get our Data     
           // sqlc
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            SqlDataReader myReader=null;
                      
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            myReader = obj.spfunexcel(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
           //DataSet dst=clsbook.spfun();
                     int iRow = 2;  //2

                    // while(myReader.Read())
                    // {
                         for (int j = 0; j < myReader.FieldCount; j++)
                         {
                             oSheet.Cells[1, j + 1] = myReader.GetName(j).ToString();

                         }
                  //   }
            // build the sheet contents
                     //for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                     //{
                     //    oSheet.Cells[1, i + 1] = dst.Tables[0].Rows[0].ItemArray[i].ToString();
                     //}
            oSheet.Cells.Font.Name = "verdana";
            oRng = oSheet.get_Range("A1", "AA1");
            oRng.EntireColumn.AutoFit();
            oRng.EntireColumn.Font.Size = 7;

            //				oRng.Column=1;
            //				oRng.EntireColumn.Width=0;
            //string total = "";
            //int tot = 0;
            //int finaltotal = 0;
            while (myReader.Read())
            {
                for (int k = 0; k < myReader.FieldCount; k++)
                {

                    oSheet.Cells[iRow, k + 1] = myReader.GetValue(k).ToString();
                    //if (txtchequedatefrom.Text != "")
                    //{
                    //    if (k == 20)
                    //    {
                    //        if (myReader.GetValue(20) != System.DBNull.Value)
                    //        {
                    //            total = myReader.GetValue(20).ToString().Replace(".00", "");
                    //            total = total.Replace(",", "").Trim();

                    //            tot = Convert.ToInt32(total.ToString());
                    //            finaltotal = finaltotal + tot;
                    //        }

                    //    }
                    //}
                    //if (rdpending.Checked == true)
                    //{
                    //    if (k == 17)
                    //    {
                    //        if (myReader.GetValue(17) != System.DBNull.Value && myReader.GetValue(17).ToString() != "")
                    //        {
                    //            total = myReader.GetValue(17).ToString().Replace(".00", "");
                    //            total = total.Replace(",", "").Trim();

                    //            tot = Convert.ToInt32(total.ToString());
                    //            finaltotal = finaltotal + tot;
                    //        }

                    //    }
                    //}

                    //((Range)oSheet.Cells[k + 1, 1]).EntireColumn.ColumnWidth = 0;
                    //((Range)oSheet.Cells[k + 1, 2]).EntireColumn.ColumnWidth = 5;
                    //((Range)oSheet.Cells[k + 1, 3]).EntireColumn.ColumnWidth = 6;
                    //((Range)oSheet.Cells[k + 1, 4]).EntireColumn.ColumnWidth = 6;
                    //((Range)oSheet.Cells[k + 1, 5]).EntireColumn.ColumnWidth = 13;
                    //((Range)oSheet.Cells[k + 1, 6]).EntireColumn.ColumnWidth = 11;
                    //((Range)oSheet.Cells[k + 1, 7]).EntireColumn.ColumnWidth = 16;
                    //((Range)oSheet.Cells[k + 1, 8]).EntireColumn.ColumnWidth = 14;
                    //((Range)oSheet.Cells[k + 1, 9]).EntireColumn.ColumnWidth = 14;
                    //((Range)oSheet.Cells[k + 1, 10]).EntireColumn.ColumnWidth = 10;
                    //((Range)oSheet.Cells[k + 1, 11]).EntireColumn.ColumnWidth = 14;
                    //((Range)oSheet.Cells[k + 1, 12]).EntireColumn.ColumnWidth = 6;
                    //((Range)oSheet.Cells[k + 1, 14]).EntireColumn.ColumnWidth = 6;
                    //((Range)oSheet.Cells[k + 1, 15]).EntireColumn.ColumnWidth = 6;
                    //((Range)oSheet.Cells[k + 1, 16]).EntireColumn.ColumnWidth = 7;
                    //((Range)oSheet.Cells[k + 1, 17]).EntireColumn.ColumnWidth = 8;
                    //((Range)oSheet.Cells[k + 1, 18]).EntireColumn.ColumnWidth = 7;
                    //((Range)oSheet.Cells[k + 1, 19]).EntireColumn.ColumnWidth = 8;
                    //((Range)oSheet.Cells[k + 1, 20]).EntireColumn.ColumnWidth = 8;
                    //((Range)oSheet.Cells[k + 1, 21]).EntireColumn.ColumnWidth = 8;
                    //((Range)oSheet.Cells[k + 1, 22]).EntireColumn.ColumnWidth = 10;
                    //((Range)oSheet.Cells[k + 1, 23]).EntireColumn.ColumnWidth = 7;
                    //((Range)oSheet.Cells[k + 1, 24]).EntireColumn.ColumnWidth = 8;
                    //((Range)oSheet.Cells[k + 1, 25]).EntireColumn.ColumnWidth = 8;
                    //((Range)oSheet.Cells[k + 1, 26]).EntireColumn.ColumnWidth = 6;
                    oRng.EntireColumn.WrapText = true;
                }

                iRow++;
            }// end while
            //if (txtchequedatefrom.Text != "")
            //{
            //    total = Convert.ToString(finaltotal);
            //    total = total + ".00";
            //    oSheet.Cells[iRow + 1, 21] = total;
            //}
            //if (rdpending.Checked == true)
            //{
            //    total = Convert.ToString(finaltotal);
            //    total = total + ".00";
            //    oSheet.Cells[iRow + 1, 18] = total;
            //}
            string row;
            string row1;
            iRow = iRow + 1;
            row = "A" + Convert.ToString(iRow);
            row1 = "AA" + Convert.ToString(iRow);
            //((Range)oSheet.Cells[row, 21]).EntireRow.Font.Color=Color.Gray;
            oSheet.get_Range(row, row1).Font.Bold = true;


            myReader.Close();
            myReader = null;
            //Format A1:Z1 as bold, vertical alignment = center.

            oSheet.get_Range("A1", "AA1").Font.Bold = true;

            oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //oSheet.PageSetup.PrintGridlines=true;
            //oSheet.PageSetup.LeftMargin=0;
            //oSheet.PageSetup.RightMargin=0;
            //oSheet.PageSetup.BlackAndWhite=true;
            //AutoFit columns A:Z.
            oRng = oSheet.get_Range("A1", "AA1");
            //oRng.EntireColumn.AutoFit();



            //oRng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            //oRng.Borders.Color = Color.LightGray.ToArgb();


            oXL.Visible = true;
            oXL.UserControl = false;
            string strFile = "report" + System.DateTime.Now.Ticks.ToString() + ".xls";

            oWB.SaveAs(strCurrentDir + strFile, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);
            // Need all following code to clean up and extingush all references!!!
            //oWB.Close(null, null, null);
            //oXL.Workbooks.Close();
            //oXL.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRng);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);
            //oSheet = null;
            //oWB = null;
            //oXL = null;
            GC.Collect();  // force final cleanup!
            string strMachineName = Request.ServerVariables["SERVER_NAME"];
            // errLabel.Text = "<A href=http://" + strMachineName + "/EWA/" + strFile + ">Download Report</a>";
            //errLabel.Font.Size = 12;

        }
        catch (Exception theException)
        {
            String errorMessage;
            errorMessage = "Error: ";
            errorMessage = String.Concat(errorMessage, theException.Message);
            errorMessage = String.Concat(errorMessage, " Line: ");
            errorMessage = String.Concat(errorMessage, theException.Source);
            //errLabel.Text = errorMessage;
        }
        finally
            {
                Response.Redirect("report.aspx");
            }

    }

 }
