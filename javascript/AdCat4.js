// JScript File
var hiddentext;
var mod="0";
var z=0;
var znk="0";
var auto="";
var hiddentext1="";
var glaobalcatcod;
var glaobalcatname;
var glaobalcatalias;
var glaobalsubcatname;
var glo_cat2=0;
var glo_cat3=0;
var name_modify="";

var dscatexecute;
var y;
var dscatdelete;

function notchar8(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which == 8) || (event.which == 0) || (event.which == 189) || (event.which >= 97 && event.which <= 122) || (event.which == 9 || event.which == 32) || (event.which >= 65 && event.which <= 90) || (event.which == 39)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode == 8) || (event.keyCode == 0) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode == 39)) {
            return false;
        }
        else {
            return true;
        }
    }
}


/*-----For---Upper Case-------------*/
function uppercase1()
{
document.getElementById('txtadcatcode').value=document.getElementById('txtadcatcode').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
return ;
}


function fillAdCat1(cat3)
{
AdCat4.fillCat1(cat3,fillCat1_callback);
//glo_cat3=cat3;
    
}
function fillCat1_callback(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("drpadcategory");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("-Select Add Category-","0");
    
    document.getElementById("drpadcategory").options.length = 1;
    document.getElementById("drpadcategory").options[0] = new Option("-Select Add Category-", "0");

    
    //alert(pkgitem.options.length);
    if(ds!=null)
    {
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].adv_cat_name,ds.Tables[0].Rows[i].adv_cat_code);
        
       pkgitem.options.length;
       
    }
    if(ds.Tables[1].Rows.length!=0)
    {
    document.getElementById("drpadcategory").value=ds.Tables[1].Rows[0].ADV_CAT_CODE;
    fillAdCat2();
    glo_cat2=ds.Tables[1].Rows[0].ADV_SUBCAT_CODE;
    }
  //   document.getElementById("drpadsubcategory").value=ds.Tables[1].Rows[0].ADV_SUBCAT_CODE;
    }
    return false;
}

