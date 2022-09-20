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
using System.IO;
using System.Drawing;

public partial class ThumbnailCreator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string imgPath;
        string ext;
        if (Request.QueryString["ImageId"] != null)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ImageId"].ToString()))
            {
                imgPath = Request.QueryString["ImageId"].ToString();
                ext = imgPath.Substring(imgPath.LastIndexOf("."));
                if (!string.IsNullOrEmpty(imgPath))
                {
                    byte[] imgByte = GetImageByteArr(new Bitmap(imgPath),ext);
                    
                    MemoryStream memoryStream = new MemoryStream();
                    memoryStream.Write(imgByte, 0, imgByte.Length);

                    //System.Drawing.Image imagen = System.Drawing.Image.FromStream(memoryStream);
                    Bitmap imagen = new Bitmap(memoryStream);
                    if (ext == ".jpg")
                    {
                        Response.ContentType = "image/Jpeg";
                    }
                    else if (ext == ".tiff")
                    {
                        Response.ContentType = "image/Tiff";
                    }
                    else if (ext == ".gif")
                    {
                        Response.ContentType = "image/Gif";
                    }

                    ImageResize ir = new ImageResize();
                    ir.File = imagen;
                    ir.Height = 60;
                    ir.Width = 60;
                    if (ext == ".jpg")
                    {
                        ir.GetThumbnail().Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (ext == ".tiff" || ext==".tif")
                    {
                        ir.GetThumbnail().Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Tiff);
                    }
                    else if (ext == ".gif")
                    {
                        ir.GetThumbnail().Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);

                    }
                    new Bitmap(imgPath).Dispose();
                    //new Bitmap(imgPath).;
                    imagen.Dispose();
                    imagen = null;
                    //imagen.Dispose();
                    memoryStream.Close();
                    memoryStream.Dispose();
                    memoryStream = null;
                    //Response.OutputStream = null;

                    //memoryStream.Flush();
                    //memoryStream.Close();
                    //memoryStream.Dispose();
                    Response.OutputStream.Close();
                }
            }
        }
    }
    private static byte[] GetImageByteArr(System.Drawing.Image img,string exttyp)
    {
        byte[] ImgByte;
        using (MemoryStream stream = new MemoryStream())
        {
            if (exttyp == ".jpg")
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (exttyp == ".tiff" || exttyp == ".tif")
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Tiff);
            }
            else if (exttyp == ".gif")
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
            }
            ImgByte = stream.ToArray();
            //stream = null;
            stream.Flush();
            stream.Close();
            stream.Dispose();
            //stream = null;
            img.Dispose();
            img = null;
        }
        
        return ImgByte;
    }
}
