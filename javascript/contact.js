

var chkboxforpay ="";
var one="";
var button="";
var chk123=""
var as="";
var val="";
var valofpro;
var code10;
var code11;
var code122;
var codepub;
var nexttable="";
var table="";
var flag=false;
var personname;
var datatable;
var datainsert;
var chkpro="";
var newboxvalue="";
var newprodname="";
var chkcode="";
var chkvalue="";
var codeforsave="";
var arrayforidupdate="";
var globalvalue="";
var newupdatecon11="";
var chkcodeup11="";
var chkvalueup11="";
var chkproup11="";
var radiocount;
var radioid;

var new_mode="";

///////////////this is used when upadting the product
var another=0;
////////////////////////////////////////////////////
var modify="0";

var browser=navigator.appName;






function eventcalling(event)
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
if(event.keyCode==113) 
    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;

}



function submitcontact()
{

if(document.getElementById('txtcontactperson').value=="")
{
alert("Contact Person Field Should Not Be Blank");
document.getElementById('txtcontactperson').focus();
return false;
}
else if(abc(document.getElementById('txtphoneno').value)=="")
{
alert("Please Enter Phone no.");
document.getElementById('txtphoneno').focus();
return(false);
}  

else if(document.getElementById('txtdob').value!="")
{
    var dateformat=document.getElementById('hiddendateformat').value;
   /* if(dateformat=="mm/dd/yyyy")
    {
        var currDate=new Date();
        var userDate=document.getElementById('txtdob').value.split('/'); 
        if(parseInt(userDate[0])>currDate.getMonth()+1)
        {
            alert("Date of Birth should be less than Current Date");
            return false;
        }
        else if(parseInt(userDate[2])>currDate.getFullYear())
        {
            alert("Date of Birth should be less than Current Date");
            return false;
        }
        else if(parseInt(userDate[1])>=currDate.getDate() && parseInt(userDate[0])==currDate.getMonth()+1 && parseInt(userDate[2])==currDate.getFullYear())
        {
            alert("Date of Birth should be less than Current Date");
            return false;
        }
    }
    else if(dateformat=="yyyy/mm/dd")
    {
        var currDate=new Date();
        var userDate=document.getElementById('txtdob').value.split('/'); 
        if(parseInt(userDate[1])>currDate.getMonth()+1)
        {
            alert("Date of Birth should be less than Current Date");
            return false;
        }
        else if(parseInt(userDate[0])>currDate.getFullYear())
        {
            alert("Date of Birth should be less than Current Date");
            return false;
        }
        else if(parseInt(userDate[2])>=currDate.getDate() && parseInt(userDate[1])==currDate.getMonth()+1 && parseInt(userDate[0])==currDate.getFullYear())
        {
            alert("Date of Birth should be less than Current Date");
            return false;
        }
    }
    
    else if(dateformat=="dd/mm/yyyy")
    {
        var currDate=new Date();
        var userDate=document.getElementById('txtdob').value.split('/'); 
        if(parseInt(userDate[1])>currDate.getMonth()+1)
        {
            alert("Date of Birth should be less than Current Date");
            return false;
        }
        else if(parseInt(userDate[2])>currDate.getFullYear())
        {
            alert("Date of Birth should be less than Current Date");
            return false;
        }
        else if(parseInt(userDate[0])>=currDate.getDate() && parseInt(userDate[1])==currDate.getMonth()+1 && parseInt(userDate[2])==currDate.getFullYear())
        {
            alert("Date of Birth should be less than Current Date");
            return false;
        }
    }*/
    
    
                var txtdob="";
				if(document.getElementById('txtdob').value!="")
				{
				    if(dateformat=="dd/mm/yyyy")
					{
						var txt=document.getElementById('txtdob').value;
						var txt1=txt.split("/");
						var dd=txt1[0];
						var mm=txt1[1];
						var yy=txt1[2];
						txtdob=mm+'/'+dd+'/'+yy;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
						txtdob=document.getElementById('txtdob').value;
					}
								
					else if(dateformat=="yyyy/mm/dd")
					{
						var txt=document.getElementById('txtdob').value;
						var txt1=txt.split("/");
						var yy=txt1[0];
						var mm=txt1[1];
						var dd=txt1[2];
						txtdob=mm+'/'+dd+'/'+yy;
					}
					if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						txtdob=document.getElementById('txtdob').value;
					}
							
				    var dt=txtdob;
                    var dts=new Date(dt);
                    var dn=new Date();
				    if(dn<=dts)
				    {
				        alert("Date should be less than  current Date.");
				        document.getElementById('txtdob').value="";
				        document.getElementById('txtdob').focus();
				        return false;
    				    
				    }
				}
}
 var msg=checkEmail();
 if(msg==false)
    return false;                           
//**********************************************<CHECK DUPLICATE NAME In New Case>*****************************************
    var hidden=document.getElementById('hiddenDupName');
	  
	   if(hidden.value!="")
	   {
	        var hiddata=hidden.value;
	        var arr=hiddata.split(",");
	    
	        for(var a=0;a<arr.length;a++)
	        {
		        if(arr[a]==document.getElementById('txtcontactperson').value)
    	        {
	                alert('This contact name already exists');
	                document.getElementById('txtcontactperson').focus();
	                return false;
	            }
	        }
	   }

//**********************************************</CHECK DUPLICATE NAME>*****************************************                           
                            
                            
                            
                            
if(document.getElementById('hiddenccode').value != "" && document.getElementById('hiddenccode').value != null)
{
//globalvalue;
//chkpro;
var nextglobal=globalvalue.split(",");
var globalvalueupadte="";
var updatecon=globalvalue.split(",");
var udateinto="";

for(var g=0;g<=updatecon.length-1;g++)
{
if(udateinto.indexOf(updatecon[g])<0)
    {
    udateinto=udateinto+updatecon[g]+",";
    }
}


////////////////////////////////
////////////////////for splitting

            var valuetochkupdate="";
            var valueofupdate="";
             var chkid=document.getElementById('prod');
        //var arrayforid=chkpro.split(",");
        var inc=0;
        //var newupdate;
        
        //xml to get the contact person detail
        
        //var userid=document.getElementById('hiddenuserid').value;
        //var compcode=document.getElementById('hiddencompcode').value;
        var page;
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
             httpRequest.onreadystatechange = function() {alertContents_chk(httpRequest) };
        
          
            httpRequest.open( "GET","checkvalueforcontact.aspx?page="+document.getElementById('hiddenccode').value, false );
            httpRequest.send('');
            id=httpRequest.responseText;
          
            

        }
        else
        {
		    var xml = new ActiveXObject("Microsoft.XMLHTTP");
		    xml.Open( "GET","checkvalueforcontact.aspx?page="+document.getElementById('hiddenccode').value, false );
		    xml.Send();
		    id=xml.responseText;
		}
   if(typeof(datatable)=="object")     
   {
        
     for (var i = 0  ; i < datatable.Tables[0].Rows.length; ++i)
    {
    var box="chk"+i;
    if( document.getElementById(box).checked==true)
        {
            inc++;
            valuetochkupdate=document.getElementById(box).value;
            valueofupdate=valuetochkupdate+","+valueofupdate;
            
        }
                    
                
     }
//     if(globalvalue == "")
//     {
//     alert("Please Select Product");
//     return false;
//     
//     }
     
      newupdate=valueofupdate+globalvalueupadte;
      
 }
else
{
newupdate=id;

}     

var forupdate=newupdate.split(",");
var forupdatesave="";

for(var k=0;k<=forupdate.length-1;k++)
{

if(forupdatesave.indexOf(forupdate[k])<0)
{

forupdatesave=forupdatesave+forupdate[k]+",";
}
                                                                      

}





var contactperson=trim(document.getElementById('txtcontactperson').value);
var txtdesignation=trim(document.getElementById('txtdesignation').value);
//-----**************_________****************________-***********************


var drprole=document.getElementById('drprole').value;

//-----------------------------------

var txtdob=document.getElementById('txtdob').value;
var txtphoneno=document.getElementById('txtphoneno').value;
var txtext=document.getElementById('txtext').value; 
var txtfaxno=document.getElementById('txtfaxno').value;
var mail=document.getElementById('TextBox2').value;
var agencycode=document.getElementById('hiddenagevcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var agencysubcode=document.getElementById('hiddenagensubcode').value; 
var hiddenccode=document.getElementById('hiddenccode').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var txtmobile=document.getElementById('txtmobile').value;
var txtmobile=document.getElementById('txtmobile').value;
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtdob').value != "")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtdob=mm+'/'+dd+'/'+yy;
}
else
{
var txtdob=document.getElementById('txtdob').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtdob').value!="")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtdob=mm+'/'+dd+'/'+yy;
}
else
{
var txtdob=document.getElementById('txtdob').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtdob=document.getElementById('txtdob').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtdob=document.getElementById('txtdob').value;
}
var role=document.getElementById('drprole').value;

//-----------------------------------change-pankaj-----------------------


contact_detail.submitcontact(contactperson,txtdesignation,txtdob,txtphoneno,txtext,txtfaxno,mail,agencycode,compcode,agencysubcode,userid,hiddenccode,role,udateinto,txtmobile);
another=0;
document.getElementById('txtcontactperson').value="";
document.getElementById('txtdesignation').value="";
//---------------
document.getElementById('drprole').value="";
//-----------------
document.getElementById('txtdob').value="";
document.getElementById('txtphoneno').value="";
document.getElementById('txtext').value=""; 
document.getElementById('txtfaxno').value="";
document.getElementById('TextBox2').value="";
document.getElementById('txtmobile').value="";

document.getElementById('hiddenccode').value=""; 

window.location=window.location;
 
return false;

}

else
{
//alert('asd');
var savevaluepro=chkpro.split(",");
var singleval="";
var rightval="";
var newrightval="";
for(var k=0;k<=savevaluepro.length-1;k++)
{


        if(savevaluepro[k]!="")
         {   
            if(savevaluepro[k]!=",")
            {
                if(savevaluepro[k]!=savevaluepro[k+1])
                {
                singleval=savevaluepro[k];
                rightval=singleval+","+rightval;
                }
            }
         }


}


                            newrightval=rightval;
//                            if(newrightval=="")
//                            {
//                            alert("Please select product");
//                            return false;
//                            }
                            
                            var product=rightval;
            
            var dl=""; 
            if(browser!="Microsoft Internet Explorer")
            {
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                 httpRequest.onreadystatechange = function() {alertContents_chk(httpRequest) };
            
              
                httpRequest.open( "GET","prod.aspx?product="+product, false );
                httpRequest.send('');
                dl=httpRequest.responseText;
              
                

            }       
            else
            {        
                 var xml = new ActiveXObject("Microsoft.XMLHTTP");
                 xml.Open( "GET","prod.aspx?product="+product, false );
		         xml.Send();
		         dl=xml.responseText;
		    }
                            
                            
var contactperson1=document.getElementById('txtcontactperson').value;
var agencycode1=document.getElementById('hiddenagevcode').value; 
var agencysubcode1=document.getElementById('hiddenagensubcode').value; 
var txtdesignation1=document.getElementById('txtdesignation').value;

//--------------------------
var drprole1=document.getElementById('drprole').value;
//-------------------------
//var txtdob1=document.getElementById('txtdob').value;
var txtphoneno1=document.getElementById('txtphoneno').value;
var txtext1=document.getElementById('txtext').value; 
var txtfaxno1=document.getElementById('txtfaxno').value;
var mail1=document.getElementById('TextBox2').value;
var agencycode1=document.getElementById('hiddenagevcode').value; 
var compcode1=document.getElementById('hiddencomcode').value; 
var userid1=document.getElementById('hiddenuserid').value; 
var agencysubcode1=document.getElementById('hiddenagensubcode').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var txtmobile=document.getElementById('txtmobile').value;

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtdob').value!="")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtdob1=mm+'/'+dd+'/'+yy;
}
else
{
var txtdob1=document.getElementById('txtdob').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtdob').value!="")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtdob1=mm+'/'+dd+'/'+yy;
}
else
{
var txtdob1=document.getElementById('txtdob').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtdob1=document.getElementById('txtdob').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtdob1=document.getElementById('txtdob').value;
}

    //if(modify!="1")
    if(opener.document.getElementById('hiddensaurabh').value!="modify")
      {
      //alert(modify);
       return;
      //alert('opener.document.getElementByIdvalue');
        
         }
         else
            {
              if(opener.document.getElementById('hiddenchk').value=="1" )
               {
                 //   alert(opener.document.getElementById('hiddenchk').value);
                 var dateformat=document.getElementById('hiddendateformat').value;
 contact_detail.insertcontact(contactperson1,txtdesignation1,drprole1,txtdob1,txtphoneno1,txtext1,txtfaxno1,mail1,agencycode1,compcode1,agencysubcode1,userid1,newrightval,dateformat,txtmobile);
                    
                    document.getElementById('txtcontactperson').value="";
                    document.getElementById('txtdesignation').value="";
                    document.getElementById('drprole').value="";
//-----------------------
                    document.getElementById('txtdob').value="";
                    document.getElementById('txtphoneno').value="";
                    document.getElementById('txtext').value=""; 
                    document.getElementById('txtfaxno').value="";
                    document.getElementById('TextBox2').value="";
                    document.getElementById('txtmobile').value="";
                     window.location=window.location;
                    return false;
                }
            }
            
             

another=0;
document.getElementById('txtcontactperson').value="";
document.getElementById('txtdesignation').value="";
//-----------------------
document.getElementById('drprole').value="";
//-----------------------

document.getElementById('txtdob').value="";
document.getElementById('txtphoneno').value="";
document.getElementById('txtext').value=""; 
document.getElementById('txtfaxno').value="";
document.getElementById('TextBox2').value="";
document.getElementById('txtmobile').value="";
window.location=window.location;

}
return false;
}




function selected(ab)
{
another=0;
var id=ab;


if(document.getElementById(id).checked==false)
        {
            cleardata('cont');
            return ;
        }


var agecode=document.getElementById('hiddenagencycode').value;
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var ss=document.getElementById('DataGrid1');

//alert(datagrid);


var j;
var t=1;
var k=0;

//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i+500;j++)
	{
	
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1" + j;
	//alert(DataGrid1__ctl_CheckBox1);
	//alert(str);
	//alert(document.getElementById(str));
	if(document.getElementById(str)!='undefined' && document.getElementById(str)!=null)
	{
        document.getElementById(str).checked=false;
    }
//document.getElementById(str).checked=false;
document.getElementById(id).checked=true;
if(id==str)
{
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	//alert(document.getElementById(str).value);
	code10=document.getElementById(id).value;
	chk123=document.getElementById(id);
	
	}
	}
	}
	if(k==1)
	{ 
	    if(document.getElementById('hiddensaurabh').value!="0")
	           document.getElementById('btndelete').disabled=false;
	          else
	            document.getElementById('btndelete').disabled=true;;
	    
	    contact_detail.bandcontact12(agecode,compcode,userid,code10,call_select12);
	//contact_detail.selectlistbox(code10,compcode,userid,call_bindlist);
	
	return false;
	
	}
	

}
function call_select12(response)
{

var ds=response.value;

chk123.checked=true;

document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;
	var dateformat=document.getElementById('hiddendateformat').value;
	if(ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "")
	{

	var enrolldate=ds.Tables[0].Rows[0].dob;
			var dd=enrolldate.getDate();
			if(dd.toString().length==1)
			   dd="0"+dd;
			var mm=enrolldate.getMonth() + 1;
			if(mm.toString().length==1)
			   mm="0"+mm;
			var yyyy=enrolldate.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="dd/mm/yyyy")
			{
			var enrolldate1=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var enrolldate1=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
	}
	else
	{
	document.getElementById('txtdob').value="";
	}
			
	
	//personname=ds.Tables[0].Rows[0].cont_person;
	document.getElementById('txtcontactperson').value=ds.Tables[0].Rows[0].cont_person;
	if(ds.Tables[0].Rows[0].designation!=null)
	{
    document.getElementById('txtdesignation').value=ds.Tables[0].Rows[0].designation;
    }
    else
    {
     document.getElementById('txtdesignation').value="";
    }
    document.getElementById('drprole').value=ds.Tables[0].Rows[0].role;

if(ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "")
{
document.getElementById('txtdob').value=enrolldate1;
}
else
{
document.getElementById('txtdob').value="";
}
codeforsave=ds.Tables[0].Rows[0].product;

if(ds.Tables[0].Rows[0].phone!=null)
{
document.getElementById('txtphoneno').value=ds.Tables[0].Rows[0].phone;
}
else
{
document.getElementById('txtphoneno').value="";
}
if(ds.Tables[0].Rows[0].extension!=null)
{
document.getElementById('txtext').value=ds.Tables[0].Rows[0].extension; 
}
else
{
document.getElementById('txtext').value="";
}
if(ds.Tables[0].Rows[0].fax!=null)
{
document.getElementById('txtfaxno').value=ds.Tables[0].Rows[0].fax;
}
else
{
document.getElementById('txtfaxno').value="";
}
if(ds.Tables[0].Rows[0].emailid!=null)
{
document.getElementById('TextBox2').value=ds.Tables[0].Rows[0].emailid;
}
else
{
document.getElementById('TextBox2').value="";
}

if(ds.Tables[0].Rows[0].phone!=null)
{
document.getElementById('txtmobile').value=ds.Tables[0].Rows[0].MOBILENO;
}
else
{
document.getElementById('txtmobile').value="";
}
document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;






return false;

}

