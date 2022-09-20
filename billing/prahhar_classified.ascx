<%@ Control Language="C#" AutoEventWireup="true" CodeFile="prahhar_classified.ascx.cs" Inherits="prahhar_classified" %>
<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />
<div id="showtable" runat ="server" style="position:absolute;top:0px;left:0px;border:none;display:block;z-index:0;">

<head>
<title>OrderwiseBilling
</title>

</head>
<table border ="0" width ="850px" align="left" >
<tr align = "left" >
<td align ="left" >
 <table   width="650px" cellspacing="0" cellpadding="0"    >
 <tr> 
 <tr><td  valign ="top"  align ="center" colspan="2" style ="border :solid 1px black;" >
     <img src="Images/Prahaar.jpg" height ="50px" width ="130px" /><span></span>
     
 </td>
 
 </tr>
 
 <tr ><td style="border :solid 1px black" align="CENTER" class ="newhead1" colspan ="2"><label id="Label5"     runat ="server">RANE PRAKASHAN PVT.LTD.<div></div></label> </td>
 

 </tr>
 <tr >
 
 

<td    align="left"class ="newhead1"><label id="lbreg"  runat ="server">Regd.Off.:</label> </td> 
<td style="border-right:solid 1px black" align ="left"  class="newhead"><asp:Label ID="lbheadoffice"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
 
 </tr>
<tr  > 
<td style="border-left:solid 1px black" class ="newhead1" align ="left"><label id="prahaar"  runat ="server">Prahhar:</label></td>
<td style="border-right:solid 1px black" align ="left" class="newhead"><asp:Label ID="lbhead2" runat ="server" CssClass="extrasizeclass" ></asp:Label></td>
</tr>
 <tr   >
 <td   style="border-left:solid 1px black;border-right:solid 1px black" colspan ="2" align ="center" ><asp:Label ID="Label4" runat ="server" class ="newhead1" >Tel No.:</asp:Label><asp:Label ID="Label1" runat ="server"  CssClass="agecnycodeclass" >40969999/</asp:Label><asp:Label ID="Label2" runat ="server" class ="newhead1">Fax No.:</asp:Label><asp:Label ID="Label3" runat ="server" CssClass="extrasizeclass">40969900</asp:Label></td>
  

   
 </tr>
           <tr >		    
		    <td style="border-left:solid 1px black;border-right:solid 1px black; height:19px" colspan ="4" align ="center" class="newhead1" ><asp:Label ID="heading" runat ="server" >INVOICE</asp:Label></td>
		   </tr>	
	</tr> 
	</table>
	
	
	
	
											
											
											
  	






