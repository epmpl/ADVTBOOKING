// JScript File
var browser = navigator.appName;
function bind_taluka()
{
var compcode=document.getElementById('hiddencompcode').value;
var district=document.getElementById('dpd_district').value;
RO_Agency_Wise.bindtaluka(compcode,district,call_bind_taluka);

}

function call_bind_taluka(response)
{

ds= response.value;
    var city=document.getElementById('dpd_taluka');
    city.options.length=0;
    city.options[0]=new Option("Select Taluka");
    document.getElementById("dpd_taluka").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 city.options[city.options.length] = new Option(ds.Tables[0].Rows[i].taluname,ds.Tables[0].Rows[i].talucode);
                city.options.length;    
             }
 }         
 
       return false;
}


function F2fillagencycr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
    if(document.activeElement.id=="txt_agency")
        {       
         
            var compcode =document.getElementById('hiddencompcode').value;
            var agn =document.getElementById('txt_agency').value.toUpperCase();
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=305+ "px" ;//314//290
            document.getElementById('div1').style.left=473+ "px";//395//1004
            document.getElementById('lstagency').focus();
            RO_Agency_Wise.fillF2_CreditAgency(compcode,agn,bindAgency_callback);
      }
 }

}

function bindAgency_callback(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstagency");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Agency Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name,ds_AccName.Tables[0].Rows[i].Agency_Code);         
                pkgitem.options.length;
            }
        }
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
   
        return false;

}


function ClickAgaency(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
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
                if(document.getElementById('lstagency').options[k].value==page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstagency').options[k].innerText;
                    }
                    document.getElementById('txt_agency').value = abc;
                    document.getElementById('hdnagencycode').value =page;
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('txt_agency').focus();
                     return false; 
                    
                }
            }
        }
      }
      else if (key == 27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txt_agency').focus();
         }
  }
  
  
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

 
 
 
 function eventcalling(event)
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
//if(event.keyCode==113) 
//    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;
}
function rad_chk()
{

document.getElementById("div1").style.display="none";
document.getElementById("div3").style.display="none";
document.getElementById("div4").style.display="none";
if(document.getElementById('drp_chk').value=="E")
{
document.getElementById('lbl_executive').disabled=false
document.getElementById('lbl_retainer').disabled=true
document.getElementById('lbl_agency').disabled=true
document.getElementById('txt_executive').disabled=false
document.getElementById('txt_retainer').disabled=true
document.getElementById('txt_agency').disabled=true
document.getElementById('txt_executive').value=""
document.getElementById('txt_retainer').value=""
document.getElementById('txt_agency').value=""
document.getElementById('hdnagencycode').value=""
document.getElementById('hdnexecode').value=""
document.getElementById('hdnretcode').value=""

document.getElementById('txt_executive').style.backgroundColor = "white";
document.getElementById('txt_retainer').style.backgroundColor = "#E8E8E8";
document.getElementById('txt_agency').style.backgroundColor = "#E8E8E8";
document.getElementById('txt_executive').focus();
}
else if(document.getElementById('drp_chk').value=="R")
{
document.getElementById('lbl_executive').disabled=true
document.getElementById('lbl_retainer').disabled=false
document.getElementById('lbl_agency').disabled=true
document.getElementById('txt_executive').disabled=true
document.getElementById('txt_retainer').disabled=false
document.getElementById('txt_agency').disabled=true
document.getElementById('txt_executive').value=""
document.getElementById('txt_retainer').value=""
document.getElementById('txt_agency').value=""
document.getElementById('hdnagencycode').value=""
document.getElementById('hdnexecode').value=""
document.getElementById('hdnretcode').value=""

document.getElementById('txt_executive').style.backgroundColor = "#E8E8E8";
document.getElementById('txt_retainer').style.backgroundColor = "white";
document.getElementById('txt_agency').style.backgroundColor = "#E8E8E8";
document.getElementById('txt_retainer').focus();
}
else
{
document.getElementById('lbl_executive').disabled=true
document.getElementById('lbl_retainer').disabled=true
document.getElementById('lbl_agency').disabled=false
document.getElementById('txt_executive').disabled=true
document.getElementById('txt_retainer').disabled=true
document.getElementById('txt_agency').disabled=false
document.getElementById('txt_executive').value=""
document.getElementById('txt_retainer').value=""
document.getElementById('txt_agency').value=""
document.getElementById('hdnagencycode').value=""
document.getElementById('hdnexecode').value=""
document.getElementById('hdnretcode').value=""

document.getElementById('txt_executive').style.backgroundColor = "#E8E8E8";
document.getElementById('txt_retainer').style.backgroundColor = "#E8E8E8";
document.getElementById('txt_agency').style.backgroundColor = "white";
document.getElementById('txt_agency').focus();
}

return false;

}

