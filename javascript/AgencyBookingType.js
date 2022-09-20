// javascript//
/////////////////Function for tabvalue////////////////
function tabvalue1(event)
{
var browser=navigator.appName;
 if(event.keyCode==113)  
    {
           
        if(document.activeElement.id=="txtagency1")
        {
            if(document.getElementById('txtagency1').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtagency1').value="";
            return false;
            }
            document.getElementById("div1").style.display="block";
        
            if(browser != "Microsoft Internet Explorer")
            {
                  document.getElementById('div1').style.top= 120;
                  document.getElementById('div1').style.left= 290;
//                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency1').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/(-6) + "px";
//                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency1').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                  document.getElementById('div1').style.top= 112;
                  document.getElementById('div1').style.left= 568;
//                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency1').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
//                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency1').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }
            AgencyBookingType.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtagency1').value.toUpperCase(),bindagencyname_callback);
        
        }
    }
    
else if(event.keyCode==27)
    {
    if(document.getElementById("div1").style.display=="block")
        {
            document.getElementById("div1").style.display="none"
            document.getElementById('txtagency1').focus();
        }
    
    }
   else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
    {
      
        if(document.activeElement.id=="lstagency")
        {
            if(document.getElementById('lstagency').value=="0" )
            {
                alert("Please select the agency sub code");
                return false;
            }
            document.getElementById("div1").style.display="none";
            var datetime="";
            var page=document.getElementById('lstagency').value;
            //document.getElementById('hiddenagency').value=page;
        
            agencycodeglo=page;
        
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                }
            
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
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
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
                xml.Send();
                id=xml.responseText;
            }
            var split=id.split("+");
            var nameagen=split[0];
            var agenadd=split[1];
        
            document.getElementById('txtagency1').value=nameagen;
           /* if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
            {
                document.getElementById('txtagency1address').value=agenadd;                
                document.getElementById('txtclient1').focus();
                Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
            }*/
            document.getElementById('txtagency1').focus();
            return false;
        }
    //else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.id=="LinkButton1" || document.activeElement.id=="LinkButton2" || document.activeElement.id=="LinkButton3" || document.activeElement.id=="LinkButton4" || document.activeElement.id=="LinkButton5")
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
            event.keyCode=13;
            return event.keyCode;
        }
        else
        {
            var idcursor;
            if(event.shiftKey==false)
            {
                event.keyCode=9;                     
                return event.keyCode;
            }    
        }
    }
}
function bindagencyname_callback(response)
{       
    ds=response.value;
    //document.getElementById('drpretainer').value="";
    var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name +'+'+ds.Tables[0].Rows[i].CITYNAME,ds.Tables[0].Rows[i].code_subcode);        
            pkgitem.options.length;       
        }
    }
    document.getElementById('txtagency1').value="";
    document.getElementById("lstagency").value="0";
    document.getElementById("lstagency").focus();
    return false;
}
function savebooktype()
{
    if(document.getElementById('drpbooktype').value =="0" ||document.getElementById('drpbooktype').value =="")
    {
    alert("Please select Booking Type.")
    document.getElementById('drpbooktype').focus();
    return false;
    }
    if(document.getElementById('txtagency1').value != "" && document.getElementById('txtagency1').value.lastIndexOf('(')>=0)
        {
         var agency=document.getElementById('txtagency1').value ;            
	     var agencyarr=agency.split("(");             
	     var agencysplit=agencyarr[1];             
	     agencysplit=agencysplit.replace(")","");
       }
       else if(document.getElementById('txtagency1').value!="")
         {
         alert("Please select correct Agency by Pressing F2");
         document.getElementById('txtagency1').value="";
         document.getElementById('txtagency1').focus();
         return false;
         }
         else if(document.getElementById('txtagency1').value=="")
         {
         alert("Please select Agency by Pressing F2");
        // document.getElementById('selectcode').value="";
         document.getElementById('txtagency1').focus();
         return false;
         }
    if(document.getElementById('txtvalidityfrom').value =="")
    {
    alert("Please select From Date.")
    document.getElementById('txtvalidityfrom').focus();
    return false;
    }
    if(document.getElementById('txttilldate').value =="")
    {
    alert("Please select To Date.")
    document.getElementById('txttilldate').focus();
    return false;
    }
var booktyp=document.getElementById('drpbooktype').value;
var frmdate=document.getElementById('txtvalidityfrom').value;
var tdate=document.getElementById('txttilldate').value;
var dateformat=document.getElementById('hiddenDateFormat').value;
var usrid=document.getElementById('hiddenuserid').value;
var compcode=document.getElementById('hiddencompcode').value;
    var res=AgencyBookingType.chkduplicate(booktyp,agencysplit,frmdate,tdate,dateformat,compcode);
    var ds=res.value;
    if(ds.Tables[0].Rows.length > 0)
	    {
		alert("This Date is Already Assigned");
		return false;
	}
	else
	{
        AgencyBookingType.savebktype(booktyp,agencysplit,frmdate,tdate,dateformat,usrid,compcode);
        alert("Data Save Successfully");
        document.getElementById('txtvalidityfrom').value="";
        document.getElementById('txttilldate').value="";
        document.getElementById('txtagency1').value="";
    }
//return false;
}
function updatebooktype()
{
    if(document.getElementById('drpbooktype').value =="0" ||document.getElementById('drpbooktype').value =="")
    {
    alert("Please select Booking Type.")
    document.getElementById('drpbooktype').focus();
    return false;
    }
    if(document.getElementById('txtagency1').value != "" && document.getElementById('txtagency1').value.lastIndexOf('(')>=0)
        {
         var agency=document.getElementById('txtagency1').value ;            
	     var agencyarr=agency.split("(");             
	     var agencysplit=agencyarr[1];             
	     agencysplit=agencysplit.replace(")","");
       }
       else if(document.getElementById('txtagency1').value!="")
         {
         alert("Please select correct Agency by Pressing F2");
         document.getElementById('txtagency1').value="";
         document.getElementById('txtagency1').focus();
         return false;
         }
         else if(document.getElementById('txtagency1').value=="")
         {
         alert("Please select Agency by Pressing F2");
        // document.getElementById('selectcode').value="";
         document.getElementById('txtagency1').focus();
         return false;
         }
    if(document.getElementById('txtvalidityfrom').value =="")
    {
    alert("Please select From Date.")
    document.getElementById('txtvalidityfrom').focus();
    return false;
    }
    if(document.getElementById('txttilldate').value =="")
    {
    alert("Please select To Date.")
    document.getElementById('txttilldate').focus();
    return false;
    }
var booktyp=document.getElementById('drpbooktype').value;
var frmdate=document.getElementById('txtvalidityfrom').value;
var tdate=document.getElementById('txttilldate').value;
var dateformat=document.getElementById('hiddenDateFormat').value;
var usrid=document.getElementById('hiddenuserid').value;
var compcode=document.getElementById('hiddencompcode').value;
var code11= document.getElementById('hiddencode').value;
    var res=AgencyBookingType.chkdupforup(booktyp,agencysplit,frmdate,tdate,dateformat,compcode,code11);
    var ds=res.value;
    if(ds.Tables[0].Rows.length > 0)
	    {
		alert("This Date is Already Assigned");
		return false;
	}
	else
	{
        AgencyBookingType.updatebktype(booktyp,agencysplit,frmdate,tdate,dateformat,usrid,compcode,code11);
        alert("Data Update Successfully");
        document.getElementById('txtvalidityfrom').value="";
        document.getElementById('txttilldate').value="";
        document.getElementById('txtagency1').value="";
    }
//return false;
}
function delbooktype()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var code11= document.getElementById('hiddencode').value;
    AgencyBookingType.delbktype(compcode,code11);
    alert("Data Deleted Successfully");
    document.getElementById('txtvalidityfrom').value="";
    document.getElementById('txttilldate').value="";
    document.getElementById('txtagency1').value="";
}
function catexitclick1()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}
////////////////this function is called when we open the list box of agency than on mouse click it get the agency

