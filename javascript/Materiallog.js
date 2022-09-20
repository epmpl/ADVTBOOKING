
var browser=navigator.appName;

function calonload()
{
 document.getElementById('txtcenter').focus()
//  document.getElementById('user').value="";
//  document.getElementById('hidcent').value="";
}

function onkeydoawn(event)
{
var key=event.keyCode?event.keyCode:event.which;
if(key=='13')
{
 if (document.activeElement.id == "txtusrnam") 
 {
  document.getElementById('txtpubdat').focus();
  return false;
  }
  if (document.activeElement.id == "txtcenter") 
  {
  document.getElementById('txtusrnam').focus();
  return false;
 } 
   if (document.activeElement.id == "txtpubdat") 
  {
  document.getElementById('drpdest').focus();
   return false;
  }
  if (document.activeElement.id == "drpdest") 
  {
  document.getElementById('BtnRun').focus();
   return false;
  }
  }
}

function binduser(event)
{

var key=event.keyCode?event.keyCode:event.which;
if (key == 27) {
    if (document.activeElement.id == "lst_user") {
        document.getElementById('div1').style.display = "none";

    }
    }
    
     if((key == 8)||(key == 46))
       {
          
          
           document.getElementById('txtusrnam').value = "";
           document.getElementById('lst_user').options.length = 0; 
       }

       if (key == 113) {
          var compcode = document.getElementById('hiddencompcode').value;
           var userid = document.getElementById('hiddenuserid').value;
           var userhome = document.getElementById('hiddenuserhome').value;
           var revenue = document.getElementById('hiddenrevenue').value;
           var admin = document.getElementById('hiddenadmin').value;
           
           document.getElementById("div1").style.display = "block";
           document.getElementById('div1').style.top = findPos(document.getElementById("txtusrnam"), "top");
           document.getElementById('div1').style.left = findPos(document.getElementById("txtusrnam"), "left");
           document.getElementById('lst_user').value = "0";
           document.getElementById('lst_user').focus();

           var res = Reports_Materiallog.UserBind(compcode, userid, userhome, revenue, admin);
           var ds = res.value;
           if (ds != null && ds.Tables[0].Rows.length > 0) {
               var pkgitem = document.getElementById("lst_user");
               pkgitem.options.length = 0;
               pkgitem.options[0] = new Option("-Select user-", "0");
               pkgitem.options.length = 1;
               for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                   pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username + "--" + ds.Tables[0].Rows[i].userid + "--" + fndnull(ds.Tables[0].Rows[i].ROLE_NAME), ds.Tables[0].Rows[i].userid);
                   pkgitem.options.length;
               }
           }
           
       }
    return false;
}

function filluser(event)
 {
        var keycode=event.keyCode?event.keyCode:event.which;
        if(keycode==13 ||event.type=="click")
         {
            if(document.activeElement.id=="lst_user")
            {
                     if(document.getElementById('lst_user').value=="0")
                     {
                          alert("Please select user");
                          return false;
                     }
                     document.getElementById("div1").style.display="none";              
                     var page=document.getElementById('lst_user').value;
                     loccode=page;     
          
                     for(var k=0;k <= document.getElementById("lst_user").length-1;k++)
                     {
                            if(document.getElementById('lst_user').options[k].value==page)
                            {
                            if(browser=="Microsoft Internet Explorer")
                            {
                                var abc=document.getElementById('lst_user').options[k].innerText;
                                }
                                else
                                {
                                var abc=document.getElementById('lst_user').options[k].textContent;
                                }
                                var fival = abc.split("--");  
                                 document.getElementById('user').value=fival[1];
                                 document.getElementById('txtusrnam').value = fival[0];
                                
                                 document.getElementById('txtusrnam').focus();
                                 break;
                            }
                       }
                   }
               }
               else
               if(keycode==27)
               {
                document.getElementById('txtusrnam').focus();
               document.getElementById("div1").style.display="none";
               }
               
      }
      
      
      
      
      function bincent(event)
{

var key=event.keyCode?event.keyCode:event.which;
if (key == 27) {
    if (document.activeElement.id == "lst_cent") {
        document.getElementById('div2').style.display = "none";

    }
    }
    
     if((key == 8)||(key == 46))
       {
          
          
           document.getElementById('txtcenter').value = "";
           document.getElementById('lst_cent').options.length = 0; 
       }

       if (key == 113) {
          var compcode = document.getElementById('hiddencompcode').value;
           var userid = document.getElementById('hiddenuserid').value;
           var access = document.getElementById('hdnaccess').value;
          
           
           document.getElementById("div2").style.display = "block";
           document.getElementById('div2').style.top = findPos(document.getElementById("txtcenter"), "top");
           document.getElementById('div2').style.left = findPos(document.getElementById("txtcenter"), "left");
           document.getElementById('lst_cent').value = "0";
           document.getElementById('lst_cent').focus();

           var res = Reports_Materiallog.publicationbind(compcode, userid, access);
           var ds = res.value;
           if (ds != null && ds.Tables[0].Rows.length > 0) {
               var pkgitem = document.getElementById("lst_cent");
               pkgitem.options.length = 0;
               pkgitem.options[0] = new Option("-Select center-", "0");
               pkgitem.options.length = 1;
               for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                   pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].center + "--" + ds.Tables[0].Rows[i].Pub_cent_Code, ds.Tables[0].Rows[i].Pub_cent_Code);
                   pkgitem.options.length;
               }
           }
           
       }
    return false;
}




