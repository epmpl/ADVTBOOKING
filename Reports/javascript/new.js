// JScript File

 var divid = "";
            var listboxid = "";
            var txtboxid="";
    var txtbxid="";
var browser=navigator.appName;
function bindedition()
{
var compcode=document.getElementById('hiddencompcode').value;
var pubcent=document.getElementById('Drppubcent').value;

issuewisereport.editionbind(compcode,pubcent,call_bindedition);
}

function call_bindedition(response)
{

   ds= response.value;
    var edition=document.getElementById('Drpedition');
    edition.options.length=0;
    edition.options[0]=new Option("-Select Edition-");
    document.getElementById("Drpedition").options.length = 1;
   
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


function issuecheck()
{
if(browser=="Microsoft Internet Explorer")
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
 }   
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;
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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
    
    document.getElementById('hdnedition').value=document.getElementById('Drpedition').value;
    var des=document.getElementById('Drpedition').options.selectedIndex;
     if(des!=-1)
    document.getElementById('hdneditionname').value=document.getElementById('Drpedition').options[des].text;
      
     var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    
    } 
    
    
    function adcat_bind()
    {
     document.getElementById("hiddenuom").value="";
    
 uombind();
    var ad_type=document.getElementById('dpdadtype').value;
    var comp_code=document.getElementById('hiddencompcode').value;
    
    report.bind_adcat(ad_type,comp_code,call_adcat_bind1);
    
    }
     function adcat_bind_client()
    {
    var ad_type=document.getElementById('dpdadtype').value;
    var comp_code=document.getElementById('hiddencompcode').value;
    
    agencyclient.bind_adcat(ad_type,comp_code,call_adcat_bindcli);
    
    }
    
    function call_adcat_bindcli(response)
    {
    //uombind();
    //var=ds;
    ds=response.value;
    
     var edition=document.getElementById('dpadcatgory');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Ad Cat--");
    document.getElementById("dpadcatgory").options.length = 1;
   
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                edition.options.length;    
             }
          
 var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpdadtype').value;
var center="";
 var res=agencyclient.pkg_adcat_uom_bind(compcode, adtype1, center);
    ds=res.value;  
    var drpuom=document.getElementById("drpuom");  
 drpuom.options.length=0;
    drpuom.options[0]=new Option("--Select UOM--","0");
    if(ds!=null)
    {
    if(ds.Tables[1].Rows.length>0)
        {
            for (var i = 0  ; i < ds.Tables[1].Rows.length; ++i)
            {
                drpuom.options[drpuom.options.length] = new Option(ds.Tables[1].Rows[i].Uom_Name,ds.Tables[1].Rows[i].Uom_Code);
                drpuom.options.length;   
            }
        }
    }
  
       return false;
    }
    
    
    
    function adcat_bind_status()
    {
      var ad_type=document.getElementById('dpdadtype').value;
    var comp_code=document.getElementById('hiddencompcode').value;
    
    report3.bind_adcat(ad_type,comp_code,call_adcat_bind);
    }
     function adcat_bind_deviation()
    {
      var ad_type=document.getElementById('dpdadtype').value;
    var comp_code=document.getElementById('hiddencompcode').value;
    
    Devationreport.bind_adcat(ad_type,comp_code,call_adcat_binddev);
    
    }
    
    function call_adcat_binddev(response)
    {
    //var=ds;
    ds=response.value;
    
     var edition=document.getElementById('dpadcatgory');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Ad Cat--");
    document.getElementById("dpadcatgory").options.length = 1;
   
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                edition.options.length;    
             }
          
 var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpdadtype').value;
var center="";
 var res=Devationreport.pkg_adcat_uom_bind(compcode, adtype1, center);
    ds=res.value;  
    var drpuom=document.getElementById("drpuom");  
 drpuom.options.length=0;
    drpuom.options[0]=new Option("--Select UOM--","0");
    if(ds!=null)
    {
    if(ds.Tables[1].Rows.length>0)
        {
            for (var i = 0  ; i < ds.Tables[1].Rows.length; ++i)
            {
                drpuom.options[drpuom.options.length] = new Option(ds.Tables[1].Rows[i].Uom_Name,ds.Tables[1].Rows[i].Uom_Code);
                drpuom.options.length;   
            }
        }
    }
  
       return false;
    }
    
    
    function adcat_bind_executive()
    {
      var ad_type=document.getElementById('dpdadtype').value;
    var comp_code=document.getElementById('hiddencompcode').value;
    
    ExecutiveReport.bind_adcat(ad_type,comp_code,call_adcat_bind);
    
    }
    function call_adcat_bind1(response)
    {
    //var=ds;
    ds=response.value;
    
     var edition=document.getElementById('dpadcatgory');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Ad Cat--");
    document.getElementById("dpadcatgory").options.length = 1;
   
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                edition.options.length;    
             }
          
 
  var edition1=document.getElementById('lstadsubcat');
    edition1.options.length=0;
    edition1.options[0]=new Option("--Select Ad SubCat--");
    document.getElementById("lstadsubcat").options.length = 1;
       return false;
    }
     function call_adcat_bind(response)
    {
    //var=ds;
    ds=response.value;
    
     var edition=document.getElementById('dpadcatgory');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Ad Cat--");
    document.getElementById("dpadcatgory").options.length = 1;
   
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                edition.options.length;    
             }
          
 
  
       return false;
    }
    
    function adsubcat_bind()
    {
     var ad_type=document.getElementById('dpdadtype').value;
    var comp_code=document.getElementById('hiddencompcode').value;
    
    
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
        
    report.bind_adsubcat(newstr,newstr1,call_adsubcat_bind);
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
    
    function allads(event)
    {
    var    newstr = "";
        var newstr1 = "";
        if(browser=="Microsoft Internet Explorer")
        {
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    }
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    
    
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;
    }
    if(alrt.indexOf('*')>=0)
    {
    if(document.getElementById('txtbukid').value=="")
    {
        if(document.getElementById('txtfrmdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txtfrmdate').focus();
            return false;
        }
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
    }
    if(alrt.indexOf('*')>=0)
    {
    if(document.getElementById('txtbukid').value=="")
    {
        if(document.getElementById('txttodate1').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txttodate1').focus();
            return false;
      
        }
        }
        }
        
        
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
        
        

        var new1str = "";
        var new1str1 = "";
         var listadsubcat=document.getElementById('lstadsubcat');
        for(var i=1;i<listadsubcat.options.length  ;  i++)
        {
         
            if (listadsubcat.options[i].selected == true)
            {
              if (new1str == "")
                {
                    new1str = listadsubcat.options[i].value;
                   new1str1 = listadsubcat.options[i].text;
               }
                else
                {
                   new1str = new1str + "," + listadsubcat.options[i].value;
                    new1str1 = new1str1 + "," + listadsubcat.options[i].text;
                }
            }
          
        }

document.getElementById('hiddenadcat').value=newstr;
document.getElementById('hiddenadsubcat').value=new1str;

document.getElementById('hiddenadcatname').value=newstr1;
document.getElementById('hiddenadsubcatname').value=new1str1;
document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
   if(des!=-1)
       document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;
     var flagDate=true;
    if(document.getElementById('txttodate1').value!=""&&document.getElementById('txtfrmdate').value!="")
    {
      flagDate=compareDates();
     }
if(flagDate ==false)
{
return false;
 } 
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
       
    ScheduleRegister.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
     function bind_edition3()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    agencyclient.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
     function bind_edition4()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    report3.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
     function bind_edition5()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    Devationreport.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
      function bind_edition6()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    pagepreviewreport.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
    function bind_edition7()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    IssueWiseBussiness.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
     function bind_edition8()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    RevenueSummarryReport.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
      function bind_edition9()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    Ageanalysis.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
       function bind_edition10()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    ExecutiveReport.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
       function bind_edition12()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    summarized_report.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    return false;
    }
   
    function call_bind_edition(response)
    {
      ds= response.value;
    var edition=document.getElementById('dpedition');
    //edition.options.length=0;
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
    
    function allagency(event)
    {
    var    newstr = "";
        var newstr1 = "";
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;

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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;
    
       var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    }
    
    function pagepremnew(event)
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;
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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
      if(document.getElementById('dppub1').value=="0")
    {
    alert("Please Select Publication");
    document.getElementById('dppub1').focus();
    return false;
    }
    
    
    
    document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;


  var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    } 
    
    
    
    
    
     function chkpubnew(event)
    {
   // var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
   // loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;
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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
   
    
    // if(document.getElementById('dppub1').value=="0")
    //{
    //alert("Please Select Publication");
    //document.getElementById('dppub1').focus();
    //return false;
    //}
    
    
    document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;

  var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    }
    
    
    function bind_executive()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var city=document.getElementById('dpcity').value;
     
       
    Ageanalysis.executive_bind(comp_code,city,call_bind_executive);
    
    }
    function call_bind_executive(response)
    {
    ds= response.value;
    var edition=document.getElementById('dpexec11');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Executive Name--");
    document.getElementById("dpexec11").options.length = 1;
   

             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Exec_name,ds.Tables[0].Rows[i].Exe_no);
                edition.options.length;    
             }
             
          
 
       return false
    }
    
    function chkexenew(event)
    {
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;
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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
   
    
//     if(document.getElementById('dppub1').value=="0")
//    {
//    alert("Please Select Publication");
//    document.getElementById('dppub1').focus();
//    return false;
//    }
    
    
    document.getElementById('hiddenexecutive').value=document.getElementById('dpexec11').value;
    var des1=document.getElementById('dpexec11').options.selectedIndex;
    document.getElementById('hiddenexecutivename').value=document.getElementById('dpexec11').options[des1].text;

    
    document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;


  var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    }
    
    
    function bind_team_exe()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var team=document.getElementById('dpteam').value;
      var userid=document.getElementById('hiddenuserid').value;
     
       
    ExecutiveReport.exe_bind(comp_code,userid,team,call_bind_team_exe);
   return false;
    }
     function bind_exe_represen()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var team=document.getElementById('dpteam').value;
      var userid=document.getElementById('hiddenuserid').value;
     
       
    representative_ledger.exe_bind(comp_code,userid,team,call_bind_team_exe);
   
    }
     function call_bind_team_exe(response)
    {
    ds= response.value;
    var edition=document.getElementById('dpexec');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Executive Name--");
    document.getElementById("dpexec").options.length = 1;
   
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Exec_name,ds.Tables[0].Rows[i].Exe_no);
                edition.options.length;    
             }
          
 
       return false
    }
    
     function validationexecnew(event)
{
var newstr="";
var newstr1 = "";
if (browser == "Microsoft Internet Explorer") {
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
    loadXML('xml/categoryreport.xml');
}

    var abc= document.getElementById('txttodate1').value
    var abc1= document.getElementById('txtfrmdate').value
    var abc2= document.getElementById('dpteam').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;
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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbteam').textContent;
    }

    else {
        alrt = document.getElementById('lbteam').innerText;
    }
    if(alrt.indexOf('*')>=0)
    {
        if (document.getElementById('dpteam').value == "0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpteam').focus();
            return false;

        }
    }
    
    
         
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
    document.getElementById('hiddenexecutive').value=document.getElementById('dpexec').value;
    var des1=document.getElementById('dpexec').options.selectedIndex;
     if(des1!=-1)
    document.getElementById('hiddenexecutivename').value=document.getElementById('dpexec').options[des1].text;

    
    document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;

     var flagDate=compareDates();
if(flagDate ==false)
{
return false;
} 
} 


function bind_edition11()
    {
//     var comp_code=document.getElementById('hiddencompcode').value;
//     var publication=document.getElementById('dppub1').value;
        var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    availablepremium.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    //availablepremium.edition_bind(publication,call_bind_edition1);
    }
      function bind_edition13()
    {
    // var comp_code=document.getElementById('hiddencompcode').value;
     //var publication=document.getElementById('dppub1').value;
       var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       BillRegister.edition_bind(publication,pub_cent,comp_code,call_bind_edition); 
    //BillRegister.edition_bind(publication,call_bind_edition1);
    }
        function bind_edition14()
    {
//     var comp_code=document.getElementById('hiddencompcode').value;
//     var publication=document.getElementById('dppub1').value;
//       
//    Retaincom.edition_bind(comp_code,publication,call_bind_edition1);
  var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       Retaincom.edition_bind(publication,pub_cent,comp_code,call_bind_edition); 
    }
    function call_bind_edition1(response)
    {
      ds= response.value;
    var edition=document.getElementById('dpedition');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Edition Name--");
    document.getElementById("dpedition").options.length = 1;
   
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_Alias,ds.Tables[0].Rows[i].Edition_Code);
                edition.options.length;    
             }
          
 
       return false
    }
    
    
    
  
 function btnrunclicknew(event) {

//var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
//    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
      var alrt;


    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;

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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
    
    
     if(document.getElementById('dppub1').value=="0")
    {
    alert("Please Select Publication");
    document.getElementById('dppub1').focus();
    return false;
    }
   
    if((document.getElementById('dppage').value=="0") && (document.getElementById('dpposition').value=="0"))
    {
    alert("Please Select Page Or Position For Available Dates");
    document.getElementById('dppage').focus();
    return false;
    }
   
    document.getElementById('hdnadcat').value=document.getElementById('dpadcat').value;
     document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;


     var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 


    } 
    
    
     function daily_summarized(event)
    {
   // var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
   // loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if(browser!="Microsoft Internet Explorer")
    alrt=document.getElementById('lbDateFrom').textContent;
    else
    alrt=document.getElementById('lbDateFrom').innerText;
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
   if(browser!="Microsoft Internet Explorer")
   alrt=document.getElementById('lbToDate').textContent;
   else
   alrt=document.getElementById('lbToDate').innerText;
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
   
    
    
    document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;

  var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    }
    
    
    
     function represennew()
{
var newstr="";
var newstr1="";
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/categoryreport.xml');

    var abc= document.getElementById('txttodate1').value
    var abc1= document.getElementById('txtfrmdate').value
    var abc2= document.getElementById('dpteam').value
    var alrt;

    alrt=document.getElementById('lbDateFrom').innerText;
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

    alrt=document.getElementById('lbToDate').innerText;
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

   

    document.getElementById('hiddenexecutive').value=document.getElementById('dpexec').value;
    var des1=document.getElementById('dpexec').options.selectedIndex;
   if(des1!=-1)
    document.getElementById('hiddenexecutivename').value=document.getElementById('dpexec').options[des1].text;

     var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
} 





