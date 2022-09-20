<%@ Page Language="C#" AutoEventWireup="true" CodeFile="htmlform.aspx.cs" Inherits="htmlform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Receipt</title>
    <link href="css/report.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="javascript/receipt.js"></script>
    <script type="text/javascript" src="javascript/numbertowords.js"></script>
    
</head>
<body onload="javascript:return filldata();">
    <form id="form1" runat="server">
    <div>
    
        <table width="100%" cellpadding="0" cellspacing="0" class="t1" border="0">
         <tr>
                 <td colspan="5">
                      <%--<img alt="4CPLUS LOGO" src="images/Hindustan-logo.jpg" width="90px" height="50px"/>--%>
                 </td>
                 <td colspan="4" align="center" valign="baseline">
                    <h2> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; KUITANSI </h2>
                 </td> 
                 <td colspan="5" align="right">
                      <img alt="4CPLUS LOGO" src="images/Ng-logo.jpg" width="150px" height="50px" />
                 </td>
          </tr>
         <tr>
                 <td style="width: 61px">
                 </td>
                  <td style="width: 49px">
                   </td>
                   <td>
                   </td>
                 <td style="width: 171px">
                      
                 </td>
                  <td style="width: 15px" >
                  </td>
                  <td style="width: 33px" >
                  </td>
                   <td>
                       
                 </td>
                 
                  <td style="width: 103px">
                    
                  </td>
                  <td colspan="2">
                     
                  </td>
                  <td>
                  </td>
                  <td >
                    
                  </td>
                  <td valign="top" style="width: 81px">
                     <%--KG Order--%>
                  </td>
                  <td style="width: 88px">
                  </td>
            </tr>
            <tr>
                 <td valign="top">
                 </td>
                  <td style="width: 49px">
                   </td>
                   <td>
                   </td>
                 <td style="width: 171px">
                       
                 </td>
                  <td style="width: 15px" >
                  </td>
                  <td style="width: 33px" >
                  </td>
                   <td>
                      
                 </td>
                 
                  <td style="width: 103px" >
                     
                  </td>
                  <td colspan="2">
                     
                  </td>
                  <td>
                  </td>
                  <td >
                  </td>
                  <td valign="top" style="width: 81px">
                    Order date
                  </td>
                  <td valign="top" style="width:88px" id="tdorddate">
                     02 mar 2009
                  </td>
            </tr> 
            <tr style="height:10px">
            </tr>
            <tr>
               <td colspan="2">
                      <b>
                        No. Cust
                       </b> 
               </td>
               <td>
                  :&nbsp;
               </td>
               <td style="width: 171px" id="tdcustid">
                       <%--1015097--%>
               </td>
               <td style="width: 15px">
               </td>
               <td style="width: 33px">
                      <b>
                           NPWP
                      </b>     
                </td>
                <td colspan="2" id="tdnpwp">
                         :&nbsp;12234567
                </td>
                <td style="width: 15px">
                </td>
                <td>
                </td>
                <td colspan="2">
                       <b>
                            Order No.
                       </b>     
                 </td>
                 
                 <td colspan="3" id="tdciobookid">
                         :&nbsp;A2737918
                 </td>
                 
            </tr>
            <tr>
                  <td colspan="2">
                      <b>
                         Name
                      </b>   
                  </td>
                  <td>
                     :
                  </td>
                  <td style="width: 171px" id="tdcustname">
                         <%--UNICEF--%>
                  </td>
                  <td style="width: 15px">
                  </td>
                  <td style="width: 33px">
                  </td>
                   <td>
                   </td>
                   <td style="width: 103px">
                   </td>
                   <td style="width: 15px">
                   </td>
                   <td>
                   </td>
                   <td colspan="2">
                      <b>
                       Ad Title
                      </b>  
                   </td>
                   <td colspan="3" id="tdadtitle">
                       :&nbsp;UNICEF-Children Health
                       
                   </td>
            
            
            
            </tr>
            <tr>
                   <td colspan="2" valign="top">
                     <b>
                           Address
                     </b>
                    </td>
                    <td valign="top">
                       :
                    </td>
                   <td colspan="3" rowspan="2" valign="top" style="width: 161px" id="tdcustadd">
                      <%--JL. JEND SUDIRMAN KAV 31 JAKARTA 12920--%>
                   </td>
                  
                   <td>
                   </td>
                   <td style="width: 103px">
                   </td>
                   <td style="width: 15px">
                   </td>
                   <td>
                   </td>
                   <td colspan="2" valign="top">
                      <b>
                             Classification
                      </b>       
                   </td>
                   
                   <td colspan="3" valign="top" id="tdadtype">
                      :&nbsp;Non -Goverment Org.
                   </td>
                   
            </tr>
          
            <tr>
            </tr>
            <tr style="height:10px">
            </tr>
            <tr style="height:35px; background-color:Silver">
                   <td colspan="4">
                       &nbsp;
                     <b>  
                            MEDIA ORDER
                     </b>
                   </td>
                   
                   <td style="width: 15px">
                   </td>
                   <td style="width: 33px">
                   </td>
                   <td align="left" colspan="2">
                     <b>
                            SCHEDULE LINE
                     </b>
                   </td>
                 
                   <td style="width: 15px">
                   </td>
                   <td>
                   </td>
                   <td>
                   </td>
                   <td>
                   </td>
                   <td style="width: 81px">
                   </td>
                   <td style="width: 88px">
                   </td>
           
            </tr>
            <tr style="height:10px">
            </tr>
            <tr>
                  <td colspan="2">
                     <b>
                                            Media order
                     </b>                       
                  </td>
                  <td>
                        :
                  </td>
                  <td style="width: 171px" id="tdrono">
                        10150
                  </td>
                  <td style="width: 15px" >
                  </td>
                   <td style="width: 33px" >
                   </td>
                   <td colspan="8" align="left" id="tdstartwith">
                        08 MAR 2009
                  </td>
                  <%--<td style="width: 15px">
                 </td>
                  <td >
                  </td>
                  <td>
                  </td>
                  <td>
                  </td>
                  <td style="width: 81px" >
                  </td>
                  <td style="width: 88px">
                  </td>
                  <td>
                  </td>--%>
            </tr>
             <tr>
                 <td style="width: 61px">
                    <b>
                          Date
                    </b>      
                 </td>
                  <td style="width: 49px">
                  </td>
                  <td>
                         :
                  </td>
                  <td colspan="2" id="tdrodate">
                          01 MARKET 2009
                 </td>
                  <td style="width: 33px" >
                  </td>
                  <td>
                  </td>
                  <td style="width: 103px" >
                  </td>
                   <td style="width: 15px">
                 </td>
                  <td>
                 </td>
                  <td >
                  </td>
                  <td>
                  </td>
                  <td style="width: 81px">
                  </td>
                  <td style="width: 88px" >
                  </td>
            </tr>
            <tr style="height:10px">
            </tr>
            <tr><td colspan="30"><table cellpadding="0" cellspacing="0" style="width:100%;background-color:Silver;height:35px">
           
            <tr>
            <td valign="middle" style="padding-left:10px;width:60%" ><b>AD SPEC</b></td>
            <td valign="middle"><b>AD INFORMATION</b></td>
            </tr>
            
            </table></td></tr>
            
             
            <tr><td colspan="30"><table cellpadding="0" cellspacing="0" style="width:100%" border="0">
            <tr><td colspan="6" style="height:10px"></td></tr>
            <tr>
            <td style="width:38%" valign="top">
            <table cellpadding="0" cellspacing="0" style="width:100%">
            <tr><td>Style</td><td id="tduom">&nbsp;&nbsp;:&nbsp;REGULER:ADVERTORIAL:DISPLAY:PC</td></tr>
            <tr><td id="tdlbsize">Size</td><td id="tdsize">&nbsp;&nbsp;:&nbsp;4 (7COL) col * 270mm</td></tr>
            <tr><td style="height:5px"></td></tr>
            <tr><td colspan="2"><table cellpadding="0" cellspacing="0" style="width:100%"><tr><td style="width:35%">&nbsp;</td><td >Gross</td></tr></table></td></tr>
            
            <tr><td colspan="2"><table cellpadding="0" cellspacing="0" style="width:100%"><tr><td style="width:35%">&nbsp;</td><td >DISC 0%</td></tr></table></td></tr>
           
            
            </table>
            </td>
            
            <td style="width:17%">
            <table cellpadding="0" cellspacing="0" style="width:100%">
            <tr><td colspan="" style="height:30px"></td></tr>
            <tr>
            <td>Rp.</td><td align="right" id="tdgrossamt">7400</td>
            </tr>
            <tr>
            <td>Rp.</td><td align="right" id="tddiscrate">0</td>
            </tr>
            </table>
            </td>
            <td style="width:5%"></td>
            <td style="width:17%">
            <table cellpadding="0" cellspacing="0" style="width:100%">
            <tr><td>Booking Unit</td></tr>
             <tr><td>Rate</td></tr>
              <tr><td><b>Frequency</b></td></tr>
               <tr><td><b>PRODUCTION NOTES</b></td></tr>
               
            </table>
            </td>
            <td style="width:23%">
              <table cellpadding="0" cellspacing="0" style="width:100%">
            <tr><td id="tdedition">:&nbsp;KNAS,KBDG,KSMG,KJOG,KSBY</td></tr>
             <tr><td id="tdcardrate">:&nbsp;50,000 IDR </td></tr>
              <tr><td id="tdinsertion">:&nbsp;1</td></tr>
               <tr><td><b>AD TEXT</b></td></tr>
               <tr><td colspan="6" style="height:10px"></td></tr>
            </table>
            </td>
            </tr>
            </table></td></tr>
           
        </table>
        <table cellpadding="0" cellspacing="0" style="width:100%" border="0" class="t1">
        <tr>
        <td style="width:13%">
       
        </td>
        <td style="width:25%"><table cellpadding="0" cellspacing="0" style="width:100%">
        <tr><td style="height:30px"></td></tr>
        <tr><td>
        SURCHG 0%
        </td>
        
        </tr>
        
        <tr><td id="tdlbvat">VAT 10%</td></tr>
        <tr><td style="height:22px"></td></tr>
        <tr><td valign="bottom">TOTAL</td></tr>
        </table></td>
        <td style="width:17%"><table cellpadding="0" cellspacing="0" style="width:100%">
        <tr><td colspan="2" align="left">----------------------</td></tr>
        <tr><td>Rp.</td><td id="tdtotal" align="right">704000</td></tr>
        <tr><td>Rp.</td><td id="tdsurcharge" align="right">0</td></tr>
        <tr><td>Rp.</td><td id="tdvatamt" align="right">70400</td></tr>
        <tr><td colspan="2" align="left">----------------------</td></tr>
        <tr><td><b>Rp.</b></td><td  id="tdfnltotal" align="right"><b>7744000</b></td></tr>
        </table></td>
        <td style="width:6%"></td>
        <td style="width:16%" id="tdmatstat" valign="top">Material via e-mail</td>
        <td style="width:23%" id="tdmatter" valign="top">
        SEWA MBL di jogia          rent car ji .ladska  addfhgjh      12344555677,123435577        46677878   fax        Email: asdfghhj@yahoo.com mndbfdhf<br /> jshdsahkdjA<br />
        </td>
        </tr>
        </table>
     
      
       <table cellpadding="0" cellspacing="0" style="width:100%" border="0">
            <tr>
                <td id="tdamtwords" style="padding-left:120px">
                        dfsdsfdsf
                </td>
            </tr>
       </table>
      
       <table width="75%" cellpadding="0" cellspacing="0" class="t2" border="0" style="font-size:xx-small; padding-top:10px">
            <tr>
                <td style="width: 115px">
                    ORIGINAL
                </td>
                <td style="width: 300px">
                    KG_SHEILA | Palmerah Selatan
                </td>
                <td>
                    PT Hindustan MEDIA NUSANTARA | Jl. Palmerah Selatan No 22 - Jakarta 10270
                    NPWP 01.304.315.3-092.000 | PKP No. 022.00012.07-84, Tgl. 23-7-84
                </td>
            </tr>
       </table>
    
    </div>
    <input id="hiddenmatter" type="hidden" runat="server" />
    <input id="hiddenvat" type="hidden" runat="server" />
    <input id="hiddenlogo" type="hidden" runat="server" />
    </form>
</body>
</html>
