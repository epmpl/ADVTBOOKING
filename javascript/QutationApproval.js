



function blankf2field() {
}


function catexitclick() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
        return false;
    }
    return false;
}







function tabvalue1(event) {
  
    var browser = navigator.appName;
    if (event.keyCode == 113) {

        if (document.activeElement.id == "txtagency1") {
            if (document.getElementById('txtagency1').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtagency1').value = "";
                return false;
            }
            document.getElementById("div1").style.display = "block";
            document.getElementById("div1").style.display = "block";
            aTag = eval(document.getElementById("txtagency1"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('div1').style.top = document.getElementById("txtagency1").offsetTop + toppos + "px";
            document.getElementById('div1').style.left = document.getElementById("txtagency1").offsetLeft + leftpos + "px";
            
            Qutation_Approval.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency1').value.toUpperCase(), bindagencyname_callback);

        }
        else if (document.activeElement.id == "txtclient1") {
            if (document.getElementById('txtclient1').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtclient1').value = "";
                return false;
            }
            document.getElementById("divclient").style.display = "block";
            aTag = eval(document.getElementById("txtclient1"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divclient').style.top = document.getElementById("txtclient1").offsetTop + toppos + "px";
            document.getElementById('divclient').style.left = document.getElementById("txtclient1").offsetLeft + leftpos + "px";
            
            Qutation_Approval.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtclient1').value.toUpperCase(), bindclientname_callback);
        }








        else if (document.activeElement.id == "dpretainer")
         {
             if (document.getElementById('dpretainer').value.length <= 2)
             {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('dpretainer').value = "";
                return false;
            }
            document.getElementById("div3").style.display = "block";
            aTag = eval(document.getElementById("dpretainer"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('div3').style.top = document.getElementById("dpretainer").offsetTop + toppos + "px";
            document.getElementById('div3').style.left = document.getElementById("dpretainer").offsetLeft + leftpos + "px";

            Qutation_Approval.fillF2_Creditretainer(document.getElementById('hiddencompcode').value, document.getElementById('dpretainer').value.toUpperCase(), bindretainer_callback);
        }
        
        
        
        
        
        
        
        else if (document.activeElement.id == "txtexecname") {
            //            if(confirm('Are you sure you want to Take Executive'))
            //                {
            if (document.getElementById('txtexecname').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtexecname').value = "";
                return false;
            }
            //                    document.getElementById('dpretainer').value='';
            document.getElementById("divexec").style.display = "block";
            aTag = eval(document.getElementById("txtexecname"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divexec').style.top = document.getElementById("txtexecname").offsetTop + toppos + "px";
            document.getElementById('divexec').style.left = document.getElementById("txtexecname").offsetLeft + leftpos + "px";
          
            Qutation_Approval.bindExec(document.getElementById('hiddencompcode').value, document.getElementById('txtexecname').value.toUpperCase(), bindexecname_callback);
        }
        //        }

    }

    else if (event.keyCode == 27) {
        if (document.getElementById("div1").style.display == "block") {
            document.getElementById("div1").style.display = "none"
            document.getElementById('txtagency1').focus();
        }
        else if (document.getElementById("divclient").style.display == "block") {
            document.getElementById("divclient").style.display = "none"
            document.getElementById('txtclient1').focus();
        }
        else if (document.getElementById("divexec").style.display == "block") {
            document.getElementById("divexec").style.display = "none"
            document.getElementById('txtexecname').focus();
        }
        else if (document.getElementById("div3").style.display == "block") {
        document.getElementById("div3").style.display = "none"
        document.getElementById('dpretainer').focus();
        }
        
    }
    else if (event.keyCode == 13 || event.keyCode == 9 && event.shiftKey == false) {
        
        if (document.activeElement.id == "lstclient") {
            if (document.getElementById('lstclient').value == "0") {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclient").style.display = "none";
            var datetime = "";
            /*@@ this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
            address and if 0 than agency name and address @@@@@@@@@@@@@@@@@@@*/

            var page = document.getElementById('lstclient').value;
            var id = "";
            document.getElementById("Hiddenclientcode").value = page;
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }
                httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
                httpRequest.send('');
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) {
                    //alert(httpRequest.status);
                    if (httpRequest.status == 200) {
                        id = httpRequest.responseText;
                    }
                    else {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
                xml.Send();
                id = xml.responseText;
            }
            var split = id.split("+");
            var namecode = split[0];
            var add = split[1];
            document.getElementById('txtclient1').value = namecode;

            /* if(document.getElementById('hiddensavemod').value=="0")
            {
            document.getElementById('txtclient1add').value=add;
            document.getElementById('txtclient1add').focus();
            }
            bind_agen_bill();*/
            document.getElementById('txtclient1').focus();
            return false;
        }
        else if (document.activeElement.id == "lstagency") {
            if (document.getElementById('lstagency').value == "0") {
                alert("Please select the agency sub code");
                return false;
            }
            document.getElementById("div1").style.display = "none";
            var datetime = "";
            var page = document.getElementById('lstagency').value;
            //document.getElementById('hiddenagency').value=page;
            document.getElementById("Hiddenagencycode").value = page;
            agencycodeglo = page;

            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }

                httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=0", false);
                httpRequest.send('');
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) {
                    //alert(httpRequest.status);
                    if (httpRequest.status == 200) {
                        id = httpRequest.responseText;
                    }
                    else {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=0", false);
                xml.Send();
                id = xml.responseText;
            }
            var split = id.split("+");
            var nameagen = split[0];
            var agenadd = split[1];

            document.getElementById('txtagency1').value = nameagen;
            /* if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
            {
            document.getElementById('txtagency1address').value=agenadd;                
            document.getElementById('txtclient1').focus();
            Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
            }*/
            document.getElementById('txtagency1').focus();
            return false;
        }

        ///this is for exec name
        else if (document.activeElement.id == "lstexec") {
            if (document.getElementById('lstexec').value == "0") {
                alert("Please select the executive");
                return false;
            }

            document.getElementById("divexec").style.display = "none";
            var datetime = "";

            var page = document.getElementById('lstexec').value;
            document.getElementById("Hiddenexecutivecode").value = page;
            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }
                httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
                httpRequest.send('');
                if (httpRequest.readyState == 4) {
                    if (httpRequest.status == 200) {
                        id = httpRequest.responseText;
                    }
                    else {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
                xml.Send();
                id = xml.responseText;
            }

            document.getElementById('txtexecname').value = id;
            document.getElementById('txtexecname').focus();
           
            return false;
        }
        
        
        /////this is for ret

        else if (document.activeElement.id == "lstret") {
        if (document.getElementById('lstret').value == "0") {
                alert("Please select the Retainer");
                return false;
            }

            document.getElementById("div3").style.display = "none";
            var datetime = "";

            var page = document.getElementById('lstret').value;
            document.getElementById("hiddenretainercode").value = page;
            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }
                httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
                httpRequest.send('');
                if (httpRequest.readyState == 4) {
                    if (httpRequest.status == 200) {
                        id = httpRequest.responseText;
                    }
                    else {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
                xml.Send();
                id = xml.responseText;
            }

            document.getElementById('dpretainer').value = id;
            document.getElementById('dpretainer').focus();

            return false;
        }
        
       
        
        
        
        
        
        
        
        

        //else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.id=="LinkButton1" || document.activeElement.id=="LinkButton2" || document.activeElement.id=="LinkButton3" || document.activeElement.id=="LinkButton4" || document.activeElement.id=="LinkButton5")
        else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
            event.keyCode = 13;
            return event.keyCode;
        }
        else {
            var idcursor;
            if (event.shiftKey == false) {
                event.keyCode = 9;
                return event.keyCode;
            }
        }
    }
}


function bindagencyname_callback(res) {


    ds = res.value;
    document.getElementById("lstagency").innerHTML = "";
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency Name-", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name + "~" + ds.Tables[0].Rows[i].code_subcode, ds.Tables[0].Rows[i].code_subcode);
            pkgitem.options.length;
        }
    }

    document.getElementById("lstagency").focus();

    return false;


}

function bindclientname_callback(response) {

    ds = response.value;
    var pkgitem = document.getElementById("lstclient");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Client-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


       
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name, ds.Tables[0].Rows[i].Cust_Code);

            pkgitem.options.length;

        }

    }
    document.getElementById('txtclient').value = "";
    document.getElementById("lstclient").value = "0";
    document.getElementById("lstclient").focus();

    return false;
}




function bindexecname_callback(response) {
    ds = response.value;
    var pkgitem = document.getElementById("lstexec");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Exec-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].exec_name, ds.Tables[0].Rows[i].exe_no);
            pkgitem.options.length;
        }
    }
    document.getElementById('txtexecname').value = "";
    document.getElementById("lstexec").value = "0";
    if (document.getElementById("lstexec").style.visibility == "hidden")
        document.getElementById("lstexec").style.visibility = "visible";
    document.getElementById("lstexec").focus();
    return false;

}

