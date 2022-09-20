<%@ Control Language="C#" AutoEventWireup="true" CodeFile="billing_package_supp.ascx.cs" Inherits="billing_package_supp" %>

<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />


<div id="showtable" runat ="server" style="position:absolute;top:0px;left:0px;border:none;display:block;z-index:0;">

<table border ="0" width ="850px" align="left" >
<%--<tr><td style="width: 846px"><asp:Button ID="btnprint" runat="server"  Text="Print" OnClick="btnprint_Click" /></td></tr>--%>
<tr align = "left" >
<td align ="left" style="width: 846px; height: 1029px;" >
 <table   width="650px" cellspacing="0" cellpadding="0"    <%--style="left: 100px; position: absolute;"--%> >
 <tr> 
 <tr><td  valign ="top"  align ="center" colspan="2" >
     <img src="Images/EML.jpg" height ="60px" width ="70px" /><span><%--<hr />--%></span>
     
 </td>
 
 </tr>
 
 <tr><td  align="CENTER" class ="newhead1" colspan ="2"><label id="Label5"  runat ="server">EASTERN MEDIA LIMITED<div><hr /></div></label> </td>

 </tr>
<%-- <tr>
<td  align="left"class ="newhead1"><label id="lbreg"  runat ="server">Regd.Off.:</label> </td> 
<td align ="left"  class="newhead"><asp:Label ID="lbheadoffice"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
 
 </tr>--%>
<tr  > 
<td class ="newhead1" align ="left"><label id="prahaar"  runat ="server">Sambad:</label></td>
<td align ="left" class="newhead"><asp:Label ID="lbhead2" runat ="server" CssClass="extrasizeclass" ></asp:Label><asp:Label ID="Label4" runat ="server" class ="newhead2" >  Ph.</asp:Label><asp:Label ID="Label1" runat ="server"  CssClass="agecnycodeclass1" ></asp:Label><asp:Label ID="Label2" runat ="server" class ="newhead2">  Fax:</asp:Label><asp:Label ID="Label3" runat ="server" CssClass="extrasizeclass"></asp:Label></td>
</tr>
<tr>
<td class ="newhead1" align ="left"><label id="Label15"  runat ="server">Email:</label>
</td>
<td class ="newhead2" align ="left"><asp:Label id="Label16"  runat ="server"></asp:Label></td>
</tr>
 <tr   >
 <%--<td    colspan ="2" align ="center" ><asp:Label ID="Label4" runat ="server" class ="newhead1" >Tel No.:</asp:Label><asp:Label ID="Label1" runat ="server"  CssClass="agecnycodeclass1" ></asp:Label><asp:Label ID="Label2" runat ="server" class ="newhead1">  Fax No.:</asp:Label><asp:Label ID="Label3" runat ="server" CssClass="extrasizeclass"></asp:Label></td>--%>
  

   
 </tr>
           <tr >		    
		    <td style="height:19px" colspan ="4" align ="center" class="newhead1" ><asp:Label ID="heading" runat ="server" >INVOICE</asp:Label></td>
		   </tr>	
	</tr> 
	</table>
	
	
	
	
											
											
											
  	






