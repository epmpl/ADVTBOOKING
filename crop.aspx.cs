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
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using SD = System.Drawing;
using System.Drawing.Drawing2D;
public partial class crop : System.Web.UI.Page
{
    static int id = 1;
    static string spath;
    string spath1;
    string spath2;
    string imagesource = "";
    string newimagename="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(crop));
        //crpimg.Attributes.Add("OnClick", "javascript:showResult()");
        apply.Attributes.Add("onclick", "javascript:applyimg()");
        imagesource = Request.QueryString["image"].ToString();
        string pth = ConfigurationManager.AppSettings["imagepath"].ToString();
        sepath2.Value = pth;
        imgCrop.ImageUrl = imagesource;
        //string imagesource ="c:/image001.jpg";
        //spath = Server.MapPath("") + ("/") + "images1/" + "test" + id + ".jpg";
        spath = Server.MapPath("") + ("/") + "images1/";
        sepath.Value = spath;
        newimagename = imagesource.Substring(imagesource.LastIndexOf("/") + 1, imagesource.Length - imagesource.LastIndexOf("/") - 1);
        //    Ajax.Utility.RegisterTypeForAjax(typeof(crop));
        //    apply.Attributes.Add("onclick", "javascript:applyimg()");
        //    string imagesource = Request.QueryString["image"].ToString();
        //    //string imagesource ="c:/image001.jpg";
        //    gettemp.Value = Environment.GetEnvironmentVariable("Temp");
    }
    [Ajax.AjaxMethod]
    public string drawImage(int cropX, int cropY, int cropWidth, int cropHeight, string img, string sp)
    {
        Bitmap cropBitmap;
        string temp = Environment.GetEnvironmentVariable("Temp");

        string paths = temp + "//admakingimg.jpg";
        WebClient client = new WebClient();
        //client.DownloadFile(img, paths);
        string[] a = img.Split(new string[] { "images1/" }, StringSplitOptions.None);
        spath1 = sp + a[1];
        Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
        Bitmap bit = new Bitmap(spath1);
        //create a new bitmap with the width/height values that were specified in the textboxes.
        cropBitmap = new Bitmap(cropWidth, cropHeight);
        //a new Graphics object that will draw on the cropBitmap
        Graphics g = Graphics.FromImage(cropBitmap);
        g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel);
        //cropBitmap.Save(temp + "//test.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
        string[] a1 = img.Split(new string[] { "images1/" }, StringSplitOptions.None);
        string[] a2 = a1[1].Split(new string[] { "." }, StringSplitOptions.None);
        spath2 = sp + a2[0] + "1" + "." + a2[1];
        //System.IO.File.Delete(spath2);
        //sepath1.Value = spath1;
        //sepath.Value = spath;
        //string[] a1 = img.Split(new string[] { "test" }, StringSplitOptions.None);
        cropBitmap.Save(spath2, System.Drawing.Imaging.ImageFormat.Jpeg);
        id++;
        //sepath1.Value = spath1;
        return spath2;
    }
    //sepath.Value = spath;

    protected void btnCrop_Click(object sender, EventArgs e)
    {
        //string ImageName = Session["WorkingImage"].ToString();
        string ImageName = imagesource;

        int w = Convert.ToInt32(W.Value);

        int h = Convert.ToInt32(H.Value);

        int x = Convert.ToInt32(X.Value);

        int y = Convert.ToInt32(Y.Value);



        byte[] CropImage = Crop(spath + newimagename, w, h, x, y);

        using (MemoryStream ms = new MemoryStream(CropImage, 0, CropImage.Length))
        {

            ms.Write(CropImage, 0, CropImage.Length);

            using (SD.Image CroppedImage = SD.Image.FromStream(ms, true))
            {

                string SaveTo = spath.Replace("/images1", "/CropImages") + newimagename;

                CroppedImage.Save(SaveTo, CroppedImage.RawFormat);

                //pnlCrop.Visible = false;

                //pnlCropped.Visible = true;

                imgCropped.ImageUrl = imagesource.Replace("/images1", "/CropImages");
                imgCrop.Visible = false;

            }

        }
    }
    static byte[] Crop(string Img, int Width, int Height, int X, int Y)
    {

        try
        {

            using (SD.Image OriginalImage = SD.Image.FromFile(Img))
            {

                using (SD.Bitmap bmp = new SD.Bitmap(Width, Height))
                {

                    bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);

                    using (SD.Graphics Graphic = SD.Graphics.FromImage(bmp))
                    {

                        Graphic.SmoothingMode = SmoothingMode.AntiAlias;

                        Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                        Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        Graphic.DrawImage(OriginalImage, new SD.Rectangle(0, 0, Width, Height), X, Y, Width, Height, SD.GraphicsUnit.Pixel);

                        MemoryStream ms = new MemoryStream();

                        bmp.Save(ms, OriginalImage.RawFormat);

                        return ms.GetBuffer();

                    }

                }

            }

        }

        catch (Exception Ex)
        {

            throw (Ex);

        }

    }
}
