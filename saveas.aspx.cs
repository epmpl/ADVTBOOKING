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
using Winnovative.WnvHtmlConvert;
using System.Diagnostics;


public partial class saveas : System.Web.UI.Page
{
    DataSet ds1 = new DataSet();
    string x, ajay, ankur;
    string thisname;
    //string blogdata;
    NewAdbooking.Classes.cls obj = new NewAdbooking.Classes.cls();
    //ABPNEW.classes.abpmaster strcountry = new ABPNEW.classes.abpmaster();
    //ABPNEW.classes.cls obj = new ABPNEW.classes.cls();
    protected void Page_Load(object sender, EventArgs e)
    {
        saveT.Attributes.Add("onFocus", "document.getElementById('savexml').value = opener.document.getElementById('editordivxml').value;document.getElementById('savehtml').value = opener.document.getElementById('editordivhtml').value;document.getElementById('completehtml').value=opener.document.getElementById('editordivfullhtml').value;document.getElementById('uomhidden').value = opener.document.getElementById('sel_unit').value;document.getElementById('adwidth').value = opener.document.getElementById('adwidth').value;document.getElementById('adheight').value = opener.document.getElementById('adheight').value");
        //saveT.Disabled = true;
        thisname = "Template_" + filename.Text;
        ds1 = obj.get_id();
        //ds1 = obj.get_id();
        int ct = ds1.Tables[0].Rows.Count;
        if (ds1.Tables[0].Rows.Count > 0)
        {
            temp_id.Value = Convert.ToString(ct + 1);
        }
        else
        {
            temp_id.Value = "1";

        }

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls dd = new NewAdbooking.Classes.cls();
            //ABPNEW.classes.cls dd = new ABPNEW.classes.cls();

            ds = dd.fatchcategory();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls dd = new NewAdbooking.classesoracle.orclcls();
            
            ds = dd.fatchcategory();
        }
        
