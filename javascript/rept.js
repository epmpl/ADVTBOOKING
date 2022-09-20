function bindadcategory()
{
var response=report2.getCategory(document.getElementById('dpdadtype').value);
     var ds=response.value;
    var pkgitem = document.getElementById("dpadcatgory");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Category--","0");
    
   

   // fillAdCat1();    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
        
       pkgitem.options.length;   
    }
 
    
    return false;
}
function bindadcategoryclient()
{
var response=report2.getCategory(document.getElementById('dpaddtype').value);
     var ds=response.value;
    var pkgitem = document.getElementById("dpadcatgory");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Category--","0");
    
   

   // fillAdCat1();    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
        
       pkgitem.options.length;   
    }
 
    
    return false;
}
// JScript File


function bindadcategoryclientfclkient()
{
var response=agencyclient.getCategory(document.getElementById('dpaddtype').value);
     var ds=response.value;
    var pkgitem = document.getElementById("dpadcatgory");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Category--","0");
    
   

   // fillAdCat1();    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
        
       pkgitem.options.length;   
    }
 
    
    return false;
}
// JScript File




var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;

function loadXML(xmlFile) 
{
    var  httpRequest =null;
    
    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
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
        // alert(xmlObj.childNodes(0).childNodes(0).text);
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
function verify() 
{ 
 
// //if (xmlDoc.readyState != 4) 
// { 
//   return false; 
// } 
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


    

function runclick()
{


var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/REPORT.xml');
    
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
//   if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    } 
}

function runclick2()
{
var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/reportagency.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
    var alrt;
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
//    if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    }
    
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
//if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    }
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
//    if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    }
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
//   if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    }     
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
//     if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    } 
   
       
}
function dateformate()

    {
    //var abc=new data('txtfrmdate')
      var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value


       if(document.getElementById('txttodate1').value!="")
       {
//    if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//       document.getElementById('txttodate1').value="";
//          document.getElementById('txttodate1').focus();
//       return false;

//    }
    }
    }
function printbtn()
{
document.getElementById('btnprint').visibility=false;
//Reportview.pdf(string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat);
window.print();
return false();
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
 document.getElementById('txtfrmdate').value="";
 document.getElementById('txtfrmdate').focus();
return false;
}
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
        
//         if(abc<abc1)
//    {
//       alert('todate cant be less from fromdate ');
//        document.getElementById('txtfrmdate').value="";
//       document.getElementById('txtfrmdate').focus();
//       return false;

//    }
    }
    } 
    
    
    //-------------------------------------------------------------------------------------------------
  
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
                     
//                     else if((abc[0]>mm) && (abc[2]=yyyy))
//                         {
//                            alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;  
//                         //break;
//                         }
//                         else if((abc[1]>dd)&&((abc[2]>yyyy))&& ((abc[0]>mm)))
//                         {
//                         alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;
//                         }
                        
                         
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
//                           if(abc[1] < splittodate[1])
//                           { 
//                              alert("From Date should not be greater than To date."); 
//                              document.getElementById('txtfrmdate').value="";
//                              document.getElementById('txtfrmdate').focus();
//                              return false;
//                           }
                           }
                             }
                                       
              }
}





 function checkrundate1()
 {  
//  var dateformat=document.getElementById('txttodate1').value;
//  var abc=dateformat.split("/");
//  var dateformat1=document.getElementById('hiddendateformat').value;
//  var thisdate =  new Date();
//  var dd   = thisdate.getDate();
//  var mm   =  thisdate.getMonth()+1;
//  var yyyy = thisdate.getYear();
//   //alert(" Please Fill The Date In "+dateformat+" Format");
//  var dateformatjava=mm+"/"+dd +"/"+yyyy;
//  
//    if(document.getElementById('txttodate1').value!="")
//       { 
//       if(dateformat1=="mm/dd/yyyy")
//            {
//            if(abc[2]>yyyy) 
//            {   
//            alert("To Date should not be greater than current date."); 
//            document.getElementById('txttodate1').value="";
//            document.getElementById('txttodate1').focus();
//            return false;  
//            //break;                                      
//            }
//            //                     goto label;
//            else if ((abc[2]==yyyy)&&(abc[0]>mm))
//            {
//            alert("To Date should not be greater than current date."); 
//            document.getElementById('txttodate1').value="";
//            document.getElementById('txttodate1').focus();
//            return false;
//            }
//            else if ((abc[2]==yyyy)&&(abc[0]==mm)&&(abc[1]>dd))
//            {
//            alert("To Date should not be greater than current date."); 
//            document.getElementById('txttodate1').value="";
//            document.getElementById('txttodate1').focus();
//            return false;
//            }
//            }
//            }
            }  
            
            
            
            
            
            
            
            
            
            
                   
