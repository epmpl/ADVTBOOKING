// JScript File

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;
function bindedition()
{
var compcode=document.getElementById('hiddencompcode').value;
var pubcent=document.getElementById('Drppubcent').value;

issuewisereport.editionbind(compcode,pubcent,call_bindedition);
}
//function loadXML(xmlFile) 
//{
//    var  httpRequest =null;
//    
//    if(browser!="Microsoft Internet Explorer")
//    { 
//        
//        req = new XMLHttpRequest();
//        //alert(req);
//        req.onreadystatechange = getMessage;
//        req.open("GET",xmlFile, true);
//        req.send('');
//        
//    }
////    else
////    {
////        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
////        xmlDoc.async="false"; 
////        xmlDoc.onreadystatechange=verify; 
////        xmlDoc.load(xmlFile); 
////        xmlObj=xmlDoc.documentElement; 
////        // alert(xmlObj.childNodes(0).childNodes(0).text);
////    }

//}



function loadXML(xmlFile) 
{

if(document.getElementById("hdn_user_right").value=="0" || document.getElementById("hdn_user_right").value=="")
{
alert("You are not Authorized to see this form")
window.close();
return false;
}
    var  httpRequest =null;
    
    if(browser!="Microsoft Internet Explorer")
    { 
        req = new XMLHttpRequest();
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
    }
}






function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
            }
        }
        
        var parser=new DOMParser();
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
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
if(event.keyCode==113) 
    event.keyCode= 81;
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



 function adcat_bind_deviation()
    {
      var ad_type=document.getElementById('dpdadtype').value;
    var comp_code=document.getElementById('hiddencompcode').value;
    
     Reports_VTS.adcatbnd(ad_type,comp_code,call_adcat_bind);
    
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
   
     
  
    
    function allads()
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
     var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    }
    
    
   
    
    function edition_bind_deviation()
   
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    Reports_VTS.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
     
    
   
    function call_bind_edition(response)
    {
     ds=response.value;
     var edition=document.getElementById('dpedition');
     edition.options.length=0;
    edition.options[0]=new Option("--Select Edition--");
     document.getElementById("dpedition").options.length = 1;
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
   
   
  
    
    
    function runclick4()
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/report3.xml');
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    
    var alrt;
    

alrt=document.getElementById('lbadtype').innerText;
    
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpdadtype').value=="0")
        {
            //alrt.Replace("*","");
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpdadtype').focus();
            return false;
        }
    }
    
   
    
   alrt=document.getElementById('lbadcatgory').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpadcatgory').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpadcatgory').focus();
            return false;
        }
    }
    
    alrt=document.getElementById('agencyname').innerText;
    
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpagencyna').value=="0")
        {
            //alrt.Replace("*","");
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpagencyna').focus();
            return false;
        }
    } 
  
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
    
     alrt=document.getElementById('lbPublication').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dppub1').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dppub1').focus();
            return false;
        }
    }
    
     alrt=document.getElementById('lbPublicationCenter').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dppubcent').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dppubcent').focus();
            return false;
        }
    } 
    alrt=document.getElementById('lbEdition').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpedition').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpedition').focus();
            return false;
        }
    } 
    
alrt=document.getElementById('lbstatus').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpstatus').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpstatus').focus();
            return false;
        }
    } 
if(abc<abc1)
    {
       alert('todate cant be less from fromdate ');
       document.getElementById('txtfrmdate').focus();
       return false;

    }
}

function runclick3()
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/agencyclient.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
    
alrt=document.getElementById('lbClient').innerText;
    
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpagencycli').value=="0")
        {
            //alrt.Replace("*","");
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpagencycli').focus();
            return false;
        }
    } 

