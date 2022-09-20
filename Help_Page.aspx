<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeFile="Help_Page.aspx.cs" Inherits="Help_Page" %>



<!DOCTYPE html PUBLIC "-//W3C//Dtr XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtr/xhtml1-transitional.dtr">
<head id="Head1" runat="server">
    <title>Help</title>

   <%-- <script src="javascript/Help.js" type="text/javascript"></script>--%>
 <%--      <script src="javascript/entertotab.js" type="text/javascript"></script>
       <script src="javascript/graph.js" type ="text/javascript"></script>--%>
       <script src="javascript/Help_Page.js" type ="text/javascript"></script>
   
    
    
    <style type="text/css">
   .DataGridFixedHeader 
   {
   	   position : relative;
   	  
       BACKGROUND-COLOR: white; 
   }
   </style>
    
    
    <style type="text/css">
        #lb1
        {
            top: 200px;
            left: 110px;
            position: absolute;
            height: 19px;
            width: 1032px;
        }
        .style1
        {
            width: 52px;
        }
        .style2
        {
            width: 120px;
        }
        .style3
        {
            width: 150px;
        }
    </style>
    </head>
<html xmlns="http://www.w3.org/1999/xhtml">
    
       
        <body onkeydown="javascript:return chkfld(event);", onload="form_load();">
        
        <form id="form1"  runat="server"> 
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="divcompany" style="position: absolute; top: 0px; left: 0px; border: none;display: none; z-index: 1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstcomp" Width="350px" Height="85px" runat="server" CssClass="btextlist"></asp:ListBox></td></tr></table></div>
    <div id="divprntcen" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstprnt" Width="350px" Height="85px"  runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
    <div id="divbranch" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstbrn" Width="350px" Height="85px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
    
                    <div runat="server" id="div1" style="width:600px;border:2px solid ;border-color:#7DAAE3;margin-left:100px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>               
          <table style= "width:450px">                       
          <tr><td><asp:Label ID="lblcompany" Font-Size="Small" Width="120px" runat="server" ></asp:Label></td>
            <td><asp:TextBox ID="txtcompany" runat="server" Width="40px"  ></asp:TextBox></td>
          <td><asp:TextBox ID="txtcompanyname" runat="server" Width="260px"  ></asp:TextBox></td></tr>
           
            
                        
          
          <tr><td><asp:Label ID="lblprtcen" Font-Size="Small"  runat="server" ></asp:Label></td>
             <td><asp:TextBox ID="txtprtcen" runat="server" Width="40px" ></asp:TextBox></td>
          <td><asp:TextBox ID="txprtcenname" runat="server"  Width="260px"  ></asp:TextBox></td></tr>
           
               
          
             <tr><td><asp:Label ID="lblbranch" Font-Size="Small" runat="server" ></asp:Label></td>
           <td><asp:TextBox ID="txtbranch" runat="server" Width="40px"   ></asp:TextBox></td>
          <td><asp:TextBox ID="txtbranchname" runat="server" Width="260px" ></asp:TextBox></td></tr>
             </table>  
            
            <table table style= "width:450px">             
      <tr><td><asp:label id="difftype" Font-Size="Small" Text="Difference Type"  runat="server"  style= " width:200px; " ></asp:label></td>
    
     
        <td><asp:DropDownList ID="helping" runat="server" Enabled = "true" Font-Size="Small" style= "vertical-align:middle;    height: 22px; width: 230px;" ></asp:DropDownList></td>
        </tr>
        </table>  
   
            <table style= "width:450px">  
                <tr><td class="style2"><asp:label id="Label1" Font-Size="Small" Text="Value"  runat="server" style= " width:300px; "   ></asp:label></td>
    
      
        <td class="style3"><asp:DropDownList ID="dd1" runat="server" 
                style= " width:150px; " Width="150px"  ><%--AutoPostBack="True"--%>
             <asp:ListItem>--select value--</asp:ListItem>
             <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
           </asp:DropDownList></td>
            
										 <td>
											     <asp:Button ID="btnresult"   width="90px" runat="server" Text="Show Result"  />
										 </td>
										 <td>
											     <asp:Button ID="btnexcel"   width="90px" runat="server" Text="Show Excel"  />
										 </td>
										 </tr>   
										  </table>  
       
      
              	
										
										  
  
         	   </ContentTemplate>
</asp:UpdatePanel>       
      </div>
         
     
       <tr>
                                        <td  align=center >
                                            <div runat="server" id="Div2" style="display:none;height:50px">
                                                
                                            </div>
                                        </td>
                                     </tr>
      
             <tr>
                                        <td  align=center >
                                            <div runat="server" id="wAITING" style="display:none;padding-left:200px">
                                                <img src="images/loading.gif" />
                                            </div>
                                        </td>
                                     </tr>
                                     
                                   
	                             <tr>
                                    <td>
                                      <%--<div style="overflow:auto;height:350px;">--%>
                                        <table cellpadding="0" cellspacing="0" >
                                            <tr>
                                                <td runat="server" id="flist" style="display: block; width:980px;" align="center" valign="top"
                                                    class="style1">
                                                </td>
                                                </tr>
          <td style="visible:false">
                                               <asp:GridView ID="grid3" Visible="false" ShowFooter="true" runat="server" Font-Names="Arial" Width="305px" >
                                               <RowStyle Font-Names="Arial" BackColor="White" Font-Size="12px" />
                                               <HeaderStyle Font-Size="X-Small" Font-Bold="true" />
                                               <FooterStyle Font-Names="Arial" Font-Size="12px" />
                                            </asp:GridView>
                                        </td>
                                                </table
      
  

	

	
	   <input id="graph_zoom_level" runat="server" type="hidden" />
            <input id="compcode" runat="server" type="hidden" />
            <input id="cirpub" runat="server" type="hidden" />
            <input id="open_graph" runat="server" type="hidden" />
            <input id="color1" runat="server" type="hidden" />
            
            <input id="pagename" runat="server" type="hidden" />
            <input id="hiddentbl" runat="server" type="hidden" />
            <input id="hiddentabl" runat="server" type="hidden" />
         <%-- <input id="current" runat="server" type="hidden" />
          <input id="previous" runat="server" type="hidden" />
          <input id="year" runat="server" type="hidden" />--%>
            <input id="chart_type1" runat ="server" type="hidden" />
            <input id="zoom_out" runat="server" type="hidden" />
            <input id="open_chart" runat="server" type="hidden" />
            <input id="chk_zero" runat="server" type="hidden" />
            <input id="Menu1_type1" runat="server" type="hidden" />
            <input id="Menu2_type1" runat="server" type="hidden" />
            <input id="Menu3_type1" runat="server" type="hidden" />
            <input id="Menu4_type1" runat="server" type="hidden" />
            <input id="Menu5_type1" runat="server" type="hidden" />
            <input id="Menu6_type1" runat="server" type="hidden" />
            <input id="count" runat="server" type="hidden" />
            <input id="count1" runat="server" type="hidden" />
            <input id="count2" runat="server" type="hidden" />
            <input id="Zoom" runat="server" type="hidden" />
            <input id="hidden_sess" runat="server" type="hidden" />
            <input id="hiddendateformat" runat="server" type="hidden" />
             <input type="hidden" runat="server" id="hdn_user_right" />
             <input id="hdncompcode" type="hidden" runat="server" name="hdncompcode" />

    
                    </form>
            </body>
            
         

</html>
