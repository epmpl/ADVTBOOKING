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
var danout = "";
var mycenter = 0
function uploadfile() {
    document.getElementById('hiddenfilename').value = "";
    var dataview = document.getElementById('GridView1');
    if (dataview == null)
        return false;
    var i = document.getElementById("GridView1").rows.length - 1;
    for (j = 2; j < i + 2; j++) {
        if (j == (i + 2))
            break;
//        if (j < 10)
//            var str = "GridView1";
//        else
        //            var str = "GridView1_ctl" + j + "_CheckBox1_filename";
       // alert("bhanu");
       // alert("bhanu" + dataview.rows[j - 1].childNodes[1].childNodes[1].checked + ' ' + dataview.rows[j - 1].cells[12].textContent);
        if (browser != "Microsoft Internet Explorer") {
            if (dataview.rows[j - 1].childNodes[1].childNodes[1].checked == true) {
                document.getElementById('hiddenfilename').value = dataview.rows[j - 1].cells[12].textContent;
                break;
            }
        }
        else {
            if (dataview.rows[j - 1].childNodes[0].childNodes[0].checked == true) {
                document.getElementById('hiddenfilename').value = dataview.rows[j - 1].childNodes[12].innerText;
                break;
            }
        }
    }
    danout = "d1"
    if (document.getElementById("myFile").value.length < 2) {
        alert("Please select a file");
        return false;
    }
    copyLocally();
    return false;
}
function copyLocally(ffname) {
    if (document.getElementById('PubDate').value == "") {
        alert('Select PubDate:');
        document.getElementById('PubDate').focus();
        return false;
    }

    var ddate = document.getElementById('PubDate').value.split("/");
    var cdatefolder = ddate[0] + ddate[1] + ddate[2];

    var res1 =CD_Upload.get_center_ip(document.getElementById('hiddenlogincenter').value);
    var ds_ip = res1.value;
    if (ds_ip == null) {
        alert(res1.error.description);
        return false;
    }
    if (ds_ip.Tables[0].Rows.length == 0) {
        alert('Default publish master is not configured.');
        return false;
    }

    var adpicpath = "\\\\" + ds_ip.Tables[0].Rows[0].center_ip.replace("\\", "") + "\\" + document.getElementById('hiddenAdPicPath').value + cdatefolder + "\\";

    var postedfile = ffname;
    var basename = document.getElementById('hiddenfilename').value;
    var splitaliddate = document.getElementById('PubDate').value.split("/");
    if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
        curr_date = splitaliddate[1];
        curr_month = splitaliddate[0];
        curr_year = splitaliddate[2];
    }
    else if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
        curr_date = splitaliddate[0];
        curr_month = splitaliddate[1];
        curr_year = splitaliddate[2];
    }
    else if (document.getElementById('hiddendateformat').value = "yyyy/mm/dd") {
        curr_date = splitaliddate[2];
        curr_month = splitaliddate[1];
        curr_year = splitaliddate[0];
    }


    var act = "http://" + "192.168.5.37" + "/akhil/uploadfile.php?mycenter=" + mycenter + "&filename=" + basename + "&date1=" + curr_date + curr_month + curr_year + "&urlreturn="
    //alert(act);
   // alert(document.forms[0]);
    fileUpload(document.forms[0], act, basename);
    //manageFile(postedfile,adpicpath,basename+"."+extensionname,basename);     
    return false;
}
var kld = 0;
//added by danish to save from php
function fileUpload(form, action_url, basename) {
    // Create the iframe...
    var iframe = document.createElement("iframe");
    iframe.setAttribute("id", "upload_iframe");
    iframe.setAttribute("name", "upload_iframe");
    iframe.setAttribute("width", "0");
    iframe.setAttribute("height", "0");
    iframe.setAttribute("border", "0");
    iframe.setAttribute("style", "width: 0; height: 0; border: none;");
    kld = 0;
   
    // Add to document...
    form.parentNode.appendChild(iframe);
    window.frames['upload_iframe'].name = "upload_iframe";

    org_filename = document.getElementById("myFile").value.substring(document.getElementById("myFile").value.lastIndexOf("\\") + 1);
    //alert(org_filename);
    iframeId = document.getElementById("upload_iframe");

    // Add event...
  //  alert(iframeId.contentWindow.document.body.innerHTML);
    var eventHandler = function() {
        if (iframeId.detachEvent) iframeId.detachEvent("onload", eventHandler);
        else iframeId.removeEventListener("load", eventHandler, false);
        try {

            if (iframeId.contentDocument) {
                content = iframeId.contentDocument.body.innerHTML;
            } else if (iframeId.contentWindow) {

                var y = iframeId.contentWindow;
                if (y.document)
                    y = y.document;
                //content = iframeId.contentWindow.document.body.innerHTML;
                content = y.body.innerHTML;
            } else if (iframeId.document) {
                content = iframeId.document.body.innerHTML;
            }
            //alert(content);
            if (content == "File Uploaded" || content == "File Uploaded.Failed To copy on Local") {
                //alert("hiop");
                if (kld == 0) {
                    kld = 1;
                    document.getElementById("myFile").value = "";
                    CD_Upload.InsertAdMaterial(document.getElementById('PubDate').value, "", document.getElementById('hiddenlogincenter').value, "", "", basename, basename, org_filename, document.getElementById('hiddendateformat').value, document.getElementById('hiddenusername').value, document.getElementById('hiddenlogincenter').value);
                    alert("Copied successfully " + basename);
                }
            }
            else
                alert(content);
            //Run some code here
        }
        catch (err) {
            alert(err.message);
            //Handle errors here
        }

        //document.getElementById(div_id).innerHTML = content;

        // Del the iframe...
        setTimeout('iframeId.parentNode.removeChild(' + iframeId + ')', 250);
        document.location
        setTimeout('location.reload(true)', 450);
        //setTimeout("deleteiframe()", 250);
    }

    if (iframeId.addEventListener) {

        iframeId.addEventListener("load", eventHandler, true);
    }
    if (iframeId.attachEvent) {
        iframeId.attachEvent("onload", eventHandler);
    }

    // Set properties of form...
    var k = document.URL.substring(0, document.URL.lastIndexOf("/"));
    action_url = action_url + k + "/result.aspx"
    form.setAttribute("target", "upload_iframe");
    form.setAttribute("action", action_url);
    form.setAttribute("method", "post");
    form.setAttribute("enctype", "multipart/form-data");
    form.setAttribute("encoding", "multipart/form-data");
   // alert(action_url);
    // Submit the form...
    form.submit();

    //document.getElementById(div_id).innerHTML = "Uploading...";
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


function incorrectodate(input)
{
	var dateformat=document.getElementById('hiddendateformat').value;
	if(dateformat=="mm/dd/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	 
	}
	if(dateformat=="yyyy/mm/dd")
	 
	{
		var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
	}
	if(dateformat=="dd/mm/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	}

	if (!validformat.test(input.value) && (document.getElementById('hiddenolddate').value=="") )
	{	
		if(input.value=="")
		{
			return true;
		}
		alert(" Please Fill The Date In "+dateformat+" Format");	
		
		document.getElementById('PubDate').value="";
		document.getElementById('PubDate').focus();
		return false;
	}
}

function printalert(comp_code1,pubdate,pripub,pcenter,pedition,spub,iidnum,f_name,pheight,pwidth,bheight,bwidth,bcolor,postedfile,strLocalpath)
{
    var win =window.open('matterpreview.aspx?comp_code=' + comp_code1 + '&pubdate=' + pubdate + '&pripub=' + pripub + '&pcenter=' + pcenter + '&pedition=' + pedition + '&spub=' + spub + '&iidnum=' + iidnum + '&f_name=' + f_name + '&pheight=' + pheight + '&pwidth=' + pwidth + '&bheight=' + bheight + '&bwidth=' + bwidth + '&bcolor=' + bcolor + '&postedfile=' + postedfile + '&strLocalpath=' + strLocalpath,'Select','status=1,toolbar=0,resizable=0,scrollbars=no,modal=yes,top=0,left=1,width=300px,height=450px,alwaysRaised=1');
    win.focus();
    return false; 
}



function savePostedFile()
{   
    var diffht=Math.abs(parseFloat(document.getElementById('hiddenbheight').value)-parseFloat(document.getElementById('hiddenpheight').value));  
   
    var diffwd=Math.abs(parseFloat(document.getElementById('hiddenbwidth').value)-parseFloat(document.getElementById('hiddenpwidth').value));
    if(parseFloat(diffht)>.3 || parseFloat(diffwd)>.3)
    {
        var ss=confirm('Booking and Material Sizes are differ. Are you sure to accept this file?'); 
        if(ss==false)
            return false;
    }
    
}

//==================================================================================//

function cd_filledition()
{
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
    var res_1=CD_Upload.bind_editioncode(centercode,userid,pubcode); //,callbind); 
    var ds=res_1.value;
    if(ds==null)
    {
        alert(res_1.error.description);
        return false;
    }
 
    if(typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var pkgitem=document.getElementById('ddlEdition');
        pkgitem.options[0]=new Option("----Select Edititon----","0");
        pkgitem.options.length = 1; 
    
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].edition_name,ds.Tables[0].Rows[i].edition_code);        
            pkgitem.options.length;
        } 
    }
    return false;
}


function cd_fillsupplement()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var editioncode=document.getElementById('ddlEdition').value;
    var userid=document.getElementById('hiddenuserid').value;
    var res=CD_Upload.bind_secpubcode(compcode,userid,editioncode); //,callbindsecpubcode); 
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

function setButtonImagesIssue() {
    if (document.getElementById('btnExit').disabled == true)
        document.getElementById('btnExit').src = "btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src = "btimages/exit.jpg";

    if (document.getElementById('btnQuery').disabled == true)
        document.getElementById('btnQuery').src = "btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src = "btimages/query.jpg";

    if (document.getElementById('btnCancel').disabled == true)
        document.getElementById('btnCancel').src = "btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src = "btimages/clear.jpg";
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
