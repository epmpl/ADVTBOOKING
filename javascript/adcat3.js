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
var glaobalxml;
var glo_cat2=0;
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


function fillAdCat1()
{
    if (glo_cat2 == null)
    {
        glo_cat2 = 0;
    }
Adsubcat3.fillCat1(glo_cat2,fillCat1_callback);
    
}

function fillAdCat99()
{
    if (document.getElementById('drpadcategory').value != null || document.getElementById('drpadcategory').value !="0")
    {
        Adsubcat3.fillCat2(document.getElementById('drpadcategory').value, document.getElementById('drpstatewise').value, fillCat2_callback);
    }
}


function fillCat1_callback(response)
{
 var ds=response.value;
 if(ds!=null)
 {
 if(ds.Tables[0].Rows.length>0)
 {
   document.getElementById('drpadcategory').value=ds.Tables[0].Rows[0].adv_cat_code;
   fillAdCat2();
   
   }
   }
}
function fillAdCat2()
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
       Adsubcat3.fillCat2(document.getElementById('drpadcategory').value, document.getElementById('drpstatewise').value, fillCat2_callback);
    
}
function fillCat2_callback(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("drpadvcatcode");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Sub Category--","0");
    
   

   // fillAdCat1();    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
        
       pkgitem.options.length;   
    }
    document.getElementById("drpadvcatcode").value=glo_cat2;
    glo_cat2=0;
    
    return false;
}
function catnewclick()
{
  var msg=checkSession();
        if(msg==false)
        return false;
 document.getElementById('drpadvcatcode').options.length=0;
            document.getElementById('drpadvcatcode').value=0;
            document.getElementById('drpadcategory').value = 0;
            document.getElementById('dppubcent').value = 0;
          
            
            
            document.getElementById('txtadcat3name').value="";
            document.getElementById('txtadcat3code').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtxml').value="";
            document.getElementById('txtpriority').value ="";
            document.getElementById('txtsapcode').value = "";
           
           
            
            document.getElementById('drpstatus').value=1 ;
            
           if(document.getElementById('hiddenauto').value==1)
                {
                   document.getElementById('txtadcat3code').disabled=true;
                   
                }
           else
              {
                document.getElementById('txtadcat3code').disabled=false;
               }
              document.getElementById('txtadcat3name').disabled=false;
              document.getElementById('txtalias').disabled=false;
              document.getElementById('drpadvcatcode').disabled=false;
                document.getElementById('drpadcategory').disabled=false;
                document.getElementById('txtpriority').disabled=false;
                document.getElementById('txtxml').disabled = false;
                document.getElementById('dppubcent').disabled = false;
                document.getElementById('txtsapcode').disabled = false;
                                            
                                          
              
              document.getElementById('drpstatus').disabled=false;
              
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
 document.getElementById('txtadcat3code').value=trim(document.getElementById('txtadcat3code').value);
 document.getElementById('txtadcat3name').value=trim(document.getElementById('txtadcat3name').value);
 document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
 document.getElementById('drpadvcatcode').value=trim(document.getElementById('drpadvcatcode').value);
 document.getElementById('drpstatus').value=trim(document.getElementById('drpstatus').value);
 document.getElementById('txtxml').value=trim(document.getElementById('txtxml').value);
 document.getElementById('txtpriority').value = trim(document.getElementById('txtpriority').value);
 document.getElementById('dppubcent').value = trim(document.getElementById('dppubcent').value);
 document.getElementById('txtsapcode').value = trim(document.getElementById('txtsapcode').value);
 document.getElementById('drpstatewise').value = trim(document.getElementById('drpstatewise').value);  

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
              
		if(document.getElementById('drpadvcatcode').value=="0" || document.getElementById('drpadvcatcode').value=="" )
              {
              alert("Please Select Ad Sub Category Name");
              document.getElementById('drpadvcatcode').focus();
              return false;
              }
  
			 if((document.getElementById('txtadcat3code').value=="")&&(document.getElementById('hiddenauto').value!=1))
              {
                           
			 //if(document.getElementById('txtadcat3code').value=="")
			//{
			alert("Please Enter the Sub Category3 Code ");
			document.getElementById('txtadcat3code').focus();
			return false;
			}
			//return false;
			//}
					
			else if(document.getElementById('txtadcat3name').value=="")
			{
			alert("Please Enter the Sub Category3 Name ");
			document.getElementById('txtadcat3name').focus();
			return false;
			}
			else if(document.getElementById('txtalias').value=="")
			{
			alert("Please Enter the Alias");
			document.getElementById('txtalias').focus();
			return false;
			}
            var subcatname=document.getElementById('drpadvcatcode').value;
            var statusac=document.getElementById('drpstatus').value;
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=trim(document.getElementById('txtadcat3code').value);
			var catname=trim(document.getElementById('txtadcat3name').value);
		    catname=trim(catname);
			var catalias=trim(document.getElementById('txtalias').value);
			var xml=trim(document.getElementById('txtxml').value);
			var userid = document.getElementById('hiddenuserid').value;
			var sapcode = document.getElementById('txtsapcode').value;
			var statecode = document.getElementById('drpstatewise').value; 			
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
			if(mod !="1" && mod !=null)
			{
			
			
Adsubcat3.chkcatcod(catcode,subcatname,catname,statecode,call_saveclick);
			}
			else
			{
			    if(name_modify==document.getElementById('txtadcat3name').value)
			    {
			        updatecat3();
			    }
			    else
			    {
			        var str=document.getElementById('txtadcat3name').value;
			        Adsubcat3.chkcatname(str,subcatname,modifyclick);
			    }
			}
			return false;
}