function insertagency()
{
var browser=navigator.appName;
if(document.activeElement.id=="lstagency")
    {
    if(document.getElementById('lstagency').value=="0")// || document.getElementById('hiddensavemod').value=="01")
    {
        alert("Please select the agency code");
        return false;
    }
        document.getElementById("div1").style.display="none";
        var datetime="";
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
        var page=document.getElementById('lstagency').value;
        //document.getElementById('hiddenagency').value=page;
        agencycodeglo=page;
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
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
             var xml = new ActiveXObject("Microsoft.XMLHTTP");
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
             xml.Send();
             id=xml.responseText;
        }
          if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd=split[1];
                
        document.getElementById('txtagency1').value=nameagen;
        
        /*if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
        {
              document.getElementById('txtagency1address').value=agenadd;
                
              document.getElementById('txtclient1').focus();
              Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
        }*/
        document.getElementById('txtagency1').focus();
        return false;
    }
}
//select book Type
function selectbooktyp(ab)
{
var id=ab;
var comcode=document.getElementById('hiddencompcode').value;
if(document.getElementById(id).checked==false)
        {
            cleardata();
            return ;
        }
var datagrid=document.getElementById('DataGrid1');
var j;
var t;
var k=0;
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
 {
	var str="DataGrid1__ctl_CheckBox1"+j;
    document.getElementById(str).checked=false;
    document.getElementById(id).checked=true;
    if(id==str)
    {
	    if(document.getElementById(id).checked==true)
	    {
	    k=k+1;
	    code11=document.getElementById(id).value;
	    document.getElementById('hiddencode').value=code11;
	    chk123=document.getElementById(id);
	    }
     }
  }
if(k==1)
	{
	document.getElementById('btnsubmit').disabled=true;
	document.getElementById('btnupdate').disabled=false;
	document.getElementById('btndel').disabled=false;
	AgencyBookingType.bandbktyp(comcode,code11,call_bktyp);
	
//	return false;
	
	}
//return false;
}
function cleardata()
{
document.getElementById('txtagency1').value="";
document.getElementById('txtvalidityfrom').value="";
document.getElementById('txttilldate').value="";
document.getElementById('btnsubmit').disabled=false;
document.getElementById('btnupdate').disabled=true;
document.getElementById('btndel').disabled=true;
return false;

}
function call_bktyp(response)
{
var ds= response.value;
var dateformat=document.getElementById('hiddenDateFormat').value;
var fdate=ds.Tables[0].Rows[0].FROM_DATE;
var tdate=ds.Tables[0].Rows[0].TO_DATE;
 if(dateformat=="dd/mm/yyyy")
	{
	var fdate1=fdate.split("/")[1] + '/' + fdate.split("/")[0] + '/' + fdate.split("/")[2];
	var tdate1=tdate.split("/")[1] + '/' + tdate.split("/")[0] + '/' + tdate.split("/")[2];
	}
	if(dateformat=="yyyy/mm/dd")
	{
	var fdate1=fdate.split("/")[2] + '/' + fdate.split("/")[0] + '/' + fdate.split("/")[1];
	var tdate1=tdate.split("/")[2] + '/' + tdate.split("/")[0] + '/' + tdate.split("/")[1];
	}
	if(dateformat=="mm/dd/yyyy")
	{
	var fdate1=fdate;
	var tdate1=tdate;
	}
document.getElementById('txtvalidityfrom').value=fdate1;
document.getElementById('txttilldate').value=tdate1;
document.getElementById('txtagency1').value=ds.Tables[0].Rows[0].AGENCY;
document.getElementById('drpbooktype').value=ds.Tables[0].Rows[0].BOOKING_TYPE;
//return false;
}
