// JScript File

var branchvar;
var agencycode="";
var subagencycode="";
var hiddentext ="";
var checkmodname="";
var glunit;
var glclient;
var glbranchcode;
var glbartercode;
var glbarterdesc;
var glbarterstdt;
var glbarterendt;
var glbarterkilldate;
var glproductdesc;
var glstrbook;
var gdsexecute;
var rowN=0;
var browser=navigator.appName;

// on pageload
function pagedef()
{
  if(document.getElementById("btnNew").disabled==false)
     document.getElementById("btnNew").focus();
   document.getElementById("drpunit").disabled=true;
   document.getElementById("drpbranch").disabled=true;
   document.getElementById("txtagency").disabled=true;
   document.getElementById("txtbartercode").disabled=true;
   document.getElementById("txtbartername").disabled=true;
   document.getElementById("txtbarterstdt").disabled=true;
   document.getElementById("txtbarterendt").disabled=true;
   document.getElementById("txtprodamt").disabled=true;
   document.getElementById("txtbarteramt").disabled=true;
   document.getElementById("txtbarterarea").disabled=true;
   document.getElementById("txtremark").disabled=true;
   document.getElementById("txtproductdesc").disabled=true;
   document.getElementById("txtbarterkilldt").disabled=true;
   document.getElementById("drpuom").disabled=true;
   document.getElementById("drpstrbank").disabled=true;
   document.getElementById("txtclient").disabled=true;
  
   document.getElementById("drpunit").value="0";
   document.getElementById("drpbranch").value="0";
   document.getElementById("txtagency").value="";
   document.getElementById("txtbartercode").value="";
   document.getElementById("txtbartername").value="";
   document.getElementById("txtbarterstdt").value="";
   document.getElementById("txtbarterendt").value="";
   document.getElementById("txtprodamt").value="";
   document.getElementById("txtbarteramt").value="";
   document.getElementById("txtbarterarea").value="";
   document.getElementById("txtremark").value="";
   document.getElementById("txtproductdesc").value="";
   document.getElementById("txtbarterkilldt").value="";
   document.getElementById("drpuom").value="0";
     document.getElementById("drpstrbank").value="0";
   document.getElementById("txtclient").value="";
   
   return false;
}

function newclick()
{
   clearclick();
   hiddentext="new";
   if(document.getElementById('hiddenauto').value==1)
   {
      document.getElementById('txtbartercode').disabled=true;
   }
   else
   {
      document.getElementById('txtbartercode').disabled=false;
   }
   
   document.getElementById("drpunit").disabled=false;
   document.getElementById("drpunit").focus();
   document.getElementById("drpbranch").disabled=false;
   document.getElementById("txtagency").disabled=false;
   document.getElementById("txtbartername").disabled=false;
   document.getElementById("txtbarterstdt").disabled=false;
   document.getElementById("txtbarterendt").disabled=false;
   document.getElementById("txtprodamt").disabled=false;
   document.getElementById("txtbarteramt").disabled=false;
   document.getElementById("txtbarterarea").disabled=false;
   document.getElementById("txtremark").disabled=false;
   document.getElementById("txtproductdesc").disabled=false;
   document.getElementById("txtbarterkilldt").disabled=false;
   document.getElementById("drpuom").disabled=false;
    document.getElementById("drpstrbank").disabled=false;
   document.getElementById("txtclient").disabled=false;
  document.getElementById("drpstrbank").value="0";
   chkstatus(FlagStatus);	
  setButtonImages();
   return false;
}

function clearclick()
{
   chkstatus(FlagStatus);
   givebuttonpermission("Ad_BarteMaster");
   hiddentext="";

   document.getElementById("drpunit").value="0";
   document.getElementById("drpbranch").options.length="";
   
   document.getElementById("txtagency").value="";
   document.getElementById("txtbartercode").value="";
   document.getElementById("txtbartername").value="";
   document.getElementById("txtbarterstdt").value="";
   document.getElementById("txtbarterendt").value="";
   document.getElementById("txtprodamt").value="";
   document.getElementById("txtbarteramt").value="";
   document.getElementById("txtbarterarea").value="";
   document.getElementById("txtremark").value="";
   document.getElementById("txtproductdesc").value="";
   document.getElementById("txtbarterkilldt").value="";
   document.getElementById("drpuom").value="0";
     document.getElementById("drpstrbank").value="0";
   document.getElementById("txtclient").value="";
   
   document.getElementById("drpunit").disabled=true;
   document.getElementById("drpbranch").disabled=true;
   document.getElementById("txtagency").disabled=true;
   document.getElementById("txtbartercode").disabled=true;
   document.getElementById("txtbartername").disabled=true;
   document.getElementById("txtbarterstdt").disabled=true;
   document.getElementById("txtbarterendt").disabled=true;
   document.getElementById("txtprodamt").disabled=true;
   document.getElementById("txtbarteramt").disabled=true;
   document.getElementById("txtbarterarea").disabled=true;
   document.getElementById("txtremark").disabled=true;
   document.getElementById("txtproductdesc").disabled=true;
   document.getElementById("txtbarterkilldt").disabled=true;
   document.getElementById("drpuom").disabled=true;
     document.getElementById("drpstrbank").disabled=true;
   document.getElementById("txtclient").disabled=true;
   document.getElementById("div1").style.display="none";
   setButtonImages();
    return false;
}


function queryclick()
{
   clearclick();
   chkstatus(FlagStatus);
   hiddentext="query";
   document.getElementById('btnQuery').disabled=true;
   document.getElementById('btnExecute').disabled=false;
   document.getElementById('btnSave').disabled=true;
   document.getElementById('btnExecute').focus();
   
   document.getElementById("drpunit").value="0";
   document.getElementById("drpbranch").value="0";
   document.getElementById("txtagency").value="";
   document.getElementById("txtbartercode").value="";
   document.getElementById("txtbartername").value="";
   document.getElementById("txtbarterstdt").value="";
   document.getElementById("txtbarterendt").value="";
   document.getElementById("txtprodamt").value="";
   document.getElementById("txtbarteramt").value="";
   document.getElementById("txtbarterarea").value="";
   document.getElementById("txtremark").value="";
   document.getElementById("txtproductdesc").value="";
   document.getElementById("txtbarterkilldt").value="";
   document.getElementById("drpuom").value="0";
   document.getElementById("drpstrbank").value="0";
   document.getElementById("txtclient").value="";
   
   document.getElementById("drpunit").disabled=false;
   document.getElementById("drpbranch").disabled=false;
   document.getElementById("txtagency").disabled=false;
   document.getElementById("txtbartercode").disabled=false;
   document.getElementById("txtbartername").disabled=false;
   document.getElementById("txtbarterstdt").disabled=true;
   document.getElementById("txtbarterendt").disabled=true;
   document.getElementById("txtprodamt").disabled=true;
   document.getElementById("txtbarteramt").disabled=true;
   document.getElementById("txtbarterarea").disabled=true;
   document.getElementById("txtremark").disabled=true;
   document.getElementById("txtproductdesc").disabled=false;
   document.getElementById("txtbarterkilldt").disabled=true;
   document.getElementById("drpuom").disabled=true;
     document.getElementById("drpstrbank").disabled=true;
   document.getElementById("txtclient").disabled=false;
setButtonImages();
  return false;
}

