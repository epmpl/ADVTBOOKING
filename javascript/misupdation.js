var browser=navigator.appName;
var activeid;
function bindcategory_package()
{
bindcategory();
}

function bindcategory()
{
 var comp_code=document.getElementById('hiddencompcode').value;
misupdation.getcategory(comp_code,document.getElementById('drpadtype').value,bindcategory_NEW);
}
function bindcategory_NEW(response)
{
    //alert(response.value);
    var ds=response.value;
    agcatby = document.getElementById("drprate");
 agcatby.options.length = 0; 
    agcatby.options[0]=new Option("--Select Category--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    var j=1;
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code,ds.Tables[0].Rows[i].Adv_Cat_Code);   
                           
       j++;
       
    }
    }
     document.getElementById("drprate").focus();
}
function catexitclick1()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}

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
misupdation.fillQBC(userid,bindQBC_callback);
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
        
       
        
        document.getElementById('divagency').style.top=100+ "px" ;
        document.getElementById('divagency').style.left=200+ "px";
        var dateformat = "'dd/mm/yyyy'";

       var ret=document.getElementById('txtagency').value

        document.getElementById('lstagency').focus();
       
        
       
         misupdation.fill_agency(compcode,'',dateformat,extra1,extra2, bindcity_callback)
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
        
       
        
        document.getElementById('divclient').style.top=100+ "px" ;
        document.getElementById('divclient').style.left=540+ "px";
       

       
        document.getElementById('lstclient').focus();
       
        
       
         misupdation.fillF2_Creditclient(compcode,client, bindclient_callback)
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
        
       
        
        document.getElementById('divexcutive').style.top=100+ "px" ;
        document.getElementById('divexcutive').style.left=540+ "px";
       

       
        document.getElementById('istexcutive').focus();
       
        
       
         misupdation.fillF2_Creditexecutive(compcode,client, bindexcutive_callback)
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

