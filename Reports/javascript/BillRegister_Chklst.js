//================================== Javascript For Bill Register Checklist ==================================//
//Global Varible Declaration
var browser=navigator.appName;
//Javascript Function

//    function bind_edition13()
//    {
//        var comp_code=document.getElementById('hiddencompcode').value;
//        var pub_cent=document.getElementById('dppubcent').value;
//        //var publication=document.getElementById('dppub1').value;
//        BillRegister_Chklst.edition_bind(publication,pub_cent,comp_code,call_bind_edition); 
//    }

function call_bind_edition(response)
{
    ds= response.value;
    var edition=document.getElementById('dpedition');
    edition.options.length=1;
//    edition.options[0]=new Option("--Select Edition Name--");
//    document.getElementById("dpedition").options.length = 1;
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

function BindUom()
{
    var comp_code=document.getElementById('hiddencompcode').value;
    var resuom=BillRegister_Chklst.binduom(comp_code,document.getElementById('drpadtype').value);
    binduom_NEW(resuom);
}

function binduom_NEW(response)
{
    var ds=response.value;
    agcatby = document.getElementById("drpuom");
    agcatby.options.length = 1; 
    //    agcatby.options[0]=new Option("--Select Category--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var j=1;
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Uom_Name,ds.Tables[0].Rows[i].Uom_Code); 
           j++;
           
        }
    }
//document.getElementById("drprate").value = "0";
}

function forreport()
  {
    var fdate = document.getElementById("txtfrmdate").value;
    var tdate = document.getElementById("txttodate1").value;
   // var pub1 = document.getElementById("dppub1").value;
   var pub1="";
    var branch = document.getElementById("drpbranch").value;
   // var edition_code = document.getElementById("dpedition").value;
   var edition_code=document.getElementById("drpcolor").value;
    var  pubcent = document.getElementById('dppubcent').value;
    var  addtype  = document.getElementById("drpadtype").value;
    
    var Agencytype = document.getElementById("dpagtype").value;
    var ratecod = document.getElementById("drpratecode").value;
    var  uom = document.getElementById('drpuom').value;
    var  basedon  = document.getElementById("drpfilteron").value;
//var  dppubcent = document.getElementById('dpsuppliment').value;
    var index1="";
    index1= document.getElementById('drpadtype').selectedIndex;
    var adtype_nam="All";
    if(document.getElementById('drpadtype').value !="0")
       adtype_nam=document.getElementById('drpadtype').options[index1].text;
     ///index1= document.getElementById('dppub1').selectedIndex;
     var publication_nam="All";
   // if(document.getElementById('dppub1').value !="0")
    //   publication_nam= document.getElementById('dppub1').options[index1].text;
   //  index1= document.getElementById('dppubcent').selectedIndex;
     var pubcent_nam="All";
    if(document.getElementById('dppubcent').value !="0")
       pubcent_nam= document.getElementById('dppubcent').options[index1].text;
     //index1= document.getElementById('dpedition').selectedIndex;
     var edition_nam="All";
    //if(document.getElementById('dpedition').value !="0" && document.getElementById('dpedition').value!="")
      // edition_nam= document.getElementById('dpedition').options[index1].text;
//====Check for validateion===========//
 var alrt;
    if(browser!="Microsoft Internet Explorer")
        alrt=document.getElementById('lbDateFrom').innerHTML;
    else
        alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfrmdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter From Date');
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    } 
    if(browser!="Microsoft Internet Explorer")
        alrt=document.getElementById('lbToDate').innerHTML;
    else
        alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate1').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter To Date');
            document.getElementById('txttodate1').focus();
            return false;
      
        }
        

    }
    if(document.getElementById('drpadtype').value=="0")
    {
      ///  alert("Please Select AdType");
       //document.getElementById('drpadtype').focus();
      //  return false;
    }
    //if(document.getElementById('dppub1').disabled != true)
    {
//            if(document.getElementById('dppub1').value=="0")
//            {
//            alert("Please Select Publication");
//            document.getElementById('dppub1').focus();
//            return false;
//            }
    
    }

   var view=document.getElementById("Txtdest").value;
 var s= document.getElementById('dppubcent').selectedIndex;
    var printcentername= document.getElementById('dppubcent').options[s].text;

     window.open ("BillRegisterchklstview.aspx?fdate="+fdate+"&tdate="+ tdate+"&printcentername="+ printcentername +"&dppub1="+ pub1+"&branch="+ branch+"&dpedition1="+ edition_code+"&dppubcent="+ pubcent+"&dpaddtype="+ addtype+"&Agencytype="+Agencytype+"&ratecod="+ratecod+"&uom="+uom+"&Basedon="+basedon+"&view="+view+"&adtype_nam="+adtype_nam+"&publication_nam="+publication_nam+"&edition_nam="+edition_nam+"&pubcent_nam="+pubcent_nam);
    return false;
  
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


