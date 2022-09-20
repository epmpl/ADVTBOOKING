var browser=navigator.appName;
function bindQBC(event)
{

  var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("drpbranch")!=null)
            document.getElementById("drpbranch").focus();
         return false;        
    }
//Booking_Audit1.fillQBC(document.getElementById('drprevenu').value,bindQBC_callback);
var userid=document.getElementById("hiddenuserid").value;
ad_rep_roapproval_detail.fillQBC(userid,bindQBC_callback);
}
function bindQBC_callback(response)
{
    //alert(response.value);
    var ds=response.value;
   // agcatby = 
   var pkgitem = document.getElementById("drpbranch");
 pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Branch--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    //var j=1;
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].BRANCH_CODE);
        
       pkgitem.options.length;
    }
    }
    document.getElementById("drpbranch").focus();
}
function fillAgency(event)
{ 

     var key=event.keyCode?event.keyCode:event.which;
  
  
    if(key==113) 
    {
    
    
        if(document.activeElement.id=="txtagency")
        {
        var extra1=document.getElementById('txtagency').value;
        var extra2="";
       
       extra1=extra1.toUpperCase();
        
        document.getElementById('lstagency').value="";
         
        
         
         var compcode =  document.getElementById("hiddencomcode").value;
        document.getElementById("divagency").style.display="block";
        
       
        
        document.getElementById('divagency').style.top=280+ "px" ;
        document.getElementById('divagency').style.left=470+ "px";
        var dateformat = "'dd/mm/yyyy'";

       var ret=document.getElementById('txtagency').value

        document.getElementById('lstagency').focus();
       
        
       
         ad_rep_roapproval_detail.fill_agency(compcode,'',dateformat,extra1,extra2, bindcity_callback)
         }
         }
          //==============add for enter===============
  var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("txtexecname")!=null)
            document.getElementById("txtexecname").focus();
         return false;        
    }
    }
function bindcity_callback(res)
{


     ds =res.value;
     document.getElementById("lstagency").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
     {
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0;
        pkgitem.options[0]=new Option("-Select Agency-","0");
        pkgitem.options.length = 1;
       
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name+ "("+ ds.Tables[0].Rows[i].Agency_Code + ")",ds.Tables[0].Rows[i].Agency_Code + "-" + ds.Tables[0].Rows[i].SUB_Agency_Code);
        pkgitem.options.length;
        }
     }
     
       document.getElementById("divagency").style.display="block";
     document.getElementById('lstagency').focus();
     return false;
}
function onclickagency(event)
{
var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
     
            if(document.activeElement.id=="lstagency")
            {        
          
                if(document.getElementById('lstagency').value=="0")
                {
                alert("Please select the Main group");
                return false;
                }     
                var page=document.getElementById('lstagency').value;
                agencycodeglo=page;               
                if(browser!="Microsoft Internet Explorer")
                {              
                    for(var k=0;k <= document.getElementById("lstagency").length-1;k++)
                    { 
                                   
                        var abc=document.getElementById('lstagency').options[k].textContent;
                        if(document.getElementById('lstagency').options[k].value==page)
                        { 
                          
                            var abc=document.getElementById('lstagency').options[k].textContent;
                            var allvalues=document.getElementById('lstagency').options[k].value;
                            var splitvalue= allvalues.split("-");
                            var fival = abc.split("(");
                            document.getElementById('txtagency').value= abc;
                           savemainagcode = splitvalue[0];
                           savemainagsubcode = splitvalue[1];
                           document.getElementById("hiddenagencycode2").value=savemainagcode;
                          
                           var hdsAgcode=savemainagcode+savemainagsubcode;
                           document.getElementById("hiddenagencycode").value=hdsAgcode;
                           var ag11 = abc.split("(")
                            document.getElementById("txtagency").focus();
                           break;
                        }
                    }
                }
                else
                {
                    for(var k=0;k <= document.getElementById("lstagency").length-1;k++)
                    {
                        if(document.getElementById('lstagency').options[k].value==page)
                        {
                            var abc=document.getElementById('lstagency').options[k].innerText;
                            var allvalues=document.getElementById('lstagency').options[k].value;
                            var splitvalue= allvalues.split("-");
                            var fival = abc.split("(");
                            document.getElementById('txtagency').value= abc;
                           savemainagcode = splitvalue[0];
                           savemainagsubcode = splitvalue[1];
                           document.getElementById("hiddenagencycode2").value=savemainagcode;
                          
                           var hdsAgcode=savemainagcode+savemainagsubcode;
                           document.getElementById("hiddenagencycode").value=hdsAgcode;
                           var ag11 = abc.split("(")
                            document.getElementById("txtagency").focus();
                           break;
                          }
                    }
                }
                document.getElementById("divagency").style.display='none';
                return false;
                }
    }
    else if (key==27)
    {
    document.getElementById("divagency").style.display='none';
     document.getElementById("txtagency").focus();
    }
}