//                     else if((abc[0]>mm) && (abc[2]=yyyy))
//                         {
//                            alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;  
//                         //break;
//                         }
//                         else if((abc[1]>dd)&&((abc[2]>yyyy))&& ((abc[0]>mm)))
//                         {
//                         alert("From Date should not be greater than current date."); 
//                            document.getElementById('txtfrmdate').value="";
//                            document.getElementById('txtfrmdate').focus();
//                            return true;
//                         }
                        

// else
// if(dateformat1=="yyyy/dd/mm")
// { 
//  }
//  
//  
// }



/**
 * DHTML date validation script. Courtesy of SmartWebby.com (http://www.smartwebby.com/dhtml/)
 */
// Declaring valid date character, minimum year and maximum year

//var dtCh= "/";
//var minYear=1900;
//var maxYear=2100;

//function isInteger(s)
//{
//	var i;
//    for (i = 0; i < s.length; i++)
//    {   
//        // Check that current character is number.
//        var c = s.charAt(i);
//        if (((c < "0") || (c > "9"))) return false;
//    }
//    // All characters are numbers.
//    return true;
//}

//function stripCharsInBag(s, bag)
//{
//	var i;
//    var returnString = "";
//    // Search through string's characters one by one.
//    // If character is not in bag, append to returnString.
//    for (i = 0; i < s.length; i++)
//    {   
//        var c = s.charAt(i);
//        if (bag.indexOf(c) == -1) returnString += c;
//    }
//    return returnString;
//}

//function daysInFebruary (year)
//{
//	// February has 29 days in any year evenly divisible by four,
//    // EXCEPT for centurial years which are not also divisible by 400.
//    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
//}
//function DaysArray(n) 
//{
//	for (var i = 1; i <= n; i++)
//	 {
//		this[i] = 31
//		if (i==4 || i==6 || i==9 || i==11) {this[i] = 30}
//		if (i==2) {this[i] = 29}
//} 
//   return this
//}

//function isDate(dtStr)
//{
//	var daysInMonth = DaysArray(12)
//	var pos1=dtStr.indexOf(dtCh)
//	var pos2=dtStr.indexOf(dtCh,pos1+1)
//	var strMonth=dtStr.substring(0,pos1)
//	var strDay=dtStr.substring(pos1+1,pos2)
//	var strYear=dtStr.substring(pos2+1)
//	strYr=strYear
//	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
//	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
//	for (var i = 1; i <= 3; i++) 
//	{
//		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
//	}
//	month=parseInt(strMonth)
//	day=parseInt(strDay)
//	year=parseInt(strYr)
//	if (pos1==-1 || pos2==-1)
//	{
//		alert("The date format should be : mm/dd/yyyy")
//		return false
//	}
//	if (strMonth.length<1 || month<1 || month>12)
//	{
//		alert("Please enter a valid month")
//		return false
//	}
//	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month])
//	{
//		alert("Please enter a valid day")
//		return false
//	}
//	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear)
//	{
//		alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
//		return false
//	}
//	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false)
//	{
//		alert("Please enter a valid date")
//		return false
//	}
//return true
//}

//function ValidateFormdate()
//{

//	var dt=document.Form1.txtbusineedate;
//	//var dt=ankur.value;
//	if (isDate(dt.value)==false)
//	{
//		dt.focus()
//		return false
//	}
//    return true
// }

// 
// 
// var daid;
// function abc()
// {
//    alert('hit');
//   
//    
// }
// function settime1()
// {
//     var dateformat=document.getElementById('hiddendateformat').value;
//     if(document.activeElement.id.indexOf('dan')<0 && document.activeElement.id!='')
//     {
//        alert(" Please Fill The Date In "+dateformat+" Format");
//        daid.focus();
//        daid.value="";
//        
//      }
//     //input.focus();
// }
// function checkdate(input)
// {
// var dateformat=document.getElementById('hiddendateformat').value;
// if(dateformat=="mm/dd/yyyy")
// 
// {
// var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
// 
// }
// if(dateformat=="yyyy/mm/dd")
// 
// {
//var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
//}
//if(dateformat=="dd/mm/yyyy")
//{
//var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
//}

//if (!validformat.test(input.value))
//{
//if(input.value=="")
//{
//return true;
//}
////alert(document.activeElement.id);
////alert(" Please Fill The Date In "+dateformat+" Format");
////popUpCalendar(document.activeElement,document.activeElement,dateformat);
//setTimeout(settime1,15);
//daid=input;
////return false;
//return;
//}
//else
//{ 
////Detailed check for valid date ranges
//if(dateformat=="yyyy/mm/dd")

