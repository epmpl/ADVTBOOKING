
var browser=navigator.appName;
var ds18="";
var datalength="";

function bindcategory_package()
{
binduomname();
bindcategory();
bindpackage();
}


function binduomname()
{
    var comp_code=document.getElementById('hiddencompcode').value;
    var resuom=RateExpiry.binduom(comp_code,document.getElementById('ddladtyp').value);
    binduom_NEW(resuom);
    
}
function binduom_NEW(response)
{
    var ds=response.value;
  var  agcatby = document.getElementById("ddluom");
    agcatby.options.length = 1; 
    //    agcatby.options[0]=new Option("--Select Category--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var j=1;
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
        if(document.getElementById("hdndtabase").value=="orcl")
            agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Uom_Name,ds.Tables[0].Rows[i].Uom_Code); 
            else
            agcatby.options[j] = new Option(ds.Tables[0].Rows[i].UOM_Name,ds.Tables[0].Rows[i].UOM_Code); 
           j++;
           
        }
    }
//document.getElementById("drprate").value = "0";
}

function bindcategory()
{
 var comp_code=document.getElementById('hiddencompcode').value;
RateExpiry.getcategory(comp_code,document.getElementById('ddladtyp').value,bindcategory_NEW);
}
function bindcategory_NEW(response)
{
    //alert(response.value);
    var ds=response.value;
    agcatby = document.getElementById("ddlcategory");
 agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Category--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    var j=1;
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code,ds.Tables[0].Rows[i].Adv_Cat_Code);   
                             //new Option(ds_AccName.Tables[0].Rows[i].Exec_name+"("+ds_AccName.Tables[0].Rows[i].Exe_no+")",ds_AccName.Tables[0].Rows[i].Exe_no);        
        
       j++;
       
    }
}
//return false;
document.getElementById("ddlcategory").value = "0";
}

function bindpackage()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('ddladtyp').value;
RateExpiry.bindpackagenew(adtype1,compcode,call_bindpackage);
//billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
}

function call_bindpackage(response)
{
ds= response.value;
    var brand=document.getElementById('ddlpkg');
    brand.options.length=0;
    brand.options[0]=new Option("--Select Package--","0");
    document.getElementById("ddlpkg").options.length = 1;
   
if(ds.Tables[0].Rows.length!=null)
{

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name,ds.Tables[0].Rows[i].Combin_Code);
                brand.options.length;   
             }
 }        
 }
       return false;
}


function fetch(ab)
{
var id=ab.srcElement.id;
data = document.getElementById(id).value;

}


function datafrGrid()
{
var adtyp=document.getElementById('ddladtyp').value;
var rtcod=document.getElementById('ddlrtcod').value;
var categry=document.getElementById('ddlcategory').value;
var color=document.getElementById('ddlcolor').value;
var uom=document.getElementById('ddluom').value;
var frdate=document.getElementById('txtvldfrm').value;
var todate=document.getElementById('txtvldto').value;
var packge=document.getElementById('ddlpkg').value;
var compcod=document.getElementById('hiddencompcode').value;
var dateformat=document.getElementById('hiddendateformat').value;
var extra1="";
var extra2="";

 if(frdate=="")
    {
    alert("Please Enter From date")
    document.getElementById('txtvldfrm').focus();
    return false;
    }
     if(todate=="")
    {
    alert("Please Enter To date")
    document.getElementById('todate').focus();
    return false;
    }

    var solo ="";

    if (document.getElementById('rbpackage').checked == true) {
        solo = "P"
    }
    else {
        solo = "S";
    }

var edition = "";
if (document.getElementById('rdall').checked==true ) {
    edition = "A";
}
else if (document.getElementById('rdmain').checked==true ) {
    edition = "M";
}
else if (document.getElementById('rdsubedition').checked==true ) {
    edition = "E";
}
else if (document.getElementById('rdsupplement').checked==true ) {
    edition = "S";
}
else
    edition = "";


 RateExpiry.getdatagrid(compcod, adtyp, rtcod, categry, color, uom, frdate, todate, packge, extra1, extra2, dateformat, solo, edition, getgrid);

 return false;
}



