//=====******************  This javascript used for AttendenceRegister in Report **************//
var browser=navigator.appName;

//========Start Funcion============//

function suppforschedule()
{

var compcode=document.getElementById('hdncompcode').value;
var edition=document.getElementById('dpedition').value;
AttendenceRegister.bindsupp(compcode,edition,call_suppforschedule);
}
function call_suppforschedule(response)
{
ds= response.value;
    var edition=document.getElementById('dpsuppliment');
    edition.options.length=1;
//    edition.options[0]=new Option("Select Supplement");
//    document.getElementById("dpsuppliment").options.length = 1;
    

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

function bindadcat_schedule()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpaddtype').value;
var res1=AttendenceRegister.adcatbnd(adtype1,compcode);
call_adcat_schedule(res1);
var res2=AttendenceRegister.adpkg_bind(adtype1,compcode);
call_pkg_schedule(res2);
var resuom=AttendenceRegister.binduom(compcode,adtype1);
binduom_NEW(resuom);
}
function binduom_NEW(response)
{
    var ds=response.value;
    agcatby = document.getElementById("drpuom");
    agcatby.options.length = 1; 
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var j=1;
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Uom_Name,ds.Tables[0].Rows[i].Uom_Code); 
           j++;
           
        }
    }
}
function call_adcat_schedule(response)
{
ds= response.value;
    var brand=document.getElementById('dpadcatgory');
    brand.options.length=1;
//    brand.options[0]=new Option("--Select AdCat--");
//    document.getElementById("dpadcatgory").options.length = 1;
    

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
    brand.options.length=1;
//    brand.options[0]=new Option("--Select Package--");
//    document.getElementById("drppackage").options.length = 1;
//    

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
    function bind_edition_sch()
    {
     var comp_code=document.getElementById('hiddencompcode').value;
     var pub_cent=document.getElementById('dppubcent').value;
     var publication=document.getElementById('dppub1').value;
       
    AttendenceRegister.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
    }
    
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
    brand.options[0]=new Option("--Select Package--","0");
    document.getElementById("drppackage").options.length = 1;
           //  document.getElementById("drppackage").value = "0";
        }
}
function forreport()
  {
    var fdate = document.getElementById("txtfrmdate").value;
    var tdate = document.getElementById("txttodate1").value;
    var pub1 = document.getElementById("dppub1").value;
    var status1 = "";
    var edition_code = document.getElementById("dpedition").value;
    var  pubcent = document.getElementById('dppubcent').value;
    var  addtype  = document.getElementById("dpaddtype").value;
//var  dppubcent = document.getElementById('dpsuppliment').value;
    var index1="";
    index1= document.getElementById('dpaddtype').selectedIndex;
    var adtype_nam="All";
    if(document.getElementById('dpaddtype').value !="0")
       adtype_nam=document.getElementById('dpaddtype').options[index1].text;
     index1= document.getElementById('dppub1').selectedIndex;
     var publication_nam="All";
    if(document.getElementById('dppub1').value !="0")
       publication_nam= document.getElementById('dppub1').options[index1].text;
     index1= document.getElementById('dppubcent').selectedIndex;
     var pubcent_nam="All";
    if(document.getElementById('dppubcent').value !="0")
       pubcent_nam= document.getElementById('dppubcent').options[index1].text;
     index1= document.getElementById('dpedition').selectedIndex;
     var edition_nam="All";
    if(document.getElementById('dpedition').value !="0" && document.getElementById('dpedition').value!="")
       edition_nam= document.getElementById('dpedition').options[index1].text;
//     index1= document.getElementById('dpaddtype').selectedIndex;
//    var adtype_nam= document.getElementById('dpaddtype').options[index1].text;
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
    if(document.getElementById('dpaddtype').value=="0")
    {
        alert("Please Select AdType");
        document.getElementById('dpaddtype').focus();
        return false;
    }
     if(document.getElementById('dppubcent').value=="0" || document.getElementById('dppubcent').value=="")
        {
           alert("Please Select Publication Center");
            document.getElementById('dppubcent').focus();
            return false;
      
        }
    if(document.getElementById('dpd_branch').value=="0" && document.getElementById('drpbookfrom').value=="Y")
    {
        alert("Please Select Branch");
        document.getElementById('dpd_branch').focus();
        return false;
  
    }
//    if(document.getElementById('dppub1').disabled != true)
//    {
//            if(document.getElementById('dppub1').value=="0")
//            {
//            alert("Please Select Publication");
//            document.getElementById('dppub1').focus();
//            return false;
//            }
//    
//    }
//=========================================================//
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
        var listadsubcat=document.getElementById('lstadsubcat');
        
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
       //"desc"//"asc" 
    var  supplement  = document.getElementById('dpsuppliment').value;
    var package1=document.getElementById('drppackage').value;
    var dpedidetail=document.getElementById("drpuom").value;
    var dpd_branch=document.getElementById("dpd_branch").value;
      var a= document.getElementById('dpd_branch').selectedIndex;
    var branch_name= document.getElementById('dpd_branch').options[a].text;
  var billflag=document.getElementById("drpflag").value;
    var drpbookfrom=document.getElementById("drpbookfrom").value;
   var view=document.getElementById("Txtdest").value;
   var dummyreport=document.getElementById("drpdummy").value;
   var branchbaseddate=document.getElementById("drpbranchbased").value;
   var allreaybilled="0";
     window.open ("AttendenceRegister_view.aspx?fdate="+fdate+"&tdate="+ tdate +"&dppub1="+ pub1+"&branchbaseddate="+ branchbaseddate+"&drpstatus="+ status1+"&allreaybilled="+ allreaybilled+"&dpedition1="+ edition_code+"&dppubcent="+ pubcent+"&dpaddtype="+ addtype+"&adcat="+ newstr+"&supplement="+ supplement+ "&package1="+package1 +"&dpedidetail="+dpedidetail+"&branch_name="+branch_name+"&dpd_branch="+dpd_branch+"&view="+view+"&adtype_nam="+adtype_nam+"&publication_nam="+publication_nam+"&subcatcode="+subcatcode+"&subcat="+subcat+"&edition_nam="+edition_nam+"&dummyreport="+dummyreport+"&billflag="+billflag+"&pubcent_nam="+pubcent_nam+"&adcat_nam="+newstr1+"&drpbookfrom="+drpbookfrom);
    return false;
  
   }
   function forreportbilled()
  {
    var fdate = document.getElementById("txtfrmdate").value;
    var tdate = document.getElementById("txttodate1").value;
    var pub1 = document.getElementById("dppub1").value;
    var status1 = "";
    var edition_code = document.getElementById("dpedition").value;
    var  pubcent = document.getElementById('dppubcent').value;
    var  addtype  = document.getElementById("dpaddtype").value;
//var  dppubcent = document.getElementById('dpsuppliment').value;
    var index1="";
    index1= document.getElementById('dpaddtype').selectedIndex;
    var adtype_nam="All";
    if(document.getElementById('dpaddtype').value !="0")
       adtype_nam=document.getElementById('dpaddtype').options[index1].text;
     index1= document.getElementById('dppub1').selectedIndex;
     var publication_nam="All";
    if(document.getElementById('dppub1').value !="0")
       publication_nam= document.getElementById('dppub1').options[index1].text;
     index1= document.getElementById('dppubcent').selectedIndex;
     var pubcent_nam="All";
    if(document.getElementById('dppubcent').value !="0")
       pubcent_nam= document.getElementById('dppubcent').options[index1].text;
     index1= document.getElementById('dpedition').selectedIndex;
     var edition_nam="All";
    if(document.getElementById('dpedition').value !="0" && document.getElementById('dpedition').value!="")
       edition_nam= document.getElementById('dpedition').options[index1].text;
//     index1= document.getElementById('dpaddtype').selectedIndex;
//    var adtype_nam= document.getElementById('dpaddtype').options[index1].text;
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
    if(document.getElementById('dpaddtype').value=="0")
    {
        alert("Please Select AdType");
        document.getElementById('dpaddtype').focus();
        return false;
    }
     if(document.getElementById('dppubcent').value=="0" || document.getElementById('dppubcent').value=="")
        {
           alert("Please Select Publication Center");
            document.getElementById('dppubcent').focus();
            return false;
      
        }
    if(document.getElementById('dpd_branch').value=="0" && document.getElementById('drpbookfrom').value=="Y")
    {
        alert("Please Select Branch");
        document.getElementById('dpd_branch').focus();
        return false;
  
    }
//    if(document.getElementById('dppub1').disabled != true)
//    {
//            if(document.getElementById('dppub1').value=="0")
//            {
//            alert("Please Select Publication");
//            document.getElementById('dppub1').focus();
//            return false;
//            }
//    
//    }
//=========================================================//
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
        var listadsubcat=document.getElementById('lstadsubcat');
        
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
       //"desc"//"asc" 
    var  supplement  = document.getElementById('dpsuppliment').value;
    var package1=document.getElementById('drppackage').value;
    var dpedidetail=document.getElementById("drpuom").value;
    var dpd_branch=document.getElementById("dpd_branch").value;
      var a= document.getElementById('dpd_branch').selectedIndex;
    var branch_name= document.getElementById('dpd_branch').options[a].text;
  var billflag=document.getElementById("drpflag").value;
    var drpbookfrom=document.getElementById("drpbookfrom").value;
   var view=document.getElementById("Txtdest").value;
   var dummyreport=document.getElementById("drpdummy").value;
   var allreaybilled="1";
     var branchbaseddate=document.getElementById("drpbranchbased").value;

   window.open ("AttendenceRegister_view.aspx?fdate="+fdate+"&tdate="+ tdate +"&dppub1="+ pub1+"&branchbaseddate="+ branchbaseddate+"&drpstatus="+ status1+"&allreaybilled="+ allreaybilled+"&dpedition1="+ edition_code+"&dppubcent="+ pubcent+"&dpaddtype="+ addtype+"&adcat="+ newstr+"&supplement="+ supplement+ "&package1="+package1 +"&dpedidetail="+dpedidetail+"&branch_name="+branch_name+"&dpd_branch="+dpd_branch+"&view="+view+"&adtype_nam="+adtype_nam+"&publication_nam="+publication_nam+"&subcatcode="+subcatcode+"&subcat="+subcat+"&edition_nam="+edition_nam+"&dummyreport="+dummyreport+"&billflag="+billflag+"&pubcent_nam="+pubcent_nam+"&adcat_nam="+newstr1+"&drpbookfrom="+drpbookfrom);
     return false;
  
   }
    function adsubcat_bind()
    {
     var ad_type=document.getElementById('dpaddtype').value;
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
        
    AttendenceRegister.bind_adsubcat(newstr,newstr1,call_adsubcat_bind);
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
   