
var browser=navigator.appName;
function formexit()
{
if (confirm("Do you want to skip this page"))
{
window.close();
}
return false;
}
function forreport()
  {
      var branch = document.getElementById("dpd_branch").value;
    var a= document.getElementById('dpd_branch').selectedIndex;
    var branch_name= document.getElementById('dpd_branch').options[a].text;
    var fromdate = document.getElementById("txtfrmdate").value;
    var todate = document.getElementById("txttodate1").value;
   var padtype = document.getElementById("drpadtype").value;
    var b= document.getElementById('drpadtype').selectedIndex;
    var padtype_name= document.getElementById('drpadtype').options[b].text;
    var  puomcode = document.getElementById("drpuom").value;
    var c= document.getElementById('drpuom').selectedIndex;
    var  puomcode_name= document.getElementById('drpuom').options[c].text;
    var  pdate_flag  = document.getElementById("drpadate").value;
    var d= document.getElementById('drpadate').selectedIndex;
    var  pdateflag_name= document.getElementById('drpadate').options[d].text;
    
    var alrt;
    alrt=document.getElementById('lbDateFrom').innerText;
   
//    if(alrt.indexOf('*')>=0)
//    {
//        if(document.getElementById('txtfrmdate').value=="" || document.getElementById('txtfrmdate').value=="0")
//        {
//            //alrt.Replace("*","");
//            var abc=alrt.replace("*","");
//            alert('Please Enter '+ abc);
//            document.getElementById('txtfrmdate').focus();
//            return false;
//        }
//    } var alrt;
//    alrt=document.getElementById('lbToDate').innerText;
//   
//    if(alrt.indexOf('*')>=0)
//    {
//        if(document.getElementById('txttodate1').value=="" || document.getElementById('txttodate1').value=="0")
//        {
//            //alrt.Replace("*","");
//            var abc=alrt.replace("*","");
//            alert('Please Enter '+ abc);
//            document.getElementById('txttodate1').focus();
//            return false;
//        }
//    }
    
    
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
    

   var view = document.getElementById("dpaddtype").value;
    window.open ("rptunregisteredclient.aspx?branch="+branch+"&branch_name="+ branch_name +"&padtype="+ padtype+"&padtype_name="+ padtype_name+"&puomcode="+ puomcode+"&puomcode_name="+ puomcode_name+"&pdate_flag="+ pdate_flag+"&pdateflag_name="+ pdateflag_name+"&fromdate="+ fromdate+ "&todate="+todate +"&view="+view);
    return false;
  
   }
   function Selectrow(ab,flag)
    {
    var id = ab;
     
    
    if(id=="DataGrid1__CheckBox_Header")
    {
    var j;
    var i = document.getElementById("DataGrid1").rows.length - 1;
        if (document.getElementById(id).checked == true) {
            for (j = 0; j < i; j++)
             {
                var str = "DataGrid1__CheckBox1" + j;
                document.getElementById(str).checked = true;
            }
        }
        else {
            for (j = 0; j < i; j++) {
                var str = "DataGrid1__CheckBox1" + j;
                document.getElementById(str).checked = false;
            }

        }
    
    }
    else
    {
    if (document.getElementById(id).checked == false) {
        document.getElementById(ab).checked = false;
    }
   }

}
function openbooking1()
{

 var cioid = "";
    var i = document.getElementById("DataGrid1").rows.length - 1;
    for (j = 0; j < i; j++) 
    {
        var str = "DataGrid1__CheckBox1" + j;
        var str1 = "cio" + j;
        if (document.getElementById(str).checked == true) 
        {
            if (cioid == "")
             if(browser!="Microsoft Internet Explorer")
                { 
                   cioid = "'"+document.getElementById(str1).textContent+ "'";
          
                }
                else
                {
                cioid = "'"+document.getElementById(str1).value+ "'";
                }
            else
              if(browser!="Microsoft Internet Explorer")
                { 
              cioid = cioid + "," +"'" +document.getElementById(str1).textContent+"'";
              
                }
                else
                {
                cioid = cioid + "," +"'" +document.getElementById(str1).value+"'";
                }
                testchkbox = "true"
            }
        }
//cioid = cioid +"'"
  var branch = document.getElementById("dpd_branch").value;
    var a= document.getElementById('dpd_branch').selectedIndex;
    var branch_name= document.getElementById('dpd_branch').options[a].text;
    var fromdate = document.getElementById("txtfrmdate").value;
    var todate = document.getElementById("txttodate1").value;
   var padtype = document.getElementById("drpadtype").value;
    var b= document.getElementById('drpadtype').selectedIndex;
    var padtype_name= document.getElementById('drpadtype').options[b].text;
    var  puomcode = document.getElementById("drpuom").value;
    var c= document.getElementById('drpuom').selectedIndex;
    var  puomcode_name= document.getElementById('drpuom').options[c].text;
    var  pdate_flag  = document.getElementById("drpadate").value;
    var d= document.getElementById('drpadate').selectedIndex;
    var  pdateflag_name= document.getElementById('drpadate').options[d].text;
    var  registertype  = document.getElementById("drpregister").value;
    var alrt;
    alrt=document.getElementById('lbDateFrom').innerText;
   
//    if(alrt.indexOf('*')>=0)
//    {
//        if(document.getElementById('txtfrmdate').value=="" || document.getElementById('txtfrmdate').value=="0")
//        {
//            //alrt.Replace("*","");
//            var abc=alrt.replace("*","");
//            alert('Please Enter '+ abc);
//            document.getElementById('txtfrmdate').focus();
//            return false;
//        }
//    } var alrt;
//    alrt=document.getElementById('lbToDate').innerText;
//   
//    if(alrt.indexOf('*')>=0)
//    {
//        if(document.getElementById('txttodate1').value=="" || document.getElementById('txttodate1').value=="0")
//        {
//            //alrt.Replace("*","");
//            var abc=alrt.replace("*","");
//            alert('Please Enter '+ abc);
//            document.getElementById('txttodate1').focus();
//            return false;
//        }
//    }
//    
    
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
    

   var view = document.getElementById("dpaddtype").value;
   //alert(cioid);
    window.open ("rptunregisteredclient.aspx?branch="+branch+"&branch_name="+ branch_name +"&padtype="+ padtype+"&padtype_name="+ padtype_name+"&puomcode="+ puomcode+"&puomcode_name="+ puomcode_name+"&pdate_flag="+ pdate_flag+"&pdateflag_name="+ pdateflag_name+"&cioid="+ cioid+ "&fromdate="+ fromdate+ "&todate="+todate +"&view="+view+"&registertype="+registertype);
    return false;
  


    
}
 function printreport()
{
    
  window.print();
  document.getElementById("btnPrint").style.display='none';
 
  return false;
}
  