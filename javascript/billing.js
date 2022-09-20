// JScript File
var test="1";
var myurl=document.URLUnencoded.split("/");
	            myurl=myurl[0]+"/"+myurl[1]+"/"+myurl[2]+"/"+myurl[3]+"/"+"billing"+"/"
	          
               //win=window.open(myurl+''+formname+'.aspx','','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');

function ttttt()
{

    
    
        if(event.keyCode==27)  
        {
          document.getElementById("divclient").style.display="none";
          document.getElementById("divagency").style.display="none";
        }
    if(event.keyCode==113)  
            {
             
                 if(document.activeElement.id=="txtclient")
                {
                    document.getElementById("divclient").style.display="block";
                    
       
       
        document.getElementById('divclient').style.top=180;
        document.getElementById('divclient').style.left=560;             
                    
//                    if(browser!="Microsoft Internet Explorer")
//                    {
     //
     //                   document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop-6)+"px";
          //              document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 3+"px";
//                    }
//                    else
//                    {
 //                       document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6+"px";
   //                     document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9+"px";
//                    }
                   myurl+ billing.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,bindclientname_callback);
                }
                
                ////////////////////////////////////////
                
                  if(document.activeElement.id=="txtagency")
                {
                    document.getElementById("divagency").style.display="block";
                    
       
       
        document.getElementById('divagency').style.top=140;
        document.getElementById('divagency').style.left=790;             
                    
//                    if(browser!="Microsoft Internet Explorer")
//                    {
     //
     //                   document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop-6)+"px";
          //              document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 3+"px";
//                    }
//                    else
//                    {
 //                       document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6+"px";
   //                     document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9+"px";
//                    }
                   
                  //var pagename="billing/billing";  
                  billing.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('txtagency').value,bindagencyname_callback);
                }
                
                /////////////////
                 
             
            }
}



var agencycodeglo;

function bindagencyname_callback(response)
{       
    ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    pkgitem.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_name,ds.Tables[0].Rows[i].code_subcode/*ds.Tables[0].Rows[i].SUB_Agency_Code*/);
  
       pkgitem.options.length;
       
    }
    }
    document.getElementById('txtagency').value="";
    document.getElementById("lstagency").value="0";
     //document.getElementById("lstagency").disabled=false;   
   // document.getElementById("lstagency").focus();
     return false;
}




function bindclientname_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstclient");
     pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Client-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);

   
    //alert(pkgitem.options.length);
    pkgitem.options.length = 1; 
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
        
       pkgitem.options.length;
       
    }
    
    }
    document.getElementById('txtclient').value="";
    document.getElementById("lstclient").value="0";
    //document.getElementById("lstclient").focus();
    
     return false;
}

////////////////this function is called when we open the list box of agency than on mouse click it get the agency
/*change*/
function insertclient()
{


    if(document.activeElement.id=="lstclient")
    {
    if(document.getElementById('lstclient').value=="0")
        {
        alert("Please select the client");
        return false;
        }
        document.getElementById("divclient").style.display="none";
        
        //alert(document.getElementById('lstagency').value);
       //alert(document.getElementById('lstagency').value);
           
        var page=document.getElementById('lstclient').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agencylist2.aspx?page="+page+"&value=1", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
        document.getElementById('txtclient').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
//        document.getElementById('drpagetyp').focus();
         // document.getElementById('dppub1').focus();
        
        document.getElementById("divclient").style.display='none';
        
        return false;
    }
    
    


}	


