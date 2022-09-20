<%@ Control Language="C#" AutoEventWireup="true" CodeFile="samab_cls_supp.ascx.cs" Inherits="samab_cls_supp" %>

<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<head>
<title>OrderwiseBilling
</title>

</head>

<div id="showtable" runat ="server" style="position:absolute;top:0px;left:0px;border:none;display:block;z-index:0;">

<table border ="0" width ="630px" align="left" >
<tr><td><asp:Button ID="btnprint" runat="server"  Text="Print" /></td></tr>
<tr align = "left" >
<td align ="left" >
 <table   width="630px" cellspacing="0" cellpadding="0"    <%--style="left: 100px; position: absolute;"--%> >
 <tr> 
 <tr><td  valign ="top"  align ="center" colspan="2" >
     <img src="Images/EML.jpg" height ="60px" width ="70px" /><span><hr /></span>
     
 </td>
 
 </tr>
 
 <tr><td  align="CENTER" class ="newhead1" colspan ="2"><label id="Label5"  runat ="server">EASTERN MEDIA LIMITED<div><hr /></div></label> </td>
 

 </tr>
 
<tr  > 
<td class ="newhead1" align ="left"><label id="prahaar"  runat ="server">Sambad:</label></td>
<td align ="left" class="newhead"><asp:Label ID="lbhead2" runat ="server" CssClass="extrasizeclass" ></asp:Label><asp:Label ID="Label4" runat ="server" class ="newhead2" >  Ph.</asp:Label><asp:Label ID="Label1" runat ="server"  CssClass="agecnycodeclass1" ></asp:Label><asp:Label ID="Label2" runat ="server" class ="newhead2">  Fax:</asp:Label><asp:Label ID="Label3" runat ="server" CssClass="extrasizeclass"></asp:Label></td>
</tr>
<tr>
<td class ="newhead1" align ="left"><label id="Label15"  runat ="server">Email:</label>
</td>
<td class ="newhead2" align ="left"><asp:Label id="Label16"  runat ="server"></asp:Label></td>
</tr>
           <tr >		    
		    <td style="height:19px" colspan ="4" align ="center" class="newhead1" ><asp:Label ID="heading" runat ="server" >INVOICE</asp:Label></td>
		   </tr>	
	</tr> 
	</table>
	
	
	
	
											
											
											
  	






<table border="1"  cellspacing="0" cellpadding="0"   class="table1"  width ="630px"  <%--style="left: 100px; position: absolute; top: 118px; width :675px"--%>  >
       <tr>
                <td rowspan="9" colspan="2" style ="width :350px" align ="left" valign ="top" >
                <table>
                <tr><td> <asp:Label CssClass="agecnycodeclass" ID="lbto" runat ="server"></asp:Label></td></tr>
                <tr><td> <asp:Label CssClass="agecnycodeclass" ID="agencytxt" runat ="server"></asp:Label></td></tr>
                <tr> <td><asp:Label CssClass="agecnycodeclass" ID="agddxt" runat ="server"></asp:Label></td></tr>
                
                
                 <tr><td style="width: 75px">----------</td></tr>
                <tr> <td><asp:Label CssClass="agecnycodeclass" ID="lbclientna" runat ="server"></asp:Label></td></tr>
                <tr> <td><asp:Label CssClass="agecnycodeclass" ID="lbclientadd" runat ="server"></asp:Label></td></tr>
                 <tr><td> <asp:Label CssClass="agecnycodeclass" ID="citytxt" runat ="server"></asp:Label></td></tr>
                </table>
                </td>
               
               <%-- <td colspan="3" align ="center" >
                
                                      <asp:Label CssClass="agecnycodeclass" ID="lblwhile" runat ="server"></asp:Label>             
                </td>--%>
               
       </tr>
       <tr align ="left">
               
                <%--<td align="left">
                                     <asp:Label CssClass="agecnycodeclass" ID="lbagecnycode" runat ="server"></asp:Label>
                                       
                </td>--%>
                <td align="left">
                                      <asp:Label CssClass="invoicenoclass" ID="lbinvoiceno" runat ="server"></asp:Label>
                 </td>
                 
                                 <td align="left">
                                      <asp:Label CssClass="invoicenoclass111" ID="txtinvoice" runat ="server"></asp:Label>
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
               <td colspan ="3" align ="left" >
                
                      <asp:Label CssClass="invoicenoclass" ID="txtpan" Text="AAACE7323H" runat ="server"></asp:Label> 
                </td>
        </tr>
        <tr>
                <td valign="top" align ="left" style=" border-top-style:solid">
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
                 <td  >
                             <asp:Label CssClass="formatproposalclass" ID="lbformatproposal" runat ="server"></asp:Label>
                             
                  </td>
                  <td   >
                             <asp:Label CssClass="formatproposalclass" ID="txtformat" runat ="server"></asp:Label>
                             
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
	
   

