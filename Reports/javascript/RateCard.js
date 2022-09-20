//=====******************  This javascript used for Rate Card in Report **************//
var browser=navigator.appName;

function bindadcat_schedule()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var adtype1=document.getElementById('dpaddtype').value;
    var res1=RateCard.adcatbnd(adtype1,compcode);
    call_adcat_schedule(res1);
    var res2=RateCard.adpkg_bind(adtype1,compcode);
    call_pkg_schedule(res2);
    var resuom=RateCard.binduom(compcode,adtype1);
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

function forreport()
  {
    var fdate = document.getElementById("txtfrmdate").value;
    var tdate = document.getElementById("txttodate1").value;
    var  center = document.getElementById('drppubcenter').value;
    var  addtype  = document.getElementById("dpaddtype").value;
    
    var index1="";
    index1= document.getElementById('dpaddtype').selectedIndex;
    var adtype_nam="All";
    if(document.getElementById('dpaddtype').value !="0")
       adtype_nam=document.getElementById('dpaddtype').options[index1].text;
     index1= document.getElementById('drppubcenter').selectedIndex;
     var center_nam="All";
    if(document.getElementById('drppubcenter').value !="0")
       center_nam= document.getElementById('drppubcenter').options[index1].text;
     index1= document.getElementById('dpratecode').selectedIndex;
     var ratecode_nam="All";
    if(document.getElementById('dpratecode').value !="0")
       ratecode_nam= document.getElementById('dpratecode').options[index1].text;
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

//=========================================================//
    var    newstr = "";
    var newstr1 = "All";
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
 
    var package1=document.getElementById('drppackage').value;
    var  ratecode  = document.getElementById('dpratecode').value;
    var dpedidetail=document.getElementById("drpuom").value;
   var view=document.getElementById("Txtdest").value;

     window.open ("RateCard_View.aspx?fdate="+fdate+"&tdate="+ tdate +"&center1="+ center+"&dpaddtype="+ addtype+"&adcat="+ newstr+"&ratecode1="+ ratecode+ "&package1="+package1 +"&view="+view+"&ratecode_nam="+ratecode_nam+"&adtype_nam="+adtype_nam+"&center_nam="+center_nam+"&adcat_nam="+newstr1+"&dpedidetail="+dpedidetail);
    return false;
  
   }
