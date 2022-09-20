// JScript File

function FOCUS_FIRST1()
{
document.getElementById('dppubcent').focus();

}

function bindQBC()
{
    rofileform.fillQBC(document.getElementById('dppubcent').value,bindQBC_callback);
}

function bindQBC_callback(response)
{
    var ds=response.value;
    agcatby = document.getElementById("drpbranch");
    agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Branch--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
    //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].Branch_Code);
        
            agcatby.options.length;       
        }
    }
}

function fetchbranch()
{



 document.getElementById("hiddenbran").value=document.getElementById("drpbranch").value;


}
function fetchtalu()
{



 document.getElementById("hiddentalu").value=document.getElementById("DropDownList3").value;


}
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
    document.getElementById('txtclient1').value="";
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
    document.getElementById('txtagency1').value="";
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
    function bindretainer_callback(res)
{
    var ds=res.value;
    var pkgitem = document.getElementById("lstretainer");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Retainer-","0");
    
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name,ds.Tables[0].Rows[i].Retain_Code);                
                pkgitem.options.length;               
            }
            
        }
        document.getElementById("lstretainer").style.display="block";
        document.getElementById('dpretainer').value="";          
        document.getElementById("lstretainer").value="0";
        if(document.getElementById("lstretainer").style.display != "none")
            document.getElementById("lstretainer").focus();
        return false;    
}
/////////////////Function for tabvalue//////////////////////////////////////////////////////////////
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
                  document.getElementById('div1').style.left= 390;
//                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency1').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/(-6) + "px";
//                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency1').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                  document.getElementById('div1').style.top= 110;
                  document.getElementById('div1').style.left= 390;
//                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency1').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
//                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency1').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }
            rofileform.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtagency1').value.toUpperCase(),bindagencyname_callback);
        
        }
        else if(document.activeElement.id=="txtclient1")
        {
            if(document.getElementById('txtclient1').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtclient1').value="";
            return false;
            }
            document.getElementById("divclient").style.display="block";
            if(browser!="Microsoft Internet Explorer")
            {       
                  document.getElementById('divclient').style.top= 112;
                  document.getElementById('divclient').style.left= 480;
//                document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient1').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/+(-6) + "px";
//                document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient1').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                  document.getElementById('divclient').style.top= 112;
                  document.getElementById('divclient').style.left= 480;
//                document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient1').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
//                document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient1').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }
            rofileform.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient1').value.toUpperCase(),bindclientname_callback);
        }
        else if(document.activeElement.id=="txtexecname")
        {
            if(confirm('Are you sure you want to Take Executive'))
                {
                   if(document.getElementById('txtexecname').value.length <=2)
                    {
                    alert("Please Enter Minimum 3 Character For Searching.");
                    document.getElementById('txtexecname').value="";
                    return false;
                    }
                    document.getElementById('dpretainer').value='';
                    document.getElementById("divexec").style.display="block";
                    if(browser!="Microsoft Internet Explorer")
                    {
                          document.getElementById('divexec').style.top= 112;
                          document.getElementById('divexec').style.left= 480;
        //                document.getElementById('divexec').style.top=parseInt(document.getElementById('txtexecname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdexec').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/ +(-6) + "px";
        //                document.getElementById('divexec').style.left=parseInt(document.getElementById('txtexecname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdexec').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
                    }
                    else
                    {
                          document.getElementById('divexec').style.top= 112;
                          document.getElementById('divexec').style.left= 480;
        //                document.getElementById('divexec').style.top=parseInt(document.getElementById('txtexecname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdexec').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
        //                document.getElementById('divexec').style.left=parseInt(document.getElementById('txtexecname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdexec').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
                    }
                    rofileform.bindExec(document.getElementById('hiddencompcode').value,document.getElementById('txtexecname').value.toUpperCase(),bindexecname_callback);
                 }
        }
        else if(document.activeElement.id=="dpretainer")
        {
            if(confirm('Are you sure you want to Take Retainer'))
                {
                document.getElementById('txtexecname').value="";
                if(document.getElementById('dpretainer').value.length <=2)
                    {
                    alert("Please Enter Minimum 3 Character For Searching.");
                    document.getElementById('dpretainer').value="";
                    return false;
                    }
                  document.getElementById("divretainer").style.display="block";
                    if(browser!="Microsoft Internet Explorer")
                    {
                        document.getElementById('divretainer').style.top=112;
                        document.getElementById('divretainer').style.left=480;
                        //document.getElementById('divretainer').style.top=parseInt(document.getElementById('dpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/ +(-6) + "px";
                        //document.getElementById('divretainer').style.left=parseInt(document.getElementById('dpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
                    }
                    else
                    {
                        document.getElementById('divretainer').style.top=112;
                        document.getElementById('divretainer').style.left=480;
                        //document.getElementById('divretainer').style.top=parseInt(document.getElementById('dpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
                        //document.getElementById('divretainer').style.left=parseInt(document.getElementById('dpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
                    }
                    rofileform.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('dpretainer').value.toUpperCase(),bindretainer_callback);
             }
        }
    }
    
