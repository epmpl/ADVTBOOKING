<%@ Page Language="C#" AutoEventWireup="true" CodeFile="crop2.aspx.cs" Inherits="crop2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/cropper.css" rel="stylesheet" type="text/css" />
    <link href="css/cropper_ie5.css" rel="stylesheet" type="text/css" />
    <link href="css/cropper_ie6.css" rel="stylesheet" type="text/css" />
    <link href="css/screen.css" rel="stylesheet" type="text/css" />

    <script src="js/lib/prototype.js" type="text/javascript"></script>

    <script src="js/lib/scriptaculous.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/lib/builder.js"></script>

    <script type="text/javascript" src="js/lib/dragdrop.js"></script>

    <script src="js/lib/cropper.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/cropped.js"></script>

    <script src="js/lib/init_cropper.js" type="text/javascript"></script>

	<!--govind test--> 

</head>
<body onload="document.getElementById('cropImage').setAttribute('src',opener.document.getElementById('imagepath').value);">
    <form id="form1" runat="server">
        <div id="crop_save">
            <form class="frmCrop" method="post">
                <!--<fieldset>
                    <legend>Continue</legend>
                    <input name="imageWidth" id="imageWidth" value="400" type="text">
                    <input name="imageHeight" id="imageHeight" value="214" type="text">
                    <input name="imageFileName" id="imageFileName" type="text">
                    <input name="cropX" id="cropX" value="0" type="text">
                    <input name="cropY" id="cropY" value="0" type="text">
                    <input name="cropWidth" id="cropWidth" value="0" type="text">
                    <input name="cropHeight" id="cropHeight" value="0" type="text">
                    <input class="hidden" name="sessID" id="sessID" value="e33528ee73b5407487601af3bf6b9ba0"
                        type="hidden">
                    <div id="submit">
                        <input value="Save" name="save" id="save" type="button" onclick="showResult();">
                    </div>
                </fieldset>-->
            </form>
        </div>
        <!-- /crop_save -->
        <div id="crop">
            <div id="cropWrap">
                <div style="width: 400px; height: 214px;" class="imgCrop_wrap">
                    <img alt="Image to crop" id="cropImage">
                    <div class="imgCrop_dragArea">
                        <div style="height: 0pt;" class="imgCrop_overlay imgCrop_north">
                            <span></span>
                        </div>
                        <div style="width: 0pt; height: 0pt;" class="imgCrop_overlay imgCrop_east">
                            <span></span>
                        </div>
                        <div style="height: 0pt;" class="imgCrop_overlay imgCrop_south">
                            <span></span>
                        </div>
                        <div style="width: 0pt; height: 0pt;" class="imgCrop_overlay imgCrop_west">
                            <span></span>
                        </div>
                        <div style="display: none;" class="imgCrop_selArea">
                            <div class="imgCrop_marqueeHoriz imgCrop_marqueeNorth">
                                <span></span>
                            </div>
                            <div class="imgCrop_marqueeVert imgCrop_marqueeEast">
                                <span></span>
                            </div>
                            <div class="imgCrop_marqueeHoriz imgCrop_marqueeSouth">
                                <span></span>
                            </div>
                            <div class="imgCrop_marqueeVert imgCrop_marqueeWest">
                                <span></span>
                            </div>
                            <div class="imgCrop_handle imgCrop_handleN">
                            </div>
                            <div class="imgCrop_handle imgCrop_handleNE">
                            </div>
                            <div class="imgCrop_handle imgCrop_handleE">
                            </div>
                            <div class="imgCrop_handle imgCrop_handleSE">
                            </div>
                            <div class="imgCrop_handle imgCrop_handleS">
                            </div>
                            <div class="imgCrop_handle imgCrop_handleSW">
                            </div>
                            <div class="imgCrop_handle imgCrop_handleW">
                            </div>
                            <div class="imgCrop_handle imgCrop_handleNW">
                            </div>
                            <div class="imgCrop_clickArea">
                            </div>
                        </div>
                        <div class="imgCrop_clickArea">
                        </div>
                    </div>
                </div>
            </div>
            <!-- /cropWrap -->
        </div>
        <!-- /crop -->
    </form>
</body>
</html>
