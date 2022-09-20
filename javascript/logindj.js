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

else 
if( document.activeElement.type=="button" || document.activeElement.type=="submit")
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

function bindpublication()
{
    var response=LoginDJ.bindpublication(document.getElementById('txtusername').value);
     var ds=response.value;
    agcatby = document.getElementById("drppublication");
    agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Publication--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
    //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].PUBL,ds.Tables[0].Rows[i].PUBL);
        
            agcatby.options.length;       
        }
    }
  //  return false;
}
function bindcenter()
{
     var response=LoginDJ.bindcenter(document.getElementById('txtusername').value,document.getElementById("drppublication").value);
     var ds=response.value;
     agcatby = document.getElementById("drpcenter");
     agcatby.options.length = 1; 
     agcatby.options[0]=new Option("--Select Center--","0");
    
//    agcatby1 = document.getElementById("drploginth");
//    agcatby1.options.length = 1; 
//    agcatby1.options[0]=new Option("--Select Login Through--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[1].Rows.length > 0) 
    {
    //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[1].Rows.length; ++i)
        {
            agcatby.options[agcatby.options.length] = new Option(ds.Tables[1].Rows[i].BKOFFICE,ds.Tables[1].Rows[i].BKOFFICE_CODE);
        
            agcatby.options.length;       
        } 
////        for (var i = 0  ; i < ds.Tables[3].Rows.length; ++i)
////        {  
////            agcatby1.options[agcatby1.options.length] = new Option(ds.Tables[3].Rows[i].LOCAL_HO,ds.Tables[3].Rows[i].LOCAL_HO);
////        
////            agcatby1.options.length;   
////        }   
    }
   
    return false;
}
function bindbranch()
{
   // alert(document.getElementById('drpcenter').value);
    var response=LoginDJ.bindbranch(document.getElementById('txtusername').value,document.getElementById('drppublication').value,document.getElementById('drploginth').value,document.getElementById('drpcenter').value);
    var ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[2].Rows.length > 0) 
    {
        document.getElementById('hiddenbranch').value=ds.Tables[2].Rows[0].BKOFFICE;
    } 
}

 function login1()
   {
        if(document.getElementById('txtusername').value=="" && document.getElementById('txtpwd').value=="")
        {
            alert("Username and Password should not be blank" );
            document.getElementById('txtusername').focus();
            return false;
        }
        else if(document.getElementById('txtusername').value=="")
        {
            alert("Username field should mot be blank" );
            document.getElementById('txtusername').focus();
            return false;
        }
        
        else if(document.getElementById('txtpwd').value=="")
        {
            alert("Password field should not be blank" );
            document.getElementById('txtpwd').focus();
            return false;
        }
        else if(document.getElementById('drppublication').value=="0")
        {
            alert("Publication field should not be blank" );
            document.getElementById('drppublication').focus();
            return false;
        }
          else if(document.getElementById('drpcenter').value=="0")
        {
            alert("Center field should not be blank" );
            document.getElementById('drpcenter').focus();
            return false;
        }
         else if(document.getElementById('drploginth').value=="0")
        {
            alert("Login Through field should not be blank" );
            document.getElementById('drploginth').focus();
            return false;
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
     
                httpRequest.open( "GET","loginsession.aspx?centerdj="+document.getElementById('drpcenter').value+"&logint="+document.getElementById('drploginth').value+"&publication="+document.getElementById('drppublication').value+"&username="+document.getElementById('txtusername').value+"&password="+document.getElementById('txtpwd').value+"&qbc="+document.getElementById('hiddenbranch').value+"&agency_name=&center="+document.getElementById('drpcenter').value+"&centername=", false );
                httpRequest.send('');
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
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
                            if(flag=="2")
                                window.location.href="cngpassword.aspx";
                            else    
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
                xml.Open( "GET","loginsession.aspx?centerdj="+document.getElementById('drpcenter').value+"&logint="+document.getElementById('drploginth').value+"&publication="+document.getElementById('drppublication').value+"&username="+document.getElementById('txtusername').value+"&password="+document.getElementById('txtpwd').value+"&qbc="+document.getElementById('hiddenbranch').value+"&agency_name=&center="+document.getElementById('drpcenter').value+"&centername=", false );
                xml.Send();
                var flag=xml.responseText;
                if(flag=="0")
                {
                    alert("Invalid User Name or Password" );
                    return false;
                }
                else
                {
                     if(flag=="2")
                            window.location.href="cngpassword.aspx";
                     else   
                         {
                            if(flag=="4")
                            {
                               alert("Prefrences is not define for user " + document.getElementById('txtusername').value );
                               return false;
                            }
                            else 
                            window.location.href="Default.aspx";                
                            
                         }
                }
            }
             return false;
        }

function bindHoLo()
{
    var response=LoginDJ.bindbranch(document.getElementById('txtusername').value,document.getElementById('drppublication').value,document.getElementById('drploginth').value,document.getElementById('drpcenter').value);
    var ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[3].Rows.length > 0) 
    {
        agcatby1 = document.getElementById("drploginth");
        agcatby1.options.length = 1; 
        agcatby1.options[0]=new Option("--Select Login Through--","0");

        for (var i = 0  ; i < ds.Tables[3].Rows.length; ++i)
        {  
            agcatby1.options[agcatby1.options.length] = new Option(ds.Tables[3].Rows[i].LOCAL_HO,ds.Tables[3].Rows[i].LOCAL_HO);        
            agcatby1.options.length;   
        }
    }
    return false;
}