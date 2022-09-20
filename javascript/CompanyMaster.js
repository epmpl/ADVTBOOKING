// JScript File
var z=0;
var flag="0";
var hiddentext;
var auto="";
var colds;
var glcode;
var glname;
var glalias;
var browser=navigator.appName;
var xmlDoc=null;
var xmlObj=null;
var req=null;
var chknamemod;
var hiddenmodify="";
var modifydate = "No";

function addcount(cou)
{
    document.getElementById('txtDistrict').value="";
    document.getElementById('txtState').value="";
    if(typeof(cou)=="object")
    {
       var country=cou.value;
    }
    else
    {
       var country=cou;
    }
    //var country=document.getElementById('txtcountry').value;
    if(country!="0")
    {
      Company_Master.addcou(country,callcount);
    }
    else
    {
    document.getElementById("drpcity").options.length = 1;
    }
return false;
}

function callcount(res)
{

var ds=res.value;
var pkgitem = document.getElementById("drpcity");

if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length==0)
{
 pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select City--","0");
    document.getElementById('txtDistrict').value="";
    document.getElementById('txtState').value="";
}


if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select City--","0");
    document.getElementById('txtDistrict').value="";
    document.getElementById('txtState').value="";
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
        
       pkgitem.options.length;
       
    }
    //alert(cityvar);
// if(cityvar == undefined || cityvar=="")
// {
//  document.getElementById('drpcity').value="0";
// 
// }
// else
// {
//  document.getElementById('drpcity').value=cityvar;
//  cityvar="";
//  } 
}
//else
//{


////pkgitem.options[0]=new Option("--Select City--","0");

//////if(document.getElementById('txtcountry').disabled==false)
//////{
//////alert("There is no matching value(s) found");
//////}
////pkgitem.options.length=1;
////pkgitem.options[0]=new Option("--Select City--","0");
////addregcity();
////document.getElementById('drpcity').value="0";
////document.getElementById('drpregion').value="0";
////document.getElementById('drpzone').value="0";
////document.getElementById('txtdistrict').value="";
//////document.getElementById('Statecode12').value="";
////document.getElementById('txtstate').value="";
//return false;

//}

return false;
}


  function NewClick4()
    {
    var msg=checkSession();
    if(msg==false)
    return false;
    document.getElementById('txtintegration').value="";
    document.getElementById('txtintegration').disabled=false;
    document.getElementById('txtCompanyCode').value="";
    document.getElementById('txtvatinno').value="";
    document.getElementById('txtCompanyName').value="";
    document.getElementById('txtCompanyalias').value="";
    document.getElementById('txtCompanyadd').value="";
    document.getElementById('txtStreet').value="";
    document.getElementById('drpcity').value="0";
    document.getElementById('txtZip').value="";
    document.getElementById('txtDistrict').value="";
    //		var pcity=trim(document.getElementById('drpcity').value);
    document.getElementById('txtState').value="";
    document.getElementById('drpcountry').value="0";
    document.getElementById('txtPhone1').value="";
    document.getElementById('txtPhone2').value="";
    document.getElementById('txtfax').value="";
    document.getElementById('txtEmailid').value="";
    document.getElementById('txtStAcNo').value="";
    document.getElementById('txtPan').value="";
    document.getElementById('txtTan').value="";
    document.getElementById('txtRegno').value="";
    document.getElementById('txtRegdate').value="";
    document.getElementById('txtRemarks').value="";
    document.getElementById('txtBoxAdd').value="";
    document.getElementById('txtCompanyCode').disabled=false;
    document.getElementById('txtCompanyCode').disabled=false;
    document.getElementById('txtvatinno').disabled=false;
    document.getElementById('txtCompanyName').disabled=false;
    document.getElementById('txtCompanyalias').disabled=false;
    document.getElementById('txtCompanyadd').disabled=false;
    document.getElementById('txtStreet').disabled=false;
    document.getElementById('drpcity').disabled=false;
    var  abc =document.getElementById('drpcountry').value
    addcount(abc);
    //document.getElementById('drpcity').value="";
    document.getElementById('txtZip').disabled=false;
    document.getElementById('txtDistrict').disabled=true;
    //		var pcity=trim(document.getElementById('drpcity').value);
    document.getElementById('txtState').disabled=true;
    document.getElementById('drpcountry').disabled=false;
    document.getElementById('txtPhone1').disabled=false;
    document.getElementById('txtPhone2').disabled=false;
    document.getElementById('txtfax').disabled=false;
    document.getElementById('txtEmailid').disabled=false;
    document.getElementById('txtStAcNo').disabled=false;
    document.getElementById('txtPan').disabled=false;
    document.getElementById('txtTan').disabled=false;
    document.getElementById('txtRegno').disabled=false;
    document.getElementById('txtRegdate').disabled=false;
    document.getElementById('txtRemarks').disabled=false;
    document.getElementById('txtBoxAdd').disabled=false;
    document.getElementById('txtCompanyCode').focus();
    document.getElementById('txtdirpername').value = "";
    document.getElementById('txtdiradd').value = "";
    document.getElementById('txtdirstreet').value = "";
    document.getElementById('drpdircity').value = "0";
    document.getElementById('txtdirstate').value = "";
    document.getElementById('drpdircountry').value = "0";
    document.getElementById('txtdirdistrict').value = "";
    document.getElementById('txtdirzip').value = "";
    document.getElementById('txtdirphone1').value = "";
    document.getElementById('txtdirphone2').value = "";
    document.getElementById('txtdirfax').value = "";
    document.getElementById('txtdiremail').value = "";
    document.getElementById('txtstatezip').value = "";
    document.getElementById('txtcountryzip').value = "";
    document.getElementById('txtdirpername').disabled = false;
    document.getElementById('txtdiradd').disabled = false;
    document.getElementById('txtdirstreet').disabled = false;
    document.getElementById('drpdircity').disabled = false;
    document.getElementById('txtdirstate').disabled = false;
    document.getElementById('drpdircountry').disabled = false;
    document.getElementById('txtdirdistrict').disabled = false;
    document.getElementById('txtdirzip').disabled = false;
    document.getElementById('txtdirphone1').disabled = false;
    document.getElementById('txtdirphone2').disabled = false;
    document.getElementById('txtdirfax').disabled = false;
    document.getElementById('txtdiremail').disabled = false;
    document.getElementById('txtstatezip').disabled = false;
    document.getElementById('txtcountryzip').disabled = false;
    document.getElementById('btnSave').disabled = false;	
    document.getElementById('btnNew').disabled = true;	
    document.getElementById('btnQuery').disabled=true;
    //			 if(document.getElementById('hiddenauto').value==1)
    //		     {
    //		      document.getElementById('txtColorCode').disabled=true;
    //    	      }
    //		     else
    //		       {
    //		       document.getElementById('txtColorCode').disabled=false;
    //    	       }

    //			document.getElementById('txtColorName').disabled=false;
    //			document.getElementById('txtAlias').disabled=false;

    //			 if(document.getElementById('hiddenauto').value==1)
    //		     {
    //		      document.getElementById('txtColorName').focus();
    //    	      }
    //		     else
    //		       {
    //		       document.getElementById('txtColorCode').focus();
    //    	       }
    //			
    //			chkstatus(FlagStatus);
    hiddentext="new";
    //			document.getElementById('btnSave').disabled = false;	
    //			document.getElementById('btnNew').disabled = true;	
    //			document.getElementById('btnQuery').disabled=true;
    //			flag=0;
    setButtonImages();
    return false;
    }

function ModifyClick4()
{
			flag=1;
			hiddentext="modify";
			document.getElementById('txtvatinno').disabled=false;
			document.getElementById('txtCompanyCode').disabled=true;
			document.getElementById('txtCompanyName').disabled=false;
			 document.getElementById('txtintegration').disabled=false;
			document.getElementById('txtCompanyalias').disabled=false;
			 document.getElementById('txtCompanyadd').disabled=false;
	        document.getElementById('txtStreet').disabled=false;
		        document.getElementById('drpcity').disabled=false;
		        document.getElementById('txtZip').disabled=false;
	        document.getElementById('txtDistrict').disabled=true;
        //		var pcity=trim(document.getElementById('drpcity').value);
		        document.getElementById('txtState').disabled=true;
		        document.getElementById('drpcountry').disabled=false;
		        document.getElementById('txtPhone1').disabled=false;
	        document.getElementById('txtPhone2').disabled=false;
	        document.getElementById('txtfax').disabled=false;
		         document.getElementById('txtEmailid').disabled=false;
		        document.getElementById('txtStAcNo').disabled=false;
	        document.getElementById('txtPan').disabled=false;
		        document.getElementById('txtTan').disabled=false;
		        document.getElementById('txtRegno').disabled=false;
		        document.getElementById('txtBoxAdd').disabled=false;
		        document.getElementById('txtRegdate').disabled=false;
		        document.getElementById('txtRemarks').disabled=false;
			        chknamemod=document.getElementById('txtCompanyName').value;
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;
			
			chkstatus(FlagStatus);
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;
			document.getElementById('btnExecute').disabled=true;
			setButtonImages();
		    document.getElementById('btnSave').focus();
//			document.getElementById('btnModify').disabled = true;
//			document.getElementById('btnSave').disabled = false;
//			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnDelete').disabled=true;
			
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
			 document.getElementById('btnCancel').disabled = false;	
			document.getElementById('btnExit').disabled = false;	
			document.getElementById('btnModify').disabled=true;
			 document.getElementById('btnfirst').disabled = true;	
			document.getElementById('btnnext').disabled = true;	
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnExecute').disabled=true;

			return false;
}


function saveclick()
{
        var msg=checkSession();
        if(msg==false)
        return false;
        document.getElementById('txtCompanyCode').value=trim(document.getElementById('txtCompanyCode').value);
		document.getElementById('txtCompanyName').value=trim(document.getElementById('txtCompanyName').value);
		document.getElementById('txtCompanyalias').value=trim(document.getElementById('txtCompanyalias').value);
		document.getElementById('txtCompanyadd').value=trim(document.getElementById('txtCompanyadd').value);
		document.getElementById('txtStreet').value=trim(document.getElementById('txtStreet').value);
		document.getElementById('drpcity').value=trim(document.getElementById('drpcity').value);
		document.getElementById('txtZip').value=trim(document.getElementById('txtZip').value);
		document.getElementById('txtDistrict').value=trim(document.getElementById('txtDistrict').value);
		document.getElementById('drpcity').value=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value=trim(document.getElementById('txtState').value);
		document.getElementById('drpcountry').value=trim(document.getElementById('drpcountry').value);
		document.getElementById('txtPhone1').value=trim(document.getElementById('txtPhone1').value);
		document.getElementById('txtPhone2').value=trim(document.getElementById('txtPhone2').value);
		document.getElementById('txtfax').value=trim(document.getElementById('txtfax').value);
		document.getElementById('txtEmailid').value=trim(document.getElementById('txtEmailid').value);
		document.getElementById('txtStAcNo').value=trim(document.getElementById('txtStAcNo').value);
		document.getElementById('txtPan').value=trim(document.getElementById('txtPan').value);
		document.getElementById('txtTan').value=trim(document.getElementById('txtTan').value);
		document.getElementById('txtRegno').value=trim(document.getElementById('txtRegno').value);
		document.getElementById('txtRegdate').value=trim(document.getElementById('txtRegdate').value);
		document.getElementById('txtRemarks').value=trim(document.getElementById('txtRemarks').value);
		document.getElementById('txtBoxAdd').value=trim(document.getElementById('txtBoxAdd').value);
		document.getElementById('txtvatinno').value = trim(document.getElementById('txtvatinno').value);
		document.getElementById('txtintegration').value = trim(document.getElementById('txtintegration').value);
		  
       //dan
        var strtextd="";
        var  httpRequest =null;
        httpRequest= new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
           if(strtextd!="sess")
           {
            alert('session expired');
           window.location.href="Default.aspx";
           return false;
           } 
          if (flag==1) // in case of modify mode
		  {
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;

			if (document.getElementById('txtCompanyCode').value=="")
            {
				alert("Please Enter Company Code");
				document.getElementById('txtCompanyCode').focus();
				return false;
			}
			else
			{
			   var CompanyCode=document.getElementById('txtCompanyCode').value;
			}

			if (document.getElementById('txtCompanyName').value=="")
			{
					alert("Please Enter Company Name");
					document.getElementById('txtCompanyName').focus();
					return false;
			}
			else
			{
					var CompanyName=document.getElementById('txtCompanyName').value;
			}

			if (document.getElementById('txtCompanyalias').value=="")
			{
					alert("Please Enter Alias");
					document.getElementById('txtCompanyalias').focus();
					return false;
			}
			else
			{
					var Companyalias=document.getElementById('txtCompanyalias').value;
			}
			
			if (document.getElementById('txtCompanyadd').value=="")
			{
					alert("Please Enter Company Address");
					document.getElementById('txtCompanyadd').focus();
					return false;
			}
			else
			{
					var Companyadd=document.getElementById('txtCompanyadd').value;
			}

//			if (document.getElementById('txtStreet').value=="")
//			{
//					alert("Please Enter street");
//					document.getElementById('txtStreet').focus();
//					return false;
//			}
//			else
//			{
					var Street=document.getElementById('txtStreet').value;
//			}
              if (document.getElementById('drpcountry').value=="0")
			{
					alert("Please Enter country");
					document.getElementById('drpcountry').focus();
					return false;
			}
			else
			{
					var Country=document.getElementById('drpcountry').value;
			} 
			
              
            if (document.getElementById('drpcity').value=="0")
			{
					alert("Please Enter city");
					document.getElementById('drpcity').focus();
					return false;
			}
			else
			{
					var City=document.getElementById('drpcity').value;
			}
			
//			if (document.getElementById('txtZip').value=="")
//			{
//					alert("Please Enter Color State");
//					document.getElementById('txtZip').focus();
//					return false;
//			}
//			else
//			{
					var Zip=document.getElementById('txtZip').value;
//			}

            if (document.getElementById('txtState').value=="")
			{
					alert("Please Enter state");
					document.getElementById('txtState').focus();
					return false;
			}
			else
			{
					var State=document.getElementById('txtState').value;
			}
            var msg1= ClientEmailCheck1("txtEmailid");
            if(msg1==false)
                return false;
//			if (document.getElementById('txtDistrict').value=="")
//			{
//					alert("Please Enter Pincode");
//					document.getElementById('txtDistrict').focus();
//					return false;
//			}
//			else
//			{
					var District=document.getElementById('txtDistrict').value;
//			}
			

					var Phone1=document.getElementById('txtPhone1').value;
			
//			if (document.getElementById('txtPhone2').value=="")
//			{
//					alert("Please Enter Phone2");
//					document.getElementById('txtPhone2').focus();
//					return false;
//			}
//			else
//			{
					var Phone2=document.getElementById('txtPhone2').value;
//			}
			
//			   	if (document.getElementById('txtfax').value=="")
//			{
//					alert("Please Enter fax");
//					document.getElementById('txtfax').focus();
//					return false;
//			}
//			else
//			{
					var Fax=document.getElementById('txtfax').value;
//			}
			
//			if (document.getElementById('txtEmailid').value=="")
//			{
//					alert("Please Enter Emailid");
//					document.getElementById('txtEmailid').focus();
//					return false;
//			}
//			else
//			{
					var EmailId=document.getElementById('txtEmailid').value;
//			}
			
//			   	if (document.getElementById('txtStAcNo').value=="")
//			{
//					alert("Please Enter StAcNo");
//					document.getElementById('txtStAcNo').focus();
//					return false;
//			}
//			else
//			{
					var StAcNo=document.getElementById('txtStAcNo').value;
//			}
			
			 
			
//			   	if (document.getElementById('txtPan').value=="")
//			{
//					alert("Please Enter Pan");
//					document.getElementById('txtPan').focus();
//					return false;
//			}
//			else
//			{
					var Pan=document.getElementById('txtPan').value;
//			}
			
//			if (document.getElementById('txtTan').value=="")
//			{
//					alert("Please Enter Tan");
//					document.getElementById('txtTan').focus();
//					return false;
//			}
//			else
//			{
					var Tan=document.getElementById('txtTan').value;
//			}
			
			   	if (document.getElementById('txtRegno').value=="")
			{
					alert("Please Enter Registration No.");
					document.getElementById('txtRegno').focus();
					return false;
			}
			else
			{
					var Regno=document.getElementById('txtRegno').value;
			}
			
			if (document.getElementById('txtRegdate').value=="")
			{
					alert("Please Enter Registration Date.");
					document.getElementById('txtRegdate').focus();
					return false;
			}
			else
			{
					var Regdate=document.getElementById('txtRegdate').value;
			}
			
//			   	if (document.getElementById('txtRemarks').value=="")
//			{
//					alert("Please Enter Remarks");
//					document.getElementById('txtRemarks').focus();
//					return false;
//			}
//			else
//			{
					var Remarks=document.getElementById('txtRemarks').value;
//			}
			
//			if (document.getElementById('txtBoxAdd').value=="")
//			{
//					alert("Please Enter BoxAdd");
//					document.getElementById('txtBoxAdd').focus();
//					return false;
//			}
//			else
//			{
					var BoxAdd=document.getElementById('txtBoxAdd').value;
//			}
			
//              var str=document.getElementById('txtColorName').value;
              
               var vatinno=document.getElementById('txtvatinno').value;
               Company_Master.chkcompanyname(CompanyName,Call_Modify);
               return false;
			}
			else // in case of save mode
			{
					var compcode=document.getElementById('hiddencompcode').value;
					var userid=document.getElementById('hiddenuserid').value;
             
             if (document.getElementById('txtCompanyCode').value=="")
              
			{
					alert("Please Enter Company Code");
					document.getElementById('txtCompanyCode').focus();
					return false;
			}
			else
			{
					var CompanyCode=document.getElementById('txtCompanyCode').value;
			}

			if (document.getElementById('txtCompanyName').value=="")
			{
					alert("Please Enter Company Name");
					document.getElementById('txtCompanyName').focus();
					return false;
			}
			else
			{
					var CompanyName=document.getElementById('txtCompanyName').value;
			}

			if (document.getElementById('txtCompanyalias').value=="")
			{
					alert("Please Enter Alias");
					document.getElementById('txtCompanyalias').focus();
					return false;
			}
			else
			{
					var Companyalias=document.getElementById('txtCompanyalias').value;
			}
			
			if (document.getElementById('txtCompanyadd').value=="")
			{
					alert("Please Enter Company Address");
					document.getElementById('txtCompanyadd').focus();
					return false;
			}
			else
			{
					var Companyadd=document.getElementById('txtCompanyadd').value;
			}

//			if (document.getElementById('txtStreet').value=="")
//			{
//					alert("Please Enter street");
//					document.getElementById('txtStreet').focus();
//					return false;
//			}
//			else
//			{
					var Street=document.getElementById('txtStreet').value;
//			}
             
             if (document.getElementById('drpcountry').value=="0")
			{
					alert("Please Enter country");
					document.getElementById('drpcountry').focus();
					return false;
			}
			else
			{
					var Country=document.getElementById('drpcountry').value;
			} 
            if (document.getElementById('drpcity').value=="0")
			{
					alert("Please Enter city");
					document.getElementById('drpcity').focus();
					return false;
			}
			else
			{
					var City=document.getElementById('drpcity').value;
			}
			
//			if (document.getElementById('txtZip').value=="")
//			{
//					alert("Please Enter Color State");
//					document.getElementById('txtZip').focus();
//					return false;
//			}
//			else
//			{
					var Zip=document.getElementById('txtZip').value;
//			}

//			if (document.getElementById('txtDistrict').value=="")
//			{
//					alert("Please Enter Pincode");
//					document.getElementById('txtDistrict').focus();
//					return false;
//			}
//			else
//			{
					var District=document.getElementById('txtDistrict').value;
//			}
			
			
           
			
			if (document.getElementById('txtState').value=="")
			{
					alert("Please Enter state");
					if(document.getElementById('txtState').disabled!=true)
					document.getElementById('txtState').focus();
					return false;
			}
			else
			{
					var State=document.getElementById('txtState').value;
			}

			
			   var msg= ClientEmailCheck1("txtEmailid");
            if(msg==false)
                return false;
//			   	if (document.getElementById('txtPhone1').value=="")
//			{
//					alert("Please Enter Phone1");
//					document.getElementById('txtPhone1').focus();
//					return false;
//			}
//			else
//			{
					var Phone1=document.getElementById('txtPhone1').value;
//			}
			
//			if (document.getElementById('txtPhone2').value=="")
//			{
//					alert("Please Enter Phone2");
//					document.getElementById('txtPhone2').focus();
//					return false;
//			}
//			else
//			{
					var Phone2=document.getElementById('txtPhone2').value;
//			}
			
//			   	if (document.getElementById('txtfax').value=="")
//			{
//					alert("Please Enter fax");
//					document.getElementById('txtfax').focus();
//					return false;
//			}
//			else
//			{
					var Fax=document.getElementById('txtfax').value;
//			}
			
//			if (document.getElementById('txtEmailid').value=="")
//			{
//					alert("Please Enter Emailid");
//					document.getElementById('txtEmailid').focus();
//					return false;
//			}
//			else
//			{
					var EmailId=document.getElementById('txtEmailid').value;
//			}
			
//			   	if (document.getElementById('txtStAcNo').value=="")
//			{
//					alert("Please Enter StAcNo");
//					document.getElementById('txtStAcNo').focus();
//					return false;
//			}
//			else
//			{
					var StAcNo=document.getElementById('txtStAcNo').value;
//			}
			
			 
			
//			   	if (document.getElementById('txtPan').value=="")
//			{
//					alert("Please Enter Pan");
//					document.getElementById('txtPan').focus();
//					return false;
//			}
//			else
//			{
					var Pan=document.getElementById('txtPan').value;
//			}
			
//			if (document.getElementById('txtTan').value=="")
//			{
//					alert("Please Enter Tan");
//					document.getElementById('txtTan').focus();
//					return false;
//			}
//			else
//			{
					var Tan=document.getElementById('txtTan').value;
//			}
			
			   	if (document.getElementById('txtRegno').value=="")
			{
					alert("Please Enter Registration No.");
					document.getElementById('txtRegno').focus();
					return false;
			}
			else
			{
					var Regno=document.getElementById('txtRegno').value;
			}
			
			if (document.getElementById('txtRegdate').value=="")
			{
					alert("Please Enter Registration Date.");
					document.getElementById('txtRegdate').focus();
					return false;
			}
			else
			{
					var Regdate=document.getElementById('txtRegdate').value;
			}
			
//			   	if (document.getElementById('txtRemarks').value=="")
//			{
//					alert("Please Enter Remarks");
//					document.getElementById('txtRemarks').focus();
//					return false;
//			}
//			else
//			{
					var Remarks=document.getElementById('txtRemarks').value;
//			}
			
//			if (document.getElementById('txtBoxAdd').value=="")
//			{
//					alert("Please Enter BoxAdd");
//					document.getElementById('txtBoxAdd').focus();
//					return false;
//			}
//			else
//			{
					var BoxAdd=document.getElementById('txtBoxAdd').value;
//			}

					              var integration=document.getElementById('txtintegration').value;
              
                        
			var res=Company_Master.chkCompany(CompanyCode,CompanyName,Companyalias,Companyadd,Street,City,Zip,District,State,Country,Phone1,Phone2,Fax,EmailId,StAcNo,Pan,Tan,Regno,Regdate,Remarks,BoxAdd,userid,integration);//,call_save);
call_save(res)
			return false;
}
}

