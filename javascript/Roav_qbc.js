
var browser=navigator.appName;
var modiflag=0;
var ds_exec;
var next;
var buttonvalue = "";
var records;

function tabval(event)
{
var key=event.keyCode?event.keyCode:event.which;


if(document.activeElement.id=="txtagnm")
{
if(key==13)
{
document.getElementById('txtisudt').focus();
return false;
}}

if(document.activeElement.id=="txtisudt")
{
if(key==13)
{
document.getElementById('txtfrmno').focus();
return false;
}}

if(document.activeElement.id=="txtfrmno")
{
if(key==13)
{
document.getElementById('txtlrono').focus();
return false;
}}

if(document.activeElement.id=="txtlrono")
{
if(key==13)
{
document.getElementById('ddlstatus').focus();
return false;
}}
if(document.activeElement.id=="ddlstatus")
{
if(key==13)
{
document.getElementById('btnSave').focus();
return false;
}}

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
        return false;
}


function first(event)
{
 document.getElementById('btnNew').disabled=false;
 document.getElementById('btnSave').disabled=true;
 document.getElementById('btnModify').disabled=true;
 document.getElementById('btnQuery').disabled=false;
 document.getElementById('btnCancel').disabled=false;
 document.getElementById('btnExecute').disabled=true;
 document.getElementById('btnfirst').disabled=true;
 document.getElementById('btnprevious').disabled=true;
 document.getElementById('btnnext').disabled=true;
 document.getElementById('btnlast').disabled=true;
 document.getElementById('btnDelete').disabled=true;
 document.getElementById('btnExit').disabled=false;
 
 document.getElementById('btnNew').focus()

document.getElementById('txtagnm').disabled=true;
document.getElementById('txtisudt').disabled=true;
document.getElementById('txtisuno').disabled=true;
document.getElementById('txtfrmno').disabled=true;
document.getElementById('txtlrono').disabled=true;
document.getElementById('ddlstatus').disabled=true;

document.getElementById('txtagnm').value="";
document.getElementById('txtisudt').value="";
document.getElementById('txtisuno').value="";
document.getElementById('txtfrmno').value="";
document.getElementById('txtlrono').value="";
document.getElementById('hdnagcod').value="";
document.getElementById('ddlstatus').value="A";
setButtonImages();
}

function enabled()
{
document.getElementById('txtagnm').disabled=false;
document.getElementById('txtisudt').disabled=false;
document.getElementById('txtisuno').disabled=true;
document.getElementById('txtfrmno').disabled=false;
document.getElementById('txtlrono').disabled=false;
document.getElementById('ddlstatus').disabled=false;
}


function agname(event)
{
var key=event.keyCode?event.keyCode:event.which;
if(key==113)
{
    if(document.activeElement.id=="txtagnm")
    {
        var divid = "divagn";
        var listboxid = "lstagn";

        var compcode =document.getElementById('hiddencompcode').value;
        var usrid = document.getElementById('hdnuserid').value;
        if (document.getElementById('drpagenexec').value == "A") {
            var agency = document.getElementById('txtagnm').value.toUpperCase();

            var ds = Ro_Qbc.bindagencyname(compcode, usrid, agency);

            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.style.width = "254px";
            objadscat.options[0] = new Option("-Select Agency Name-", "0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].code_subcode + "-" + ds.value.Tables[0].Rows[i].Agency_Name, ds.value.Tables[0].Rows[i].code_subcode);
                objadscat.options.length;
            }
            aTag = eval(document.getElementById('txtagnm'))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            var tot = document.getElementById('divagn').scrollLeft;
            var scrolltop = document.getElementById('divagn').scrollTop;
            document.getElementById(divid).style.left = document.getElementById('txtagnm').offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById('txtagnm').offsetTop + toppos - scrolltop + "px"; //"510px";
            //document.getElementById(activeid).style.backgroundColor="#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();
        }

        else {
            var executive = document.getElementById('txtagnm').value.toUpperCase();

            var ds = Ro_Qbc.bindexecname(compcode, usrid, executive);

            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.style.width = "254px";
            objadscat.options[0] = new Option("-Select Executive Name-", "0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Exe_no + "-" + ds.value.Tables[0].Rows[i].Exec_name, ds.value.Tables[0].Rows[i].Exe_no);
                objadscat.options.length;
            }
            aTag = eval(document.getElementById('txtagnm'))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            var tot = document.getElementById('divagn').scrollLeft;
            var scrolltop = document.getElementById('divagn').scrollTop;
            document.getElementById(divid).style.left = document.getElementById('txtagnm').offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById('txtagnm').offsetTop + toppos - scrolltop + "px"; //"510px";
            //document.getElementById(activeid).style.backgroundColor="#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();

        }
}
}
}


