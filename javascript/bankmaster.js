// JScript File
var chk123="";
var modify="0";
var city;
var code10;
function fillcity()
{
	var country=document.getElementById('drpcountryname').value;
	bank_master.addcou(country,callcount);
	return false;
}

function callcount(res)
{
	var ds=res.value;
	
	var pkgitem = document.getElementById("drpcity");
	if(ds.Tables[0].Rows.length==0)
	{
	 pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select City--","0");
    alert("Matching Value Not Found");

  	document.getElementById('drpcountryname').focus();
	return false;
	}
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select City--","0");
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
       pkgitem.options.length;
    }
    
    //alert(city);
    if(city == undefined || city=="")
 {
  document.getElementById('drpcity').value="0";
 
 }
 else
 {
  document.getElementById('drpcity').value=city;
  city="";
  } 
}


function submitdata()
{           if(document.getElementById('drpcountryname').value=="0")
			{
			alert("Please Enter the Country ");
			document.getElementById('drpcountryname').focus();
			return false;
			}
            else if(document.getElementById('drpcity').value=="0")
			{
			alert("Please Enter the City");
			document.getElementById('drpcity').focus();
			return false;
			}
			else if(document.getElementById('txtbno').value=="")
			{
			alert("Please Enter the Bank No.");
			document.getElementById('txtbno').focus();
			return false;
			}
			else if(document.getElementById('txtano').value=="")
			{
			alert("Please Enter the Account No.");
			document.getElementById('txtano').focus();
			return false;
			}
			else if(document.getElementById('txtname').value=="")
			{
			alert("Please Enter the bank name");
			document.getElementById('txtname').focus();
			return false;
			}
			else if(document.getElementById('txtbran').value=="")
			{
			alert("Please Enter the Branch name");
			document.getElementById('txtbran').focus();
			return false;
			}
			
			
			
			

			
			var bankname=document.getElementById('txtname').value;
			var branch=document.getElementById('txtbran').value;
			var country=document.getElementById('drpcountryname').value;
			var city=document.getElementById('drpcity').value;
			var bankno=document.getElementById('txtbno').value;
			var accountno=document.getElementById('txtano').value;

			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var agencode=document.getElementById('hiddenagencycode').value;
			var subagncode=document.getElementById('hiddenagensubcode').value;
			var codebk=document.getElementById('hiddenccode').value;
			
			document.getElementById('hiddencountry').value=country;
			document.getElementById('hiddencity').value=city;
			
//			        var dateformat="";
//                    //var status="";
//                    var hiddenagevcode=hiddenagevcode;
//                    var hiddenagensubcode=hiddenagensubcode;
//                    var bankname=bankname;
//                    var txtefftill=txtefftill;
//                    var drpcommdetail="";
//                    
//		            var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		            xml.Open( "GET","chkbank_mastdetail.aspx?hiddenagevcode="+hiddenagevcode+"&hiddenagensubcode="+hiddenagensubcode+"&dateformat="+dateformat+"&txtefffrom="+txtefffrom+"&txtefftill="+txtefftill+"&drpcommdetail="+drpcommdetail, false );
//		            xml.Send();
//		            var dl=xml.responseText;
			
			
			
			//if(modify!="1")
			if(opener.document.getElementById('hiddensaurabh').value!="modify")
			{
			        //alert('pankaj');
			        //alert('save');
			        return;
			 }
			   else
			    {
			    if(codebk=="" )//opener.document.getElementById('hiddenchk').value
                   {
                    var res=bank_master.chkBgNo(agencode,bankname);
                    if(res.value!=null)
                    {
                        if(res.value.Tables[1].Rows.length>0)
                        {
                            alert("This Bank Name already Exist");
                            return false;
                        }
                    }
                    
				    bank_master.insert(bankname,branch,country,city,bankno,accountno,compcode,userid,agencode,subagncode)
				    window.location=window.location;
				    return false;
			       }  
			       else
			       {
			        bank_master.update(bankname,branch,country,city,bankno,accountno,compcode,userid,agencode,subagncode,codebk)
 				    window.location=window.location;
 				    return false;
			       }  

			    }
			
			
			
				
			

	return false;
}