function call_save(response)
{
		var ds=response.value;
		
		if(document.getElementById('hiddenauto')!="1")
		{
		   if(ds.Tables[0].Rows.length > 0)
    	    {
			    alert("This Company Code Is Already Assigned.");
			    document.getElementById('txtCompanyCode').value="";
			     document.getElementById('txtCompanyCode').focus();
			    return false;
	   	    }
        }		
		if(ds.Tables[1].Rows.length > 0)
//		 0 && ds.tables[0].Rows.length > 0)
		{
				alert("This Company Name Is Already Assigned.");
			    document.getElementById('txtCompanyName').value="";
//			    document.getElementById('txtAlias').value="";
			    document.getElementById('txtCompanyName').focus();
				return false;
		}
		
//		else if(ds.tables[0].Rows.length > 0)
//		  {
//		    alert("This Color Name IS Already Assigned");
//		    return false;
//		  }
//		
		else
		 {
		 
		  var CompanyCode=trim(document.getElementById('txtCompanyCode').value);
		  var CompanyName=trim(document.getElementById('txtCompanyName').value);
		  var Companyalias=trim(document.getElementById('txtCompanyalias').value);
		  var Companyadd=trim(document.getElementById('txtCompanyadd').value);
	      var Street=trim(document.getElementById('txtStreet').value);
		  var City=trim(document.getElementById('drpcity').value);
		  var Zip=trim(document.getElementById('txtZip').value);
		  var District=trim(document.getElementById('txtDistrict').value);
//		  var pcity=trim(document.getElementById('drpcity').value);
		  var State=trim(document.getElementById('txtState').value);
		  var Country=trim(document.getElementById('drpcountry').value);
		  var Phone1=trim(document.getElementById('txtPhone1').value);
		  var Phone2=trim(document.getElementById('txtPhone2').value);
		  var Fax=trim(document.getElementById('txtfax').value);
		  var EmailId=trim(document.getElementById('txtEmailid').value);
		  var StAcNo=trim(document.getElementById('txtStAcNo').value);
		  var Pan=trim(document.getElementById('txtPan').value);
		  var Tan=trim(document.getElementById('txtTan').value);
		  var Regno=trim(document.getElementById('txtRegno').value);
		  var Regdate=trim(document.getElementById('txtRegdate').value);
		  var Remarks=trim(document.getElementById('txtRemarks').value);
		  var BoxAdd=trim(document.getElementById('txtBoxAdd').value);
		  var vatinno=trim(document.getElementById('txtvatinno').value);
//		  var compcode=document.getElementById('hiddencompcode').value;
		  var userid=document.getElementById('hiddenuserid').value;
		  var dateformat = document.getElementById('hiddendateformat').value;
		  var integration = trim(document.getElementById('txtintegration').value);
				
	//-----------------------------------------new change by rinki---------------------------------//

              /*  var txtdob;
				if(dateformat=="dd/mm/yyyy")
							{
								var txt=document.getElementById('txtRegdate').value;
								var txt1=txt.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								txtdob=mm+'/'+dd+'/'+yy;
								
								var currDate=new Date();
                                var userDate=document.getElementById('txtRegdate').value.split('/'); 
                                if(parseInt(userDate[1])>currDate.getMonth()+1)
                                {
                                    alert("Registration Date should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[2])>currDate.getFullYear())
                                {
                                    alert("Registration Date should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[0])>=currDate.getDate() && parseInt(userDate[1])==currDate.getMonth()+1 && parseInt(userDate[2])==currDate.getFullYear())
                                {
                                    alert("Registration Date should be less than Current Date");
                                    return false;
                                }
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								var currDate=new Date();
                                var userDate=document.getElementById('txtRegdate').value.split('/'); 
                                if(parseInt(userDate[0])>currDate.getMonth()+1)
                                {
                                    alert("Registration should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[2])>currDate.getFullYear())
                                {
                                    alert("Registration should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[1])>=currDate.getDate() && parseInt(userDate[0])==currDate.getMonth()+1 && parseInt(userDate[2])==currDate.getFullYear())
                                {
                                    alert("Registration should be less than Current Date");
                                    return false;
                                }
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtRegdate').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								txtdob=mm+'/'+dd+'/'+yy;
								
								var currDate=new Date();
                                var userDate=document.getElementById('txtRegdate').value.split('/'); 
                                if(parseInt(userDate[1],10)>parseInt(currDate.getMonth()+1,10))
                                {
                                    alert("Registration should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[0],10)>parseInt(currDate.getFullYear(),10))
                                {
                                    alert("Registration should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[2],10)>=parseInt(currDate.getDate(),10) && parseInt(userDate[1],10)==parseInt(currDate.getMonth()+1,10) && parseInt(userDate[0],10)==parseInt(currDate.getFullYear(),10))
                                {
                                    alert("Registration should be less than Current Date");
                                    return false;
                                }               
                                                               
                                
								
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								txtdob=document.getElementById('txtRegdate').value;
							}*/
						   var dateformat=document.getElementById('hiddendateformat').value;
				var txtdob="";
				if(document.getElementById('txtRegdate').value!="")
				{
				    if(dateformat=="dd/mm/yyyy")
					{
						var txt=document.getElementById('txtRegdate').value;
						var txt1=txt.split("/");
						var dd=txt1[0];
						var mm=txt1[1];
						var yy=txt1[2];
						txtdob=mm+'/'+dd+'/'+yy;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
						txtdob=document.getElementById('txtRegdate').value;
					}
								
					else if(dateformat=="yyyy/mm/dd")
					{
						var txt=document.getElementById('txtRegdate').value;
						var txt1=txt.split("/");
						var yy=txt1[0];
						var mm=txt1[1];
						var dd=txt1[2];
						txtdob=mm+'/'+dd+'/'+yy;
					}
					if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						txtdob=document.getElementById('txtRegdate').value;
					}
							
				    var dt=txtdob;
                    var dts=new Date(dt);
                    var dn=new Date();
				    if(dn<dts)
				    {
				        alert("Date should be less than or equal to current Date.");
				        document.getElementById('txtRegdate').value="";
				        document.getElementById('txtRegdate').focus();
				        return false;
    				    
				    }
				}
				var myDate = dateformat;
				var chunks = myDate.split('/'); 
                var formattedDate = chunks[1] + '-' + chunks[0] + '-' + chunks[2];
		//------------------------------------------------------------------------end ---------------------------------//

                Company_Master.saveCompany(CompanyCode, CompanyName, Companyalias, Companyadd, Street, City, Zip, District, State, Country, Phone1, Phone2, Fax, EmailId, StAcNo, Pan, Tan, Regno, txtdob, Remarks, BoxAdd, userid, formattedDate, vatinno, integration);
                if(browser!="Microsoft Internet Explorer")
                {
                    //alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);

                    savetab();
                   
                    alert("Data Saved Succesfully");
                }
                else
                {

                    savetab();
                    alert("Data Saved Succesfully");
                }
			
				//alert("Data Saved Successfully");

//				document.getElementById('txtColorCode').disabled=true;
//				document.getElementById('txtColorName').disabled=true;
//				document.getElementById('txtAlias').disabled=true;
//		
//				CancelClick4('ColorMaster');
		}
			   document.getElementById('txtCompanyCode').value="";
		       document.getElementById('txtCompanyName').value="";
	           document.getElementById('txtCompanyalias').value="";
		       document.getElementById('txtCompanyadd').value="";
	           document.getElementById('txtStreet').value="";
	           document.getElementById('drpcity').value="0";
		       document.getElementById('txtZip').value="";
	           document.getElementById('txtDistrict').value="";
//		       var pcity=trim(document.getElementById('drpcity').value);
		      document.getElementById('txtState').value="";
		      document.getElementById('drpcountry').value="0";
		      document.getElementById('txtPhone1').value="";
	          document.getElementById('txtPhone2').value="";
	          document.getElementById('txtfax').value="";
		      document.getElementById('txtEmailid').value="";
		      document.getElementById('txtStAcNo').value="";
	          document.getElementById('txtPan').value="";
		      document.getElementById('txtTan').value="";
		      document.getElementById('txtRegno').value="";
		      document.getElementById('txtBoxAdd').value="";
		      document.getElementById('txtRegdate').value="";
		      document.getElementById('txtRemarks').value="";
		      document.getElementById('txtvatinno').value = "";
		      document.getElementById('txtintegration').value = "";
		
		
		document.getElementById('txtCompanyCode').disabled=true;
  	 document.getElementById('txtCompanyCode').disabled=true;
  	 
		document.getElementById('txtCompanyName').disabled=true;
	document.getElementById('txtCompanyalias').disabled=true;
		   document.getElementById('txtCompanyadd').disabled=true;
	document.getElementById('txtStreet').disabled=true;
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtZip').disabled=true;
	document.getElementById('txtDistrict').disabled=true;
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').disabled=true;
		document.getElementById('drpcountry').disabled=true;
		document.getElementById('txtPhone1').disabled=true;
	document.getElementById('txtPhone2').disabled=true;
	document.getElementById('txtfax').disabled=true;
		 document.getElementById('txtEmailid').disabled=true;
		document.getElementById('txtStAcNo').disabled=true;
	document.getElementById('txtPan').disabled=true;
		document.getElementById('txtTan').disabled=true;
		document.getElementById('txtRegno').disabled=true;
		document.getElementById('txtRegdate').disabled=true;
		document.getElementById('txtRemarks').disabled=true;
		document.getElementById('txtBoxAdd').disabled=true;
		document.getElementById('txtvatinno').disabled = true;
		document.getElementById('txtintegration').disabled = true;
//				var compcode=document.getElementById('hiddencompcode').value;
//				var userid=document.getElementById('hiddenuserid').value;

               document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnExit').disabled=false;	
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;
			setButtonImages();
			document.getElementById('btnNew').focus();
		return false;
}

function QueryClick4()
{

			hiddentext="query";
//			chkstatus(FlagStatus);


			
			 document.getElementById('txtCompanyCode').value="";
		document.getElementById('txtCompanyName').value="";
	document.getElementById('txtCompanyalias').value="";
		   document.getElementById('txtCompanyadd').value="";
	document.getElementById('txtStreet').value="";
		document.getElementById('drpcity').value="0";
		document.getElementById('txtZip').value="";
	document.getElementById('txtDistrict').value="";
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value="";
		document.getElementById('drpcountry').value="0";
		document.getElementById('txtPhone1').value="";
	document.getElementById('txtPhone2').value="";
	document.getElementById('txtfax').value="";
		 document.getElementById('txtEmailid').value="";
		document.getElementById('txtStAcNo').value="";
	document.getElementById('txtPan').value="";
		document.getElementById('txtTan').value="";
		document.getElementById('txtRegno').value="";
		document.getElementById('txtBoxAdd').value="";
		document.getElementById('txtRegdate').value="";
		document.getElementById('txtRemarks').value="";
		document.getElementById('txtvatinno').value="";
		
		document.getElementById('txtCompanyCode').disabled=false;
  	 document.getElementById('txtCompanyCode').disabled=false;
  	 
		document.getElementById('txtCompanyName').disabled=false;
	document.getElementById('txtCompanyalias').disabled=false;
		   document.getElementById('txtCompanyadd').disabled=true;
	document.getElementById('txtStreet').disabled=true;
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtZip').disabled=true;
	document.getElementById('txtDistrict').disabled=true;
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').disabled=true;
		document.getElementById('drpcountry').disabled=true;
		document.getElementById('txtPhone1').disabled=true;
	document.getElementById('txtPhone2').disabled=true;
	document.getElementById('txtfax').disabled=true;
		 document.getElementById('txtEmailid').disabled=true;
		document.getElementById('txtStAcNo').disabled=true;
	document.getElementById('txtPan').disabled=true;
		document.getElementById('txtTan').disabled=true;
		document.getElementById('txtRegno').disabled=true;
		document.getElementById('txtRegdate').disabled=true;
		document.getElementById('txtRemarks').disabled=true;
		document.getElementById('txtBoxAdd').disabled=true;
		document.getElementById('txtvatinno').disabled=true;
		
		chkstatus(FlagStatus);
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			setButtonImages();
			document.getElementById('btnExecute').focus();
			
			
			return false;
}

function ExecuteClick4()
{
 var msg=checkSession();
        if(msg==false)
        return false;
    document.getElementById('txtCompanyName').value=document.getElementById('txtCompanyName').value.toUpperCase();
        var CompanyCode=trim(document.getElementById('txtCompanyCode').value);
		var CompanyName=trim(document.getElementById('txtCompanyName').value);
		var Companyalias=trim(document.getElementById('txtCompanyalias').value);
			var userid=document.getElementById('hiddenuserid').value;

//			var compcode=document.getElementById('hiddencompcode').value;
//			var userid=document.getElementById('hiddenuserid').value;
//			var ColorCode=document.getElementById('txtColorCode').value;
//			var ColorName=document.getElementById('txtColorName').value;
//			var Alias=document.getElementById('txtAlias').value; 
			
			
	            glcode=document.getElementById('txtCompanyCode').value;
				glname=document.getElementById('txtCompanyName').value;
				glalias=document.getElementById('txtCompanyalias').value;

			//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Company_Master.Select(CompanyCode,CompanyName,Companyalias,userid,call_Execute);
			updateStatus();
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled = false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;
setButtonImages();
	if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();	
			return false;
}

