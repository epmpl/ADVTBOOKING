// JScript File

function bindclientname_callback(response)
{
         
    ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var pkgitem = document.getElementById("lstclient");
        pkgitem.options.length = 0; 
        pkgitem.options[0]=new Option("-Select Client-","0");
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
            pkgitem.options.length;
        }
    }
    else
    {
    var pkgitem = document.getElementById("lstclient");
        pkgitem.options.length = 0; 
        pkgitem.options[0]=new Option("-Select Client-","0");
        pkgitem.options.length = 1; 
        pkgitem.options.length;
        }
    document.getElementById('txtcustomername').value="";
    document.getElementById("lstclient").value="0";
    document.getElementById("lstclient").focus();
    return false;
}

function tabvalue(event,id) {

   if(event.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
    if(document.getElementById('hiddenquery').value=="query")
    {
        if(event.keyCode==113)  
        {
            if(document.activeElement.id=="txtcustomername")
            {
                document.getElementById("divclient").style.display="block";
        
//              document.getElementById('divclient').style.top=parseInt(document.getElementById('txtcustomername').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6;
//              document.getElementById('divclient').style.left=parseInt(document.getElementById('txtcustomername').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9;
      
        document.getElementById('divclient').style.top = "230px";

                document.getElementById('divclient').style.left= "410px";
                
                var type=document.getElementById('drpclinttype').value;

                var clientdatabind = ClientMaster.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtcustomername').value,type,bindclientname_callback);
        
            }
         }
          if(event.keyCode==113)  
          {
            bindclientname_callback(clientdatabind);
          }
         if(event.keyCode==27)  
    {
        if(document.getElementById("divclient").style.display=="block") {
        
    
             document.getElementById("divclient").style.display="none";
             document.getElementById("lstclient").options.length=0;
             document.getElementById("txtcustomername").focus();
        }    
        
    }
            else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
            {
                if(document.activeElement.id=="lstclient")
                {
                    if(document.getElementById('lstclient').value=="0")
                    {
                        alert("Please select the client");
                        return false;
                    }
                document.getElementById("divclient").style.display="none";
                //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
              //----------not needed for client master-------------------------//
                var page=document.getElementById('lstclient').value;
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open( "GET","AgencyNameList.aspx?page="+page+"&value=1", false );
                xml.Send();
                var id=xml.responseText;
         
                 var split=id.split("+");
                 var namecode=split[0];
                 var code=split[1];
                 var alias=split[2];
                 var add=split[3];

                document.getElementById('txtcustcode').value=code;
                //----------------------------------------------------///
                document.getElementById('txtcustomername').value=namecode;//document.getElementById('lstclient').options[document.getElementById('lstclient').selectedIndex].innerText;
                document.getElementById('txtalias').value=alias;
                document.getElementById('txtadd1').value=add;
                
                document.getElementById('txtcustomername').focus();
                
                document.getElementById("divclient").style.display='none';
        //*************************************************************
        
                //document.getElementById('txtagencyaddress').focus();
        
                return false;
            }
         

        else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
   
          event.keyCode=13;
          return event.keyCode;

        }
        
        else if(document.activeElement.id==id)
        {
            if(document.getElementById('btnSave').disabled==false)
            {
        document.getElementById('btnSave').focus();
        event.keyCode=13;
        return event.keyCode;

            }
        return;

        }
        
        else
        {
            if(event.shiftKey==false)
            {
                event.keyCode=9;
                return event.keyCode;
            }
        }
    
}
else if(event.shiftKey==true && event.keyCode==9)
{
 
 
}
else if((event.keyCode==9) && (document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image"))      
{   
 event.keyCode=9;
 return event.keyCode;  
}



}

else
{
    if(event.keyCode==13)
{
if(document.activeElement.id==id)
{
    if(document.getElementById('btnSave').disabled==false)
    {
document.getElementById('btnSave').focus();
event.keyCode=13;
return event.keyCode;

    }
return;

}
else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
{
event.keyCode=13;
return event.keyCode;

}
else
{
event.keyCode=9;
return event.keyCode;
}
}
}
}

function agencyf2(event) {
 var key = event.keyCode ? event.keyCode : event.which;
 if (key == 113 || key == 35) {
     if (document.activeElement.id == "txtagencycode") {
         document.getElementById("divagency").style.display = "block";
         aTag = eval(document.getElementById("txtagencycode"))
         var btag;
         var leftpos = 0;
         var toppos = 0;
         do {
             aTag = eval(aTag.offsetParent);
             leftpos += aTag.offsetLeft;
             toppos += aTag.offsetTop;
             btag = eval(aTag)
         } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
         document.getElementById('divagency').style.top = document.getElementById("txtagencycode").offsetTop + toppos + "px";
         document.getElementById('divagency').style.left = document.getElementById("txtagencycode").offsetLeft + leftpos + "px";

         ClientMaster.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagencycode').value, "", bindagencyname_callback);
     }
 }
 else if (((key == 8) || (key == 46)) || (event.ctrlKey == true && key == 88)) {

     if (document.activeElement.id == "txtagencycode") {
         document.getElementById('txtagencycode').value = "";
        document.getElementById('hiddenagency_uer').value = "";
         return false;
     }
     return key;
 }
}


function bindagencyname_callback(response) {
    ds = response.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency-", "0");
        pkgitem.options.length = 1;
        //alert(pkgitem.options.length);
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name + '+' + ds.Tables[0].Rows[i].code_subcode + '+' + ds.Tables[0].Rows[i].Agency_Code + '+' + ds.Tables[0].Rows[i].SUB_Agency_Code, ds.Tables[0].Rows[i].code_subcode);

            pkgitem.options.length;

        }
    }
    else {
        document.getElementById("lstagency").options.length = 0;
    }
    document.getElementById('txtagencycode').value = "";
    document.getElementById('hiddenagency_uer').value = "";
    document.getElementById("lstagency").value = "0";
    document.getElementById("lstagency").focus();
    return false;
}

function insertagency(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstagency") {
            if (document.getElementById('lstagency').value == "0") {
                alert("Please select Agency Code");
                return false;
            }

            var page = document.getElementById('lstagency').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstagency').length - 1; k++) {
                if (document.getElementById('lstagency').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstagency').options[k].innerText;
                    }
                    document.getElementById('txtagencycode').value = abc.split("+")[0];
                    document.getElementById('hiddenagency_uer').value = abc.split("+")[1];

                    document.getElementById("divagency").style.display = "none";
                    document.getElementById('txtagencycode').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

        document.getElementById("divagency").style.display = "none";
        document.getElementById('txtagencycode').focus();
    }
}