function bindBranch(cou)
{
    if(typeof(cou)=="object")
    {
      var bunit=cou.value;
    }
    else
    {
       var bunit=cou;
    }
    if(bunit!="0")
    {
      Ad_BarteMaster.fillQBC(document.getElementById('drpunit').value,bindQBC_callback);
    }
    else
    {
     document.getElementById("drpunit").value="0";
     document.getElementById("drpbranch").value="0";
    }
    return false;
}
function bindQBC_callback(response)
{
    //alert(response.value);
    var ds=response.value;
    agcatby = document.getElementById("drpbranch");
    agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Branch--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
    //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].Branch_Code);
        
            agcatby.options.length;       
        }
        
        if(branchvar == undefined || branchvar=="")
        {
          document.getElementById('drpbranch').value="0";
        }
        else
        {
          document.getElementById('drpbranch').value=branchvar;
          branchvar="";
        } 
    }
}


function exitclick()
{
    if(confirm("Do you want to skip this page."))
    {
       window.close();
       return false;
    }
  return false;
}

function tabvalue (event,id)
{
var key=event.keyCode?event.keyCode:event.which;
    if(key==13)
    {
            if(document.activeElement.id==id)
            {
                if(document.getElementById('btnSave').disabled==false)
                {
                   document.getElementById('btnSave').focus();
                }
                 return;

            }
            else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
            {
                key=13;
                return key;

            }
            else if(document.activeElement.id=="lstagency")
           {
                if(document.getElementById('lstagency').value=="0" )
                {
                    alert("Please select the agency sub code");
                    return false;
                }
                document.getElementById("div1").style.display="none";
                document.getElementById('hiddenagcode').value=document.getElementById('lstagency').value;
                 if(browser!="Microsoft Internet Explorer")
                { 
                var agcode=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].textContent;
                }
                else
                {
                 var agcode=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].innerText;
             
                }
                var agcode1=agcode.split('(');
                agcode1=agcode1[1].split('+');
                agencycode=trim(agcode1[0]);
                subagencycode=trim(agcode1[1].replace(')',''));
                if(browser!="Microsoft Internet Explorer")
                {
                document.getElementById('txtagency').value=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].textContent
                }
                else
                {
                 document.getElementById('txtagency').value=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].innerText
             
                }
                document.getElementById('txtagency').focus();
            }
             else if(document.activeElement.id=="lstclient")
           {
               if(document.getElementById('lstclient').value=="0" )
                {
                    alert("Please select Client");
                    return false;
                }
                document.getElementById("divclient").style.display="none";
                if(browser!="Microsoft Internet Explorer")
                {
                document.getElementById('txtclient').value=document.getElementById('lstclient').options[document.getElementById('lstclient').selectedIndex].textContent + '(' + document.getElementById('lstclient').value + ')';
                }
                else
                {
                document.getElementById('txtclient').value=document.getElementById('lstclient').options[document.getElementById('lstclient').selectedIndex].innerText + '(' + document.getElementById('lstclient').value + ')';
               
                }
                document.getElementById('txtclient').focus();
           }
            else
            {
                //alert(event.keyCode);
                key=9;
                //alert(event.keyCode);
                return key;
            }
    }
     if(key==27)  
    {
        if(document.getElementById("divclient").style.display=="block")
        {
             document.getElementById("divclient").style.display="none";
             document.getElementById("lstclient").options.length=0;
             document.getElementById("txtclient").focus();
        }    
        else if(document.getElementById("div1").style.display=="block")
        {
             document.getElementById("div1").style.display="none";
             document.getElementById("lstagency").options.length=0;
             document.getElementById("txtagency").focus();
        } 
    
    }
    if(key==113)  
    {
         
        if(document.activeElement.id=="txtagency")
        {
            aTag = eval( document.getElementById("txtagency"))
			var btag;
			var leftpos=0;
			var toppos=0;        
			do
			{
				aTag = eval(aTag.offsetParent);
				leftpos	+= aTag.offsetLeft;
				toppos += aTag.offsetTop;
				btag=eval(aTag)
			} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			
            document.getElementById("div1").style.left=document.getElementById("txtagency").offsetLeft + leftpos+"px";
            document.getElementById("div1").style.top= document.getElementById("txtagency").offsetTop + toppos + "px";//"510px";
            document.getElementById("div1").style.display="block"; 
           Ad_BarteMaster.bindAgency(document.getElementById('hiddencompcode').value,document.getElementById('txtagency').value.toUpperCase(),bindagencyname_callback);
        }
        else if(document.activeElement.id=="txtclient")
        {
             aTag = eval( document.getElementById("txtclient"))
			var btag;
			var leftpos=0;
			var toppos=0;        
			do
			{
				aTag = eval(aTag.offsetParent);
				leftpos	+= aTag.offsetLeft;
				toppos += aTag.offsetTop;
				btag=eval(aTag)
			} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			
            document.getElementById("divclient").style.left=document.getElementById("txtclient").offsetLeft + leftpos+"px";
            document.getElementById("divclient").style.top= document.getElementById("txtclient").offsetTop + toppos + "px";//"510px";
            document.getElementById("divclient").style.display="block";
            var res;
           
            res=Ad_BarteMaster.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value);
            
            if(res.value!=null && res.value.Tables.length>0)
            {
                var ds=res.value;
             var pkgitem = document.getElementById("lstclient");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Client-","0");
                if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                { 
                        //alert(pkgitem.options.length);
                    pkgitem.options.length = 1; 
                    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                    {
                        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
                    
                        pkgitem.options.length;       
                    }    
                }
                pkgitem.focus();
            }
    }
    }
   
}
function fillVal()
{
    if(document.activeElement.id=="lstagency")
           {
           var agcode="";
           
                if(document.getElementById('lstagency').value=="0" )
                {
                    alert("Please select the agency sub code");
                    return false;
                }
                document.getElementById("div1").style.display="none";
                agcode=document.getElementById('hiddenagcode').value=document.getElementById('lstagency').value;
                 if(browser!="Microsoft Internet Explorer")
                    {
                        agcode=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].textContent;
                    }
                    else
                    {
                     agcode=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].innerText;
                   
                    }
                var agcode1=agcode.split('(');
                agcode1=agcode1[1].split('+');
                agencycode=trim(agcode1[0]);
                subagencycode=trim(agcode1[1].replace(')',''));
                 if(browser!="Microsoft Internet Explorer")
                    {
                      document.getElementById('txtagency').value=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].textContent
                    }
                    else
                    {
                        document.getElementById('txtagency').value=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].innerText
                    }
                //return false;
                document.getElementById('txtagency').focus();
                 // 
            }
             else if(document.activeElement.id=="lstclient")
           {
               if(document.getElementById('lstclient').value=="0" )
                {
                    alert("Please select Client");
                    return false;
                }
                document.getElementById("divclient").style.display="none";
                 if(browser!="Microsoft Internet Explorer")
                    {
                         
                document.getElementById('txtclient').value=document.getElementById('lstclient').options[document.getElementById('lstclient').selectedIndex].textContent + '(' + document.getElementById('lstclient').value + ')';
                }
                else
                {
                document.getElementById('txtclient').value=document.getElementById('lstclient').options[document.getElementById('lstclient').selectedIndex].innerText + '(' + document.getElementById('lstclient').value + ')';
              
                }
                document.getElementById('txtclient').focus();
                  //return false;
           }
         
}

