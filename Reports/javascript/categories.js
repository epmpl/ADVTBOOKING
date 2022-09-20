var browser=navigator.appName;


function keySort(dropdownlist,caseSensitive) 
 {
       // check the keypressBuffer attribute is defined on the dropdownlist
         var undefined;
         if (dropdownlist.keypressBuffer == undefined)
         {
             dropdownlist.keypressBuffer = '';
         }
         // get the key that was pressed
         var key = String.fromCharCode(window.event.keyCode);
         dropdownlist.keypressBuffer += key;
         if (!caseSensitive)
          {
              // convert buffer to lowercase
              dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
          }
          // find if it is the start of any of the options
          var optionsLength = dropdownlist.options.length;
          for (var n=0; n<optionsLength; n++) 
          {
                  var optionText = dropdownlist.options[n].text;
                  if (!caseSensitive)
                  {
                       optionText = optionText.toLowerCase();
                  }
                  if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0)
                  {
                      dropdownlist.selectedIndex = n;
                      return false; 
                      // cancel the default behavior since
                                // we have selected our own value
                  }
           }
          // reset initial key to be inline with default behavior
          dropdownlist.keypressBuffer = key;
          return true; // give default behavior
}

function bindsubcat345()
{
var compcode=document.getElementById('hiddencomcode').value;
var adsubcat1=document.getElementById('dpadsubcat').value;
categories.subcat345(adsubcat1,compcode,"","",call_adsubcat345);
}
function call_adsubcat345(response)
{
ds= response.value;

    var brand=document.getElementById('dpadsubcat3');
    brand.options.length=0;
    brand.options[0]=new Option("Select AdSubCat2");
    document.getElementById("dpadsubcat3").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].catname,ds.Tables[0].Rows[i].catcode);
                brand.options.length;    
             }
 }         
}
  function uombind()
    {
    
var comp_code=document.getElementById('hiddencomcode').value;
 var adtype=document.getElementById('dpadtype').value;
 var uomdesc="";
    categories.uom_bind(comp_code,adtype,uomdesc,call_bind_uom); 
 
    }
    
        function call_bind_uom(response)
{

     ds= response.value;
    var edition=document.getElementById('drpuom');
    edition.options.length=0;
    edition.options[0]=new Option("--Select UOM Name--");
   if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Uom_Name,ds.Tables[0].Rows[i].Uom_Code);
                edition.options.length;  
               document.getElementById("hiddenuom").value= ds.Tables[0].Rows[i].Uom_Code; 
             }
             }
          //  document.getElementById("hiddenuom").value=  document.getElementById("drpuom").value
        return false
        
}

function uomcode()
{
document.getElementById("hiddenuom").value=  document.getElementById("drpuom").value
return false
}
///////////////////////////////////////////////////////fill agency f2//////////////////////////////////
function fillAgency(event)
{ 

var key=event.keyCode?event.keyCode:event.which;

 if((key==8 && document.activeElement.id=="txtagency") || (event.ctrlKey==true && key==88 && document.activeElement.id=="txtagency") || (key==46 && document.activeElement.id=="txtagency"))
   {
         if(key!=113)
         {   
          document.getElementById('hidenagecode').value="";       
            document.getElementById('hiddenagencycode').value="";
            document.getElementById('hidenmainsubcode').value="";
               document.getElementById('hidenmainsubcode').value="";
   
         }
   }
if(key==113) 
{


if(document.activeElement.id=="txtagency")
{
var agency=document.getElementById('txtagency').value;

agency=agency.toUpperCase();

document.getElementById('lstagency').value="";



var compcode =  document.getElementById("hiddencomcode").value;


var activeid=document.activeElement.id;
var listboxid="lstagency";
var objchannel=document.getElementById(listboxid);
var divid="div1";

aTag = eval(document.getElementById(activeid))
var btag;
var leftpos=0;
var toppos=0;        
do {
aTag = eval(aTag.offsetParent);
leftpos    += aTag.offsetLeft;
toppos += aTag.offsetTop;
btag=eval(aTag)
} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  

document.getElementById("lstagency").style.display="block";




document.getElementById("divagency").style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
document.getElementById("divagency").style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";                            

document.getElementById("divagency").style.display="block";

var dateformat = "'dd/mm/yyyy'";


document.getElementById('lstagency').focus();


categories.fill_agency(compcode,agency, bindcity_callback)

}

}
//==============add for enter===============
if(key==13)
{
if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
{
key=13;
return key;

}
else
{
key=9;
return key;
return false;
}
}
}
function bindcity_callback(res)
{


ds =res.value;
document.getElementById("lstagency").innerHTML = "";
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
{
var pkgitem = document.getElementById("lstagency");
pkgitem.options.length = 0;
pkgitem.options[0]=new Option("-Select Agency-","0");
pkgitem.options.length = 1;

for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
{
pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name+ "("+ ds.Tables[0].Rows[i].Agency_Code + ")",ds.Tables[0].Rows[i].Agency_Code + "-" + ds.Tables[0].Rows[i].SUB_Agency_Code);
pkgitem.options.length;
}
}