function call_Execute(response)
{
		//var ds=response.value;
		colds=response.value;

		if(colds.Tables[0].Rows.length>0)
		{
		  document.getElementById('txtCompanyCode').value=colds.Tables[0].Rows[0].Comp_Code;
		  document.getElementById('txtCompanyName').value=colds.Tables[0].Rows[0].Comp_Name;
	      document.getElementById('txtCompanyalias').value=colds.Tables[0].Rows[0].Comp_Alias;
		  document.getElementById('txtCompanyadd').value=colds.Tables[0].Rows[0].Add1;
		  document.getElementById('drpcountry').value=colds.Tables[0].Rows[0].Country_Code;
         
          var res=Company_Master.addcou(colds.Tables[0].Rows[0].Country_Code);
            bindcity(res);		
            if(colds.Tables[0].Rows[0].Street=="null" || colds.Tables[0].Rows[0].Street==null)
			{   
	         document.getElementById('txtStreet').value="";
	      	}
			else
			{
			  document.getElementById('txtStreet').value=colds.Tables[0].Rows[0].Street;
	        }
	     	document.getElementById('drpcity').value=colds.Tables[0].Rows[0].City_Code;
		
		    if(colds.Tables[0].Rows[0].Zip=="null" || colds.Tables[0].Rows[0].Zip==null)
			{   
	          document.getElementById('txtZip').value="";
	      	}
			else
			{
			document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;;
			}
		//document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;
		    if(colds.Tables[0].Rows[0].Dist_Code=="null" || colds.Tables[0].Rows[0].Dist_Code==null)
			{   
	         document.getElementById('txtDistrict').value="";
	      	}
			else
			{
			document.getElementById('txtDistrict').value=colds.Tables[0].Rows[0].Dist_Code;
			
			}
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value=colds.Tables[0].Rows[0].State_Code;
		
		  if(colds.Tables[0].Rows[0].Phone1=="null" || colds.Tables[0].Rows[0].Phone1==null)
			{  
		    document.getElementById('txtPhone1').value="";
		    }
			else
			{
			document.getElementById('txtPhone1').value=colds.Tables[0].Rows[0].Phone1;
			
			}
			
			 if(colds.Tables[0].Rows[0].Phone2=="null" || colds.Tables[0].Rows[0].Phone2==null)
			{  
			document.getElementById('txtPhone2').value="";
            }
			else
			{
			document.getElementById('txtPhone2').value=colds.Tables[0].Rows[0].Phone2;
			}
			
			 if(colds.Tables[0].Rows[0].Fax=="null" || colds.Tables[0].Rows[0].Fax==null)
			{  
	         document.getElementById('txtfax').value="";
		     }
			else
			{
			document.getElementById('txtfax').value=colds.Tables[0].Rows[0].Fax;
			}
			
			 if(colds.Tables[0].Rows[0].EmailID=="null" || colds.Tables[0].Rows[0].EmailID==null)
			{  
		     document.getElementById('txtEmailid').value="";
		 	}
			else
			{
			  document.getElementById('txtEmailid').value=colds.Tables[0].Rows[0].EmailID;
			}
			
			 if(colds.Tables[0].Rows[0].ST_Acc_No=="null" || colds.Tables[0].Rows[0].ST_Acc_No==null)
			{  
		     document.getElementById('txtStAcNo').value="";
			}
			else
			{
			document.getElementById('txtStAcNo').value=colds.Tables[0].Rows[0].ST_Acc_No;
			}
			
		   if(colds.Tables[0].Rows[0].PAN_No=="null" || colds.Tables[0].Rows[0].PAN_No==null)
			{  
		     document.getElementById('txtPan').value="";
		    }
			else
			{
			document.getElementById('txtPan').value=colds.Tables[0].Rows[0].PAN_No;
			}
			
			if(colds.Tables[0].Rows[0].TAN_No=="null" || colds.Tables[0].Rows[0].TAN_No==null)
			{  
		     document.getElementById('txtTan').value="";
		    }
			else
			{
			document.getElementById('txtTan').value=colds.Tables[0].Rows[0].TAN_No;
			}
			
			 if(colds.Tables[0].Rows[0].Reg_No=="null"||colds.Tables[0].Rows[0].Reg_No==null)
			{  
		     document.getElementById('txtRegno').value="";
		    }
			else
			{
			    document.getElementById('txtRegno').value = colds.Tables[0].Rows[0].Reg_No;
           }
			if (colds.Tables[0].Rows[0].INTEGRATION_ID == "null" || colds.Tables[0].Rows[0].INTEGRATION_ID == null) {
               document.getElementById('txtintegration').value = "";
              }
           else {
               document.getElementById('txtintegration').value = colds.Tables[0].Rows[0].INTEGRATION_ID;
            }
		    document.getElementById('btnSave').disabled = true;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=false;
			 document.getElementById('btnCancel').disabled = false;	
			document.getElementById('btnExit').disabled = false;	
			if(document.getElementById('btnModify').disabled==false)
			   document.getElementById('btnModify').focus();
			 document.getElementById('btnfirst').disabled = true;	
			document.getElementById('btnnext').disabled = false;	
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			
			//document.getElementById('btnModify').focus();
		var dateformat=document.getElementById('hiddendateformat').value; 
		
		if(colds.Tables[0].Rows[0].Reg_Date != "null" && colds.Tables[0].Rows[0].Reg_Date != "")
			{
			var validate_fromdate=colds.Tables[0].Rows[0].Reg_Date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtRegdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtRegdate').value="";
			}
//		document.getElementById('txtRegdate').value=colds.Tables[0].Rows[0].REG_DATE;
		   if(colds.Tables[0].Rows[0].Remarks== "null" || colds.Tables[0].Rows[0].Remarks==null)
			{  
	     	 document.getElementById('txtRemarks').value="";
		    }
			else
			{
			 document.getElementById('txtRemarks').value=colds.Tables[0].Rows[0].Remarks;
			}
			
			if(colds.Tables[0].Rows[0].Box_Address== "null" || colds.Tables[0].Rows[0].Box_Address==null)
			{  
		     document.getElementById('txtBoxAdd').value="";  
		    }
			else
			{
			document.getElementById('txtBoxAdd').value=colds.Tables[0].Rows[0].Box_Address;
			}
		
		   if(colds.Tables[0].Rows[0].VAT_TINNO== "null" || colds.Tables[0].Rows[0].VAT_TINNO==null)
			{  
		     document.getElementById('txtvatinno').value="";  
		    }
			else
			{
			document.getElementById('txtvatinno').value=colds.Tables[0].Rows[0].VAT_TINNO;
			}
		    
				/*glcode=document.getElementById('txtColorCode').value;
				glname=document.getElementById('txtColorName').value;
				glalias=document.getElementById('txtAlias').value;*/
				
				 document.getElementById('txtCompanyCode').disabled=true;
		document.getElementById('txtCompanyName').disabled=true;
	document.getElementById('txtCompanyalias').disabled=true;
		   document.getElementById('txtCompanyadd').disabled=true;
	document.getElementById('txtStreet').disabled=true;
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtZip').disabled=true;
	document.getElementById('txtDistrict').disabled=true;
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').disabled=true;
		document.getElementById('drpcountry').disabled=true;
		document.getElementById('txtPhone1').disabled=true;
	document.getElementById('txtPhone2').disabled=true;
	document.getElementById('txtfax').disabled=true;
		 document.getElementById('txtEmailid').disabled=true;
		document.getElementById('txtStAcNo').disabled=true;
	document.getElementById('txtPan').disabled=true;
		document.getElementById('txtTan').disabled=true;
		document.getElementById('txtRegno').disabled=true;
		document.getElementById('txtBoxAdd').disabled=true;
		document.getElementById('txtRegdate').disabled=true;
		document.getElementById('txtRemarks').disabled=true;
		document.getElementById('txtvatinno').disabled=true;
		
			
				z=0;
		}
		else
		{
//				document.getElementById('btnModify').disabled=true;
//				document.getElementById('btnDelete').disabled=true;
//				document.getElementById('txtColorCode').disabled=true;
//				document.getElementById('txtColorName').disabled=true;
//				document.getElementById('txtAlias').disabled=true;
				
				CancelClick4('ColorMaster');
				alert("This Search Criteria Does Not Exist");
		}
		
		
		if(colds.Tables[0].Rows.length==1)
		{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
		
		}

		EnableExecute();
		setButtonImages();
		
		return false;
}


function CancelClick4(formname)
{
       chkstatus(FlagStatus);
	   givebuttonpermission(formname);
        hiddentext="";
        document.getElementById('txtCompanyCode').value="";
		document.getElementById('txtCompanyName').value="";
	document.getElementById('txtCompanyalias').value="";
		   document.getElementById('txtCompanyadd').value="";
	document.getElementById('txtStreet').value="";
		document.getElementById('drpcity').value="0";
		document.getElementById('txtZip').value="";
	document.getElementById('txtDistrict').value="";
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value="";
		document.getElementById('drpcountry').value="0";
		document.getElementById('txtPhone1').value="";
	document.getElementById('txtPhone2').value="";
	document.getElementById('txtfax').value="";
		 document.getElementById('txtEmailid').value="";
		document.getElementById('txtStAcNo').value="";
	document.getElementById('txtPan').value="";
		document.getElementById('txtTan').value="";
		document.getElementById('txtRegno').value="";
		document.getElementById('txtBoxAdd').value="";
		document.getElementById('txtRegdate').value="";
		document.getElementById('txtRemarks').value="";
		document.getElementById('txtvatinno').value="";



		document.getElementById('txtdirpername').value = "";
		document.getElementById('txtdiradd').value = "";
		document.getElementById('txtdirstreet').value = "";
		document.getElementById('drpdircity').value = "";
		document.getElementById('txtdirstate').value = "";
		document.getElementById('drpdircountry').value = "";
		document.getElementById('txtdirdistrict').value = "";
		document.getElementById('txtdirzip').value = "";
		document.getElementById('txtdirphone1').value = "";
		document.getElementById('txtdirphone2').value = "";
		document.getElementById('txtdirfax').value = "";
		document.getElementById('txtdiremail').value = "";
		document.getElementById('txtstatezip').value = "";
		document.getElementById('txtcountryzip').value = "";
		document.getElementById('txtintegration').value = "";



		document.getElementById('txtdirpername').disabled =true;
		document.getElementById('txtdiradd').disabled = true;
		document.getElementById('txtdirstreet').disabled = true;
		document.getElementById('drpdircity').disabled = true;
		document.getElementById('txtdirstate').disabled = true;
		document.getElementById('drpdircountry').disabled = true;
		document.getElementById('txtdirdistrict').disabled = true;
		document.getElementById('txtdirzip').disabled = true;
		document.getElementById('txtdirphone1').disabled = true;
		document.getElementById('txtdirphone2').disabled = true;
		document.getElementById('txtdirfax').disabled = true;
		document.getElementById('txtdiremail').disabled = true;
		document.getElementById('txtstatezip').disabled = true;
		document.getElementById('txtcountryzip').disabled = true;
		document.getElementById('txtintegration').disabled = true;


document.getElementById('txtCompanyCode').disabled=true;
  	 document.getElementById('txtCompanyCode').disabled=true;
  	 
		document.getElementById('txtCompanyName').disabled=true;
	document.getElementById('txtCompanyalias').disabled=true;
		   document.getElementById('txtCompanyadd').disabled=true;
	document.getElementById('txtStreet').disabled=true;
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtZip').disabled=true;
	document.getElementById('txtDistrict').disabled=true;
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').disabled=true;
		document.getElementById('drpcountry').disabled=true;
		document.getElementById('txtPhone1').disabled=true;
	document.getElementById('txtPhone2').disabled=true;
	document.getElementById('txtfax').disabled=true;
		 document.getElementById('txtEmailid').disabled=true;
		document.getElementById('txtStAcNo').disabled=true;
	document.getElementById('txtPan').disabled=true;
		document.getElementById('txtTan').disabled=true;
		document.getElementById('txtRegno').disabled=true;
		document.getElementById('txtRegdate').disabled=true;
		document.getElementById('txtRemarks').disabled=true;
		document.getElementById('txtBoxAdd').disabled=true;
		document.getElementById('txtvatinno').disabled=true;
//				var compcode=document.getElementById('hiddencompcode').value;
//				var userid=document.getElementById('hiddenuserid').value;
			//getPermission(formname);
//				chkstatus(FlagStatus);
		//
		document.getElementById('DesInfTab').style.display = "none";
setButtonImages();
				if(document.getElementById('btnNew').disable==false)
				  document.getElementById('btnNew').focus();
////				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExit').disabled=false;
			    document.getElementById('btnCancel').disabled=false;
			
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
			
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
			
			return false;
}


function LastClick4()
{
 var msg=checkSession();
        if(msg==false)
        return false;
		var userid=document.getElementById('hiddenuserid').value;
		var CompanyCode=document.getElementById('txtCompanyCode').value;
		var CompanyName=document.getElementById('txtCompanyName').value;
		var Alias=document.getElementById('txtCompanyalias').value;   

		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Company_Master.Selectfnpl(CompanyCode,CompanyName,Alias,userid,call_Last);  

//			ColorMaster.Selectfnpl(ColorCode,ColorName,Alias,compcode,userid,call_Last);
			return false;
}

function call_Last(response)
{
		//var ds=response.value;
		var y=colds.Tables[0].Rows.length;
		z=y-1;

		document.getElementById('txtCompanyCode').value=colds.Tables[0].Rows[z].Comp_Code;
		document.getElementById('txtCompanyName').value=colds.Tables[0].Rows[z].Comp_Name;
	document.getElementById('txtCompanyalias').value=colds.Tables[0].Rows[z].Comp_Alias;
		   document.getElementById('txtCompanyadd').value=colds.Tables[0].Rows[z].Add1;
		   
		   document.getElementById('drpcountry').value=colds.Tables[0].Rows[z].Country_Code;
         var res=Company_Master.addcou(colds.Tables[0].Rows[z].Country_Code);
            bindcity(res);		
            if(colds.Tables[0].Rows[z].Street=="null" || colds.Tables[0].Rows[z].Street==null)
			{   
	         document.getElementById('txtStreet').value="";
	      	}
			else
			{
			  document.getElementById('txtStreet').value=colds.Tables[0].Rows[z].Street;
	        }
	     	document.getElementById('drpcity').value=colds.Tables[0].Rows[z].City_Code;
		
		    if(colds.Tables[0].Rows[z].Zip=="null" || colds.Tables[0].Rows[z].Zip==null)
			{   
	          document.getElementById('txtZip').value="";
	      	}
			else
			{
			document.getElementById('txtZip').value=colds.Tables[0].Rows[z].Zip;;
			}
		//document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;
		    if(colds.Tables[0].Rows[z].Dist_Code=="null" || colds.Tables[0].Rows[z].Dist_Code==null)
			{   
	         document.getElementById('txtDistrict').value="";
	      	}
			else
			{
			document.getElementById('txtDistrict').value=colds.Tables[0].Rows[z].Dist_Code;
			
			}
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value=colds.Tables[0].Rows[z].State_Code;
		
		  if(colds.Tables[0].Rows[z].Phone1=="null" || colds.Tables[0].Rows[z].Phone1==null)
			{  
		    document.getElementById('txtPhone1').value="";
		    }
			else
			{
			document.getElementById('txtPhone1').value=colds.Tables[0].Rows[z].Phone1;
			
			}
			
			 if(colds.Tables[0].Rows[z].Phone2=="null" || colds.Tables[0].Rows[z].Phone2==null)
			{  
			document.getElementById('txtPhone2').value="";
            }
			else
			{
			document.getElementById('txtPhone2').value=colds.Tables[0].Rows[z].Phone2;
			}
			
			 if(colds.Tables[0].Rows[z].Fax=="null" || colds.Tables[0].Rows[z].Fax==null)
			{  
	         document.getElementById('txtfax').value="";
		     }
			else
			{
			document.getElementById('txtfax').value=colds.Tables[0].Rows[z].Fax;
			}
			
			 if(colds.Tables[0].Rows[z].EmailID=="null" || colds.Tables[0].Rows[z].EmailID==null)
			{  
		     document.getElementById('txtEmailid').value="";
		 	}
			else
			{
			  document.getElementById('txtEmailid').value=colds.Tables[0].Rows[z].EmailID;
			}
			
			 if(colds.Tables[0].Rows[z].ST_Acc_No=="null" || colds.Tables[0].Rows[z].ST_Acc_No==null)
			{  
		     document.getElementById('txtStAcNo').value="";
			}
			else
			{
			document.getElementById('txtStAcNo').value=colds.Tables[0].Rows[z].ST_Acc_No;
			}
			
			
			
			if(colds.Tables[0].Rows[z].PAN_No=="null" || colds.Tables[0].Rows[z].PAN_No==null)
			{  
		     document.getElementById('txtPan').value="";
		    }
			else
			{
			document.getElementById('txtPan').value=colds.Tables[0].Rows[z].PAN_No;
			}
			
			if(colds.Tables[0].Rows[z].TAN_No=="null" || colds.Tables[0].Rows[z].TAN_No==null)
			{  
		     document.getElementById('txtTan').value="";
		    }
			else
			{
			document.getElementById('txtTan').value=colds.Tables[0].Rows[z].TAN_No;
			}
			
			 if(colds.Tables[0].Rows[z].Reg_No=="null"||colds.Tables[0].Rows[z].Reg_No==null)
			{  
		     document.getElementById('txtRegno').value="";
		    }
			else
			{
			document.getElementById('txtRegno').value=colds.Tables[0].Rows[z].Reg_No;
			}
			
		var dateformat=document.getElementById('hiddendateformat').value; 
		
		if(colds.Tables[0].Rows[z].Reg_Date != null && colds.Tables[0].Rows[z].Reg_Date != "")
			{
			var validate_fromdate=colds.Tables[0].Rows[z].Reg_Date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtRegdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtRegdate').value="";
			}
				
		//		document.getElementById('txtRegdate').value=colds.Tables[0].Rows[0].REG_DATE;
		if(colds.Tables[0].Rows[z].Remarks== "null" || colds.Tables[0].Rows[z].Remarks==null)
			{  
	     	 document.getElementById('txtRemarks').value="";
		    }
			else
			{
			 document.getElementById('txtRemarks').value=colds.Tables[0].Rows[z].Remarks;
			}
			
			if(colds.Tables[0].Rows[z].Box_Address== "null" || colds.Tables[0].Rows[z].Box_Address==null)
			{  
		     document.getElementById('txtBoxAdd').value="";  
		    }
			else
			{
			document.getElementById('txtBoxAdd').value=colds.Tables[0].Rows[z].Box_Address;
			}
			
			 if(colds.Tables[0].Rows[z].VAT_TINNO== "null" || colds.Tables[0].Rows[z].VAT_TINNO==null)
			{  
		     document.getElementById('txtvatinno').value="";  
		    }
			else
			{
			document.getElementById('txtvatinno').value=colds.Tables[0].Rows[z].VAT_TINNO;
}
if (colds.Tables[0].Rows[z].INTEGRATION_ID == "null" || colds.Tables[0].Rows[z].INTEGRATION_ID == null) {
                document.getElementById('txtintegration').value = "";
            }
            else {
                document.getElementById('txtintegration').value = colds.Tables[0].Rows[z].INTEGRATION_ID;
            }



//		document.getElementById('txtColorCode').disabled=true;
//		document.getElementById('txtColorName').disabled=true;
//		document.getElementById('txtAlias').disabled=true;
         
         document.getElementById('btnnext').disabled=true;
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
setButtonImages();
		return false;
}