function call_select(response)
{
var ds= response.value;


var y=ds.Tables[0].Rows.length;
var z=0;
var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;


	
	document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;
	
	var enrolldate=ds.Tables[0].Rows[0].dob;
			var dd=enrolldate.getDate();
			var mm=enrolldate.getMonth() + 1;
			var yyyy=enrolldate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
	
	
	document.getElementById('txtcontactperson').value=ds.Tables[0].Rows[0].cont_person;
document.getElementById('txtdesignation').value=ds.Tables[0].Rows[0].designation;

//--------------------------------------------------------------------------------------
document.getElementById('drprole').value=ds.Tables[0].Rows[0].role;
//******************************************************
if(ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "")
{
document.getElementById('txtdob').value=enrolldate1;
}
else
{
document.getElementById('txtdob').value="";
}
document.getElementById('txtphoneno').value=ds.Tables[0].Rows[0].phone;
document.getElementById('txtext').value=ds.Tables[0].Rows[0].extension; 
document.getElementById('txtfaxno').value=ds.Tables[0].Rows[0].fax;
document.getElementById('TextBox2').value=ds.Tables[0].Rows[0].emailid;
document.getElementById('txtmobile').value=ds.Tables[0].Rows[0].MOBILENO;

document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;

return false;
	
}


function clearcontact()
{
//alert("hi");
document.getElementById('txtcontactperson').value="";
document.getElementById('txtdesignation').value="";

//*************&&&&&&&&&&&&&&&&&&&((((((((((((((()__________________________
document.getElementById('drprole').value="";
//__________________________________________________________________
document.getElementById('txtdob').value="";
document.getElementById('txtphoneno').value="";
document.getElementById('txtext').value=""; 
document.getElementById('txtfaxno').value="";
document.getElementById('TextBox2').value="";
document.getElementById('txtmobile').value="";
return false;

}
//Commission *Submit*//
function commsubmit()
{
        var fromdate=document.getElementById('txtefffrom').value;
		var todate=document.getElementById('txtefftill').value;
		var dateformat=document.getElementById('hiddendateformat').value;
		if(dateformat=="dd/mm/yyyy")
        {
        var txt=fromdate;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        fromdate=mm+'/'+dd+'/'+yy;

        }
        if(dateformat=="mm/dd/yyyy")
        {
        fromdate=fromdate;
        }
        if(dateformat=="yyyy/mm/dd")
        {
        var txt=fromdate;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
       fromdate=mm+'/'+dd+'/'+yy;
        }

if(dateformat=="dd/mm/yyyy")
        {
        var txt=todate;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        todate=mm+'/'+dd+'/'+yy;

        }
        if(dateformat=="mm/dd/yyyy")
        {
        todate=todate;
        }
        if(dateformat=="yyyy/mm/dd")
        {
        var txt=todate;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
       todate=mm+'/'+dd+'/'+yy;
        }
		
		
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
		

        if (document.getElementById('txtefffrom').value=="")
		{
		alert("Plese fill Effective From");
		return false;
		}	
		else if (document.getElementById('txtefftill').value=="")
		{
		alert("Plese fill Effective To");
		return false;
		}	 
		else if(fromdate !='' && todate !='' && fdate > tdate)
		{
		alert(" Effective To should be greater than Effective From");
		document.getElementById('txtefftill').focus();
		return false;
		}					
		else if(document.getElementById('txtcommrate').value=="")
		{
		alert(" please enter Commission Rate %");
		document.getElementById('txtcommrate').focus();
		return false;
		}
		else if(document.getElementById('drpcommdetail').value=="0")
		{
		alert("Please select value");
		document.getElementById('drpcommdetail').focus();
		return false;
		}
		
		
		
		
//alert('hi');
////if(modify=="1")

////{
////alert('hi');
if(document.getElementById('hiddenccode').value != "" && document.getElementById('hiddenccode').value != null)
{

//alert(document.getElementById('hiddenccode').value );
//var txtefffrom=document.getElementById('txtefffrom').value;
var dateformat=document.getElementById('hiddendateformat').value;

if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefffrom=mm+'/'+dd+'/'+yy;

}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefffrom=mm+'/'+dd+'/'+yy;
}
if(dateformat=="mm/dd/yyyy")
{
var txtefffrom=document.getElementById('txtefffrom').value;
}

if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefffrom=document.getElementById('txtefffrom').value;
}


//var txtefftill=document.getElementById('txtefftill').value;

if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txtefftill').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txtefftill').value;
}

var txtcommrate=document.getElementById('txtcommrate').value;

var j=parseFloat(txtcommrate);

if( j<0 || j>100 )
{
alert("This commission rate is not valid");
document.getElementById('txtcommrate').value="";
document.getElementById('txtcommrate').focus();
return false;
}

var drpcommdetail=document.getElementById('drpcommdetail').value;
var hiddenccode=document.getElementById('hiddenccode').value; 
var hiddenagevcode=document.getElementById('hiddenagevcode').value; 
var hiddenagencysubcode=document.getElementById('hiddenagensubcode').value;
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var adtype=document.getElementById('drpadtype').value;
var uom =document.getElementById('drpuom').value;
//alert('Commission Update');
Comm_detail.commdate12(hiddenagevcode,hiddencomcode,hiddenuserid,txtefffrom,txtefftill,hiddenccode,hiddenagencysubcode,drpcommdetail,adtype,uom,call_commupdate);

//document.getElementById('txtefftill').value="";
//document.getElementById('txtcommrate').value="";
//document.getElementById('drpcommdetail').value="0";
//document.getElementById('txtefffrom').value=="";
return false;



}

else

{
//alert('Comm CHK');
//var txtefffrom=document.getElementById('txtefffrom').value;

var txtcommrate=document.getElementById('txtcommrate').value;

var j=parseFloat(txtcommrate);

if( j<0 || j>100 )
{
alert("This commission rate in not valid");
document.getElementById('txtcommrate').value="";
document.getElementById('txtcommrate').focus();

return false;
}

var dateformat=document.getElementById('hiddendateformat').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefffrom=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtefffrom=document.getElementById('txtefffrom').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefffrom=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefffrom=document.getElementById('txtefffrom').value;
}

//var txtefftill=document.getElementById('txtefftill').value;

if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txtefftill').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txtefftill').value;
}


//var txtcommrate=document.getElementById('txtcommrate').value;
var drpcommdetail=document.getElementById('drpcommdetail').value;

var hiddenagevcode=document.getElementById('hiddenagevcode').value; 
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;
var adtype=document.getElementById('drpadtype').value;
var uom11=document.getElementById('drpuom').value;
var cash_disc=document.getElementById('drpcashdis').value;
var cash_amt=document.getElementById('txtcsamt').value;
//Pankaj Gupta//

              
                    var dateformat="";
                    //var status="";
                    var hiddenagevcode=hiddenagevcode;
                    var hiddenagensubcode=hiddenagensubcode;
                    var txtefffrom=txtefffrom;
                    var txtefftill=txtefftill;
                    var drpcommdetail="";
                    drpcommdetail=document.getElementById('drpcommdetail').value;
                    var dl="";
                    if(browser!="Microsoft Internet Explorer")
                    {
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                         httpRequest.onreadystatechange = function() {alertContents_chk(httpRequest) };
                    
                      
                        httpRequest.open( "GET","chkcomm_detail.aspx?hiddenagevcode="+hiddenagevcode+"&hiddenagensubcode="+hiddenagensubcode+"&dateformat="+dateformat+"&txtefffrom="+txtefffrom+"&txtefftill="+txtefftill+"&drpcommdetail="+drpcommdetail+"&adtype="+adtype+"&uom11="+uom11, false );
                        httpRequest.send('');
                        dl=httpRequest.responseText;
                      
                        

                    }
                    else
                    {
		                var xml = new ActiveXObject("Microsoft.XMLHTTP");
		                xml.Open( "GET","chkcomm_detail.aspx?hiddenagevcode="+hiddenagevcode+"&hiddenagensubcode="+hiddenagensubcode+"&dateformat="+dateformat+"&txtefffrom="+txtefffrom+"&txtefftill="+txtefftill+"&drpcommdetail="+drpcommdetail+"&adtype="+adtype+"&uom11="+uom11, false );
		                xml.Send();
		                dl=xml.responseText;
		            }
            if(dl=="Y")
		        {
    		       alert("This Date Is Already Assigned");
		           return false;
		        }
		    
		   
		    else 
		    {
		       // alert('vibhor');
		    //if(modify!="1")
		    if(opener.document.getElementById('hiddensaurabh').value!="modify")
                  {
                   // alert('Commission Save');
			        return  ;
                  
                  }
              else
                  {
                  if (opener.document.getElementById('hiddenchk').value=="1")
                       {
                         //alert('Commission New Entry During Modify');
               // pubstatdetails.insertpcm(compcode,userid,centcode,status,circular,todate,fromdate,dateformat,insertpcmcall);
               
               var dateformat=document.getElementById('hiddendateformat').value;
               var addcomm=document.getElementById('txtaddcomm').value;
               var uom =document.getElementById('drpuom').value;
               var agen=document.getElementById('drpagen').value;
                        Comm_detail.insertcommdetail(txtefffrom,txtefftill,txtcommrate,drpcommdetail,hiddenagevcode,hiddencomcode,hiddenuserid,hiddenagensubcode,dateformat,adtype,addcomm,uom,agen,cash_disc,cash_amt);
                        
                        document.getElementById('txtefffrom').value="";
                        document.getElementById('txtefftill').value="";
                        document.getElementById('txtcommrate').value="";
                        document.getElementById('drpcommdetail').value="NET";

                        window.location=window.location;
                        return false;
                      }
                   
                 }
                 
               }
                 
                
          }

//Comm_detail.commdate(hiddenagevcode,hiddencomcode,hiddenuserid,txtefffrom,txtefftill,hiddenagensubcode,call_comminsert);
return false;


        }

//}

function call_commupdate(response)
{


var ds=response.value;
var dateformat=document.getElementById('hiddendateformat').value;

//var txtefffrom=document.getElementById('txtefffrom').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefffrom=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtefffrom=document.getElementById('txtefffrom').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefffrom=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefffrom=document.getElementById('txtefffrom').value;
}

//var txtefftill=document.getElementById('txtefftill').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txtefftill').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txtefftill').value;
}


var txtcommrate=document.getElementById('txtcommrate').value;
var drpcommdetail=document.getElementById('drpcommdetail').value;
var hiddenccode=document.getElementById('hiddenccode').value; 
var hiddenagevcode=document.getElementById('hiddenagevcode').value; 
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var adtype=document.getElementById('drpadtype').value
var addcomm=document.getElementById('txtaddcomm').value;
 var uom =document.getElementById('drpuom').value;
 var agen=document.getElementById('drpagen').value;
 var cash_disc=document.getElementById('drpcashdis').value;
 var cash_amt = document.getElementById('txtcsamt').value;
 var adcat = document.getElementById('dpadcat').value;

if(ds.Tables[0].Rows.length > 0)
{
alert("This date has been assigned");
return false;

}
else
{
    Comm_detail.submitcomm(txtefffrom, txtefftill, txtcommrate, drpcommdetail, hiddenccode, hiddenagevcode, hiddencomcode, hiddenuserid, adtype, addcomm, uom, agen, cash_disc, cash_amt, adcat);

document.getElementById('txtefffrom').value="";
document.getElementById('txtefftill').value="";
document.getElementById('txtcommrate').value="";
document.getElementById('drpcommdetail').value="";
document.getElementById('hiddenccode').value=""; 

window.location=window.location;

return false;

}

}


function call_comminsert(response)
{
var ds=response.value;

var dateformat=document.getElementById('hiddendateformat').value;
//var txtefffrom=document.getElementById('txtefffrom').value;

//var txtefffrom=document.getElementById('txtefffrom').value;

if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefffrom=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtefffrom=document.getElementById('txtefffrom').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefffrom=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefffrom=document.getElementById('txtefffrom').value;
}
//var txtefftill=document.getElementById('txtefftill').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txtefftill').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txtefftill').value;
}
var txtcommrate=document.getElementById('txtcommrate').value;
var drpcommdetail=document.getElementById('drpcommdetail').value;

var hiddenagevcode=document.getElementById('hiddenagevcode').value; 
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;
var addcomm=document.getElementById('txtaddcomm').value;
if(ds.Tables[0].Rows.length > 0)
{
alert("This Date Has Been Assigned");
return false;

}
else
{
Comm_detail.insertcommdetail(txtefffrom,txtefftill,txtcommrate,drpcommdetail,hiddenagevcode,hiddencomcode,hiddenuserid,hiddenagensubcode,addcomm);

document.getElementById('txtefffrom').value="";
document.getElementById('txtefftill').value="";
document.getElementById('txtcommrate').value="";
document.getElementById('drpcommdetail').value="";

window.location=window.location;

return false;
}
}

//selectComm//
function selectcomm(ab)
{
var id=ab;

if(document.getElementById(id).checked==false)
        {
            cleardata('comm');
            return ;
        }

var hiddenagevcode=document.getElementById('hiddenagevcode').value; 
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var datagrid=document.getElementById('DataGrid1');

var j;
var t;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
//	alert(str);
//	alert(document.getElementById(str));
document.getElementById(str).checked=false;
document.getElementById(id).checked=true;
if(id==str)
{
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	code11=document.getElementById(id).value;
	chk123=document.getElementById(id);
	}
	}
	}
	if(k==1)
	{
	if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled=false;
	}
	//document.getElementById('btndelete').disabled=false; 
	
	Comm_detail.bandcomm123(hiddenagevcode,hiddencomcode,hiddenuserid,code11,call_comm);
	//}
	
	return false;
	
	}
	else
	{
	alert("You Should Select One Row");
	return false;
	}
	return false;
					
}

function call_comm(response)