function bindagencyname_callback(response)
{       
    ds=response.value;
    
    var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name+'('+ ds.Tables[0].Rows[i].Agency_Code + ' + ' + ds.Tables[0].Rows[i].SUB_Agency_Code +')',ds.Tables[0].Rows[i].Agency_Code);        
            pkgitem.options.length;       
        }
    }
    document.getElementById('txtagency').value="";
    document.getElementById("lstagency").value="0";
    document.getElementById("lstagency").focus();
    return false;
}


//   -------------------- for save --------------------------------//

function saveclick()
{
var strtextd="";
 var  httpRequest =null;
    httpRequest= new XMLHttpRequest();
    if (httpRequest.overrideMimeType) 
    {
         httpRequest.overrideMimeType('text/xml');
         }
         //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

           httpRequest.open( "GET","checksessiondan.aspx", false );
           httpRequest.send('');
           //alert(httpRequest.readyState);
           if (httpRequest.readyState == 4)
           {
               //alert(httpRequest.status);
               if (httpRequest.status == 200)
               {
                   strtextd=httpRequest.responseText;
               }
               else
               {
                   //alert('There was a problem with the request.');
                   if(browser!="Microsoft Internet Explorer")
                   {
                       //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                   }
               }
           }
             if(strtextd!="sess")
      {
      alert('session expired');
          window.location.href="Default.aspx";
          return false;
      }
 
    document.getElementById("txtproductdesc").value=trim(document.getElementById("txtproductdesc").value);
    document.getElementById("txtbartername").value=trim(document.getElementById("txtbartername").value);
   var compcode=document.getElementById('hiddencompcode').value;
   var userid=document.getElementById('hiddenuserid').value;
   var unitcode=document.getElementById('drpunit').value;
   var branchcode=document.getElementById('drpbranch').value;
   //var agencycode="";
   //var subagencycode=""
   var bartercode=document.getElementById('txtbartercode').value;
   var barterdesc=document.getElementById('txtbartername').value;
   var barterstdt=document.getElementById('txtbarterstdt').value;
   var barterendt=document.getElementById('txtbarterendt').value;
   var ProdAmt=document.getElementById('txtprodamt').value;
   var barterAmt=document.getElementById('txtbarteramt').value;
   var barterArea=document.getElementById('txtbarterarea').value;
   var Remarks=document.getElementById('txtremark').value;
   var productdesc=document.getElementById('txtproductdesc').value;
   var barteruom=document.getElementById('drpuom').value;
   var barterkilldate=document.getElementById('txtbarterkilldt').value;
   var dateformat=document.getElementById('hiddendateformat').value;
   var strbook=document.getElementById('drpstrbank').value;
   
    var lbunit= document.getElementById("lbunit").innerHTML;
    var lbbranchname=document.getElementById("lbbranchname").innerHTML;
    var lbagency=document.getElementById("lbagency").innerHTML;
    var lblbartercode= document.getElementById("lblbartercode").innerHTML;
    var lblbartername=document.getElementById("lblbartername").innerHTML;
    var lblbarterstdt=document.getElementById("lblbarterstdt").innerHTML;
    var lbbarterendt=document.getElementById("lbbarterendt").innerHTML;
    var lbbarterkilldt=document.getElementById("lbbarterkilldt").innerHTML;
    var lblproddesc=document.getElementById("lblproddesc").innerHTML;
    var lblprodamt=document.getElementById("lblprodamt").innerHTML;
    var lblbarteramt=document.getElementById("lblbarteramt").innerHTML;
    var lbluom=document.getElementById("lbluom").innerHTML;
    var lblbarterarea=document.getElementById("lblbarterarea").innerHTML;
    var lblbarterremark=document.getElementById("lblbarterremark").innerHTML;
    var client=""
    if(document.getElementById('txtclient').value!="" && document.getElementById('txtclient').value.lastIndexOf('(')>=0)
        client=document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf('(')+1,document.getElementById('txtclient').value.length  + document.getElementById('txtclient').value.lastIndexOf('('));
     client = client.replace(")", "");
    
   if((document.getElementById("drpunit").value =="0") && (lbunit.indexOf("*") >=0))
  {
    alert("Please Enter Center." );
    document.getElementById("drpunit").focus();
    return false;
  }
  else if((document.getElementById("drpbranch").value =="0" ||document.getElementById("drpbranch").value=="") && (lbbranchname.indexOf("*") >="0"))
  {
    alert("Please Enter Branch." );
    document.getElementById("drpbranch").focus();
    return false;
  }
  else if(( document.getElementById("txtagency").value =="" ) && (lbagency.indexOf("*") >="0"))
  {
    alert("Please Enter Agency." );
    document.getElementById("txtagency").focus();
    return false;
  }
  if(document.getElementById("txtclient").value =="" && document.getElementById("txtagency").value =="" )
  {
  alert("Please Enter Agency." );
    document.getElementById("txtagency").focus();
    return false;
  }
  if(document.getElementById('txtagency').value !="" && document.getElementById('txtagency').value.lastIndexOf('(')<0)
     {
         alert("This Agency does not exists." );
        document.getElementById("txtagency").focus();
        return false;
     }
   if(document.getElementById('txtagency').value !="" && document.getElementById('txtagency').value.lastIndexOf('(')>=0)
       {
            var agcode=document.getElementById('txtagency').value;
            var agcode1=agcode.split('(');
            agcode1=agcode1[1].split('+');
            agencycode=trim(agcode1[0]);
            subagencycode=trim(agcode1[1].replace(')',''));
            var code=agencycode+subagencycode;
            var chr_res=Ad_BarteMaster.chkCodeMain( 'agency',code, compcode)
            var ds1=chr_res.value;
            if(ds1== false)
            {
            alert("This agency does not exists.");
            document.getElementById('txtagency').focus();
            return false;
            }
        }
        
   
//  else if(document.getElementById("txtclient").value =="" && document.getElementById("lbunit").innerHTML.indexOf("*") >=0 )
//  {
//    alert("Please Enter Client." );
//    document.getElementById("txtclient").focus();
//    return false;
//  }
     if(document.getElementById('txtclient').value !="" && document.getElementById('txtclient').value.lastIndexOf('(')<0)
     {
         alert("This Client does not exists." );
        document.getElementById("txtclient").focus();
        return false;
     }
    if(document.getElementById('txtclient').value !="" && document.getElementById('txtclient').value.lastIndexOf('(')>=0)
       {
            var clientcode = document.getElementById('txtclient').value;
             var myarray1 = clientcode.split('(');
            var client = myarray1[1];
            client = client.replace(")", '');
            var chr_res=Ad_BarteMaster.chkCodeMain( 'client',client, compcode)
            var ds1=chr_res.value;
            if(ds1== false)
            {
            alert("This Client does not exists.");
            document.getElementById('txtclient').focus();
            return false;
            }
        }      
      
  if(document.getElementById("hiddenauto").value!= 1)
  {
   if((document.getElementById("txtbartercode").value =="") && (lblbartercode.indexOf("*") >="0"))
  {
    alert("Please Enter Barter Code." );
    document.getElementById("txtbartercode").focus();
    return false;
  }
  }
  if((document.getElementById("txtbarteramt").value =="") && (lblbarteramt.indexOf("*") >="0"))
  {
    alert("Please Enter Barter Amount." );
    document.getElementById("txtbarteramt").focus();
    return false;
  }
   if((document.getElementById("txtbarterstdt").value =="") && (lblbarterstdt.indexOf("*") >="0"))
  {
    alert("Please Enter Start Date.");
    document.getElementById("txtbarterstdt").focus();
    return false;
  }
  if((document.getElementById("txtbarterendt").value =="") && (lbbarterendt.indexOf("*") >="0") )
  {
    alert("Please Enter End Date." );
    document.getElementById("txtbarterendt").focus();
    return false;
  }
  // check date validation
  if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
  {
      var startdate=document.getElementById("txtbarterstdt").value;
      var enddate=document.getElementById("txtbarterendt").value;
      var startdateC=startdate.split("/")[1] + '/' + startdate.split("/")[0] + '/' + startdate.split("/")[2];
      var enddateC=enddate.split("/")[1] + '/' + enddate.split("/")[0] + '/' + enddate.split("/")[2];
      var d1=new Date(startdateC);
      var d2=new Date(enddateC);
      if(d1>d2)
      {
        alert("Start Date can't be greater than End Date");
        return false;
      }
  }
  else  if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
  {
      var startdate=document.getElementById("txtbarterstdt").value;
      var enddate=document.getElementById("txtbarterendt").value;
      var startdateC=startdate.split("/")[1] + '/' + startdate.split("/")[2] + '/' + startdate.split("/")[0];
      var enddateC=enddate.split("/")[1] + '/' + enddate.split("/")[2] + '/' + enddate.split("/")[0];
      var d1=new Date(startdateC);
      var d2=new Date(enddateC);
      if(d1>d2)
      {
        alert("Start Date can't be greater than End Date");
        return false;
      }
  }
   else  if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
  {
      var startdateC=document.getElementById("txtbarterstdt").value;
      var enddateC=document.getElementById("txtbarterendt").value;
      var d1=new Date(startdateC);
      var d2=new Date(enddateC);
      if(d1>d2)
      {
        alert("Start Date can't be greater than End Date");
        return false;
      }
  }
  if((document.getElementById("txtbartername").value =="") && (lblbartername.indexOf("*") >="0"))
  {
    alert("Please Enter Barter Description." );
    document.getElementById("txtbartername").focus();
    return false;
  }
   if(( document.getElementById("txtproductdesc").value =="" ) && (lblproddesc.indexOf("*") >="0"))
  {
    alert("Please Enter Product Description." );
    document.getElementById("txtproductdesc").focus();
    return false;
  }
   if(( document.getElementById("txtprodamt").value =="" ) && (lblprodamt.indexOf("*") >="0"))
  {
    alert("Please Enter Product Amount." );
    document.getElementById("txtprodamt").focus();
    return false;
  }
  if((document.getElementById("drpuom").value =="0") && (lbluom.indexOf("*") >="0"))
  {
    alert("Please Enter Barter UOM." );
    document.getElementById("drpuom").focus();
    return false;
  }
  if((document.getElementById("txtbarterarea").value =="") && (lblbarterarea.indexOf("*") >="0"))
  {
    alert("Please Enter Barter Area." );
    document.getElementById("txtbarterarea").focus();
    return false;
  }
//     else if((document.getElementById("txtbarterkilldt").value =="") && (lbbarterkilldt.indexOf("*") >="0"))
//  {
//    alert("Please Enter Barter Kill Date." );
//    document.getElementById("txtbarterkilldt").focus();
//    return false;
//  }
  if(document.getElementById("txtbarterkilldt").value!="")
  {
    if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
  {
      var startdate=document.getElementById("txtbarterstdt").value;
      var enddate=document.getElementById("txtbarterkilldt").value;
      var startdateC=startdate.split("/")[1] + '/' + startdate.split("/")[0] + '/' + startdate.split("/")[2];
      var enddateC=enddate.split("/")[1] + '/' + enddate.split("/")[0] + '/' + enddate.split("/")[2];
      var d1=new Date(startdateC);
      var d2=new Date(enddateC);
      if(d2<d1)
      {
        alert("Kill Date Can not be less than Start Date");
        return false;
      }
  }
  else  if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
  {
      var startdate=document.getElementById("txtbarterstdt").value;
      var enddate=document.getElementById("txtbarterkilldt").value;
      var startdateC=startdate.split("/")[1] + '/' + startdate.split("/")[2] + '/' + startdate.split("/")[0];
      var enddateC=enddate.split("/")[1] + '/' + enddate.split("/")[2] + '/' + enddate.split("/")[0];
      var d1=new Date(startdateC);
      var d2=new Date(enddateC);
      if(d2<d1)
      {
        alert("Kill Date Can not be less than Start Date");
        return false;
      }
  }
   else  if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
  {
      var startdate=document.getElementById("txtbarterstdt").value;
      var enddate=document.getElementById("txtbarterkilldt").value;
     
      var d1=new Date(startdate);
      var d2=new Date(enddate);
      if(d2<d1)
      {
        alert("Kill Date Can not be less than Start Date");
        return false;
      }
  }
  }
   if((document.getElementById("txtremark").value =="") && (lblbarterremark.indexOf("*") >="0"))
  {
    alert("Please Enter Barter Remarks." );
    document.getElementById("txtremark").focus();
    return false;
  }
//  if(document.getElementById("drpstrbank").value =="0")
//  {
//    alert("Please Enter Stop Booking." );
//    document.getElementById("drpstrbank").focus();
//    return false;
//  }
  
   if(hiddentext !="modify")
   {
       Ad_BarteMaster.checkdupbarter(compcode,unitcode,branchcode,bartercode,barterdesc,agencycode,subagencycode ,save_callback)
       return false;
   }
   else
   {
       if(barterdesc!=checkmodname)
		{
		    var res=Ad_BarteMaster.checkdupbarter(compcode,unitcode,branchcode,bartercode,barterdesc,agencycode,subagencycode)
		    if(res.value.Tables[1].Rows.length>0)
		    {
		        alert("This Barter Name Is Already Exist, Try Another Name !!!!");
		        document.getElementById('txtbartername').focus();
		        return false;
		    }
		}
		
		if(document.getElementById('txtagency').value!=null&&document.getElementById('txtagency').value!="")
		{
		var agcode=document.getElementById('txtagency').value;
        var agcode1=agcode.split('(');
        agcode1=agcode1[1].split('+');
        agencycode=trim(agcode1[0]);
        subagencycode=trim(agcode1[1].replace(')',''));
        }
		Ad_BarteMaster.bartermodify(compcode,userid,unitcode,branchcode,agencycode,subagencycode,bartercode,barterdesc,barterstdt,barterendt,ProdAmt,barterAmt,barterArea,Remarks,dateformat,productdesc,barteruom,barterkilldate,strbook,client);
		
		gdsexecute.Tables[0].Rows[rowN].AgencyName= document.getElementById("txtagency").value;
        gdsexecute.Tables[0].Rows[rowN].BARTE_DESC=document.getElementById("txtbartername").value; 
        gdsexecute.Tables[0].Rows[rowN].PRODUCT_AMOUNT= document.getElementById("txtprodamt").value;
        gdsexecute.Tables[0].Rows[rowN].BARTER_KILLDT=document.getElementById("txtbarterkilldt").value; 
        gdsexecute.Tables[0].Rows[rowN].BARTER_STDT= document.getElementById("txtbarterstdt").value;
        gdsexecute.Tables[0].Rows[rowN].BARTER_ENDDT= document.getElementById("txtbarterendt").value;
        gdsexecute.Tables[0].Rows[rowN].BARTER_AMOUNT= document.getElementById("txtbarteramt").value;
        gdsexecute.Tables[0].Rows[rowN].BARTER_AREA=document.getElementById("txtbarterarea").value; 
        gdsexecute.Tables[0].Rows[rowN].BARTER_REMARK=document.getElementById("txtremark").value; 
        gdsexecute.Tables[0].Rows[rowN].PROD_DESC=document.getElementById("txtproductdesc").value; 
        gdsexecute.Tables[0].Rows[rowN].BARTER_UOM=document.getElementById("drpuom").value; 
        gdsexecute.Tables[0].Rows[rowN].CLIENT_CODE=document.getElementById("txtclient").value;
        gdsexecute.Tables[0].Rows[rowN].STOPBOOKING=document.getElementById("drpstrbank").value;
        
		alert("Data update successfully.");
	
		//--------------------------------------//
		updateStatus();
        document.getElementById('btnfirst').disabled=false;				
	    document.getElementById('btnnext').disabled=false;					
	    document.getElementById('btnprevious').disabled=false;			
	    document.getElementById('btnlast').disabled=false;
	    document.getElementById('btnExit').disabled=false;
       var x=gdsexecute.Tables[0].Rows.length;
       y=rowN;	
       if (rowN==0)
       {
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
       }
       if(rowN==(gdsexecute.Tables[0].Rows.length-1))
       {
            document.getElementById('btnNext').disabled=true;
            document.getElementById('btnLast').disabled=true;
       }
       
       agencycode="";
       subagencycode=""
       document.getElementById("drpunit").disabled=true;
       document.getElementById("drpbranch").disabled=true;
       document.getElementById("txtagency").disabled=true;
       document.getElementById("txtbartercode").disabled=true;
       document.getElementById("txtbartername").disabled=true;
       document.getElementById("txtbarterstdt").disabled=true;
       document.getElementById("txtbarterendt").disabled=true;
       document.getElementById("txtprodamt").disabled=true;
       document.getElementById("txtbarteramt").disabled=true;
       document.getElementById("txtbarterarea").disabled=true;
       document.getElementById("txtremark").disabled=true;
       document.getElementById("txtproductdesc").disabled=true;
       document.getElementById("txtbarterkilldt").disabled=true;
       document.getElementById("drpuom").disabled=true;
       document.getElementById("drpstrbank").disabled=true;
       document.getElementById("txtclient").disabled=true;
       setButtonImages();
       return false;
   }
  
}