<table border="1"  cellspacing="0" cellpadding="0"   class="table1"  width ="650px"  <%--style="left: 100px; position: absolute; top: 118px; width :675px"--%>  >
       <tr>
                <td rowspan="9" colspan="2" style ="width :350px" align ="left" valign ="top" >
                <table>
                <tr><td> <asp:Label CssClass="agecnycodeclass" ID="lbto" runat ="server"></asp:Label></td></tr>
                <tr><td> <asp:Label CssClass="agecnycodeclass" ID="agencytxt" runat ="server"></asp:Label></td></tr>
                <tr> <td><asp:Label CssClass="agecnycodeclass" ID="agddxt" runat ="server"></asp:Label></td></tr>
                <tr> <td><asp:Label CssClass="agecnycodeclass" ID="lbclientna" runat ="server"></asp:Label></td></tr>
                <tr> <td><asp:Label CssClass="agecnycodeclass" ID="lbclientadd" runat ="server"></asp:Label></td></tr>
                 <tr><td> <asp:Label CssClass="agecnycodeclass" ID="citytxt" runat ="server"></asp:Label></td></tr>
                </table>
                </td>
               
                <td colspan="3" align ="center" >
                
                                      <asp:Label CssClass="agecnycodeclass" ID="lblwhile" runat ="server"></asp:Label>             
                </td>
               
       </tr>
       <tr align ="left">
               
               
                <td align="left">
                                      <asp:Label CssClass="invoicenoclass" ID="lbinvoiceno" runat ="server"></asp:Label>
                 </td>
                 
                                 <td align="left">
                                      <asp:Label CssClass="invoicenoclass" ID="txtinvoice" runat ="server"></asp:Label>
                 </td>
                 </tr>
                 <tr>
                 <td align="left">
                                      <asp:Label CssClass="dateclass" ID="lbdate" runat ="server"></asp:Label>
                 </td>
                 
                  <td style="height: 19px" align ="left" >
                                      <asp:Label CssClass="invoicenoclass" ID="runtxt" runat ="server"></asp:Label> 
                  </td>
                 </tr>
              
       
       <tr>
                
                  <%--<td style="height: 19px">
                                      <asp:Label CssClass="agencycod1class" ID="agencycod" runat ="server"></asp:Label>
                  </td>--%>
                  <td >
                    
                                      <asp:Label CssClass="invoicenoclass" ID="txtinvoice1" runat ="server"></asp:Label>
                  </td>
                 
       </tr>
       <tr>
                 <td valign="top"  align ="left" style="height: 18px" >
    
                        <asp:Label CssClass="typeclass" ID="lbtype" runat ="server"></asp:Label>
                 </td>
                 <td colspan ="2" valign="top" align ="left" style="height: 18px" >
                        <asp:Label CssClass="standardclass" ID="lbstandard" runat ="server"></asp:Label>
                 </td>
        </tr>
        <tr>
                <td valign="top" style="height: 18px"  align ="left">
                       <asp:Label CssClass="adtypeclass" ID="lbadtype" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" style="height: 18px" align ="left" >
                       <asp:Label CssClass="invoicenoclass" ID="adcat" runat ="server"></asp:Label>
                </td>
        </tr>
         <tr>
                <td valign="top" style="height: 18px"  align ="left">
                       <asp:Label CssClass="adtypeclass" ID="lbpub" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" style="height: 18px" align ="left" >
                       <asp:Label CssClass="invoicenoclass" ID="pubtxt" runat ="server"></asp:Label>
                </td>
        </tr>
        <%--<tr>
                <td valign="top"  align ="left">
                      <asp:Label CssClass="positionclass" ID="lbposition" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" align ="left" >
                      <asp:Label CssClass="position11class" ID="position" runat ="server"></asp:Label>
                </td>
       </tr>--%>
       
         <%-- <tr>
                <td valign="top" align ="left">
                      <asp:Label CssClass="packageclass" ID="lbpackagena" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" align ="left">
                      <asp:Label CssClass="invoicenoclass" ID="txtpackname" runat ="server"></asp:Label>
                </td>
        </tr>--%>
   
        <tr>
                <td valign="top" align ="left">
                      <asp:Label CssClass="schemeclass" ID="lbscheme" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" align ="left">
                 <table style=" border-top-style:solid"> 
                
                      <asp:Label CssClass="scheme11class" ID="scheme" runat ="server"></asp:Label></table> 
                </td>
       </tr>
       <tr>
                <td valign="top" align ="left" >
                      <asp:Label CssClass="packageclass" ID="lbpanno" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" align ="left" style=" border-top-style:solid ; ">
               
                      <asp:Label CssClass="packageclass" ID="txtpan" runat ="server"></asp:Label>
                </td>
        </tr>
         <tr>
                <td valign="top" align ="left" style=" border-top-style:solid" colspan ="2">
                      <asp:Label CssClass="packageclass" ID="lbproductkey" runat ="server"></asp:Label>
                </td>
                <td colspan ="3" align ="left">
                      <asp:Label CssClass="invoicenoclass" ID="txtproduct" runat ="server"></asp:Label>
                </td>
        </tr>
         
       <tr style=" border-top-width:thin; border-top-color:Gray ; border-top-style:solid">
               
                <%-- <td style ="width :110px;" valign="top" align ="left" >
                              <asp:Label CssClass="numberclass" ID="lbnumber" runat ="server"></asp:Label>
                 </td>--%>
                 <%--<td style ="width :215px;" align ="left">
                            
                                  <asp:Label CssClass="invoicenoclass" ID="rono" runat ="server"></asp:Label>  
                 </td>--%>
                  <td style ="width :115px;" valign="top" align ="left" colspan ="2" >
                             <asp:Label CssClass="formatproposalclass" ID="lbformatproposal" runat ="server"></asp:Label>
                  </td>
                  <td style ="width :222px;" colspan="3" align ="left" >
                             
                             <asp:Label  CssClass="formatproposalclass" ID="format" runat ="server"></asp:Label>
                  </td>
        </tr>
    
        <%--<tr>
                        <td valign="top" align ="left" >
                                 <asp:Label CssClass="numberclass" ID="lbnumber" runat ="server"></asp:Label>
                        </td>
                        <td colspan ="4" align ="left">
                                  <asp:Label CssClass="ronoclass" ID="rono" runat ="server"></asp:Label>
                        </td>
        </tr>--%>
       
       
       
      
       
       
       
        
       

       