function bindretainer_callback(res)
{



    ds = res.value;
     var pkgitem = document.getElementById("lstret");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Reatiner Name-", "0");
    //    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            // pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].exec_name, ds.Tables[0].Rows[i].exe_no);
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name + "(" + ds.Tables[0].Rows[i].Retain_Code + ")", ds.Tables[0].Rows[i].Retain_Code);
            pkgitem.options.length;
        }
    }
    document.getElementById('dpretainer').value = "";
    document.getElementById("lstexec").value = "0";
    if (document.getElementById("lstret").style.visibility == "hidden")
        document.getElementById("lstret").style.visibility = "visible";
    document.getElementById("lstret").focus();
    return false;

}



//    ds = res.value;
//    document.getElementById("lblret").innerHTML = "";
//    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
//        var pkgitem = document.getElementById("lstretainer");
//        pkgitem.options.length = 0;
//        pkgitem.options[0] = new Option("-Select Reatiner Name-", "0");
//        pkgitem.options.length = 1;

//        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
//            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name + "(" + ds.Tables[0].Rows[i].Retain_Code + ")", ds.Tables[0].Rows[i].Retain_Code);
//            pkgitem.options.length;
//        }
//    }



//    return false;


//}


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
       
        var page=document.getElementById('lstagency').value;
              document.getElementById("Hiddenagencycode").value=page;
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
 else if(document.activeElement.id=="lstclient")
    {
       if(document.getElementById('lstclient').value=="0")
        {
            alert("Please select the client");
            return false;
        }
        document.getElementById("divclient").style.display="none";
        var datetime="";
       
     
        var page=document.getElementById('lstclient').value;
        document.getElementById("Hiddenclientcode").value = page;
       // alert(page);
        
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
      
         
     
        document.getElementById('txtclient1').focus();
        
        return false;
    }
    ///this is for ret name                 

    else if (document.activeElement.id == "lstret") {

    if (document.getElementById('lstret').value == "0") 
    {
            alert("Please select the Retainer");
            return false;
        }
        document.getElementById("div3").style.display = "none";
        var datetime = "";


        var page = document.getElementById('lstret').value;
        document.getElementById("hiddenretainercode").value = page;
       
        var id = "";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null; ;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

            httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) {
                    id = httpRequest.responseText;
                }
                else {
                    alert('There was a problem with the request.');
                }
            }
        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
            xml.Send();
            id = xml.responseText;
        }
        if (id == "yes") {
            alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
            return false;
        }
        var split = id.split("+");
        var namecode = split[0];
        var add = split[1];


        document.getElementById('dpretainer').value = namecode;
        document.getElementById('dpretainer').focus();

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
               document.getElementById("Hiddenexecutivecode").value=page;
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
         
         if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
        document.getElementById('txtexecname').value=id;
        
        
       document.getElementById('txtexecname').focus();
      
        return false;
    }
}