function agnamelst(event)
{
var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
     if(document.activeElement.id=="lstagn")
        {
       if($('lstagn').value=="0")
        {
     //   alert("Please select the publication");
        return false;
        }
        $("divagn").style.display="none";
        var page=$('lstagn').value;
     var agencycodeglo=page; 
       
         for(var k=0;k <= $("lstagn").length-1;k++)
                {
                   if($('lstagn').options[k].value==page)
                    {
                    if(browser!="Microsoft Internet Explorer")
                    var abc=$('lstagn').options[k].textContent;
                    else
                    var abc=$('lstagn').options[k].innerText;
                    $('txtagnm').value=agencycodeglo;
                    var splitpub = abc;
                    var str = splitpub.split("-");
                    abc=str[1];
                    abc1=str[0];
                 //   $('hdnsubedtn').value = abc1;
                    var abc2 = str[3];
                    $('txtagnm').value=abc;
                    $('hdnagcod').value=abc1;
                    //$('txtagencycode').value = abc1;
                    //$('txtagencysubcode').value = abc2;
                   // $('hdnpubcode').value=abc1;
               $('txtagnm').focus();
                    return false;           
                    }
                }
              }
     } 
     
     else if(key==27)
     {
     $("divagn").style.display="none";
     $('txtagnm').focus();
     }
}

function newclick()
{
enabled();
document.getElementById('btnSave').disabled=false;
 document.getElementById('btnCancel').disabled=false;
 document.getElementById('btnExit').disabled=false;
 document.getElementById('btnNew').disabled=true;
 document.getElementById('btnModify').disabled=true;
 document.getElementById('btnQuery').disabled=true;
 document.getElementById('btnExecute').disabled=true;
 document.getElementById('btnfirst').disabled=true;
 document.getElementById('btnprevious').disabled=true;
 document.getElementById('btnnext').disabled=true;
 document.getElementById('btnlast').disabled=true;
 document.getElementById('btnDelete').disabled=true;
 

 setButtonImages();
document.getElementById('txtagnm').focus();

return false;
}

function cancelclick()
{
first();
//document.getElementById('ddlstatus').value="A";
return false;
}

function abcSaveclick()
{

//document.getElementById('txtisudt').value="";
//document.getElementById('txtisuno').value="";
//document.getElementById('txtfrmno').value="";
//document.getElementById('txtlrono').value="";
//document.getElementById('hdnagcod').value="";
//document.getElementById('ddlstatus').value="0";

if($('txtagnm').value=="")
{
alert("Fill Agency name")
$('txtagnm').focus();
return false;
}
if($('hdnagcod').value=="")
{
alert("Select Agency name By F2")
$('txtagnm').focus();
return false;
}
if($('txtisudt').value=="")
{
alert("Fill Issue Date name")
$('txtisudt').focus();
return false;
}

if($('txtfrmno').value=="")
{
alert("Fill From No.")
$('txtfrmno').focus();
return false;
}


if($('txtlrono').value=="")
{
alert("Fill Till No.")
$('txtlrono').focus();
return false;
}
if (($('txtfrmno').value > $('txtlrono').value))
 {
     alert("Ro No is Greater than Till Ro No")
     $('txtlrono').focus();
    return false;
}
if(modiflag==1)
   {
       Modifyroqbc();
       return false;
   }
   else
   {
        var pcode = "'"+document.getElementById('hiddencompcode').value+"'";
        var namestr =document.getElementById('txtisudt').value;
        var dtfomat= "'"+document.getElementById('hiddendateformat').value+"'";
var ds = Ro_Qbc.Autogenerate_Code(namestr,pcode,dtfomat,callback_save)
 // var ds=callback_save("av")
          return false;
          
    }  


}