function fillAdCat2() {
    //dan
    var strtextd = "";
    var httpRequest = null;
    httpRequest = new XMLHttpRequest();
    if (httpRequest.overrideMimeType) {
        httpRequest.overrideMimeType('text/xml');
    }
    //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

    httpRequest.open("GET", "checksessiondan.aspx", false);
    httpRequest.send('');
    //alert(httpRequest.readyState);
    if (httpRequest.readyState == 4) {
        //alert(httpRequest.status);
        if (httpRequest.status == 200) {
            strtextd = httpRequest.responseText;
        }
        else {
            //alert('There was a problem with the request.');
            if (browser != "Microsoft Internet Explorer") {
                //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
            }
        }
    }
    if (strtextd != "sess") {
        alert('session expired');
        window.location.href = "Default.aspx";
        return false;
    }
    AdCat4.fillCat2(document.getElementById('drpadcategory').value,"", fillCat2_callback);

}
function fillCat2_callback(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("drpadsubcategory");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Ad Category2--","0");
    
    document.getElementById("drpadvcatcode").options.length = 1;
    document.getElementById("drpadvcatcode").options[0] = new Option("--Select Ad Category3--", "0");
    
    
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
        
       pkgitem.options.length;
       
    }
    document.getElementById("drpadsubcategory").value=glo_cat2;
    fillAdCat3();
    return false;
}
function fillAdCat3()
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
AdCat4.fillCat3(document.getElementById('drpadsubcategory').value,fillCat3_callback);
    
}
function fillCat3_callback(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("drpadvcatcode");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Ad Category3--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].catname,ds.Tables[0].Rows[i].catcode);
        
       pkgitem.options.length;
       
    }
     document.getElementById("drpadvcatcode").value=glo_cat3;
    return false;
}
function catnewclick()
{

 var msg=checkSession();
        if(msg==false)
        return false;
glo_cat3=0;
glo_cat2=0;
            document.getElementById('drpadcategory').value=0;
//             document.getElementById('drpadsubcategory').value=0;
//            document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value = "";
           
           if(document.getElementById('hiddenauto').value==1)
                {
                   document.getElementById('txtadcatcode').disabled=true;
                   
                }
           else
              {
                document.getElementById('txtadcatcode').disabled=false;
               }
              document.getElementById('txtadcatname').disabled=false;
              document.getElementById('txtalias').disabled=false;
              document.getElementById('drpadvcatcode').disabled=false;
              document.getElementById('drpadcategory').disabled=false;
              document.getElementById('drpadsubcategory').disabled = false;
              document.getElementById('dppubcent').disabled = false;
             if(document.getElementById('hiddenauto').value==1)
               {
                   document.getElementById('dppubcent').focus();
               }
             else
              {
                  document.getElementById('dppubcent').focus();
               }
	hiddentext="new";
	chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
		setButtonImages();
				return false;
	}



	
	function catsaveclick()
{
 var msg=checkSession();
        if(msg==false)
        return false;
 document.getElementById('txtadcatcode').value=trim(document.getElementById('txtadcatcode').value);
 document.getElementById('txtadcatname').value=trim(document.getElementById('txtadcatname').value);
 document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
 document.getElementById('drpadvcatcode').value = trim(document.getElementById('drpadvcatcode').value);
 document.getElementById('dppubcent').value = trim(document.getElementById('dppubcent').value);

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

//if(flag==1)
//				{
//					if(document.getElementById('drpadvcatcode').value=="0")
//		{
//		
//		alert("You Must Select Ad Category Name");
//		document.getElementById('drpadvcatcode').focus();
//		return false;
//		}
//		else
//		{}

        if(document.getElementById('drpadcategory').options.length=="0" || document.getElementById('drpadcategory').value=="0")
              {
              alert("You Must Select Ad Category1 ");
              document.getElementById('drpadcategory').focus();
              return false;
              }
              
         if(document.getElementById('drpadsubcategory').options.length=="0" || document.getElementById('drpadsubcategory').value=="0")
              {
              alert("You Must Select Ad Category2 ");
              document.getElementById('drpadsubcategory').focus();
              return false;
              }
              
		if(document.getElementById('drpadvcatcode').options.length=="0" || document.getElementById('drpadvcatcode').value=="0")
              {
              alert("You Must Select Ad Sub Category3 Name");
              document.getElementById('drpadvcatcode').focus();
              return false;
              }
              
  
			 if((document.getElementById('txtadcatcode').value=="")&&(document.getElementById('hiddenauto').value!=1))
//              {
//                           
//			 if(document.getElementById('txtadcatcode').value=="")
			{
			alert("Please Enter the Category4 Code ");
			document.getElementById('txtadcatcode').focus();
			return false;
			}
//			return false;
//			}
					
			else if(document.getElementById('txtadcatname').value=="")
			{
			alert("Please Enter the Category4 Name ");
			document.getElementById('txtadcatname').focus();
			return false;
			}
			else if(document.getElementById('txtalias').value=="")
			{
			alert("Please enter the Alias");
			document.getElementById('txtalias').focus();
			return false;
			}
			
			
            var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcatcode').value;
			var catname=document.getElementById('txtadcatname').value;
		    catname=trim(catname);
			var catalias=document.getElementById('txtalias').value;
			var userid=document.getElementById('hiddenuserid').value;			

			if(mod !="1" && mod !=null)
			{
			
			AdCat4.chkcatcod(catcode,catname,subcatname,call_saveclick);
			}
			else
			{
			    if(name_modify==document.getElementById('txtadcatname').value)
			    {
			        updatecat4();
			    }
			    else
			    {
			        var str=document.getElementById('txtadcatname').value;
			        AdCat4.catdauto(str,subcatname,modifyclick);
			    }
			}
			return false;
}

function modifyclick(res) {
    document.getElementById('dppubcent').disabled = false;
    var ds=res.value;
		
    var newstr;
glo_cat2=0;
glo_cat3=0;
    if(ds.Tables[0].Rows.length !=0)
    {
        alert("This Category4 Name has already been assigned !! ");

        document.getElementById('txtadcatname').value="";
         document.getElementById('txtalias').value="";
        document.getElementById('txtadcatname').focus();


        return false;
    }
    updatecat4();    
}
		
