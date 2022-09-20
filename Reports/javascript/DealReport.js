//===========================DealReport Javascript ===================================//
/*Global Varible declaration*/

/* Start Function */
var browser=navigator.appName;
function bindadcategory() {
    var compcode = document.getElementById('hdncompcode').value;
    var adtype1 = document.getElementById('dpaddtype').value;
    DealReport.adcatbnd(adtype1, compcode, call_bindadcategory);
    DealReport.adpkg_bind(adtype1, compcode, call_pkg_schedule);
}
function call_bindadcategory(response) {
    ds = response.value;
    var brand = document.getElementById('dpadcatgory');
    brand.options.length = 0;
    brand.options[0] = new Option("--Select AdCat--");
    document.getElementById("dpadcatgory").options.length = 1;


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name, ds.Tables[0].Rows[i].Adv_Cat_Code);
            brand.options.length;
        }
    }

    return false;
}
function call_pkg_schedule(response) {
    ds = response.value;

    document.getElementById("drppackage").options.length = 0;
    var brand = document.getElementById('drppackage');
    brand.options.length = 0;
    brand.options[0] = new Option("--Select Package--");


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name, ds.Tables[0].Rows[i].Combin_Code);
            brand.options.length;
        }
    }

    return false;
}
function F2fillclientcr_dev(event) 