function insertagency()
{

    if(document.activeElement.id=="lstagency")
    {
    if(document.getElementById('lstagency').value=="0")
        {
        alert("Please select the agency");
        return false;
        }
        document.getElementById("divagency").style.display="none";
        
        //alert(document.getElementById('lstagency').value);
       //alert(document.getElementById('lstagency').value);
           
        var page=document.getElementById('lstagency').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agencylist2.aspx?page="+page+"&value=0", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
        document.getElementById('txtagency').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
        document.getElementById('txtclient').focus();
        
        document.getElementById("divagency").style.display='none';
        
        return false;
    }
    
    


	}
	
	
	function checklenthbill()
{
//document.getElementById('divgrid1').style.display="none";
alert('Seaching criteria does not produce any result');

return false;



}
	
	
	function  checkboxid()
{

var checkradio="";



if (document.getElementById("billprev").checked == true)
            {
                checkradio="1";
            }
            else
                if (document.getElementById("billgen").checked ==true)
                {
                    checkradio="2";
                }
                 else
                    if (document.getElementById("billreprint").checked ==true)
                    {
                        checkradio ="3";
                    }
                else
                {
                    checkradio ="4";
                }

if(checkradio=="4")
{
alert('please select altest once Billing type');
return false;
}

if(document.getElementById("hiddencheck").value!='CL0')
{

var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
				var j;
				
				
				var str1="DataGrid1_ctl02_Checkbox1";
				if(document.getElementById("DataGrid1")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}

else
{
                 for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)				
				 {                
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				if(ciobookid=="")
				{
				ciobookid=document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}
				else
				{
				ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= insertion+","+	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=edition+","+  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}					
		
			j1=2;	
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 
				 //window.open('invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 if(checkradio==3)
				 {
				 
				 window.open(myurl+'testnewsambad.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 }
				 else
				 {
window.open(myurl+'invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);

				 }
				  
				   
		}
		else
		
		{
		
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
			}		
				
				
				
			j1=2;
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client);
				  
				   
				 
				 
				 

				 
				
				
		}
				 
				 
				 

				 
				
				


}
	

 function  checklenthbill1()
				 {
				 alert ('this bill can not be printed');
				  return false;
				 
				 }
				 
				 
				 
				 
function	 chekvalidaton()
{



//garima
var check=1;






	
				 
      if(document.getElementById('drpbillstatus').value=="0")
             {
            
                alert('Please Enter  Bill Type');
                return false;
            
              }
              
              
             
               if(document.getElementById('dpdadtype').value=="0")
             {
            
                alert('Please Enter  Adtype');
               return false;
            
              }
//              if(document.getElementById("billgen").checked==true || document.getElementById("billprev").checked==true||document.getElementById("billreprint").checked==true)
//              
//            {
//            check=2;
//            }
//            if(check==1)
//            {
//            alert('Please select atleast one radio button');
//               return false;
//            }
            
            /////
            
           // if(document.getElementById('dpdadtype').value=="xxx")
           
           if(document.getElementById('hiddenclsbill').value=='monthly')
           {
           
           }
           
           else
           {
            
            
             if(document.getElementById('txtfrmdate').value=="")
             {
            
                alert('Please Enter  From Date');
                return false;
            
              }
               if(document.getElementById('txttodate1').value=="")
             {
            
                alert('Please Enter  Dateto');
                return false;
            
              }
            
            
             if((document.getElementById('txtfrmdate').value!="")||(document.getElementById('txttodate1').value!=""))
             {
            
            
            var dateformat=document.getElementById('hiddendateformat').value;
            if(dateformat=="mm/dd/yyyy")
            {
            var strfromdate=document.getElementById('txtfrmdate').value;
            var strdateto=document.getElementById('txttodate1').value;
            var strfromdate1mon=strfromdate.split('/')[0]
            var strdateto1mon=strdateto.split('/')[0]
             var strfromdate1year=strfromdate.split('/')[2]
            var strdateto1year=strdateto.split('/')[2]
            }
            else
            if(dateformat=="dd/mm/yyyy")
            {
            
               var strfromdate=document.getElementById('txtfrmdate').value;
            var strdateto=document.getElementById('txttodate1').value;
            var strfromdate1mon=strfromdate.split('/')[1]
            var strdateto1mon=strdateto.split('/')[1]
             var strfromdate1year=strfromdate.split('/')[2]
            var strdateto1year=strdateto.split('/')[2]
            }
            else         
            
            {
             var strfromdate=document.getElementById('txtfrmdate').value;
            var strdateto=document.getElementById('txttodate1').value;
            var strfromdate1mon=strfromdate.split('/')[1]
            var strdateto1mon=strdateto.split('/')[1]
             var strfromdate1year=strfromdate.split('/')[0]
            var strdateto1year=strdateto.split('/')[0]
            }
            
//            if(strfromdate1mon==strdateto1mon && strfromdate1year==strdateto1year)
//            {
//            }
//            else
//            {
//            alert('selected from date  and Date to  must be of same year and month');
//              return false;
//            }
//            
         }
         
         }
              
				 
				 
}

function  checkvisible()
{
//document.getElementById('div1').style.display="none";
document.getElementById('divgrid1').style.display="block";


}

function checkvisiblecla()
{
//document.getElementById('divgrid1').style.display="none";
document.getElementById('div1').style.display="block";


}

function  checkvisibleold()
{/*
if(document.getElementById('drpbillstatus').value=='3')
{
document.getElementById('btngenrate').disabled=false;
}
else
{
document.getElementById("btnprv").disabled=false;
document.getElementById("btnprint").disabled=false;
}





var checkst=1;


  var str1="DataGrid1_ctl02_Checkbox1";
  
//  if(document.getElementById("DataGrid2")!=null)
//{
//}
              if (document.getElementById("billgen").checked ==true && document.getElementById("drpbillstatus").value=="2" )
                {
                

                if(document.getElementById("DataGrid1")!=null)
                {
                
                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				document.getElementById(str1). disabled=true;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				}
                document.getElementById('btnnext').disabled= true;
                
                }
                    
                }
                
                ////////////////ALL///////////////////////
                else
                if (document.getElementById("billgen").checked ==true&&document.getElementById("drpbillstatus").value=="1")
                {
                
                if(document.getElementById("DataGrid1")!=null)
                {
                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				if(document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="billed")
				
				{
				document.getElementById(str1). disabled=true;
				}
				else
				
				{
				checkst=2;
				}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				}
                
                if(checkst==2)
                {
                document.getElementById('btnnext').disabled= false;
                
                }
                else
                
                {
                document.getElementById('btnnext').disabled= true;
                }
                
                
                }
                    
                }
                
                ///all with preview
                
                 else
                if ((document.getElementById("billprev").checked ==true&&document.getElementById("drpbillstatus").value=="1")||(document.getElementById("billreprint").checked ==true&&document.getElementById("drpbillstatus").value=="1"))
                {
                
                if(document.getElementById("DataGrid1")!=null)
                {
                
                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				if((document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="publish")||(document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="audit by rate"))
				
				{
				document.getElementById(str1). disabled=true;
				}
				else
				
				{
				checkst=2;
				}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				}
                
                if(checkst==2)
                {
                document.getElementById('btnnext').disabled= false;
                
                }
                else
                
                {
                document.getElementById('btnnext').disabled= true;
                }
                
                }
                
                    
                }
                
                
                /////////
                
                 else
                if ((document.getElementById("billprev").checked ==true&&document.getElementById("drpbillstatus").value=="3")||(document.getElementById("billreprint").checked ==true&&document.getElementById("drpbillstatus").value=="3"))
                {
                
                if(document.getElementById("DataGrid1")!=null)
                {
                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				if((document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="publish")||(document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="audit by rate"))				
				{
				document.getElementById(str1). disabled=true;
				}
				else
				
				{
				checkst=2;
				}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				}
                
                
                
                
                if(checkst==2)
                {
                document.getElementById('btnnext').disabled= false;
                
                }
                
                
                
                else
                
                {
                document.getElementById('btnnext').disabled= true;
                }
                
                
                }
                    
                }
                
                
                
                
                
                
                
                
                
                
                
 */               
}




  /*function SelectHi(grdid,obj,objlist)
			{ 		
			
			 onclick="SelectHi('DataGrid1',this,'Checkbox1');"
				
				
				var j1;
				var j;
				var str1="DataGrid1_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				   // document.getElementById("DataGrid1").rows[j].cells[7].childNodes[0].checked=true;
				if(objlist=="Checkbox1")
				{		 
				
				
			document.getElementById(str1).checked=false;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
			
				
			}  */
			
			
			
			
			
			



function  checkboxidnew()
{

var checkradio="";


//if(document.getElementById("billgen").checked ==true &&  document.getElementById("DataGrid1").rows[j].cells[0].innerHTML==)

if (document.getElementById("billprev").checked == true)
            {
                checkradio="1";
            }
            else
                if (document.getElementById("billgen").checked ==true)
                {
                    checkradio="2";
                }
                 else
                    if (document.getElementById("billreprint").checked ==true)
                    {
                        checkradio ="3";
                    }
                else
                {
                    checkradio ="4";
                }

//var checkradio=document.getElementById("hiddenradio").value;
if(checkradio=="4")
{
alert('please select altest once Billing type');
return false;
}
var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[7].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[7].innerHTML;
				
			}
				
				
				
				
			// ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
			//var insertion= 	document.getElementById("DataGrid1").rows[j].cells[2].innerHTML;
			//var edition=  document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
			j1=2;
			//bookaudit.updatestatus(ciobookid,insertion,edition);
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt);
				  
				   
				 
				 
				 

				 
				
				


}