document.getElementById("divagency").style.display="block";
document.getElementById('lstagency').focus();
return false;
}
function onclickagency(event)
{
var key=event.keyCode?event.keyCode:event.which;
if(key==13 || event.type=="click")
{

if(document.activeElement.id=="lstagency")
{        

if(document.getElementById('lstagency').value=="0")
{
alert("Please select the Main group");
return false;
}     
var page=document.getElementById('lstagency').value;
agencycodeglo=page;               
if(browser!="Microsoft Internet Explorer")
{            
for(var k=0;k <= document.getElementById("lstagency").length-1;k++)
{                      
var abc=document.getElementById('lstagency').options[k].innerHTML;

if(document.getElementById('lstagency').options[k].value==page)
{ 
var abc=document.getElementById('lstagency').options[k].innerHTML;
var allvalues=document.getElementById('lstagency').options[k].value;
var splitvalue= allvalues.split("-");
var fival = abc.split("(");
document.getElementById('txtagency').value= abc;
//document.getElementById('txtcode').value= hdsAgcode;
savemainagcode = splitvalue[0];
savemainagsubcode = splitvalue[1];
var hdsAgcode=savemainagcode+savemainagsubcode;
document.getElementById("hidenagecode").value=savemainagcode;   
document.getElementById("hidenmainsubcode").value=savemainagsubcode;                     
document.getElementById("hiddenagencysubcode").value=savemainagsubcode;                     
      
document.getElementById("hiddenagencycode").value=hdsAgcode;
var ag11 = abc.split("(")
break;
}
}
}
else
{
for(var k=0;k <= document.getElementById("lstagency").length-1;k++)
{
if(document.getElementById('lstagency').options[k].value==page)
{
var abc=document.getElementById('lstagency').options[k].innerText;
var allvalues=document.getElementById('lstagency').options[k].value;
var splitvalue= allvalues.split("-");
var fival = abc.split("(");
document.getElementById('txtagency').value= abc;
savemainagcode = splitvalue[0];
savemainagsubcode = splitvalue[1];
var hdsAgcode=savemainagcode+savemainagsubcode;
document.getElementById("hidenagecode").value=savemainagcode;
 document.getElementById("hidenmainsubcode").value=savemainagsubcode;
 document.getElementById("hiddenagencysubcode").value=savemainagsubcode;                        
document.getElementById("hiddenagencycode").value=hdsAgcode;
var ag11 = abc.split("(")
document.getElementById("txtagency").focus();
break;

}
}
}
document.getElementById("divagency").style.display='none';
return false;
}
}
else if (key==27)
{
document.getElementById("divagency").style.display='none';
document.getElementById("txtagency").focus();
}
}

////////////////////////////////////////////////////////////////////fiil client f2////////////////////////////////

function fillclient(event)
{ 

var key=event.keyCode?event.keyCode:event.which;

 if((key==8 && document.activeElement.id=="txtclient") || (event.ctrlKey==true && key==88 && document.activeElement.id=="txtclient") || (key==46 && document.activeElement.id=="txtclient"))
   {
         if(key!=113)
         {
               document.getElementById('hiddeclientcode').value="";
         }
   }
if(key==113) 
{


if(document.activeElement.id=="txtclient")
{
var client=document.getElementById('txtclient').value;

client=client.toUpperCase();

document.getElementById('istclient').value="";



var compcode =  document.getElementById("hiddencomcode").value;


var activeid=document.activeElement.id;
var listboxid="istclient";
var objchannel=document.getElementById(listboxid);
var divid="div1";

aTag = eval(document.getElementById(activeid))
var btag;
var leftpos=0;
var toppos=0;        
do {
aTag = eval(aTag.offsetParent);
leftpos    += aTag.offsetLeft;
toppos += aTag.offsetTop;
btag=eval(aTag)
} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  

document.getElementById("istclient").style.display="block";




document.getElementById("divclient").style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
document.getElementById("divclient").style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";                            

document.getElementById("divclient").style.display="block";

var dateformat = "'dd/mm/yyyy'";


document.getElementById('istclient').focus();


categories.fill_maingrp(compcode,client, bindcilent_callback)

}

}
//==============add for enter===============
if(key==13)
{
if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
{
key=13;
return key;

}
else
{
key=9;
return key;
return false;
}
}
}
function bindcilent_callback(res)
{


ds =res.value;
document.getElementById("istclient").innerHTML = "";
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
{
var pkgitem = document.getElementById("istclient");
pkgitem.options.length = 0;
pkgitem.options[0]=new Option("-Select Agency-","0");
pkgitem.options.length = 1;

for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
{
   pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name+ "("+ ds.Tables[0].Rows[i].Cust_Code + ")",ds.Tables[0].Rows[i].Cust_Code) ;
   pkgitem.options.length;
}
}