function fillret(event)
{ 

     var key=event.keyCode?event.keyCode:event.which;
  
  
    if(key==113) 
    {
    
    
        if(document.activeElement.id=="txtret")
        {
        var client=document.getElementById('txtret').value;
       
       client =client.toUpperCase();
        
        document.getElementById('istret').value="";
         
        
         
         var compcode =  document.getElementById("hiddencomcode").value;
        document.getElementById("divret").style.display="block";
        
       
        
        document.getElementById('divret').style.top=100+ "px" ;
        document.getElementById('divret').style.left=100+ "px";
       

       
        document.getElementById('istret').focus();
       
        
       
         misupdation.fillF2_Creditretainer(compcode,client, bindret_callback)
         }
         }
          //==============add for enter===============
   var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("drprevenu")!=null)
            document.getElementById("drprevenu").focus();
         return false;        
    }
   
}
function bindret_callback(res)
{


     ds =res.value;
     document.getElementById("istret").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
     {
        var pkgitem = document.getElementById("istret");
        pkgitem.options.length = 0;
        pkgitem.options[0]=new Option("-Select Client-","0");
        pkgitem.options.length = 1;
       
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name+ "("+ ds.Tables[0].Rows[i].Retain_Code + ")",ds.Tables[0].Rows[i].Retain_Code);
        pkgitem.options.length;
        }
     }
     
       document.getElementById("divret").style.display="block";
     document.getElementById('istret').focus();
     return false;
}
function onclickret(event)
{
var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
     
            if(document.activeElement.id=="istret")
            {        
          
                if(document.getElementById('istret').value=="0")
                {
                alert("Please slect Client");
                return false;
                }     
                var page=document.getElementById('istret').value;
                agencycodeglo=page;               
                if(browser!="Microsoft Internet Explorer")
                {              
                    for(var k=0;k <= document.getElementById("istret").length-1;k++)
                    {                      
                        var abc=document.getElementById('istret').options[k].textContent;
                        if(document.getElementById('istret').options[k].value==page)
                        { 
                            var abc=document.getElementById('istret').options[k].textContent;
                            var allvalues=document.getElementById('istret').options[k].value;
                            var splitvalue= allvalues.split("-");
                            var fival = abc.split("(");
                            document.getElementById('txtret').value= abc;
                           savemainagcode = splitvalue[0];
                           savemainagsubcode = splitvalue[1];
                           document.getElementById("hiddenexcutivecode2").value=savemainagcode;
                       
                           var hdsAgcode=savemainagcode+savemainagsubcode;
                           document.getElementById("hiddenexcutivecode").value=hdsAgcode;
                           var ag11 = abc.split("(")
                            document.getElementById("txtret").focus();
                           break;
                        }
                    }
                }
                else
                {
                    for(var k=0;k <= document.getElementById("istret").length-1;k++)
                    {
                        if(document.getElementById('istret').options[k].value==page)
                        {
                            var abc=document.getElementById('istret').options[k].innerText;
                            var allvalues=document.getElementById('istret').options[k].value;
                            var splitvalue= allvalues.split("-");
                            var fival = abc.split("(");
                            document.getElementById('txtret').value= abc;
                           savemainagcode = splitvalue[0];
                           savemainagsubcode = splitvalue[1];
                           document.getElementById("hiddenretcode2").value=savemainagcode;
                       
                           var hdsAgcode=savemainagcode+savemainagsubcode;
                           document.getElementById("hiddenretcode").value=hdsAgcode;
                           var ag11 = abc.split("(")
                            document.getElementById("txtret").focus();
                           break;
                          }
                    }
                }
                document.getElementById("divret").style.display='none';
                return false;
                }
    }
    else if (key==27)
    {
    document.getElementById("divret").style.display='none';
     document.getElementById("txtret").focus();
    }
}
function fillproduct(event)
{
  var key=event.keyCode?event.keyCode:event.which;
   var id=document.activeElement.id;
        activeid=id;
       
    if(key==113) 
    {
        document.getElementById('istproduct').value="";
        //var id=document.activeElement.id;
        //activeid=id;
        var product=document.getElementById(id).value;
        product =product.toUpperCase(); 
         var compcode =  document.getElementById("hiddencomcode").value;
         
        document.getElementById("divproduct").style.display="block";
        
        aTag = eval(document.getElementById(activeid))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        document.getElementById('divproduct').style.top = document.getElementById(activeid).offsetTop + toppos + "px";
        document.getElementById('divproduct').style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";
        
        if(activeid.indexOf("txtin_")>=0){
             var res1=misupdation.bindindustry(compcode,product);
             bindproduct_callback(res1,"Industry")
         }
        else if(activeid.indexOf("txtp_")>=0){
        var index=activeid.split('_')[1];
            if(document.getElementById("txtin_"+index).value==" "  || document.getElementById("txtin_"+index).value=="")
            {
            document.getElementById("txtindco_"+index).value="";
                  
            alert("Please Select Industry by F2.");
             document.getElementById("divproduct").style.display='none';
   
            return false;
            }
            var ind_code=document.getElementById("txtindco_"+index).value;
             var res1=misupdation.bindProduct(compcode,product,ind_code);
             bindproduct_callback(res1,"Product")
         }
         else if(activeid.indexOf("txtbn_")>=0){
            var index=activeid.split('_')[1];
            if(document.getElementById("txtp_"+index).value==" "  || document.getElementById("txtp_"+index).value=="")
            {
             document.getElementById("txtpcod_"+index).value="";
           
            alert("Please Select Product by F2.");
               document.getElementById("divproduct").style.display='none';
               return false;
            }
             var res1=misupdation.bindbrand(compcode,document.getElementById("txtpcod_"+index).value);
             bindproduct_callback(res1,"Brand")
         }
         else if(activeid.indexOf("txtvn_")>=0)
         {
         var index=activeid.split('_')[1];
            if(document.getElementById("txtbn_"+index).value==" "  || document.getElementById("txtbn_"+index).value=="")
            {
             document.getElementById("txtbc_"+index).value="";
           
            alert("Please Select Brand by F2.");
               document.getElementById("divproduct").style.display='none';
               return false;
            }
           
            var res1=misupdation.bindvarant(compcode,document.getElementById("txtbc_"+index).value);
             bindproduct_callback(res1,"Varient")
         }
         else{
         //return false;
         }
          document.getElementById('istproduct').focus();
         }
    
       
     
     if(activeid.indexOf("txtin_")>=0)
     {
             //==============add for enter===============
   var evtobj=window.event? window.event : event         
    if(evtobj.keyCode==40 )
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])+1;
        if(document.getElementById("txtin_"+next_id)!=null)
            document.getElementById("txtin_"+next_id).focus();
         return false;        
    }
    else if(evtobj.keyCode==38)
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])-1;
        if(document.getElementById("txtin_"+next_id)!=null)
            document.getElementById("txtin_"+next_id).focus();
         return false;       
    } 
    } 
    else if (activeid.indexOf("txtp_")>=0)
    {
    var evtobj=window.event? window.event : event       
    if(evtobj.keyCode==40 )
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])+1;
        if(document.getElementById("txtp_"+next_id)!=null)
            document.getElementById("txtp_"+next_id).focus();
         return false;        
    }
    else if(evtobj.keyCode==38)
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])-1;
        if(document.getElementById("txtp_"+next_id)!=null)
            document.getElementById("txtp_"+next_id).focus();
         return false;       
    }
    }  
    else if (activeid.indexOf("txtbn_")>=0)
    {
    var evtobj=window.event? window.event : event     
    if(evtobj.keyCode==40 )
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])+1;
        if(document.getElementById("txtbn_"+next_id)!=null)
            document.getElementById("txtbn_"+next_id).focus();
         return false;        
    }
    else if(evtobj.keyCode==38)
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])-1;
        if(document.getElementById("txtbn_"+next_id)!=null)
            document.getElementById("txtbn_"+next_id).focus();
         return false;       
    }
    } 
     else if (activeid.indexOf("txtvn_")>=0)
    {
    var evtobj=window.event? window.event : event       
    if(evtobj.keyCode==40 )
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])+1;
        if(document.getElementById("txtvn_"+next_id)!=null)
            document.getElementById("txtvn_"+next_id).focus();
         return false;        
    }
    else if(evtobj.keyCode==38)
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])-1;
        if(document.getElementById("txtvn_"+next_id)!=null)
            document.getElementById("txtvn_"+next_id).focus();
         return false;       
    }
    } 
    if (activeid.indexOf("txtin_")>=0)
    {
    var evtobj=window.event? window.event : event      
    if(evtobj.keyCode==13 )
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1]);
        if(document.getElementById("txtp_"+next_id)!=null)
            document.getElementById("txtp_"+next_id).focus();
         return false;        
    }
    }
     if (activeid.indexOf("txtp_")>=0)
    {
    var evtobj=window.event? window.event :event        
    if(evtobj.keyCode==13 )
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1]);
        if(document.getElementById("txtbn_"+next_id)!=null)
            document.getElementById("txtbn_"+next_id).focus();
         return false;        
    }
    }
      if (activeid.indexOf("txtbn_")>=0)
    {
    var evtobj=window.event? window.event :event       
    if(evtobj.keyCode==13 )
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1]);
        if(document.getElementById("txtvn_"+next_id)!=null)
            document.getElementById("txtvn_"+next_id).focus();
         return false;        
    }
    }
        if (activeid.indexOf("txtvn_")>=0)
    {
    var evtobj=window.event? window.event : event       
    if(evtobj.keyCode==13 )
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])+1;
        if(document.getElementById("txtin_"+next_id)!=null)
            document.getElementById("txtin_"+next_id).focus();
         return false;        
    }
    }
}
 function bindproduct_callback(res,type)
{


     ds =res.value;
     document.getElementById("istproduct").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
     {
        var pkgitem = document.getElementById("istproduct");
        pkgitem.options.length = 0;
        pkgitem.options[0]=new Option("---Select---","0");
        pkgitem.options.length = 1;
       
       if(type == "Product"){
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].prod_desc+ "("+ ds.Tables[0].Rows[i].prod_cat_code + ")",ds.Tables[0].Rows[i].prod_cat_code);
        pkgitem.options.length;
        }
        }
        else if(type == "Brand"){
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
       
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].brand_name+ "("+ ds.Tables[0].Rows[i].brand_code + ")",ds.Tables[0].Rows[i].brand_code);
        pkgitem.options.length;
        }
        }
         else if(type == "Industry"){
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
       
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].industry_name+ "("+ ds.Tables[0].Rows[i].industry_code + ")",ds.Tables[0].Rows[i].industry_code);
        pkgitem.options.length;
        }
        }
        else if(type == "Varient"){
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].varient_name+ "("+ ds.Tables[0].Rows[i].varient_code + ")",ds.Tables[0].Rows[i].varient_code);
        pkgitem.options.length;
        }
        }
     }
     
     document.getElementById("divproduct").style.display="block";
     document.getElementById('istproduct').focus();
     return false;
}