function rad_chk1(id)
{
id=id.id

document.getElementById("div1").style.display="none";
document.getElementById("div3").style.display="none";
document.getElementById("div4").style.display="none";
if(id=="radio_exe_ret")
{
document.getElementById('radio_exe_ret').checked=true
document.getElementById('radio_agency').checked=false
document.getElementById('td_age').style.display="none"
document.getElementById('td_exe_ret').style.display="block"
document.getElementById('txt_agency').value=""

document.getElementById('hdnagencycode').value=""
}
else
{
document.getElementById('radio_exe_ret').checked=false
document.getElementById('radio_agency').checked=true
document.getElementById('td_age').style.display="block"
document.getElementById('td_exe_ret').style.display="none"
document.getElementById('txt_executive').value=""
document.getElementById('txt_retainer').value=""

document.getElementById('hdnexecode').value=""
document.getElementById('hdnretcode').value=""
}



}


function F2fillexecutivecr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
    if(document.activeElement.id=="txt_executive")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hiddencompcode').value;
             var executive =document.getElementById('txt_executive').value.toUpperCase();
            document.getElementById("div3").style.display="block";
            document.getElementById('div3').style.top=335+ "px" ;
            document.getElementById('div3').style.left=473+ "px";
            document.getElementById('lstexecutive').focus();
            RO_Agency_Wise.fillF2_Creditexecutive(compcode,executive,bindexecutive_callback);
      }
 }

}
function bindexecutive_callback(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstexecutive");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Executive Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Exec_name,ds_AccName.Tables[0].Rows[i].Exe_no);         
                pkgitem.options.length;
            }
        }
        document.getElementById("lstexecutive").value="0";
        document.getElementById("div3").value="";
        document.getElementById('lstexecutive').focus();
   
        return false;

}


function Clickexecutive(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
    {
        if(document.activeElement.id=="lstexecutive")
        {
        if(document.getElementById('lstexecutive').value=="0")
            {
                 alert("Please select Executive Name");
                 return false;
            }
            
            var page = document.getElementById('lstexecutive').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstexecutive').length-1;k++)
            {   
                if(document.getElementById('lstexecutive').options[k].value==page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstexecutive').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstexecutive').options[k].innerText;
                    }
                    document.getElementById('txt_executive').value = abc;
                   
                    document.getElementById('hdnexecode').value =page;
                    
                    document.getElementById("div3").style.display="none";
                    document.getElementById('txt_executive').focus();
                     return false; 
                    
                }
            }
        }
      }
      else if (key == 27)
         {
         
        document.getElementById("div3").style.display="none";
        document.getElementById('txt_executive').focus();
         }
  }
  /////////////////////////ret
  

function F2fillretainercr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
    if(document.activeElement.id=="txt_retainer")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hiddencompcode').value;
            var retainer =document.getElementById('txt_retainer').value.toUpperCase();
            document.getElementById("div4").style.display="block";
            document.getElementById('div4').style.top=350+ "px" ;
            document.getElementById('div4').style.left=473+ "px";
            document.getElementById('lstretainer').focus();
            RO_Agency_Wise.fillF2_Creditretainer(compcode,retainer,bindretainer_callback);
      }
 }

}
function bindretainer_callback(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstretainer");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Retainer Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Retain_Name,ds_AccName.Tables[0].Rows[i].Retain_Code);         
                pkgitem.options.length;
            }
        }
        document.getElementById("lstretainer").value="0";
        document.getElementById("div4").value="";
        document.getElementById('lstretainer').focus();
   
        return false;

}