////////////////////////ad type////////////////////////////////////////




function bindcategory_package() {

      
   // binduomname();
    bindcategory();
    //bindpackage();
}


//function binduomname() {
//    var comp_code = document.getElementById('hiddencompcode').value;
//    var resuom = Booking_Audit1.binduom(comp_code, document.getElementById('drpadtype').value);
//    binduom_NEW(resuom);
//}


function bindcategory() {

    var comp_code = document.getElementById('hiddencompcode').value;
    Qutation_Approval.getcategory(comp_code, document.getElementById('drpadtype').value, bindcategory_NEW);



}
function bindcategory_NEW(response)
{
    //alert(response.value);
    var ds=response.value;
    agcatby = document.getElementById("drprate");
 agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Category--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    var j=1;
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code,ds.Tables[0].Rows[i].Adv_Cat_Code);   
                             //new Option(ds_AccName.Tables[0].Rows[i].Exec_name+"("+ds_AccName.Tables[0].Rows[i].Exe_no+")",ds_AccName.Tables[0].Rows[i].Exe_no);        
        
       j++;
       
    }
}
//return false;
document.getElementById("drprate").value = "0";
}





function fetch_categary() {
    document.getElementById("hdnexecutivetxt").value = document.getElementById("drprate").value;
}
function mandat() {
    //refreshControl();
    if (document.getElementById('txtvalidityfrom').value == "") {

        alert('Please Enter  From Date');
        document.getElementById('txtvalidityfrom').focus();
        return false;

    }
    if (document.getElementById('txttilldate').value == "") {

        alert('Please Enter  To Date');
        document.getElementById('txttilldate').focus();
        return false;

    }
    if (document.getElementById('drpaudit').value == "0") {

        alert('Please Select the Audit Type');
        document.getElementById('drpaudit').focus();
        return false;
    }
    document.getElementById('hdnfdate').value = document.getElementById('txtvalidityfrom').value;
    document.getElementById('hdntdate').value = document.getElementById('txttilldate').value;

}