alrt=document.getElementById('lbAdtype').innerText;
    //alert(alrt);
    if(alrt.indexOf('*')>=0)
    {
   // alert(alrt.indexOf);
        if(document.getElementById('dpaddtype').value=="0")
        {
        //alert(document.getElementById('dpaddtype').value);
            //alrt.Replace("*","");
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpaddtype').focus();
            return false;
        }
    } 
    
   
    
   alrt=document.getElementById('lbadcatgory').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpadcatgory').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpadcatgory').focus();
            return false;
        }
    }
  
    
  
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
    
     alrt=document.getElementById('lbPublication').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dppub1').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dppub1').focus();
            return false;
        }
    }
    
     alrt=document.getElementById('lbPublicationCenter').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dppubcent').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dppubcent').focus();
            return false;
        }
    } 
    alrt=document.getElementById('lbEdition').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpedition').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpedition').focus();
            return false;
        }
    } 
    if(abc<abc1)
    {
       alert('todate cant be less from fromdate ');
       document.getElementById('txtfrmdate').focus();
       return false;

    }
}
     function bind_edition2()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    report2.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
     function bind_edition_sch()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    ScheduleRegister.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
    function validation()
{

var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/DEVIATION.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value

    var alrt;
    alrt=document.getElementById('lbClient').innerText;
    
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpagencycli').value=="0")
        {
            //alrt.Replace("*","");
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpagencycli').focus();
            return false;
        }
    }
    var alrt;
    alrt=document.getElementById('lbAdtype').innerText;
    
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpaddtype').value=="0")
        {
            //alrt.Replace("*","");
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpaddtype').focus();
            return false;
        }
    }
    
   
    
  
    
      alrt=document.getElementById('agencyname').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpagencyna').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpagencyna').focus();
            return false;
        }
    } 
  
  
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
    
     alrt=document.getElementById('lbPublication').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dppub1').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dppub1').focus();
            return false;
        }
    }
    
     alrt=document.getElementById('lbPublicationCenter').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dppubcent').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dppubcent').focus();
            return false;
        }
    } 
    alrt=document.getElementById('lbEdition').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpedition').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpedition').focus();
            return false;
        }
    } 
   
   
   if(abc<abc1)
    {
       alert('todate cant be less from fromdate ');
       document.getElementById('txtfrmdate').focus();
       return false;

    }     
}
     function bind_edition3()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    agencyclient.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
    function validation1()
{

var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/pagepreviewreport.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value

  
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
    
     alrt=document.getElementById('lbPublication').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dppub1').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dppub1').focus();
            return false;
        }
    }
    
     alrt=document.getElementById('lbPublicationCenter').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dppubcent').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dppubcent').focus();
            return false;
        }
    } 
    alrt=document.getElementById('lbEdition').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpedition').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpedition').focus();
            return false;
        }
    }
     if(abc<abc1)
    {
       alert('todate cant be less from fromdate ');
       document.getElementById('txtfrmdate').focus();
       return false;

    } 
   
       
}
    
     function bind_edition4()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    report3.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    function dateformate()

    {
    //var abc=new data('txtfrmdate')
      var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value


       if(document.getElementById('txttodate1').value!="")
       {
    if(abc<abc1)
    {
       alert('todate cant be less from fromdate ');
       document.getElementById('txttodate1').value="";
          document.getElementById('txttodate1').focus();
       return false;

    }
    }
    }
     function bind_edition5()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
     Reports_VTS.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    function printbtn()
{
document.getElementById('btnprint').visibility=false;
//Reportview.pdf(string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat);
window.print();
return false();
}
      function bind_edition6()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    pagepreviewreport.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
    function validdate()
{

if(event.keyCode<= 57 && event.keyCode>=47)
{
//document.getElementById('txttodate1').value
return true;
}
else
{
alert('plz enter only numeric value');
 document.getElementById('txttodate1').value="";
 document.getElementById('txttodate1').focus();
 return false;

}
}
    
    function bind_edition7()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    IssueWiseBussiness.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    function validdate1()
{

if(event.keyCode<= 57 && event.keyCode>=47)
{
//document.getElementById('txttodate1').value
return true;
}
else
{
alert('plz enter only numeric value');
 document.getElementById('txttodate1').value="";
 document.getElementById('txttodate1').focus();
 return false;

}
}
     function bind_edition8()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    RevenueSummarryReport.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    function exfromdate()
{
if(event.keyCode<= 57 && event.keyCode>=47)
{
return true;
}
else
{
alert('plz enter only numeric value');
 document.getElementById('txttodate1').value="";
 document.getElementById('txttodate1').focus();
 return false;

}
}
      function bind_edition9()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    Ageanalysis.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
    function extodate()
{
if(event.keyCode<= 57 && event.keyCode>=47)
{
return true;
}
else
{
alert('plz enter only numeric value');
 document.getElementById('txttodate1').value="";
 document.getElementById('txttodate1').focus();
 return false;

}
}
       function bind_edition10()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    ExecutiveReport.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
    function RetCheckdate_currtill(input)
{
       var dateformat=document.getElementById('hiddendateformat').value;
       if(dateformat=="mm/dd/yyyy")
       {
               var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
       
       }
       if(dateformat=="yyyy/mm/dd")
       
       {
               var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
       }
       if(dateformat=="dd/mm/yyyy")
       {
               var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
       }
       
       
       
   

       if (!validformat.test())
       {
               if(input.value=="")
               {
               return true;
               }
               alert(" Please Fill The Date In "+dateformat+" Format");
               document.getElementById('txttodate1').value="";
               return false;
       }
}
function RetCheckdate1_currtill1(input)
{
       var dateformat=document.getElementById('hiddendateformat').value;
       if(dateformat=="mm/dd/yyyy")
       {
               var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
       
       }
       if(dateformat=="yyyy/mm/dd")
       
       {
               var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
       }
       if(dateformat=="dd/mm/yyyy")
       {
               var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
       }

       if (!validformat.test())
       {
               if(input.value=="")
               {
               return true;
               }
               alert(" Please Fill The Date In "+dateformat+" Format");
               document.getElementById('txtfrmdate').value="";
               return false;
       }
}
function pivalidation()
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
        
         if(abc<abc1)
    {
       alert('todate cant be less from fromdate ');
        document.getElementById('txtfrmdate').value="";
       document.getElementById('txtfrmdate').focus();
       return false;

    }
    }
    }
    
    function checkrundate()
 {  
 var dateformat=document.getElementById('txtfrmdate').value;
  var abc=dateformat.split("/");
  var todate = document.getElementById('txttodate1').value;
  var splittodate = todate.split("/");
  var dateformat1=document.getElementById('hiddendateformat').value;
  //var abc1 = dateformat1.split("/");
  var thisdate =  new Date();
  
  var dd   = thisdate.getDate();
  var mm   =  thisdate.getMonth()+1;
  var yyyy = thisdate.getYear();
  var label;
      if(document.getElementById('txtfrmdate').value!="")
        {
            if(dateformat1=="mm/dd/yyyy")
              {
                     if(abc[2]>yyyy) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfrmdate').value="";
                       document.getElementById('txtfrmdate').focus();
                       return false;  
                       //break;                                      
                     }
//                     goto label;
                     else if ((abc[2]==yyyy)&&(abc[0]>mm))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return false;
                     }
                     else if ((abc[2]==yyyy)&&(abc[0]==mm)&&(abc[1]>dd))
                     {
                     alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return false;
                     }
                     
                     else if((abc[0]>mm) && (abc[2]=yyyy))
                         {
                            alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return true;  
                         //break;
                         }
                         else if((abc[1]>dd)&&((abc[2]>yyyy))&& ((abc[0]>mm)))
                         {
                         alert("From Date should not be greater than current date."); 
                            document.getElementById('txtfrmdate').value="";
                            document.getElementById('txtfrmdate').focus();
                            return true;
                         }
                        
                         
                         //label;
                        
                       else if(abc[2]>splittodate[2]) 
                     {   
                       alert("From Date should not be greater than current date."); 
                       document.getElementById('txtfrmdate').value="";
                       document.getElementById('txtfrmdate').focus();
                       return false;  
                       //break;                                      
                     }
                     
                            else if((abc[2] == splittodate[2])&& (abc[0]> splittodate[0]) )
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfrmdate').value="";
                              document.getElementById('txtfrmdate').focus();
                              return false;  
                           }
                           
                           else if((abc[0] == splittodate[0])&& (abc[2] == splittodate[2]) && (abc[1] > splittodate[1]))
                           {
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfrmdate').value="";
                              document.getElementById('txtfrmdate').focus();
                              return false;
                           }
                           else 
                           {
                           if(abc[1] < splittodate[1])
                           { 
                              alert("From Date should not be greater than To date."); 
                              document.getElementById('txtfrmdate').value="";
                              document.getElementById('txtfrmdate').focus();
                              return false;
                           }
                           }
                             }
                                       
              }
}
       function bind_edition12()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    summarized_report.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    return false;
    }
    function sorting(field,fieldid)
{
var imgsplit=fieldid.split("~")[1];

//alert(imgsplit)

var imageid=$(fieldid).childNodes[1].id


//alert(imageid)
var newimageid="";
if($(fieldid).childNodes[1].id.indexOf("down")>-1)
{
    newimageid=imageid.replace("down","up");
//alert(newimageid)
}
else if($(fieldid).childNodes[1].id.indexOf("up")>-1)
{
    newimageid=imageid.replace("up","down");
   // alert(newimageid)
}
if(document.getElementById("ctrlIds")!=null)
    document.getElementById("ctrlIds").value=imageid+","+newimageid;//Manish Verma
//if(imageidimgpubdown)
    document.getElementById('hiddencioid').value=field;
   if(document.getElementById(imageid).style.display=="block")
   {
        document.getElementById(newimageid).style.display="block";
        document.getElementById(imageid).style.display="none";
        document.getElementById('hiddenascdesc').value="desc";
   }
   else if(document.getElementById(newimageid).style.display=="block")
   {
        document.getElementById(newimageid).style.display="none";
        document.getElementById(imageid).style.display="block";
        document.getElementById('hiddenascdesc').value="asc";
        
   }
   
    
    
    document.form1.submit();
    

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
    function sorting1(field,fieldid)
{
var imgsplit=fieldid.split("~")[1];

//alert(imgsplit)

var imageid=$(fieldid).childNodes[3].id


//alert(imageid)
var newimageid="";
if($(fieldid).childNodes[3].id.indexOf("down")>-1)
{
    newimageid=imageid.replace("down","up");
//alert(newimageid)
}
else if($(fieldid).childNodes[3].id.indexOf("up")>-1)
{
    newimageid=imageid.replace("up","down");
   // alert(newimageid)
}
if(document.getElementById("ctrlIds")!=null)
    document.getElementById("ctrlIds").value=imageid+","+newimageid;//Manish Verma
//if(imageidimgpubdown)
    document.getElementById('hiddencioid').value=field;
   if(document.getElementById(imageid).style.display=="block")
   {
        document.getElementById(newimageid).style.display="block";
        document.getElementById(imageid).style.display="none";
        document.getElementById('hiddenascdesc').value="desc";
   }
   else if(document.getElementById(newimageid).style.display=="block")
   {
        document.getElementById(newimageid).style.display="none";
        document.getElementById(imageid).style.display="block";
        document.getElementById('hiddenascdesc').value="asc";
        
   }
   
    
    
    document.form1.submit();
    

}
    
    function allagency()
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
    function windowreort()
{


if(event.keyCode==113) 
{

//$('txtpopup').style.display="block";
//$('frmpopup').src="alladday.aspx";
window.open('BookingDetail.aspx','','height=500px,width=550px');
}
}

function windowreport1()
{


if(event.keyCode==113) 
{
window.open('alagency.aspx','','height=500px,width=550px');
}
}
function windowreport2()
{


if(event.keyCode==113) 
{
window.open('agencclientpop.aspx','','height=600px,width=550px');
}
}

function windowreport4()
{


if(event.keyCode==113) 
{
window.open('deviationpop.aspx','','height=500px,width=400px');
}
}
function windowreport5()
{
if(event.keyCode==113) 
{
window.open('pageprepop.aspx','','height=600px,width=550px');
}

}

function windowreport8()
{
if(event.keyCode==113) 
{
window.open('branchpop.aspx','','height=600px,width=550px');
}

}





function windowclose()
{
window.close();
}
    
    function pagepremnew()
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
    
    function windowop(pagename)
{
if(event.keyCode==113)
{
window.open(pagename ,'','height=550px,width=550px'); 
}
//window.close();
}
    
     function chkpubnew()
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
    
    function drill_outdeviation()
		{
		var str="";
				//alert(a)
		  try
{
		if(typeof(window.opener)!="undefined")
		{
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
						
						if($('divpdf').style.display=="block")
						
						{
//						window.open("NewDemoViewPage.aspx?edition="+editioncode+"&editionname="+editiontext +"&startdate="+$('txtstartingdate').value +"&endingdate="+$('txtendingdate').value +"&branch="+str +"&branchname="+str1 +"&reportvalue="+report +"&destination="+$('Destination1').value +"&compcode="+ $('hdncompcode').value +"&selref="+ selref +"&cityrep="+cityreport +"&strsqcm1="+strsqcm+"&refname="+selrefname+"&pubcode="+pubcode+"&pubname="+pubname+"&center="+center+"&centername="+centername+"&condition="+condition,null)

					window.open("vtsviewapge.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch="+$('dpbranch').value  + "&destination=" + $('Txtdest').value);
					}                                           //"agencycode~" + agencychk + "~clientcode~" + dpclient.Text + "~fromdate~" +txtfrmdate.Text + "~dateto~" + txttodate1.Text + "~pubname~" + dppub1.SelectedValue + "~pubcenter~" + dppubcent.SelectedValue +"~dateformate~"+ dateformate+ "~publicname~" + dppub1.SelectedItem.Text + "~publiccent~" + dppubcent.SelectedItem.Text + "~edition~" + hiddenedition.Value + "~pubcent~" + dppubcent.SelectedItem.Text + "~branch_c~" + dpd_branch.SelectedItem.Text + "~destination~" + Txtdest.SelectedItem.Value + "~clientname~" + clientchk+"~compcode~"+compcode ;
						
						
						else
						
						{
				window.open("vtsviewapge.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch="+$('dpbranch').value  + "&destination=" + $('Txtdest').value);

						}
						window.close() 
					break;
					}
				}
		}
		else
		{
	for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
	window.open("vtsviewapge.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch="+$('dpbranch').value  + "&destination=" + $('Txtdest').value);
			
		}
	}
	catch(e)
	{
	
	window.open("/");
	}
		}
    
    function bind_executive()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var city=document.getElementById('dpcity').value;
     
       
    Ageanalysis.executive_bind(comp_code,city,call_bind_executive);
    
    }
    
    function run_report()
		{	
		
		
		 if (browser != "Microsoft Internet Explorer")
                     {
                       alrt=document.getElementById('lbDateFrom').textContent;
                       alrt=document.getElementById('lbToDate').textContent;
                       
                    }
                    else 
                    {
                        alrt=document.getElementById('lbDateFrom').innerText;
                        alrt=document.getElementById('lbToDate').innerText;
                    }
                   
		
		
		
		// alert(document.getElementById('txtfrmdate').value)
		 
            		 
		    if(document.getElementById('txtfrmdate').value=="")
            {
            alert('Please Select from date');
            document.getElementById('txtfrmdate').focus();
            return false;
            }

            if(document.getElementById('txttodate1').value=="")
            {
            alert('Please Select TO date');
            document.getElementById('txttodate1').focus();
            return false;
            }

		
//    if(alrt.indexOf('*')>=0)
//    {
//        alert('123')
//        if(document.getElementById('txtfrmdate').value=="")
//        {
//           
//           alert('asdf')
//            var abc=alrt.replace("*","");
//            alert('Please Enter '+ abc);
//            document.getElementById('txtfrmdate').focus();
//            alert( document.getElementById('txtfrmdate').value)
//            return false;
//        }
//    } 
//    
//    alert('4')
//    alrt=document.getElementById('lbToDate').innerText;
//    if(alrt.indexOf('*')>=0)
//    {
//        if(document.getElementById('txttodate1').value=="")
//        {
//            var abc=alrt.replace("*","");
//            alert('Please Enter '+ abc);
//            document.getElementById('txttodate1').focus();
//            return false;
//      
//        }
//        }
       
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
else

{
document.getElementById('hdnagency1').value=""
document.getElementById('hdnagencytxt').value=""


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
else

{
document.getElementById('hdnclient1').value=""
document.getElementById('hdnclienttxt').value=""


}

		
		var agency_code=document.getElementById('hdnagency1').value
		var client_code=document.getElementById('hdnclient1').value
	    var agency_name=document.getElementById('dpagency').value
		var client_name=document.getElementById('dpclient').value
		
		var pub_code=document.getElementById('dppub1').value
		 var des_pub=document.getElementById('dppub1').options.selectedIndex;
        if(des_pub!=-1)
        document.getElementById('hiddendppub1').value=document.getElementById('dppub1').options[des_pub].text;
        var pub_name=document.getElementById('hiddendppub1').value;
    
    
		var from_date=document.getElementById('txtfrmdate').value
		var todate=document.getElementById('txttodate1').value
		
		var publication_center=document.getElementById('dppubcent').value
		var des_pubcen=document.getElementById('dppubcent').options.selectedIndex;
		if(des_pubcen!=-1)
        document.getElementById('hiddenpubcenter').value=document.getElementById('dppubcent').options[des_pubcen].text;
		var pub_center=document.getElementById('hiddenpubcenter').value
		
		var edition_code=document.getElementById('dpedition').value
		var des_edi=document.getElementById('dpedition').options.selectedIndex;

        var edition_name="";
        
        
          for (var k = 0; k <= document.getElementById("dpedition").length - 1; k++) {
      if (document.getElementById('dpedition').options[k].selected == true)
            {
        var page=  document.getElementById('dpedition').options[k].value;  
              if (browser != "Microsoft Internet Explorer") {
                  var abc = document.getElementById('dpedition').options[k].textContent;
              }
              else {
                  var abc = document.getElementById('dpedition').options[k].innerText;
              }
              
              if(edition_name=="")
              {
              edition_name=page;
              }
              else
              {
                edition_name=edition_name+","+page;
              }
              
              
          
          }
          }
        
        		if(des_edi!=-1)
		document.getElementById('hiddeneditionname').value=edition_name;
        
        var branch_code=document.getElementById('dpd_branch').value
		 var des_bran=document.getElementById('dpd_branch').options.selectedIndex;
        if(des_bran!=-1)
        document.getElementById('hiddenbranchname').value=document.getElementById('dpd_branch').options[des_bran].text;
        var branch_name=document.getElementById('hiddenbranchname').value;
    
    
        
//        var pub_code=document.getElementById('hiddendppub1').value
//        var pub_name=document.getElementById('dppub1').value;
       
        //var branch_code=document.getElementById('hiddenbranchname').value
		// branch_name=document.getElementById('dpd_branch').value
		
		var userid=document.getElementById('hiddenuseid').value
		var dest=document.getElementById('Txtdest').value
		var clienttype=document.getElementById('DropDownClient').value;
		var ClientIndex=document.getElementById('DropDownClient').options.selectedIndex;
		 var clienttypeName=document.getElementById('DropDownClient').options[ClientIndex].text;
		 var reporttype=document.getElementById('drpbilles').value;
		 
		 var browser = navigator.appName;
    var state="";
  
        for (var k = 0; k <= document.getElementById("ListBox1").length - 1; k++) {
      if (document.getElementById('ListBox1').options[k].selected == true)
            {
        var page=  document.getElementById('ListBox1').options[k].value;  
              if (browser != "Microsoft Internet Explorer") {
                  var abc = document.getElementById('ListBox1').options[k].textContent;
              }
              else {
                  var abc = document.getElementById('ListBox1').options[k].innerText;
              }
              
              if(state=="")
              {
              state=page;
              }
              else
              {
                state=state+","+page;
              }
              
              
          
          }
          }
		 
//		 var adtypeIndex=document.getElementById('dpdadtype').options.selectedIndex;
//	var dpdadtypeName=document.getElementById('dpdadtype').options[adtypeIndex].text;
//		var dpdadtype=document.getElementById('dpdadtype').value;
		
		    
        	 var adtypeIndex=document.getElementById('dpdadtype').options.selectedIndex;	
		    if(adtypeIndex!=-1)
		    {
		    var dpdadtypeName=document.getElementById('dpdadtype').options[adtypeIndex].text;
		    var dpdadtype=document.getElementById('dpdadtype').value;
		    }
		    else
		    {
		     var dpdadtypeName="";
		     var dpdadtype="";
		    }
		
		//window.open("vtsviewpage.aspx?agency_code1="+agency_code+"&agency_name1="+agency_name+"&client_code1="+client_code+"&client_name1="+client_name+"&pub_code1="+pub_code+"&pub_name1="+pub_name+"&from_date1="+from_date+"&todate1="+todate+"&publication_center1="+publication_center+"&edition_name1="+edition_name+"&branch_name1="+branch_name+"&userid1="+userid+"&dest1="+dest+"&edition_code1="+edition_code+"&branch_code1="+branch_code)		
		window.open("vtsviewpage.aspx?agency_code1="+agency_code+"&des_pub1="+des_pub+"&des_pubcen1="+des_pubcen+"&des_edi1="+des_edi+"&des_bran1="+des_bran+"&agency_name1="+agency_name+"&client_code1="+client_code+"&client_name1="+client_name+"&pub_code1="+pub_code+"&pub_name1="+pub_name+"&from_date1="+from_date+"&todate1="+todate+"&publication_center1="+publication_center+"&pub_center1="+pub_center+"&edition_name1="+edition_name+"&edition_code1="+edition_code+"&branch_name1="+branch_name+"&branch_code1="+branch_code+"&userid1="+userid+"&dest1="+dest+"&clienttype="+clienttype+"&clienttypeName="+clienttypeName+"&dpdadtype="+dpdadtype+"&dpdadtypeName="+dpdadtypeName+"&state="+state+"&reporttype="+reporttype)
		return false;
		
		}
    
    function drill_outallday()
		{
		var str="";
				//alert(a)
				
				
				
				if($('Txtdest').value==3)
				{
				
				var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
                loadXML('xml/pdf.xml');   
                var alrt;
                alrt=document.getElementById('lbpdfsortvalue').innerText;    
                if(alrt.indexOf('*')>=0)
                {
                if(document.getElementById('txtpdfsortvalue').value=="0")
                {
            //alrt.Replace("*","");
                var abc=alrt.replace("*","");
                alert('Please Enter '+ abc);
                document.getElementById('txtpdfsortvalue').focus();
                return false;
                }
                }
    
   
    
               alrt=document.getElementById('lbpdfsort').innerText;
               if(alrt.indexOf('*')>=0)
               {
               if(document.getElementById('txtpdfsort').value=="0")
               {
               var abc=alrt.replace("*","");
               alert('Please Enter '+ abc);
               document.getElementById('txtpdfsort').focus();
               return false;
               }
               } 
  
		      try
              {
		      if(typeof(window.opener)!="undefined")
		      {		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
						
						if($('divpdf').style.display=="block")
						
						{
					window.open("vtsviewapge.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch="+$('dpbranch').value  + "&destination=" + $('Txtdest').value);
					}
					else
					{
					window.open("vtsviewapge.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch="+$('dpbranch').value  + "&destination=" + $('Txtdest').value);
					
					}
						
						window.close() 
					break;
					}
				}
		}
		else
		{
	for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
	         window.open("vtsviewapge.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch="+$('dpbranch').value  + "&destination=" + $('Txtdest').value);
			
			
		}
	}
	catch(e)
	{
	
	window.open("/");
	}
	
	}
	
	else
	
	{
	
	
	
			  try
{
		if(typeof(window.opener)!="undefined")
		{
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
						
						if($('divpdf').style.display=="block")
						
						{
					window.open("vtsviewapge.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch="+$('dpbranch').value  + "&destination=" + $('Txtdest').value);
					}
					else
					{
					window.open("vtsviewapge.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch="+$('dpbranch').value  + "&destination=" + $('Txtdest').value);
					
					}
						
						window.close() 
					break;
					}
				}
		}
		else
		{
            for(i=0;i<$('dpadcatgory').length;i++)
            {
                if($('dpadcatgory').options[i].selected==true)
                {
                str+=$('dpadcatgory').options[i].value+",";
                }   		    
            }
	window.open("vtsviewapge.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch="+$('dpbranch').value  + "&destination=" + $('Txtdest').value);
			
		}
	}
	catch(e)
	{
	
	window.open("/");
	}
	
	}
	
	
	
	
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
    
    function drill_outagency()
		{
		var str="";
				//alert(a)
		  try
{
		if(typeof(window.opener)!="undefined")
		{
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
						
						
						if($('divpdf').style.display=="block")
						
						{
						  
						
					x_win.location.href="reportview2.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
					}
					else
					{
					x_win.location.href="reportview2.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50" + "&sortvalue=" + "50";
					
					}
						//x_win.location.href="reportview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&adcat=" +$('dpadcatgory').value + "&edition=" +$('dpedition').value + "&package=" +$('dppackage').value + "&pubcenter=" +$('pubcent').value+ "&drilout=" + "yes" + "&destination="+"1";
						//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
						//alert(x_win.location.href)
						window.close() 
					break;
					}
				}
		}
		else
		{
	for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
	window.location.href="reportview2.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			//window.location.href="reportview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&drilout=" + "yes" + "&destination="+"1";
			//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
		}
	}
	catch(e)
	{
	
	window.open("/");
	}
		}
    function chkexenew()
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
   
    
     if(document.getElementById('dppub1').value=="0")
    {
    alert("Please Select Publication");
    document.getElementById('dppub1').focus();
    return false;
    }
    
    
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
    
    function drill_outclient()
		{
		var str="";
				//alert(a)
		  try
{
		if(typeof(window.opener)!="undefined")
		{
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
						
						if($('divpdf').style.display=="block")
						
						{
						
					x_win.location.href="Agencycliview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str + "&fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&client=" + $('dpclient').value + "&drilout=" + "yes" +  "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
					}
					else
					{
					x_win.location.href="Agencycliview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str + "&fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&client=" + $('dpclient').value + "&drilout=" + "yes" +  "&destination=" + $('Txtdest').value+ "&sortorder=" + "50" + "&sortvalue=" + "50";
					}
						//x_win.location.href="reportview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&adcat=" +$('dpadcatgory').value + "&edition=" +$('dpedition').value + "&package=" +$('dppackage').value + "&pubcenter=" +$('pubcent').value+ "&drilout=" + "yes" + "&destination="+"1";
						//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
						//alert(x_win.location.href)
						window.close() 
					break;
					}
				}
		}
		else
		{
	for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
	window.location.href="Agencycliview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str + "&fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&client=" + $('dpclient').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			//window.location.href="reportview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&drilout=" + "yes" + "&destination="+"1";
			//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
		}
	}
	catch(e)
	{
	
	window.open("/");
	}
}

