<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CD_Upload.aspx.cs" Inherits="CD_Upload" %>


<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Classified Display : Material Uploading</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/CD_Upload.js"></script>		
		<%--<script language="javascript" src="javascript/popcalendar.js"></script>	--%>	
		 <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>			
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
	</style>
		<link href="css/main.css" type="text/css" rel="stylesheet" />
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript">
		function dateenter(event)
        {
            if(navigator.appName!="Microsoft Internet Explorer")
            {
                if((event.which>=46 && event.which<=57) || (event.which==111) || (event.which==127) || (event.which==191) ||(event.which==8)||(event.which==9) || (event.which==13))
                    return true;
                else
                    return false;
            }
            else
            {
            //if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
                if((event.keyCode>=46 && event.keyCode<=57) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
		</script>	
		
</head>
<body  style="background-color:#f3f6fd; margin-top:0px;">
    <form id="form1" runat="server">    
        <table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0" style="height: 27%">
			<tr valign="top">
				<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Material Uploading"></uc1:topbar></td>
			</tr>
			<tr valign="top" >
				<td valign="top" style="width: 22%;" ><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
				<td valign="top" id="frsttd" style="width: 774px;">	
				<table id="RightTable" cellpadding="0" cellspacing="0" border="0" >
				<tr valign="top">
				    <td>
                        <asp:ImageButton id="btnQuery" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
                        <asp:button id="btnView" runat="server" Height="24px" Font-Bold="True" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton" Visible="False"></asp:button>
                        <asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
                        <asp:ImageButton id="btnExit" runat="server" CssClass="topbutton"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
                    </td>
                    <td>
                        <asp:Label id="lbback" class="topbarclock" runat="server" Width="506px" Height="27px" CssClass=""></asp:Label>
                    </td>
				</tr>
				<tr>
				    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </td>
                </tr>
                </table>
                </td>
             </tr>
             </table>
					
		<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
              <tr>
		         <td style="width:27px;"></td>
                 <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                 <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>CD Uploading</b></center></td>
                 <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
			     <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
               </tr>
        </table>
        
        <table style="width:auto;margin:10px 40px;" cellpadding="0" cellspacing="0">					
		    <tr>
			    <td valign="top" id="secid" style="width: 294px"> 
			    <table cellspacing="0" cellpadding="0" align="center" border="0" width="600" 
                        style="height: 219px">
			        <tr>
			            <td style="width:209px"><asp:Label ID="lblPublicationDate" runat="server" CssClass="LabelField"></asp:Label></td>
				        <td style="width: 293px"><asp:TextBox ID="PubDate" runat="server" CssClass="btext1" onpaste="return false;"  MaxLength="15"  onkeypress="return dateenter(event);"></asp:TextBox>
                        <img src='Images/cal1.gif' alt="" id="div1" onclick='popUpCalendar(this, form1.PubDate, "mm/dd/yyyy")' height="16" width="16" /></td>                           
			        </tr>					    
			        <tr>
			            <td style="width: 209px"><asp:Label ID="lblPublication" runat="server" CssClass="LabelField"></asp:Label></td>
				        <td style="width: 293px">
                            <asp:DropDownList ID="ddlPublication" runat="server" CssClass="dropdown" Width="160px"><asp:ListItem Value="0">Select Publication</asp:ListItem></asp:DropDownList></td>                           
			        </tr>
					    
			        <tr>
			            <td style="width: 209px"><asp:Label ID="lblCenter" runat="server" CssClass="LabelField"></asp:Label></td>
				        <td style="width: 293px">
                            <asp:DropDownList ID="ddlCenter" runat="server" CssClass="dropdown" Width="160px"><asp:ListItem Value="0">Select Center</asp:ListItem></asp:DropDownList></td>                        
			        </tr>
			        <tr>
			            <td style="width: 209px"><asp:Label ID="lblEdition" runat="server" CssClass="LabelField" Width="160px"></asp:Label></td>
				        <td style="width: 293px">
                            <asp:DropDownList ID="ddlEdition" runat="server" CssClass="dropdown" Width="160px"><asp:ListItem Value="0">Select Edition</asp:ListItem></asp:DropDownList></td>                        
			        </tr>
			        <tr>
			            <td style="width: 209px"><asp:Label ID="lblSupplement" runat="server" CssClass="LabelField" Width="160px"></asp:Label></td>
				        <td style="width: 293px">
                            <asp:DropDownList ID="ddlSupplement" runat="server" CssClass="dropdown" Width="160px"><asp:ListItem Value="0">Select Supplement</asp:ListItem></asp:DropDownList></td>
                    </tr>
                    <tr>
			            <td style="width: 209px"><asp:Label ID="lblpageno" runat="server" CssClass="LabelField"></asp:Label></td>
				        <td style="width: 293px">
                            <asp:TextBox ID="txtPage" runat="server" CssClass="btext1" Width="160px"></asp:TextBox></td>
                    </tr>
                       
                    <tr style="width: 209px;height:20px">
                        <td > </td>                       
                        <td style="width: 293px" colspan="4"><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="btnAdView" runat="server" Font-Bold="True" OnClick="btnAdView_Click" Text="View" Font-Size="XX-Small" Width="82px" />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                         </td>
                    </tr>      
			        <tr>
			            <td  colspan="3">  <input  size="52" id="myFile" type="file" runat="server" />	</td>
				                               
		            </tr>
		            <tr>
		              <td>
				           			            
                                <asp:Button ID="btnUpload" runat="server"  Font-Bold="True" Font-Size="XX-Small" Text="Upload" OnClick="btnUpload_Click" Height="18px" />                                                            
                                <asp:Button ID="btnUpdateFilename" runat="server"  Font-Bold="True" Font-Size="XX-Small" Text="Update Filename" OnClick="btnUpdateFilename_Click" Height="18px" />                               
                            </td>   
		            </tr>
		            <tr><td style="height:20px"></td>
				        <td><asp:LinkButton ID="Btnremove" runat="server" Text="Remove" OnClick="Btnremove_Click"></asp:LinkButton>
                             &nbsp&nbsp &nbsp  &nbsp<asp:LinkButton ID="btnPreview" runat="server" Text="Preview" OnClick="Preview_Click"></asp:LinkButton></td>
				    </tr>
				    
				    
				    
				    				    <tr style="width: 45px"><td style="width: 25px"><asp:Label ID="Label2" runat="server" CssClass="LabelField">All</asp:Label>
                       
                                            <input id="Checkbox4"  type="checkbox" name="Checkbox4" runat="server"  />

                        
                        </td></tr>
				    
		        </table>
		        </td>	        
		        
		        </tr>
		        </table>
                       
            <table  cellpadding="0" style=" margin-left:15px;"  cellspacing="0">
                <tr align="center" > <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtgridSize" runat="server" CssClass="btext1" Width="70px"  onpaste="return false;"  MaxLength="3"  onkeypress="return dateenter(event);"></asp:TextBox>
                <asp:GridView ID="GridView1" runat="server" CssClass="dtGrid" Width="1050px" AllowPaging="True"  OnPageIndexChanging="GridView1_PageIndexChange" AutoGenerateColumns="False" PageSize="8"><%----%>
                <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" Font-Size="X-Small" ForeColor="White" Height="20px" HorizontalAlign="Center" />
                <Columns>
                <asp:TemplateField><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>										   
				<input  name="RadioButton1" type="radio" value='<%# Eval("file_name") %>'/>                            
				</ItemTemplate></asp:TemplateField>										
                    <asp:BoundField DataField="idnum" HeaderText="Order No" />
                    <asp:BoundField DataField="colour" HeaderText="Color" />
                    <asp:BoundField DataField="sz1" HeaderText="Ht" />
                    <asp:BoundField DataField="col1" HeaderText="Wd" />
                    <asp:BoundField DataField="pubsize" HeaderText="Pubht" />
                    <asp:BoundField DataField="pubcol" HeaderText="Pubwd" />
                    <asp:BoundField DataField="client_name" HeaderText="Agency Name" />
                    <asp:BoundField DataField="clientname" HeaderText="Clientname" />
                    <asp:BoundField DataField="caption" HeaderText="Caption" Visible="true" />
                    <asp:BoundField DataField="page_no" HeaderText="PageNo" />
                    <asp:BoundField DataField="insnum" HeaderText="Insnum" />
                    <asp:BoundField DataField="file_name" HeaderText="Filename" />
                    <asp:BoundField DataField="remark1" HeaderText="Remark" ItemStyle-Width="100px"/>
                    <asp:BoundField DataField="insert_id" HeaderText="Insertid" Visible="true"/>
                    <asp:BoundField DataField="edition_name" HeaderText="Edition" Visible="true"/>
                                      <%--  <asp:CommandField DeleteText="Remove"  ShowDeleteButton="True" />--%>
                </Columns>
                <PagerSettings FirstPageText="&amp;lt; &amp;lt;" LastPageText="&amp;gt; &amp;gt;" />                                  
                </asp:GridView>                                
                </ContentTemplate>
                </asp:UpdatePanel>
                                             
                <asp:label id="li" runat="server"></asp:label>
                    
            </td></tr>
            </table>
				<input id="hiddenuserid" runat="server" type="hidden" name="hiddenuserid" />
                <input id="hiddenusername" runat="server" type="hidden" name="username" />
                <input id="hiddencompcode" runat="server" type="hidden" name="hiddencompcode" />
                <input id="hiddendateformat" runat="server" type="hidden" name="hiddendateformat" />
                <input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server"/>
                <input id="hiddenpermission" type="hidden" name="hiddenpermission" runat="server" />
                <input id="UserLabel" type="hidden" name="UserLabel" runat="server"/> 
                <input id="hiddenstatuslabel" type="hidden" name="hiddenstatuslabel" runat="server" />
                <input id="hiddenolddate" runat="server" type="hidden" name="hiddenolddate" /> 
                <input id="hiddenftpcenters" runat="server" type="hidden" name="hiddenftpcenters" />                 
                <asp:label id="Label1" runat="server" ></asp:label>
    </form>
</body>
</html>

