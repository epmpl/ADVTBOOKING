function CheckKey()
{
    var browser=navigator.appName;
    var response1=upgradelicense.fetchCompanyName();
    var dsn1=response1.value;
    var compname1="";
    if(dsn1==null)
    {
        alert(response1.error.description);
        return false;
    }
    else{
        if(dsn1!="" && dsn1!="null" && dsn1!=null)
        {
            compname1=dsn1;
        }
    }
    if(document.getElementById('txtkeyno').value=="")
    {
        alert("Please Enter Key No");
        document.getElementById('txtkeyno').focus();
        return false;
    }
    if(browser!="Microsoft Internet Explorer")
                {
                        var  httpRequest =null;;
                        httpRequest= new XMLHttpRequest();
                                if (httpRequest.overrideMimeType) {
                                httpRequest.overrideMimeType('text/xml'); 
                                }
                               
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
                       
                        httpRequest.open( "GET","http://LOCALHOST/licence/checklicense.aspx?compname="+compname1+"&keyno="+document.getElementById('txtkeyno').value, false );
                        httpRequest.send('');
                       // alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                strtext=httpRequest.responseText;
                            }
                            else 
                            {
                                alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
                            }
                        }
                   
                }
                    else
                    {
                        validuse="";
                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
                       
                        xml.Open( "GET","http://LOCALHOST/licence/checklicense.aspx?compname="+compname1+"&keyno="+document.getElementById('txtkeyno').value, false );
                        xml.Send();
                        strtext=xml.responseText;
                    }
                    
                    if(strtext=="")
                    {
                        alert("Invalid Key");
                        return false;
                    }
                    else{
                        var arr=strtext.split("^");
                       
                        for(var n=0;n<arr.length;n++)
                        {
                            var arrn=arr[n].toString().split("~");
                             if(arrn[0]!="" && arr[0]!=null)
                            {
                                alert(arrn[0].toString());
                                document.getElementById('txtkeyno').value="";
                                document.getElementById('txtkeyno').focus();
                                return false;
                            }
                            else{
                            var arr1=arrn[1].split("#");
                                var response=upgradelicense.updateKey(arr1[1].toString(),arr1[0].toString(),document.getElementById('hiddenuserid').value);
                                var dsn=response.value;
                                var compname="";
                                if(dsn==null)
                                {
                                    alert(response.error.description);
                                    return false;
                                }
                                else{
                                    if(dsn.Tables.length>0 && dsn.Tables[0].Rows.length>0)
                                    {
                                        compname=dsn.Tables[0].Rows[0].COMPANY_NAME;
                                    }
                                }
                                updateMain(document.getElementById('txtkeyno').value,compname);
                               } 
                              
                        }
                    }
                      alert("License Upgraded Successfully");
                                document.getElementById('txtkeyno').value="";
                            return false;
}
function GetIPAddress()
  {
var obj = null;
    var rslt = "";
    try
    {
        obj = new ActiveXObject("rcbdyctl.Setting");
        rslt = obj.GetIPAddress;
        obj = null;
    }
    catch(e)
    {
        //
    }
    
    return rslt; 
        }
function updateMain(keyno,compname)
{
var browser=navigator.appName;
    var ip = GetIPAddress();
     if(browser!="Microsoft Internet Explorer")
                {
                        var  httpRequest =null;;
                        httpRequest= new XMLHttpRequest();
                                if (httpRequest.overrideMimeType) {
                                httpRequest.overrideMimeType('text/xml'); 
                                }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
                       // var adcat=adcat_vari.value;
                        httpRequest.open( "GET","http://LOCALHOST/licence/updatelicense.aspx?keyno="+keyno+"&compname="+compname+"&ipaddress="+ip+"&usedby="+document.getElementById('hiddenuserid').value, false );
                        httpRequest.send('');
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                strtext=httpRequest.responseText;
                            }
                            else 
                            {
                                alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
                            }
                        }
                }
                    else
                    {
                    validuse="";
                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
                       
                        xml.Open( "GET","http://LOCALHOST/licence/updatelicense.aspx?keyno="+keyno+"&compname="+compname+"&ipaddress="+ip+"&usedby="+document.getElementById('hiddenuserid').value, false );
                        xml.Send();
                        strtext=xml.responseText;
                    }
                   
                   // return false;
}
function ExitClick()
{
      if (confirm("Do you want to close this page."))
        window.close();

    return false;
}
function alertContents(httpRequest) {

    if (httpRequest.readyState == 4) {
        alert(httpRequest.status);
        if (httpRequest.status == 200) {
            //alert(httpRequest.responseText);
            s = httpRequest.responseText;
        } else {
            alert('There was a problem with the request.');
        }
    }

}