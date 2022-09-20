// JScript File
var glo_cat2=0;
var hiddentext;
var mod="0";
var z=0;
var name_modify="";
var glaobalpubname;
var glaobalcatname; 
var glaobalsubcatname;
var glaobalrefname;
var browser = navigator.appName;  
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
PubCatRef.fillCat2(document.getElementById('drpadcategory').value,fillCat2_callback);
    
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
function pubcatnewclick()
{
        document.getElementById('drpPubName').value=0;
        document.getElementById('drpadcategory').value=0;
        document.getElementById('drpadvcatcode').value=0;
        document.getElementById('txtname').value="";
        
         document.getElementById('drpPubName').disabled=false;
         document.getElementById('drpadcategory').disabled=false;
         document.getElementById('drpadvcatcode').disabled=false;
         document.getElementById('txtname').disabled=false;
         document.getElementById('drpPubName').focus();
         hiddentext="new";
         document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
		setButtonImages();
				return false;
}
function pubcatsaveclick()
{
    var chmandat;
document.getElementById('txtname').value=trim(document.getElementById('txtname').value);
    if(document.getElementById('drpPubName').options.length=="0" || document.getElementById('drpPubName').value=="0")
              {
              alert("Please Select Publication ");
              document.getElementById('drpPubName').focus();
              return false;
              }
    if(document.getElementById('drpadcategory').options.length=="0" || document.getElementById('drpadcategory').value=="0")
              {
              alert("Please Select Category ");
              if(document.getElementById('drpadcategory').disabled==false)
              document.getElementById('drpadcategory').focus();
              return false;
              }
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat = document.getElementById('lbsubcat').textContent;
        }
        else
        {
            chmandat = document.getElementById('lbsubcat').innerText;
        }
        if (chmandat.indexOf('*') >= 0) {
            if (document.getElementById('drpadvcatcode').value == "0" || document.getElementById('drpadvcatcode').value == "") {
                alert("Please Select Sub Category");
                if (document.getElementById('drpadvcatcode').disabled == false)
                    document.getElementById('drpadvcatcode').focus();
                return false;
            }
        }
        if(document.getElementById('txtname').value=="")
            {
            alert("Please Select Name");
            document.getElementById('txtname').focus();
            return false;
            }
    var compcode=document.getElementById('hiddencompcode').value;
    var pubname=document.getElementById('drpPubName').value;
    var catname=document.getElementById('drpadcategory').value;
    var subcatname=document.getElementById('drpadvcatcode').value; 
    var refname=trim(document.getElementById('txtname').value);  
//code for session expire
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
//===============
var res=PubCatRef.chkname(compcode,pubname,catname,subcatname,refname);
ds=res.value;

    if(mod !="1")
    {
        if(ds.Tables[0].Rows.length !=0)
        {
        alert("This name is already assign");
        document.getElementById('txtname').value="";
        document.getElementById('txtname').focus();
        return false;
        }
        else
        {
        call_saveclick();
        return false;
        }
    }
    else
    {
        if(name_modify==document.getElementById('txtname').value)
			    {
			        updatepubcat();
			    }
        else
        {
            if(ds.Tables[0].Rows.length > 1)
            {
            alert("This name is already assign");
            document.getElementById('txtname').value="";
            document.getElementById('txtname').focus();
            return false;
            }
            else
            updatepubcat();
        }
    return false;
    }
 }