function FirstClick4()
{
 var msg=checkSession();
        if(msg==false)
        return false;
		var userid=document.getElementById('hiddenuserid').value;
		var CompanyCode=document.getElementById('txtCompanyCode').value;
		var CompanyName=document.getElementById('txtCompanyName').value;
		var Alias=document.getElementById('txtCompanyalias').value;   

		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Company_Master.Selectfnpl(CompanyCode,CompanyName,Alias,userid,call_First);
		return false;
}

function call_First(response)
{
		z=0;
		//var ds=response.value;

		document.getElementById('txtCompanyCode').value=colds.Tables[0].Rows[z].Comp_Code;
		document.getElementById('txtCompanyName').value=colds.Tables[0].Rows[z].Comp_Name;
	document.getElementById('txtCompanyalias').value=colds.Tables[0].Rows[z].Comp_Alias;
		   document.getElementById('txtCompanyadd').value=colds.Tables[0].Rows[z].Add1;
		   
		   document.getElementById('drpcountry').value=colds.Tables[0].Rows[z].Country_Code;
         var res=Company_Master.addcou(colds.Tables[0].Rows[z].Country_Code);
            bindcity(res);		
          if(colds.Tables[0].Rows[z].Street=="null" || colds.Tables[0].Rows[z].Street==null)
			{   
	         document.getElementById('txtStreet').value="";
	      	}
			else
			{
			  document.getElementById('txtStreet').value=colds.Tables[0].Rows[z].Street;
	        }
	     	document.getElementById('drpcity').value=colds.Tables[0].Rows[z].City_Code;
		
		    if(colds.Tables[0].Rows[z].Zip=="null" || colds.Tables[0].Rows[z].Zip==null)
			{   
	          document.getElementById('txtZip').value="";
	      	}
			else
			{
			document.getElementById('txtZip').value=colds.Tables[0].Rows[z].Zip;;
			}
		//document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;
		    if(colds.Tables[0].Rows[z].Dist_Code=="null" || colds.Tables[0].Rows[z].Dist_Code==null)
			{   
	         document.getElementById('txtDistrict').value="";
	      	}
			else
			{
			document.getElementById('txtDistrict').value=colds.Tables[0].Rows[z].Dist_Code;
			
			}
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value=colds.Tables[0].Rows[z].State_Code;
		
		  if(colds.Tables[0].Rows[z].Phone1=="null" || colds.Tables[0].Rows[z].Phone1==null)
			{  
		    document.getElementById('txtPhone1').value="";
		    }
			else
			{
			document.getElementById('txtPhone1').value=colds.Tables[0].Rows[z].Phone1;
			
			}
			
			 if(colds.Tables[0].Rows[z].Phone2=="null" || colds.Tables[0].Rows[z].Phone2==null)
			{  
			document.getElementById('txtPhone2').value="";
            }
			else
			{
			document.getElementById('txtPhone2').value=colds.Tables[0].Rows[z].Phone2;
			}
			
			 if(colds.Tables[0].Rows[z].Fax=="null" || colds.Tables[0].Rows[z].Fax==null)
			{  
	         document.getElementById('txtfax').value="";
		     }
			else
			{
			document.getElementById('txtfax').value=colds.Tables[0].Rows[z].Fax;
			}
			
			 if(colds.Tables[0].Rows[z].EmailID=="null" || colds.Tables[0].Rows[z].EmailID==null)
			{  
		     document.getElementById('txtEmailid').value="";
		 	}
			else
			{
			  document.getElementById('txtEmailid').value=colds.Tables[0].Rows[z].EmailID;
			}
			
			 if(colds.Tables[0].Rows[z].ST_Acc_No=="null" || colds.Tables[0].Rows[z].ST_Acc_No==null)
			{  
		     document.getElementById('txtStAcNo').value="";
			}
			else
			{
			document.getElementById('txtStAcNo').value=colds.Tables[0].Rows[z].ST_Acc_No;
			}
			
			
			
		if(colds.Tables[0].Rows[z].PAN_No=="null" || colds.Tables[0].Rows[z].PAN_No==null)
			{  
		     document.getElementById('txtPan').value="";
		    }
			else
			{
			document.getElementById('txtPan').value=colds.Tables[0].Rows[z].PAN_No;
			}
			
			if(colds.Tables[z].Rows[0].TAN_No=="null" || colds.Tables[0].Rows[z].TAN_No==null)
			{  
		     document.getElementById('txtTan').value="";
		    }
			else
			{
			document.getElementById('txtTan').value=colds.Tables[0].Rows[z].TAN_No;
			}
			
			
			 if(colds.Tables[0].Rows[z].Reg_No=="null"||colds.Tables[0].Rows[z].Reg_No==null)
			{  
		     document.getElementById('txtRegno').value="";
		    }
			else
			{
			document.getElementById('txtRegno').value=colds.Tables[0].Rows[z].Reg_No;
			}
				
		    var dateformat=document.getElementById('hiddendateformat').value; 
		
		    if(colds.Tables[0].Rows[z].Reg_Date != null && colds.Tables[0].Rows[z].Reg_Date != "")
			{
			var validate_fromdate=colds.Tables[0].Rows[z].Reg_Date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtRegdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtRegdate').value="";
			}
		//		document.getElementById('txtRegdate').value=colds.Tables[0].Rows[0].REG_DATE;
		if(colds.Tables[0].Rows[z].Remarks== "null" || colds.Tables[0].Rows[z].Remarks==null)
			{  
	     	 document.getElementById('txtRemarks').value="";
		    }
			else
			{
			 document.getElementById('txtRemarks').value=colds.Tables[0].Rows[z].Remarks;
			}
			
			if(colds.Tables[0].Rows[z].Box_Address== "null" || colds.Tables[0].Rows[z].Box_Address==null)
			{  
		     document.getElementById('txtBoxAdd').value="";  
		    }
			else
			{
			document.getElementById('txtBoxAdd').value=colds.Tables[0].Rows[z].Box_Address;
			}
		   
		     if(colds.Tables[0].Rows[z].VAT_TINNO== "null" || colds.Tables[0].Rows[z].VAT_TINNO==null)
			{  
		     document.getElementById('txtvatinno').value="";  
		    }
			else
			{
			document.getElementById('txtvatinno').value=colds.Tables[0].Rows[z].VAT_TINNO;
			}


if (colds.Tables[0].Rows[z].INTEGRATION_ID == "null" || colds.Tables[0].Rows[z].INTEGRATION_ID == null) {
    document.getElementById('txtintegration').value = "";
}
else {
    document.getElementById('txtintegration').value = colds.Tables[0].Rows[z].INTEGRATION_ID;
}
		updateStatus();
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		setButtonImages();							
		return false;
}


function bindcity(res)
{
    var ds=res.value;
    //Company_Master.addcou(country,callcount);
    var ds=res.value;
    var pkgitem = document.getElementById("drpcity");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

        pkgitem.options.length = 1; 
        pkgitem.options[0]=new Option("--Select City--","0");
        for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);

            pkgitem.options.length;
        }

    }
}

function Call_Modify(response)
{
        var ds=response.value;
        if(chknamemod!=document.getElementById('txtCompanyName').value.toUpperCase())
        {
            if(ds.Tables[0].Rows.length!=0)
            {
                alert("This Company Name has been already assigned")
                 document.getElementById('txtCompanyName').value="";
                 document.getElementById('txtCompanyName').focus();
                
                  return false;
            }
        }
        var dateformat=document.getElementById('hiddendateformat').value;
				
	    //--------------new change by rinki(check Registration date)------------//

//        var txtdob;
//	    if(dateformat=="dd/mm/yyyy")
//        {
//	        var txt=document.getElementById('txtRegdate').value;
//	        var txt1=txt.split("/");
//	        var dd=txt1[0];
//	        var mm=txt1[1];
//	        var yy=txt1[2];
//	        txtdob=mm+'/'+dd+'/'+yy;
//			
//	        var currDate=new Date();
//            var userDate=document.getElementById('txtRegdate').value.split('/'); 
//            if(parseInt(userDate[1])>currDate.getMonth()+1)
//            {
//                alert("Registration Date should be less than Current Date");
//                return false;
//            }
//            else if(parseInt(userDate[2])>currDate.getFullYear())
//            {
//                alert("Registration Date should be less than Current Date");
//                return false;
//            }
//            else if(parseInt(userDate[0])>=currDate.getDate() && parseInt(userDate[1])==currDate.getMonth()+1 && parseInt(userDate[2])==currDate.getFullYear())
//            {
//                alert("Registration Date should be less than Current Date");
//                return false;
//            }
//			
//         }
//		 else if(dateformat=="mm/dd/yyyy")
//		 {
//			    var currDate=new Date();
//                var userDate=document.getElementById('txtRegdate').value.split('/'); 
//                if(parseInt(userDate[0])>currDate.getMonth()+1)
//                {
//                    alert("Registration should be less than Current Date");
//                    return false;
//                }
//                else if(parseInt(userDate[2])>currDate.getFullYear())
//                {
//                    alert("Registration should be less than Current Date");
//                    return false;
//                }
//                else if(parseInt(userDate[1])>=currDate.getDate() && parseInt(userDate[0])==currDate.getMonth()+1 && parseInt(userDate[2])==currDate.getFullYear())
//                {
//                    alert("Registration should be less than Current Date");
//                    return false;
//                }
//		  }
//				
//		  else if(dateformat=="yyyy/mm/dd")
//		  {
//			    var txt=document.getElementById('txtRegdate').value;
//			    var txt1=txt.split("/");
//			    var yy=txt1[0];
//			    var mm=txt1[1];
//			    var dd=txt1[2];
//			    txtdob=mm+'/'+dd+'/'+yy;
//				
//			    var currDate=new Date();
//                var userDate=document.getElementById('txtRegdate').value.split('/'); 
//                if(parseInt(userDate[1])>currDate.getMonth()+1)
//                {
//                    alert("Registration should be less than Current Date");
//                    return false;
//                }
//                else if(parseInt(userDate[0])>currDate.getFullYear())
//                {
//                    alert("Registration should be less than Current Date");
//                    return false;
//                }
//                else if(parseInt(userDate[2])>=currDate.getDate() && parseInt(userDate[1])==currDate.getMonth()+1 && parseInt(userDate[0])==currDate.getFullYear())
//                {
//                    alert("Registration should be less than Current Date");
//                    return false;
//                }
//				
//		   }

                var dateformat=document.getElementById('hiddendateformat').value;
				var txtdob="";
				if(document.getElementById('txtRegdate').value!="")
				{
				    if(dateformat=="dd/mm/yyyy")
					{
						var txt=document.getElementById('txtRegdate').value;
						var txt1=txt.split("/");
						var dd=txt1[0];
						var mm=txt1[1];
						var yy=txt1[2];
						txtdob=mm+'/'+dd+'/'+yy;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
						txtdob=document.getElementById('txtRegdate').value;
					}
								
					else if(dateformat=="yyyy/mm/dd")
					{
						var txt=document.getElementById('txtRegdate').value;
						var txt1=txt.split("/");
						var yy=txt1[0];
						var mm=txt1[1];
						var dd=txt1[2];
						txtdob=mm+'/'+dd+'/'+yy;
					}
					if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						txtdob=document.getElementById('txtRegdate').value;
					}
							
				    var dt=txtdob;
                    var dts=new Date(dt);
                    var dn=new Date();
				    if(dn<dts)
				    {
				        alert("Date should be less than or equal to current Date.");
				        document.getElementById('txtRegdate').value="";
				        document.getElementById('txtRegdate').focus();
				        return false;
    				    
				    }
				}
		   //---------------------------------------------END----------------------------------------------------------//
            document.getElementById('txtCompanyName').value=document.getElementById('txtCompanyName').value.toUpperCase();
            document.getElementById('txtCompanyalias').value=document.getElementById('txtCompanyalias').value.toUpperCase();
            var CompanyCode=trim(document.getElementById('txtCompanyCode').value);
		    var CompanyName=trim(document.getElementById('txtCompanyName').value);
		    var Companyalias=trim(document.getElementById('txtCompanyalias').value);
		    var Companyadd=trim(document.getElementById('txtCompanyadd').value);
	        var	Street=trim(document.getElementById('txtStreet').value);
		    var City=trim(document.getElementById('drpcity').value);
		    var Zip=trim(document.getElementById('txtZip').value);
		    var District=trim(document.getElementById('txtDistrict').value);
   //		var pcity=trim(document.getElementById('drpcity').value);
		    var State=trim(document.getElementById('txtState').value);
		    var Country=trim(document.getElementById('drpcountry').value);
		    var Phone1=trim(document.getElementById('txtPhone1').value);
		    var Phone2=trim(document.getElementById('txtPhone2').value);
	    	var Fax=trim(document.getElementById('txtfax').value);
		    var EmailId=trim(document.getElementById('txtEmailid').value);
		    var StAcNo=trim(document.getElementById('txtStAcNo').value);
		    var Pan=trim(document.getElementById('txtPan').value);
		    var Tan=trim(document.getElementById('txtTan').value);
		    var Regno=trim(document.getElementById('txtRegno').value);
		    var Regdate=trim(document.getElementById('txtRegdate').value);
		    var Remarks=trim(document.getElementById('txtRemarks').value);
		    var BoxAdd=trim(document.getElementById('txtBoxAdd').value);
//			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var dateformat=document.getElementById('hiddendateformat').value;
			var vatinno = trim(document.getElementById('txtvatinno').value);
			var integration = trim(document.getElementById('txtintegration').value);
			Company_Master.modifyCompany(CompanyCode, CompanyName, Companyalias, Companyadd, Street, City, Zip, District, State, Country, Phone1, Phone2, Fax, EmailId, StAcNo, Pan, Tan, Regno, txtdob, Remarks, BoxAdd, userid,dateformat,vatinno,integration);
				
		//-----------------------------------  ad by rinki -----------------------------------------------//
			   colds.Tables[0].Rows[z].Comp_Code=document.getElementById('txtCompanyCode').value;
		       colds.Tables[0].Rows[z].Comp_Name=document.getElementById('txtCompanyName').value;
		       colds.Tables[0].Rows[z].Comp_Alias=document.getElementById('txtCompanyalias').value;
		       colds.Tables[0].Rows[z].Add1=document.getElementById('txtCompanyadd').value;
	           colds.Tables[0].Rows[z].Country_Code=document.getElementById('drpcountry').value;
	           colds.Tables[0].Rows[z].City_Code=document.getElementById('drpcity').value;
	           if(document.getElementById('txtRegdate').value!="")
	           {
	             if(dateformat=="mm/dd/yyyy")
	             {
	                var dateM=new Date(document.getElementById('txtRegdate').value);
	                colds.Tables[0].Rows[z].Reg_Date=dateM;
	             }
	            else if(dateformat=="yyyy/mm/dd")
	             {
	                var dateM=new Date(document.getElementById('txtRegdate').value);
	                colds.Tables[0].Rows[z].Reg_Date=dateM;
	             }
	              else if(dateformat=="dd/mm/yyyy")
	             {
	                var d=document.getElementById('txtRegdate').value.toString().split("/");
	               var dDate=d[1]+"/" + d[0] + "/" + d[2];
	                var dateM=new Date(dDate);
	                colds.Tables[0].Rows[z].Reg_Date=dateM;
	             }
	           }
		  //  var res=Company_Master.addcou(colds.Tables[0].Rows[z].Country_Code);
         //  bindcity(res);		
		       if(colds.Tables[0].Rows[z].Street=="null" || colds.Tables[0].Rows[z].Street==null)
		       {   
			      document.getElementById('txtStreet').value="";
		       }
		       else
		       {
			      colds.Tables[0].Rows[z].Street=document.getElementById('txtStreet').value;
		       }
	           
	           if(colds.Tables[0].Rows[z].Zip=="null" || colds.Tables[0].Rows[z].Zip==null)
			   {   
	              document.getElementById('txtZip').value="";
	       	   }
		       else
			   {
			     colds.Tables[0].Rows[z].Zip=document.getElementById('txtZip').value;
			   }
		
		      if(colds.Tables[0].Rows[z].Dist_Code=="null" || colds.Tables[0].Rows[z].Dist_Code==null)
			  {   
	             document.getElementById('txtDistrict').value="";
	      	  }
			  else
			  {
			    colds.Tables[0].Rows[z].Dist_Code=document.getElementById('txtDistrict').value;
			  }

		      colds.Tables[0].Rows[z].State_Code=document.getElementById('txtState').value;
		
		      if(colds.Tables[0].Rows[z].Phone1=="null" || colds.Tables[0].Rows[z].Phone1==null)
			  {  
		           document.getElementById('txtPhone1').value="";
		      }
		  	  else
			  {
			      colds.Tables[0].Rows[z].Phone1=document.getElementById('txtPhone1').value;
			  }
			
			  if(colds.Tables[0].Rows[z].Phone2=="null" || colds.Tables[0].Rows[z].Phone2==null)
			  {  
			      document.getElementById('txtPhone2').value="";
              }
			  else
			  {
			      colds.Tables[0].Rows[z].Phone2=document.getElementById('txtPhone2').value;
			  }
			
			  if(colds.Tables[0].Rows[z].Fax=="null" || colds.Tables[0].Rows[z].Fax==null)
			  {  
	              document.getElementById('txtfax').value="";
		      }
			  else
			  {
			      colds.Tables[0].Rows[z].Fax=document.getElementById('txtfax').value;
			  }
			
			  if(colds.Tables[0].Rows[z].EmailID=="null" || colds.Tables[0].Rows[z].EmailID==null)
			  {  
		         document.getElementById('txtEmailid').value="";
		 	  }
			  else
			  {
			     colds.Tables[0].Rows[z].EmailID= document.getElementById('txtEmailid').value;
			  }
			
			  if(colds.Tables[0].Rows[z].ST_Acc_No=="null" || colds.Tables[0].Rows[z].ST_Acc_No==null)
			  {  
		          document.getElementById('txtStAcNo').value="";
			  }
			  else
			  {
			    colds.Tables[0].Rows[z].ST_Acc_No=document.getElementById('txtStAcNo').value;
			  }
			
			  if(colds.Tables[0].Rows[z].PAN_No=="null" || colds.Tables[0].Rows[z].PAN_No==null)
			  {  
		          document.getElementById('txtPan').value="";
		      }
			  else
			  {
			    colds.Tables[0].Rows[z].PAN_No=document.getElementById('txtPan').value;
			  }
			
			  if(colds.Tables[0].Rows[z].TAN_No=="null" || colds.Tables[0].Rows[z].TAN_No==null)
			  {  
		          document.getElementById('txtTan').value="";
		      }
			  else
			  {
			    colds.Tables[0].Rows[z].TAN_No=document.getElementById('txtTan').value;
			  }
			
		      if(colds.Tables[0].Rows[z].Reg_No=="null"||colds.Tables[0].Rows[z].Reg_No==null)
		      {  
	              document.getElementById('txtRegno').value="";
	          }
		      else
		      {
		         colds.Tables[0].Rows[z].Reg_No= document.getElementById('txtRegno').value;
		      }
			  