function Clickretainer(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
    {
        if(document.activeElement.id=="lstretainer")
        {
        if(document.getElementById('lstretainer').value=="0")
            {
                 alert("Please select Retainer Name");
                 return false;
            }
            
            var page = document.getElementById('lstretainer').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstretainer').length-1;k++)
            {   
                if(document.getElementById('lstretainer').options[k].value==page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstretainer').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstretainer').options[k].innerText;
                    }
                    document.getElementById('txt_retainer').value = abc;
                     
                    document.getElementById('hdnretcode').value =page;
                    
                    document.getElementById("div4").style.display="none";
                    document.getElementById('txt_retainer').focus();
                     return false; 
                    
                }
               
            }
          
        
        }
        
      }
      else if (key == 27)
         {
         
        document.getElementById("div4").style.display="none";
        document.getElementById('txt_retainer').focus();
        return false;
         }
  }
  
  
  
  function run_report(det_sum)
  {
  if(document.getElementById('txtfrmdate').value=="")
  {
  alert("Please enter from date");
  document.getElementById('txtfrmdate').focus();
  return false;
  }
  if(document.getElementById('txttodate1').value=="")
  {
  alert("Please enter to date");
  document.getElementById('txttodate1').focus();
  return false;
  }
  if(document.getElementById('txt_agency').value!="")
  {
      if(document.getElementById('hdnagencycode').value=="")
      {
      alert("Press F2 for Agency");
      document.getElementById('txt_agency').value="";
      document.getElementById('txt_agency').focus();
      return false;
      }
  }
  if(document.getElementById('txt_executive').value!="")
  {
      if(document.getElementById('hdnexecode').value=="")
      {
      alert("Press F2 for Executive");
      document.getElementById('txt_executive').value="";
      document.getElementById('txt_executive').focus();
      return false;
      }
  }
  if(document.getElementById('txt_retainer').value!="")
  {
      if(document.getElementById('hdnretcode').value=="")
      {
      alert("Press F2 for Retainer");
      document.getElementById('txt_retainer').value="";
      document.getElementById('txt_retainer').focus();
      return false;
      }
  }
  
  
  
  if(document.getElementById('txt_agency').value=="")
  {
  document.getElementById('hdnagencycode').value="";
  }
  if(document.getElementById('txt_executive').value=="")
  {
  document.getElementById('hdnexecode').value="";
  }
  if(document.getElementById('txt_retainer').value=="")
  {
  document.getElementById('hdnretcode').value="";
  }
  
  
  
  document.getElementById('hdntaluka').value=document.getElementById('dpd_taluka').value;
  
  var str="";
         if (document.getElementById('drp_chk').value == "A")
             str = "1";
         else if (document.getElementById('drp_chk').value == "E")
             str = "2";
             else
             str = "3";

         var chk_excel = "";
         if (document.getElementById('dpd_destination').value == "4")
         {
             if (document.getElementById('exe').checked == true)
             {
                 chk_excel = "1";//excel
             }
             else
             {
                 chk_excel = "2";//csv
             }

         }
         else
         {
             chk_excel = "0";//other than excel
         }
         
         var compcode=document.getElementById('hiddencompcode').value
         var dateformat=document.getElementById('hiddendateformat').value
         var user_id=document.getElementById('hiddenuserid').value
         var access=document.getElementById('hiddenaccess').value
         var from_date=document.getElementById('txtfrmdate').value
         var to_date=document.getElementById('txttodate1').value
         var print_cent=document.getElementById('dpd_printcent').value
         var agency_code=document.getElementById('hdnagencycode').value
         var branch_code=document.getElementById('dpd_branch').value
          var branch=""
          var des=document.getElementById('dpd_branch').options.selectedIndex;
     if(des!=-1)
    branch=document.getElementById('dpd_branch').options[des].text;
      
      var district=""
          var des1=document.getElementById('dpd_district').options.selectedIndex;
     if(des1!=-1)
    district=document.getElementById('dpd_district').options[des1].text;

         var taluka=document.getElementById('hdntaluka').value
         var ro_doc_status=document.getElementById('dpd_rodoc_status').value
         var pay_mode=document.getElementById('dpd_paymode').value
         var exe_code=document.getElementById('hdnexecode').value
         var ret_code=document.getElementById('hdnretcode').value
        var destination=document.getElementById('dpd_destination').value
        
        
        //
        document.getElementById('hiddenadtype').value=document.getElementById('dpd_adtype').value
        document.getElementById('hiddenadcat').value=document.getElementById('dpd_adcat').value
        document.getElementById('hiddentype').value=document.getElementById('dpd_type').value
        
        var ad_type=document.getElementById('hiddenadtype').value
        var ad_cat=document.getElementById('hiddenadcat').value
        var type=document.getElementById('hiddentype').value
        
        ///
        
        //new added for name
         var print_cent_name=""
          var des2=document.getElementById('dpd_printcent').options.selectedIndex;
     if(des2!=-1)
    print_cent_name=document.getElementById('dpd_printcent').options[des2].text;
        
         var taluka_name=""
          var des3=document.getElementById('dpd_taluka').options.selectedIndex;
     if(des3!=-1)
    taluka_name=document.getElementById('dpd_taluka').options[des3].text;
    
    
          var agency_name=document.getElementById('txt_agency').value;
          var executive_name=document.getElementById('txt_executive').value;
          var retainer_name=document.getElementById('txt_retainer').value;
          
           var adtyp_name=""
          var des4=document.getElementById('dpd_adtype').options.selectedIndex;
     if(des4!=-1)
    adtyp_name=document.getElementById('dpd_adtype').options[des4].text;
    
     var adcat_name=""
          var des5=document.getElementById('dpd_adcat').options.selectedIndex;
     if(des5!=-1)
    adcat_name=document.getElementById('dpd_adcat').options[des5].text;
    
    var typ_name=""
          var des6=document.getElementById('dpd_type').options.selectedIndex;
     if(des6!=-1)
    typ_name=document.getElementById('dpd_type').options[des6].text;
    
   
           var rodoc_status_name=""
          var des7=document.getElementById('dpd_rodoc_status').options.selectedIndex;
     if(des7!=-1)
    rodoc_status_name=document.getElementById('dpd_rodoc_status').options[des7].text;
    
     var paymode_name=""
          var des8=document.getElementById('dpd_paymode').options.selectedIndex;
     if(des8!=-1)
         paymode_name = document.getElementById('dpd_paymode').options[des8].text;

     var dtbased = document.getElementById('drpbasedon').value;
   
   // add by sourabh
            var adsubcat = document.getElementById('dpd_adcatsub').value;
            var rpttype = document.getElementById('drprpttype').value;
            var extra1="";
            var extra2="";

        ////new added for name
     var res = RO_Agency_Wise.btn_click(compcode, dateformat, user_id, access, from_date, to_date, print_cent, agency_code, branch, district, taluka, ro_doc_status, pay_mode, exe_code, ret_code, det_sum, str, destination, chk_excel, branch_code, type, ad_type, ad_cat, print_cent_name, taluka_name, agency_name, executive_name, retainer_name, adtyp_name, adcat_name, typ_name, rodoc_status_name, paymode_name, dtbased,adsubcat,rpttype,extra1,extra2)
        var ds1=res.value;
        
        if(ds1==null)
        {
        alert(res.error.description);
        return false;
        }
        if(ds1.Tables[0].Rows.length==0)
        {
        
        alert("Searching Criteria is not valid");
        return false
        }
        else
        {
         window.open('RO_Agency_Wise_View.aspx');
        }
         return false;
         
  }
  
  