function callback_save(res)
{

ds=res.value;
if(modiflag==1)
   {
       ModifyArea();
       return false;
   }
  
   else
{
//return false;
var str=$('hdnsav').value;
var str1=str.split("$~$");

var tablename=str1[str1.length-2];

var action=str1[str1.length-1];
var finalaction=action.split("#");

var insert=finalaction[0];
var update=finalaction[1];
var del=finalaction[2];
var select=finalaction[3];

$('txtagnm').value=repalcesinglequote(trim($('txtagnm').value));

var userid = "'"+document.getElementById('hdnuserid').value+"'";
     var compcode = "'"+document.getElementById('hiddencompcode').value+"'";
      var currentdate="'"+document.getElementById('hidsysdate').value+"'";
     // alert($('hdncon').value)
      if($('hdncon').value=="orcl")
      {
      if(ds.Tables[0].Rows[0].ISSUE_NO==null)
    {
           //var issuno=$('txtisuno').value.substring(0,2)+"0";
           alert("ISSUE NOT GENERATE")
           return false;
    }
    else
    {
     var issuno=ds.Tables[0].Rows[0].ISSUE_NO;
//     issuno++;
//      issuno=$('txtisuno').value.substring(0,2)+ areacode++;
    }
    $('txtisuno').value=ds.Tables[0].Rows[0].ISSUE_NO;
    var csisno="'"+issuno.toUpperCase()+"'";
    }
//$('txtisuno').value=ds.Tables[0].Rows[0].ISSUE_NO;
//var issuno=$('txtisuno').value.substring(0,2)+"0";
  
      
    // var csisno="3";   
      var agncod = "'"+trim($('hdnagcod').value)+"'";
         agncod=agncod.toUpperCase();
   
     // var csisno=issuno.toUpperCase();
      var typ="A";
       var issdt= "'"+trim($('txtisudt').value)+"'";
         issdt=issdt.toUpperCase();
     
     var ronofrm= "'"+trim($('txtfrmno').value)+"'";
         ronofrm=ronofrm.toUpperCase();
  //    var ronofrm=$('txtfrmno').value;
   var ronotll= "'"+trim($('txtlrono').value)+"'";
         ronotll=ronotll.toUpperCase();
   //   var ronotll=$('txtlrono').value;
     var sts= "'"+trim($('ddlstatus').value)+"'";
         sts=sts.toUpperCase();
    //  var sts=$('ddlstatus').value;

         var bason = "'" + trim($('drpagenexec').value) + "'";
         basedon = sts.toUpperCase();
      
 if($('hdncon').value!="sql") 
 {    
     var finalval = compcode + "$~$" + "'" + typ + "'" + "$~$" + agncod + "$~$" + issdt + "$~$" + csisno + "$~$" + ronofrm + "$~$" + ronotll + "$~$" + sts + "$~$" + userid + "$~$" + currentdate + "$~$" + bason;
 var fields=document.getElementById('hdnsav').value.replace("$~$"+tablename,"")
fields=fields.replace("$~$"+action,"")
}
else
{
var currentdate="'"+document.getElementById('hidsysdatesql').value+"'";
var finalval = compcode + "$~$" + "'" + typ + "'" + "$~$" + agncod + "$~$" + issdt + "$~$" + ronofrm + "$~$" + ronotll + "$~$" + sts  + "$~$" + userid + "$~$" + currentdate + "$~$" + bason;
var fields=document.getElementById('hdnsavsql').value.replace("$~$"+tablename,"")

fields=fields.replace("$~$"+action,"")
//alert(fields)
}
var dateformat = trim($('hiddendateformat').value);
var result=Ro_Qbc.Savename(fields,finalval,tablename,insert,dateformat,"","")
if(result.value=="true")
     {
    // alert("client name saved at" +csisno);
      alert("Saved Successfully ");
     }
first();
}}




function Modify_Records() {
    modiflag = 1;

    $('btnQuery').disabled = true;
    $('btnSave').disabled = false;
    $('btnfirst').disabled = true;
    $('btnlast').disabled = true;
    $('btnModify').disabled = true;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = true;
    $('btnDelete').disabled = true;
    setButtonImages();
//    $('pagingtab').style.display = 'none';
//    $('nextpage').style.display = 'none';
//    $('next1').style.display = 'none';
   // $('Td14').style.display = 'none';
//    $('view19').style.display = 'none';
//    $('Button4').disabled = true;




  document.getElementById('txtagnm').disabled=false;
document.getElementById('txtisudt').disabled=false;
document.getElementById('txtisuno').disabled=true;
document.getElementById('txtfrmno').disabled=false;
document.getElementById('txtlrono').disabled=false;
document.getElementById('ddlstatus').disabled=false;

 //   modifyduplicacydesc = $('txtunitcode').value;

//    updatemaingrcode = $('txtchannel_name').value
 //   updateprmgrcode = $('txtchannel_code').value

    $('btnSave').focus();
    //new_button("Modify");
    return false;
}

function Modifyroqbc() {
    modiflag = 0;
  //  alert("abc")
    var str = $('hdnsav2').value;
    var str1 = str.split("$~$");
    var tablename = str1[str1.length - 2];
    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];

   
    document.getElementById('btnSave').focus();

    var str5 = $('whercol').value;
    var str6 = str5.split("$~$");
    var modcolname = "";
    var modtblname = str6[str6.length - 1];




    modcolname = $('whercol').value;
    modcolname = modcolname + "$~$"

     
      
     



//     var clientname = "'"+trim($('txtclientName').value)+"'";
//     var caseclientname=clientname.toUpperCase();
     
     

    var userid = "'"+document.getElementById('hdnuserid').value+"'";
     var compcode = "'"+document.getElementById('hiddencompcode').value+"'";
     if($('hdncon').value=="orcl")
      {
      var currentdate="'"+document.getElementById('hidsysdate').value+"'";
    }
    else
    {
    var currentdate="'"+document.getElementById('hidsysdatesql').value+"'";
    }
        var agncod = "'"+trim($('hdnagcod').value)+"'";
         agncod=agncod.toUpperCase();
   // var agncod=$('hdnagcod').value;
   
      var csisno="'"+$('txtisuno').value+"'";
      var typ="A";
       var issdt= "'"+trim($('txtisudt').value)+"'";
         issdt=issdt.toUpperCase();
     // var issdt=$('txtisudt').value;
     var ronofrm= "'"+trim($('txtfrmno').value)+"'";
         ronofrm=ronofrm.toUpperCase();
  //    var ronofrm=$('txtfrmno').value;
   var ronotll= "'"+trim($('txtlrono').value)+"'";
         ronotll=ronotll.toUpperCase();
   //   var ronotll=$('txtlrono').value;
     var sts= "'"+trim($('ddlstatus').value)+"'";
     sts = sts.toUpperCase();
     var bason = "'" + trim($('drpagenexec').value) + "'";
     basedon = sts.toUpperCase();
    //  var sts=$('ddlstatus').value;
      
     var finalval = compcode + "$~$" + "'" + typ + "'" + "$~$" + agncod + "$~$" + issdt + "$~$" + csisno + "$~$" + ronofrm + "$~$" + ronotll + "$~$" + sts + "$~$" + userid + "$~$" + currentdate + "$~$" + basedon+"$~$";