function runclickalladday()
{


var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/pdf.xml');
    
   
    var alrt;
    alrt=document.getElementById('lbpdfsortvalue').innerText;
    
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtpdfsortvalue').value=="0")
        {
            //alrt.Replace("*","");
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txtpdfsortvalue').focus();
            return false;
        }
    }
    
   
    
   alrt=document.getElementById('lbpdfsort').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtpdfsort').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txtpdfsort').focus();
            return false;
        }
    } 
  
  
   
}


function runclickbillregister()
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('XML/disschreg.xml');
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
    
    
   

if(abc<abc1)
    {
//       alert('todate cant be less from fromdate ');
//       document.getElementById('txttodate1').focus();
//       document.getElementById('txttodate1').value="";
//       return false;

    }
    
    
    
    
    
    ////////////////////////////////////////////////////////////////////////
    
    //if((document.getElementById('bill').checked==false) && (document.getElementById('schedule').checked==false))
    //{
   // alert("Please Select Ads");
   // return false;
   // }
    //////////////////////////////////////////////////////////////////////////
}



	function drill_out()
		{
			//***********************************************************
        if($('Txtdest').value==3)
		{
				
				var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
                loadXML('xml/pdf.xml');   
                var alrt;
                alrt=document.getElementById('lbpdfsortvalue').innerText;    
                if(alrt.indexOf('*')>=0)
                {
                if(document.getElementById('txtpdfsortvalue').value=="0")
                {
            //alrt.Replace("*","");
                var abc=alrt.replace("*","");
                alert('Please Enter '+ abc);
                document.getElementById('txtpdfsortvalue').focus();
                return false;
                }
                }
    
   
    
               alrt=document.getElementById('lbpdfsort').innerText;
               if(alrt.indexOf('*')>=0)
               {
               if(document.getElementById('txtpdfsort').value=="0")
               {
               var abc=alrt.replace("*","");
               alert('Please Enter '+ abc);
               document.getElementById('txtpdfsort').focus();
               return false;
               }
               }
     
        //************************************************************	//alert(a)
		    try
	       {
	       
 //*******************************************************************************************
	       var myrange="";
	       var myrangeid="";
	       var myvalue="";
	       var userrange="";
		     if(typeof(window.opener)!="undefined")
		     {
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
//*******************************************************************************************
						
						for(k=0;k<$('txtrange').options.length;k++)
			{
			    if($('txtrange').options[k].selected==true)
			    {
			        myrange=$('txtrange').options[k].value;
			        myrangeid=k;
			        break;
			    }
			}
			if(myrange!="")
			{
			     myvalue= $('arrayval').value.split("~");
			     for(j=0;j<myvalue.length-1;j++)
			     {
			        if(j==k)
			        {
			        
			            userrange=myvalue[j];
			        }
			     }
			}
			            if(userrange=="" || userrange=="undefined")
						{
						userrange="no";
						}
						else
						{
						}
//*******************************************************************************************
			        
						if($('divpdf').style.display=="block")
						
						{
						
						    x_win.location.href="BillRegisterview.aspx?region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value +"&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value + "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
						}
						else
						{
						    x_win.location.href="BillRegisterview.aspx?region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value + "&sortorder=" + "50"+ "&sortvalue=" + "50";
						}
						
						window.close() 
					break;
					}
				}
		}
		else
		{
	
			//window.location.href="BillRegisterview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value + "&drilout=" + "yes" + "&destination="+"1";
			x_win.location.href="BillRegisterview.aspx?region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
		}
		}
	
	catch(e)
	{
	window.open("/");
	}
		}
		
		else
	
	{
	try
	       {
		     if(typeof(window.opener)!="undefined")
		     {
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						
			//*******************************************************************************************			
						for(k=0;k<$('txtrange').options.length;k++)
			{
			    if($('txtrange').options[k].selected==true)
			    {
			        myrange=$('txtrange').options[k].value;
			        myrangeid=k;
			        break;
			    }
			}
			if(myrange!="")
			{
			     myvalue= $('arrayval').value.split("~");
			     for(j=0;j<myvalue.length-1;j++)
			     {
			        if(j==k)
			        {
			            userrange=myvalue[j];
			        }
			     }
			}
			//alert(userrange)
			if(userrange=="" || userrange== undefined)
						{
						userrange="no";
						}
						else
						{
						}
						
	//*******************************************************************************************					
						//x_win.location.href="BillRegisterview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value + "&drilout=" + "yes" + "&destination="+"1";
						if($('divpdf').style.display=="block")
						
						{
						    x_win.location.href="BillRegisterview.aspx?region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value + "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
						}
						else
						{
						    x_win.location.href="BillRegisterview.aspx?region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value + "&sortorder=" + "50"+ "&sortvalue=" + "50";
						}
						
						window.close() 
					break;
					}
				}
		}
		else
		{
	
			//window.location.href="BillRegisterview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value + "&drilout=" + "yes" + "&destination="+"1";
			x_win.location.href="BillRegisterview.aspx?region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
		}
	}
	catch(e)
	{
	window.open("/");
	}
		}
	
	}
	
	
	
	
	
	
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	

		
		
		///////////////////+++///////////////////////////////////////////
		
		
	
	