function compareDates()
{
var fromDate=document.getElementById('txtfrmdate').value;
var toDate=document.getElementById('txttodate1').value;
var splitChar="";
if(fromDate .indexOf ("/")>=0)
{
splitChar="/";
}
else if(fromDate .indexOf("-")>=0)
{
splitChar ="-";
}
else if(fromDate .indexOf(".")>=0)
{
splitChar =".";
}

var fromDateArray=fromDate .split(splitChar );
var toDateArray=toDate .split(splitChar);
if(document.getElementById('hiddendateformat').value="dd/mm/yyyy")
{
    var from_day=parseInt(fromDateArray [0],10);
    var from_month=parseInt (fromDateArray  [1],10);
    var from_year=parseInt (fromDateArray  [2],10);
    
    var to_day=parseInt(toDateArray [0],10);
    var to_month=parseInt(toDateArray [1],10);
    var to_year=parseInt(toDateArray [2],10);
}
else if(document.getElementById('hiddendateformat').value="mm/dd/yyyy")
{
    var from_day=parseInt(fromDateArray [1],10);
    var from_month=parseInt (fromDateArray  [0],10);
    var from_year=parseInt (fromDateArray  [2],10);

    var to_day=parseInt(toDateArray [1],10);
    var to_month=parseInt(toDateArray [0],10);
    var to_year=parseInt(toDateArray [2],10);

}
else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
{
    var from_day=parseInt(fromDateArray [2],10);
    var from_month=parseInt (fromDateArray  [1],10);
    var from_year=parseInt (fromDateArray  [0],10);

    var to_day=parseInt(toDateArray [2],10);
    var to_month=parseInt(toDateArray [1],10);
    var to_year=parseInt(toDateArray [0],10);

}
    if(to_year >from_year )
    {
        return true;
    }
    else
    {
        if(to_year ==from_year && to_month >from_month)
        {
            return true;
        }
        else if(to_year ==from_year && to_month ==from_month && to_day >=from_day )
            {
                return true;
                
            }
        else
        {    
        alert("From Date should be less than To date.");
                document.getElementById('txtfrmdate').focus();
                return false;
        }
       
    }

}




function pivalidation_nn()
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    
    alrt=document.getElementById('lbDateFrom').innerText;
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
   
   alrt=document.getElementById('lbToDate').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate1').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txttodate1').focus();
            return false;
      
        }
        
//         if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//        document.getElementById('txtfrmdate').value="";
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    }
    }
    
       var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    } 
    
    
    
    function chkorder_nn()
 {
 if(browser=="Microsoft Internet Explorer")
 {
 var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
  }  
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    
    if(browser!="Microsoft Internet Explorer")
    alrt=document.getElementById('lbDateFrom').textContent;
    else
    alrt=document.getElementById('lbDateFrom').innerText;
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
   
   if(browser!="Microsoft Internet Explorer")
   alrt=document.getElementById('lbToDate').textContent;
   else
   alrt=document.getElementById('lbToDate').innerText;
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
  if(document.getElementById('dporderby').value=="0")
  {
  alert("Please Select Order By");
  document.getElementById('dporderby').focus();
  return false;
  
  }
  
  var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
 }
 
 
 
 function allads_nn()
    {
    var    newstr = "";
        var newstr1 = "";
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    
    alrt=document.getElementById('lbDateFrom').innerText;
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
   
   alrt=document.getElementById('lbToDate').innerText;
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
        

        
        

     var flagDate=compareDates();
if(flagDate ==false)
{
return false;
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
   
   var reptype = document.getElementById('drpreptype').value;
   if (reptype == "O") {

       window.open("ScheduleRegisterView.aspx?destination=" + destination + "&fromdate=" + frmdt + "&dateto=" + datto + "&publication=" + publ + "&publicationname=" + pubnam + "&edition=" + edtn + "&editionname=" + edtnnam + "&publicationcenter=" + pubcenanm + "&pubcentcode=" + pubcentcod + "&adtype=" + adtypnam + "&adtypecode=" + adtypcod + "&adcategory=" + adcat + "&editiondetail=" + editiondetail + "&status=" + status + "&adcatname=" + adcatname + "&supplementcode=" + supplementcode + "&package11=" + package11 + "&pkgdetail=" + pkgdetail + "&package11name=" + package11name + "&chk_excel=" + chk_excel + "&branch_code=" + branch_code + "&branch_name=" + branch_name + "&hdnasc=" + hdnasc + "&ciod=" + ciod + "&rostatus=" + rostatus + "&rostatus_code=" + rostatus_code + "&designer=" + designer);
   }
   else {
       window.open("scheduleregister_new.aspx?destination=" + destination + "&fromdate=" + frmdt + "&dateto=" + datto + "&publication=" + publ + "&publicationname=" + pubnam + "&edition=" + edtn + "&editionname=" + edtnnam + "&publicationcenter=" + pubcenanm + "&pubcentcode=" + pubcentcod + "&adtype=" + adtypnam + "&adtypecode=" + adtypcod + "&adcategory=" + adcat + "&editiondetail=" + editiondetail + "&status=" + status + "&adcatname=" + adcatname + "&supplementcode=" + supplementcode + "&package11=" + package11 + "&pkgdetail=" + pkgdetail + "&package11name=" + package11name + "&chk_excel=" + chk_excel + "&branch_code=" + branch_code + "&branch_name=" + branch_name + "&hdnasc=" + hdnasc + "&ciod=" + ciod + "&rostatus=" + rostatus + "&rostatus_code=" + rostatus_code + "&designer=" + designer);

   }

    return false;
    
    }
    
    
    
    
    

function compareDates_schedule()
{
var fromDate=document.getElementById('txtfrmdate').value;
var toDate=document.getElementById('txttodate1').value;
var splitChar="";
if(fromDate .indexOf ("/")>=0)
{
splitChar="/";
}
else if(fromDate .indexOf("-")>=0)
{
splitChar ="-";
}
else if(fromDate .indexOf(".")>=0)
{
splitChar =".";
}

var fromDateArray=fromDate .split(splitChar );
var toDateArray=toDate .split(splitChar);
if(document.getElementById('hiddendateformat').value="dd/mm/yyyy")
{
    var from_day=parseInt(fromDateArray [0],10);
    var from_month=parseInt (fromDateArray  [1],10);
    var from_year=parseInt (fromDateArray  [2],10);
    
    var to_day=parseInt(toDateArray [0],10);
    var to_month=parseInt(toDateArray [1],10);
    var to_year=parseInt(toDateArray [2],10);
}
else if(document.getElementById('hiddendateformat').value="mm/dd/yyyy")
{
    var from_day=parseInt(fromDateArray [1],10);
    var from_month=parseInt (fromDateArray  [0],10);
    var from_year=parseInt (fromDateArray  [2],10);

    var to_day=parseInt(toDateArray [1],10);
    var to_month=parseInt(toDateArray [0],10);
    var to_year=parseInt(toDateArray [2],10);

}
else if(document.getElementById('hiddendateformat').value="yyyy/mm/dd")
{
    var from_day=parseInt(fromDateArray [2],10);
    var from_month=parseInt (fromDateArray  [1],10);
    var from_year=parseInt (fromDateArray  [0],10);

    var to_day=parseInt(toDateArray [2],10);
    var to_month=parseInt(toDateArray [1],10);
    var to_year=parseInt(toDateArray [0],10);

}
    if(to_year >from_year )
    {
        return true;
    }
    else
    {
        if(to_year ==from_year && to_month >from_month)
        {
            return true;
        }
        else if(to_year ==from_year && to_month ==from_month && to_day >=from_day )
            {
                return true;
                
            }
        else
        {    
        alert("From Date should be less than To date.");
                document.getElementById('txtfrmdate').focus();
                return false;
        }
       
    }

}

////////////////////all ads agency//status based ad list

function allagency_f2()
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
    
    if(browser!="Microsoft Internet Explorer")
    alrt=document.getElementById('lbDateFrom').textContent;
    else
    alrt=document.getElementById('lbDateFrom').innerText;
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
   
   if(browser!="Microsoft Internet Explorer")
   alrt=document.getElementById('lbToDate').textContent;
   else
   alrt=document.getElementById('lbToDate').innerText;
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
        
        if(document.getElementById('dpagency').value!="")
{
if(document.getElementById('dpagency').value!=document.getElementById('hdnagencytxt').value)
{
alert("Press F2 To Bind a Valid Agency");
document.getElementById('dpagency').value=""
document.getElementById('dpagency').focus();
return false;
}
}
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
document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;
    
       var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
// var publicatnnam=document.getElementById('dppub1').options[document.getElementById('dppub1').selectedIndex].text;
// var ppubcent=document.getElementById('dppubcent').options[document.getElementById('dppubcent').selectedIndex].text;
// var adtnam=document.getElementById('dpdadtype').options[document.getElementById('dpdadtype').selectedIndex].text;
//var agnamety=document.getElementById('dpagtype').options[document.getElementById('dpagtype').selectedIndex].text;
// var chk_excel="";
// if (document.getElementById('Txtdest').value == "4")
//        {
//        if (document.getElementById('exe').checked == true)
//  chk_excel="1";
//  else
//  chk_excel="2";
//  }
//  else
//  chk_excel="0";
//var coid=document.getElementById("hiddencioid").value;
//var ascdec=document.getElementById("hiddenascdesc").value;
//var str2="true";
//var uomcod=document.getElementById("drpuom").value;
//var uomnam=document.getElementById('drpuom').options[document.getElementById('drpuom').selectedIndex].text;

// window.open("reportview2.aspx?agname=" + document.getElementById("hdnagency1").value + "&adtype=" + document.getElementById("dpdadtype").value+ "&adcategory=" + document.getElementById("hiddenadcat").value + "&fromdate=" + document.getElementById("txtfrmdate").value + "&dateto=" + document.getElementById("txttodate1").value + "&publication=" + document.getElementById("dppub1").value + "&pubcenter=" + document.getElementById("dppubcent").value + "&publicname=" + publicatnnam + "&publiccent=" + ppubcent + "&edition=" + document.getElementById("hiddenedition").value + "&destination=" + document.getElementById("Txtdest").value + "&adcatname=" + document.getElementById("hiddenadcatname").value + "&agencyname=" + document.getElementById("hdnagencytxt").value + "&adtypename=" + adtnam + "&editionname=" + document.getElementById("hiddeneditionname").value + "&agencysubcode=" + str2 + "&agtype=" + document.getElementById("dpagtype").value + "&agtypetext=" + adtnam + "&chk_excel=" + chk_excel+"&coid=" + coid+"&ascdec=" + ascdec+"&agnamety="+agnamety+"&uomcod="+uomcod+"&uomnam="+uomnam);

// return false;
    }
    
    ////////all ads client
    function allclient_f2()
    {
    var    newstr = "";
        var newstr1 = "";
        if(browser=="Microsoft Internet Explorer")
        {
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    }
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if(browser!="Microsoft Internet Explorer")
    alrt=document.getElementById('lbDateFrom').textContent;
     else
     alrt=document.getElementById('lbDateFrom').innerText;
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
   if(browser!="Microsoft Internet Explorer")
   alrt=document.getElementById('lbToDate').textContent;
   else
   alrt=document.getElementById('lbToDate').innerText; 
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
        if(document.getElementById('dpclient').value!="")
{
if(document.getElementById('dpclient').value!=document.getElementById('hdnclienttxt').value)
{
alert("Press F2 To Bind a Valid Client");
document.getElementById('dpclient').value=""
document.getElementById('dpclient').focus();
return false;
}
}
        
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
document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
document.getElementById('hdnuomcod').value=document.getElementById('drpuom').value;
 document.getElementById('hdnuomnam').value=document.getElementById('drpuom').options[document.getElementById('drpuom').selectedIndex].text;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;
    
       var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    }
    
    
    ///////deviation
    function deviation_f2()
    {
    var    newstr = "";
    var newstr1 = "";

    if (browser == "Microsoft Internet Explorer") {
        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        loadXML('xml/disschreg.xml');
    }
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;

    if (browser != "Microsoft Internet Explorer")
        alrt = document.getElementById('lbDateFrom').textContent;
    else
        alrt = document.getElementById('lbDateFrom').innerText;
        
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

    if (browser != "Microsoft Internet Explorer")
        alrt = document.getElementById('lbToDate').textContent;
    else
        alrt = document.getElementById('lbToDate').innerText;


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
        
        if(document.getElementById('dpagency').value!="")
{
if(document.getElementById('dpagency').value!=document.getElementById('hdnagencytxt').value)
{
alert("Press F2 To Bind a Valid Agency");
document.getElementById('dpagency').value=""
document.getElementById('dpagency').focus();
return false;
}
}
 if(document.getElementById('dpclient').value!="")
{
if(document.getElementById('dpclient').value!=document.getElementById('hdnclienttxt').value)
{
alert("Press F2 To Bind a Valid Client");
document.getElementById('dpclient').value=""
document.getElementById('dpclient').focus();
return false;
}
}
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
        
        
var status=document.getElementById('Dropdwnstatus').options[document.getElementById('Dropdwnstatus').selectedIndex].text;
document.getElementById('hiddenadcat').value=newstr;
document.getElementById('hiddenadcatname').value=newstr1;
document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;

document.getElementById('hdnuomcod').value=document.getElementById('drpuom').value;
 document.getElementById('hdnuomnam').value=document.getElementById('drpuom').options[document.getElementById('drpuom').selectedIndex].text;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;
    
       var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    }
    