function updatecat4()
{

                var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=trim(document.getElementById('txtadcatcode').value);
			var catname=trim(document.getElementById('txtadcatname').value);
		    catname=trim(catname);
			var catalias=trim(document.getElementById('txtalias').value.toUpperCase());
			var userid=document.getElementById('hiddenuserid').value;
			var ip2 = document.getElementById('ip1').value;
			var ppubcenter = document.getElementById('dppubcent').value;
			var sapcode = "";
			AdCat4.catmodify(compcode, subcatname, catname, catcode, catalias, userid, ip2, ppubcenter, sapcode);
		     dscatexecute.Tables[0].Rows[z].Comp_Code=document.getElementById('hiddencomcode').value;
              dscatexecute.Tables[0].Rows[z].Cat_Code=document.getElementById('txtadcatcode').value;
			dscatexecute.Tables[0].Rows[z].Cat_Name=document.getElementById('txtadcatname').value;
			dscatexecute.Tables[0].Rows[z].Cat_Alias=document.getElementById('txtalias').value;
			dscatexecute.Tables[0].Rows[z].Sub_Cat_Name=document.getElementById('drpadvcatcode').value;
			dscatexecute.Tables[0].Rows[z].userId = document.getElementById('hiddencomcode').value;
			dscatexecute.Tables[0].Rows[z].ppubcenter = document.getElementById('dppubcent').value;

			alert("Data Updated Successfully");

			document.getElementById('drpadvcatcode').disabled=true;
            document.getElementById('txtadcatname').disabled=true;
            document.getElementById('txtadcatcode').disabled=true;
            document.getElementById('txtalias').disabled=true;
			document.getElementById('drpadcategory').disabled=true;
			document.getElementById('drpadsubcategory').disabled = true;
			document.getElementById('dppubcent').disabled = true;

			
			//document.getElementById('btnSave').disabled=true;
			
		    
			updateStatus();
			mod="0";
			if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dscatexecute.Tables[0].Rows.length-1))
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              } 
              setButtonImages();
              if(document.getElementById('btnModify').disabled==false)      
	          document.getElementById('btnModify').focus();
			return false;
}
function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This Category3 Code  Is Already Exist, Try Another Code !!!!");
			
			 document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value=""
			
			
			return false;
			} 
			else if(ds.Tables.length>1 && ds.Tables[1].Rows.length > 0)
			{
			alert("This  Category3 Nmae  Is Already Exist, Try Another Code !!!!");
			
		     document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value=""
			
			return false;
			} 
			else
			{
			var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcatcode').value;
			var catname=document.getElementById('txtadcatname').value;
		    var catalias=document.getElementById('txtalias').value;
			var userid=document.getElementById('hiddenuserid').value;
			var ip2 = document.getElementById('ip1').value;
			var ppubcenter = document.getElementById('dppubcent').value;
			var sapcode = "";
			AdCat4.savecat4(compcode, subcatname, catname, catalias, catcode, userid, ppubcenter, ip2, sapcode);

				alert("Data Saved Successfully");


				document.getElementById('drpadcategory').value = 0;
				document.getElementById('dppubcent').value = 0;

			//document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value="";
						
//			document.getElementById('drpadvcatcode').value=true;
//            document.getElementById('txtadcat3name').value=true;
//            document.getElementById('txtadcat3code').value=true;
//            document.getElementById('txtalias').value=true;
								
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
			}
			catcancelclick('AdCat4');
			return false;
}
/*********************************************Auto Generate***********************/
function autoornot()
{
document.getElementById('txtadcatname').value=document.getElementById('txtadcatname').value.toUpperCase();
 //if(hiddentext=="new")
   // {
          if(document.getElementById('hiddenauto').value==1)
            {
            changeoccured();
            //return false;
            }
        else
            {
            userdefine();

            //return false;
            }
    //}

}

// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new")
//{

  //if(document.getElementById('hiddenauto').value==1)
			{
	
            uppercase3();
           
           }
            else
            {
            document.getElementById('txtadcatname').value=document.getElementById('txtadcatname').value.toUpperCase();
            }
            //document.getElementById('btnSave').disabled=true;
            //document.getElementById('btnModify').disabled=true;
            //AdCat4.catdauto(fillcall);
               return false;