//			  if(colds.Tables[0].Rows[z].Reg_Date != null && colds.Tables[0].Rows[z].Reg_Date != "")
//			  {
//			    colds.Tables[0].Rows[z].Reg_Date=document.getElementById('txtRegdate').value;
//			  }
//			  else
//			  {
//			    document.getElementById('txtRegdate').value="";
//			  }
		      var dateformat=document.getElementById('hiddendateformat').value; 
		      
		      if(colds.Tables[0].Rows[z].Reg_Date != null && colds.Tables[0].Rows[z].Reg_Date != "")
			  {
			        var validate_fromdate=colds.Tables[0].Rows[z].Reg_Date;
			        var dd=validate_fromdate.getDate();
			        var mm=validate_fromdate.getMonth() + 1;
			        var yyyy=validate_fromdate.getFullYear();
        			
			        var enrolldate1=mm+'/'+dd+'/'+yyyy;
			        var enrolldateday=dd+'/'+mm+'/'+yyyy;
			        var enrollyear=yyyy+'/'+mm+'/'+dd;
        			
			        if(dateformat=="mm/dd/yyyy")
			        {
			         // colds.Tables[0].Rows[z].Reg_Date =enrolldate1;
			           document.getElementById('txtRegdate').value=enrolldate1;
			         //colds.Tables[0].Rows[z].Reg_Date=document.getElementById('txtRegdate').value;
			        }
			        if(dateformat=="yyyy/mm/dd")
			        {
			        document.getElementById('txtRegdate').value=enrollyear;
			        }
			        if(dateformat=="dd/mm/yyyy")
			        {
			        document.getElementById('txtRegdate').value=enrolldateday;
			        }
			        if(dateformat==null || dateformat=="")
			        {
			          enrolldate1=document.getElementById('txtRegdate').value;
	      	        }
   			  }
			  else
			  {
			    document.getElementById('txtRegdate').value="";
			  }
				
		
	          if(colds.Tables[0].Rows[z].Remarks== "null" || colds.Tables[0].Rows[z].Remarks==null)
		      {  
     	         document.getElementById('txtRemarks').value="";
	          }
			  else
			  {
			     colds.Tables[0].Rows[z].Remarks=document.getElementById('txtRemarks').value;
			  }
			
			  if(colds.Tables[0].Rows[z].Box_Address== "null" || colds.Tables[0].Rows[z].Box_Address==null)
			  {  
		         document.getElementById('txtBoxAdd').value="";  
		      }
			  else
			  {
			    colds.Tables[0].Rows[z].Box_Address=document.getElementById('txtBoxAdd').value;
			  }
			
			  if(colds.Tables[0].Rows[z].VAT_TINNO== "null" || colds.Tables[0].Rows[z].VAT_TINNO==null)
			  {  
		         document.getElementById('txtvatinno').value="";  
		      }
			  else
			  {
			   colds.Tables[0].Rows[z].VAT_TINNO=document.getElementById('txtvatinno').value;
			  }
	//-------------------------------------------------------------------------------------------------//
                if(browser!="Microsoft Internet Explorer")
                {
                   // alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                   alert("Data Updated Succesfully");
                }
                else
                {
                    alert("Data Updated Succesfully");
                }
                flag="0";
                updateStatus();
                
                var x=colds.Tables[0].Rows.length;
	            y=z;	
                if (z==0)
                {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

                if(z==(colds.Tables[0].Rows.length-1))
                {
                    document.getElementById('btnnext').disabled=true;
	                document.getElementById('btnlast').disabled=true;
                }
				
                
                document.getElementById('txtCompanyCode').disabled=true;
  	            document.getElementById('txtCompanyCode').disabled=true;
  	 
		        document.getElementById('txtCompanyName').disabled=true;
	            document.getElementById('txtCompanyalias').disabled=true;
		        document.getElementById('txtCompanyadd').disabled=true;
	            document.getElementById('txtStreet').disabled=true;
		        document.getElementById('drpcity').disabled=true;
		        document.getElementById('txtZip').disabled=true;
	            document.getElementById('txtDistrict').disabled=true;
        //		var pcity=trim(document.getElementById('drpcity').value);
		        document.getElementById('txtState').disabled=true;
		        document.getElementById('drpcountry').disabled=true;
		        document.getElementById('txtPhone1').disabled=true;
	            document.getElementById('txtPhone2').disabled=true;
	            document.getElementById('txtfax').disabled=true;
		         document.getElementById('txtEmailid').disabled=true;
		        document.getElementById('txtStAcNo').disabled=true;
	            document.getElementById('txtPan').disabled=true;
		        document.getElementById('txtTan').disabled=true;
		        document.getElementById('txtRegno').disabled=true;
		        document.getElementById('txtRegdate').disabled=true;
		        document.getElementById('txtRemarks').disabled=true;
		        document.getElementById('txtBoxAdd').disabled=true;
		        document.getElementById('txtvatinno').disabled = true;
		        document.getElementById('txtintegration').disabled = false;
        		setButtonImages();
        		document.getElementById('btnModify').focus();
		        return false;
 }
			  
		
function NextClick4()
{
 var msg=checkSession();
        if(msg==false)
        return false;
//		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var CompanyCode=document.getElementById('txtCompanyCode').value;
		var CompanyName=document.getElementById('txtCompanyName').value;
		var Alias=document.getElementById('txtCompanyalias').value;   

		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Company_Master.Selectfnpl(CompanyCode,CompanyName,Alias,userid,call_Next);
		return false;
}
		
function call_Next(response)
{
		//var ds=response.value;
var a=colds.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		
	document.getElementById('txtCompanyCode').value=colds.Tables[0].Rows[z].Comp_Code;
		document.getElementById('txtCompanyName').value=colds.Tables[0].Rows[z].Comp_Name;
	document.getElementById('txtCompanyalias').value=colds.Tables[0].Rows[z].Comp_Alias;
	document.getElementById('txtCompanyadd').value = colds.Tables[0].Rows[z].Add1;
	document.getElementById('txtintegration').value = colds.Tables[0].Rows[z].INTEGRATION_ID;
		   
		   document.getElementById('drpcountry').value=colds.Tables[0].Rows[z].Country_Code;
         var res=Company_Master.addcou(colds.Tables[0].Rows[z].Country_Code);
            bindcity(res);		
            if(colds.Tables[0].Rows[z].Street=="null" || colds.Tables[0].Rows[z].Street==null)
			{   
	         document.getElementById('txtStreet').value="";
	      	}
			else
			{
			  document.getElementById('txtStreet').value=colds.Tables[0].Rows[z].Street;
	        }
	     	document.getElementById('drpcity').value=colds.Tables[0].Rows[z].City_Code;
		
		    if(colds.Tables[0].Rows[z].Zip=="null" || colds.Tables[0].Rows[z].Zip==null)
			{   
	          document.getElementById('txtZip').value="";
	      	}
			else
			{
			document.getElementById('txtZip').value=colds.Tables[0].Rows[z].Zip;;
			}
		//document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;
		    if(colds.Tables[0].Rows[z].Dist_Code=="null" || colds.Tables[0].Rows[z].Dist_Code==null)
			{   
	         document.getElementById('txtDistrict').value="";
	      	}
			else
			{
			document.getElementById('txtDistrict').value=colds.Tables[0].Rows[z].Dist_Code;
			
			}
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value=colds.Tables[0].Rows[z].State_Code;
		
		  if(colds.Tables[0].Rows[z].Phone1=="null" || colds.Tables[0].Rows[z].Phone1==null)
			{  
		    document.getElementById('txtPhone1').value="";
		    }
			else
			{
			document.getElementById('txtPhone1').value=colds.Tables[0].Rows[z].Phone1;
			
			}
			
			 if(colds.Tables[0].Rows[z].Phone2=="null" || colds.Tables[0].Rows[z].Phone2==null)
			{  
			document.getElementById('txtPhone2').value="";
            }
			else
			{
			document.getElementById('txtPhone2').value=colds.Tables[0].Rows[z].Phone2;
			}
			
			 if(colds.Tables[0].Rows[z].Fax=="null" || colds.Tables[0].Rows[z].Fax==null)
			{  
	         document.getElementById('txtfax').value="";
		     }
			else
			{
			document.getElementById('txtfax').value=colds.Tables[0].Rows[z].Fax;
			}
			
			 if(colds.Tables[0].Rows[z].EmailID=="null" || colds.Tables[0].Rows[z].EmailID==null)
			{  
		     document.getElementById('txtEmailid').value="";
		 	}
			else
			{
			  document.getElementById('txtEmailid').value=colds.Tables[0].Rows[z].EmailID;
			}
			
			 if(colds.Tables[0].Rows[z].ST_Acc_No=="null" || colds.Tables[0].Rows[z].ST_Acc_No==null)
			{  
		     document.getElementById('txtStAcNo').value="";
			}
			else
			{
			document.getElementById('txtStAcNo').value=colds.Tables[0].Rows[z].ST_Acc_No;
			}
			
			
			
			 if(colds.Tables[0].Rows[z].PAN_No=="null" || colds.Tables[0].Rows[z].PAN_No==null)
			{  
		     document.getElementById('txtPan').value="";
		    }
			else
			{
			document.getElementById('txtPan').value=colds.Tables[0].Rows[z].PAN_No;
			}
			
			if(colds.Tables[0].Rows[z].TAN_No=="null" || colds.Tables[0].Rows[z].TAN_No==null)
			{  
		     document.getElementById('txtTan').value="";
		    }
			else
			{
			document.getElementById('txtTan').value=colds.Tables[0].Rows[z].TAN_No;
			}
			
			 if(colds.Tables[0].Rows[z].Reg_No=="null"||colds.Tables[0].Rows[z].Reg_No==null)
			{  
		     document.getElementById('txtRegno').value="";
		    }
			else
			{
			document.getElementById('txtRegno').value=colds.Tables[0].Rows[z].Reg_No;
			}
		
				var dateformat=document.getElementById('hiddendateformat').value; 
		
		if(colds.Tables[0].Rows[z].Reg_Date != null && colds.Tables[0].Rows[z].Reg_Date != "")
			{
			var validate_fromdate=colds.Tables[0].Rows[z].Reg_Date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtRegdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtRegdate').value="";
			}
		//		document.getElementById('txtRegdate').value=colds.Tables[0].Rows[0].REG_DATE;
	 if(colds.Tables[0].Rows[z].Remarks== "null" || colds.Tables[0].Rows[z].Remarks==null)
			{  
	     	 document.getElementById('txtRemarks').value="";
		    }
			else
			{
			 document.getElementById('txtRemarks').value=colds.Tables[0].Rows[z].Remarks;
			}
			
			if(colds.Tables[0].Rows[z].Box_Address== "null" || colds.Tables[0].Rows[z].Box_Address==null)
			{  
		     document.getElementById('txtBoxAdd').value="";  
		    }
			else
			{
			document.getElementById('txtBoxAdd').value=colds.Tables[0].Rows[z].Box_Address;
			}
		
		     if(colds.Tables[0].Rows[z].VAT_TINNO== "null" || colds.Tables[0].Rows[z].VAT_TINNO==null)
			{  
		     document.getElementById('txtvatinno').value="";  
		    }
			else
			{
			document.getElementById('txtvatinno').value=colds.Tables[0].Rows[z].VAT_TINNO;
			}
           updateStatus();
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		else
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}	
	}
	else
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}	
		if(z==a-1)
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
setButtonImages();
return false;
}

//function FirstClick4()
//{
//			var userid=document.getElementById('hiddenuserid').value;
//		var CompanyCode=document.getElementById('txtCompanyCode').value;
//		var CompanyName=document.getElementById('txtCompanyName').value;
//		var Alias=document.getElementById('txtCompanyalias').value;   

//		
//		return false;
//}

//function call_First(response)
//{
//		z=0;
//		//var ds=response.value;

//		document.getElementById('txtCompanyCode').value=colds.Tables[0].Rows[0].Comp_Code;
//		document.getElementById('txtCompanyName').value=colds.Tables[0].Rows[0].Comp_Name;
//	document.getElementById('txtCompanyalias').value=colds.Tables[0].Rows[0].Comp_Alias;
//		   document.getElementById('txtCompanyadd').value=colds.Tables[0].Rows[0].Add1;
//		   
//		   document.getElementById('drpcountry').value=colds.Tables[0].Rows[0].Country_Code;
//         var res=Company_Master.addcou(colds.Tables[0].Rows[0].Country_Code);
//            bindcity(res);		
//            if(colds.Tables[0].Rows[0].Street!="null")
//			{   
//	document.getElementById('txtStreet').value=colds.Tables[0].Rows[0].Street;
//		}
//			else
//			{
//			document.getElementById('txtStreet').value="";
//			}
//		document.getElementById('drpcity').value=colds.Tables[0].Rows[0].City_Code;
//		
//		  if(colds.Tables[0].Rows[0].Zip!="null")
//			{   
//	document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;;
//		}
//			else
//			{
//			document.getElementById('txtZip').value="";
//			}
//		//document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;
//		 if(colds.Tables[0].Rows[0].Dist_Code!="null")
//			{   
//	document.getElementById('txtDistrict').value=colds.Tables[0].Rows[0].Dist_Code;
//	}
//			else
//			{
//			document.getElementById('txtDistrict').value="";
//			}
////		var pcity=trim(document.getElementById('drpcity').value);
//		document.getElementById('txtState').value=colds.Tables[0].Rows[0].State_Code;
//		
//		 if(colds.Tables[0].Rows[0].Phone1!="null")
//			{  
//		document.getElementById('txtPhone1').value=colds.Tables[0].Rows[0].Phone1;
//		}
//			else
//			{
//			document.getElementById('txtPhone1').value="";
//			}
//			
//			 if(colds.Tables[0].Rows[0].Phone2!="null")
//			{  
//	document.getElementById('txtPhone2').value=colds.Tables[0].Rows[0].Phone2;
//		}
//			else
//			{
//			document.getElementById('txtPhone2').value="";
//			}
//			
//			 if(colds.Tables[0].Rows[0].Fax!="null")
//			{  
//	document.getElementById('txtfax').value=colds.Tables[0].Rows[0].Fax;
//		}
//			else
//			{
//			document.getElementById('txtfax').value="";
//			}
//			
//			 if(colds.Tables[0].Rows[0].EmailID!="null")
//			{  
//		 document.getElementById('txtEmailid').value=colds.Tables[0].Rows[0].EmailID;
//		 	}
//			else
//			{
//			 document.getElementById('txtEmailid').value="";
//			}
//			
//			 if(colds.Tables[0].Rows[0].ST_Acc_No!="null")
//			{  
//		document.getElementById('txtStAcNo').value=colds.Tables[0].Rows[0].ST_Acc_No;
//			}
//			else
//			{
//			document.getElementById('txtStAcNo').value="";
//			}
//			
//			 if(colds.Tables[0].Rows[0].PAN_No!="null")
//			{  
//	document.getElementById('txtPan').value=colds.Tables[0].Rows[0].PAN_No;
//		}
//			else
//			{
//			document.getElementById('txtPan').value="";
//			}
//			
//			 if(colds.Tables[0].Rows[0].PAN_No!="null")
//			{  
//		document.getElementById('txtTan').value=colds.Tables[0].Rows[0].TAN_No;
//		}
//			else
//			{
//			document.getElementById('txtTan').value="";
//			}
//			
//			 if(colds.Tables[0].Rows[0].Reg_No!="null")
//			{  
//		document.getElementById('txtRegno').value=colds.Tables[0].Rows[0].Reg_No;
//		}
//			else
//			{
//			document.getElementById('txtRegno').value="";
//			}
//		
//				var dateformat=document.getElementById('hiddendateformat').value; 
//		
//		if(colds.Tables[0].Rows[0].Reg_Date != null && colds.Tables[0].Rows[0].Reg_Date != "")
//			{
//			var validate_fromdate=colds.Tables[0].Rows[0].Reg_Date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txtRegdate').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txtRegdate').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txtRegdate').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txtRegdate').value=enrolldate1;
//			}
//			
//			
//			}
//			else
//			{
//			document.getElementById('txtRegdate').value="";
//			}
//		//		document.getElementById('txtRegdate').value=colds.Tables[0].Rows[0].REG_DATE;
//		 if(colds.Tables[0].Rows[0].Remarks!="null")
//			{  
//		document.getElementById('txtRemarks').value=colds.Tables[0].Rows[0].Remarks;
//		}
//			else
//			{
//			document.getElementById('txtRemarks').value="";
//			}
//			
//			 if(colds.Tables[0].Rows[0].Box_Address!="null")
//			{  
//		document.getElementById('txtBoxAdd').value=colds.Tables[0].Rows[0].Box_Address;
//		}
//			else
//			{
//			document.getElementById('txtBoxAdd').value="";
//			}
//		
//			
//		updateStatus();
//		document.getElementById('btnfirst').disabled=true;				
//		document.getElementById('btnprevious').disabled=true;
//		document.getElementById('btnnext').disabled=false;
//		document.getElementById('btnlast').disabled=false;							
//		return false;
//}