function F2fillclientcr_allclient(event)
{
 var key = event.keyCode ? event.keyCode : event.which;
if(key==113)
{
divid = "div2";
            listboxid = "lstclient";
    txtbxid=eval(document.getElementById('dpclient'))
    txtboxid="dpclient";


    if(document.activeElement.id=="dpclient")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('dpclient').value.toUpperCase();
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=215+ "px" ;
            document.getElementById('div2').style.left=580+ "px";
            document.getElementById('lstclient').focus();
            agencyclient.fillF2_Creditclient(compcode,client,bindclient_callbackaa);
      }
 }

}
function F2fillclientcr_dev(event)
{
if(event.keyCode==113) {

    divid = "div2";
    listboxid = "lstclient";
    txtbxid = eval(document.getElementById('dpclient'))
    txtboxid = "dpclient";


    if(document.activeElement.id=="dpclient")
        {       
            //$('txtagency').value="";
            var compcode = document.getElementById('hdncompcode').value.toUpperCase();
            var client =document.getElementById('dpclient').value;
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=155+ "px" ;
            document.getElementById('div2').style.left=580+ "px";
            document.getElementById('lstclient').focus();
            Devationreport.fillF2_Creditclient(compcode,client,bindclient_callbackaa);
      }
 }

}
function F2fillclientcr_page(event)
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="dpclient")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('dpclient').value;
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=385+ "px" ;
            document.getElementById('div2').style.left=600+ "px";
            document.getElementById('lstclient').focus();
            pagepreviewreport.fillF2_Creditclient(compcode,client,bindclient_callbackaa);
      }
 }

}
function bindclient_callbackaa(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstclient");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Client Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name, ds_AccName.Tables[0].Rows[i].Cust_Code);
            pkgitem.options.length;
        }
    }

    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        txtbxid = eval(txtbxid.offsetParent);
        leftpos += txtbxid.offsetLeft;
        toppos += txtbxid.offsetTop;
        btag = eval(txtbxid)
    } while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
    var tot = document.getElementById('div2').scrollLeft;
    var scrolltop = document.getElementById('div2').scrollTop;
    document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; //"510px";



    document.getElementById("lstclient").value = "0";
    document.getElementById("div2").value = "";
    document.getElementById('lstclient').focus();

    return false;

}



function Clickclientaa(event)
{
    if(event.keyCode==13 || event.type=="click")
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
                if(document.getElementById('lstclient').options[k].value==page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstclient').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstclient').options[k].innerText;

                    }
                    document.getElementById('dpclient').value = abc;
                     document.getElementById('hdnclienttxt').value =abc;
                    document.getElementById('hdnclient1').value =page;
                    
                    document.getElementById("div2").style.display="none";
                    document.getElementById('dpclient').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('dpclient').focus();
         }
  }
  
  
  
  
  
  
 function eventcallingaa(event)
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


function chklstagencyaa()
  {
  if(document.activeElement.id=="lstagency" || document.activeElement.id=="dpagency")
  {
         if(event.keyCode==27)
        {
         if(document.getElementById("div1").style.display="block")
         {
          document.getElementById("div1").style.display="none";
          document.getElementById('dpagency').focus();
         }
       }
  }
   if(document.activeElement.id=="lstclient" || document.activeElement.id=="dpclient")
  {
         if(event.keyCode==27)
        {
         if(document.getElementById("div2").style.display="block")
         {
          document.getElementById("div2").style.display="none";
          document.getElementById('dpclient').focus();
         }
       }
  }
  
    if(document.activeElement.id=="lstexecutive" || document.activeElement.id=="dpexecutive")
  {
         if(event.keyCode==27)
        {
         if(document.getElementById("div3").style.display="block")
         {
          document.getElementById("div3").style.display="none";
          document.getElementById('dpexecutive').focus();
         }
       }
  }
  
    if(document.activeElement.id=="lstretainer" || document.activeElement.id=="dpretainer")
  {
         if(event.keyCode==27)
        {
         if(document.getElementById("div4").style.display="block")
         {
          document.getElementById("div4").style.display="none";
          document.getElementById('dpretainer').focus();
         }
       }
  }
         return false;
 }
         /////////////////////////////////////////////////////////////////
         
         
         
         
function F2fillagencycr_status(event)
{
if(event.keyCode==113)
{ divid = "div1";
           listboxid = "lstagency";
    txtbxid=eval(document.getElementById('dpagency'))
    txtboxid="dpagency";
    if(document.activeElement.id=="dpagency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('dpagency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=465+ "px" ;//314//290
            document.getElementById('div1').style.left=580+ "px";//395//1004
            document.getElementById('lstagency').focus();
            report3.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb);
      }
 }

}

function F2fillagencycr_dev(event)
{
if(event.keyCode==113) {
    divid = "div1";
    listboxid = "lstagency";
    txtbxid = eval(document.getElementById('dpagency'))
    txtboxid = "dpagency";

    if(document.activeElement.id=="dpagency")
        {       
            //$('txtagency').value="";
            var compcode = document.getElementById('hdncompcode').value.toUpperCase();
            var agn =document.getElementById('dpagency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=180+ "px" ;//314//290
            document.getElementById('div1').style.left=580+ "px";//395//1004
            document.getElementById('lstagency').focus();
            Devationreport.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb);
      }
 }

}

function F2fillagencycr_page(event)
{
if(event.keyCode==113) {
    divid = "div1";
    listboxid = "lstagency";
    txtbxid = eval(document.getElementById('dpagency'))
    txtboxid = "dpagency";
    if(document.activeElement.id=="dpagency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('dpagency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=310+ "px" ;//314//290
            document.getElementById('div1').style.left=480+ "px";//395//1004
            document.getElementById('lstagency').focus();
            pagepreviewreport.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb);
      }
 }

}
function bindAgency_callbackbb(res)
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
  
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     txtbxid = eval(txtbxid.offsetParent);
                     leftpos += txtbxid.offsetLeft;
                     toppos += txtbxid.offsetTop;
                     btag = eval(txtbxid)
                 } while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
                 var tot = document.getElementById('div1').scrollLeft;
                 var scrolltop = document.getElementById('div1').scrollTop;
                 document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
                 document.getElementById(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; //"510px";
        
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
   
        return false;

}


function ClickAgaencybb(event)
{
    if(event.keyCode==13 || event.type=="click")
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
                    document.getElementById('dpagency').value = abc;
                    document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hdnagency1').value =page;
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('dpagency').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('dpagency').focus();
         }
  }
  
  
  
  ///////////pagepremium report
  function pagepremnew_f2(event) {
      if (browser == "Microsoft Internet Explorer") {
          var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
          loadXML('xml/disschreg.xml');
      }
    
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        
        alrt = document.getElementById('lbDateFrom').innerText;
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

    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
      if(document.getElementById('dppub1').value=="0")
    {
    alert("Please Select Publication");
    document.getElementById('dppub1').focus();
    return false;
    }
    
     if(document.getElementById('dpagency').value!="")
{
if(document.getElementById('dpagency').value!=document.getElementById('hdnagencytxt').value)
{
alert("Press F2 To Bind a Valid Agency");
document.getElementById('dpagency').value=""
document.getElementById('dpagency').focus();
return false;
}
}
 if(document.getElementById('dpclient').value!="")
{
if(document.getElementById('dpclient').value!=document.getElementById('hdnclienttxt').value)
{
alert("Press F2 To Bind a Valid Client");
document.getElementById('dpclient').value=""
document.getElementById('dpclient').focus();
return false;
}
}
    
    document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;


  var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    } 
    
    
    
    
    
     function bindadcat_agency()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpdadtype').value;
report2.adcatbnd(adtype1,compcode,call_adcatbind_agency);
//billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
}
   
   function call_adcatbind_agency(response)
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
 var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpdadtype').value;
var center="";
 var res=report2.pkg_adcat_uom_bind(compcode, adtype1, center);
    ds=res.value;  
    var drpuom=document.getElementById("drpuom");  
 drpuom.options.length=0;
    drpuom.options[0]=new Option("--Select UOM--","0");
    if(ds!=null)
    {
    if(ds.Tables[1].Rows.length>0)
        {
            for (var i = 0  ; i < ds.Tables[1].Rows.length; ++i)
            {
                drpuom.options[drpuom.options.length] = new Option(ds.Tables[1].Rows[i].Uom_Name,ds.Tables[1].Rows[i].Uom_Code);
                drpuom.options.length;   
            }
        }
    }
       return false;
} 
    
    
    function bindadcat1()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpadtype').value;
availablepremium.adcatbnd(adtype1,compcode,call_adcatbind1);
//billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
}
    function bindadcat_schedule()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpaddtype').value;
ScheduleRegister.adcatbnd(adtype1,compcode,call_adcat_schedule);
ScheduleRegister.adpkg_bind(adtype1,compcode,call_pkg_schedule);
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








////////////////////////////////executive f2 for category wise report

function F2fillexecutivecr(event)
{
if(event.keyCode==113)
{
divid = "div3";
            listboxid = "lstexecutive";
    txtbxid=eval(document.getElementById('txt_executive'))
    txtboxid="txt_executive";
    if(document.activeElement.id=="txt_executive")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hiddencompcode').value;
             var executive =document.getElementById('txt_executive').value;
            document.getElementById("div3").style.display="block";
            document.getElementById('div3').style.top=366+ "px" ;
            document.getElementById('div3').style.left=500+ "px";
            document.getElementById('lstexecutive').focus();
            categorywisereport.fillF2_Creditexecutive(compcode,executive,bindexecutive_callbackreg);
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
         var   aTag = eval(document.getElementById('txt_executive'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('div3').scrollLeft;
                 var scrolltop = document.getElementById('div3').scrollTop;
                 document.getElementById('div3').style.left = document.getElementById('txt_executive').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div3').style.top = document.getElementById('txt_executive').offsetTop + toppos - scrolltop + "px"; //"510px";
        
        document.getElementById("lstexecutive").value="0";
        document.getElementById("div3").value="";
        document.getElementById('lstexecutive').focus();
   
        return false;

}

function bindexecutive_callbackreg(res)
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
        
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     txtbxid = eval(txtbxid.offsetParent);
                     leftpos += txtbxid.offsetLeft;
                     toppos += txtbxid.offsetTop;
                     btag = eval(txtbxid)
                 } while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
                 var tot = document.getElementById('div3').scrollLeft;
                 var scrolltop = document.getElementById('div3').scrollTop;
                 document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
                 document.getElementById(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; //"510px";
        
        
        document.getElementById("lstexecutive").value="0";
        document.getElementById("div3").value="";
        document.getElementById('lstexecutive').focus();
   
        return false;

}


function Clickexecutive(event)
{
    if(event.keyCode==13 || event.type=="click")
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
                if(document.getElementById('lstexecutive').options[k].value==page)
                {if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstexecutive').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstexecutive').options[k].innerText;

                    }
                    document.getElementById('txt_executive').value = abc;
                   
                    document.getElementById('hdnexecode').value =page;
                    document.getElementById('hdnexename').value =abc;
                    
                    document.getElementById("div3").style.display="none";
                    document.getElementById('txt_executive').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div3").style.display="none";
        document.getElementById('txt_executive').focus();
         }
  }
  //////////////run btn for category wise report
  function pivalidation_nn_cat(event)
{if (browser == "Microsoft Internet Explorer") {
        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        loadXML('xml/disschreg.xml');
    }
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;
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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
    
       var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
 
 if(document.getElementById('txt_executive').value=="")
 { 
 document.getElementById('hdnexecode').value=""
 document.getElementById('hdnexename').value=""
 }
 else if(document.getElementById('txt_executive').value!="" && document.getElementById('hdnexecode').value=="")
 { 
alert("Press F2 for executive name")
document.getElementById('txt_executive').value=""
document.getElementById('txt_executive').focus()
return false
 }
 else if(document.getElementById('txt_executive').value!="")
{
if(document.getElementById('txt_executive').value!=document.getElementById('hdnexename').value)
{
alert("Press F2 for executive name")
document.getElementById('txt_executive').value=""
document.getElementById('hdnexecode').value=""
document.getElementById('hdnexename').value=""
document.getElementById('txt_executive').focus();
return false;
}
selectvaluef2(event);
 }
 
 
    } 
      //////////////run btn for category wise report
  ////////////////////////////////////end of executive f2 for category wise report
  
  
  
  //////////////////agency f2 for money reprt
  
  
  