{
    var ds= response.value;
    chk123.checked=true;

    document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].comm_code;
    var dateformat=document.getElementById('hiddendateformat').value;
    var enrolldate=ds.Tables[0].Rows[0].Eff_from_date;
			
    var dd = "";
    var mm = "";
    var yyyy = "";

    if (document.getElementById('hdnconntype').value == "mysql") {
         dd = enrolldate.split('/')[1];
         mm = enrolldate.split('/')[0];
         yyyy = enrolldate.split('/')[2];

    }
    else {
         dd = enrolldate.getDate();
        if (dd.toString().length == 1)
            dd = "0" + dd;
         mm = enrolldate.getMonth() + 1;
        if (mm.toString().length == 1)
            mm = "0" + mm;
         yyyy = enrolldate.getFullYear();
    }
    //var enrolldate1=mm+'/'+dd+'/'+yyyy;
    if(dateformat=="dd/mm/yyyy")
    {
        var enrolldate1=dd+'/'+mm+'/'+yyyy;
			
    }
    if(dateformat=="yyyy/mm/dd")
    {
        var enrolldate1=yyyy+'/'+mm+'/'+dd;
    }
    if(dateformat=="mm/dd/yyyy")
    {
        var enrolldate1=mm+'/'+dd+'/'+yyyy;
    }
    if(dateformat==null || dateformat=="" || dateformat=="undefined")
    {
        var enrolldate1=mm+'/'+dd+'/'+yyyy;
    }
	
    if(ds.Tables[0].Rows[0].Eff_from_date != null && ds.Tables[0].Rows[0].Eff_from_date != "")
    {
        document.getElementById('txtefffrom').value=enrolldate1;
    }
    else
    {
        document.getElementById('txtefffrom').value="";
    }

    var tilldate = ds.Tables[0].Rows[0].Eff_Till_date;

    var dd = "";
    var mm = "";
    var yyyy = "";

    if (document.getElementById('hdnconntype').value == "mysql") {
         dd = tilldate.split('/')[1];
         mm = tilldate.split('/')[0];
         yyyy = tilldate.split('/')[2];

    }
else{
			 dd=tilldate.getDate();
    if(dd.toString().length==1)
        dd="0"+dd;
     mm=tilldate.getMonth() + 1;
    if(mm.toString().length==1)
        mm="0"+mm;
     yyyy=tilldate.getFullYear();
}
			
			if(dateformat=="dd/mm/yyyy")
			{
			var tilldate1=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var tilldate1=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var tilldate1=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var tilldate1=mm+'/'+dd+'/'+yyyy;
			}
	
if(ds.Tables[0].Rows[0].Eff_Till_date != null && ds.Tables[0].Rows[0].Eff_Till_date != "")
{
document.getElementById('txtefftill').value=tilldate1;
}
else
{
document.getElementById('txtefftill').value="";
}

document.getElementById('txtcommrate').value=ds.Tables[0].Rows[0].Comm_rate;
document.getElementById('txtaddcomm').value=ds.Tables[0].Rows[0].Addl_Comm_Rate;
document.getElementById('drpcommdetail').value=ds.Tables[0].Rows[0].Discount;
document.getElementById('drpadtype').value=ds.Tables[0].Rows[0].ADTYPE;
document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].comm_code;
 bind_pkg_adcat_uom(ds.Tables[0].Rows[0].ADTYPE)
if(ds.Tables[0].Rows[0].UOM != null && ds.Tables[0].Rows[0].UOM != "")
{
document.getElementById('drpuom').value=ds.Tables[0].Rows[0].UOM;
}
if(ds.Tables[0].Rows[0].ADDITIONAL_FLAG != null && ds.Tables[0].Rows[0].ADDITIONAL_FLAG != "")
{
document.getElementById('drpagen').value=ds.Tables[0].Rows[0].ADDITIONAL_FLAG;
}
document.getElementById('drpcashdis').value=ds.Tables[0].Rows[0].CASH_DISCOUNTTYPE;
document.getElementById('txtcsamt').value=ds.Tables[0].Rows[0].CASH_DISCOUNT;
if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled= false;
	document.getElementById('btnsubmit').disabled=false;
	}
	

return false;
}

function Clearcomm()
{

document.getElementById('txtefffrom').value="";
document.getElementById('txtefftill').value="";
document.getElementById('txtcommrate').value="";
document.getElementById('drpcommdetail').value="0";
document.getElementById('drpuom').value="0";
document.getElementById('drpagen').value="0";
document.getElementById('drpcashdis').value="0";
document.getElementById('txtcsamt').value="";

return false;

}

function deletecomm()

{

var hiddenagevcode=document.getElementById('hiddenagevcode').value; 
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var hiddenccode=document.getElementById('hiddenccode').value; 
var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;
var datagrid=document.getElementById('DataGrid1')

var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	
	}
	}
	if(k==1)
	{
	boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	if(i!=1)
	{
	Comm_detail.deletecommdet(hiddenagevcode,hiddencomcode,hiddenuserid,code11,hiddenagensubcode);
	}
	else
	{
	alert("One Commission Detail should be present for this Agency");
	return false;
	}
	}     
	else
	{
	return false;
	}	
	
	alert("Data Deleted Successfully");
	window.location=window.location;
	return false;
	
	}
	else
	{
	alert("You Should Select One Row");
	return false;
	}
	
	return false;

}


function deletecontact()
{

var agecode=document.getElementById('hiddenagencycode').value;
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var agencysubcode1=document.getElementById('hiddenagensubcode').value; 
var hiddenccode=document.getElementById('hiddenccode').value; 

var datagrid=document.getElementById('DataGrid1')

var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i+500;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));
//if(document.getElementById(str))
if(document.getElementById(str)!='undefined' && document.getElementById(str)!=null)
{
	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	
	}
}
	
	}
	if(k==1)
	{
	boolReturn = confirm("Are you sure you want to delete this?");
	if(boolReturn==1)
	{
	contact_detail.deletecontact(agecode,compcode,userid,agencysubcode1,code10);
	}     
	else
	{
	return false;
	}	
	
	alert("Data Deleted Successfully");	
	window.location=window.location;
	return false;
	}
	
	else
	{
	alert("You should select one row");
	return false;
	}
	
	
	return false;

}

//*Bank****//
function submitbank()

{
var dateformat=document.getElementById('hiddendateformat').value;
var fromdate=document.getElementById('txtbgdate').value;
		var todate=document.getElementById('txtvaliditydate').value;
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
        var curdate=new Date();
if(curdate > tdate)
{
alert("Validity date must be greater than current date");
return false;
}

if(trim(document.getElementById('txtbgno').value)=="")
		{
		alert("Please enter BG No.");
		document.getElementById('txtbgno').focus();
		return false;
		}
		
		else if(trim(document.getElementById('txtamount').value)=="")
		{
		alert("Please enter Amount");
		document.getElementById('txtamount').focus();
		return false;
		}
			
		
		
		
		else if(trim(document.getElementById('txtbgdate').value)=="")
		{
		alert("Please fill BG Date");
		document.getElementById('txtbgdate').focus();
		return false;
		}
		else if(document.getElementById('txtbgdate').value!="")
		{
            if(dateformat=="dd/mm/yyyy")
            {
            var txt=document.getElementById('txtbgdate').value;
            var txt1=txt.split("/");
            var dd=txt1[0];
            var mm=txt1[1];
            var yy=txt1[2];
            var txtbgdate=mm+'/'+dd+'/'+yy;

            }
            if(dateformat=="mm/dd/yyyy")
            {
            var txtbgdate=document.getElementById('txtbgdate').value;
            }
            if(dateformat=="yyyy/mm/dd")
            {
            var txt=document.getElementById('txtbgdate').value;
            var txt1=txt.split("/");
            var yy=txt1[0];
            var mm=txt1[1];
            var dd=txt1[2];
            var txtbgdate=mm+'/'+dd+'/'+yy;
            }
		var bdte=new Date(txtbgdate/*document.getElementById('txtbgdate').value*/);
		var cdate=new Date();
		if(bdte>cdate)
		    {
		    alert("BG Date should be less than the current date");
		    return false;
		    }
		
		}
				
		if(trim(document.getElementById('txtvaliditydate').value)=="")
		{
		alert("Please fill Validity Date");
		document.getElementById('txtvaliditydate').focus();
		return false;
		}
		
		else if(fdate > tdate)
		{
		alert("BG Date should be less than Validity Date");
		
		return false;
		}
		if(trim(document.getElementById('txtbank').value)=="")
		{
		alert("Please enter Bank Name");
		document.getElementById('txtbank').focus();
		return false;
		}
		


if(document.getElementById('hiddenccode').value != "" && document.getElementById('hiddenccode').value != null)
{
//alert('Bank Update');
var dateformat=document.getElementById('hiddendateformat').value;
var txtbgno=document.getElementById('txtbgno').value;
var txtamount=document.getElementById('txtamount').value;
var txtbank=document.getElementById('txtbank').value;
//var txtbgdate=document.getElementById('txtbgdate').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtbgdate').value;
			var txt1=txt.split("/");
			var dd=txt1[0];
			var mm=txt1[1];
			var yy=txt1[2];
			var txtbgdate=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtbgdate=document.getElementById('txtbgdate').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtbgdate').value;
			var txt1=txt.split("/");
			var yy=txt1[0];
			var mm=txt1[1];
			var dd=txt1[2];
			var txtbgdate=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtbgdate=document.getElementById('txtbgdate').value;
}
//var txtvaliditydate=document.getElementById('txtvaliditydate').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtvaliditydate').value;
			var txt1=txt.split("/");
			var dd=txt1[0];
			var mm=txt1[1];
			var yy=txt1[2];
			var txtvaliditydate=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtvaliditydate=document.getElementById('txtvaliditydate').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtvaliditydate').value;
			var txt1=txt.split("/");
			var yy=txt1[0];
			var mm=txt1[1];
			var dd=txt1[2];
			var txtvaliditydate=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtvaliditydate=document.getElementById('txtvaliditydate').value;
}

var hiddenccode=document.getElementById('hiddenccode').value;
var hiddenagevcode=document.getElementById('hiddenagevcode').value;
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;

bank_detail.submitbankdet(txtbgno, txtamount, txtbank, txtbgdate, txtvaliditydate, hiddenccode, hiddenagevcode, hiddencomcode, hiddenuserid, hiddenagensubcode, document.getElementById('hidattach2').value);

document.getElementById('txtbgno').value="";
document.getElementById('txtamount').value="";
document.getElementById('txtbank').value="";
document.getElementById('txtbgdate').value="";
document.getElementById('txtvaliditydate').value="";
document.getElementById('hiddenccode').value="";

window.location=window.location;

return false;

}
else

{
var dateformat=document.getElementById('hiddendateformat').value;
var txtbgno=document.getElementById('txtbgno').value;
var txtamount=document.getElementById('txtamount').value;
var txtbank=document.getElementById('txtbank').value;
//var txtbgdate=document.getElementById('txtbgdate').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtbgdate').value;
			var txt1=txt.split("/");
			var dd=txt1[0];
			var mm=txt1[1];
			var yy=txt1[2];
			var txtbgdate=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtbgdate=document.getElementById('txtbgdate').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtbgdate').value;
			var txt1=txt.split("/");
			var yy=txt1[0];
			var mm=txt1[1];
			var dd=txt1[2];
			var txtbgdate=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtbgdate=document.getElementById('txtbgdate').value;
}
var txtvaliditydate=document.getElementById('txtvaliditydate').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtvaliditydate').value;
			var txt1=txt.split("/");
			var dd=txt1[0];
			var mm=txt1[1];
			var yy=txt1[2];
			var txtvaliditydate=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtvaliditydate=document.getElementById('txtvaliditydate').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtvaliditydate').value;
			var txt1=txt.split("/");
			var yy=txt1[0];
			var mm=txt1[1];
			var dd=txt1[2];
			var txtvaliditydate=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtvaliditydate=document.getElementById('txtvaliditydate').value;
}

var hiddenagevcode=document.getElementById('hiddenagevcode').value;
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;
var dateformat=document.getElementById('hiddendateformat').value;


        //if(modify!="1")
        if(opener.document.getElementById('hiddensaurabh').value=="modify")
            {
              // alert('Bank Chk');
               if (opener.document.getElementById('hiddenchk').value=="1" )
                  {
                    //alert('Bank New Entry During Modify');
                   
                   var response= bank_detail.chkBgNo(txtbgno,txtbank);
                    var ds =response.value;
                   if(ds==null)
                   {
                     alert(response.error.description);
                     return false;
                   }
                   else  if(ds.Tables[0].Rows.length > 0 )
                    {
                        alert("This BG No. Already Exists.");
                        document.getElementById('txtbgno').value="";
                        return false;
                    }
                    bank_detail.insertbankdet(txtbgno, txtamount, txtbank, txtbgdate, txtvaliditydate, hiddenagevcode, hiddencomcode, hiddenuserid, hiddenagensubcode, dateformat, document.getElementById('hidattach2').value);

                    document.getElementById('txtbgno').value="";
                    document.getElementById('txtamount').value="";
                    document.getElementById('txtbank').value="";
                    document.getElementById('txtbgdate').value="";
                    document.getElementById('txtvaliditydate').value="";

                    window.location=window.location;

                    return false;
                   }
                }
            else
                {
                    //alert('Bank Save');
                    return;
        
                }
         
         }
     
     }  

function call_BgNo(response)
{
   var ds =response.value;
   if(ds==null)
   {
     alert(response.error.description);
     return false;
   }
   else  if(ds.Tables[0].Rows.length > 0 )
    {
        alert("This BG No. Already Exists.");
        document.getElementById('txtbgno').value="";
        return false;
    }
   
}
       
//function selectbank(ab)
//{
//var id=ab;
//var hiddenagevcode=document.getElementById('hiddenagevcode').value;
//var hiddencomcode=document.getElementById('hiddencomcode').value;
//var hiddenuserid=document.getElementById('hiddenuserid').value;
//var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;

//var j;
//var k=0;
////var DataGrid1__ctl_CheckBox1= new Array();
//var i=document.getElementById("DataGrid1").rows.length -1;

//for(j=0;j<i;j++)
//	{
//	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
//	var str="DataGrid1__ctl_CheckBox1"+j;
//	//alert(str);
////	alert(document.getElementById(str));
//document.getElementById(str).checked=false;
//document.getElementById(id).checked=true;
//if(id==str)
//{
//	if(document.getElementById(id).checked==true)
//	{
//	k=k+1;
//	code122=document.getElementById(id).value;
//	chk123=document.getElementById(id);
//	}
//	}
//	}
//	if(k==1)
//	{
//	document.getElementById('btndelete').disabled=false;
//	bank_detail.bandbank12(hiddenagevcode,hiddencomcode,hiddenuserid,hiddenagensubcode,code122,call_bank);
//	return false;
//	
//	}
//	else
//	{
//	alert("You Can Select One Row At A Time");
//	return false;
//	}
//	return false;

//}

//SBANKDETAIL//
function selectbank(ab)
{
//alert(ab);
var id=ab;

if(document.getElementById(id).checked==false)
        {
            cleardata('bank');
            return ;
        }

/*
var j;
var t=1;
var k=0;

//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i+100;j++)
	{
	
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1" + j;
	//alert(DataGrid1__ctl_CheckBox1);
	//alert(str);
	//alert(document.getElementById(str));
	if(document.getElementById(str)!='undefined' && document.getElementById(str)!=null)
	{
        document.getElementById(str).checked=false;
    }
document.getElementById(id).checked=true;
if(id==str)
{
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	//alert(document.getElementById(str).value);
	code10=document.getElementById(id).value;
	chk123=document.getElementById(id);
	
	}
	}
	}
	if(k==1)
	{
	document.getElementById('btndelete').disabled=false;
	contact_detail.bandcontact12(agecode,compcode,userid,code10,call_select12);
	//contact_detail.selectlistbox(code10,compcode,userid,call_bindlist);
	
	return false;
	
	}


*/


var hiddenagevcode=document.getElementById('hiddenagevcode').value;
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;
var datagrid=document.getElementById('DataGrid1');

var j=0;
var k=0;
var t=1;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;
//alert(i);
for(j=0;j<i+100;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));
//document.getElementById(str).checked=false;
if(document.getElementById(str)!='undefined' && document.getElementById(str)!=null)
	{
        document.getElementById(str).checked=false;
    }
document.getElementById(id).checked=true;
if(id==str)
   {
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	code122=document.getElementById(id).value;
	chk123=document.getElementById(id);
	}
	}
	}
	if(k==1)
	{
	   if(document.getElementById('hiddensaurabh').value!="0")
	       document.getElementById('btndelete').disabled=false;
	      else
	        document.getElementById('btndelete').disabled=true;;
	  
	bank_detail.bandbank12(hiddenagevcode,hiddencomcode,hiddenuserid,hiddenagensubcode,code122,call_bank);
	return false;
	
	}
	else if(k==0)
	{
	//alert("You Should Select One Row");
	document.getElementById('txtbgno').value="";
document.getElementById('txtamount').value="";
document.getElementById('txtbank').value="";
document.getElementById('txtbgdate').value="";
document.getElementById('txtvaliditydate').value="";
	
	
	
	return false;
	}
	return false;

}