<br />
<table border="1"  cellspacing="0" cellpadding="0"    width ="630px"  <%--style="left: 100px; position: absolute; top: 330px;width :675px"--%> class="table1" >
              
                      
                     
               
                       <tr >
                       
                       
                      
                        
                         
                        
                         
                         
                       <td valign="top" align="left" colspan="13"   id="tabledy" runat ="server"   >
                                      <asp:Label ID="dynamictable" runat="server" CssClass ="amtxtclass"    ></asp:Label>                       
                                    
                                     
                                     
                        
                                           </td>   
                                           
                                           
                                            
                                           
                                                                
                                       
                                           
                                           
                                             
                                            
                                            
                                          
                                           
                                             
                         </tr>
                         <tr>
                            <td colspan ="10" style="height: 10px"><asp:Label CssClass="amount1class" ID="lbgr" runat ="server"></asp:Label></td>

                         <td colspan ="3" style="height: 10px;"><asp:Label CssClass="amount1class" ID="txtgross" runat ="server"></asp:Label></td>
                         </tr>
                         <tr>
                       <td colspan ="10"><asp:Label CssClass="amount1class" ID="lbcomm" runat ="server"></asp:Label></td>
                         <td colspan ="3"><asp:Label CssClass="amount1class" ID="txtcomm" runat ="server"></asp:Label></td>
                         </tr>
                           <tr>
                        <td colspan ="10"><asp:Label CssClass="amount1class" ID="lbbox" runat ="server"></asp:Label></td>
                         <td colspan ="3"><asp:Label CssClass="amount1class" ID="txbox" runat ="server"></asp:Label></td>
                         </tr>
                         
                          <tr>
                                                   <td colspan ="10"><asp:Label CssClass="amount1class" ID="lbgross" runat ="server"></asp:Label></td>
                     
                         <td colspan ="3"><asp:Label CssClass="invoicenoclass111" ID="txtgr" runat ="server"></asp:Label></td>
                         </tr>
                       
                         
                         <tr>
                       
                            <td colspan ="3" style="height: 10px"><asp:Label CssClass="amount1class" ID="lbrupee" runat ="server"></asp:Label></td>
                 
                  
                         <td colspan ="10" style="height: 10px"><asp:Label CssClass="amount1class" ID="finalamt" runat ="server"></asp:Label></td>
                         
                         
                         </tr>
                         
                         <tr >
                               
                                            <td colspan="3" style="height: 10px"><asp:Label CssClass="amount1class" ID="remark" runat ="server"></asp:Label></td>
                                            <td colspan ="10" style="height: 10px"><asp:Label CssClass="amount1class" ID="Label17" runat ="server"></asp:Label></td>
                               </tr> 
                   <%--        <tr>   
                  <td colspan ="4"><asp:Label CssClass="amount1class" ID="lbrupee" runat ="server"></asp:Label></td>
                  <td colspan ="9"><asp:Label CssClass="amount1class" ID="rupeetxt" runat ="server"></asp:Label></td>
                  
                  
                  </tr> 
                               <tr >
                               
                                            <td colspan="13"><asp:Label CssClass="netpayable1class" ID="remark" runat ="server"></asp:Label></td>
                               </tr>  --%>
                
                                        
                        
               
      </table>      
      <table  border="1"  cellspacing="0" cellpadding="0"    width ="630px" class ="table1"  >
      <tr>
       <td align="left" valign ="top" > <asp:Label  ID="Label6" runat ="server" CssClass="newhead1" >Terms & Conditions</asp:Label><br />
      <asp:Label  ID="Label8" runat ="server"  CssClass="netpayable1class">1)Payments should be  made by through A/C Payee Bank Draft favouring  "EASTERN MEDIA LIMITED" Payable at: BHUBANESWAR/ANGUL/BERHAMPUR/BALASORE/KATAK/JAYAPUR/ROURKELA/SAMBALPUR.</asp:Label><br />
      <asp:Label  ID="Label12" runat ="server"  CssClass="netpayable1class">2)Payments must be accompanied with Bill No. and Date.</asp:Label><br />
      <asp:Label  ID="Label9" runat ="server" CssClass="netpayable1class" >3)All correspondence and complaints regarding advertisements should be addressed to Manager Advertisement, along with the Bill No. and Date within 15 days or reciept of the bill. </asp:Label><BR/>
      <asp:Label  ID="Label10" runat ="server"  CssClass="netpayable1class">4) All disputes are subject to BHUBANESWAR jurisdiction</asp:Label>
      
      
      </td>
      <td valign ="top" ><asp:Label  ID="Label7" runat ="server" CssClass="newhead1">FOR EASTERN MEDIA LIMITED</asp:Label><br /><br /><br /><br />
      <asp:Label  ID="Label11" runat ="server" CssClass="newhead1" >(AUTHORISED SIGNATORY)</asp:Label>
      
      
      </td>
      
      </tr>
      
      </table>
      <table>
       <tr>
 
 
 

<td  align="left"class ="newhead1"><label id="lbreg"  runat ="server">Regd.Off.:</label> </td> 
<td align ="left"  class="newhead"><asp:Label ID="lbheadoffice"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
 
 </tr>
 <tr>
 <td  align="left"class ="newhead1"><label id="Label13" runat ="server">Email:</label> </td> 
<td align ="left"  class="newhead"><asp:Label ID="Label14"   runat ="server" CssClass="extrasizeclass"></asp:Label>sambadbbsr@easternmedia.in</td>
 </tr>
      </table>
      
      
      </td> 
      </tr> 
      </div> 