document.getElementById("divclient").style.display="block";
document.getElementById('istclient').focus();
return false;
}
function onclickclient(event)
{
var key=event.keyCode?event.keyCode:event.which;
if(key==13 || event.type=="click")
{

if(document.activeElement.id=="istclient")
{        

if(document.getElementById('istclient').value=="0")
{
alert("Please select the Main group");
return false;
}     
var page=document.getElementById('istclient').value;
agencycodeglo=page;               
if(browser!="Microsoft Internet Explorer")
{            
for(var k=0;k <= document.getElementById("istclient").length-1;k++)
{                      
var abc=document.getElementById('istclient').options[k].innerHTML;

if(document.getElementById('istclient').options[k].value==page)
{ 
var abc=document.getElementById('istclient').options[k].innerHTML;
var allvalues=document.getElementById('istclient').options[k].value;
var splitvalue= allvalues.split("-");
var fival = abc.split("(");
document.getElementById('txtclient').value= abc;
//document.getElementById('txtcode').value= hdsAgcode;
savemainagcode = splitvalue[0];
document.getElementById('txtclient').value= abc;
savemainagcode = splitvalue[0];
document.getElementById("hiddeclientcode").value=savemainagcode;
var ag11 = abc.split("(")
break;
}
}
}
else
{
for(var k=0;k <= document.getElementById("istclient").length-1;k++)
{
if(document.getElementById('istclient').options[k].value==page)
{
var abc=document.getElementById('istclient').options[k].innerText;
var allvalues=document.getElementById('istclient').options[k].value;
var splitvalue= allvalues.split("-");
var fival = abc.split("(");
document.getElementById('txtclient').value= abc;
savemainagcode = splitvalue[0];
document.getElementById("hiddeclientcode").value=savemainagcode;
var ag11 = abc.split("(")
document.getElementById("txtclient").focus();
break;

}
}
}
document.getElementById("divclient").style.display='none';
return false;
}
}
else if (key==27)
{
document.getElementById("divclient").style.display='none';
document.getElementById("txtclient").focus();
}
}
/////////////////////////////////////////////////////////////////////excutive f2////////////////////////////////
function fillexcutive(event)
{ 

var key=event.keyCode?event.keyCode:event.which;

 if((key==8 && document.activeElement.id=="txtexcutive") || (event.ctrlKey==true && key==88 && document.activeElement.id=="txtexcutive") || (key==46 && document.activeElement.id=="txtexcutive"))
   {
         if(key!=113)
         {
               document.getElementById('hiddenexcutive').value="";
         }
   }
if(key==113) 
{


if(document.activeElement.id=="txtexcutive")
{
var exectv=document.getElementById('txtexcutive').value;

exectv=exectv.toUpperCase();

document.getElementById('istexcutive').value="";



var compcode =  document.getElementById("hiddencomcode").value;


var activeid=document.activeElement.id;
var listboxid="istexcutive";
var objchannel=document.getElementById(listboxid);
var divid="div1";

aTag = eval(document.getElementById(activeid))
var btag;
var leftpos=0;
var toppos=0;        
do {
aTag = eval(aTag.offsetParent);
leftpos    += aTag.offsetLeft;
toppos += aTag.offsetTop;
btag=eval(aTag)
} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  

document.getElementById("istexcutive").style.display="block";




document.getElementById("divexcutive").style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
document.getElementById("divexcutive").style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";                            

document.getElementById("divexcutive").style.display="block";

var dateformat = "'dd/mm/yyyy'";


document.getElementById('istexcutive').focus();


categories.fillF2_Creditexecutive(compcode,exectv, bindexcutive_callback)

}

}
//==============add for enter===============
if(key==13)
{
if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
{
key=13;
return key;

}
else
{
key=9;
return key;
return false;
}
}
}
function bindexcutive_callback(res)
{


ds =res.value;
document.getElementById("istexcutive").innerHTML = "";
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
{
var pkgitem = document.getElementById("istexcutive");
pkgitem.options.length = 0;
pkgitem.options[0]=new Option("-Select Agency-","0");
pkgitem.options.length = 1;

for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
{
    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Exec_name+ "("+ ds.Tables[0].Rows[i].Exe_no + ")",ds.Tables[0].Rows[i].Exe_no);
        pkgitem.options.length;
}
}