function call_bank(response)
{
var ds= response.value;


chk123.checked=true;

var y=ds.Tables[0].Rows.length;


var z=0;
var j;
var t;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	t=j;
	t++;
	t++;
	var str="DataGrid1__ctl_CheckBox1"+t;
	
	var chk=str;
	chk=true;
	if(chk==true)
	{
	z=j;
	
	}
	
	}
    if(z.length > 1)
	{
	return false;
	}





	var dateformat=document.getElementById('hiddendateformat').value;
	document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].BG_CODE ;
	
	var enrolldate=ds.Tables[0].Rows[0].VALIDITY_DATE;
			var dd=enrolldate.getDate();
			if(dd.toString().length==1)
			   dd="0"+dd;
			var mm=enrolldate.getMonth() + 1;
			if(mm.toString().length==1)
			   mm="0"+mm;
			var yyyy=enrolldate.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
	
	
	
if(ds.Tables[0].Rows[0].VALIDITY_DATE != null && ds.Tables[0].Rows[0].VALIDITY_DATE != "")
{

if(dateformat=="dd/mm/yyyy")
{
var enrolldate1=dd+'/'+mm+'/'+yyyy;
document.getElementById('txtvaliditydate').value=enrolldate1;

}
if(dateformat=="mm/dd/yyyy")
{
var enrolldate1=mm+'/'+dd+'/'+yyyy;
document.getElementById('txtvaliditydate').value=enrolldate1;
}
if(dateformat=="yyyy/mm/dd")
{
var enrolldate1=yyyy+'/'+mm+'/'+dd;
document.getElementById('txtvaliditydate').value=enrolldate1;

}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var enrolldate1=mm+'/'+dd+'/'+yyyy;
document.getElementById('txtvaliditydate').value=enrolldate1;
}



}
else
{
document.getElementById('txtvaliditydate').value="";
}


if (ds.Tables[0].Rows[0].ATTACHMENT != null) {
    document.getElementById('hidattach2').value = ds.Tables[0].Rows[0].ATTACHMENT;
    document.getElementById('attachment1').src = "Images/indexred.jpg";

}
else {
    document.getElementById('hidattach2').value = "";
    document.getElementById('attachment1').src = "Images/index.jpeg"
}




var tilldate=ds.Tables[0].Rows[0].BG_DATE;
			var dd=tilldate.getDate();
			if(dd.toString().length==1)
			   dd="0"+dd;
			var mm=tilldate.getMonth() + 1;
			if(mm.toString().length==1)
			   mm="0"+mm;
			var yyyy=tilldate.getFullYear();
			
			
			
	
	
	
if(ds.Tables[0].Rows[0].BG_DATE != null && ds.Tables[0].Rows[0].BG_DATE != "")
{

if(dateformat=="dd/mm/yyyy")
{
var tilldate1=dd+'/'+mm+'/'+yyyy;
document.getElementById('txtbgdate').value=tilldate1;
}
if(dateformat=="mm/dd/yyyy")
{
var tilldate1=mm+'/'+dd+'/'+yyyy;
document.getElementById('txtbgdate').value=tilldate1;
}
if(dateformat=="yyyy/mm/dd")
{
var tilldate1=yyyy+'/'+mm+'/'+dd;
document.getElementById('txtbgdate').value=tilldate1;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var tilldate1=mm+'/'+dd+'/'+yyyy;
document.getElementById('txtbgdate').value=tilldate1;
}



}
else
{
document.getElementById('txtbgdate').value="";
}






document.getElementById('txtbgno').value=ds.Tables[0].Rows[0].BG_NO;
document.getElementById('txtamount').value=ds.Tables[0].Rows[0].AMOUNT;
document.getElementById('txtbank').value=ds.Tables[0].Rows[0].BANK_NAME;


return false;

}

function clearbank()
{
document.getElementById('txtbgno').value="";
document.getElementById('txtamount').value="";
document.getElementById('txtbank').value="";
document.getElementById('txtbgdate').value="";
document.getElementById('txtvaliditydate').value="";

return false;

}

function deletebank()
{

var hiddenccode=document.getElementById('hiddenccode').value;
var hiddenagevcode=document.getElementById('hiddenagevcode').value;
var hiddencomcode=document.getElementById('hiddencomcode').value;
var hiddenuserid=document.getElementById('hiddenuserid').value;
var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;
var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i+500;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));

if(document.getElementById(str)!='undefined' && document.getElementById(str)!=null)
{
	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	
	}
	}
	}
	if(k==1)
	{
	boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	bank_detail.deletebank(hiddenagevcode,hiddencomcode,hiddenuserid,code122,hiddenagensubcode);
	}     
	else
	{
	return false;
	}	
	alert("Data Deleted");
	document.getElementById('btndelete').disabled=true;
	window.location=window.location;
	return false;
	
	}
	else
	{
	alert("You Should Select One Row");
	return false;
	}
	
	
	return false;


}

function call_payselect(response)
{

//document.getElementById('Button2').disabled=false;
var ds=response.value;

if(ds.Tables[0].Rows[0].cash != "" && ds.Tables[0].Rows[0].cash != null)
{
document.getElementById('Checkbox4').checked=true;
}
if(ds.Tables[0].Rows[0].credit != "" && ds.Tables[0].Rows[0].credit != null)
{
document.getElementById('Checkbox5').checked=true;
}
if(ds.Tables[0].Rows[0].bank != "" && ds.Tables[0].Rows[0].bank != null)
{
document.getElementById('Checkbox6').checked=true;
}
window.location=window.location;
return false;
}

//Status****//
function summition()
 {
var dateformat=document.getElementById('hiddendateformat').value;
//-------------------------------------------------------------------//
        if(dateformat=="dd/mm/yyyy")
        {
        var txt=document.getElementById('txtfrom').value;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        var txtfrom=mm+'/'+dd+'/'+yy;

        }
        if(dateformat=="mm/dd/yyyy")
        {
        var txtfrom=document.getElementById('txtfrom').value;
        }
        if(dateformat=="yyyy/mm/dd")
        {
        var txt=document.getElementById('txtfrom').value;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
        var txtfrom=mm+'/'+dd+'/'+yy;
        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
        var txtfrom=document.getElementById('txtfrom').value;
        }

         
        //var txtto=document.getElementById('txtto').value;
        if(dateformat=="dd/mm/yyyy")
        {
        var txt=document.getElementById('txtto').value;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        var txtto=mm+'/'+dd+'/'+yy;

        }
        if(dateformat=="yyyy/mm/dd")
        {
        var txt=document.getElementById('txtto').value;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
        var txtto=mm+'/'+dd+'/'+yy;
        }
        if(dateformat=="mm/dd/yyyy")
        {
        var txtto=document.getElementById('txtto').value;
        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
        var txtto=document.getElementById('txtto').value;
        }
//--------------------------------------------------------------------------///
//        var txtfrom=document.getElementById('txtfrom').value;
//        var txtto=document.getElementById('txtto').value;

		var fdate=new Date(txtfrom);
		var tdate=new Date(txtto);


    if(document.getElementById('txtfrom').value=="")
    {
    alert("Please Fill Date From");
    document.getElementById('txtfrom').focus();
    return false;

    }

    else if(fdate > tdate)
    {
    alert("To Date should be greater than From Date");
    return false;
    }
    else if(document.getElementById('drpstatus').value=="0")
    {
    alert("Plese select status");
    document.getElementById('drpstatus').focus();
    return false;
    }
    else if(document.getElementById('txtto').value=="")
    {
    alert("Please fill To Date");
    document.getElementById('txtto').focus();
    return false;
    }
//***********************Duplicate Date Entry Cheching***************************************************

    var hidfdate=document.getElementById('hiddenfdate').value;
    var hidtdate=document.getElementById('hiddentdate').value;
    if(hidfdate!="")
    {
        var arrfdate=hidfdate.split(",");
        var arrtdate=hidtdate.split(",");
        for(var a=0;a<arrfdate.length;a++)
        {
            var fdate=arrfdate[a].split("/");
            var fday=fdate[1];
            var fmonth=fdate[0];
            var fyear=fdate[2];			        
            
            var txtfdatev=document.getElementById('txtfrom').value;
            var txtfdate=txtfdatev.split("/");
            var txtfday=txtfdate[1];
            var txtfmonth=txtfdate[0];
            var txtfyear=txtfdate[2];
            
            var tdate=arrtdate[a].split("/");
            var tday=tdate[1];
            var tmonth=tdate[0];
            var tyear=tdate[2];			        
            
            var txttdatev=document.getElementById('txtto').value;
            var txttdate=txttdatev.split("/");
            var txttday=txttdate[1];
            var txttmonth=txttdate[0];
            var txttyear=txttdate[2];
            
            if(((txtfyear>=fyear) && (txtfyear<=tyear)) || ((txttyear>=fyear) && (txttyear<=tyear)))
            {
                if(((txtfmonth>=fmonth) && (txtfmonth<=tmonth)) || ((txttmonth>=fmonth) && (txttmonth<=tmonth)))
                {
                    if(((txtfday>=fday) && (txtfday<=tday)) || ((txttday>=fday) && (txttday<=tday)))
                    {
                        alert("This date is already assigned");
                        return false;
                    }
                }
            }
         }
     }

//*******************************************************************************************************


if(document.getElementById('hiddenccode').value != "" && document.getElementById('hiddenccode').value != null)
{
//alert('Status Update');
        var agencycode=document.getElementById('hiddenagevcode').value; 
        var subagencycode=document.getElementById('hiddenagensubcode').value; 
        var compcode=document.getElementById('hiddencomcode').value; 
        var userid=document.getElementById('hiddenuserid').value; 
        var agencysubcode=document.getElementById('hiddenagensubcode').value; 
        var dateformat=document.getElementById('hiddendateformat').value;
        var circular=document.getElementById('txtCircular').value;
        var drpstatus=document.getElementById('drpstatus').value;
var attachment1=document.getElementById('hidattach1').value;
        //---------------------
        var remarks=document.getElementById('txtremark').value;
        //-----------------------------------

        var code=document.getElementById('hiddenccode').value;
        //***********************Duplicate Date Entry Cheching***************************************************
                    if(dateformat=="dd/mm/yyyy")
                    {
                    var txt=document.getElementById('txtfrom').value; 
                    var txt1=txt.split("/");
                    var dd=txt1[0];
                    var mm=txt1[1];
                    var yy=txt1[2];
                    var txtfrom=mm+'/'+dd+'/'+yy;

                    }
                    if(dateformat=="mm/dd/yyyy")
                    {
                    var txtfrom=document.getElementById('txtfrom').value; 
                    }
                    if(dateformat=="yyyy/mm/dd")
                    {
                    var txt=document.getElementById('txtfrom').value; 
                    var txt1=txt.split("/");
                    var yy=txt1[0];
                    var mm=txt1[1];
                    var dd=txt1[2];
                    var txtfrom=mm+'/'+dd+'/'+yy;
                    }
                    if(dateformat==null || dateformat=="" || dateformat=="undefined")
                    {
                    var txtfrom=document.getElementById('txtfrom').value; 
                    }

                    //var txtto=document.getElementById('txtto').value;
                    if(dateformat=="dd/mm/yyyy")
                    {
                    var txt=document.getElementById('txtto').value;
                    var txt1=txt.split("/");
                    var dd=txt1[0];
                    var mm=txt1[1];
                    var yy=txt1[2];
                    var txtto=mm+'/'+dd+'/'+yy;

                    }
                    if(dateformat=="mm/dd/yyyy")
                    {
                    var txtto=document.getElementById('txtto').value;
                    }
                    if(dateformat=="yyyy/mm/dd")
                    {
                    var txt=document.getElementById('txtto').value;
                    var txt1=txt.split("/");
                    var yy=txt1[0];
                    var mm=txt1[1];
                    var dd=txt1[2];
                    var txtto=mm+'/'+dd+'/'+yy;

                    }
                    if(dateformat==null || dateformat=="" || dateformat=="undefined")
                    {
                    var txtto=document.getElementById('txtto').value;
                    }
              //*************************CHECK DUPLIACY IN MODIFY MODE ONTHE BASIS OF DATE/STATUS*******************************//
                    if(document.getElementById('hidden1').value!=document.getElementById('txtfrom').value || document.getElementById('hidden2').value!=document.getElementById('txtto').value || document.getElementById('hidden3').value !=drpstatus || document.getElementById('hidden4').value!=circular || document.getElementById('hidden5').value!=remarks)
                    {
                   var chkres1= status_detail.checkstatusdate(drpstatus,txtfrom,txtto,compcode,userid,agencycode,agencysubcode,dateformat)
                   var chkds=chkres1.value;
                   if(chkds==null)
                   {
                     alert("ERROR : \n"+chkres1.error.description);
                     return false;
                   }
                   else
                   {
                     if(chkds.Tables[0].Rows.length>0)
                     {
                      alert("This date is already assigned.")
                      return false;
                     }
                     }
                   }
           //************************************************************************************//
        //var circular=document.getElementById('txtCircular').value;

        //status_detail.Update(drpstatus,txtfrom,txtto,agencycode,compcode,userid,agencysubcode,code);

        if(modify=="1")
        {
        status_detail.statusdateupdate(agencycode,compcode,userid,txtfrom,txtto,code,circular,dateformat,remarks,subagencycode,call_statusupdate);
         
         return false;
        }
        else
        {
        
        
          status_detail.Update(drpstatus,txtfrom,txtto,circular,agencycode,compcode,userid,agencysubcode,code,remarks,attachment1);
          window.location=window.location;
          return false;
        }

        return false;
        }
else
{

        var dateformat=document.getElementById('hiddendateformat').value;
        var agencycode=document.getElementById('hiddenagevcode').value; 
        var compcode=document.getElementById('hiddencomcode').value; 
        var userid=document.getElementById('hiddenuserid').value; 
        var agencysubcode=document.getElementById('hiddenagensubcode').value; 
        var subagencycode=document.getElementById('hiddenagensubcode').value; 
        //var txtfrom=document.getElementById('txtfrom').value; 

        if(dateformat=="dd/mm/yyyy")
        {
        var txt=document.getElementById('txtfrom').value; 
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        var txtfrom=mm+'/'+dd+'/'+yy;

        }
        if(dateformat=="mm/dd/yyyy")
        {
        var txtfrom=document.getElementById('txtfrom').value; 
        }
        if(dateformat=="yyyy/mm/dd")
        {
        var txt=document.getElementById('txtfrom').value; 
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
        var txtfrom=mm+'/'+dd+'/'+yy;
        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
        var txtfrom=document.getElementById('txtfrom').value; 
        }

        //var txtto=document.getElementById('txtto').value;
        if(dateformat=="dd/mm/yyyy")
        {
        var txt=document.getElementById('txtto').value;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        var txtto=mm+'/'+dd+'/'+yy;

        }
        if(dateformat=="mm/dd/yyyy")
        {
        var txtto=document.getElementById('txtto').value;
        }
        if(dateformat=="yyyy/mm/dd")
        {
        var txt=document.getElementById('txtto').value;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
        var txtto=mm+'/'+dd+'/'+yy;

        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
        var txtto=document.getElementById('txtto').value;
        }


        var drpstatus=document.getElementById('drpstatus').value;
        var code=document.getElementById('hiddenccode').value;
        var circular=document.getElementById('txtCircular').value;
        var remarks=document.getElementById('txtremark').value;
//Gupta//
        //if(modify!="1")
        if(opener.document.getElementById('hiddensaurabh').value=="modify")
            {
                //alert('modify=1');
                if(opener.document.getElementById('hiddenchk').value=="1" )
                   {
                    //alert('Status New Entry During Modify');
                    var dateformat=document.getElementById('hiddendateformat').value;
                    //***********************Duplicate Date Entry Cheching***************************************************
                    if(dateformat=="dd/mm/yyyy")
                    {
                    var txt=document.getElementById('txtfrom').value; 
                    var txt1=txt.split("/");
                    var dd=txt1[0];
                    var mm=txt1[1];
                    var yy=txt1[2];
                    var txtfrom=mm+'/'+dd+'/'+yy;

                    }
                    if(dateformat=="mm/dd/yyyy")
                    {
                    var txtfrom=document.getElementById('txtfrom').value; 
                    }
                    if(dateformat=="yyyy/mm/dd")
                    {
                    var txt=document.getElementById('txtfrom').value; 
                    var txt1=txt.split("/");
                    var yy=txt1[0];
                    var mm=txt1[1];
                    var dd=txt1[2];
                    var txtfrom=mm+'/'+dd+'/'+yy;
                    }
                    if(dateformat==null || dateformat=="" || dateformat=="undefined")
                    {
                    var txtfrom=document.getElementById('txtfrom').value; 
                    }

                    //var txtto=document.getElementById('txtto').value;
                    if(dateformat=="dd/mm/yyyy")
                    {
                    var txt=document.getElementById('txtto').value;
                    var txt1=txt.split("/");
                    var dd=txt1[0];
                    var mm=txt1[1];
                    var yy=txt1[2];
                    var txtto=mm+'/'+dd+'/'+yy;

                    }
                    if(dateformat=="mm/dd/yyyy")
                    {
                    var txtto=document.getElementById('txtto').value;
                    }
                    if(dateformat=="yyyy/mm/dd")
                    {
                    var txt=document.getElementById('txtto').value;
                    var txt1=txt.split("/");
                    var yy=txt1[0];
                    var mm=txt1[1];
                    var dd=txt1[2];
                    var txtto=mm+'/'+dd+'/'+yy;

                    }
                    if(dateformat==null || dateformat=="" || dateformat=="undefined")
                    {
                    var txtto=document.getElementById('txtto').value;
                    }
              //*************************CHECK DUPLIACY IN MODIFY MODE ONTHE BASIS OF DATE/STATUS*******************************//
                    
                   var chkres1= status_detail.checkstatusdate(drpstatus,txtfrom,txtto,compcode,userid,agencycode,agencysubcode,dateformat)
                   var chkds=chkres1.value;
                   if(chkds==null)
                   {
                     alert("ERROR : \n"+chkres1.error.description);
                     return false;
                   }
                   else
                   {
                     if(chkds.Tables[0].Rows.length>0)
                     {
                      alert("This date is already assigned.")
                      return false;
                     }
                   }
                   var attach=document.getElementById('hidattach1').value;
           //************************************************************************************//
                    status_detail.Submit(drpstatus,txtfrom,txtto,circular,compcode,userid,agencycode,agencysubcode,remarks,dateformat,attach);

                    document.getElementById('txtfrom').value="";
                    document.getElementById('txtto').value="";
                    document.getElementById('drpstatus').value="0";
                    //var remarks=document.getElementById('txtremark').value;
                    window.location=window.location;
                    return false;
                    // status_detail.statusinsert(agencycode,compcode,userid,txtfrom,txtto,circular,dateformat,remarks,subagencycode,call_statuschk)
                    //window.location=window.location;
                   }
            }
          else
            {
               //alert('Bank Save');
               return;
            }
        }
}