function forsummary()
  {
    var fdate = document.getElementById("txtfrmdate").value;
    var tdate = document.getElementById("txttodate1").value;
    //var pub1 = document.getElementById("dppub1").value;
    var pub1="";
    var branch = document.getElementById("drpbranch").value;
    //var edition_code = document.getElementById("dpedition").value;
    var edition_code=document.getElementById("drpcolor").value;
    var  pubcent = document.getElementById('dppubcent').value;
    var  addtype  = document.getElementById("drpadtype").value;
    
    var Agencytype = document.getElementById("dpagtype").value;
    var ratecod = document.getElementById("drpratecode").value;
    var  uom = document.getElementById('drpuom').value;
    var  basedon  = document.getElementById("drpfilteron").value;
//var  dppubcent = document.getElementById('dpsuppliment').value;
    var index1="";
    index1= document.getElementById('drpadtype').selectedIndex;
    var adtype_nam="All";
    if(document.getElementById('drpadtype').value !="0")
       adtype_nam=document.getElementById('drpadtype').options[index1].text;
     //index1= document.getElementById('dppub1').selectedIndex;
     var publication_nam="All";
    //if(document.getElementById('dppub1').value !="0")
      // publication_nam= document.getElementById('dppub1').options[index1].text;
     index1= document.getElementById('dppubcent').selectedIndex;
     var pubcent_nam="All";
    if(document.getElementById('dppubcent').value !="0")
       pubcent_nam= document.getElementById('dppubcent').options[index1].text;
     //index1= document.getElementById('dpedition').selectedIndex;
     var edition_nam="All";
   // if(document.getElementById('dpedition').value !="0" && document.getElementById('dpedition').value!="")
   //    edition_nam= document.getElementById('dpedition').options[index1].text;
//====Check for validateion===========//
 var alrt;
    if(browser!="Microsoft Internet Explorer")
        alrt=document.getElementById('lbDateFrom').innerHTML;
    else
        alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfrmdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter From Date');
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    } 
    if(browser!="Microsoft Internet Explorer")
        alrt=document.getElementById('lbToDate').innerHTML;
    else
        alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate1').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter To Date');
            document.getElementById('txttodate1').focus();
            return false;
      
        }
        

    }
    if(document.getElementById('drpadtype').value=="0")
    {
      //  alert("Please Select AdType");
      //  document.getElementById('drpadtype').focus();
      //  return false;
    }
   // if(document.getElementById('dppub1').disabled != true)
    {
//            if(document.getElementById('dppub1').value=="0")
//            {
//            alert("Please Select Publication");
//            document.getElementById('dppub1').focus();
//            return false;
//            }
    
    }

   var view=document.getElementById("Txtdest").value;
 var flag="1";
     window.open ("BillRegisterchklstsummry.aspx?fdate="+fdate+"&tdate="+ tdate +"&dppub1="+ pub1+"&branch="+ branch+"&flag="+ flag+"&dpedition1="+ edition_code+"&dppubcent="+ pubcent+"&dpaddtype="+ addtype+"&Agencytype="+Agencytype+"&ratecod="+ratecod+"&uom="+uom+"&Basedon="+basedon+"&view="+view+"&adtype_nam="+adtype_nam+"&publication_nam="+publication_nam+"&edition_nam="+edition_nam+"&pubcent_nam="+pubcent_nam);
    return false;


   }
   
   function fordetail()
  {
    var fdate = document.getElementById("txtfrmdate").value;
    var tdate = document.getElementById("txttodate1").value;
    //var pub1 = document.getElementById("dppub1").value;
    var pub1="";
    var branch = document.getElementById("drpbranch").value;
   // var edition_code = document.getElementById("dpedition").value;
   var edition_code =document.getElementById("drpcolor").value;
    var  pubcent = document.getElementById('dppubcent').value;
    var  addtype  = document.getElementById("drpadtype").value;
    
    var Agencytype = document.getElementById("dpagtype").value;
    var ratecod = document.getElementById("drpratecode").value;
    var  uom = document.getElementById('drpuom').value;
    var  basedon  = document.getElementById("drpfilteron").value;
//var  dppubcent = document.getElementById('dpsuppliment').value;
    var index1="";
    index1= document.getElementById('drpadtype').selectedIndex;
    var adtype_nam="All";
    if(document.getElementById('drpadtype').value !="0")
       adtype_nam=document.getElementById('drpadtype').options[index1].text;
     //index1= document.getElementById('dppub1').selectedIndex;
     var publication_nam="All";
    //if(document.getElementById('dppub1').value !="0")
       //publication_nam= document.getElementById('dppub1').options[index1].text;
     index1= document.getElementById('dppubcent').selectedIndex;
     var pubcent_nam="All";
    if(document.getElementById('dppubcent').value !="0")
       pubcent_nam= document.getElementById('dppubcent').options[index1].text;
     //index1= document.getElementById('dpedition').selectedIndex;
     var edition_nam="All";
   // if(document.getElementById('dpedition').value !="0" && document.getElementById('dpedition').value!="")
    //   edition_nam= document.getElementById('dpedition').options[index1].text;
//====Check for validateion===========//
 var alrt;
    if(browser!="Microsoft Internet Explorer")
        alrt=document.getElementById('lbDateFrom').innerHTML;
    else
        alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfrmdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter From Date');
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    } 
    if(browser!="Microsoft Internet Explorer")
        alrt=document.getElementById('lbToDate').innerHTML;
    else
        alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate1').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter To Date');
            document.getElementById('txttodate1').focus();
            return false;
      
        }
        

    }
    if(document.getElementById('drpadtype').value=="0")
    {
        //alert("Please Select AdType");
        //document.getElementById('drpadtype').focus();
        //return false;
    }
  //  if(document.getElementById('dppub1').disabled != true)
    {
//            if(document.getElementById('dppub1').value=="0")
//            {
//            alert("Please Select Publication");
//            document.getElementById('dppub1').focus();
//            return false;
//            }
    
    }
   var flag="2";
   var view=document.getElementById("Txtdest").value;

    window.open ("BillRegisterchklstsummry.aspx?fdate="+fdate+"&tdate="+ tdate +"&dppub1="+ pub1+"&branch="+ branch+"&flag="+ flag+"&dpedition1="+ edition_code+"&dppubcent="+ pubcent+"&dpaddtype="+ addtype+"&Agencytype="+Agencytype+"&ratecod="+ratecod+"&uom="+uom+"&Basedon="+basedon+"&view="+view+"&adtype_nam="+adtype_nam+"&publication_nam="+publication_nam+"&edition_nam="+edition_nam+"&pubcent_nam="+pubcent_nam);
   return false;


   }
     function dailyreportdata()
  {
    var fdate = document.getElementById("txtfrmdate").value;
    var tdate = document.getElementById("txttodate1").value;
    //var pub1 = document.getElementById("dppub1").value;
    var pub1="";
    var branch = document.getElementById("drpbranch").value;
    //var edition_code = document.getElementById("dpedition").value;
    var edition_code =document.getElementById("drpcolor").value;
    var  pubcent = document.getElementById('dppubcent').value;
    var  addtype  = document.getElementById("drpadtype").value;
    
    var Agencytype = document.getElementById("dpagtype").value;
    var ratecod = document.getElementById("drpratecode").value;
    var  uom = document.getElementById('drpuom').value;
    var  basedon  = document.getElementById("drpfilteron").value;
//var  dppubcent = document.getElementById('dpsuppliment').value;
    var index1="";
    index1= document.getElementById('drpadtype').selectedIndex;
    var adtype_nam="All";
    if(document.getElementById('drpadtype').value !="0")
       adtype_nam=document.getElementById('drpadtype').options[index1].text;
     //index1= document.getElementById('dppub1').selectedIndex;
     var publication_nam="All";
    //if(document.getElementById('dppub1').value !="0")
       //publication_nam= document.getElementById('dppub1').options[index1].text;
     index1= document.getElementById('dppubcent').selectedIndex;
     var pubcent_nam="All";
    if(document.getElementById('dppubcent').value !="0")
       pubcent_nam= document.getElementById('dppubcent').options[index1].text;
     //index1= document.getElementById('dpedition').selectedIndex;
     var edition_nam="All";
    //if(document.getElementById('dpedition').value !="0" && document.getElementById('dpedition').value!="")
      // edition_nam= document.getElementById('dpedition').options[index1].text;
//====Check for validateion===========//
 var alrt;
    if(browser!="Microsoft Internet Explorer")
        alrt=document.getElementById('lbDateFrom').innerHTML;
    else
        alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfrmdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter From Date');
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    } 
    if(browser!="Microsoft Internet Explorer")
        alrt=document.getElementById('lbToDate').innerHTML;
    else
        alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate1').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter To Date');
            document.getElementById('txttodate1').focus();
            return false;
      
        }
        

    }
    if(document.getElementById('dppubcent').value=="0")
    {
        alert("Please Select Pub Center");
        document.getElementById('dppubcent').focus();
        return false;
    }
  //  if(document.getElementById('dppub1').disabled != true)
    {
//            if(document.getElementById('dppub1').value=="0")
//            {
//            alert("Please Select Publication");
//            document.getElementById('dppub1').focus();
//            return false;
//            }
    
    }
   var flag="3";
   var view=document.getElementById("Txtdest").value;

    window.open ("BillRegisterchklstsummry.aspx?fdate="+fdate+"&tdate="+ tdate +"&dppub1="+ pub1+"&branch="+ branch+"&flag="+ flag+"&dpedition1="+ edition_code+"&dppubcent="+ pubcent+"&dpaddtype="+ addtype+"&Agencytype="+Agencytype+"&ratecod="+ratecod+"&uom="+uom+"&Basedon="+basedon+"&view="+view+"&adtype_nam="+adtype_nam+"&publication_nam="+publication_nam+"&edition_nam="+edition_nam+"&pubcent_nam="+pubcent_nam);
   return false;


   }