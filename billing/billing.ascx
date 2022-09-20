<%@ Control Language="C#" AutoEventWireup="true" CodeFile="billing.ascx.cs" Inherits="billing" %>
<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />
 <table   width="850px" class="table" cellspacing="0" cellpadding="0" >
 <tr align="center"><td><asp:Label ID="Label2" runat ="server" CssClass="heading"></asp:Label></td></tr>
 <tr align="center"><td><asp:Label ID="Label3" runat ="server" CssClass="heading"></asp:Label></td></tr>
 <tr align="center"><td><asp:Label ID="Label4" runat ="server" CssClass="heading"></asp:Label></td></tr>
           <tr align="center">
		    
		    <td <%--style ="border-color:Black ;border-width: thin; --%>">
		    	<asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label>
		    </td>
		   </tr>
	</table>
											
											
											
    <table   cellspacing="0" cellpadding="0"     class="table1" border="1" style="width:700px;height :120px; border-left-color: black; border-bottom-color: black; border-top-style: solid; border-top-color: black; border-right-style: solid; border-left-style: solid; border-right-color: black; border-bottom-style: solid; left: 100px; position: absolute; top: 100px;"   >
      <tr border="1">
          <td style ="width :350px">
                  <asp:Label ID="agencytxt" runat ="server"></asp:Label>
          </td>
          <td>
               <table  border="1"  >
                     <tr  border="1"  valign ="top" align ="center" >
                           <td colspan ="3" style ="width :350px"  border="1"  >
                                   <asp:Label CssClass="while1class" ID="lblwhile" runat ="server"></asp:Label>
                           </td>
                    </tr>
                    <tr   align ="center" >
                           <td  border="1" >
                                  <asp:Label CssClass="agecnycodeclass" ID="lbagecnycode" runat ="server"></asp:Label>
    
                           </td>
                           <td  border="1" >
                                 <asp:Label CssClass="invoicenoclass" ID="lbinvoiceno" runat ="server"></asp:Label>
                           </td>
                          <td  border="1">
                                  <asp:Label CssClass="dateclass" ID="lbdate" runat ="server"></asp:Label>
                          </td>
                    </tr>
                   <tr  border="1" >
                          <td style="height: 19px">
                                  <asp:Label CssClass="agencycod1class" ID="agencycod" runat ="server"></asp:Label>
                          </td>
                         <td style="width: 4px" >
                                  <asp:Label CssClass="invoiceclass" ID="invoice" runat ="server"></asp:Label>
                         </td>
                         <td style="height: 19px">
                                  <asp:Label CssClass="Label1class" ID="Label1" runat ="server"></asp:Label> 
                        </td>
                 </tr>
                 <tr border="1">
                  <td valign="top"  >
    
                        <asp:Label CssClass="typeclass" ID="lbtype" runat ="server"></asp:Label>
                 </td>
                 <td colspan ="2" valign="top">
                        <asp:Label CssClass="standardclass" ID="lbstandard" runat ="server"></asp:Label>
                 </td>
           </tr>
           <tr>
                <td valign="top">
                       <asp:Label CssClass="adtypeclass" ID="lbadtype" runat ="server"></asp:Label>
                </td>
                <td colspan ="2">
                       <asp:Label CssClass="adcatclass" ID="adcat" runat ="server"></asp:Label>
                </td>
           </tr>
           <tr>
                <td valign="top">
                      <asp:Label CssClass="positionclass" ID="lbposition" runat ="server"></asp:Label>
                </td>
                <td colspan ="2">
                      <asp:Label CssClass="position11class" ID="position" runat ="server"></asp:Label>
                </td>
           </tr>
           <tr>
                <td valign="top">
                      <asp:Label CssClass="packageclass" ID="lbpackage" runat ="server"></asp:Label>
                </td>
                <td colspan ="2">
                      <asp:Label CssClass="packagetclass" ID="packaget" runat ="server"></asp:Label>
                </td>
           </tr>
           <tr>
                <td valign="top">
                      <asp:Label CssClass="schemeclass" ID="lbscheme" runat ="server"></asp:Label>
                </td>
                <td colspan ="2">
                      <asp:Label CssClass="scheme11class" ID="scheme" runat ="server"></asp:Label>
                </td>
          </tr>
         
    
    
       </table>
    </td>
    
    
    
    </tr>
    <tr style ="width:700px;"><td colspan="4">
           <table   border="1" >
                 <tr >
                      <td style ="width :125px;" valign="top" >
                              <asp:Label CssClass="avertiserclass" ID="lbavertiser" runat ="server"></asp:Label>
                      </td>
                      <td style ="width :225px;">
                              <asp:Label CssClass="advertsr11class" ID="advertsr" runat ="server"></asp:Label> 
                      </td>
                      <td style ="width :125px;" valign="top" >
                             <asp:Label CssClass="formatproposalclass" ID="lbformatproposal" runat ="server"></asp:Label>
                       </td>
                       <td style ="width :225px;">
                             <asp:Label  CssClass="formatclass" ID="format" runat ="server"></asp:Label>
                       </td>
                  </tr>
    
                  <tr>
                        <td valign="top" >
                                 <asp:Label CssClass="numberclass" ID="lbnumber" runat ="server"></asp:Label>
                        </td>
                        <td colspan ="3">
                                  <asp:Label CssClass="ronoclass" ID="rono" runat ="server"></asp:Label>
                        </td>
                   </tr>
                   <tr>
                        <td valign="top" >
                                  <asp:Label CssClass="ordernumberclass" ID="lbordernumber" runat ="server"></asp:Label>
                        </td>
                        <td>
                                   <asp:Label CssClass="ordernoclass" ID="orderno" runat ="server"></asp:Label>
                        </td>
                        <td valign="top" >
                                  <asp:Label CssClass="insertionnumberclass" ID="lbinsertionnumber" runat ="server"></asp:Label>
                        </td>
                        <td>
                                  <asp:Label CssClass="insertiontxtclass" ID="insertiontxt" runat ="server"></asp:Label>
                        </td>
                    </tr>
          </table>
    
    
       </td>
    
    
    </tr>
 
    
