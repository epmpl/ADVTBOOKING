<%@ Control Language="C#" AutoEventWireup="true" CodeFile="prhaarre.ascx.cs" Inherits="prhaarre" %>

<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<table class ="break" >
<tr>
<td>



                <table   width="640px" cellspacing="0" cellpadding="0"  border ="1" >
                 <tr > <td align ="center" colspan="2"><asp:Label ID="pagestatus" runat ="server"   CssClass="billstatusnew" ></asp:Label></td></tr>
 <tr style ="height :104px;">
 <td  valign ="middle"  align ="center" colspan="2" >
     <img  src="Images/Prahaar.jpg" height ="70px" width ="150px" />
     
 </td>
 
 </tr>
 
 <tr><td  align="CENTER" class ="newhead1" colspan ="2"><label id="Label5"  runat ="server">RANE PRAKASHAN PVT.LTD.<div><hr /></div></label> </td>
 

 </tr>
 <tr>
 
<td  align="left"class ="newhead1"><label id="lbreg"  runat ="server">Regd.Off.:</label> </td> 
<td align ="left"  class="newhead"><asp:Label ID="lbheadoffice"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
 
 
 </tr>
<tr > 
<td class ="newhead1" align ="left"><label id="prahaar"  runat ="server">Prahaar:</label></td>
<td align ="left" class="newhead"><asp:Label ID="lbhead2" runat ="server" CssClass="extrasizeclass" ></asp:Label></td>
</tr>
 <tr >
 <td    colspan ="2" align ="center" ><asp:Label ID="Label4" runat ="server" class ="newhead1" >Tel No.:</asp:Label><asp:Label ID="Label1" runat ="server"  CssClass="agecnycodeclass" ></asp:Label><asp:Label ID="Label6" runat ="server" Text="   "  CssClass="agecnycodeclass" ></asp:Label><asp:Label ID="Label2" runat ="server" class ="newhead1">Fax No.:</asp:Label><asp:Label ID="Label3" runat ="server" CssClass="extrasizeclass"></asp:Label></td>
  

   
 </tr>
           <tr >		    
		    <td style="height:19px" colspan ="4" align ="center" class="newhead1" ><asp:Label ID="heading" runat ="server" >INVOICE</asp:Label></td>
		   </tr>	

	</table>
	
	
	
	
											
											
											
  	