<table border="1"  cellspacing="0" cellpadding="0"   class="table1"  width ="650px"  <%--style="left: 100px; position: absolute; top: 118px; width :675px"--%>  >
       <tr>
                <td rowspan="11" colspan="2" style ="width :250px" align ="left" valign ="top" >
                <div id="div11" runat ="server" style ="auto:overflow;">
                <table>
                <tr><td style="width: 75px"> <asp:Label CssClass="agecnycodeclass" ID="lbto" runat ="server"></asp:Label></td></tr>
                <tr><td style="width: 75px"> <asp:Label CssClass="agecnycodeclass" ID="agencytxt" runat ="server"></asp:Label></td></tr>
                <tr> <td style="width: 75px"><asp:Label CssClass="agecnycodeclass" ID="agddxt" runat ="server"></asp:Label></td></tr>
                <tr><td style="width: 75px">----------</td></tr>
                <tr> <td style="width: 75px"><asp:Label CssClass="agecnycodeclass" ID="lbclientna" runat ="server"></asp:Label></td></tr>
                <tr> <td style="width: 75px"><asp:Label CssClass="agecnycodeclass" ID="lbclientadd" runat ="server"></asp:Label></td></tr>
                 <tr><td style="width: 75px"> <asp:Label CssClass="agecnycodeclass" ID="citytxt" runat ="server"></asp:Label></td></tr>
                </table>
                </div> 
                </td>
               
                <%--<td colspan="4" align ="center" >
                
                                      <asp:Label CssClass="agecnycodeclass" ID="lblwhile" runat ="server"></asp:Label>             
                </td>--%>
               
       </tr>
       <tr align ="left">
               
                <%--<td align="left">
                                     <asp:Label CssClass="agecnycodeclass" ID="lbagecnycode" runat ="server"></asp:Label>
                                       
                </td>--%>
                <td align="left" colspan ="1" >
                                      <asp:Label CssClass="invoicenoclass" ID="lbinvoiceno" runat ="server"></asp:Label>
                 </td>
                 <td align="left" colspan ="3" >
                    
                                      <asp:Label CssClass="agecnycodeclass" ID="txtinvoice" runat ="server"></asp:Label>
                  </td>
                 
                        </tr>
                        <tr>
                 <td align="left">
                                      <asp:Label CssClass="dateclass" ID="lbdate" runat ="server"></asp:Label>
                 </td>
                 
                   <td style="height: 19px" align ="left" colspan ="3" >
                                      <asp:Label CssClass="invoicenoclass" ID="runtxt" runat ="server"></asp:Label> 
                  </td>
                 </tr>
              

       <tr>
                
                  <%--<td style="height: 19px">
                                      <asp:Label CssClass="agencycod1class" ID="agencycod" runat ="server"></asp:Label>
                  </td>--%>
                  <%--<td >
                    
                                      <asp:Label CssClass="invoicenoclass" ID="txtinvoice" runat ="server"></asp:Label>
                  </td>--%>
                
       </tr>
       <tr>
                 <td valign="top"  align ="left" style="height: 18px" >
    
                        <asp:Label CssClass="typeclass" ID="lbtype" runat ="server"></asp:Label>
                 </td>
                 <td colspan ="3" valign="top" align ="left" style="height: 18px" >
                        <asp:Label CssClass="standardclass" ID="lbstandard" runat ="server"></asp:Label>
                 </td>
        </tr>
        <tr>
                <td valign="top" style="height: 18px"  align ="left">
                       <asp:Label CssClass="adtypeclass" ID="lbadtype" runat ="server"></asp:Label>
                </td>
                <td colspan ="3" style="height: 18px" align ="left" >
                       <asp:Label CssClass="invoicenoclass" ID="adcat" runat ="server"></asp:Label>
                </td>
        </tr>
         <tr>
                <td valign="top" style="height: 18px"  align ="left">
                       <asp:Label CssClass="adtypeclass" ID="lbpub" runat ="server"></asp:Label>
                </td>
                <td colspan ="3" style="height: 18px" align ="left" >
                       <asp:Label CssClass="invoicenoclass" ID="pubtxt" runat ="server"></asp:Label>
                </td>
        </tr>
        <%--<tr>
               <tr>
                <td valign="top" align ="left" style="width: 115px">
                      <asp:Label CssClass="packageclass" ID="lbgroup" runat ="server">Group</asp:Label>
                </td>
                <td colspan ="2" align ="left" style="width: 224px">
                      <asp:Label CssClass="invoicenoclass" ID="txtgroup" runat ="server"></asp:Label>
                </td>
        </tr>
       </tr>--%>
       
          <tr>
                <td valign="top" align ="left">
                      <asp:Label CssClass="packageclass" ID="lbpackagena" runat ="server"></asp:Label>
                </td>
                <td colspan ="3" align ="left">
                      <asp:Label CssClass="invoicenoclass" ID="txtpackname" runat ="server"></asp:Label>
                </td>
        </tr>
        
        
        
        <tr>
                <td valign="top" align ="left" >
                      <asp:Label CssClass="packageclass" ID="lbgroup" runat ="server">Group</asp:Label>
                </td>
                <td colspan ="3" align ="left">
                      <asp:Label CssClass="invoicenoclass" ID="txtgroup" runat ="server"></asp:Label>
                </td>
        </tr>
        
   
        <tr>
                <td valign="top" align ="left">
                      <asp:Label CssClass="schemeclass" ID="lbscheme" runat ="server"></asp:Label>
                </td>
                <td colspan ="3" align ="left">
                 <table style=" border-top-style:solid"> 
                
                      <asp:Label CssClass="scheme11class" ID="scheme" runat ="server"></asp:Label></table> 
                </td>
       </tr>
       <tr>
                <td valign="top" align ="left" >
                      <asp:Label CssClass="packageclass" ID="lbpanno" runat ="server"></asp:Label>
                </td>
                
                
                <td colspan ="3" align ="left" >
                
                      <asp:Label CssClass="packagetclass" ID="txtpan" Text="AAACE7323H" runat ="server"></asp:Label> 
                </td>
        </tr>
        <tr>
                <td valign="top" align ="left" style=" border-top-style:solid" colspan ="2">
                      <asp:Label CssClass="packageclass" ID="lbproductkey" runat ="server"></asp:Label>
                </td>
                <td  align ="left" colspan ="3">
                      <asp:Label CssClass="invoicenoclass" ID="txtproduct" runat ="server"></asp:Label>
                </td>
        </tr>
         
       <tr style=" border-top-width:thin; border-top-color:Gray ; border-top-style:solid">
               
                 <td valign="top" align ="left"  colspan ="2">
                              <asp:Label CssClass="numberclass" ID="lbnumber" runat ="server"></asp:Label>
                 </td>
                 <td  align ="left" >
                            
                                  <asp:Label CssClass="invoicenoclass" ID="rono" runat ="server"></asp:Label>  
                 </td>
                 <td  valign="top" align ="left" >
                             <asp:Label CssClass="formatproposalclass" ID="lbformatproposal" runat ="server"></asp:Label>
                  </td>
                  <td  colspan="1" align ="left" >
                            
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
        <tr>
                        <td valign="top"  align ="left" style="height: 18px" colspan ="2">
                                  <asp:Label CssClass="ordernumberclass" ID="lbordernumber" runat ="server"></asp:Label>
                        </td>
                        <td align ="left" style="height: 18px">
                                   <asp:Label CssClass="invoicenoclass" ID="orderno" runat ="server"></asp:Label>
                        </td>
                        <td valign="top" style="height: 18px" >
                                  <asp:Label CssClass="insertionnumberclass" ID="lbinsertionnumber" runat ="server"></asp:Label>
                        </td >
                        <td  align ="left" style="height: 18px">
                                  <asp:Label CssClass="invoicenoclass" ID="insertiontxt" runat ="server"></asp:Label>
                        </td>
                  
         </tr>
       
       
      
       
       
       
        
       

       
