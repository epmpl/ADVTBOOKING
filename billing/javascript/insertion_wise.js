// JScript File


var test="1";
//var myurl=document.URLUnencoded.split("/");
	            //myurl=myurl[0]+"/"+myurl[1]+"/"+myurl[2]+"/"+myurl[3]+"/"+"billing"+"/"
	          


		function  checkboxidbillpreview()
{



var checkradio="1";

var hiddenbillstatus="";
if(document.getElementById('hiddenadtype').value=="CL0")
{
hiddenbillstatus=document.getElementById('hiddenclsbill').value;

}
if(document.getElementById('hiddenadtype').value=='DI0')
{
hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


}



////////////////////////////

//if(document.getElementById("hiddencheck").value!='CL0')


var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition = "";
var spl_dis = "";
var trade_dis = "";
var rborg="";

    if(document.getElementById('rboriginal').checked==true)
     {
        rborg=  "0";
     }
     else
     {
        rborg=  "1";
     }
				var j;


				var str1 = "DataGrid1_ctl02_CheckBox1";
				var str21 = "DataGrid1_ctl02_CheckBox2";
				var str31 = "DataGrid1_ctl02_CheckBox3";
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
				 edition = document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				     if (document.getElementById(str21).checked == true) {
				         spl_dis = "1";
				     }
				     else {
				         spl_dis = "0";
				     }

				     if (document.getElementById(str31).checked == true) {
				         trade_dis = "1";
				     }
				     else {
				         trade_dis = "0";
				     }
				}
				else
				{
				ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= insertion+","+	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition = edition + "," + document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;

				 if (document.getElementById(str21).checked == true) {
				     spl_dis = spl_dis + "," + "1";
				 }
				 else {
				     spl_dis = spl_dis + "," + "0";
				 }

				 if (document.getElementById(str31).checked == true) {
				     trade_dis = trade_dis + "," + "1";
				 }
				 else {
				     trade_dis = trade_dis + "," + "0";
				 }
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
				    str1 = "DataGrid1_ctl" + str3 + "_CheckBox1";
				    str21 = "DataGrid1_ctl" + str3 + "_CheckBox2";
				    str31 = "DataGrid1_ctl" + str3 + "_CheckBox3";
				}
				else
				{
				    str1 = "DataGrid1_ctl0" + str3 + "_CheckBox1";
				    str21 = "DataGrid1_ctl0" + str3 + "_CheckBox2";
				    str31 = "DataGrid1_ctl0" + str3 + "_CheckBox3";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }



				 insertion_wise.setSession_preview(ciobookid, checkradio, insertion, edition, spl_dis, trade_dis,rborg);
window.open('invoice_package.aspx');				 