function closediv()
{

//window.close();
 //document.getElementById('allads').style.display='none';
 //alert('ajay');
 return true;

}





function reset()
{

document.getElementById('dpclient').value="0";
document.getElementById('dpdadtype').value="0";
document.getElementById('dpadcatgory').value="0";
document.getElementById('dppub1').value="0";
document.getElementById('pubcent').value="0";
document.getElementById('dppackage').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}

function resetbill()
{

document.getElementById('dpregion').value="0";
document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dppub').value="0";
document.getElementById('dpadtype').value="0";
document.getElementById('dppayment').value="0";
document.getElementById('dpbillstatus').value="0";
document.getElementById('txtrange').value="0";
document.getElementById('Txtdest').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}

function resetbarter()
{

document.getElementById('dpregion').value="0";
document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dppub').value="0";
document.getElementById('dpadtype').value="0";
document.getElementById('dppayment').value="0";
document.getElementById('dpbillstatus').value="0";
document.getElementById('txtrange').value="0";
document.getElementById('Txtdest').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}


function resetregion()
{

document.getElementById('dpregion').value="0";
document.getElementById('dpagency').value="0";
document.getElementById('dpcategory').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dppub').value="0";
document.getElementById('dpadtype').value="0";
document.getElementById('dppayment').value="0";
document.getElementById('dpbillstatus').value="0";
document.getElementById('txtrange').value="0";
document.getElementById('Txtdest').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}