function F2fillagencycr_mon(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{  divid = "div1";
            listboxid = "lstagency";
    txtbxid=eval(document.getElementById('txt_agency'))
    txtboxid="txt_agency";
    if(document.activeElement.id=="txt_agency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn = document.getElementById('txt_agency').value.toUpperCase();
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=180+ "px" ;//314//290
            document.getElementById('div1').style.left=580+ "px";//395//1004
            document.getElementById('lstagency').focus();
            moneyrecievedreport.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb);
      }
 }

}


function ClickAgaency_mon(event) {
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

                    document.getElementById('hdnagency').value =page;
                    document.getElementById('hdnagencyname').value =abc;
                    
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
  
  ///////////////////////end of agency f2 for money report
  //////////////f2 for client
  
  
  
  
  function F2fillclientcr_mon(event) {
      var key = event.keyCode ? event.keyCode : event.which;
      if (key == 113)
{divid = "div2";
            listboxid = "lstclient";
    txtbxid=eval(document.getElementById('txt_client'))
    txtboxid="txt_client";


    if(document.activeElement.id=="txt_client")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('txt_client').value.toUpperCase();
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=155+ "px" ;
            document.getElementById('div2').style.left=580+ "px";
            document.getElementById('lstclient').focus();
            moneyrecievedreport.fillF2_Creditclient(compcode,client,bindclient_callbackaa);
      }
 }

}
  
  
  function Clickclient_mon(event)
{ var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
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
                {if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstclient').options[k].textContent;
                    }

                    else {
                        var abc = document.getElementById('lstclient').options[k].innerText;

                    }
                    document.getElementById('txt_client').value = abc;
                    
                    document.getElementById('hdnclient').value =page;
                    document.getElementById('hdnclientname').value =abc;
                    
                    document.getElementById("div2").style.display="none";
                    document.getElementById('txt_client').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('txt_client').focus();
         }
  }
  
  
  
  
  ///////////run
  
function pivalidation_mon(event) {
    if (browser == "Microsoft Internet Explorer") {
        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        loadXML('xml/disschreg.xml');
    }
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }

    else {
        alrt = document.getElementById('lbDateFrom').innerText;
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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
        
//         if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//        document.getElementById('txtfrmdate').value="";
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    }
    }
    
       var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
 
 
 if(document.getElementById('txt_agency').value=="")
 { 
 document.getElementById('hdnagency').value=""
  document.getElementById('hdnagencyname').value=""
 }
 else if(document.getElementById('txt_agency').value!="" && document.getElementById('hdnagency').value=="")
 { 
alert("Press F2 for agency name")
document.getElementById('txt_agency').value=""
document.getElementById('txt_agency').focus()
return false
 }
 else if(document.getElementById('txt_agency').value!="")
{
if(document.getElementById('txt_agency').value!=document.getElementById('hdnagencyname').value)
{
alert("Press F2 for agency name")
document.getElementById('txt_agency').value=""
document.getElementById('hdnagency').value=""
document.getElementById('hdnagencyname').value=""
document.getElementById('txt_agency').focus();
return false;
}
 
 }
 
  if(document.getElementById('txt_client').value=="")
 { 
 document.getElementById('hdnclient').value=""
  document.getElementById('hdnclientname').value=""
 }
 else if(document.getElementById('txt_client').value!="" && document.getElementById('hdnclient').value=="")
 { 
alert("Press F2 for client name")
document.getElementById('txt_client').value=""
document.getElementById('txt_client').focus()
return false
 }
  else if(document.getElementById('txt_client').value!="")
{
if(document.getElementById('txt_client').value!=document.getElementById('hdnclientname').value)
{
alert("Press F2 for client name")
document.getElementById('txt_client').value=""
document.getElementById('hdnclient').value=""
document.getElementById('hdnclientname').value=""
document.getElementById('txt_client').focus();
return false;
}
 
 }
 
 
    } 
    
  
  
  /////////////////f2 for client
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  //////////////f2 for retainer commission
  

function F2fillretainercr_ret(event)
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_retainer")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hiddencompcode').value;
            var retainer =document.getElementById('txt_retainer').value;
            document.getElementById("div4").style.display="block";
            document.getElementById('div4').style.top=430+ "px" ;
            document.getElementById('div4').style.left=500+ "px";
            document.getElementById('lstretainer').focus();
            Retaincom.fillF2_Creditretainer(compcode,retainer,bindretainer_callbackb);
      }
 }

}
function bindretainer_callbackb(res)
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


function Clickretainer_ret(event) {
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
                    
                    document.getElementById('hdnretainer').value =page;
                    document.getElementById('hdnretainername').value =abc;
                    
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
  /////////run
   function daily_summarized_ret()
    {if (browser == "Microsoft Internet Explorer") {
            var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
            loadXML('xml/disschreg.xml');
        }
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;
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
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbToDate').textContent;
    }
    else {
        alrt = document.getElementById('lbToDate').innerText;
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
   
    
    
    document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;

  var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
 
 
 if(document.getElementById('txt_retainer').value=="")
 { 
 document.getElementById('hdnretainer').value=""
  document.getElementById('hdnretainername').value=""
 }
 else if(document.getElementById('txt_retainer').value!="" && document.getElementById('hdnretainer').value=="")
 { 
alert("Press F2 for retainer name")
document.getElementById('txt_retainer').value=""
document.getElementById('txt_retainer').focus()
return false
 }
  
else if(document.getElementById('txt_retainer').value!="")
{
if(document.getElementById('txt_retainer').value!=document.getElementById('hdnretainername').value)
{
alert("Press F2 for retainer name")
document.getElementById('txt_retainer').value=""
document.getElementById('hdnretainer').value=""
document.getElementById('hdnretainername').value=""
document.getElementById('txt_retainer').focus();
return false;
}
 
 }
 
 
 
 
 
    }
  //prachi
  /////////////f2 for retainer comm
  
  
  //////////////f2 for rebate report
  function F2fillexecutivecr_reb(event)
{
var key = event.keyCode ? event.keyCode : event.which;
if(key==113)
{
    if(document.activeElement.id=="txt_executive")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hiddencompcode').value;
             var executive =document.getElementById('txt_executive').value;
            document.getElementById("div3").style.display="block";
            document.getElementById('div3').style.top=366+ "px" ;
            document.getElementById('div3').style.left=500+ "px";
            document.getElementById('lstexecutive').focus();
            valueReport.fillF2_Creditexecutive(compcode,executive,bindexecutive_callback);
      }
 }

}
function Clickexecutive_reb(event)
{
var key = event.keyCode ? event.keyCode : event.which;
    if(key==13 || event.type=="click")
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
                if(document.getElementById('lstexecutive').options[k].value==page)
                {
                if(browser!="Microsoft Internet Explorer")
                    var abc=document.getElementById('lstexecutive').options[k].textContent;
                    else
                    var abc=document.getElementById('lstexecutive').options[k].innerText;
                    document.getElementById('txt_executive').value = abc;
                   
                    document.getElementById('hdnexecode').value =page;
                    
                    document.getElementById('hdnexename').value =abc;
                    
                    document.getElementById("div3").style.display="none";
                    document.getElementById('txt_executive').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div3").style.display="none";
        document.getElementById('txt_executive').focus();
         }
  }
  
  //////////RUN REPORT
  
     function chkorder_nn_reb()
 {
 if(browser=="Microsoft Internet Explorer")
 {
 var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
  }
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    if(browser!="Microsoft Internet Explorer")
    alrt=document.getElementById('lbDateFrom').textContent;
    else
    alrt=document.getElementById('lbDateFrom').innerText;
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
   
   if(browser!="Microsoft Internet Explorer")
   alrt=document.getElementById('lbToDate').textContent;
   else
   alrt=document.getElementById('lbToDate').innerText;
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
  if(document.getElementById('dporderby').value=="0")
  {
  alert("Please Select Order By");
  document.getElementById('dporderby').focus();
  return false;
  
  }
  
  var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
 if(document.getElementById('txt_executive').value=="")
 { 
 document.getElementById('hdnexecode').value=""
  document.getElementById('hdnexename').value=""
 }
 else if(document.getElementById('txt_executive').value!="" && document.getElementById('hdnexecode').value=="")
 { 
alert("Press F2 for executive name")
document.getElementById('txt_executive').value=""
document.getElementById('txt_executive').focus()
return false
 }
  
else if(document.getElementById('txt_executive').value!="")
{
if(document.getElementById('txt_executive').value!=document.getElementById('hdnexename').value)
{
alert("Press F2 for executive name")
document.getElementById('txt_executive').value=""
document.getElementById('hdnexecode').value=""
document.getElementById('hdnexename').value=""
document.getElementById('txt_executive').focus();
return false;
}
 
 }
 
 }
  ////////////////////////////////////
  
  
  
  
  
  ////////////fr foe executive /retainer
  
function F2fillagencycr_exe(event) {

    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
   divid = "div1";
            listboxid = "lstagency";
    txtbxid=eval(document.getElementById('txt_agency'))
    txtboxid="txt_agency";
    if(document.activeElement.id=="txt_agency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('txt_agency').value.toUpperCase();
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=270+ "px" ;//314//290
            document.getElementById('div1').style.left=360+ "px";//395//1004
            document.getElementById('lstagency').focus();
            representative_ledger.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb1);
      }
 }
 else if (((key == 8) || (key == 46)) || (event.ctrlKey == true && key == 88)) 
    {

        if (document.activeElement.id == "txt_agency")
         {
            document.getElementById('txt_agency').value = "";
            document.getElementById('hdnagency').value = "";

            //saveagencycode = "";
            //saveagencyname = "";
            //savedpcdcode = "";


            return false;
        }
        return key;
    }

}
  function bindAgency_callbackbb1(res)
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
         var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        txtbxid = eval(txtbxid.offsetParent);
        leftpos += txtbxid.offsetLeft;
        toppos += txtbxid.offsetTop;
        btag = eval(txtbxid)
    } while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
    var tot = document.getElementById('div1').scrollLeft;
    var scrolltop = document.getElementById('div1').scrollTop;
    document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; //"510px";

        
        
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
   
        return false;

}

function ClickAgaency_exe(event)
{
    if(event.keyCode==13 || event.type=="click")
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
                {if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstagency').options[k].innerText;

                    }
                    document.getElementById('txt_agency').value = abc;

                    document.getElementById('hdnagency').value =page;
                    document.getElementById('hdnagencyname').value =abc;
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('txt_agency').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txt_agency').focus();
         }
  }
  
  ///////////////////////end of agency f2 for money report
  //////////////f2 for client
  
  
  
  
  function F2fillclientcr_exe(event) {
      var key = event.keyCode ? event.keyCode : event.which;
      if (key == 113)
{
   divid = "div2";
            listboxid = "lstclient";
    txtbxid=eval(document.getElementById('txt_client'))
    txtboxid="txt_client";
    if(document.activeElement.id=="txt_client")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('txt_client').value.toUpperCase();
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=295+ "px" ;
            document.getElementById('div2').style.left=355+ "px";
            document.getElementById('lstclient').focus();
            representative_ledger.fillF2_Creditclient(compcode,client,bindclient_callbackaa1);
      }
 }


 else if (((key == 8) || (key == 46)) || (event.ctrlKey == true && key == 88)) 
    {

        if (document.activeElement.id == "txt_client")
         {
            document.getElementById('txt_client').value = "";
            document.getElementById('hdnclient').value = "";

            //saveagencycode = "";
            //saveagencyname = "";
            //savedpcdcode = "";


            return false;
        }
        return key;
    }

}
  
  function bindclient_callbackaa1(res)
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
        
        var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        txtbxid = eval(txtbxid.offsetParent);
        leftpos += txtbxid.offsetLeft;
        toppos += txtbxid.offsetTop;
        btag = eval(txtbxid)
    } while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
    var tot = document.getElementById('div2').scrollLeft;
    var scrolltop = document.getElementById('div2').scrollTop;
    document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; //"510px";

        
        document.getElementById("lstclient").value="0";
        document.getElementById("div2").value="";
        document.getElementById('lstclient').focus();
   
        return false;

}


  function Clickclient_exe(event)
{
    if(event.keyCode==13 || event.type=="click")
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
                {if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstclient').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstclient').options[k].innerText;

                    }
                    document.getElementById('txt_client').value = abc;
                    
                    document.getElementById('hdnclient').value =page;
                    document.getElementById('hdnclientname').value =abc;
                    document.getElementById("div2").style.display="none";
                    document.getElementById('txt_client').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('txt_client').focus();
         }
  }


  function F2fillretainercr_exe(event) {

      var key = event.keyCode ? event.keyCode : event.which;
      
      if (key == 113) {
      
      divid = "div4";
            listboxid = "lstretainer";
    txtbxid=eval(document.getElementById('txt_retainer'))
    txtboxid="txt_retainer";
   
      
          
    if(document.activeElement.id=="txt_retainer")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hiddencompcode').value;
            var retainer =document.getElementById('txt_retainer').value;
            document.getElementById("div4").style.display="block";
            document.getElementById('div4').style.top=365+ "px" ;
            document.getElementById('div4').style.left=355+ "px";
            document.getElementById('lstretainer').focus();
            representative_ledger.fillF2_Creditretainer(compcode,retainer,bindretainer_callbackb5);
      }
 }

}
function bindretainer_callbackb5(res)
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
        
        var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        txtbxid = eval(txtbxid.offsetParent);
        leftpos += txtbxid.offsetLeft;
        toppos += txtbxid.offsetTop;
        btag = eval(txtbxid)
    } while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
    var tot = document.getElementById('div4').scrollLeft;
    var scrolltop = document.getElementById('div4').scrollTop;
    document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; //"510px";

        
        document.getElementById("lstretainer").value="0";
        document.getElementById("div4").value="";
        document.getElementById('lstretainer').focus();
   
        return false;

}


