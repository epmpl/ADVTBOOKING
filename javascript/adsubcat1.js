var z=0;

	var flag;	
	//var k=0;

	var statecode ;//= document.getElementById('drpstatewise').value;
	var previous = statecode;
var hiddentext;
var adsubcatds;

var gladvcatcode;
var glsubcatcode;
var gladsubcatname;
var glalias;
var adsubcatds;
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
		var xmlObj;
        function loadXML(xmlFile) 
         { 
            xmlDoc.async="false"; 
            xmlDoc.onreadystatechange=verify; 
            xmlDoc.load(xmlFile); 
            xmlObj=xmlDoc.documentElement; 
           // alert(xmlObj.childNodes(0).childNodes(0).text);  
            
          }

function refreshf()
{
    document.getElementById('txtsubcatcode').value="";
	document.getElementById('txtadsubcatname').value="";
	document.getElementById('txtalias').value="";
	return false;
}



function subcatinsert()
	{
				//alert("hi");
				 var msg=checkSession();
            if(msg==false)
            return false;
				flag=1;
				
				 if(document.getElementById('hiddenauto').value==1)
		        {
		         document.getElementById('txtsubcatcode').disabled=true;
    	        }
		       else
		       {
		       document.getElementById('txtsubcatcode').disabled=false;
    	       }

				
				
				
				

			//==============navigation================
				document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=false;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExit').disabled=false;
				hiddentext="new";
				
				document.getElementById('drpadvcatcode').value=0;
				document.getElementById('txtsubcatcode').value="";
				document.getElementById('txtadsubcatname').value="";
				document.getElementById('txtalias').value="";
					document.getElementById('drpstatus').value="1";
				document.getElementById('txtimagename').value="";
				document.getElementById('txtxml').value="";
				document.getElementById('txtpri').value="";
				document.getElementById('drpstatus').value="1";
				document.getElementById('txtsapcode').value = "";
				document.getElementById('drpeddiscflag').value = "N";
			chkstatus(FlagStatus);
			/*document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;*/
				
				document.getElementById('drpadvcatcode').disabled=false;
		//		document.getElementById('txtsubcatcode').disabled=false;
				document.getElementById('txtadsubcatname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				document.getElementById('drpstatus').disabled=false;
				document.getElementById('drpstatus').disabled=false;
				document.getElementById('txtimagename').disabled=false;
				document.getElementById('txtxml').disabled=false;

				document.getElementById('txtpri').disabled = false;
				document.getElementById('txtsapcode').disabled = false;
				document.getElementById('drpeddiscflag').disabled = false;
				   document.getElementById('drpadvcatcode').focus();
				setButtonImages();
			return false;
		}
			
			
function canceladsubcat(formname)

			{
			   
				
				
				document.getElementById('drpadvcatcode').value="0";
				document.getElementById('txtsubcatcode').value="";
				document.getElementById('txtadsubcatname').value="";
				document.getElementById('txtalias').value="";
				document.getElementById('drpstatus').value="1";
				document.getElementById('txtimagename').value="";
				document.getElementById('txtxml').value="";
				document.getElementById('txtpri').value = "";
				document.getElementById('txtsapcode').value = "";
				document.getElementById('drpeddiscflag').value = "N";
				//hiddentext="";
				
				document.getElementById('drpadvcatcode').disabled=true;
				document.getElementById('txtsubcatcode').disabled=true;
				document.getElementById('txtadsubcatname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('drpstatus').disabled=true;
				document.getElementById('txtimagename').disabled=true;
				document.getElementById('txtxml').disabled=true;
				document.getElementById('txtpri').disabled = true;
				document.getElementById('txtsapcode').disabled = true;
				document.getElementById('drpeddiscflag').disabled = true;
			    givebuttonpermission(formname);
			    setButtonImages();
			    if(document.getElementById('btnNew').disabled==false)
				    document.getElementById('btnNew').focus();
				
				return false;
			}
			
function saveadsubcat()
{
 var msg=checkSession();
            if(msg==false)
            return false;
  document.getElementById('txtsubcatcode').value=trim(document.getElementById('txtsubcatcode').value);
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
	if(flag==1)
	{
	   if(document.getElementById('drpadvcatcode').value=="0")
		{
		
		alert("You Must Select Ad Category Name");
		document.getElementById('drpadvcatcode').focus();
		return false;
		}
		else
		{}
		
		
		 if((document.getElementById('txtsubcatcode').value=="")&&(document.getElementById('hiddenauto').value!=1))
		{
		alert("You Must Enter SubCategory Code");
		document.getElementById('txtsubcatcode').focus();
		return false;
		}
		else
		{}
		if (document.getElementById('txtadsubcatname').value=="")
		{
		alert("You Must Enter Ad SubCategory Name");
		document.getElementById('txtadsubcatname').focus();
		return false;
		}
		else
		{}
		 if(document.getElementById('txtalias').value=="")
		{
		alert("You must Enter The Alias Name");
		document.getElementById('txtalias').focus();
		return false;
		}
		else
		{}
		
		
		
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpadvcatcode').value;
		var subcatcode =document.getElementById('txtsubcatcode').value;
		var subcatname =document.getElementById('txtadsubcatname').value;
		var subcatalias =document.getElementById('txtalias').value;
		var userid = document.getElementById('hiddenuserid').value;
		var statecode = document.getElementById('drpstatewise').value;
		var eddiscflag = document.getElementById('drpeddiscflag').value;
				//var status1=document.getElementById('drpstatus').value;
		var res=adsubcat1.subcatchk(compcode, subcatcode, subcatname, catcode, userid, statecode)

		savenew(res.value);
		 //adsubcat1.chksubcatcode(str,catcode,savenew)
					return false;
				}
				else
				{
				    if(name_modify==trim(document.getElementById('txtadsubcatname').value))
				    {
				        savemodify();
				        return false;
				    }
				    {
				        var str=document.getElementById('txtadsubcatname').value;
				        var catcode = document.getElementById('drpadvcatcode').value;
				        var statecode = document.getElementById('drpstatewise').value;
				        var eddiscflag = document.getElementById('drpeddiscflag').value;
				        var res = adsubcat1.chksubcatcode(str, catcode, statecode);
				        savemodify(res.value);
				    }
					//savemodify();
				return false;
				}

}


function savenew(res)
{     

    var ds = res;
if(ds.Tables.length>1)
{
if(ds.Tables[1].Rows.length>0)
{
    alert("This Sub Category Name has already assigned !! ");
	        document.getElementById('txtalias').value="";
	        document.getElementById('txtimagename').value="";
		    document.getElementById('txtxml').value="";
		    document.getElementById('txtpri').value = "";
		    document.getElementById('txtsapcode').value = "";
		    document.getElementById('txtadsubcatname').value="";
		    document.getElementById('drpeddiscflag').value = "0";

		    if(document.getElementById('txtadsubcatname').disabled==false)
		    document.getElementById('txtadsubcatname').focus();
  
//return false;
}
}
if(ds.Tables[0].Rows.length==0)
{
if(document.getElementById('drpadvcatcode').value=="0")
		{
		
		alert("You Must Select Ad Category Name");
		document.getElementById('drpadvcatcode').focus();
		return false;
		}
		else
		{}
		
		
		 if((document.getElementById('txtsubcatcode').value=="")&&(document.getElementById('hiddenauto').value!=1))
		{
		alert("You Must Enter SubCategory Code");
		document.getElementById('txtsubcatcode').focus();
		return false;
		}
		else
		{}
		if (document.getElementById('txtadsubcatname').value=="")
		{
		alert("You Must Enter Ad SubCategory Name");
		document.getElementById('txtadsubcatname').focus();
		return false;
		}
		else
		{}
		 if(document.getElementById('txtalias').value=="")
		{
		alert("You must Enter The Alias Name");
		document.getElementById('txtalias').focus();
		return false;
		}
		else
		{
		
		}
		
		
		
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpadvcatcode').value;
		var subcatcode =trim(document.getElementById('txtsubcatcode').value);
		var subcatname =trim(document.getElementById('txtadsubcatname').value);
		var subcatalias =trim(document.getElementById('txtalias').value)
		var userid=document.getElementById('hiddenuserid').value;
		var status1=document.getElementById('drpstatus').value; 
		var imagename= trim(document.getElementById('txtimagename').value);
		var txtxml= trim(document.getElementById('txtxml').value);
		var ip2 = document.getElementById('ip1').value;
		var sapcode = document.getElementById('txtsapcode').value;
		var statecode = document.getElementById('drpstatewise').value;
		var eddiscflag = document.getElementById('drpeddiscflag').value;
		adsubcat1.subcatsave(compcode, catcode, subcatcode, subcatname, subcatalias, userid, imagename, txtxml, document.getElementById('txtpri').value, ip2, status1, sapcode, statecode, eddiscflag)
		
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
					
					
				document.getElementById('drpadvcatcode').value=0;
				document.getElementById('txtsubcatcode').value="";
				document.getElementById('txtadsubcatname').value="";
				document.getElementById('txtalias').value="";
					document.getElementById('drpstatus').value="1";
				document.getElementById('txtimagename').value="";
				document.getElementById('txtxml').value="";
				document.getElementById('txtpri').value = "";
				document.getElementById('txtsapcode').value = "";
				document.getElementById('drpeddiscflag').value = "N";
				
				
				document.getElementById('drpadvcatcode').disabled=true;
				document.getElementById('txtsubcatcode').disabled=true;
				document.getElementById('txtadsubcatname').disabled=true;
				document.getElementById('txtalias').disabled=true;
						document.getElementById('drpstatus').disabled=true;
				document.getElementById('txtimagename').disabled=true;
				document.getElementById('txtxml').disabled=true;
				document.getElementById('txtpri').disabled = true;
				document.getElementById('txtsapcode').disabled = true;
				document.getElementById('drpeddiscflag').disabled = true;
				alert("Data Saved Successfully");
				setButtonImages();
				if(document.getElementById('btnNew').disabled==false)
				document.getElementById('btnNew').focus();
					return false;
}
else if(ds.Tables[0].Rows.length>0)
{

	        //document.getElementById('txtalias').value="";
	       // document.getElementById('txtimagename').value="";
		   // document.getElementById('txtxml').value="";
		    document.getElementById('txtsubcatcode').value="";
		    alert("This Sub Category Code has already assigned !! ");
		    if(document.getElementById('txtsubcatcode').disabled==false)
		    document.getElementById('txtsubcatcode').focus();
  
//return false;
}
setButtonImages();
return false;
}


function savemodify()
{

        
        if(document.getElementById('drpadvcatcode').value=="0")
		{
		
		alert("You Must Select Ad Category Name");
		document.getElementById('drpadvcatcode').focus();
		return false;
		}



			if (document.getElementById('txtadsubcatname').value=="")
		{
		alert("You Must Enter Ad SubCategory Name");
		document.getElementById('txtadsubcatname').focus();
		return false;
		}
		else
		{}
		 if(document.getElementById('txtalias').value=="")
		{
		alert("You must Enter The Alias Name");
		document.getElementById('txtalias').focus();
		return false;
		}
		else
		{}

			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('drpadvcatcode').value;
			var subcatcode =trim(document.getElementById('txtsubcatcode').value);
			var subcatname =trim(document.getElementById('txtadsubcatname').value);
			var subcatalias =trim(document.getElementById('txtalias').value);
			var userid=document.getElementById('hiddenuserid').value; 
			var status1=document.getElementById('drpstatus').value; 
			var imagename= trim(document.getElementById('txtimagename').value);
		    var txtxml= trim(document.getElementById('txtxml').value);
		    var ip2 = document.getElementById('ip1').value;
		    var sapcode = document.getElementById('txtsapcode').value;
		    var statecode = document.getElementById('drpstatewise').value;
		    var eddiscflag = document.getElementById('drpeddiscflag').value;
		    adsubcat1.subcatupdate(compcode, catcode, subcatcode, subcatname, subcatalias, userid, imagename, txtxml, document.getElementById('txtpri').value, ip2, status1, sapcode, statecode, eddiscflag)
			
			         adsubcatds.Tables[0].Rows[z].Adv_Cat_Code=document.getElementById('drpadvcatcode').value;
					adsubcatds.Tables[0].Rows[z].Adv_Subcat_Code=document.getElementById('txtsubcatcode').value;
					adsubcatds.Tables[0].Rows[z].Adv_Subcat_Name=document.getElementById('txtadsubcatname').value;
					adsubcatds.Tables[0].Rows[z].Adv_Subcat_Alias=document.getElementById('txtalias').value;
					adsubcatds.Tables[0].Rows[z].STATUS=document.getElementById('drpstatus').value;
					if(document.getElementById('txtpri').value!=null)
					    adsubcatds.Tables[0].Rows[z].PRIORITY=document.getElementById('txtpri').value;
					else
					    adsubcatds.Tables[0].Rows[z].PRIORITY = "";

					if (document.getElementById('txtsapcode').value != null)
					    adsubcatds.Tables[0].Rows[z].sapcode = document.getElementById('txtsapcode').value;
					else
					    adsubcatds.Tables[0].Rows[z].sapcode = "";
					adsubcatds.Tables[0].Rows[z].STATECODE = document.getElementById('drpstatewise').value;
					adsubcatds.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG = document.getElementById('drpeddiscflag').value;
				   
					
					document.getElementById('btnNew').disabled=true;
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=false;
					document.getElementById('btnDelete').disabled=false;
					document.getElementById('btnQuery').disabled=false;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;



					alert("Data Updated Successfully");


					document.getElementById('drpadvcatcode').value = 0;
					document.getElementById('txtsubcatcode').value = "";
					document.getElementById('txtadsubcatname').value = "";
					document.getElementById('txtalias').value = "";
					document.getElementById('drpstatus').value = "1";
					document.getElementById('txtimagename').value = "";
					document.getElementById('txtxml').value = "";
					document.getElementById('txtpri').value = "";
					document.getElementById('txtsapcode').value = "";
					updateStatus();
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					document.getElementById('btnExit').disabled=false;
					
					
			if (z==0)
                {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

           if(z==(adsubcatds.Tables[0].Rows.length-1))
               {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
               }       
      						
						
						document.getElementById('drpadvcatcode').disabled=true;
						document.getElementById('txtsubcatcode').disabled=true;
						document.getElementById('txtadsubcatname').disabled=true;
						document.getElementById('txtalias').disabled=true;
						document.getElementById('drpstatus').disabled=true;
						document.getElementById('txtimagename').disabled=true;
				        document.getElementById('txtxml').disabled=true;

				        document.getElementById('txtpri').disabled = true;
				        document.getElementById('txtsapcode').disabled = true;	
						 setButtonImages();
					return false;

}


function modifyadsubcat()
{
			flag=2 ;
			hiddentext="modify";
			   	chkstatus(FlagStatus);
				
				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;
				
				name_modify=trim(document.getElementById('txtadsubcatname').value);
		
				document.getElementById('drpadvcatcode').disabled=true;
				document.getElementById('txtsubcatcode').disabled=true;
				document.getElementById('txtadsubcatname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				document.getElementById('drpstatus').disabled=false;
				document.getElementById('txtimagename').disabled=false;
				document.getElementById('txtxml').disabled=false;
				document.getElementById('txtpri').disabled = false;
				document.getElementById('txtsapcode').disabled = false;
				document.getElementById('drpeddiscflag').disabled = false;
					setButtonImages();
				if( document.getElementById('btnSave').disabled==false)
				  document.getElementById('btnSave').focus();
				
				
				
				
				return false;



}



function queryadsubcat()
{

			

				
				chkstatus(FlagStatus);

			
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
				
				
				document.getElementById('drpadvcatcode').disabled=false;
				document.getElementById('txtsubcatcode').disabled=false;
				document.getElementById('txtadsubcatname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				document.getElementById('txtpri').disabled = true;
				document.getElementById('txtsapcode').disabled = true;
				document.getElementById('drpstatus').disabled = true;
				document.getElementById('drpeddiscflag').disabled = true;
				document.getElementById('drpadvcatcode').value=0;
						document.getElementById('txtsubcatcode').value="";
						document.getElementById('txtadsubcatname').value="";
						document.getElementById('txtalias').value="";
						document.getElementById('drpstatus').value="1";
						document.getElementById('txtimagename').value="";
				        document.getElementById('txtxml').value="";
				        document.getElementById('txtpri').value = "";
				        document.getElementById('txtsapcode').value = "";
				        document.getElementById('drpstatewise').value = "";
				        document.getElementById('drpeddiscflag').value = "0";

						z=0;
						hiddentext="";
						setButtonImages();
				if(document.getElementById('btnExecute').disabled==false)		
				document.getElementById('btnExecute').focus();	
						
				
				return false;



}



function executeadsubcat()
{
 var msg=checkSession();
            if(msg==false)
            return false;
//alert(adsubcat1);
    	var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpadvcatcode').value;
		var subcatcode =document.getElementById('txtsubcatcode').value;
		var subcatname =document.getElementById('txtadsubcatname').value;
		var subcatalias =document.getElementById('txtalias').value;
		var userid = document.getElementById('hiddenuserid').value;
		var sapcode = document.getElementById('txtsapcode').value;
		var statecode = document.getElementById('drpstatewise').value;
		var eddiscflag = document.getElementById('drpeddiscflag').value;
		
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
       adsubcat1.subcatexe12(compcode, catcode, subcatcode, subcatname, subcatalias, userid, statecode, execall);
		
		gladvcatcode=catcode;
		glsubcatcode=subcatcode;
		gladsubcatname=subcatname;
		glalias=subcatalias;

						/*document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
						document.getElementById('btnModify').disabled=false;
						document.getElementById('btnDelete').disabled=false;
						document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnExecute').disabled=true;
						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;	
						document.getElementById('btnExit').disabled=false;*/
						updateStatus();
							document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();
						
						document.getElementById('drpadvcatcode').disabled=true;
				document.getElementById('txtsubcatcode').disabled=true;
				document.getElementById('txtadsubcatname').disabled=true;
				document.getElementById('txtalias').disabled=true;
					document.getElementById('drpstatus').disabled=true;
				document.getElementById('txtimagename').disabled=true;
				document.getElementById('txtxml').disabled=true;
						document.getElementById('txtpri').disabled=true;
						document.getElementById('txtsapcode').disabled = true;
								
						return false;

}

		function execall(response)
			{
			
			
				//ds=response.value;
				adsubcatds=response.value;
				
				if(adsubcatds.Tables[0].Rows.length>0)
				{
				
				
					
					document.getElementById('drpadvcatcode').value=adsubcatds.Tables[0].Rows[0].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=adsubcatds.Tables[0].Rows[0].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=adsubcatds.Tables[0].Rows[0].Adv_Subcat_Name;
					document.getElementById('txtalias').value=adsubcatds.Tables[0].Rows[0].Adv_Subcat_Alias;
					document.getElementById('drpstatus').value=adsubcatds.Tables[0].Rows[0].STATUS;
					if(adsubcatds.Tables[0].Rows[0].PRIORITY!=null)
					    document.getElementById('txtpri').value=adsubcatds.Tables[0].Rows[0].PRIORITY;
					else
					    document.getElementById('txtpri').value = "";
					    
					if (adsubcatds.Tables[0].Rows[0].sapcode != null)
					    document.getElementById('txtsapcode').value = adsubcatds.Tables[0].Rows[0].sapcode;
					else
					    document.getElementById('txtsapcode').value = "";

				     document.getElementById('drpstatewise').value = adsubcatds.Tables[0].Rows[0].STATECODE;   
					if(adsubcatds.Tables[0].Rows[0].Image_name!=null)
					{
					    document.getElementById('txtimagename').value=adsubcatds.Tables[0].Rows[0].Image_name;
					}
					else
					{
					    document.getElementById('txtimagename').value="";
					}
					
					if(adsubcatds.Tables[0].Rows[0].ADMINWEBXML!=null)
					{
					    document.getElementById('txtxml').value=adsubcatds.Tables[0].Rows[0].ADMINWEBXML;
					}
					else
					{
					    document.getElementById('txtxml').value="";
					}
					if (adsubcatds.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG == null) {
					    document.getElementById('drpeddiscflag').value = "";
					}
					else {
					    document.getElementById('drpeddiscflag').value = adsubcatds.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG;
					}
					
					document.getElementById('btnfirst').disabled=true;
			        document.getElementById('btnprevious').disabled=true;
			        
			        	if(adsubcatds.Tables[0].Rows.length==1)
					   	{
					   	document.getElementById('btnprevious').disabled=true;	
			            document.getElementById('btnlast').disabled=true;	
			            document.getElementById('btnfirst').disabled=true;
			            document.getElementById('btnnext').disabled=true;
			            }
			        if(document.getElementById('btnModify').disabled==false)
			            document.getElementById('btnModify').focus();
					
					//return false;
				}
				
				else
				{
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				
				
				alert("Your search Criteria Does Not Exist");
				canceladsubcat('adsubcat1');
				//return false;
				}
				setButtonImages();
		//return false;
		}
		
		
		
		/*function subexe()
		{
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpadvcatcode').value;
		var subcatcode =document.getElementById('txtsubcatcode').value;
		var subcatname =document.getElementById('txtadsubcatname').value;
		var subcatalias =document.getElementById('txtalias').value;
		var userid=document.getElementById('hiddenuserid').value; 
		//alert("hi");
		adsubcat1.exesub(compcode,catcode,subcatcode,subcatname,subcatalias,userid,exerecall)
		//alert("hello");
		return false;
		
		
		}*/
		
		/*function exerecall(response)
		{
		ds= response.value;
		
		document.getElementById('drpadvcatcode').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=ds.Tables[0].Rows[0].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=ds.Tables[0].Rows[0].Adv_Subcat_Name;
					document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Adv_Subcat_Alias;
		return false;
		}*/





function firstadsubcat()
{
 var msg=checkSession();
            if(msg==false)
            return false;
z=0;
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			 var catcode=document.getElementById('drpadvcatcode').value;
			//adsubcat1.subcatfirst(compcode,catcode,userid,firstcall)
			
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
			
			
//		return false;

//}


//function firstcall(response)
//{
//ds=response.value;

					document.getElementById('drpadvcatcode').value=adsubcatds.Tables[0].Rows[0].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=adsubcatds.Tables[0].Rows[0].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=adsubcatds.Tables[0].Rows[0].Adv_Subcat_Name;
					document.getElementById('txtalias').value=adsubcatds.Tables[0].Rows[0].Adv_Subcat_Alias;
					document.getElementById('drpstatus').value=adsubcatds.Tables[0].Rows[0].STATUS;
					if(adsubcatds.Tables[0].Rows[0].PRIORITY!=null)
					    document.getElementById('txtpri').value=adsubcatds.Tables[0].Rows[0].PRIORITY;
					else
					    document.getElementById('txtpri').value = "";

					if (adsubcatds.Tables[0].Rows[0].sapcode != null)
					    document.getElementById('txtsapcode').value = adsubcatds.Tables[0].Rows[0].sapcode;
					else
					    document.getElementById('txtsapcode').value = "";


					document.getElementById('drpstatewise').value = adsubcatds.Tables[0].Rows[0].STATECODE;        
					if(adsubcatds.Tables[0].Rows[0].Image_name!=null)
					{
					    document.getElementById('txtimagename').value=adsubcatds.Tables[0].Rows[0].Image_name;
					}
					else
					{
					    document.getElementById('txtimagename').value="";
					}
					
					if(adsubcatds.Tables[0].Rows[0].ADMINWEBXML!=null)
					{
					    document.getElementById('txtxml').value=adsubcatds.Tables[0].Rows[0].ADMINWEBXML;
					}
					else
					{
					    document.getElementById('txtxml').value="";
					}
					if (adsubcatds.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG == null) {
					    document.getElementById('drpeddiscflag').value = "";
					}
					else {
					    document.getElementById('drpeddiscflag').value = adsubcatds.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG;
					}
		
setButtonImages();
return false;
}


function previousadsubcat()
{
 var msg=checkSession();
            if(msg==false)
            return false;

			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			 var catcode=document.getElementById('drpadvcatcode').value;
//		adsubcat1.subcatpre(compcode,catcode,userid,precall)

//return false;

//}

//function precall(response)
//{

z--;
	//ds=response.value;
	
	var x=adsubcatds.Tables[0].Rows.length;
	
	

			if(z>x)
			{
			document.getElementById('btnfirst').disabled=false;				
						document.getElementById('btnnext').disabled=true;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=true;
return false;
			}
			
			
			
			if(z!=-1 && z>=0)
			{
					if(adsubcatds.Tables[0].Rows.length != z && z < x)
					{
					document.getElementById('drpadvcatcode').value=adsubcatds.Tables[0].Rows[z].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=adsubcatds.Tables[0].Rows[z].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=adsubcatds.Tables[0].Rows[z].Adv_Subcat_Name;
					document.getElementById('txtalias').value=adsubcatds.Tables[0].Rows[z].Adv_Subcat_Alias;
					document.getElementById('drpstatus').value=adsubcatds.Tables[0].Rows[z].STATUS;
					if(adsubcatds.Tables[0].Rows[z].PRIORITY!=null)
					    document.getElementById('txtpri').value=adsubcatds.Tables[0].Rows[z].PRIORITY;
					else
					    document.getElementById('txtpri').value = "";

					if (adsubcatds.Tables[0].Rows[z].sapcode != null)
					    document.getElementById('txtsapcode').value = adsubcatds.Tables[0].Rows[z].sapcode;
					else
					    document.getElementById('txtsapcode').value = "";


					document.getElementById('drpstatewise').value = adsubcatds.Tables[0].Rows[0].STATECODE;      
					
					
					if(adsubcatds.Tables[0].Rows[z].Image_name!=null)
					{
					    document.getElementById('txtimagename').value=adsubcatds.Tables[0].Rows[z].Image_name;
					}
					else
					{
					    document.getElementById('txtimagename').value="";
					}
					
					if(adsubcatds.Tables[0].Rows[z].ADMINWEBXML!=null)
					{
					    document.getElementById('txtxml').value=adsubcatds.Tables[0].Rows[z].ADMINWEBXML;
					}
					else
					{
					    document.getElementById('txtxml').value="";
					}
					if (adsubcatds.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG == null) {
					    document.getElementById('drpeddiscflag').value = "";
					}
					else {
					    document.getElementById('drpeddiscflag').value = adsubcatds.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG;
					}
					
					
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					if(document.getElementById('btnModify').disabled==false)
			    	document.getElementById('btnModify').focus();
						
					}
					else
					{
							document.getElementById('btnnext').disabled=true;
							document.getElementById('btnlast').disabled=false;
							document.getElementById('btnfirst').disabled=true;
							document.getElementById('btnprevious').disabled=false;
							return false;
		
					}
			
			
					}
					else
					{
							document.getElementById('btnnext').disabled=true;
							document.getElementById('btnlast').disabled=false;
							document.getElementById('btnfirst').disabled=true;
							document.getElementById('btnprevious').disabled=false;
							return false;
		
					}	

if (z<=0)
	{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;
			setButtonImages();	
	return false;		
	}
	setButtonImages();
	return false;


}



function nextadsubcat()
{
 var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			 var catcode=document.getElementById('drpadvcatcode').value;
//adsubcat1.subcatnext(compcode,catcode,userid,nextcall)



//return false;

//}

//function nextcall(response)
//{
z++;
	//ds=response.value;
	
	var x=adsubcatds.Tables[0].Rows.length;
	
	if(z <= x && z !=-1)

	{
		if(adsubcatds.Tables[0].Rows.length != z && z >= 0)
		
		{
		document.getElementById('drpadvcatcode').value=adsubcatds.Tables[0].Rows[z].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=adsubcatds.Tables[0].Rows[z].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=adsubcatds.Tables[0].Rows[z].Adv_Subcat_Name;
					document.getElementById('txtalias').value=adsubcatds.Tables[0].Rows[z].Adv_Subcat_Alias;
					document.getElementById('drpstatus').value=adsubcatds.Tables[0].Rows[z].STATUS;
					if(adsubcatds.Tables[0].Rows[z].PRIORITY!=null)
					    document.getElementById('txtpri').value=adsubcatds.Tables[0].Rows[z].PRIORITY;
					else
					    document.getElementById('txtpri').value = "";

					if (adsubcatds.Tables[0].Rows[z].sapcode != null)
					    document.getElementById('txtsapcode').value = adsubcatds.Tables[0].Rows[z].sapcode;
					else
					    document.getElementById('txtsapcode').value = "";

					document.getElementById('drpstatewise').value = adsubcatds.Tables[0].Rows[0].STATECODE;     
					if(adsubcatds.Tables[0].Rows[z].Image_name!=null)
					{
					    document.getElementById('txtimagename').value=adsubcatds.Tables[0].Rows[z].Image_name;
					}
					else
					{
					    document.getElementById('txtimagename').value="";
					}
					
					if(adsubcatds.Tables[0].Rows[z].ADMINWEBXML!=null)
					{
					    document.getElementById('txtxml').value=adsubcatds.Tables[0].Rows[z].ADMINWEBXML;
					}
					else
					{
					    document.getElementById('txtxml').value="";
					}
					if (adsubcatds.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG == null) {
					    document.getElementById('drpeddiscflag').value = "";
					}
					else {
					    document.getElementById('drpeddiscflag').value = adsubcatds.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG;
					}
					
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					if(document.getElementById('btnModify').disabled==false)
					document.getElementById('btnModify').focus();
					
					
	} 
	else
		{
		    document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=true;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=true;
					return false;
		
		}

	}
	else
		{
		document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=true;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=true;
					return false;
		
		}
		if(z==x-1)
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		setButtonImages();
		return false;
  
}
function lastadsubcat()
{
 var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			 var catcode=document.getElementById('drpadvcatcode').value;
//			adsubcat1.subcatlast(compcode,catcode,userid,lastcall)


//return false;


//}


//function lastcall(response)
//	{

			//ds= response.value;
				var x=adsubcatds.Tables[0].Rows.length;
				z=x-1;
				x=x-1;

					document.getElementById('drpadvcatcode').value=adsubcatds.Tables[0].Rows[x].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=adsubcatds.Tables[0].Rows[x].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=adsubcatds.Tables[0].Rows[x].Adv_Subcat_Name;
					document.getElementById('txtalias').value=adsubcatds.Tables[0].Rows[x].Adv_Subcat_Alias;
										document.getElementById('drpstatus').value=adsubcatds.Tables[0].Rows[x].STATUS;
					if(adsubcatds.Tables[0].Rows[x].PRIORITY!=null)
					    document.getElementById('txtpri').value=adsubcatds.Tables[0].Rows[x].PRIORITY;
					else
					    document.getElementById('txtpri').value = "";

					if (adsubcatds.Tables[0].Rows[x].sapcode != null)
					    document.getElementById('txtsapcode').value = adsubcatds.Tables[0].Rows[x].sapcode;
					else
					    document.getElementById('txtsapcode').value = "";


					document.getElementById('drpstatewise').value = adsubcatds.Tables[0].Rows[0].STATECODE;     
					if(adsubcatds.Tables[0].Rows[x].Image_name!=null)
					{
					    document.getElementById('txtimagename').value=adsubcatds.Tables[0].Rows[x].Image_name;
					}
					else
					{
					    document.getElementById('txtimagename').value="";
					}
					
					if(adsubcatds.Tables[0].Rows[x].ADMINWEBXML!=null)
					{
					    document.getElementById('txtxml').value=adsubcatds.Tables[0].Rows[x].ADMINWEBXML;
					}
					else
					{
					    document.getElementById('txtxml').value="";
					}
					
					if (adsubcatds.Tables[0].Rows[x].EDITION_DISCOUNT_FLAG == null) {
					    document.getElementById('drpeddiscflag').value = "";
					}
					else {
					    document.getElementById('drpeddiscflag').value = adsubcatds.Tables[0].Rows[x].EDITION_DISCOUNT_FLAG;
					}


			document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=true;	
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;
            setButtonImages();
            return false


	}



function deleteadsubcat()
	{
	 var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var catcode=document.getElementById('drpadvcatcode').value;
			var subcatcode = document.getElementById('txtsubcatcode').value;
			var statecode = document.getElementById('drpstatewise').value; 
			
			if(confirm("Are You Sure To Delete The Data ?"))
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
      var ip2=document.getElementById('ip1').value;
adsubcat1.subcatdel(compcode,catcode,userid,subcatcode,ip2);
alert("Data Deleted Successfully");
			adsubcat1.subcatexe12(compcode,gladvcatcode,glsubcatcode,gladsubcatname,glalias,userid,call_deleteadsubcode);
			//adsubcat1.subcatlast(compcode,catcode,userid,call_deleteadsubcode);

}

document.getElementById('drpadvcatcode').value = 0;
document.getElementById('txtsubcatcode').value = "";
document.getElementById('txtadsubcatname').value = "";
document.getElementById('txtalias').value = "";
document.getElementById('drpstatus').value = "1";
document.getElementById('txtimagename').value = "";
document.getElementById('txtxml').value = "";
document.getElementById('txtpri').value = "";
document.getElementById('txtsapcode').value = "";
document.getElementById('drpstatewise').value = ""; 
			return false;
		
		}
		
function call_deleteadsubcode(response)
		{
		//var ds=response.value;
//var ds=response.value;
adsubcatds=response.value;
	var a=adsubcatds.Tables[0].Rows.length;
	var y=a-1;
	
	if( adsubcatds.Tables[0].Rows.length==0 )
	{
	alert("There Is No Data In The Database");
	document.getElementById('drpadvcatcode').value=0;
				document.getElementById('txtsubcatcode').value="";
				document.getElementById('txtadsubcatname').value="";
				document.getElementById('txtalias').value="";
				document.getElementById('txtpri').value = "";
				document.getElementById('txtsapcode').value = "";
				document.getElementById('drpstatus').value="1";
canceladsubcat('adsubcat1');
	}
	
	else if(z==-1 ||z>=a)
	{
	
              document.getElementById('drpadvcatcode').value=adsubcatds.Tables[0].Rows[0].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=adsubcatds.Tables[0].Rows[0].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=adsubcatds.Tables[0].Rows[0].Adv_Subcat_Name;
					document.getElementById('txtalias').value=adsubcatds.Tables[0].Rows[0].Adv_Subcat_Alias;
					document.getElementById('txtimagename').value=adsubcatds.Tables[0].Rows[0].Image_name;
					document.getElementById('txtxml').value=adsubcatds.Tables[0].Rows[0].ADMINWEBXML;
					document.getElementById('drpstatus').value=adsubcatds.Tables[0].Rows[0].STATUS;
					if(adsubcatds.Tables[0].Rows[0].PRIORITY!=null)
					    document.getElementById('txtpri').value=adsubcatds.Tables[0].Rows[0].PRIORITY;
					else
					    document.getElementById('txtpri').value = "";

					if (adsubcatds.Tables[0].Rows[0].sapcode != null)
					    document.getElementById('txtsapcode').value = adsubcatds.Tables[0].Rows[0].sapcode;
					else
					    document.getElementById('txtsapcode').value = "";

					document.getElementById('drpstatewise').value = adsubcatds.Tables[0].Rows[0].STATECODE;
					if (adsubcatds.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG == null) {
					    document.getElementById('drpeddiscflag').value = "";
					}
					else {
					    document.getElementById('drpeddiscflag').value = adsubcatds.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG;
					}
return false;
	}
	
	else
	{
	
document.getElementById('drpadvcatcode').value=adsubcatds.Tables[0].Rows[z].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=adsubcatds.Tables[0].Rows[z].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=adsubcatds.Tables[0].Rows[z].Adv_Subcat_Name;
					document.getElementById('txtalias').value=adsubcatds.Tables[0].Rows[z].Adv_Subcat_Alias;
					document.getElementById('txtimagename').value=adsubcatds.Tables[0].Rows[z].Image_name;
					document.getElementById('txtxml').value=adsubcatds.Tables[0].Rows[z].ADMINWEBXML;
					document.getElementById('drpstatus').value=adsubcatds.Tables[0].Rows[z].STATUS;
					if(adsubcatds.Tables[0].Rows[z].PRIORITY!=null)
					    document.getElementById('txtpri').value=adsubcatds.Tables[0].Rows[z].PRIORITY;
					else
					    document.getElementById('txtpri').value = "";

					if (adsubcatds.Tables[0].Rows[z].sapcode != null)
					    document.getElementById('txtsapcode').value = adsubcatds.Tables[0].Rows[z].sapcode;
					else
					    document.getElementById('txtsapcode').value = "";
					if (adsubcatds.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG == null) {
					    document.getElementById('drpeddiscflag').value = "";
					}
					else {
					    document.getElementById('drpeddiscflag').value = adsubcatds.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG;
					}
return false;
	}
	
	setButtonImages();
return false;
		
		}
	
	
	function exitadsubcat()
	{
	if(confirm("Do You Want To Skip This Page"))
	{
	//window.location.href='Default.aspx';
	window.close();
	return false;
	}
	return false;
	}
	
	
	///////////////////////////////////////////









	function autoornot() {
	   // var statecode = document.getElementById('drpstatewise').value;

	    //if (document.getElementById('drpstatewise').value == document.getElementById('txtadsubcatname').value)
 //{
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    //return false;
    }
else
    {
    userdefine();

    return false;
}
    //}
return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )
			{
			
		document.getElementById('txtadsubcatname').value=trim(document.getElementById('txtadsubcatname').value.toUpperCase());
		lstr=document.getElementById('txtadsubcatname').value;
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
//			        if (document.getElementById('drpstatewise').value != document.getElementById('txtadsubcatname').value)
//			        {

			            if (document.getElementById('txtadsubcatname').value != "") 
                    {
                
                document.getElementById('txtadsubcatname').value=document.getElementById('txtadsubcatname').value.toUpperCase();
	            document.getElementById('txtalias').value=document.getElementById('txtadsubcatname').value;
	            var catcode = document.getElementById('drpadvcatcode').value;
	            
	            var statecode = document.getElementById('drpstatewise').value;
	            // str=document.getElementById('txtadsubcatname').value;
	            str = mstr;

	            var res = adsubcat1.chksubcatcode(str, catcode, statecode, fillcall);
	             
		       return false;
                }
		     //return false;
		     //}
           
           }
            else
            {
            document.getElementById('txtadsubcatname').value=document.getElementById('txtadsubcatname').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code
function UpperCaseAlias()
{
   document.getElementById('txtalias').value= document.getElementById('txtalias').value.toUpperCase();
   if(document.getElementById('txtpri').style.display=="none")
   {
    //document.getElementById('btnSave').focus();
   }
}
/*function uppercase3()
		{
		    if(document.getElementById('txtadsubcatname').value!="")
                {
                // document.getElementById('txtadsubcatname').value=document.getElementById('txtadsubcatname').value.toUpperCase();
	            document.getElementById('txtalias').value=document.getElementById('txtadsubcatname').value;
	           var catcode=document.getElementById('drpadvcatcode').value;
		        str=document.getElementById('txtadsubcatname').value;
		        adsubcat1.chksubcatcode(str,catcode,fillcall);
		        return false;
                }
		     return false;
		
}*/

    function fillcall(res)
    {
		    var ds=res.value;
    		
		    var newstr;
    		
		        if(ds.Tables[0].Rows.length!=0)
		        {
		            document.getElementById('txtalias').value="";
		            document.getElementById('txtadsubcatname').value="";
		            alert("This SubCategory Name has already been assigned !! ");
		            document.getElementById('txtadsubcatname').focus();
		            return false;
		        }
		        else
		        {
                        if(ds.Tables[1].Rows.length==0)
                        {
                            newstr=null;
                        }
                        else
                        {
                            newstr=ds.Tables[1].Rows[0].Adv_Subcat_Code;
                        }

                        if(newstr !=null )
                        {
                            var code=newstr;//.substr(2,4);
                            code++;
                            str=str.toUpperCase();
                            document.getElementById('txtsubcatcode').value=str.substr(0,2)+ code;
                        }
                        else
                        {
                            str=str.toUpperCase();
                            document.getElementById('txtsubcatcode').value=str.substr(0,2)+ "0";
                            document.getElementById('txtalias').focus();
                        }
		          }
    		    
	    return false;
    }
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtsubcatcode').disabled=false;
        document.getElementById('txtadsubcatname').value=trim(document.getElementById('txtadsubcatname').value.toUpperCase());
        document.getElementById('txtalias').value=document.getElementById('txtadsubcatname').value;
        auto=document.getElementById('hiddenauto').value;
        document.getElementById('txtalias').focus();
         return false;
        }

return false;
}
	
	
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

function subcatmodify(res)
{
    var ds=res.value;
		
    if(ds.Tables[0].Rows.length>0)
    {
        document.getElementById('txtadsubcatname').value="";
        alert("This SubCategory Name has already been assigned !! ");

        document.getElementById('txtadsubcatname').focus();



        return false;
    }
    
    savemodify();      
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

function clearadsub1() {
    canceladsubcat('adsubcat1');
    givebuttonpermission('adsubcat1');
}



function keycalling(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13) {
        if (document.activeElement.id == "drpadvcatcode") {
            document.getElementById("txtadsubcatname").focus();
            return false;

        }
        if (document.activeElement.id == "txtsubcatcode") {
            document.getElementById("txtadsubcatname").focus();
            return false;

        }
        if (document.activeElement.id == "txtadsubcatname") {
            document.getElementById("txtalias").focus();
            return false;

        }


        if (document.activeElement.id == "txtalias") {
            document.getElementById("txtimagename").focus();
            return false;

        }

        if (document.activeElement.id == "txtimagename") {
            document.getElementById("drpstatus").focus();
            return false;

        }

       

       
        if (document.activeElement.id == "drpstatus") {
            document.getElementById("btnSave").focus();
            return false;

        }

    }
}