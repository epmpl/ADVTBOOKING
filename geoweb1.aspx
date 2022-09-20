<%@ Page Language="C#" AutoEventWireup="true" CodeFile="geoweb1.aspx.cs" Inherits="geoweb1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Geographical</title>
    
      <script language="javascript" src="javascript/geowebbook.js" type="text/javascript"></script>
      
      
    <style type="text/css">
        
      .dropdown123
        {
        	width:"1px";
        	height:"10px";
        	
        }
        
        
        
        .inputbuttongeo
{
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10px;	
	color: #000000;
	background-color:#e1e1e1;	
	height:24px;
	width:62px;
}
        
        
        
.dropdown
	{
	
	 border: 1px solid #929292;
	background-color: #ffffff;
	font-family: verdana;
	font-size: 10px;
	color: #000000;
	height:17px;
	width:144px;
		
}


.dropdowntime
	{
	
	 border: 1px solid #929292;
	background-color: #ffffff;
	font-family: verdana;
	font-size: 10px;
	color: #000000;
	height:17px;
	width:30px;
		
}    
        
        
        
        
        .maindiv
        {
            width: auto;
            height: auto;
        }
        .leftdiv
        {
            width: 300px;
            float: left;
            height: 200px;
            overflow: auto;
        }
        .rightdiv
        {
            width: 200px;
            float: right;
            height: 40px;
        }
        .tree
        {
            border-top: 1px solid #FFFFFF;
            border-bottom: 1px solid #DDD;
            display: block;
            font-size: 10px;
            font-family: Arial;
            width: 160px;
        }
        .geography
        {
            overflow: auto;
            vertical-align: top;
            height: 30px;
            background-color: #7daae3;
            text-align: center;
            font-family: Arial;
            color: White;
        }
        .gridtext
        {
            font-size: 10px;
            font-family: Arial;
        }
        .image
        {
            padding-right: auto;
            text-align: right;
            float: right;
            border-color: White;
        }
        .image1
        {
            text-align: right;
            float: right;
        }
    </style>

    