function onclickproduct(event)
{
var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
        if(document.getElementById('istproduct').value=="0")
        {
            alert("Please slect Value.");
            return false;
        }     
        var page=document.getElementById('istproduct').value;
        var fillname;
        var fillcode;
        var fillindname;
        var index=activeid.split('_')[1];
        var abc="";
        if(activeid.indexOf("txtp_")>=0){
            fillname="txtp_"+index;
            fillcode="txtpcod_"+index;
             
         }
         else if(activeid.indexOf("txtbn_")>=0){
            fillname="txtbn_"+index;
            fillcode="txtbc_"+index;
         }
           else if(activeid.indexOf("txtbn_")>=0){
            fillname="txtbn_"+index;
            fillcode="txtbc_"+index;
         }
         else if(activeid.indexOf("txtin_")>=0){
            fillname="txtin_"+index;
            fillcode="txtindco_"+index;
         }
            for(var k=0;k <= document.getElementById("istproduct").length-1;k++)
                    { 
                        if(document.getElementById('istproduct').options[k].value==page)
                        { 
                            if(browser!="Microsoft Internet Explorer")
                                abc=document.getElementById('istproduct').options[k].textContent;
                            else
                                abc=document.getElementById('istproduct').options[k].innerText;
                            var allvalues=document.getElementById('istproduct').options[k].value;
                            var industry=abc.split('(')
                          var abc1=trim(abc);
                             document.getElementById(fillname).value= abc1;
                             document.getElementById(fillcode).value= allvalues;
                               
                        
                         break;
                        }
                }
               
        document.getElementById("divproduct").style.display='none';
          document.getElementById(fillname).focus();
        return false;
    }
    else if (key==27)
    {
    document.getElementById("divproduct").style.display='none';
   
    }
}
function update()
{
  var compcode =  document.getElementById("hiddencomcode").value;
   var index=activeid.split('_')[1];
      
  for(var i=1;i<document.getElementById("GridView1").rows.length-1;i++)
        {
             if(browser!="Microsoft Internet Explorer")
             {              
          
             var idno=document.getElementById("GridView1").rows[i].cells[0].textContent;
             }
             else
             {
               var idno=document.getElementById("GridView1").rows[i].cells[0].outerText;
          
             }
              var product=document.getElementById('txtpcod_'+(i-1)).value;
              var brand=document.getElementById('txtbc_'+(i-1)).value;
          
              var Varient=document.getElementById('txtvc_'+(i-1)).value;
              
            
        
              misupdation.Update(compcode,idno,product,brand,Varient);                            
                     
                        
             }  
             alert('Data Updated Successfully');  
            return false ;       
}
function chk_downkey(e)
{
    var evtobj=window.event? window.event : e         
    if(evtobj.keyCode==40 || evtobj.keyCode==13)
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])+1;
        if(document.getElementById("txtindco_"+next_id)!=null)
            document.getElementById("txtindco_"+next_id).focus();
         return false;        
    }
    else if(evtobj.keyCode==38)
    {
        var next_id=parseInt(document.activeElement.id.split("_")[1])-1;
        if(document.getElementById("txtindco_"+next_id)!=null)
            document.getElementById("txtindco_"+next_id).focus();
         return false;       
    }    
   }