{
     var key=event.keyCode?event.keyCode:event.which;

    if (key == 113) 
    {
        var compcode = document.getElementById('hdncompcode').value;
        var client = document.getElementById('txtclient').value.toUpperCase();
        document.getElementById("div2").style.display = "block";
        aTag = eval(document.getElementById("txtclient"))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        document.getElementById('div2').style.top = document.getElementById("txtclient").offsetTop + toppos + "px";
        document.getElementById('div2').style.left = document.getElementById("txtclient").offsetLeft + leftpos + "px";
        document.getElementById('lstclient').focus();
        DealReport.fillF2_Creditclient(compcode, client, bindclient_callbackaa);
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
    document.getElementById('hdnclienttxt').value = "";
    document.getElementById('hdnclient1').value = "";
    document.getElementById('txtclient').value = "";
    }

}
function bindclient_callbackaa(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstclient");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Client Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name,ds_AccName.Tables[0].Rows[i].Cust_Code);         
                pkgitem.options.length;
            }
        }
        document.getElementById("lstclient").value="0";
        document.getElementById("div2").value="";
        document.getElementById('lstclient').focus();
   
        return false;

}
function Clickclientaa(event)
{
      var key=event.keyCode?event.keyCode:event.which;

    if(key==13 || event.type=="click")
    {
        if(document.activeElement.id=="lstclient")
        {
        if(document.getElementById('lstclient').value=="0")
            {
                 alert("Please select Client Name");
                 return false;
            }
            
            var page = document.getElementById('lstclient').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstclient').length-1;k++)
            {   
                if(document.getElementById('lstclient').options[k].value==page)
                {
                      if(browser!="Microsoft Internet Explorer")
                {
                var abc=document.getElementById('lstclient').options[k].textContent;
                    
                }
                else
                {
                    var abc=document.getElementById('lstclient').options[k].innerText;
                    }
                    document.getElementById('txtclient').value = abc;
                     document.getElementById('hdnclienttxt').value =abc;
                    document.getElementById('hdnclient1').value =page;
                    
                    document.getElementById("div2").style.display="none";
                    document.getElementById('txtclient').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(key==27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('txtclient').focus();
         }
  }
function F2fillagencycr_dev(event)
{

     var key=event.keyCode?event.keyCode:event.which;
if(key==113)
{
    var compcode = document.getElementById('hdncompcode').value;
    var agn = document.getElementById('txtagency').value.toUpperCase();
            document.getElementById("div1").style.display="block";
            aTag = eval(document.getElementById("txtagency"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('div1').style.top = document.getElementById("txtagency").offsetTop + toppos + "px";
            document.getElementById('div1').style.left = document.getElementById("txtagency").offsetLeft + leftpos + "px";
            document.getElementById('lstagency').focus();
            DealReport.fillF2_CreditAgency(compcode, agn, bindAgency_callbackbb);
    
 }
 else if (event.keyCode == 8 || event.keyCode == 46) {
 document.getElementById('txtagency').value = "";
 document.getElementById('hdnagencytxt').value = "";
 document.getElementById('hdnagmaincode').value = "";
 document.getElementById('hdnagsubcode').value = "";
 }
}
function bindAgency_callbackbb(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstagency");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Agency Name-","0"+ "$~$" +"");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name, ds_AccName.Tables[0].Rows[i].Agency_Code + "$~$" + ds_AccName.Tables[0].Rows[i].SUB_Agency_Code);         
                pkgitem.options.length;
            }
        }
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
   
        return false;

}
function ClickAgaencybb(event)
{
     var key=event.keyCode?event.keyCode:event.which;

    if(key==13 || event.type=="click")
    {
        if(document.activeElement.id=="lstagency")
        {
        if(document.getElementById('lstagency').value=="0")
            {
                 alert("Please select Agency Name");
                 return false;
            }
            
            var page = document.getElementById('lstagency').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstagency').length-1;k++)
            {   
                if(document.getElementById('lstagency').options[k].value==page)
                {
               if(browser!="Microsoft Internet Explorer")
                {
                     var abc=document.getElementById('lstagency').options[k].textContent;
              
                }
                else
                { 
                    var abc=document.getElementById('lstagency').options[k].innerText;
                    }
                    document.getElementById('txtagency').value = abc;
                    document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hdnagmaincode').value = page.split('$~$')[0];
                    document.getElementById('hdnagsubcode').value = page.split('$~$')[1];
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('txtagency').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txtagency').focus();
         }
  }
 function chkmand()
 {
     var newstr = "";
     var newstr1 = "";
 if(document.getElementById('txtfrmdate').value=="")
 {
     alert("Please Enter From Date");
     document.getElementById('txtfrmdate').focus();
    return false;
 }
 else if (document.getElementById('txttodate1').value == "") {
 alert("Please Enter To  Date");
 document.getElementById('txttodate1').focus();
     return false;
 }
 var listadcat = document.getElementById('dpadcatgory');
 for (var i = 1; i < listadcat.options.length; i++) {

     if (listadcat.options[i].selected == true) {
         if (newstr == "") {
             newstr = listadcat.options[i].value;
             newstr1 = listadcat.options[i].text;
         }
         else {
             newstr = newstr + "," + listadcat.options[i].value;
             newstr1 = newstr1 + "," + listadcat.options[i].text;
         }
     }

 }


 document.getElementById('hiddenadcat').value = newstr;
 document.getElementById('hiddenadcatname').value = newstr1;
 }
 function getpackagecode() {
     document.getElementById('hiddenpackage').value = document.getElementById('drppackage').value;
 }

 function openprintpage() {
     window.location.href = 'PrintDealReport.aspx';
     return false;
 }
 function calculatenextdate()
 {
 var fdate=document.getElementById('txtfrmdate').value;
 var fdate1="";
 var noofdays=0;
 var dd="";
 var mm="";
 var yy="";
  if(fdate != "" && document.getElementById('noofdatys').value !="")
  {
    if(document.getElementById('hiddendateformat').value == "dd/mm/yyyy")
    {
        fdate1=fdate.split("/")[1]+"/"+fdate.split("/")[0]+"/"+fdate.split("/")[2];
    }
    else if(document.getElementById('hiddendateformat').value == "yyyy/mm/dd")
    {
        fdate1=fdate.split("/")[1]+"/"+fdate.split("/")[2]+"/"+fdate.split("/")[0];
    }
    else
    {
       fdate1=fdate;
    }
    var d = new Date(fdate1);
    if(document.getElementById('noofdatys').value =="")
        noofdays=0;
    else
        noofdays=parseInt(document.getElementById('noofdatys').value);
    d.setDate(d.getDate()+noofdays);
    dd=d.getDate();
    mm=(d.getMonth()+1);
    if(dd.toString().length ==1)
    dd="0"+dd;
    if(mm.toString().length ==1)
    mm="0"+mm;
    yy=d.getFullYear();
    document.getElementById('txttodate1').value=dd+"/"+(mm)+"/"+yy;
    //alert((d.getMonth()+1)+"/"+d.getDate()+"/"+d.getYear());
  }
//return false;    
}
function notchar2(event)
{
//alert(event.which);
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
    if((event.which>=48 && event.which<=57)||(event.which==0)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which==13))
    {
    return true;
    }
    else
    {
    return false;
    }
}
else
{
    if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==13))
    {
    return true;
    }
    else
    {
    return false;
    }
}   
}