function Clickretainer_exe(event)
{
    if(event.keyCode==13 || event.type=="click")
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
                if(document.getElementById('lstretainer').options[k].value==page)
                {if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstretainer').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstretainer').options[k].innerText;

                    }
                    document.getElementById('txt_retainer').value = abc;
                    
                    document.getElementById('hdnretainer').value =page;
                    document.getElementById('hdnretainername').value =abc;
                    
                    document.getElementById("div4").style.display="none";
                    document.getElementById('txt_retainer').focus();
                     return false; 
                    
                }
               
            }
          
        
        }
        
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div4").style.display="none";
        document.getElementById('txt_retainer').focus();
        return false;
         }
  }
  
function runclickbarter_exe()
{
var newstr="";
var newstr1="";
if(browser=="Microsoft Internet Explorer")
{
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/categoryreport.xml');
}
    var abc= document.getElementById('txttodate1').value
    var abc1= document.getElementById('txtfrmdate').value
    var abc2= document.getElementById('dpteam').value
    var alrt;

if(browser!="Microsoft Internet Explorer")
    alrt=document.getElementById('lbDateFrom').textContent;
    else
    alrt=document.getElementById('lbDateFrom').innerText;
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

if(browser!="Microsoft Internet Explorer")
    alrt=document.getElementById('lbToDate').textContent;
    else
    alrt=document.getElementById('lbToDate').innerText;
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

   

    document.getElementById('hiddenexecutive').value=document.getElementById('dpexec').value;
    var des1=document.getElementById('dpexec').options.selectedIndex;
   if(des1!=-1)
    document.getElementById('hiddenexecutivename').value=document.getElementById('dpexec').options[des1].text;

     var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    
    
 if(document.getElementById('txt_agency').value=="")
 { 
 document.getElementById('hdnagency').value=""
 document.getElementById('hdnagencyname').value=""
 }
 else if(document.getElementById('txt_agency').value!="" && document.getElementById('hdnagency').value=="")
 { 
alert("Press F2 for agency name")
document.getElementById('txt_agency').value=""
document.getElementById('txt_agency').focus()
return false
 }
  else if(document.getElementById('txt_agency').value!="")
{
if(document.getElementById('txt_agency').value!=document.getElementById('hdnagencyname').value)
{
alert("Press F2 for agency name")
document.getElementById('txt_agency').value=""
document.getElementById('hdnagency').value=""
document.getElementById('hdnagencyname').value=""
document.getElementById('txt_agency').focus();
return false;
}
 
 }
 
  if(document.getElementById('txt_client').value=="")
 { 
 document.getElementById('hdnclient').value=""
 document.getElementById('hdnclientname').value=""
 }
 else if(document.getElementById('txt_client').value!="" && document.getElementById('hdnclient').value=="")
 { 
alert("Press F2 for client name")
document.getElementById('txt_client').value=""
document.getElementById('txt_client').focus()
return false
 }
 else if(document.getElementById('txt_client').value!="")
{
if(document.getElementById('txt_client').value!=document.getElementById('hdnclientname').value)
{
alert("Press F2 for client name")
document.getElementById('txt_client').value=""
document.getElementById('hdnclient').value=""
document.getElementById('hdnclientname').value=""
document.getElementById('txt_client').focus();
return false;
}
 
 }
 
  if(document.getElementById('txt_retainer').value=="")
 { 
 document.getElementById('hdnretainer').value=""
  document.getElementById('hdnretainername').value=""
 }
 else if(document.getElementById('txt_retainer').value!="" && document.getElementById('hdnretainer').value=="")
 { 
alert("Press F2 for retainer name")
document.getElementById('txt_retainer').value=""
document.getElementById('txt_retainer').focus()
return false
 }
  
else if(document.getElementById('txt_retainer').value!="")
{
if(document.getElementById('txt_retainer').value!=document.getElementById('hdnretainername').value)
{
alert("Press F2 for retainer name")
document.getElementById('txt_retainer').value=""
document.getElementById('hdnretainer').value=""
document.getElementById('hdnretainername').value=""
document.getElementById('txt_retainer').focus();
return false;
}
 
 }
 
    
}



/////////////f2 bil register
function F2fillexecutivecr_bill(event)
{
if(event.keyCode==113)
{divid = "div3";
            listboxid = "lstexecutive";
    txtbxid=eval(document.getElementById('txt_executive'))
    txtboxid="txt_executive";
    if(document.activeElement.id=="txt_executive")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hiddencompcode').value;
             var executive =document.getElementById('txt_executive').value;
            document.getElementById("div3").style.display="block";
            document.getElementById('div3').style.top=366+ "px" ;
            document.getElementById('div3').style.left=500+ "px";
            document.getElementById('lstexecutive').focus();
            BillRegister.fillF2_Creditexecutive(compcode,executive,bindexecutive_callbackreg);
      }
 }

}
function Clickexecutive_bill(event)
{
    if(event.keyCode==13 || event.type=="click")
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
                if(document.getElementById('lstexecutive').options[k].value==page)
                {if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstexecutive').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstexecutive').options[k].innerText;

                    }
                    document.getElementById('txt_executive').value = abc;
                   
                    document.getElementById('hdnexecode').value =page;
                    
                    document.getElementById('hdnexename').value =abc;
                    
                    document.getElementById("div3").style.display="none";
                    document.getElementById('txt_executive').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div3").style.display="none";
        document.getElementById('txt_executive').focus();
         }
  }
  
  
  
  ///////runreport
   function daily_summarized_bill()
    {
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    
    alrt=document.getElementById('lbDateFrom').innerText;
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
   
   alrt=document.getElementById('lbToDate').innerText;
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
   
    
    
    document.getElementById('hiddenedition').value=document.getElementById('dpedition').value;
 var des=document.getElementById('dpedition').options.selectedIndex;
  if(des!=-1)
    document.getElementById('hiddeneditionname').value=document.getElementById('dpedition').options[des].text;

  var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
 if(document.getElementById('txt_executive').value=="")
 { 
 document.getElementById('hdnexecode').value=""
  document.getElementById('hdnexename').value=""
 }
 else if(document.getElementById('txt_executive').value!="" && document.getElementById('hdnexecode').value=="")
 { 
alert("Press F2 for executive name")
document.getElementById('txt_executive').value=""
document.getElementById('txt_executive').focus()
return false
 }
  
else if(document.getElementById('txt_executive').value!="")
{
if(document.getElementById('txt_executive').value!=document.getElementById('hdnexename').value)
{
alert("Press F2 for executive name")
document.getElementById('txt_executive').value=""
document.getElementById('hdnexecode').value=""
document.getElementById('hdnexename').value=""
document.getElementById('txt_executive').focus();
return false;
}
 
 }
 
    }
    
    
    
    /////////////////////f2 pi contract
    
function F2fillagencycr_picon(event)
{
 var key = event.keyCode ? event.keyCode : event.which;
if(key==113)
{
    if(document.activeElement.id=="txt_agency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('txt_agency').value.toUpperCase();
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=205+ "px" ;//314//290
            document.getElementById('div1').style.left=500+ "px";//395//1004
            document.getElementById('lstagency').focus();
            picontractreport.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb9);
      }
 }

}
  function bindAgency_callbackbb9(res)
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
  
function ClickAgaency_picon(event)
{
 var key = event.keyCode ? event.keyCode : event.which;
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
                    var abc=document.getElementById('lstagency').options[k].textContent;
                    else
                    var abc=document.getElementById('lstagency').options[k].innerText;
                    document.getElementById('txt_agency').value = abc;

                    document.getElementById('hdnagency').value =page;
                    document.getElementById('hdnagencyname').value =abc;
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('txt_agency').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(key==27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txt_agency').focus();
         }
  }
  
  ///////////////////////end of agency f2 for money report
  //////////////f2 for client
  
  
  
  
  function F2fillclientcr_picon(event)
{ var key = event.keyCode ? event.keyCode : event.which;

if(key==113)
{
    if(document.activeElement.id=="txt_client")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('txt_client').value.toUpperCase();
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=220+ "px" ;
            document.getElementById('div2').style.left=500+ "px";
            document.getElementById('lstclient').focus();
            picontractreport.fillF2_Creditclient(compcode,client,bindclient_callbackaa9);
      }
 }

}
  
  function bindclient_callbackaa9(res)
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


  function Clickclient_picon(event)
{
var key = event.keyCode ? event.keyCode : event.which;
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
                    var abc=document.getElementById('lstclient').options[k].textContent;
                    else
                    var abc=document.getElementById('lstclient').options[k].innerText;
                    document.getElementById('txt_client').value = abc;
                    
                    document.getElementById('hdnclient').value =page;
                    document.getElementById('hdnclientname').value =abc;
                    document.getElementById("div2").style.display="none";
                    document.getElementById('txt_client').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(key==27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('txt_client').focus();
         }
  }
  
  
  function allads_nn_picon()
    {
    var    newstr = "";
        var newstr1 = "";
        if(browser=="Microsoft Internet Explorer")
        {
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    }
    
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    
     if(browser!="Microsoft Internet Explorer")
     alrt=document.getElementById('lbDateFrom').textContent;
     else
    alrt=document.getElementById('lbDateFrom').innerText;
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
   if(browser!="Microsoft Internet Explorer")
   alrt=document.getElementById('lbToDate').textContent;
   else
   alrt=document.getElementById('lbToDate').innerText;
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
        

        
        

     var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
 
 if(document.getElementById('txt_agency').value=="")
 { 
 document.getElementById('hdnagency').value=""
 document.getElementById('hdnagencyname').value=""
 }
 else if(document.getElementById('txt_agency').value!="" && document.getElementById('hdnagency').value=="")
 { 
alert("Press F2 for agency name")
document.getElementById('txt_agency').value=""
document.getElementById('txt_agency').focus()
return false
 }
  else if(document.getElementById('txt_agency').value!="")
{
if(document.getElementById('txt_agency').value!=document.getElementById('hdnagencyname').value)
{
alert("Press F2 for agency name")
document.getElementById('txt_agency').value=""
document.getElementById('hdnagency').value=""
document.getElementById('hdnagencyname').value=""
document.getElementById('txt_agency').focus();
return false;
}
 
 }
 
  if(document.getElementById('txt_client').value=="")
 { 
 document.getElementById('hdnclient').value=""
 document.getElementById('hdnclientname').value=""
 }
 else if(document.getElementById('txt_client').value!="" && document.getElementById('hdnclient').value=="")
 { 
alert("Press F2 for client name")
document.getElementById('txt_client').value=""
document.getElementById('txt_client').focus()
return false
 }
 else if(document.getElementById('txt_client').value!="")
{
if(document.getElementById('txt_client').value!=document.getElementById('hdnclientname').value)
{
alert("Press F2 for client name")
document.getElementById('txt_client').value=""
document.getElementById('hdnclient').value=""
document.getElementById('hdnclientname').value=""
document.getElementById('txt_client').focus();
return false;
}
 
 }
 
    }



    function selectvaluef2(event)
    {
        if(document.getElementById('hdnexecode').value!="")     
    {
        alert('Please Select Executive name using F2.')
        document.getElementById('txt_executive').value="";
        document.getElementById('txt_executive').focus();
        return false;
    }
    }
    
      function selectvalueagency()
    {
        if(document.getElementById('hdnagency').value!="")     
    {
        alert('Please Select Agency name using F2.')
        document.getElementById('txt_agency').value="";
        document.getElementById('txt_agency').focus();
        return false;
    }
    }
    
    
    
      function selectvalueclient()
    {
        if(document.getElementById('hdnclient').value!="")     
    {
        alert('Please Select Client name using F2.')
        document.getElementById('txt_client').value="";
        document.getElementById('txt_client').focus();
        return false;
    }
}


function F2fillclientcr() {
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtclient") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hiddencompcode').value;
            var client = document.getElementById('txtclient').value;
            document.getElementById("div2").style.display = "block";
            document.getElementById('div2').style.top = 325 + "px";
            document.getElementById('div2').style.left = 278 + "px";
            document.getElementById('lstclintf2').focus();
            BillRegister.fillF2_client(compcode, client, bindclient_callback);
        }
    }

}

function bindclient_callback(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstclintf2");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Client Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name, ds_AccName.Tables[0].Rows[i].Cust_Code);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstclintf2").value = "0";
    document.getElementById("div2").value = "";
    document.getElementById('lstclintf2').focus();

    return false;

}


function Clickclient() {
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstclintf2") {
            if (document.getElementById('lstclintf2').value == "0") {
                alert("Please select Client Name");
                return false;
            }

            var page = document.getElementById('lstclintf2').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstclintf2').length - 1; k++) {
                if (document.getElementById('lstclintf2').options[k].value == page) {
                    var abc = document.getElementById('lstclintf2').options[k].innerText;
                    document.getElementById('txtclient').value = abc;
                    //document.getElementById('hdnclienttxt').value = abc;
                    document.getElementById('hdnclntcode').value = page;

                    document.getElementById("div2").style.display = "none";
                    document.getElementById('txtclient').focus();
                    return false;

                }
            }
        }
    }
    else if (event.keyCode == 27) {

        document.getElementById("div2").style.display = "none";
        document.getElementById('txtclient').focus();
    }
}





function F2fillagencycr(event) {
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtage") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hiddencompcode').value;
            var agn = document.getElementById('txtage').value;
            document.getElementById("div1").style.display = "block";
            document.getElementById('div1').style.top = 350 + "px"; //314//290
            document.getElementById('div1').style.left = 278 + "px"; //395//1004
            document.getElementById('lstagencyf2').focus();
            BillRegister.fillF2_Agency(compcode, agn, bindAgency_callback);
        }
    }

}