else if(event.keyCode==27)
    {
    if(document.getElementById("div1").style.display=="block")
        {
            document.getElementById("div1").style.display="none"
            document.getElementById('txtagency1').focus();
        }
    else if(document.getElementById("divclient").style.display=="block")
        {
            document.getElementById("divclient").style.display="none"
            document.getElementById('txtclient1').focus();
        }
    else if(document.getElementById("divexec").style.display=="block")
        {
            document.getElementById("divexec").style.display="none"
            document.getElementById('txtexecname').focus();
        }   
    else if(document.getElementById("divretainer").style.display=="block")
        {
            document.getElementById("divretainer").style.display="none"
            document.getElementById('dpretainer').focus();
        }
    }
   else if(event.keyCode==13)
    {
       /* if(document.activeElement.id.indexOf("txtagency1")>=0)
        {
            if(document.getElementById('txtagency1').value=="")
            {
                alert("Please Enter Agency");
                document.getElementById('txtagency1').focus();
                return false;
            }
        }
          if(document.activeElement.id.indexOf("txtclient1")>=0)
        {
          if(document.getElementById('txtclient1').value=="")
          {
            alert("Please Enter Client");
            document.getElementById('txtclient1').focus();
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
            document.getElementById('txtclient1').value=namecode;
            
           /* if(document.getElementById('hiddensavemod').value=="0")
            {
                document.getElementById('txtclient1add').value=add;
                document.getElementById('txtclient1add').focus();
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
            document.getElementById('txtexecname').focus();
            return false;
        }
        ///for retainer//////
        else if(document.activeElement.id=="lstretainer")
        {   
             if(document.getElementById('lstretainer').value == "0")
               {
                alert("Please select the Retainer");
                            return false;
                  }
              else
              {
                document.getElementById('dpretainer').value=document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text +"("+document.getElementById('lstretainer').value+")" ;
                document.getElementById('lstretainer').style.display="none";
                 return false;
                 }
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
            if(document.getElementById('txtagency1outstand').disabled==false)
            {
                document.getElementById('txtagency1outstand').focus();
            }
            else
            {
                changediv();
            }*/
            document.getElementById('txtclient1').focus();
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
        document.getElementById('txtclient1').focus();
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

        
        document.getElementById('txtclient1').value=namecode;
      
         
       /* if(document.getElementById('hiddensavemod').value=="0")
        {
            document.getElementById('txtclient1add').value=add;        
            document.getElementById('txtclient1add').focus();
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

function bind_taluka()
{
var compcode=document.getElementById('hiddencompcode').value;
var district=document.getElementById('drpdist').value;
rofileform.bindtaluka(compcode,district,call_bind_taluka);

}

function call_bind_taluka(response)
{

ds= response.value;
    var city=document.getElementById('DropDownList3');
    city.options.length=0;
    city.options[0]=new Option("Select Taluka");
    document.getElementById("DropDownList3").options.length = 1;
   

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 city.options[city.options.length] = new Option(ds.Tables[0].Rows[i].taluname,ds.Tables[0].Rows[i].talucode);
                city.options.length;   
             }
 }        
 
       return false;
}
function mandat()
{
refreshControl();
        if(document.getElementById('txtvalidityfrom').value=="")
            {

                alert('Please Enter  From Date');
                document.getElementById('txtvalidityfrom').focus();
                return false;

            }
        if(document.getElementById('txttilldate').value=="")
            {

                alert('Please Enter  To Date');
                document.getElementById('txttilldate').focus();
                return false;

            }
            document.getElementById('btnsave1').disabled=true;
            document.getElementById('txtremarks').disabled=true;
            document.getElementById('txtremarks').value="";
            document.getElementById('btnsub').disabled=true;
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
function showretainervalue()
{    
   if(document.getElementById('lstretainer').value == "0")
   {
    alert("Please select the Retainer");
                return false;
      }
      else
      {
    document.getElementById('dpretainer').value=document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text +"("+document.getElementById('lstretainer').value+")" ;
    document.getElementById('lstretainer').style.display="none";
      return false;
   }
}
function refreshControl()
{
document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
document.getElementById('txtretainername').style.backgroundColor="#FFFFFF";
document.getElementById('txtratecode').style.backgroundColor="#FFFFFF";
document.getElementById('txtclient').style.backgroundColor="#FFFFFF";
document.getElementById('txtadsubcat4').style.backgroundColor="#FFFFFF";
document.getElementById('txtpaymode').style.backgroundColor="#FFFFFF";
document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFFFF";
document.getElementById('txtcardrate').style.backgroundColor="#FFFFFF";
document.getElementById('txtagreedamount').style.backgroundColor="#FFFFFF";
document.getElementById('txtarea').style.backgroundColor="#FFFFFF";
document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";
document.getElementById('txtgrossamt').style.backgroundColor="#FFFFFF";
document.getElementById('txtspacediscount').style.backgroundColor="#FFFFFF";
document.getElementById('txtcardamount').style.backgroundColor="#FFFFFF";
document.getElementById('txtcontractname').style.backgroundColor="#FFFFFF";
document.getElementById('txtaddagecomm').style.backgroundColor="#FFFFFF";
document.getElementById('txtpackage').style.backgroundColor="#FFFFFF";
document.getElementById('txtdiscount').style.backgroundColor="#FFFFFF";
document.getElementById('txtbillamount').style.backgroundColor="#FFFFFF";
document.getElementById('txtpageposition').style.backgroundColor="#FFFFFF";
document.getElementById('txtexecutivename').style.backgroundColor="#FFFFFF";
document.getElementById('txtlines').style.backgroundColor="#FFFFFF";
document.getElementById('txtbookingtype').style.backgroundColor="#FFFFFF";
document.getElementById('txtheight').style.backgroundColor="#FFFFFF";
document.getElementById('txtcolourtype').style.backgroundColor="#FFFFFF";
document.getElementById('txtwidth').style.backgroundColor="#FFFFFF";
//document.getElementById('txtbrand').style.backgroundColor="#FFFFFF";
document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFFFF";
//document.getElementById('txtproduct').style.backgroundColor="#FFFFFF";
document.getElementById('txtdiscount').style.backgroundColor="#FFFFFF";
document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";

document.getElementById('txtschemetype').style.backgroundColor="#FFFFFF";
//document.getElementById('txtpositionpre').style.backgroundColor="#FFFFFF";
//document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFFFF";
document.getElementById('txtpaid').style.backgroundColor="#FFFFFF";
document.getElementById('txtpublishdate').style.backgroundColor="#FFFFFF";
document.getElementById('txtwidth').style.backgroundColor="#FFFFFF";
//document.getElementById('txtcurrencytype').style.backgroundColor="#FFFFFF";
document.getElementById('txtpositionpremium').style.backgroundColor="#FFFFFF";
document.getElementById('txtretainercommission').style.backgroundColor="#FFFFFF";
document.getElementById('txtadcategory').style.backgroundColor="#FFFFFF";
document.getElementById('txtadsubcat1').style.backgroundColor="#FFFFFF";
document.getElementById('txtuom').style.backgroundColor="#FFFFFF";
document.getElementById('txtoutstanding').style.backgroundColor="#FFFFFF";
document.getElementById('txtadsubcat2').style.backgroundColor="#FFFFFF";
document.getElementById('txtspecialcharge').style.backgroundColor="#FFFFFF";
document.getElementById('txtadsubcat3').style.backgroundColor="#FFFFFF";
document.getElementById('txtrono').style.backgroundColor="#FFFFFF";
document.getElementById('txtrostatus').style.backgroundColor="#FFFFFF";
}
function checklenthnew1()
{
if(document.getElementById('hidden1').value=="0")
{
alert('Searching criteria does not produce any result');
if(document.getElementById('DataGrid1')!=null)
document.getElementById('DataGrid1').outerHTML="";
return false;
}


}
var glo_amt
function openbooking1(cioid,id,length,edition,insertion)
{
refreshControl();
if(id!="undefined")
{
    document.getElementById('hiddenid').value = id;
}
var i=0;
for(i=0;i<parseInt(length);i++)
{
    document.getElementById('cio'+i).style.color="blue";
}

document.getElementById(document.getElementById('hiddenid').value).style.color="red";
document.getElementById('hiddenbookingid').value=cioid;
//var adtype=edition.value;

document.getElementById('btnsave1').disabled=false;
document.getElementById('txtremarks').disabled=false;
document.getElementById('btnsub').disabled=false;
glo_amt=rofileform.fetchamt(cioid,document.getElementById('hiddencompcode').value);
rofileform.execute(cioid,document.getElementById('hiddencompcode').value,edition,document.getElementById('hiddendateformat').value,exec_callback1);


    //alert("bhanu");
}
function exec_callback1(response)
{
    var ds=response.value;
    var len=ds.Tables[0].Rows.length;
    if(len!="0")
    {
    if(document.getElementById('hiddenrefresh').value=='1')
    {
        if(ds.Tables[0].Rows[0].AgencyName!=ds.Tables[2].Rows[0].AgencyName)
        {
         document.getElementById('txtagency').style.backgroundColor="#FFFF80";
        }
        else
        {
         document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
        }
        if(ds.Tables[0].Rows[0].AgencySubCode!=ds.Tables[2].Rows[0].AgencySubCode)
         {
             document.getElementById('txtagencysubcode').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtagencysubcode').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].Client!=ds.Tables[2].Rows[0].Client)
         {
             document.getElementById('txtclient').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtclient').style.backgroundColor="#FFFFFF";
         }
         
           if(ds.Tables[0].Rows[0].Agency_type!=ds.Tables[2].Rows[0].Agency_type)
         {
             document.getElementById('txtagencytype').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtagencytype').style.backgroundColor="#FFFFFF";
         }
         
             if(ds.Tables[0].Rows[0].Agency_address!=ds.Tables[2].Rows[0].Agency_address)
         {
             document.getElementById('txtadress2').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtadress2').style.backgroundColor="#FFFFFF";
         }
         
            if(ds.Tables[0].Rows[0].Client_address!=ds.Tables[2].Rows[0].Client_address)
         {
             document.getElementById('txtaddress1').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtaddress1').style.backgroundColor="#FFFFFF";
         }
         
               if(ds.Tables[0].Rows[0].Agency_status!=ds.Tables[2].Rows[0].Agency_status)
         {
             document.getElementById('txtstatus').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtstatus').style.backgroundColor="#FFFFFF";
         }
         
               if(ds.Tables[0].Rows[0].PayMode!=ds.Tables[2].Rows[0].PayMode)
         {
             document.getElementById('txtpaymode').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpaymode').style.backgroundColor="#FFFFFF";
         }
         
                  if(ds.Tables[0].Rows[0].Agency_credit!=ds.Tables[2].Rows[0].Agency_credit)
         {
             document.getElementById('txtcreditperiod').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtcreditperiod').style.backgroundColor="#FFFFFF";
         }
         
                     if(ds.Tables[0].Rows[0].RO_No!=ds.Tables[2].Rows[0].RO_No)
         {
             document.getElementById('txtrono').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtrono').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].RO_Date!=ds.Tables[2].Rows[0].RO_Date)
         {
             document.getElementById('txtrodate').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtrodate').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].ro_status!=ds.Tables[2].Rows[0].ro_status)
         {
             document.getElementById('txtrostatus').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtrostatus').style.backgroundColor="#FFFFFF";
         }
         
            if(ds.Tables[0].Rows[0].Dockit_no!=ds.Tables[2].Rows[0].Dockit_no)
         {
             document.getElementById('txtdockitno').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtdockitno').style.backgroundColor="#FFFFFF";
         }
         
              if(ds.Tables[0].Rows[0].Key_no!=ds.Tables[2].Rows[0].Key_no)
         {
             document.getElementById('txtkeyno').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtkeyno').style.backgroundColor="#FFFFFF";
         }
         
                  if(ds.Tables[0].Rows[0].execname!=ds.Tables[2].Rows[0].execname)
         {
             document.getElementById('txtexecutivename').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtexecutivename').style.backgroundColor="#FFFFFF";
         }
         
        if(ds.Tables[0].Rows[0].Executive_zone!=ds.Tables[2].Rows[0].Executive_zone)
         {
             document.getElementById('txtexecutivezone').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtexecutivezone').style.backgroundColor="#FFFFFF";
         }
        
        if(ds.Tables[0].Rows[0].Agency_out!=ds.Tables[2].Rows[0].Agency_out)
         {
             document.getElementById('txtoutstanding').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtoutstanding').style.backgroundColor="#FFFFFF";
         }
         
           if(ds.Tables[0].Rows[0].categoryname!=ds.Tables[2].Rows[0].categoryname)
         {
             document.getElementById('txtadcategory').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtadcategory').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].subcategoryname!=ds.Tables[2].Rows[0].subcategoryname)
         {
             document.getElementById('txtadsubcat').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtadsubcat').style.backgroundColor="#FFFFFF";
         }
         
           
         if(ds.Tables[0].Rows[0].Brand!=ds.Tables[2].Rows[0].Brand)
         {
             document.getElementById('txtbrand').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtbrand').style.backgroundColor="#FFFFFF";
         }
         
           if(ds.Tables[0].Rows[0].product!=ds.Tables[2].Rows[0].product)
         {
             document.getElementById('txtproduct').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtproduct').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].UOM!=ds.Tables[2].Rows[0].UOM)
         {
             document.getElementById('txtuom').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtuom').style.backgroundColor="#FFFFFF";
         }
         
          if(ds.Tables[0].Rows[0].PagePremium!=ds.Tables[2].Rows[0].PagePremium)
         {
             document.getElementById('txtpagepremium').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpagepremium').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].PositionPremium!=ds.Tables[2].Rows[0].PositionPremium)
         {
             document.getElementById('txtpositionpremium').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpositionpremium').style.backgroundColor="#FFFFFF";
         }
           if(ds.Tables[0].Rows[0].Ad_size_column!=ds.Tables[2].Rows[0].Ad_size_column)
         {
             document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFFFF";
         }
         
          if(ds.Tables[0].Rows[0].Ad_size_height!=ds.Tables[2].Rows[0].Ad_size_height)
         {
             document.getElementById('txtheight').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtheight').style.backgroundColor="#FFFFFF";
         }
         
          if(ds.Tables[0].Rows[0].Ad_size_width!=ds.Tables[2].Rows[0].Ad_size_width)
         {
             document.getElementById('txtwidth').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtwidth').style.backgroundColor="#FFFFFF";
         }
         
           if(ds.Tables[0].Rows[0].Currency!=ds.Tables[2].Rows[0].Currency)
         {
             document.getElementById('txtcurrencytype').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtcurrencytype').style.backgroundColor="#FFFFFF";
         }  
         
         if(ds.Tables[0].Rows[0].Insertion_date!=ds.Tables[2].Rows[0].Insertion_date)
         {
             document.getElementById('txtpublishdate').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpublishdate').style.backgroundColor="#FFFFFF";
         }  
         
         if(ds.Tables[0].Rows[0].No_of_insertion!=ds.Tables[2].Rows[0].No_of_insertion)
         {
             document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFFFF";
         }  
         
         
          if(ds.Tables[0].Rows[0].Contract_name!=ds.Tables[2].Rows[0].Contract_name)
         {
             document.getElementById('txtcontractname').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtcontractname').style.backgroundColor="#FFFFFF";
         }  
         
          if(ds.Tables[0].Rows[0].Paid_ins!=ds.Tables[2].Rows[0].Paid_ins)
         {
             document.getElementById('txtpaid').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpaid').style.backgroundColor="#FFFFFF";
         } 
          if(ds.Tables[0].Rows[0].Card_amount!=ds.Tables[2].Rows[0].Card_amount)
         {
             document.getElementById('txtcardamount').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtcardamount').style.backgroundColor="#FFFFFF";
         } 
         
           if(ds.Tables[0].Rows[0].Agrred_rate!=ds.Tables[2].Rows[0].Agrred_rate)
         {
             document.getElementById('txtagreedrate').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";
         } 
         
           if(ds.Tables[0].Rows[0].Special_discount!=ds.Tables[2].Rows[0].Special_discount)
         {
             document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFFFF";
         } 
         
           if(ds.Tables[0].Rows[0].Discount!=ds.Tables[2].Rows[0].Discount)
         {
             document.getElementById('txtdiscount').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtdiscount').style.backgroundColor="#FFFFFF";
         } 
          
     }   
     
     //////////////////////////////////////////////////////////////////////
      if(ds.Tables[0].Rows[0].uom_desc==null)
    {
        document.getElementById('txtlines').value="";
        document.getElementById('txtarea').value="";
     }   
      else  {
        if(ds.Tables[0].Rows[0].uom_desc=='CD')
        {
           document.getElementById('txtlines').value="";
           document.getElementById('txtarea').value=ds.Tables[0].Rows[0].Total_area;
           
        }
        else
        {
            document.getElementById('txtlines').value=ds.Tables[0].Rows[0].Total_area;
            document.getElementById('txtarea').value="";
        }
         //document.getElementById('txtlines').value=ds.Tables[0].Rows[0].Total_area;
    }
    if(ds.Tables[0].Rows[0].AgencyName==null)
    {
        document.getElementById('txtagency').value=="";
    }
    else
    {
        document.getElementById('txtagency').value=ds.Tables[0].Rows[0].AgencyName;
     }
         
     
     
     if(ds.Tables[0].Rows[0].Package_cod==null)
     {
     document.getElementById('txtpackage').value="";
     }
     else
     {
     document.getElementById('txtpackage').value=ds.Tables[0].Rows[0].Package_cod;
     }
    if(ds.Tables[0].Rows[0].Client==null)
    {
    document.getElementById('txtclient').value="";
    }
    else
    {
    document.getElementById('txtclient').value=ds.Tables[0].Rows[0].Client;
    }
    if(ds.Tables[0].Rows[0].Agreed_amount==null)
    {
    document.getElementById('txtagreedamount').value="";
    }
    else
    {
     document.getElementById('txtagreedamount').value=ds.Tables[0].Rows[0].Agreed_amount;
    }
    if(ds.Tables[0].Rows[0].Space_discount==null)
    {
    document.getElementById('txtspacediscount').value="";
    }
    else
    {
    document.getElementById('txtspacediscount').value=ds.Tables[0].Rows[0].Space_discount;
    }
   if(ds.Tables[0].Rows[0].Special_charges==null)
   {
   document.getElementById('txtspecialcharge').value="";
   }
   else
   {
   document.getElementById('txtspecialcharge').value=ds.Tables[0].Rows[0].Special_charges;
   }
   if(ds.Tables[0].Rows[0].RETAINER1==null)
   {
   document.getElementById('txtretainername').value="";
   }
   else
   {
   document.getElementById('txtretainername').value=ds.Tables[0].Rows[0].RETAINER1;
   }
   if(ds.Tables[0].Rows[0].PayMode==null)
   {
   document.getElementById('txtpaymode').value="";
   }
   else
   {
   document.getElementById('txtpaymode').value=ds.Tables[0].Rows[0].PayMode;
   }
   if(ds.Tables[0].Rows[0].ADD_AGENCY_COMM==null)
   {
   document.getElementById('txtaddagecomm').value="";
   }
   else
   {
   document.getElementById('txtaddagecomm').value=ds.Tables[0].Rows[0].ADD_AGENCY_COMM;
   }
   if(ds.Tables[0].Rows[0].RO_No==null)
   {
   document.getElementById('txtrono').value="";
   }
   else
   {
   document.getElementById('txtrono').value=ds.Tables[0].Rows[0].RO_No;
   }
   if(ds.Tables[0].Rows[0].Book_type==null)
   {
   document.getElementById('txtbookingtype').value="";
   }
   else
   {
   document.getElementById('txtbookingtype').value=ds.Tables[0].Rows[0].Book_type;
   }
   if(ds.Tables[0].Rows[0].ro_status==null)
   {
   document.getElementById('txtrostatus').value="";
   }
   else
   {
   if(ds.Tables[0].Rows[0].ro_status=='1')
   {
    document.getElementById('txtrostatus').value='Confirm';
   }
   else{
    document.getElementById('txtrostatus').value='UnConfirm';
    }
   }
   if(ds.Tables[0].Rows[0].Page_position_cod==null)
   {
   document.getElementById('txtpageposition').value="";
   }
   else
   {
   document.getElementById('txtpageposition').value=ds.Tables[0].Rows[0].Page_position_cod;
   }
   if(ds.Tables[0].Rows[0].SUBCAT3==null || ds.Tables[0].Rows[0].SUBCAT3=="0")
   {
   document.getElementById('txtadsubcat2').value="";
   }
   else
   {
   document.getElementById('txtadsubcat2').value=ds.Tables[0].Rows[0].SUBCAT3;
   }
   if(ds.Tables[0].Rows[0].execname==null)
   {
   document.getElementById('txtexecutivename').value="";
   }
   else
   {
   document.getElementById('txtexecutivename').value=ds.Tables[0].Rows[0].execname;
   }
   if(ds.Tables[0].Rows[0].Scheme_type_code==null)
   {
   document.getElementById('txtschemetype').value="";
   }
   else
   {
   document.getElementById('txtschemetype').value=ds.Tables[0].Rows[0].Scheme_type_code;
   }
   if(ds.Tables[0].Rows[0].Agency_out==null)
   {
   document.getElementById('txtoutstanding').value="";
   }
   else
   {
   document.getElementById('txtoutstanding').value=ds.Tables[0].Rows[0].Agency_out;
   }
   if(ds.Tables[0].Rows[0].categoryname==null)
   {
   document.getElementById('txtadcategory').value="";
   }
   else
   {
   document.getElementById('txtadcategory').value=ds.Tables[0].Rows[0].categoryname;
   }
  
  if(glo_amt.value.Tables[0].Rows[0].RECEIVED_AMT==null)
   {
   document.getElementById('txtbillrecamt').value="0";
   }
   else
   {
   document.getElementById('txtbillrecamt').value=glo_amt.value.Tables[0].Rows[0].RECEIVED_AMT;
   }
  
   if(ds.Tables[0].Rows[0].Bill_amount==null)
   {
   document.getElementById('txtbillamount').value="0";
   }
   else
   {
   document.getElementById('txtbillamount').value=ds.Tables[0].Rows[0].Bill_amount;
   }
   
  document.getElementById('txtbillbalamt').value= parseFloat(document.getElementById('txtbillamount').value)-parseFloat(document.getElementById('txtbillrecamt').value);
   
   if(ds.Tables[0].Rows[0].Rate_code==null)
    {
        document.getElementById('txtratecode').value="";
    }
    else
    {
        document.getElementById('txtratecode').value=ds.Tables[0].Rows[0].Rate_code;
    }
    if(ds.Tables[0].Rows[0].Card_rate==null)
    {
    document.getElementById('txtcardrate').value="";
    }
    else
    {
    document.getElementById('txtcardrate').value=ds.Tables[0].Rows[0].Card_rate;
    }
   if(ds.Tables[0].Rows[0].UOM==null)
   {
   document.getElementById('txtuom').value=""
   }
   else
   {
   document.getElementById('txtuom').value=ds.Tables[0].Rows[0].UOM;
   }
   if(ds.Tables[0].Rows[0].SUBCAT4==null || ds.Tables[0].Rows[0].SUBCAT4=="null")
   {
   document.getElementById('txtadsubcat3').value="";
   }
   else
   {
   document.getElementById('txtadsubcat3').value=ds.Tables[0].Rows[0].SUBCAT4;
   }
   if(ds.Tables[0].Rows[0].SUBCAT5==null)
   {
   document.getElementById('txtadsubcat4').value="";
   }
   else
   {
   document.getElementById('txtadsubcat4').value=ds.Tables[0].Rows[0].SUBCAT5;
   }
   if(ds.Tables[0].Rows[0].PositionPremium==null)
   {
    document.getElementById('txtpositionpremium').value="";
   }
   else
   {
   document.getElementById('txtpositionpremium').value=ds.Tables[0].Rows[0].PositionPremium;
   }
   if(ds.Tables[0].Rows[0].RO_COMMENT==null)
    {
        document.getElementById('txtremarks').value=""
    }
    else
    {
        document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].RO_COMMENT;
    }
   if(ds.Tables[0].Rows[0].RETAINER_COMM==null)
   {
    document.getElementById('txtretainercommission').value="";
   }
   else
   {
   document.getElementById('txtretainercommission').value=ds.Tables[0].Rows[0].RETAINER_COMM;
   }
   if(ds.Tables[0].Rows[0].Trade_disc==null)
   {
   document.getElementById('txtagtradediscount').value="";
   }
   else
   {
   document.getElementById('txtagtradediscount').value=ds.Tables[0].Rows[0].Trade_disc;
   }
   if(ds.Tables[0].Rows[0].height==null)
   {
   document.getElementById('txtheight').value="";
   }
   else
   {
   document.getElementById('txtheight').value=ds.Tables[0].Rows[0].height;
   }
   if(ds.Tables[0].Rows[0].width==null)
   {
   document.getElementById('txtwidth').value=""
   }
   else
   {
   document.getElementById('txtwidth').value=ds.Tables[0].Rows[0].width;
   }
   if(ds.Tables[0].Rows[0].subcategoryname==null)
   {
   document.getElementById('txtadsubcat1').value="";
   }
   else
   {
    document.getElementById('txtadsubcat1').value=ds.Tables[0].Rows[0].subcategoryname;
   }
   if(ds.Tables[0].Rows[0].Ad_size_height==null)
   {
   document.getElementById('txtheight').value="";
   }
   else
   {
    document.getElementById('txtheight').value=ds.Tables[0].Rows[0].Ad_size_height;
   }
   if(ds.Tables[0].Rows[0].Ad_size_width==null)
   {
   document.getElementById('txtwidth').value="";
   }
   else
   {
    document.getElementById('txtwidth').value=ds.Tables[0].Rows[0].Ad_size_width;
   }
   if(ds.Tables[0].Rows[0].Insertion_date==null)
   {
   document.getElementById('txtpublishdate').value="";
   }
   else
   {
   document.getElementById('txtpublishdate').value=ds.Tables[0].Rows[0].Insertion_date;
   }
   if(ds.Tables[0].Rows[0].No_of_insertion==null)
   {
   document.getElementById('txtnoofinsertion').value="";
   }
   else
   {
   document.getElementById('txtnoofinsertion').value=ds.Tables[0].Rows[0].No_of_insertion;
   }
   
   if(ds.Tables[0].Rows[0].Contract_name==null)
   {
   document.getElementById('txtcontractname').value="";
   }
   else
   {
   document.getElementById('txtcontractname').value=ds.Tables[0].Rows[0].Contract_name;
   }
  if(ds.Tables[0].Rows[0].Paid_ins==null)
  {
  document.getElementById('txtpaid').value="";
  }
  else
  {
  document.getElementById('txtpaid').value=ds.Tables[0].Rows[0].Paid_ins;
  }
   if(ds.Tables[0].Rows[0].Card_amount==null)
   {
   document.getElementById('txtcardamount').value="";
   }
   else
   {
   document.getElementById('txtcardamount').value=ds.Tables[0].Rows[0].Card_amount;
   }
   if(ds.Tables[0].Rows[0].Agrred_rate==null)
   {
   document.getElementById('txtagreedrate').value==""
   }
   else
   {
    document.getElementById('txtagreedrate').value=ds.Tables[0].Rows[0].Agrred_rate;
   }
   if(ds.Tables[0].Rows[0].Color_cod==null)
   {
   document.getElementById('txtcolourtype').value==""
   }
   else
   {
    document.getElementById('txtcolourtype').value=ds.Tables[0].Rows[0].Color_cod;
   }
   if(ds.Tables[0].Rows[0].Gross_amount==null)
   {
   document.getElementById('txtgrossamt').value==""
   }
   else
   {
    document.getElementById('txtgrossamt').value=ds.Tables[0].Rows[0].Gross_amount;
   }
   
   //document.getElementById('txtschemetype').value=ds.Tables[0].Rows[0].Contract_name;
   if(ds.Tables[0].Rows[0].Special_discount==null)
   {
   document.getElementById('txtspecialdiscount').value="";
   }
   else
   {
   document.getElementById('txtspecialdiscount').value=ds.Tables[0].Rows[0].Special_discount;
   }
   
  if(ds.Tables[0].Rows[0].Disc_Rate==null)
  {
   document.getElementById('txtdiscount').value="";
  }
  else
  {
  document.getElementById('txtdiscount').value=ds.Tables[0].Rows[0].Disc_Rate;
  }
  
  if(ds.Tables[0].Rows[0].Ad_type_code==null)
  {
   document.getElementById('hiddenadtype').value="";
  }
  else
  {
  document.getElementById('hiddenadtype').value=ds.Tables[0].Rows[0].Ad_type_code;
  }
  ////////////////////////////////////////////

  
 }
   
  //  alert(ds);
}

function openremark(cioid,index)
{
//alert("bhanu");
var ip2=document.getElementById('ip1').value;
var doctype=document.getElementById('select'+index).value;
var compcode=document.getElementById('hiddencompcode').value;
rofileform.update(cioid,compcode,doctype,ip2);

}
function save1()

{
var remarks=document.getElementById('txtremarks').value;
var cioid=document.getElementById('hiddenbookingid').value;
var ip2=document.getElementById('ip1').value;
if(document.getElementById('txtremarks').value=="")
              {
              alert("Please Enter Remarks/comments");
              //document.getElementById('txtremarks').focus();
              return false;
              }
              

rofileform.save(remarks,cioid,ip2,call_savecomment)
    return false;
}
function call_savecomment(response)
{
  var ds=response.value;
  alert("Auditor Comments save Successfully")
    return false;
}
function openbookingModify1()
{
if(document.getElementById('hiddenbookingid').value !="" || document.getElementById('hiddenbookingid').value != null)
 window.open("bookingauditshowdetailgrid.aspx?cioid="+document.getElementById('hiddenbookingid').value);
 return false;
}