//}
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		document.getElementById('txtadcatname').value=trim(document.getElementById('txtadcatname').value);
		lstr=document.getElementById('txtadcatname').value;
		  cstr=lstr.substring(0,1);
            var mstr="";
            			   if(lstr.indexOf(" ")==1)
			            {
			            var leng=lstr.length;
			           mstr= cstr + lstr.substring(2,leng);
			            }
			            else
			            {
			             var leng=lstr.length;
			            mstr=cstr + lstr.substring(1,leng);
			            }
		
		    if(document.getElementById('txtadcatname').value!="")
                {

		document.getElementById('txtadcatname').value=document.getElementById('txtadcatname').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtadcatname').value;
		// str=document.getElementById('txtzonename').value;
		str=mstr;
		var cat3code=document.getElementById('drpadvcatcode').value;
		AdCat4.catdauto(str,cat3code,fillcall);
		return false;
                }
		       
               
 return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		var newstr;
		 if(ds.Tables[0].Rows.length !=0)
		{
		    alert("This Category4 Name has already been assigned !! ");
		    
		         document.getElementById('txtadcatcode').value="";
				document.getElementById('txtadcatname').value="";	
				document.getElementById('txtalias').value="";
			document.getElementById('txtadcatname').focus();
		  
    		
		    return false;
		 }
		 else
		 {
//		        if(hiddentext=="new" )
//		        {
		            if(ds.Tables[1].Rows.length==0)
		            {
		                newstr=null;
		            }
		            else
		            {
		               newstr=ds.Tables[1].Rows[0].Cat_Code;
		             }
		            if(newstr==0)
		              {
		                             str=str.toUpperCase();
		                            document.getElementById('txtadcatcode').value=str.substr(0,2)+ "1";
		                            //newstr=document.getElementById('txtadcatcode').value;
		               }
		             else if(newstr>=1)
		             {
		                 
		                   var Autoincrement=parseInt(ds.Tables[1].Rows[0].Cat_Code)+1;
		                   str=str.toUpperCase();
		                   document.getElementById('txtadcatcode').value=str.substr(0,2)+ Autoincrement;
		             }
		             else if(newstr !=null )
		             {
		                  document.getElementById('txtadcatname').value=trim(document.getElementById('txtadcatname').value);
		                   var code=newstr.substr(2,4);
		                   var code=newstr;
		                    code++;
		                    str=str.toUpperCase();
		                   document.getElementById('txtadcatcode').value=str.substr(0,2)+ code;
		               // document.getElementById('txtbillid').value=str.substr(1,3)+ code;
		               }
		               else
		               {
		              
		                    str=str.toUpperCase();
		                    document.getElementById('txtadcatcode').value=str.substr(0,2)+ "0";
		                            //document.getElementById('txtbillid').value=str.substr(0,2)+ "00";
		               }
		         //}
		     }
	return false;
		}
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtadcatcode').disabled=false;
        document.getElementById('txtadcatname').value=document.getElementById('txtadcatname').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtadcatname').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
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
function check()
{
    document.getElementById('txtadcatname').value=trim(document.getElementById('txtadcatname').value);
 }

//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function catmodifyclick()
{
glo_cat2=0;
glo_cat3=0;
            document.getElementById('drpadcategory').disabled=true;
            document.getElementById('drpadsubcategory').disabled=true;

			document.getElementById('drpadvcatcode').disabled=true;
            document.getElementById('txtadcatname').disabled=false;
            document.getElementById('txtadcatcode').disabled=true;
            document.getElementById('txtalias').disabled = false;
            document.getElementById('dppubcent').disabled = false;
					
				
				chkstatus(FlagStatus);
				
				document.getElementById('btnSave').disabled = false;
				//document.getElementById('btnModify').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
				name_modify=document.getElementById('txtadcatname').value;
				
				document.getElementById('btnSave').focus();	
			
				   mod="1";
				   hiddentext = "mod";	
				 
				setButtonImages();
				return false;
}
//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//

