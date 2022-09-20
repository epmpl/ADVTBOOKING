var browser=navigator.appName;




function openbookingmast()
{
//======******To open ad tracker booking master***********=======//
   var page;
   var abc=""; 
   if(document.getElementById("hdntracadtye").value=="DI0")
   {
   var url="Booking_master.aspx"
   }
   else if(document.getElementById("hdntracadtye").value=="CL0")
   {
    var url="Classified_Booking.aspx"
   }       
            var browser=navigator.appName;
            //alert(browser);
            var  httpRequest =null;
            if(browser!="Microsoft Internet Explorer")
            {
                //alert("test");
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
     
                httpRequest.open( "GET","loginsession.aspx?username="+document.getElementById('hdnusername22').value+"&password="+document.getElementById('hdnpassword22').value+"&qbc="+abc+"&agency_name="+abc+"&center="+document.getElementById('hdncenter22').value+"&centername="+abc, false );
                httpRequest.send('');
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
//                    if (httpRequest.status == 200) 
//                    {
//                        var flag=httpRequest.responseText;   
//                        if(flag=="0")
//                        {
//                            alert("Invalid User Name or Password" );
//                            return false;
//                        }
//                        else
//                        {
//                          login.saveLoginInfo(ip);
                           window.open(url+"?refid="+(document.getElementById("hdntracid").value)+"&cioid="+(document.getElementById("hdntracbook").value)+"&adty="+(document.getElementById("hdntracadtye").value));
//                        }
//                    }
//                    else 
//                    {
//                        alert('There was a problem with the request.');
//                    }
                }
            }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
              
               xml.open( "GET","loginsession.aspx?username="+document.getElementById('hdnusername22').value+"&password="+document.getElementById('hdnpassword22').value+"&qbc="+abc+"&agency_name="+abc+"&center="+document.getElementById('hdncenter22').value+"&centername="+abc, false );
                xml.Send();
                var flag=xml.responseText;
//                if(flag=="0")
//                {
//                    alert("Invalid User Name or Password" );
//                    return false;
//                }
//                else
//                { 
                   // window.open(url+"?refid="+(document.getElementById("hdntracid").value)+"&bookid="+(document.getElementById("hdntracbook").value)+"&ins="+(document.getElementById("hdntracbook").value));
                   
                   window.open(url+"?refid="+(document.getElementById("hdntracid").value)+"&cioid="+(document.getElementById("hdntracbook").value)+"&add_type="+(document.getElementById("hdntracadtye").value));
//                }
        }
//window.open(url+"?password="+pas+"&type=ratemaster&qbc="+document.getElementById('hiddenbranch').value+"&center="+document.getElementById('hiddenCenter').value+"&username="+document.getElementById('hiddenuserid').value+"&refid="+document.getElementById("hiddenrateuniqid").value);

return false;
}