var dateformat = trim($('hiddendateformat').value);

    

    var fi = document.getElementById('hdnsav2').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    fi = fi + "$~$";


     if($('hdncon').value=="sql") 
    var res = Ro_Qbc.ro_modify(document.getElementById('hiddencompcode').value,typ,$('hdnagcod').value,$('txtisudt').value,dateformat,$('txtisuno').value,$('txtfrmno').value,$('txtlrono').value,$('ddlstatus').value,document.getElementById('hdnuserid').value,document.getElementById('hidsysdatesql').value)
else
    var res = Ro_Qbc.tal_modify(fi, finalval, tablename, update, modcolname, dateformat, "", "")
   

    var result = res.value

    if (result != "true") {
        if (result.split("(")[0] == "ORA-00001: unique constraint ") {
            alert('This combination is allready exsist please enter some other combination.');
            return false;
        }
        else {
            alert(result)
            return false;
        }

    }

    alert("Data Updated Successfully ")
    modiflag = "";
      

    $('btnModify').disabled = false;
    $('btnQuery').disabled = false;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnDelete').disabled = false;
    $('btnSave').disabled = true;
    $('btnModify').focus();
    setButtonImages();


    

   first();


}


function onquery()
{
//modify="0";
//newcode="0";

//document.getElementById('txtgpcode').value="";
//document.getElementById('txtgpname').value="";

//document.getElementById('txtgpcode').disabled=false;
//document.getElementById('txtgpname').disabled=false;
enabled();
 document.getElementById('btnExecute').disabled=false;
 document.getElementById('btnCancel').disabled=false;
 document.getElementById('btnExit').disabled=false;
 document.getElementById('btnNew').disabled=true;
 document.getElementById('btnSave').disabled=true;
 document.getElementById('btnModify').disabled=true;
 document.getElementById('btnQuery').disabled=true;
 document.getElementById('btnfirst').disabled=true;
 document.getElementById('btnprevious').disabled=true;
 document.getElementById('btnnext').disabled=true;
 document.getElementById('btnlast').disabled=true;
 document.getElementById('btnDelete').disabled=true;
 setButtonImages();
 document.getElementById('txtisuno').disabled=false;
document.getElementById('btnExecute').focus();

return false;
}



function onexecute()
{
//modify="0";
//newcode="0";
$('btnNew').disabled = true;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnSave').disabled = true;
    $('btnExecute').disabled = true;
    $('btnfirst').disabled = true;
    $('btnlast').disabled = false;
    $('btnModify').disabled = false;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = false;
    $('btnDelete').disabled = false;

    setButtonImages();
   
   document.getElementById('txtagnm').disabled=true;
document.getElementById('txtisudt').disabled=true;
document.getElementById('txtisuno').disabled=true;
document.getElementById('txtfrmno').disabled=true;
document.getElementById('txtlrono').disabled=true;
document.getElementById('ddlstatus').disabled=true;
   
    $('btnModify').focus();
    
    var str=$('hdnexecut').value;
var str1=str.split("$~$");

var tablename=str1[str1.length-2];


var action=str1[str1.length-1];
var finalaction=action.split("#");

var cols = document.getElementById('hdnexecut').value.replace("$~$" + tablename, "")
    cols = cols.replace("$~$" + action, "")


var insert=finalaction[0];
var update=finalaction[1];
var del=finalaction[2];
var select=finalaction[3];


 var userid = "'"+document.getElementById('hdnuserid').value+"'";
     var compcode = "'"+document.getElementById('hiddencompcode').value+"'";
      var currentdate="'"+document.getElementById('hidsysdate').value+"'";


var issuno="'"+document.getElementById('txtisuno').value+"'";;
    
        var agncod = "'"+trim($('hdnagcod').value)+"'";
         agncod=agncod.toUpperCase();
   // var agncod=$('hdnagcod').value;
      var csisno=issuno.toUpperCase();
      var typ="A";
       var issdt= "'"+trim($('txtisudt').value)+"'";
         issdt=issdt.toUpperCase();
     // var issdt=$('txtisudt').value;
     var ronofrm= "'"+trim($('txtfrmno').value)+"'";
         ronofrm=ronofrm.toUpperCase();
  //    var ronofrm=$('txtfrmno').value;
   var ronotll= "'"+trim($('txtlrono').value)+"'";
         ronotll=ronotll.toUpperCase();
   //   var ronotll=$('txtlrono').value;
     var sts= "'"+trim($('ddlstatus').value)+"'";
         sts=sts.toUpperCase();
    //  var sts=$('ddlstatus').value;

         var bason = "'" + trim($('drpagenexec').value) + "'";
         basedon = sts.toUpperCase();
      
         var finalval = compcode+"$~$"+"'"+typ+"'"+"$~$"+agncod+"$~$"+issdt+"$~$"+csisno+"$~$"+ronofrm+"$~$"+ronotll+"$~$"+sts+"$~$"+basedon;


var dateformat = trim($('hiddendateformat').value);
   
     var extra1 = "''";
    
     
     var exect = Ro_Qbc.clie_execute(tablename, cols, finalval, select, dateformat, extra1, "")
    
    if (exect.error != null) { 
            alert(exect.error)
            return false;
        }
        else {
            var result = exect.value
            callback_exec(exect)
            return false;
        }
     
    


}