function save_callback(res)
{
    var ds =res.value;
    if(ds.Tables[0].Rows.length > 0)
    {
	    alert("This Barter Code Is Already Exist, Try Another Code !!!!");
	    return false;
    } 
    else if(ds.Tables[1].Rows.length > 0)
    {
	    alert("This Barter Name Is Already Exist, Try Another Code !!!!");
	    return false;
    } 
    else
    {
           var compcode=document.getElementById('hiddencompcode').value;
           var userid=document.getElementById('hiddenuserid').value;
           var unitcode=document.getElementById('drpunit').value;
           var branchcode=document.getElementById('drpbranch').value;
           //var agencycode="";
           //var subagencycode=""
           var bartercode=document.getElementById('txtbartercode').value;
           var barterdesc=document.getElementById('txtbartername').value;
           var barterstdt=document.getElementById('txtbarterstdt').value;
           var barterendt=document.getElementById('txtbarterendt').value;
           var ProdAmt=document.getElementById('txtprodamt').value;
           var barterAmt=document.getElementById('txtbarteramt').value;
           var barterArea=document.getElementById('txtbarterarea').value;
           var Remarks=document.getElementById('txtremark').value;
           var productdesc=document.getElementById('txtproductdesc').value;
           var barteruom=document.getElementById('drpuom').value;
           var barterkilldate=document.getElementById('txtbarterkilldt').value;
           var dateformat=document.getElementById('hiddendateformat').value;
           var strbook=document.getElementById('drpstrbank').value;
           var client=""
    if(document.getElementById('txtclient').value!="" && document.getElementById('txtclient').value.lastIndexOf('(')>=0)
        client=document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf('(')+1,document.getElementById('txtclient').value.length  + document.getElementById('txtclient').value.lastIndexOf('('));
     client = client.replace(")", "");
             //****************** check agency exists or not****************************//
           if(document.getElementById('txtagency').value !="" && document.getElementById('txtagency').value.lastIndexOf('(')>=0)
           {
                var agcode=document.getElementById('txtagency').value;
                var agcode1=agcode.split('(');
                agcode1=agcode1[1].split('+');
                agencycode=trim(agcode1[0]);
                subagencycode=trim(agcode1[1].replace(')',''));
                var code=agencycode+subagencycode;
               
            }
            if(document.getElementById('txtagency').value !="" )
            {
            var chr_res=Ad_BarteMaster.chkCodeMain( 'agency',code, compcode)
            var ds1=chr_res.value;
            if(ds1== false)
            {
               alert("This agency does not exists.");
               document.getElementById('txtagency').focus();
               return false;
            }
           else
           {
               Ad_BarteMaster.bartersave(compcode,userid,unitcode,branchcode,agencycode,subagencycode,bartercode,barterdesc,barterstdt,barterendt,ProdAmt,barterAmt,barterArea,Remarks,dateformat,productdesc,barteruom,barterkilldate,strbook,client);
               
               alert("Data saved successfully.");
               document.getElementById('btnNew').disabled=false;
               document.getElementById('btnQuery').disabled=false;
               document.getElementById('btnCancel').disabled=false;		
               document.getElementById('btnExit').disabled=false;	
            	
              document.getElementById('btnSave').disabled=true;
              document.getElementById('btnModify').disabled=true;
              document.getElementById('btnDelete').disabled=true;
              document.getElementById('btnExecute').disabled=true;
              document.getElementById('btnfirst').disabled=true;				
              document.getElementById('btnnext').disabled=true;					
              document.getElementById('btnprevious').disabled=true;			
              document.getElementById('btnlast').disabled=true;
              agencycode="";
              subagencycode=""
              clearclick();
        }
      }
      else
           {
               Ad_BarteMaster.bartersave(compcode,userid,unitcode,branchcode,agencycode,subagencycode,bartercode,barterdesc,barterstdt,barterendt,ProdAmt,barterAmt,barterArea,Remarks,dateformat,productdesc,barteruom,barterkilldate,strbook,client);
               
               alert("Data saved successfully.");
               document.getElementById('btnNew').disabled=false;
               document.getElementById('btnQuery').disabled=false;
               document.getElementById('btnCancel').disabled=false;		
               document.getElementById('btnExit').disabled=false;	
            	
              document.getElementById('btnSave').disabled=true;
              document.getElementById('btnModify').disabled=true;
              document.getElementById('btnDelete').disabled=true;
              document.getElementById('btnExecute').disabled=true;
              document.getElementById('btnfirst').disabled=true;				
              document.getElementById('btnnext').disabled=true;					
              document.getElementById('btnprevious').disabled=true;			
              document.getElementById('btnlast').disabled=true;
              agencycode="";
              subagencycode=""
              clearclick();
        }
    }
     return false;
}