</table>
								
	
   
 <table  border="1" cellspacing="0" cellpadding="0"   style="left: 100px; position: absolute; top: 350px;" class="table2" valign="top">
         <tr align ="center" >
                  <td>

                         <table style ="width:700px;height :100px"  border="1" valign="top" >
                                   <tr align ="center">
                                             <td  style ="height :40px;width:58px;"  valign ="top" >
                                                              <asp:Label CssClass="weidthclass" ID="lbweidth" runat ="server"></asp:Label>
                                             </td>
                                             <td style ="height :40px;width:58px;" valign ="top">
                                                               <asp:Label CssClass="heightclass" ID="lbheight" runat ="server"></asp:Label>
                                             </td>
                                             <td style ="height :40px;width:58px;" valign ="top">
                                                               <asp:Label CssClass="volumeclass" ID="lbvolume" runat ="server"></asp:Label>
                                             </td>
                                             <td style ="height :40px;width:58px;" valign ="top">
                                                                <asp:Label  CssClass="extrasizeclass" ID="lbextrasize" runat ="server"></asp:Label>
                                             </td>
                                             <td style ="height :40px;width:58px;" valign ="top"> 
                                                                <asp:Label  CssClass="colorclass" ID="lbcolor" runat ="server"></asp:Label>
                                             </td>
                                             <td style ="height :40px;width:58px;" valign ="top"> 
                                                                 <asp:Label CssClass="packagerateclass" ID="lbpackagerate" runat ="server"></asp:Label>
                                             </td>
                                             <td style ="height :40px;width:116px;" valign ="top">
                                                                 <asp:Label CssClass="extrachargesclass"  ID="lbextracharges" runat ="server"></asp:Label>
                                             </td>
                                             <td style ="height :40px;width:116px;" valign ="top">
                                                                  <asp:Label CssClass="discountclass" ID="lbdiscount" runat ="server"></asp:Label>
                                             </td>
                                             <td style ="height :40px;width:116px;" valign ="top">
                                                                   <asp:Label CssClass="amountclass" ID="lbamount" runat ="server"></asp:Label>
                                             </td>
                                   </tr>
                                   <tr align ="center">
                                             <td style="height :15px;" valign ="top">
                                                       <asp:Label CssClass="weidthclass" ID="lbweidthtxt" runat ="server"></asp:Label>
                                             </td>
                                             <td  valign ="top">
                                                       <asp:Label CssClass="heitextclass" ID="lbheitext" runat ="server"></asp:Label>
                                             </td>
                                             <td style="height :15px;" valign ="top">
                                                       <asp:Label CssClass="voltxtclass" ID="lbvoltxt" runat ="server"></asp:Label>
                                             </td>
                                             <td style="height :15px;" valign ="top">
                                                       <asp:Label CssClass="extratxtclass" ID="lbextratxt" runat ="server"></asp:Label>
                                             </td>
                                             <td style="height :15px;" valign ="top">
                                                       <asp:Label CssClass="colortxtclass" ID="lbcolortxt" runat ="server"></asp:Label>
                                             </td>
                                             <td style="height :15px;" valign ="top">
                                                        <asp:Label CssClass="packtxtclass" ID="lbpacktxt" runat ="server"></asp:Label>
                                             </td>
                                             <td style="height :15px;" valign ="top">
                                                        <asp:Label CssClass="extrclass" ID="lbextr" runat ="server"></asp:Label>
                                             </td>
                                             <td style="height :15px;" valign ="top">
                                                        <%--<asp:Label  CssClass="discounttxtclass"ID="lbdiscounttxt" runat ="server"></asp:Label>--%>
                                             </td>
                                             <td style="height :15px;" valign ="top">
                                                       <asp:Label CssClass="amtxtclass" ID="lbamtxt" runat ="server"></asp:Label>
                                             </td>
                                  </tr>
                                  <tr  align ="left"  >
                                             <td colspan ="7" style="height :159px;width:400px;" valign ="top" > 
                                             <table>
                                             <tr valign ="top" ><td style ="height :33%; position: absolute;" ><asp:Label CssClass="amount1class" ID="lbpanno" runat ="server"></asp:Label></td><td><asp:Label CssClass="amount1class" ID="pantxt" runat ="server"></asp:Label></td></tr><br />
                                             <tr ><td><asp:Label CssClass="amount1class" ID="lbproductkey" runat ="server"></asp:Label></td><td><asp:Label CssClass="amount1class" ID="producttxt" runat ="server"></asp:Label></td></tr>
                                             <tr ><td><asp:Label CssClass="amount1class" ID="lbrupee" runat ="server"></asp:Label></td><td><asp:Label CssClass="amount1class" ID="rupeetxt" runat ="server"></asp:Label></td></tr>
                                             </table>
                                             </td>
                                             <td colspan ="2" valign="top" style="height: 159px">
                                                             <table  border="1" >
                                                                           <tr>
                                                                                   <td style="height :15px;width:150px;" valign ="top">
                                                                                           <asp:Label CssClass="amount1class" ID="lblamount" runat ="server"></asp:Label>
                                                                                   </td>
                                                                                   <td style="height :15px;width:150px;">
                                                                                   </td>
                                                                           </tr>
                                                                           <tr>
                                                                                    <td style="height :15px;" valign ="top">
                                                                                            <asp:Label CssClass="trade1class" ID="lbltrade" runat ="server"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                           </tr>
                                                                           <tr>
                                                                                    <td valign ="top">
                                                                                              <asp:Label CssClass="total1class" ID="lbltotal" runat ="server" ></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                           </tr>
                                                                           <tr>
                                                                                    <td valign ="top">
                                                                                                <asp:Label CssClass="box1class" ID="lblbox" runat ="server"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                           </tr>
                                                                           <tr>
                                                                                    <td valign ="top">
                                                                                                 <asp:Label CssClass="net1class" ID="lblnet" runat ="server"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                            </tr>
                                                                           <tr>
                                                                                     <td valign ="top">
                                                                                                  <asp:Label CssClass="netpayable1class" ID="lblnetpayable" runat ="server"></asp:Label>
                                                                                     </td>
                                                                                     <td>
                                                                                     </td>
                                                                           </tr>
                                                             </table>
        
        
        
                                             </td>
                                 </tr>
                                 <tr >
                                             <td colspan ="9" style="height: 23px">
                                            </td>
                                </tr>
                                <tr align ="left" >
                                          <td> <asp:Label CssClass="netpayable1class" ID="lbpub" runat ="server"></asp:Label></td>  <td colspan ="8"> <asp:Label CssClass="netpayable1class" ID="lbedition" runat ="server"></asp:Label></td>
                               </tr>
                               <tr align ="left">
                                          <td><asp:Label CssClass="netpayable1class" ID="pubtxt" runat ="server"></asp:Label></td>  <td colspan ="8"><asp:Label CssClass="netpayable1class" ID="editxt" runat ="server"></asp:Label></td>
                               </tr>
 
    
    
                    </table>
    
                </td>
         </tr>
   
    </table>