function call_statuschk(response)
{
var ds=response.value;

if(ds.Tables[0].Rows.length > 0)
{
alert("This Date Has Been Assigned");
return false;

}
else
{
var dateformat=document.getElementById('hiddendateformat').value;
var agencycode=document.getElementById('hiddenagevcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var agencysubcode=document.getElementById('hiddenagensubcode').value; 
//var txtfrom=document.getElementById('txtfrom').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtfrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtfrom=mm+'/'+dd+'/'+yy;
}
if(dateformat=="mm/dd/yyyy")
{
var txtfrom=document.getElementById('txtfrom').value;
}
 
 if(dateformat=="yyyy/mm/dd")
 {
 var txt=document.getElementById('txtfrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtfrom=mm+'/'+dd+'/'+yy;
 }
 if(dateformat==null || dateformat=="" || dateformat=="undefined")
 {
 var txtfrom=document.getElementById('txtfrom').value;
 }
//var txtto=document.getElementById('txtto').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtto').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtto=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtto=document.getElementById('txtto').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtto=document.getElementById('txtto').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtto').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtto=mm+'/'+dd+'/'+yy;
}
var drpstatus=document.getElementById('drpstatus').value;
var code=document.getElementById('hiddenccode').value;
var circular=document.getElementById('txtCircular').value;
//----------------------
var remarks=document.getElementById('txtremark').value;
//--------------------------------
var dateformat =document.getElementById('hiddendateformat').value;
var attach=document.getElementById('hidattach1').value;
status_detail.Submit(drpstatus,txtfrom,txtto,circular,compcode,userid,agencycode,agencysubcode,remarks,dateformat,attach);

document.getElementById('txtfrom').value="";
document.getElementById('txtto').value="";
document.getElementById('drpstatus').value="";

var remarks=document.getElementById('txtremark').value;

window.location=window.location;
//alert("Recod Sucessfully Save in database");
return ;

}



}

function call_statusupdate(response)
{
var ds=response.value;

if(ds.Tables[0].Rows.length > 0)
{
alert("This Date Has Been Assigned");
return false;

}

else
{
var dateformat=document.getElementById('hiddendateformat').value;
var agencycode=document.getElementById('hiddenagevcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var agencysubcode=document.getElementById('hiddenagensubcode').value; 

//var txtfrom=document.getElementById('txtfrom').value; 
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtfrom').value; 
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtfrom=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
var txtfrom=document.getElementById('txtfrom').value; 
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtfrom').value; 
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtfrom=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtfrom=document.getElementById('txtfrom').value; 
}


//var txtto=document.getElementById('txtto').value;

if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtto').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtto=mm+'/'+dd+'/'+yy;
}
if(dateformat=="mm/dd/yyyy")
{
var txtto=document.getElementById('txtto').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtto').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtto=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtto=document.getElementById('txtto').value;
}
var drpstatus=document.getElementById('drpstatus').value;
var code=document.getElementById('hiddenccode').value;
var circular=document.getElementById('txtCircular').value;
var remarks=document.getElementById('txtremark').value;


status_detail.Update(drpstatus,txtfrom,txtto,circular,agencycode,compcode,userid,agencysubcode,code,remarks,dateformat);
//status_detail.statusinsert(agencycode,compcode,userid,txtfrom,txtto,call_statuschk)
document.getElementById('txtfrom').value="";
document.getElementById('txtto').value="";
document.getElementById('drpstatus').value="";
//-------------------------------------------------------------
document.getElementById('txtremark').value="";
//==================================================
window.location=window.location;
//alert("Recod Sucessfully Save in database");
return false;

}

}





function selectstatus(ab)
{

var id=ab;

if(document.getElementById(id).checked==false)
        {
            cleardata('stat');
            return ;
        }


var dateformat=document.getElementById('hiddendateformat').value;
var agecode=document.getElementById('hiddenagevcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var agencysubcode=document.getElementById('hiddenagensubcode').value; 
var datagrid=document.getElementById('DataGrid1');

var j;
var k=0;
var t;
//var DataGrid1__ctl_CheckBox1= new Array();

var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));
document.getElementById(str).checked=false;
document.getElementById(id).checked=true;
//**//
if(id==str)
{
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	var statushidcode= document.getElementById(id).value;
	document.getElementById('hiddendelete').value=statushidcode;
	//document.getElementById('str').checked=true;
	 chk123=document.getElementById(id);
	//alert(chk123.checked+"1");
	//chk123.checked=true
	
	}
	}
	}
	if(k==1)
	{
	   if(document.getElementById('hiddensaurabh').value!="0")
	       document.getElementById('btndelete').disabled=false;
	      else
	        document.getElementById('btndelete').disabled=true;;
	    status_detail.databind1(agecode,compcode,userid,statushidcode,call_selectstatus);
	
	
	return false;
	
	}
	else if(k==0)
	{
	//chk123.checked=false;
	document.getElementById('txtfrom').value="";
document.getElementById('txtto').value="";
document.getElementById('drpstatus').value="";
//-------------------------------------------------------------
document.getElementById('txtremark').value="";
	return false;
	}
//	else
//	{
//	alert("You Can Select One Row At A Time");
//	return false;
//	}
	
	return false;
	

}

function call_selectstatus(response)
{

var ds= response.value;

//alert(chk123);
//alert(chk123.checked+"4");
chk123.checked=true;
var y=ds.Tables[0].Rows.length;
var z=0;
var j;
var t;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	t=j;
	t++;
	t++;
	var str="DataGrid1__ctl_CheckBox1"+t;
	
	var chk=str;
	chk=true;
	if(chk==true)
	{
	z=j;
	
	}
	
	}
	if(z.length > 1)
	{
	return false;
	}
	
	//document.getElementById('str').checked=true;
	var dateformat=document.getElementById('hiddendateformat').value;
	if(ds.Tables[0].Rows.length>0)
{



	document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].stat_code;
	
	var DateFrom=ds.Tables[0].Rows[0].From_date;
	
    //document.getElementById('hidattach1').value=ds.Tables[0].Rows[0].ATTACHMENT;
    if(ds.Tables[0].Rows[0].ATTACHMENT!=null && ds.Tables[0].Rows[0].ATTACHMENT!="")
                {
                    document.getElementById('hidattach1').value=ds.Tables[0].Rows[0].ATTACHMENT;
                    document.getElementById('attachment1').src="Images/indexred.jpg";
                } 
			
	var DateTo=ds.Tables[0].Rows[0].to_date;
			
	
	document.getElementById('drpstatus').value=ds.Tables[0].Rows[0].Status_name;
	if(ds.Tables[0].Rows[0].circular_no!=null)
	{
	document.getElementById('txtCircular').value=ds.Tables[0].Rows[0].circular_no;
	}
	else
	{
	document.getElementById('txtCircular').value="";
	}
	//==================
	if(ds.Tables[0].Rows[0].remarks!=null)
	{
	document.getElementById('txtremark').value=ds.Tables[0].Rows[0].remarks;
	}
	else
	{
	document.getElementById('txtremark').value="";
	}
	//====================
	
	//document.getElementById('txtremark').value=ds.Tables[0].Rows[0].circular_no;
	
if(ds.Tables[0].Rows[0].From_date != null && ds.Tables[0].Rows[0].From_date != "")
{
//document.getElementById('txtfrom').value=DateFrom;
if(dateformat=="dd/mm/yyyy")
{
var txt=DateFrom.split("/");
var mm=txt[0];
var dd=txt[1];
var yy=txt[2];
var datem=dd+'/'+mm+'/'+yy;
document.getElementById('txtfrom').value=datem;


}
if(dateformat=="mm/dd/yyyy")
{
document.getElementById('txtfrom').value=DateFrom;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=DateFrom.split("/");
var mm=txt[0];
var dd=txt[1];
var yy=txt[2];
var datem=yy+'/'+mm+'/'+dd;
document.getElementById('txtfrom').value=datem;

}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
document.getElementById('txtfrom').value=DateFrom;
}


}
else
{
document.getElementById('txtfrom').value="";
}

if(ds.Tables[0].Rows[0].to_date != null && ds.Tables[0].Rows[0].to_date != "")
{
//document.getElementById('txtto').value=DateTo;
if(dateformat=="dd/mm/yyyy")
{
var txt=DateTo.split("/");
var mm=txt[0];
var dd=txt[1];
var yy=txt[2];
var datem=dd+'/'+mm+'/'+yy;
document.getElementById('txtto').value=datem;
}
if(dateformat=="mm/dd/yyyy")
{
document.getElementById('txtto').value=DateTo;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=DateTo.split("/");
var mm=txt[0];
var dd=txt[1];
var yy=txt[2];
var datem=yy+'/'+mm+'/'+dd;
document.getElementById('txtto').value=datem;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
 {
document.getElementById('txtto').value=DateTo;
 }
 
}
else
{
document.getElementById('txtto').value="";
}
document.getElementById('hidden1').value=document.getElementById('txtfrom').value;
document.getElementById('hidden2').value=document.getElementById('txtto').value;
document.getElementById('hidden3').value=document.getElementById('drpstatus').value;
document.getElementById('hidden4').value=document.getElementById('txtCircular').value;
document.getElementById('hidden5').value=document.getElementById('txtremark').value;
}
return false;

}

function deletestatus()

{

var agecode=document.getElementById('hiddenagevcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var agencysubcode=document.getElementById('hiddenagensubcode').value; 
var hiddenccode=document.getElementById('hiddenccode').value; 
var datagrid=document.getElementById('DataGrid1')

var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	
	}
	}
	if(k==1)
	{
	var hiddendelete=document.getElementById('hiddendelete').value; 
	boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	status_detail.delete1(compcode,userid,agecode,agencysubcode,hiddendelete);
	}     
	else
	{
	return false;
	}	
	alert("Data Deleted Susseccfully");
	document.getElementById('btndelete').disabled=true;
	window.location=window.location;
	return false;
	
	}
	else
	{
	alert("You Should Select One Row");
	return false;
	}
	return false;

}


function allamount121()
		{
		var fld =document.getElementById('txtcommrate').value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{1,3})?$/i))
			{
			if(document.getElementById('txtcommrate').value>=100)
			{
			alert("Commission Rate should be less than 100%")
			document.getElementById('txtcommrate').value="";
			document.getElementById('txtcommrate').focus();
			return false;
			}
			else
			return true;
			}
			else
			{
			alert("Input error")
			document.getElementById('txtcommrate').value="";
			document.getElementById('txtcommrate').focus();
			return false;
			}
			
			}
	return true;
		}
		
		function allamount122()
		{
		if(document.getElementById('txtamount').value=="0")
		{
		alert("0 Should not be accepted as an amount");
		return false;
		}
		var fld =document.getElementById('txtamount').value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{2})?$/i))
			{
			return true;
			}
			else
			{
			alert("Input error")
			document.getElementById('txtamount').value="";
			document.getElementById('txtamount').focus();
			return false;
			}
			
			}
	return true;
		}
		
		
		
		function pubsubmit()
		{
		
		if(document.getElementById('drppub').value=="0")
{
alert("Please,Select The Code");
document.getElementById('drppub').focus();
return false;
}
		
		else if (document.getElementById('txtcommrate').value=="")
{
alert("Please,Fill The Commission Rate");
document.getElementById('txtcommrate').focus();
return false;
}
 
		
		
		if(document.getElementById('hiddenfield').value !="" && document.getElementById('hiddenfield').value!= null)
		
		{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var agencycode=document.getElementById('hiddenagencycode').value;
		var subagency=document.getElementById('hiddensubagencycode').value;
		var pub=document.getElementById('drppub').value;
		var commrate=document.getElementById('txtcommrate').value;
		var code=document.getElementById('hiddenfield').value;
		
		
		pub_mast.updatepub(compcode,userid,agencycode,subagency,pub,commrate,codepub);
		
		
		
		document.getElementById('drppub').value="";
		document.getElementById('txtcommrate').value="";
		
		document.getElementById('hiddenfield').value="";
		codepub="";
		window.location=window.location;
		return false;
		
		}
		else
		{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var agencycode=document.getElementById('hiddenagencycode').value;
		var subagency=document.getElementById('hiddensubagencycode').value;
		var pub=document.getElementById('drppub').value;
		var commrate=document.getElementById('txtcommrate').value;
		
		pub_mast.insertpub(compcode,userid,agencycode,subagency,pub,commrate);
		
		document.getElementById('hiddencompcode').value="";
		document.getElementById('hiddenuserid').value="";
		document.getElementById('hiddenagencycode').value="";
		document.getElementById('hiddensubagencycode').value="";
		document.getElementById('drppub').value="";
		document.getElementById('txtcommrate').value="";
		//document.getElementById('hiddenfield').value="";
		
		window.location=window.location;
		return false;
		
		
		}
		
	}
		