function catqueryclick()
{
            document.getElementById('drpadcategory').value=0;
            document.getElementById('drpadsubcategory').value=0;
			document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value = "";
            document.getElementById('dppubcent').value = "0";
				z=0;
				document.getElementById('drpadcategory').disabled=false;
document.getElementById('drpadsubcategory').disabled=false;

				document.getElementById('drpadvcatcode').disabled=false;
				document.getElementById('txtadcatname').disabled=false;
				document.getElementById('txtadcatcode').disabled=false;
				document.getElementById('txtalias').disabled = false;
				document.getElementById('dppubcent').disabled = false; 
				chkstatus(FlagStatus);
	//document.getElementById('btnNew').disabled=true;				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
				hiddentext="query";
		setButtonImages();		
	document.getElementById('btnExecute').focus();									
				
				return false;
}

//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//

function catexecuteclick()
{
 var msg=checkSession();
        if(msg==false)
        return false;
            glo_cat3=0;
            glo_cat2=0;
            z=0;
           // var cat1=document.getElementById('drpadcategory').value;
         //   fillAdCat1(cat1);
			var compcode=document.getElementById('hiddencomcode').value;
			var subcatname=document.getElementById('drpadvcatcode').value;
		//	var subcatname=document.getElementById('drpadsubcategory').value;
			glaobalsubcatname=subcatname;
			var catcode=document.getElementById('txtadcatcode').value;
			glaobalcatcode=catcode;
			var catname=document.getElementById('txtadcatname').value;
			glaobalcatname=catname;
			var catalias=document.getElementById('txtalias').value;
			glaobalcatalias=catalias;
			var userid = document.getElementById('hiddenuserid').value;
			var ppubcenter = document.getElementById('dppubcent').value;
						

			//BillStatus.billexecute1(companycode,zonecode,zonename,alias,UserId,checkcall);	
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
       var sapcode = "";
       var exe_ds =  AdCat4.catexecute1(compcode, subcatname, catname, catcode, catalias, userid);

       checkcall(exe_ds);
				
			updateStatus();
			document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcatcode').disabled=true;
			document.getElementById('txtadcatname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('drpadcategory').disabled=true;
			document.getElementById('drpadsubcategory').disabled = true;
			document.getElementById('dppubcent').disabled = true;

			mod="0";
			            document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;
			if(document.getElementById('btnModify').disabled==false)
			    document.getElementById('btnModify').focus();
			//checkcall(response);
return false;

}

//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function checkcall(response)
{
			var ds=response.value;
			dscatexecute=response.value;
			if(dscatexecute.Tables[0].Rows.length > 0)
			{
			   //document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].Sub_Cat_Name;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[0].CAT_CODE;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[0].CAT_NAME;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[0].CAT_ALIAS;
				if (dscatexecute.Tables[0].Rows[0].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[0].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";
					
				document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcatcode').disabled=true;
			document.getElementById('txtadcatname').disabled=true;
			document.getElementById('txtalias').disabled=true;
						document.getElementById('drpadcategory').disabled=true;
						document.getElementById('drpadsubcategory').disabled = true;
						document.getElementById('dppubcent').disabled = true;
						
glo_cat3=dscatexecute.Tables[0].Rows[0].SUB_CAT_NAME;
                fillAllCategory(dscatexecute.Tables[0].Rows[0].CAT_CODE);
			}
			
			else
			{
				alert("Your Search Produce No Result!!!!");
			catcancelclick('AdCat4');
			}
			

            if(dscatexecute.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			   document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			   document.getElementById('btnlast').disabled=true;
		}
		
			setButtonImages();
			return false;
}
//*******************************************************************************//
//*************************This Function For First Button************************//
//********************************************************//

//function catfirstclick()
//{

//			AdCat4.catfpnl(firstcall);
//						
//			document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcatcode').disabled=true;
//			document.getElementById('txtadcatname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
//			
//			document.getElementById('btnprevious').disabled=true;	
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnnext').disabled=false;
//			
//			document.getElementById('btnNew').disabled=true;
//			document.getElementById('btnSave').disabled=true;
//			document.getElementById('btnModify').disabled=false;
//			document.getElementById('btnDelete').disabled=false;
//			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnExecute').disabled=true;
//			document.getElementById('btnCancel').disabled=false;		
//			document.getElementById('btnfirst').disabled=true;				
//			document.getElementById('btnnext').disabled=false;					
//			document.getElementById('btnprevious').disabled=true;			
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnExit').disabled=false;
//			
//			return false;
//}

//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//	
function firstcall()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	document.getElementById("drpadvcatcode").options.length = 1; 
    document.getElementById("drpadvcatcode").options[0]=new Option("--Select Ad Category3--","0");
    
    	document.getElementById("drpadsubcategory").options.length = 1;
    	document.getElementById("drpadsubcategory").options[0] = new Option("--Select Ad Category2--", "0");

//    	document.getElementById("dppubcent").options.length = 1;
//    	document.getElementById("dppubcent").options[0] = new Option("--Select Pub Center--", "0");
//    
  document.getElementById('drpadcategory').value=0;
    document.getElementById('drpadsubcategory').value=0;
    document.getElementById('drpadvcatcode').value = 0;
    document.getElementById('dppubcent').value = 0;
			//var dszoneexecute=response.value;
	
			    document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].SUB_CAT_NAME;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[0].CAT_CODE;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[0].CAT_NAME;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[0].CAT_ALIAS;
				document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].CAT_PUBCENTER;

				if (dscatexecute.Tables[0].Rows[z].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";
			z=0;
			updateStatus();
        glo_cat3=dscatexecute.Tables[0].Rows[0].SUB_CAT_NAME;
		document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
				fillAllCategory(dscatexecute.Tables[0].Rows[0].CAT_CODE);
				
		 setButtonImages();
			return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//

//function catlastclick()
//{
//			AdCat4.catfpnl(lastcall);

//			 document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcatcode').disabled=true;
//			document.getElementById('txtadcatname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
//						
//			return false;
//}

//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
function lastcall()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	document.getElementById("drpadvcatcode").options.length = 1; 
    document.getElementById("drpadvcatcode").options[0]=new Option("--Select Ad Category3--","0");
    
    	document.getElementById("drpadsubcategory").options.length = 1;
    	document.getElementById("drpadsubcategory").options[0] = new Option("--Select Ad Category2--", "0");

//    	document.getElementById("dppubcent").options.length = 1;
//    	document.getElementById("dppubcent").options[0] = new Option("--Select Pub Center--", "0");
//    
  document.getElementById('drpadcategory').value=0;
    document.getElementById('drpadsubcategory').value=0;
    document.getElementById('drpadvcatcode').value = 0;
    document.getElementById('dppubcent').value = 0;
			//var dszoneexecute=response.value;
			var y=dscatexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			    document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].SUB_CAT_NAME;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[z].CAT_CODE;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[z].CAT_NAME;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[z].CAT_ALIAS;
				document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].CAT_PUBCENTER;

				if (dscatexecute.Tables[0].Rows[z].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";
				 glo_cat3=dscatexecute.Tables[0].Rows[z].SUB_CAT_NAME;
			updateStatus();
			
		        document.getElementById('btnnext').disabled=true;
		        document.getElementById('btnlast').disabled=true;
		        document.getElementById('btnfirst').disabled=false;
		        document.getElementById('btnprevious').disabled=false;
		        fillAllCategory(dscatexecute.Tables[0].Rows[z].CAT_CODE);
		        
				
		         setButtonImages();
			return false;
}