function Selectrow(ab, flag) {
    var id = ab;
    if (flag != "Y" && flag != "N") {
//        document.getElementById('btnsave1').disabled = false;
//        document.getElementById('btnmail').disabled = false;
        document.getElementById('txtremarks').disabled = false;
    }
    else {
//        document.getElementById('btnsave1').disabled = true;
//        document.getElementById('btnmail').disabled = true;
        document.getElementById('txtremarks').disabled = true;
    }

    if (id == "DataGrid1__CheckBox_Header") {
        var j;
        var i = document.getElementById("DataGrid1").rows.length - 1;
        if (document.getElementById(id).checked == true) {
            for (j = 0; j < i; j++) {
                var str = "DataGrid1__CheckBox1" + j;
                document.getElementById(str).checked = true;
            }
        }
        else {
            for (j = 0; j < i; j++) {
                var str = "DataGrid1__CheckBox1" + j;
                document.getElementById(str).checked = false;
            }

        }

    }
    else {
        if (document.getElementById(id).checked == false) {
            document.getElementById(ab).checked = false;
        }
    }


}


var glo_amt
function openbooking1(cioid, id, length, edition, flag) {
    
    var i = 0;
    for (i = 0; i < parseInt(length); i++) {
        document.getElementById('cio' + i).style.color = "blue";
    }

    document.getElementById(id).style.color = "red";
    
    glo_amt = Qutation_Approval.fetchamt(cioid, document.getElementById('hiddencompcode').value);
    Qutation_Approval.execute(cioid, document.getElementById('hiddencompcode').value, edition, document.getElementById('hiddenDateFormat').value, exec_callback1);


    //alert("bhanu");
}