function excel_report1()
{
if(document.getElementById('dpd_destination').value=="4")
{
if(document.getElementById('fg').style.display = 'none')
{
//document.getElementById('exe').disabled = false
document.getElementById('fg').style.display = 'block'
//document.getElementById('csv').disabled = false
}

}
else

{
//document.getElementById('exe').disabled = true
//document.getElementById('csv').disabled = true
document.getElementById('fg').style.display = 'none'
}
return false;
}

function enable_exe1()
{
if(document.getElementById('exe').checked == false)
{
document.getElementById('exe').checked =true
}
if(document.getElementById('csv').checked == true)
{
document.getElementById('csv').checked =false
}
}

function enable_csv1()
{
if(document.getElementById('exe').checked == true)
{
document.getElementById('exe').checked =false
}
if(document.getElementById('csv').checked == false)
{
document.getElementById('csv').checked =true
}
}




function load_chkdiv()
{
    if(document.getElementById("radio_exe_ret").checked==true)
    {
    document.getElementById('td_age').style.display="none"
    document.getElementById('td_exe_ret').style.display="block"
    }
    else
    {
    document.getElementById('td_age').style.display="block"
    document.getElementById('td_exe_ret').style.display="none"
    }
}

function bind_pubcentbranch()
{
RO_Agency_Wise.fillQBC(document.getElementById('dpd_printcent').value,bindQBC_callback);
}
function bindQBC_callback(response)
{
    var ds=response.value;
    agcatby = document.getElementById("dpd_branch");
    agcatby.options.length = 1; 
    agcatby.options[0]=new Option("Select Branch","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
    //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].Branch_Code);
        
            agcatby.options.length;       
        }
    }
}