//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//


//function catpreviousclick()
//{			
//			AdCat4.catfpnl(previouscall);

//			    document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcatcode').disabled=true;
//			document.getElementById('txtadcatname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
//			return false;
//}

//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
function previouscall()
{
 var msg=checkSession();
        if(msg==false)
        return false;
		//var dszoneexecute=response.value;
			document.getElementById("drpadvcatcode").options.length = 1; 
    document.getElementById("drpadvcatcode").options[0]=new Option("--Select Ad Category3--","0");
    
    	document.getElementById("drpadsubcategory").options.length = 1; 
    document.getElementById("drpadsubcategory").options[0]=new Option("--Select Ad Category2--","0");

//    document.getElementById("dppubcent").options.length = 1;
//    document.getElementById("dppubcent").options[0] = new Option("--Select Pub Center--", "0");
    
  document.getElementById('drpadcategory').value=0;
    document.getElementById('drpadsubcategory').value=0;
    document.getElementById('drpadvcatcode').value = 0;
    document.getElementById('dppubcent').value = 0;
		
		var a=dscatexecute.Tables[0].Rows.length;
		z--;
		if(z>a)
			{
			    document.getElementById('btnfirst').disabled = false;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=true;
						return false;
			}
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
				 document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].SUB_CAT_NAME;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[z].CAT_CODE;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[z].CAT_NAME;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[z].CAT_ALIAS;
				document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].CAT_PUBCENTER;

				if (dscatexecute.Tables[0].Rows[z].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";
				
				 glo_cat3=dscatexecute.Tables[0].Rows[z].SUB_CAT_NAME;
			    updateStatus();
				document.getElementById('btnfirst').disabled=false;
				document.getElementById('btnnext').disabled = false;
		        document.getElementById('btnprevious').disabled = false;			
		        document.getElementById('btnlast').disabled=false;			
		        document.getElementById('btnExit').disabled=false;
				 fillAllCategory(dscatexecute.Tables[0].Rows[z].CAT_CODE);
			}
			else
			{
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				return false;
			}
		}
		else
		{		document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				return false;
		}
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled = true;

			
			
}
setButtonImages();
		return false;
}
		
