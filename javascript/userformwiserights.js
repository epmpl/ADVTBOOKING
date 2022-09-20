var extra1 = "";
var extra2 = "";
var logincode = "";
var usercode = "";
var username = "";
var companyname = "";
var companycode = "";
var modulename = "";
var browser=navigator.appName;

function foruserid()
{
var dateformat = $('dateformat').value;
 usercode = $('drpuserid').value;
var a= document.getElementById("drpuserid").selectedIndex;
username= document.getElementById("drpuserid").options[a].text;
userformwiserights.bindcompname(usercode,dateformat,extra1,extra2,call_compname);

}
function blankfields()
{
if(document.getElementById("hdn_user_right").value!="8" && document.getElementById("hdn_user_right").value!="7")
{
alert("You are not Authorized to see this form")
window.close();
return false;

}
else
{
$('txtuser').focus();
 
  return false;
}
}

function call_compname(record)
{
  df=record.value;
  var compname = $('drpcompanyname');
//   companycode = $('drpcompanyname').value;
  compname.options.length=1;
  compname.options[0] = new Option("Select Company Name","");
  if(df!=null && typeof(df)=="object" && df.Tables[0].Rows.length>0)
 {
         for(var i=0; i < df.Tables[0].Rows.length; i++)
         {
         compname.options[compname.options.length] = new Option(df.Tables[0].Rows[i].Comp_Name,df.Tables[0].Rows[i].Comp_Code)
         }
}
return false;
}