function bindAgency_callback(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstagencyf2");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name, ds_AccName.Tables[0].Rows[i].Agency_Code);
            pkgitem.options.length;
        }
    }
    
    var   aTag = eval(document.getElementById('txtage'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('div1').scrollLeft;
                 var scrolltop = document.getElementById('div1').scrollTop;
                 document.getElementById('div1').style.left = document.getElementById('txtage').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div1').style.top = document.getElementById('txtage').offsetTop + toppos - scrolltop + "px"; //"510px";
        
    
    document.getElementById("lstagencyf2").value = "0";
    document.getElementById("div1").value = "";
    document.getElementById('lstagencyf2').focus();

    return false;

}



function ClickAgaency(event) {
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstagencyf2") {
            if (document.getElementById('lstagencyf2').value == "0") {
                alert("Please select Agency Name");
                return false;
            }

            var page = document.getElementById('lstagencyf2').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstagencyf2').length - 1; k++) {
                if (document.getElementById('lstagencyf2').options[k].value == page) {

                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstagencyf2').options[k].textContent;
                    }

                    else {
                        var abc = document.getElementById('lstagencyf2').options[k].innerText;
                    }
                    document.getElementById('txtage').value = abc;
//                    document.getElementById('hdnagencytxt').value = abc;
                      document.getElementById('hdnagncode').value = page;

                    document.getElementById("div1").style.display = "none";
                    document.getElementById('txtage').focus();
                    return false;

                }
            }
        }
    }
    else if (event.keyCode == 27) {

        document.getElementById("div1").style.display = "none";
        //document.getElementById('txtage').focus();
    }
}

function clearpagepremium() {

if (browser != "Microsoft Internet Explorer") {
        event.keyCode = 116

    }
    if (event.keyCode == 116) {
    document.getElementById('dppage').value = "0";
    document.getElementById('dpposition').value = "0";
    document.getElementById('txtfrmdate').value = "";
    document.getElementById('txttodate1').value ="";
    document.getElementById('dppub1').value = "0";
    document.getElementById('dppubcent').value = "0";
    document.getElementById('dpedition').value = "0";
    document.getElementById('dpcategory').value = "0";
    document.getElementById('dpagency').value = "";
    document.getElementById('dpclient').value = "";
    document.getElementById('dpagtype').value = "0";
    document.getElementById('Txtdest').value = "0";
    document.getElementById('dppage').focus();
}
return false;
} 


function clearallclient() {
//    document.getElementById('dpclient').value = "";
//    document.getElementById('dpdadtype').value = "0";
//    document.getElementById('dpadcatgory').value = "0";
//    document.getElementById('txtfrmdate').value = "";
//    document.getElementById('txttodate1').value = "";
//    document.getElementById('dppub1').value = "0";
//    document.getElementById('dppubcent').value = "0";
//    document.getElementById('dpedition').value = "0";
//    document.getElementById('dpagtype').value = "0";
//    document.getElementById('Txtdest').value = "0";
//    document.getElementById('dpclient').focus();
    //document.getElementById('dpagtype').value = "0";
}


function clearrevenue() {
    document.getElementById('txtfrmdate').value = "";
    document.getElementById('txttodate1').value = "";
    document.getElementById('dpdadtype').value = "0";
    document.getElementById('dppub1').value = "0";
    //document.getElementById('dppubcent').value = "0";
    document.getElementById('dpedition').value = "0";
    document.getElementById('txtfrmdate').focus();

}


function clearretainerwise() {
//    document.getElementById('txtfrmdate').value = "";
//    document.getElementById('txttodate1').value = "";
//    document.getElementById('txt_agency').value = "";
//    document.getElementById('txt_client').value = "";
//    document.getElementById('dppub1').value = "0";
//    document.getElementById('dppubcent').value = "0";
//  
//    //document.getElementById('txtbill').value = "0";
//  
//    document.getElementById('retainerwise').value = "0";
//    document.getElementById('txt_retainer').value = "";
//    document.getElementById('dpd_branch').value = "";
//    document.getElementById('txtdistrict').value = "";
//    
//    document.getElementById('dpexec').value = "0";
//    document.getElementById('dpteam').value = "0";
//    document.getElementById('dpaddtype').value = "0";
//  
//    document.getElementById('Txtdest').value = "0";
//    document.getElementById('txtfrmdate').focus();
}



function clearbillregister() {
//if(event.keyCode==116)
//{
   // document.getElementById('txtfrmdate').value = "";

   // alert(document.getElementById('txtfrmdate').value);
    document.getElementById('txttodate1').value = "";
    document.getElementById('dppub1').value = "0";
   // document.getElementById('dppubcent').value = "0";
    document.getElementById('dpedition').value = "0";
    document.getElementById('dpregion').value = "0";

    document.getElementById('dpcategory').value = "0";

    document.getElementById('dpagtype').value = "0";
    document.getElementById('dpagcat').value = "0";
    document.getElementById('txt_executive').value = "";
    document.getElementById('txtage').value = "";

    document.getElementById('txtclient').value = "0";
    document.getElementById('Txtdest').value = "0";
    document.getElementById('drpbreak').value = "0";
    document.getElementById('ddldistrict').value = "0";

    document.getElementById('txtfrmdate').focus();
    return false;
    
//}
}


function clearmoneyreport() {
//if(event.keyCode==116)
//{
    document.getElementById('txt_agency').value = "";
    document.getElementById('txt_client').value = "";
    document.getElementById('txtfrmdate').value = "";
    document.getElementById('txttodate1').value = "";
    document.getElementById('drpadtype').value = "0";
    document.getElementById('drpuserid').value = "0";
    document.getElementById('drppaymode').value = "0";
   // document.getElementById('dppubcent').value = "0";
   // document.getElementById('dpbranch').value = "0";
    document.getElementById('Txtdest').value = "0";
    document.getElementById('txtfrmdate').focus();
// }   
    }

    function clearreport2() {
    
    document.getElementById('dpagency').focus();
    
//    if(event.keyCode==116)
//    {
//        document.getElementById('dpagency').value = "";
//        document.getElementById('dpdadtype').value = "0";
//        document.getElementById('dpadcatgory').value = "0";
//        document.getElementById('txtfrmdate').value = "";
//        document.getElementById('txttodate1').value = "";
//        document.getElementById('dppub1').value = "0";
//        document.getElementById('dppubcent').value = "0";
//        document.getElementById('dpedition').value = "0";
//        document.getElementById('dpagtype').value = "0";
//        document.getElementById('Txtdest').value = "0";
//        document.getElementById('dpagency').focus();
//}
    }


    function clearavailable() {
        if (event.keyCode == 116) {
            document.getElementById('dppage').value = "0";
            document.getElementById('dpposition').value = "0";
            document.getElementById('dppub1').value = "0";
            document.getElementById('txtfrmdate').value = "";
            document.getElementById('txttodate1').value = "";
           // document.getElementById('dppubcent').value = "0";
            document.getElementById('dpedition').value = "0";
            document.getElementById('dppageno').value = "0";
            document.getElementById('dpadtype').value = "0";
            document.getElementById('dpadcat').value = "0";
            document.getElementById('Txtdest').value = "0";
            document.getElementById('dppage').focus();
        }
        return false;
       }
  function uombind()
    {
    
var comp_code=document.getElementById('hiddencompcode').value;
 var adtype=document.getElementById('dpdadtype').value;
 var uomdesc="";
    report.uom_bind(comp_code,adtype,uomdesc,call_bind_uom); 
 
    }
    function uombind1()
    {
    
var comp_code=document.getElementById('hiddencompcode').value;
 var adtype=document.getElementById('dpdadtype').value;
 var uomdesc="";
    report2.uom_bind(comp_code,adtype,uomdesc,call_bind_uom); 
 
    }
         function uombind2()
    {
    
var comp_code=document.getElementById('hiddencompcode').value;
 var adtype=document.getElementById('dpdadtype').value;
 var uomdesc="";
    agencyclient.uom_bind(comp_code,adtype,uomdesc,call_bind_uom); 
 
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
            //   document.getElementById("hiddenuom").value= ds.Tables[0].Rows[i].Uom_Code; 
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




function bindclient_pageprem(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstclient");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Client Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name, ds_AccName.Tables[0].Rows[i].Cust_Code);
            pkgitem.options.length;
        }
    }
    aTag = eval(document.getElementById("dpclient"))
    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById('div1').scrollLeft;
    var scrolltop = document.getElementById('div1').scrollTop;
    document.getElementById("div2").style.left = document.getElementById("dpclient").offsetLeft + leftpos - tot + "px";
    document.getElementById("div2").style.top = document.getElementById("dpclient").offsetTop + toppos - scrolltop + "px"; //"510px";



    document.getElementById("lstclient").value = "0";
    document.getElementById("div2").value = "";
    document.getElementById('lstclient').focus();

    return false;

}

function F2fillclientcr_pageprem(event) {
    if (event.keyCode == 113) {
        if (document.activeElement.id == "dpclient") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hdncompcode').value;
            var client = document.getElementById('dpclient').value;
            document.getElementById("div2").style.display = "block";
            document.getElementById('div2').style.top = 385 + "px";
            document.getElementById('div2').style.left = 600 + "px";
            document.getElementById('lstclient').focus();
            pagepreviewreport.fillF2_Creditclient(compcode, client, bindclient_pageprem);
        }
    }

}


function tabvaluesumrisrepo(event)
{
  var key = event.keyCode ? event.keyCode : event.which;
//alert(key)

if(key==13)
{
//if(document.activeElement.id==id)
//{
//    if(document.getElementById('btnSave').disabled==false)
//    {
//document.getElementById('btnSave').focus();
//    }
//return;

//}
//else 
if(document.activeElement.type=="button" || document.activeElement.type=="submit")
{
key=13;
return key;

}
else
{
//alert(event.keyCode);
key=9;
//alert(event.keyCode);
return key;
}
}

if(key==116)
{
window.open ('summarized_report.aspx','_self','',false)
return false;
}


}


function clearexereport() {

    
    if (event.keyCode == 116) {
        document.getElementById('dppub1').value = "0";
       // document.getElementById('dppubcent').value = "0";
        document.getElementById('dpedition').value = "0";
        document.getElementById('txtfrmdate').value = "";
        document.getElementById('txttodate1').value = "";
        document.getElementById('dpdadtype').value = "0";
        document.getElementById('dpadcatgory').value = "0";
        document.getElementById('dpteam').value = "0";
        document.getElementById('dpexec').value = "0";
        document.getElementById('Txtdest').value = "0";
        document.getElementById('txtfrmdate').focus();
    }
    return false;   
}

function tabvaluerebaterepo(event)
{

  var key = event.keyCode ? event.keyCode : event.which;
//alert(key)

if(key==13)
{
//if(document.activeElement.id==id)
//{
//    if(document.getElementById('btnSave').disabled==false)
//    {
//document.getElementById('btnSave').focus();
//    }
//return;

//}
//else 
if(document.activeElement.type=="button" || document.activeElement.type=="submit")
{
key=13;
return key;

}
else
{
//alert(event.keyCode);
key=9;
//alert(event.keyCode);
return key;
}
}

if(key==116)
{

window.open ('valueReport.aspx','_self','',false)
return false;
}


}


function clearcategorywise(event) {

    if (browser != "Microsoft Internet Explorer") {
        event.keyCode = 116
       
    }
    if (event.keyCode == 116) {
   
        document.getElementById('dppub1').value = "0";
        document.getElementById('dppubcent').value = "0";
        document.getElementById('dpadtype').value = "0";
        document.getElementById('txtfrmdate').value = "";
        document.getElementById('txttodate1').value = "";
        document.getElementById('dpregion').value = "0";
        document.getElementById('dpplace').value = "0";
        document.getElementById('dpagcat').value = "0";
        document.getElementById('dppage').value = "0";
        document.getElementById('txt_executive').value = "";
        document.getElementById('Txtdest').value = "0";
        //document.getElementById('dpedition').value = "0";
        document.getElementById('txtfrmdate').focus();

    }
    return false;
} 



function tabvaluepipro(event)
{

  var key = event.keyCode ? event.keyCode : event.which;
//alert(key)

if(key==13)
{
//if(document.activeElement.id==id)
//{
//    if(document.getElementById('btnSave').disabled==false)
//    {
//document.getElementById('btnSave').focus();
//    }
//return;

//}
//else 
if(document.activeElement.type=="button" || document.activeElement.type=="submit")
{
key=13;
return key;

}
else
{
//alert(event.keyCode);
key=9;
//alert(event.keyCode);
return key;
}
}

if(key==116)
{

window.open ('piproduct.aspx','_self','',false)
return false;
}


}


