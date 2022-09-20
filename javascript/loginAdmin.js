// JScript File

function login1()
{
    //debugger;
    if(document.getElementById('drpUser').value=="0" && document.getElementById('txtpwd').value=="")
    {
        alert("Username and Password should not be blank" );
        document.getElementById('drpUser').focus();
        return false;
    }
    else if(document.getElementById('drpUser').value=="0")
    {
        alert("Username field should mot be blank" );
        document.getElementById('drpUser').focus();
        return false;
    }

    else if(document.getElementById('txtpwd').value=="")
    {
        alert("Password field should not be blank" );
        document.getElementById('txtpwd').focus();
        return false;
    }
    else
    {
        var cusername=document.getElementById('drpUser').value;
        var cpassword=document.getElementById('txtpwd').value;
        var qbc=null;
        
        var browser=navigator.appName;
        var  httpRequest =null;
        if(browser!="Microsoft Internet Explorer")
        {
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open('GET', "loginAdSession.aspx?username="+cusername+"&password="+cpassword+"&qbc="+qbc, false );
            httpRequest.send('');
            if (httpRequest.readyState == 4) 
            {
                if (httpRequest.status == 200) 
                {
                      var flag=httpRequest.responseText;   
                    if(flag=="0")
                    {
                        alert("Invalid User Name or Password" );
                        return false;
                    }
                    else
                    {
                        //debugger;
                        window.location.href="Default.aspx";
                        //window.location.href="citymaster.aspx";
                    }
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
            xml.Open( "GET","loginAdSession.aspx?username="+cusername+"&password="+cpassword+"&qbc="+qbc, false );
            xml.Send();
            var flag=xml.responseText;
            if(flag=="0")
            {
                alert("Invalid User Name or Password" );
                return false;
            }
            else
            {
                window.location.href="Default.aspx";
            }
        }
        //loginAdmin.chkLoginAd1(cusername,cpassword,callback_login1);
    }
    return false;

}

function tabvalue (id)
{
    if(event.keyCode==13)
    {

    //btnsubmit

        if(document.activeElement.id==id)
        {
            document.getElementById('btnlogin').focus();
            event.keyCode=13;
            return event.keyCode;

        }

        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
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

function alertContents(httpRequest) 
{
    debugger; 
    if (httpRequest.readyState == 4) 
    {
        if (httpRequest.status == 200) 
        {
              var flag=httpRequest.responseText;   
            if(flag=="0")
            {
                alert("Invalid User Name or Password" );
                return false;
            }
            else
            {
                debugger;
                window.location.href="Default.aspx";
                //window.location.href="citymaster.aspx";
            }
        }
        else 
        {
            alert('There was a problem with the request.');
        }
    }

}