function modifyclick(res) {

    document.getElementById('dppubcent').disabled = false;



    var ds=res.value;
		
    var newstr;

    if(ds.Tables[0].Rows.length !=0)
    {
        alert("This Category3 Name has already been assigned !! ");

        document.getElementById('txtadcat3name').value="";
        document.getElementById('txtadcat3name').focus();


        return false;
    }
    updatecat3();    
}
	
function updatecat3()
{
            var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=trim(document.getElementById('txtadcat3code').value);
			var catname=trim(document.getElementById('txtadcat3name').value);
		    catname=trim(catname);
			var catalias=trim(document.getElementById('txtalias').value);
			var xml=trim(document.getElementById('txtxml').value);
			var userid=document.getElementById('hiddenuserid').value;
			var ip2=document.getElementById('ip1').value;
			var priority=document.getElementById('txtpriority').value;
			var statusai = document.getElementById('drpstatus').value;
			var ppubcenter = document.getElementById('dppubcent').value;
			var sapcode = document.getElementById('txtsapcode').value;
			var statecode = document.getElementById('drpstatewise').value;
			var pub = document.getElementById('dppubcent').value;
			Adsubcat3.cat3modify(compcode, subcatname, catname, catalias, catcode, userid, xml, ip2, priority, statusai, ppubcenter, sapcode, statecode, pub);
              dscatexecute.Tables[0].Rows[z].catcode=document.getElementById('txtadcat3code').value;
			dscatexecute.Tables[0].Rows[z].catname=document.getElementById('txtadcat3name').value;
			dscatexecute.Tables[0].Rows[z].catalias=document.getElementById('txtalias').value;
			dscatexecute.Tables[0].Rows[z].subcatname=document.getElementById('drpadvcatcode').value;
             dscatexecute.Tables[0].Rows[z].adminwebxml=document.getElementById('txtxml').value;
             dscatexecute.Tables[0].Rows[z].PRIORITY = document.getElementById('txtpriority').value;
             dscatexecute.Tables[0].Rows[z].ppubcenter = document.getElementById('dppubcent').value;
             dscatexecute.Tables[0].Rows[z].sapcode = document.getElementById('txtsapcode').value;
             alert("Data Updated Successfully");
             document.getElementById('drpadvcatcode').value = 0;
             document.getElementById('drpadcategory').value = "0";
             document.getElementById('txtadcat3name').value = "";
             document.getElementById('txtadcat3code').value = "";
             document.getElementById('txtalias').value = "";
             document.getElementById('txtxml').value = "";
             document.getElementById('dppubcent').value = "0";
             document.getElementById('txtsapcode').value = "";
             document.getElementById('txtpriority').value = "";
			updateStatus();
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

			document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('drpadcategory').disabled=true;
            document.getElementById('txtadcat3name').disabled=true;
            document.getElementById('txtadcat3code').disabled=true;
            document.getElementById('txtalias').disabled=true;
			document.getElementById('txtxml').disabled=true;
			document.getElementById('txtpriority').disabled = true;
			document.getElementById('drpstatus').disabled = true;
			document.getElementById('dppubcent').disabled = true;
			document.getElementById('txtsapcode').disabled = true;		
			
			//document.getElementById('btnSave').disabled=true;
			setButtonImages()
			 if(document.getElementById('btnModify').disabled==false)      
	          document.getElementById('btnModify').focus();
		    
			
			mod="0";
			glo_cat2=0;
			return false;
}
function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This Sub Category3 Cod  Is Already Exist, Try Another Code !!!!");
			
			 document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcat3name').value="";
            document.getElementById('txtadcat3code').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtxml').value = "";
            document.getElementById('txtsapcode').value = "";
			document.getElementById('txtadcat3name').focus();
			
			return false;
			} 
			else if(ds.Tables.length>1 && ds.Tables[1].Rows.length > 0)
			{
			alert("This Sub Category3 Nmae  Is Already Exist, Try Another Code !!!!");			
			document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcat3name').value="";
            document.getElementById('txtadcat3code').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtxml').value = "";
            document.getElementById('txtsapcode').value = "";
			document.getElementById('txtadcat3name').focus();
			
			return false;
			} 
			else
			{
			var subcatname=document.getElementById('drpadvcatcode').value;
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcat3code').value;
			var catname=document.getElementById('txtadcat3name').value;
		    var catalias=document.getElementById('txtalias').value;
		    var statusai=document.getElementById('drpstatus').value;
		    var xml=document.getElementById('txtxml').value;
			var userid=document.getElementById('hiddenuserid').value;
			var ip2=document.getElementById('ip1').value;
			var priority = document.getElementById('txtpriority').value;
			var ppubcenter = document.getElementById('dppubcent').value;
			var sapcode = document.getElementById('txtsapcode').value;
			var statecode = document.getElementById('drpstatewise').value;
			var pub = document.getElementById('dppubcent').value;
			Adsubcat3.savecat3(compcode, subcatname, catname, catalias, catcode, userid, xml, ip2, priority, statusai, ppubcenter, sapcode, statecode, pub);		

			alert("Data Saved Successfully");
	        document.getElementById('drpadcategory').value=0;
			document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcat3name').value="";
            document.getElementById('txtadcat3code').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtxml').value="";
            document.getElementById('txtpriority').value = "";
            document.getElementById('dppubcent').value = 0;
            document.getElementById('txtsapcode').value = "";
						
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
			catcancelclick('Adsubcat3');
			return false;
}
/*********************************************Auto Generate***********************/
function autoornot()
 {
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
   // return false;
    }