function PreviousClick4()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	    var userid=document.getElementById('hiddenuserid').value;
		var CompanyCode=document.getElementById('txtCompanyCode').value;
		var CompanyName=document.getElementById('txtCompanyName').value;
		var Alias=document.getElementById('txtCompanyalias').value;   

		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Company_Master.Selectfnpl(CompanyCode,CompanyName,Alias,userid,call_Previous);
		
	    return false;
}


function call_Previous(response)
{
	//	var ds=response.value;
var a=colds.Tables[0].Rows.length;

z--;
if(z>a)
			{
						document.getElementById('btnfirst').disabled=false;				
						document.getElementById('btnnext').disabled=true;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=true;
						return false;
			}
    if(z != -1  )
	{
     	if(z >= 0 && z < a)
		{
		   document.getElementById('txtCompanyCode').value=colds.Tables[0].Rows[z].Comp_Code;
		   document.getElementById('txtCompanyName').value=colds.Tables[0].Rows[z].Comp_Name;
	       document.getElementById('txtCompanyalias').value=colds.Tables[0].Rows[z].Comp_Alias;
		   document.getElementById('txtCompanyadd').value=colds.Tables[0].Rows[z].Add1;
		   
		   document.getElementById('drpcountry').value=colds.Tables[0].Rows[z].Country_Code;
           var res=Company_Master.addcou(colds.Tables[0].Rows[z].Country_Code);
            bindcity(res);		
         if(colds.Tables[0].Rows[z].Street=="null" || colds.Tables[0].Rows[z].Street==null)
			{   
	         document.getElementById('txtStreet').value="";
	      	}
			else
			{
			  document.getElementById('txtStreet').value=colds.Tables[0].Rows[z].Street;
	        }
	     	document.getElementById('drpcity').value=colds.Tables[0].Rows[z].City_Code;
		
		    if(colds.Tables[0].Rows[z].Zip=="null" || colds.Tables[0].Rows[z].Zip==null)
			{   
	          document.getElementById('txtZip').value="";
	      	}
			else
			{
			document.getElementById('txtZip').value=colds.Tables[0].Rows[z].Zip;;
			}
		//document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;
		    if(colds.Tables[0].Rows[z].Dist_Code=="null" || colds.Tables[0].Rows[z].Dist_Code==null)
			{   
	         document.getElementById('txtDistrict').value="";
	      	}
			else
			{
			document.getElementById('txtDistrict').value=colds.Tables[0].Rows[z].Dist_Code;
			
			}
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value=colds.Tables[0].Rows[z].State_Code;
		
		  if(colds.Tables[0].Rows[z].Phone1=="null" || colds.Tables[0].Rows[z].Phone1==null)
			{  
		    document.getElementById('txtPhone1').value="";
		    }
			else
			{
			document.getElementById('txtPhone1').value=colds.Tables[0].Rows[z].Phone1;
			
			}
			
			 if(colds.Tables[0].Rows[z].Phone2=="null" || colds.Tables[0].Rows[z].Phone2==null)
			{  
			document.getElementById('txtPhone2').value="";
            }
			else
			{
			document.getElementById('txtPhone2').value=colds.Tables[0].Rows[z].Phone2;
			}
			
			 if(colds.Tables[0].Rows[z].Fax=="null" || colds.Tables[0].Rows[z].Fax==null)
			{  
	         document.getElementById('txtfax').value="";
		     }
			else
			{
			document.getElementById('txtfax').value=colds.Tables[0].Rows[z].Fax;
			}
			
			 if(colds.Tables[0].Rows[z].EmailID=="null" || colds.Tables[0].Rows[z].EmailID==null)
			{  
		     document.getElementById('txtEmailid').value="";
		 	}
			else
			{
			  document.getElementById('txtEmailid').value=colds.Tables[0].Rows[z].EmailID;
			}
			
			 if(colds.Tables[0].Rows[z].ST_Acc_No=="null" || colds.Tables[0].Rows[z].ST_Acc_No==null)
			{  
		     document.getElementById('txtStAcNo').value="";
			}
			else
			{
			document.getElementById('txtStAcNo').value=colds.Tables[0].Rows[z].ST_Acc_No;
			}
			
			
			
		if(colds.Tables[0].Rows[z].PAN_No=="null" || colds.Tables[0].Rows[z].PAN_No==null)
			{  
		     document.getElementById('txtPan').value="";
		    }
			else
			{
			document.getElementById('txtPan').value=colds.Tables[0].Rows[z].PAN_No;
			}
			
			if(colds.Tables[0].Rows[z].TAN_No=="null" || colds.Tables[0].Rows[z].TAN_No==null)
			{  
		     document.getElementById('txtTan').value="";
		    }
			else
			{
			document.getElementById('txtTan').value=colds.Tables[0].Rows[z].TAN_No;
			}
			
			 if(colds.Tables[0].Rows[z].Reg_No=="null"||colds.Tables[0].Rows[z].Reg_No==null)
			{  
		     document.getElementById('txtRegno').value="";
		    }
			else
			{
			document.getElementById('txtRegno').value=colds.Tables[0].Rows[z].Reg_No;
			}
			
			var dateformat=document.getElementById('hiddendateformat').value; 
		
	     	if(colds.Tables[0].Rows[z].Reg_Date != null && colds.Tables[0].Rows[z].Reg_Date != "")
			{
			var validate_fromdate=colds.Tables[0].Rows[z].Reg_Date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtRegdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtRegdate').value="";
			}
		//		document.getElementById('txtRegdate').value=colds.Tables[0].Rows[0].REG_DATE;
	        
		     if(colds.Tables[0].Rows[z].Remarks== "null" || colds.Tables[0].Rows[z].Remarks==null)
			{  
	     	 document.getElementById('txtRemarks').value="";
		    }
			else
			{
			 document.getElementById('txtRemarks').value=colds.Tables[0].Rows[z].Remarks;
			}
			
			if(colds.Tables[0].Rows[z].Box_Address== "null" || colds.Tables[0].Rows[z].Box_Address==null)
			{  
		     document.getElementById('txtBoxAdd').value="";  
		    }
			else
			{
			document.getElementById('txtBoxAdd').value=colds.Tables[0].Rows[z].Box_Address;
			}
		
             if(colds.Tables[0].Rows[z].VAT_TINNO== "null" || colds.Tables[0].Rows[z].VAT_TINNO==null)
			{  
		     document.getElementById('txtvatinno').value="";  
		    }
			else
			{
			document.getElementById('txtvatinno').value=colds.Tables[0].Rows[z].VAT_TINNO;
}
if (colds.Tables[0].Rows[z].VAT_TINNO == "null" || colds.Tables[0].Rows[z].VAT_TINNO == null) {
    document.getElementById('txtintegration').value = "";
}
else {
    document.getElementById('txtintegration').value = colds.Tables[0].Rows[z].INTEGRATION_ID;
}
        updateStatus();
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
		
	    }
		else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}	
	}
	else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}	
		
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}

setButtonImages();
return false;
}



function deleteClick()
{


    delete_grid();
 var msg=checkSession();
        if(msg==false)
        return false;
		var userid=document.getElementById('hiddenuserid').value;
		var compcode=document.getElementById('txtCompanyCode').value;
		var CompanyName=document.getElementById('txtCompanyName').value;
		var Alias=document.getElementById('txtCompanyalias').value;  
	
		if(confirm("Are You Sure To Delete The Data"))
		{
			//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Company_Master.deletecolor(compcode);
			//alert("Value Deleted Sucessfully");
			if(browser!="Microsoft Internet Explorer")
            {
                alert("Data deleted Succesfully");
                blank_fields();
            }
            else
            {
                alert("Data deleted Succesfully");
                blank_fields();
            }
			
			var response=Company_Master.Select(glcode,glname,glalias,userid);//,call_deleteclick);
			call_deleteclick(response);
			//	ColorMaster.Selectfnpl(ColorCode,ColorName,Alias,compcode,userid,call_deleteclick);
		  
			//document.getElementById('txtColorCode').disabled=true;
			//document.getElementById('txtColorName').disabled=true;
			//document.getElementById('txtAlias').disabled=true;
		}
		return false;
}

function call_deleteclick(response)
{
	colds=response.value;
	//var ds=response.value;
	var a=colds.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
	
			alert("There Is No Data");
			document.getElementById('txtCompanyCode').value="";
		document.getElementById('txtCompanyName').value="";
	document.getElementById('txtCompanyalias').value="";
		   document.getElementById('txtCompanyadd').value="";
	document.getElementById('txtStreet').value="";
		document.getElementById('drpcity').value="";
		document.getElementById('txtZip').value="";
	document.getElementById('txtDistrict').value="";
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value="";
		document.getElementById('drpcountry').value="";
		document.getElementById('txtPhone1').value="";
	document.getElementById('txtPhone2').value="";
	document.getElementById('txtfax').value="";
		 document.getElementById('txtEmailid').value="";
		document.getElementById('txtStAcNo').value="";
	document.getElementById('txtPan').value="";
		document.getElementById('txtTan').value="";
		document.getElementById('txtRegno').value="";
		document.getElementById('txtBoxAdd').value="";
		document.getElementById('txtRegdate').value="";
		document.getElementById('txtRemarks').value="";
		document.getElementById('txtvatinno').value="";
			CancelClick4('ColorMaster');
			return false;
	}
	
	else if(z==-1 ||z>=a)
	{
	document.getElementById('txtCompanyCode').value=colds.Tables[0].Rows[0].Comp_Code;
		document.getElementById('txtCompanyName').value=colds.Tables[0].Rows[0].Comp_Name;
	document.getElementById('txtCompanyalias').value=colds.Tables[0].Rows[0].Comp_Alias;
		   document.getElementById('txtCompanyadd').value=colds.Tables[0].Rows[0].Add1;
		   
		   document.getElementById('drpcountry').value=colds.Tables[0].Rows[0].Country_Code;
         var res=Company_Master.addcou(colds.Tables[0].Rows[0].Country_Code);
            bindcity(res);		
             if(colds.Tables[0].Rows[0].Street=="null" || colds.Tables[0].Rows[0].Street==null)
			{   
	         document.getElementById('txtStreet').value="";
	      	}
			else
			{
			  document.getElementById('txtStreet').value=colds.Tables[0].Rows[0].Street;
	        }
	     	document.getElementById('drpcity').value=colds.Tables[0].Rows[0].City_Code;
		
		    if(colds.Tables[0].Rows[0].Zip=="null" || colds.Tables[0].Rows[0].Zip==null)
			{   
	          document.getElementById('txtZip').value="";
	      	}
			else
			{
			document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;;
			}
		//document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;
		    if(colds.Tables[0].Rows[0].Dist_Code=="null" || colds.Tables[0].Rows[0].Dist_Code==null)
			{   
	         document.getElementById('txtDistrict').value="";
	      	}
			else
			{
			document.getElementById('txtDistrict').value=colds.Tables[0].Rows[0].Dist_Code;
			
			}
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value=colds.Tables[0].Rows[0].State_Code;
		
		  if(colds.Tables[0].Rows[0].Phone1=="null" || colds.Tables[0].Rows[0].Phone1==null)
			{  
		    document.getElementById('txtPhone1').value="";
		    }
			else
			{
			document.getElementById('txtPhone1').value=colds.Tables[0].Rows[0].Phone1;
			
			}
			
			 if(colds.Tables[0].Rows[0].Phone2=="null" || colds.Tables[0].Rows[0].Phone2==null)
			{  
			document.getElementById('txtPhone2').value="";
            }
			else
			{
			document.getElementById('txtPhone2').value=colds.Tables[0].Rows[0].Phone2;
			}
			
			 if(colds.Tables[0].Rows[0].Fax=="null" || colds.Tables[0].Rows[0].Fax==null)
			{  
	         document.getElementById('txtfax').value="";
		     }
			else
			{
			document.getElementById('txtfax').value=colds.Tables[0].Rows[0].Fax;
			}
			
			 if(colds.Tables[0].Rows[0].EmailID=="null" || colds.Tables[0].Rows[0].EmailID==null)
			{  
		     document.getElementById('txtEmailid').value="";
		 	}
			else
			{
			  document.getElementById('txtEmailid').value=colds.Tables[0].Rows[0].EmailID;
			}
			
			 if(colds.Tables[0].Rows[0].ST_Acc_No=="null" || colds.Tables[0].Rows[0].ST_Acc_No==null)
			{  
		     document.getElementById('txtStAcNo').value="";
			}
			else
			{
			document.getElementById('txtStAcNo').value=colds.Tables[0].Rows[0].ST_Acc_No;
			}
			
			
			
			if(colds.Tables[0].Rows[0].PAN_No=="null" || colds.Tables[0].Rows[0].PAN_No==null)
			{  
		     document.getElementById('txtPan').value="";
		    }
			else
			{
			document.getElementById('txtPan').value=colds.Tables[0].Rows[0].PAN_No;
			}
			
			if(colds.Tables[0].Rows[0].TAN_No=="null" || colds.Tables[0].Rows[0].TAN_No==null)
			{  
		     document.getElementById('txtTan').value="";
		    }
			else
			{
			document.getElementById('txtTan').value=colds.Tables[0].Rows[0].TAN_No;
			}
			
			 if(colds.Tables[0].Rows[0].Reg_No=="null"||colds.Tables[0].Rows[0].Reg_No==null)
			{  
		     document.getElementById('txtRegno').value="";
		    }
			else
			{
			document.getElementById('txtRegno').value=colds.Tables[0].Rows[0].Reg_No;
			}
		
				var dateformat=document.getElementById('hiddendateformat').value; 
		
		if(colds.Tables[0].Rows[0].Reg_Date != null && colds.Tables[0].Rows[0].Reg_Date != "")
			{
			var validate_fromdate=colds.Tables[0].Rows[0].Reg_Date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtRegdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtRegdate').value="";
			}
		//		document.getElementById('txtRegdate').value=colds.Tables[0].Rows[0].REG_DATE;
	  if(colds.Tables[0].Rows[0].Remarks== "null" || colds.Tables[0].Rows[0].Remarks==null)
			{  
	     	 document.getElementById('txtRemarks').value="";
		    }
			else
			{
			 document.getElementById('txtRemarks').value=colds.Tables[0].Rows[0].Remarks;
			}
			
			if(colds.Tables[0].Rows[0].Box_Address== "null" || colds.Tables[0].Rows[0].Box_Address==null)
			{  
		     document.getElementById('txtBoxAdd').value="";  
		    }
			else
			{
			document.getElementById('txtBoxAdd').value=colds.Tables[0].Rows[0].Box_Address;
			}
			
			if(colds.Tables[0].Rows[0].VAT_TINNO== "null" || colds.Tables[0].Rows[0].VAT_TINNO==null)
			{  
		     document.getElementById('txtvatinno').value="";  
		    }
			else
			{
			document.getElementById('txtvatinno').value=colds.Tables[0].Rows[0].VAT_TINNO;
			}
		CancelClick4('ColorMaster');
	
			
			return false;
	}
	else
	{
	document.getElementById('txtCompanyCode').value=colds.Tables[0].Rows[z].Comp_Code;
		document.getElementById('txtCompanyName').value=colds.Tables[0].Rows[z].Comp_Name;
	document.getElementById('txtCompanyalias').value=colds.Tables[0].Rows[z].Comp_Alias;
		   document.getElementById('txtCompanyadd').value=colds.Tables[0].Rows[z].Add1;
		   
		   document.getElementById('drpcountry').value=colds.Tables[0].Rows[z].Country_Code;
         var res=Company_Master.addcou(colds.Tables[0].Rows[z].Country_Code);
            bindcity(res);		
             if(colds.Tables[0].Rows[z].Street=="null" || colds.Tables[0].Rows[z].Street==null)
			{   
	         document.getElementById('txtStreet').value="";
	      	}
			else
			{
			  document.getElementById('txtStreet').value=colds.Tables[0].Rows[z].Street;
	        }
	     	document.getElementById('drpcity').value=colds.Tables[0].Rows[z].City_Code;
		
		    if(colds.Tables[0].Rows[z].Zip=="null" || colds.Tables[0].Rows[z].Zip==null)
			{   
	          document.getElementById('txtZip').value="";
	      	}
			else
			{
			document.getElementById('txtZip').value=colds.Tables[0].Rows[z].Zip;;
			}
		//document.getElementById('txtZip').value=colds.Tables[0].Rows[0].Zip;
		    if(colds.Tables[0].Rows[z].Dist_Code=="null" || colds.Tables[0].Rows[z].Dist_Code==null)
			{   
	         document.getElementById('txtDistrict').value="";
	      	}
			else
			{
			document.getElementById('txtDistrict').value=colds.Tables[0].Rows[z].Dist_Code;
			
			}
//		var pcity=trim(document.getElementById('drpcity').value);
		document.getElementById('txtState').value=colds.Tables[0].Rows[z].State_Code;
		
		  if(colds.Tables[0].Rows[z].Phone1=="null" || colds.Tables[0].Rows[z].Phone1==null)
			{  
		    document.getElementById('txtPhone1').value="";
		    }
			else
			{
			document.getElementById('txtPhone1').value=colds.Tables[0].Rows[z].Phone1;
			
			}
			
			 if(colds.Tables[0].Rows[z].Phone2=="null" || colds.Tables[0].Rows[z].Phone2==null)
			{  
			document.getElementById('txtPhone2').value="";
            }
			else
			{
			document.getElementById('txtPhone2').value=colds.Tables[0].Rows[z].Phone2;
			}
			
			 if(colds.Tables[0].Rows[z].Fax=="null" || colds.Tables[0].Rows[z].Fax==null)
			{  
	         document.getElementById('txtfax').value="";
		     }
			else
			{
			document.getElementById('txtfax').value=colds.Tables[0].Rows[z].Fax;
			}
			
			 if(colds.Tables[0].Rows[z].EmailID=="null" || colds.Tables[0].Rows[z].EmailID==null)
			{  
		     document.getElementById('txtEmailid').value="";
		 	}
			else
			{
			  document.getElementById('txtEmailid').value=colds.Tables[0].Rows[z].EmailID;
			}
			
			 if(colds.Tables[0].Rows[z].ST_Acc_No=="null" || colds.Tables[0].Rows[z].ST_Acc_No==null)
			{  
		     document.getElementById('txtStAcNo').value="";
			}
			else
			{
			document.getElementById('txtStAcNo').value=colds.Tables[0].Rows[z].ST_Acc_No;
			}
			
			
			if(colds.Tables[0].Rows[z].PAN_No=="null" || colds.Tables[0].Rows[z].PAN_No==null)
			{  
		     document.getElementById('txtPan').value="";
		    }
			else
			{
			document.getElementById('txtPan').value=colds.Tables[0].Rows[z].PAN_No;
			}
			
			if(colds.Tables[0].Rows[z].TAN_No=="null" || colds.Tables[0].Rows[z].TAN_No==null)
			{  
		     document.getElementById('txtTan').value="";
		    }
			else
			{
			document.getElementById('txtTan').value=colds.Tables[0].Rows[z].TAN_No;
			}
			
			 if(colds.Tables[0].Rows[z].Reg_No=="null"||colds.Tables[0].Rows[z].Reg_No==null)
			{  
		     document.getElementById('txtRegno').value="";
		    }
			else
			{
			document.getElementById('txtRegno').value=colds.Tables[0].Rows[z].Reg_No;
			}
		
				var dateformat=document.getElementById('hiddendateformat').value; 
		
		if(colds.Tables[0].Rows[z].Reg_Date != null && colds.Tables[0].Rows[z].Reg_Date != "")
			{
			var validate_fromdate=colds.Tables[0].Rows[z].Reg_Date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtRegdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtRegdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtRegdate').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtRegdate').value="";
			}
		//		document.getElementById('txtRegdate').value=colds.Tables[0].Rows[0].REG_DATE;
			 if(colds.Tables[0].Rows[z].Remarks== "null" || colds.Tables[0].Rows[z].Remarks==null)
			{  
	     	 document.getElementById('txtRemarks').value="";
		    }
			else
			{
			 document.getElementById('txtRemarks').value=colds.Tables[0].Rows[z].Remarks;
			}
			
			if(colds.Tables[0].Rows[z].Box_Address== "null" || colds.Tables[0].Rows[z].Box_Address==null)
			{  
		     document.getElementById('txtBoxAdd').value="";  
		    }
			else
			{
			document.getElementById('txtBoxAdd').value=colds.Tables[0].Rows[z].Box_Address;
			}
			
			if(colds.Tables[0].Rows[z].VAT_TINNO== "null" || colds.Tables[0].Rows[z].VAT_TINNO==null)
			{  
		     document.getElementById('txtvatinno').value="";  
		    }
			else
			{
			document.getElementById('txtvatinno').value=colds.Tables[0].Rows[z].VAT_TINNO;
			}
	//CancelClick4('ColorMaster');
						
			//updateStatus();		
	}
	setButtonImages();
	return false;
}