function getgrid(res)
{
 if(res.value!=undefined)
    {
    
    ds18=res.value;
 
    }
    else
    {
    ds18=res;
    }
 var row_count=ds18.Tables[0].Rows.length;
var hdsview="";
var j=1
var i=0
//alert(ds18.Tables[0].Rows.length)
 if(ds18!=null && ds18.Tables[0].Rows.length > 0)
    {  
    
//      document.getElementById('ddladtyp').disabled=true;
//document.getElementById('ddlrtcod').disabled=true;
//document.getElementById('ddlcategory').disabled=true;
//document.getElementById('ddlcolor').disabled=true;
//document.getElementById('ddluom').disabled=true;
//document.getElementById('txtvldfrm').disabled=true;
//document.getElementById('txtvldto').disabled=true;
//document.getElementById('ddlpkg').disabled=true; 
//document.getElementById('btnsbmit').disabled=true; 
    
     document.getElementById('txtexpdt').disabled=false;
     document.getElementById('btnsave').disabled=false;
      document.getElementById('txtexpdt').focus();                     
var finaldata="";
 var datalength="";
 //document.getElementById('hdnrateunitid').value=fndnull(ds18.Tables[0].Rows[i].rateuniqueid);
if (ds18.Tables[0].Rows.length > 0) {
            datalength = ds18.Tables[0].Rows.length;


            finaldata = "<table border=1 width=100%>"
            finaldata +="<tr>";
        //    finaldata += "<tr><td width='2%'bgcolor=#7DAAE3  style='font-size:12px;font-weight:bold;text-align:left;border:1px solid #7DAAE3;'><input id=Chk_all_box type=checkbox onclick=chkall_123('no') ></td>";
            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Rate Code</td>";
            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Category</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Color</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Uom</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Premium</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>S/L/W From</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>S/L/W To</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>From Insert</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>To Insert</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Weekday Rate</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Extra Rate</td>";
            finaldata += "<td width='2%'bgcolor=#7DAAE3  style='font-size:12px;font-weight:bold;text-align:left;border:1px solid #7DAAE3;'><input id=Chk_all_box type=checkbox onclick=chkall_123('no') ></td></tr>";
//            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Insert ID</td></tr>";
          
            //finaldata+="</table>";

            for (i = 0; i < datalength; i++) {

            
              // finaldata += "<tr><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Rate_Mast_Code) + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Adv_Cat_Code) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Color) + "</td><td width='6%' class='clickFieldinGrid'  onclick='javascript:return excutedeal(this.id);' id='dealcode_" + i + "'  align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].CONTRACT) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].BILL_NO) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].SIZE_BOOK) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].BILL_RATE) + "</td><td width='9%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'> <input type='text' class='txtboxforgridmim1' onkeydown='javascript:return chknum(event);'   value='" + fndnull(data1.Tables[0].Rows[i].DEAL) + "' id='Provisonalrate_" + i + "' ></td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'> <input type='text' class='txtboxforgridmim'    value='" + fndnull(data1.Tables[0].Rows[i].REMARKS) + "' id='Remarks_" + i + "' ></td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].CREDIT_NOTE_RATE) + "</td><td><input type='CheckBox' width='2%' id='chkdel_" + i + "' ></td></tr>"//<td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].BLOCK_REASON) + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].UNBLOCK_BY) + "</td><td width='15%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].SUSPEND_TYPE) + "</td><td><input type='CheckBox' width='25px' id='chkdel_" + i + "' ></td></tr>"
            finaldata += "<tr><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Rate_Mast_Code).toUpperCase() + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Adv_Cat_Code) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Color) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Uom) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Premium) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Size_From) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Size_To) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].From_insertion) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].To_insertion) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Week_Day_Rate) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(ds18.Tables[0].Rows[i].Week_Extra_Rate) + "</td><td><input type='CheckBox' width='2%' id='chkdel_" + i + "' ></td></tr>";//<td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].BLOCK_REASON) + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].UNBLOCK_BY) + "</td><td width='15%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].SUSPEND_TYPE) + "</td><td><input type='CheckBox' width='25px' id='chkdel_" + i + "' ></td></tr>"
     
            }

            finaldata += "</table>";
            document.getElementById("view19").innerHTML = finaldata;
                     document.getElementById("view19").style.display = "block";
}
else
{
 finaldata = "";
 document.getElementById("view19").innerHTML = finaldata;
 document.getElementById("view19").style.display = "none";
}
}
else
{
alert("No Data Found")
 finaldata = "";
 document.getElementById("view19").innerHTML = finaldata;
 document.getElementById("view19").style.display = "none";
}
return false;
}



function repalcestr2quote(val)
{
if(val!=null)
{
    if(val.indexOf("^")>=0)
    {
        while(val.indexOf("^")>=0)
        {
            val=val.replace("^","'");
        }
    }
    return val;
}
}


function selected(i)
{

//document.getElementById('ddladtyp').value=ds18.Tables[0].Rows[i].Week_Extra_Rate;
//document.getElementById('ddlrtcod').value=ds18.Tables[0].Rows[i].Week_Extra_Rate;
//document.getElementById('ddlcategory').value=ds18.Tables[0].Rows[i].Week_Extra_Rate;
//document.getElementById('ddlcolor').value=ds18.Tables[0].Rows[i].Week_Extra_Rate;
//document.getElementById('ddluom').value=ds18.Tables[0].Rows[i].Week_Extra_Rate;
//document.getElementById('txtvldfrm').value=ds18.Tables[0].Rows[i].Week_Extra_Rate;
//document.getElementById('txtvldto').value=ds18.Tables[0].Rows[i].Week_Extra_Rate;
//document.getElementById('ddlpkg').value=ds18.Tables[0].Rows[i].Week_Extra_Rate;
return false;
}