document.getElementById("divexcutive").style.display="block";
document.getElementById('istexcutive').focus();
return false;
}
function onclickexcutive(event)
{
var key=event.keyCode?event.keyCode:event.which;
if(key==13 || event.type=="click")
{

if(document.activeElement.id=="istexcutive")
{        

if(document.getElementById('istexcutive').value=="0")
{
alert("Please select the Main group");
return false;
}     
var page=document.getElementById('istexcutive').value;
agencycodeglo=page;               
if(browser!="Microsoft Internet Explorer")
{            
for(var k=0;k <= document.getElementById("istexcutive").length-1;k++)
{                      
var abc=document.getElementById('istexcutive').options[k].innerHTML;

if(document.getElementById('istexcutive').options[k].value==page)
{ 
var abc=document.getElementById('istexcutive').options[k].innerHTML;
var allvalues=document.getElementById('istexcutive').options[k].value;
var splitvalue= allvalues.split("-");
var fival = abc.split("(");
document.getElementById('txtexcutive').value= abc;
//document.getElementById('txtcode').value= hdsAgcode;
savemainagcode = splitvalue[0];
savemainagcode = splitvalue[0];
document.getElementById("hiddenexcutive").value=savemainagcode;
var ag11 = abc.split("(")
break;
}
}
}
else
{
for(var k=0;k <= document.getElementById("istexcutive").length-1;k++)
{
if(document.getElementById('istexcutive').options[k].value==page)
{
var abc=document.getElementById('istexcutive').options[k].innerText;
var allvalues=document.getElementById('istexcutive').options[k].value;
var splitvalue= allvalues.split("-");
var fival = abc.split("(");
document.getElementById('txtexcutive').value= abc;
savemainagcode = splitvalue[0];
document.getElementById("hiddenexcutive").value=savemainagcode;
var ag11 = abc.split("(")
document.getElementById("txtexcutive").focus();
break;

}
}
}
document.getElementById("divexcutive").style.display='none';
return false;
}
}
else if (key==27)
{
document.getElementById("divexcutive").style.display='none';
document.getElementById("txtexcutive").focus();
}
}

//////////////////////////////////////////////////////////////////////// fill ret F2//////////////
function fillreterner(event)
{ 

var key=event.keyCode?event.keyCode:event.which;

 if((key==8 && document.activeElement.id=="txtret") || (event.ctrlKey==true && key==88 && document.activeElement.id=="txtret") || (key==46 && document.activeElement.id=="txtret"))
   {
         if(key!=113)
         {
               document.getElementById('hiddenreterner').value="";
         }
   }
if(key==113) 
{


if(document.activeElement.id=="txtret")
{
var ret=document.getElementById('txtret').value;

ret=ret.toUpperCase();

document.getElementById('istret').value="";



var compcode =  document.getElementById("hiddencomcode").value;


var activeid=document.activeElement.id;
var listboxid="istret";
var objchannel=document.getElementById(listboxid);
var divid="div1";

aTag = eval(document.getElementById(activeid))
var btag;
var leftpos=0;
var toppos=0;        
do {
aTag = eval(aTag.offsetParent);
leftpos    += aTag.offsetLeft;
toppos += aTag.offsetTop;
btag=eval(aTag)
} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  

document.getElementById("istret").style.display="block";




document.getElementById("divret").style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
document.getElementById("divret").style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";                            

document.getElementById("divret").style.display="block";

var dateformat = "'dd/mm/yyyy'";


document.getElementById('istret').focus();


categories.fillF2_Creditretainer(compcode,ret, bindret_callback)

}

}
//==============add for enter===============
if(key==13)
{
if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
{
key=13;
return key;

}
else
{
key=9;
return key;
return false;
}
}
}
function bindret_callback(res)
{


ds =res.value;
document.getElementById("istret").innerHTML = "";
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
{
var pkgitem = document.getElementById("istret");
pkgitem.options.length = 0;
pkgitem.options[0]=new Option("-Select Agency-","0");
pkgitem.options.length = 1;

for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
{
     pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name+ "("+ ds.Tables[0].Rows[i].Retain_Code + ")",ds.Tables[0].Rows[i].Retain_Code);
    pkgitem.options.length;
}
}

