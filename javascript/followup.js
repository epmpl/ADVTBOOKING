var browser=navigator.appName;

function formexit()
{
if (confirm("Do you want to skip this page"))
{
window.close();
}
return false;
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
        
       
        
        document.getElementById('divagency').style.top=160+ "px" ;
        document.getElementById('divagency').style.left=360+ "px";
        var dateformat = "'dd/mm/yyyy'";

       var ret=document.getElementById('txtagency').value

        document.getElementById('lstagency').focus();
       
        
       
         followup.fill_agency(compcode,'',dateformat,extra1,extra2, bindcity_callback)
         }
         }
          //==============add for enter===============
    if(key==13)
    {
        if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
            key=13;
            return key;

        }
         else
        {
            key=9;
            return key;
            return false;
        }
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
function mandat()
{
//refreshControl();
        if(document.getElementById('txtfrmdate').value=="")
            {

                alert('Please Enter  From Date');
                document.getElementById('txtfrmdate').focus();
                return false;

            }
        if(document.getElementById('txttodate1').value=="")
            {

                alert('Please Enter  To Date');
                document.getElementById('txttodate1').focus();
                return false;

            }
//            document.getElementById('btnsave1').disabled=true;
//            document.getElementById('txtremarks').disabled=true;
//            document.getElementById('txtremarks').value="";
//            document.getElementById('btnsub').disabled=true;
}  
var glo_amt

function Selectrow(ab)
 {
    var id = ab;
//        if (flag != "Y" && flag != "N") {
//            document.getElementById('btnsave1').disabled = false;
//            document.getElementById('txtremarks').disabled = false;
//        }
//        else {
//            document.getElementById('btnsave1').disabled = true;
//            document.getElementById('txtremarks').disabled = true;
//        }  
//        
    if(id=="DataGrid1__CheckBox_Header")
    {
    var j;
    var i = document.getElementById("DataGrid1").rows.length - 1;
        if (document.getElementById(id).checked == true) 
        {
            for (j = 0; j < i; j++) 
            {
                var str = "DataGrid1__CheckBox1" + j;
                document.getElementById(str).checked = true;
            }
        }
        else 
        {
            for (j = 0; j < i; j++) 
            {
                var str = "DataGrid1__CheckBox1" + j;
                document.getElementById(str).checked = false;
            }

        }
    
    }
    else
    {
    if (document.getElementById(id).checked == false) 
    {
        document.getElementById(ab).checked = true;
    }
    
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
        
       
        
        document.getElementById('divclient').style.top=160+ "px" ;
        document.getElementById('divclient').style.left=360+ "px";
       

       
        document.getElementById('lstclient').focus();
       
        
       
         followup.fillF2_Creditclient(compcode,client, bindclient_callback)
         }
         }
          //==============add for enter===============
    if(key==13)
    {
        if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
            key=13;
            return key;

        }
         else
        {
            key=9;
            return key;
            return false;
        }
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
function  report()
{

      
      var compcode = document.getElementById("hiddencomcode").value;
   var agency = document.getElementById("hiddenagencycode2").value;
    var client = document.getElementById("hiddenclientcode2").value;
  
    var fdate = document.getElementById("txtfrmdate").value;
    var tdate = document.getElementById("txttodate1").value;
  
  
   
    
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
    
   
   var view = document.getElementById("DrpDestinationType").value;
  
    window.open ("followupreport.aspx?compcode="+compcode+"&agency="+ agency +"&client="+ client+ "&fdate="+fdate + "&tdate="+tdate+"&view="+view);
    return false;
  
}

function savecomment() 
{
    var testchkbox = "false";

    var cioid = "";
    var i = document.getElementById("DataGrid1").rows.length - 1;
    for (j = 0; j < i; j++) 
    {
        var str = "DataGrid1__CheckBox1" + j;
        var str1 = "cio" + j;
        if (document.getElementById(str).checked == true) {
            if (cioid == "")
             if(browser!="Microsoft Internet Explorer")
                { 
                 cioid = document.getElementById(str1).innerHTML;
            
                }
                else
                {
                cioid = document.getElementById(str1).value;
                }
            else
              if(browser!="Microsoft Internet Explorer")
                { 
                   cioid = cioid + "," + document.getElementById(str1).innerHTML;
          
                }
                else
                {
                cioid = cioid + "," + document.getElementById(str1).value;
                }
                testchkbox = "true"
            }
        }
          document.getElementById("hiddenbookingid").value = cioid;
   var idno=  document.getElementById("hiddenbookingid").value ;

     var agency = document.getElementById("hiddenagencycode2").value;
    var client = document.getElementById("hiddenclientcode2").value;
     var fdate = document.getElementById("txtfrmdate").value;
    var tdate = document.getElementById("txttodate1").value;
 
      window.open ("followupmail.aspx?idno="+idno+"&agency="+ agency +"&client="+ client+ "&fdate="+fdate + "&tdate="+tdate);
    return false;

   
   
}



function enable() {

    document.getElementById('btnremainder').disabled = false;
    document.getElementById('btnreport').disabled = false;
    document.getElementById('DrpDestinationType').disabled = false;

}

function alert1() {

    alert('There is no data available ');

}

         