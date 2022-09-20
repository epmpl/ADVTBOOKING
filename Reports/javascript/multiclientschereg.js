


function F2fillsectioncode(event) {


   // alert('1')
    if (event.keyCode == 113) {
        divid = "div1";
        listboxid = "lstsectioncode";
        txtbxid = eval(document.getElementById('dpagency'))
        txtboxid = "txt_designer";
        if (document.activeElement.id == "txt_designer") {

            // var compcode = document.getElementById('hdncompcode').value;
            var name_p = document.getElementById('txt_designer').value;
            document.getElementById("div1").style.display = "block";
            document.getElementById('div1').style.top = 465 + "px"; //314//290
            document.getElementById('div1').style.left = 580 + "px"; //395//1004
            document.getElementById('lstsectioncode').focus();
            multiclientschedulereg.getSectionCode(name_p, bindsectioncode_callbackbb);
        }
    }


}

function bindsectioncode_callbackbb(res) {
    var ds_AccName = res.value;


    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstsectioncode");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Section Code-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].CODE, ds_AccName.Tables[0].Rows[i].NAME);
            pkgitem.options.length;
        }
    }
//    var btag;
//        var leftpos = 0;
//    var toppos = 0;
//      do {
//    //        txtbxid = eval(txtbxid.offsetParent);
//          leftpos += txtbxid.offsetLeft;
//          toppos += txtbxid.offsetTop;
//           btag = eval(txtbxid)
//        } 
//    //   while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
//       var tot = document.getElementById('div1').scrollLeft;
//       var scrolltop = document.getElementById('div1').scrollTop;
//        document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
//        document.getElementById(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; 

//      document.getElementById("lstsectioncode").value = "0";
//      document.getElementById("div1").value = "";
//       document.getElementById('lstsectioncode').focus();

   return false;

}


function fillondesign(event)
{
    if(event.keyCode==13 || event.type=="click")
    {
        if(document.activeElement.id=="lstsectioncode")
        {
        if(document.getElementById('lstsectioncode').value=="0")
            {
                 alert("Please select Section Code");
                 return false;
            }
            
            var page = document.getElementById('lstsectioncode').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstsectioncode').length-1;k++)
            {   
                if(document.getElementById('lstsectioncode').options[k].value==page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstsectioncode').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstsectioncode').options[k].innerText;
                    }
                    document.getElementById('txt_designer').value = abc;
                   // document.getElementById('hdnagencytxt').value =abc;
                   // document.getElementById('hdnagency1').value =page;
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('txt_designer').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
        {
        alert('2')
       document.getElementById("div1").style.display="none";
        document.getElementById('txt_designer').focus();
    }

    
  }

function bindadcat_schedule()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpaddtype').value;
multiclientschedulereg.adcatbnd(adtype1,compcode,call_adcat_schedule);
multiclientschedulereg.adpkg_bind(adtype1,compcode,call_pkg_schedule);
}
function call_adcat_schedule(response)
{
ds= response.value;
    var brand=document.getElementById('dpadcatgory');
    brand.options.length=0;
    brand.options[0]=new Option("--Select AdCat--");
    document.getElementById("dpadcatgory").options.length = 1;
    

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
function call_pkg_schedule(response)
{
ds= response.value;
    var brand=document.getElementById('drppackage');
    brand.options.length=0;
    brand.options[0]=new Option("--Select Package--");
    document.getElementById("drppackage").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name,ds.Tables[0].Rows[i].Combin_Code);
                brand.options.length;    
             }
 }         
 
       return false;
}



function call_adcatbind1(response)
{
ds= response.value;
    var brand=document.getElementById('dpadcat');
    brand.options.length=0;
    brand.options[0]=new Option("--Select AdCat--");
    document.getElementById("dpadcat").options.length = 1;
    

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

function enable_pkg()
{
 if ( document.getElementById("drppackagedetail").value == "1")
        {
            document.getElementById("drppackage").disabled = false;
            document.getElementById("dppub1").disabled= true;
            document.getElementById("dppubcent").disabled = true;
            document.getElementById("dpsuppliment").disabled = true;
            document.getElementById("dpedition").disabled = true;

            document.getElementById("dppub1").value= "0";
            document.getElementById("dppubcent").value= "0";
            document.getElementById("dpsuppliment").value= "0";
            document.getElementById("dpedition").value= "0";
        }
        else
        {
            document.getElementById("drppackage").disabled = true;
            document.getElementById("dppub1").disabled= false;
            document.getElementById("dppubcent").disabled = false;
            document.getElementById("dpsuppliment").disabled = false;
            document.getElementById("dpedition").disabled = false;
        
            
  var brand=document.getElementById('drppackage');
    brand.options.length=0;
    brand.options[0]=new Option("--Select Package--");
    document.getElementById("drppackage").options.length = 1;
           //  document.getElementById("drppackage").value = "0";
        }
}

 function chknessschedule_nn()
    {
    
    
     var    newstr = "";
    var    newstr1 = "";
    if(browser=="Microsoft Internet Explorer")
    {
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    }
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    
  //  alert('1');
    if(browser!="Microsoft Internet Explorer")
    {
    alrt=document.getElementById('lbDateFrom').textContent;
    }
    else
    {
    alrt=document.getElementById('lbDateFrom').innerText;
    }
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfrmdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    } 
//   alert('2');
if(browser!="Microsoft Internet Explorer")
    {
   alrt=document.getElementById('lbToDate').textContent;
    }
     else
    {
    alrt=document.getElementById('lbToDate').innerText;
    }
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate1').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txttodate1').focus();
            return false;
      
        }
        

    }
 //   alert('3');
     if(document.getElementById('dpaddtype').value=="0")
    {
    alert("Please Select AdType");
    document.getElementById('dpaddtype').focus();
    return false;
    }
 //    alert('4');
    if(document.getElementById('dppub1').disabled != true)
    {
    
            if(document.getElementById('dppub1').value=="0")
            {
            alert("Please Select Publication");
            document.getElementById('dppub1').focus();
            return false;
            }
    
    }
 //    alert('5');
    
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
    
    
    document.getElementById('hiddenadcat').value=newstr;