function fillcent(event)
 {
        var keycode=event.keyCode?event.keyCode:event.which;
        if(keycode==13 ||event.type=="click")
         {
            if(document.activeElement.id=="lst_cent")
            {
                     if(document.getElementById('lst_cent').value=="0")
                     {
                          alert("Please select user");
                          return false;
                     }
                     document.getElementById("div2").style.display="none";              
                     var page=document.getElementById('lst_cent').value;
                     loccode=page;     
          
                     for(var k=0;k <= document.getElementById("lst_cent").length-1;k++)
                     {
                            if(document.getElementById('lst_cent').options[k].value==page)
                            {
                            if(browser=="Microsoft Internet Explorer")
                            {
                                var abc=document.getElementById('lst_cent').options[k].innerText;
                                }
                                else
                                {
                                var abc=document.getElementById('lst_cent').options[k].textContent;
                                }
                                var fival = abc.split("--");  
                                 
                                 document.getElementById('txtcenter').value = fival[0];
                                document.getElementById('hidcent').value = fival[1];
                                 document.getElementById('txtcenter').focus();
                                 break;
                            }
                       }
                   }
               }
               
               else
               if(keycode==27)
               {
                document.getElementById('txtcenter').focus();
               document.getElementById("div2").style.display="none";
               }
               
      }
      
      
      
       function findPos(obj,val) {
    var curleft = curtop = 0;

    if (obj.offsetParent) {
        curleft = obj.offsetLeft

        curtop = obj.offsetTop

        while (obj = obj.offsetParent) {
            curleft += obj.offsetLeft

            curtop += obj.offsetTop

        }

    }
    curtop = curtop += 5;
    if (val == "top")
        return curtop +"px";
    else
        return curleft + "px";
}

function fndnull(myval) {
    if (myval == "undefined") {
        myval = "";
    }
    else if (myval == null) {
        myval = "";
    }
    return myval
}




function get_report(event)
{

if(document.getElementById('txtusrnam').value=="")
{
alert("Fill User ");
document.getElementById('txtusrnam').focus();
return false;
}
else
if(document.getElementById('txtusrnam').value!="")
{
if(document.getElementById('user').value=="")
alert("Fill user By F2");
document.getElementById('txtusrnam').focus();
return false;
}

if(document.getElementById('txtcenter').value=="")
{
alert("Fill publication center");
document.getElementById('txtcenter').focus();
return false;
}
else
if(document.getElementById('txtcenter').value!="")
{
if(document.getElementById('hidcent').value=="")
alert("fill publication center By F2");
document.getElementById('txtcenter').focus();
return false;
}

if(document.getElementById('txtpubdat').value=="")
{
alert("Fill publication center");
document.getElementById('txtcenter').focus();
return false;
}


var pubdate=document.getElementById('txtpubdat').value;
var pubcenter=document.getElementById('hidcent').value;
var pubname=document.getElementById('txtcenter').value;
var username=document.getElementById('txtusrnam').value;
var user=document.getElementById('user').value;
var extra1="";
var extra2="";
var dest=document.getElementById('drpdest').value;
var dateformat=document.getElementById('hiddendateformat').value;

   var res = Reports_Materiallog.getdata(pubdate, pubcenter, username,extra1,extra2,dateformat);
//   if(res!=null||res.value.Table[0].rows.length<1)
//   {
//  
//   alert("Searching criteria not valid");
//}
//else
window.open("MaterialReport.aspx?pubdate="+pubdate+"&pubcenter="+pubcenter+"&user="+user+"&dest="+dest+"&pubname="+pubname+"&username="+username)

}