function savdata()
{
alert("hello")

}


function fndnull(myval) {
        if (myval == "undefined") {
            myval = "&nbsp";
        }
        else if (myval == null) {
            myval = "&nbsp";
        }
        else if (myval == "") {
            myval = "&nbsp";
        }
        return myval
    }
    
    
     function chkall_123() {

        var dtlen = document.getElementById("view19").childNodes[0].childNodes[0].children.length;
    //    alert(document.getElementById("Chk_all_box").checked+datalength)
        if (dtlen > 1) {
            if (document.getElementById("Chk_all_box").checked == true) {
                for (i = 0; i < ds18.Tables[0].Rows.length; i++) {
                    document.getElementById("chkdel_" + i).checked = true;

                }
            }
            else {
                for (i = 0; i < ds18.Tables[0].Rows.length; i++) {

                    document.getElementById("chkdel_" + i).checked = false;

                }
            }
        }
        else {
            return false;
        }

    }
    
    
    
    function savdata()
    {
    var compcod=document.getElementById('hiddencompcode').value;
    var expdate=document.getElementById('txtexpdt').value;
    var ratecod=document.getElementById('hdnrateunitid').value;
    var dateformat=document.getElementById('hiddendateformat').value;
    var extra1="";
    if(expdate=="")
    {
    alert("Please Enter Expiry date")
    document.getElementById('txtexpdt').focus();
    return false;
    }
    
     for (i = 0; i < ds18.Tables[0].Rows.length; i++) {
                    if (document.getElementById("chkdel_" + i).checked == true) 
                    {
                    document.getElementById('hdnrateunitid').value=fndnull(ds18.Tables[0].Rows[i].rateuniqueid);
                    ratecod=document.getElementById('hdnrateunitid').value;
                var resp= RateExpiry.saveexpdate(compcod,expdate,ratecod,dateformat,extra1);
                    
                    }

                }
             //   alert(resp.value.)
                
                if(ratecod=="")
    {
    alert("please Select at least one checkbox")
    return false;
    }
    
//    if(resp.value!=""||resp.value!=null)
//    {
//    alert(resp.value)
//    return false;
//    }
//    else
//    {
    alert("save Successfully")
    datafrGrid();
    return false;
    //}
    
    
    }
    
    
     function exitwin()
    {
   if (confirm("Do you want to skip this page ?")) {
            window.close();
            return false;
        }
        return false;
    }
    
    
    
     function clearwin()
    {
  window.open ('RateExpiry.aspx','_self','',false)
return false;
    }
    
    
    function enabling()
    {
   
   document.getElementById('ddladtyp').disabled=false;
document.getElementById('ddlrtcod').disabled=false;
document.getElementById('ddlcategory').disabled=false;
document.getElementById('ddlcolor').disabled=false;
document.getElementById('ddluom').disabled=false;
document.getElementById('txtvldfrm').disabled=false;
document.getElementById('txtvldto').disabled=false;
document.getElementById('ddlpkg').disabled=false; 
document.getElementById('txtexpdt').disabled=true;
document.getElementById('hdnrateunitid').value="";
document.getElementById('btnsave').disabled=true;
    document.getElementById('ddladtyp').focus();
    }
    
    
    function tabval(event)
{

  var key = event.keyCode ? event.keyCode : event.which;
//alert(key)

if(key==13)
{

if(document.activeElement.id=="ddladtyp")
{
document.getElementById("ddlrtcod").focus();
return false;

}
if(document.activeElement.id=="ddlrtcod")
{
document.getElementById("ddlcategory").focus();
return false;

}
if(document.activeElement.id=="ddlcategory")
{
document.getElementById("ddlcolor").focus();
return false;

}
if(document.activeElement.id=="ddlcolor")
{
document.getElementById("ddluom").focus();
return false;

}
if(document.activeElement.id=="ddluom")
{
document.getElementById("ddlpkg").focus();
return false;

}
if(document.activeElement.id=="ddlpkg")
{
document.getElementById("txtvldfrm").focus();
return false;

}

if(document.activeElement.id=="txtvldfrm")
{
document.getElementById("txtvldto").focus();
return false;

}
if(document.activeElement.id=="txtvldto")
{
document.getElementById("btnsbmit").focus();
return false;

}

}

if(key==116)
{

window.open ('RateExpiry.aspx','_self','',false)
return false;
}


}




function check2() {
    //if (document.getElementById('FileUpload1').value == "") {
    document.getElementById('tdall').style.display = "block";
    document.getElementById('td2').style.display = "none";

    //return false;
    // }
}
function check3() {
    //if (document.getElementById('FileUpload1').value == "") {
    document.getElementById('tdall').style.display = "block";
    document.getElementById('td2').style.display = "block";
    //return false;
    // }
}