document.getElementById('hiddenadcatname').value=newstr1;
//alert(document.getElementById('dpedition').value);
document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;
    if(document.getElementById('hiddenedition').value=="--Select Edition Name--")
    document.getElementById('hiddenedition').value="";
    document.getElementById('hiddenpackage').value=document.getElementById('drppackage').value;
 var des1=document.getElementById('drppackage').options.selectedIndex;
  if(des1!=-1)
    document.getElementById('hiddenpackagename').value=document.getElementById('drppackage').options[des1].text;
    if(document.getElementById('hiddenpackage').value=="--Select Package--")
    document.getElementById('hiddenpackage').value="";
    document.getElementById('hdnsuppliment').value=document.getElementById('dpsuppliment').value;
    
    
         var flagDate=compareDates_schedule();
if(flagDate ==false)
{
return false;
 } 
    
     
    //var destination=document.getElementById('Txtdest').options[document.getElementById('Txtdest').selectedIndex].text;
    var destination=document.getElementById('Txtdest').value;
    var frmdt=document.getElementById('txtfrmdate').value;
    var datto=document.getElementById('txttodate1').value;
    var publ=document.getElementById('dppub1').value;
    var pubnam=document.getElementById('dppub1').options[document.getElementById('dppub1').selectedIndex].text;
    var edtn=document.getElementById('hiddenedition').value;
    var edtnnam=document.getElementById('hiddeneditionname').value;
    var pubcenanm=document.getElementById('dppubcent').options[document.getElementById('dppubcent').selectedIndex].text;
    var pubcentcod=document.getElementById('dppubcent').value;
    var adtypnam=document.getElementById('dpaddtype').options[document.getElementById('dpaddtype').selectedIndex].text;
   var adtypcod=document.getElementById('dpaddtype').value;
   var adcat=document.getElementById('hiddenadcat').value; 
   var editiondetail=document.getElementById('dpedidetail').value;
   var status=document.getElementById('drpstatus').value;
    var adcatname=document.getElementById('hiddenadcatname').value;
   var supplementcode=document.getElementById('hdnsuppliment').value;
     var package11=document.getElementById('hiddenpackage').value;
      var pkgdetail=document.getElementById('drppackagedetail').value;
      var package11name = document.getElementById('hiddenpackagename').value;
      var designer = document.getElementById('txt_designer').value;
      
      
      var chk_excel="";
       if (document.getElementById('Txtdest').value == "4")
        {
      if(document.getElementById('exe').checked==true)
      chk_excel="1";
      else
     chk_excel="2";
      }
      else
      chk_excel="0";
      var branch_code=document.getElementById('dpd_branch').value;
     var branch_name=document.getElementById('dpd_branch').options[document.getElementById('dpd_branch').selectedIndex].text;
   
   var rostatus_code=document.getElementById('ddlrostatus').value;
   var rostatus=document.getElementById('ddlrostatus').options[document.getElementById('ddlrostatus').selectedIndex].text;
   
   var ciod=document.getElementById('hiddencioid').value;
   var hdnasc=document.getElementById('hiddenascdesc').value;

   window.open("multiclientscheduleregView.aspx?destination=" + destination + "&fromdate=" + frmdt + "&dateto=" + datto + "&publication=" + publ + "&publicationname=" + pubnam + "&edition=" + edtn + "&editionname=" + edtnnam + "&publicationcenter=" + pubcenanm + "&pubcentcode=" + pubcentcod + "&adtype=" + adtypnam + "&adtypecode=" + adtypcod + "&adcategory=" + adcat + "&editiondetail=" + editiondetail + "&status=" + status + "&adcatname=" + adcatname + "&supplementcode=" + supplementcode + "&package11=" + package11 + "&pkgdetail=" + pkgdetail + "&package11name=" + package11name + "&chk_excel=" + chk_excel + "&branch_code=" + branch_code + "&branch_name=" + branch_name + "&hdnasc=" + hdnasc + "&ciod=" + ciod + "&rostatus=" + rostatus + "&rostatus_code=" + rostatus_code + "&designer=" + designer);
    return false;
    
    }
    
    function bind_edition()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    report.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
     function bind_edition2()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    report2.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    return false;
    }
     function bind_edition_sch()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    multiclientschedulereg.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
    function call_bind_edition(response)
    {
      ds= response.value;
    var edition=document.getElementById('dpedition');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Edition Name--");
    document.getElementById("dpedition").options.length = 1;
   if(ds!=null && ds.Tables.length>0)
   {
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias,ds.Tables[0].Rows[i].edition_code);
                edition.options.length;    
             }
          
 }
       return false
    }