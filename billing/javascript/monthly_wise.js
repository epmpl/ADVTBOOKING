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
				  var  adtype=document.getElementById('hiddenadtype').value;
				  
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[4].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=ciobookid+"^"+document.getElementById("DataGrid2").rows[j].cells[4].innerHTML;
				
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
				 
				 hiddenbillstatus="monthlyclientwise";
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				// window.open('invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&hiddensession='+hiddenbillstatus);
				
				
					monthly_wise.setSessionmonthly_preview(ciobookid,checkradio,insertion,agencycode,dateto,frmdt,client,adtype,hiddenbillstatus);				 
                  window.open('invoice_classified.aspx');
			
				  
				   
				 
			
				 
		
		///////
		
		
		
	
		
		
		
		




}



	function  checkboxidbillgen1()
{

		
		
		
		checkradio="42";
			
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
				agencycode=document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[4].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=ciobookid+"^"+document.getElementById("DataGrid2").rows[j].cells[4].innerHTML;
				
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
				hiddenbillstatus="monthlyclientwise";
				
				
				
				monthly_wise.setSessionmonthly(ciobookid,checkradio,insertion,agencycode,dateto,frmdt,client,bill,hiddenbillstatus);				 
                  window.open('invoice_classified.aspx');
				 
				 //var win_=window.open('invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&bill='+bill+'&hiddensession='+hiddenbillstatus);				  
				 
			 
				
		


}

	function checkboxidbillgen() {

	    var checkradio = "2";


	    /////////////////////

	    
	    
	   

	    var hiddenbillstatus = "";
	    if (document.getElementById('hiddenadtype').value == "CL0") {
	        hiddenbillstatus = document.getElementById('hiddenclsbill').value;

	    }
	    if (document.getElementById('hiddenadtype').value == 'DI0') {
	        hiddenbillstatus = document.getElementById('hiddendisplaybill').value;


	    }



	    var publish = "";

	    var rborg = "";

	    var j1 = 1;
	    var i;
	    var ciobookid = "";
	    var insertion = "";
	    var edition = "";
	    var frmdt = "";
	    var dateto = "";
	    var client = "";
	    agencycode = "";
	    rborg = "1";

	    var j;


	    var str1 = "DataGrid2_ctl02_CheckBox1";
	    if (document.getElementById("DataGrid2") == null) {
	        alert('please check atleast  id from grid');
	        return false;
	    }

	    else {
	        for (j = 1; j < document.getElementById("DataGrid2").rows.length; j++) {


	            
	            if (document.getElementById(str1).checked == true) {

	                frmdt = document.getElementById('hiddenfromdate').value;
	                dateto = document.getElementById('hiddendateto').value;
	                client = document.getElementById('hiddenclient').value;
	                var adtype = document.getElementById('hiddenadtype').value;

	                if (ciobookid == "") {
	                    agencycode = document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
	                    ciobookid = document.getElementById("DataGrid2").rows[j].cells[4].innerHTML;
	                    edition = "";
	                    publish = "";

	                }
	                else {
	                    agencycode = agencycode + "," + document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
	                    ciobookid = ciobookid + "," + document.getElementById("DataGrid2").rows[j].cells[4].innerHTML;
	                    edition = edition + "," + "";
	                    publish = publish + "," + "";

	                }



	                j1 = 2;


	            }





	            var str2 = str1.split('_')[1]


	            var str3 = str2.split('l')[1]
	            var str4 = str2.split('l')[0]
	            str3 = str3
	            str3 = Number(str3) + 1;
	            if (str3 >= 10) {
	                str1 = "DataGrid2_ctl" + str3 + "_CheckBox1";
	            }
	            else {
	                str1 = "DataGrid2_ctl0" + str3 + "_CheckBox1";
	            }

            }

            if (j1 == 1) {
                alert('Please Select atlest one CheckBox for bill');
                return false;
            }


	    }
	    todate_v = document.getElementById("txtdate").value;
	   
	    hiddenbillstatus = "monthlyclientwise";

	    var status_bill = document.getElementById('gaubillstate').value;
	    var rate_audit = document.getElementById('gaurtaudit').value;


	    ////////////
	    // window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
	    var bill = "Bill"
	    var date = document.getElementById('txtdate').value;
	    var spl_dis = "";
	    var trade_dis = "";
	    checkradio = "firstsave";
	    monthly_wise.setSessionIns_gen(ciobookid, checkradio, insertion, dateto, frmdt, client, adtype, bill, hiddenbillstatus, todate_v, edition, spl_dis, trade_dis, todate_v, rborg);
	    window.open('order_wise_first_bill_generate.aspx');

	    //orderwise_first.setSessionfirst(ciobookid, checkradio, insertion, edition, agencycode, dateto, frmdt, client, bill, date, rborg)
	    // window.open(myurl + 'invoice_classified.aspx?ciobookid=' + ciobookid + '&checkradio=' + checkradio + '&insertion=' + insertion + '&agencycode=' + agencycode + '&dateto=' + dateto + '&frmdt=' + frmdt + '&client=' + client + '&bill=' + bill);

	    return false;

	}

	function  checkboxidbillreprint1()
{


	
		checkradio="42";
		
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
				
				
				var str1="DataGrid2_ctl02_CheckBox1";
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
				invoice_no=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				agencycode=document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[3].innerHTML;
				
				}
				else
				{
				invoice_no=invoice_no+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=ciobookid+"^"+document.getElementById("DataGrid2").rows[j].cells[3].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_CheckBox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 
				 hiddenbillstatus="monthlyclientwise";
				 //window.open('classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&invoice_no='+invoice_no+'&hiddensession='+hiddenbillstatus);
				  
				  
				  
				  	monthly_wise.setSessionmonthly_pr(ciobookid,checkradio,insertion,agencycode,dateto,frmdt,client,invoice_no,hiddenbillstatus);				 
                  window.open('classifiednew.aspx');
			 
				 
				 
				 

				 
				
				
	

	}

	function checkboxidbillreprint() {





	    checkradio = "first";
	  
	    var j1 = 1;
	    var i;
	    var ciobookid = "";
	    var insertion = "";
	    var edition = "";
	    var frmdt = "";
	    var dateto = "";
	    var client = "";
	    agencycode = "";
	    var invoice_no = "";

	    var j;




	    var str1 = "DataGrid2_ctl02_CheckBox1";
	    if (document.getElementById("DataGrid2") == null) {
	        alert('please check atleast  id from grid');
	        return false;
	    }


	    else {
	        for (j = 1; j < document.getElementById("DataGrid2").rows.length; j++) {


	            
	            if (document.getElementById(str1).checked == true) {

	                frmdt = document.getElementById('hiddenfromdate').value;
	                dateto = document.getElementById('hiddendateto').value;
	                client = document.getElementById('hiddenclient').value;
	                var adtype = document.getElementById('hiddenadtype').value;

	                if (agencycode == "") {
	                    agencycode = document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
	                    ciobookid = document.getElementById("DataGrid2").rows[j].cells[3].innerHTML;
	                    invoice_no = document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;

	                }
	                else {
	                    agencycode = agencycode + "," + document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
	                    ciobookid = ciobookid + "," + document.getElementById("DataGrid2").rows[j].cells[3].innerHTML;
	                    invoice_no = invoice_no + "," + document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
	                }



	                j1 = 2;


	            }




	            var str2 = str1.split('_')[1]


	            var str3 = str2.split('l')[1]
	            var str4 = str2.split('l')[0]
	            str3 = str3
	            str3 = Number(str3) + 1;
	            if (str3 >= 10) {
	                str1 = "DataGrid2_ctl" + str3 + "_CheckBox1";
	            }
	            else {
	                str1 = "DataGrid2_ctl0" + str3 + "_CheckBox1";
	            }

	        }

	        if (j1 == 1) {
	            alert('Please Select atlest one CheckBox for bill');
	            return false;
	        }


	    }
	    hiddenbillstatus = "orderwiselastins";
	    ////////////
	    monthly_wise.setSessionlast(ciobookid, checkradio, insertion, edition, agencycode, dateto, frmdt, client, adtype, invoice_no, hiddenbillstatus);
	    // window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
	    // orderwise_first.setSessionfirstpr(ciobookid, checkradio, insertion, agencycode, dateto, frmdt, client, invoice_no)
	    //window.open(myurl+'classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client);

	    window.open('classifiednew.aspx');

	    return false;








	}