function foruserformwiserights()
{
//var mp= document.getElementById("drpcompanyname").selectedIndex;

// companyname= document.getElementById("drpcompanyname").options[mp].text;
 companycode = $('drpcompanyname').value;
 var modulecode = $('drpmodulename').value;
  var usercode =document.getElementById("drpuserid").value;
  
    if(browser!="Microsoft Internet Explorer")
        chmandat=document.getElementById('lbluserid').textContent;
    else     
        chmandat=document.getElementById('lbluserid').innerText;
    if(chmandat.indexOf('*')>= 0)
    {
        if(usercode == "" || usercode == "0")
        {
            alert("Please Select the User By F2");
            $('txtuser').focus();
            return false;
        }
    }
 
//if(companycode=="")
// {
  companycode = $('hdncompcode').value;
// }
// else
// {
//var mp= document.getElementById("drpcompanyname").selectedIndex;
// companyname= document.getElementById("drpcompanyname").options[mp].text;
// companycode = $('drpcompanyname').value;
// 
// }
if(modulename == "---Select Module---" || modulecode == "")
 {
 alert('Plese select Module Name');
 $('drpmodulename').focus();
 }
// else
// {
if(document.getElementById("drpuserid").value!="")
{
   usercode = $('drpuserid').value;
}
else
{
    usercode=""; 
}
//var username = $('drpuserid').value;
//var compname=$('drpcompanyname').value;
var unitcode =$('drpunit').value;
var y= document.getElementById("drpunit").selectedIndex;
 var unitname= document.getElementById("drpunit").options[y].text;
var modulecode = $('drpmodulename').value;
var x= document.getElementById("drpmodulename").selectedIndex;
 modulename= document.getElementById("drpmodulename").options[x].text;
 var compname = $('drpcompanyname').value;

 
 
 


var view = $('drpformat').value;
  var lang = $('drplanguage').value;
  window.open("user_formwise_rights.aspx?usercode="+usercode+  "&lang=" + lang +"&unitcode=" + unitcode + "&modulecode=" + modulecode +  "&modulename=" + modulename+ "&companycode=" + companycode + "&view=" + view,'');
  
// }
//var compname = $('drpcompanyname').value;
//var mp= document.getElementById("drpcompanyname").selectedIndex;
//companycode = $('drpcompanyname').value;
// companyname= document.getElementById("drpcompanyname").options[mp].text;
//var view = $('drpformat').value;
//  var lang = $('drplanguage').value;
  
//  window.open("user_formwise_rights.aspx?usercode="+usercode+  "&lang=" + lang +"&unitcode=" + unitcode + "&modulecode=" + modulecode +  "&modulename=" + modulename+ "&companycode=" + companycode + "&view=" + view,'');
  return false;
  
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function forcancel()
{
  $('drpuserid').value = "";
  $('drpcompanyname').value = "";
  $('drpunit').value = "";
  $('drpmodulename').value = "";
  $('drpformat').value = "ons";
  username = "";
  return false;
}
function onloadq()
{
 $('txtuser').focus();
 return false;
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function chkfild(event)
 {
 var key = event.keyCode ? event.keyCode : event.which;
  if(key == 13)
   {
//    if(document.activeElement.id == "txtuser" && $('drpuserid').value == "")
//     {
//        if(browser!="Microsoft Internet Explorer")
//            chmandat=document.getElementById('lbluserid').textContent;
//        else     
//            chmandat=document.getElementById('lbluserid').innerText;
//        if(chmandat.indexOf('*')>= 0)
//        {
//            $('txtuser').focus();
//            alert("Please Select the User By F2");
//             return false;
//       }
//       else
//       {
//       $('drpunit').focus();
//         return false;
//       }
//       
//     }
//     else 
     if(document.activeElement.id == "lstuser")
     {
        insertuserbyenter();
         return false;
     }
    else if(document.activeElement.id == "txtuser" && $('txtuser').value != "")
     {
      if(key == 13)
       {
//        $('drpcompanyname').focus();
      $('drpunit').focus();
         return false;
       }
     }
    else if(document.activeElement.id == "drpcompanyname" && $('drpcompanyname').value == "")
     {
      if(key == 13)
       {
        $('drpcompanyname').focus();
       alert("Please Select Company");
         return false;
       }
     }
    else if(document.activeElement.id == "drpcompanyname" && $('drpcompanyname').value != "")
     {
      if(key == 13)
       {
        $('drpunit').focus();
      
         return false;
       }
     }
    else if(document.activeElement.id == "drpunit" && $('drpunit').value == "")
     {
      if(key == 13)
       {
        $('drpmodulename').focus();
      
         return false;
       }
     }
     else if(document.activeElement.id == "drpunit" && $('drpunit').value != "")
     {
      if(key == 13)
       {
        $('drpmodulename').focus();
      
         return false;
       }
     }
     else if(document.activeElement.id == "drpmodulename" && $('drpmodulename').value == "")
     {
      if(key == 13)
       {
        $('drpmodulename').focus();
        alert("Please Select Module Name.");
         return false;
       }
     }
     else if(document.activeElement.id == "drpmodulename" && $('drpmodulename').value != "")
     {
      if(key == 13)
       {
        $('drpformat').focus();
      
         return false;
       }
     }
    else if(document.activeElement.id == "drpformat" && $('drpformat').value == "")
     {
      if(key == 13)
       {
        $('drplanguage').focus();
      
         return false;
       }
     }
     else if(document.activeElement.id == "drpformat" && $('drpformat').value != "")
     {
      if(key == 13)
       {
        $('drplanguage').focus();
      
         return false;
       }
     }
     else if(document.activeElement.id == "drplanguage" && $('drplanguage').value == "")
     {
      if(key == 13)
       {
        $('btnsubmit').focus();
      
         return false;
       }
     }
     else if(document.activeElement.id == "drplanguage" && $('drplanguage').value != "")
     {
      if(key == 13)
       {
        $('btnsubmit').focus();
      
         return false;
       }
     }
 }
 else if(key==113)
    {
        if(document.getElementById('txtuser').value.length <=2)
        {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtuser').focus();
            return false;
        }
         document.getElementById("div2").style.display="block";
         aTag = eval(document.getElementById("txtuser"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        document.getElementById('div2').style.top = document.getElementById("txtuser").offsetTop + toppos  + "px";
        document.getElementById('div2').style.left = document.getElementById("txtuser").offsetLeft + leftpos + "px";
        userformwiserights.Binduser(document.getElementById('txtuser').value.toUpperCase(),binduser_callback1);
            
    }
    if(key==27)
    {
      document.getElementById('div2').style.display="none"; 
    }
   if(((key == 8)||(key == 46)) && document.activeElement.id == "txtuser")
   {
     document.getElementById('drpuserid').value ="";
   }
   
}
function binduser_callback1(response)
{       
    ds=response.value;
    var pkgitem = document.getElementById("lstuser");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("---------Select user---------","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username,ds.Tables[0].Rows[i].userid);        
            pkgitem.options.length;       
        }
    }
//    document.getElementById('drpuserid').value="";
    document.getElementById("lstuser").value="0";
    document.getElementById("lstuser").focus();
    return false;
}
//to fill user in text box
function insertuser()
{
        if(document.getElementById('lstuser').value=="0")
        {
            alert("Please Select the User By F2");
            return false;
        }
        document.getElementById("div2").style.display="none";
        
        var page=document.getElementById('lstuser').value;
        for(var k=0;k <= document.getElementById("lstuser").length-1;k++)
        {
               if(document.getElementById('lstuser').options[k].value==page)
               {
               var abc="";
               if(browser!="Microsoft Internet Explorer")
                   abc=document.getElementById('lstuser').options[k].textContent;
                else     
                   abc=document.getElementById('lstuser').options[k].innerText;
                document.getElementById('txtuser').value=abc;
               document.getElementById('drpuserid').value=page;
                }
          }
                 
//        document.getElementById('drpuserid').value=page;
        document.getElementById('txtuser').focus();
        return false;
}
function insertuserbyenter()
{
    if(document.getElementById('lstuser').value=="0")
    {
        alert("Please select the user");
        return false;
    }
    document.getElementById("div2").style.display="none";
        
        var page=document.getElementById('lstuser').value;
        for(var k=0;k <= document.getElementById("lstuser").length-1;k++)
        {
               if(document.getElementById('lstuser').options[k].value==page)
               {
               var abc="";
               if(browser!="Microsoft Internet Explorer")
                   abc=document.getElementById('lstuser').options[k].textContent;
                else     
                   abc=document.getElementById('lstuser').options[k].innerText;
                document.getElementById('txtuser').value=abc;
               document.getElementById('drpuserid').value=page;
                }
          }
        document.getElementById('txtuser').focus();
        return false;
}