/////


function  blankgrid()
{

if(document.getElementById('dpdadtype').value=='CL0')
{
var Classified=document.getElementById('hiddenclsbill').value;
if(Classified=='monthly')
{
document.getElementById("divmonth").style.display="block";
document.getElementById("divnew").style.display="none";
}
else
{
document.getElementById("divmonth").style.display="none";
document.getElementById("divnew").style.display="block";

}

}
if(document.getElementById('dpdadtype').value=='DI0')
{
var display=document.getElementById('hiddendisplaybill').value;

if(display=='monthly')
{
document.getElementById("divmonth").style.display="block";
document.getElementById("divnew").style.display="none";
}
else
{
document.getElementById("divmonth").style.display="none";
document.getElementById("divnew").style.display="block";
}

}
if(document.getElementById("DataGrid1")!=null)
{

document.getElementById("DataGrid1").outerText='';
return false;
}

if(document.getElementById("DataGrid2")!=null)
{

document.getElementById("DataGrid2").outerText='';
return false;
}


}


///////////


function SelectHi(grdid,obj,objlist)
			{ 		
			
			
				if(document.getElementById("DataGrid1_ctl01_Checkbox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid1_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				
				
				
				   
				if(objlist=="Checkbox4")
				{		 
				
				
				if(document.getElementById(str1).disabled==false)
				{
			document.getElementById(str1).checked=true;
			}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				 if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				//return false;
				
				
				}
				//return false;
				}
				else
				{ 
				var j1;
				var j;
				var str1="DataGrid1_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				
				
				   // document.getElementById("DataGrid1").rows[j].cells[7].childNodes[0].checked=true;
				if(objlist=="Checkbox4")
				{		 
				
				
			document.getElementById(str1).checked=false;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
				}
				
			}   
			
			
			
			
			
			/////for classified
			
			
			
			function SelectHiclass(grdid,obj,objlist)
			{ 		
			
			
				if(document.getElementById("DataGrid2_ctl01_Checkbox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid2_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
				{
				
				
				
				   
				if(objlist=="Checkbox4")
				{		 
				
				
				if(document.getElementById(str1).disabled==false)
				{
			document.getElementById(str1).checked=true;
			}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				 if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				//return false;
				
				
				}
				//return false;
				}
				else
				{ 
				var j1;
				var j;
				var str1="DataGrid2_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
				{
				
				
				   // document.getElementById("DataGrid1").rows[j].cells[7].childNodes[0].checked=true;
				if(objlist=="Checkbox4")
				{		 
				
				
			document.getElementById(str1).checked=false;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
				}
				
			}   
			
			
			
			
			
			
			





	function checklenthbillcla()
{

//document.getElementById('div1').style.display="none";


alert('Seaching criteria does not produce any result');

return false;



}



//////////////////new
	
	function  checkboxidbillgen()
{

var checkradio="2";


/////////////////////


var hiddenbillstatus="";
if(document.getElementById('dpdadtype').value=='CL0')
{
hiddenbillstatus=document.getElementById('hiddenclsbill').value;

}
if(document.getElementById('dpdadtype').value=='DI0')
{
hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


}



//////////

if(hiddenbillstatus=='insertionwise')
{

var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
				var j;
				
				
				var str1="DataGrid1_ctl02_Checkbox1";
				if(document.getElementById("DataGrid1")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}

else
{
                 for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)				
				 {                
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				if(ciobookid=="")
				{
				ciobookid=document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}
				else
				{
				ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= insertion+","+	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=edition+","+  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}					
		
			j1=2;	
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 
				 //window.open('invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
//				 if(checkradio==3)
//				 {
//				 
//				 window.open('testnew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
//				 }
//				 else
//				 {
var bill="Bill"
window.open(myurl+'invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition+'&bill='+bill);

//				 }
				  
				   
		}
		
		//////////////////////////////////////////////////////////////////////////////////////
		else
		if(hiddenbillstatus=='orderwisefirstins')
		
		{
		
		
		checkradio="firstsave";
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
			}		
				
				
				
			j1=2;
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				var bill="Bill"
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&bill='+bill);				  
				
				
		}
		
		/////////////////
		else
		if(document.getElementById("hiddenbillstatus").value=='monthly')
		{
		
		
		checkradio="2";
			
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
			}		
				
				
				
			j1=2;
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				var bill="Bill"
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&bill='+bill);				  
				
		}
		
		////////////////////////
		
		
			else
		if(hiddenbillstatus=='orderwiselastins')
		{
		
		checkradio="2";
		var edition;
		////////
				
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";



				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('dpdadtype').value;
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
			}		
				
				
				
			j1=2;
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 var bill="Bill"
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&bill='+bill);
				  
				   
				 
				 
				 
		
		///////
		
		
		
		
		} 
		
		////////
				 
	

}
///////////bill print

	function  checkboxidbillpreview()
{



var checkradio="1";

var hiddenbillstatus="";
if(document.getElementById('hiddenadtype').value=='CL0')
{
hiddenbillstatus=document.getElementById('hiddenclsbill').value;

}
if(document.getElementById('hiddenadtype').value=='DI0')
{
hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


}



////////////////////////////

//if(document.getElementById("hiddencheck").value!='CL0')
if(hiddenbillstatus=='insertionwise')
{

var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
				var j;
				
				
				var str1="DataGrid1_ctl02_Checkbox1";
				if(document.getElementById("DataGrid1")==null)
				{
				alert('please check atleast one id from grid' );
				return false;
				}

else
{
                 for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)				
				 {                
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				if(ciobookid=="")
				{
				ciobookid=document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}
				else
				{
				ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= insertion+","+	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=edition+","+  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}					
		
			j1=2;	
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 
				 //window.open('invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
//				 if(checkradio==3)
//				 {
//				 
//				 window.open('testnew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
//				 }
//				 else
//				 {
window.open(myurl+'invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);

//				 }
				  
				   
		}
		////////////////////////////////
		else
		if(hiddenbillstatus=='orderwisefirstins')
		
		{
		
		
		checkradio= "first";
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
			}		
				
				
				
			j1=2;
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client);
				  
				   
				 
				 
				 

				 
				
				
		}
				 
		/////////////////////////////		
		else
		if(hiddenbillstatus=='monthly')
		{
		
		checkradio="4";
		
		////////
				
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";



				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('dpdadtype').value;
				  
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
			}		
				
				
				
			j1=2;
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype);
				  
				   
				 
				 
				 
		
		///////
		
		
		
		
		} 
		
		/////////////////////////////
		
			else
		if(hiddenbillstatus=='orderwiselastins')
		{
		
		checkradio="1";
		var edition;
		////////
				
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";



				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('dpdadtype').value;
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
			}		
				
				
				
			j1=2;
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype);
				  
				   
				 
				 
				 
		
		///////
		
		
		
		
		} 
		
		
		
		
		
		///
				 

				 
				
				


}

///////////billreprint

	function  checkboxidbillreprint()
{

var checkradio="3";


/////////////

var hiddenbillstatus="";
if(document.getElementById('dpdadtype').value=='CL0')
{
hiddenbillstatus=document.getElementById('hiddenclsbill').value;

}
if(document.getElementById('dpdadtype').value=='DI0')
{
hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


}

//////////////////////////////////////////////////////////////////////////////////////////////////////////


if(hiddenbillstatus=='insertionwise')
{

var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
				var j;
				
				
				var str1="DataGrid1_ctl02_Checkbox1";
				if(document.getElementById("DataGrid1")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}

else
{
                 for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)				
				 {                
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				if(ciobookid=="")
				{
				ciobookid=document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}
				else
				{
				ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= insertion+","+	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=edition+","+  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}					
		
			j1=2;	
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 

				 window.open(myurl+'testnewsambad.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);


//				 }
				  
				   
		}
		
		///////////////////////////////////////////////////////////////////
		else
		if(hiddenbillstatus=='orderwisefirstins')
		
		{
		
		checkradio="first";
		
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
			}		
				
				
				
			j1=2;
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client);
				  
				   
				 
				 
				 

				 
				
				
		}
		///////////////////////////////////////////////////////////////////
		
		
		
			else
		if(hiddenbillstatus=='orderwiselastins')
		{
		
		checkradio="4";
		var edition;
		////////
				
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";



				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('dpdadtype').value;
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
			}		
				
				
				
			j1=2;
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype);
				  
				   
				 
				 
				 
		
		///////
		
		
		
		
		} 
		
		
		//////////////
				 
				 
				 

				 
				
				


}