function retain()
{

document.getElementById('dpregion').value="0";
document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dpretainname').value="0";
document.getElementById('dppub').value="0";
document.getElementById('dpadtype').value="0";
document.getElementById('dppayment').value="0";
document.getElementById('dpbillstatus').value="0";
document.getElementById('txtrange').value="0";
document.getElementById('Txtdest').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}


function extrarebate()
{

document.getElementById('dpregion').value="0";
document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dpcategory').value="0";
document.getElementById('dppub').value="0";
document.getElementById('dpadtype').value="0";
document.getElementById('dppayment').value="0";
document.getElementById('dpbillstatus').value="0";
document.getElementById('txtrange').value="0";
document.getElementById('Txtdest').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}


function pubrebate()
{

document.getElementById('dpregion').value="0";
document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dpcategory').value="0";
document.getElementById('dppub').value="0";
document.getElementById('dpadtype').value="0";
document.getElementById('dppayment').value="0";
document.getElementById('dpbillstatus').value="0";
document.getElementById('txtrange').value="0";
document.getElementById('Txtdest').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}



function valuereport()
{

document.getElementById('dpregion').value="0";
document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dppub').value="0";
document.getElementById('dpadtype').value="0";
document.getElementById('dppayment').value="0";
document.getElementById('dpbillstatus').value="0";
document.getElementById('txtrange').value="0";
document.getElementById('Txtdest').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}



function schedule()
{

document.getElementById('dppublication').value="0";
document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dppackage').value="0";
document.getElementById('Txtdest').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}



