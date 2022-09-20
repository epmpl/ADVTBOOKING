// JScript File

var agencycodeglo;

function bindagencyname_callback(response)
{       
    ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    pkgitem.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].sub_agency_code);
        
       pkgitem.options.length;
       
    }
    }
    document.getElementById('txtagency').value="";
    document.getElementById("lstagency").value="0";
    document.getElementById("lstagency").focus();
     return false;
}

function tabvalue(id)
{
if(document.getElementById('hiddenquery').value=="query")
{
if(event.keyCode==113)  
{
 if(document.activeElement.id=="txtagenname")
    {
        document.getElementById("divagency").style.display="block";
        
//        document.getElementById('divagency').style.top=parseInt(document.getElementById('txtagenname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen3').offsetTop) + parseInt(document.getElementById('frsttd').offsetTop) + parseInt(document.getElementById('td3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6;
document.getElementById('divagency').style.top=parseInt(document.getElementById('txtagenname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen3').offsetTop) + parseInt(document.getElementById('td3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 18;
        
        document.getElementById('divagency').style.left=parseInt(document.getElementById('txtagenname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen3').offsetLeft) + parseInt(document.getElementById('frsttd').offsetLeft) + parseInt(document.getElementById('td3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 70;
        Agent_master.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtsagencycode').value,bindagencyname_callback);
        
    }
//    else if(document.activeElement.id=="txtclient")
//    {
//        document.getElementById("divclient").style.display="block";
//        document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6;
//        document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9;
//        Booking_master.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,bindclientname_callback);
//    }

}

else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
{
//alert(event.shiftKey);
//if(document.activeElement.id=="lstclient")
//    {
//       if(document.getElementById('lstclient').value=="0")
//        {
//        alert("Please select the client");
//        return false;
//        }
//        document.getElementById("divclient").style.display="none";
//        //alert(document.getElementById('lstagency').value);
//        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
//        address and if 0 than agency name and address
//        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
//     
//        var page=document.getElementById('lstclient').value;
//       
//         var xml = new ActiveXObject("Microsoft.XMLHTTP");
//         xml.Open( "GET","AgencyNameList.aspx?page="+page+"&value=1", false );
//         xml.Send();
//         var id=xml.responseText;
//         
//         var split=id.split("+");
//         var namecode=split[0];
//         var add=split[1];

//        
//        document.getElementById('txtclient').value=namecode;
//        document.getElementById('txtclientadd').value=add;
//        document.getElementById('txtclientadd').focus();
//        
//        //document.getElementById('txtagencyaddress').focus();
//        
//        return false;
//    }
    if(document.activeElement.id=="lstagency")
    {
    if(document.getElementById('lstagency').value=="0")
        {
        alert("Please select the agency");
        return false;
        }
        document.getElementById("divagency").style.display="none";
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
        var page=document.getElementById('lstagency').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","AgencyNameList.aspx?page="+page+"&value=0", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var code=split[1];
         var agenadd1=split[2];
         var agenadd2=split[3];
         var agenadd3=split[4];
        
         
        
        document.getElementById('txtagenname').value=nameagen;
        document.getElementById('txtadd').value=agenadd1;
        document.getElementById('txtaddress1').value=agenadd2;
        document.getElementById('txtaddress2').value=agenadd3;
        document.getElementById('drpagetyp').focus();
        
        
//        Agent_master.SubAgencyBind(page,document.getElementById('hiddencompcode').value,"0",call_bindagsub);
        return false;
    }
    
    
    else if(document.activeElement.type=="button" || document.activeElement.type=="submit" )
    {
  
    event.keyCode=13;
    return event.keyCode;

    }
    else
    {
            if(event.shiftKey==false)
            {
            event.keyCode=9;
            return event.keyCode;
            }
    
    }
}
else if(event.shiftKey==true && event.keyCode==9)
{
 
 
}
else if((event.keyCode==9) && (document.activeElement.type=="button" || document.activeElement.type=="submit"))      
{   
 event.keyCode=9;
 return event.keyCode;  
}
}
else
{
    if(event.keyCode==13)
    {
        if(document.activeElement.id==id)
        {
          if(document.getElementById('btnSave').disabled==false)
          {
document.getElementById('btnSave').focus();
event.keyCode=13;
return event.keyCode;

             }
            return;

        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
        {
        event.keyCode=13;
        return event.keyCode;

        }
        else
        {
        event.keyCode=9;
        return event.keyCode;
        }
    }
  }
}