document.getElementById("divret").style.display="block";
document.getElementById('istret').focus();
return false;
}
function onclickreterner(event)
{
var key=event.keyCode?event.keyCode:event.which;
if(key==13 || event.type=="click")
{

if(document.activeElement.id=="istret")
{        

if(document.getElementById('istret').value=="0")
{
alert("Please select the Main group");
return false;
}     
var page=document.getElementById('istret').value;
agencycodeglo=page;               
if(browser!="Microsoft Internet Explorer")
{            
for(var k=0;k <= document.getElementById("istret").length-1;k++)
{                      
var abc=document.getElementById('istret').options[k].innerHTML;

if(document.getElementById('istret').options[k].value==page)
{ 
var abc=document.getElementById('istret').options[k].innerHTML;
var allvalues=document.getElementById('istret').options[k].value;
var splitvalue= allvalues.split("-");
var fival = abc.split("(");
document.getElementById('txtret').value= abc;
savemainagcode = splitvalue[0];
document.getElementById("hiddenreterner").value=savemainagcode;
var ag11 = abc.split("(")
break;
}
}
}
else
{
for(var k=0;k <= document.getElementById("istret").length-1;k++)
{
if(document.getElementById('istret').options[k].value==page)
{
var abc=document.getElementById('istret').options[k].innerText;
var allvalues=document.getElementById('istret').options[k].value;
var splitvalue= allvalues.split("-");
var fival = abc.split("(");
document.getElementById('txtret').value= abc;
savemainagcode = splitvalue[0];
document.getElementById("hiddenreterner").value=savemainagcode;
var ag11 = abc.split("(")
document.getElementById("txtret").focus();
break;

}
}
}
document.getElementById("divret").style.display='none';
return false;
}
}
else if (key==27)
{
document.getElementById("divret").style.display='none';
document.getElementById("txtret").focus();
}
}

function formexit()
{
if (confirm("Do you want to skip this page"))
{
window.close();
}
return false;
}