function piproduct()
{

document.getElementById('dpregion').value="0";
document.getElementById('dplanguage').value="0";
document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dpdestination').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}

function pipublicationreset()
{

document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dpregion').value="0";
document.getElementById('dppublication').value="0";
document.getElementById('dppubnot').value="0";
document.getElementById('dpdestination').value="0";
document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

return false;


}


function picontractppreset()
{

var dropcount=$('dpadtype').item.length;
var dropcount1=$('dpadcatgory').item.length;


var mymumber=0;    
var myresult=0;


//for(j=dropcount-1;j>0;j--)
//{
//        $('dpdadtype').remove(j)
//}
//     $('dpdadtype').options[mymumber]=new Option("-Select AdType-","0");




for(j=dropcount-1;j>0;j--)
{
  $('dpadtype').remove(j)
}
 $('dpadtype').options[mymumber]=new Option("--Select AdType--","0");
 
// for(j=dropcount1-1;j>0;j--)
//{
//  $('dpadcatgory').remove(j)
//}
// $('dpadcatgory').options[mymumber]=new Option("-Select Category-","0");



document.getElementById('dpagency').value="0";
document.getElementById('dpclient').value="0";
document.getElementById('dppackage').value="0";
//document.getElementById('dpadtype').value="0";
//document.getElementById('dpadcatgory').value="0";




document.getElementById('dpregion').value="0";
//document.getElementById('dpprodcat').value="";


document.getElementById('dpdestination').value="0";

document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";

//return false;


}





function filldrop()
{

var dropcount=$('dpdadtype').item.length;
var dropcount1=$('dpclient').item.length;

var dropcount2=$('dppub1').item.length;
var dropcount3=$('pubcent').item.length;
var dropcount4=$('Txtdest').item.length;
var dropcount5=$('dppackage').item.length;

var dropcount6=$('dpedition').item.length;




var mymumber=0;    
var myresult=0;

    
    document.getElementById('dpclient').value="0";


for(j=dropcount-1;j>0;j--)
{
        $('dpdadtype').remove(j)
}
     $('dpdadtype').options[mymumber]=new Option("-Select AdType-","0");


for(j=dropcount2-1;j>0;j--)
{
        $('dppub1').remove(j)
}
     $('dppub1').options[mymumber]=new Option("-Select Publication-","0");



//for(j=dropcount3-1;j>0;j--)
//{
//        $('pubcent').remove(j)
//}
//     $('pubcent').options[mymumber]=new Option("-Select Pub Center-","0");

    document.getElementById('pubcent').value="0";


//for(j=dropcount6 -1;j>0;j--)
//{
//        $('dpedition').remove(j)
//}
//     $('dpedition').options[mymumber]=new Option("-Select Edition-","0");


    document.getElementById('dpedition').value="0";


//for(j=dropcount5-1;j>0;j--)
//{
//        $('dppackage').remove(j)
//ss}
//     $('dppackage').options[mymumber]=new Option("-Select Package-","0");


    document.getElementById('dppackage').value="0";

for(j=dropcount4-1;j>0;j--)
{
        $('Txtdest').remove(j)
}
     $('Txtdest').options[mymumber]=new Option("-Select Destination-","0");



document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";


}





function agencyreset()
{


var dropcount=$('dpdadtype').item.length;
var dropcount1=$('dpclient').item.length;

var dropcount2=$('dppub1').item.length;
var dropcount3=$('pubcent').item.length;
var dropcount4=$('Txtdest').item.length;
var dropcount5=$('dppackage').item.length;

var dropcount6=$('dpedition').item.length;

var mymumber=0;    
var myresult=0;


  
 document.getElementById('dpagency').value="0";
 document.getElementById('dpclient').value="0";


for(j=dropcount-1;j>0;j--)
{
        $('dpdadtype').remove(j)
}
     $('dpdadtype').options[mymumber]=new Option("-Select AdType-","0");


for(j=dropcount2-1;j>0;j--)
{
        $('dppub1').remove(j)
}
     $('dppub1').options[mymumber]=new Option("-Select Publication-","0");




    document.getElementById('pubcent').value="0";

    document.getElementById('dpedition').value="0";

    document.getElementById('dppackage').value="0";    


   

for(j=dropcount4-1;j>0;j--)
{
        $('Txtdest').remove(j)
}
     $('Txtdest').options[mymumber]=new Option("-Select Destination-","0");



document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";


}



function statusreset()
{


var dropcount=$('dpdadtype').item.length;
var dropcount1=$('dpclient').item.length;

var dropcount2=$('dppub1').item.length;
var dropcount3=$('pubcent').item.length;
var dropcount4=$('Txtdest').item.length;
var dropcount5=$('dppackage').item.length;

var dropcount6=$('dpedition').item.length;

var mymumber=0;    
var myresult=0;


  
 document.getElementById('dpagency').value="0";
 document.getElementById('dpclient').value="0";


for(j=dropcount-1;j>0;j--)
{
        $('dpdadtype').remove(j)
}
     $('dpdadtype').options[mymumber]=new Option("-Select AdType-","0");


for(j=dropcount2-1;j>0;j--)
{
        $('dppub1').remove(j)
}
     $('dppub1').options[mymumber]=new Option("-Select Publication-","0");




    document.getElementById('pubcent').value="0";

    document.getElementById('dpedition').value="0";

    document.getElementById('dppackage').value="0";    


    document.getElementById('dpstatus').value="0";

for(j=dropcount4-1;j>0;j--)
{
        $('Txtdest').remove(j)
}
     $('Txtdest').options[mymumber]=new Option("-Select Destination-","0");



document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";


}


function deviationreset()
{


var dropcount=$('dpdadtype').item.length;
var dropcount1=$('dpclient').item.length;

var dropcount2=$('dppub1').item.length;
var dropcount3=$('pubcent').item.length;
var dropcount4=$('Txtdest').item.length;
var dropcount5=$('dppackage').item.length;

var dropcount6=$('dpedition').item.length;

var mymumber=0;    
var myresult=0;


  
 document.getElementById('dpagency').value="0";
 document.getElementById('dpclient').value="0";


for(j=dropcount-1;j>0;j--)
{
        $('dpdadtype').remove(j)
}
     $('dpdadtype').options[mymumber]=new Option("-Select AdType-","0");


for(j=dropcount2-1;j>0;j--)
{
        $('dppub1').remove(j)
}
     $('dppub1').options[mymumber]=new Option("-Select Publication-","0");




    document.getElementById('pubcent').value="0";

    document.getElementById('dpedition').value="0";

    document.getElementById('dppackage').value="0";    


    document.getElementById('dpstatus').value="0";

for(j=dropcount4-1;j>0;j--)
{
        $('Txtdest').remove(j)
}
     $('Txtdest').options[mymumber]=new Option("-Select Destination-","0");



document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";


}


function pagepremiumreset()
{


var dropcount=$('dpdadtype').item.length;
var dropcount1=$('dpclient').item.length;

var dropcount2=$('dppub1').item.length;
var dropcount3=$('pubcent').item.length;
var dropcount4=$('dpdestination').item.length;
var dropcount5=$('dppackage').item.length;

var dropcount6=$('dpedition').item.length;

var mymumber=0;    
var myresult=0;

 document.getElementById('dppage').value="0";
 document.getElementById('dpposition').value="0";

  
 document.getElementById('dpagency').value="0";
 document.getElementById('dpclient').value="0";


for(j=dropcount-1;j>0;j--)
{
        $('dpdadtype').remove(j)
}
     $('dpdadtype').options[mymumber]=new Option("-Select AdType-","0");


for(j=dropcount2-1;j>0;j--)
{
        $('dppub1').remove(j)
}
     $('dppub1').options[mymumber]=new Option("-Select Publication-","0");




    document.getElementById('pubcent').value="0";

    document.getElementById('dpedition').value="0";

    document.getElementById('dppackage').value="0";    


    document.getElementById('dpstatus').value="0";

for(j=dropcount4-1;j>0;j--)
{
        $('dpdestination').remove(j)
}
     $('dpdestination').options[mymumber]=new Option("-Select Destination-","0");



document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";


}




function alladsreset()
{


var dropcount=$('dpdadtype').item.length;
var dropcount1=$('dpclient').item.length;

var dropcount2=$('dppub1').item.length;
var dropcount3=$('pubcent').item.length;
var dropcount4=$('Txtdest').item.length;
var dropcount5=$('dppackage').item.length;

var dropcount6=$('dpedition').item.length;

var mymumber=0;    
var myresult=0;


  
 document.getElementById('dpagency').value="0";
 document.getElementById('dpclient').value="0";


for(j=dropcount-1;j>0;j--)
{
        $('dpdadtype').remove(j)
}
     $('dpdadtype').options[mymumber]=new Option("-Select AdType-","0");


for(j=dropcount2-1;j>0;j--)
{
        $('dppub1').remove(j)
}
     $('dppub1').options[mymumber]=new Option("-Select Publication-","0");




    document.getElementById('pubcent').value="0";

    document.getElementById('dpedition').value="0";

    document.getElementById('dppackage').value="0";    


    

for(j=dropcount4-1;j>0;j--)
{
        $('Txtdest').remove(j)
}
     $('Txtdest').options[mymumber]=new Option("-Select Destination-","0");



document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";


}




function pireport1()
{

var dropcount=$('dpregion').item.length;
 //dropcount6=$('dpedition').item.length;

var mymumber=0;    
var myresult=0;
  
   document.getElementById('dpregion').value="0";
      document.getElementById('dpprodcat').value="0";

   document.getElementById('dpadcategory').value="0";

   document.getElementById('dpagency').value="0";

   document.getElementById('dpclient').value="0";
      document.getElementById('dppackage').value="0";
   document.getElementById('dpdestination').value="0";

document.getElementById('divpdf').style.display="none";
document.getElementById('divpdf1').style.display="none";


}

function incorrectfromdate(input)
{
	var dateformat=document.getElementById('hiddendateformat').value;
	if(dateformat=="mm/dd/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	 
	}
	if(dateformat=="yyyy/mm/dd")
	 
	{
		var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
	}
	if(dateformat=="dd/mm/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	}

	if (!validformat.test(input.value) && (document.getElementById('hiddenolddate').value=="") )
	{
	
		if(input.value=="")
		{
		//input.focus();
		return true;
		}
		
		alert(" Please Fill The Date In "+dateformat+" Format");
		document.getElementById('txtfrmdate').value="";
		document.getElementById('txtfrmdate').focus();
		
		
		//document.activeElement.id="";
		

    
		return false;
	
		
	}
	
	
}

function incorrectodate(input)
{
	var dateformat=document.getElementById('hiddendateformat').value;
	if(dateformat=="mm/dd/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	 
	}
	if(dateformat=="yyyy/mm/dd")
	 
	{
		var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
	}
	if(dateformat=="dd/mm/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	}

	if (!validformat.test(input.value) && (document.getElementById('hiddenolddate').value=="") )
	{
	
		if(input.value=="")
		{
		//input.focus();
		return true;
		}
		
		alert(" Please Fill The Date In "+dateformat+" Format");
		
		
		document.getElementById('txttodate1').value="";
		document.getElementById('txttodate1').focus();
		
		//document.activeElement.id="";
		

    
		return false;
	
		
	}
	
	
}
 
 
function  closeallday()
 {

 document.getElementById('txtpopup').style.display="none";

 }
 
 function showUpDownImg()
 {
    if(document.getElementById("ctrlIds").value!="")
    {
        var arrImg=document.getElementById("ctrlIds").value.split(',');
        if(document.getElementById("flag").value=="0")
        {
            var arrImg=document.getElementById("ctrlIds").value.split(',');
            document.getElementById(arrImg[0]).style.display="none";
            document.getElementById(arrImg[1]).style.display="block";
            document.getElementById("flag").value="1";
            return false;
        }
        else
        {
//            var arrImg=document.getElementById("ctrlIds").value.split(',');
//            document.getElementById(arrImg[0]).style.display="block";
//            document.getElementById(arrImg[1]).style.display="none";
            document.getElementById("flag").value="0";
            return false;
        }
    }
    return false;
 }
 
 
 
 
 function billclick()
 {
  if(document.getElementById('bill').checked==false)
  {
  document.getElementById('bill').checked=true;
  }
 if(document.getElementById('schedule').checked==true)
  {
  document.getElementById('schedule').checked=false;
  }
  //return false ;
 }
 
  function scheduleclick()
 {
  if(document.getElementById('bill').checked==true)
  {
  document.getElementById('bill').checked=false;
  }
 if(document.getElementById('schedule').checked==false)
  {
  document.getElementById('schedule').checked=true;
  }
  //return false;
 }




 function chkorder()
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
  if(document.getElementById('dporderby').value=="0")
  {
  alert("Please Select Order By");
  document.getElementById('dporderby').focus();
  return false;
  
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

 
 
 
 
 
 /*********************************************************************************************************/
 
  /*******************           executivewise report            ***************************/
 
 
 
 
 function validationexec()
{
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

    alrt=document.getElementById('lbteam').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpteam').value=="0")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('dpteam').focus();
            return false;

        }
    }
} 



 
 
  
 function btnrunclick()
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
   
    
    
    } 
    
    
    
    function chkness()
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
    
     if(document.getElementById('dpaddtype').value=="0")
    {
    alert("Please Select AdType");
    document.getElementById('dpaddtype').focus();
    return false;
    }
    
     if(document.getElementById('dppub1').value=="0")
    {
    alert("Please Select Publication");
    document.getElementById('dppub1').focus();
    return false;
    }
    
    }
     function chkness1()
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
    
     if(document.getElementById('dpaddtype').value=="0")
    {
    alert("Please Select AdType");
    document.getElementById('dpaddtype').focus();
    return false;
    }
    
  //  if(document.getElementById('dppub1').disabled != true)
  //  {
    
             if(document.getElementById('dppub1').value=="0")
            {
            alert("Please Select Publication");
            document.getElementById('dppub1').focus();
            return false;
            }
    
  //  }
    
    document.getElementById('hdnsuppliment').value=document.getElementById('dpsuppliment').value;
    
    }
    
    
      function chknessschedule()
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
    
     if(document.getElementById('dpaddtype').value=="0")
    {
    alert("Please Select AdType");
    document.getElementById('dpaddtype').focus();
    return false;
    }
    
    if(document.getElementById('dppub1').disabled != true)
    {
    
             if(document.getElementById('dppub1').value=="0")
            {
            alert("Please Select Publication");
            document.getElementById('dppub1').focus();
            return false;
            }
    
    }
    
    document.getElementById('hdnsuppliment').value=document.getElementById('dpsuppliment').value;
    
    }
        function chkpub()
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
   
    
     if(document.getElementById('dppublication').value=="0")
    {
    alert("Please Select Publication");
    document.getElementById('dppublication').focus();
    return false;
    }
    
    }
    
    
    
    
    function pageprem()
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
      if(document.getElementById('dppub1').value=="0")
    {
    alert("Please Select Publication");
    document.getElementById('dppub1').focus();
    return false;
    }
    
    } 
    
    
    
    