else
    {
    userdefine();

    //return false;
    }
//return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )

  //if(document.getElementById('hiddenauto').value==1)
	{

	    //uppercase3();
	    document.getElementById('txtadcat3name').value = trim(document.getElementById('txtadcat3name').value.toUpperCase());
	   // document.getElementById('txtadcat3name').value = trim(document.getElementById('txtadcat3name').value.value.toUpperCase());
		lstr=document.getElementById('txtadcat3name').value;
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
		
		    if(document.getElementById('txtadcat3name').value!="")
                {

		document.getElementById('txtadcat3name').value=document.getElementById('txtadcat3name').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtadcat3name').value;
	    var subcatname = document.getElementById('drpadvcatcode').value;
	    var statecode = document.getElementById('drpstatewise').value;
		// str=document.getElementById('txtzonename').value;
		str=mstr;
		var res = Adsubcat3.catdauto(str, subcatname, statecode, fillcall);
	//	return false;
                }
     
        }
      else
            {
            document.getElementById('txtadcat3name').value=document.getElementById('txtadcat3name').value.toUpperCase();
            }
            //document.getElementById('btnSave').disabled=true;
            //document.getElementById('btnModify').disabled=true;
           // BgColor.bgdauto(fillcall);
               return false;

}


//auto generated
//this is used for increment in code

