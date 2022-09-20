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
 document.getElementById('txttodate1').value="";
 document.getElementById('txttodate1').focus();
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

function F2fillagencycr_bar(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
    if(document.activeElement.id=="txt_agency")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn = document.getElementById('txt_agency').value.toUpperCase();
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
        
        var   aTag = eval(document.getElementById('txt_agency'))
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
                 document.getElementById('div1').style.left = document.getElementById('txt_agency').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div1').style.top = document.getElementById('txt_agency').offsetTop + toppos - scrolltop + "px"; //"510px";
        
        
        
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
   
        return false;

}

function ClickAgaency_bar(event) {
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
  
  
  
  
  function F2fillclientcr_bar(event) {
      var key = event.keyCode ? event.keyCode : event.which;
      if (key == 113)
{
    if(document.activeElement.id=="txt_client")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var client = document.getElementById('txt_client').value.toUpperCase();
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
        
        var   aTag = eval(document.getElementById('txt_client'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('div2').scrollLeft;
                 var scrolltop = document.getElementById('div2').scrollTop;
                 document.getElementById('div2').style.left = document.getElementById('txt_client').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div2').style.top = document.getElementById('txt_client').offsetTop + toppos - scrolltop + "px"; //"510px";
        
        
        
        document.getElementById("lstclient").value="0";
        document.getElementById("div2").value="";
        document.getElementById('lstclient').focus();
   
        return false;

}


function Clickclient_bar(event) {
      var key = event.keyCode ? event.keyCode : event.which;
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
                if(document.getElementById('lstclient').options[k].value==page) {
                    if (browser != "Microsoft Internet Explorer") {
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
      else if (key == 27)
         {
         
        document.getElementById("div2").style.display="none";
        document.getElementById('txt_client').focus();
         }
  }
  
  
  
  
function runclickbarter_bar() {
    if (browser == "Microsoft Internet Explorer") {
        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        loadXML('XML/disschreg.xml');
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




     function clearbookitype() {
        
         document.getElementById('txt_agency').value = "";
         document.getElementById('txt_client').value = "";
         document.getElementById('txtfrmdate').value = "";
         document.getElementById('txttodate1').value = "";
         document.getElementById('drpbooktype').value = "0";
         document.getElementById('dpregion').value = "0";
         document.getElementById('dpproduct').value = "0";
        // document.getElementById('dppubcent').value = "0";
         document.getElementById('Txtdest').value = "0";
         document.getElementById('txtfrmdate').focus();
     }





/////////////////////


