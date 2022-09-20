// JScript File



var test="1";
var myurl=document.URLUnencoded.split("/");
	            myurl=myurl[0]+"/"+myurl[1]+"/"+myurl[2]+"/"+myurl[3]+"/"+"billing"+"/"

function checkvisiblecla()
{
//document.getElementById('div1').style.display="block";


}



	function checklenthbillcla()
{

//document.getElementById('div1').style.display="none";


alert('Seaching criteria does not produce any result');

return false;



}

	function  checkboxidbillpreview()
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
				 
				 window.open(myurl+'invoice_cls_supp.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client);
				  
				   
				 
				 
				 

				 
				
				
	
}















	function  checkboxidbillgen()
{

var checkradio="2";


/////////////////////


var hiddenbillstatus="";


		
		
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
				 
				 window.open(myurl+'invoice_cls_supp.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&bill='+bill);				  
				
				
		
		}
		
		
		
		
		
		
			function  checkboxidbillreprint()
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

var invoice_no="";


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
				invoice_no=document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
					invoice_no=invoice_no+","+document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
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
				 
				 window.open(myurl+'clasifiednew_supp.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&invoice_no='+invoice_no);
				  
				   
				 
				 
				 

				 
				
				
		}
		
		
		
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
			
			
			
			
			function fnUnloadHandler()

{   
    window.close();
       window.open('revised_bill.aspx');

}