</table>

	
   

<br />
<table border="1"  cellspacing="0" cellpadding="0"    width ="650px"  <%--style="left: 100px; position: absolute; top: 330px;width :675px"--%> class="table1" >
              
                       <tr align ="center">
                       
                                             <td  style=" height: 40px; width :60px;"  valign ="top" >
                                                              <asp:Label CssClass="weidthclass" ID="lbinsdt" runat ="server"></asp:Label>
                                             </td>
                                             
                                             <%--<td   style=" height: 40px; width :60px;"  valign ="top">
                                                              <asp:Label CssClass="weidthclass" ID="lbedi" runat ="server"></asp:Label>
                                             </td>--%>
                                             <td   valign ="top" style=" height: 40px; width :60px;">
                                                              <asp:Label CssClass="weidthclass" ID="lbweidth" runat ="server"></asp:Label>
                                             </td>
                                             <td  valign ="top" style=" height: 40px; width :60px;">
                                                               <asp:Label CssClass="weidthclass" ID="lbheight" runat ="server"></asp:Label>
                                             </td>
                                             <td valign ="top" style=" height: 40px; width :60px;">
                                                               <asp:Label CssClass="weidthclass" ID="lbvolume" runat ="server"></asp:Label>
                                             </td>
                                            
                                             <td  valign ="top" style=" height: 40px; width :60px;"> 
                                                                <asp:Label  CssClass="weidthclass" ID="lbcolor" runat ="server"></asp:Label>
                                             </td>
                                             
                                              <td valign ="top" style=" height: 40px; width :60px;">
                                                                   <asp:Label CssClass="weidthclass" ID="lbpageno" runat ="server"></asp:Label>
                                             </td>
                                            
                                             <td valign ="top" style=" height: 40px; width :60px;">
                                                                 <asp:Label CssClass="weidthclass"  ID="lbextracharges" runat ="server"></asp:Label>
                                             </td>
                                            <td valign="top" style=" height: 40px; width :60px;" > <asp:Label CssClass="weidthclass" ID="lbposition" runat ="server"></asp:Label>
                                            
                                            
                                            
                                            
                                            </td>
                                            
                                            
                                             <td valign ="top" style=" height: 40px; width:50px;"> 
                                                                 <asp:Label CssClass="weidthclass" ID="lbpackagerate" runat ="server"></asp:Label>
                                             </td>
                                             
                                             <td valign ="top" style=" height: 40px;width:50px;"> 
                                                                 <asp:Label CssClass="weidthclass" ID="lbpack" runat ="server"></asp:Label>
                                             </td>                      
                            
                            
                            
                            
                            
                            
                            
                            
                            
                                            
                         </tr>
                         
                     
               
                       <tr >
                       
                       
                      
                        
                         
                        
                         
                         
                       <td valign="top" align="left" colspan="8"   id="tabledy" runat ="server" style="height: 300px">
                                      <asp:Label ID="dynamictable" runat="server" CssClass ="amtxtclass" ></asp:Label>                       
                                    
                                     
                                     
                        
                                           </td>   
                                           
                                           
                                             <td valign ="top"  colspan ="2" style="height: 300px" > 
                
                
                <div >
                <table  width ="100%" cellpadding ="0" cellspacing ="0"  border ="1" >
               
                                             
                                                                 
                  
                   
                                                      <tr   >
                                              <td  valign ="top" align ="left"   <%--style ="width:50%;border-right:solid 1px black;border-bottom :solid 1px black;"--%> >
                                                                <asp:Label  ID="lblamount" runat ="server"  CssClass="amtxtclass"></asp:Label>
                                              </td>
                                              <td align ="left" >
                                               <asp:Label   ID="amount1" runat ="server"  CssClass="amtxtclass"></asp:Label>
                                              </td>
                                              
                                              
                   </tr>
                   <tr>
                   
                   <td  valign ="top" align ="left"  >
                                                                <asp:Label  CssClass="amtxtclass" ID="lbpremium" runat ="server"></asp:Label>
                                              </td>
                                              <td align ="left"  >
                                               <asp:Label  CssClass="amtxtclass" ID="txtprem" runat ="server"></asp:Label>
                                              </td>
                   
                   </tr>
                   
                   
                   <tr>
                   
                    <td align ="left"  >
                                                                <asp:Label  CssClass="amtxtclass" ID="lbextrach" runat ="server"></asp:Label>
                                             </td>
                                             <td align ="left"  >
                                                                <asp:Label  CssClass="amtxtclass" ID="txch" runat ="server"></asp:Label>
                                             </td>
                   
                   </tr>
                   <tr>
                                              <td  valign ="top" align ="left"  >  
                                                               <asp:Label CssClass="trade1class" ID="lbltrade" runat ="server"></asp:Label>
                                              </td>
                                              <td  >
                                               <asp:Label CssClass="amtxtclass" ID="amtdisc" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                    <tr>
                                              <td  valign ="top" align ="left"  >  
                                                               <asp:Label CssClass="trade1class" ID="lbgr" runat ="server"></asp:Label>
                                              </td>
                                              <td   >
                                               <asp:Label CssClass="amtxtclass" ID="txtgr" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                    <tr>
                                              <td  valign ="top" align ="left"    >  
                                                               <asp:Label CssClass="trade1class" ID="lbtdper" runat ="server"></asp:Label>
                                              </td>
                                              <td   >
                                               <asp:Label CssClass="amtxtclass" ID="txtper" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                    <tr>
                                              <td  valign ="top" align ="left"    >  
                                                               <asp:Label CssClass="trade1class" ID="lbtrade1" runat ="server"></asp:Label>
                                              </td>
                                              <td >
                                               <asp:Label CssClass="amtxtclass" ID="txtdiscal" runat ="server"></asp:Label>
                                              </td>
                   </tr>
               
                   <tr>
                                              <td valign ="top"  align ="left"   >
                                                                <asp:Label CssClass="box1class" ID="lblbox" runat ="server"></asp:Label>
                                                              
                                              </td>
                                              <td  >
                                                  <asp:Label CssClass="net1class" ID="boxcharges1" runat ="server"></asp:Label> 
                                              </td>
                   </tr>
                       <tr>
                                              <td valign ="top"  align ="left"  >
                                                               <asp:Label CssClass="total1class" ID="lbltotal" runat ="server" ></asp:Label>
                                                              
                                              </td>
                                              <td  >
                                               <asp:Label CssClass="total1class" ID="txttotal" runat ="server" ></asp:Label>
                                              </td>
                   </tr>
                   
                   
                      <tr>
                                              <td valign ="top"  align ="left"   >
                                                               <asp:Label CssClass="total1class" ID="lbvat" runat ="server" ></asp:Label>
                                                              
                                              </td>
                                              <td style="height: 18px" >
                                               <asp:Label CssClass="amtxtclass" ID="lblamt" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                   
                  
                    <tr>
                                              <td valign ="top"  align ="left" >
                                                               <asp:Label CssClass="total1class" ID="lbeduca" runat ="server" ></asp:Label>
                                                              
                                              </td>
                                              <td style="height: 18px">
                                               <asp:Label CssClass="amtxtclass" ID="lbled" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                   
                     <tr>
                                              <td valign ="top" align ="left"  >
                                                               <asp:Label CssClass="total1class" ID="lbservice" runat ="server" ></asp:Label>
                                                              
                                              </td>
                                              <td style="height: 18px" >
                                              <asp:Label CssClass="total1class" ID="lblser" runat ="server" ></asp:Label>
                                              </td>
                   </tr>
                   <tr>
                                              <td valign ="top"  align ="left"  >
                                                                 <asp:Label CssClass="net1class" ID="lblnet" runat ="server" ></asp:Label> 
                                              </td>
                                              <td >
                                              <asp:Label CssClass="total1class" ID="netacc" runat ="server" ></asp:Label> 
                                             
                                              </td>
                  </tr>
                   <tr>
                                              <td valign ="top"  align ="left" style="height: 20px"   >
                                                                <asp:Label CssClass="netpayable1class" ID="lblnetpayable" runat ="server" ></asp:Label> 
                                              </td>
                                              <td style="height: 20px" >
                                               <asp:Label CssClass="total1class1" ID="netpay" runat ="server"  ></asp:Label> 
                                              </td>
                 </tr>
                         
                                             </table>
                                             </div>
                                             
                                             </td>    
                                          
                                           
                                                                
                                       
                                           
                                           
                                             
                                            
                                            
                                          
                                           
                                             
                         </tr>
                           <tr>   
                  <td colspan ="3" style="height: 10px"><asp:Label CssClass="amount1class" ID="lbrupee" runat ="server"></asp:Label></td>
                  <td colspan ="8" style="height: 10px"><asp:Label CssClass="amount1class" ID="rupeetxt" runat ="server"></asp:Label></td>
                  
                  
                  </tr> 
                              <tr >
                               
                                            <td colspan="3" style="height: 10px"><asp:Label CssClass="amount1class" ID="remark" runat ="server"></asp:Label></td>
                                            <td colspan ="8" style="height: 10px"><asp:Label CssClass="amount1class" ID="Label17" runat ="server"></asp:Label></td>
                               </tr> 
                
                                        
                        
               
      </table>      
      <table  border="1"  cellspacing="0" cellpadding="0"    width ="650px" class ="table1"  >
      <tr>
      <td align="left"> <asp:Label  ID="Label6" runat ="server" CssClass="newhead1" >Terms & Conditions</asp:Label><br />
      <asp:Label  ID="Label8" runat ="server"  CssClass="netpayable1class">1)Payments should be  made by through A/C Payee Bank Draft favouring  "EASTERN MEDIA LIMITED" Payable at: BHUBANESWAR/ANGUL/BERHAMPUR/BALASORE/KATAK/JAYAPUR/ROURKELA/SAMBALPUR.</asp:Label><br />
      <asp:Label  ID="Label12" runat ="server"  CssClass="netpayable1class">2)Payments must be accompanied with Bill No. and Date.</asp:Label><br />
      <asp:Label  ID="Label9" runat ="server" CssClass="netpayable1class" >3)All correspondence and complaints regarding advertisements should be addressed to Manager Advertisement, along with the Bill No. and Date within 15 days or reciept of the bill. </asp:Label><br/>
      <asp:Label  ID="Label10" runat ="server"  CssClass="netpayable1class"></asp:Label>
      </td>
      <td valign ="top" style="width: 123px" ><asp:Label  ID="Label7" runat ="server" CssClass="newhead1">FOR EASTERN MEDIA LIMITED</asp:Label><br /><br /><br /><br />
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
<td align ="left"  class="newhead" style="font-family: Verdana"><asp:Label ID="Label14"   runat ="server" CssClass="extrasizeclass"></asp:Label>sambadbbsr@easternmedia.in</td>
 </tr>
      </table>
      </td> 
      </tr> 
      </div> 