function forreport()
{
 var    newstr = "";
    var newstr1 = "All";
    var subcatcode="";
    var subcat="All";
    var uomcode="";
    var uomname="All";
     var listadcat=document.getElementById('dpadcatgory');
        for(var i=1;i<listadcat.options.length  ;  i++)
        {
         
            if (listadcat.options[i].selected == true)
            {
              if (newstr == "")
                {
                    newstr = listadcat.options[i].value;
                   newstr1 = listadcat.options[i].text;
               }
                else
                {
                   newstr = newstr + "','" + listadcat.options[i].value;
                    newstr1 = newstr1 + "," + listadcat.options[i].text;
                }
            }
          
        }
        var listadsubcat=document.getElementById('lstadsubcat');
        
            for(var i=1;i<listadsubcat.options.length  ;  i++)
        {
         
            if (listadsubcat.options[i].selected == true)
            {
              if (subcatcode == "")
                {
                
                    subcatcode = listadsubcat.options[i].value;
                   subcat = listadsubcat.options[i].text;
               }
                else
                {
                   subcatcode = subcatcode + "','" + listadsubcat.options[i].value;
                    subcat = subcat + "," + listadsubcat.options[i].text;
                }
            }
          
        }
      var listuom=document.getElementById('drpuom');
        
            for(var i=1;i<listuom.options.length  ;  i++)
        {
         
            if (listuom.options[i].selected == true)
            {
              if (uomcode == "")
                {
                
                    uomcode = listuom.options[i].value;
                   uomname = listuom.options[i].text;
               }
                else
                {
                   uomcode = uomcode + "','" + listuom.options[i].value;
                    uomname = subcat + "," + listuom.options[i].text;
                }
            }
          
        }     
        
var pcentercode= document.getElementById("dpprintcenter").value;
var pbranchcode = document.getElementById("dpbranch").value;
var  padtype = document.getElementById("dpadtype").value;
var  puomcode   = uomcode;
var  pcatcode = newstr;
var psubcatcode = subcatcode;
var pagency_type  = document.getElementById("drpagtype").value;
if( document.getElementById("txtagency").value!=""||document.getElementById("hidenagecode").value!="")
{
var pag_main_code  = document.getElementById("hidenagecode").value;
var agencysubcode = document.getElementById("hiddenagencysubcode").value;
}
else
{
var pag_main_code  ="";
var agencysubcode="";
}

var pag_sub_code =document.getElementById("hidenmainsubcode").value;
var pexecode   = document.getElementById("hiddenexcutive").value;
var   pretcode  = document.getElementById("hiddenreterner").value;
var   pclientcode  = document.getElementById("hiddeclientcode").value;
var pdatefrom = document.getElementById("txtfromdate").value;
var  pdateto = document.getElementById("txttodate").value;

if(pcentercode=="")
{
alert("Please select Center");
document.getElementById("dpprintcenter").focus();
return false;
}
if(pdatefrom=="")
{
alert("Please select From Date");
document.getElementById("txtfromdate").focus();
return false;
}
if(pdateto=="")
{
alert("Please select To Date");
document.getElementById("txttodate").focus();
return false;
}
var  prep_type = document.getElementById("txtreporttype").value;
var view=document.getElementById("DrpDestinationType").value;
var extra1=document.getElementById("drpbasedon").value;
  window.open ("monthwisebill.aspx?pcentercode="+pcentercode+"&pbranchcode="+ pbranchcode +"&agencysubcode="+ agencysubcode+"&padtype="+ padtype +"&puomcode="+ puomcode+ "&pcatcode="+pcatcode +"&psubcatcode="+psubcatcode+ "&pagency_type="+pagency_type+"&pag_main_code="+ pag_main_code+  "&pag_sub_code ="+pag_sub_code+" &view="+view+"&pexecode="+pexecode+"&pretcode="+pretcode+"&pclientcode="+pclientcode+"&pdatefrom="+pdatefrom+"&pdateto="+pdateto+"&prep_type="+prep_type+"&extra1="+extra1,'gaurav','resizable=yes,scrollbars=yes,toolbar=yes,titlebar=yes,menubar=yes,status=yes');
  

}
function LTrim( value )
 {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) 
{
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}

 function adsubcat_bind()
    {
     var ad_type=document.getElementById('dpadtype').value;
    var comp_code=document.getElementById('hiddencomcode').value;
    
    
     var newstr = "";
        var newstr1 = "";
          var listadcat=document.getElementById('dpadcatgory');
        for(var i=1;i<listadcat.options.length  ;  i++)
        {
         
            if (listadcat.options[i].selected == true)
            {
              if (newstr == "")
                {
                
                       newstr = listadcat.options[i].value;
                   newstr1 = listadcat.options[i].text;
               }
                else
                {
                   newstr = newstr + "," + listadcat.options[i].value;
                    newstr1 = newstr1 + "," + listadcat.options[i].text;
                }
            }
          
        }
        
    categories.bind_adsubcat(newstr,newstr1,call_adsubcat_bind);
    }
    
    function call_adsubcat_bind(response)
    {
    dst=response.value;
    
     var edition=document.getElementById('lstadsubcat');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Ad SubCat--");
    document.getElementById("lstadsubcat").options.length = 1;
   
             for(var i=0; i<dst.Tables[0].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(dst.Tables[0].Rows[i].Adv_Subcat_Name,dst.Tables[0].Rows[i].Adv_Subcat_Code);
                edition.options.length;    
             }
          
 
       return false;
    }
   function bindadcat_schedule()
{
var compcode=document.getElementById('hiddencomcode').value;
var adtype1=document.getElementById('dpadtype').value;
var res1=categories.adcatbnd(adtype1,compcode);
call_adcat_schedule(res1);

var resuom=categories.binduom(compcode,adtype1);
binduom_NEW(resuom);
}
function binduom_NEW(response)
{
    var ds=response.value;
    agcatby = document.getElementById("drpuom");
    agcatby.options.length = 1; 
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var j=1;
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Uom_Name,ds.Tables[0].Rows[i].Uom_Code); 
           j++;
           
        }
    }
}
function call_adcat_schedule(response)
{
ds= response.value;
    var brand=document.getElementById('dpadcatgory');
    brand.options.length=1;
//    brand.options[0]=new Option("--Select AdCat--");
//    document.getElementById("dpadcatgory").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                brand.options.length;    
             }
 }         
 
       return false;
}