        int i = ds.Tables[0].Rows.Count;
        int K = 0;
        for (K = 0; K < i - 1; K++)
        {
            ListItem li = new ListItem();
            li.Text = ds.Tables[0].Rows[K].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[K].ItemArray[1].ToString();
            drpcat.Items.Add(li);
        }




    }
    protected void saveT_onclick(object sender, EventArgs e)
    {
        try
        {
            string xmlval = savexml.Value;
            string filterhtml = savehtml.Value;
            string htmlval = completehtml.Value;
            string thisname = "Template_" + filename.Text;
            string uom1 = uomhidden.Value;
            if (filename.Text == "")
            {
                Response.Write("<script>alert('Please Specify Template name ?');</script>");
            }
            else
            {
                 //thisname = "Template_" + filename.Text;
                int cnt = 0;
                for (int w = 0; w < ds1.Tables[0].Rows.Count; w++)
                {
                    // string x = ds1.Tables[0].Rows[w].ItemArray[1];
                    x = ds1.Tables[0].Rows[w].ItemArray[1].ToString();
                    if (x == thisname)
                    {
                        //Response.Write("<script>alert('Template Name Exist !!');</script>");
                        cnt = 1;
                    }
                }
                if (cnt == 1)
                {
                    Response.Write("<script>alert('Template name Exist');</script>");
                }
                //}
                else
                {
                    //char[] c = { "<DIV>" };
                    string[] countdiv = filterhtml.Split(new string[] { "<DIV" }, StringSplitOptions.None);
                    int len = countdiv.Length - 1;

                    int newid = 1;
                    for (int i = 0; i <= len; i++)
                    {

                        //    string src = i.innerHTML;
                        //    char[] c ={ '\"' };
                        string s = "src=";
                        if (countdiv[i].IndexOf(s) >= 0)
                        {
                            string[] path1 = countdiv[i].Split(new string[] { "src=" }, StringSplitOptions.None);
                            string[] path2 = path1[1].Split(new string[] { "\"" }, StringSplitOptions.None);
                            // browse.Value = path2[1];
                            string foldernameIMG = "images1/";
                            string[] strsql = path2[1].Split('.');
                            string strFilename1 = "Image" + newid + "_" + temp_id.Value + "." + strsql[1];
                            string serverpath = Server.MapPath("") + ("/") + foldernameIMG + strFilename1;
                            string serverpath1 = serverpath.Replace(":", "$");

                            //      \\192.168.1.115\
                            //System.IO.File.Copy(path2[1], Server.MapPath("") + ("/") + foldername + strFilename1);
                            //System.IO.File.Copy(path2[1], serverpath);
                            newid++;
                        }

                        //    string[] image1 = path[1].Split(c);
                        //    //path.Value = image1;
                        //    //browse.Value = image1;
                        //    //string[] strsql = image1.Split('.');
                        //    //string foldername = "images/";
                        //    //
                        //    //string strfilename2 = foldername + strFilename1;
                        //    //newid++;
                        //    //browse.PostedFile.SaveAs(Server.MapPath("") + ("/") + foldername + "//" + strFilename1);


                    }
                    //if (ddl.SelectedValue != "XML")
                    //{
                    //    string htmlfile = "<html><body>" + filterhtml + "</body></html>";
                    //    string filetemp = "htmlgen/test.html";
                    //    string filepath = Server.MapPath("") + ("//") + filetemp;
                    //    //string location = paths + "test" + "." +ddl.SelectedValue;
                    //    System.IO.StreamWriter htfile = new System.IO.StreamWriter(filepath);
                    //    htfile.WriteLine(htmlfile);
                    //    htfile.Close();
                    //    LaunchCommandLineApp(filepath, ddl.SelectedValue, thisname);

                    //}
                    //else
                    //{
                    string idTemp = temp_id.Value;
                    string foldernameTMP = "Templates/";
                    string paths = Server.MapPath("") + ("/") + foldernameTMP + "//";
                    string location = paths + thisname + ".xml";
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(location);
                    sw.WriteLine(xmlval);
                    sw.Close();
                    //string blogdata = xmlval;
                    string adh = adheight.Value;
                    string adw = adwidth.Value;
                    DataSet ds = new DataSet();
                    ds = obj.insertxml(Convert.ToInt32(idTemp), location, xmlval, thisname, htmlval, filterhtml, uom1, adh, adw, "ank");
                    //Response.Write("<script>alert('Template Saved Successfully !!');window.close();currentid=null;</script>");

                    saveastype.Value = filename.Text;
                    ajay = "'" + saveastype.Value + "'";
                    Response.Write("<script>opener.document.getElementById('selected_name').value=" + ajay + ";alert('template Saved Successfully !!!');window.close();currentid=null;</script>"); ;


                
                }
                //Response.Write("<script>alert('Template Saved Successfully !!');window.close();</script>");
            }
        }

        //}
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error in Saving!!" + ex + "');window.close();</script>");
        }
    }
    
    private void ConvertHTMLStringToPDF()
    {
        //string htmlString = textBoxHTMLCode.Text;
        string htmlString = savehtml.Value;
        // string baseURL = textBoxBaseURL.Text.Trim();
        //bool selectablePDF = radioConvertToSelectablePDF.Checked;

        // Create the PDF converter. Optionally you can specify the virtual browser 
        // width as parameter. 1024 pixels is default, 0 means autodetect
        PdfConverter pdfConverter = new PdfConverter();
        // set the license key
        pdfConverter.LicenseKey = "P38cBx6AWW7b9c81TjEGxnrazP+J7rOjs+9omJ3TUycauK+cLWdrITM5T59hdW5r";
        // set the converter options
        pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
        pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
        pdfConverter.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;
        pdfConverter.PdfDocumentOptions.ShowHeader = false;
        pdfConverter.PdfDocumentOptions.ShowFooter = false;
        // set to generate selectable pdf or a pdf with embedded image
        //pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = selectablePDF;
        // set the embedded fonts option - optional, by default is false
        pdfConverter.PdfDocumentOptions.EmbedFonts = false;
        // enable the live HTTP links option - optional, by default is true
        pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = true;
        // enable the support for right to left languages , by default false
        pdfConverter.RightToLeftEnabled = false;

        // set PDF security options - optional
        //pdfConverter.PdfSecurityOptions.CanPrint = true;
        //pdfConverter.PdfSecurityOptions.CanEditContent = true;
        //pdfConverter.PdfSecurityOptions.UserPassword = "";

        //set PDF document description - optional
        pdfConverter.PdfDocumentInfo.AuthorName = "ajay Kumar";

        // add HTML header
        //if (cbAddHeader.Checked)
        //    AddHeader(pdfConverter);
        //// add HTML footer
        //if (cbAddFooter.Checked)
        //    AddFooter(pdfConverter);

        // Performs the conversion and get the pdf document bytes that you can further 
        // save to a file or send as a browser response
        //
        // The baseURL parameter helps the converter to get the CSS files and images
        // referenced by a relative URL in the HTML string. This option has efect only if the HTML string
        // contains a valid HEAD tag. The converter will automatically inserts a <BASE HREF="baseURL"> tag. 
        byte[] pdfBytes = null;
        //if (baseURL.Length > 0)
        //    pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(htmlString, baseURL);
        //else
        pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(htmlString);

        // send the PDF document as a response to the browser for download
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.Clear();
        response.AddHeader("Content-Type", "binary/octet-stream");
        response.AddHeader("Content-Disposition",
        "attachment; filename=ConversionResult.pdf; size=" + pdfBytes.Length.ToString());
        response.Flush();
        response.BinaryWrite(pdfBytes);
        response.Flush();
        response.End();
    }

    private void LaunchCommandLineApp(string location,string type,string name)
    {
        // Launch a command-line application, with some options set.
        // Arguments here are just application-specific and can be
        // used to control the output format of the application being started.
        string gen_path = Server.MapPath("") + "\\htmlgen\\";
        string fname = "";
        if (type == "PDF")
        {
            fname = gen_path  + "\\pdf\\" + name + "." + type;
        }
        else if (type=="PS")
        {
            fname = gen_path + "\\eps\\" + name + "." + type;
        }
        else if (type == "GIF")
        {
            fname = gen_path + "\\gif\\" + name + "." + type;
        }
        else if (type == "PNG")
        {
            fname = gen_path + "\\png\\" + name + "." + type;
        }
        else if (type == "TIF")
        {
            fname = gen_path + "\\tif\\" + name + "." + type;
        }
        else if (type == "JPG")
        {
            fname = gen_path + "\\jpg\\" + name + "." + type;
        }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = gen_path  + "htmltools.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = location + " " + fname;// "-f j -o \"" + _cacheDir + "\" -z 1.0 -s y " + target;
        
        try
        {
            // Start the process with the info we specified.
            // Call WaitForExit and the Close. An exception is thrown
            // if something goes wrong.
            Process exeProcess = Process.Start(startInfo);
            exeProcess.WaitForExit();
            exeProcess.Close();
        }
        catch//(Exception ex)
        {
            return;
        }
    }

 }