function callback_exec(res) { 
    next = 0;
    
    ds_exec = res.value;
    //record_show = rec_page_val
   // record_show1 = 1
    if (ds_exec == null) {
        alert("Your search can not produce any result.")
 
    first();
        return false;
    }

//var res = Ro_Qbc.Agency_get($('hiddencompcode').value,ds_exec.Tables[0].Rows[0].CODE_SUBCODE);
 //   if (next != -1) {
        if (ds_exec.Tables[0].Rows.length == 1) {
      
      //  document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
document.getElementById('txtisudt').value=CHKDATE(ds_exec.Tables[0].Rows[0].ISSUE_DT);
document.getElementById('txtisuno').value=ds_exec.Tables[0].Rows[0].ISSUE_NO;
document.getElementById('txtfrmno').value=ds_exec.Tables[0].Rows[0].RONO_FROM;
document.getElementById('txtlrono').value=ds_exec.Tables[0].Rows[0].RONO_TILL;
document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[0].STATUS;
document.getElementById('drpagenexec').value = ds_exec.Tables[0].Rows[0].BASEDON;

$('hdnagcod').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
            //var res = agencyget($('hiddencompcode').value,ds_exec.Tables[0].Rows[0].CODE_SUBCODE)
if (ds_exec.Tables[0].Rows[0].BASEDON == 'A' || ds_exec.Tables[0].Rows[0].BASEDON == null) {
    document.getElementById('txtagnm').value = agencyget($('hiddencompcode').value, ds_exec.Tables[0].Rows[0].CODE_SUBCODE);
}
else {
    document.getElementById('txtagnm').value = executiveget($('hiddencompcode').value, ds_exec.Tables[0].Rows[0].CODE_SUBCODE);
}

//               if (ds_exec.Tables[0].Rows[next].City_Code == null)

//                $('txtcity').value = "";
//            else
//            {
//                var pcityname = get_cityname(ds_exec.Tables[0].Rows[next].Comp_Code,ds_exec.Tables[0].Rows[next].City_Code)
//                $('txtcity').value = repalcestr2quote(pcityname)
//           
//           $('hidnctycode').value= repalcestr2quote(ds_exec.Tables[0].Rows[next].City_Code)
//           }

            
            document.getElementById('btnlast').disabled = true;


            document.getElementById('btnnext').disabled = true;
            setButtonImages();

        }
        else if (ds_exec.Tables[0].Rows.length > 0) {

           //  document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
            if (ds_exec.Tables[0].Rows[0].BASEDON == 'A' || ds_exec.Tables[0].Rows[0].BASEDON ==null) {
                document.getElementById('txtagnm').value = agencyget($('hiddencompcode').value, ds_exec.Tables[0].Rows[0].CODE_SUBCODE);
            }
            else {
                document.getElementById('txtagnm').value = executiveget($('hiddencompcode').value, ds_exec.Tables[0].Rows[0].CODE_SUBCODE);
            }
document.getElementById('txtisudt').value=CHKDATE(ds_exec.Tables[0].Rows[next].ISSUE_DT);
document.getElementById('txtisuno').value=ds_exec.Tables[0].Rows[0].ISSUE_NO;
document.getElementById('txtfrmno').value=ds_exec.Tables[0].Rows[0].RONO_FROM;
document.getElementById('txtlrono').value=ds_exec.Tables[0].Rows[0].RONO_TILL;
document.getElementById('ddlstatus').value = ds_exec.Tables[0].Rows[0].STATUS;
document.getElementById('drpagenexec').value = ds_exec.Tables[0].Rows[0].BASEDON;
$('hdnagcod').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
        }
        else {
            alert("Your search can not produce any result.")
         //   flg_req = "no"
         //   ClearAll()
         first();
            return false;
        }
        document.getElementById('txtagnm').disabled=true;
document.getElementById('txtisudt').disabled=true;
document.getElementById('txtisuno').disabled=true;
document.getElementById('txtfrmno').disabled=true;
document.getElementById('txtlrono').disabled=true;
document.getElementById('ddlstatus').disabled = true;
document.getElementById('drpagenexec').disabled = false;
        
      
        return false;

}