//{
//var yearfield=input.value.split("/")[0]
//var monthfield=input.value.split("/")[1]
//var dayfield=input.value.split("/")[2]
//var dayobj = new Date(yearfield, monthfield-1, dayfield)
//}
//if(dateformat=="mm/dd/yyyy")

//{
//var yearfield=input.value.split("/")[2]
//var monthfield=input.value.split("/")[0]
//var dayfield=input.value.split("/")[1]
////var dayobj = new Date(monthfield-1, dayfield, yearfield)
//var dayobj = new Date(yearfield, monthfield-1, dayfield)

//}
//if(dateformat=="dd/mm/yyyy")
//{
//var yearfield=input.value.split("/")[2]
//var monthfield=input.value.split("/")[1]
//var dayfield=input.value.split("/")[0]
////var dayobj = new Date(dayfield, monthfield-1, yearfield)
//var dayobj = new Date(yearfield, monthfield-1, dayfield)
//}
//}

////if ((dayobj.getMonth()+1!=monthfield)||(dayobj.getDate()!=dayfield)||(dayobj.getFullYear()!=yearfield)) 
//var abcd= dayobj.getMonth()+1;

//var date1=dayobj.getDate();
//var year1=dayobj.getFullYear();
//if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
//{
//alert(" Please Fill The Date In "+dateformat+" Format");
//input.value="";
//return false;
//}


// 
//returnval=true
// 


//if (returnval==false) 

//input.select()
//return returnval

//}
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





