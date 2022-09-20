var browser=navigator.appName;
var activeid;

function bindQBC()
{
var userid=document.getElementById("hiddenuserid").value;
rpt_auditor_comment.fillQBC(userid,bindQBC_callback);
}
function bindQBC_callback(response)
{
   
    var ds=response.value;
    
   var pkgitem = document.getElementById("drpbranch");
 pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Branch--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].BRANCH_CODE);
        
       pkgitem.options.length;
    }
    }
}

function forreport()
  {
     var fromdate = document.getElementById("txtfrmdate").value;
    var todate = document.getElementById("txttodate1").value;
   var center = document.getElementById("drpcenter").value;
    var b= document.getElementById('drpcenter').selectedIndex;
    var center_name= document.getElementById('drpcenter').options[b].text;
    var  branch = document.getElementById("drpbranch").value;
  var c= document.getElementById('drpbranch').selectedIndex;
   var  branch_name= document.getElementById('drpbranch').options[c].text;
    var  adtype  = document.getElementById("drpadtype").value;
    var d= document.getElementById('drpadtype').selectedIndex;
  var  adtype_name= document.getElementById('drpadtype').options[d].text;
  var bookingtype= document.getElementById('drpdateflag').value;

//       var alrt;
//    alrt=document.getElementById('lbDateFrom').innerText;
//   
//    if(alrt.indexOf('*')>=0)
//    {
//        if(document.getElementById('txtfrmdate').value=="" || document.getElementById('txtfrmdate').value=="0")
//        {
//        
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
//            
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
    window.open ("rpt_auditor_commentprint.aspx?fromdate="+ fromdate+ "&todate="+todate +"&center="+center +"&center_name="+center_name +"&branch="+branch +"&branch_name="+branch_name +"&adtype_name="+adtype_name +"&adtype="+adtype+"&bookingtype="+bookingtype+"&view="+view);
    return false;
  
   }
   
      function formexit()
{
if (confirm("Do you want to skip this page"))
{
window.close();
}
return false;
}
   function printreport()
{
    
  window.print();
  document.getElementById("btnPrint").style.display='none';
             
  return false;
}