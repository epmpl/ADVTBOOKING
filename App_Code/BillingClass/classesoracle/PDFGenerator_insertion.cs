using System;
using System.IO;

/// <summary>
/// Summary description for PDFGenerator
/// </summary>
public class PDFGeneratorcls_insertion : System.Web.UI.Page
{

    private string sLandScape;
    private string m_sWaterMark;
    private string m_sDrive;
    private string m_Directory;
    private string stitle;
    public PDFGeneratorcls_insertion(string sDirectory)
    {
        sFontSize = "";
        sLandScape = "--portrait";
        stitle = "--title";
        m_sWaterMark = "";
        string sRoot = sDirectory;
        //string sRoot = "C:\\Users\\Office Max\\Downloads\\HtmlToPDF\\HtmlToPDF";
        m_sDrive = "" + sRoot[0];
        m_Directory = sDirectory + "\\BILLING\\PRINTPDF\\";
    }

    private string sFontSize;
    public string FontSize
    {
        set { sFontSize = "--fontsize " + value; }
        get { return (sFontSize); }
    }

    private string spagesize;
    public string PageSize
    {
        set { spagesize = "--size size " + value; }
        get { return (spagesize); }
    }

    public void SetLandScape(bool bRet)
    {
        if (bRet == false)
            sLandScape = "";
    }

    public void SetWaterMark(bool bRet)
    {
        if (bRet == false)
            m_sWaterMark = "";

    }


    public string RunWeb(string sUrl)
    {
        string sFileName = GetNewName();

        System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
        pProcess.StartInfo.FileName = m_sDrive + ":" + m_Directory + "\\ghtmldoc.exe";
        pProcess.StartInfo.Arguments = "--webpage --quiet " + sFontSize + " --bodyfont Arial " + sLandScape + " -t pdf14 -f " + sFileName + ".pdf " + sUrl;
        pProcess.StartInfo.WorkingDirectory = m_sDrive + ":" + m_Directory;

        pProcess.Start();

        return (sFileName + ".pdf");
    }

    public string Run(string sRawUrl)
    {

        string sFileName = GetNewName();
        string sPage = m_Directory + sFileName + ".html";
        // string sPage = Server.MapPath("" + sFileName + ".html");

        string sUrlVirtual = sRawUrl;
        StringWriter sw = new StringWriter();

        Server.Execute(sUrlVirtual, sw);

        StreamWriter sWriter = File.CreateText(sPage);

        //code to replace to come here

        string std = sw.ToString();

        //string[] names = new string[] { "<td  valign =\"middle\"  align =\"LEFT\" style=\"font-family:Times New Roman ;font-size:18px;font-weight :bold \" >" };

        //string[] strd = std.Split(names, StringSplitOptions.RemoveEmptyEntries);

        //std = "";

        //for (int i = 0; i < strd.Length; i++)
        //{

        //    if (i == 0)
        //    {

        //        std = std + strd[i];

        //    }

        //    else
        //    {

        //        string[] names1 = new string[] { "</span>" };

        //        string[] strd2 = strd[i].Split(names1, 2, StringSplitOptions.RemoveEmptyEntries);

        //        std = std + "<td  valign =\"middle\"  align =\"LEFT\" style=\"font-family:Times New Roman ;font-size:18px;font-weight :bold \" ><h1>" + strd2[0] + "</span></h1>";

        //        std = std + strd2[1];

        //    }

        //}

        // std = std.Replace("INVOICE", "<h1>INVOICE</h1>");
        sWriter.WriteLine(std);
        sWriter.Close();

        System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
        pProcess.StartInfo.FileName = m_Directory + "\\ghtmldoc.exe";
        pProcess.StartInfo.Arguments = "--webpage --quiet " + spagesize + sFontSize  + m_sWaterMark + " --bodyfont Arial " + sLandScape + " -t pdf14 -f " + sFileName + ".pdf " + sFileName + ".html";
        pProcess.StartInfo.WorkingDirectory = m_Directory;

        pProcess.Start();

        return (sFileName + ".pdf");
    }


    private string GetNewName()
    {
        string sName = Convert.ToString(DateTime.Now.Ticks);
        return (sName);
    }
}
