var z=0;

//this flag is for permission
var flag="";
var hiddentext;
var auto="";
var hiddentext1="";
var hiddentext2="";
var dspubtypemaster;

var glapubtypecode;
var glapubtypename;
var glaAlias;

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;
var activeid;



function ExitClick2()
{
if(confirm("Do You Want To Skip This Page"))
{
  window.close();
   return false;
}
    return false;
}



  function cancelClick()
{ 
document.getElementById('ddlDays').value="0";
document.getElementById('drpcenter').value="0";
document.getElementById('drpadtype').value="0";
   
if(document.getElementById('GridView1') !=null)
{
 document.getElementById('GridView1').style.display="none";
			       
}
return false;


}

function save ()
{

var days=document.getElementById('ddlDays').value;
if(document.getElementById('ddlDays').value=="0")
{
alert ("Please select Days");
document.getElementById("ddlDays").focus();
return false;
}

var center=document.getElementById('drpcenter').value;
if(document.getElementById('drpcenter').value=="0")
{
alert ("Please select Center");
document.getElementById("drpcenter").focus();
 
return false;
}

var adtype=document.getElementById('drpadtype').value;
{
if(document.getElementById('drpadtype').value=="0")
{
alert ("Please select Adtype");
document.getElementById("drpadtype").focus();
return false;
}
}
if(document.getElementById('GridView1') ==null)
{
 alert ("Please select Cat_seq");
  document.getElementById("btnview").focus();
  
return false;
			       
}
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var datformate=document.getElementById('hiddenauto').value;
var flag="Y";

var extra1="";
var extra2="";
var extra3="";
var extra4="";
var extra5="";

 for(var i=1; i<document.getElementById("GridView1").rows.length-1;i++)
        {
         if(browser!="Microsoft Internet Explorer")
             {              
             
       var catcode=document.getElementById("GridView1").rows[i].cells[1].textContent;
     
        var ins_upd=document.getElementById("GridView1").rows[i].cells[3].textContent;
       
  }
  else
       {
          var catcode=document.getElementById("GridView1").rows[i].cells[1].outerText;
        var ins_upd=document.getElementById("GridView1").rows[i].cells[3].outerText;
    
        }
          
       var cat_seqno =parseInt (document.getElementById('txtindco_'+(i-1)).value);
          cat_seq_no.save(compcode,center,days,adtype,catcode,cat_seqno,userid,flag,ins_upd,datformate,extra1,extra2,extra3,extra4,extra5);                            
           
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


