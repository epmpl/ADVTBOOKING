// JScript File
var browser=navigator.appName;

function exitclick()
{
    if(confirm("Do you want to close this page ?"))
    {
        window.close();
        return false;
    }
    return false;
}


function cancelClick()
 {
    hiddentext="cancel";
    document.getElementById('btnExit').disabled=false;			
	document.getElementById('btnAdView').disabled=true;					
	document.getElementById('btnQuery').disabled=false;		
	
	document.getElementById('PubDate').value="";
	document.getElementById('PubDate').disabled=true;	
	document.getElementById('ddlPublication').value="0";
	document.getElementById('ddlCenter').value="0";
	document.getElementById('ddlEdition').value="0";			
	document.getElementById('ddlSupplement').value="0";	
	document.getElementById('txtPage').value="";	
		
    document.getElementById('ddlPublication').disabled=true;
    document.getElementById('ddlCenter').disabled=true;
    document.getElementById('ddlEdition').disabled=true;					
	document.getElementById('ddlSupplement').disabled=true;	
	document.getElementById('txtPage').disabled=true;	
	
	if(document.getElementById('GridView1') !=null)	
	  document.getElementById('GridView1').style.visibility="hidden";
	document.getElementById('btnQuery').focus();
	setButtonImagesIssue();
	return false;
 }
 
 
 function queryclick()
{
    show="0";
    hiddentext="query";
    z=0;
    
    document.getElementById('hiddenstatuslabel').value="show";
    document.getElementById('ddlPublication').disabled=false;
    document.getElementById('ddlCenter').disabled=false;
    document.getElementById('ddlEdition').disabled=false;
    document.getElementById('ddlSupplement').disabled=false;
    document.getElementById('PubDate').disabled=false;
    document.getElementById('txtPage').disabled=false;
    document.getElementById('PubDate').focus();
    
  //  document.getElementById('PubDate').value="";
   // document.getElementById('ddlPublication').value="0";
	//document.getElementById('ddlCenter').value="0";
	document.getElementById('ddlEdition').value="0";			
	document.getElementById('ddlSupplement').value="0";				
	
	document.getElementById('btnQuery').disabled=true;						
	document.getElementById('btnExit').disabled=false;
    document.getElementById('btnAdView').disabled=false;			
	setButtonImagesIssue();		
	return false;
}



function filledition()
{
    document.getElementById("ddlSupplement").options.length=1;
    document.getElementById("ddlSupplement").value="0";
    document.getElementById("ddlEdition").options.length=1;
    document.getElementById("ddlEdition").value="0";
    
    var centercode=document.getElementById('ddlCenter').value;
    var pubcode=document.getElementById('ddlPublication').value;
    var userid=document.getElementById('hiddenuserid').value;
    if(centercode=="0")
    {
        alert('Please Select Center.');
        return false;
    }
    if(pubcode=="0")
    {
       alert('Please Select Publication.');
       return false;
    }
    if(document.getElementById('PubDate').value=="")
    {
        alert("Please Select Date: ");
        document.getElementById('PubDate').focus();
        return false;
    }
    
    var res_1=adswap_publication.bind_editioncode_dt(document.getElementById('PubDate').value,centercode,userid,pubcode); //,callbind); 
    var ds=res_1.value;
    if(ds==null)
    {
        alert(res_1.error.description);
        return false;
    }
 
    if(typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var pkgitem=document.getElementById('ddlEdition');
        pkgitem.options[0]=new Option("---Select Edititon---","0");
        pkgitem.options.length = 1; 
    
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].edition_name,ds.Tables[0].Rows[i].edition_code);        
            pkgitem.options.length;
        } 
    }    
}



function fillsupp()
{
    var compcode=document.getElementById('hiddencompcode').value;    
    var editioncode=document.getElementById('ddlEdition').value; 
    //var editioncode=document.getElementById('ddlPublication').value;   
    var userid=document.getElementById('hiddenuserid').value;
    var res=adswap_publication.bind_secpubcode(compcode,userid,editioncode); //,callbindsecpubcode); 
    var ds=res.value;    
    if(ds==null)
    {
        alert(res.error.description);
        return false;
    }
     
    if(typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var pkgitem=document.getElementById('ddlSupplement');
        pkgitem.options[0]=new Option("----Select Supplement----","0");
        pkgitem.options.length = 1;
    
        for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].supplement,res.value.Tables[0].Rows[i].supp_code);        
            pkgitem.options.length;       
        } 
    }    
    return false;
}