function tabvalueisuebusi(event)
{

  var key = event.keyCode ? event.keyCode : event.which;
//alert(key)
if(key==13)
{
//if(document.activeElement.id==id)
//{
//    if(document.getElementById('btnSave').disabled==false)
//    {
//document.getElementById('btnSave').focus();
//    }
//return;

//}
//else 
if(document.activeElement.type=="button" || document.activeElement.type=="submit")
{

key=13;
return key;

}
if(document.activeElement.id=="Drppubcent")
{
document.getElementById("drpbasedon").focus();
return false;

}

if(document.activeElement.id=="drpbasedon")
{
document.getElementById("dpd_ratiotyp").focus();
return false;

}
if(document.activeElement.id=="dpd_ratiotyp")
{
document.getElementById("drpreporttype").focus();
return false;

}

if(document.activeElement.id=="drpreporttype")
{
document.getElementById("Txtdest").focus();
return false;

}
if(document.activeElement.id=="Txtdest")
{
document.getElementById("btnRun").focus();
return false;

}
if(document.activeElement.id=="txtfrmdate")
{
document.getElementById("txttodate1").focus();
return false;

}
if(document.activeElement.id=="txttodate1")
{
document.getElementById("Drppubcent").focus();
return false;

}

//else
//{
////alert(event.keyCode);
//key=9;
////alert(event.keyCode);
//return key;
//}
}

if(key==116)
{

window.open ('issuewisereport.aspx','_self','',false)
return false;
}



}

function F2filldistrict(event)
{

var key=event.keyCode?event.keyCode:event.which;
if(key==113)
{


    if(document.activeElement.id=="txtdistrict")
        {      
            var compcode =document.getElementById('hdncompcode').value;
             var uid =document.getElementById('hiddenuseid').value;
            document.getElementById("divdistrict").style.display="block";
            document.getElementById('divdistrict').style.top=395+ "px" ;
            document.getElementById('divdistrict').style.left=775+ "px";
            document.getElementById('lstdistrict').focus();
            representative_ledger.fillF2_Creditexecutive(compcode,uid,F2filldistrict_callback);
           // return false;
      }
      }
      
      
      
      
else if(event.keyCode==8 || event.keyCode==46)
    {
    document.getElementById('txtdistrict').value = "";
//    saveagencycode = "";
//    saveagencyname = "";
//    savedpcdcode = "";
    document.getElementById('hidden_dist').value = "";
    //$('Hiddenagencysubcode').value =""

    return false;
    }

    else if(event.ctrlKey==true && event.keyCode==88)
    {
    document.getElementById('txtdistrict').value = "";

//    saveagencycode = "";
//    saveagencyname = "";
//    savedpcdcode = "";
//        $('Hiddenagencycode').value = "";
    document.getElementById('hidden_dist').value ="";
    return false;
    }
    }

function F2filldistrict_callback(res)
{
     var ds_AccName=res.value;
      
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0)
        {
            var pkgitem = document.getElementById("lstdistrict");
            pkgitem.options.length = 0;
            pkgitem.options[0]=new Option("-Select District-","0");
            pkgitem.options.length = 1;
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Dist_Name+"`"+ds_AccName.Tables[0].Rows[i].Dist_Code,ds_AccName.Tables[0].Rows[i].Dist_Code);        
                pkgitem.options.length;
            }
        }
        
         var   aTag = eval(document.getElementById('txtdistrict'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('divdistrict').scrollLeft;
                 var scrolltop = document.getElementById('divdistrict').scrollTop;
                 document.getElementById('divdistrict').style.left = document.getElementById('txtdistrict').offsetLeft + leftpos - tot + "px";
                 document.getElementById('divdistrict').style.top = document.getElementById('txtdistrict').offsetTop + toppos - scrolltop + "px"; //"510px";
        
        
        document.getElementById("lstdistrict").value="0";
        document.getElementById("divdistrict").value="";
        document.getElementById('lstdistrict').focus();
  
        return false;

}

function Clickdistrict(event)
{

var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
        if(document.activeElement.id=="lstdistrict")
        {
        if(document.getElementById('lstdistrict').value=="0")
            {
                 alert("Please select District");
                 return false;
            }
           
            var page = document.getElementById('lstdistrict').value;
            agencycode = page;
            
            for(var k=0;k<=document.getElementById('lstdistrict').length-1;k++)
            {  
                if(document.getElementById('lstdistrict').options[k].value==page)
                {
                    //var abc=document.getElementById('lstdistrict').options[k].innerText;
                       var abc;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        abc=document.getElementById('lstdistrict').options[k].innerHTML;
                    }
                    else
                    {
                          abc=document.getElementById('lstdistrict').options[k].innerText;
                    }
                  
                    var splitpub = abc;
                    var str = splitpub.split("`");
                    abc=str[0];
                    abc1=str[1];
                    document.getElementById('txtdistrict').value = abc;
                   document.getElementById('hidden_dist_text').value=abc
                    document.getElementById('hidden_dist').value=page;
                    document.getElementById("divdistrict").style.display="none";
                    ass="";
                    xyz1="";
                   
                    document.getElementById('txtdistrict').focus();
                     return false;
                   
                }
            }
            
           
            
            
        }
      }
         else if(key==27)
         {
        
        document.getElementById("divdistrict").style.display="none";
        document.getElementById('txtdistrict').value="";
        document.getElementById('txtdistrict').focus();
         }
     }
     
     
     function tabvalueexeret(event)
{

  var key = event.keyCode ? event.keyCode : event.which;
//alert(key)

if(key==13)
{
//if(document.activeElement.id==id)
//{
//    if(document.getElementById('btnSave').disabled==false)
//    {
//document.getElementById('btnSave').focus();
//    }
//return;

//}
//else 
if(document.activeElement.type=="button" || document.activeElement.type=="submit")
{
key=13;
return key;

}
else
{
//alert(event.keyCode);
key=9;
//alert(event.keyCode);
return key;
}
}

if(key==116)
{

window.open ('representative_ledger.aspx','_self','',false)
return false;
}


}

function tabvaluepicont(event)
{

  var key = event.keyCode ? event.keyCode : event.which;
//alert(key)

if(key==13)
{
//if(document.activeElement.id==id)
//{
//    if(document.getElementById('btnSave').disabled==false)
//    {
//document.getElementById('btnSave').focus();
//    }
//return;

//}
//else 
//if(document.activeElement.type=="button" || document.activeElement.type=="submit")
//{
//key=13;
//return key;

//}
if(document.activeElement.id=="txtfrmdate")
{
document.getElementById("txttodate1").focus();
return false;

}
if(document.activeElement.id=="txttodate1")
{
document.getElementById("txt_agency").focus();
return false;

}
if(document.activeElement.id=="txt_agency")
{
document.getElementById("txt_client").focus();
return false;

}
if(document.activeElement.id=="txt_client")
{
document.getElementById("drpregion").focus();
return false;

}
if(document.activeElement.id=="drpregion")
{
document.getElementById("dpproduct").focus();
return false;

}
if(document.activeElement.id=="dpproduct")
{
document.getElementById("dppubcent").focus();
return false;

}

if(document.activeElement.id=="dppubcent")
{
document.getElementById("drpcat").focus();
return false;

}
if(document.activeElement.id=="drpcat")
{
document.getElementById("Txtdest").focus();
return false;

}
if(document.activeElement.id=="Txtdest")
{
document.getElementById("BtnRun").focus();
return false;

}

}

if(key==116)
{

window.open ('picontractreport.aspx','_self','',false)
return false;
}


}

function tabvalueallsads(event)
{

  var key = event.keyCode ? event.keyCode : event.which;
//alert(key)

if(key==13)
{
//if(document.activeElement.id==id)
//{
//    if(document.getElementById('btnSave').disabled==false)
//    {
//document.getElementById('btnSave').focus();
//    }
//return;

//}
//else 
if(document.activeElement.type=="button" || document.activeElement.type=="submit")
{
key=13;
return key;

}
else
{
//alert(event.keyCode);
key=9;
//alert(event.keyCode);
return key;
}
}

if(key==116)
{

window.open ('report.aspx','_self','',false)
return false;
}


}


function tabvalueadagency(event)
{

  var key = event.keyCode ? event.keyCode : event.which;
//alert(key)

if(key==13)
{
//if(document.activeElement.id==id)
//{
//    if(document.getElementById('btnSave').disabled==false)
//    {
//document.getElementById('btnSave').focus();
//    }
//return;

//}
//else 
//if(document.activeElement.type=="button" || document.activeElement.type=="submit")
//{
//key=13;
//return key;

//}
if(document.activeElement.id=="dpagency")
{
document.getElementById("dpdadtype").focus();
return false;

}
if(document.activeElement.id=="dpdadtype")
{
document.getElementById("dpadcatgory").focus();
return false;

}
if(document.activeElement.id=="dpadcatgory")
{
document.getElementById("txtfrmdate").focus();
return false;

}
if(document.activeElement.id=="txtfrmdate")
{
document.getElementById("txttodate1").focus();
return false;

}
if(document.activeElement.id=="txttodate1")
{
document.getElementById("dppub1").focus();
return false;

}
if(document.activeElement.id=="dppub1")
{
document.getElementById("dppubcent").focus();
return false;

}

if(document.activeElement.id=="dppubcent")
{
document.getElementById("dpedition").focus();
return false;

}
if(document.activeElement.id=="dpedition")
{
document.getElementById("dpagtype").focus();
return false;

}
if(document.activeElement.id=="dpagtype")
{
document.getElementById("Txtdest").focus();
return false;

}
if(document.activeElement.id=="Txtdest")
{
document.getElementById("BtnRun").focus();
return false;

}
}

if(key==116)
{

window.open ('report2.aspx','_self','',false)
return false;
}


}


//function tabvalueschreg(event)
//{

//  var key = event.keyCode ? event.keyCode : event.which;
////alert(key)

//if(key==13)
//{


//if(document.activeElement.id=="txtfrmdate")
//{
//document.getElementById("txttodate1").focus();
//return false;

//}
//if(document.activeElement.id=="txttodate1")
//{
//document.getElementById("dpaddtype").focus();
//return false;

//}
//if(document.activeElement.id=="dpaddtype")
//{
//document.getElementById("dpadcatgory").focus();
//return false;

//}
//if(document.activeElement.id=="dpadcatgory")
//{
//document.getElementById("drppackagedetail").focus();
//return false;

//}
//if(document.activeElement.id=="drppackagedetail")
//{
//if(document.getElementById("drppackage").disabled!=true)
//document.getElementById("drppackage").focus();
//else
//document.getElementById("dppub1").focus();
//return false;

//}
//if(document.activeElement.id=="drppackage")
//{
//if(document.getElementById("dppub1").disabled!=true)
//document.getElementById("dppub1").focus();
//else
//document.getElementById("dpedidetail").focus();
//return false;

//}

//if(document.activeElement.id=="dppub1")
//{
//document.getElementById("dppubcent").focus();
//return false;

//}
//if(document.activeElement.id=="dppubcent")
//{
//document.getElementById("dpedition").focus();
//return false;

//}
//if(document.activeElement.id=="dpedition")
//{
//document.getElementById("dpsuppliment").focus();
//return false;

//}
//if(document.activeElement.id=="dpsuppliment")
//{
//document.getElementById("dpedidetail").focus();
//return false;
//}
//if(document.activeElement.id=="dpedidetail")
//{
//document.getElementById("dpd_branch").focus();
//return false;
//}
//if(document.activeElement.id=="dpd_branch")
//{
//document.getElementById("drpstatus").focus();
//return false;
//}
//if(document.activeElement.id=="drpstatus")
//{
//document.getElementById("ddlrostatus").focus();
//return false;

//}
//if(document.activeElement.id=="ddlrostatus")
//{
//document.getElementById("Txtdest").focus();
//return false;
//}
//if(document.activeElement.id=="Txtdest")
//{
//document.getElementById("BtnRun").focus();
//return false;

//}



//}
//if(key==116)
//{
//window.open ('ScheduleRegister.aspx','_self','',false)
//return false;
//}
//}


function cleardeviation(event) {

    if (browser != "Microsoft Internet Explorer") {
        event.keyCode = 116

    }
    if (event.keyCode == 116) {

        document.getElementById('dpclient').value = "";
        document.getElementById('dpagency').value = "";
        document.getElementById('dpdadtype').value = "0";
        document.getElementById('drpuom').value = "0";
        document.getElementById('txtfrmdate').value = "";
        document.getElementById('txttodate1').value = "";
        document.getElementById('dppub1').value = "0";
        document.getElementById('dppubcent').value = "0";
        document.getElementById('dpedition').value = "0";
        document.getElementById('dpstatus').value = "0";

        document.getElementById('dpagtype').value = "0";
        document.getElementById('Txtdest').value = "0";
        document.getElementById('dpclient').focus();

    }
    return false;
} 