/*function uppercase3()
		{
		document.getElementById('txtadcat3name').value=trim(document.getElementById('txtadcat3name').value);
		lstr=document.getElementById('txtadcat3name').value;
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
		
		    if(document.getElementById('txtadcat3name').value!="")
                {

		document.getElementById('txtadcat3name').value=document.getElementById('txtadcat3name').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtadcat3name').value;
		// str=document.getElementById('txtzonename').value;
		str=mstr;
		Adsubcat3.catdauto(str,fillcall);
		return false;
                }
		       
               
 return false;
		
}*/

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length !=0)
		    {
		    alert("This Category3 Name has already been assigned !! ");
		    
		         document.getElementById('txtadcat3code').value="";
				document.getElementById('txtadcat3name').value="";	
				document.getElementById('txtalias').value="";
			document.getElementById('txtadcat3name').focus();
		  
    		
		  //  return false;
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
		                         newstr=ds.Tables[1].Rows[0].catcode;
		                        }
		                        if(newstr==0)
		                        {
		                            str=str.toUpperCase();
		                            document.getElementById('txtadcat3code').value=str.substr(0,2)+ "1";
		                        }
		                        else if(newstr>=1)
		                        {
		                           var Autoincrement=parseInt(ds.Tables[1].Rows[0].catcode)+1;
		                            str=str.toUpperCase();
		                            document.getElementById('txtadcat3code').value=str.substr(0,2)+ Autoincrement;
		                        }
		                        
		                    else if(newstr !=null )
		                        {
		                        document.getElementById('txtadcat3name').value=trim(document.getElementById('txtadcat3name').value);
		                        var code=newstr.substr(2,4);
		                       var code=newstr;
		                       str=str.toUpperCase();
		                        code++;
		                        document.getElementById('txtadcat3code').value=str.substr(0,2)+ code;
		                        return false;
		                       // document.getElementById('txtbillid').value=str.substr(1,3)+ code;
		                         }
		                         
		                    else
		                         {
		                           str=str.toUpperCase();
		                          document.getElementById('txtadcat3code').value=str.substr(0,2)+ "0";
		                          //document.getElementById('txtbillid').value=str.substr(0,2)+ "00";
		                          }
		                         // }
		     }
	//return false;
		}
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtadcat3code').disabled=false;
        document.getElementById('txtadcat3name').value=document.getElementById('txtadcat3name').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtadcat3name').value;
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
    document.getElementById('txtadcat3name').value=trim(document.getElementById('txtadcat3name').value);
 }

//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function catmodifyclick()
{
                   mod="1";
				 hiddentext="mod";	
                glo_cat2=0;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnModify').disabled=false;
				
				name_modify=document.getElementById('txtadcat3name').value;
				
                chkstatus(FlagStatus);
               
                document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
               document.getElementById('btnSave').focus();
               
			document.getElementById('drpadvcatcode').disabled=true;
			 document.getElementById('drpadcategory').disabled=true;
            document.getElementById('txtadcat3name').disabled=false;
            document.getElementById('txtadcat3code').disabled=true;
            document.getElementById('txtalias').disabled=false;
	        document.getElementById('txtxml').disabled=false;
	        document.getElementById('txtpriority').disabled=false;
	        document.getElementById('drpstatus').disabled = false;
	        document.getElementById('dppubcent').disabled = false;
	        document.getElementById('txtsapcode').disabled = false;
				setButtonImages();
				return false;
}
//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//

