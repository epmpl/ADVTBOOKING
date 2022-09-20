

var browser=navigator.appName;



function selectuser(event)
{
var key = event.keyCode ? event.keyCode : event.which;
      if(key==113 || (event.shiftKey==true && key==50))
    {
          if(document.getElementById('txtusrid').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtusrid').value="";
            return false;
            }
            document.getElementById("div2").style.display="block";
            if(browser != "Microsoft Internet Explorer")
            {
                  document.getElementById('div2').style.top= 70 +"px";
                  document.getElementById('div2').style.left= 210 +"px";
            }
            else
            {
                 document.getElementById('div2').style.top= 70+"px";
                  document.getElementById('div2').style.left= 10+"px";
            }
            Matter_log.Binduser(document.getElementById('txtusrid').value.toUpperCase(),binduser_callback1);
        
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
//        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            if (document.getElementById('hiddensessionuser').value == "yes")
                {                    
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username+"+"+ds.Tables[0].Rows[i].userid,ds.Tables[0].Rows[i].userid);        
                     pkgitem.options.length; 
                }
                else
                {
                    if (ds.Tables[0].Rows[i].Admin == "" && ds.Tables[0].Rows[i].Company_user == "Agency")
                    { }
                    else
                    {
                        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username+"+"+ds.Tables[0].Rows[i].userid,ds.Tables[0].Rows[i].userid);        
                     pkgitem.options.length; 
                    }
                }
//            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name +'+'+ds.Tables[0].Rows[i].CITYNAME,ds.Tables[0].Rows[i].code_subcode);        
//            pkgitem.options.length;       
        }
    }
    
    
    var   aTag = eval(document.getElementById('txtusrid'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('div2').scrollLeft;
                 var scrolltop = document.getElementById('div2').scrollTop;
                 document.getElementById('div2').style.left = document.getElementById('txtusrid').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div2').style.top = document.getElementById('txtusrid').offsetTop + toppos - scrolltop + "px"; //"510px";
        
    
    
    document.getElementById('txtusrid').value="";
    document.getElementById("lstuser").value="0";
    document.getElementById("lstuser").focus();
    return false;
}

function insertuser(event)
{
var key = event.keyCode ? event.keyCode : event.which;
    if(document.activeElement.id=="lstuser")
    {
    if(key==13||event.type=="click")
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
               if(browser!="Microsoft Internet Explorer")
                {
                    var abc=document.getElementById('lstuser').options[k].textContent;
                }
                else
                {        
                    var abc=document.getElementById('lstuser').options[k].innerText;
                    var namcod=abc.split("+");
                    document.getElementById('txtusrid').value=namcod[0];
                    document.getElementById('txtusrnam').value=namcod[1];
                }
                           //var abc=document.getElementById('lstuser').options[k].innerText;            
//                           var splitpub = abc;
//                           var str = splitpub.split("--");
//                           var username = str[0];
//                           var user = str[1];
                            //document.getElementById('txtusrid').value=abc;
                             var namcod=abc.split("+");
                    document.getElementById('txtusrid').value=namcod[0];
                    document.getElementById('txtusrnam').value=namcod[1];
               document.getElementById('hdnusrid').value=namcod[1];
                }
          }
                 

        document.getElementById('txtusrid').focus();
       
        return false;
    }
    }
}

function bindreport()
{

//if(document.getElementById('txtusrid').value=="")
//{
//alert("Please fill userid")
//document.getElementById('txtusrid').focus();
//return false;
//}
if(document.getElementById('txtusrid').value!="")
{
if(document.getElementById('hdnusrid').value=="")
{
alert("Please fill userid by F2")
document.getElementById('txtusrid').focus();
return false;
}
}

if(document.getElementById('txtfrmdat').value=="")
{
alert("Please fill FromDate")
document.getElementById('txtfrmdat').focus();
return false;
}

if(document.getElementById('txttodt').value=="")
{
alert("Please fill ToDate")
document.getElementById('txttodt').focus();
return false;
}

if(document.getElementById('ddlmainlog').value=="0")
{
alert("Please select Main Log")
document.getElementById('ddlmainlog').focus();
return false;
}

var tname=document.getElementById('ddlmainlog').value;
var userid=document.getElementById('hdnusrid').value;
var todate=document.getElementById('txttodt').value;
var frmdat=document.getElementById('txtfrmdat').value;
var bukid=document.getElementById('txtbukid').value;
var branch=document.getElementById('dpd_branch').value;
var res=Matter_log.call_data(tname,userid,frmdat,todate,document.getElementById('hiddendateformat').value,bukid,branch)
if(res.value!="" && res.value!=null)
{
document.getElementById('Td_supply_final').innerHTML=res.value.toString()
}
else
{
alert("No Data Found")
}
return false



}


function clearfields()
{

document.getElementById('txtusrid').value="";
document.getElementById('txtusrnam').value="";
document.getElementById('hdnusrid').value="";
document.getElementById('txtfrmdat').value="";

document.getElementById('txttodt').value="";

document.getElementById('ddlmainlog').value="0";
document.getElementById('Td_supply_final').innerHTML="";
document.getElementById('txtbukid').value="";
return false;


}


function closewin()
{
if(confirm("Do You Want To Skip This Page"))
{

window.close();

return false;
}
}