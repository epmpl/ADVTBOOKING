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
		
		checkradio="5";
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
				
				
				var str1="DataGrid3_ctl02_CheckBox1";
				if(document.getElementById("DataGrid3")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid3").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('hiddenadtype').value;
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid3_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid3_ctl0"+str3+"_CheckBox1";
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
				 hiddenbillstatus="orderwiselastins";
				// window.open('invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&hiddensession='+hiddenbillstatus);
				  
				   orderwise_last.setSessionlast_priev(ciobookid,checkradio,insertion,agencycode,dateto,frmdt,client,adtype,hiddenbillstatus);				 
                  window.open('invoice_classified.aspx');
				  
				 
				 
				 
			
		
		
		
	
		
		}
		
		
		
		
		
			function  checkboxidbillgen1()
{
		
		
		
		
		
		
		
		
		
		checkradio="6";
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
				
				
				var str1="DataGrid3_ctl02_CheckBox1";
				if(document.getElementById("DataGrid3")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid3").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('hiddenadtype').value;
				  
				
				
				if(ciobookid=="")
				{
				
			
				ciobookid=document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				agencycode=document.getElementById("DataGrid3").rows[j].cells[1].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid3").rows[j].cells[3].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				
				
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
				str1="DataGrid3_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid3_ctl0"+str3+"_CheckBox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 hiddenbillstatus="orderwiselastins";
				 
				 var status_bill= document.getElementById('gaubillstate').value;
				  var rate_audit=document.getElementById('gaurtaudit').value;
				 
				 
				 
				 
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				
				
				if((status_bill=="5"&& rate_audit=="y")||(status_bill=="3"&& rate_audit=="y")||(status_bill=="3"&& rate_audit=="y"))
				{
				
				var bill="Bill"
				// win_=window.open('invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&bill='+bill+'&hiddensession='+hiddenbillstatus);
				  
				  
				
                      //  alert("Your bill has been generated")
                       // win_.close();
               
                  
                  
                  
                  orderwise_last.setSessionlast_pr(ciobookid,checkradio,insertion,agencycode,dateto,frmdt,client,adtype,bill,hiddenbillstatus);				 
                  window.open('invoice_classified.aspx');
				
				   
				 
				 
				 }
				 else
				 
				 {
				 alert("bills can not be processed for an UnAudited Booking")
                     
				 }
		
	
		
		
		
		
	
		
		}
		
		//************************new add  by diksha

		function checkboxidbillgen() {

		    var checkradio = "6";

		
		    var hiddenbillstatus = "";
		    if (document.getElementById('hiddenadtype').value == "CL0") {
		        hiddenbillstatus = document.getElementById('hiddenclsbill').value;

		    }
		    if (document.getElementById('hiddenadtype').value == 'DI0') {
		        hiddenbillstatus = document.getElementById('hiddendisplaybill').value;


		    }


		    var j1 = 1;
		    var i;
		    var ciobookid = "";
		    var insertion = "";
		    var edition = "";
		    var publish = "";
		    var spl_dis = "";
		    var trade_dis = "";
		    var rborg = "";

		    var frmdt = "";
		    var dateto = "";
		    var client = "";
		    agencycode = "";

		    if (document.getElementById('rboriginal').checked == true) {
		        rborg = "0";
		    }
		    else {
		        rborg = "1";
		    }
		    var j;


		   var str1="DataGrid3_ctl02_CheckBox1";
				if(document.getElementById("DataGrid3")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}

		    else {
		        for (j = 1; j < document.getElementById("DataGrid3").rows.length; j++) {



		            if (document.getElementById(str1).checked == true) {

		                frmdt = document.getElementById('hiddenfromdate').value;
		                dateto = document.getElementById('hiddendateto').value;
		                client = document.getElementById('hiddenclient').value;
		                var adtype = document.getElementById('hiddenadtype').value;
		                if (ciobookid == "") {
		                    ciobookid = document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
		                    insertion = document.getElementById("DataGrid3").rows[j].cells[5].innerHTML;
		                    edition = "";
		                    publish = "";

//		                    if (document.getElementById(str21).checked == true) {
//		                        spl_dis = "1";
//		                    }
//		                    else {
//		                        spl_dis = "0";
//		                    }

//		                    if (document.getElementById(str31).checked == true) {
//		                        trade_dis = "1";
//		                    }
//		                    else {
//		                        trade_dis = "0";
//		                    }
		                }
		                else {
		                    ciobookid = ciobookid + "," + document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
		                    insertion = insertion + "," + document.getElementById("DataGrid3").rows[j].cells[5].innerHTML;
		                    edition = edition + "," + "";
		                    publish = publish + "," +"";

//		                    if (document.getElementById(str21).checked == true) {
//		                        spl_dis = spl_dis + "," + "1";
//		                    }
//		                    else {
//		                        spl_dis = spl_dis + "," + "0";
//		                    }

//		                    if (document.getElementById(str31).checked == true) {
//		                        trade_dis = trade_dis + "," + "1";
//		                    }
//		                    else {
//		                        trade_dis = trade_dis + "," + "0";
//		                    }
		                }

		                j1 = 2;


		            }




		            var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid3_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid3_ctl0"+str3+"_CheckBox1";
				 }

		        }

		        if (j1 == 1) {
		            alert('Please Select atlest one CheckBox for bill');
		            return false;
		        }


		    }



		    todate_v = document.getElementById("gautodate").value;
 hiddenbillstatus="orderwiselastins";
				 
				 var status_bill= document.getElementById('gaubillstate').value;
				  var rate_audit=document.getElementById('gaurtaudit').value;

		    var bill = "Bill"

		    //insertion_wise.setSession(ciobookid, checkradio, insertion, edition, bill, spl_dis, trade_dis, todate_v, rborg);
		    orderwise_last.setSessionIns_gen(ciobookid, checkradio, insertion, dateto, frmdt, client, adtype, bill, hiddenbillstatus, todate_v, edition, spl_dis, trade_dis, todate_v, rborg);
		    window.open('order_wise_bill_generate.aspx');
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
			function  checkboxidbillreprint()
{

	
		
		
		checkradio="7";
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
var bill_no="";
agencycode="";
	 var invoice_no="";



				var j;
				
				
				var str1="DataGrid3_ctl02_CheckBox1";
				if(document.getElementById("DataGrid3")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid3").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('hiddenadtype').value;
				  
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				invoice_no=document.getElementById("DataGrid3").rows[j].cells[1].innerHTML;
				
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				invoice_no=invoice_no+","+document.getElementById("DataGrid3").rows[j].cells[1].innerHTML;
				
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
				str1="DataGrid3_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid3_ctl0"+str3+"_CheckBox1";
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
			
			 hiddenbillstatus="orderwiselastins";
				// window.open('classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&invoice_no='+invoice_no+'&hiddensession='+hiddenbillstatus);
				  
				orderwise_last.setSessionlast(ciobookid,checkradio,insertion,edition,agencycode,dateto,frmdt,client,adtype,invoice_no,hiddenbillstatus);				 
                 window.open('classifiednew.aspx');
                 
				
				 
				 
				 
		
		///////
		
		
		
		
	


}


function fnUnloadHandler()

{   
    window.close();
       window.open('billing.aspx');

}



	function SelectHILAST(grdid,obj,objlist)
			{ 		
			
			
				if(document.getElementById("DataGrid3_ctl01_Checkbox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid3_ctl02_CheckBox1";
				for(j=1;j<document.getElementById("DataGrid3").rows.length;j++)
				
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
				str1="DataGrid3_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid3_ctl0"+str3+"_CheckBox1";
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
				var str1="DataGrid3_ctl02_CheckBox1";
				for(j=1;j<document.getElementById("DataGrid3").rows.length;j++)
				
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
				str1="DataGrid3_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid3_ctl0"+str3+"_CheckBox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
				}
				
			}   
			
			
			function openbilling()
			{
                var dtformat=document.getElementById('gaudtformat').value
                var todate=document.getElementById('gautodate').value
                var fromdt=document.getElementById('gaufromdt').value
                var pub=document.getElementById('gaupub').value
                var bkcen=document.getElementById('gaubkcen').value
                var rev=document.getElementById('gaurev').value
                var agtype=document.getElementById('gauagtype').value
                var pckg=document.getElementById('gaupckg').value
                var adtyp=document.getElementById('gauadtyp').value
                var ag=document.getElementById('gauag').value
                var client=document.getElementById('gauclient').value
                var billstate=document.getElementById('gaubillstate').value
               
                var rtaudit= document.getElementById('gaurtaudit').value
                var blmod=document.getElementById('gaublmod').value
                
                var blcycle=document.getElementById('gaublcycle').value
                
                window.open('bill_summary_last.aspx?dtformat=' + dtformat + '&todate=' + todate + '&fromdt=' + fromdt + '&pub=' + pub + '&bkcen=' + bkcen + '&rev=' + rev + '&agtype=' + agtype + '&pckg=' + pckg + '&adtyp=' + adtyp + '&ag=' + ag + '&client=' + client + '&billstate=' + billstate + '&rtaudit=' + rtaudit + '&blmod=' + blmod + '&blcycle=' + blcycle);

			}
			
			
			
			
				
			function  printpdf()
{

	
		
		
		checkradio="7";
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
var bill_no="";
agencycode="";
	 var invoice_no="";



				var j;
				
				
				var str1="DataGrid3_ctl02_Checkbox1";
				if(document.getElementById("DataGrid3")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid3").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('hiddenadtype').value;
				  
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				invoice_no=document.getElementById("DataGrid3").rows[j].cells[1].innerHTML;
				
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				invoice_no=invoice_no+","+document.getElementById("DataGrid3").rows[j].cells[1].innerHTML;
				
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
				str1="DataGrid3_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid3_ctl0"+str3+"_Checkbox1";
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
			
			 hiddenbillstatus="orderwiselastins";
				// window.open('classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&invoice_no='+invoice_no+'&hiddensession='+hiddenbillstatus);
				  
				orderwise_last.setSessionlast(ciobookid,checkradio,insertion,edition,agencycode,dateto,frmdt,client,adtype,invoice_no,hiddenbillstatus);				 
                 //window.open('classifiednew.aspx');
                 window.open('PDF.ASPX');
				
				 
				 
				 
		
		///////
		
		
		
		
	


}



/*
			function  printpdf()
{

	
		
		
		checkradio="7";
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
var bill_no="";
agencycode="";
	 var invoice_no="";



				var j;
				
				
				var str1="DataGrid3_ctl02_Checkbox1";
				if(document.getElementById("DataGrid3")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid3").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('hiddenadtype').value;
				  
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				invoice_no=document.getElementById("DataGrid3").rows[j].cells[1].innerHTML;
				
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				invoice_no=invoice_no+","+document.getElementById("DataGrid3").rows[j].cells[1].innerHTML;
				
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
				str1="DataGrid3_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid3_ctl0"+str3+"_Checkbox1";
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
			
			 hiddenbillstatus="orderwiselastins";
				// window.open('classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&invoice_no='+invoice_no+'&hiddensession='+hiddenbillstatus);
				  
				orderwise_last.setSessionlast(ciobookid,checkradio,insertion,edition,agencycode,dateto,frmdt,client,adtype,invoice_no,hiddenbillstatus);				 
                 window.open('classifiednew.aspx');
                 
				
				 
				 
				 
		
		///////
		
		
		
		
	


}

*/



		function  printletter()
{

	
		
		
		checkradio="7";
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
var bill_no="";
agencycode="";
	 var invoice_no="";



				var j;
				
				
				var str1="DataGrid3_ctl02_Checkbox1";
				if(document.getElementById("DataGrid3")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid3").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('hiddenadtype').value;
				  
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				invoice_no=document.getElementById("DataGrid3").rows[j].cells[1].innerHTML;
				
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid3").rows[j].cells[2].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid3").rows[j].cells[0].innerHTML;
				invoice_no=invoice_no+","+document.getElementById("DataGrid3").rows[j].cells[1].innerHTML;
				
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
				str1="DataGrid3_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid3_ctl0"+str3+"_Checkbox1";
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
			
			 hiddenbillstatus="orderwiselastins";
				// window.open('classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&invoice_no='+invoice_no+'&hiddensession='+hiddenbillstatus);
				  
				
				orderwise_last.setSessionlast_cover(ciobookid,checkradio,insertion,edition,agencycode,dateto,frmdt,client,adtype,invoice_no,hiddenbillstatus);				 
                 window.open('cover_letter.aspx');
				 
				 
				 
		
		///////
		
		
		
		
	


}