function executewise()
{
if(document.getElementById('retainerwise').checked==true)
{
document.getElementById('retainerwise').checked=false;
}
if(document.getElementById('executivewise').checked==false)
{
document.getElementById('executivewise').checked=true;
}
document.getElementById('txt_retainer').disabled=true;
document.getElementById('txt_retainer').value="";
document.getElementById('dpteam').disabled=false;
document.getElementById('dpexec').disabled=false;

}

function retainwise()
{
if(document.getElementById('executivewise').checked==true)
{
document.getElementById('executivewise').checked=false;
}
if(document.getElementById('retainerwise').checked==false)
{
document.getElementById('retainerwise').checked=true;
}
document.getElementById('txt_retainer').disabled=false;
document.getElementById('dpteam').disabled=true;
document.getElementById('dpteam').value="0";
document.getElementById('dpexec').disabled=true;
document.getElementById('dpexec').value="0";

}


function suppforschedule()
{

var compcode=document.getElementById('hdncompcode').value;
var edition=document.getElementById('dpedition').value;
ScheduleRegister.bindsupp(compcode,edition,call_suppforschedule);
}
function call_suppforschedule(response)
{
ds= response.value;
    var edition=document.getElementById('dpsuppliment');
    edition.options.length=0;
    edition.options[0]=new Option("Select Supplement");
    document.getElementById("dpsuppliment").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
                edition.options.length;    
             }
 }         
 
       return false;

}



function runclickbarter()
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('XML/disschreg.xml');
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
    
      if(document.getElementById('drpbooktype').value=="0")
    {
    alert("Please Select Booking Type");
    document.getElementById('drpbooktype').focus();
    return false;
    }
    
    
    
}





function excel_report()
{
if(document.getElementById('Txtdest').value=="4")
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

function enable_exe()
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

function enable_csv()
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



function bindqbc_new()
{

moneyrecievedreport.fillQBC(document.getElementById('dppubcent').value,bindQBC_callback11);
}

function bindQBC_callback11(response)
{
    var ds=response.value;
    agcatby = document.getElementById("dpbranch");
 agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Branch--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].Branch_Code);
       agcatby.options.length;
       
    }
    }
}


function logoutpage()
{
    var c;
    //alert(typeof(formopen));
    //alert(win);
    if(typeof(win)!="undefined")
    {
        win.close();
    }
    window.location.href="../logout.aspx";
    window.close();
    return false;
}
///////////////////////////bind f2 for booking type wise report

function F2fillagencycr_bar()
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_agency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('txt_agency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=180+ "px" ;//314//290
            document.getElementById('div1').style.left=580+ "px";//395//1004
            document.getElementById('lstagency').focus();
            BarterBill.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb);
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
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
   
        return false;

}
  
function ClickAgaency_bar()
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
                {
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
         else if(event.keyCode==27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txt_agency').focus();
         }
  }
  
  ///////////////////////end of agency f2 for money report
  //////////////f2 for client
  
  
  
  
  function F2fillclientcr_bar()
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_client")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('txt_client').value;
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=155+ "px" ;
            document.getElementById('div2').style.left=580+ "px";
            document.getElementById('lstclient').focus();
            BarterBill.fillF2_Creditclient(compcode,client,bindclient_callbackaa);
      }
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


  function Clickclient_bar()
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
                {
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
         else if(event.keyCode==27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('txt_client').focus();
         }
  }
  
  
  
  
function runclickbarter_bar()
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('XML/disschreg.xml');
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
    
      if(document.getElementById('drpbooktype').value=="0")
    {
    alert("Please Select Booking Type");
    document.getElementById('drpbooktype').focus();
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
 
 
 
    


    function drill_outstatus()
		{
		var str="";
				//alert(a)
		  try
{
		if(typeof(window.opener)!="undefined")
		{
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
						
						
						if($('divpdf').style.display=="block")
						
						{
					//x_win.location.href="reportstatus.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str +  "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&status=" + $('dpstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
					}
					else
					{
					//x_win.location.href="reportstatus.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str +  "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value  + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&status=" + $('dpstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50"+ "&sortvalue=" + "50";
					}
						
						window.close() 
					break;
					}
				}
		}
		else
		{
	for(i=0;i<$('dpadcatgory').length;i++)
						{
						    if($('dpadcatgory').options[i].selected==true)
						     {
						        str+=$('dpadcatgory').options[i].value+",";
				             }   		    
						}
	                //window.location.href="reportstatus.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str +  "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value +  "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&status=" + $('dpstatus').value  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
		}
	}
	catch(e)
	{
	
	window.open("/");
	}
		}
    
    function bind_team_exe()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var team=document.getElementById('dpteam').value;
      var userid=document.getElementById('hiddenuserid').value;
     
       
    ExecutiveReport.exe_bind(comp_code,userid,team,call_bind_team_exe);
   
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
    
     function validationexecnew()
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

    alrt=document.getElementById('lbteam').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('dpteam').value=="0")
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
    
    
    
  
 function btnrunclicknew()
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
    
    
     function daily_summarized()
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
        
         if(abc<abc1)
    {
       alert('todate cant be less from fromdate ');
        document.getElementById('txtfrmdate').value="";
       document.getElementById('txtfrmdate').focus();
       return false;

    }
    }
    
       var flagDate=compareDates();
if(flagDate ==false)
{
return false;
 } 
    } 
    
    
    
    function chkorder_nn()
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
    
     if(document.getElementById('dpaddtype').value=="0")
    {
    alert("Please Select AdType");
    document.getElementById('dpaddtype').focus();
    return false;
    }
    
    if(document.getElementById('dppub1').disabled != true)
    {
    
            if(document.getElementById('dppub1').value=="0")
            {
            alert("Please Select Publication");
            document.getElementById('dppub1').focus();
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
    
    document.getElementById('hiddenpackage').value=document.getElementById('drppackage').value;
 var des1=document.getElementById('drppackage').options.selectedIndex;
  if(des1!=-1)
    document.getElementById('hiddenpackagename').value=document.getElementById('drppackage').options[des1].text;
    
    document.getElementById('hdnsuppliment').value=document.getElementById('dpsuppliment').value;
    
    
         var flagDate=compareDates_schedule();
if(flagDate ==false)
{
return false;
 } 
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
    }
    
    ////////all ads client
    function allclient_f2()
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
    var    newstr1 = "";
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
//         var listadcat=document.getElementById('dpadcatgory');
//        for(var i=1;i<listadcat.options.length  ;  i++)
//        {
//         
//            if (listadcat.options[i].selected == true)
//            {
//              if (newstr == "")
//                {
//                    newstr = listadcat.options[i].value;
//                   newstr1 = listadcat.options[i].text;
//               }
//                else
//                {
//                   newstr = newstr + "," + listadcat.options[i].value;
//                    newstr1 = newstr1 + "," + listadcat.options[i].text;
//                }
//            }
//          
//        }
//        
//        
//        
//document.getElementById('hiddenadcat').value=newstr;
//document.getElementById('hiddenadcatname').value=newstr1;
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
    
function F2fillclientcr_allclient()
{
var key=event.keyCode?event.keyCode:event.which;
if(event.keyCode==113)
{
    if(document.activeElement.id=="dpclient")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('dpclient').value;
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
var key=event.keyCode?event.keyCode:event.which;
if(event.keyCode==113)
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
            document.getElementById('div2').style.top=155+ "px" ;
            document.getElementById('div2').style.left=580+ "px";
            document.getElementById('lstclient').focus();
            Reports_VTS.fillF2_Creditclient(compcode,client,bindclient_callbackaa);
      }
 }

}
function F2fillclientcr_page()
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
//function bindclient_callbackaa(res)
//{
//     var ds_AccName=res.value;
//       
//        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
//        {
//            var pkgitem = document.getElementById("lstclient");
//            pkgitem.options.length = 0; 
//            pkgitem.options[0]=new Option("-Select Client Name-","0");
//            pkgitem.options.length = 1; 
//            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
//            {
//                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name,ds_AccName.Tables[0].Rows[i].Cust_Code);         
//                pkgitem.options.length;
//            }
//        }
//        document.getElementById("lstclient").value="0";
//        document.getElementById("div2").value="";
//        document.getElementById('lstclient').focus();
//   
//        return false;