function fillclient(event)
{ 

     var key=event.keyCode?event.keyCode:event.which;
  
  
    if(key==113) 
    {
    
    
        if(document.activeElement.id=="txtclient")
        {
        var client=document.getElementById('txtclient').value;
       
       client =client.toUpperCase();
        
        document.getElementById('lstclient').value="";
         
        
         
         var compcode =  document.getElementById("hiddencomcode").value;
        document.getElementById("divclient").style.display="block";
        
       
        
        document.getElementById('divclient').style.top=300+ "px" ;
        document.getElementById('divclient').style.left=480+ "px";
       

       
        document.getElementById('lstclient').focus();
       
        
       
         ad_rep_roapproval_detail.fillF2_Creditclient(compcode,client, bindclient_callback)
         }
         }
          //==============add for enter===============
  var evtobj=window.event? window.event :event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("txtret")!=null)
            document.getElementById("txtret").focus();
         return false;        
    }
 
}
function bindclient_callback(res)
{


     ds =res.value;
     document.getElementById("lstclient").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
     {
        var pkgitem = document.getElementById("lstclient");
        pkgitem.options.length = 0;
        pkgitem.options[0]=new Option("-Select Client-","0");
        pkgitem.options.length = 1;
       
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name+ "("+ ds.Tables[0].Rows[i].Cust_Code + ")",ds.Tables[0].Rows[i].Cust_Code);
        pkgitem.options.length;
        }
     }
     
       document.getElementById("divclient").style.display="block";
     document.getElementById('lstclient').focus();
     return false;
}
function onclickclient(event)
{
var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
     
            if(document.activeElement.id=="lstclient")
            {        
          
                if(document.getElementById('lstclient').value=="0")
                {
                alert("Please slect Client");
                return false;
                }     
                var page=document.getElementById('lstclient').value;
                agencycodeglo=page;               
                if(browser!="Microsoft Internet Explorer")
                {              
                    for(var k=0;k <= document.getElementById("lstclient").length-1;k++)
                    {                      
                        var abc=document.getElementById('lstclient').options[k].textContent;
                        if(document.getElementById('lstclient').options[k].value==page)
                        { 
                            var abc=document.getElementById('lstclient').options[k].textContent;
                            var allvalues=document.getElementById('lstclient').options[k].value;
                            var splitvalue= allvalues.split("-");
                            var fival = abc.split("(");
                            document.getElementById('txtclient').value= abc;
                           savemainagcode = splitvalue[0];
                           savemainagsubcode = splitvalue[1];
                           document.getElementById("hiddenclientcode2").value=savemainagcode;
                       
                           var hdsAgcode=savemainagcode+savemainagsubcode;
                           document.getElementById("hiddenclientcode").value=hdsAgcode;
                           var ag11 = abc.split("(")
                            document.getElementById("txtclient").focus();
                           break;
                        }
                    }
                }
                else
                {
                    for(var k=0;k <= document.getElementById("lstclient").length-1;k++)
                    {
                        if(document.getElementById('lstclient').options[k].value==page)
                        {
                            var abc=document.getElementById('lstclient').options[k].innerText;
                            var allvalues=document.getElementById('lstclient').options[k].value;
                            var splitvalue= allvalues.split("-");
                            var fival = abc.split("(");
                            document.getElementById('txtclient').value= abc;
                           savemainagcode = splitvalue[0];
                           savemainagsubcode = splitvalue[1];
                           document.getElementById("hiddenclientcode2").value=savemainagcode;
                       
                           var hdsAgcode=savemainagcode+savemainagsubcode;
                           document.getElementById("hiddenclientcode").value=hdsAgcode;
                           var ag11 = abc.split("(")
                            document.getElementById("txtclient").focus();
                           break;
                          }
                    }
                }
                document.getElementById("divclient").style.display='none';
                return false;
                }
    }
    else if (key==27)
    {
    document.getElementById("divclient").style.display='none';
     document.getElementById("txtclient").focus();
    }
}
function fillexcutive(event)
{ 

     var key=event.keyCode?event.keyCode:event.which;
  
  
    if(key==113) 
    {
    
    
        if(document.activeElement.id=="txtexecname")
        {
        var client=document.getElementById('txtexecname').value;
       
       client =client.toUpperCase();
        
        document.getElementById('istexcutive').value="";
         
        
         
         var compcode =  document.getElementById("hiddencomcode").value;
        document.getElementById("divexcutive").style.display="block";
        
       
        
        document.getElementById('divexcutive').style.top=320+ "px" ;
        document.getElementById('divexcutive').style.left=480+ "px";
       

       
        document.getElementById('istexcutive').focus();
       
        
       
         ad_rep_roapproval_detail.fillF2_Creditexecutive(compcode,client, bindexcutive_callback)
         }
         }
          //==============add for enter===============
    var evtobj=window.event? window.event : event       
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("txtclient")!=null)
            document.getElementById("txtclient").focus();
         return false;        
    }
   
}
function bindexcutive_callback(res)
{


     ds =res.value;
     document.getElementById("istexcutive").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
     {
        var pkgitem = document.getElementById("istexcutive");
        pkgitem.options.length = 0;
        pkgitem.options[0]=new Option("-Select Client-","0");
        pkgitem.options.length = 1;
       
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Exec_name+ "("+ ds.Tables[0].Rows[i].Exe_no + ")",ds.Tables[0].Rows[i].Exe_no);
        pkgitem.options.length;
        }
     }
     
       document.getElementById("divexcutive").style.display="block";
     document.getElementById('istexcutive').focus();
     return false;
}
function onclickexcutive(event)
{
var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
     
            if(document.activeElement.id=="istexcutive")
            {        
          
                if(document.getElementById('istexcutive').value=="0")
                {
                alert("Please slect Client");
                return false;
                }     
                var page=document.getElementById('istexcutive').value;
                agencycodeglo=page;               
                if(browser!="Microsoft Internet Explorer")
                {              
                    for(var k=0;k <= document.getElementById("istexcutive").length-1;k++)
                    {                      
                        var abc=document.getElementById('istexcutive').options[k].textContent;
                        if(document.getElementById('istexcutive').options[k].value==page)
                        { 
                            var abc=document.getElementById('istexcutive').options[k].textContent;
                            var allvalues=document.getElementById('istexcutive').options[k].value;
                            var splitvalue= allvalues.split("-");
                            var fival = abc.split("(");
                            document.getElementById('txtexecname').value= abc;
                           savemainagcode = splitvalue[0];
                           savemainagsubcode = splitvalue[1];
                           document.getElementById("hiddenexcutivecode2").value=savemainagcode;
                       
                           var hdsAgcode=savemainagcode+savemainagsubcode;
                           document.getElementById("hiddenexcutivecode").value=hdsAgcode;
                           var ag11 = abc.split("(")
                            document.getElementById("txtexecname").focus();
                           break;
                        }
                    }
                }
                else
                {
                    for(var k=0;k <= document.getElementById("istexcutive").length-1;k++)
                    {
                        if(document.getElementById('istexcutive').options[k].value==page)
                        {
                            var abc=document.getElementById('istexcutive').options[k].innerText;
                            var allvalues=document.getElementById('istexcutive').options[k].value;
                            var splitvalue= allvalues.split("-");
                            var fival = abc.split("(");
                            document.getElementById('txtexecname').value= abc;
                           savemainagcode = splitvalue[0];
                           savemainagsubcode = splitvalue[1];
                           document.getElementById("hiddenexcutivecode2").value=savemainagcode;
                       
                           var hdsAgcode=savemainagcode+savemainagsubcode;
                           document.getElementById("hiddenexcutivecode").value=hdsAgcode;
                           var ag11 = abc.split("(")
                            document.getElementById("txtexecname").focus();
                           break;
                          }
                    }
                }
                document.getElementById("divexcutive").style.display='none';
                return false;
                }
    }
    else if (key==27)
    {
    document.getElementById("divexcutive").style.display='none';
     document.getElementById("txtexecname").focus();
    }
}
function forreport()
  {
      var center = document.getElementById("drprevenu").value;
    var a= document.getElementById('drprevenu').selectedIndex;
    var center_name= document.getElementById('drprevenu').options[a].text;
    var fromdate = document.getElementById("txtfrmdate").value;
    var todate = document.getElementById("txttodate1").value;
   var branch = document.getElementById("drpbranch").value;
    var b= document.getElementById('drpbranch').selectedIndex;
    var branch_name= document.getElementById('drpbranch').options[b].text;
    var  status = document.getElementById("dppstatus").value;
      var  pdate_flag  = document.getElementById("drpbasedon").value;
    var  view  = document.getElementById("drpadate").value;
    var agencycode=document.getElementById("hiddenagencycode").value;
    var client=document.getElementById("hiddenclientcode2").value;
    var excutive=document.getElementById("hiddenexcutivecode2").value;
    var alrt;
    alrt=document.getElementById('lbDateFrom').innerText;
   

    
     if(document.getElementById("txtfrmdate").value=="")
    {
        alert("please select from date");
        document.getElementById("txtfrmdate").focus();
        return false;
    }
   
    if(document.getElementById("txttodate1").value=="")
    {
        alert("please select to date");
        document.getElementById("txttodate1").focus();
        return false;
    }
    

     window.open ("ad_rep_roapproval_detail_view.aspx?center="+center+"&center_name="+ center_name +"&fromdate="+ fromdate+"&todate="+ todate+"&branch="+ branch+"&branch_name="+ branch_name+"&status="+ status+"&pdate_flag="+ pdate_flag+"&view="+ view+ "&agencycode="+agencycode +"&client="+client+"&excutive="+excutive);
    return false;
  
   }
    function printreport()
{
    
  window.print();
  document.getElementById("btnPrint").style.display='none';
 
  return false;
}
  