function openbooking(cioid)
{
if(cioid==" ")
{
alert('there are no unaudited bookings');
}
else
{
window.open('showunaudit.aspx?ciobookid='+cioid);
}
//window.open('classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&invoice_no='+invoice_no);

}


function fnUnloadHandler()
//function fnUnloadHandler(event.keyCode)
{   
//alert(event.keyCode);
//if(event.keyCode != 116)
//{
    //===============you can write ur code here==============
    window.close();
       window.open('billing.aspx');
       
//}
}


//function gaurav(event)
//{
//alert (event.keyCode);
//if(event.keyCode != 116)
//{
// 
//return false;
//}
//}


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
			
			
			
			
			
			
			function  printpdf()
{


	
		checkradio="42";
		
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
				
				
				if(agencycode=="")
				{
				invoice_no=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				agencycode=document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[3].innerHTML;
				
				}
				else
				{
				invoice_no=invoice_no+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=ciobookid+"^"+document.getElementById("DataGrid2").rows[j].cells[3].innerHTML;
				
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
				 
				 
				 hiddenbillstatus="monthlyclientwise";
				 //window.open('classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&invoice_no='+invoice_no+'&hiddensession='+hiddenbillstatus);
				  
				  
				  
				  	monthly_wise.setSessionmonthly_pr(ciobookid,checkradio,insertion,agencycode,dateto,frmdt,client,invoice_no,hiddenbillstatus);				 
                  window.open('pdf.aspx');
			 
				 
				 
				 

				 
				
				
	

}




	function  checkboxidbillreprint_cover()
{


	
		checkradio="42";
		
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
				
				
				if(agencycode=="")
				{
				invoice_no=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				agencycode=document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[3].innerHTML;
				
				}
				else
				{
				invoice_no=invoice_no+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[1].innerHTML;
				ciobookid=ciobookid+"^"+document.getElementById("DataGrid2").rows[j].cells[3].innerHTML;
				
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
				 
				 
				 hiddenbillstatus="monthlyclientwise";
				 //window.open('classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&invoice_no='+invoice_no+'&hiddensession='+hiddenbillstatus);
				  
				  
				  
				  	monthly_wise.setSessionmonthly_cover(ciobookid,checkradio,insertion,agencycode,dateto,frmdt,client,invoice_no,hiddenbillstatus);				 
                  window.open('cover_letter.aspx');
			 
				 
				 
				 

				 
				
				
	

}