function windowreort()
{


if(event.keyCode==113) 
{

//$('txtpopup').style.display="block";
//$('frmpopup').src="alladday.aspx";
window.open('alladday.aspx','','height=500px,width=550px');
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


function windowreport3()
{


if(event.keyCode==113) 
{
window.open('statuspop.aspx','','height=500px,width=400px');
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
function windowreport6()
{
if(event.keyCode==113) 
{
window.open('statuspop.aspx','','height=600px,width=550px');
}

}
function windowreport7()
{
if(event.keyCode==113) 
{
window.open('deviationpop.aspx','','height=600px,width=550px');
}

}




function windowclose()
{
window.close();
}




//if(event.keyCode==113) 
//{
//windowop('BarterBill2.aspx');
//}
function windowop(pagename)
{
if(event.keyCode==113)
{
window.open(pagename ,'','height=550px,width=550px'); 
}
//window.close();
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
						
					x_win.location.href="Deviationview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str + "&fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value +"&status1=" + $('dpstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
					}
						
						
						else
						
						{
				x_win.location.href="Deviationview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str + "&fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value  +"&status1=" + $('dpstatus').value +  "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50" + "&sortvalue=" + "50";

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
	window.location.href="Deviationview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str + "&fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&status1=" + $('dpstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			//window.location.href="reportview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&drilout=" + "yes" + "&destination="+"1";
			//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
		}
	}
	catch(e)
	{
	
	window.open("/");
	}
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
					x_win.location.href="reportview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
					}
					else
					{
					x_win.location.href="reportview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50" + "&sortvalue=" + "50";
					
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
	         x_win.location.href="reportview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes"  + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			//window.location.href="reportview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes"  + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			
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
					x_win.location.href="reportview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
					}
					else
					{
					x_win.location.href="reportview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50" + "&sortvalue=" + "50";
					
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
	window.location.href="reportview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes"  + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			
		}
	}
	catch(e)
	{
	
	window.open("/");
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
					x_win.location.href="reportstatus.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str +  "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&status=" + $('dpstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
					}
					else
					{
					x_win.location.href="reportstatus.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str +  "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&status=" + $('dpstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50"+ "&sortvalue=" + "50";
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
	                window.location.href="reportstatus.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str +  "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&status=" + $('dpstatus').value  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
		}
	}
	catch(e)
	{
	
	window.open("/");
	}
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
						  
						
					x_win.location.href="reportview2.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
					}
					else
					{
					x_win.location.href="reportview2.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50" + "&sortvalue=" + "50";
					
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
	window.location.href="reportview2.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str  + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			//window.location.href="reportview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&drilout=" + "yes" + "&destination="+"1";
			//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
		}
	}
	catch(e)
	{
	
	window.open("/");
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
						
					x_win.location.href="Agencycliview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str + "&fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&drilout=" + "yes" +  "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
					}
					else
					{
					x_win.location.href="Agencycliview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str + "&fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&drilout=" + "yes" +  "&destination=" + $('Txtdest').value+ "&sortorder=" + "50" + "&sortvalue=" + "50";
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
	window.location.href="Agencycliview.aspx?adtype=" + $('dpdadtype').value + "&adcategory=" + str + "&fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "package=" + $('dppackage').value + "&client=" + $('dpclient').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
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
  function runReport()
     {  
     if(document.getElementById('txtFromDate').value=="")
     {
        alert("Please Enter From Date");
        document.getElementById('txtFromDate').focus();
        return false;
     }
     else if(document.getElementById('txtToDate').value=="")
     {
        alert("Please Enter To Date");
        document.getElementById('txtToDate').focus();
        return false;
     }
  	var fromdate=document.getElementById('txtFromDate').value;
		var todate=document.getElementById('txtToDate').value;
		
		//
		var dateformat=document.getElementById('hiddendateformat').value;
		//For From Date Converssion 
        if(dateformat=="dd/mm/yyyy")
        {
            if(fromdate != "")
            {
                var txt=fromdate;
                 var txt1;
                if(txt.indexOf("-")>=0)
                {
                     txt1=txt.split("-");
                }
                else{
                    txt1=txt.split("/");
                }
               
                var dd=txt1[0];
                var mm1=txt1[1];
                var mm;
                 if(txt.indexOf("-")>=0)
                 {
                     mm = getMonthNo(mm1);
                }
                else
                {
                    mm=mm1;
                }
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                fromdate=fromdate;
            }

        }
        
        if(dateformat=="yyyy/mm/dd")
        {
            if(fromdate!="")
            {
                var txt=fromdate;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                fromdate=fromdate;
            }
        }
        
        if(dateformat=="mm/dd/yyyy")
        {
            fromdate=fromdate;
        }
        
        //For From Date Converssion /************************************************************/
        if(dateformat=="dd/mm/yyyy")
        {
            if(todate != "")
            {
                var txt=todate;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                todate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                todate=todate;
            }

        }
        
        if(dateformat=="yyyy/mm/dd")
        {
            if(todate!="")
            {
                var txt=todate;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                todate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                todate=todate;
            }
        }
        
        if(dateformat=="mm/dd/yyyy")
        {
            todate=todate;
        }
        	var fdate=new Date(fromdate);
		fdate.setDate(fdate.getDate()+1);
		var tdate=new Date(todate);
		if(tdate<fdate)
		{
		    alert("To Date Can't be less than From Date");
		    return false;
		}

        window.location.href="displayadstatus.aspx?fromdate="+document.getElementById('txtFromDate').value+"&todate="+document.getElementById('txtToDate').value+"&edition="+document.getElementById('drpedition').value;
        return false;
     }
     
     
     
     /////////////////////all day report////////////////////////
     
   function allagency_f28989()
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
        
       /* if(document.getElementById('dpagencyna').value!="")
{
if(document.getElementById('dpagencyna').value!=document.getElementById('hdnagencytxt').value)
{
alert("Press F2 To Bind a Valid Agency");
document.getElementById('dpagency').value=""
document.getElementById('dpagency').focus();
return false;
}
}*/
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
                    newstr1 =  newstr1+ "," + listadcat.options[i].text;
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
     //////////////////////new added agency report////////////////
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
        
       /* if(document.getElementById('dpagencyna').value!="")
{
if(document.getElementById('dpagencyna').value!=document.getElementById('hdnagencytxt').value)
{
alert("Press F2 To Bind a Valid Agency");
document.getElementById('dpagency').value=""
document.getElementById('dpagency').focus();
return false;
}
}*/
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
                    newstr1 =  newstr1+ "," + listadcat.options[i].text;
                }
            }
          
        }
        
     var adcat_type=document.getElementById('dpagencyna').value
         document.getElementById('hiddenagencyname').value=adcat_type;
		 var des_adty1=document.getElementById('dpagencyna').options.selectedIndex;
        if(des_adty1!=-1)document.getElementById('hiddenagency').value=document.getElementById('dpagencyna').options[des_adty1].text;        
	     var ad_type=document.getElementById('hiddenagency').value
        
        
        
     
        
        
        
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
    
    
    ////////////////////////////////////////////////////////client report///////////
    
    
    
     function allagency_f24354()
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
        
       /* if(document.getElementById('dpagencyna').value!="")
{
if(document.getElementById('dpagencyna').value!=document.getElementById('hdnagencytxt').value)
{
alert("Press F2 To Bind a Valid Agency");
document.getElementById('dpagency').value=""
document.getElementById('dpagency').focus();
return false;
}
}*/
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




var adcat_type=document.getElementById('dpagencycli').value
         document.getElementById('hiddenagencycode').value=adcat_type;
		 var des_adty1=document.getElementById('dpagencycli').options.selectedIndex;
        if(des_adty1!=-1)document.getElementById('hiddenclientname').value=document.getElementById('dpagencycli').options[des_adty1].text;        
	     var ad_type=document.getElementById('hiddenclientname').value
	     
	     
	     
//document.getElementById('hiddenclientname').value=document.getElementById('dpagencycli').value;
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
    
    /////////////////////////////////
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

    