function exec_callback1(response) {
    var ds = response.value;
    var len = ds.Tables[0].Rows.length;
    if (len != "0") {
        
      

        //////////////////////////////////////////////////////////////////////
        if (ds.Tables[0].Rows[0].uom_desc == null) {
            document.getElementById('txtlines').value = "";
            document.getElementById('txtarea').value = "";
        }
        else {
            if (ds.Tables[0].Rows[0].uom_desc == 'CD') {
                document.getElementById('txtlines').value = "";
                document.getElementById('txtarea').value = ds.Tables[0].Rows[0].Total_area;

            }
            else {
                document.getElementById('txtlines').value = ds.Tables[0].Rows[0].Total_area;
                document.getElementById('txtarea').value = "";
            }
            //document.getElementById('txtlines').value=ds.Tables[0].Rows[0].Total_area;
        }
        if (ds.Tables[0].Rows[0].AgencyName == null) {
            document.getElementById('txtagency').value == "";
        }
        else {
            document.getElementById('txtagency').value = ds.Tables[0].Rows[0].AgencyName;
        }



        if (ds.Tables[0].Rows[0].Package_cod == null) {
            document.getElementById('txtpackage').value = "";
        }
        else {
            document.getElementById('txtpackage').value = ds.Tables[0].Rows[0].Package_cod;
        }
        if (ds.Tables[0].Rows[0].Client == null) {
            document.getElementById('txtclient').value = "";
        }
        else {
            document.getElementById('txtclient').value = ds.Tables[0].Rows[0].Client;
        }
        if (ds.Tables[0].Rows[0].Agreed_amount == null) {
            document.getElementById('txtagreedamount').value = "";
        }
        else {
            document.getElementById('txtagreedamount').value = ds.Tables[0].Rows[0].Agreed_amount;
        }
        if (ds.Tables[0].Rows[0].Space_discount == null) {
            document.getElementById('txtspacediscount').value = "";
        }
        else {
            document.getElementById('txtspacediscount').value = ds.Tables[0].Rows[0].Space_discount;
        }
        if (ds.Tables[0].Rows[0].Special_charges == null) {
            document.getElementById('txtspecialcharge').value = "";
        }
        else {
            document.getElementById('txtspecialcharge').value = ds.Tables[0].Rows[0].Special_charges;
        }
        if (ds.Tables[0].Rows[0].RETAINER1 == null) {
            document.getElementById('txtretainername').value = "";
        }
        else {
            document.getElementById('txtretainername').value = ds.Tables[0].Rows[0].RETAINER1;
        }
        if (ds.Tables[0].Rows[0].PayMode == null) {
            document.getElementById('txtpaymode').value = "";
        }
        else {
            document.getElementById('txtpaymode').value = ds.Tables[0].Rows[0].PayMode;
        }
        if (ds.Tables[0].Rows[0].ADD_AGENCY_COMM == null) {
            document.getElementById('txtaddagecomm').value = "";
        }
        else {
            document.getElementById('txtaddagecomm').value = ds.Tables[0].Rows[0].ADD_AGENCY_COMM;
        }
        if (ds.Tables[0].Rows[0].RO_No == null) {
            document.getElementById('txtrono').value = "";
        }
        else {
            document.getElementById('txtrono').value = ds.Tables[0].Rows[0].RO_No;
        }
        if (ds.Tables[0].Rows[0].Book_type == null) {
            document.getElementById('txtbookingtype').value = "";
        }
        else {
            document.getElementById('txtbookingtype').value = ds.Tables[0].Rows[0].Book_type;
        }
        if (ds.Tables[0].Rows[0].ro_status == null) {
            document.getElementById('txtrostatus').value = "";
        }
        else {
            if (ds.Tables[0].Rows[0].ro_status == '1') {
                document.getElementById('txtrostatus').value = 'Confirm';
            }
            else {
                document.getElementById('txtrostatus').value = 'UnConfirm';
            }
        }
        if (ds.Tables[0].Rows[0].Page_position_cod == null) {
            document.getElementById('txtpageposition').value = "";
        }
        else {
            document.getElementById('txtpageposition').value = ds.Tables[0].Rows[0].Page_position_cod;
        }
        if (ds.Tables[0].Rows[0].SUBCAT3 == null || ds.Tables[0].Rows[0].SUBCAT3 == "0") {
            document.getElementById('txtadsubcat2').value = "";
        }
        else {
            document.getElementById('txtadsubcat2').value = ds.Tables[0].Rows[0].SUBCAT3;
        }
        if (ds.Tables[0].Rows[0].execname == null) {
            document.getElementById('txtexecutivename').value = "";
        }
        else {
            document.getElementById('txtexecutivename').value = ds.Tables[0].Rows[0].execname;
        }
        if (ds.Tables[0].Rows[0].Scheme_type_code == null) {
            document.getElementById('txtschemetype').value = "";
        }
        else {
            document.getElementById('txtschemetype').value = ds.Tables[0].Rows[0].Scheme_type_code;
        }
        if (ds.Tables[0].Rows[0].Agency_out == null) {
            document.getElementById('txtoutstanding').value = "";
        }
        else {
            document.getElementById('txtoutstanding').value = ds.Tables[0].Rows[0].Agency_out;
        }
        if (ds.Tables[0].Rows[0].categoryname == null) {
            document.getElementById('txtadcategory').value = "";
        }
        else {
            document.getElementById('txtadcategory').value = ds.Tables[0].Rows[0].categoryname;
        }

        if (glo_amt.value.Tables[0].Rows[0].RECEIVED_AMT == null) {
            document.getElementById('txtbillrecamt').value = "0";
        }
        else {
            document.getElementById('txtbillrecamt').value = glo_amt.value.Tables[0].Rows[0].RECEIVED_AMT;
        }

        if (ds.Tables[0].Rows[0].Bill_amount == null) {
            document.getElementById('txtbillamount').value = "0";
        }
        else {
            document.getElementById('txtbillamount').value = ds.Tables[0].Rows[0].Bill_amount;
        }

        document.getElementById('txtbillbalamt').value = parseFloat(document.getElementById('txtbillamount').value) - parseFloat(document.getElementById('txtbillrecamt').value);

        if (ds.Tables[0].Rows[0].Rate_code == null) {
            document.getElementById('txtratecode').value = "";
        }
        else {
            document.getElementById('txtratecode').value = ds.Tables[0].Rows[0].Rate_code;
        }
        if (ds.Tables[0].Rows[0].Card_rate == null) {
            document.getElementById('txtcardrate').value = "";
        }
        else {
            document.getElementById('txtcardrate').value = ds.Tables[0].Rows[0].Card_rate;
        }
        if (ds.Tables[0].Rows[0].UOM == null) {
            document.getElementById('txtuom').value = ""
        }
        else {
            document.getElementById('txtuom').value = ds.Tables[0].Rows[0].UOM;
        }
        if (ds.Tables[0].Rows[0].SUBCAT4 == null || ds.Tables[0].Rows[0].SUBCAT4 == "null") {
            document.getElementById('txtadsubcat3').value = "";
        }
        else {
            document.getElementById('txtadsubcat3').value = ds.Tables[0].Rows[0].SUBCAT4;
        }
        if (ds.Tables[0].Rows[0].SUBCAT5 == null) {
            document.getElementById('txtadsubcat4').value = "";
        }
        else {
            document.getElementById('txtadsubcat4').value = ds.Tables[0].Rows[0].SUBCAT5;
        }
        if (ds.Tables[0].Rows[0].PositionPremium == null) {
            document.getElementById('txtpositionpremium').value = "";
        }
        else {
            document.getElementById('txtpositionpremium').value = ds.Tables[0].Rows[0].PositionPremium;
        }
        if (ds.Tables[0].Rows[0].APP_REMARKS == null) {
            document.getElementById('txtremarks').value = ""
        }
        else {
            document.getElementById('txtremarks').value = ds.Tables[0].Rows[0].APP_REMARKS;
        }
        if (ds.Tables[0].Rows[0].RETAINER_COMM == null) {
            document.getElementById('txtretainercommission').value = "";
        }
        else {
            document.getElementById('txtretainercommission').value = ds.Tables[0].Rows[0].RETAINER_COMM;
        }
        if (ds.Tables[0].Rows[0].Trade_disc == null) {
            document.getElementById('txtagtradediscount').value = "";
        }
        else {
            document.getElementById('txtagtradediscount').value = ds.Tables[0].Rows[0].Trade_disc;
        }
        if (ds.Tables[0].Rows[0].height == null) {
            document.getElementById('txtheight').value = "";
        }
        else {
            document.getElementById('txtheight').value = ds.Tables[0].Rows[0].height;
        }
        if (ds.Tables[0].Rows[0].width == null) {
            document.getElementById('txtwidth').value = ""
        }
        else {
            document.getElementById('txtwidth').value = ds.Tables[0].Rows[0].width;
        }
        if (ds.Tables[0].Rows[0].subcategoryname == null) {
            document.getElementById('txtadsubcat1').value = "";
        }
        else {
            document.getElementById('txtadsubcat1').value = ds.Tables[0].Rows[0].subcategoryname;
        }
        if (ds.Tables[0].Rows[0].Ad_size_height == null) {
            document.getElementById('txtheight').value = "";
        }
        else {
            document.getElementById('txtheight').value = ds.Tables[0].Rows[0].Ad_size_height;
        }
        if (ds.Tables[0].Rows[0].Ad_size_width == null) {
            document.getElementById('txtwidth').value = "";
        }
        else {
            document.getElementById('txtwidth').value = ds.Tables[0].Rows[0].Ad_size_width;
        }
        if (ds.Tables[0].Rows[0].Insertion_date == null) {
            document.getElementById('txtpublishdate').value = "";
        }
        else {
            document.getElementById('txtpublishdate').value = ds.Tables[0].Rows[0].Insertion_date;
        }
        if (ds.Tables[0].Rows[0].No_of_insertion == null) {
            document.getElementById('txtnoofinsertion').value = "";
        }
        else {
            document.getElementById('txtnoofinsertion').value = ds.Tables[0].Rows[0].No_of_insertion;
        }

        if (ds.Tables[0].Rows[0].Contract_name == null) {
            document.getElementById('txtcontractname').value = "";
        }
        else {
            document.getElementById('txtcontractname').value = ds.Tables[0].Rows[0].Contract_name;
        }
        if (ds.Tables[0].Rows[0].Paid_ins == null) {
            document.getElementById('txtpaid').value = "";
        }
        else {
            document.getElementById('txtpaid').value = ds.Tables[0].Rows[0].Paid_ins;
        }
        if (ds.Tables[0].Rows[0].Card_amount == null) {
            document.getElementById('txtcardamount').value = "";
        }
        else {
            document.getElementById('txtcardamount').value = ds.Tables[0].Rows[0].Card_amount;
        }
        if (ds.Tables[0].Rows[0].Agrred_rate == null) {
            document.getElementById('txtagreedrate').value == ""
        }
        else {
            document.getElementById('txtagreedrate').value = ds.Tables[0].Rows[0].Agrred_rate;
        }
        if (ds.Tables[0].Rows[0].Color_cod == null) {
            document.getElementById('txtcolourtype').value == ""
        }
        else {
            document.getElementById('txtcolourtype').value = ds.Tables[0].Rows[0].Color_cod;
        }
        if (ds.Tables[0].Rows[0].Gross_amount == null) {
            document.getElementById('txtgrossamt').value == ""
        }
        else {
            document.getElementById('txtgrossamt').value = ds.Tables[0].Rows[0].Gross_amount;
        }

        //document.getElementById('txtschemetype').value=ds.Tables[0].Rows[0].Contract_name;
        if (ds.Tables[0].Rows[0].Special_discount == null) {
            document.getElementById('txtspecialdiscount').value = "";
        }
        else {
            document.getElementById('txtspecialdiscount').value = ds.Tables[0].Rows[0].Special_discount;
        }

        if (ds.Tables[0].Rows[0].Discount_per == null) {
            document.getElementById('txtdiscount').value = "";
        }
        else {
            document.getElementById('txtdiscount').value = ds.Tables[0].Rows[0].Discount_per;
        }

    }

}



