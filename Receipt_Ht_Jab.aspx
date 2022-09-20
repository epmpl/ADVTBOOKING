<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receipt_Ht_Jab.aspx.cs" Inherits="Receipt_Ht_Jab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Receipt</title>
     <link href="css/report.css" type="text/css" rel="stylesheet"/>
</head>
<body style="margin-top:0px;">
    <form id="form1" runat="server">
    <div>
    <table cellpadding ="0" cellspacing ="0" width="500px" border="0">
        <tr>
            <td colspan ="3"  align ="center" valign="top">
                <table width="50%" cellpadding="0" cellspacing="0">
                <tr>
                <td align="left"><asp:Button id="btnpdf" runat="server" Visible="false" Text="Convert to PDF" CssClass="topbutton" Width="91px" Font-Size="XX-Small"
							BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px" OnClick="btnpdf_Click"/></td>
                    <td align="left" valign="top">
                        <img src="Images/receipt_logo.gif" alt=""  />
                    </td>
                </tr>
                <tr><td align="left" class="labelhtheading">Regd. Office:</td>
                <td align="left"><asp:Label ID="lblqbcname"  CssClass="labelhtheading" runat="server" Text="" Width="210px"></asp:Label></td>
                <td align="left" class="labelhtheading" >Local Office:</td></tr>
                <tr><td align="left" class="labelhtheading"></td>
                <td align="left"><asp:Label ID="lblqbcaddress"  CssClass="labelhtheading" runat="server" Text="" Width="210px"></asp:Label></td>
                <td align="left" class="labelhtheading"></td></tr>
                    <tr>
                        <td align="left"><asp:Label ID="lblheadingmain"  CssClass="labelhtheading" runat="server" Text="" Width="200px"></asp:Label></td>
                        <td></td>
                        <td align="left"><asp:Label ID="lblheadingadd" CssClass="labelhtheading" runat="server" Text="" Width="200px"></asp:Label></td>
                    </tr>
                     <tr>
                        <td align="left"><asp:Label ID="labelhtheadingph"  CssClass="labelhtheading" runat="server" Text="" Width="200px"></asp:Label></td>
                        <td></td>
                        <td align="left"><asp:Label ID="lblheadingph" CssClass="labelhtheading" runat="server" Text="66561396,66561437" Width="200px"></asp:Label></td>
                    </tr>
                  
                    <tr style="display:none">
                        <td style="padding-top:20px"><asp:Label ID="lblheading" CssClass="labelhtheading" runat="server" Text="Heading" Width="200px"></asp:Label></td>
                    </tr>
                </table>             
                
            </td>
        </tr>
        <tr>
        <td style="width :100%">
            <table cellpadding="0" cellspacing ="0" style="margin-left :120px" width="400px" border="0">
                  <tr>
                        <td style="width:110px"><asp:Label ID="lableclientname" CssClass="labelht" runat="server" Width="110px" ></asp:Label></td>
                        <td style="width:150px"><asp:Label ID="lblclientname" CssClass="labelhtdata" runat="server" Width="200px" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width:110px"><asp:Label ID="lableclientadd" CssClass="labelht" runat="server" Text="" Width="110px"></asp:Label></td>
                        <td style="width:150px"><asp:Label ID="lblclientadd" CssClass="labelhtdata" runat="server" Text="" Width="200px"></asp:Label></td>
                    </tr>
            </table>
        </td>
           <%-- <td style="width :300px;padding-left:82px" align ="left" >
                <asp:Label ID="Label12" runat="server"></asp:Label>
            </td>
            <td style="width :125px;padding-left:30px" align ="left">
                
            </td>
            <td style="width :50px" align ="left">
                
           </td>--%>
        </tr>
          <%--<tr>
            <td style="width :100px" align ="left" valign="top">
                <table>
                    <tr>
                        <td><asp:Label ID="lblreceiptno" CssClass="labelht" runat="server" Width="100px"></asp:Label></td>
                     <td><asp:Label ID="lblreceiptnov" CssClass="labelht" runat="server" Width="100px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblcat" CssClass="labelht" runat="server" Width="100px"></asp:Label></td>
                    <td><asp:Label ID="lblcatv" CssClass="labelht" runat="server" Width="100px"></asp:Label></td>
                    </tr>
                  
                </table>
            </td>
            
            <td align ="left" valign="top">
                <table>
                    <tr>
                        <asp:Label ID="lblRDate" CssClass="labelht" Width="125px" runat="server"></asp:Label>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbldetype" CssClass="labelht" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblcatname" CssClass="labelht" runat="server"></asp:Label></td>
                    </tr>
                    
                </table>
            </td>
            <td align ="left" valign="top">
                <table>
                    <tr>
                        <td>
                      <asp:Label ID="lblRDatev" CssClass="labelht" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbldetypev" CssClass="labelht" runat="server" ></asp:Label></td>
                    </tr>
                    
                    <tr>
                        <td style="height: 18px"><asp:Label ID="lblcatnamev" CssClass="labelht" runat="server" ></asp:Label></td>
                    </tr>
                    
                </table>
             </td>
        </tr>--%>
         <%--<tr>
            <td style="width :250px;padding-left:82px" align ="left" valign="top" >
                
            </td>
            <td style="width :125px">
               &nbsp;
            </td>
            <td style="width :125px">
               &nbsp;
           </td>
        </tr>--%>
    </table>
    <table cellpadding="0" cellspacing="0" border="1" width="640px">
        <tr>
             <td style="width:30px"><asp:Label ID="lblreceiptno" CssClass="labelht" runat="server" Width="100px"></asp:Label></td>
             <%--<td><asp:Label ID="lblsapid" CssClass="labelht" runat="server" Width="100px"></asp:Label></td>--%>
               <td>  <asp:Label ID="lblRDate" CssClass="labelht" Width="80px" runat="server"></asp:Label></td>
              <td><asp:Label ID="lblcat" CssClass="labelht" runat="server" Width="100px"></asp:Label></td>
               <td><asp:Label ID="lbldetype" CssClass="labelht" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcatname" CssClass="labelht" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblrostatus" CssClass="labelht" runat="server"></asp:Label></td>
        </tr>
        <tr>
              <td><asp:Label ID="lblreceiptnov" CssClass="labelhtdata" runat="server" Width="100px"></asp:Label></td>
             <%-- <td><asp:Label ID="lblsapidv" CssClass="labelhtdata" runat="server" Width="100px"></asp:Label></td>--%>
                <td>  <asp:Label ID="lblRDatev" CssClass="labelhtdata" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcatv" CssClass="labelhtdata" runat="server" Width="100px"></asp:Label></td>
                  <td><asp:Label ID="lbldetypev" CssClass="labelhtdata" runat="server" ></asp:Label></td>
                  <td style="height: 18px"><asp:Label ID="lblcatnamev" CssClass="labelhtdata" runat="server" ></asp:Label></td>
                    <td><asp:Label ID="lblrostatusv" CssClass="labelhtdata" runat="server" ></asp:Label></td>
        </tr>
    </table>
    
    <table cellpadding ="0" cellspacing ="0" width ="400px" style ="margin-top :10px" border="0">
         <tr>
            
             <td  align="center" >
                <asp:Label ID="lblsub" CssClass="labelht" runat="server" Width="50px"></asp:Label></td>
            <td colspan ="5" align="right">
            <asp:Label ID="lblsecondheading" CssClass="labelhtdata" Width="200px" runat="server" Text=""></asp:Label></td>
            <td Width="30px">
                </td>  
            <td Width="20px"></td>            
        </tr>
        <tr>
            <td style="width:100%" colspan="11">
                <div id="tblinserts" class='labelht' runat="server">
                    <table border="0" cellpadding="0" cellspacing ="0">
                        <tr>
                            <td style="width: 80px" colspan="2"></td>
                            <td style="width: 50px"></td>
                            <td style="width: 80px"></td>
                            <td style="width: 80px"></td>
                            <td style="width: 25px"></td>
                            <td style="width: 25px"></td>
                            <td style="width: 25px"></td>
                            <td style="width: 25px"></td>  
                            <td style="width: 150px"></td>
                        </tr>
                    </table>
                </div>
            </td>            
        </tr>
          <%-- <tr>
            <td colspan="4" style="height: 38px;"></td>
            <td colspan ="4" style="height: 38px; width:250px" align="right">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td><asp:Label ID="lblcomm" CssClass="labelht" runat="server" Width="300px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblboxchrg" CssClass="labelht" runat="server" Width="300px"></asp:Label></td>
                    </tr>
                </table>
            </td>
            <td style="width: 25px; height: 38px;"></td>  
            <td style="width: 150px; height: 38px;" align="right">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right"><asp:Label ID="lblcommv" CssClass="labelht" runat="server" Text="" Width="141px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lblboxchrgv" CssClass="labelht" runat="server" Text="0.00" Width="139px"></asp:Label></td>
                    </tr>
                </table>
            </td>            
        </tr>--%>
        <%-- <tr>
            <td colspan ="4"></td>
            <td colspan ="6" align="right">----------------------------------------------------------</td>
         </tr>--%>
            
         
          <tr align="right">
            <td colspan ="2"></td><td>&nbsp;</td><td></td>
         
                        <td colspan ="5" style="padding-left:200px;width:150px" align="right"><asp:Label ID="lblboxchrg" CssClass="labelhtdata" runat="server" Width="100px"></asp:Label></td>
                   
         
                        <td align="right" style="padding-right:35px">&nbsp;<asp:Label ID="lblboxchrgv" CssClass="labelht" runat="server" Text="0.00"></asp:Label></td>
                    </tr>
        <tr>
            <td colspan ="3">
                <asp:Label ID="Label31" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label33" runat="server" Text=""></asp:Label></td>
            <td colspan ="7"></td>
        </tr>
         <tr>
            <td colspan ="2"></td><td>&nbsp;</td><td></td>
            <td colspan ="5" style="padding-left:200px;width:150px" align="right"><asp:Label ID="lblamtpaid" CssClass="labelhtdata" runat="server" Text="Label" Width="100px"></asp:Label></td>
            <td align="right" style="padding-right:35px">&nbsp;<asp:Label ID="lblamt" CssClass="labelhtdata" runat="server" Text="Label"></asp:Label></td>
         </tr>
          <tr>
            <td colspan ="10" style="height: 19px" class="labelhtdata" align="center">
                <asp:Label ID="lblmatter" runat="server" Text="Label"></asp:Label></td>
          </tr>
           <tr>
            <td colspan="9">
                <div id="divmatter" class="labelht" runat="server">
                    <table width="100%" border="1">
                        <tr>
                            <td style='width:50px'></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width:50px"></td>
                            <td></td>
                        </tr>
                    </table>
                </div>
            </td>            
        </tr>
        <%-- <tr>
            <td colspan ="10"><hr /></td>
        </tr>--%>
    </table>
  <%--  <table cellpadding ="0" cellspacing ="0" width ="500px" >
        <tr>
            <td colspan ="2"></td>
        </tr>
        <tr>
            <td style ="width :60px"></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan ="2"><hr /></td>
        </tr>
    </table>--%>
    
    <table cellpadding ="13" cellspacing ="0" width="350px" style ="margin-top :45px;display:none">
        <tr>
            <td colspan ="3"  align ="center">             
                <asp:Label ID="lblheadingdown" runat="server" Text="" Width="283px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width :300px;padding-left:82px" align ="left" >
                <asp:Label ID="Label17" runat="server" Text="" Width="222px"></asp:Label>
            </td>
            <td style="width :125px;padding-left:30px" align ="left">
                <asp:Label ID="lblRDatedown" CssClass="labelht" Width="125px" runat="server"></asp:Label>
            </td>
            <td style="width :50px" align ="left">
                <asp:Label ID="lblRDatevdown" CssClass="labelht" runat="server"></asp:Label>
           </td>
        </tr>
          <tr>
            <td style="width :300px;padding-left:82px" align ="left" valign="top">
                <table>
                    <tr>
                        <td><asp:Label ID="lblclientnamedown" CssClass="labelht" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblclientadddown" CssClass="labelht" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
            </td>
            <td align ="left" valign="top">
                <table>
                    <tr>
                        <td><asp:Label ID="lbldetypedown" CssClass="labelht" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblcatdown" CssClass="labelht" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblcatnamedown" CssClass="labelht" runat="server"></asp:Label></td>
                    </tr>
                    
                </table>
            </td>
            <td align ="left" valign="top">
                <table>
                    <tr>
                        <td><asp:Label ID="lbldetypevdown" CssClass="labelht" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblcatvdown" CssClass="labelht" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblcatnamevdown" CssClass="labelht" runat="server" ></asp:Label></td>
                    </tr>
                    
                </table>
             </td>
        </tr>
         <tr>
            <td style="width :350px" align ="center" >
                
            </td>
            <td style="width :125px">
               &nbsp;
            </td>
            <td style="width :125px">
               &nbsp;
           </td>
        </tr>
    </table>
    
    <table cellpadding ="0" cellspacing ="0" width ="700px" style ="margin-top :20px;display:none">
         <tr>
            <td colspan ="2"></td>
             <td style="width: 150px">
                <asp:Label ID="Label28" runat="server" Text="" Width="126px"></asp:Label></td>
            <td colspan ="5"></td>
            <td style="width: 25px">
                <asp:Label ID="Label29" runat="server" Text=""></asp:Label></td>  
            <td style="width: 150px"></td>            
        </tr>
         <tr>
            <td colspan ="10"></td>
        </tr>
        <tr>
            <td style="width: 50px"></td>
            <td colspan ="6"></td>
            <td colspan ="3"></td>
               
        </tr>
     </table>
    </div>
    <input id="hiddenbookid" type="hidden" name="hiddenid" runat="server" />
    </form>
</body>
</html>