<table border="1"  cellspacing="0" cellpadding="0"   class="table1"   style="width: 640px; height: 243px"  >
       <tr>
                <td rowspan="11" colspan="2" style ="width :350px" align ="left" valign ="top" >
                <table>
                <tr><td> <asp:Label CssClass="agecnycodeclass" ID="lbto" runat ="server"></asp:Label></td></tr>
              <tr><td> <asp:Label CssClass="agecnycodeclass" ID="agencytxt" runat ="server"></asp:Label></td></tr>
                <tr> <td><asp:Label CssClass="agecnycodeclass" ID="agddxt" runat ="server"></asp:Label></td></tr>
               
                <tr>
                
                <td>               
                <hr style="width:350px" />
                <table border="0"  cellspacing="0" cellpadding="0" >
                <tr>
                <td>    
                  <asp:Label CssClass="agecnycodeclass" ID="lbclientna" runat ="server"></asp:Label>              
                  </td>
                </tr>
                <tr> <td style="height: 12px"><asp:Label CssClass="agecnycodeclass" ID="lbclientadd" runat ="server"></asp:Label></td></tr>
                 <tr><td> <asp:Label CssClass="agecnycodeclass" ID="citytxt" runat ="server"></asp:Label></td></tr>
                </table>
                </td>
                </tr>
                
                </table>
                </td>
               
                <td colspan="3" align ="center" >
                
                                      <asp:Label CssClass="agecnycodeclass" ID="lblwhile" runat ="server"></asp:Label>             
                </td>
               
       </tr>
       <tr align ="left">
               
                <%--<td align="left">
                                     <asp:Label CssClass="agecnycodeclass" ID="lbagecnycode" runat ="server"></asp:Label>
                                       
                </td>--%>
                <td align="left" style="width: 115px">
                                      <asp:Label CssClass="invoicenoclass" ID="lbinvoiceno" runat ="server"></asp:Label>
                 </td>
                 
                       <td style="width: 115px" >
                    
                                      <asp:Label CssClass="invoicenoclass" ID="txtinvoice" runat ="server"></asp:Label>
                  </td>
                        </tr>
                        <tr>
                 <td align="left" style="width: 115px">
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
            
                
       </tr>
       <tr>
                 <td valign="top"  align ="left" style="height: 18px; width: 115px;" >
    
                        <asp:Label CssClass="typeclass" ID="lbtype" runat ="server"></asp:Label>
                 </td>
                 <td colspan ="2" valign="top" align ="left" style="height: 18px; width: 224px;" >
                        <asp:Label CssClass="standardclass" ID="lbstandard" runat ="server"></asp:Label>
                 </td>
        </tr>
        <tr>
                <td valign="top" style="height: 18px; width: 115px;"  align ="left">
                       <asp:Label CssClass="adtypeclass" ID="lbadtype" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" style="height: 18px; width: 224px;" align ="left" >
                       <asp:Label CssClass="invoicenoclass" ID="adcat" runat ="server"></asp:Label>
                </td>
        </tr>
         <tr>
                <td valign="top" style="height: 18px; width: 115px;"  align ="left">
                       <asp:Label CssClass="adtypeclass" ID="lbpub" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" style="height: 18px; width: 224px;" align ="left" >
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
       
          <tr>
                <td valign="top" align ="left" style="width: 115px">
                      <asp:Label CssClass="packageclass" ID="lbpackagena" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" align ="left" style="width: 224px">
                      <asp:Label CssClass="invoicenoclass" ID="txtpackname" runat ="server"></asp:Label>
                </td>
        </tr>
         <tr>
                <td valign="top" align ="left" style="width: 115px">
                      <asp:Label CssClass="packageclass" ID="lbgroup" runat ="server">Group</asp:Label>
                </td>
                <td colspan ="2" align ="left" style="width: 224px">
                      <asp:Label CssClass="invoicenoclass" ID="txtgroup" runat ="server"></asp:Label>
                </td>
        </tr>
   
        <tr>
                <td valign="top" align ="left" style="width: 115px">
                      <asp:Label CssClass="schemeclass" ID="lbscheme" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" align ="left" style="width: 224px">
               
                
                      <asp:Label CssClass="scheme11class" ID="scheme" runat ="server"></asp:Label>
                </td>
       </tr>
       <tr>
                <td valign="top" align ="left" style="width: 115px; height: 6px" >
                      <asp:Label CssClass="packageclass" ID="lbpanno" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" align ="left" style=" border-top-style:solid ; height: 6px; width: 224px;">
                <table > 
                      <asp:Label CssClass="invoicenoclass" ID="txtpan" runat ="server"></asp:Label></table> 
                </td>
        </tr>
        <tr>
                <td valign="top" align ="left" style=" border-top-style:solid">
                      <asp:Label CssClass="packageclass" ID="lbproductkey" runat ="server"></asp:Label>
                </td>
                <td colspan ="2" align ="left">
                      <asp:Label CssClass="invoicenoclass" ID="txtproduct" runat ="server"></asp:Label>
                </td>
        </tr>
         
       <tr style=" border-top-width:thin; border-top-color:Gray ; border-top-style:solid">
               
                 <td style ="width :110px;" valign="top" align ="left" >
                              <asp:Label CssClass="numberclass" ID="lbnumber" runat ="server"></asp:Label>
                 </td>
                 <td style ="width :215px;" align ="left">
                            
                                  <asp:Label CssClass="invoicenoclass" ID="rono" runat ="server"></asp:Label>  
                 </td>
                 <td style ="width :115px;" valign="top" align ="left" >
                             <asp:Label CssClass="formatproposalclass" ID="lbformatproposal" runat ="server"></asp:Label>
                  </td>
                  <td style="width :224px;" colspan="2" align ="left" >
                           <table style=" border-top-style:solid">  
                             <asp:Label  CssClass="formatclass" ID="format" runat ="server"></asp:Label></table> 
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
                        <td valign="top"  align ="left" style="height: 18px">
                                  <asp:Label CssClass="ordernumberclass" ID="lbordernumber" runat ="server"></asp:Label>
                        </td>
                        <td align ="left" style="height: 18px">
                                   <asp:Label CssClass="invoicenoclass" ID="orderno" runat ="server"></asp:Label>
                        </td>
                        <td valign="top" style="height: 18px; width: 115px;" >
                                  <asp:Label CssClass="insertionnumberclass" ID="lbinsertionnumber" runat ="server"></asp:Label>
                        </td >
                        <td colspan="2" align ="left" style="height: 18px; width: 224px;">
                                  <asp:Label CssClass="invoicenoclass" ID="insertiontxt" runat ="server"></asp:Label>
                        </td>
                  
         </tr>
       
       
      
       
       
       
        
       

       