function selected(ab)
	{
	var id=ab;
	//alert('id');
	if(document.getElementById(id).checked==false)
        {
            cleardata();
            return ;
        }
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var agencode=document.getElementById('hiddenagencycode').value;
			var subagncode=document.getElementById('hiddenagensubcode').value;
			var datagrid=document.getElementById('DataGrid1');
			var j;
			var k=0;
		
			//var DataGrid1__ctl_CheckBox1= new Array();
			var i=document.getElementById("DataGrid1").rows.length -1;

			for(j=0;j<i;j++)
				{
				
					var str="DataGrid1__ctl_CheckBox1"+j;
					//alert(str);
					document.getElementById(str).checked=false;
                    document.getElementById(id).checked=true;
                    if(id==str)
                    {		
                    //alert(id);
						if(document.getElementById(id).checked==true)
						{
							k=k+1;
							code10=document.getElementById(id).value;
							chk123=document.getElementById(id);
						}
				    }
				}
		if(k==1)
			{
					document.getElementById('btndelete').disabled=false;
					bank_master.bandcontact(compcode,userid,agencode,subagncode,code10,call_select);
					return false;
			}
		else if(k==0)
	    {
		
				//alert("You Can Select One Row At A Time");
				document.getElementById('txtname').value="";
				document.getElementById('txtbran').value="";
				document.getElementById('drpcountryname').value="0";
				document.getElementById('drpcity').value="0";
				document.getElementById('txtano').value="";
				document.getElementById('txtbno').value="";
				return false;
				}
		return false;
}



function call_select(res)
{
var ds= res.value;
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

			document.getElementById('txtname').value=ds.Tables[0].Rows[0].bank_name;
			document.getElementById('txtbran').value=ds.Tables[0].Rows[0].branch;
			document.getElementById('drpcountryname').value=ds.Tables[0].Rows[0].Country;
			
			fillcity();
			city=ds.Tables[0].Rows[0].city;
			//document.getElementById('drpcity').value=ds.Tables[0].Rows[0].city;
			document.getElementById('txtbno').value=ds.Tables[0].Rows[0].bank_no;
			document.getElementById('txtano').value=ds.Tables[0].Rows[0].Acount_No;
			
			document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].autobank;
			
if(document.getElementById('hiddensaurabh').value==0)
{
            document.getElementById('btnsubmit').disabled = true;
            document.getElementById('btndelete').disabled = true;
            document.getElementById('txtano').disabled = true;
            document.getElementById('txtbno').disabled = true;
            document.getElementById('txtbran').disabled = true;
            document.getElementById('txtname').disabled = true;
            document.getElementById('drpcountryname').disabled = true;
            document.getElementById('drpcity').disabled = true;
}

return false;
}

function deleted()
{

	var compcode=document.getElementById('hiddencomcode').value;
	var userid=document.getElementById('hiddenuserid').value;
	var agencode=document.getElementById('hiddenagencycode').value;
	var subagncode=document.getElementById('hiddenagensubcode').value;
	var codebk=document.getElementById('hiddenccode').value;
//	boolReturn = confirm("Are you sure you wish to delete this?");
//	if(boolReturn==1)
//	{
//	bank_master.dele(compcode,userid,codebk)
//	
//	
//	}     
//	else
//	{
//	return false;
//	}	
//	
//	alert("Data Deleted Successfully");
//	window.location=window.location;

//return false;
//}


//new code by saurabh

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
	//var hiddendelete=document.getElementById('hiddendelete').value; 
	boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	bank_master.dele(compcode,userid,codebk);
	}     
	else
	{
	return false;
	}	
	alert("Data Deleted Successfully");
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


	


//Special Character Check Validator Function
function BankSpecialchar(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
	if((event.which>=48 && event.which<=57)||(event.which==32)||(event.which==8) || (event.which==0)||(event.which>=97 && event.which<=122)||(event.which==127)||(event.which>=65 && event.which<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
}
else
{
    if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==32)||(event.keyCode==8)||(event.keyCode>=97 && event.keyCode<=122)||(event.keycode==127)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
}
}
function ischarKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode == 31 || charCode == 45) || (charCode == 8) || (charCode >= 97 && charCode <= 122) || (charCode >= 65 && charCode <= 90) || (charCode >= 48 && charCode <= 57))
        return true;
    else
        return false;
}




function Bankacc(event) {
 
  var browser=navigator.appName;
  if (browser != "Microsoft Internet Explorer") 
 {

    
     if ((event.which >= 48 && event.which <= 57) || (event.which == 8) || (event.which == 0) || (event.which >= 97 && event.which <= 122) || (event.which == 127) || (event.which >= 65 && event.which <= 90) || (event.which == 9)) {
        
            return true;
                
          }
          else 
          {
          
             return false;
          }
}
else
{
         if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode>=97 && event.keyCode<=122)||(event.keycode==127)||(event.keyCode>=65 && event.keyCode<=90))
          {
            return true;
           
          }
          else
          {
             return false;
          }
} 
  }
  
  
  //UpperCase Function
function uppercase(q)
{

	document.getElementById(q).value=document.getElementById(q).value.toUpperCase();
	return false;
}


function cleardata()
{
document.getElementById('txtname').value="";
			document.getElementById('txtbran').value="";
			document.getElementById('drpcountryname').value="0";
			document.getElementById('drpcity').value="0";
			document.getElementById('txtbno').value="";
			document.getElementById('txtano').value="";
			document.getElementById('hiddenccode').value="";
			chk123.checked=false;
return false;
}