function catqueryclick()
{
 document.getElementById('drpadcategory').value=0;
			document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcat3name').value="";
            document.getElementById('txtadcat3code').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtxml').value="";
            document.getElementById('txtpriority').value = "";
            document.getElementById('dppubcent').value = "";
            document.getElementById('txtsapcode').value = "";
				z=0;
				document.getElementById('drpadvcatcode').disabled=false;
				 document.getElementById('drpadcategory').disabled=false;
				document.getElementById('txtadcat3name').disabled=false;
				document.getElementById('txtadcat3code').disabled=false;
				document.getElementById('txtalias').disabled=false;
				document.getElementById('txtxml').disabled = false;
				document.getElementById('txtpriority').disabled = true;
				document.getElementById('dppubcent').disabled = true;
				document.getElementById('txtsapcode').disabled = true; 
				
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

             z=0;
			var compcode=document.getElementById('hiddencomcode').value;
			var subcatname=document.getElementById('drpadvcatcode').value;
			glaobalsubcatname=subcatname;
			var catcode=document.getElementById('txtadcat3code').value;
			glaobalcatcode=catcode;
			var catname=document.getElementById('txtadcat3name').value;
			glaobalcatname=catname;
			var catalias=document.getElementById('txtalias').value;
			glaobalcatalias=catalias;
			var userid=document.getElementById('hiddenuserid').value;
			var xml=document.getElementById('txtxml').value;
			glaobalxml = xml;
			var ppubcenter = document.getElementById('dppubcent').value;
			var sapcode = document.getElementById('txtsapcode').value;
			var statecode = document.getElementById('drpstatewise').value;
			if(statecode=="0")
			{
			statecode="";
			}
			
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
Adsubcat3.catexecute1(compcode, subcatname, catname, catcode, catalias,xml,ppubcenter,statecode,checkcall);		
			updateStatus();
			document.getElementById('drpadvcatcode').disabled=true;
			 document.getElementById('drpadcategory').disabled=true;
			document.getElementById('txtadcat3code').disabled=true;
			document.getElementById('txtadcat3name').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('txtxml').disabled=true;
			document.getElementById('txtpriority').disabled=true;
			document.getElementById('drpstatus').disabled = true;
			document.getElementById('txtsapcode').disabled = true;
			mod="0";
			            document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;
						
					    if(document.getElementById('btnModify').disabled==false)
			                document.getElementById('btnModify').focus();
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
			   //document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].subcatname;
			   glo_cat2=dscatexecute.Tables[0].Rows[0].subcatname;
			 	document.getElementById('txtadcat3code').value=dscatexecute.Tables[0].Rows[0].catcode;
				document.getElementById('txtadcat3name').value=dscatexecute.Tables[0].Rows[0].catname;
				if(dscatexecute.Tables[0].Rows[0].PRIORITY != null)
				document.getElementById('txtpriority').value=dscatexecute.Tables[0].Rows[0].PRIORITY;
				else
				document.getElementById('txtpriority').value="";
				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[0].catalias;
				if(dscatexecute.Tables[0].Rows[0].adminwebxml==null || dscatexecute.Tables[0].Rows[0].adminwebxml=="")
				{
				    document.getElementById('txtxml').value="";
				}	
				else
				{
				    document.getElementById('txtxml').value=dscatexecute.Tables[0].Rows[0].adminwebxml;
				}
				
				if(dscatexecute.Tables[0].Rows[0].STATUS != null)
				document.getElementById('drpstatus').value=dscatexecute.Tables[0].Rows[0].STATUS;
				else
				    document.getElementById('drpstatus').value = "";

				if (dscatexecute.Tables[0].Rows[0].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[0].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";

				if (dscatexecute.Tables[0].Rows[0].sapcode != null)
				    document.getElementById('txtsapcode').value = dscatexecute.Tables[0].Rows[0].sapcode;
				else
				    document.getElementById('txtsapcode').value = "";



                  document.getElementById('drpstatewise').value = dscatexecute.Tables[0].Rows[0].STATECODE;   
				//document.getElementById('drpstatewise').value = dscatexecute.Tables[0].Rows[0].sapcode;
				
				document.getElementById('drpadvcatcode').disabled=true;
				 document.getElementById('drpadcategory').disabled=true;
			document.getElementById('txtadcat3code').disabled=true;
			document.getElementById('txtadcat3name').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('txtxml').disabled=true;
			document.getElementById('txtpriority').disabled = true;
			document.getElementById('txtsapcode').disabled = true;
			
			fillAdCat1();
						
			}
			
			else
			{
				alert("Your Search Produce No Result!!!!");
			catcancelclick('Adsubcat3');
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

/*function catfirstclick()
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
Adsubcat3.catfpnl(firstcall);
						
			document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcat3code').disabled=true;
			document.getElementById('txtadcat3name').disabled=true;
			document.getElementById('txtalias').disabled=true;
			
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
			
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;
			
			return false;
}*/

//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//	
function catfirstclick()
{
  var msg=checkSession();
        if(msg==false)
        return false;
			//var dszoneexecute=response.value;
			 document.getElementById('drpadvcatcode').options.length=0;
			 document.getElementById('drpadvcatcode').value=0;
              document.getElementById('drpadcategory').value=0;
	 glo_cat2=dscatexecute.Tables[0].Rows[0].subcatname;

			 //   document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].subcatname;
			 	document.getElementById('txtadcat3code').value=dscatexecute.Tables[0].Rows[0].catcode;
				document.getElementById('txtadcat3name').value=dscatexecute.Tables[0].Rows[0].catname;
				if(dscatexecute.Tables[0].Rows[0].PRIORITY != null)
				document.getElementById('txtpriority').value=dscatexecute.Tables[0].Rows[0].PRIORITY;
				else
				document.getElementById('txtpriority').value="";
				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[0].catalias;
				if(dscatexecute.Tables[0].Rows[0].adminwebxml==null || dscatexecute.Tables[0].Rows[0].adminwebxml=="")
				{
				    document.getElementById('txtxml').value="";
				}	
				else
				{
				    document.getElementById('txtxml').value=dscatexecute.Tables[0].Rows[0].adminwebxml;
				}
				
				if(dscatexecute.Tables[0].Rows[0].STATUS != null)
				document.getElementById('drpstatus').value=dscatexecute.Tables[0].Rows[0].STATUS;
				else
				    document.getElementById('drpstatus').value = "";
				if (dscatexecute.Tables[0].Rows[0].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[0].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";

				if (dscatexecute.Tables[0].Rows[0].sapcode != null)
				    document.getElementById('txtsapcode').value = dscatexecute.Tables[0].Rows[0].sapcode;
				else
				    document.getElementById('txtsapcode').value = "";
				
				
				
				
			z=0;
			updateStatus();

		document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
		fillAdCat1();
		setButtonImages();
			return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//

/*function catlastclick()
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
Adsubcat3.catfpnl(lastcall);

			 document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcat3code').disabled=true;
			document.getElementById('txtadcat3name').disabled=true;
			document.getElementById('txtalias').disabled=true;
						
			return false;
}*/

//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
function catlastclick()
{
  var msg=checkSession();
        if(msg==false)
        return false;
			//var dszoneexecute=response.value;
			 document.getElementById('drpadvcatcode').options.length=0;
			 document.getElementById('drpadvcatcode').value=0;
              document.getElementById('drpadcategory').value=0;
			var y=dscatexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			 glo_cat2=dscatexecute.Tables[0].Rows[z].subcatname;

			   //document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].subcatname;
			 	document.getElementById('txtadcat3code').value=dscatexecute.Tables[0].Rows[z].catcode;
				document.getElementById('txtadcat3name').value=dscatexecute.Tables[0].Rows[z].catname;
				if(dscatexecute.Tables[0].Rows[z].PRIORITY != null)
				document.getElementById('txtpriority').value=dscatexecute.Tables[0].Rows[z].PRIORITY;
				else
				document.getElementById('txtpriority').value="";
				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[z].catalias;
				if(dscatexecute.Tables[0].Rows[z].adminwebxml==null || dscatexecute.Tables[0].Rows[z].adminwebxml=="")
				{
				    document.getElementById('txtxml').value="";
				}	
				else
				{
				    document.getElementById('txtxml').value=dscatexecute.Tables[0].Rows[z].adminwebxml;
				}
				
				if(dscatexecute.Tables[0].Rows[z].STATUS != null)
				document.getElementById('drpstatus').value=dscatexecute.Tables[0].Rows[z].STATUS;
				else
				    document.getElementById('drpstatus').value = "";


				if (dscatexecute.Tables[0].Rows[z].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";


				if (dscatexecute.Tables[0].Rows[z].sapcode != null)
				    document.getElementById('txtsapcode').value = dscatexecute.Tables[0].Rows[z].sapcode;
				else
				    document.getElementById('txtsapcode').value = "";
				
				
				
				
				
			updateStatus();
			fillAdCat1();
		      document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
			return false;
}


//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//


/*function catpreviousclick()
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
Adsubcat3.catfpnl(previouscall);

			    document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcat3code').disabled=true;
			document.getElementById('txtadcat3name').disabled=true;
			document.getElementById('txtalias').disabled=true;
			return false;
}*/

//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
function catpreviousclick()
{
  var msg=checkSession();
        if(msg==false)
        return false;
		//var dszoneexecute=response.value;
		 document.getElementById('drpadvcatcode').options.length=0;
			 document.getElementById('drpadvcatcode').value=0;
              document.getElementById('drpadcategory').value=0;
		var a=dscatexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
			    glo_cat2=dscatexecute.Tables[0].Rows[z].subcatname;
				// document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].subcatname;
			 	document.getElementById('txtadcat3code').value=dscatexecute.Tables[0].Rows[z].catcode;
				document.getElementById('txtadcat3name').value=dscatexecute.Tables[0].Rows[z].catname;
				if(dscatexecute.Tables[0].Rows[z].PRIORITY != null)
				document.getElementById('txtpriority').value=dscatexecute.Tables[0].Rows[z].PRIORITY;
				else
				document.getElementById('txtpriority').value="";
				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[z].catalias;
				if(dscatexecute.Tables[0].Rows[z].adminwebxml==null || dscatexecute.Tables[0].Rows[z].adminwebxml=="")
				{
				    document.getElementById('txtxml').value="";
				}	
				else
				{
				    document.getElementById('txtxml').value=dscatexecute.Tables[0].Rows[z].adminwebxml;
				}
				
				if(dscatexecute.Tables[0].Rows[z].STATUS != null)
				document.getElementById('drpstatus').value=dscatexecute.Tables[0].Rows[z].STATUS;
				else
				    document.getElementById('drpstatus').value = "";


				if (dscatexecute.Tables[0].Rows[z].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";

				if (dscatexecute.Tables[0].Rows[z].sapcode != null)
				    document.getElementById('txtsapcode').value = dscatexecute.Tables[0].Rows[z].sapcode;
				else
				    document.getElementById('txtsapcode').value = "";
				
				
				
				
			updateStatus();
					document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
				fillAdCat1();
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
			document.getElementById('btnprevious').disabled=true;
		}
		setButtonImages();
		return false;
}
		
//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//

//function catnextclick()
//{
//Adsubcat3.catfpnl(nextcall);

//		        
//			    document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcat3code').disabled=true;
//			document.getElementById('txtadcat3name').disabled=true;
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
	 document.getElementById('drpadvcatcode').options.length=0;
			 document.getElementById('drpadvcatcode').value=0;
              document.getElementById('drpadcategory').value=0;
	var a=dscatexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
		glo_cat2=dscatexecute.Tables[0].Rows[z].subcatname;
			// document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].subcatname;
			 	document.getElementById('txtadcat3code').value=dscatexecute.Tables[0].Rows[z].catcode;
				document.getElementById('txtadcat3name').value=dscatexecute.Tables[0].Rows[z].catname;
				if(dscatexecute.Tables[0].Rows[z].PRIORITY != null)
				document.getElementById('txtpriority').value=dscatexecute.Tables[0].Rows[z].PRIORITY;
				else
				document.getElementById('txtpriority').value="";
				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[z].catalias;
				
				if(dscatexecute.Tables[0].Rows[z].adminwebxml==null || dscatexecute.Tables[0].Rows[z].adminwebxml=="")
				   {
				    document.getElementById('txtxml').value="";
				   }
				   else
				   {
				     document.getElementById('txtxml').value=dscatexecute.Tables[0].Rows[z].adminwebxml;
				   }
				
				
				if(dscatexecute.Tables[0].Rows[z].STATUS != null)
				document.getElementById('drpstatus').value=dscatexecute.Tables[0].Rows[z].STATUS;
				else
				    document.getElementById('drpstatus').value = "";


				if (dscatexecute.Tables[0].Rows[z].PUBCENTER != null)
				    document.getElementById('dppubcent').value = dscatexecute.Tables[0].Rows[z].PUBCENTER;
				else
				    document.getElementById('dppubcent').value = "";

				if (dscatexecute.Tables[0].Rows[z].sapcode != null)
				    document.getElementById('txtsapcode').value = dscatexecute.Tables[0].Rows[z].sapcode;
				else
				    document.getElementById('txtsapcode').value = "";
				
				
			
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			fillAdCat1();
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
			//var companycode=document.getElementById('hiddencomcode').value;
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcat3code').value;
			var catname=document.getElementById('txtadcat3name').value;
		    var alias=document.getElementById('txtalias').value;
		    var xml = document.getElementById('txtxml').value;
		    var ppubcenter = document.getElementById('dppubcent').value;
		    var priority = document.getElementById('txtpriority').value;
		    var sapcode = document.getElementById('txtsapcode').value;				
		    
		   			
		    
			var userid=document.getElementById('hiddenuserid').value;	
				    //dan

		if( confirm("Are You Sure To Delete The Data ?"));
			{
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
       
       var ip2=document.getElementById('ip1').value;	
       Adsubcat3.catdelete(compcode,catcode,ip2);
       alert("Data Deleted Successfully");
      
			document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcat3name').value="";
            document.getElementById('txtadcat3code').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtxml').value="";
            document.getElementById('txtpriority').value = "";
            document.getElementById('dppubcent').value = 0;
            document.getElementById('txtsapcode').value = "";

            document.getElementById('drpadcategory').value = 0;


            Adsubcat3.catexecute1(compcode, glaobalsubcatname, glaobalcatname, glaobalcatcode, glaobalcatalias, glaobalxml, document.getElementById('dppubcent').value,delcall);
		     }
//		   document.getElementById('drpadvcatcode').value=0;
//            document.getElementById('txtadcat3name').value="";
//            document.getElementById('txtadcat3code').value="";
//            document.getElementById('txtalias').value="";
		
		
		
		//BgColor.bgexecute2(glaobalbgid,glaobalbgname,glaobalbgalias,delcall);
		//catnextclicktest();
		
//		
//		}     
//	else
//	{
	//return false;
	//}
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
		
		document.getElementById('drpadvcatcode').value="0";
            document.getElementById('txtadcat3name').value="";
            document.getElementById('txtadcat3code').value="";
            document.getElementById('txtalias').value="";
             document.getElementById('txtxml').value="";
             document.getElementById('txtpriority').value = "";
             document.getElementById('txtsapcode').value = "";
		 catcancelclick('Adsubcat3');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
	glo_cat2=dscatexecute.Tables[0].Rows[0].subcatname;
		   //  document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].subcatname;
			 	document.getElementById('txtadcat3code').value=dscatexecute.Tables[0].Rows[0].catcode;
				document.getElementById('txtadcat3name').value=dscatexecute.Tables[0].Rows[0].catname;
				if(dscatexecute.Tables[0].Rows[0].PRIORITY != null)
				document.getElementById('txtpriority').value=dscatexecute.Tables[0].Rows[0].PRIORITY;
				else
				document.getElementById('txtpriority').value="";
				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[0].catalias;
				if(dscatexecute.Tables[0].Rows[0].adminwebxml==null || dscatexecute.Tables[0].Rows[0].adminwebxml=="")
				   {
				    document.getElementById('txtxml').value="";
				   }
				   else
				   {
				     document.getElementById('txtxml').value=dscatexecute.Tables[0].Rows[0].adminwebxml;
				 }
				fillAdCat1();
			
	}
	else
	{
	glo_cat2=dscatexecute.Tables[0].Rows[0].subcatname;
		      // document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].subcatname;
			 	document.getElementById('txtadcat3code').value=dscatexecute.Tables[0].Rows[z].catcode;
				document.getElementById('txtadcat3name').value=dscatexecute.Tables[0].Rows[z].catname;
				if(dscatexecute.Tables[0].Rows[z].PRIORITY != null)
				document.getElementById('txtpriority').value=dscatexecute.Tables[0].Rows[z].PRIORITY;
				else
				document.getElementById('txtpriority').value="";
				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[z].catalias;
			  if(dscatexecute.Tables[0].Rows[z].adminwebxml==null || dscatexecute.Tables[0].Rows[z].adminwebxml=="")
				   {
				    document.getElementById('txtxml').value="";
				   }
				   else
				   {
				     document.getElementById('txtxml').value=dscatexecute.Tables[0].Rows[z].adminwebxml;
				   }
				   
				   fillAdCat1();
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
document.getElementById('drpadvcatcode').options.length=0;
				document.getElementById('drpadvcatcode').value=0;
				 document.getElementById('drpadcategory').value=0;
            document.getElementById('txtadcat3name').value="";
            document.getElementById('txtadcat3code').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtxml').value="";
            document.getElementById('txtpriority').value = "";
            document.getElementById('dppubcent').value = 0;
            document.getElementById('txtsapcode').value = "";
                  document.getElementById('drpstatewise').value = 0;
				glo_cat2=0;
				document.getElementById('drpadvcatcode').disabled=true;
				 document.getElementById('drpadcategory').disabled=true;
			document.getElementById('txtadcat3code').disabled=true;
			document.getElementById('txtadcat3name').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('txtxml').disabled=true;
			document.getElementById('txtpriority').disabled = true;
			document.getElementById('drpstatus').disabled = true;
			document.getElementById('dppubcent').disabled = true;
			document.getElementById('txtsapcode').disabled = true;
				
				
				
				document.getElementById('btnModify').disabled=true;
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				
				
			//getPermission(formname);
				mod="0";
				
					chkstatus(FlagStatus);
					
					
					
					if(document.getElementById('btnNew').disabled==false)
					{
					   
						document.getElementById('btnNew').focus();
					}
						
					else
					{
						document.getElementById('btnNew').disabled=false;
						document.getElementById('btnNew').focus();
						
					}
					
				/*document.getElementById('btnNew').disabled=false;
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
				document.getElementById('btnlast').disabled=true;*/
				
					givebuttonpermission(formname);
					setButtonImages();
				return false;
}

/*function catnextclicktest()
{
		Adsubcat3.catfpnl(nextcalltest);

		        document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcat3code').disabled=true;
			document.getElementById('txtadcat3name').disabled=true;
			document.getElementById('txtalias').disabled=true;
		
		return false;
}*/


//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function catnextclicktest()
{
	//var dszoneexecute=response.value;
	var a=dscatexecute.Tables[0].Rows.length;
	znk++;
	if(znk !=-1 && znk >= 0)
	{
		if(znk <= a-1)
		{
			glo_cat2=dscatexecute.Tables[0].Rows[znk].subcatname;
		      // document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[znk].subcatname;
			 	document.getElementById('txtadcat3code').value=dscatexecute.Tables[0].Rows[znk].catcode;
				document.getElementById('txtadcat3name').value=dscatexecute.Tables[0].Rows[znk].catname;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[znk].catalias;
				document.getElementById('txtsapcode').value = dscatexecute.Tables[0].Rows[znk].sapcode;
			
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			
			fillAdCat1();
			
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

/*-----For---Upper Case-------------*/
function uppercase1()
{
document.getElementById('txtadcat3code').value=document.getElementById('txtadcat3code').value.toUpperCase();

return ;
}
		
function uppercase2()
{
document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
if(document.getElementById('txtxml').style.display=="none" && hiddentext != "query")
   {
    document.getElementById('btnSave').focus();
   }
return ;
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
function clearadcat3() {
    catcancelclick('Adsubcat3');
    givebuttonpermission('Adsubcat3');
    


}