function pubselect()
		{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var agencycode=document.getElementById('hiddenagencycode').value;
		var subagency=document.getElementById('hiddensubagencycode').value;
		var pub=document.getElementById('drppub').value;
		var commrate=document.getElementById('txtcommrate').value;

var j;
var k=0;

//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	//alert(document.getElementById(str).value);
	codepub=document.getElementById(str).value;
	
	
	}
	}
	if(k==1)
	{
	document.getElementById('btndelete').disabled=false;
	pub_mast.bandpub(agencycode,subagency,compcode,userid,codepub,call_pub);
	return false;
	
	}
	else
	{
	alert("You Should Select One Row");
	return false;
	}
	return false;
	
}

function call_pub(response)
{
var ds=response.value;

document.getElementById('drppub').value=ds.Tables[0].Rows[0].pub_code;
document.getElementById('hiddenfield').value=ds.Tables[0].Rows[0].pub_code;
document.getElementById('txtcommrate').value=ds.Tables[0].Rows[0].Comm_rate;

return false;

}


function deletepub()
{

var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var agencycode=document.getElementById('hiddenagencycode').value;
		var subagency=document.getElementById('hiddensubagencycode').value;
		var pub=document.getElementById('drppub').value;
		var commrate=document.getElementById('txtcommrate').value;
		var code=document.getElementById('hiddenfield').value;
		
		pub_mast.deletpub(compcode,userid,agencycode,subagency,pub,commrate,codepub);
		
		document.getElementById('btndelete').disabled=true;
		
		document.getElementById('drppub').value="";
		document.getElementById('txtcommrate').value="";
		
		document.getElementById('hiddenfield').value="";
		codepub="";
		window.location=window.location;
		return false;


}

//------------------------------------previous code changed by saurabh------------------------


//*s*//
//function paymodesubmit()
//{
//var chk="";
//var codeofpay="";
//var hiddenagevcode=document.getElementById('hiddenagevcode').value;
//		var hiddencomcode=document.getElementById('hiddencomcode').value;
//		var hiddenuserid=document.getElementById('hiddenuserid').value;
//		var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;
//for(var j=0;j<=datainsert.Tables[0].Rows.length-1;j++)
//    {
//    var i=j;
//   
//    //alert(document.getElementById(i))
//    if(datainsert.Tables[0].Rows[i].Pay_Mode_Code!="")
//    {
//    if(document.getElementById(datainsert.Tables[0].Rows[i].Pay_Mode_Code).checked==true)
//        {
//         chk=datainsert.Tables[0].Rows[i].Pay_Mode_Code;
//         codeofpay=codeofpay+chk;
//        }
//        
//        }
//    
//    }
//    if(codeofpay=="")
//    {
//    alert("Please Enter Payment mode")
//    return false;
//    }
//     var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		        xml.Open("GET","paymodesession.aspx?codeofpay1="+codeofpay, false );
//		        xml.Send();
//	
//    //  agentpaymode.insertpaymode(hiddenagevcode,hiddencomcode,hiddenuserid,hiddenagensubcode,codeofpay);
//    
//     document.getElementById('btnSubmit').style.visibility="hidden";
//  //  document.getElementById('btnUpdate').style.visibility="visible";
//  //  document.getElementById('btnUpdate').disabled=false;
//    alert("Your payment mode submitted");
//	
//	return false;
//}

//function paymodeupdateddata()
//{
//var chkListSubmit= document.getElementById("chklstSubmit");
//	var arrayOfCheckBoxesSubmit= chkListSubmit.getElementsByTagName("input");
//	
//	var chklstUpdate= document.getElementById("chklstUpdate");
//	var arrayOfCheckBoxesUpdate= chklstUpdate.getElementsByTagName("input");
//	
//		
//	for(var i =0;i<=arrayOfCheckBoxesSubmit.length-1;i++)
//	{
//		if(arrayOfCheckBoxesSubmit[i].checked==true)
//		{
//			arrayOfCheckBoxesUpdate[i].checked=true;
//		}
//	}
//	
//	document.getElementById("chklstUpdate").disabled=false;
//	document.getElementById("btnUpdate").disabled=false;
//	return false;
//}

//function paymodeupdate()
//{

//		var chk="";
//var codeofpay="";
//        var hiddenagevcode=document.getElementById('hiddenagevcode').value;
//		var hiddencomcode=document.getElementById('hiddencomcode').value;
//		var hiddenuserid=document.getElementById('hiddenuserid').value;
//		var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;
//for(var j=0;j<=datainsert.Tables[0].Rows.length-1;j++)
//    {
//    var i=j;
//    
//    //alert(document.getElementById(i))
//    if(datainsert.Tables[0].Rows[i].Pay_Mode_Code!="")
//    {
//    if(document.getElementById(datainsert.Tables[0].Rows[i].Pay_Mode_Code).checked==true)
//        {
//         chk=datainsert.Tables[0].Rows[i].Pay_Mode_Code;
//         codeofpay=codeofpay+chk;
//        
//        }
//        }
//    
//    }
//    
//    if(codeofpay=="")
//    {
//    alert("Please Enter Payment Mode");
//    return false;
//    }
//      
//		agentpaymode.updatepaymode(hiddenagevcode,hiddencomcode,hiddenuserid,hiddenagensubcode,codeofpay);

//		
//	alert("Your Payment Mode Updated");
//	return false;

//}
//---------------------------------------------------------------change over-----------------------------

//----------------------------------new code for pay mode pop up by saurabh Agarwal------------------

//-----------------------------------------------------------------------------------
	
	//                          Saurabh Code for Payment Mode Pop Up
	
	//------------------------------------------------------------------------------------
	
	function paymodesubmit()
    {
	var chkList234= document.getElementById("chklistsubmit");
	var count_chk=0;
	
	var str;

	var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
		

	for(var j=0;j<arrayOfCheckBoxes.length;j++)
	{
		if(arrayOfCheckBoxes[j].checked==true)
			{
			count_chk=1;
			break;
			}
			else
			{
			count_chk=0;
			}
	}
	if(count_chk==0)
	{
		alert('Please Check One Mode of Payment');
		return false;
	}
	else
	{
	
		var compcode=document.getElementById('hiddencomcode').value;
		//var custcode=document.getElementById('hiddenclientcode').value; 
		var userid = document.getElementById('hiddenuserid').value; 
		
		for(var i=0;i<arrayOfCheckBoxes.length;i++)
		{
			if(arrayOfCheckBoxes[i].checked==true)
			{
				
				str=arrayOfCheckBoxes[i].value;
		
			}
		}
		return;
		document.getElementById("chklistsubmit").disabled=true;
		document.getElementById("btnSubmit").disabled=true;
		
	}

	return false;
}


//Client Refereshed Data

function ClientPayModeUpdatedData()
{
	
	var chkListSubmit= document.getElementById("chklistsubmit");
	var arrayOfCheckBoxesSubmit= chkListSubmit.getElementsByTagName("input");
	
	var chklstUpdate= document.getElementById("chklistsubmit");
	var arrayOfCheckBoxesUpdate= chklstUpdate.getElementsByTagName("input");
	
	var compcode=document.getElementById('hiddencomcode').value;
	//var custcode=document.getElementById('hiddenclientcode').value; 
	var userid = document.getElementById('hiddenuserid').value; 
		
	for(var i =0;i<=arrayOfCheckBoxesSubmit.length-1;i++)
	{
		if(arrayOfCheckBoxesSubmit[i].checked==true)
		{
			arrayOfCheckBoxesUpdate[i].checked=true;
		}
	}
	
	document.getElementById("chklistsubmit").disabled=false;
	document.getElementById("btnUpdate").disabled=false;
	return false;
}


//Updating Values 


function paymodeupdate()
{
	var chkList234= document.getElementById("chklistsubmit");
	var count_chk=0;

	var str;

	var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
		

	for(var j=0;j<arrayOfCheckBoxes.length;j++)
	{
		if(arrayOfCheckBoxes[j].checked==true)
			{
			count_chk=1;
			break;
			}
			else
			{
			count_chk=0;
			}
	}
	if(count_chk==0)
	{
		alert('Please Check One Mode of Payment');
		return false;
	}
	else
	{
	$('hiddenagecode').value=opener.document.getElementById('txtagencode').value;
		$('hiddenagencycode').value=opener.document.getElementById('txtsagencycode').value;
	return true;
	/*	var compcode=document.getElementById('hiddencomcode').value;
	
	
		var agecode=opener.document.getElementById('txtagencode').value;
		
	
	    var agencysubcode=opener.document.getElementById('txtsagencycode').value;
	    
		var userid = document.getElementById('hiddenuserid').value; 
		
		for(var i=0;i<arrayOfCheckBoxes.length;i++)
		{
			if(arrayOfCheckBoxes[i].checked==true)
			{
				
				str=str+arrayOfCheckBoxes[i].value;
		
			}
		}
		
//		ClientPaymode.AgencyPayModeInsert(compcode,agecode,agencysubcode,userid,str);
        
        agentpaymode.AgencyPayModeInsert(compcode,agecode,agencysubcode,userid,str);*/
        
	
	}
	return false;
}

	


//----------------------------------new code over-----------------------------------------------------
function tddisplay()
{

//payvisible();
var show=document.getElementById('hiddenshow').value;
			
		var hiddenagevcode=document.getElementById('hiddenagevcode').value;
		var hiddencomcode=document.getElementById('hiddencomcode').value;
		var hiddenuserid=document.getElementById('hiddenuserid').value;
		var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;

			if(show==1)
				{
				agentpaymode.chk(hiddencomcode,hiddenuserid,hiddenagevcode,hiddenagensubcode,callshow);
				
				}
				else
				{
				//document.getElementById('updat').style.display="block";
	var chkList2345= document.getElementById("chklistsubmit");
    var arrayOfCheckBoxes= chkList2345.getElementsByTagName("input");
    var sel=document.getElementById("hiddenval").value;
    for(var j=0;j<arrayOfCheckBoxes.length;j++)
    {
        if(arrayOfCheckBoxes[j].value==sel)
            {
                arrayOfCheckBoxes[j].checked=true;
                break;
            }
    }
				document.getElementById('updat1').style.display="block";
				}
//---------------------previous code(Change by saurabh)-----				
				
//			else
//				{
//				document.getElementById('updat').style.display="block";
//				document.getElementById('updat1').style.display="block";
//				chkview();
//				}
				
return false;
}


//----------------------------previous function(Change by saurabh)

//function callshow(res)
//{
//var ds=res.value;

//if(ds.Tables[0].Rows.length==0)
//{
//		document.getElementById('sub').style.display="block";
//		document.getElementById('sub1').style.display="block";
//}
//else
//{
//		document.getElementById('updat').style.display="block";
//	    document.getElementById('updat1').style.display="block";
//		document.getElementById('btnUpdate').disabled=false;

//}	
//payvisible();
////alert(chkboxforpay.checked+"1");
//return false;
//}
function callshow(res)
{
var ds=res.value;
if(ds.Tables[0].Rows.length==0)
//var show=document.getElementById('hiddenshow').value;
{
	document.getElementById('sub').style.display="block";
	
	var chkList234= document.getElementById("chklistsubmit");
	
    var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
    
    var sel1=document.getElementById("hiddenval").value;
    
    for(var j=0;j<arrayOfCheckBoxes.length;j++)
    {
        if(arrayOfCheckBoxes[j].value==sel1)
            {
                arrayOfCheckBoxes[j].checked=true;
                break;
            }
    }
		document.getElementById('sub1').style.display="block";
}
else
{
        document.getElementById('updat1').style.display="block";
        
		//document.getElementById('updat').style.display="block";
		
		var chkList2345= document.getElementById("chklistsubmit");
		
        var arrayOfCheckBoxes= chkList2345.getElementsByTagName("input");
        
        var sel=document.getElementById("hiddenval").value;
        
        for(var j=0;j<arrayOfCheckBoxes.length;j++)
        {
        if(arrayOfCheckBoxes[j].value==sel)
        {
            arrayOfCheckBoxes[j].checked=true;
                break;
        }
 }
		document.getElementById('updat1').style.display="block";
		
		document.getElementById('btnUpdate').disabled=true;
		

}	
}



function chkview()
{
       //document.getElementById('sub').style.display="none";
      //document.getElementById('sub1').style.display="none";		
    //document.getElementById('updat').style.display="block";
    //document.getElementById('updat1').style.display="block";

return false;
}

function productopen(res,name,strb)
{

update(event);
var code=res;
personname=name;
//for ( var index = 0; index < 200; index++ ) 
//          { 
//        //window.open('productag.aspx?code='+code);
//        popup=window.open('productag.aspx?code='+code,'Ankur2', 'status=0,toolbar=0,resizable=1,scrollbars=yes,top=244,left=210,width=180px,height=95px'); 
//        popup.focus();

//        //document.getElementById('txtproduct').value=
//        return false;
//           }
                    one="";
                     button="";
                     nexttable=""

                    document.getElementById('dislaypro').innerHTML=one+nexttable+button;
//    if(new_mode!="new")
//    {
        contact_detail.product(code,callproduct);
//    }
//    else
//    {
//        var xml=new ActiveXObject("Microsoft.XMLHTTP")
//        xml.Open( "GET","agency_chkpronew.aspx?", false );
//		xml.Send();
//		var dl=xml.responseText;
//    }

// saurabh                          contact_detail.product(code,callproduct);
 document.getElementById('dislaypro').style.visibility="visible";
//document.getElementById('dislaypro').style.display="Block";attachEvent






return false;
}
//L1T3
                   function callproduct(res)
                    {
                    if(new_mode!="new")
                    {
                    var ds=res.value;
                    var pro=ds.Tables[0].Rows[0].product;
                    if(pro==null)
                        return false;
                    var aftersplit=pro.split(",");
                    for(var i=0;i<=aftersplit.length-1;i++)
                        {
                            if(aftersplit[i]!=",")
                                {
                                    if(aftersplit[i]!="")
                                        {
                                        contact_detail.productname(aftersplit[i],callproductname);
                                        }
                                }
                        }
                    }
                    return false;
                    }

                    function callproductname(res)
                    {
                     if(new_mode!="yes")
                    {
                    var ds= res.value;
                   
                    //alert(ds.Tables[0].Rows[0].Product_Name);
                    var len=ds.Tables[0].Rows.length-1;
                  // variable for person name
                   //personname
                   // one="<table><tr><td>\"Product\"</td></tr></table>";
                   
                   one="<tr><td bgColor=\"#7daae3\" class=\"btnlink\"> "+"Product Of "+ personname+"</td></tr>" ;
//                   if(ds.Tables[0].Rows[0].Product_Name==""||ds.Tables[0].Rows[0].Product_Name=="null")
//                   {
//                        table="<tr><td>"+" "+"</td></tr>";
//                   }
//                   else
//                   {
                        if(ds.Tables[0].Rows.length>0)
                            table="<tr><td>"+ds.Tables[0].Rows[0].Product_Name+"</td></tr>";
                        else
                            table="<tr><td></td></tr>";    
//                   }
//                    table="<tr><td>"+ds.Tables[0].Rows[0].Product_Name+"</td></tr>";
                    nexttable=nexttable+table;
                    //button="<table><tr><td><input type='button' width='15px' id=\"close\" runat=\"server\" OnClick=\"javascript:return closediv();\" value=\"Close\" CssClass=\"buttongrid\"   /></td></tr></table>";
                    //button="<input type='button' onClick="hideDiv();" value="Close" />";
                    //button="<table ><tr><td align=right><a href='javascript:hideDiv()'><IMG SRC='"+imgDir+"close.gif' WIDTH='15' HEIGHT='13' BORDER='0' ALT='Close the Calendar'></a></td></tr></table>";
                      
                  //button="<table><tr><td><asp:button id=\"close\"  runat=\"server\" OnClick=\"javascript:return closediv();\" value=\"Close\" Text='Close'></asp:button></td></tr></table>"
                  
                  
                  //alert(ds.Tables[0].Rows[0].Product_Name);
//                  table=ds.Tables[0].Rows[0].Product_Name;
//                  nexttable=nexttable+","+table;
                 //alert(nexttable);
                  document.getElementById('dislaypro').innerHTML=null;
                    document.getElementById('dislaypro').innerHTML="<table cellSpacing=\"0\" cellPadding=\"0\"  width=\"125px\">"+one+nexttable+"</table>";
//                 
                     
                    }

                    return false;
                    }
                    function closediv()
                    {
                    //alert("hi");
                    one="";
                     button="";
                     nexttable=""

                    document.getElementById('dislaypro').innerHTML=one+nexttable+button;
                    document.getElementById('dislaypro').style.display="none";
                    return false;
                    }

