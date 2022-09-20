// JScript File

function bindclientname_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstclient");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Client-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
            //alert(pkgitem.options.length);
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
        
            pkgitem.options.length;       
        }    
    }
    document.getElementById('txtclient').value="";
    document.getElementById("lstclient").value="0";
    document.getElementById("lstclient").focus();  //uncomment
    
     return false;
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
    document.getElementById('txtagency').value="";
    document.getElementById("lstagency").value="0";
    document.getElementById("lstagency").focus();
    return false;
}
 //this is to bind the list box for exec name

    function bindexecname_callback(response)
    {
         ds=response.value;
         var pkgitem = document.getElementById("lstexec");
         pkgitem.options.length = 0; 
         pkgitem.options[0]=new Option("-Select Exec-","0");
         if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
         {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].exec_name,ds.Tables[0].Rows[i].exe_no);                
               pkgitem.options.length;               
            }
         }
         document.getElementById('txtexecname').value="";
         document.getElementById("lstexec").value="0";
         if(document.getElementById("lstexec").style.visibility=="hidden")
            document.getElementById("lstexec").style.visibility="visible";
         document.getElementById("lstexec").focus();
         return false;

    }
/////////////////Function for tabvalue//////////////////////////////////////////////////////////////
function tabvalue(event)
{
var browser=navigator.appName;
 if(event.keyCode==113)  
    {
           
        if(document.activeElement.id=="txtagency")
        {
            if(document.getElementById('txtagency').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtagency').value="";
            return false;
            }
            document.getElementById("div1").style.display="block";
        
            if(browser != "Microsoft Internet Explorer")
            {
                  document.getElementById('div1').style.top= 155;
                  document.getElementById('div1').style.left= 390;
//                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/(-6) + "px";
//                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                  document.getElementById('div1').style.top= 155;
                  document.getElementById('div1').style.left= 390;
//                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
//                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }
            ROapproval.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtagency').value.toUpperCase(),bindagencyname_callback);
        
        }
        else if(document.activeElement.id=="txtclient")
        {
            if(document.getElementById('txtclient').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtclient').value="";
            return false;
            }
            document.getElementById("divclient").style.display="block";
            if(browser!="Microsoft Internet Explorer")
            {       
                  document.getElementById('divclient').style.top= 172;
                  document.getElementById('divclient').style.left= 390;
//                document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/+(-6) + "px";
//                document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                  document.getElementById('divclient').style.top= 172;
                  document.getElementById('divclient').style.left= 390;
//                document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
//                document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }
            ROapproval.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value.toUpperCase(),bindclientname_callback);
        }
        else if(document.activeElement.id=="txtexecname")
        {
           if(document.getElementById('txtexecname').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtexecname').value="";
            return false;
            }
            document.getElementById("divexec").style.display="block";
            if(browser!="Microsoft Internet Explorer")
            {
                  document.getElementById('divexec').style.top= 172;
                  document.getElementById('divexec').style.left= 390;
//                document.getElementById('divexec').style.top=parseInt(document.getElementById('txtexecname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdexec').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/ +(-6) + "px";
//                document.getElementById('divexec').style.left=parseInt(document.getElementById('txtexecname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdexec').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                  document.getElementById('divexec').style.top= 195;
                  document.getElementById('divexec').style.left= 390;
//                document.getElementById('divexec').style.top=parseInt(document.getElementById('txtexecname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdexec').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
//                document.getElementById('divexec').style.left=parseInt(document.getElementById('txtexecname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdexec').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }
            ROapproval.bindExec(document.getElementById('hiddencompcode').value,document.getElementById('txtexecname').value.toUpperCase(),bindexecname_callback);
        }
    }
else if(event.keyCode==27)
    {
    if(document.getElementById("div1").style.display=="block")
        {
            document.getElementById("div1").style.display="none"
            document.getElementById('txtagency').focus();
        }
    else if(document.getElementById("divclient").style.display=="block")
        {
            document.getElementById("divclient").style.display="none"
            document.getElementById('txtclient').focus();
        }
    else if(document.getElementById("divexec").style.display=="block")
        {
            document.getElementById("divexec").style.display="none"
            document.getElementById('txtexecname').focus();
        }   
    }
   else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
    {
       /* if(document.activeElement.id.indexOf("txtagency")>=0)
        {
            if(document.getElementById('txtagency').value=="")
            {
                alert("Please Enter Agency");
                document.getElementById('txtagency').focus();
                return false;
            }
        }
          if(document.activeElement.id.indexOf("txtclient")>=0)
        {
          if(document.getElementById('txtclient').value=="")
          {
            alert("Please Enter Client");
            document.getElementById('txtclient').focus();
            return false;
          }  
        }  
        else */
        if(document.activeElement.id=="lstclient")
        {
            if(document.getElementById('lstclient').value=="0")
            {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclient").style.display="none";
            var datetime="";
                /*@@ this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                    address and if 0 than agency name and address @@@@@@@@@@@@@@@@@@@*/
     
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
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
                xml.Send();
                id=xml.responseText;
            }
            var split=id.split("+");
            var namecode=split[0];
            var add=split[1];        
            document.getElementById('txtclient').value=namecode;
            
           /* if(document.getElementById('hiddensavemod').value=="0")
            {
                document.getElementById('txtclientadd').value=add;
                document.getElementById('txtclientadd').focus();
            }
            bind_agen_bill();*/
            document.getElementById('txtexecname').focus();
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
            var datetime="";
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
        
            document.getElementById('txtagency').value=nameagen;
           /* if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
            {
                document.getElementById('txtagencyaddress').value=agenadd;                
                document.getElementById('txtclient').focus();
                Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
            }*/
            document.getElementById('txtclient').focus();
            return false;
        }
    
    ///this is for exec name
        else if(document.activeElement.id=="lstexec")
        {
            if(document.getElementById('lstexec').value=="0")
            {
                alert("Please select the executive");
                return false;
            }
      
            document.getElementById("divexec").style.display="none";
            var datetime="";
        
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
          /*  Booking_master.getexeczone(page,document.getElementById('hiddencompcode').value,call_bindexeczone);
            if(document.getElementById('txtagencyoutstand').disabled==false)
            {
                document.getElementById('txtagencyoutstand').focus();
            }
            else
            {
                changediv();
            }*/
            document.getElementById('btnSubmit').focus();
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
                
        document.getElementById('txtagency').value=nameagen;
        
        /*if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
        {
              document.getElementById('txtagencyaddress').value=agenadd;
                
              document.getElementById('txtclient').focus();
              Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
        }*/
        document.getElementById('txtclient').focus();
        return false;
    }
 else if(document.activeElement.id=="lstclient")
    {
       if(document.getElementById('lstclient').value=="0")
        {
            alert("Please select the client");
            return false;
        }
        document.getElementById("divclient").style.display="none";
        var datetime="";
        //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
     
        var page=document.getElementById('lstclient').value;
       
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
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
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
             xml.Send();
             id=xml.responseText;
        }
         if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         var split=id.split("+");
         var namecode=split[0];
         var add=split[1];

        
        document.getElementById('txtclient').value=namecode;
      
         
       /* if(document.getElementById('hiddensavemod').value=="0")
        {
            document.getElementById('txtclientadd').value=add;        
            document.getElementById('txtclientadd').focus();
        }
         bind_agen_bill();*/
        document.getElementById('txtexecname').focus();
        
        return false;
    }
 ///this is for exec name
    else if(document.activeElement.id=="lstexec")
    {
     if(document.getElementById('lstexec').value=="0")
        {
        alert("Please select the executive");
        return false;
        }
        document.getElementById("divexec").style.display="none";
           var datetime="";
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address and if 2 than its for product and 3 for exec
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
        var page=document.getElementById('lstexec').value;
        //agencycodeglo=page;
        
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
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
             xml.Send();
             id=xml.responseText;
        }
         
         if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
        document.getElementById('txtexecname').value=id;
        
        
       /* document.getElementById('txtexeczone').focus();
        Booking_master.getexeczone(page,document.getElementById('hiddencompcode').value,call_bindexeczone);*/
        return false;
    }
}
function openremark(res,stat)
{
var win;
bookid=res;
appstat=stat;
insid="";
 win=window.open('Ro_AppRemark.aspx?bookid='+bookid+'&appstat='+appstat+'&insid='+insid,"Remarks1",'width=240px,height=190,resizable=0,left=200,top=0,scrollbars=yes');
 win.focus();
}
function clicksubmit()
{
remark=document.getElementById('lbremark').value.toUpperCase();
bookid=document.getElementById('bookingid').value;
userid=document.getElementById('hiddenuserid').value;
appstatus=document.getElementById('appstatus').value;
instid=document.getElementById('insertid').value;
Ro_AppRemark.insertrem(remark,userid,appstatus,bookid,instid)
}
function openbooking1(bkid)
{
var win;
bookid=bkid;
win=window.open('RoBookingdata.aspx?bookid='+bookid,"Remarks",'width=700px,height=500,resizable=0,left=200,top=0,scrollbars=yes');
win.focus();
}
function openremark1(res,inid,stat)
{
bookid=res;
appstat=stat;
insid=inid;
var win;
win=window.open('Ro_AppRemark.aspx?bookid='+bookid+'&appstat='+appstat+'&insid='+insid,"Remarks1",'width=240px,height=190,resizable=0,left=200,top=0,scrollbars=yes');
win.focus();
//Response.Redirect("<script> window.open('"Ro_AppRemark.aspx?bookid='"+bookid+"'&appstat='"+appstat+"'&insid='"+insid,'Remarks','"width=250px,height=230,resizable=0,left=200,top=0,scrollbars=yes"');</script>");
}