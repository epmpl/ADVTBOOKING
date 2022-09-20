// JScript File


function danperr(btn)
{
    if(document.getElementById('danperm').value=='0')
    {
    return false;
    }

    if(btn=="btnNew")
    {
        if(document.getElementById('danperm').value=='14' || document.getElementById('danperm').value=='6' || document.getElementById('danperm').value=='12' || document.getElementById('danperm').value=='4' || document.getElementById('danperm').value=='10' || document.getElementById('danperm').value=='2' || document.getElementById('danperm').value=='8' )
        {
            alert('you are not authorized');
            return false;
        }
    }
    if(btn=="btnModify")
    {
        if(document.getElementById('danperm').value=='13' || document.getElementById('danperm').value=='5' || document.getElementById('danperm').value=='9' || document.getElementById('danperm').value=='1' || document.getElementById('danperm').value=='12' || document.getElementById('danperm').value=='4' || document.getElementById('danperm').value=='8' )
        {
            alert('you are not authorized');
            return false;
        }
    }
    if(btn=="btnDelete")
    {
        if(document.getElementById('danperm').value=='11' || document.getElementById('danperm').value=='3' || document.getElementById('danperm').value=='9' || document.getElementById('danperm').value=='1' || document.getElementById('danperm').value=='10' || document.getElementById('danperm').value=='2' || document.getElementById('danperm').value=='8' )
        {
            alert('you are not authorized');
            return false;
        }
    }

    return true;
}
function validate_d()
{
if(validate()==true && document.getElementById('GridView1') != null)
    return confirm('Are you sure you want to delete?');
else
    return false;
}
function validate()
{
    if(document.getElementById("txtFromDate").value=="")
    {
        alert("Please enter From Date");
        document.getElementById("txtFromDate").focus();
        return false;
    }
    
    if(document.getElementById("txtToDate").value=="")
    {
        alert("Please enter To Date");
        document.getElementById("txtToDate").focus();
        return false;
    }
    
    if(document.getElementById("drpForm").value=="0")
    {
        alert("Please Select Form");
        document.getElementById("drpForm").focus();
        return false;
    }

    var dateformat=document.getElementById("hiddendateformat").value;
    var fDate="";
    var tDate="";
    if(dateformat=="yyyy/mm/dd")
    {
        var input=document.getElementById("txtFromDate");
        var yearfield=input.value.split("/")[0];
        var monthfield=input.value.split("/")[1];
        var dayfield=input.value.split("/")[2];
        fDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="mm/dd/yyyy")
    {
        var input=document.getElementById("txtFromDate");
        var yearfield=input.value.split("/")[2];
        var monthfield=input.value.split("/")[0];
        var dayfield=input.value.split("/")[1];
        fDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="dd/mm/yyyy")
    {
        var input=document.getElementById("txtFromDate");
        var yearfield=input.value.split("/")[2];
        var monthfield=input.value.split("/")[1];
        var dayfield=input.value.split("/")[0];
        fDate= monthfield+"/"+dayfield+"/"+yearfield;
    }
    
    ///////////////////To Date
    if(dateformat=="yyyy/mm/dd")
    {
        var input=document.getElementById("txtToDate");
        var yearfield=input.value.split("/")[0];
        var monthfield=input.value.split("/")[1];
        var dayfield=input.value.split("/")[2];
        tDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="mm/dd/yyyy")
    {
        var input=document.getElementById("txtToDate");
        var yearfield=input.value.split("/")[2];
        var monthfield=input.value.split("/")[0];
        var dayfield=input.value.split("/")[1];
        tDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="dd/mm/yyyy")
    {
        var input=document.getElementById("txtToDate");
        var yearfield=input.value.split("/")[2];
        var monthfield=input.value.split("/")[1];
        var dayfield=input.value.split("/")[0];
        tDate= monthfield+"/"+dayfield+"/"+yearfield;
    }
    
    var fDate1=new Date(fDate);
    var tDate1=new Date(tDate);
    
    if(tDate1<fDate1)
    {
        alert("To date should be Greater than From Date");
        document.getElementById("txtToDate").focus();
        return false;
    }
    
    /*var arrformname=document.getElementById("drpForm").value.split(',');
    var formname=arrformname[0];
    if(document.getElementById("drpForm").value=="ALL")
    {
        //window.open('searchreportnew.aspx?fromdate="+fDate+"&dateto="+tDate,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
        window.open('searchreportnew.aspx?fromdate='+document.getElementById("txtFromDate").value+'&dateto='+document.getElementById("txtToDate").value,'Ankur2', 'width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
    }
    else
    {
        window.open("Log/"+formname+"?fdate="+document.getElementById("txtFromDate").value+"&tdate="+document.getElementById("txtToDate").value,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
    } */   
    return true;
}
function checkprocess()
{
    if(document.getElementById("drpForm").value =="Ad Account Receipt" || document.getElementById("drpForm").value =="Classified Ad Booking" || document.getElementById("drpForm").value =="Display Ad Booking")
    {
     document.getElementById("txtbookid").disabled=false;
    }
    else
    {
    document.getElementById("txtbookid").value="";
     document.getElementById("txtbookid").disabled=true;
    }
}
function deletelog()
{
    var dateformat=document.getElementById("hiddendateformat").value;
    var fDate="";
    var tDate="";
    
    if(document.getElementById("txtFromDate").value=="")
    {
        alert("Please enter From Date");
        document.getElementById("txtFromDate").focus();
        return false;
    }
    
    if(document.getElementById("txtToDate").value=="")
    {
        alert("Please enter To Date");
        document.getElementById("txtToDate").focus();
        return false;
    }
    
    if(document.getElementById("drpForm").value=="0")
    {
        alert("Please Select Form");
        document.getElementById("drpForm").focus();
        return false;
    }
    
    if(dateformat=="yyyy/mm/dd")
    {
        var input=document.getElementById("txtFromDate");
        var yearfield=input.value.split("/")[0];
        var monthfield=input.value.split("/")[1];
        var dayfield=input.value.split("/")[2];
        fDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="mm/dd/yyyy")
    {
        var input=document.getElementById("txtFromDate");
        var yearfield=input.value.split("/")[2];
        var monthfield=input.value.split("/")[0];
        var dayfield=input.value.split("/")[1];
        fDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="dd/mm/yyyy")
    {
        var input=document.getElementById("txtFromDate");
        var yearfield=input.value.split("/")[2];
        var monthfield=input.value.split("/")[1];
        var dayfield=input.value.split("/")[0];
        fDate= monthfield+"/"+dayfield+"/"+yearfield;
    }
    
    ///////////////////To Date
    if(dateformat=="yyyy/mm/dd")
    {
        var input=document.getElementById("txtToDate");
        var yearfield=input.value.split("/")[0];
        var monthfield=input.value.split("/")[1];
        var dayfield=input.value.split("/")[2];
        tDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="mm/dd/yyyy")
    {
        var input=document.getElementById("txtToDate");
        var yearfield=input.value.split("/")[2];
        var monthfield=input.value.split("/")[0];
        var dayfield=input.value.split("/")[1];
        tDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="dd/mm/yyyy")
    {
        var input=document.getElementById("txtToDate");
        var yearfield=input.value.split("/")[2];
        var monthfield=input.value.split("/")[1];
        var dayfield=input.value.split("/")[0];
        tDate= monthfield+"/"+dayfield+"/"+yearfield;
    }
    
    var fDate1=new Date(fDate);
    var tDate1=new Date(tDate);
    
    if(tDate1<fDate1)
    {
        alert("To date should be Greater than From Date");
        document.getElementById("txtToDate").focus();
        return false;
    }
    
    var arrformname=document.getElementById("drpForm").value.split(',');
    var tablename=arrformname[1];
    if(confirm("Do you want to Delete Logs"))
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
reportlog.deletelog(fDate,tDate,tablename);
        alert("Data Deleted Successfully");
        document.getElementById("drpForm").value="0";
        document.getElementById("txtToDate").value="";
        document.getElementById("txtFromDate").value="";
        return false;
    }
    return false;
}