function Find_Firstrecord() {


    buttonvalue = "";
    buttonvalue = "firstrecords";


     next = 0;


         //   document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[next].CODE_SUBCODE;
     if (ds_exec.Tables[0].Rows[next].BASEDON == 'A' || ds_exec.Tables[0].Rows[next].BASEDON == null) {
         document.getElementById('txtagnm').value = agencyget($('hiddencompcode').value, ds_exec.Tables[0].Rows[next].CODE_SUBCODE);
     }
     else {
         document.getElementById('txtagnm').value = executiveget($('hiddencompcode').value, ds_exec.Tables[0].Rows[next].CODE_SUBCODE);
     }
document.getElementById('txtisudt').value=CHKDATE(ds_exec.Tables[0].Rows[next].ISSUE_DT);
document.getElementById('txtisuno').value=ds_exec.Tables[0].Rows[next].ISSUE_NO;
document.getElementById('txtfrmno').value=ds_exec.Tables[0].Rows[next].RONO_FROM;
document.getElementById('txtlrono').value=ds_exec.Tables[0].Rows[next].RONO_TILL;
document.getElementById('ddlstatus').value = ds_exec.Tables[0].Rows[next].STATUS;
document.getElementById('drpagenexec').value = ds_exec.Tables[0].Rows[next].BASEDON;

$('hdnagcod').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
//             if (ds_exec.Tables[0].Rows[next].Zone_code == null)

//                $('txtzone').value = "";
//            else
//              {
//              var pzone = get_zone(ds_exec.Tables[0].Rows[next].Comp_Code,ds_exec.Tables[0].Rows[next].Zone_code)
//                $('txtzone').value = repalcestr2quote(pzone)
             // }
               
            
        

    $('btnfirst').disabled = true;
    $('btnprevious').disabled = true;
    if(ds_exec.Tables[next].Rows.length > 0)
    {
    $('btnlast').disabled = false;
   
    $('btnnext').disabled = false;
    }
    else
    {
    $('btnlast').disabled = true;
   
    $('btnnext').disabled = true;
    }
    $('btnNew').disabled = true;
    setButtonImages();
    $('btnnext').focus();
    return false;
}


function Find_Lastrecord() {


    buttonvalue = "lastrecords";
    records = ds_exec.Tables[0].Rows.length;

    next = records - 1;
    records = records - 1;
    if (next >= records && records != -1) {
        
 //document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[next].CODE_SUBCODE;
        if (ds_exec.Tables[0].Rows[next].BASEDON == 'A' || ds_exec.Tables[0].Rows[next].BASEDON == null) {
            document.getElementById('txtagnm').value = agencyget($('hiddencompcode').value, ds_exec.Tables[0].Rows[next].CODE_SUBCODE);
        }
        else {
            document.getElementById('txtagnm').value = executiveget($('hiddencompcode').value, ds_exec.Tables[0].Rows[next].CODE_SUBCODE);
        }
document.getElementById('txtisudt').value=CHKDATE(ds_exec.Tables[0].Rows[next].ISSUE_DT);
document.getElementById('txtisuno').value=ds_exec.Tables[0].Rows[next].ISSUE_NO;
document.getElementById('txtfrmno').value=ds_exec.Tables[0].Rows[next].RONO_FROM;
document.getElementById('txtlrono').value=ds_exec.Tables[0].Rows[next].RONO_TILL;
document.getElementById('ddlstatus').value = ds_exec.Tables[0].Rows[next].STATUS;
document.getElementById('drpagenexec').value = ds_exec.Tables[0].Rows[next].BASEDON;
$('hdnagcod').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
            


        $('btnfirst').disabled = false;
        $('btnlast').disabled = true;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnNew').disabled = true;
        setButtonImages();
        $('btnprevious').focus();
        return false;
    }
    return false;


}


function Find_PreRecord() {
    
 
 
  
    next--;

    var record = ds_exec.Tables[0].Rows.length;
    if (next > record) {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('Button4').disabled = false;
        setButtonImages();
       // $('Td14').style.display = 'none';
 //       $('view19').style.display = 'none';
 //       $('pagingtab').style.display = 'none';
//        $('nextpage').style.display = 'none';
//        $('next1').style.display = 'none';
        return false;
    }

    if (next != -1 && next >= 0) {
        if (ds_exec.Tables[0].Rows.length != next) {

//           document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[next].CODE_SUBCODE;
            if (ds_exec.Tables[0].Rows[next].BASEDON == 'A' || ds_exec.Tables[0].Rows[next].BASEDON == null) {
                document.getElementById('txtagnm').value = agencyget($('hiddencompcode').value, ds_exec.Tables[0].Rows[next].CODE_SUBCODE);
            }
            else {
                document.getElementById('txtagnm').value = executiveget($('hiddencompcode').value, ds_exec.Tables[0].Rows[next].CODE_SUBCODE);
            }
document.getElementById('txtisudt').value=CHKDATE(ds_exec.Tables[0].Rows[next].ISSUE_DT);
document.getElementById('txtisuno').value=ds_exec.Tables[0].Rows[next].ISSUE_NO;
document.getElementById('txtfrmno').value=ds_exec.Tables[0].Rows[next].RONO_FROM;
document.getElementById('txtlrono').value=ds_exec.Tables[0].Rows[next].RONO_TILL;
document.getElementById('ddlstatus').value = ds_exec.Tables[0].Rows[next].STATUS;
document.getElementById('drpagenexec').value = ds_exec.Tables[0].Rows[next].BASEDON;
$('hdnagcod').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;
            
            setButtonImages();

        }
    }
    if (next == 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = false;
        $('btnnext').focus();
        setButtonImages();

    }


    return false;

}