</table>
	
   


<table style="width: 640px; border-left:solid 1px black " cellspacing="0" cellpadding="0" >
<tr>
<td valign ="top " <%--style="width: 413px"--%> style="height: 324px" >

<table style="vertical-align :top ;width: 500px; border-bottom:0;"cellspacing="0" cellpadding="0" border="1"    <%--style="left: 100px; position: absolute; top: 330px;width :675px"--%> class="table1" >
              
                    <%--<tr>
                       
                                            <td  style=" height: 20px; width:87px"  valign ="top"  >
                                                              <asp:Label CssClass="weidthclass" ID="lbinsdt" runat ="server"></asp:Label>
                                             </td>
                                             
                                             <td   style=" height: 20px; width:77px" valign ="top">
                                                              <asp:Label CssClass="weidthclass" ID="lbedi" runat ="server"></asp:Label>
                                             </td>
                                             <td   valign ="top" style=" height: 20px; width:36px">
                                                              <asp:Label CssClass="weidthclass" ID="lbweidth" runat ="server"></asp:Label>
                                             </td>
                                             <td  valign ="top" style=" height: 20px; width:37px">
                                                               <asp:Label CssClass="weidthclass" ID="lbheight" runat ="server"></asp:Label>
                                             </td>
                                             <td valign ="top" style=" height: 20px;width:48px">
                                                               <asp:Label CssClass="volumeclass" ID="lbvolume" runat ="server"></asp:Label>
                                             </td>
                                            
                                             <td  valign ="top" style=" height:20px;width:39px"> 
                                                                <asp:Label  CssClass="colorclass" ID="lbcolor" runat ="server"></asp:Label>
                                             </td>
                                             
                                              <td valign ="top" style=" height: 20px;width:55px">
                                                                   <asp:Label CssClass="amountclass" ID="lbpageno" runat ="server"></asp:Label>
                                             </td>
                                            
                                             <td valign ="top" style=" height: 20px;width:78px">
                                                                 <asp:Label CssClass="extrachargesclass"  ID="lbextracharges" runat ="server"></asp:Label>
                                             </td>
                                            <td valign="top" style=" height: 40px;border-bottom:solid 1px black" > <asp:Label CssClass="positionclass" ID="lbposition" runat ="server"></asp:Label>
                                            
                                                                                      
                                            
                                            </td></tr>--%>
                                            <tr>
                                            <td valign="top" align="left" colspan="9"   id="dynamictable" runat ="server" style ="border-bottom :0px" >
                                      
                                    
                                     
                                     
                        
                                           </td>
    </tr> 
   
   
   
   
    </table>
    </td>
    <td  valign ="top" style="height: 324px" ><table cellpadding ="0" cellspacing ="0"  border =""  class="table1" >
               
                                             
                                                          <tr>
                                                          <td valign ="top"   style=" height: 40px;"> 
                                                                 <asp:Label CssClass="packagerateclass" ID="lbpackagerate" runat ="server"></asp:Label>
                                             </td>
                                             
                                             <td valign ="top"  align="right" style=" height: 40px;"> 
                                                                 <asp:Label CssClass="packagerateclass" ID="lbpack" runat ="server"></asp:Label>
                                             </td>                      
                            </tr>
                  
                   
                                                      <tr>
                                              <td  valign ="top" align ="left"   <%--style ="width:50%;border-right:solid 1px black;border-bottom :solid 1px black;"--%>>
                                                                <asp:Label  ID="lblamount" runat ="server"  CssClass="weidthclass"></asp:Label>
                                              </td>
                                              <td align ="right"  >
                                               <asp:Label   ID="amount1" runat ="server"  CssClass="weidthclass"></asp:Label>
                                              </td>
                                              
                                              
                   </tr>
                   <tr>
                   
                   <td  valign ="top" align ="left"  >
                                                                <asp:Label  CssClass="amtxtclass" ID="lbpremium" runat ="server"></asp:Label>
                                              </td>
                                              <td align="right"   >
                                               <asp:Label  CssClass="amtxtclass" ID="txtprem" runat ="server"></asp:Label>
                                              </td>
                   
                   </tr>
                   
                   
                   <tr>
                   
                    <td align ="left"   >
                                                                <asp:Label  CssClass="amtxtclass" ID="lbextrach" runat ="server"></asp:Label>
                                             </td>
                                             <td align="right">
                                                                <asp:Label  CssClass="amtxtclass" ID="txch" runat ="server"></asp:Label>
                                             </td>
                   
                   </tr>
                   <tr>
                                              <td  valign ="top" align ="left"  >  
                                                               <asp:Label CssClass="trade1class" ID="lbltrade" runat ="server"></asp:Label>
                                              </td>
                                              <td style="width: 92px" align="right" >
                                               <asp:Label CssClass="amtxtclass" ID="amtdisc" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                    <tr>
                                              <td  valign ="top" align ="left" >  
                                                               <asp:Label CssClass="trade1class" ID="lbgr" runat ="server"></asp:Label>
                                              </td>
                                              <td style="width: 92px" align="right"  >
                                               <asp:Label CssClass="amtxtclass" ID="txtgr" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                    <tr>
                                              <td  valign ="top" align ="left"     >  
                                                               <asp:Label CssClass="trade1class" ID="lbtdper" runat ="server"></asp:Label>
                                              </td>
                                              <td style="width: 92px"  align="right" >
                                               <asp:Label CssClass="amtxtclass" ID="txtper" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                    <tr>
                                              <td  valign ="top" align ="left"   >  
                                                               <asp:Label CssClass="trade1class" ID="lbtrade1" runat ="server"></asp:Label>
                                              </td>
                                              <td style="width: 92px" align="right" >
                                               <asp:Label CssClass="amtxtclass" ID="txtdiscal" runat ="server"></asp:Label>
                                              </td>
                   </tr>
               
                   <tr>
                                              <td valign ="top"  align ="left" style="width: 70px"   >
                                                                <asp:Label CssClass="box1class" ID="lblbox" runat ="server"></asp:Label>
                                                              
                                              </td>
                                              <td style="width: 92px" align="right" >
                                                  <asp:Label CssClass="net1class" ID="boxcharges1" runat ="server"></asp:Label> 
                                              </td>
                   </tr>
                       <tr>
                                              <td valign ="top"  align ="left"  >
                                                               <asp:Label CssClass="total1class" ID="lbltotal" runat ="server" ></asp:Label>
                                                              
                                              </td>
                                              <td style="height: 20px; width: 92px;" align="right" >
                                               <asp:Label CssClass="total1class" ID="txttotal" runat ="server" ></asp:Label>
                                              </td>
                   </tr>
                   
                   
                      <tr>
                                              <td valign ="top"  align ="left"    >
                                                               <asp:Label CssClass="total1class" ID="lbvat" runat ="server" ></asp:Label>
                                                              
                                              </td>
                                              <td style="height: 21px; width: 92px;"  align="right" >
                                               <asp:Label CssClass="amtxtclass" ID="lblamt" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                   
                  
                    <tr>
                                              <td valign ="top"  align ="left"  >
                                                               <asp:Label CssClass="total1class" ID="lbeduca" runat ="server" ></asp:Label>
                                                              
                                              </td>
                                              <td style="height: 18px; " align="right" >
                                               <asp:Label CssClass="amtxtclass" ID="lbled" runat ="server"></asp:Label>
                                              </td>
                   </tr>
                   
                     <tr>
                                              <td valign ="top" align ="left"   >
                                                               <asp:Label CssClass="total1class" ID="lbservice" runat ="server" ></asp:Label>
                                                              
                                              </td>
                                              <td style="height: 18px; width: 92px;" align="right" >
                                              <asp:Label CssClass="total1class" ID="lblser" runat ="server" ></asp:Label>
                                              </td>
                   </tr>
                   <tr>
                                              <td valign ="top"  align ="left"   >
                                                                 <asp:Label CssClass="net1class" ID="lblnet" runat ="server" ></asp:Label> 
                                              </td>
                                              <td style="width: 92px"  align="right">
                                              <asp:Label CssClass="total1class" ID="netacc" runat ="server" ></asp:Label> 
                                             
                                              </td>
                  </tr>
                   <tr>
                                              <td valign ="top"  align ="left"    >
                                                                <asp:Label CssClass="netpayable1class" ID="lblnetpayable" runat ="server" ></asp:Label> 
                                              </td>
                                              <td style="width: 92px; height: 24px;" align="right" >
                                               <asp:Label CssClass="total1class" ID="netpay" runat ="server"  ></asp:Label> 
                                              </td>
                 </tr>
                         
                                             </table>
                
                                            </td>
                                                                                      
                         </tr>
                         
                    </table> 
               <table border="" cellpadding ="0" cellspacing ="0" style="width: 640px" class ="table1">
               <tr>
                                                     
                                                                
                     <td width="20%"><asp:Label CssClass="amount1class" ID="lbrupee" runat ="server"></asp:Label></td>
                  <td width="80%"   ><asp:Label CssClass="amount1class" ID="rupeetxt" runat ="server"></asp:Label></td>
                  
                  </tr>
                
                               <tr >
                               
                                            <td colspan="11"><asp:Label CssClass="netpayable1class" ID="remark" runat ="server"></asp:Label></td>
                       
                               </tr>
                                        
                                     
                                           
                                             
                                            
                                            
                                          
                                           
                                             
                         
                         </table>
                           
      <table  border="1"  cellspacing="0" cellpadding="0" class ="table1" style="width: 640px;"  >
      <tr>
      <td align="left" valign="top" > <asp:Label  ID="Label7" runat ="server" CssClass="newhead1" >Terms & Conditions</asp:Label><br />
      <asp:Label  ID="Label8" runat ="server"  CssClass="netpayable1class">1)Remittance should be  made by crossed Cheques/Draft in favour of "Rane Prakashan Pvt.Ltd." Payable</asp:Label><br />
      <asp:Label  ID="Label9" runat ="server" CssClass="netpayable1class" >2)All Payment should be made according to the credit  limits to avoid  interest,Which will be levied @18% per annum </asp:Label><br/>
      <asp:Label  ID="Label10" runat ="server"  CssClass="netpayable1class"></asp:Label>
      
      
      </td>
      <td valign ="top" ><asp:Label  ID="Label11" runat ="server" CssClass="newhead1">FOR RANE PRAKASHAN PVT.LTD</asp:Label><br /><br /><br />
      <asp:Label  ID="Label12" runat ="server" CssClass="newhead1" >(Billing Officer)</asp:Label>
      
      
      </td>
      
      </tr>
      
      </table>
    

</td>
</tr>
</table>