function ClientisNumber(event)
{
	if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode>=96 && event.keyCode<=105)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13)|| (event.keyCode==8) ||(event.keyCode==47)||(event.keyCode==191)||(event.keyCode==46)||(event.keyCode==37)||(event.keyCode==39)||(event.keyCode==111))
	{
		
		return true;
	}
	else
	{
		return false;
	}
	
}


function givebuttonpermission(formname)
{
    var browser=navigator.appName;
    var id;
    
     if(browser!="Microsoft Internet Explorer")
    {
        var  httpRequest =null;
        httpRequest= new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
        httpRequest.overrideMimeType('text/xml'); 
        }
        
        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

        httpRequest.open( "GET","button.aspx?page="+formname, false );
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) 
        {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) 
            {
                id=httpRequest.responseText;   
            }
            else 
            {
                alert('There was a problem with the request.');
            }
        }
    }
    else
    {
        var page;
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open( "GET","button.aspx?page="+formname, false );
        xml.Send();
        id=xml.responseText;
    }  
    document.getElementById('danperm').value=id;
    if(id!=0)
	{
	    if(id=="0"||id=="8")
		{			
			//FlagStatus = 0;
			
			document.getElementById('btnDelete').disabled=true;
			
			
		
			window.location.href = 'EnterPage.aspx';
			alert("You Are Not Authorised To See This Form");
			//FlagStatus = 0;
			window.close();
			//return false;
					
		}
		if(id=="1"||id=="9")
		{
			
			document.getElementById('btnDelete').disabled=true;
				
			//FlagStatus = 1;
			//return false;
		}
		if(id=="2"||id=="10")
		{	
			document.getElementById('btnDelete').disabled=true;
			
		}
		if(id=="3"||id=="11")
		{
			document.getElementById('btnDelete').disabled=true;
		}
		if(id=="4"||id=="12" )
		{
			document.getElementById('btnDelete').disabled=false;
		}
		if(id=="5" ||id=="13")
		{
			document.getElementById('btnDelete').disabled=false;
		}
		if(id=="6"||id=="14")
		{
			document.getElementById('btnDelete').disabled=false;
		}
		if(id=="7"||id=="15")
		{
			document.getElementById('btnDelete').disabled=false;
		}
	}
	else
	{
		alert("You are not Authorized.");
		window.close();
		return false;
	}
}


function exitform()
{
    if(confirm("Do you want to skip this page"))
    {
        window.close();
    }
    return false;
}
function tabvalue12(event,id)
{
var browser=navigator.appName;
if(browser!="Microsoft Internet Explorer")
 {
        if(event.which==13)
        {
        if(document.activeElement.id==id)
        {
            if(document.getElementById('BtnRun').disabled==false)
            {
        document.getElementById('BtnRun').focus();
            }
        return;

        }
        else
        {
        //alert(event.keyCode);
        event.which=9;
        //alert(event.keyCode);
        return event.which;
        }
        }
 }       
else
{
     if(event.keyCode==13)
        {
            if(document.activeElement.id==id)
            {
                if(document.getElementById('BtnRun').disabled==false)
                {
            document.getElementById('BtnRun').focus();
                }
            return;

            }
            else
            {
            //alert(event.keyCode);
            event.keyCode=9;
            //alert(event.keyCode);
            return event.keyCode;
            }
        }
        
        if(event.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
}

}

