<%@ Page Language="C#" AutoEventWireup="true" CodeFile="crop.aspx.cs" Inherits="crop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crop the Image</title>
    <link href="css/jquery.Jcrop.css" type="text/css" rel="stylesheet"/>
  <script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.Jcrop.js"></script>
<script type="text/javascript" src="js/aj.js"></script>


<script type="text/javascript">

  jQuery(document).ready(function()
   {
      jQuery('#imgCrop').Jcrop({
      onSelect: storeCoords

    });

  });

 

  function storeCoords(c)
   {
     jQuery('#X').val(c.x);
     jQuery('#Y').val(c.y);
     jQuery('#W').val(c.w);
     jQuery('#H').val(c.h);
   };
   
</script>

</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
        <table border="1">
            <tr>
                <td>
                    <div>
                        <input type="hidden" id="gettemp" runat="server" />
                        <asp:Image ID="imgCrop" ImageUrl="~/images1/sunset.jpg" runat="server" />
                    </div>
                </td>
                 <td>
                    <table>
                        <!--<tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="proplbl" Text="Crop Height"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="heights" CssClass="proptxt" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Crop Width"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="widths" CssClass="proptxt" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" CssClass="proplbl" Text="Left:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="left" CssClass="proptxt" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" CssClass="proplbl" Text="Top:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="top" CssClass="proptxt" runat="server"></asp:TextBox>
                            </td>
                        </tr>-->
                        
                        <tr>
                            <td colspan="2">
                                <!--<img id="imgCropped"/>-->
                                <asp:Image ID="imgCropped" runat="server" />
                                <input type="hidden" id="sepath" runat="server" />
                                <input type="hidden" id="sepath1" runat="server" />
                                <input type="hidden" id="sepath2" runat="server" />
                                 <asp:HiddenField ID="X" runat="server" />

                              <asp:HiddenField ID="Y" runat="server" />

                              <asp:HiddenField ID="W" runat="server" />

                              <asp:HiddenField ID="H" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 63px; height: 26px">
                                <asp:Button ID="crpimg" OnClick="btnCrop_Click" CssClass="button1" Text="Crop Image" runat="server" />
                            
                            </td>
                                
                            <td style="width: 63px; height: 26px">
                                 <asp:Button ID="apply" CssClass="button1" Text="Apply" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