function Find_NextRecord() {


//  delete_record = 0;
 //   record_show = rec_page_val;
  //  record_show1 = 1;
//    document.getElementById('Button4').disabled = true;
 next++;
    if (next > 0) {
        $('btnfirst').disabled = false;
        $('btnlast').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = false;
        setButtonImages();
    }

  //  next++;
    var records = ds_exec.Tables[0].Rows.length;
    if (next <= records && next >= 0) {
        if (ds_exec.Tables[0].Rows.length != next && next != -1) {
//            document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[next].CODE_SUBCODE;
            if (ds_exec.Tables[0].Rows[next].BASEDON == 'A' || ds_exec.Tables[0].Rows[next].BASEDON == null) {
                document.getElementById('txtagnm').value = agencyget($('hiddencompcode').value, ds_exec.Tables[0].Rows[next].CODE_SUBCODE);
            }
            else {
                document.getElementById('txtagnm').value = executiveget($('hiddencompcode').value, ds_exec.Tables[0].Rows[next].CODE_SUBCODE);
            }
document.getElementById('txtisudt').value=CHKDATE(ds_exec.Tables[0].Rows[next].ISSUE_DT);
document.getElementById('txtisuno').value=ds_exec.Tables[0].Rows[next].ISSUE_NO;
document.getElementById('txtfrmno').value=ds_exec.Tables[0].Rows[next].RONO_FROM;
document.getElementById('txtlrono').value=ds_exec.Tables[0].Rows[next].RONO_TILL;
document.getElementById('ddlstatus').value = ds_exec.Tables[0].Rows[next].STATUS;
document.getElementById('drpagenexec').value = ds_exec.Tables[0].Rows[next].BASEDON;
$('hdnagcod').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
             setButtonImages();
           // return false;
        }
        else {
            $('btnfirst').disabled = false;
            $('btnprevious').disabled = false;
            $('btnnext').disabled = true;
            $('btnlast').disabled = true;
            $('btnNew').disabled = true;
            setButtonImages();
            $('btnprevious').focus();
            return false;

        }

    }
    else {
        $('btnfirst').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnlast').disabled = true;
        $('btnNew').disabled = true;
        setButtonImages();
        return false;
    }
    if (next == records - 1) {
        $('btnfirst').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnlast').disabled = true;
        $('btnNew').disabled = true;
        setButtonImages();
        return false;
    }

    return false;

}

function Delete_Record() {

    var str = $('hdnsav').value;
    var str1 = str.split("$~$");
    var tablename = str1[str1.length - 2];
    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];


 var str5 = $('whercol').value;
    var str6 = str5.split("$~$");
    var modcolname = "";
    var modtblname = str6[str6.length - 1];



     modcolname = $('whercol').value;
    modcolname = modcolname + "$~$";

//     document.getElementById('hdnregion').value="";
//      document.getElementById('hdntaluka').value="";
//      document.getElementById('hdnzone').value="";
      
$('txtagnm').value=repalcesinglequote(trim($('txtagnm').value));

var userid = "'"+document.getElementById('hdnuserid').value+"'";
     var compcode = "'"+document.getElementById('hiddencompcode').value+"'";
      var currentdate="'"+document.getElementById('hidsysdate').value+"'";
      
//      if(ds.Tables[1].Rows[0].cust_code==null)
//    {
//           var issuno=$('txtisuno').value.substring(0,2)+"0";
//    }
//    else
//    {
//     var issuno=ds.Tables[1].Rows[0].cust_code;
//     issuno++;
//      issuno=$('txtisuno').value.substring(0,2)+ areacode++;
//    }