//function autoornot()
// {
//  if(document.getElementById('hiddenauto').value==1)
//    {
//    changeoccured();
//    return false;
//    }
//else
//    {
//    userdefine();

//    //return false;
//    }
////return false;
//}


//// Auto generated
//// This Function is for check that whether this is case for new or modify

//function changeoccured()
//{
//if(hiddentext=="new" )
//			{
//	
//           // uppercase3();
//           
//           }
//            else
//            {
//            document.getElementById('txtCompanyName').value=document.getElementById('txtCompanyName').value.toUpperCase();
//            }
//return false;
//}


function userdefine()
    {
        if(hiddentext=="new")// || hiddentext=="modify") 
        {
        
        document.getElementById('txtCompanyCode').disabled=false;
        document.getElementById('txtCompanyName').value=document.getElementById('txtCompanyName').value.toUpperCase();
        document.getElementById('txtCompanyalias').value=document.getElementById('txtCompanyName').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

//return false;
}
//function ClientUpperCase(field)
//{
//     // document.getElementById('txtCompanyCode').disabled=false;
//        document.getElementById(field).value=document.getElementById(field).value.toUpperCase();
//}

function ClientisNumber()
{
	if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11))
	{
		
		return true;
	}
	else
	{
		return false;
	}

}



function ClientisNumberforcompany(event) {
    var browser = navigator.appName;
    //alert(event.which);
    if (event.shiftKey == true)
        return false;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 9) || (event.which == 0) || (event.which == 8) || (event.which == 11) || (event.which == 13) || (event.which == 44)) {

            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 9) || (event.keyCode == 11) || (event.keyCode == 13) || (event.keyCode == 44)) {

            return true;
        }
        else {
            return false;
        }
    }

}


////function ClientEmailCheck1(q) 
////{
////	var theurl=document.getElementById('txtEmailid').value;

////	if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value == "" || document.getElementById(q).value.indexOf(",") > 0)
////	{
////		return (true)
////	}
////	alert("Invalid E-mail Address! Please re-enter.")
////	//alert("mail");
////	document.getElementById('txtEmailid').value="";
////	document.getElementById('txtEmailid').focus();
////	return false;
////}



function ClientEmailCheck1(q) {
    var theurl = document.Form1.txtEmailid.value;

    var splt = theurl.split(',');
    if (splt.length > 1) {
        for (var i = 0; i < splt.length; i++) {
            var eml2 = splt[i];
            if (eml2 != "") {
                if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(splt[i]) || document.getElementById(q).value == "") {

                }
                else {
                    alert("Invalid E-mail Address! Please re-enter.")
                    //document.getElementById(q).value="";
                    document.getElementById(q).focus();
                    return (false)
                }
            }
            else {
                //        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(splt[i]) || document.getElementById(q).value=="")
                //	{
                //		return (true)
                //	}
                //	alert("Invalid E-mail Address! Please re-enter.")
                //	//document.getElementById(q).value="";
                //	document.getElementById(q).focus();
                return (true)
            }
        }
    }
    else
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value == "") {
        return (true)
    }
    //	var splt= theurl.split(',');
    else {
        alert("Invalid E-mail Address! Please re-enter.")
        //document.getElementById(q).value="";
        document.getElementById(q).focus();
        return (false)
    }
}



function ClientEmailCheck_tab(q) {
    var theurl = document.getElementById('txtdiremail').value;

    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value == "") {
        return (true)
    }
    alert("Invalid E-mail Address! Please re-enter.")
    //alert("mail");
    document.getElementById('txtdiremail').value = "";
    document.getElementById('txtdiremail').focus();
    return false;
}
function ExitClick4()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				//return false;
			}
			return false;
}

function addregcity_client()
{
//alert(document.Form1.drpcity.value);
//alert(document.Form1.drpcity.value);

var values=document.getElementById('drpcity').value;
	if(values!="0")
	{
	Company_Master.addreg(values,FillDropDownList_CallBackMaindoc_client);
	
	}
	else
    {
	   document.getElementById('txtState').value="";
	   document.getElementById('txtDistrict').value="";	
				//document.forms[0].item("drpzone").options.length=ds.Tables[2].Rows.length;
	}	 			
				
	return false;

}


function addregcity_client1() {
    //alert(document.Form1.drpcity.value);
    //alert(document.Form1.drpcity.value);

    var values = document.getElementById('drpdircity').value;
    if (values != "0") {
        Company_Master.addreg(values, FillDropDownList_CallBackMaindoc_client1);

    }
    else {
        document.getElementById('txtdirstate').value = "";
        document.getElementById('txtdirdistrict').value = "";
        //document.forms[0].item("drpzone").options.length=ds.Tables[2].Rows.length;
    }

    return false;

}


			
function FillDropDownList_CallBackMaindoc_client(response) 
{


    var ds = response.value;


   // var region=document.getElementById('drpregion');
    //var zone=document.getElementById('drpzone');


    if(document.getElementById('drpcity').value!="0" && document.getElementById('drpcity').value!="")
    {

        if(ds!= null && typeof(ds) == "object" && ds.Tables!= null && ds.Tables.length>0) 
        {	

//            document.getElementById("drpzone").options[0]=new Option("------Select Zone------","0");
//            document.getElementById("drpregion").options[0]=new Option("-----Select Region-----","0");

//            document.getElementById("drpregion").options.length=0;		
//            document.getElementById("drpregion").options.length=ds.Tables[1].Rows.length;

//            document.getElementById("drpzone").options.length=0;		
//            document.getElementById("drpzone").options.length=ds.Tables[2].Rows.length;


//            if(ds.Tables[4].Rows.length>0)
//            {	
//                for(var i=0;i<ds.Tables[1].Rows.length;++i) 
//                {
//                    document.getElementById("drpregion").options[i]=new Option(ds.Tables[2].Rows[i].region_name,ds.Tables[2].Rows[i].region_code);
//                }	
//                document.getElementById('drpregion').value=ds.Tables[2].Rows[0].region_code;

//            }
//            else
//            {
//                if(document.getElementById('drpcity').disabled==false)
//                {
//                    //alert("There is no matching value(s) found for region");
//                }
////document.getElementById('drpregion').disabled=true;
//                region.options.length=0;
//                //return false;

//            }	

//document.getElementById("hiddenregion").value=document.getElementById("drpregion").value;


            if(ds.Tables[0].Rows.length>0)
            {
                document.getElementById('txtState').value=ds.Tables[0].Rows[0].state_name;
            }
            else
            {
                if(document.getElementById('drpcity').disabled==false)
                {
                    alert("There is no matching value for state");
                }
                document.getElementById('txtState').value="";
            //document.getElementById('txtstate').disabled=true;

            }



            if(ds.Tables[1].Rows.length>0)
            {
                document.getElementById('txtDistrict').value=ds.Tables[1].Rows[0].dist_name;
            }
            else
            {
                document.getElementById('txtDistrict').value="";
                //document.getElementById('drpcity').disabled=true;//this is disabled in city master
            }
//            if(document.getElementById('drpcity').disabled==false)
//            {
//                //alert("There is no matching value for district");//this is disabled in city master
//            }
            

        
}



    return false;
}	
}

function setButtonImages()
{
    if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
}

function blank_fields()
{

CancelClick4('Company_Master');
givebuttonpermission('Company_Master');

}

function checktab(opendiv) {

      modifydate = "Yes" ;

      if (document.getElementById('btnNew').disabled != false || modifydate == "Yes") {


        
       
       

         if (opendiv == "Dirinform") {

             document.getElementById('DesInfTab').style.display = "block";


             document.getElementById('DesInfTab').className = "btnlink_selected";

            return false;
        }
        else {
            return false;
        }
    }
    
}


function addcount1(cou) {
    document.getElementById('txtdirdistrict').value = "";
    document.getElementById('txtdirstate').value = "";
    if (typeof (cou) == "object") {
        var country = cou.value;
    }
    else {
        var country = cou;
    }
    //var country=document.getElementById('txtcountry').value;
    if (country != "0") {
        Company_Master.addcou1(country, callcount1);
    }
    else {
        document.getElementById("drpdircity").options.length = 1;
    }
    return false;
}




var po_no = "";
function savetab(res) {

   
   
   
   



        var str = $('hdntblfields').value;
        var str1 = str.split("$~$");

        var tablename = str1[str1.length - 2];

        var action = str1[str1.length - 1];
        var finalaction = action.split("#");

        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];








//        if (trim($('txtdirpername').value) == "") {
//            alert('Please Fill Unit Name')
//            $('txtdirpername').focus()
//            return false;
//        }



//        if (trim($('txtdiradd').value) == "") {
//            alert('Please press F2 Branch Name')
//            //$('txtbranch').value = "";
//            $('txtdiradd').focus()
//            return false;
//        }

//        if (trim($('txtdirstreet').value) == "") {
//            alert('Please Fill Pay Date')
//            $('txtdirstreet').focus()
//            return false;
//        }




//        if (trim($('drpdircity').value) == "") {
//           alert('Please Fill Trnp name')
//           $('drpdircity').focus()
//            return false;
//        }



//        if (trim($('txtdirstate').value) == "") {
//            alert('Please press F2 for Agent Code')
//            $('txtdirstate').value = "";
//            
//            return false;
//        }

//        if (trim($('drpdircountry').value) == "") {
//            alert('Please Fill Net Paid Amt')
//            $('drpdircountry').focus()
//            return false;
//        }



//        if (trim($('txtdirdistrict').value) == "") {
//            alert('Please Fill Paymode')

//            $('txtdirdistrict').focus()
//            return false;
//        }

       
  

//        if (trim($('txt_vch_no').value) == "") {
//            alert('Please enter VCH No')
//           // $('txt_vch_no').value = "";
//            $('txt_vch_no').focus()
//            return false;
//        }

//        if (trim($('txt_vch_dt').value) == "") {
//            alert('Please enter Vch ')
//          //  $('txt_vch_dt').value = "";
//            $('txt_vch_dt').focus()
//            return false;
//        }


       po_no = "";

       // var compcode = $('hdncompcode').value;

        var compcode = trim(document.getElementById('txtCompanyCode').value);
       // po_no = ds.Tables[0].Rows[0].V_CODE;
     //   var casepocode = "'" + po_no + "'"



        var dirname = "'" + repalcesinglequote(trim($('txtdirpername').value)) + "'";
        var address = "'" + repalcesinglequote(trim($('txtdiradd').value)) + "'";
        var street = "'" + repalcesinglequote(trim($('txtdirstreet').value)) + "'";
       var city = "'" + repalcesinglequote(trim($('drpdircity').value)) + "'";
       var state = "'" + repalcesinglequote(trim($('txtdirstate').value)) + "'";
        var country = "'" + repalcesinglequote(trim($('drpdircountry').value)) + "'";
////        var city1 = 'DELHI';
////        var city = "'" + repalcesinglequote(city1) + "'";
////        var country1 = 'INDIA';
////        var country = "'" + repalcesinglequote(country1) + "'";
////        var state1 = 'DELHI';
////        var state = "'" + repalcesinglequote(state1) + "'";
        var district = "'" + repalcesinglequote(trim($('txtdirdistrict').value)) + "'";
        //var district1 = 'DELHI';
      //  var district = "'" + repalcesinglequote(district1) + "'";
        var zip = "'" + repalcesinglequote(trim($('txtdirzip').value)) + "'";
        var phone1 = "'" + repalcesinglequote(trim($('txtdirphone1').value)) + "'";

        var phone2 = "'" + repalcesinglequote(trim($('txtdirphone2').value)) + "'";


        var fax = "'" + repalcesinglequote(trim($('txtdirfax').value)) + "'";

        var email = "'" + repalcesinglequote(trim($('txtdiremail').value)) + "'";
        var statezip = "'" + repalcesinglequote(trim($('txtstatezip').value)) + "'";

        var countryzip = "'" + repalcesinglequote(trim($('txtcountryzip').value)) + "'";
       
     // var CREATED_DT = "'" + $('HDN_server_date').value + "'";

        var date_format = $('hiddendateformat').value;


        var finalval = "'" + compcode + "'" + "$~$" + dirname + "$~$"  + address + "$~$" + street + "$~$" + city + "$~$" + state + "$~$" + country + "$~$" + district + "$~$" + zip + "$~$" + phone1 + "$~$" + phone2 + "$~$" + fax + "$~$" + email + "$~$" + statezip + "$~$" + countryzip 
        var fields = $('hdntblfields').value.replace("$~$" + tablename, "")
        fields = fields.replace("$~$" + action, "")

        var result = Company_Master.savedata(fields, finalval, tablename, insert, date_format, "", "")
    }





    function repalcesinglequote(val) {
        if (val.indexOf("'") >= 0) {
            while (val.indexOf("'") >= 0) {
                val = val.replace("'", "^");
            }
        }
        return val;
    }


    function repalcestr2quote(val) {

        if (val == undefined) {
            var ab11 = "";
            return ab11;
        }
        if (val.indexOf("^") >= 0) {
            while (val.indexOf("^") >= 0) {
                val = val.replace("^", "'");
            }
        }
        return val;
    }




    function EnableExecute() {

      //  chkexecute = "execute";

//next = 0;
       




//        document.getElementById("txt_comp").disabled = true;
//        document.getElementById("ddlpaymode").disabled = true;
//        document.getElementById("txt_unit").disabled = true;
//        document.getElementById("txt_chq_no").disabled = true;
//        document.getElementById("txtbranch").disabled = true;
//        document.getElementById("txt_chq_dt").disabled = true;
//        document.getElementById("txt_pay_id").disabled = true;
//        document.getElementById("txt_cdp").disabled = true;
//        document.getElementById("txt_cds").disabled = true;
//        document.getElementById("txt_trnp_name").disabled = true;
//        document.getElementById("txt_vch_no").disabled = true;
//        document.getElementById("txt_agent_code").disabled = true;
//        document.getElementById("txt_vch_dt").disabled = true;
//        document.getElementById("txt_net_paid_amt").disabled = true;
//        document.getElementById("txt_pay_dt").disabled = true;







      //  $('btnModify').focus();
//



       // var str = $('executefields').value;
      //  var str1 = str.split("$~$");
      //  var tablename = str1[str1.length - 2];

        var str = $('hdntblfields').value;
        var str1 = str.split("$~$");

        var tablename = str1[str1.length - 2];
       
        var action = str1[str1.length - 1];
        var finalaction = action.split("#");
        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];







        var compcode = trim(document.getElementById('txtCompanyCode').value);
        // po_no = ds.Tables[0].Rows[0].V_CODE;
        //   var casepocode = "'" + po_no + "'"



        var dirname = "'" + repalcesinglequote(trim($('txtdirpername').value)) + "'";
        var address = "'" + repalcesinglequote(trim($('txtdiradd').value)) + "'";
        var street = "'" + repalcesinglequote(trim($('txtdirstreet').value)) + "'";
        var city = "'" + repalcesinglequote(trim($('drpdircity').value)) + "'";
          var state = "'" + repalcesinglequote(trim($('txtdirstate').value)) + "'";
         var country = "'" + repalcesinglequote(trim($('drpdircountry').value)) + "'";
       // var city1 = 'DELHI';
       // var city = "'" + repalcesinglequote(city1) + "'";
