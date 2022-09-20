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
using System.Drawing;
using System.IO;
using System.Diagnostics;
public partial class measurestring : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    //public void MeasureStringSizeFFormatInts(PaintEventArgs e)
    //{
    //    // Set up string.
        
    //    string measureString = "Measure String";
    //    Font stringFont = new Font("Arial", 16);
    //    // Set maximum layout size.
    //    SizeF layoutSize = new SizeF(100.0F, 200.0F);
    //    // Set string format.
    //    StringFormat newStringFormat = new StringFormat();
    //    newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
    //    // Measure string.
    //    int charactersFitted;
    //    int linesFilled;
    //    SizeF stringSize = new SizeF();
    //    stringSize = e.Graphics.MeasureString(
    //    measureString,
    //    stringFont,
    //    layoutSize,
    //    newStringFormat,
    //    out charactersFitted,
    //    out linesFilled);
    //    // Draw rectangle representing size of string.
    //    e.Graphics.DrawRectangle(
    //    new Pen(Color.Red, 1),
    //    0.0F, 0.0F, stringSize.Width, stringSize.Height);
    //    // Draw string to screen.
    //    e.Graphics.DrawString(
    //    measureString,
    //    stringFont,
    //    Brushes.Black,
    //    new PointF(0, 0),
    //    newStringFormat);
    //    // Draw output parameters to screen.
    //    string outString = "chars " + charactersFitted + ", lines " + linesFilled;
    //    e.Graphics.DrawString(
    //    outString,
    //    stringFont,
    //    Brushes.Black,
    //    new PointF(100, 0));
    //}

}