function modifyclick()
{
   chkstatus(FlagStatus);
   document.getElementById('btnSave').disabled = false;
   document.getElementById('btnQuery').disabled = true; 
   document.getElementById('btnExecute').disabled=true;
   
   
   hiddentext="modify";
   document.getElementById("drpunit").disabled=true;
   document.getElementById("drpbranch").disabled=true;
   document.getElementById("txtagency").disabled=false;
   document.getElementById("txtbartercode").disabled=true;
   document.getElementById("txtbartername").disabled=false;
   document.getElementById("txtbarterstdt").disabled=false;
   document.getElementById("txtbarterendt").disabled=false;
   document.getElementById("txtprodamt").disabled=false;
   document.getElementById("txtbarteramt").disabled=false;
   document.getElementById("txtbarterarea").disabled=false;
   document.getElementById("txtremark").disabled=false;
   document.getElementById("txtproductdesc").disabled=false;
   document.getElementById("txtbarterkilldt").disabled=false;
   document.getElementById("drpuom").disabled=false;
   document.getElementById("drpstrbank").disabled=false;
   document.getElementById("txtclient").disabled=false;
   checkmodname=document.getElementById("txtbartername").value;
   setButtonImages();
   return false;
}

function executeclick()
{

   // disableflds();
     //  pagedef();
       hiddentext="execute";
   
       var compcode=document.getElementById('hiddencompcode').value;
       var userid=document.getElementById('hiddenuserid').value;
       var unitcode=document.getElementById('drpunit').value;
       var branchcode=document.getElementById('drpbranch').value;
       var bartercode=document.getElementById('txtbartercode').value;
       var barterdesc=document.getElementById('txtbartername').value;
       var barterstdt=document.getElementById('txtbarterstdt').value;
       var barterendt=document.getElementById('txtbarterendt').value;
       var ProdAmt=document.getElementById('txtprodamt').value;
       var barterAmt=document.getElementById('txtbarteramt').value;
       var barterArea=document.getElementById('txtbarterarea').value;
       var Remarks=document.getElementById('txtremark').value;
       var productdesc=document.getElementById('txtproductdesc').value;
       var barteruom=document.getElementById('drpuom').value;
       var barterkilldate=document.getElementById('txtbarterkilldt').value;
       var strbook=document.getElementById('drpstrbank').value;
       var dateformat=document.getElementById('hiddendateformat').value;
        var client=""
    if(document.getElementById('txtclient').value!="" && document.getElementById('txtclient').value.lastIndexOf('(')>=0)
    {
        client=document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf('(')+1,document.getElementById('txtclient').value.length  + document.getElementById('txtclient').value.lastIndexOf('('));
     client = client.replace(")", "");
     }
     else if(document.getElementById('txtclient').value!="")
         {
         alert("Please select correct Client");
         document.getElementById('txtclient').focus();
         return false;
         }
   if(document.getElementById('txtagency').value != "" && document.getElementById('txtagency').value.lastIndexOf('(')>=0)
    {
           var agcode=document.getElementById('txtagency').value;
           var agcode1=agcode.split('(');
           agcode1=agcode1[1].split('+');
           agencycode=trim(agcode1[0]);
           subagencycode=trim(agcode1[1].replace(')',''));
       }
       else if(document.getElementById('txtagency').value!="")
         {
         alert("Please select correct Agency by Pressing F2");
         document.getElementById('txtagency').value="";
         document.getElementById('txtagency').focus();
         return false;
         }
       glunit=unitcode;
       glbranchcode=branchcode;
       glbartercode=bartercode;
       glbarterdesc=barterdesc;
       glbarterstdt=barterstdt;
       glbarterendt=barterendt;
       glbarterkilldate=barterkilldate;
       glproductdesc=productdesc;
       glagencycode=agencycode;
       glstrbook=strbook
       glclient=client;
       glsubagencycode=subagencycode;
       var barterdesc= barterdesc.toUpperCase();
       var bartercode= bartercode.toUpperCase();
       rowN=0;
       var res = Ad_BarteMaster.executebarter(compcode,unitcode, branchcode, bartercode, barterdesc,barterstdt,barterendt,barterkilldate,productdesc,agencycode,subagencycode,strbook,client)
       executeclick_call(res);
	
       if(document.getElementById('btnModify').disabled==false)					
	     document.getElementById('btnModify').focus();
             
        document.getElementById("drpunit").disabled=true;
        document.getElementById("drpbranch").disabled=true;
        document.getElementById("txtagency").disabled=true;
        document.getElementById("txtbartercode").disabled=true;
        document.getElementById("txtbartername").disabled=true;
        document.getElementById("txtbarterstdt").disabled=true;
        document.getElementById("txtbarterendt").disabled=true;
        document.getElementById("txtprodamt").disabled=true;
        document.getElementById("txtbarteramt").disabled=true;
        document.getElementById("txtbarterarea").disabled=true;
        document.getElementById("txtremark").disabled=true;
        document.getElementById("txtproductdesc").disabled=true;
        document.getElementById("txtbarterkilldt").disabled=true;
        document.getElementById("drpuom").disabled=true;
         document.getElementById("drpstrbank").disabled=true;
        document.getElementById("txtclient").disabled=true;
  
  
   
    return false;
}


