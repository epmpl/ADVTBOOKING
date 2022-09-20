var retexeboth="";
var regclient="";
var rownumEx;
var executequery;
var browser=navigator.appName;
var browserversion=msieversion();
var xmlDoc=null;
var xmlObj=null;
var fmgInsert="";
var innertablehtmlforbook;
var mode;
 function msieversion()
   {
      var ua = window.navigator.userAgent
      var msie = ua.indexOf ( "MSIE " )

      if ( msie > 0 )      // If Internet Explorer, return version number
         return parseInt (ua.substring (msie+5, ua.indexOf (".", msie )))
      else                 // If another browser, return 0
         return 0

   }
function loadXML(xmlFile) 
{
    var  httpRequest =null;    
    if(browser!="Microsoft Internet Explorer")
    {         
        req = new XMLHttpRequest();        
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement;        
    }

}
function getMessage()
{
    var response="";
    if(req.readyState == 4)
    {
       if(req.status == 200)
       {
           response = req.responseText;          
       }
    }
        
    var parser=new DOMParser();
    xmlDoc=parser.parseFromString(response,"text/xml"); 
    xmlObj=xmlDoc.documentElement;
}

loadXML('xml/billcycle.xml');

function verify() 
{ 
 // 0 Object is not initialized 
 // 1 Loading object is loading data 
 // 2 Loaded object has loaded data 
 // 3 Data from object can be worked with 
 // 4 Object completely initialized 
     if (xmlDoc.readyState != 4) 
     { 
       return false; 
     } 
}
function newclick()
{
    clearClick();
     var msg=checkSession();
     if(msg==false)
     {
        window.location.href="login.aspx";
        return false;
     }
     mode="0";
     document.getElementById('txtclient').disabled = false;
     document.getElementById('txtdeal').disabled = false;
     document.getElementById('txtdeal').disabled = false;
     document.getElementById('txtexecname').disabled = false;
     document.getElementById('drpretainer').disabled = false;
     document.getElementById('txtagency').disabled = false;
     document.getElementById('txtagency').focus();
     document.getElementById('LinkButton1').disabled = false;
     document.getElementById('LinkButton4').disabled = false;
     document.getElementById('LinkButton3').disabled = false;
     document.getElementById('txtkeyno').disabled = false;
     document.getElementById('drpcolor').disabled = false;
     document.getElementById('drpadcategory').disabled = false;
     document.getElementById('drprostatus').disabled = false;
     document.getElementById('txtrono').disabled = false;
     document.getElementById('txtMobile').disabled = false;
     document.getElementById('txtrodate').disabled = false;
     document.getElementById('txtclientadd').disabled = false;
     document.getElementById('txtagencyaddress').disabled = false;
     document.getElementById('drpbooktype').disabled = false;
     document.getElementById('txtappby').disabled = false;
     document.getElementById('txtcamp').disabled = false;
     document.getElementById('txtcaption').disabled = false;
     document.getElementById('drpmatsta').disabled = false;
     document.getElementById('drpbillcycle').disabled = false;
     document.getElementById('drprevenue').disabled = false;
     document.getElementById('drppaymenttype').disabled = false;
     document.getElementById('drpbillstatus').disabled = false;
     document.getElementById('txtbillamt').disabled = false;
     document.getElementById('txtbillremark').disabled = false;
     document.getElementById('txttradedisc').disabled = false;
     document.getElementById('chktrade').disabled = false;
     document.getElementById('drpbillto').disabled = false;
     
     
     document.getElementById('tblGridelecbook').outerHTML="<TABLE id=tblGridelecbook style=\"BORDER-COLLAPSE: collapse\" borderColor=#7daae5 width=1000 cellSpacing=0 cellPadding=0 border=1 name=\"tblGridelec\"><TBODY></TBODY><THEAD><TR bgColor=#7daae3><TD class=tdcls align=middle width=100>Channel</TD><TD class=tdcls align=middle width=100>Location</TD><TD class=tdcls align=middle width=100>Adv Type</TD><TD class=tdcls align=middle width=100>Rate Type(UOM)</TD><TD class=tdcls align=middle width=100>Schedule Date</TD><TD class=tdcls align=middle width=80>BTB</TD><TD class=tdcls align=middle width=100>From Band</TD><TD class=tdcls align=middle width=100>To Band</TD><TD class=tdcls align=middle width=80>Break</TD><TD class=tdcls align=middle width=100>Position</TD><TD class=tdcls align=middle width=80>Program</TD><TD class=tdcls align=middle width=100>Paid/ Bonus</TD><TD class=tdcls align=middle width=100>No Of Spot</TD><TD class=tdcls align=middle width=80>Tape Id</TD><TD class=tdcls align=middle width=100>Duration</TD><TD class=tdcls align=middle width=80>Rate</TD><TD class=tdcls align=middle width=100>Gross Amt</TD><TD class=tdcls align=middle width=100>InsertId</TD><TD class=tdcls align=middle width=100>Status</TD><TD class=tdcls align=middle width=100>Ad Category</TD></TR></THEAD><TBODY><TR><TD class=tdcls>0</TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD></TR></TBODY></TABLE>";
     var res=tv_booking_transaction.getCurTime(document.getElementById('hiddencompcode').value);
            var ds=res.value;
            if(ds==null)
            {
                alert(res.error.description);
                return false;
            }
            if(ds.Tables[0].Rows.length>0)
            {
                if(ds.Tables[0].Rows[0].T=="Y")
                {
                    var curdate=document.getElementById('currdate').value;
                     var fromdate="";
                    if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
                    {
                        fromdate=curdate.split('/')[1] + '/' + curdate.split('/')[0] + '/' + curdate.split('/')[2];
                        var fdate=new Date(fromdate);
		                fdate.setDate(fdate.getDate()+1);
		                document.getElementById('txtdatetime').value= (fdate.getDate()) + '/' + (parseInt(fdate.getMonth(),10)+1) + '/' + fdate.getYear();
                    }
                    else  if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
                    {
                        fromdate=curdate;
                        var fdate=new Date(fromdate);
		                fdate.setDate(fdate.getDate()+1);
		                document.getElementById('txtdatetime').value=(parseInt(fdate.getMonth(),10)+1) + '/' + (fdate.getDate()) + '/' + fdate.getYear();
                    }
                    else  if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
                    {
                        fromdate=curdate.split('/')[1] + '/' + curdate.split('/')[2] + '/' + curdate.split('/')[0];
                        var fdate=new Date(fromdate);
		                fdate.setDate(fdate.getDate()+1);
		                document.getElementById('txtdatetime').value=fdate.getYear() + '/' + (parseInt(fdate.getMonth(),10)+1) + '/' + (fdate.getDate());
                    }
                }
                else
                {
                    document.getElementById('txtdatetime').value=document.getElementById('currdate').value;
                }
            }
            else
              {
                document.getElementById('txtdatetime').value=document.getElementById('currdate').value;
              }
        if(document.getElementById('hidbackdatereceipt').value=="y")
           document.getElementById('txtdatetime').disabled = false;
        else
           document.getElementById('txtdatetime').disabled = true;
           bindBookType_Agency()
           /////////if 0 than autogenerate the cio booking id and if 1 than autogenerate dockit no.
        autogenerated("0");
        
        var res=tv_booking_transaction.getPrevBookId();
         if(res.value!=null)
         {
            if(res.value.Tables[0].Rows.length>0)
            {
                document.getElementById('txtprevbook').value=res.value.Tables[0].Rows[0].cio_booking_id;
            }
         }
        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        setButtonImages();
     return false;
 }
 function clearClick()	
 {
        document.getElementById('txtciobookid').value="";
        document.getElementById('txtciobookid').disabled = true;
        document.getElementById('txtprevbook').value="";
        document.getElementById('txtprevbook').disabled = true;
        document.getElementById('txtclient').value="";
        document.getElementById('txtclient').disabled = true;
        document.getElementById('txtdeal').value="";
        document.getElementById('txtdeal').disabled = true;
        document.getElementById('txtagency').value="";
        document.getElementById('txtagency').disabled = true;
        document.getElementById('txtclientadd').value="";
        document.getElementById('txtclientadd').disabled = true;
        document.getElementById('txtagencyaddress').value="";
        document.getElementById('txtagencyaddress').disabled = true;
        document.getElementById('LinkButton1').disabled=true;
		document.getElementById('LinkButton3').disabled=true;
		document.getElementById('LinkButton4').disabled=true;
		document.getElementById('hidattach1').value="";
	    document.getElementById('attachment1').src="Images/index.jpeg"
	    document.getElementById('hidattach2').value="";
	    document.getElementById('attachment2').src="Images/index.jpeg"
	    document.getElementById('addetails').style.display='none';
	    document.getElementById('tblrate').style.display='none';
        document.getElementById('tblbill').style.display='none';
        document.getElementById('txtexecname').value="";//new
        document.getElementById('txtexecname').disabled = true;
        document.getElementById('drpretainer').value="";
        document.getElementById('drpretainer').disabled = true;        
        document.getElementById('txtMobile').value="";
        document.getElementById('txtMobile').disabled = true;
        document.getElementById('txtrono').value = "";
        document.getElementById('txtrono').disabled = true;
        document.getElementById('txtrodate').value = "";
        document.getElementById('txtrodate').disabled = true;
        document.getElementById('drprostatus').value = "0";
        document.getElementById('drprostatus').disabled = true;
        document.getElementById('txtkeyno').value =  "";
        document.getElementById('txtkeyno').disabled = true;
        document.getElementById('drpcolor').selectedIndex =  "1";
        document.getElementById('drpcolor').disabled = true;
        document.getElementById('drpadcategory').selectedIndex =  "1";
        document.getElementById('drpadcategory').disabled = true;
        document.getElementById('tblGridelecbook').outerHTML="<TABLE id=tblGridelecbook style=\"BORDER-COLLAPSE: collapse\" borderColor=#7daae5 width=1000 cellSpacing=0 cellPadding=0 border=1 name=\"tblGridelec\"><TBODY></TBODY></TABLE>"
        document.getElementById("div_electronicbook").style.display="none";
        document.getElementById('hiddentradedisc').value="";
        if(document.getElementById('txtaddagencycommrateamt')!=null)
            document.getElementById('txtaddagencycommrateamt').disabled = true;
        document.getElementById('txtRetainercomm').value="";
        document.getElementById('txtRetainercomm').disabled=true;
        document.getElementById('txtRetainercommamt').value="";
        document.getElementById('txtRetainercommamt').disabled=true;
        document.getElementById('drpbooktype').value="0";
        document.getElementById('drpbooktype').disabled = true;
        document.getElementById('txtappby').value="";
        document.getElementById('txtappby').disabled = true;
        document.getElementById('txtcamp').value="";
        document.getElementById('txtcamp').disabled = true;
        document.getElementById('txtcaption').value="";
        document.getElementById('txtcaption').disabled = true;
        document.getElementById('drpmatsta').value="";
        document.getElementById('drpmatsta').disabled = true;
        document.getElementById('hiddenbillpay').value="";
        document.getElementById('hiddenpay').value="";
        document.getElementById('drpbillcycle').value="0";
        document.getElementById('drpbillcycle').disabled = true;
        document.getElementById('drprevenue').value="0";
        document.getElementById('drprevenue').disabled = true;
        document.getElementById('drppaymenttype').options.length=0;
        document.getElementById('drppaymenttype').disabled = true;
        document.getElementById('drpbillstatus').value="0";
        document.getElementById('drpbillstatus').disabled = true;
        document.getElementById('txtbillamt').value="";
        document.getElementById('txtbillamt').disabled = true;
        document.getElementById('txtbillremark').value="";
        document.getElementById('txtbillremark').disabled = true;
        document.getElementById('txttradedisc').value="";
        document.getElementById('txttradedisc').disabled = true;
        document.getElementById('chktrade').checked=false; 
        document.getElementById('chktrade').disabled = true;
        document.getElementById('drpbillto').options.length=0;
        document.getElementById('drpbillto').disabled = true;
        document.getElementById('drpagscode').options.length=0;
        document.getElementById('drpagscode').disabled = true;
        document.getElementById('txtagencypaymode').options.length=0;
        document.getElementById('txtagencypaymode').disabled = true;
        document.getElementById('txtagencystatus').value="";
        document.getElementById('txtagencystatus').disabled = true;
        document.getElementById('txtcreditperiod').value="";
        document.getElementById('txtcreditperiod').disabled = true;
        document.getElementById('txtexeczone').value="";
        document.getElementById('txtexeczone').disabled = true;
        document.getElementById('txtagencyoutstand').value="";
        document.getElementById('txtagencyoutstand').disabled = true;
        innertablehtmlforbook="";
        mode="0";
        
        document.getElementById('btnSave').disabled = true;//end
        document.getElementById('btnNew').disabled = false;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnNew').focus();
        var res=null;
         res=tv_booking_transaction.getRev();
           if(res.value!=null)
         {
            document.getElementById('drprevenue').value=res.value;
            
         }
        setButtonImages();
     return false;
 }
 function autogenerated(no)
{
   //Booking id
    if (no == "0")
    {
         var dt= new Date()
         var auto = "";
         var cen = document.getElementById('hiddencenter').value;
         cen = cen.substring(0, 3);            
         var year = dt.getFullYear();
         var zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
        if (document.getElementById('hiddencioidformat').value == "1")
        {
            auto = cen + year;
        }
        else if (document.getElementById('hiddencioidformat').value == "2")
        {
            auto = cen + year + document.getElementById('hiddenuserid').value;
        }
      else if (document.getElementById('hiddencioidformat').value == "3")
        {
            auto = "";
        }
        else if (document.getElementById('hiddencioidformat').value == "4")
        {
            auto = "DI";
        }
        var autogen = auto + "0";
        var res=tv_booking_transaction.getBookingIdNo(document.getElementById('hiddencompcode').value,auto,no,document.getElementById('txtciobookid').value);
        var da=res.value;
        if(da==null)
        {
            alert(res.error.description);
            return false;
        }   
        if (da.Tables[0].Rows.length > 0 && da.Tables[0].Rows[0].ID != "")
        {
            var ab = da.Tables[0].Rows[0].ID;
            year = da.Tables[0].Rows[0].YEAR1;
              if (document.getElementById('hiddencioidformat').value == "1")
            {
                auto = cen + year;
            }
            else if (document.getElementById('hiddencioidformat').value == "2")
            {
                auto = cen + year + document.getElementById('hiddenuserid').value;
            }
             else if (document.getElementById('hiddencioidformat').value == "3")
            {
                auto = "";
            }
             else if (document.getElementById('hiddencioidformat').value == "4")
            {
                auto = "DI";
            }
            var cou1 = parseInt(ab,10);           
            var countlen = cou1.toString().length;
            if (countlen == 1)
            {
                zeros = "0000000" + cou1;
            }
            else if (countlen == 2)
            {
                zeros = "000000" + cou1;
            }
            else if (countlen == 3)
            {
                zeros = "00000" + cou1;
            }
            else if (countlen == 4)
            {
                zeros = "0000" + cou1;
            }
            else if (countlen == 5)
            {
                zeros = "000" + cou1;
            }
            else if (countlen == 6)
            {
                zeros = "00" + cou1;
            }
            else if (countlen == 7)
            {
                zeros = "0" + cou1;
            }
            else if (countlen == 8)
            {
                zeros = "0" + cou1;
            }

            document.getElementById('txtciobookid').value = auto + zeros;
        }
        else
        {
            document.getElementById('txtciobookid').value = autogen;

        }
    }
    //Dokit number
    else if (no == "1")
    {
         var auto = "DN";
         var autogen = auto + "0";
         var res=tv_booking_transaction.getBookingIdNo(document.getElementById('hiddencompcode').value,auto,no,document.getElementById('txtciobookid').value);
         var da=res.value;
         if(da==null)
         {
               alert(res.error.description);
               return false;
          }   
          if (da.Tables[0].Rows.length > 0 && da.Tables[0].Rows[0].ID != "")
          {
                var ab = da.Tables[0].Rows[0].ID;
                var cou1 = parseInt(ab,10);
              //  cou1++;
                document.getElementById('txtdockitno1').value = auto + cou1;
          }
          else
          {
                document.getElementById('txtdockitno1').value = autogen;
          }

     }
     else if (no == "2")
     {
          var auto = "BN";
          var autogen = auto + "0";
          var res=tv_booking_transaction.getBookingIdNo(document.getElementById('hiddencompcode').value,auto,no,document.getElementById('txtciobookid').value);
          var da=res.value;
          if(da==null)
          {
               alert(res.error.description);
               return false;
          }   
          if (da.Tables[0].Rows.length > 0 && da.Tables[0].Rows[0].boxno != "" && da.Tables[0].Rows[0].boxno!=undefined)
          {
               var ab = da.Tables[0].Rows[0].boxno;
               var cou1 = parseInt(ab,10);
               cou1++;
               document.getElementById('txtboxno').value = auto + cou1;
          }
          else
          {
               document.getElementById('txtboxno').value = autogen;
          }


     }

        //get max receipt number 
     else if (no == "3")
     {
        document.getElementById('txtreceipt').value = "";
        document.getElementById('hiddenreceiptno').value="";
          var res=tv_booking_transaction.getBookingIdNo(document.getElementById('hiddencompcode').value,"",no,document.getElementById('txtciobookid').value);
          var da=res.value;
            //***************************************
           if(da==null)
           {
               alert(res.error.description);
               return false;
           }   
           var max_number = "0";
           if (da.Tables[0].Rows[0].recno.toString().length == 1)
                max_number = "000" + da.Tables[0].Rows[0].recno;
           else if (da.Tables[0].Rows[0].recno.toString().length == 2)
                max_number = "00" + da.Tables[0].Rows[0].recno;
           else if (da.Tables[0].Rows[0].recno.toString().length == 3)
                max_number = "0" + da.Tables[0].Rows[0].recno;
           else
                max_number = da.Tables[0].Rows[0].recno;
                 //for sambad only
           if (document.getElementById('hiddenprereceipt').value == "6")
           {
               
               document.getElementById('txtreceipt').value = "D-BHU-" + max_number;
               document.getElementById('hiddenreceiptno').value = document.getElementById('txtreceipt').value;
           }
           else //for sambad only    
           {
                if(document.getElementById('hiddenhidReceipt').value!="" && document.getElementById('txtbranch').value!="")
                {
                    var arr= document.getElementById('txtbranch').value;
                    var res=Booking_master.getBAlias(document.getElementById('txtbranch').value,document.getElementById('hiddencompcode').value);
                    if(res.value!=null && res.value.Tables[0].Rows.length>0)
                    {
                        var str=res.value.Tables[0].Rows[0].ALIAS;
                        var str1=document.getElementById('hiddenhidReceipt').value.substring(0,document.getElementById('hiddenhidReceipt').value.indexOf("/"));
                        document.getElementById('hiddenhidReceipt').value=document.getElementById('hiddenhidReceipt').value.replace(str1,str);
                    }
                    
                }
                if (document.getElementById('hiddenpaymode').value == "CASH")
                {
                    document.getElementById('txtreceipt').value = "R/" + document.getElementById('hiddenhidReceipt').value + max_number;
                    document.getElementById('hiddenreceiptno').value = document.getElementById('txtreceipt').value;
                }
                else
                {
                    document.getElementById('txtreceipt').value = document.getElementById('hiddenhidReceipt').value + max_number;
                    document.getElementById('hiddenreceiptno').value = document.getElementById('txtreceipt').value;
                }
            }
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
function insertagency()
{
 if(document.activeElement.id=="lstclient")
        {
            if(document.getElementById('lstclient').value=="0")
            {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclient").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
            var page=document.getElementById('lstclient').value;       
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) 
                {
                    httpRequest.overrideMimeType('text/xml'); 
                }            
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
                httpRequest.send('');
                if (httpRequest.readyState == 4) 
                {
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
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
                xml.Send();
                id=xml.responseText;
            }
            var split=id.split("+");
            var namecode=split[0];
            var add=split[1];        
            document.getElementById('txtclient').value=namecode;
            
//            if(document.getElementById('hiddensavemod').value=="0")
//            {
                document.getElementById('txtclientadd').value=add;
                document.getElementById('txtdeal').focus();
            //}
            if(agencycodeglo!="undefined" && agencycodeglo!=undefined)
               {
                    var resbill=tv_booking_transaction.bindbillto_ag(agencycodeglo,document.getElementById('hiddencompcode').value);
                    dsbill=resbill.value;
                  var pkgitem = document.getElementById("drpbillto");
              
                 if(dsbill!= null && typeof(dsbill) == "object" && dsbill.Tables[0].Rows.length > 0) 
                 {
                      pkgitem.options.length = 0; 
                       var client_val=document.getElementById('txtclient').value;
                       var client_name=document.getElementById('txtclient').value;
                        if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0)
                    {
                        client_val =document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(")+1,document.getElementById('txtclient').value.length-1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                        client_name=document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                        alertfun();
                     }   
                        pkgitem.options[0]=new Option(client_name,client_val);
                      for (var i = 0  ; i < dsbill.Tables[0].Rows.length; ++i)
                      {
                      if(dsbill.Tables[0].Rows[i].bill_to=="")
                        pkgitem.options[pkgitem.options.length] = new Option(dsbill.Tables[0].Rows[i].agency_name,dsbill.Tables[1].Rows[0].sub_agency_code);      
                      else
                        pkgitem.options[pkgitem.options.length] = new Option(dsbill.Tables[0].Rows[i].agency_name,dsbill.Tables[0].Rows[i].bill_to);        
                        pkgitem.options.length;               
                      }                        
                  }
                  if(dsbill.Tables[1].Rows.length>0)
                  {
                    document.getElementById("drpbillto").value=dsbill.Tables[1].Rows[0].sub_agency_code
                    document.getElementById('hiddenbillto').value=dsbill.Tables[1].Rows[0].sub_agency_code
                  }
                }
            
          return false;
        }
        else if(document.activeElement.id=="lstagency")
        {
            if(document.getElementById('lstagency').value=="0" )
            {
                alert("Please select the agency sub code");
                return false;
            }
            document.getElementById("div1").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
            var page=document.getElementById('lstagency').value;
            document.getElementById('hiddenagency').value=page;
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
                if (httpRequest.readyState == 4) 
                {
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
            document.getElementById('txtagency').value=nameagen;
//            if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
//            {
                document.getElementById('txtagencyaddress').value=agenadd;                
                document.getElementById('txtclient').focus();
                //Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
                var resag=tv_booking_transaction.bindagencusub(page,document.getElementById('hiddencompcode').value);//,call_bindagsub);
                ds=resag.value;
                document.getElementById('txtagencytype').value="";
                document.getElementById('txtagencystatus').value="";
                document.getElementById('txtcreditperiod').value="";
                document.getElementById('txtagencypaymode').value="";
                document.getElementById('txttradedisc').value="";
                 document.getElementById('hiddenagcommflag').value="";
                document.getElementById('txtgrossamt').value="";
                if(document.getElementById('txtaddagencycommrate')!=null)
                document.getElementById('txtaddagencycommrate').value="";
                
                document.getElementById('hiddentradedisc').value="";
                document.getElementById('lstagency').options.length=0;
                var pkgitem = document.getElementById("drpagscode");
              //pkgitem.options.length=0;
               // pkgitem.options[0] = new Option("-Select-","0");
                
                if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                {
                    pkgitem.options.length = 0; 
                    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                    {
                        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].Agency_Code);        
                        pkgitem.options.length;       
                    }
                }
    
                getpayandstatus1();
//            }
            return false;
        }
        else if(document.activeElement.id=="lstdeal")
        {
            if(document.getElementById('lstdeal').value=="0" )
            {
                alert("Please select the Deal");
                return false;
            }
            document.getElementById("divdeal").style.display="none";
            document.getElementById('txtdeal').value=document.getElementById('lstdeal').options[document.getElementById('lstdeal').selectedIndex].text +"("+document.getElementById('lstdeal').value+")";
            if(document.getElementById('lstdeal').value!="0")
            {
                if(document.getElementById('txtagency').value=="" || document.getElementById('txtagency').value=="0")
                {
                    var resforagency=tv_booking_transaction.getagencyfromdeal(document.getElementById('hiddencompcode').value,document.getElementById('lstdeal').value);
                    var dsforagency=resforagency.value;
                    if(dsforagency==null)
                    {
                        alert(resforagency.error.description);
                        return false;
                    }
                   if(dsforagency.Tables[0].Rows.length>0)
                    {
                        document.getElementById('txtagencyaddress').value=dsforagency.Tables[0].Rows[0].address;
                        document.getElementById('txtagency').value=dsforagency.Tables[0].Rows[0].agency_name;
                        document.getElementById('hiddenagency').value=dsforagency.Tables[0].Rows[0].Agency_code;
                    }
                    var agency_code="";
                    if(document.getElementById('txtagency').value!="")
                    {
                        var agency_name=document.getElementById('txtagency').value.split('(');
                        agency_code=agency_name[1].replace(')','');
                    }
                    agencycodeglo=agency_code;
                    var resforpay=tv_booking_transaction.bindagencusub(agency_code,document.getElementById('hiddencompcode').value);
                        dsforpay=resforpay.value;
                        document.getElementById('txtagencytype').value="";
                        document.getElementById('txtagencystatus').value="";
                        document.getElementById('txtcreditperiod').value="";
                        document.getElementById('txtagencypaymode').value="";
                        document.getElementById('txttradedisc').value="";
                         document.getElementById('hiddenagcommflag').value="";
                        document.getElementById('txtgrossamt').value="";
                        if(document.getElementById('txtaddagencycommrate')!=null)
                        document.getElementById('txtaddagencycommrate').value="";
                        document.getElementById('hiddentradedisc').value="";
                        document.getElementById('lstagency').options.length=0;
                        var pkgitem = document.getElementById("drpagscode");
                        if(dsforpay!= null && typeof(dsforpay) == "object" && dsforpay.Tables[0].Rows.length > 0) 
                        {
                            pkgitem.options.length = 0; 
                            for (var i = 0  ; i < dsforpay.Tables[0].Rows.length; ++i)
                            {
                                pkgitem.options[pkgitem.options.length] = new Option(dsforpay.Tables[0].Rows[i].agency_name,dsforpay.Tables[0].Rows[i].Agency_Code);        
                                pkgitem.options.length;       
                            }
                        }
                        
                        getpayandstatus(dsforagency.Tables[0].Rows[0].PAYMENTTYPE ,dsforagency.Tables[0].Rows[0].PAYTYPENAME);
                }
                else if(document.getElementById('txtclient').value=="" || document.getElementById('txtclient').value=="0")
                {
                    var resforclient=tv_booking_transaction.getclientfromdeal(document.getElementById('hiddencompcode').value,document.getElementById('lstdeal').value);
                    var dsforclient=resforclient.value;
                    if(dsforclient==null)
                    {
                        alert(resforclient.error.description);
                        return false;
                    }
                   if(dsforclient.Tables[0].Rows.length>0)
                    {
                        document.getElementById('txtclientadd').value=dsforclient.Tables[0].Rows[0].address;
                        document.getElementById('txtclient').value=dsforclient.Tables[0].Rows[0].client_name;
                    }
                    var agency_code="";
                    if(document.getElementById('txtagency').value!="")
                    {
                        var agency_name=document.getElementById('txtagency').value.split('(');
                        agency_code=agency_name[1].replace(')','');
                    }
                    var resforpay=tv_booking_transaction.bindagencusub(agency_code,document.getElementById('hiddencompcode').value);
                        dsforpay=resforpay.value;
                        document.getElementById('txtagencytype').value="";
                        document.getElementById('txtagencystatus').value="";
                        document.getElementById('txtcreditperiod').value="";
                        document.getElementById('txtagencypaymode').value="";
                        document.getElementById('txttradedisc').value="";
                         document.getElementById('hiddenagcommflag').value="";
                        document.getElementById('txtgrossamt').value="";
                        if(document.getElementById('txtaddagencycommrate')!=null)
                        document.getElementById('txtaddagencycommrate').value="";
                        document.getElementById('hiddentradedisc').value="";
                        document.getElementById('lstagency').options.length=0;
                        var pkgitem = document.getElementById("drpagscode");
                        if(dsforpay!= null && typeof(dsforpay) == "object" && dsforpay.Tables[0].Rows.length > 0) 
                        {
                            pkgitem.options.length = 0; 
                            for (var i = 0  ; i < dsforpay.Tables[0].Rows.length; ++i)
                            {
                                pkgitem.options[pkgitem.options.length] = new Option(dsforpay.Tables[0].Rows[i].agency_name,dsforpay.Tables[0].Rows[i].Agency_Code);        
                                pkgitem.options.length;       
                            }
                        }
                    getpayandstatus(dsforclient.Tables[0].Rows[0].PAYMENTTYPE ,dsforclient.Tables[0].Rows[0].PAYTYPENAME);
                }
                else
                {
                    var resforclient=tv_booking_transaction.getclientfromdeal(document.getElementById('hiddencompcode').value,document.getElementById('lstdeal').value);
                    var dsforclient=resforclient.value;
                    if(dsforclient==null)
                    {
                        alert(resforclient.error.description);
                        return false;
                    }
                    var agency_code="";
                    if(document.getElementById('txtagency').value!="")
                    {
                        var agency_name=document.getElementById('txtagency').value.split('(');
                        agency_code=agency_name[1].replace(')','');
                    }
                    var resforpay=tv_booking_transaction.bindagencusub(agency_code,document.getElementById('hiddencompcode').value);
                        dsforpay=resforpay.value;
                        document.getElementById('txtagencytype').value="";
                        document.getElementById('txtagencystatus').value="";
                        document.getElementById('txtcreditperiod').value="";
                        document.getElementById('txtagencypaymode').value="";
                        document.getElementById('txttradedisc').value="";
                         document.getElementById('hiddenagcommflag').value="";
                        document.getElementById('txtgrossamt').value="";
                        if(document.getElementById('txtaddagencycommrate')!=null)
                        document.getElementById('txtaddagencycommrate').value="";
                        document.getElementById('hiddentradedisc').value="";
                        document.getElementById('lstagency').options.length=0;
                        var pkgitem = document.getElementById("drpagscode");
                        if(dsforpay!= null && typeof(dsforpay) == "object" && dsforpay.Tables[0].Rows.length > 0) 
                        {
                            pkgitem.options.length = 0; 
                            for (var i = 0  ; i < dsforpay.Tables[0].Rows.length; ++i)
                            {
                                pkgitem.options[pkgitem.options.length] = new Option(dsforpay.Tables[0].Rows[i].agency_name,dsforpay.Tables[0].Rows[i].Agency_Code);        
                                pkgitem.options.length;       
                            }
                        }
                    getpayandstatus(dsforclient.Tables[0].Rows[0].PAYMENTTYPE ,dsforclient.Tables[0].Rows[0].PAYTYPENAME);
                }
                var allinfo=tv_booking_transaction.bindallinfo(document.getElementById('hiddencompcode').value,document.getElementById('lstdeal').value)
                var dsforallinfo=allinfo.value;
                if(dsforallinfo==null)
                    {
                        alert(allinfo.error.description);
                        return false;
                    }
                if(dsforallinfo.Tables[0].Rows.length>0)
                {
                    document.getElementById('txtexecname').value=dsforallinfo.Tables[0].Rows[0].execname;
                    document.getElementById('drpretainer').value=dsforallinfo.Tables[0].Rows[0].RETAINER1;
                    document.getElementById('txtexeczone').value=dsforallinfo.Tables[0].Rows[0].zone;
                }                    
            }
            return false;
        }
        else if(document.activeElement.id=="lstexec")
        {
            if(document.getElementById('lstexec').value=="0")
            {
                      var a="Executive name";
            if(browser!="Microsoft Internet Explorer")
            {
                a=document.getElementById('lbececname').textContent.replace("*[F2]","");
            }
            else
            {        
                a=document.getElementById('lbececname').innerText.replace("*[F2]","");
            }
                alert("Please select the "+a);
                return false;
            }
      
            document.getElementById("divexec").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
        
            var page=document.getElementById('lstexec').value;
               
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                }
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
                httpRequest.send('');
                if (httpRequest.readyState == 4) 
                {
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
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
                xml.Send();
                id=xml.responseText;
            }
        
            document.getElementById('txtexecname').value=id;
            tv_booking_transaction.getexeczone(page,document.getElementById('hiddencompcode').value,call_bindexeczone);
            if(document.getElementById('txtagencyoutstand').disabled==false)
            {
                document.getElementById('txtagencyoutstand').focus();
            }
            else
            {
                //changediv();
                  document.getElementById('txtrono').focus();
            }
            return false;
        }
        else  if(document.activeElement.id=="lstbarter")
        {
             if(document.getElementById('lstbarter').value=="0")
            {
                alert("Please Select Barter Type");
                document.getElementById('txtbartertype').value="";
                document.getElementById('hiddenbarteramt').value="";
                document.getElementById('hiddenstopbarterbooking').value="";
                return false;
            }
            document.getElementById("divbarter").style.display="none";
            var bartervalue=document.getElementById('lstbarter').value;
              if(bartervalue!="")
            {
            document.getElementById('hiddenbarteramt').value=bartervalue.split('û')[1];
            document.getElementById('hiddenstopbarterbooking').value=bartervalue.split('û')[2];
            var bame=document.getElementById('lstbarter').options[document.getElementById('lstbarter').selectedIndex].text + '(' + bartervalue.split('û')[0] + ')';
            document.getElementById('txtbartertype').value=bame;
            }
            
        }
        else if(document.activeElement.id=="lstproduct")
        {
            if(document.getElementById('lstproduct').value=="0")
            {
                alert("Please select the product");
                return false;
            }
            document.getElementById("divproduct").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
               
            var page=document.getElementById('lstproduct').value;
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                }
            
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=2", false );
                httpRequest.send('');
                if (httpRequest.readyState == 4) 
                {
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
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=2", false );
                xml.Send();
                id=xml.responseText;
            }
            document.getElementById('txtproduct').value=id;
            document.getElementById('drpbrand').disabled==false;
            document.getElementById('drpbrand').focus();
            tv_booking_transaction.getbrand(page,document.getElementById('hiddencompcode').value,call_bindproduct);
            return false;
        }
        else if(document.activeElement.id=="lstretainer")
        {
            if(document.getElementById('lstretainer').value=="0" )
            {
                var b="Retainer";
                if(browser!="Microsoft Internet Explorer")
                {
                  b=document.getElementById('lblretainer').textContent.replace("*[F2]","");
                }
                else
                {        
                  b=document.getElementById('lblretainer').innerText.replace("*[F2]","");
                }
                alert("Please select the "+b);            
                return false;
            }        
            document.getElementById('drpretainer').value=document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text +"("+document.getElementById('lstretainer').value+")";
            document.getElementById("divretainer").style.display="none";
            document.getElementById('txtaddagencycommrateamt').value="";
            if(document.getElementById('txtaddagencycommrate')!=null)
            document.getElementById('txtaddagencycommrate').value="";
              if(document.getElementById('drpretainer').value!="" && document.getElementById('drpretainer').value!="0")
                {
                    document.getElementById('txtRetainercomm').value="";
                    var retain_name=document.getElementById('drpretainer').value.split('(');
                    var retain_code=retain_name[1].replace(')','');
                    var ds_ret=tv_booking_transaction.getRetainerComm(retain_code,document.getElementById('hiddencompcode').value);                    
                    if(ds_ret.value==null)
                        return false;                       
                   if(ds_ret.value.Tables[0].Rows.length>0)
                    {
                        document.getElementById('retcommtype').value=ds_ret.value.Tables[0].Rows[0].Discount;
                        document.getElementById('txtRetainercomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                        document.getElementById('retcomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                        if(document.getElementById('retcommtype').value=="Gross" && document.getElementById('txtgrossamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                        {
                            document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtgrossamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                        }
                        else  if(document.getElementById('retcommtype').value=="Net" && document.getElementById('txtbillamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                        {
                            document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtbillamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                        }
                    }                      
                }
            //changediv();  
        }
}
function scheduletime()
{
    if(mode=="0")
      if(document.getElementById('txtdeal').disabled==true)
        return false;
    if(document.getElementById('txtagency').value=="" || document.getElementById('txtclient').value=="")
    {
        alert("Please enter Agency. OR Client");
        return false;
    }
    if(document.getElementById('txtexecname').value=="")
    {
        document.getElementById('txtexecname').focus();
        return false;
    }
    window.open('bookingschedule.aspx?dealnamecode='+document.getElementById('txtdeal').value,'Ankur2', 'width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
    return false;
}
function openattach1()
{
if(document.getElementById('LinkButton1').disabled==false)
    window.open('approvalAttachment.aspx?filename='+document.getElementById('hidattach1').value,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
     return false;
}
function openattach2()
{
if(document.getElementById('LinkButton1').disabled==false)
 window.open('approvalAttachment1.aspx?filename='+document.getElementById('hidattach2').value,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
 return false;
}
function changediv()
{
    if(document.getElementById('LinkButton1').disabled==true)
        return false;
       if(document.getElementById('drpretainer').value=="" && document.getElementById('txtexecname').value=="")
        {
         var a="Executive name";
                 var b="Retainer";
                if(browser!="Microsoft Internet Explorer")
                {
                    a=document.getElementById('lbececname').textContent.replace("*[F2]","");
                     b=document.getElementById('lblretainer').textContent.replace("*[F2]","");
                }
                else
                {        
                    a=document.getElementById('lbececname').innerText.replace("*[F2]","");
                     b=document.getElementById('lblretainer').innerText.replace("*[F2]","");
                }
            alert('Please fill '+a+' or '+b+'.');
            //document.getElementById('drpretainer').focus();
            return false;
        }
  	if(document.getElementById('LinkButton1').disabled==false)
		{
		
		if(document.getElementById('txtagency').value=="")
		{
		    alert("Please fill the Agency Name");
		    document.getElementById('txtagency').focus();
		    return false;
		}
		else if(document.getElementById('drpagscode').value=="" || document.getElementById('drpagscode').value=="0")
		{
		    alert("Please select the agency sub code");
		    document.getElementById('drpagscode').focus();
		    return false;
		
		}
		if(document.getElementById('txtrono').value!="" && document.getElementById('txtrono').disabled==false)
        {
            if(document.getElementById('txtrodate').value=="")
            {
                alert("Please fill ro date");
                document.getElementById('txtrodate').focus();
                return false;            
            }
    
        }
		document.getElementById('LinkButton1').style.fontWeight="bold";
		document.getElementById('LinkButton1').style.color="#FFFF80";
		document.getElementById('LinkButton3').style.fontWeight="normal";
		document.getElementById('LinkButton3').style.color="White";
		document.getElementById('LinkButton4').style.fontWeight="normal";
		document.getElementById('LinkButton4').style.color="White";
		document.getElementById('tblrate').style.display="none";
		document.getElementById('tblbill').style.display="none";
		document.getElementById('addetails').style.display="block";
		if(document.getElementById('drpbooktype').disabled==false)
		{
		    document.getElementById('drpbooktype').focus();
		}
		return false;
	}
}
function changebilldiv()
{
 if(document.getElementById('LinkButton1').disabled==true)
   return false;
    if(document.getElementById('drpretainer').value=="" && document.getElementById('txtexecname').value=="")
    {
        alert('Please fill Execute Name or Retainer.');
        //document.getElementById('drpretainer').focus();
        return false;
    }
if(document.getElementById('drpbooktype').value=="0")
{
    alert("Please Select Booking Type");
    return false;
}    
if(document.getElementById('drpcolor').value=="0")
{
    alert("Please Select Color");
    return false;
}   
if(document.getElementById('drpadcategory').value=="0")
{
    alert("Please Select Ad Category");
    return false;
}   
//if(document.getElementById('drpcurrency').value=="0")
//{
//    alert("Please Select Currency");
//    return false;
//}  
if(document.getElementById('txtratecode').value=="0")
{
    alert("Please Select Rate Code");
    document.getElementById('txtratecode').focus();
    return false;
}  
    if(document.getElementById('txttradedisc').value=="")
        document.getElementById('txttradedisc').value="0";
    if(document.getElementById('txttradedisc').value=="")
        document.getElementById('txttradedisc').value="0";
    if(document.getElementById('LinkButton3').disabled==true)
	        return false;
    if(document.getElementById('LinkButton3').disabled==false)
    {
        if(document.getElementById('txtagency').value=="")
        {
            alert("Please fill the Agency Sub Code");
            document.getElementById('txtagency').focus();
            return false;
        }
        else if(document.getElementById('drpagscode').value=="" || document.getElementById('drpagscode').value=="0")
        {
            alert("Please select the agency sub code");
            document.getElementById('drpagscode').focus();
            return false;		
        }
        if(document.getElementById('txtrono').value!="" && document.getElementById('txtrono').disabled==false)
        {
            if(document.getElementById('txtrodate').value=="")
            {
                alert("Please fill ro date");
                document.getElementById('txtrodate').focus();
                return false;            
            }

        }
		document.getElementById('LinkButton3').style.fontWeight="bold";
        document.getElementById('LinkButton3').style.color="#FFFF80";
        document.getElementById('LinkButton1').style.fontWeight="normal";
        document.getElementById('LinkButton1').style.color="White";
        document.getElementById('LinkButton4').style.fontWeight="normal";
        document.getElementById('LinkButton4').style.color="White";
        document.getElementById('addetails').style.display="none";
        document.getElementById('tblrate').style.display="none";
        document.getElementById('tblbill').style.display="block";
        if(document.getElementById('drpbillcycle').disabled==false)
        {
            document.getElementById('drpbillcycle').focus();
        }
     return false;
	}
}
	function changedivrate()
{
    if(document.getElementById('LinkButton4').disabled==true)
	        return false;
    if(document.getElementById('drpretainer').value=="" && document.getElementById('txtexecname').value=="")
    {
        alert('Please fill Execute Name or Retainer.');
        if(document.getElementById('drpretainer').disabled==false)
            document.getElementById('drpretainer').focus();
        return false;
    }
if(document.getElementById('drpbooktype').value=="0")
{
    alert("Please Select Booking Type");
    return false;
}    
if(document.getElementById('drpcolor').value=="0")
{
    alert("Please Select Color");
    return false;
}   
if(document.getElementById('drpadcategory').value=="0")
{
    alert("Please Select Ad Category");
    return false;
}   
if(document.getElementById('LinkButton4').disabled==false)
    {		
        if(document.getElementById('txtagency').value=="")
        {
            alert("Please fill the agency name");
            document.getElementById('txtagency').focus();
            return false;
        }
        else if(document.getElementById('drpagscode').value=="" || document.getElementById('drpagscode').value=="0")
        {
            alert("Please select the agency sub code");
            document.getElementById('drpagscode').focus();
            return false;

        }
        if(document.getElementById('txtrono').value!="" && document.getElementById('txtrono').disabled==false)
         {
              if(document.getElementById('txtrodate').value=="")
              {
                  alert("Please fill ro date");
                  document.getElementById('txtrodate').focus();
                  return false;            
              }
    
          }
		
	    document.getElementById('LinkButton4').style.fontWeight="bold";
	    document.getElementById('LinkButton4').style.color="#FFFF80";
	    document.getElementById('LinkButton1').style.fontWeight="normal";
	    document.getElementById('LinkButton1').style.color="White";
	    document.getElementById('tblrate').style.display="block";
	    if(document.getElementById('txtratecode').disabled==false)
	    {
	        document.getElementById('txtratecode').focus();
	    }
	    document.getElementById('tblbill').style.display="none";
	    document.getElementById('addetails').style.display="none";
	    if(document.getElementById('drpretainer').value!="" && document.getElementById('drpretainer').value!="0" && document.getElementById('txtRetainercomm').value=="")
        {
            document.getElementById('txtRetainercomm').value="";
            var retain_name=document.getElementById('drpretainer').value.split('(');
            var retain_code=retain_name[1].replace(')','');
            var ds_ret=tv_booking_transaction.getRetainerComm(retain_code,document.getElementById('hiddencompcode').value);
            
            if(ds_ret.value==null)
                return false;
               
           if(ds_ret.value.Tables[0].Rows.length>0)
            {
                document.getElementById('retcommtype').value=ds_ret.value.Tables[0].Rows[0].Discount;
                document.getElementById('txtRetainercomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                document.getElementById('retcomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                if(document.getElementById('retcommtype').value=="Gross" && document.getElementById('txtgrossamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                {
                    document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtgrossamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                }
                else  if(document.getElementById('retcommtype').value=="Net" && document.getElementById('txtbillamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                {
                    document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtbillamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                }
            }    
               
        }
		//getrateonchangecurr();
		 return false;
	}
}
function modifyClick()
{
    mode="1";
    document.getElementById('btnSave').disabled = false;
    setButtonImages();
    return false;
}
function queryClick()
{
    document.getElementById('txtciobookid').disabled = false;
    document.getElementById('btnExecute').disabled = false;
    setButtonImages();
    return false;
}
function firstClick()
{
    clearClick();
         cali=0;
        rownumEx=0;
        fillDATA();
        document.getElementById('txtRetainercomm').value="";
        document.getElementById('txtRetainercomm').disabled=true;
        document.getElementById('LinkButton1').disabled = false;
        document.getElementById('LinkButton4').disabled = false;
        document.getElementById('LinkButton3').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        setButtonImages();
        return false;
}
function lastClick()
{
    clearClick();
          var count = executequery.Tables[0].Rows.length - 1;
        rownumEx=count;
        fillDATA();
        document.getElementById('LinkButton1').disabled = false;
        document.getElementById('LinkButton4').disabled = false;
        document.getElementById('LinkButton3').disabled = false;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnnext').disabled = true;
        setButtonImages();
        return false;
}
function nextClick()
{
    clearClick();
         rownumEx=parseInt(rownumEx) + 1;
         var count = executequery.Tables[0].Rows.length - 1;
        fillDATA();
         document.getElementById('LinkButton1').disabled = false;
         document.getElementById('LinkButton4').disabled = false;
         document.getElementById('LinkButton3').disabled = false;
         document.getElementById('btnprevious').disabled = false;
         document.getElementById('btnfirst').disabled = false;
         if(rownumEx == count)
         {
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnnext').disabled = true;
         }
         else
         {
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnnext').disabled = false;
         }
         setButtonImages();
            return false;
}
function previousClick()
{
    clearClick();
    rownumEx=parseInt(rownumEx) - 1;
    fillDATA();
        document.getElementById('LinkButton1').disabled = false;
        document.getElementById('LinkButton4').disabled = false;
        document.getElementById('LinkButton3').disabled = false;
      document.getElementById('btnnext').disabled = false;
       document.getElementById('btnlast').disabled = false;
     if (rownumEx == 0)
        {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
        }
     else
     {
        document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
     }
     setButtonImages();
 return false;
}
function executeClick()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var deal=document.getElementById('txtdeal').value;
    if(deal!="")
    {
        if (deal.indexOf("(".toString()) > 0)
        {
            var myarray2 = deal.split('(');
              deal = myarray2[1];
              deal = deal.replace(")", '');
            var dealdesc=myarray2[0];
        }
        else
        {
            alert("Please press F2 on Deal");
            document.getElementById('txtdeal').focus();
            return false;
        }
    }
    var agency=document.getElementById('txtagency').value;
    var agencycode="";
    if(agency!="")
    {
        if (agency.indexOf("(".toString()) > 0)
        {
            var myarray1 = agency.split('(');
              agency = myarray1[1];
              agency = agency.replace(")", '');
            var agencyname=myarray1[0];
            agencycode=document.getElementById('hiddenagency').value;
        }
        else
        {
            alert("Please press F2 on Agency");
            document.getElementById('txtagency').focus();
            return false; 
        }
    }
    var client=document.getElementById('txtclient').value;
    if(client!="")
    {
        if (client.indexOf("(".toString()) > 0)
        {
            var myarray = client.split('(');
              client = myarray[1];
              client = client.replace(")", '');
            var clientname=myarray[0];
        }
        else
        {
            alert("Please press F2 on Client");
            document.getElementById('txtclient').focus();
            return false; 
        }
    }
    var bookingid=document.getElementById('txtciobookid').value;
    var dockitno=document.getElementById('txtdockitno1').value;
    var keyno=document.getElementById('txtkeyno').value;
    var rono=document.getElementById('txtrono').value;
    var booking="EL0";
    var bookingdata=tv_booking_transaction.tvbookingexecute(compcode,deal,agencycode,client,bookingid,dockitno,keyno,rono,booking);
    executequery=bookingdata.value;
    if(executequery==null)
      {
        alert(bookingdata.error.description);
        return false;
      }
      rownumEx=0;
      fillDATA();
      document.getElementById('btnModify').disabled = false;
      setButtonImages()
    return false;
}
function deleteCheck()
{
    return false;
}
function exitbook()
{
     if(confirm("Do You Want To Skip This Page"))
     {
          window.close();
     }
     return false;    
}
function bindBookType_Agency()
{
 if(browser!="Microsoft Internet Explorer")
    {
	var c=0;
	  var obj=document.getElementById('drpbooktype');
          obj.options.length = 0; 
        obj.options[0]=new Option("Select Booking Type","0");
	for(c=1;c<=xmlObj.childNodes[15].childNodes.length-1;c=c+4)
             {   
                 obj.options[obj.options.length] = new Option(xmlObj.childNodes[15].childNodes[c].childNodes[0].nodeValue,xmlObj.childNodes[15].childNodes[c+2].childNodes[0].nodeValue);
             }

   }  
   else{
     var c=0;
          if(xmlObj.childNodes(1)==null)
          {
            loadXML('xml/billcycle.xml');
          }
            var obj=document.getElementById('drpbooktype');
          obj.options.length = 0; 
        obj.options[0]=new Option("Select Booking Type","0");

              for(c=0;c<=xmlObj.childNodes(7).childNodes.length-1;c++)
              {
                obj.options[obj.options.length] = new Option(xmlObj.childNodes(7).childNodes(c).text,xmlObj.childNodes(7).childNodes(c+1).text);
                c=c+1;
              } 
              if(obj.options.length>1)
              {
                obj.options[1].selected=true;
              }
   }  
}
function getbillzero()
{
    if(document.getElementById('drpbooktype').value=="2")
        document.getElementById('btnfmg').disabled=false;
    else
         document.getElementById('btnfmg').disabled=true;
    if(document.getElementById('drpbooktype').value=="1")
    {
        document.getElementById('txtbartertype').disabled=false;
     }
    else{
        document.getElementById('txtbartertype').disabled=true;
        document.getElementById('txtbartertype').value="";
        document.getElementById('hiddenbarteramt').value="";
        document.getElementById('hiddenstopbarterbooking').value="";
    }
    document.getElementById('txtgrossamt').value="";
    document.getElementById('txtbillamt').value="";
    if(document.getElementById('txtbillamt').value!="")
    {
      if(document.getElementById('drpbooktype').value=="2" || document.getElementById('drpbooktype').value=="4" || document.getElementById('drpbooktype').value=="5")  
       {
           document.getElementById('txtbillamt').value="0";
           return false;
        }
    }
}
function openFMGRef()
{
var agencycode="";
if(document.getElementById('txtagency').value!="")
     agencycode=document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf("(")+1,document.getElementById('txtagency').value.lastIndexOf(")"));
window.open('fmg_transaction.aspx?fmgInsert='+fmgInsert+'&agencycode='+agencycode,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=600px,height=600px');
}
function getFMGRef()
{
fmgInsert="";
    var res=Booking_master.fetchFMGrefID(document.getElementById('txtciobookid').value);
    if(res.error!=null)
    {
        alert(res.error.description);
        return false;
    }
    var ds=res.value;
    if(ds!=null)
    {
        for(var i=0;i<ds.Tables[0].Rows.length;i++)
        {
        if(fmgInsert=="")
           fmgInsert= ds.Tables[0].Rows[i].INSERTID ;
        else
           fmgInsert= fmgInsert + "$" +ds.Tables[0].Rows[i].INSERTID;   
        }
    }
}
function blankGross()
{
    document.getElementById('txtgrossamt').value="";
     document.getElementById('txtbillamt').value="";
     if(paivar=="Y")
    {
        document.getElementById(document.activeElement.id).value="Y";
    }
}
function saveclick()
{
    var vali=validationalert();
    if(vali.value==false)
     return false;
    
    var adtype="EL0";
    var compcode=document.getElementById('hiddencompcode').value;
    var bookingdate=document.getElementById('txtdatetime').value;
    var branch=document.getElementById('txtbranch').value;
    var bookedby=document.getElementById('txtbookedby').value;
    var bookingid=document.getElementById('txtciobookid').value;
    var prebookingid=document.getElementById('txtprevbook').value;
    var client=document.getElementById('txtclient').value;
    if (client.indexOf("(".toString()) > 0)
    {
        var myarray = client.split('(');
          client = myarray[1];
          client = client.replace(")", '');
        var clientname=myarray[0];
    }
    var agency=document.getElementById('txtagency').value;
    if (agency.indexOf("(".toString()) > 0)
    {
        var myarray1 = agency.split('(');
          agency = myarray1[1];
          agency = agency.replace(")", '');
        var agencyname=myarray1[0];
    }
    var subagency=agency;//this is codesubcode save in SUB_AGENCY field in db
    var deal=document.getElementById('txtdeal').value;
    if (deal.indexOf("(".toString()) > 0)
    {
        var myarray2 = deal.split('(');
          deal = myarray2[1];
          deal = deal.replace(")", '');
        var dealdesc=myarray2[0];
    }
    var clientadd=document.getElementById('txtclientadd').value;
    var agencyadd=document.getElementById('txtagencyaddress').value;
    var agencycode=document.getElementById('drpagscode').value;//this is agencycode save in AGENCY_CODE field in db
    var agencytype=document.getElementById('txtagencytype').value;
    var mobileno=document.getElementById('txtMobile').value;
    var status=document.getElementById('txtagencystatus').value;
    var agencypaymode=document.getElementById('txtagencypaymode').value;
    var creditperiod=document.getElementById('txtcreditperiod').value;
    var rono=document.getElementById('txtrono').value;
    var rodate=document.getElementById('txtrodate').value;
    var rostatus=document.getElementById('drprostatus').value;
    var dockitno=document.getElementById('txtdockitno1').value;
    var keyno=document.getElementById('txtkeyno').value;
    var execode=document.getElementById('txtexecname').value;
    if (execode.indexOf("(".toString()) > 0)
    {
        var myarray3 = execode.split('(');
          execode = myarray3[1];
          execode = execode.replace(")", '');
        var exename=myarray3[0];
    }
    var execzone=document.getElementById('txtexeczone').value;
    var agencyoutstand=document.getElementById('txtagencyoutstand').value;
    var retainer=document.getElementById('drpretainer').value;
    if (retainer.indexOf("(".toString()) > 0)
    {
        var myarray4 = retainer.split('(');
          retainer = myarray4[1];
          retainer = retainer.replace(")", '');
        var retainername=myarray4[0];
    }
    var booktype=document.getElementById('drpbooktype').value;
    var color=document.getElementById('drpcolor').value;
    var adcategory=document.getElementById('drpadcategory').value;
    var appby=document.getElementById('txtappby').value;
    var audit=document.getElementById('txtaudit').value;
    var product=document.getElementById('txtproduct').value;
    if (product.indexOf("(".toString()) > 0)
    {
        var myarray4 = product.split('(');
          product = myarray4[1];
          product = product.replace(")", '');
        var productname=myarray4[0];
    }
    var brand=document.getElementById('drpbrand').value;
    var varient=document.getElementById('drpvarient').value;
    var campain=document.getElementById('txtcamp').value;
    var caption=document.getElementById('txtcaption').value;
    var materialstatus=document.getElementById('drpmatsta').value;
    var bartertype=document.getElementById('txtbartertype').value;
    if (bartertype.indexOf("(".toString()) > 0)
    {
        var myarray5 = bartertype.split('(');
        bartertype = myarray5[1];
        bartertype = bartertype.replace(")", '');
        var bartertypename=myarray5[0];
    }
    var ratecode=document.getElementById('txtratecode').value;
    var cardrate=document.getElementById('txtcardrate').value;
    var cardamt=document.getElementById('txtcardamt').value;
    var contractrate=document.getElementById('txtdealrate').value;
    var deviation=document.getElementById('txtdeviation').value;
//    var agreedrate=document.getElementById('txtagreedrate').value;
//    var agreedamt=document.getElementById('txtagreedamt').value;
    var discount=document.getElementById('txtdiscount').value;
    var discountpre=document.getElementById('txtdiscpre').value;
    var premiumamt=document.getElementById('txtpageamt').value;
    var premiumper=document.getElementById('txtpremper').value;
    var specialdisc=document.getElementById('txtspedisc').value;
    var specialdiscper=document.getElementById('txtspediscper').value;
    var spacialcharges=document.getElementById('txtextracharges').value;
    var addagencycommrate=document.getElementById('txtaddagencycommrate').value;
    var addagencycommrateper=document.getElementById('txtaddagencycommrateamt').value;
    var grossamt=document.getElementById('txtgrossamt').value;
    var Retainercomm=document.getElementById('txtRetainercomm').value;
    var Retainercommper=document.getElementById('txtRetainercommamt').value;
    var billcycle=document.getElementById('drpbillcycle').value;
    var revenue=document.getElementById('drprevenue').value;
    var paymenttype=document.getElementById('drppaymenttype').value;
    var billstatus=document.getElementById('drpbillstatus').value;
    var cashdiscount=document.getElementById('txtcashdiscount').value;
    //var cashdiscount=document.getElementById('txtcashdiscount').value;
    var cashrecieved=document.getElementById('drpcashrecieved').value;
    var carname=document.getElementById('txtcardname').value;
    var cardtype=document.getElementById('drptype').value;
    var expirydate="";
    var drpmonth=document.getElementById('drpmonth').value;
    var drpyear=document.getElementById('drpyear').value;
    var cardno=document.getElementById('txtcardno').value;
    var chqno=document.getElementById('ttextchqno').value;
    var chqamt=document.getElementById('ttextchqamt').value;
    var chqdate=document.getElementById('ttextchqdate').value;
    var bankname=document.getElementById('ttextbankname').value;
    var ourbank=document.getElementById('drpourbank').value;
    var billto=document.getElementById('drpbillto').value;
    var receipt=document.getElementById('txtreceipt').value;
    var tradedisc=document.getElementById('txttradedisc').value;
    var chktrade;
    if(document.getElementById('chktrade').checked==false)
        chktrade="0";
    else
        chktrade="1";
   var billamt=document.getElementById('txtbillamt').value;
   var billremark=document.getElementById('txtbillremark').value;
   var userid=document.getElementById('hiddenuserid').value;
   var fromdealdate=document.getElementById('hiddendaelfromdate').value;
   var todealdate=document.getElementById('hiddendaeltodate').value;
   var flag="0";
   var fmg=fmgInsert;
   if(mode=="0")
   {
     var savedata=tv_booking_transaction.bookingsave(compcode,adtype,bookingdate,branch,bookedby,bookingid,prebookingid,client,agencycode,deal,clientadd,agencyadd,subagency,agencytype,mobileno,status,agencypaymode,creditperiod,rono,rodate,rostatus,dockitno,keyno,execode,execzone,agencyoutstand,retainer,booktype,color,adcategory,appby,audit,product,brand,varient,campain,caption,materialstatus,bartertype,ratecode,cardrate,cardamt,contractrate,deviation,discount,discountpre,premiumamt,premiumper,specialdisc,specialdiscper,spacialcharges,addagencycommrate,addagencycommrateper,grossamt,Retainercomm,Retainercommper,billcycle,revenue,paymenttype,billstatus,cashdiscount,cashrecieved,carname,cardtype,expirydate,drpmonth,drpyear,cardno,chqno,chqamt,chqdate,bankname,ourbank,billto,receipt,tradedisc,chktrade,billamt,billremark,userid,flag,document.getElementById('hidattach1').value,document.getElementById('hidattach2').value,fmg,fromdealdate,todealdate);
       if(savedata.value==null)
          {
            alert(savedata.error.description);
            return false;
          }
       savegrid();
       savehtml();
       alert("Data Save Successfully.")
       clearClick();
   }
   else
   {
   flag="1";
    var savedata=tv_booking_transaction.bookingsave(compcode,adtype,bookingdate,branch,bookedby,bookingid,prebookingid,client,agencycode,deal,clientadd,agencyadd,subagency,agencytype,mobileno,status,agencypaymode,creditperiod,rono,rodate,rostatus,dockitno,keyno,execode,execzone,agencyoutstand,retainer,booktype,color,adcategory,appby,audit,product,brand,varient,campain,caption,materialstatus,bartertype,ratecode,cardrate,cardamt,contractrate,deviation,discount,discountpre,premiumamt,premiumper,specialdisc,specialdiscper,spacialcharges,addagencycommrate,addagencycommrateper,grossamt,Retainercomm,Retainercommper,billcycle,revenue,paymenttype,billstatus,cashdiscount,cashrecieved,carname,cardtype,expirydate,drpmonth,drpyear,cardno,chqno,chqamt,chqdate,bankname,ourbank,billto,receipt,tradedisc,chktrade,billamt,billremark,userid,flag,document.getElementById('hidattach1').value,document.getElementById('hidattach2').value,fmg,fromdealdate,todealdate);
       if(savedata.value==null)
          {
            alert(savedata.error.description);
            return false;
          }
          savegrid();
          savehtml();
   }
   //
   return false;
}
function validationalert()
{
    return false
}

function savegrid()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;  
    var bookingid=document.getElementById('txtciobookid').value;
    var revenue=document.getElementById('txtbranch').value;
    var deal=document.getElementById('txtdeal').value;
    var myarray2 = deal.split('(');
      deal = myarray2[1];
      deal = deal.replace(")", '');
    var flag="0"; 
    var seqno=1;
 if(document.getElementById('tblGridelecbook').rows.length>1)
    {
        for(var i=1;i<document.getElementById('tblGridelecbook').rows.length;i++)
        {
            var channel=document.getElementById('tblGridelecbook').rows[i].cells[0].innerHTML;
            if(channel.indexOf("(")>0)
                channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')')); 
            var location=document.getElementById('tblGridelecbook').rows[i].cells[1].innerHTML;
            if(location.indexOf("(")>0)
                location=location.substring(location.lastIndexOf('(')+1,location.lastIndexOf(')')); 
            var advtype=document.getElementById('tblGridelecbook').rows[i].cells[2].innerHTML;
            if(advtype.indexOf("(")>0)
                advtype=advtype.substring(advtype.lastIndexOf('(')+1,advtype.lastIndexOf(')'));
            var ratetype=document.getElementById('tblGridelecbook').rows[i].cells[3].innerHTML;
            var scheduledate=document.getElementById('tblGridelecbook').rows[i].cells[4].innerHTML;
            var btbcode=document.getElementById('tblGridelecbook').rows[i].cells[5].innerHTML;
            var fromband=document.getElementById('tblGridelecbook').rows[i].cells[6].innerHTML;
            var toband=document.getElementById('tblGridelecbook').rows[i].cells[7].innerHTML;
            var break1=document.getElementById('tblGridelecbook').rows[i].cells[8].innerHTML;
            var position=document.getElementById('tblGridelecbook').rows[i].cells[9].innerHTML;
            var progname=document.getElementById('tblGridelecbook').rows[i].cells[10].innerHTML;
            if(progname.indexOf("(")>0)
                progname=progname.substring(progname.lastIndexOf('(')+1,progname.lastIndexOf(')'));
            var padebonus=document.getElementById('tblGridelecbook').rows[i].cells[11].innerHTML;
            var noofspote=document.getElementById('tblGridelecbook').rows[i].cells[12].innerHTML;
            var tapeid=document.getElementById('tblGridelecbook').rows[i].cells[13].innerHTML;
            var duration=document.getElementById('tblGridelecbook').rows[i].cells[14].innerHTML;
            var rate=document.getElementById('tblGridelecbook').rows[i].cells[15].innerHTML;
            var gross=document.getElementById('tblGridelecbook').rows[i].cells[16].innerHTML;
            var insertid=document.getElementById('tblGridelecbook').rows[i].cells[17].innerHTML;
            var status=document.getElementById('tblGridelecbook').rows[i].cells[18].innerHTML;
            var category=document.getElementById('tblGridelecbook').rows[i].cells[19].innerHTML;
            if(category.indexOf("(")>0)
                category=category.substring(category.lastIndexOf('(')+1,category.lastIndexOf(')'));
            if(document.getElementById('tblGridelecbook').rows[i].cells[17].innerHTML=="")
            {
                flag="0";
                tv_booking_transaction.insertintoelectronicchild(compcode,userid,bookingid,revenue,channel,location,advtype,ratetype,scheduledate,btbcode,fromband,toband,break1,position,progname,padebonus,noofspote,tapeid,duration,rate,gross,flag,insertid,"booked",seqno,category);//
            }
            else
            {
                flag="1";
                tv_booking_transaction.insertintoelectronicchild(compcode,userid,bookingid,revenue,channel,location,advtype,ratetype,scheduledate,btbcode,fromband,toband,break1,position,progname,padebonus,noofspote,tapeid,duration,rate,gross,flag,insertid,'',seqno,category);//
            }
        seqno++;   
        }    
    }
}
function savehtml()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var bookingid=document.getElementById('txtciobookid').value;
    var flag="0";
    if(mode=="0")
    {
        tv_booking_transaction.insertupdatehtml(compcode,bookingid,innertablehtmlforbook,flag);
    }
    else
    {
        flag="1";
        tv_booking_transaction.insertupdatehtml(compcode,bookingid,innertablehtmlforbook,flag);
    }
    
}
function fillDATA()
{
    var msg=checkSession();
     if(msg==false)
     {
        window.location.href="login.aspx";
        return false;
     }
    var dateformat=document.getElementById('hiddendateformat').value;
    if (executequery.Tables[0].Rows.length > 0)
       {
            if(executequery.Tables[0].Rows[rownumEx].PREV_BK_ID!=null && executequery.Tables[0].Rows[rownumEx].PREV_BK_ID!="")
              {
                document.getElementById('txtprevbook').value=executequery.Tables[0].Rows[rownumEx].PREV_BK_ID;
              }
              if(executequery.Tables[0].Rows[rownumEx].ATTACHMENT1!=null && executequery.Tables[0].Rows[rownumEx].ATTACHMENT1!="")
                {
                    document.getElementById('hidattach1').value = executequery.Tables[0].Rows[rownumEx].ATTACHMENT1;
                    document.getElementById('attachment1').src="Images/indexred.jpg";
                }   
                  if(executequery.Tables[0].Rows[rownumEx].ATTACHMENT2!=null && executequery.Tables[0].Rows[rownumEx].ATTACHMENT2!="")
                {
                    document.getElementById('hidattach2').value = executequery.Tables[0].Rows[rownumEx].ATTACHMENT2;
                    document.getElementById('attachment2').src="Images/indexred.jpg";
                }
                if(executequery.Tables[0].Rows[rownumEx].BRANCH!=null)
                {
                    document.getElementById('txtbranch').value = executequery.Tables[0].Rows[rownumEx].BRANCH;
                }
                 else
                {
                     document.getElementById('txtbranch').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].MOBILE_NO!=null)
                {
                    document.getElementById('txtMobile').value = executequery.Tables[0].Rows[rownumEx].MOBILE_NO;
                }    
                else
                {
                     document.getElementById('txtMobile').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].USERNAME!=null)
                {
                    document.getElementById('txtbookedby').value = executequery.Tables[0].Rows[rownumEx].USERNAME;
                }
                else
                {
                    document.getElementById('txtbookedby').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].BK_NUM!=null)
                {
                    document.getElementById('txtciobookid').value = executequery.Tables[0].Rows[rownumEx].BK_NUM;
                }
                else
                {
                    document.getElementById('txtciobookid').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].RO_NUM!=null)
                {
                    document.getElementById('txtrono').value = executequery.Tables[0].Rows[rownumEx].RO_NUM;
                }   
                else
                {
                    document.getElementById('txtrono').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].BK_DATE!=null)
                {
                   document.getElementById('txtdatetime').value = executequery.Tables[0].Rows[rownumEx].BK_DATE;
                }   
                else
                {
                    document.getElementById('txtdatetime').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].CLENT_CODE!=null)
                {
                   document.getElementById('txtclient').value = executequery.Tables[0].Rows[rownumEx].CLENT_CODE;     //.ItemArray[14].ToString();
                }    
                else
                {
                    document.getElementById('txtclient').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].SUB_AGENCY!=null)
                {
                    document.getElementById('txtagency').value = executequery.Tables[0].Rows[rownumEx].SUB_AGENCY;
                }    
                else
                {
                    document.getElementById('txtagency').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].DEAL_NO!=null)
                {
                    document.getElementById('txtdeal').value = executequery.Tables[0].Rows[rownumEx].DEAL_NO;
                }    
                else
                {
                    document.getElementById('txtdeal').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].CLIENT_ADDR!=null)
                {
                    document.getElementById('txtclientadd').value = executequery.Tables[0].Rows[rownumEx].CLIENT_ADDR;
                }    
                else
                {
                    document.getElementById('txtclientadd').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].AGENCY_ADDR!=null)
                {
                    document.getElementById('txtagencyaddress').value = executequery.Tables[0].Rows[rownumEx].AGENCY_ADDR;
                }   
                else
                {
                     document.getElementById('txtagencyaddress').value = "";
                }
                var res2=tv_booking_transaction.bindagencusub(executequery.Tables[0].Rows[rownumEx].SUB_AGENCY1, document.getElementById('hiddencompcode').value);
                var dsbsa = res2.value;
                if(dsbsa==null)
                {
                    alert(res2.error.description);
                    return false;
                }
                document.getElementById('drpagscode').options.length=0;
                document.getElementById('drpagscode').options[0]=new Option("Select Agency","0");
                document.getElementById('drpagscode').options.length = 1; 
                for (var i = 0  ; i < dsbsa.Tables[0].Rows.length; ++i)
                {
                    document.getElementById('drpagscode').options[document.getElementById('drpagscode').options.length] = new Option(dsbsa.Tables[0].Rows[i].agency_name,dsbsa.Tables[0].Rows[i].Agency_Code);
                
                    document.getElementById('drpagscode').options.length;       
                }
                if(executequery.Tables[0].Rows[rownumEx].AGENCY_CODE!=null)
                {
                    document.getElementById('hiddensubcode').value = document.getElementById('drpagscode').value = executequery.Tables[0].Rows[rownumEx].AGENCY_CODE;
                }    
                else
                {
                    document.getElementById('drpagscode').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].AGENCY_TYPE!=null)
                {
                    document.getElementById('txtagencytype').value = executequery.Tables[0].Rows[rownumEx].AGENCY_TYPE;
                }
                if(executequery.Tables[0].Rows[rownumEx].AGENCY_STATUS!=null)
                {
                    document.getElementById('hiddenstatus').value = document.getElementById('txtagencystatus').value = executequery.Tables[0].Rows[rownumEx].AGENCY_STATUS;
                }
                var res3;
                if(executequery.Tables[0].Rows[rownumEx].SUB_AGENCY1!=null)
                {
                res3=tv_booking_transaction.getpayandstatus(executequery.Tables[0].Rows[rownumEx].SUB_AGENCY1, executequery.Tables[0].Rows[rownumEx].AGENCY_CODE, document.getElementById('hiddencompcode').value, document.getElementById('txtdatetime').value,document.getElementById('hiddendateformat').value);
                var dch = res3.value;
                if(dch==null)
                {
                    alert(res3.error.description);
                    return false;
                }
                document.getElementById('txtagencypaymode').options.length=0;
                if (dch.Tables[5].Rows.length > 0)
                {
                    for (var i = 0; i < dch.Tables[5].Rows.length; i++)
                    {
                        document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').options.length] = new Option(dch.Tables[5].Rows[i].payment_mode_name,dch.Tables[5].Rows[i].pay_mode_code);
                    
                        document.getElementById('txtagencypaymode').options.length; 
                       
                    }

                }
                if (dch.Tables[5].Rows.length > 0)
                    {
                        for (var i = 0;  i< dch.Tables[5].Rows.length; i++)
                        {
                           document.getElementById('drppaymenttype').options[document.getElementById('drppaymenttype').options.length] = new Option(dch.Tables[5].Rows[i].payment_mode_name,dch.Tables[5].Rows[i].pay_mode_code);                
                           document.getElementById('drppaymenttype').options.length; 
                        }

                    }
               } 
                if(executequery.Tables[0].Rows[rownumEx].AGENCY_PAY_MODE!=null)
                {
                    document.getElementById('hiddenpay').value =   document.getElementById('txtagencypaymode').value = executequery.Tables[0].Rows[rownumEx].AGENCY_PAY_MODE;
                }    
                if(document.getElementById('txtagencypaymode').value!="")
                    document.getElementById('hiddenpaymode').value = document.getElementById('hiddenpaymode').value=document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').selectedIndex].text;
                    
                if(executequery.Tables[0].Rows[rownumEx].CREDIT_PERIOD!=null)
                {
                    document.getElementById('txtcreditperiod').value = executequery.Tables[0].Rows[rownumEx].CREDIT_PERIOD;
                }
                var ro_date = executequery.Tables[0].Rows[rownumEx].RO_DATE;
                if(ro_date!=null)
                {  
                   document.getElementById('txtrodate').value =RO_DATE;
                }   
                else
                {
                     document.getElementById('txtrodate').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].RO_STATUS!=null)
                {
                    document.getElementById('drprostatus').value = executequery.Tables[0].Rows[rownumEx].RO_STATUS;
                }    
                else
                {
                    document.getElementById('drprostatus').value = "0";
                }
                if(executequery.Tables[0].Rows[rownumEx].DOCKIT_NO!=null)
                {
                    document.getElementById('txtdockitno1').value = executequery.Tables[0].Rows[rownumEx].DOCKIT_NO;
                }   
                else
                {
                    document.getElementById('txtdockitno1').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].KEY_NUM!=null)
                {
                    document.getElementById('txtkeyno').value = executequery.Tables[0].Rows[rownumEx].KEY_NUM;
                }    
                else
                {
                     document.getElementById('txtkeyno').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].EXEC_CODE!=null)
                {
                    document.getElementById('txtexecname').value = executequery.Tables[0].Rows[rownumEx].EXEC_CODE;
                }    
                else
                {
                     document.getElementById('txtexecname').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].EXEC_ZONE!=null)
                {
                    document.getElementById('txtexeczone').value = executequery.Tables[0].Rows[rownumEx].EXEC_ZONE;
                }    
                else
                {
                     document.getElementById('txtexeczone').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].AGENCY_OUTSTAND!=null)
                {
                    document.getElementById('txtagencyoutstand').value = executequery.Tables[0].Rows[rownumEx].AGENCY_OUTSTAND;
                }    
                else
                {
                     document.getElementById('txtagencyoutstand').value = "";
                }
                if(executequery.Tables[0].Rows[rownumEx].RETAINER_CODE!=null)
                {
                    document.getElementById('drpretainer').value = executequery.Tables[0].Rows[rownumEx].RETAINER_CODE;
                }    
                else
                {
                     document.getElementById('drpretainer').value = "";
                }
                bindBookType_Agency();
                if(executequery.Tables[0].Rows[rownumEx].BOOKING_TYPE!=null)
                {
                    document.getElementById('drpbooktype').value = executequery.Tables[0].Rows[rownumEx].BOOKING_TYPE;
                }
                
                if(executequery.Tables[0].Rows[rownumEx].COLOR!=null)
                {
                    document.getElementById('drpcolor').value = executequery.Tables[0].Rows[rownumEx].COLOR;
                }
                if(executequery.Tables[0].Rows[rownumEx].AD_CTG!=null)
                {
                    document.getElementById('drpadcategory').value = executequery.Tables[0].Rows[rownumEx].AD_CTG;
                }
                if(executequery.Tables[0].Rows[rownumEx].APP_BY!=null)
                 {
                    document.getElementById('txtappby').value = executequery.Tables[0].Rows[rownumEx].APP_BY;
                 }  
                 else
                 {
                    document.getElementById('txtappby').value = "";
                 }
                 if(executequery.Tables[0].Rows[rownumEx].AUDITED!=null)
                 {
                    document.getElementById('txtaudit').value = executequery.Tables[0].Rows[rownumEx].AUDITED;
                 }  
                 else
                 {
                    document.getElementById('txtaudit').value = "";
                 }
                 if(executequery.Tables[0].Rows[rownumEx].PROD!=null)
                 {
                    document.getElementById('txtproduct').value = executequery.Tables[0].Rows[rownumEx].PROD;
                 }  
                 else
                 {
                    document.getElementById('txtproduct').value = "";
                 }
                  res2=null;
                    if(executequery.Tables[0].Rows[rownumEx].PROD!=null && executequery.Tables[0].Rows[rownumEx].PROD!="")
                    {
                    res2=tv_booking_transaction.brandbind(document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[rownumEx].PROD1);
                    var dsbrand = res2.value;
                    if(dsbrand==null)
                    {
                        alert(res2.error.description);
                        return false;
                    }
                      document.getElementById('drpbrand').options.length=0;
                      document.getElementById('drpbrand').options[0]=new Option("Select Brand","0");
                      document.getElementById('drpbrand').options.length = 1; 
                        for (var i = 0  ; i < dsbrand.Tables[0].Rows.length; ++i)
                        {
                            document.getElementById('drpbrand').options[document.getElementById('drpbrand').options.length] = new Option(dsbrand.Tables[0].Rows[i].brand_name,dsbrand.Tables[0].Rows[i].brand_code);                        
                            document.getElementById('drpbrand').options.length;       
                        }                        
                   }
                    if (executequery.Tables[0].Rows[rownumEx].BRAND==null || executequery.Tables[0].Rows[rownumEx].BRAND.toString() == "")
                    {
                        document.getElementById('drpbrand').options.length=0;
                        document.getElementById('hiddenbrand').value = "";
                    }
                    else
                    {
                        if(executequery.Tables[0].Rows[rownumEx].BRAND!=null)
                        {
                            document.getElementById('hiddenbrand').value = document.getElementById('drpbrand').value = executequery.Tables[0].Rows[rownumEx].BRAND.toString();
                        }    
                        else
                        {
                            document.getElementById('hiddenbrand').value = "";
                        }
                    }
                    res2=null;
                    res2=tv_booking_transaction.varientbind(document.getElementById('hiddencompcode').value, document.getElementById('hiddenbrand').value);
                   var dsvarient = res2.value;
                   if(dsvarient==null)
                   {
                        alert(res2.error.description)
                        return false;
                   }
                   document.getElementById('drpvarient').options.length=0;
                   document.getElementById('drpvarient').options[0]=new Option("Select Varient","0");
                   document.getElementById('drpvarient').options.length = 1; 
                   for (var i = 0  ; i < dsvarient.Tables[0].Rows.length; ++i)
                   {
                        document.getElementById('drpvarient').options[document.getElementById('drpvarient').options.length] = new Option(dsvarient.Tables[0].Rows[i].varient_name,dsvarient.Tables[0].Rows[i].varient_code);                
                        document.getElementById('drpvarient').options.length;    
                        if(executequery.Tables[0].Rows[0].Brand_code!=null && executequery.Tables[0].Rows[0].VARIENT==document.getElementById('drpvarient').options[i].value)
                        {
                            document.getElementById('hiddenvar').value = document.getElementById('drpvarient').value = executequery.Tables[0].Rows[0].VARIENT.toString();
                        }     
                   } 
                   if (executequery.Tables[0].Rows[0].VARIENT==null || executequery.Tables[0].Rows[0].VARIENT.toString() == "")
                   {
                        document.getElementById('drpvarient').options.length=0;
                        document.getElementById('hiddenvar').value = "";
                   }
                     if(executequery.Tables[0].Rows[rownumEx].COMPAIN!=null)
                     {
                        document.getElementById('txtcamp').value = executequery.Tables[0].Rows[rownumEx].COMPAIN;
                     }  
                     else
                     {
                        document.getElementById('txtcamp').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].CAPTION!=null)
                     {
                        document.getElementById('txtcaption').value = executequery.Tables[0].Rows[rownumEx].CAPTION;
                     }  
                     else
                     {
                        document.getElementById('txtcaption').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].MAT_STATUS!=null)
                     {
                        document.getElementById('drpmatsta').value = executequery.Tables[0].Rows[rownumEx].MAT_STATUS;
                     }  
                     else
                     {
                        document.getElementById('drpmatsta').value = "0";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].BARTER_TYPE!=null)
                     {
                        document.getElementById('txtbartertype').value = executequery.Tables[0].Rows[rownumEx].BARTER_TYPE;
                     }  
                     else
                     {
                        document.getElementById('txtbartertype').value = "";
                     }
                     
                     //ratecode bind
                     if(executequery.Tables[0].Rows[rownumEx].RATE_CODE!=null)
                     {
                        document.getElementById('txtratecode').value = executequery.Tables[0].Rows[rownumEx].RATE_CODE;
                     }  
                     else
                     {
                        document.getElementById('txtratecode').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].CARD_RATE!=null)
                     {
                        document.getElementById('txtcardrate').value = executequery.Tables[0].Rows[rownumEx].CARD_RATE;
                     }  
                     else
                     {
                        document.getElementById('txtcardrate').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].CARD_AMT!=null)
                     {
                        document.getElementById('txtcardamt').value = executequery.Tables[0].Rows[rownumEx].CARD_AMT;
                     }  
                     else
                     {
                        document.getElementById('txtcardamt').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].CONTRACT_RATE!=null)
                     {
                        document.getElementById('txtdealrate').value = executequery.Tables[0].Rows[rownumEx].CONTRACT_RATE;
                     }  
                     else
                     {
                        document.getElementById('txtdealrate').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].DAVIATION!=null)
                     {
                        document.getElementById('txtdeviation').value = executequery.Tables[0].Rows[rownumEx].DAVIATION;
                     }  
                     else
                     {
                        document.getElementById('txtdeviation').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].DISCOUNT_AMT!=null)
                     {
                        document.getElementById('txtdiscount').value = executequery.Tables[0].Rows[rownumEx].DISCOUNT_AMT;
                     }  
                     else
                     {
                        document.getElementById('txtdiscount').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].DISC_PER!=null)
                     {
                        document.getElementById('txtdiscpre').value = executequery.Tables[0].Rows[rownumEx].DISC_PER;
                     }  
                     else
                     {
                        document.getElementById('txtdiscpre').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].PREMIUM_AMT!=null)
                     {
                        document.getElementById('txtpageamt').value = executequery.Tables[0].Rows[rownumEx].PREMIUM_AMT;
                     }  
                     else
                     {
                        document.getElementById('txtpageamt').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].PREMIUM_PER!=null)
                     {
                        document.getElementById('txtpremper').value = executequery.Tables[0].Rows[rownumEx].PREMIUM_PER;
                     }  
                     else
                     {
                        document.getElementById('txtpremper').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].SPECIAL_DISC!=null)
                     {
                        document.getElementById('txtspedisc').value = executequery.Tables[0].Rows[rownumEx].SPECIAL_DISC;
                     }  
                     else
                     {
                        document.getElementById('txtspedisc').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].SPECIAL_PER!=null)
                     {
                        document.getElementById('txtspediscper').value = executequery.Tables[0].Rows[rownumEx].SPECIAL_PER;
                     }  
                     else
                     {
                        document.getElementById('txtspediscper').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].SPECIAL_CHARGES!=null)
                     {
                        document.getElementById('txtextracharges').value = executequery.Tables[0].Rows[rownumEx].SPECIAL_CHARGES;
                     }  
                     else
                     {
                        document.getElementById('txtextracharges').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM!=null)
                     {
                        document.getElementById('txtaddagencycommrate').value = executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM;
                     }  
                     else
                     {
                        document.getElementById('txtaddagencycommrate').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM_PER!=null)
                     {
                        document.getElementById('txtaddagencycommrateamt').value = executequery.Tables[0].Rows[rownumEx].ADD_AGENCY_COMM_PER;
                     }  
                     else
                     {
                        document.getElementById('txtaddagencycommrateamt').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].GROSS_AMT!=null)
                     {
                        document.getElementById('txtgrossamt').value = executequery.Tables[0].Rows[rownumEx].GROSS_AMT;
                     }  
                     else
                     {
                        document.getElementById('txtgrossamt').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].RETAINER_COMM!=null)
                     {
                        document.getElementById('txtRetainercomm').value = executequery.Tables[0].Rows[rownumEx].RETAINER_COMM;
                     }  
                     else
                     {
                        document.getElementById('txtRetainercomm').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].RETAINER_COMM_PER!=null)
                     {
                        document.getElementById('txtRetainercommamt').value = executequery.Tables[0].Rows[rownumEx].RETAINER_COMM_PER;
                     }  
                     else
                     {
                        document.getElementById('txtRetainercommamt').value = "";
                     }
                     if(executequery.Tables[0].Rows[rownumEx].BILL_CYCLE!=null)
                        {
                            document.getElementById('drpbillcycle').value = executequery.Tables[0].Rows[rownumEx].BILL_CYCLE;
                        }
                    if(executequery.Tables[0].Rows[rownumEx].Revenue_center!=null)
                    {
                        document.getElementById('drprevenue').value = executequery.Tables[0].Rows[rownumEx].Revenue_center;
                    }    
                    if(document.getElementById('drprevenue').selectedIndex!="-1")
                    {
                    document.getElementById('hiddenbranch').value = document.getElementById('drprevenue').options[document.getElementById('drprevenue').selectedIndex].text;//drprevenue.SelectedItem.Text.ToString();
                    }
                    document.getElementById('drppaymenttype').options.length=0;
                    if (dch.Tables[5].Rows.length > 0)
                    {
                        for (var i = 0;  i< dch.Tables[5].Rows.length; i++)
                        {
                           document.getElementById('drppaymenttype').options[document.getElementById('drppaymenttype').options.length] = new Option(dch.Tables[5].Rows[i].payment_mode_name,dch.Tables[5].Rows[i].pay_mode_code);                
                           document.getElementById('drppaymenttype').options.length; 
                        }

                    }
                    if(executequery.Tables[0].Rows[rownumEx].Bill_pay!=null)
                    {    
                        document.getElementById('hiddenbillpay').value = document.getElementById('drppaymenttype').value = executequery.Tables[0].Rows[rownumEx].PAYMENT_TYPE;
                    }
                    if(executequery.Tables[0].Rows[rownumEx].BILL_STATUS!=null)
                        {
                            document.getElementById('drpbillstatus').value = executequery.Tables[0].Rows[rownumEx].BILL_STATUS;
                        }                    
                    res3=null;
                    if(executequery.Tables[0].Rows[0].SUB_AGENCY1!=null)
                    {
                        res3=tv_booking_transaction.bindbillto_ag(executequery.Tables[0].Rows[0].SUB_AGENCY1, document.getElementById('hiddencompcode').value);
                        var dbt = res3.value;
                        if(dbt==null)
                        {
                            alert(res3.error.description);
                            return false;
                        }          
                        
                        ////////////////////////////////////////////////////
                        document.getElementById('drpbillto').options.length=0;
                        var client_val=document.getElementById('txtclient').value;
                         var client_name=document.getElementById('txtclient').value;
                         if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0)
                        {
                            client_val =document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(")+1,document.getElementById('txtclient').value.length-1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                            client_name=document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                         }  
                        document.getElementById('drpbillto').options[0] = new Option(client_name,client_val);                
                        for (var k = 0; k < dbt.Tables[0].Rows.length; k++)
                        {
                            if(dbt.Tables[0].Rows[k].bill_to=="")
                            document.getElementById('drpbillto').options[document.getElementById('drpbillto').options.length] = new Option(dbt.Tables[0].Rows[k].agency_name,dbt.Tables[0].Rows[k].SUB_agency_code);                
                            else
                            document.getElementById('drpbillto').options[document.getElementById('drpbillto').options.length] = new Option(dbt.Tables[0].Rows[k].agency_name,dbt.Tables[0].Rows[k].bill_to);                
                            document.getElementById('drpbillto').options.length; 
                        }
                    }
                    if(executequery.Tables[0].Rows[rownumEx].BILL_TO!=null)
                    {
                        document.getElementById('hiddenbillto').value = executequery.Tables[0].Rows[rownumEx].BILL_TO;
                    }                   
                     if(executequery.Tables[0].Rows[rownumEx].BILL_TO!=null)
                        {
                            document.getElementById('drpbillto').value = executequery.Tables[0].Rows[rownumEx].BILL_TO;
                        }
                 
                  if(executequery.Tables[0].Rows[0].RECIEPT_NUM!=null)
                    { 
                        document.getElementById('hiddenreceiptno').value =  document.getElementById('txtreceipt').value = executequery.Tables[0].Rows[0].RECIEPT_NUM;
                    }
                  else 
                     document.getElementById('hiddenreceiptno').value =  document.getElementById('txtreceipt').value ="";  
                     
                 if(executequery.Tables[0].Rows[0].AGENCY_COMM!=null)
                    { 
                        document.getElementById('txttradedisc').value = executequery.Tables[0].Rows[0].AGENCY_COMM;
                    }
                  else 
                     document.getElementById('txttradedisc').value =""; 
                 if(executequery.Tables[0].Rows[0].CHK_AGENCY_COMM!=null && executequery.Tables[0].Rows[0].CHK_AGENCY_COMM!="1")
                    { 
                        document.getElementById('chktrade').checked=false
                    }
                    else
                        document.getElementById('chktrade').checked=true;
                        
                    if(executequery.Tables[0].Rows[rownumEx].BILL_AMOUNT!=null)
                    {
                        document.getElementById('txtbillamt').value = executequery.Tables[0].Rows[rownumEx].BILL_AMOUNT;
                    }
                    if(executequery.Tables[0].Rows[rownumEx].BILL_AMOUNT!=null)
                    {
                        document.getElementById('txtbillamt').value = executequery.Tables[0].Rows[rownumEx].BILL_AMOUNT;
                    }
                 if(executequery.Tables[0].Rows[rownumEx].BILL_REMARK!=null)
                    {
                        document.getElementById('txtbillremark').value = executequery.Tables[0].Rows[rownumEx].BILL_REMARK;
                    }
                 if(executequery.Tables[0].Rows[rownumEx].FROM_DEAL_DATE!=null)
                     {
                        document.getElementById("hiddendaelfromdate").value = executequery.Tables[0].Rows[rownumEx].FROM_DEAL_DATE;
                     }  
                     else
                     {
                        document.getElementById("hiddendaelfromdate").value = "";
                     }
                   if(executequery.Tables[0].Rows[rownumEx].TO_DEAL_DATE!=null)
                     {
                        document.getElementById("hiddendaeltodate").value = executequery.Tables[0].Rows[rownumEx].TO_DEAL_DATE;
                     }  
                     else
                     {
                        document.getElementById("hiddendaeltodate").value = "";
                     }
                 
                 
                 
                 
                 
                 
                 
                 bindgrid();
                 bindhtml();
                 
                 document.getElementById('LinkButton1').disabled = false;
                 document.getElementById('LinkButton4').disabled = false;
                 document.getElementById('LinkButton3').disabled = false;
                if(document.getElementById('drpbooktype').value=="2")
                getFMGRef();
       }
       else
        {
            alert("Your Search Produces No Result");
            clearClick();
            return false;
        }
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;

        var count = executequery.Tables[0].Rows.length - 1;
        if (executequery.Tables[0].Rows.length - 1 == 0)
        {
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
            document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
        }
        
          if(rownumEx == count)
         {
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnnext').disabled = true;
         }
         else
         {
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnnext').disabled = false;
         }
     
}
function bindgrid()
{
    var bookingid=document.getElementById('txtciobookid').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var fachdata=tv_booking_transaction.tvbookingexecutedet(compcode,bookingid);
    document.getElementById("tblGridelecbook").outerHTML="<TABLE id=tblGridelecbook style=\"BORDER-COLLAPSE: collapse\" borderColor=#7daae5 width=1000 cellSpacing=0 cellPadding=0 border=1 name=\"tblGridelec\"><TBODY></TBODY><THEAD><TR bgColor=#7daae3><TD class=tdcls align=middle width=100>Channel</TD><TD class=tdcls align=middle width=100>Location</TD><TD class=tdcls align=middle width=100>Adv Type</TD><TD class=tdcls align=middle width=100>Rate Type(UOM)</TD><TD class=tdcls align=middle width=100>Schedule Date</TD><TD class=tdcls align=middle width=80>BTB</TD><TD class=tdcls align=middle width=100>From Band</TD><TD class=tdcls align=middle width=100>To Band</TD><TD class=tdcls align=middle width=80>Break</TD><TD class=tdcls align=middle width=100>Position</TD><TD class=tdcls align=middle width=80>Program</TD><TD class=tdcls align=middle width=100>Paid/ Bonus</TD><TD class=tdcls align=middle width=100>No Of Spot</TD><TD class=tdcls align=middle width=80>Tape Id</TD><TD class=tdcls align=middle width=100>Duration</TD><TD class=tdcls align=middle width=80>Rate</TD><TD class=tdcls align=middle width=100>Gross Amt</TD><TD class=tdcls align=middle width=100>InsertId</TD><TD class=tdcls align=middle width=100>Status</TD><TD class=tdcls align=middle width=100>Ad Category</TD></TR></THEAD><TBODY><TR><TD class=tdcls>0</TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD><TD class=tdcls></TD></TR></TBODY></TABLE>";
   document.getElementById("div_electronicbook").style.display="block";
   element1 = document.getElementById ('tblGridelecbook');
   var ds_tv=fachdata.value;
   if(ds_tv!=null)
   {
        if(ds_tv.Tables[0].Rows.length>0)
        {
           for(var i=0;i<ds_tv.Tables[0].Rows.length;i++)
             { 
               if(i>0)
                {
                  addRow('','','','','','','','','','','','','','','','','','','','');
                }
                if(ds_tv.Tables[0].Rows[i].CHANNEL!=null)
                    element1.rows[i+1].cells[0].innerHTML=ds_tv.Tables[0].Rows[i].CHANNEL;
                else
                    element1.rows[i+1].cells[0].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].LOCCD!=null)
                    element1.rows[i+1].cells[1].innerHTML=ds_tv.Tables[0].Rows[i].LOCCD;
                else
                    element1.rows[i+1].cells[1].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].AD_TYPE!=null)
                    element1.rows[i+1].cells[2].innerHTML=ds_tv.Tables[0].Rows[i].AD_TYPE;
                else
                    element1.rows[i+1].cells[2].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].RATE_TYPE!=null)
                    element1.rows[i+1].cells[3].innerHTML=ds_tv.Tables[0].Rows[i].RATE_TYPE;
                else
                    element1.rows[i+1].cells[3].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].AIR_DATE!=null)
                    {          
	                    var txt1=ds_tv.Tables[0].Rows[i].AIR_DATE;
	                    var txt2=txt1.split("/");
	                    var mm=txt2[1];
	                    var dd=txt2[0];
	                    var yy=txt2[2];
	                    txtbussinessdate1=dd+'/'+mm+'/'+yy;	            
                        element1.rows[i+1].cells[4].innerHTML=txtbussinessdate1;
                    }
                else
                    element1.rows[i+1].cells[4].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].BTB_CODE!=null)
                    element1.rows[i+1].cells[5].innerHTML=ds_tv.Tables[0].Rows[i].BTB_CODE;
                else
                    element1.rows[i+1].cells[5].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].FR_BND_CODE!=null)
                    element1.rows[i+1].cells[6].innerHTML=ds_tv.Tables[0].Rows[i].FR_BND_CODE;
                else
                    element1.rows[i+1].cells[6].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].TO_BND_CODE!=null)
                    element1.rows[i+1].cells[7].innerHTML=ds_tv.Tables[0].Rows[i].TO_BND_CODE;
                else
                    element1.rows[i+1].cells[7].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].BRK_CODE!=null)
                    element1.rows[i+1].cells[8].innerHTML=ds_tv.Tables[0].Rows[i].BRK_CODE;
                else
                    element1.rows[i+1].cells[8].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].POS!=null)
                    element1.rows[i+1].cells[9].innerHTML=ds_tv.Tables[0].Rows[i].POS;
                else
                    element1.rows[i+1].cells[9].innerHTML="";
                if(ds_tv.Tables[0].Rows[i].PRG_ID!=null)
                    element1.rows[i+1].cells[10].innerHTML=ds_tv.Tables[0].Rows[i].PRG_ID;
                else
                    element1.rows[i+1].cells[10].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].PAID_BONUS!=null)
                    element1.rows[i+1].cells[11].innerHTML=ds_tv.Tables[0].Rows[i].PAID_BONUS;
                else
                    element1.rows[i+1].cells[11].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].NO_OF_SPOT!=null)
                    element1.rows[i+1].cells[12].innerHTML=ds_tv.Tables[0].Rows[i].NO_OF_SPOT;
                else
                    element1.rows[i+1].cells[12].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].CLIP_ID!=null)
                    element1.rows[i+1].cells[13].innerHTML=ds_tv.Tables[0].Rows[i].CLIP_ID;
                else
                    element1.rows[i+1].cells[13].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].DUR!=null)
                    element1.rows[i+1].cells[14].innerHTML=ds_tv.Tables[0].Rows[i].DUR;
                else
                    element1.rows[i+1].cells[14].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].RATE!=null)
                    element1.rows[i+1].cells[15].innerHTML=ds_tv.Tables[0].Rows[i].RATE;
                else
                    element1.rows[i+1].cells[15].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].GRS_AMT!=null)
                    element1.rows[i+1].cells[16].innerHTML=ds_tv.Tables[0].Rows[i].GRS_AMT;
                else
                    element1.rows[i+1].cells[16].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].INSERT_ID!=null)
                    element1.rows[i+1].cells[17].innerHTML=ds_tv.Tables[0].Rows[i].INSERT_ID;
                else
                    element1.rows[i+1].cells[17].innerHTML=""
                if(ds_tv.Tables[0].Rows[i].BOOK_STATUS!=null)
                    element1.rows[i+1].cells[18].innerHTML=ds_tv.Tables[0].Rows[i].BOOK_STATUS;
                else
                    element1.rows[i+1].cells[18].innerHTML=""    
                if(ds_tv.Tables[0].Rows[i].CATEGORY_CODE!=null)
                    element1.rows[i+1].cells[19].innerHTML=ds_tv.Tables[0].Rows[i].CATEGORY_CODE;
                else
                    element1.rows[i+1].cells[19].innerHTML="";
             }
        }         
   }
    
}
function addRow ()
  {
    var objTR = document.createElement ("TR");
    var objTD = document.createElement ("TD");

    for (var i = 0; i < addRow.arguments.length; i++) 
    {
      objTD = document.createElement ("TD");
      objTD.className="tdcls";
      objTD.appendChild (document.createTextNode ((arguments[i]=="")?"":arguments[i]));
      objTR.insertAdjacentElement ("beforeEnd", objTD);
    }

    objTBody = element1.tBodies [1];
    objTBody.insertAdjacentElement ("beforeEnd", objTR);

    resizeDivs ();
  }
  var intColCount = 0;
  function resizeDivs ()
  {
    for (var i = 0; i < intColCount; i++)
    {  
      var objDiv = element1.document.getElementById ("DragMark" + (i));
      var objTD = element1.tHead.childNodes[0].childNodes[i];

      if ((!objDiv) || (!objTD) || (objTD.tagName != "TD")) return;
      objDiv.style.height = (element1.tBodies[0].childNodes.length + 1) * (objTD.offsetHeight - 1);
    }
  }
  function bindhtml()
  {
    var bookingid=document.getElementById('txtciobookid').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var fachhtml=tv_booking_transaction.tvbookinghtml(compcode,bookingid);
    var htmlval=fachhtml.value;
    if(htmlval==null)
      {
        alert(fachhtml.error.description);
        return false;
      }
      if(htmlval!=null)
        {
            if(htmlval.Tables[0].Rows.length>0)
                {
                    innertablehtmlforbook=htmlval.Tables[0].Rows[0].HTMLFORMAT;
                }
        }
  }
    function showcreditdetail()
    {
        if(document.getElementById('drppaymenttype').value=="CA0")
        {
             if(!confirm("Are you sure want to take paymode Cash"))
             {
                document.getElementById('drppaymenttype').value=0;
             }
        }
        var ag=tv_booking_transaction.GETCASH_PAY(document.getElementById('hiddencompcode').value,document.getElementById('drppaymenttype').value);
        var ds_n=ag.value;
        var cashdiscount='N';
        if(ds_n!=null && ds_n.Tables[0].Rows.length>0)
        {
            cashdiscount=ds_n.Tables[0].Rows[0].CASHDISCOUNT;
        }
        document.getElementById('txtbillamt').value="";    
        document.getElementById('txtagencypaymode').value=document.getElementById('drppaymenttype').value;
        if(document.getElementById('txtagencypaymode').selectedIndex!=-1)
        document.getElementById('hiddenpaymode').value=document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').selectedIndex].text;
        if(document.getElementById('drppaymenttype').value=="CR0")  //CR0 is Credit Card code
        {          
            document.getElementById('tdcarname').style.display="";
            document.getElementById('tdtxtcarname').style.display="";
            document.getElementById('tdtype').style.display="";
            document.getElementById('tddrptyp').style.display="";
            document.getElementById('tdexdat').style.display="";
            
            document.getElementById('tdtxtexdat').style.display="";
            document.getElementById('tdcardno').style.display="";
            document.getElementById('tdtxtcarno').style.display="";
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            
             document.getElementById('txtcardname').disabled=false;
            document.getElementById('drptype').disabled=false;
            document.getElementById('drpmonth').disabled=false;
            document.getElementById('drpyear').disabled=false;
            document.getElementById('txtcardno').disabled=false;
            
            document.getElementById('tdrec').style.display="none";
            document.getElementById('receipt').style.display="none";
            document.getElementById('print').style.display="none";   
            
            document.getElementById('tdchqno').style.display="none";
            document.getElementById('tdchqdate').style.display="none";
            document.getElementById('tdchqamt').style.display="none";
            document.getElementById('tdbankname').style.display="none";
             document.getElementById('tdourbank').style.display="none";
         
            
            document.getElementById('tdtextchqno').style.display="none";            
            document.getElementById('tdtextchqdate').style.display="none";
            document.getElementById('tdtextchqamt').style.display="none";
            document.getElementById('tdtextbankname').style.display="none"; 
                document.getElementById('tdtextourbank').style.display="none";            
             
            document.getElementById("txtreceipt").value=""; 
            if(cashdiscount=='N')
             {
                document.getElementById('cashrecvd').style.display="none";
                 document.getElementById('drpcashrecieved').disabled = true; 
                document.getElementById('txtcashdiscount').disabled =true; 
             }
             else   
             {
                document.getElementById('cashrecvd').style.display="";
                 document.getElementById('drpcashrecieved').disabled = false; 
             document.getElementById('txtcashdiscount').disabled =false; 
             }      
           //  document.getElementById('tdcashrecvd').style.display="none";
//             document.getElementById('drpcashrecieved').disabled = true;  
//             document.getElementById('txtcashdiscount').disabled =true;  
        }
        else if(document.getElementById('drppaymenttype').value=="CH0" || document.getElementById('drppaymenttype').value=="DD0"   || document.getElementById('drppaymenttype').value=='PO0')  //CR0 is Credit Card code and DD0 is demand draft
        {          
            document.getElementById('ttextchqno').disabled = false;  
             document.getElementById('drpourbank').disabled=false;                      
            document.getElementById('ttextchqdate').disabled = false;
            document.getElementById('ttextchqamt').disabled = false;
            document.getElementById('ttextbankname').disabled = false;
            document.getElementById('tdchqno').style.display="";
            document.getElementById('tdchqdate').style.display="";
            document.getElementById('tdchqamt').style.display="";
            document.getElementById('tdbankname').style.display="";
            document.getElementById('tdourbank').style.display="";
            
            
            document.getElementById('tdtextchqno').style.display="";            
            document.getElementById('tdtextchqdate').style.display="";
            document.getElementById('tdtextchqamt').style.display="";
            document.getElementById('tdtextbankname').style.display="";
             document.getElementById('tdtextourbank').style.display="";
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            
            document.getElementById('tdrec').style.display="none";
            document.getElementById('receipt').style.display="none";
            document.getElementById('print').style.display="none";   
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";
             
             document.getElementById("txtreceipt").value=""; 
             if(cashdiscount=='N')
             {
                document.getElementById('cashrecvd').style.display="none";
                 document.getElementById('drpcashrecieved').disabled = true; 
                document.getElementById('txtcashdiscount').disabled =true; 
             }
             else   
             {
                document.getElementById('cashrecvd').style.display="";
                 document.getElementById('drpcashrecieved').disabled = false; 
             document.getElementById('txtcashdiscount').disabled =false; 
             }   
             //document.getElementById('tdcashrecvd').style.display="none";
//             document.getElementById('drpcashrecieved').disabled = true;  
//             document.getElementById('txtcashdiscount').disabled =true;  
         }
         else if(document.getElementById('drppaymenttype').value=="CA0")
         {
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";
            
            document.getElementById('txtcardname').value="";
            document.getElementById('drptype').value="0";
            document.getElementById('drpmonth').value="0";
            document.getElementById('drpyear').value="0";
            document.getElementById('txtcardno').value="";
            document.getElementById("txtreceipt").value="";
            
            document.getElementById('tdchqno').style.display="none";
            document.getElementById('tdchqdate').style.display="none";
            document.getElementById('tdchqamt').style.display="none";
            document.getElementById('tdbankname').style.display="none";
            document.getElementById('tdourbank').style.display="none";
            
            document.getElementById('tdtextchqno').style.display="none";            
            document.getElementById('tdtextchqdate').style.display="none";
            document.getElementById('tdtextchqamt').style.display="none";
            document.getElementById('tdtextbankname').style.display="none";
              document.getElementById('tdtextourbank').style.display="none";
              
            document.getElementById('ttextchqno').value="";  
             document.getElementById('drpourbank').value="0";               
            document.getElementById('ttextchqdate').value="";   
            document.getElementById('ttextchqamt').value="";   
            document.getElementById('ttextbankname').value=""; 
             if(cashdiscount=='N')
             {
                document.getElementById('cashrecvd').style.display="none";
                 document.getElementById('drpcashrecieved').disabled = true; 
                document.getElementById('txtcashdiscount').disabled =true; 
             }
             else   
             {
                document.getElementById('cashrecvd').style.display="";
                 document.getElementById('drpcashrecieved').disabled = false; 
             document.getElementById('txtcashdiscount').disabled =false; 
             }   
            // document.getElementById('tdcashrecvd').style.display="";
//             document.getElementById('drpcashrecieved').disabled = false;  
//             document.getElementById('txtcashdiscount').disabled =false;  
             document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
           
         }
         else 
         {
             if(cashdiscount=='N')
             {
                document.getElementById('cashrecvd').style.display="none";
                 document.getElementById('drpcashrecieved').disabled = true; 
                document.getElementById('txtcashdiscount').disabled =true; 
             }
             else   
             {
                document.getElementById('cashrecvd').style.display="";
                 document.getElementById('drpcashrecieved').disabled = false; 
             document.getElementById('txtcashdiscount').disabled =false; 
             }   
           //  document.getElementById('tdcashrecvd').style.display="none";
              
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";
            
            document.getElementById('txtcardname').value="";
            document.getElementById('drptype').value="0";
            document.getElementById('drpmonth').value="0";
            document.getElementById('drpyear').value="0";
            document.getElementById('txtcardno').value="";
            document.getElementById("txtreceipt").value="";
            
            document.getElementById('tdchqno').style.display="none";
            document.getElementById('tdchqdate').style.display="none";
            document.getElementById('tdchqamt').style.display="none";
            document.getElementById('tdbankname').style.display="none";
            document.getElementById('tdourbank').style.display="none";
            
            document.getElementById('tdtextchqno').style.display="none";            
            document.getElementById('tdtextchqdate').style.display="none";
            document.getElementById('tdtextchqamt').style.display="none";
            document.getElementById('tdtextbankname').style.display="none";
              document.getElementById('tdtextourbank').style.display="none";
              
            document.getElementById('ttextchqno').value="";  
             document.getElementById('drpourbank').value="0";               
            document.getElementById('ttextchqdate').value="";   
            document.getElementById('ttextchqamt').value="";   
            document.getElementById('ttextbankname').value="";   
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
        }
        return false;    
    }
    function notchar2()
    {
       
        if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
        {
            return true;
        }
        else
        {   
            return false;
        }
    }
    function notchar2_book(event,strValue) 
    {
        var num=document.getElementById(strValue.id).value;
        ////var tomatch=/^\d*(\.\d{1,2})?$/;
        //if (tomatch.test(num))
        if(document.getElementById(strValue.id).value.indexOf(".")>=0)
        {
        if(event.keyCode==46)
        {
        alert("Input error");
        document.getElementById(strValue.id).value="";
        document.getElementById(strValue.id).focus();
        return false;
        }
        else
        return true; 
        }
        else
        {
        //alert("Input error");
        //document.getElementById(strValue.id).value="";
        //document.getElementById(strValue.id).focus();

        return true; 

        }
     }
     function dateenter(event)
    {
    //if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
        if((event.keyCode>=46 && event.keyCode<=57) ||(event.keyCode>=96 && event.keyCode<=105)|| (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
function divopen()
{
 changediv();
}