function refreshfield()
{
    document.getElementById('ddlCenter').value="0";
    document.getElementById('ddlEdition').value="0";
    document.getElementById('ddlEdition').options.length=1;
    document.getElementById('ddlSupplement').value="0";
    document.getElementById('ddlSupplement').options.length=1;
    return false;
}

function ViewClick()
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
        alert('Session Expired ! Please Login Again.');
        window.location.href="Login.aspx";
        return false;
    }         
}
 
 
 function setButtonImagesIssue()
{
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
}

function getfilename(str)
{
    document.getElementById('hiddenbasename').value=str;
   // return false;
}
 
 function tabvalueFMU (id)
{
}
 
 function sendtocenters()
{

    var insertdate = document.getElementById('PubDate').value;
    var compcode=document.getElementById('hiddencompcode').value; 
    var pubcode=document.getElementById('ddlPublication').value;
    if(pubcode=="0")
    {  alert("Please select Publication");      return false;}
    var centercoden=document.getElementById('ddlCenter').value;
     if(centercoden=="0")
    {    alert("Please select Center");         return false;}
    var editioncode=document.getElementById('ddlEdition').value; 
     if(editioncode=="0")
    {    alert("Please select Edition");        return false;}
    var suppcode=document.getElementById('ddlSupplement').value; 
    if(suppcode=="0")
    {    alert("Please select Supplement");     return false; }
    
     var drpadtype=document.getElementById('drpadtype').value; 
    if(drpadtype=="0")
    {    alert("Please select Ad Type");     return false; }
    
    var userid=document.getElementById('hiddenuserid').value;
    
    var dataview=document.getElementById('SendGridView');
    if(dataview==null)
        return false;
    var i=document.getElementById("SendGridView").rows.length -1;
    var centercode="";
    for(j=2;j<i+2;j++)
	{
        if(j<10)
            var str="SendGridView_ctl"+0+""+j+"_CheckBox1";
        else
            var str="SendGridView_ctl"+j+"_CheckBox1";
            
        //****************2********************************
        if(document.getElementById(str).checked==true)
        {
            if(browser=="Microsoft Internet Explorer")
            {
                if(centercode=="")
                    centercode=document.getElementById('SendGridView').rows[j-1].cells[1].innerText + "~" + document.getElementById('SendGridView').rows[j-1].cells[3].innerText + "~" + document.getElementById('SendGridView').rows[j-1].cells[5].innerText + "~" + document.getElementById('SendGridView').rows[j-1].cells[7].innerText+ "~" + document.getElementById('SendGridView').rows[j-1].cells[8].innerText;
                else
                    centercode=centercode+"#"+document.getElementById('SendGridView').rows[j-1].cells[1].innerText + "~" + document.getElementById('SendGridView').rows[j-1].cells[3].innerText + "~" + document.getElementById('SendGridView').rows[j-1].cells[5].innerText+ "~" + document.getElementById('SendGridView').rows[j-1].cells[7].innerText+ "~" + document.getElementById('SendGridView').rows[j-1].cells[8].innerText;
            }
            else
            {
                if(centercode=="")
                    centercode=document.getElementById('SendGridView').rows[j-1].cells[1].textContent + "~" + document.getElementById('SendGridView').rows[j-1].cells[3].textContent + "~" + document.getElementById('SendGridView').rows[j-1].cells[5].textContent + "~" + document.getElementById('SendGridView').rows[j-1].cells[7].textContent+ "~" + document.getElementById('SendGridView').rows[j-1].cells[8].textContent;
                else
                    centercode=centercode + "#" + document.getElementById('SendGridView').rows[j-1].cells[1].textContent + "~" + document.getElementById('SendGridView').rows[j-1].cells[3].textContent + "~" + document.getElementById('SendGridView').rows[j-1].cells[5].textContent + "~" + document.getElementById('SendGridView').rows[j-1].cells[7].textContent+ "~" + document.getElementById('SendGridView').rows[j-1].cells[8].textContent;
            }
            document.getElementById(str).checked=false;
        }
	}
	if (centercode.split("#").length>1)
	{
	    alert("Please select Single Edition");
	    centercode="";
	    document.getElementById(str).checked=false;
	    return false;
	}
	
	document.getElementById("hiddenftpcenters").value=centercode;
	
    if(centercode=="")
	{
	    alert("Please select Transfer Edition");
	    return false;
	}
	
	// center selection process end
	// start for booking selection 
	var bk_allbackup = pubcode + "~" + centercoden + "~" + editioncode + "~" + suppcode;
	var extra1="";
	var extra2=drpadtype;
	var extra3="";
	var ftpcentersname = centercode.split("#");
	 var dataview1=document.getElementById('GridView1');
    if(dataview1==null)
        return false;
    var i=document.getElementById("GridView1").rows.length -1;
    var centercode="";
    for(j=2;j<i+2;j++)
	{
        if(j<10)
            var str1="GridView1_ctl"+0+""+j+"_CheckBox2";
        else
            var str1="GridView1_ctl"+j+"_CheckBox2";
            
        //****************2********************************
        if(document.getElementById(str1).checked==true)
        {
	            if(browser=="Microsoft Internet Explorer")
                {
                    var booking_id = document.getElementById('GridView1').rows[j-1].cells[1].innerText;
                    var booking_inserid = document.getElementById('GridView1').rows[j-1].cells[14].innerText
                
                    for (var k = 0; k < ftpcentersname.length; k++)
                    {
                        var transferedition = ftpcentersname[k].split("~");
                        var pripub          = transferedition[0];
                        var bkfor           = transferedition[1];
                        var editionc        = transferedition[2];
                        var secpubc         = transferedition[3];
                        var pubtypec        = transferedition[4];
                        
                        var swapedexistdata = adswap_publication.swaptransferdata(compcode,insertdate,booking_id,booking_inserid,pripub,bkfor,editionc,secpubc,pubtypec,userid ,bk_allbackup,"P","E",extra2,extra3);
                        var ds=swapedexistdata.value;    
                            if(ds.Tables[0].Rows[0].adnumber != "0")
                            {
                                alert("Ad Already swaped ");
                            }
                            else
                            {
                                adswap_publication.swaptransferdata(compcode,insertdate,booking_id,booking_inserid,pripub,bkfor,editionc,secpubc,pubtypec,userid ,bk_allbackup,"P","I",extra2,extra3);
                            }
                        pripub="";
                        bkfor="";
                        editionc="";
                        secpubc="";
                        pubtypec="";
                    }
                }
                else
                {
                        var booking_id = document.getElementById('GridView1').rows[j-1].cells[1].textContent;
                        var booking_inserid = document.getElementById('GridView1').rows[j-1].cells[14].textContent
                        
                       for (var k = 0; k < ftpcentersname.length; k++)
                        {
                            var transferedition = ftpcentersname[k].split("~");
                            var pripub          = transferedition[0];
                            var bkfor           = transferedition[1];
                            var editionc        = transferedition[2];
                            var secpubc         = transferedition[3];
                            var pubtypec        = transferedition[4];
                            
                            var swapedexistdata = adswap_publication.swaptransferdata(compcode,insertdate,booking_id,booking_inserid,pripub,bkfor,editionc,secpubc,pubtypec,userid ,bk_allbackup,"P","E",extra2,extra3);
                            var ds=swapedexistdata.value;    
                            if(ds.Tables[0].Rows[0].adnumber != "0")
                            {
                                alert("Ad Already swaped ");
                            }
                            else
                            {
                                adswap_publication.swaptransferdata(compcode,insertdate,booking_id,booking_inserid,pripub,bkfor,editionc,secpubc,pubtypec,userid ,bk_allbackup,"P","I",extra2,extra3);
                            }
                            
                            //adswap_publication.swaptransferdata(compcode,insertdate,booking_id,booking_inserid,pripub,bkfor,editionc,secpubc,pubtypec,userid,bk_allbackup,"Change Pub","I",extra2,extra3)
                            pripub="";
                            bkfor="";
                            editionc="";
                            secpubc="";
                            pubtypec="";
                        }
                }
                document.getElementById(str).checked=false;
                document.getElementById(str1).checked=false;
        }
	}
	alert("Process Completed.");
	// end booking selection 
	document.getElementById(str).checked=false;
    document.getElementById(str1).checked=false;
    
		
}
 
 
 
 function adswaprevert()
 {
        //    alert("hi");
    var sft=confirm('Are you sure to Revert This Entry');
    if(sft==true)
    {
            var insertdate = document.getElementById('PubDate').value;
            var compcode=document.getElementById('hiddencompcode').value; 
            var pubcode=document.getElementById('ddlPublication').value;
            if(pubcode=="0")
            {  alert("Please select Publication");      return false;}
            var centercoden=document.getElementById('ddlCenter').value;
             if(centercoden=="0")
            {    alert("Please select Center");         return false;}
            var editioncode=document.getElementById('ddlEdition').value; 
             if(editioncode=="0")
            {    alert("Please select Edition");        return false;}
            var suppcode=document.getElementById('ddlSupplement').value; 
            if(suppcode=="0")
            {    alert("Please select Supplement");     return false; }
            var userid=document.getElementById('hiddenuserid').value;
             var drpadtype=document.getElementById('drpadtype').value; 
            if(drpadtype=="0")
            {    alert("Please select Ad Type");     return false; }
    
            var bk_allbackup = pubcode + "~" + centercoden + "~" + editioncode + "~" + suppcode;
	        var extra1="";
	        var extra2=drpadtype;
	        var extra3="";
	        //var ftpcentersname = centercode.split("#");
	         var dataview1=document.getElementById('GridView1');
            if(dataview1==null)
                return false;
            var i=document.getElementById("GridView1").rows.length -1;
            var centercode="";
        for(j=2;j<i+2;j++)
	    {
            if(j<10)
                var str1="GridView1_ctl"+0+""+j+"_CheckBox2";
            else
                var str1="GridView1_ctl"+j+"_CheckBox2";
            
        //****************2********************************
                if(document.getElementById(str1).checked==true)
                {
	                    if(browser=="Microsoft Internet Explorer")
                        {
                                var booking_id = document.getElementById('GridView1').rows[j-1].cells[1].innerText;
                                var booking_inserid = document.getElementById('GridView1').rows[j-1].cells[14].innerText;
                        
                                var pripub=pubcode;
                                var bkfor=centercoden;
                                var editionc=editioncode;
                                var secpubc=suppcode;
                                var pubtypec="";
                        
                                var swapedexistdata = adswap_publication.swaptransferdata(compcode,insertdate,booking_id,booking_inserid,pripub,bkfor,editionc,secpubc,pubtypec,userid ,bk_allbackup,"P","DE",extra2,extra3);
                                var ds=swapedexistdata.value;    
                                    if(ds.Tables[0].Rows[0].adnumber == "0")
                                    {
                                        alert("This AD is fresh Entry you Can't Revert this Entry.");
                                    }
                                    else
                                    {
                                        adswap_publication.swaptransferdata(compcode,insertdate,booking_id,booking_inserid,pripub,bkfor,editionc,secpubc,pubtypec,userid ,bk_allbackup,"P","D",extra2,extra3);
                                    }
                        }
                        else
                        {
                                var booking_id = document.getElementById('GridView1').rows[j-1].cells[1].textContent;
                                var booking_inserid = document.getElementById('GridView1').rows[j-1].cells[14].textContent;
                              
                                var pripub=pubcode;
                                var bkfor=centercoden;
                                var editionc=editioncode;
                                var secpubc=suppcode;
                                var pubtypec="";
                              
                                var swapedexistdata = adswap_publication.swaptransferdata(compcode,insertdate,booking_id,booking_inserid,pripub,bkfor,editionc,secpubc,pubtypec,userid ,bk_allbackup,"P","DE",extra2,extra3);
                                var ds=swapedexistdata.value;    
                                    if(ds.Tables[0].Rows[0].adnumber == "0")
                                    {
                                        alert("This AD is fresh Entry you Can't Revert this Entry.");
                                    }
                                    else
                                    {
                                        adswap_publication.swaptransferdata(compcode,insertdate,booking_id,booking_inserid,pripub,bkfor,editionc,secpubc,pubtypec,userid ,bk_allbackup,"P","D",extra2,extra3);
                                    }
                        }
                        //document.getElementById(str).checked=false;
                        document.getElementById(str1).checked=false;
                }
	    } // for end
    }               // if end
    else
    {
        return false;
    }
    alert("Process Completed.");
 }
 
 
 
 