function bindadcat()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpd_adtype').value;
RO_Agency_Wise.adcatbnd(adtype1,compcode,call_adcatbind);
//billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
}
function call_adcatbind(response)
{
ds= response.value;
    var brand=document.getElementById('dpd_adcat');
    brand.options.length=0;
    brand.options[0]=new Option("Select AdCat");
    document.getElementById("dpd_adcat").options.length = 1;
    

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


   function clearro_agency() {
       document.getElementById('drp_chk').value = "A";
       document.getElementById('dpd_printcent').value = "0";
       document.getElementById('dpd_branch').value = "0";
       document.getElementById('txtfrmdate').value = "";
       document.getElementById('txttodate1').value = "";
       document.getElementById('dpd_district').value = "0";
       document.getElementById('dpd_taluka').value = "0";
       document.getElementById('txt_agency').value = "";
       document.getElementById('txt_executive').value = "";
       document.getElementById('txt_retainer').value = "";
       document.getElementById('dpd_rodoc_status').value = "0";
       document.getElementById('dpd_paymode').value = "0";
       document.getElementById('dpd_adtype').value = "0";
       document.getElementById('dpd_adcat').value = "0";
       document.getElementById('dpd_destination').value = "0";
       document.getElementById('dpd_type').value = "0";
       document.getElementById('dpd_printcent').focus();
      document.getElementById('dpd_adcatsub').value = "0";

   }
   
   
   
   
   
   
    function bindadcatsub()
    {
        var compcode=document.getElementById('hiddencompcode').value;
        var adtype2=document.getElementById('dpd_adcat').value;
        RO_Agency_Wise.bind_adsubcat(adtype2,compcode,call_adcatbindsub);
        //billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
    }
    
            
        function call_adcatbindsub(response)
        {
                ds= response.value;
                var brand=document.getElementById('dpd_adcatsub');
                brand.options.length=0;
                brand.options[0]=new Option("Select AdCat Sub");
                document.getElementById("dpd_adcatsub").options.length = 1;

                if(ds.Tables[0].Rows.length>0)
                {
                    for(var i=0; i<ds.Tables[0].Rows.length; i++)
                    {
                        brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
                        brand.options.length;    
                    }
                }         
                return false;
        }