//window.open(myurl+'invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);


				  
				   
		
		
		}










		function checkboxidbillgen() 
		{

		    var checkradio = "2";

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


		    var str1 = "DataGrid1_ctl02_CheckBox1";
		    var str21 = "DataGrid1_ctl02_CheckBox2";
		    var str31 = "DataGrid1_ctl02_CheckBox3";
		    if (document.getElementById("DataGrid1") == null) {
		        alert('please check atleast  id from grid');
		        return false;
		    }

		    else {
		        for (j = 1; j < document.getElementById("DataGrid1").rows.length; j++) {



		            if (document.getElementById(str1).checked == true) {

		                frmdt = document.getElementById('hiddenfromdate').value;
		                dateto = document.getElementById('hiddendateto').value;
		                client = document.getElementById('hiddenclient').value;
		                var adtype = document.getElementById('hiddenadtype').value;
		                if (ciobookid == "") {
		                    ciobookid = document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
		                    insertion = document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
		                    edition = document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
		                    publish = document.getElementById("DataGrid1").rows[j].cells[11].innerHTML;

		                    if (document.getElementById(str21).checked == true) {
		                        spl_dis = "1";
		                    }
		                    else {
		                        spl_dis = "0";
		                    }

		                    if (document.getElementById(str31).checked == true) {
		                        trade_dis = "1";
		                    }
		                    else {
		                        trade_dis = "0";
		                    }
		                }
		                else {
		                    ciobookid = ciobookid + "," + document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
		                    insertion = insertion + "," + document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
		                    edition = edition + "," + document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
		                    publish = publish + "," + document.getElementById("DataGrid1").rows[j].cells[11].innerHTML;

		                    if (document.getElementById(str21).checked == true) {
		                        spl_dis = spl_dis + "," + "1";
		                    }
		                    else {
		                        spl_dis = spl_dis + "," + "0";
		                    }

		                    if (document.getElementById(str31).checked == true) {
		                        trade_dis = trade_dis + "," + "1";
		                    }
		                    else {
		                        trade_dis = trade_dis + "," + "0";
		                    }
		                }

		                j1 = 2;


		            }




		            var str2 = str1.split('_')[1]


		            var str3 = str2.split('l')[1]
		            var str4 = str2.split('l')[0]
		            str3 = str3
		            str3 = Number(str3) + 1;
		            if (str3 >= 10) {
		                str1 = "DataGrid1_ctl" + str3 + "_CheckBox1";
		                str21 = "DataGrid1_ctl" + str3 + "_CheckBox2";
		                str31 = "DataGrid1_ctl" + str3 + "_CheckBox3";
		            }
		            else {
		                str1 = "DataGrid1_ctl0" + str3 + "_CheckBox1";
		                str21 = "DataGrid1_ctl0" + str3 + "_CheckBox2";
		                str31 = "DataGrid1_ctl0" + str3 + "_CheckBox3";
		            }

		        }

		        if (j1 == 1) {
		            alert('Please Select atlest one CheckBox for bill');
		            return false;
		        }


		    }



		    todate_v = document.getElementById("txtdate").value;
		    //var billdate = document.getElementById("txtdate").value;

		    var bill = "Bill"

		    //insertion_wise.setSession(ciobookid, checkradio, insertion, edition, bill, spl_dis, trade_dis, todate_v, rborg);
		    insertion_wise.setSessionIns_gen(ciobookid, checkradio, insertion, dateto, frmdt, client, adtype, bill, hiddenbillstatus, todate_v, edition, spl_dis, trade_dis, todate_v, rborg);
		    window.open('insertion_wise_bill_generate.aspx');
		}
		
		
		
		
		
		
		
		
		
		




	
	function  checkboxidbillgenold()//chnages done by diksha on 05/11/2014
{

var checkradio="2";


/////////////////////


var hiddenbillstatus="";
if(document.getElementById('hiddenadtype').value=="CL0")
{
hiddenbillstatus=document.getElementById('hiddenclsbill').value;

}
if(document.getElementById('hiddenadtype').value=='DI0')
{
hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


}



//////////



var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var publish = "";
var spl_dis = "";
var trade_dis = "";
var rborg="";

    if(document.getElementById('rboriginal').checked==true)
     {
        rborg=  "0";
     }
     else
     {
        rborg=  "1";
     }
				var j;


				var str1 = "DataGrid1_ctl02_CheckBox1";
				var str21 = "DataGrid1_ctl02_CheckBox2";
				var str31 = "DataGrid1_ctl02_CheckBox3";
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
				 publish = document.getElementById("DataGrid1").rows[j].cells[11].innerHTML;

				     if (document.getElementById(str21).checked == true) {
				         spl_dis = "1";
				     }
				     else {
				         spl_dis = "0";
				     }

				     if (document.getElementById(str31).checked == true) {
				         trade_dis = "1";
				     }
				     else {
				         trade_dis = "0";
				     }
				}
				else
				{
				ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= insertion+","+	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=edition+","+  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				 publish = publish + "," + document.getElementById("DataGrid1").rows[j].cells[11].innerHTML;

				     if (document.getElementById(str21).checked == true) {
				         spl_dis = spl_dis + "," + "1";
				     }
				     else {
				         spl_dis = spl_dis + "," + "0";
				     }

				     if (document.getElementById(str31).checked == true) {
				         trade_dis = trade_dis + "," + "1";
				     }
				     else {
				         trade_dis = trade_dis + "," + "0";
				     }
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
				    str1 = "DataGrid1_ctl" + str3 + "_CheckBox1";
				    str21 = "DataGrid1_ctl" + str3 + "_CheckBox2";
				    str31 = "DataGrid1_ctl" + str3 + "_CheckBox3";
				}
				else
				{
				    str1 = "DataGrid1_ctl0" + str3 + "_CheckBox1";
				    str21 = "DataGrid1_ctl0" + str3 + "_CheckBox2";
				    str31 = "DataGrid1_ctl0" + str3 + "_CheckBox3";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 

todate_v=document.getElementById("hiddentdate").value;


var bill="Bill"

insertion_wise.setSession(ciobookid, checkradio, insertion, edition, bill, spl_dis, trade_dis, todate_v, rborg);
//billing_insertion_wise_bill_generate
/*//to enter in temp table
if(document.getElementById('hiddenbillcycle').value=="2" || document.getElementById('hiddenbillcycle').value=="3" || document.getElementById('hiddenbillcycle').value=="4" ||document.getElementById('hiddenbillcycle').value=="5")
{
    insertion_wise.settempdata(ciobookid,publish,insertion,document.getElementById('hiddenbillcycle').value,document.getElementById('hiddenfdate').value,document.getElementById('hiddentdate').value);
}
if(document.getElementById('hiddenbillcycle').value=="2" || document.getElementById('hiddenbillcycle').value=="3" || document.getElementById('hiddenbillcycle').value=="4" ||document.getElementById('hiddenbillcycle').value=="5")
{
    insertion_wise.billpross(document.getElementById('hiddenbillcycle').value,document.getElementById('hiddenfdate').value,document.getElementById('hiddentdate').value,document.getElementById('hiddenadtype').value);
}
else
{
//to bill generate
window.open('invoice_package.aspx');
}


//var win_=window.open(myurl+'invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition+'&bill='+bill);

//alert("Your bill has been generated")
//win_.close();
                       
                       */


				  
				   
		
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		/////////////////////
		
		function  checkboxidbillreprint()
{

var checkradio="3";


/////////////

var hiddenbillstatus="";
if(document.getElementById('hiddenadtype').value=="CL0")
{
hiddenbillstatus=document.getElementById('hiddenclsbill').value;

}
if(document.getElementById('hiddenadtype').value=='DI0')
{
hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


}

//////////////////////////////////////////////////////////////////////////////////////////////////////////



var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var invoice_no="";
var spl_dis="";
var trade_dis="";
var rborg="";

    if(document.getElementById('rboriginal').checked==true)
     {
        rborg=  "0";
     }
     else
     {
        rborg=  "1";
     }

				var j;
				
				
				var str1="DataGrid1_ctl02_CheckBox1";
				var str21="DataGrid1_ctl02_CheckBox2";
				var str31="DataGrid1_ctl02_CheckBox3";
				
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
				invoice_no=document.getElementById("DataGrid1").rows[j].cells[1].innerHTML;
				 insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				 
				     if(document.getElementById(str21).checked==true)
				     {
				        spl_dis=  "1";
				     }
				     else
				     {
				        spl_dis=  "0";
				     }
				     
				     if(document.getElementById(str31).checked==true)
				     {
				        trade_dis=  "1";
				     }
				     else
				     {
				        trade_dis=  "0";
				     }
				}
				else
				{
				ciobookid= ciobookid+","+document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				invoice_no=invoice_no+","+document.getElementById("DataGrid1").rows[j].cells[1].innerHTML;
				 insertion= insertion+","+	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=edition+","+  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				 
    				 if(document.getElementById(str21).checked==true)
				     {
				        spl_dis= spl_dis+","+ "1";
				     }
				     else
				     {
				        spl_dis= spl_dis+","+ "0";
				     }
				     
				     if(document.getElementById(str31).checked==true)
				     {
				        trade_dis= trade_dis+","+ "1";
				     }
				     else
				     {
				        trade_dis=  trade_dis+","+ "0";
				     }
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
				str1="DataGrid1_ctl"+str3+"_CheckBox1";
				str21="DataGrid1_ctl"+str3+"_CheckBox2";
				str31="DataGrid1_ctl"+str3+"_CheckBox3";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
				 str21="DataGrid1_ctl0"+str3+"_CheckBox2";
				 str31="DataGrid1_ctl0"+str3+"_CheckBox3";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 
				  insertion_wise.setSessionre(ciobookid,checkradio,insertion,edition,invoice_no,spl_dis,trade_dis,rborg);				 
                  //window.open('testnewsambad.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition+'&invoice='+invoice_no);
				  window.open('testnewsambad.aspx');

			//	 window.open(myurl+'testnewsambad.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition+'&invoice='+invoice_no);


				  return false;
				  
				   
	
		}


		function checkboxidbillreprintforgov() {

		    var checkradio = "3";


		    /////////////

		    var hiddenbillstatus = "";
		    if (document.getElementById('hiddenadtype').value == "CL0") {
		        hiddenbillstatus = document.getElementById('hiddenclsbill').value;

		    }
		    if (document.getElementById('hiddenadtype').value == 'DI0') {
		        hiddenbillstatus = document.getElementById('hiddendisplaybill').value;


		    }

		    //////////////////////////////////////////////////////////////////////////////////////////////////////////



		    var j1 = 1;
		    var i;
		    var ciobookid = "";
		    var insertion = "";
		    var edition = "";
		    var invoice_no = "";
		    var spl_dis = "";
		    var trade_dis = "";
		    var rborg = "";

		    if (document.getElementById('rboriginal').checked == true) {
		        rborg = "0";
		    }
		    else {
		        rborg = "1";
		    }

		    var j;


		    var str1 = "DataGrid1_ctl02_CheckBox1";
		    var str21 = "DataGrid1_ctl02_CheckBox2";
		    var str31 = "DataGrid1_ctl02_CheckBox3";

		    if (document.getElementById("DataGrid1") == null) {
		        alert('please check atleast  id from grid');
		        return false;
		    }

		    else {
		        for (j = 1; j < document.getElementById("DataGrid1").rows.length; j++) {



		            if (document.getElementById(str1).checked == true) {
		                if (ciobookid == "") {
		                    ciobookid = document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
		                    invoice_no = document.getElementById("DataGrid1").rows[j].cells[1].innerHTML;
		                    insertion = document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
		                    edition = document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;

		                    if (document.getElementById(str21).checked == true) {
		                        spl_dis = "1";
		                    }
		                    else {
		                        spl_dis = "0";
		                    }

		                    if (document.getElementById(str31).checked == true) {
		                        trade_dis = "1";
		                    }
		                    else {
		                        trade_dis = "0";
		                    }
		                }
		                else {
		                    ciobookid = ciobookid + "," + document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
		                    invoice_no = invoice_no + "," + document.getElementById("DataGrid1").rows[j].cells[1].innerHTML;
		                    insertion = insertion + "," + document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
		                    edition = edition + "," + document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;

		                    if (document.getElementById(str21).checked == true) {
		                        spl_dis = spl_dis + "," + "1";
		                    }
		                    else {
		                        spl_dis = spl_dis + "," + "0";
		                    }

		                    if (document.getElementById(str31).checked == true) {
		                        trade_dis = trade_dis + "," + "1";
		                    }
		                    else {
		                        trade_dis = trade_dis + "," + "0";
		                    }
		                }

		                j1 = 2;


		            }




		            var str2 = str1.split('_')[1]


		            var str3 = str2.split('l')[1]
		            var str4 = str2.split('l')[0]
		            str3 = str3
		            str3 = Number(str3) + 1;
		            if (str3 >= 10) {
		                str1 = "DataGrid1_ctl" + str3 + "_CheckBox1";
		                str21 = "DataGrid1_ctl" + str3 + "_CheckBox2";
		                str31 = "DataGrid1_ctl" + str3 + "_CheckBox3";
		            }
		            else {
		                str1 = "DataGrid1_ctl0" + str3 + "_CheckBox1";
		                str21 = "DataGrid1_ctl0" + str3 + "_CheckBox2";
		                str31 = "DataGrid1_ctl0" + str3 + "_CheckBox3";
		            }

		        }

		        if (j1 == 1) {
		            alert('Please Select atlest one CheckBox for bill');
		            return false;
		        }


		    }


		    insertion_wise.setSessionre(ciobookid, checkradio, insertion, edition, invoice_no, spl_dis, trade_dis, rborg);
		    //window.open('testnewsambadfrgov.aspx?ciobookid=' + ciobookid + '&checkradio=' + checkradio + '&insertion=' + insertion + '&edition=' + edition + '&invoice=' + invoice_no);
		    window.open('testnewsambadfrgov.aspx');
		    return false;


		    //	 window.open(myurl+'testnewsambad.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition+'&invoice='+invoice_no);






		}




			function SelectHiclass(grdid,obj,objlist)
			{ 		
			
			
				if(document.getElementById("DataGrid2_ctl01_Checkbox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid2_ctl02_CheckBox1";
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
				str1="DataGrid2_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_CheckBox1";
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
				var str1="DataGrid2_ctl02_CheckBox1";
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
				str1="DataGrid2_ctl"+str3+"_CheckBx1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_CheckBox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
				}
				
			}   
			
			
			
			function SelectHi(grdid,obj,objlist)
			{ 		
			
			
				if(document.getElementById("DataGrid1_ctl01_Checkbox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid1_ctl02_CheckBox1";
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
				str1="DataGrid1_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
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
				var str1="DataGrid1_ctl02_CheckBox1";
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
				str1="DataGrid1_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
				}
				
			}   
			
//For select special discount and trade dis=================================
/*function SelectHi1(grdid,obj,objlist)
	{ 		
	
	if(document.getElementById("DataGrid1_ctl01_Checkbox3").checked==true)
	{ 
		var j1;
		var j;
		var str1="DataGrid1_ctl02_Checkbox2";
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
		        str1="DataGrid1_ctl"+str3+"_Checkbox2";
		        }
		        else
		        {
		         str1="DataGrid1_ctl0"+str3+"_Checkbox2";
		         } 
		
		       }
		}
	 }
	else
	{ 
		var j1;
		var j;
		var str1="DataGrid1_ctl02_Checkbox2";
		for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
		
		{
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
		str1="DataGrid1_ctl"+str3+"_Checkbox2";
		}
		else
		{
		 str1="DataGrid1_ctl0"+str3+"_Checkbox2";
		 } 
		
		}
		
		}
		return false;
		}
		
	}  
//==============================================================================================================*/
			
				function checklenthbill()
{

//document.getElementById('div1').style.display="none";


alert('Seaching criteria does not produce any result');
window.close();
window.open('billing.aspx');
return false;



}


function fnUnloadHandler()

{   
    window.close();
       window.open('billing.aspx');

}




	
function  printpdf()
{
    var checkradio="93";


/////////////

    var hiddenbillstatus="";
    if(document.getElementById('hiddenadtype').value=="CL0")
    {
    hiddenbillstatus=document.getElementById('hiddenclsbill').value;

    }
    if(document.getElementById('hiddenadtype').value=='DI0')
    {
    hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


    }

//////////////////////////////////////////////////////////////////////////////////////////////////////////



var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var invoice_no="";
				var j;
				
				
			var str1="DataGrid1_ctl02_CheckBox1";
				var str21 = "DataGrid1_ctl02_CheckBox2";
				var str31 = "DataGrid1_ctl02_CheckBox3";
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
                                invoice_no=document.getElementById("DataGrid1").rows[j].cells[1].innerHTML;
                                insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
                                edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				     if(document.getElementById(str21).checked==true)
				     {
				        spl_dis=  "1";
				     }
				     else
				     {
				        spl_dis=  "0";
				     }
				     
				     if(document.getElementById(str31).checked==true)
				     {
				        trade_dis=  "1";
				     }
				     else
				     {
				        trade_dis=  "0";
				     }
                            }
                            else
                            {
                                ciobookid= ciobookid+","+document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
                                invoice_no=invoice_no+","+document.getElementById("DataGrid1").rows[j].cells[1].innerHTML;
                                insertion= insertion+","+	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
                                edition=edition+","+  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
                                	 if(document.getElementById(str21).checked==true)
				     {
				        spl_dis= spl_dis+","+ "1";
				     }
				     else
				     {
				        spl_dis= spl_dis+","+ "0";
				     }
				     
				     if(document.getElementById(str31).checked==true)
				     {
				        trade_dis= trade_dis+","+ "1";
				     }
				     else
				     {
				        trade_dis=  trade_dis+","+ "0";
				     }
                                
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
				str1="DataGrid1_ctl"+str3+"_CheckBox1";
				str21="DataGrid1_ctl"+str3+"_CheckBox2";
				str31="DataGrid1_ctl"+str3+"_CheckBox3";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
				 str21="DataGrid1_ctl0"+str3+"_CheckBox2";
				 str31="DataGrid1_ctl0"+str3+"_CheckBox3";
				 } 				                 
    				
	             }
    				 
	                      if(j1==1)
	                     {
	                         alert('Please Select atlest one CheckBox for bill');
	                         return false;
	                     }
                				 
                				 
	             }
				 
				 
				  insertion_wise.setSessionre(ciobookid,checkradio,insertion,edition,invoice_no,spl_dis,trade_dis,todate_v);				 
				  
				  window.open('pdf.aspx');
				  
                //  window.open('testnewsambad.aspx');
				 

			//	 window.open(myurl+'testnewsambad.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition+'&invoice='+invoice_no);



				  
				   
	
		}
		
		
//-----------------------------------------------------------------------------------------------------------------//


function  printletter()
{

	
		
		
		checkradio="insertionwise";
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
				
				
				var str1="DataGrid1_ctl02_CheckBox1";
//				var str2 = "DataGrid1_ctl02_CheckBox2";
//				var str3 = "DataGrid1_ctl02_CheckBox3";
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
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('hiddenadtype').value;
				  
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid1").rows[j].cells[2].innerHTML;
				ciobookid=document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				invoice_no=document.getElementById("DataGrid1").rows[j].cells[1].innerHTML;
				
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid1").rows[j].cells[2].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				invoice_no=invoice_no+","+document.getElementById("DataGrid1").rows[j].cells[1].innerHTML;
				
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
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
			
			 hiddenbillstatus="orderwiselastins";
				// window.open('classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&invoice_no='+invoice_no+'&hiddensession='+hiddenbillstatus);
				  
				
				insertion_wise.setSessionlast_cover(ciobookid,agencycode,invoice_no,checkradio);				 
                 window.open('cover_letter.aspx');
				 
				 
				 
		
		///////
		
		
		
		
	


}