function call_bindlist(response)
{
var ds=response.value;
var val=ds.Tables[0].Rows[0].product;
var var1=val.split(",");
var i;
var ListBox1= document.getElementById('ListBox1');

for(i=0;i<=var1.length-1;i++)
			{
				if(var1[i]!="")
				{
					if(var1[i]!="0")
					{
					    //document.getElementById('ListBox1').value=var1[i];
					    //document.getElementById('ListBox1').style.checked=true;
					    
						  ListBox1.options[i]=new Option(var1[i]);
						//ListBox1.Items.FindByValue("0").Selected=false;
						//ListBox1.option[i].value.selected

					}
				}
			}


}

function showdiv()
{
///to check whether phonew text is not blank
//if(document.getElementById('txtphoneno').value=="")
//{
//alert("Phone No. Should Not Be Blank");
//document.getElementById('txtphoneno').disabled=false;
//document.getElementById('txtphoneno').focus();
//return false;
//}
////////////////////////////////////////////////////


document.getElementById('Div1').style.visibility="visible";
 document.getElementById('txtmobile').focus();


return false;

}


		function fillproduct()
            {
            if(document.getElementById('ListBox2').value=="0")
             {
            return false;
            }
            document.getElementById('productbind').style.visibility="visible";
            var clientcode=document.getElementById('ListBox2').value;
            var comp=document.getElementById('hiddencomcode').value;
            var userid=document.getElementById('hiddenuserid').value;
           var agencycode=document.getElementById('hiddenagevcode').value; 
            var agencysubcode=document.getElementById('hiddenagensubcode').value; 
            
            contact_detail.addlistbox1(comp,userid,clientcode,agencycode,agencysubcode,filllist);
            
            return false;
            }

        function filllist(res)
        {
        var ds=res.value;
        datatable=ds;
        
    if(codeforsave=="" || codeforsave==null)
    {    
        
    var generatetd="<table  cellSpacing=\"0\" cellPadding=\"0\">";
    var into="";
     for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
     val=val+","+res.value.Tables[0].Rows[i].Product_Code;
     valofpro=val;
    into=into+"<tr>";
        into=into+"<td><input  type='checkbox' width='3px' id=chk"+i+" onclick=\"javascript:return hello();\"  value="+res.value.Tables[0].Rows[i].Product_Code+" /></td><td class=\"btextdivitem\">"+res.value.Tables[0].Rows[i].Product_Name+" </td>"
        into=into+"</tr>";
        generatetd=into;
       
    }
    //button="<table border=\"1\" cellSpacing=\"1\"  cellPadding=\"1\" style=\"width:700px;\"><tr><td border=\"1\" width=\"700px\"><input type='button' width=\"500px\"  id='proclick' text=\"submit\"/></td></tr></table>"
    var top="<table  cellSpacing=\"1\"  cellPadding=\"1\"  width\"200px\"><tr><td bgColor=\"#7daae3\" class=\"btnlink\" align=\"center\" width=\"150\"> "+"Product "+"</td></tr></table>" 
    generatetd="<table id=\"prod\" cellSpacing=\"0\" cellPadding=\"0\">"+into+"</table>"
    //button="<table  cellSpacing=\"1\"  cellPadding=\"1\" ><tr><td ><input type=\"button\" class=\"button1\"  id='proclick' onclick=\"javascript:return submitproductingrid();\"value=\"Submit\"/></td></tr></table>"
    document.getElementById('productbind').innerHTML=top+generatetd;
    //document.getElementById('productbind').innerHTML=button;
    chkboxtrue();
    }
    //when we click on the checkbox of grid to update the value
    else
    {
    if(another=="0")
    {
        var generatetd="<table  cellSpacing=\"0\" cellPadding=\"0\">";
    var into="";
     for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
     val=val+","+res.value.Tables[0].Rows[i].Product_Code;
     valofpro=val;
    into=into+"<tr>";
    
  into=into+"<td><input  type='checkbox' width='3px' id=chk"+i+" onclick=\"javascript:return updateclick();\"  value="+res.value.Tables[0].Rows[i].Product_Code+" /></td><td class=\"btextdivitem\">"+res.value.Tables[0].Rows[i].Product_Name+" </td>"



        into=into+"</tr>";
        generatetd=into;
       
    }
    //button="<table border=\"1\" cellSpacing=\"1\"  cellPadding=\"1\" style=\"width:700px;\"><tr><td border=\"1\" width=\"700px\"><input type='button' width=\"500px\"  id='proclick' text=\"submit\"/></td></tr></table>"
    var top="<table  cellSpacing=\"1\"  cellPadding=\"1\"  width\"200px\"><tr><td bgColor=\"#7daae3\" class=\"btnlink\" align=\"center\" width=\"150\"> "+"Product "+"</td></tr></table>" 
    generatetd="<table id=\"prod\" cellSpacing=\"0\" cellPadding=\"0\">"+into+"</table>"
    //button="<table  cellSpacing=\"1\"  cellPadding=\"1\" ><tr><td ><input type=\"button\" class=\"button1\"  id='proclick' onclick=\"javascript:return submitproductingrid();\"value=\"Submit\"/></td></tr></table>"
    document.getElementById('productbind').innerHTML=top+generatetd;
    
    
    
                                            var chkid=document.getElementById('prod');
                                            arrayforidupdate=codeforsave.split(",");
                                            
                                         for (var i = 0  ; i < datatable.Tables[0].Rows.length; ++i)
                                        {
                                        var box="chk"+i;

                                            for(var j=0;j<=arrayforidupdate.length-1;j++)
                                            {
                                                if(arrayforidupdate[j]!=",")
                                                {
                                                    if(arrayforidupdate[j]!="")
                                                    {
                                                        if(datatable.Tables[0].Rows[i].Product_Code==arrayforidupdate[j])
                                                        {
                                                            document.getElementById(box).checked=true;
                                                        }
                                                        else
                                                        {
                                                            document.getElementById(box).checked=false;
                                                        }
                                                    
                                                    }
                                                }
                                            
                                            }
                                            


                                            
                                           
                                        }
                                        chkboxtrue();
    
    
    }
    }
if(document.getElementById('hiddenccode').value != "" && document.getElementById('hiddenccode').value != null && another=="0")
{
//////////////////////////////////////////////////////////////if we do not click on the next client

        var page;
         var agencycode12=document.getElementById('hiddenagevcode').value; 
            var agencysubcode12=document.getElementById('hiddenagensubcode').value;
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
             httpRequest.onreadystatechange = function() {alertContents_chk(httpRequest) };
        
          
            httpRequest.open( "GET","getclient.aspx?page="+document.getElementById('hiddenccode').value+"&agencycode12="+agencycode12+"&agencysubcode12="+agencysubcode12, false );
            httpRequest.send('');
            id=httpRequest.responseText;
          
            

        }
        else
        { 
		    var xml = new ActiveXObject("Microsoft.XMLHTTP");
		    xml.Open( "GET","getclient.aspx?page="+document.getElementById('hiddenccode').value+"&agencycode12="+agencycode12+"&agencysubcode12="+agencysubcode12, false );
		    xml.Send();
		    id=xml.responseText;
        }


////////////////////////////////////////////////////////////////////////////////////////////

                                 var chkid=document.getElementById('prod');
        
      // alert(document.getElementById('prod').rows.length);
       for (var j=0; j<=chkid.rows.length-1;j++)
       {
                          var box="chk"+j;
                   if(document.getElementById(box).checked==true)
                   {
                   var alpha=document.getElementById(box);
                   chkcodeup11=alpha.value;
                   
                   chkvalueup11=chkvalueup11+chkcodeup11+",";
                  
                   }
                   
       }
       //alert(alpha.value);
       if(typeof(alpha)=="object")
       {
       alpha.checked=true;
       chkproup11=chkvalueup11;
       newupdatecon11=chkproup11+newupdatecon11;
       globalvalue=globalvalue+newupdatecon11+id;
       newupdatecon11="";
       chkproup11="";
       chkvalueup11="";
       
       
       }
       else
       {
        globalvalue=globalvalue+id;
       }


}    
else
{
//////////////////////////////////////////////////////////////////////////
if(another!="0")
{///////////////////////////
var splitvalue=globalvalue.split(",");
var generatetd="<table  cellSpacing=\"0\" cellPadding=\"0\">";
    var into="";
     for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
     val=val+","+res.value.Tables[0].Rows[i].Product_Code;
     valofpro=val;
    into=into+"<tr>";
    
  into=into+"<td><input  type='checkbox' width='3px' id=chk"+i+" onclick=\"javascript:return updateclick();\"  value="+res.value.Tables[0].Rows[i].Product_Code+" /></td><td class=\"btextdivitem\">"+res.value.Tables[0].Rows[i].Product_Name+" </td>"



        into=into+"</tr>";
        generatetd=into;
       
    }
    //button="<table border=\"1\" cellSpacing=\"1\"  cellPadding=\"1\" style=\"width:700px;\"><tr><td border=\"1\" width=\"700px\"><input type='button' width=\"500px\"  id='proclick' text=\"submit\"/></td></tr></table>"
    var top="<table  cellSpacing=\"1\"  cellPadding=\"1\"  width\"200px\"><tr><td bgColor=\"#7daae3\" class=\"btnlink\" align=\"center\" width=\"150\"> "+"Product "+"</td></tr></table>" 
    generatetd="<table id=\"prod\" cellSpacing=\"0\" cellPadding=\"0\">"+into+"</table>"
    //button="<table  cellSpacing=\"1\"  cellPadding=\"1\" ><tr><td ><input type=\"button\" class=\"button1\"  id='proclick' onclick=\"javascript:return submitproductingrid();\"value=\"Submit\"/></td></tr></table>"
    document.getElementById('productbind').innerHTML=top+generatetd;
    
    
    
                                            var chkid=document.getElementById('prod');
                                            arrayforidupdate=codeforsave.split(",");
                                            
                                         for (var i = 0  ; i < datatable.Tables[0].Rows.length; ++i)
                                        {
                                        var box="chk"+i;

                                            for(var j=0;j<=splitvalue.length-1;j++)
                                            {
                                                if(splitvalue[j]!=",")
                                                {
                                                    if(splitvalue[j]!="")
                                                    {
                                                        if(datatable.Tables[0].Rows[i].Product_Code==splitvalue[j])
                                                        {
                                                            document.getElementById(box).checked=true;
                                                        }
                                                    
                                                    }
                                                }
                                            
                                            }
                                            


                                            
                                           
                                        }
                                        }
                                        chkboxtrue();
                                        ////////////////////////////////////////////////////////

}
    
        return false;
        }	
        
        
       
        
        
        
        
        
        
        
        
        function submitproductingrid()
        {
        if(document.getElementById('txtcontactperson').value=="")
        {
        alert("Please Enter Contact Person");
        document.getElementById('txtcontactperson').focus();
        return false;
        }
        var newboxvalue="";
        var newprodname="";
       // alert("hello");
       // alert(document.getElementById('prod'));
        var chkid=document.getElementById('prod');
        
      // alert(document.getElementById('prod').rows.length);
       for (var j=0; j<=chkid.rows.length-1;j++)
       {
                   var box="chk"+j;
                   if(document.getElementById(box).checked==true)
                   {
                   var boxvalue=document.getElementById(box).value;
                   
                    newboxvalue=boxvalue+","+newboxvalue;
                    var prodname=datatable.Tables[0].Rows[j].Product_Name;
                    newprodname=prodname+","+newprodname;
                   }
                   
       }
       
       if(newboxvalue=="")
                   {
                   alert("You must select any product before submit");
                   return false;
                   }
       var clientcode=document.getElementById('ListBox2').value;
       var agencycode=document.getElementById('hiddenagevcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var agencysubcode=document.getElementById('hiddenagensubcode').value;
            var contactperson=document.getElementById('txtcontactperson').value;
            
      contact_detail.productinsert(newboxvalue,compcode,userid,clientcode,newprodname,contactperson,agencycode,agencysubcode)
      bindclientgrid(contactperson);
       return false;
        }
        





function bindclientgrid(a)
{
var comp=document.getElementById('hiddencomcode').value;
            var userid=document.getElementById('hiddenuserid').value;
           var agencycode=document.getElementById('hiddenagevcode').value; 
            var agencysubcode=document.getElementById('hiddenagensubcode').value; 

 contact_detail.checkuom(a,comp,userid,agencycode,agencysubcode,call_res);

return false;
}
function call_res(res)
{
var ds=res.value;

var generatetd="<table  cellSpacing=\"0\" cellPadding=\"0\">";
    var into="";
     for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
//     //val=val+","+res.value.Tables[0].Rows[i].Product_Code;
//     valofpro=val;
   into=into+"<tr>";
   
      into=into+"<td>"+res.value.Tables[0].Rows[i].Client+" </td><td>"+res.value.Tables[0].Rows[i].Product+" </td>"
        into=into+"</tr>";
        generatetd=into;
       
    }
    
    header="<tr><td bgColor=\"#7daae3\" class=\"btnlink\" align=\"center\">Client</td><td bgColor=\"#7daae3\" class=\"btnlink\" align=\"middle\">Product</td></tr>";
//    //button="<table border=\"1\" cellSpacing=\"1\"  cellPadding=\"1\" style=\"width:700px;\"><tr><td border=\"1\" width=\"700px\"><input type='button' width=\"500px\"  id='proclick' text=\"submit\"/></td></tr></table>"
  generatetd="<table id=\"prod\" cellSpacing=\"0\" cellPadding=\"0\" border=\"1\" class=\"btextdivitem\">"+header+into+"</table>"
////alert(document.getElementById("divGrid"));

//alert(generatetd);


document.getElementById("showgrid").innerHTML = generatetd;
return false;
}
        
        function productclose()
        {
        document.getElementById('dislaypro').style.visibility="hidden";
        return false;
        
        
        }
        
        
        
        function cleardata(form)
        {
         
        var chkstr=form;
        //alert("hi")
        if(chkstr=="cont")
        {
        document.getElementById('txtcontactperson').value="";
        document.getElementById('txtdesignation').value="";
        //---------------
        document.getElementById('drprole').value="0";
        //-----------------
        document.getElementById('txtdob').value="";
        document.getElementById('txtphoneno').value="";
        document.getElementById('txtext').value=""; 
        document.getElementById('txtfaxno').value="";
        document.getElementById('TextBox2').value="";
        document.getElementById('Div1').style.visibility="hidden";
        document.getElementById('productbind').style.visibility="hidden";
        document.getElementById('txtmobile').value="";
        document.getElementById('hiddenccode').value = "";
        document.getElementById('txtemcode').value = "";


       
        chk123.checked=false;
        //window.location=window.location;
        return false;
        }
        else if(chkstr=="comm")
        {
        document.getElementById('txtefffrom').value="";
        document.getElementById('txtefftill').value="";
        document.getElementById('txtcommrate').value="";
         document.getElementById('txtaddcomm').value="";
        document.getElementById('drpcommdetail').value="Gross";
        document.getElementById('drpadtype').value="0";
        document.getElementById('hiddenccode').value="";
        document.getElementById('drpuom').length="1";
        document.getElementById('drpagen').value="0";
        document.getElementById('drpcashdis').value="0";
        document.getElementById('txtcsamt').value="";
         chk123.checked=false;
        return false;
        }
        else if(chkstr=="stat")
        {
        document.getElementById('txtCircular').value="";
        document.getElementById('drpstatus').value="0";
        document.getElementById('txtremark').value="";
        document.getElementById('txtfrom').value="";
        document.getElementById('txtto').value="";
        document.getElementById('hiddenccode').value="";
        document.getElementById('attachment1').src="Images/index.jpeg"
	    document.getElementById('hidattach1').value="";
        chk123.checked=false;
        return false;
        }
        else(chkstr=="bank")
        {
        document.getElementById('txtbgno').value="";
        document.getElementById('txtamount').value="";
        document.getElementById('txtbank').value="";
        document.getElementById('txtbgdate').value="";
        document.getElementById('txtvaliditydate').value="";
        document.getElementById('hiddenccode').value = "";
        document.getElementById('attachment1').src = "Images/index.jpeg"
        
        
        
        
        
        chk123.checked=false;
        return false;
        }
        return false;
        }
        
        
        
        function update(ev)
        {
        var mouseX=ev.pageX?ev.pageX:ev.clientX;
        var mouseY=ev.pageY?ev.pageY:ev.clientY;
       
        var mosX = ev.clientX + document.body.scrollLeft ;
        var mosY = ev.clientY + document.body.scrollTop;
       
//        document.getElementById('dislaypro').style.top=mouseY;
//        document.getElementById('dislaypro').style.left=475;
//        document.getElementById('dislaypro').style.left=mouseX+25;
            
          document.getElementById('dislaypro').style.top=mosY;
          document.getElementById('dislaypro').style.left=mosX;  
        
        
        //var cor=mouseX + "," +mouseY
        return false;
        
        
        }
        
        
        function payvisible()
        {
             var hiddencomcode=document.getElementById('hiddencomcode').value;
		     var hiddenuserid=document.getElementById('hiddenuserid').value;
		

			if(document.getElementById('hiddenshow').value == "1" || document.getElementById('hiddenshow').value == "2")
			{
				
				agentpaymode.filldata(hiddencomcode,hiddenuserid,callpayvisibleforupdate);
			}
			
			else
			{
			    agentpaymode.filldata(hiddencomcode,hiddenuserid,callpayvisible);
			
			}
				
				
        return false;
        }
        
        function callpayvisible(res)
        {
        var ds =res.value;
        datainsert=ds;
        var generatetd="<table cellSpacing=\"0\" cellPadding=\"0\">";
    var into="";
    radiocount=ds.Tables[0].Rows.length;
     for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
     //val=val+","+res.value.Tables[0].Rows[i].Product_Code;
     valofpro=val;
    into=into+"<tr>";
        into=into+"<td style=\"WIDTH: 50px;\"><input  type='radio' width='3px' id="+i+"  /></td><td class=\"btextdivitem\" align=\"left\">"+res.value.Tables[0].Rows[i].Payment_Mode_Name+" </td>"
        into=into+"</tr>";
        generatetd=into;
       
    }
    generatetd="<table cellSpacing=\"0\" cellPadding=\"0\">"+into+"</table>"
    document.getElementById('sub').innerHTML=generatetd;
    document.getElementById('updat').innerHTML=generatetd;
        return false;
    
        }
   
        function callpayvisibleforupdate(res)
        {
        var ds =res.value;
        datainsert=ds;
        var generatetd="<table cellSpacing=\"0\" cellPadding=\"0\">";
    var into="";
     for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
     val=val+","+res.value.Tables[0].Rows[i].Pay_Mode_Code;
     valofpro=val;
    into=into+"<tr>";
        into=into+"<td style=\"WIDTH: 50px;\"><input  type='radio' width='3px' id="+res.value.Tables[0].Rows[i].Pay_Mode_Code+" OnClick=\"javascript:return chkradio('"+res.value.Tables[0].Rows[i].Pay_Mode_Code+"');\" /></td><td class=\"btextdivitem\" align=\"left\">"+res.value.Tables[0].Rows[i].Payment_Mode_Name+" </td>"
        into=into+"</tr>";
        generatetd=into;
       
    }
    generatetd="<table cellSpacing=\"0\" cellPadding=\"0\">"+into+"</table>"
    document.getElementById('sub').innerHTML=generatetd;
    //document.getElementById('updat').innerHTML=generatetd;
    var hiddenagevcode=document.getElementById('hiddenagevcode').value;
		var hiddencomcode=document.getElementById('hiddencomcode').value;
		var hiddenuserid=document.getElementById('hiddenuserid').value;
		var hiddenagensubcode=document.getElementById('hiddenagensubcode').value;

    	agentpaymode.chk(hiddencomcode,hiddenuserid,hiddenagevcode,hiddenagensubcode,fillradio);
			
