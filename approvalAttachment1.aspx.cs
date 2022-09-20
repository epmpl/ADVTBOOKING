﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
public partial class approvalAttachment1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnok.Attributes.Add("OnClick", "javascript:closeattach();");
        lblfilename.Attributes.Add("OnClick", "javascript:return openfile();");
        if (Request.QueryString["filename"] != null)
        {
            lblfilename.Text = Request.QueryString["filename"].ToString();
            lblfilename.ToolTip = Request.QueryString["filename"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        lblfilename.Text = filename;
        lblfilename.ToolTip = filename;
        FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("ApprovalAttachment"), filename));
    }
}