</table>
	
   




 <%--<table border="1"  cellspacing="0" cellpadding="0"    width ="650px"  class="table1" >
              
                   <tr align ="center">
                       
                          <td  style=" height: 40px; width: 66px; "  valign ="top" >
                                                              <asp:Label CssClass="weidthclass" ID="lbinsdt" runat ="server"></asp:Label>
                                             </td>
                                             
                                               <td  style=" height: 40px; width:50px;"  valign ="top" >
                                                              <asp:Label CssClass="weidthclass" ID="lbinsno" runat ="server"></asp:Label>
                                             </td>
                       <td  style=" height: 40px; width:45px;"  valign ="top" >
                                                              <asp:Label CssClass="weidthclass" ID="lblrono" runat ="server"></asp:Label>
                                             </td>
                       
                                          
                                             
                                             <td   style=" height: 40px; width:50px;"  valign ="top">
                                                              <asp:Label CssClass="weidthclass" ID="lbedi" runat ="server"></asp:Label>
                                             </td>
                                             <td   valign ="top" style=" height: 40px; width:40px;">
                                                              <asp:Label CssClass="weidthclass" ID="lbweidth" runat ="server"></asp:Label>
                                             </td>
                                             <td  valign ="top" style=" height: 40px; width:50px;">
                                                               <asp:Label CssClass="volumeclass" ID="lbheight" runat ="server"></asp:Label>
                                             </td>
                                             <td valign ="top" style=" height: 40px; width:50px;">
                                                               <asp:Label CssClass="volumeclass" ID="lbvolume" runat ="server"></asp:Label>
                                             </td>
                                            
                                             <td  valign ="top" style=" height: 40px;width:60px; "> 
                                                                <asp:Label  CssClass="colorclass" ID="lbcolor" runat ="server"></asp:Label>
                                             </td>
                                             
                                              <td valign ="top" style=" height: 40px; width:40px;">
                                                                   <asp:Label CssClass="amountclass" ID="lbpageno" runat ="server"></asp:Label>
                                             </td>
                                            
                                             <td valign ="top" style=" height: 40px;width:50px; ">
                                                                 <asp:Label CssClass="extrachargesclass"  ID="lbnoofcolumns" runat ="server"></asp:Label>
                                             </td>
                                            <td valign="top" style=" height: 40px; width:50px;" > <asp:Label CssClass="positionclass" ID="lbra" runat ="server"></asp:Label>
                                            
                                            
                                            
                                            
                                            </td>
                                            
                                            
                                             <td valign ="top" style=" height: 40px;width:50px; "> 
                                                                 <asp:Label CssClass="packagerateclass" ID="lbper" runat ="server"></asp:Label>
                                             </td>
                                             
                                             <td valign ="top" style=" height: 40px; width:50px;"> 
                                                                 <asp:Label CssClass="packagerateclass" ID="lbAmount" runat ="server"></asp:Label>
                                             </td>                      
                                                                   
                         </tr>--%>
   
   
   <table border="1"  cellspacing="0" cellpadding="0"    width ="646px"  <%--style="left: 100px; position: absolute; top: 330px;width :675px"--%> class="table1" >
                    <tr >
                            <td valign="top"    align="left" colspan="8"   id="tabledy" runat ="server" style ="width :650px;height :300px;" >
                            <asp:Label ID="dynamictable" runat="server" CssClass ="amtxtclass"  style ="width :650px;"></asp:Label>                       
                            </td>   
                       </tr>
                       
                       
                      <tr>
                         <td style="width:480px; font-weight:bold;"  ><asp:Label CssClass="amount1class" ID="lbgross" runat ="server"></asp:Label></td>
                         <td style="width:170px" ><asp:Label CssClass="amount1class" ID="txtgross" runat ="server"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width:480px; font-weight:bold;"  ><asp:Label CssClass="amount1class" ID="lbcomm" runat ="server"></asp:Label></td>
                         <td ><asp:Label CssClass="amount1class" ID="txtcomm" runat ="server"></asp:Label></td>
                     </tr>
                        
                     <tr>
                        <td style=" width:480px; font-weight:bold;"><asp:Label CssClass="amount1class" ID="lbgr" runat ="server"></asp:Label></td>
                         <td ><asp:Label CssClass="amount1class" ID="txtgr" runat ="server"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style=" width:480px; font-weight:bold;"><asp:Label CssClass="amount1class" ID="lbbox" runat ="server"></asp:Label></td>
                         <td ><asp:Label CssClass="amount1class" ID="txbox" runat ="server"></asp:Label></td>
                     </tr>
                         
                     <tr>
                                               <td style="font-weight:bold;"> <asp:Label CssClass="amount1class" ID="lbcharge" runat ="server">Chargable Amount</asp:Label></td>

                         <td ><asp:Label CssClass="amount1class" ID="finalamt" runat ="server"></asp:Label></td>
                     </tr>
               </table>      
       
      
       
      <table  border="1"  cellspacing="0" cellpadding="0"    width ="650px" class ="table1"  >
      <tr>
      <td align="left" style=" width:480px"> <asp:Label  ID="Label6" runat ="server" CssClass="newhead1" >Terms & Conditions</asp:Label><br />
      <asp:Label  ID="Label8" runat ="server"  CssClass="netpayable1class">1)Remittance should be  made by crossed Cheques/Draft in favour of "Rane Prakashan Pvt.Ltd." Payable at Mumbai</asp:Label><br />
      <asp:Label  ID="Label9" runat ="server" CssClass="netpayable1class" >2)All Payment should be made according to the credit  limits to avoid  interest,Which will be levied @18% per annum </asp:Label><BR/>
      <asp:Label  ID="Label10" runat ="server"  CssClass="netpayable1class"></asp:Label>
      
      
      </td>
      <td valign ="top" style=" width:170px" ><asp:Label  ID="Label7" runat ="server" CssClass="newhead1">FOR RANE PRAKASHAN PVT.LTD</asp:Label><br /><br /><br /><br />
      <asp:Label  ID="Label11" runat ="server" CssClass="newhead1" >(Billing Officer)</asp:Label>
      
      
      </td>
      
      </tr>
      
      </table>
      </td> 
      </tr> 
      </table>
      </div> 