function executeclick_call(responce)
{
    if(responce.error!=null)
    {
        alert("ERROR : \n"+responce.error.description);
        return false;
    }
    gdsexecute=responce.value;
    if(gdsexecute!=null)
    {
        if(gdsexecute.Tables[0].Rows.length>0)
        {
          bindctrls();
        }
        else
        {
            alert("Your Search Produces No Result");
            clearclick();
            return false;
        }
    }
    
     updateStatus();
    
    if(gdsexecute.Tables[0].Rows.length==1)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
    }
    else
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
    }
    setButtonImages();
}


function bindctrls()
{    
            
     document.getElementById('drpunit').value=gdsexecute.Tables[0].Rows[rowN].UNIT_CODE;
     branchvar=gdsexecute.Tables[0].Rows[rowN].BRAN_CODE;
     bindBranch(document.getElementById('drpunit').value);
    // document.getElementById('drpbranch').value = gdsexecute.Tables[0].Rows[rowN].BRAN_CODE;
     document.getElementById('txtbartercode').value=gdsexecute.Tables[0].Rows[rowN].BARTER_CODE;
     document.getElementById('txtbartername').value = gdsexecute.Tables[0].Rows[rowN].BARTE_DESC;
     var dateformat = document.getElementById('hiddendateformat').value;
	//-------------------- get barter start date---------------------------------//
	 var txt=gdsexecute.Tables[0].Rows[rowN].BARTER_STDT;
	 var dd=txt.getDate();
	 var mm=txt.getMonth() + 1;
	var yyyy=txt.getFullYear();
	if(gdsexecute.Tables[0].Rows[rowN].BARTER_STDT==null)
	{
	    document.getElementById('txtbarterstdt').value="";
	}
	else
	{
	    var txtto=gdsexecute.Tables[0].Rows[rowN].BARTER_STDT;
		var dd1=txtto.getDate();
		var mm1=txtto.getMonth()+1;
		var yyyy1=txtto.getFullYear();
		if(dateformat=="dd/mm/yyyy")
		{
		document.getElementById('txtbarterstdt').value=dd1+'/'+mm1+'/'+yyyy1;
		}
		else if(dateformat=="mm/dd/yyyy")
		{
		document.getElementById('txtbarterstdt').value=mm1+'/'+dd1+'/'+yyyy1;
		}
		else if(dateformat=="yyyy/mm/dd")
		{
		document.getElementById('txtbarterstdt').value=yyyy1+'/'+mm1+'/'+dd1;
		}
		else if(dateformat==null || dateformat=="" || dateformat=="undefined")
		{
			document.getElementById('txtbarterstdt').value=dd1+'/'+mm1+'/'+yyyy1;			
		}
					
	}	
	
	//--------------------------
	 var txtenddt=gdsexecute.Tables[0].Rows[rowN].BARTER_ENDDT;
	 var dd0=txtenddt.getDate();
	 var mm0=txtenddt.getMonth() + 1;
	var yyyy0=txtenddt.getFullYear();
	if(gdsexecute.Tables[0].Rows[rowN].BARTER_ENDDT==null)
	{
	    document.getElementById('txtbarterendt').value="";
	}
	else
	{
	    var txtenddt1=gdsexecute.Tables[0].Rows[rowN].BARTER_ENDDT;
		var dd11=txtenddt1.getDate();
		var mm11=txtenddt1.getMonth()+1;
		var yyyy11=txtenddt1.getFullYear();
		if(dateformat=="dd/mm/yyyy")
		{
		document.getElementById('txtbarterendt').value=dd11+'/'+mm11+'/'+yyyy11;
		}
		else if(dateformat=="mm/dd/yyyy")
		{
		document.getElementById('txtbarterendt').value=mm11+'/'+dd11+'/'+yyyy11;
		}
		else if(dateformat=="yyyy/mm/dd")
		{
		document.getElementById('txtbarterendt').value=yyyy11+'/'+mm11+'/'+dd11;
		}
		else if(dateformat==null || dateformat=="" || dateformat=="undefined")
		{
			document.getElementById('txtbarterendt').value=dd11+'/'+mm11+'/'+yyyy11;			
		}
					
	}
	//------------------------------------------------------------------------------------//
	 var txtkilldt=gdsexecute.Tables[0].Rows[rowN].BARTER_KILLDT;
//	 var dd01=txtkilldt.getDate();
//	 var mm01=txtkilldt.getMonth() + 1;
//	var yyyy01=txtkilldt.getFullYear();
	if(gdsexecute.Tables[0].Rows[rowN].BARTER_KILLDT==null)
	{
	    document.getElementById('txtbarterkilldt').value="";
	}
	else
	{
	    var txtkilldt11=gdsexecute.Tables[0].Rows[rowN].BARTER_KILLDT;
		var dd110=txtkilldt11.getDate();
		var mm110=txtkilldt11.getMonth()+1;
		var yyyy110=txtkilldt11.getFullYear();
		if(dateformat=="dd/mm/yyyy")
		{
		document.getElementById('txtbarterkilldt').value=dd110+'/'+mm110+'/'+yyyy110;
		}
		else if(dateformat=="mm/dd/yyyy")
		{
		document.getElementById('txtbarterkilldt').value=mm110+'/'+dd110+'/'+yyyy110;
		}
		else if(dateformat=="yyyy/mm/dd")
		{
		document.getElementById('txtbarterkilldt').value=yyyy110+'/'+mm110+'/'+dd110;
		}
		else if(dateformat==null || dateformat=="" || dateformat=="undefined")
		{
			document.getElementById('txtbarterkilldt').value=dd11+'/'+mm11+'/'+yyyy11;			
		}
					
	}
	//----------------------------------------------------------------------------------------//		
  
     document.getElementById('txtprodamt').value=gdsexecute.Tables[0].Rows[rowN].PRODUCT_AMOUNT;
     document.getElementById('txtbarteramt').value=gdsexecute.Tables[0].Rows[rowN].BARTER_AMOUNT;
     document.getElementById('txtbarterarea').value=gdsexecute.Tables[0].Rows[rowN].BARTER_AREA;
     document.getElementById('txtremark').value=gdsexecute.Tables[0].Rows[rowN].BARTER_REMARK;
     document.getElementById('drpuom').value=gdsexecute.Tables[0].Rows[rowN].BARTER_UOM;
     document.getElementById('txtproductdesc').value=gdsexecute.Tables[0].Rows[rowN].PROD_DESC;
     if(gdsexecute.Tables[0].Rows[rowN].AgencyName==null||gdsexecute.Tables[0].Rows[rowN].AgencyName=="")
     {
     document.getElementById('txtagency').value="";
     }
     else
     {
     document.getElementById('txtagency').value=gdsexecute.Tables[0].Rows[rowN].AgencyName;
     }
     if(gdsexecute.Tables[0].Rows[rowN].CUSTNAME!=null)
     {
        document.getElementById('txtclient').value=gdsexecute.Tables[0].Rows[rowN].CUSTNAME + "(" + gdsexecute.Tables[0].Rows[rowN].CLIENT_CODE+")";
     }
     document.getElementById('drpstrbank').value=gdsexecute.Tables[0].Rows[rowN].STOPBOOKING;
     
    
}

