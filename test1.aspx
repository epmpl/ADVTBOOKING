<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test1.aspx.cs" Inherits="test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="css/report.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table width="930px" cellpadding="0" cellspacing="0" class="t1" border="0">
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
                 <td style="width: 61px; ">
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
                  <td style="width: 60px">
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
                  <td style="width: 60px">
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
                   <td style="width: 60px">
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
                  <td style="width: 60px" >
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
             <tr style="height:35px; background-color:Silver">
                 <td colspan="2" style="height: 35px" >
                     &nbsp;
                    <b>  
                          AD SPEC
                    </b>      
                 </td>
                 <td>
                 </td>
                 <td style="height: 35px; width: 171px;">
                 </td>
                  <td style="height: 35px; width: 15px;" >
                  </td>
                  <td style="height: 35px; width: 33px;" >
                  </td>
                  <td style="height: 35px">
                  </td>
                   <td style="width: 103px; height: 35px">
                 </td>
                  <td style="width: 15px; height: 35px;">
                 </td>
                  <td colspan="2" style="height: 35px">
                    <b>
                            AD INFORMATION
                    </b>        
                  </td>
                 
                  <td style="height: 35px">
                  </td>
                  <td style="width: 81px; height: 35px" >
                  </td>
                  <td style="width: 88px; height: 35px">
                  </td>
            </tr>
            <tr style="height:10px">
                  <td colspan="11">
                  </td>
                  <td colspan="3" >
                  </td>
            </tr>
             <tr>
                 <td>
                    Style
                 </td>
                  <td colspan="7" id="tduom">
                     :&nbsp;REGULER:ADVERTORIAL:DISPLAY:PC
                   </td>
                
                  <td style="width: 15px" >
                 </td>
                  <td colspan="2">
                    Booking Unit
                  </td>
                  
                  <td colspan="3" id="tdedition">
                  :&nbsp;KNAS,KBDG,KSMG,KJOG,KSBY
                  </td>
                  
            </tr>
             <tr>
                 <td style="width: 61px" id="tdlbsize">
                    Size
                 </td>
                  <td colspan="4" id="tdsize">
                      :&nbsp;4 (7COL) col * 270mm
                   </td>
                
                  <td style="width: 33px" >
                  </td>
                   <td>
                 </td>
                  <td style="width: 119px">
                 </td>
                 <td>
                 </td>
                  <td>
                     Rate
                  </td>
                  <td style="width: 60px" >
                  </td>
                  <td colspan="2" id="tdcardrate">
                     :&nbsp;50,000 IDR
                  </td>
                 
                  <td >
                  </td>
            </tr>
             <tr>
                 <td style="width: 61px; height: 14px;">
                 </td>
                  <td style="width: 49px; height: 14px;">
                   </td>
                   <td style="height: 14px">
                   </td>
                 <td style="width: 171px; height: 14px;">
                 </td>
                
                  <td style="width: 15px; height: 14px;" >
                  </td>
                  <td style="width: 33px; height: 14px;" >
                  </td>
                   <td style="height: 14px">
                 </td>
                  <td style="width: 103px; height: 14px;">
                 </td>
                 <td style="width: 15px ; height: 14px;">
                 </td>
                  <td style="height: 14px">
                     <b>
                          Frequency
                     </b>     
                  </td>
                  <td style="height: 14px; width: 60px;">
                  </td>
                  <td colspan="2" id="tdinsertion" style="height: 14px">
                            :&nbsp;1
                  </td>
                  <td style="width: 88px ; height: 14px;">
                  </td>
            </tr>
             <tr>
                   <td style="width: 61px; height: 3px;">
                   </td>
                   <td style="width: 49px; height: 3px;">
                   </td>
                   <td style="height: 3px">
                   </td>
                   <td  valign="top">
                          Gross
                  </td>
                  
                  <td style="width: 15px; height: 3px;">
                  </td>
                  <td style="width: 33px; height: 3px;" >
                  </td>
                   <td style="height: 3px" valign="top" >
                        Rp.
                 </td>
                  <td align="right"  id="tdgrossamt" valign="top">
                        704000</td>
                  <td style="width: 15px ; height: 3px; padding:10px">
                  </td>
                  <td style="height: 3px" >
                  </td>
                  <td style="height: 3px; width: 60px;" >
                  </td>
                  <td style="height: 3px" >
                  </td>
                  <td style="width: 81px ; height: 3px;">
                  </td>
                  <td style="width: 88px ; height: 3px;">
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
                        DISC 0%
                 </td>
                  <td style="width: 15px" >
                  </td>
                  <td style="width: 33px" >
                  </td>
                   <td>
                        Rp.
                 </td>
                  <td align="right"  id="tddiscrate" valign="top">
                       0</td>
                  <td style="width: 15px" >
                  </td>
                  <td colspan="2" >
                     <b>  
                             PRODUCTION NOTES
                     </b>        
                  </td>
                  
                  
                  <td colspan="3" >
                     <b>
                         AD TEXT
                     </b>    
                  
                  
            </tr>
        </table>
        <table width="930px" cellpadding="0" cellspacing="0" class="t1" border="0">
            <tr valign="top">
                <td style="width: 705px">
                    <table cellpadding="0" cellspacing="0"  border="0" style="width: 699px">
                        <tr>
                 <td style="width: 55px;">
                 </td>
                  <td style="width: 50px; height: 19px;">
                   </td>
                   <td style="width: 12px; height: 19px;">
                   </td>
                 <td style="width: 170px; height: 19px;">
                 </td>
                  <td style="width: 11px; height: 19px;" >
                  </td>
                  <td style="width: 44px; height: 3px;"  >
                  </td>
                   <td colspan="2">
                       ---------------------
                 </td>
                 
                  <td style="width: 23px ; height: 19px;" >
                  </td>
                  <td colspan="2"  id="tdmatstat" style="height: 19px">
                      Material via e-mail
                  </td>
                  </tr>
                  <tr>
                 <td style="width: 55px; height: 40px;">
                 </td>
                  <td style="width: 50px; height: 40px;">
                   </td>
                   <td style="width: 11px; height: 40px;">
                   </td>
                 <td style="width: 170px; height: 40px;">
                 </td>
                  <td style="width: 15px; height: 40px;" >
                  </td>
                  <td style="width: 44px; height: 40px;" >
                  </td>
                   <td style="width: 19px; height: 40px;">
                       Rp.
                 </td>
                 
                  <td align="right"  id="tdtotal" style="width: 125px; height: 40px">
                       704000
                  </td>
                  <td style="width: 23px ; height: 40px; padding:10px">
                     
                  </td>
                 
            </tr>
            <tr>
                 <td style="width: 55px; height: 12px;">
                 </td>
                  <td style="width: 50px; height: 12px;">
                   </td>
                   <td style="width: 11px; height: 12px;">
                   </td>
                 <td style="width: 170px; height: 12px;">
                      SURCHG 0%
                 </td>
                  <td style="width: 15px; height: 12px;" >
                  </td>
                  <td style="width: 44px; height: 12px;" >
                  </td>
                   <td style="width: 19px; height: 12px;" >
                        Rp.
                 </td>
                 
                  <td align="right" id="tdsurcharge" style="width: 125px">
                     0
                  </td>
                  <td style="width: 23px ; height: 12px;">
                      
                  </td>
                  
            </tr>
            <tr>
                <td style="width: 55px">
                 </td>
                  <td style="width: 50px">
                   </td>
                   <td style="width: 11px">
                   </td>
                 <td style="width: 170px" id="tdlbvat">
                      VAT 10%
                 </td>
                  <td style="width: 15px" >
                  </td>
                  <td style="width: 44px" >
                  </td>
                   <td style="width: 19px">
                        Rp.
                 </td>
                 
                  <td align="right" style="width: 125px" id="tdvatamt">
                        70400
                  </td>
                  <td style="width: 23px ">
                     
                  </td>
                  
            </tr>
            <tr>
                <td style="width: 55px">
                 </td>
                  <td style="width: 50px">
                   </td>
                   <td style="width: 11px">
                   </td>
                 <td style="width: 170px">
                 </td>
                  <td style="width: 15px" >
                  </td>
                  <td style="width: 44px" >
                  </td>
                   <td colspan="2">
                       ---------------------
                 </td>
                 
                  <td style="width: 23px">
                  </td>
                  <td colspan="2" >
                     
                  </td>
                  
            </tr>
            <tr>
                <td style="width: 55px; height: 16px;">
                 </td>
                  <td style="width: 50px; height: 16px;">
                   </td>
                   <td style="width: 11px">
                   </td>
                 <td style="height: 16px; width: 170px;">
                         TOTAL
                 </td>
                  <td style="height: 16px; width: 15px;" >
                  </td>
                  <td style="height: 16px; width: 44px;" >
                  </td>
                   <td style="height: 16px; width: 19px;">
                      <b>
                           Rp.
                      </b>     
                 </td>
                 
                  <td align="right" style="width: 125px; height: 16px" id="tdfnltotal">
                     <b>
                         7744000
                     </b>    
                  </td>
                  <td colspan="2" style="height: 16px">
                     
                  </td>
                  
            </tr>
                </table>
                </td>
                <td style="width:250px">
                    <div>
                        <table><%-- style="background-image:url(images/Hindustan-logo2.jpg)" --%>
                            <tr>
                                <td id="tdmatter">
                                    SEWA MBL di jogia          rent car ji .ladska  addfhgjh      12344555677,123435577        46677878   fax        Email: asdfghhj@yahoo.com mndbfdhf<br /> jshdsahkdjA<br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
       </table>
       <b>
       <table cellpadding="0" cellspacing="0">
            <tr>
                <td id="tdamtwords" style="padding-left:120px">
                        dfsdsfdsf
                </td>
            </tr>
       </table>
       </b>
       <table width="930px" cellpadding="0" cellspacing="0" class="t2" border="0" style="font-size:xx-small; padding-top:10px">
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
    </form>
</body>
</html>