//==========Save Comment======================//
function savecomment() {
    var testchkbox = "false";

    var cioid = "";
    var insertid = "";
    var i = document.getElementById("DataGrid1").rows.length - 1;
    for (j = 0; j < i; j++) {
        var str = "DataGrid1__CheckBox1" + j;
        var str1 = "cio" + j;
        var str2 = "cio2" + j;
        if (document.getElementById(str).checked == true) {
            if (cioid == "") {
                if (browser != "Microsoft Internet Explorer") {
                    cioid = document.getElementById(str1).textContent;
                    insertid = document.getElementById(str2).textContent;
                }
                else {
                    cioid = document.getElementById(str1).innerHTML;
                    insertid = document.getElementById(str2).innerHTML;
                }
            }
            else {
                if (browser != "Microsoft Internet Explorer") {
                    cioid = cioid + "," + document.getElementById(str1).textContent;
                    insertid = insertid + "," + document.getElementById(str2).textContent;
                }
                else {
                    cioid = cioid + "," + document.getElementById(str1).innerHTML;
                    insertid = insertid + "," + document.getElementById(str2).innerHTML;
                }

            }
            testchkbox = "true"
        }
        document.getElementById('hiddenbookingid').value = cioid;
        document.getElementById('hidattach1').value = insertid;
    }
    if (testchkbox == "false") {
        alert("Please Select Atleast one Checkbox.");
        document.getElementById('txtremarks').focus();
        return false;
    }

    //document.getElementById('hiddenbookingid').value = cioid;
    var appstatus = "";
    if (document.getElementById('txtremarks').value == "") {
        alert("Please Enter Comments.");
        document.getElementById('txtremarks').focus();
        return false;
    }
    if (document.getElementById('rbapr').checked == true) {
        appstatus = "Y";
    }
    else {
        appstatus = "N";
    }
    if (appstatus == "N") {
        if (!confirm('Are you sure you want to Reject Booking')) {
            return false;
        }
    }
    var userid = document.getElementById('hiddenuserid').value;
    var remarks = document.getElementById('txtremarks').value;
    
}