function forsummary() {
    var fromdate = document.getElementById('txttodate1').value
    var todate = document.getElementById('txtfrmdate').value
    var alrt;
    if (browser != "Microsoft Internet Explorer")
        alrt = document.getElementById('lbDateFrom').innerHTML;
    else {

        alrt = document.getElementById('lbDateFrom').innerText;
    }
    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txtfrmdate').value == "") {
            var abc = alrt.replace("*", "");
            alert('Please Enter ' + abc);
            document.getElementById('txtfrmdate').focus();
            return false;

        }
    }
    if (browser != "Microsoft Internet Explorer")
        alrt = document.getElementById('lbToDate').innerHTML;
    else {
        alrt = document.getElementById('lbToDate').innerText;
    }

    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txttodate1').value == "") {
            var abc = alrt.replace("*", "");
            alert('Please Enter ' + abc);
            document.getElementById('txttodate1').focus();
            return false;

        }
    }
    var newstr = "";
    var newstr1 = "";


    var pubcenter = ""
    var publicatnnam = document.getElementById('dppub1').options[document.getElementById('dppub1').selectedIndex].text;
    var ppubcent = "";//document.getElementById('dppubcent').options[document.getElementById('dppubcent').selectedIndex].text;
    var adtnam = document.getElementById('dpdadtype').options[document.getElementById('dpdadtype').selectedIndex].text;
    var agnamety = document.getElementById('dpagtype').options[document.getElementById('dpagtype').selectedIndex].text;

    //var status=document.getElementById('Dropdwnstatus').options[document.getElementById('Dropdwnstatus').selectedIndex].text;
    var status = document.getElementById('hdnstatus').value;
    var chk_excel = "";
    if (document.getElementById('Txtdest').value == "4") {
        if (document.getElementById('exe').checked == true)
            chk_excel = "1";
        else
            chk_excel = "2";
    }
    else
        chk_excel = "0";
    var coid = document.getElementById("hiddencioid").value;
    var ascdec = document.getElementById("hiddenascdesc").value;
    var str2 = "true";
    var uomcod = document.getElementById("drpuom").value;
    var uomnam = document.getElementById('drpuom').options[document.getElementById('drpuom').selectedIndex].text;
    var branch = document.getElementById("drpbranch").value;
    var pstatus = document.getElementById("hdnstatus").value;
    //window.open("reportview2.aspx?agname=" + document.getElementById("hdnagency1").value + "&adtype=" + document.getElementById("dpdadtype").value+ "&adcategory=" + document.getElementById("hiddenadcat").value + "&fromdate=" + document.getElementById("txtfrmdate").value + "&dateto=" + document.getElementById("txttodate1").value + "&publication=" + document.getElementById("dppub1").value + "&pubcenter=" + document.getElementById("dppubcent").value + "&publicname=" + publicatnnam + "&publiccent=" + ppubcent + "&edition=" + document.getElementById("hiddenedition").value + "&destination=" + document.getElementById("Txtdest").value + "&adcatname=" + document.getElementById("hiddenadcatname").value + "&agencyname=" + document.getElementById("hdnagencytxt").value + "&adtypename=" + adtnam + "&editionname=" + document.getElementById("hiddeneditionname").value + "&agencysubcode=" + str2 + "&agtype=" + document.getElementById("dpagtype").value + "&agtypetext=" + adtnam + "&chk_excel=" + chk_excel+"&coid=" + coid+"&ascdec=" + ascdec+"&agnamety="+agnamety+"&uomcod="+uomcod+"&uomnam="+uomnam"&Dropdwnstatus="+Dropdwnstatus);
    window.open("reportview2.aspx?agname=" + document.getElementById("hdnagency1").value + "&adtype=" + document.getElementById("dpdadtype").value + "&adcategory=" + document.getElementById("dpadcatgory").value + "&fromdate=" + document.getElementById("txtfrmdate").value + "&dateto=" + document.getElementById("txttodate1").value + "&publication=" + document.getElementById("dppub1").value + "&pubcenter=" + pubcenter + "&publicname=" + publicatnnam + "&publiccent=" + ppubcent + "&edition=" + document.getElementById("hiddenedition").value + "&destination=" + document.getElementById("Txtdest").value + "&adcatname=" + document.getElementById("hiddenadcatname").value + "&agencyname=" + document.getElementById("hdnagencytxt").value + "&adtypename=" + adtnam + "&editionname=" + document.getElementById("hiddeneditionname").value + "&agencysubcode=" + str2 + "&agtype=" + document.getElementById("dpagtype").value + "&agtypetext=" + adtnam + "&chk_excel=" + chk_excel + "&coid=" + coid + "&ascdec=" + ascdec + "&agnamety=" + agnamety + "&uomcod=" + uomcod + "&uomnam=" + uomnam + "&pstatus=" + pstatus + "&branch=" + branch);



    return false;

}
  
  
  function diststate()
{
var compcode=document.getElementById('hiddencompcode').value;

if(document.getElementById('drpstate').value=="")
{
alert("Please Select To State");
}
else
{
var statecode=document.getElementById('drpstate').value;
}
report.binddist(compcode,statecode,binddist)

}
  
  function binddist(res)
{
 var ds=res.value;
  var pkgitem = document.getElementById("drpdistrict");
  pkgitem.options.length = 1;
  pkgitem.options[0]=new Option("--Select District--","");
 


 
  for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
  {
      pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Dist_Name,ds.Tables[0].Rows[i].Dist_Code);
     
     pkgitem.options.length;  
  }
}


function city()
{
var compcode=document.getElementById('hiddencompcode').value;

var dist=document.getElementById('drpdistrict').value;

report.bindcity(compcode,dist,bindcity)

}

function bindcity(res)
{

 var ds=res.value;
  var pkgitem = document.getElementById("drpcity");
  pkgitem.options.length = 1;
  pkgitem.options[0]=new Option("--Select city--","");
 


 
  for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
  {
      pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].City_Name,ds.Tables[0].Rows[i].city_Code);
     
     pkgitem.options.length;  
  }
 
}

function branchbind()
{
var compcode=document.getElementById('hiddencompcode').value;

var centercode=document.getElementById('dpd_printcent').value;
var branchname="";
report.bindbranch(compcode,branchname,centercode,bindbranchname)

}

function bindbranchname(res)
{

 var ds=res.value;
  var pkgitem = document.getElementById("dpd_branch");
  pkgitem.options.length = 1;
  pkgitem.options[0]=new Option("--Select Branch--","");
 


 
  for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
  {
      pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].Branch_Code);
     
     pkgitem.options.length;  
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

function dailysummaryreport()
{
  var adtype = document.getElementById("dpdadtype").value;
    var uom = document.getElementById("drpuom").value;
     var    newstr = "";
    var newstr1 = "All";
    var subcatcode="";
    var subcat="All";
   
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
        var listadsubcat=document.getElementById('dpadcatgory');
        
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
        var fromdate = document.getElementById("txtfrmdate").value;
    var dateto = document.getElementById("txttodate1").value;
        var docket = document.getElementById("DropDowndocket").value;
    var searching = document.getElementById("DropDownsearching").value;
  
       var pubname = document.getElementById("dppub1").value;
    var pubcent = document.getElementById("dppubcent").value;
        var edition = document.getElementById("dpedition").value;
    var state = document.getElementById("drpstate").value;
    var dist=document.getElementById("drpdistrict").value;
    var city=document.getElementById("drpcity").value;
        var printcenter=document.getElementById("dpd_printcent").value;
    var branch=document.getElementById("dpd_branch").value;
    var agencytype=document.getElementById("dpagtype").value;
    var userid=document.getElementById("drpuserid").value;
    var reporttype = document.getElementById("Txtdest").value;
    var pageno = document.getElementById("txtpageno").value;
    //window.open("dailyadsummary.aspx?adtype=" + adtype + "&uom=" + uom + "&listadcat=" + newstr + "&subcatcode=" + subcatcode + "&fromdate=" + fromdate + "&dateto=" + dateto + "&docket=" + docket + "&searching=" + searching + "&pubname=" + pubname + "&pubcent=" + pubcent + "&edition=" + edition + "&state=" + state + "&dist=" + dist + "&city=" + city + "&printcenter=" + printcenter + "&branch=" + branch + "&agencytype=" + agencytype + "&userid=" + userid + "&reporttype=" + reporttype + "&pageno=" + pageno);
    var bookingtype = document.getElementById("drpbooktype").value;
    window.open("dailyadsummary.aspx?adtype=" + adtype + "&uom=" + uom + "&listadcat=" + newstr + "&subcatcode=" + subcatcode + "&fromdate=" + fromdate + "&dateto=" + dateto + "&docket=" + docket + "&searching=" + searching + "&pubname=" + pubname + "&pubcent=" + pubcent + "&edition=" + edition + "&state=" + state + "&dist=" + dist + "&city=" + city + "&printcenter=" + printcenter + "&branch=" + branch + "&agencytype=" + agencytype + "&userid=" + userid + "&reporttype=" + reporttype + "&pageno=" + pageno + "&bookingtype=" + bookingtype);

    return false;


}



//function F2fillagencycr_status(event) {
//    if (event.keyCode == 113) {
//        divid = "div1";
//        listboxid = "lstagency";
//        txtbxid = eval(document.getElementById('dpagency'))
//        txtboxid = "dpagency";
//        if (document.activeElement.id == "dpagency") {
//            //$('txtagency').value="";
//            var compcode = document.getElementById('hdncompcode').value;
//            var agn = document.getElementById('dpagency').value;
//            document.getElementById("div1").style.display = "block";
//            document.getElementById('div1').style.top = 465 + "px"; //314//290
//            document.getElementById('div1').style.left = 580 + "px"; //395//1004
//            document.getElementById('lstagency').focus();
//            report3.fillF2_CreditAgency(compcode, agn, bindAgency_callbackbb);
//        }
//    }

//}



//function F2fillsectioncode(event)
// {
//    if (event.keyCode == 113) {
//        divid = "div1";
//        listboxid = "lstsectioncode";
//        txtbxid = eval(document.getElementById('dpagency'))
//        txtboxid = "txt_designer";
//        if (document.activeElement.id == "txt_designer") {
//            
//           // var compcode = document.getElementById('hdncompcode').value;
//            var name_p = document.getElementById('txt_designer').value;
//            document.getElementById("div1").style.display = "block";
//            document.getElementById('div1').style.top = 465 + "px"; //314//290
//            document.getElementById('div1').style.left = 580 + "px"; //395//1004
//            document.getElementById('lstsectioncode').focus();
//            ScheduleRegister.getSectionCode(name_p, bindsectioncode_callbackbb);
//        }
//    }

//}

//function F2fillsectioncode(event)
//{
//    alert('1')

//    if (event.keyCode == 113) {
//        divid = "div1";
//        listboxid = "lstsectioncode";
//        txtbxid = eval(document.getElementById('dpagency'))
//        txtboxid = "txt_designer";
//        if (document.activeElement.id == "txt_designer") {

//            // var compcode = document.getElementById('hdncompcode').value;
//            var name_p = document.getElementById('txt_designer').value;
//            document.getElementById("div1").style.display = "block";
//            document.getElementById('div1').style.top = 465 + "px"; //314//290
//            document.getElementById('div1').style.left = 580 + "px"; //395//1004
//            document.getElementById('lstsectioncode').focus();
//            ScheduleRegister.getSectionCode(name_p, bindsectioncode_callbackbb);
//        }
//    }

//}


//function bindsectioncode_callbackbb(res) {
//    var ds_AccName = res.value;


//    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
//        var pkgitem = document.getElementById("lstsectioncode");
//        pkgitem.options.length = 0;
//        pkgitem.options[0] = new Option("-Select Section Code-", "0");
//        pkgitem.options.length = 1;
//        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
//            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].CODE, ds_AccName.Tables[0].Rows[i].NAME);
//            pkgitem.options.length;
//        }
//    }
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

//    return false;

//}


////function F2fillsectioncode(event)
////{
////    if(event.keyCode==13 || event.type=="click")
////    {
////        if(document.activeElement.id=="lstsectioncode")
////        {
////        if(document.getElementById('lstsectioncode').value=="0")
////            {
////                 alert("Please select Section Code");
////                 return false;
////            }
////            
////            var page = document.getElementById('lstsectioncode').value;
////            agencycode = page;
////            for(var k=0;k<=document.getElementById('lstsectioncode').length-1;k++)
////            {   
////                if(document.getElementById('lstsectioncode').options[k].value==page) {
////                    if (browser != "Microsoft Internet Explorer") {
////                        var abc = document.getElementById('lstsectioncode').options[k].textContent;
////                    }
////                    else {
////                        var abc = document.getElementById('lstsectioncode').options[k].innerText;
////                    }
////                    document.getElementById('txt_designer').value = abc;
////                   // document.getElementById('hdnagencytxt').value =abc;
////                   // document.getElementById('hdnagency1').value =page;
////                    
////                    document.getElementById("div1").style.display="none";
////                    document.getElementById('txt_designer').focus();
////                     return false; 
////                    
////                }
////            }
////        }
////      }
////         else if(event.keyCode==27)
////         {
////         
////        document.getElementById("div1").style.display="none";
////        document.getElementById('dpagency').focus();
////         }
////  }
////
//

function scheduleclick1() {
    if (document.getElementById("schedule").checked == true) {
        document.getElementById("bill").checked = false;
        document.getElementById("schedule").checked = true;
        return true;
    }
    else {
        document.getElementById("schedule").checked = true
        return true;
    }
}

function billclick1()
{
    if (document.getElementById("bill").checked == true) {
        document.getElementById("bill").checked = true;
    document.getElementById("schedule").checked = false;
    return true;
}
else{
    document.getElementById("bill").checked = true
    return true;
}
}






function clearall()
 {
    document.getElementById("txtfrmdate").value = "";
    document.getElementById("txttodate1").value = "" 

}


function getValue()
{ var newstr=""
var newstr1="";
  var status=document.getElementById("lststatus");
  for (var i = 0; i < status.options.length; i++) {
     if(status.options[i].selected ==true){
    // alert(status.options[i].value)
          //alert(status.options[i].selected);
          //newstr=status.value;
          if (newstr == "")
                {
                    newstr = status.options[i].value;
                    newstr1 = status.options[i].value;
                }
                else
                {
                    newstr = newstr + "," + status.options[i].value;
                    newstr1 = newstr1 + "," +status.options[i].value;
                }
          //newstr1=newstr1+","+newstr;
          
      }
  }
  //alert(newstr)
   document.getElementById('hdnstatus').value = newstr;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}


function bind_edition4final()
{
    if (document.getElementById('dpedition').value != "0" || document.getElementById('dpedition').value != "") {
        document.getElementById('hiddenedition').value = document.getElementById('dpedition').value;
    }
    else {
        document.getElementById('hiddenedition').value = "";
    }
    return false
}