//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//

//function catnextclick()
//{
//		AdCat4.catfpnl(nextcall);

//		        
//			    document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcatcode').disabled=true;
//			document.getElementById('txtadcatname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
//		
//		return false;
//}


//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function catnextclick()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	//var dszoneexecute=response.value;
	//dscatexecute=response.value;
	
		document.getElementById("drpadvcatcode").options.length = 1; 
    document.getElementById("drpadvcatcode").options[0]=new Option("--Select Ad Category3--","0");
    
    	document.getElementById("drpadsubcategory").options.length = 1;
    	document.getElementById("drpadsubcategory").options[0] = new Option("--Select Ad Category2--", "0");

//    	document.getElementById("dppubcent").options.length = 1;
//    	document.getElementById("dppubcent").options[0] = new Option("--Select Pub Center--", "0");
//    
  document.getElementById('drpadcategory').value=0;
    document.getElementById('drpadsubcategory').value=0;
    document.getElementById('drpadvcatcode').value = 0;
    
   
	
	var a=dscatexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
			 document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].SUB_CAT_NAME;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[z].CAT_CODE;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[z].CAT_NAME;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[z].CAT_ALIAS;
				document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].PUBCENTER;


				if (dscatexecute.Tables[0].Rows[z].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";
	
	
			 glo_cat3=dscatexecute.Tables[0].Rows[z].SUB_CAT_NAME;
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			 fillAllCategory(dscatexecute.Tables[0].Rows[z].CAT_CODE);
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
	if (z == a - 1) {
	    document.getElementById('btnnext').disabled = true;
	    document.getElementById('btnlast').disabled = true;
	    document.getElementById('btnfirst').disabled = false;
	    document.getElementById('btnprevious').disabled = false;
	}

setButtonImages();

	
	return false;

}


function catexitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}
//*******************************************************************************//
//*************************This Function For Delete Button***********************//
//*******************************************************************************//
function catdeleteclick()
{
 var msg=checkSession();
        if(msg==false)
        return false;

        updateStatus();
		   var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcatcode').value;
			var catname=document.getElementById('txtadcatname').value;
		    var alias=document.getElementById('txtalias').value;
			var userid=document.getElementById('hiddenuserid').value;		
		boolReturn = confirm("Are you sure you wish to delete this?");
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
		if(boolReturn==1)
		{
		var ip2=document.getElementById('ip1').value;
		AdCat4.catdelete(catcode,ip2);

		alert ("Data Deleted Successfully");
		
		document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value = "";
            document.getElementById('dppubcent').value = 0;

		
		
//AdCat4.catdelete(catcode);
            var ds_exe = AdCat4.catexecute1(compcode, glaobalsubcatname, glaobalcatname, glaobalcatcode, glaobalcatalias, userid);
            delcall(ds_exe);

		//BgColor.bgexecute2(glaobalbgid,glaobalbgname,glaobalbgalias,delcall);
		//catnextclicktest();
		
		}     
//	else
//	{
//	return false;
//	}
	return false;
}
//*******************************************************************************//
//*******************This Is The Responce Of The delete Button*******************//
//*******************************************************************************//