function  updatepubcat()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var pubname=document.getElementById('drpPubName').value;
    var catname=document.getElementById('drpadcategory').value;
    var subcatname=document.getElementById('drpadvcatcode').value;
    var refname = trim(document.getElementById('txtname').value.toUpperCase()); 
    
    PubCatRef.pubcatmodify(compcode,pubname,catname,subcatname,refname);
            dscatexecute.Tables[0].Rows[z].PUBLICATION=document.getElementById('drpPubName').value;
			dscatexecute.Tables[0].Rows[z].CAT1=document.getElementById('drpadcategory').value;
			dscatexecute.Tables[0].Rows[z].CAT2=document.getElementById('drpadvcatcode').value;
			dscatexecute.Tables[0].Rows[z].CATNAME=document.getElementById('txtname').value;
			
    alert("Data Updated Successfully");
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

         document.getElementById('drpPubName').disabled=true;
         document.getElementById('drpadcategory').disabled=true;
         document.getElementById('drpadvcatcode').disabled=true;
         document.getElementById('txtname').disabled=true;
         setButtonImages();
			 if(document.getElementById('btnModify').disabled==false)      
	          document.getElementById('btnModify').focus();
	mod="0";
			glo_cat2=0;
			return false;
}

function call_saveclick(response)
{

    var compcode=document.getElementById('hiddencompcode').value;
    var pubname=document.getElementById('drpPubName').value;
    var catname=document.getElementById('drpadcategory').value;
    var subcatname=document.getElementById('drpadvcatcode').value;
    var refname = trim(document.getElementById('txtname').value).toUpperCase(); 
    
    PubCatRef.pubcatsave(compcode,pubname,catname,subcatname,refname);
    alert("Data Saved Successfully");
            document.getElementById('drpPubName').value=0;
            document.getElementById('drpadcategory').value=0;
            document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtname').value="";
            
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
			
			pubcatcancelclick('PubCatRef');
			return false;
}
function pubcatmodifyclick()
{
     mod="1";
	 hiddentext="mod";	
    glo_cat2=0;
	document.getElementById('btnQuery').disabled = true;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnModify').disabled=false;
	document.getElementById('btnSave').disabled = false;
	document.getElementById('btnSave').focus();
	
	name_modify=document.getElementById('txtname').value;
	    chkstatus(FlagStatus);
	    document.getElementById('drpPubName').disabled=true;
         document.getElementById('drpadcategory').disabled=true;
         document.getElementById('drpadvcatcode').disabled=true;
         document.getElementById('txtname').disabled=false;
    setButtonImages();
return false;
}
function pubcatqueryclick()
{
    document.getElementById('drpPubName').value=0;
    document.getElementById('drpadcategory').value=0;
    document.getElementById('drpadvcatcode').value=0;
    document.getElementById('drpadvcatcode').options.length="0" 
    document.getElementById('txtname').value="";
    z=0;
    document.getElementById('drpPubName').disabled=false;
     document.getElementById('drpadcategory').disabled=false;
     document.getElementById('drpadvcatcode').disabled=false;
     document.getElementById('txtname').disabled=false;
     
    document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
				hiddentext="query";
		setButtonImages();				
	document.getElementById('btnExecute').focus();
return false;
}
function pubcatexecuteclick()
{
z=0;
    var compcode=document.getElementById('hiddencompcode').value;
    var pubname=document.getElementById('drpPubName').value;
    glaobalpubname=pubname;
    var catname=document.getElementById('drpadcategory').value;
    glaobalcatname=catname;
    var subcatname=document.getElementById('drpadvcatcode').value; 
    glaobalsubcatname=subcatname;
    var refname = trim(document.getElementById('txtname').value.toUpperCase()); 
    glaobalrefname=refname;
    
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
PubCatRef.pubcatexecute(compcode,pubname,catname,subcatname,refname,callexec);
    updateStatus();
    
    document.getElementById('drpPubName').disabled=true;
     document.getElementById('drpadcategory').disabled=true;
     document.getElementById('drpadvcatcode').disabled=true;
     document.getElementById('txtname').disabled = true;
     //document.getElementById('btnModify').disabled = false;
     
    mod="0";
			            document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;
						document.getElementById('btnlast').disabled = false;
						document.getElementById('btnModify').disabled = false;
						document.getElementById('btnDelete').disabled = false;
     
						
						
					    if(document.getElementById('btnModify').disabled==false)
			                document.getElementById('btnModify').focus();
			return false;
    
}
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function callexec(response)
{
    var ds=response.value;
	dscatexecute=response.value;
	    if(dscatexecute.Tables[0].Rows.length > 0)
	    {
	        glo_cat2=dscatexecute.Tables[0].Rows[0].CAT2;
			 	document.getElementById('drpPubName').value=dscatexecute.Tables[0].Rows[0].PUBLICATION;
				document.getElementById('drpadcategory').value=dscatexecute.Tables[0].Rows[0].CAT1;
				bindcat2(dscatexecute.Tables[0].Rows[0].CAT1);
				document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].CAT2;
				document.getElementById('txtname').value=dscatexecute.Tables[0].Rows[0].CATNAME;
				
				document.getElementById('drpPubName').disabled=true;
                document.getElementById('drpadcategory').disabled=true;
                document.getElementById('drpadvcatcode').disabled=true;
                document.getElementById('txtname').disabled=true;
	    }
	    else
	    {
	        alert("Your Search Produce No Result!!!!");
			pubcatcancelclick('Adsubcat3');
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
function pubcatfirstclick()
{
glo_cat2=dscatexecute.Tables[0].Rows[0].CAT2;
			 	document.getElementById('drpPubName').value=dscatexecute.Tables[0].Rows[0].PUBLICATION;
				document.getElementById('drpadcategory').value=dscatexecute.Tables[0].Rows[0].CAT1;
				bindcat2(dscatexecute.Tables[0].Rows[0].CAT1);
				document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].CAT2;
				document.getElementById('txtname').value=dscatexecute.Tables[0].Rows[0].CATNAME;
				
				z=0;
			updateStatus();

		document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
		//fillAdCat1();
		setButtonImages();
			return false;
}
function pubcatpreviousclick()
{
var a=dscatexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
			    glo_cat2=dscatexecute.Tables[0].Rows[z].CAT2;
		 	document.getElementById('drpPubName').value=dscatexecute.Tables[0].Rows[z].PUBLICATION;
			document.getElementById('drpadcategory').value=dscatexecute.Tables[0].Rows[z].CAT1;
			bindcat2(dscatexecute.Tables[0].Rows[z].CAT1);
			document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].CAT2;
			document.getElementById('txtname').value=dscatexecute.Tables[0].Rows[z].CATNAME;
			updateStatus();
					document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
				//fillAdCat1();
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
function pubcatnextclick()
{
var a=dscatexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
		 glo_cat2=dscatexecute.Tables[0].Rows[z].CAT2;
		 	document.getElementById('drpPubName').value=dscatexecute.Tables[0].Rows[z].PUBLICATION;
			document.getElementById('drpadcategory').value=dscatexecute.Tables[0].Rows[z].CAT1;
			bindcat2(dscatexecute.Tables[0].Rows[z].CAT1);
			document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].CAT2;
			document.getElementById('txtname').value=dscatexecute.Tables[0].Rows[z].CATNAME;
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			//fillAdCat1();
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
function pubcatlastclick()
{
var y=dscatexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			glo_cat2=dscatexecute.Tables[0].Rows[z].CAT2;
		 	document.getElementById('drpPubName').value=dscatexecute.Tables[0].Rows[z].PUBLICATION;
			document.getElementById('drpadcategory').value=dscatexecute.Tables[0].Rows[z].CAT1;
			bindcat2(dscatexecute.Tables[0].Rows[z].CAT1);
			document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].CAT2;
			document.getElementById('txtname').value=dscatexecute.Tables[0].Rows[z].CATNAME;
			
			updateStatus();
			//fillAdCat1();
		      document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
			return false;
}
function pubcatexitclick()
{
//if(confirm("Do You Want To Skip This Page"))
			//{
				window.close();
				return false;
			//}
			//return false;
}
function pubcatdeleteclick()
{
    updateStatus();
    var compcode=document.getElementById('hiddencompcode').value;
    var pubname=document.getElementById('drpPubName').value;
    var catname=document.getElementById('drpadcategory').value;
    var subcatname=document.getElementById('drpadvcatcode').value; 
    var refname=trim(document.getElementById('txtname').value); 
    
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
       PubCatRef.pubcatdelete(compcode, pubname, catname, subcatname);

			alert ("Data Deleted Successfully");
			document.getElementById('drpPubName').value=0;
            document.getElementById('drpadcategory').value=0;
            document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtname').value="";
		

		       PubCatRef.pubcatexecute(compcode,glaobalpubname, glaobalcatname, glaobalsubcatname, glaobalrefname,delcall);
		     }
		     return false;
}
function delcall(res)
{
 dscatexecute1= res.value;
	len=dscatexecute1.Tables[0].Rows.length;
	
	if(dscatexecute1.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('drpPubName').value=0;
            document.getElementById('drpadcategory').value=0;
            document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtname').value="";
		 pubcatcancelclick('PubCatRef');
		return false;
	}
	        else if(z>=len || z==-1)
	        {
			 glo_cat2=dscatexecute1.Tables[0].Rows[0].CAT2;
			 	document.getElementById('drpPubName').value=dscatexecute1.Tables[0].Rows[0].PUBLICATION;
				document.getElementById('drpadcategory').value=dscatexecute1.Tables[0].Rows[0].CAT1;
				bindcat2(dscatexecute1.Tables[0].Rows[0].CAT1);
				document.getElementById('drpadvcatcode').value=dscatexecute1.Tables[0].Rows[0].CAT2;
				document.getElementById('txtname').value=dscatexecute1.Tables[0].Rows[0].CATNAME;
        			
	        }
	        else
	        {
	         glo_cat2=dscatexecute1.Tables[0].Rows[0].CAT2;
			 	document.getElementById('drpPubName').value=dscatexecute1.Tables[0].Rows[z].PUBLICATION;
				document.getElementById('drpadcategory').value=dscatexecute1.Tables[0].Rows[z].CAT1;
				bindcat2(dscatexecute1.Tables[0].Rows[0].CAT1);
				document.getElementById('drpadvcatcode').value=dscatexecute1.Tables[0].Rows[z].CAT2;
				document.getElementById('txtname').value=dscatexecute1.Tables[0].Rows[z].CATNAME;;
	        }
		if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dscatexecute1.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       
            if(dscatexecute1.Tables[0].Rows.length ==1)
			{
		        document.getElementById('btnfirst').disabled=true;				
		       document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnprevious').disabled=true;			
		       document.getElementById('btnlast').disabled=true;
			}
	setButtonImages();
return false;
}
function pubcatcancelclick()
{
        document.getElementById('drpPubName').value=0;
        document.getElementById('drpadcategory').value=0;
        document.getElementById('drpadvcatcode').value=0;
        document.getElementById('drpadvcatcode').options.length="0" 
        document.getElementById('txtname').value="";
        glo_cat2=0;
         document.getElementById('drpPubName').disabled=true;
         document.getElementById('drpadcategory').disabled=true;
         document.getElementById('drpadvcatcode').disabled=true;
         document.getElementById('txtname').disabled=true;
         
         document.getElementById('btnModify').disabled=true;
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				
				mod="0";
				
					//chkstatus(FlagStatus);
					
					
					
					if(document.getElementById('btnNew').disabled==false)
					{
					   
						document.getElementById('btnNew').focus();
					}
						
					else
					{
						document.getElementById('btnNew').disabled=false;
						document.getElementById('btnNew').focus();
						
					}
					//givebuttonpermission(formname);
					setButtonImages();
				return false;
}
//=========function to change image of buttons
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
function bindcat2(cat1)
{
var res2=PubCatRef.fillCat2(cat1);
ds1=res2.value;
var pkgitem = document.getElementById("drpadvcatcode");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Sub Category--","0");
for (var i = 0  ; i < ds1.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds1.Tables[0].Rows[i].Adv_Subcat_Name,ds1.Tables[0].Rows[i].Adv_Subcat_Code);
        
       pkgitem.options.length;   
    }
}