//    var payvalue=document.getElementById('hiddenpayvalue').value;
//    var payarray=payvalue.split(",");
//    
//    if(payvalue!="")
//    {
//    document.getElementById('btnSubmit').style.visibility="hidden";
//    document.getElementById('btnUpdate').style.visibility="visible";
//    
//    for(var f=0;f<=payarray.length-1;f++)
//    {
//        if(payarray[f]!=",")
//            {
//                if(payarray[f]!="")
//                {
//                document.getElementById(payarray[f]).checked=true;
//                    
//                }
//             }
//    
//    
//    }
    
   // }
       
        return false;
        
     
        }
        
        
        ////////////////////////////////////////////////////////////////////////////////////////
        function fillradio(res)
        {
        var ds=res.value;
        if(ds.Tables[0].Rows.length>0)
        {
           if(ds.Tables[0].Rows[0].Cash !="")
            {
              for (var lcount=0;lcount<datainsert.Tables[0].Rows.length;lcount++)
              {
              if(datainsert.Tables[0].Rows[lcount].Pay_Mode_Code==ds.Tables[0].Rows[0].Cash)
                  {
                     document.getElementById(datainsert.Tables[0].Rows[lcount].Pay_Mode_Code).checked=true;
           
                  }
              }
                              
            }
        
        
        }
         return false;
        }
        
        
        
        
        
        function chkcompu(res)
        {
        var id=res.value;
        if(id=="")
        {
        
        alert("Please Select Product");
        return false;
        }
       
        
        
        }
        
        
        
        
        function proup(res)
        {
        
        var id=res.value;
        if(id=="")
        {
        
        alert("Please Select Product");
        return false;
        }
        

        }
        
        function hello()
        {
        
        
        //alert(document.getElementById(box));
        
        if(document.getElementById('txtcontactperson').value=="")
        {
        alert("Please Enter Contact Person");
        if(document.getElementById('txtcontactperson').disabled==false)
        document.getElementById('txtcontactperson').focus();
        return false;
        }
        
       // alert("hello");
       // alert(document.getElementById('prod'));
        var chkid=document.getElementById('prod');
        
      // alert(document.getElementById('prod').rows.length);
       for (var j=0; j<=chkid.rows.length-1;j++)
       {
                          var box="chk"+j;
                   if(document.getElementById(box).checked==true)
                   {
                   var alpha=document.getElementById(box);
                   chkcode=alpha.value;
                   
                   chkvalue=chkvalue+chkcode+",";
                  
                   }
                   
       }
       //alert(alpha.value);
       if(typeof(alpha)=="object")
       {
       alpha.checked=true;
       chkpro=chkvalue;
       }
       // return false;
        }
        
        function chkboxtrue()
        {
        var chkid=document.getElementById('prod');
        var arrayforid=chkpro.split(",");
        
     for (var i = 0  ; i < datatable.Tables[0].Rows.length; ++i)
    {
    var box="chk"+i;

        for(var j=0;j<=arrayforid.length-1;j++)
        {
            if(arrayforid[j]!=",")
            {
                if(arrayforid[j]!="")
                {
                    if(datatable.Tables[0].Rows[i].Product_Code==arrayforid[j])
                    {
                        document.getElementById(box).checked=true;
                    }
                
                }
            }
        
        }
        


        
       
    }
        
        }
        
       function updateclick()
       {
       another=1;
       if(document.getElementById('txtcontactperson').value=="")
        {
        alert("Please Enter Contact Person");
        document.getElementById('txtcontactperson').focus();
        return false;
        }
        
       // alert("hello");
       // alert(document.getElementById('prod'));
        var chkid=document.getElementById('prod');
        
      // alert(document.getElementById('prod').rows.length);
       for (var j=0; j<=chkid.rows.length-1;j++)
       {
                          var box="chk"+j;
                   if(document.getElementById(box).checked==true)
                   {
                   var alpha=document.getElementById(box);
                   chkcode=alpha.value;
                   
                   chkvalue=chkvalue+chkcode+",";
                   
                   }
                   else
                   {
                      var alpha=document.getElementById(box);
                   chkcode=alpha.value;
                    if(globalvalue.indexOf(chkcode+',') >=0)
                    {
                      globalvalue=globalvalue.replace(chkcode+',','');
                    }
                   }
                   
       }
       //alert(alpha.value);
       if(typeof(alpha)=="object")
       {
       alpha.checked=true;
       chkpro=chkvalue;
       }
       /////////////////////////////////////////////////////////////////////for update value
       var f;
       var c;
       var splitglobal=globalvalue.split(",");
       var splitchkpro=chkpro.split(",");
       for(f=0;f<=splitglobal.length-1;f++)
       {
            for(c=0;c<=splitchkpro.length-1;c++)
            {
                if(splitchkpro[c]!="")
                {
            
                        if(globalvalue.indexOf(splitchkpro[c])<0)
                        {
                        globalvalue=globalvalue+splitchkpro[c]+",";
                 
                        }
                 }
            }
       }
       
       ///////////////////////////////////////////////////////////////////////////////////////
       var chkvaluefalse="";
       var chcodefalse="";
       for (var j=0; j<=chkid.rows.length-1;j++)
       {
                          var box="chk"+j;
                   if(document.getElementById(box).checked==false)
                   {
                   var alpha=document.getElementById(box);
                   chcodefalse=alpha.value;
                   
                   chkvaluefalse=chkvaluefalse+chcodefalse+",";
                   
                   }
                   
       }
       /////////////////////////////////////////////////////////////////////////////////////////
       var splitvalue;
       var d;
       var x;
       splitvalue=chkvaluefalse.split(",");
       var spl=globalvalue.split(",");
       var dup=globalvalue;
       
       for(d=0;d<=splitvalue.length-1;d++)
       {
            if(globalvalue.indexOf(splitvalue[d])>= 0)
            {
            for(x=0;x<=spl.length-1;x++)
                {
            dup=dup.replace(splitvalue[d],"");
                }
            }
       }
       globalvalue=dup;
       
       
       
       }
       
       
       ///this function is for the contact detail pop up to check the duplicacy for contact name
       
       
       function chkcontactname()
       {
       var contactperson1=document.getElementById('txtcontactperson').value;
var agencycode1=document.getElementById('hiddenagevcode').value; 
var agencysubcode1=document.getElementById('hiddenagensubcode').value; 

////to check contact name

var page;
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
             httpRequest.onreadystatechange = function() {alertContents_chk(httpRequest) };
        
          
            httpRequest.open( "GET","chkname.aspx?page="+contactperson1+"&agencycode1="+agencycode1+"&agencysubcode1="+agencysubcode1, false );
            httpRequest.send('');
            id=httpRequest.responseText;
          
            

        }
        else
        {
		    var xml = new ActiveXObject("Microsoft.XMLHTTP");
		    xml.Open( "GET","chkname.aspx?page="+contactperson1+"&agencycode1="+agencycode1+"&agencysubcode1="+agencysubcode1, false );
		    xml.Send();
		    id=xml.responseText;
		}

if(id!="")
{
alert("This Name Is Already There");
document.getElementById('txtcontactperson').value="";
return false;
}
else
{
}
       
       }
       
       
       //////////////this function is for contact detail pop up to check whether the phone no is not blank
       
       function checkphone()
       {
       if(document.getElementById('txtphoneno').value=="")
{
alert("Phone No. Should Not Be Blank");
document.getElementById('txtphoneno').focus();
return false;
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////

 function chkradio(ab)
 {
 radioid=ab;
   var hiddencomcode=document.getElementById('hiddencomcode').value;
		     var hiddenuserid=document.getElementById('hiddenuserid').value;
		
 	agentpaymode.filldata(hiddencomcode,hiddenuserid,callpayvisibleforupdatechkbox);
	}
	
	
	function callpayvisibleforupdatechkbox(res)
	{	
	var ds=res.value;
	
 for (var kcount=0;kcount<ds.Tables[0].Rows.length;kcount++)
 {
 if(ds.Tables[0].Rows[kcount].Pay_Mode_Code!="")
 {
 document.getElementById(ds.Tables[0].Rows[kcount].Pay_Mode_Code).checked=false;

 document.getElementById(radioid).checked=true;

}
 }
  return;
 }
       
       
function newmode()
{
    new_mode="new";
    return;
}
function executemode()
{
    new_mode="execute";
    return;
}

function exec_agency()
{

//    var chklstUpdate= document.getElementById("chklistsubmit");
//	var arrayOfCheckBoxesUpdate= chklstUpdate.getElementsByTagName("input");
//		
//	for(var j=0;j<arrayOfCheckBoxesUpdate.length;j++)
//	{
//    arrayOfCheckBoxesUpdate[j].disabled=true;
//    arrayOfCheckBoxesUpdate[j].checked=false;
//	}
    return;
}
function onchage_adtype()
{
    var adtype = document.getElementById("drpadtype").value;
    var drpuom=document.getElementById("drpuom");
    var adcat=document.getElementById("dpadcat");
    
    drpuom.options.length=0;
    drpuom.options[0]=new Option("--Select UOM--","0");
    
    adcat.options.length=0;
    adcat.options[0]=new Option("---Select AdCat","0");
    
    if(adtype!="0")
    {
        bind_pkg_adcat_uom(adtype);
        bind_ad_cat(adtype);
        }
    return false;
}
function bind_pkg_adcat_uom(adtype)
{
    var compcode=document.getElementById("hiddencomcode").value;
    var res=Comm_detail.pkg_adcat_uom_bind(compcode, adtype);
    var ds=res.value;
    var drpuom=document.getElementById("drpuom");

    drpuom.options.length=0;
    drpuom.options[0]=new Option("--Select UOM--","0");
    
    var i;
//    if(ds!=null)
//    {
        if(ds.Tables[1].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[1].Rows.length; ++i)
            {
                drpuom.options[drpuom.options.length] = new Option(ds.Tables[1].Rows[i].Uom_Name,ds.Tables[1].Rows[i].Uom_Code);
                drpuom.options.length;   
            }
        }

}


function bind_ad_cat(adtype)
{
    var compcode=document.getElementById("hiddencomcode").value;
    var res=Comm_detail.pkg_adcat(compcode, adtype);
    var ds=res.value;
    var dpadcat=document.getElementById("dpadcat");
    

    dpadcat.options.length=0;
    dpadcat.options[0]=new Option("--Select AdCat--","0");
    
    var i;
//    if(ds!=null)
//    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                dpadcat.options[dpadcat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                dpadcat.options.length;   
            }
        }

}

function  alertContents_chk(httpRequest)
 {
 
  if (httpRequest.readyState == 4) 
    {
        //alert(httpRequest.status);
        if (httpRequest.status == 200) 
        {
             //alert('hi..');
          var str=httpRequest.responseText;
            
       
        }
        else 
        {
            alert('There was a problem with the request.');
        }
    }
 
 
 }
 function onchage_uom()
 {
    document.getElementById("hiddenuom").value=document.getElementById("drpuom").value;
 }
 function LTrim( value )
 {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 
{
	
	return LTrim(RTrim(value));
	
}
function chkamt()
{
var sau=parseFloat(document.getElementById('txtcsamt').value);
//document.getElementById('txtsharing').value=sau;

if(sau>100 && document.getElementById('drpcashdis').value=="P")
{
    alert("Cash Amount should not be greater than 100");
    document.getElementById('txtcsamt').value="";
    document.getElementById('txtcsamt').focus();
    return false;
}
var num=document.getElementById('txtcsamt').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtcsamt').value="";
document.getElementById('txtcsamt').focus();

return false; 

}
}
function openattach123()
{
//if(document.getElementById('LinkButton1').disabled==false)


var popUpWin2="";
popUpWin2 = window.open('bankgaurantee.aspx?filename=' + document.getElementById('hidattach2').value, 'Ankur12', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px')
  popUpWin2.focus();
    return false;
     
}