//var country1 = 'INDIA';
//var country = "'" + repalcesinglequote(country1) + "'";
       // var state1 = 'DELHI';
       // var state = "'" + repalcesinglequote(state1) + "'";
          var district = "'" + repalcesinglequote(trim($('txtdirdistrict').value)) + "'";
       // var district1 = 'DELHI';
       // var district = "'" + repalcesinglequote(district1) + "'";
        var zip = "'" + repalcesinglequote(trim($('txtdirzip').value)) + "'";
        var phone1 = "'" + repalcesinglequote(trim($('txtdirphone1').value)) + "'";

        var phone2 = "'" + repalcesinglequote(trim($('txtdirphone2').value)) + "'";


        var fax = "'" + repalcesinglequote(trim($('txtdirfax').value)) + "'";

        var email = "'" + repalcesinglequote(trim($('txtdiremail').value)) + "'";
        var statezip = "'" + repalcesinglequote(trim($('txtstatezip').value)) + "'";

        var countryzip = "'" + repalcesinglequote(trim($('txtcountryzip').value)) + "'";

        // var CREATED_DT = "'" + $('HDN_server_date').value + "'";

        var dateformat = $('hiddendateformat').value;


        var finalval = "'" + compcode + "'" + "$~$" + dirname + "$~$" + address + "$~$" + street + "$~$" + city + "$~$" + state + "$~$" + country + "$~$" + district + "$~$" + zip + "$~$" + phone1 + "$~$" + phone2 + "$~$" + fax + "$~$" + email + "$~$" + statezip + "$~$" + countryzip
        var fields = $('hdntblfields').value.replace("$~$" + tablename, "")
        fields = fields.replace("$~$" + action, "")

        //  var finalval = compcode + "$~$" + branch_code + "$~$" + po_type + "$~$" + po_no + "$~$" + po_date + "$~$" + agent_code + "$~$" + supp_code + "$~$" + type_code + "$~$" + terms + "$~$" + payment + "$~$" + tax + "$~$" + exec_name + "$~$" + designation + "$~$" + remark + "$~$";
        Company_Master.execute(tablename, fields, finalval, select, dateformat, "", "", callback_exec)

        return false;



    }






    function callback_exec(res)
     {

        // alert('fgfhchk');
       next = 0;
        dsexe = res.value;

        //    var abcd=dsexe.Tables[0].Rows.length;
        //    alert(abcd);

        record_show = 5
        record_show1 = 1


        if (dsexe == null || dsexe == "" || dsexe.Tables[0].Rows.length == "0" || dsexe.Tables[0].Rows.length == 0)
         {
        //    alert('There is No data Regarding Your Query')
            // $('txt_pono').value="";
//            document.getElementById("ddlpaymode").value = "";
//            document.getElementById("txt_unit").value = "";
//            document.getElementById("txt_chq_no").value = "";
//            document.getElementById("txtbranch").value = "";
//            document.getElementById("txt_chq_dt").value = "";
//            document.getElementById("txt_pay_id").value = "";
//            document.getElementById("txt_cdp").value = "";
//            document.getElementById("txt_cds").value = "";
//            document.getElementById("txt_trnp_name").value = "";
//            document.getElementById("txt_vch_no").value = "";
//            document.getElementById("txt_agent_code").value = "";
//            document.getElementById("txt_vch_dt").value = "";
//            document.getElementById("txt_net_paid_amt").value = "";
//            document.getElementById("txt_pay_dt").value = "";

            return false;
        }

        if (dsexe.Tables[0].Rows.length == 1) 
        {




            var comp_code = fndnull(dsexe.Tables[0].Rows[next].COMP_CODE);

            $('txtCompanyCode').value = dsexe.Tables[0].Rows[next].COMP_CODE

            


            if (dsexe.Tables[0].Rows[next].DIRECTOR_NAME == null) {
                $('txtdirpername').value = "";
            }
            else {
                $('txtdirpername').value = repalcestr2quote(dsexe.Tables[0].Rows[next].DIRECTOR_NAME)

            }


           

            if (dsexe.Tables[0].Rows[next].ADD1 == null) {
                $('txtdiradd').value = "";
            }
            else {
                $('txtdiradd').value = dsexe.Tables[0].Rows[next].ADD1
            }

            if (dsexe.Tables[0].Rows[next].STREET == null) {
                $('txtdirstreet').value = "";
            }
            else {
                $('txtdirstreet').value = dsexe.Tables[0].Rows[next].STREET
            }


            if (dsexe.Tables[0].Rows[next].CITY_CODE == null) {
                $('drpdircity').value = "";
            }
            else {
                $('drpdircity').value = repalcestr2quote(dsexe.Tables[0].Rows[next].CITY_CODE)
            }


            if (dsexe.Tables[0].Rows[next].STATE_CODE == null) {
                $('txtdirstate').value = "";
            }
            else {

              //  $('Hiddenagentcode').value = (dsexe.Tables[0].Rows[next].AGENT_CODE)
                $('txtdirstate').value = repalcestr2quote(dsexe.Tables[0].Rows[next].STATE_CODE)
            }


           




            if (dsexe.Tables[0].Rows[next].COUNTRY_CODE == null) {
                $('drpdircountry').value = "";
            }
            else {
                $('drpdircountry').value = repalcestr2quote(dsexe.Tables[0].Rows[next].COUNTRY_CODE)

                }

               



            if (dsexe.Tables[0].Rows[next].DIST_CODE == null) {
                $('txtdirdistrict').value = "";
            }
            else {
                // var po_d = CHKDATE(dsexe.Tables[0].Rows[next].CHQNO)
                $('txtdirdistrict').value = repalcestr2quote(dsexe.Tables[0].Rows[next].DIST_CODE)
            }


            if (dsexe.Tables[0].Rows[next].ZIP == null) {
                $('txtdirzip').value = "";
            }
            else {


                var po_d = repalcestr2quote(dsexe.Tables[0].Rows[next].ZIP)

                $('txtdirzip').value = po_d;
                // $('txt_chq_dt').value = repalcestr2quote(dsexe.Tables[0].Rows[next].CHQDT)
            }



            if (dsexe.Tables[0].Rows[next].PHONE1 == null) {
                $('txtdirphone1').value = "";
            }
            else {


                var po_d = (dsexe.Tables[0].Rows[next].PHONE1)

                $('txtdirphone1').value = po_d;

            }

            if (dsexe.Tables[0].Rows[next].PHONE2 == null) {
                $('txtdirphone2').value = "";
            }
            else {


                $('txtdirphone2').value = (dsexe.Tables[0].Rows[next].PHONE2)
            }

            if (dsexe.Tables[0].Rows[next].FAX == null) {
                $('txtdirfax').value = "";
            }
            else {
                $('txtdirfax').value = repalcestr2quote(dsexe.Tables[0].Rows[next].FAX)
            }

            if (dsexe.Tables[0].Rows[next].EMAILID == null) {
                $('txtdiremail').value = "";
            }
            else {
                $('txtdiremail').value = (dsexe.Tables[0].Rows[next].EMAILID)
            }

            if (dsexe.Tables[0].Rows[next].STATE_ZIP == null) {
                $('txtstatezip').value = "";
            }
            else {
                $('txtstatezip').value = dsexe.Tables[0].Rows[next].STATE_ZIP
            }




            if (dsexe.Tables[0].Rows[next].COUNTRY_ZIP == null) {
                $('txtcountryzip').value = "";
            }
            else {
                $('txtcountryzip').value = (dsexe.Tables[0].Rows[next].COUNTRY_ZIP)
            }








            $('btnfirst').disabled = true;
            $('btnlast').disabled = true;
            $('btnprevious').disabled = true;
            $('btnnext').disabled = true;
            setButtonImages();
        }



        else if (dsexe.Tables[0].Rows.length > 0)
         {



           var comp_code = fndnull(dsexe.Tables[0].Rows[next].COMP_CODE);

           $('txtCompanyCode').value = dsexe.Tables[0].Rows[next].COMP_CODE

            


            if (dsexe.Tables[0].Rows[next].DIRECTOR_NAME == null) 
            {
                $('txtdirpername').value = "";
            }
            else
             {
                $('txtdirpername').value = repalcestr2quote(dsexe.Tables[0].Rows[next].DIRECTOR_NAME)

            }


           

            if (dsexe.Tables[0].Rows[next].ADD1 == null) {
                $('txtdiradd').value = "";
            }
            else {
                $('txtdiradd').value = dsexe.Tables[0].Rows[next].ADD1
            }

            if (dsexe.Tables[0].Rows[next].STREET == null)
             {
                $('txtdirstreet').value = "";
            }
            else {
                $('txtdirstreet').value = dsexe.Tables[0].Rows[next].STREET
            }


            if (dsexe.Tables[0].Rows[next].CITY_CODE == null) 
            {
                $('drpdircity').value = "";
            }
            else 
            {
                $('drpdircity').value = repalcestr2quote(dsexe.Tables[0].Rows[next].CITY_CODE)
            }


            if (dsexe.Tables[0].Rows[next].STATE_CODE == null) 
            {
                $('txtdirstate').value = "";
            }
            else 
            {

              //  $('Hiddenagentcode').value = (dsexe.Tables[0].Rows[next].AGENT_CODE)
                $('txtdirstate').value = repalcestr2quote(dsexe.Tables[0].Rows[next].STATE_CODE)
            }







            if (dsexe.Tables[0].Rows[next].COUNTRY_CODE == null)
             {
                $('drpdircountry').value = "";
            }
            else
             {
                $('drpdircountry').value = repalcestr2quote(dsexe.Tables[0].Rows[next].COUNTRY_CODE)

            }




            if (dsexe.Tables[0].Rows[next].DIST_CODE == null) 
            {
                $('txtdirdistrict').value = "";
            }
            else 
            {
                // var po_d = CHKDATE(dsexe.Tables[0].Rows[next].CHQNO)
                $('txtdirdistrict').value = repalcestr2quote(dsexe.Tables[0].Rows[next].DIST_CODE)
            }


            if (dsexe.Tables[0].Rows[next].ZIP == null) 
            {
                $('txtdirzip').value = "";
            }
            else {


                var po_d = repalcestr2quote(dsexe.Tables[0].Rows[next].ZIP)

                $('txtdirzip').value = po_d;
                // $('txt_chq_dt').value = repalcestr2quote(dsexe.Tables[0].Rows[next].CHQDT)
            }



            if (dsexe.Tables[0].Rows[next].PHONE1 == null)
             {
                $('txtdirphone1').value = "";
            }
            else 
            {


                var po_d = (dsexe.Tables[0].Rows[next].PHONE1)

                $('txtdirphone1').value = po_d;

            }

            if (dsexe.Tables[0].Rows[next].PHONE2 == null) {
                $('txtdirphone2').value = "";
            }
            else {


                $('txtdirphone2').value = (dsexe.Tables[0].Rows[next].PHONE2)
            }

            if (dsexe.Tables[0].Rows[next].FAX == null) {
                $('txtdirfax').value = "";
            }
            else {
                $('txtdirfax').value = repalcestr2quote(dsexe.Tables[0].Rows[next].FAX)
            }

            if (dsexe.Tables[0].Rows[next].EMAILID == null) {
                $('txtdiremail').value = "";
            }
            else {
                $('txtdiremail').value = (dsexe.Tables[0].Rows[next].EMAILID)
            }

            if (dsexe.Tables[0].Rows[next].STATE_ZIP == null) {
                $('txtstatezip').value = "";
            }
            else {
                $('txtstatezip').value = dsexe.Tables[0].Rows[next].STATE_ZIP
            }




            if (dsexe.Tables[0].Rows[next].COUNTRY_ZIP == null) {
                $('txtcountryzip').value = "";
            }
            else {
                $('txtcountryzip').value = (dsexe.Tables[0].Rows[next].COUNTRY_ZIP)
            }



            /*********************/
        }




        return false;

    }




    function fndnull(myval) {
        if (myval == "undefined") {
            myval = "";
        }
        else if (myval == null) {
            myval = "";
        }
        return myval
    }



    function callcount1(res) {

        var ds = res.value;
        var pkgitem = document.getElementById("drpdircity");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length == 0) {
            pkgitem.options.length = 1;
            pkgitem.options[0] = new Option("--Select City--", "0");
            document.getElementById('txtdirdistrict').value = "";
            document.getElementById('txtdirstate').value = "";
        }


        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {

            pkgitem.options.length = 1;
            pkgitem.options[0] = new Option("--Select City--", "0");
            document.getElementById('txtdirdistrict').value = "";
            document.getElementById('txtdirstate').value = "";
            //alert(pkgitem.options.length);
            for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name, res.value.Tables[0].Rows[i].City_Code);

                pkgitem.options.length;

            }


            return false;
        }
    }



    function FillDropDownList_CallBackMaindoc_client1(response) {


        var ds = response.value;


        // var region=document.getElementById('drpregion');
        //var zone=document.getElementById('drpzone');


        if (document.getElementById('drpdircity').value != "0" && document.getElementById('drpdircity').value != "") {

            if (ds != null && typeof (ds) == "object" && ds.Tables != null && ds.Tables.length > 0) {

              

                if (ds.Tables[0].Rows.length > 0) {
                    document.getElementById('txtdirstate').value = ds.Tables[0].Rows[0].state_name;
                }
                else {
                    if (document.getElementById('drpdircity').disabled == false) {
                        alert("There is no matching value for state");
                    }
                    document.getElementById('txtdirstate').value = "";
               

                }



                if (ds.Tables[1].Rows.length > 0) {
                    document.getElementById('txtdirdistrict').value = ds.Tables[1].Rows[0].dist_name;
                }
                else {
                    document.getElementById('txtdirdistrict').value = "";
                    //document.getElementById('drpcity').disabled=true;//this is disabled in city master
                }
              

            }



            return false;
        }
    }







    function delete_grid() {


       
       










        var str = $('hdntblfields').value;
        var str1 = str.split("$~$");
        var tablename = str1[str1.length - 2];
        var action = str1[str1.length - 1];
        var finalaction = action.split("#");
        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];



        var str3 = str.split("$~$");
        var delcolname = "";
        var deltblname = str3[str3.length - 1];

        delcolname = str.replace("$~$" + deltblname, "")
        delcolname = delcolname + "$~$";










        var compcode = trim(document.getElementById('txtCompanyCode').value);
       


        var dirname = "'" + repalcesinglequote(trim($('txtdirpername').value)) + "'";
        var address = "'" + repalcesinglequote(trim($('txtdiradd').value)) + "'";
        var street = "'" + repalcesinglequote(trim($('txtdirstreet').value)) + "'";
        var city = "'" + repalcesinglequote(trim($('drpdircity').value)) + "'";
        var state = "'" + repalcesinglequote(trim($('txtdirstate').value)) + "'";
        var country = "'" + repalcesinglequote(trim($('drpdircountry').value)) + "'";
       
        var district = "'" + repalcesinglequote(trim($('txtdirdistrict').value)) + "'";
        
        var zip = "'" + repalcesinglequote(trim($('txtdirzip').value)) + "'";
        var phone1 = "'" + repalcesinglequote(trim($('txtdirphone1').value)) + "'";

        var phone2 = "'" + repalcesinglequote(trim($('txtdirphone2').value)) + "'";


        var fax = "'" + repalcesinglequote(trim($('txtdirfax').value)) + "'";

        var email = "'" + repalcesinglequote(trim($('txtdiremail').value)) + "'";
        var statezip = "'" + repalcesinglequote(trim($('txtstatezip').value)) + "'";

        var countryzip = "'" + repalcesinglequote(trim($('txtcountryzip').value)) + "'";

        // var CREATED_DT = "'" + $('HDN_server_date').value + "'";

        var dateformat = $('hiddendateformat').value;


        var finalval = "'" + compcode + "'" + "$~$" + dirname + "$~$" + address + "$~$" + street + "$~$" + city + "$~$" + state + "$~$" + country + "$~$" + district + "$~$" + zip + "$~$" + phone1 + "$~$" + phone2 + "$~$" + fax + "$~$" + email + "$~$" + statezip + "$~$" + countryzip
        var fields = $('hdntblfields').value.replace("$~$" + tablename, "")
        fields = fields.replace("$~$" + action, "")

        
      //  var finalval = "'" + compcode + "'" + "$~$" + unitcode + "$~$" + branchcode + "$~$" + pay_id + "$~$" + pay_dt + "$~$" + agent_code + "$~$" + trnp_name + "$~$" + paymode + "$~$" + chq_no + "$~$" + chq_dt + "$~$" + vch_no + "$~$" + vch_dt + "$~$" + cdp + "$~$" + cds + "$~$" + net_paid_amt + "$~$" + userid + "$~$";
      

      //  var delcolvalue = "'" + compcode + "'" + "$~$" + pay_id + "$~$";










//        boolReturn = confirm("Do you want to delete this record ?");
//        if (boolReturn == 1) {

            Company_Master.zone_delete(tablename, fields, finalval, del, dateformat, "", "");
          //  alert("Data Delete Successfully")


            $('btnDelete').focus();
           // blank_fields();
            return false;
        //}


//        else {
//            $('btnDelete').focus()
//            return false;
//        }
    }



    function callback_grid() {


        var str = $('hdntblfields').value;
        var str1 = str.split("$~$");
        var tablename = str1[str1.length - 2];

        var action = str1[str1.length - 1];
        var finalaction = action.split("#");
        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];



        var compcode = trim(document.getElementById('txtCompanyCode').value);



        var dirname = "'" + repalcesinglequote(trim($('txtdirpername').value)) + "'";
        var address = "'" + repalcesinglequote(trim($('txtdiradd').value)) + "'";
        var street = "'" + repalcesinglequote(trim($('txtdirstreet').value)) + "'";
        var city = "'" + repalcesinglequote(trim($('drpdircity').value)) + "'";
        var state = "'" + repalcesinglequote(trim($('txtdirstate').value)) + "'";
        var country = "'" + repalcesinglequote(trim($('drpdircountry').value)) + "'";

        var district = "'" + repalcesinglequote(trim($('txtdirdistrict').value)) + "'";

        var zip = "'" + repalcesinglequote(trim($('txtdirzip').value)) + "'";
        var phone1 = "'" + repalcesinglequote(trim($('txtdirphone1').value)) + "'";

        var phone2 = "'" + repalcesinglequote(trim($('txtdirphone2').value)) + "'";


        var fax = "'" + repalcesinglequote(trim($('txtdirfax').value)) + "'";

        var email = "'" + repalcesinglequote(trim($('txtdiremail').value)) + "'";
        var statezip = "'" + repalcesinglequote(trim($('txtstatezip').value)) + "'";

        var countryzip = "'" + repalcesinglequote(trim($('txtcountryzip').value)) + "'";

        // var CREATED_DT = "'" + $('HDN_server_date').value + "'";

        var dateformat = $('hiddendateformat').value;


        var finalval = "'" + compcode + "'" + "$~$" + dirname + "$~$" + address + "$~$" + street + "$~$" + city + "$~$" + state + "$~$" + country + "$~$" + district + "$~$" + zip + "$~$" + phone1 + "$~$" + phone2 + "$~$" + fax + "$~$" + email + "$~$" + statezip + "$~$" + countryzip
        var fields = $('hdntblfields').value.replace("$~$" + tablename, "")
        fields = fields.replace("$~$" + action, "")





        Company_Master.execute_detail(tablename, fields, finalval, select, "", "", "", callback_execgrid)

    }