function delcall(res)
{
	 dscatexecute= res.value;
	len=dscatexecute.Tables[0].Rows.length;
	
	if(dscatexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value="";
		catcancelclick('AdCat4');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		        document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].SUB_CAT_NAME;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[0].CAT_CODE;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[0].CAT_NAME;
				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[0].CAT_ALIAS;
				glo_cat3=dscatexecute.Tables[0].Rows[0].SUB_CAT_NAME;
                fillAllCategory(dscatexecute.Tables[0].Rows[0].CAT_CODE);
			
	}
	else
	{
		       document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].SUB_CAT_NAME;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[z].CAT_CODE;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[z].CAT_NAME;
				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[z].CAT_ALIAS;
				glo_cat3=dscatexecute.Tables[0].Rows[0].SUB_CAT_NAME;
                fillAllCategory(dscatexecute.Tables[0].Rows[0].CAT_CODE);
			
	}
	
		if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dscatexecute.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       

	setButtonImages();
return false;
}

//*******************************************************************************//
//*********************This For The Do The laters in capital laters**************//
//*******************************************************************************//	
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

//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//


function catcancelclick(formname)
{
	        chkstatus(FlagStatus);
	        givebuttonpermission(formname);
	        document.getElementById("drpadvcatcode").options.length = 1; 
            document.getElementById("drpadvcatcode").options[0]=new Option("--Select Ad Category3--","0");
            
            document.getElementById("drpadsubcategory").options.length = 1;
            document.getElementById("drpadsubcategory").options[0] = new Option("--Select Ad Category2--", "0");

//            document.getElementById("dppubcent").options.length = 1;
//            document.getElementById("dppubcent").options[0] = new Option("--Select Pub Center--", "0");
//            
            document.getElementById('drpadcategory').value=0;
            document.getElementById('drpadsubcategory').value=0;
            document.getElementById('drpadvcatcode').value = 0;
//            document.getElementById('dppubcent').value = 0;
			

            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value = "";
            document.getElementById('dppubcent').value = 0;
				
			document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcatcode').disabled=true;
			document.getElementById('txtadcatname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('drpadcategory').disabled=true;
			document.getElementById('drpadsubcategory').disabled = true;
			document.getElementById('dppubcent').disabled = true;		
				
				
			/*document.getElementById('btnModify').disabled=true;
		    document.getElementById('btnQuery').disabled=false;
		    document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnSave').disabled=true;*/
			if(document.getElementById('btnNew').disable==false)
				  document.getElementById('btnNew').focus();	
				
			//getPermission(formname);
				mod="0";
						
					/*if(document.getElementById('btnNew').disabled==false)
					{
					   
						document.getElementById('btnNew').focus();
					}
						
					else
					{
						document.getElementById('btnNew').disabled=false;
						document.getElementById('btnNew').focus();
						
					}
					*/
			
				setButtonImages();
				return false;
}

function catnextclicktest()
{
		AdCat4.catfpnl(nextcalltest);

		        document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcatcode').disabled=true;
			document.getElementById('txtadcatname').disabled=true;
			document.getElementById('txtalias').disabled = true;
			document.getElementById('dppubcent').disabled = true;
		
		return false;
}


//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function nextcalltest(response)
{
	//var dszoneexecute=response.value;
	var a=dscatexecute.Tables[0].Rows.length;
	znk++;
	if(znk !=-1 && znk >= 0)
	{
		if(znk <= a-1)
		{
			
	       document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[znk].SUB_CAT_NAME;
		 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[znk].CAT_CODE;
			document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[znk].CAT_NAME;
			document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[znk].CAT_ALIAS;
			document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[znk].CAT_ALIAS;
			
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
			
			document.getElementById('btnDelete').disabled=false
	}
	}
	else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		
			document.getElementById('btnDelete').disabled=false
	}
	if(znk==a-1)
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
	}
	return false;
}


function fillAllCategory(subcat3)
{
    fillAdCat1(subcat3);
    
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


function clearadcat4() {
    catcancelclick('AdCat4');
    givebuttonpermission('AdCat4');
}