function LTrim( value ) {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}

function enter(event)
{
 var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("txtvalidityfrom")!=null)
            document.getElementById("txtvalidityfrom").focus();
         return false;        
    }
    
   
}
 function enterto(event)
    {
     var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("txttilldate")!=null)
            document.getElementById("txttilldate").focus();
         return false;        
    }
    }
    
    function enterid(event)
    {
     var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("txtcioid")!=null)
            document.getElementById("txtcioid").focus();
         return false;        
    }
    }
  function enterad(event)
    {
     var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("drpadtype")!=null)
            document.getElementById("drpadtype").focus();
         return false;        
    }
    }
      function entercat(event)
    {
     var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("drprate")!=null)
            document.getElementById("drprate").focus();
         return false;        
    }
    } 
      function enterbooktype(event)
    {
     var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("drpbasedon")!=null)
            document.getElementById("drpbasedon").focus();
         return false;        
    }
    }
      function enterpageno(event)
    {
     var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("txtpageno")!=null)
            document.getElementById("txtpageno").focus();
         return false;        
    }
    }
      function enterbuton(event)
    {
     var evtobj=window.event? window.event : event        
    if(evtobj.keyCode==13 )
    {
         if(document.getElementById("btnAdView")!=null)
            document.getElementById("btnAdView").focus();
         return false;        
    }
    }