function firstclick()
{
    rowN=0;
    
    document.getElementById("btnfirst").disabled=true;
    document.getElementById("btnprevious").disabled=true;
    document.getElementById("btnnext").disabled=false;
    document.getElementById("btnlast").disabled=false;
    
    bindctrls();
    setButtonImages();
    return false;
}

function prevclick()
{
    rowN--;
    if(rowN<=0)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
        rowN=0;
    }
    else
    {
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
    }
    bindctrls();
    setButtonImages();
    return false;
}

function nextclick()
{
    rowN++;
    if(rowN>=gdsexecute.Tables[0].Rows.length-1)
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
        rowN=gdsexecute.Tables[0].Rows.length-1;
    }
    else
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
    }
    bindctrls();
    setButtonImages();
    return false;
}

function lastclick()
{
    rowN=gdsexecute.Tables[0].Rows.length-1;
    
    document.getElementById("btnfirst").disabled=false;
    document.getElementById("btnprevious").disabled=false;
    document.getElementById("btnnext").disabled=true;
    document.getElementById("btnlast").disabled=true;
    
    bindctrls();
    setButtonImages();
    return false;
}

function deleteclick()
{
var strtextd="";
 var  httpRequest =null;
    httpRequest= new XMLHttpRequest();
    if (httpRequest.overrideMimeType) {
         httpRequest.overrideMimeType('text/xml');
         }
         //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

           httpRequest.open( "GET","checksessiondan.aspx", false );
           httpRequest.send('');
           //alert(httpRequest.readyState);
           if (httpRequest.readyState == 4)
           {
               //alert(httpRequest.status);
               if (httpRequest.status == 200)
               {
                   strtextd=httpRequest.responseText;
               }
               else
               {
                   //alert('There was a problem with the request.');
                   if(browser!="Microsoft Internet Explorer")
                   {
                       //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                   }
               }
           }
             if(strtextd!="sess")
      {
      alert('session expired');
          window.location.href="Default.aspx";
          return false;
      }
 
  if(confirm('Are you sure you want to delete?'))
  {
     var compcode = document.getElementById("hiddencompcode").value;
     var bartercode=document.getElementById("txtbartercode").value;
      
     Ad_BarteMaster.deletebarter(bartercode, compcode);
     alert("Data Deleted Successfully");
     rowN=0;  
     var res = Ad_BarteMaster.executebarter(compcode,glunit, glbranchcode, glbartercode, glbarterdesc,glbarterstdt,glbarterendt,glbarterkilldate,glproductdesc,glagencycode,glsubagencycode,glstrbook,glclient)
     executeclick_call(res);
  }
  setButtonImages();
  return false;
   
}


// ******************************Code For Auto Generation********************

 function autoornot()
 {
      if(hiddentext=="new")
      {
        if(document.getElementById('hiddenauto').value==1)
        {
          autochange();
          return false;
        }
        else
        {
          userdefine();
          return false;
        }
      }

}

// Auto generated
// This Function is for check that whether this is case for new or modify

function autochange()
{
   if(hiddentext=="new" )
   {
       UPPERCASE();
   }
   else
   {
        document.getElementById('txtbartername').value=document.getElementById('txtbartername').value.toUpperCase();
   }
return false;
}


//auto generated
//this is used for increment in code

function UPPERCASE()
{
	document.getElementById('txtbartername').value=document.getElementById('txtbartername').value.toUpperCase();
	document.getElementById('txtbartername').value=trim(document.getElementById('txtbartername').value);
	
	 lstr=document.getElementById('txtbartername').value;
     cstr=lstr.substring(0,1);
     var mstr="";
     	    if(lstr.indexOf(" ")==1)
            {
               var leng=lstr.length;
               mstr= cstr + lstr.substring(2,leng);
            }
            else
            {
               var leng=lstr.length;
               mstr=cstr + lstr.substring(1,leng);
            }
		
       if(document.getElementById('txtbartername').value!="")
       {
            document.getElementById('txtbartername').value=document.getElementById('txtbartername').value.toUpperCase();
		    str=mstr;
		    var compcode=document.getElementById('hiddencompcode').value;
            var unitcode=document.getElementById('drpunit').value;
            var branchcode=document.getElementById('drpbranch').value;
		    Ad_BarteMaster.chkbarterdesc(str,compcode,unitcode,branchcode,fillcall);
		    return false;
       }
   return false;
		
}

function fillcall(res)
{
		var ds=res.value;
		var newstr;
	
//	    if(ds.Tables[0].Rows.length!=0)
//	    {
//	        alert("This Barter name has already assigned !! ");
//	        document.getElementById('txtbartername').value="";
//		    document.getElementById('txtbartername').focus();
//    		return false;
//	    }

        if(ds.Tables[1].Rows.length==0)
        {
          newstr=null;
        }
        else
        {
           newstr=ds.Tables[1].Rows[0].BARTER_CODE;
        }
        if(newstr !=null )
        {
            var code=newstr;
            str=str.toUpperCase();
            code++;
            document.getElementById('txtbartercode').value=str.substr(0,2)+ code;
        }
        else
        {
            str=str.toUpperCase();
            document.getElementById('txtbartercode').value=str.substr(0,2)+ "0";
        }
	   return false;
}
		
function userdefine()
 {
        if(hiddentext=="new")
        {
            document.getElementById('txtbartercode').disabled=false;
            document.getElementById('txtbartername').value=document.getElementById('txtbartername').value.toUpperCase();
            document.getElementById('txtbartername').value=trim(document.getElementById('txtbartername').value);
            auto=document.getElementById('hiddenauto').value;
            return false;
        }

//return false;
}
//-------------------------------------------------------------------------//

function chkamount(e)
{
    var flag="";
    e=document.getElementById(e);//.value;
    var fld=e.value;
	if(fld!="")
    {
	    if(fld.match(/^\d+(\.\d{1,3})?$/i))
		{
			flag="t";
			return flag;
	    }
		else
		{
			alert("Input Error")
			var str=e.id;
			e.value="";
			document.getElementById(str).focus();
			flag="f";
			return false;
		}
	}
}


function LTrim( value ) {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}
function setButtonImages()
{
    if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
}


function chkfield(event)
{
    if (event.keyCode == "13" || event.keyCode == "9")
     {
        var key = event.keyCode;

        if (document.activeElement.id == "txtbartername")
         {
             if (key == 13 || key == 9) 
            {
                document.getElementById('txtbarterstdt').focus();
                return false;
            }
        }
        
        }
        
}