var issuno=$('txtisuno').value;
  
      var csisno="'"+issuno.toUpperCase()+"'";
         
      var agncod = "'"+trim($('hdnagcod').value)+"'";
         agncod=agncod.toUpperCase();
   // var agncod=$('hdnagcod').value;
     // var csisno=issuno.toUpperCase();
      var typ="I";
       var issdt= "'"+trim($('txtisudt').value)+"'";
         issdt=issdt.toUpperCase();
     // var issdt=$('txtisudt').value;
     var ronofrm= "'"+trim($('txtfrmno').value)+"'";
         ronofrm=ronofrm.toUpperCase();
  //    var ronofrm=$('txtfrmno').value;
   var ronotll= "'"+trim($('txtlrono').value)+"'";
         ronotll=ronotll.toUpperCase();
   //   var ronotll=$('txtlrono').value;
     var sts= "'"+trim($('ddlstatus').value)+"'";
         sts=sts.toUpperCase();
    //  var sts=$('ddlstatus').value;
      
         var bason = "'" + trim($('drpagenexec').value) + "'";
         basedon = sts.toUpperCase();
    var finalval = compcode + "$~$" + csisno + "$~$";
    //var finalval = casesecsubgrUnitCode + "$~$" + casemaingrcode + "$~$" + talcode + "$~$" + casesecsubgrchanel + "$~$" + casesecsubgrname + "$~$" + "'" + "" + "'" + "$~$" + casesecsubgrloc + "$~$" + casesecsubgrtypecode + "$~$";
    // var finalval = casesecsubgrUnitCode + "$~$" + casemaingrcode + "$~$" + talcode + "$~$" + casesecsubgrchanel + "$~$" + casesecsubgrname + "$~$" + casesecsubgrloc + "$~$" + casesecsubgrtypecode + "$~$";

    var fi = document.getElementById('whercol').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    fi = fi + "$~$";


    

    
   
  var    boolReturn = confirm("Are You Sure You Want To Delete This Data??");
    if (boolReturn == 1) {
        var res = Ro_Qbc.tal_delete(tablename, fi, finalval, del, "", "", "");
        var result = res.value
        if (result != "true") {
            alert("Data Do Not Delete")
            return false;
        }
        else {
            alert("Data Deleted Successfully")
           first();
            return false;
        }
         }

         first();
    return false;
}

function agencyget(compcod,codesbcod)
{
//alert("avi")
 var ds = Ro_Qbc.Agency_get(compcod,codesbcod);
 //alert(ds.value.Tables[0].Rows[0].Agency_Name)
 if($('hdncon').value=="sql") 
 {return ds.value.Tables[1].Rows[0].Agency_Name;
 }
 else
 {
return ds.value.Tables[0].Rows[0].AGENCY_NAME;
}
}

function executiveget(compcod, codesbcod) {
    //alert("avi")
    var ds = Ro_Qbc.executive_get(compcod, codesbcod);
    //alert(ds.value.Tables[0].Rows[0].Agency_Name)
    if ($('hdncon').value == "sql") {
        return ds.value.Tables[1].Rows[0].EXEC_NAME;
    }
    else {
        return ds.value.Tables[0].Rows[0].EXEC_NAME;
    }
}





function repalcesinglequote(val) {
    if (val.indexOf("'") >= 0) {
        while (val.indexOf("'") >= 0) {
            val = val.replace("'", "^");
        }
    }
    return val;
}
function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}


function onexit()
{
if(confirm('Do You Want To Skip This Page?'))
{
window.close();
return false;
}
return false;
}

function CHKDATE(userdate)
{
var mycondate=""
   
if(userdate==null || userdate=="")
{
    mycondate=""
    return mycondate
}
else
{
   
    var myDate=new Date(userdate);
    var dd = myDate.getDate();
     var d;
     if(dd<=9 && dd>=1)
     {
     d='0'+dd;
     dd=d;
     }
     else
     {
     
     }
    var mm = myDate.getMonth()+1;
    var m;
    if(mm<=9 && mm>=1)
    {
    m='0'+mm;
    mm=m;
    }
    else
    {
    
    }
    var year = myDate.getFullYear();
    
    if($('hiddendateformat').value=="mm/dd/yyyy")
        {
        mycondate= mm +"/"+ dd +"/"+ year;
        }
        else if ($('hiddendateformat').value=="dd/mm/yyyy")
        {
        mycondate=dd + "/" + mm + "/" + year;
        }
        else
        {
        mycondate=year+"/"+mm+"/"+dd;
        }
   
   // mycondate=myDate.getDate()+"/"+myDate.getMonth()+"/"+myDate.getFullYear();
   
    $('txtisudt').value=mycondate; 
       
       
    return mycondate;
   
}
}

//function onlynum(event) {
//   
//    var browser = navigator.appName;
//    if (browser != "Microsoft Internet Explorer") {
//        if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 0)) {
//            return true;
//        }
//        else {
//            return false;
//        }
//    }
//    else {
//        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) {
//            return true;
//        }
//        else {
//            return false;
//        }
//    }
//}


//function onlynum(event) {
//    var browser = navigator.appName;

//    if (browser != "Microsoft Internet Explorer") {
//        if ((event.which >= 46 && event.which <= 57) || (event.which == 32) || (event.keyCode == 8) || (event.which == 127)) {
//            return true;
//        }


//        else {
//          //   alert("Please enter only numeric values");
//            return false;
//        }
//    }
//    else {
//        if ((event.keyCode >= 46 && event.keyCode <= 57) || (event.keyCode == 32 || (event.keyCode == 8) || (event.which == 127)))
//        {
//            return true;

//        }


//        else {
//          //   alert("Please enter only numeric values");
//            return false;
//        }
//    }
//    return false;
//}





function chnglabel() {

    var htmlval = "";
    if (document.getElementById('drpagenexec').value == "E") {
        htmlval = "Executive" + "<span style='color:red'> [F2]*</span>";
    }
    else {
        htmlval = "Agency" + "<span style='color:red'> [F2]*</span>";
    }
    document.getElementById('lblagnm').innerHTML = htmlval;
    document.getElementById('txtagnm').value = "";
    basedcode = "";

}