</head>
<body onload="excutedays123()">
     <form  style="margin-left:0px;margin-top:0px; vertical-align:top;"  id="form1" runat="server">
    
    <table>  <tr valign="top"><td colspan="3" align="left"  style="font-size:14px;font-family:Arial;" ><b>Geography</b></td></tr></table>
   
    <table width="575px"   style="border: 2px solid #0066FF; margin-top:0px; caption-side: top; v-align:top;">
       
     
       
        <tr>
            <td valign="top">
                <div class="leftdiv ">
                
                    <asp:TreeView ID="someTree" runat="server" ForeColor="Blue" CssClass="tree" ShowCheckBoxes="All"
                        Height="100px" EnableClientScript="true" SelectionAction="none" 
                        >
                    </asp:TreeView>
                </div>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td valign="top">
                <div class="rightdiv">
                    <table border="0" width="200px">
                        <tr>
                          
                        </tr>
                        <tr>
                            <td>
                                <div id="dynamicvalue" runat="server">
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        
        
        </table>
        <table width="530px"> <tr><td colspan="3" align="left" style="font-size:14px;font-family:Arial;" ><b>Adjust Delivery</b>&nbsp;&nbsp;<asp:Button ID="Button1" CssClass="inputbuttongeo" runat="server" Text="Views" Enabled="false" /></td></tr></table>
         <table width="575px"  style="border: 2px solid #0066FF; margin-top:0px; caption-side: top;">
         <tr>
         <td>
         
         
        <table width="530px"  >
        
 
       
      <tr> <td width="100px"><asp:Label ID="lbagency" runat="server" style="font-size:14px;font-family:Verdana"  Text="Rotation(%)" ></asp:Label></td>
       <td Width="30px"></td>
       <td ><asp:TextBox ID="txtrotation" runat="server" Height="15px" width="150px" 
                                                       
                                 onkeypress="return isNumberKey(event);"           MaxLength="3"            ></asp:TextBox></td></tr>
       
       
       
       
     
       <tr>
       <td width="100px"><asp:Label ID="Label1" runat="server" style="font-size:14px;font-family:Verdana"  Text="Priority" ></asp:Label></td>
       <td Width="30px"></td>
       <td><asp:TextBox ID="txtpriority" runat="server" Height="15px" width="150px" 
                                                       
                                                        ></asp:TextBox></td>
       
       </tr>
       
       </table>
       
       
       </td></tr>
       
       </table>
       
        
       
       
       <tr><td>
     
       
      <table width="530px" >
             
       <tr><td style="font-size:14px;font-family:Arial;"><b>Days</b></td></tr>
       </table>
       
       </td></tr>
       
       <table width="530px"  style="border: 2px solid #0066FF; margin-top:0px; caption-side: top;">
       
       
       
       <tr><td>
       
     
      <table width="530px" border="0" >
       
             <tr>
                                                                    <td  style="text-align:center; background-color:#7daae3;font-size:14px;font-family:Verdana;"  >Sunday</td>
                                                                    <td style="text-align:center; background-color:#7daae3;font-size:14px;font-family:Verdana;" >Monday</td>
                                                                    <td style="text-align:center; background-color:#7daae3;font-size:14px;font-family:Verdana;" >Tuesday</td>
                                                                    <td style="text-align:center; background-color:#7daae3;font-size:14px;font-family:Verdana;" >Wednesday</td>
                                                                    <td style="text-align:center; background-color:#7daae3;font-size:14px;font-family:Verdana;" >Thursday</td>
                                                                    <td style="text-align:center; background-color:#7daae3;font-size:14px;font-family:Verdana;" >Friday</td>
                                                                    <td style="text-align:center; background-color:#7daae3;font-size:14px;font-family:Verdana;" >Saturday</td>
                                                                </tr>
                                                                
                                                               <tr>
                                                                <td align="center"  style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px">  <asp:CheckBox ID="chks" runat="server"  />   </td>
                                                                <td align="center"   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px">  <asp:CheckBox ID="chkm" runat="server"   />   </td>
                                                                <td align="center"   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px">  <asp:CheckBox ID="chkt" runat="server"   />   </td>
                                                                <td align="center"   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px">  <asp:CheckBox ID="chkw" runat="server"  />   </td>
                                                                <td align="center"   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px">  <asp:CheckBox ID="chkth" runat="server"   />   </td>
                                                                <td align="center"   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px">  <asp:CheckBox ID="chkf" runat="server"   />   </td>
                                                                <td align="center"   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px">  <asp:CheckBox ID="chksat" runat="server"  />   </td>
                                                             
                                                                </tr>
                                                                
                                                           <tr>
                                                                
                                                                <td     style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px;font-family:"verdana""  >F&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T</td>
                                                              <td      style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px;font-family:"verdana""><table  width="50px"><tr><td align="left">F</td><td align="right">T</td></tr></table></td>
                                                               <td      style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px;font-family:"verdana""><table  width="60px"><tr><td align="left">F</td><td align="right">T</td></tr></table></td>
                                                                 <td     style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px;font-family:"verdana""><table  width="80px"><tr><td align="left">F</td><td align="right">T</td></tr></table></td>
                                                                 <td      style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px;font-family:"verdana""><table  width="80px"><tr><td align="left">F</td><td align="right">T</td></tr></table></td>
                                                                  <td      style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px;font-family:"verdana""><table  width="80px"><tr><td align="left">F</td><td align="right">T</td></tr></table></td>
                                                                  <td     style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px;font-family:"verdana""><table  width="60px"><tr><td align="left">F</td><td align="right">T</td></tr></table></td>
                                                                
                                                                
                                                                </tr>
                                                                
                                                                
                                                                        <tr>
                                                                
                                                                  <td style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px"><table><tr><td><asp:DropDownList  CssClass="dropdowntime" ID="tfs" runat="server" >
                                                                      
                                                </asp:DropDownList></td><td><asp:DropDownList CssClass="dropdowntime"    ID="tts" runat="server"   >
                                                </asp:DropDownList></td></tr></table></td>
                                                
                                                
                                                
                                                                <td style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px"><table><tr><td><asp:DropDownList CssClass="dropdowntime" ID="tfm" runat="server" 
                                                                       
                                                                     
                                                                       >
                                                </asp:DropDownList></td><td><asp:DropDownList  CssClass="dropdowntime" ID="ttm" runat="server"   >
                                                </asp:DropDownList></td></tr></table></td>
                                                
                                                
                                                   <td   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px"><table><tr><td><asp:DropDownList ID="tft" CssClass="dropdowntime"  runat="server" 
                                                                      
                                                                     
                                                                       >
                                                </asp:DropDownList></td><td><asp:DropDownList  CssClass="dropdowntime" ID="ttt" runat="server" >
                                                </asp:DropDownList></td></tr></table></td>
                                                  <td   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px"><table><tr><td><asp:DropDownList ID="tfw" runat="server" CssClass="dropdowntime" 
                                                                     
                                                                     
                                                                     Width="30px"  >
                                                </asp:DropDownList></td><td><asp:DropDownList  CssClass="dropdowntime" ID="ttw" runat="server"   >
                                                </asp:DropDownList></td></tr></table></td>
                                                  <td   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px"><table><tr><td><asp:DropDownList ID="tft1" CssClass="dropdowntime" runat="server" 
                                                                        
                                                                     
                                                                       >
                                                </asp:DropDownList></td><td><asp:DropDownList  CssClass="dropdowntime" ID="ttt1" runat="server"  >
                                                </asp:DropDownList></tr></table></td>
                                                
                                                   <td   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px"><table><tr><td><asp:DropDownList ID="tff" CssClass="dropdowntime" runat="server" 
                                                                     
                                                                     
                                                                       >
                                                </asp:DropDownList></td><td><asp:DropDownList CssClass="dropdowntime" ID="ttf" runat="server"  >
                                                </asp:DropDownList></tr></table></td>
                                                
                                                
                                                   <td   style="border-right-style:solid;border-right-width:thin; border-color:#7DAAE3;font-size:14px"><table><tr><td><asp:DropDownList ID="tfsat" CssClass="dropdowntime" runat="server" 
                                                                       
                                                                     
                                                                       >
                                                </asp:DropDownList></td><td><asp:DropDownList ID="ttsat" CssClass="dropdowntime" runat="server"  >
                                                </asp:DropDownList></tr></table></td>
                                                                
                                                                
                                                                </tr>
                                     
   
       </table>
       
       </td></tr>
       </table>
       
       <table><tr><td align="left" style="font-size:14px;font-family:Arial;"><b>Demography</b></td></tr></table>
       
       <table  width="575px"   style="border: 2px solid #0066FF; margin-top:0px; caption-side: top;"> <tr>
       
       <td align="left" style="font-size:14px;font-family:Verdana;" width="75px"  >Sex</td><td width="20px"></td><td style="font-size:14px"><asp:RadioButton runat="server" Text="Male" ID="ml1" GroupName="Radio" ></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton runat="server" Text="Female" ID="fe1" GroupName="Radio" ></asp:RadioButton></td>
       
       
       </tr>
       <tr>
       <td align="left" style="font-size:14px;font-family:Verdana;" width="80px"> Age Group</td><td width="20px"></td>
       
       <td>
       <asp:DropDownList runat="server" ID="age1" CssClass="dropdown"  ></asp:DropDownList>
       </td></tr>
       
       <tr><td align="left" style="font-size:14px;font-family:Verdana;" width="75px" >Occupation</td><td width="20px"></td><td>
       <asp:DropDownList runat="server" ID="occup" CssClass="dropdown" ></asp:DropDownList>
                </td></tr>
        <tr><td align="left" style="font-size:14px;font-family:Verdana;" width="75px">Interest</td><td width="20px"><td id="dynamiccheck" runat="server"></td></td></tr>
       
       
       
       
        </table>
       
       
      
     
        
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="save" CssClass="inputbuttongeo"  runat="server" Text="Save" />&nbsp;<asp:Button
                    ID="cancel" CssClass="inputbuttongeo" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
    <input type="hidden" id="hiddencompcode" runat="server" />
    <input type="hidden" id="hdnuserid" runat="server" />
    <input type="hidden" id="hdnobj" runat="server" />
    <input type="hidden" id="hdnciobookid123" runat="server" />
     <input type="hidden" id="hdneditiongeo" runat="server" />
      <input type="hidden" id="hdnnoinsert" runat="server" />
            <input type="hidden" id="hdnexecute" runat="server" />
            <input type="hidden" id="hdnnoinsert123" runat="server" />
            <input type="hidden" id="hdneditiongeo123" runat="server" />
            <input type="hidden" id="hdnflag" runat="server" />
          <input type="hidden" id="hdnadcategory" runat="server" />
    <input type="hidden" id="hdnuom" runat="server" />
     <input type="hidden" id="hdndummydate" runat="server" />
      <input type="hidden" id="hdnpageprem" runat="server" />
     
    </form>
</body>
</html>