//}


function Clickclientaa(event)
{
     var browser=navigator.appName;
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
                {
                     var abc;
                    if (browser != "Microsoft Internet Explorer")
                     {
                        abc = document.getElementById('lstclient').options[k].textContent;
                    }
                    else 
                    {
                        abc = document.getElementById('lstclient').options[k].innerText;
                    }
                    
                    
                    
                  //  var abc=document.getElementById('lstclient').options[k].innerText;
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
  return true;
}


function chklstagencyaa(event)
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
  
       
 }
         /////////////////////////////////////////////////////////////////
         
         
         
         
function F2fillagencycr_status()
{
if(event.keyCode==113)
{
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

var key=event.keyCode?event.keyCode:event.which;
if(event.keyCode==113)
{
divid = "div1";
            listboxid = "lstagency";
    txtbxid=eval(document.getElementById('dpagency'))
    txtboxid="dpagency";
    if(document.activeElement.id=="dpagency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('dpagency').value.toUpperCase();
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=180+ "px" ;//314//290
            document.getElementById('div1').style.left=580+ "px";//395//1004
            document.getElementById('lstagency').focus();
             Reports_VTS.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb);
      }
 }

}

function F2fillagencycr_page(event)
{
var key=event.keyCode?event.keyCode:event.which;
if(event.keyCode==113)
{
    if(document.activeElement.id=="dpagency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('dpagency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=355+ "px" ;//314//290
            document.getElementById('div1').style.left=600+ "px";//395//1004
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
      var browser=navigator.appName;
   
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
                {
                 var abc;
                    if (browser != "Microsoft Internet Explorer")
                     {
                        abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else 
                    {
                        abc = document.getElementById('lstagency').options[k].innerText;
                    }
                    //var abc=document.getElementById('lstagency').options[k].innerText;
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
    function pagepremnew_f2()
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

function F2fillexecutivecr()
{
if(event.keyCode==113)
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
            categorywisereport.fillF2_Creditexecutive(compcode,executive,bindexecutive_callback);
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


function Clickexecutive()
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
                {
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
  //////////////run btn for category wise report
  function pivalidation_nn_cat()
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
      //////////////run btn for category wise report
  ////////////////////////////////////end of executive f2 for category wise report
  
  
  
  //////////////////agency f2 for money reprt
  
  
  
function F2fillagencycr_mon()
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_agency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('txt_agency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=180+ "px" ;//314//290
            document.getElementById('div1').style.left=580+ "px";//395//1004
            document.getElementById('lstagency').focus();
            moneyrecievedreport.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb);
      }
 }

}
  
  
function ClickAgaency_mon()
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
                {
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
         else if(event.keyCode==27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txt_agency').focus();
         }
  }
  
  ///////////////////////end of agency f2 for money report
  //////////////f2 for client
  
  
  
  
  function F2fillclientcr_mon()
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_client")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('txt_client').value;
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=155+ "px" ;
            document.getElementById('div2').style.left=580+ "px";
            document.getElementById('lstclient').focus();
            moneyrecievedreport.fillF2_Creditclient(compcode,client,bindclient_callbackaa);
      }
 }

}
  
  
  function Clickclient_mon()
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
                {
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
         else if(event.keyCode==27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('txt_client').focus();
         }
  }
  
 function clear()
{

  
        document.getElementById('dpagency').value="";
        document.getElementById('dpclient').value="";
       document.getElementById('dpdadtype').value="0";
//        document.getElementById('dpadcatgory').value="";
        document.getElementById('txtfrmdate').value="";
        document.getElementById('txttodate1').value="";
          
        document.getElementById('dppub1').value="0";
    //    document.getElementById('dppubcent').value="0";
      
        document.getElementById('dpedition').value="0";
       // document.getElementById("Drpedition").value="0";
     //   document.getElementById('dpd_branch').value="0";

        document.getElementById('DropDownClient').value="0";
        document.getElementById('Txtdest').value="0";
        document.getElementById('dpagency').focus();   
        return false;
  
   
} 
  
  
  ///////////run
  
function pivalidation_mon()
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
  

function F2fillretainercr_ret()
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


function Clickretainer_ret()
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
                {
                    var abc=document.getElementById('lstretainer').options[k].innerText;
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
  /////////run
   function daily_summarized_ret()
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
  function F2fillexecutivecr_reb()
{
if(event.keyCode==113)
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
function Clickexecutive_reb()
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
                {
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
  
function F2fillagencycr_exe()
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_agency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('txt_agency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=300+ "px" ;//314//290
            document.getElementById('div1').style.left=340+ "px";//395//1004
            document.getElementById('lstagency').focus();
            representative_ledger.fillF2_CreditAgency(compcode,agn,bindAgency_callbackbb1);
      }
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
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
   
        return false;

}
  
function ClickAgaency_exe()
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
                {
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
         else if(event.keyCode==27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txt_agency').focus();
         }
  }
  
  ///////////////////////end of agency f2 for money report
  //////////////f2 for client
  
  
  
  
  function F2fillclientcr_exe()
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_client")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('txt_client').value;
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=320+ "px" ;
            document.getElementById('div2').style.left=340+ "px";
            document.getElementById('lstclient').focus();
            representative_ledger.fillF2_Creditclient(compcode,client,bindclient_callbackaa1);
      }
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
        document.getElementById("lstclient").value="0";
        document.getElementById("div2").value="";
        document.getElementById('lstclient').focus();
   
        return false;

}


  function Clickclient_exe()
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
                {
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
         else if(event.keyCode==27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('txt_client').focus();
         }
  }
  
  
  function F2fillretainercr_exe()
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_retainer")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hiddencompcode').value;
            var retainer =document.getElementById('txt_retainer').value;
            document.getElementById("div4").style.display="block";
            document.getElementById('div4').style.top=385+ "px" ;
            document.getElementById('div4').style.left=650+ "px";
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
        document.getElementById("lstretainer").value="0";
        document.getElementById("div4").value="";
        document.getElementById('lstretainer').focus();
   
        return false;

}


function Clickretainer_exe()
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
                {
                    var abc=document.getElementById('lstretainer').options[k].innerText;
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
 
  if(document.getElementById('dpclient').value=="")
 { 
 document.getElementById('hdnclient').value=""
 document.getElementById('hiddendpclie').value=""
 }
 else if(document.getElementById('dpclient').value!="" && document.getElementById('hdnclient').value=="")
 { 
alert("Press F2 for client name")
document.getElementById('txt_client').value=""
document.getElementById('txt_client').focus()
return false
 }
 else if(document.getElementById('dpclient').value!="")
{
if(document.getElementById('dpclient').value!=document.getElementById('hiddendpclie').value)
{
alert("Press F2 for client name")
document.getElementById('dpclient').value=""
document.getElementById('hdnclient').value=""
document.getElementById('hdnclientname').value=""
document.getElementById('dpclient').focus();
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

function f2()
{
if(document.getElementById('lstpubcat1').value=="0")
                            {
                            alert("Please select the Pub cat");
                            return false;
                            }
                            }

/////////////f2 bil register
function F2fillexecutivecr_bill()
{
if(event.keyCode==113)
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
            BillRegister.fillF2_Creditexecutive(compcode,executive,bindexecutive_callback);
      }
 }

}
function Clickexecutive_bill()
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
                {
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
    
function F2fillagencycr_picon()
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_agency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('txt_agency').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=180+ "px" ;//314//290
            document.getElementById('div1').style.left=580+ "px";//395//1004
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
  
function ClickAgaency_picon()
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
                {
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
         else if(event.keyCode==27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txt_agency').focus();
         }
  }
  
  ///////////////////////end of agency f2 for money report
  //////////////f2 for client
  
  
  
  
  function F2fillclientcr_picon()
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txt_client")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client =document.getElementById('txt_client').value;
            document.getElementById("div2").style.display="block";
            document.getElementById('div2').style.top=155+ "px" ;
            document.getElementById('div2').style.left=580+ "px";
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


  function Clickclient_picon()
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
                {
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
         else if(event.keyCode==27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('txt_client').focus();
         }
  }
  
  
  function allads_nn_picon()
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
    
   