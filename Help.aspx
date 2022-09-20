<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="Help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>:: HELP ::</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/Help.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="javascript/Help.js" type="text/javascript"></script>
</head>
<body onload="loadHtmlpage();"> 
<div class="main_container">
<div class="header" style="background-image:url('Images/header_img.jpg')" runat="server"></div>
<div class="leftbar">
<table border="0" cellpadding="10" cellspacing="0">
  <tr><td>

<table border="0" cellpadding="1" cellspacing="1">
<tr>
	<td width='16'><a id="xproducts" href="javascript:Toggle('products');"><img src="Images/folder.gif" width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
    <td><b>Ad Manager</b></td>
    </tr>
 </table>
	<div id="products" style="display: none; margin-left: 2em;">
				<table border=0 cellpadding='1' cellspacing=1>
                <tr>
               	 <td width='16'><a id="xmasterclick" href="javascript:Toggle('masterclick');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
                	<td><b>Master</b></td>
                </tr>
                </table>
                
                 <div id="masterclick" style="display: none; margin-left: 2em;"> 
                    <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><a id="xspecs1" href="javascript:Toggle('specs1');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
                    <td><b>Agency/Client Master</b></td>
                    </tr>
                    </table>
                
				
                
                    <div id="specs1" style="display: none; margin-left: 2em;">
                          <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="#"  onclick="loadHtml('AgencyTypeMaster.html')">Agency Type </a></td>
                        </tr>
                        </table>
                    
                        <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="#" onclick="loadHtml('Agent_Master.html')">Agency </a></td>
                        </tr>
                        </table>
                               
                        <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="#" onclick="loadHtml('ClientMaster.html')">Client</a></td>
                        </tr>
                        </table>
                       
                        <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="#" onclick="loadHtml('PublisherMaster.html')">Publisher</a></td>
                        </tr>
                        </table> 
                     
                         <table border=0 cellpadding='1' cellspacing=1>
                         <tr>
                         <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                         <td><a href="#" onclick="loadHtml('ProductCategory.html')">Product </a></td>
                         </tr>
                         </table>                       
                    </div>
                    
                    
                    
                    
                    <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><a id="xspecs2" href="javascript:Toggle('specs2');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
                    <td><b>Exec./Retainer Master</b></td>
                    </tr>
                    </table>
                    
                    <div id="specs2" style="display: none; margin-left: 2em;">
                          <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="#" onclick="loadHtml('AgencyRoleMaster.html')">Designation</a></td>
                        </tr>
                        </table>
                        
                        
                        
                         <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="#" onclick="loadHtml('All_module_master.html')">Reporting To</a></td>
                        </tr>
                        </table>
                        
                        <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="#" onclick="loadHtml('AdvExecMaster.html')">Executive Master</a></td>
                        </tr>
                        </table>
                        
                        <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="#" onclick="loadHtml('RetainerMaster.html')">Retainer Master</a></td>
                        </tr>
                        </table>
                        
                    </div>
                  
                    
                    <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><a id="xspecs3" href="javascript:Toggle('specs3');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
                    <td><b>Enviornment Master</b></td>
                    </tr>
                    </table>
                    
                    
                   <div id="specs3" style="display: none; margin-left: 2em;">
                      <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('Company_Master.html')">Company Name</a></td>
                    </tr>
                    </table>
                        
                        
                        
                        
                    <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('PubCatMast.html')">Publication Center</a>
                    </td>
                    </tr>
                    </table>
                        
                        
                <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('BranchMaster.html')">Branch Master</a>
                </td>
                </tr>
                </table>
                        
                        
                        
                        
                <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('CountryMaster.html')">Country Master</a>
                </td>
                </tr>
                </table>
                        
                        
                
                <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('StateMaster.html')">State Master</a>
                </td>
                </tr>
                </table>
                        
                        
                        
                        
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('ZoneMaster.html')">Zone Master</a>
                </td>
                </tr>
                </table>
                        
                        
                        
                        
                <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('DistrictMaster.html')">District Master</a>
                </td>
                </tr>
                </table>
                        
                        
                        
                        
                <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('taluka_mast.html')">Taluka Master</a>
                </td>
                </tr>
                </table>
                        
                        
                        
                        
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('region_master.html')">Region Master</a>
                </td>
                </tr>
                </table>
                        
                        
                        
                     <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('PaymentMode.html')">Payment Mode</a>
                    </td>
                    </tr>
                    </table>
                        
                        
                    
                     <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('status_master.html')">Status Master</a>
                    </td>
                    </tr>
                    </table>
                    
                    
                    
                        <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('AdvTypeMaster2.html')">Ad Type</a>
                    </td>
                    </tr>
                    </table>
                    
                    
                    
                    
                          <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('CurrencyMaster.html')">Currency </a>
                   </td>
                    </tr>
                    </table>
                    
                    
                    
                          <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('LanguageMaster.html')">Language </a>
                    </td>
                    </tr>
                    </table>
                    
                    
                    
                    
                          <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('Vatmaster.html')">Tax Rate</a>
                    </td>
                    </tr>
                    </table>
                    
                    
                    
                          <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('AdCategoryMaster.html')">Ad Category</a>
                    </td>
                    </tr>
                    </table>
                    
                    
                    
                    
                          <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('adsubcat1.html')">Ad Sub Category</a>
                    </td>
                    </tr>
                    </table>
                    
                    
                    
                          <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('Adsubcat3.html')">Ad Sub Category3</a>
                    </td>
                    </tr>
                    </table>
                    
                    
                    
                          <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('AdCat4.html')">Ad Sub Category4</a>
                    </td>
                    </tr>
                    </table>
                    
                    
                    
                                <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                    <td><a href="#" onclick="loadHtml('AdSubCat5.html')">Ad Sub Category5</a>
                    </td>
                    </tr>
                    </table>
                    </div>
                        
                        
                        
                        <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><a id="xspecs4" href="javascript:Toggle('specs4');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
                    <td><b>Publication Masters</b></td>
                    </tr>
                    </table>
         
         
         
          <div id="specs4" style="display: none; margin-left: 2em;">
          
          
                  <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('PublicationType.html')">Publication Type </a></td>
                </tr>
                </table>
                
                
                
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('PublicationMaster.html')">Publication</a></td>
                </tr>
                </table>
                
            
              <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('EditorMaster.html')">Editon </a></td>
            </tr>
            </table>
            
            
            
            
               <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('SupplementType.html')">Supplement Type</a></td>
            </tr>
            </table>
            
            
            
           <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('SupplementMaster.html')">Supplement</a></td>
            </tr>
            </table>
            
            
               <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('CombinationMaster.html')">Combination </a></td>
            </tr>
            </table>
             <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('EditionStatus.html')">Change Package Status </a></td>
            </tr>
            </table>
             <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('PageType.html')">Page Type </a></td>
            </tr>
            </table>
             <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('preodicitymaster.html')">Periodicity </a></td>
            </tr>
            </table>
             <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('NoIssueMaster.html')">No Issue </a></td>
            </tr>
            </table>
             <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('NoIssueDayMaster.html')">No Issue Day </a></td>
            </tr>
            </table>
              <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('UOM.html')">Unit Of Measurement </a></td>
            </tr>
            </table>
             <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
            <td><a href="#" onclick="loadHtml('AdsizeMaster.html')">Ad Size </a></td>
            </tr>
            </table>
             </div>
             
             
            <table border=0 cellpadding='1' cellspacing=1>
            <tr>
            <td width='16'><a id="xspecs5" href="javascript:Toggle('specs5');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
            <td><b>Rate Masters</b></td>
            </tr>
            </table>



 <div id="specs5" style="display: none; margin-left: 2em;">
          
          
                  <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('Ratemaster.html')">Rate Master</a></td>
                </tr>
                </table>
                
                
                  <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('RateGroupMaster.html')">Rate Group Master</a></td>
                </tr>
                </table>
                
                
                    <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('ColorRateGroup.html')">Color Rate Group </a></td>
                </tr>
                </table>
                
                
                  <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('Premium_type_master.html')">Premium Type </a></td>
                </tr>
                </table>
                
                <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('DealTypeMaster.html')">Contract Type </a></td>
                </tr>
                </table>
                
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('ContractMaster.html')">Contract Master </a></td>
                </tr>
                </table>
                
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('ColorMaster.html')">Color Master</a></td>
                </tr>
                </table>
                
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('colortype.html')">Color Type </a></td>
                </tr>
                </table>
                
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('BgColor.html')">Bg Color</a></td>
                </tr>
                </table>
                
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('Bullet_master.html')">Bullet </a></td>
                </tr>
                </table>
                
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('AdvPagePositionMaster.html')">Ad Page Prem. </a></td>
                </tr>
                </table>
                
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('Scheme_Master.html')">Scheme</a></td>
                </tr>
                </table>
                
                 <table border=0 cellpadding='1' cellspacing=1>
                <tr>
                <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                <td><a href="#" onclick="loadHtml('BoxMaster.html')">Box </a></td>
                </tr>
                </table>
                </div>
                    
                
                </div>
                
                
                <%-- <div id="Div1" style="display: none; margin-left: 2em;"> 
                    <table border=0 cellpadding='1' cellspacing=1>
                    <tr>
                    <td width='16'><a id="xspecs" href="javascript:Toggle('specs2');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
                    <td><b>Exec./Retainer Master</b></td>
                    </tr>
                    </table>
                
				
                
                    <div id="Div2" style="display: none; margin-left: 2em;">
                          <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="http://www.industriavirtual.com.br/homepage.asp?code=modulos&subcode=newsletter" target="master">Agency Type </a></td>
                        </tr>
                        </table>
                    
                        <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="http://www.industriavirtual.com.br/homepage.asp?code=modulos&subcode=consulta" target="master">Agency </a></td>
                        </tr>
                        </table>
                               
                        <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="http://www.industriavirtual.com.br/homepage.asp?code=modulos&subcode=consulta" target="master">Client</a></td>
                        </tr>
                        </table>
                       
                        <table border=0 cellpadding='1' cellspacing=1>
                        <tr>
                        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                        <td><a href="http://www.industriavirtual.com.br/homepage.asp?code=modulos&subcode=consulta" target="master">Publisher</a></td>
                        </tr>
                        </table> 
                     
                         <table border=0 cellpadding='1' cellspacing=1>
                         <tr>
                         <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
                         <td><a href="http://www.industriavirtual.com.br/homepage.asp?code=modulos&subcode=consulta" target="master">Product </a></td>
                         </tr>
                         </table>                       
                    </div>
                
                </div>--%>
                
                
                
                
                
                
            
            <table border=0 cellpadding='1' cellspacing=1>
            <tr>
             <td width='16'><a id="xTransactionsclick" href="javascript:Toggle('Transactionsclick');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
                <td><b>Transactions</b></td>
            </tr>
            </table>
            
            <div id="Transactionsclick" style="display: none; margin-left: 2em;">
            
            
          <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="#" onclick="loadHtml('Booking_master.html')">Display Booking</a></td>
        </tr>
        </table>
        
        
           <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="#" onclick="loadHtml('Classified_Booking.html')">Classified Booking</a></td>
        </tr>
        </table>
        
        
        
            <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="#" onclick="loadHtml('QBC.html')">QBC</a></td>
        </tr>
        </table>
        
        
               <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="#" onclick="loadHtml('QBC.html')">Payment Gateway </a></td>
        </tr>
        </table>
        
        
               <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="#" onclick="loadHtml('QBC.html')">Confirm Ads paid through Payment Gatway</a></td>
        </tr>
        </table>
        
        
        
                        </div>
            
            
            
            <table border=0 cellpadding='1' cellspacing=1>
            <tr>
             <td width='16'><a id="xPamclick" href="javascript:Toggle('Pamclick');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
            <td><b>PAM</b></td>
            </tr>
            </table>
            
            
              <div id="Pamclick" style="display: none; margin-left: 2em;">
              
              
                      <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="http://www.industriavirtual.com.br/homepage.asp?code=modulos&subcode=newsletter" target="master">PAM</a></td>
        </tr>
        </table>
              
              </div>
            
            
            
            
             <table border=0 cellpadding='1' cellspacing=1>
            <tr>
             <td width='16'><a id="xReportsclick" href="javascript:Toggle('Reportsclick');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
            <td><b>Reports</b></td>
            </tr>
            </table>
            
            
              <div id="Reportsclick" style="display: none; margin-left: 2em;">
              
              
                      <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="http://www.industriavirtual.com.br/homepage.asp?code=modulos&subcode=newsletter" target="master">Report</a></td>
        </tr>
        </table>
        </div>
        
        
                  <table border=0 cellpadding='1' cellspacing=1>
            <tr>
             <td width='16'><a id="xBillingclick" href="javascript:Toggle('Billingclick');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
            <td><b>Billing</b></td>
            </tr>
            </table>
            
            
            
                       <div id="Billingclick" style="display: none; margin-left: 2em;">
              
              
                      <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="#" onclick="loadHtml('billing.html')">Billing</a></td>
        </tr>
        </table>
        
        
        
         <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="#" onclick="loadHtml('revised_bill.html')">Revised Bill </a></td>
        </tr>
        </table>
        </div>
        
               
               
               
               
          <table border=0 cellpadding='1' cellspacing=1>
            <tr>
             <td width='16'><a id="xServicesclick" href="javascript:Toggle('Servicesclick');"><img src='Images/folder.gif' width='16' height='16' hspace='0' vspace='0' border='0'></a></td>
            <td><b>Services</b></td>
            </tr>
            </table>
            
            
            
            
                           <div id="Servicesclick" style="display: none; margin-left: 2em;">
              
              
                      <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="#" onclick="loadHtml('Createuser.html')">Create User</a></td>
        </tr>
        </table>
        
        
        
         <table border=0 cellpadding='1' cellspacing=1>
        <tr>
        <td width='16'><img src='Images/text.gif' width='16' height='16' hspace='0' vspace='0' border='0'></td>
        <td><a href="#" onclick="loadHtml('cngpassword.html')">Change Password </a></td>
        </tr>
        </table>
        </div>
              
              </div>
                
   </td></tr></table>
</div>
<div class="rightbar">
  <iframe  id="data_container" height="100%" width="100%" style="border:0px;"></iframe>
</div>
<div class="footer" style="background-image:url('Images/footer.jpg')" runat="server"></div>
</div>
	<input id="hiddenfilepath" runat="server" type="hidden" name="hiddenfilepath" />
	<input id="hiddenformname" runat="server" type="hidden" name="hiddenformname" />
</body>
</html>