function automail() {
    var center = document.getElementById("Hiddencentercode").value;
    var userid = document.getElementById("hiddenuserid").value;
    var branch = document.getElementById("hdnbranch").value;
    var compcode = document.getElementById("hiddencompcode").value;
    var agencycode = document.getElementById("Hiddenagencycode").value;
    var client = document.getElementById("Hiddenclientcode").value;
    var executive = document.getElementById("Hiddenexecutivecode").value;
    var dateformat = document.getElementById('hiddenDateFormat').value;
  //  var destination = document.getElementById('drpdestination').value;
    var fdate;
    if (document.getElementById('txtvalidityfrom').value != "") {

        if (document.getElementById('txtvalidityfrom').value != "") {
            if (dateformat == "dd/mm/yyyy") {
                var txt = document.getElementById('txtvalidityfrom').value;
                var txt1 = txt.split("/");
                var dd = txt1[0];
                var mm = txt1[1];
                var yy = txt1[2];
                fdate = mm + '/' + dd + '/' + yy;
            }
            else if (dateformat == "mm/dd/yyyy") {
                fdate = document.getElementById('txtvalidityfrom').value;
            }

            else if (dateformat == "yyyy/mm/dd") {
                var txt = document.getElementById('txtvalidityfrom').value;
                var txt1 = txt.split("/");
                var yy = txt1[0];
                var mm = txt1[1];
                var dd = txt1[2];
                fdate = mm + '/' + dd + '/' + yy;
            }

        }

    }
    else {
        alert("Please Select From Date")
        document.getElementById('txtvalidityfrom').focus();
        return false;
    }

    var todate;
    if (document.getElementById('txttilldate').value != "") {

        if (document.getElementById('txttilldate').value != "") {
            if (dateformat == "dd/mm/yyyy") {
                var txt = document.getElementById('txttilldate').value;
                var txt1 = txt.split("/");
                var dd = txt1[0];
                var mm = txt1[1];
                var yy = txt1[2];
                todate = mm + '/' + dd + '/' + yy;
            }
            else if (dateformat == "mm/dd/yyyy") {
                todate = document.getElementById('txttilldate').value;
            }

            else if (dateformat == "yyyy/mm/dd") {
                var txt = document.getElementById('txttilldate').value;
                var txt1 = txt.split("/");
                var yy = txt1[0];
                var mm = txt1[1];
                var dd = txt1[2];
                todate = mm + '/' + dd + '/' + yy;
            }

        }

    }
    else {

        alert("Please Select To Date")
        document.getElementById('txttilldate').focus();
        return false;

    }
    window.open('autoreport.aspx?center=' + center + '&userid=' + userid + '&branch=' + branch + '&compcode=' + compcode + '&agencycode=' + agencycode + '&client=' + client + '&executive=' + executive + '&dateformat=' + dateformat + '&fdate=' + fdate + '&todate=' + todate );
   


    //window.open('autoreport.aspx?center=' + center + '&userid=' + userid + '&branch=' + branch + '&compcode=' + compcode + '&agencycode=' + agencycode + '&client=' + client + '&executive=' + executive + '&dateformat=' + dateformat + '&fdate=' + fdate + '&todate=' + todate + '&destination=' + destination);
    return false;
}